using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Connection.Configuration;
using Elasticsearch.Net.Connection.RequestHandlers;
using Elasticsearch.Net.Connection.RequestState;
using Elasticsearch.Net.ConnectionPool;
using Elasticsearch.Net.Exceptions;
using Elasticsearch.Net.Providers;
using Elasticsearch.Net.Serialization;
using PurifyNet;
using System.Reflection.TypeExtensions;

namespace Elasticsearch.Net.Connection
{
	public class Transport : ITransport, ITransportDelegator
	{

		protected internal readonly IConnectionConfigurationValues ConfigurationValues;
		protected internal readonly IConnection Connection;
		private readonly IElasticsearchSerializer _serializer;

		private readonly IConnectionPool _connectionPool;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IMemoryStreamProvider _memoryStreamProvider;
		private readonly RequestHandler _requestHandler;
		private readonly RequestHandlerAsync _requestHandlerAsync;

		private DateTime? _lastSniff;

		private readonly int DefaultPingTimeout = 200;

		public IConnectionConfigurationValues Settings { get { return ConfigurationValues; } }
		public IElasticsearchSerializer Serializer { get { return _serializer; } }

		private ITransportDelegator Self { get { return this; } }

		public Transport(
			IConnectionConfigurationValues configurationValues,
			IConnection connection,
			IElasticsearchSerializer serializer,
			IDateTimeProvider dateTimeProvider = null,
			IMemoryStreamProvider memoryStreamProvider = null
			)
		{
			this.ConfigurationValues = configurationValues;
			this.Connection = connection ?? new HttpConnection(configurationValues);
			this._serializer = serializer ?? new ElasticsearchDefaultSerializer();
			this._connectionPool = this.ConfigurationValues.ConnectionPool;

			this._dateTimeProvider = dateTimeProvider ?? new DateTimeProvider();
			this._memoryStreamProvider = memoryStreamProvider ?? new MemoryStreamProvider();

			this._lastSniff = this._dateTimeProvider.Now();

			this.Settings.Serializer = this._serializer;

			this._requestHandler = new RequestHandler(this.Settings, this._connectionPool, this.Connection, this._serializer, this._memoryStreamProvider, this);
			this._requestHandlerAsync = new RequestHandlerAsync(this.Settings, this._connectionPool, this.Connection, this._serializer, this._memoryStreamProvider, this);
			if (this._connectionPool.AcceptsUpdates && this.Settings.SniffsOnStartup)
				Self.SniffClusterState();
		}


		/* PING/SNIFF	*** ********************************************/

		bool ITransportDelegator.Ping(ITransportRequestState requestState)
		{
			var pingTimeout = this.Settings.PingTimeout.GetValueOrDefault(DefaultPingTimeout);
			pingTimeout = requestState.RequestConfiguration != null
				? requestState.RequestConfiguration.ConnectTimeout.GetValueOrDefault(pingTimeout)
				: pingTimeout;
			var requestOverrides = new RequestConfiguration
			{
				ConnectTimeout = pingTimeout,
				RequestTimeout = pingTimeout
			};
			try
			{
				ElasticsearchResponse<Stream> response;
				using (var rq = requestState.InitiateRequest(RequestType.Ping))
				{
					response = this.Connection.HeadSync(requestState.CreatePathOnCurrentNode(""), requestOverrides);
					rq.Finish(response.Success, response.HttpStatusCode);
				}
				if (!response.HttpStatusCode.HasValue || response.HttpStatusCode.Value == -1)
					throw new Exception("ping returned no status code", response.OriginalException);
				if (response.HttpStatusCode == (int)HttpStatusCode.Unauthorized)
					throw new ElasticsearchAuthenticationException(response);
				if (response.Response == null)
					return response.Success;
				using (response.Response)
					return response.Success;
			}
			catch(ElasticsearchAuthenticationException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new PingException(requestState.CurrentNode, e);
			}
		}

		Task<bool> ITransportDelegator.PingAsync(ITransportRequestState requestState)
		{
			var pingTimeout = this.Settings.PingTimeout.GetValueOrDefault(DefaultPingTimeout);
			pingTimeout = requestState.RequestConfiguration != null
				? requestState.RequestConfiguration.ConnectTimeout.GetValueOrDefault(pingTimeout)
				: pingTimeout;
			var requestOverrides = new RequestConfiguration
			{
				ConnectTimeout = pingTimeout,
				RequestTimeout = pingTimeout
			};
			var rq = requestState.InitiateRequest(RequestType.Ping);
			try
			{
				return this.Connection.Head(requestState.CreatePathOnCurrentNode(""), requestOverrides)
					.ContinueWith(t =>
					{
						if (t.IsFaulted)
						{
							rq.Finish(false, null);
							rq.Dispose();
							throw new PingException(requestState.CurrentNode, t.Exception);
						}
						rq.Finish(t.Result.Success, t.Result.HttpStatusCode);
						rq.Dispose();
						var response = t.Result;
						if (!response.HttpStatusCode.HasValue || response.HttpStatusCode.Value == -1)
							throw new PingException(requestState.CurrentNode, t.Exception);
						if (response.HttpStatusCode == (int)HttpStatusCode.Unauthorized)
							throw new ElasticsearchAuthenticationException(response);
						using (response.Response)
							return response.Success;
					});
			}
			catch (ElasticsearchAuthenticationException)
			{
				throw;
			}
			catch (Exception e)
			{
				var tcs = new TaskCompletionSource<bool>();
				var pingException = new PingException(requestState.CurrentNode, e);
				tcs.SetException(pingException);
				return tcs.Task;
			}
		}

		IList<Uri> ITransportDelegator.Sniff(ITransportRequestState ownerState = null)
		{
			var pingTimeout = this.Settings.PingTimeout.GetValueOrDefault(DefaultPingTimeout);
			var requestOverrides = new RequestConfiguration
			{
				ConnectTimeout = pingTimeout,
				RequestTimeout = pingTimeout,
				DisableSniff = true //sniff call should never recurse 
			};

			var requestParameters = new RequestParameters { RequestConfiguration = requestOverrides };
			try
			{

				var path = "_nodes/_all/clear?timeout=" + pingTimeout;
				ElasticsearchResponse<Stream> response;
				using (var requestState = new TransportRequestState<Stream>(this.Settings, requestParameters, "GET", path))
				{
					response = this._requestHandler.Request(requestState);

					//inform the owing request state of the requests the sniffs did.
					if (requestState.RequestMetrics != null && ownerState != null)
					{
						foreach (var r in requestState.RequestMetrics.Where(p => p.RequestType == RequestType.ElasticsearchCall))
							r.RequestType = RequestType.Sniff;


						if (ownerState.RequestMetrics == null) ownerState.RequestMetrics = new List<RequestMetrics>();
						ownerState.RequestMetrics.AddRange(requestState.RequestMetrics);
					}
					if (response.HttpStatusCode.HasValue && response.HttpStatusCode == (int)HttpStatusCode.Unauthorized)
						throw new ElasticsearchAuthenticationException(response);
					if (response.Response == null) 
						return null;

					using (response.Response)
					{
						return Sniffer.FromStream(response, response.Response, this.Serializer);
					}
				}
			}
			catch (ElasticsearchAuthenticationException)
			{
				throw;
			}
			catch (MaxRetryException e)
			{
				throw new MaxRetryException(new SniffException(e));
			}
		}

		void ITransportDelegator.SniffClusterState(ITransportRequestState requestState = null)
		{
			if (!this._connectionPool.AcceptsUpdates)
				return;

			var newClusterState = Self.Sniff(requestState);
			if (!newClusterState.HasAny())
				return;

			this._connectionPool.UpdateNodeList(newClusterState);
			this._lastSniff = this._dateTimeProvider.Now();

		}

		void ITransportDelegator.SniffOnStaleClusterState(ITransportRequestState requestState)
		{
			if (Self.SniffingDisabled(requestState.RequestConfiguration))
				return;

			var sniffLifeSpan = this.ConfigurationValues.SniffInformationLifeSpan;
			var now = this._dateTimeProvider.Now();
			if (requestState.Retried == 0 && this._lastSniff.HasValue &&
				sniffLifeSpan.HasValue && sniffLifeSpan.Value < (now - this._lastSniff.Value))
				Self.SniffClusterState(requestState);
		}

		void ITransportDelegator.SniffOnConnectionFailure(ITransportRequestState requestState)
		{
			if (requestState.SniffedOnConnectionFailure
				|| Self.SniffingDisabled(requestState.RequestConfiguration)
				|| !this.ConfigurationValues.SniffsOnConnectionFault
				|| requestState.Retried != 0) return;

			Self.SniffClusterState(requestState);
			requestState.SniffedOnConnectionFailure = true;
		}

		/* REQUEST STATE *** ********************************************/

		/// <summary>
		/// Returns either the fixed maximum set on the connection configuration settings or the number of nodes
		/// </summary>
		int ITransportDelegator.GetMaximumRetries(IRequestConfiguration requestConfiguration)
		{
			//if we have a request specific max retry setting use that
			if (requestConfiguration != null && requestConfiguration.MaxRetries.HasValue)
				return requestConfiguration.MaxRetries.Value;

			return this.ConfigurationValues.MaxRetries.GetValueOrDefault(this._connectionPool.MaxRetries);
		}

		bool ITransportDelegator.SniffingDisabled(IRequestConfiguration requestConfiguration)
		{
			if (!this._connectionPool.AcceptsUpdates)
				return true;
			if (requestConfiguration == null)
				return false;
			return requestConfiguration.DisableSniff.GetValueOrDefault(false);
		}

		bool ITransportDelegator.SniffOnFaultDiscoveredMoreNodes(ITransportRequestState requestState, int retried, ElasticsearchResponse<Stream> streamResponse)
		{
			if (retried != 0 || streamResponse.SuccessOrKnownError) return false;
			Self.SniffOnConnectionFailure(requestState);
			return Self.GetMaximumRetries(requestState.RequestConfiguration) > 0;
		}

		/// <summary>
		/// Selects next node uri on request state
		/// </summary>
		/// <returns>bool hint whether the new current node needs to pinged first</returns>
		bool ITransportDelegator.SelectNextNode(ITransportRequestState requestState)
		{
			if (requestState.RequestConfiguration != null && requestState.RequestConfiguration.ForceNode != null)
			{
				requestState.Seed = 0;
				return false;
			}
			int initialSeed;
			bool shouldPingHint;
			var baseUri = this._connectionPool.GetNext(requestState.Seed, out initialSeed, out shouldPingHint);
			requestState.Seed = initialSeed;
			requestState.CurrentNode = baseUri;
			return shouldPingHint
				&& !this.ConfigurationValues.DisablePings
				&& (requestState.RequestConfiguration == null
					|| !requestState.RequestConfiguration.DisablePing.GetValueOrDefault(false));

		}

		public ElasticsearchResponse<T> DoRequest<T>(string method, string path, object data = null, IRequestParameters requestParameters = null)
		{
			using (var requestState = new TransportRequestState<T>(this.Settings, requestParameters, method, path))
			{
				return this._requestHandler.Request<T>(requestState, data);
			}
		}

		public Task<ElasticsearchResponse<T>> DoRequestAsync<T>(string method, string path, object data = null, IRequestParameters requestParameters = null)
		{
			using (var requestState = new TransportRequestState<T>(this.Settings, requestParameters, method, path))
			{
				return this._requestHandlerAsync.RequestAsync(requestState, data);
			}
		}
	}
}