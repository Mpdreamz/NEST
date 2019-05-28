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
namespace Elasticsearch.Net.Specification.GraphApi
{
	///<summary>
	/// Logically groups all Graph API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Graph"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelGraphNamespace : NamespacedClientProxy
	{
		internal LowLevelGraphNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /{index}/_graph/explore <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/graph-explore-api.html</para></summary>
		///<param name = "index">A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">Graph Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Explore<TResponse>(string index, PostData body, GraphExploreRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_graph/explore"), body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_graph/explore <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/graph-explore-api.html</para></summary>
		///<param name = "index">A comma-separated list of index names to search; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">Graph Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ExploreAsync<TResponse>(string index, PostData body, GraphExploreRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_graph/explore"), ctx, body, RequestParams(requestParameters));
	}
}