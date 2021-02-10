// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elasticsearch.Net.Specification.MachineLearningApi;

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

		protected CatResponse<TCatRecord> DoCat<TRequest, TParams, TCatRecord>(TRequest request)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			if (typeof(TCatRecord) == typeof(CatHelpRecord))
			{
				request.RequestParameters.CustomResponseBuilder = CatHelpResponseBuilder.Instance;
				return DoRequest<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, r => ElasticClient.ForceTextPlain(r));
			}
			request.RequestParameters.CustomResponseBuilder = CatResponseBuilder<TCatRecord>.Instance;
			return DoRequest<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, r => ElasticClient.ForceJson(r));
		}

		protected Task<CatResponse<TCatRecord>> DoCatAsync<TRequest, TParams, TCatRecord>(TRequest request, CancellationToken ct)
			where TCatRecord : ICatRecord
			where TParams : RequestParameters<TParams>, new()
			where TRequest : class, IRequest<TParams>
		{
			if (typeof(TCatRecord) == typeof(CatHelpRecord))
			{
				request.RequestParameters.CustomResponseBuilder = CatHelpResponseBuilder.Instance;
				return DoRequestAsync<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, ct, r => ElasticClient.ForceTextPlain(r));
			}
			request.RequestParameters.CustomResponseBuilder = CatResponseBuilder<TCatRecord>.Instance;
			return DoRequestAsync<TRequest, CatResponse<TCatRecord>>(request, request.RequestParameters, ct, r => ElasticClient.ForceJson(r));
		}

		internal IRequestParameters ResponseBuilder(PreviewDatafeedRequestParameters parameters, CustomResponseBuilderBase builder)
		{
			parameters.CustomResponseBuilder = builder;
			return parameters;
		}
	}
	/// <summary>
	/// ElasticClient is NEST's strongly typed client which exposes fully mapped Elasticsearch endpoints
	/// </summary>
	public partial class ElasticClient : IElasticClient
	{
		public ElasticClient() : this(new ConnectionSettings(new Uri("http://localhost:9200"))) { }

		public ElasticClient(Uri uri) : this(new ConnectionSettings(uri)) { }

		/// <summary>
		/// Sets up the client to communicate to Elastic Cloud using <paramref name="cloudId"/>,
		/// <para><see cref="CloudConnectionPool"/> documentation for more information on how to obtain your Cloud Id</para>
		/// <para></para>If you want more control use the <see cref="ElasticClient(IConnectionSettingsValues)"/> constructor and pass an instance of
		/// <see cref="ConnectionSettings" /> that takes <paramref name="cloudId"/> in its constructor as well
		/// </summary>
		public ElasticClient(string cloudId, BasicAuthenticationCredentials credentials) : this(new ConnectionSettings(cloudId, credentials)) { }

		/// <summary>
		/// Sets up the client to communicate to Elastic Cloud using <paramref name="cloudId"/>,
		/// <para><see cref="CloudConnectionPool"/> documentation for more information on how to obtain your Cloud Id</para>
		/// <para></para>If you want more control use the <see cref="ElasticClient(IConnectionSettingsValues)"/> constructor and pass an instance of
		/// <see cref="ConnectionSettings" /> that takes <paramref name="cloudId"/> in its constructor as well
		/// </summary>
		public ElasticClient(string cloudId, ApiKeyAuthenticationCredentials credentials) : this(new ConnectionSettings(cloudId, credentials)) { }

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
			var url = p.GetUrl(ConnectionSettings);
			var b = (p.HttpMethod == HttpMethod.GET || p.HttpMethod == HttpMethod.HEAD || !parameters.SupportsBody) ? null : new SerializableData<TRequest>(p);

			void RequestConfig(IRequestConfiguration r)
			{
				ForceApiNameHeader(p, r);
				forceConfiguration?.Invoke(r);
			}

			ForceConfiguration(p, RequestConfig);
			if (p.ContentType != null) ForceContentType(p, p.ContentType);


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
			var url = p.GetUrl(ConnectionSettings);
			var b = (p.HttpMethod == HttpMethod.GET || p.HttpMethod == HttpMethod.HEAD || !parameters.SupportsBody) ? null : new SerializableData<TRequest>(p);

			void RequestConfig(IRequestConfiguration r)
			{
				ForceApiNameHeader(p, r);
				forceConfiguration?.Invoke(r);
			}

			ForceConfiguration(p, RequestConfig);
			if (p.ContentType != null) ForceContentType(p, p.ContentType);


			return LowLevel.DoRequestAsync<TResponse>(p.HttpMethod, url, ct, b, parameters);
		}

		private static void ForceApiNameHeader(IRequest request, IRequestConfiguration configuration)
		{
			var apiName = request.GetType()
				.GetInterfaces()
				.SelectMany(i => i.GetCustomAttributes())
				.Select(a => a as MapsApiAttribute)
				.First(a => a != null);

			configuration.Headers ??= new NameValueCollection();
			configuration.Headers["x-api-name"] = apiName.Name?.Replace(".json", "");
			var args =
				request.RouteValues != null && request.RouteValues.Resolved != null
				? string.Join(";", request.RouteValues.Resolved.Select(c => $"{c.Key}={c.Value}"))
				: string.Empty;

			configuration.Headers["x-api-args"] = args;

			var st = new StackTrace(true);
			var frames = st.GetFrames();
			if (frames == null)
			{
				return;
			}
			var testCode = frames
				.Where(f =>
				{
					var path = f.GetFileName();
					return path != null
						&& path.Contains("Tests" + Path.DirectorySeparatorChar)
						&& !path.Contains("Framework");
				})
				.FirstOrDefault();

			if (testCode != null)
			{

				var file = Regex.Replace(testCode.GetFileName(), @"^.*Tests\" + Path.DirectorySeparatorChar, "");
				var method = testCode.GetMethod();
				var @class = method.ReflectedType?.DeclaringType?.Name ?? "unknown";
				configuration.Headers["x-test-name"] = $"{file}${@class}${method.Name}";
			}

		}

		private static void ForceConfiguration(IRequest request, Action<IRequestConfiguration> forceConfiguration)
		{
			if (forceConfiguration == null) return;

			var configuration = request.RequestParameters.RequestConfiguration ?? new RequestConfiguration();
			forceConfiguration(configuration);
			request.RequestParameters.RequestConfiguration = configuration;
		}
		private void ForceContentType<TRequest>(TRequest request, string contentType) where TRequest : class, IRequest
		{
			var configuration = request.RequestParameters.RequestConfiguration ?? new RequestConfiguration();
			configuration.Accept = contentType;
			configuration.ContentType = contentType;
			request.RequestParameters.RequestConfiguration = configuration;
		}

		internal static void ForceJson(IRequestConfiguration requestConfiguration)
		{
			requestConfiguration.Accept = RequestData.MimeType;
			requestConfiguration.ContentType = RequestData.MimeType;
		}
		internal static void ForceTextPlain(IRequestConfiguration requestConfiguration)
		{
			requestConfiguration.Accept = RequestData.MimeTypeTextPlain;
			requestConfiguration.ContentType = RequestData.MimeTypeTextPlain;
		}

		internal IRequestParameters ResponseBuilder(SourceRequestParameters parameters, CustomResponseBuilderBase builder)
		{
			parameters.CustomResponseBuilder = builder;
			return parameters;
		}
	}
}
