using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using static Elasticsearch.Net.HttpMethod;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.XPackApi
{
	///<summary>
	/// Logically groups all XPack API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.XPack"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelXPackNamespace : NamespacedClientProxy
	{
		internal LowLevelXPackNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>GET on /_xpack <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/info-api.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Info<TResponse>(XPackInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_xpack", null, RequestParams(requestParameters));
		///<summary>GET on /_xpack <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/info-api.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoAsync<TResponse>(XPackInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_xpack", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_xpack/usage <para>Retrieve information about xpack features usage</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Usage<TResponse>(XPackUsageRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_xpack/usage", null, RequestParams(requestParameters));
		///<summary>GET on /_xpack/usage <para>Retrieve information about xpack features usage</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UsageAsync<TResponse>(XPackUsageRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_xpack/usage", ctx, null, RequestParams(requestParameters));
	}
}