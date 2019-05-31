﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{

	public class NamespacedClientProxy
	{
		private readonly ElasticClient _client;

		protected NamespacedClientProxy(ElasticClient client) => _client = client;

		internal TResponse DoRequest<TRequest, TResponse>(
			TRequest p,
			IRequestParameters parameters,
			Action<IRequestConfiguration> forceConfiguration = null
		)
			where TRequest : class, IRequest
			where TResponse : class, IElasticsearchResponse, new() =>
			_client.DoRequest<TRequest, TResponse>(p, parameters, forceConfiguration);

		internal Task<TResponse> DoRequestAsync<TRequest, TResponse>(
			TRequest p,
			IRequestParameters parameters,
			CancellationToken ct,
			Action<IRequestConfiguration> forceConfiguration = null
		)
			where TRequest : class, IRequest
			where TResponse : class, IElasticsearchResponse, new() =>
			_client.DoRequestAsync<TRequest, TResponse>(p, parameters, ct, forceConfiguration);

		private CatResponse<TCatRecord> DeserializeCatResponse<TCatRecord>(IApiCallDetails response, Stream stream)
			where TCatRecord : ICatRecord
		{
			var catResponse = new CatResponse<TCatRecord>();

			if (!response.Success) return catResponse;

			var records = _client.RequestResponseSerializer.Deserialize<IReadOnlyCollection<TCatRecord>>(stream);
			catResponse.Records = records;

			return catResponse;
		}

		private CatResponse<TCatRecord> DeserializeCatHelpResponse<TCatRecord>(IApiCallDetails response, Stream stream)
			where TCatRecord : ICatRecord
		{
			var catResponse = new CatResponse<TCatRecord>();

			if (!response.Success) return catResponse;

			using (stream)
			using (var ms = response.ConnectionConfiguration.MemoryStreamFactory.Create())
			{
				stream.CopyTo(ms);
				var body = ms.ToArray().Utf8String();
				catResponse.Records = body.Split('\n')
					.Skip(1)
					.Select(f => new CatHelpRecord { Endpoint = f.Trim() })
					.Cast<TCatRecord>()
					.ToList();
			}

			return catResponse;
		}

		protected CatResponse<TCatRecord> DoCat<TRequest, TParams, TCatRecord>(TRequest request)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			request.RequestParameters.DeserializationOverride = DeserializeCatResponse<TCatRecord>;
			return DoRequest<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, r => ElasticClient.ForceJson(r));
		}

		protected Task<CatResponse<TCatRecord>> DoCatAsync<TRequest, TParams, TCatRecord>(TRequest request, CancellationToken ct)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			request.RequestParameters.DeserializationOverride = DeserializeCatResponse<TCatRecord>;
			return DoRequestAsync<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, ct, r => ElasticClient.ForceJson(r));
		}


		protected CatResponse<CatHelpRecord> DoCatHelp<TRequest, TParams, TCatRecord>(TRequest request)
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			request.RequestParameters.DeserializationOverride = DeserializeCatHelpResponse<CatHelpRecord>;
			return DoRequest<TRequest, CatResponse<CatHelpRecord>>(request, request.RequestParameters, r => ElasticClient.ForceJson(r));
		}

		protected Task<CatResponse<CatHelpRecord>> DoCatHelpAsync<TRequest, TParams, TCatRecord>(TRequest request, CancellationToken ct)
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			request.RequestParameters.DeserializationOverride = DeserializeCatHelpResponse<CatHelpRecord>;
			return DoRequestAsync<TRequest, CatResponse<CatHelpRecord>>(request, request.RequestParameters, ct, r => ElasticClient.ForceJson(r));
		}
	}
	/// <summary>
	/// ElasticClient is NEST's strongly typed client which exposes fully mapped Elasticsearch endpoints
	/// </summary>
	public partial class ElasticClient : IElasticClient
	{
		public ElasticClient() : this(new ConnectionSettings(new Uri("http://localhost:9200"))) { }

		public ElasticClient(Uri uri) : this(new ConnectionSettings(uri)) { }

		public ElasticClient(IConnectionSettingsValues connectionSettings)
			: this(new Transport<IConnectionSettingsValues>(connectionSettings ?? new ConnectionSettings())) { }

		public ElasticClient(ITransport<IConnectionSettingsValues> transport)
		{
			transport.ThrowIfNull(nameof(transport));
			transport.Settings.ThrowIfNull(nameof(transport.Settings));
			transport.Settings.RequestResponseSerializer.ThrowIfNull(nameof(transport.Settings.RequestResponseSerializer));
			transport.Settings.Inferrer.ThrowIfNull(nameof(transport.Settings.Inferrer));

			Transport = transport;
			LowLevel = new ElasticLowLevelClient(Transport);
			SetupNamespaces();
		}

		partial void SetupNamespaces();

		public IConnectionSettingsValues ConnectionSettings => Transport.Settings;
		public Inferrer Infer => Transport.Settings.Inferrer;

		public IElasticLowLevelClient LowLevel { get; }
		public IElasticsearchSerializer RequestResponseSerializer => Transport.Settings.RequestResponseSerializer;

		public IElasticsearchSerializer SourceSerializer => Transport.Settings.SourceSerializer;

		private ITransport<IConnectionSettingsValues> Transport { get; }

		internal TResponse DoRequest<TRequest, TResponse>(TRequest p, IRequestParameters parameters, Action<IRequestConfiguration> forceConfiguration = null)
			where TRequest : class, IRequest
			where TResponse : class, IElasticsearchResponse, new()
		{
			if (forceConfiguration != null) ForceConfiguration(p, forceConfiguration);

			var url = p.GetUrl(ConnectionSettings);
			var b = (p.HttpMethod == HttpMethod.GET || p.HttpMethod == HttpMethod.HEAD) ? null : new SerializableData<TRequest>(p);

			return LowLevel.DoRequest<TResponse>(p.HttpMethod, url, b, parameters);
		}

		internal Task<TResponse> DoRequestAsync<TRequest, TResponse>(
			TRequest p,
			IRequestParameters parameters,
			CancellationToken ct,
			Action<IRequestConfiguration> forceConfiguration = null
		)
			where TRequest : class, IRequest
			where TResponse : class, IElasticsearchResponse, new()
		{
			if (forceConfiguration != null) ForceConfiguration(p, forceConfiguration);

			var url = p.GetUrl(ConnectionSettings);
			var b = (p.HttpMethod == HttpMethod.GET || p.HttpMethod == HttpMethod.HEAD) ? null : new SerializableData<TRequest>(p);

			return LowLevel.DoRequestAsync<TResponse>(p.HttpMethod, url, ct, b, parameters);
		}

		private static void ForceConfiguration(IRequest request, Action<IRequestConfiguration> forceConfiguration)
		{
			if (forceConfiguration == null) return;
			var configuration = request.RequestParametersInternal.RequestConfiguration ?? new RequestConfiguration();
			forceConfiguration(configuration);
			request.RequestParametersInternal.RequestConfiguration = configuration;
		}

		private static readonly int[] AllStatusCodes = { -1 };
		private static void AcceptAllStatusCodesHandler(IRequestConfiguration requestConfiguration) =>
			requestConfiguration.AllowedStatusCodes = AllStatusCodes;

		internal static void ForceJson(IRequestConfiguration requestConfiguration)
		{
			requestConfiguration.Accept = RequestData.MimeType;
			requestConfiguration.ContentType = RequestData.MimeType;
		}
	}
}
