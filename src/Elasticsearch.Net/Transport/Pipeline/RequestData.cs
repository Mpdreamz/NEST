﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Purify;

namespace Elasticsearch.Net
{
	public class RequestData
	{
		public const string MimeType = "application/json";

		public Uri Uri => new Uri(this.Node.Uri, this.Path).Purify();

		public HttpMethod Method { get; private set; }
		public string Path { get; }
		public PostData<object> PostData { get; }
		public Node Node { get; internal set; }
		public TimeSpan RequestTimeout { get; }
		public TimeSpan PingTimeout { get; }
		public int KeepAliveTime { get; }
		public int KeepAliveInterval { get; }

		public bool Pipelined { get; }
		public bool HttpCompression { get; }
		public string ContentType { get; }

		public NameValueCollection Headers { get; }
		public string ProxyAddress { get; }
		public string ProxyUsername { get; }
		public string ProxyPassword { get; }
		public bool DisableAutomaticProxyDetection { get; }
		public BasicAuthenticationCredentials BasicAuthorizationCredentials { get; }
		public CancellationToken CancellationToken { get; }
		public IEnumerable<int> AllowedStatusCodes { get; }
		public Func<IApiCallDetails, Stream, object> CustomConverter { get; private set; }
		public IConnectionConfigurationValues ConnectionSettings { get; private set; }
		public IMemoryStreamFactory MemoryStreamFactory { get; private set; }

		public RequestData(HttpMethod method, string path, PostData<object> data, IConnectionConfigurationValues global, IMemoryStreamFactory memoryStreamFactory)
			: this(method, path, data, global, (IRequestConfiguration)null, memoryStreamFactory)
		{ }

		public RequestData(HttpMethod method, string path, PostData<object> data, IConnectionConfigurationValues global, IRequestParameters local, IMemoryStreamFactory memoryStreamFactory)
			: this(method, path, data, global, (IRequestConfiguration)local?.RequestConfiguration, memoryStreamFactory)
		{
			this.CustomConverter = local?.DeserializationOverride;
			this.Path = this.CreatePathWithQueryStrings(path, this.ConnectionSettings, local);
		}

		public RequestData(HttpMethod method, string path, PostData<object> data, IConnectionConfigurationValues global, IRequestConfiguration local, IMemoryStreamFactory memoryStreamFactory)
		{
			this.ConnectionSettings = global;
			this.MemoryStreamFactory = memoryStreamFactory;
			this.Method = method;
			this.PostData = data;
			this.Path = this.CreatePathWithQueryStrings(path, this.ConnectionSettings, null);

			this.Pipelined = global.HttpPipeliningEnabled || (local?.EnableHttpPipelining).GetValueOrDefault(false);
			this.HttpCompression = global.EnableHttpCompression;
			this.ContentType = local?.ContentType ?? MimeType;
			this.Headers = global.Headers;

			this.RequestTimeout = local?.RequestTimeout ?? global.RequestTimeout;
			this.PingTimeout = 
				local?.PingTimeout
				?? global?.PingTimeout
				?? (global.ConnectionPool.UsingSsl ? ConnectionConfiguration.DefaultPingTimeoutOnSSL : ConnectionConfiguration.DefaultPingTimeout);

			this.KeepAliveInterval = (int)(global.KeepAliveInterval?.TotalMilliseconds ?? 2000);
			this.KeepAliveTime = (int)(global.KeepAliveTime?.TotalMilliseconds ?? 2000);

			this.ProxyAddress = global.ProxyAddress;
			this.ProxyUsername = global.ProxyUsername;
			this.ProxyPassword = global.ProxyPassword;
			this.DisableAutomaticProxyDetection = global.DisableAutomaticProxyDetection;
			this.BasicAuthorizationCredentials = local?.BasicAuthenticationCredentials ?? global.BasicAuthenticationCredentials;
			this.CancellationToken = local?.CancellationToken ?? CancellationToken.None;
			this.AllowedStatusCodes = local?.AllowedStatusCodes ?? Enumerable.Empty<int>();
		}

		private string CreatePathWithQueryStrings(string path, IConnectionConfigurationValues global, IRequestParameters request = null)
		{
			//Make sure we append global query string as well the request specific query string parameters
			var copy = new NameValueCollection(global.QueryStringParameters);
			var formatter = new UrlFormatProvider(this.ConnectionSettings);
			if (request != null)
				copy.Add(request.QueryString.ToNameValueCollection(formatter));
			if (!copy.HasKeys()) return path;

			var queryString = copy.ToQueryString();
			path += queryString;
			return path;
		}
	}
}