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
namespace Elasticsearch.Net.Specification.IndicesApi
{
	///<summary>
	/// Logically groups all Indices API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Indices"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelIndicesNamespace : NamespacedClientProxy
	{
		internal LowLevelIndicesNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /_analyze <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-analyze.html</para></summary>
		///<param name = "body">Define analyzer/tokenizer parameters and the text on which the analysis should be performed</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse AnalyzeForAll<TResponse>(PostData body, AnalyzeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_analyze", body, RequestParams(requestParameters));
		///<summary>POST on /_analyze <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-analyze.html</para></summary>
		///<param name = "body">Define analyzer/tokenizer parameters and the text on which the analysis should be performed</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AnalyzeForAllAsync<TResponse>(PostData body, AnalyzeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_analyze", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_analyze <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-analyze.html</para></summary>
		///<param name = "index">The name of the index to scope the operation</param>
		///<param name = "body">Define analyzer/tokenizer parameters and the text on which the analysis should be performed</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Analyze<TResponse>(string index, PostData body, AnalyzeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_analyze"), body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_analyze <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-analyze.html</para></summary>
		///<param name = "index">The name of the index to scope the operation</param>
		///<param name = "body">Define analyzer/tokenizer parameters and the text on which the analysis should be performed</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AnalyzeAsync<TResponse>(string index, PostData body, AnalyzeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_analyze"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_cache/clear <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-clearcache.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ClearCacheForAll<TResponse>(ClearCacheRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_cache/clear", null, RequestParams(requestParameters));
		///<summary>POST on /_cache/clear <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-clearcache.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ClearCacheForAllAsync<TResponse>(ClearCacheRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_cache/clear", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_cache/clear <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-clearcache.html</para></summary>
		///<param name = "index">A comma-separated list of index name to limit the operation</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ClearCache<TResponse>(string index, ClearCacheRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_cache/clear"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_cache/clear <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-clearcache.html</para></summary>
		///<param name = "index">A comma-separated list of index name to limit the operation</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ClearCacheAsync<TResponse>(string index, ClearCacheRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_cache/clear"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_close <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-open-close.html</para></summary>
		///<param name = "index">A comma separated list of indices to close</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Close<TResponse>(string index, CloseIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_close"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_close <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-open-close.html</para></summary>
		///<param name = "index">A comma separated list of indices to close</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CloseAsync<TResponse>(string index, CloseIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_close"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-create-index.html</para></summary>
		///<param name = "index">The name of the index</param>
		///<param name = "body">The configuration for the index (`settings` and `mappings`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Create<TResponse>(string index, PostData body, CreateIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-create-index.html</para></summary>
		///<param name = "index">The name of the index</param>
		///<param name = "body">The configuration for the index (`settings` and `mappings`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CreateAsync<TResponse>(string index, PostData body, CreateIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}"), ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-delete-index.html</para></summary>
		///<param name = "index">A comma-separated list of indices to delete; use `_all` or `*` string to delete all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Delete<TResponse>(string index, DeleteIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"{index:index}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-delete-index.html</para></summary>
		///<param name = "index">A comma-separated list of indices to delete; use `_all` or `*` string to delete all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteAsync<TResponse>(string index, DeleteIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names (supports wildcards); use `_all` for all indices</param>
		///<param name = "name">A comma-separated list of aliases to delete (supports wildcards); use `_all` to delete all aliases for the specified indices.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteAlias<TResponse>(string index, string name, DeleteAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"{index:index}/_alias/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names (supports wildcards); use `_all` for all indices</param>
		///<param name = "name">A comma-separated list of aliases to delete (supports wildcards); use `_all` to delete all aliases for the specified indices.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteAliasAsync<TResponse>(string index, string name, DeleteAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"{index:index}/_alias/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteTemplateForAll<TResponse>(string name, DeleteIndexTemplateRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteTemplateForAllAsync<TResponse>(string name, DeleteIndexTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-exists.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Exists<TResponse>(string index, IndexExistsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(HEAD, Url($"{index:index}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-exists.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ExistsAsync<TResponse>(string index, IndexExistsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse AliasExistsForAll<TResponse>(string name, AliasExistsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(HEAD, Url($"_alias/{name:name}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AliasExistsForAllAsync<TResponse>(string name, AliasExistsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"_alias/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse AliasExists<TResponse>(string index, string name, AliasExistsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(HEAD, Url($"{index:index}/_alias/{name:name}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AliasExistsAsync<TResponse>(string index, string name, AliasExistsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"{index:index}/_alias/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The comma separated names of the index templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse TemplateExistsForAll<TResponse>(string name, IndexTemplateExistsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(HEAD, Url($"_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The comma separated names of the index templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> TemplateExistsForAllAsync<TResponse>(string name, IndexTemplateExistsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /{index}/_mapping/{type} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-types-exists.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use `_all` to check the types across all indices</param>
		///<param name = "type">A comma-separated list of document types to check</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse TypeExists<TResponse>(string index, string type, TypeExistsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(HEAD, Url($"{index:index}/_mapping/{type:type}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /{index}/_mapping/{type} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-types-exists.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use `_all` to check the types across all indices</param>
		///<param name = "type">A comma-separated list of document types to check</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> TypeExistsAsync<TResponse>(string index, string type, TypeExistsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"{index:index}/_mapping/{type:type}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-flush.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse FlushForAll<TResponse>(FlushRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_flush", null, RequestParams(requestParameters));
		///<summary>POST on /_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-flush.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> FlushForAllAsync<TResponse>(FlushRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_flush", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-flush.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All for all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Flush<TResponse>(string index, FlushRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_flush"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-flush.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All for all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> FlushAsync<TResponse>(string index, FlushRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_flush"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_flush/synced <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-synced-flush.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse SyncedFlushForAll<TResponse>(SyncedFlushRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_flush/synced", null, RequestParams(requestParameters));
		///<summary>POST on /_flush/synced <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-synced-flush.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SyncedFlushForAllAsync<TResponse>(SyncedFlushRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_flush/synced", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_flush/synced <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-synced-flush.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All for all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse SyncedFlush<TResponse>(string index, SyncedFlushRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_flush/synced"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_flush/synced <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-synced-flush.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All for all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SyncedFlushAsync<TResponse>(string index, SyncedFlushRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_flush/synced"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_forcemerge <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-forcemerge.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ForceMergeForAll<TResponse>(ForceMergeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_forcemerge", null, RequestParams(requestParameters));
		///<summary>POST on /_forcemerge <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-forcemerge.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ForceMergeForAllAsync<TResponse>(ForceMergeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_forcemerge", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_forcemerge <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-forcemerge.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ForceMerge<TResponse>(string index, ForceMergeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_forcemerge"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_forcemerge <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-forcemerge.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ForceMergeAsync<TResponse>(string index, ForceMergeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_forcemerge"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-index.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Get<TResponse>(string index, GetIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-index.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAsync<TResponse>(string index, GetIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_alias <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAliasForAll<TResponse>(GetAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_alias", null, RequestParams(requestParameters));
		///<summary>GET on /_alias <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAliasForAllAsync<TResponse>(GetAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_alias", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAliasForAll<TResponse>(string name, GetAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_alias/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAliasForAllAsync<TResponse>(string name, GetAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_alias/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAlias<TResponse>(string index, string name, GetAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_alias/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAliasAsync<TResponse>(string index, string name, GetAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_alias/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_alias <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAlias<TResponse>(string index, GetAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_alias"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_alias <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names to filter aliases</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAliasAsync<TResponse>(string index, GetAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_alias"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_mapping/field/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-field-mapping.html</para></summary>
		///<param name = "fields">A comma-separated list of fields</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetFieldMappingForAll<TResponse>(string fields, GetFieldMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_mapping/field/{fields:fields}"), null, RequestParams(requestParameters));
		///<summary>GET on /_mapping/field/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-field-mapping.html</para></summary>
		///<param name = "fields">A comma-separated list of fields</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetFieldMappingForAllAsync<TResponse>(string fields, GetFieldMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_mapping/field/{fields:fields}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_mapping/field/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-field-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "fields">A comma-separated list of fields</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetFieldMapping<TResponse>(string index, string fields, GetFieldMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_mapping/field/{fields:fields}"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_mapping/field/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-field-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "fields">A comma-separated list of fields</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetFieldMappingAsync<TResponse>(string index, string fields, GetFieldMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_mapping/field/{fields:fields}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-mapping.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetMappingForAll<TResponse>(GetMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_mapping", null, RequestParams(requestParameters));
		///<summary>GET on /_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-mapping.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetMappingForAllAsync<TResponse>(GetMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_mapping", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetMapping<TResponse>(string index, GetMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_mapping"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetMappingAsync<TResponse>(string index, GetMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_mapping"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetSettingsForAll<TResponse>(GetIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_settings", null, RequestParams(requestParameters));
		///<summary>GET on /_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetSettingsForAllAsync<TResponse>(GetIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_settings", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetSettings<TResponse>(string index, GetIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_settings"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetSettingsAsync<TResponse>(string index, GetIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_settings"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_settings/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "name">The name of the settings that should be included</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetSettings<TResponse>(string index, string name, GetIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_settings/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_settings/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "name">The name of the settings that should be included</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetSettingsAsync<TResponse>(string index, string name, GetIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_settings/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_settings/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "name">The name of the settings that should be included</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetSettingsForAll<TResponse>(string name, GetIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_settings/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_settings/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-get-settings.html</para></summary>
		///<param name = "name">The name of the settings that should be included</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetSettingsForAllAsync<TResponse>(string name, GetIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_settings/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_template <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetTemplateForAll<TResponse>(GetIndexTemplateRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_template", null, RequestParams(requestParameters));
		///<summary>GET on /_template <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetTemplateForAllAsync<TResponse>(GetIndexTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_template", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The comma separated names of the index templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetTemplateForAll<TResponse>(string name, GetIndexTemplateRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The comma separated names of the index templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetTemplateForAllAsync<TResponse>(string name, GetIndexTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpgradeStatusForAll<TResponse>(UpgradeStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_upgrade", null, RequestParams(requestParameters));
		///<summary>GET on /_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpgradeStatusForAllAsync<TResponse>(UpgradeStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_upgrade", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpgradeStatus<TResponse>(string index, UpgradeStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_upgrade"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpgradeStatusAsync<TResponse>(string index, UpgradeStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_upgrade"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_open <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-open-close.html</para></summary>
		///<param name = "index">A comma separated list of indices to open</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Open<TResponse>(string index, OpenIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_open"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_open <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-open-close.html</para></summary>
		///<param name = "index">A comma separated list of indices to open</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> OpenAsync<TResponse>(string index, OpenIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_open"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names the alias should point to (supports wildcards); use `_all` to perform the operation on all indices.</param>
		///<param name = "name">The name of the alias to be created or updated</param>
		///<param name = "body">The settings for the alias, such as `routing` or `filter`</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutAlias<TResponse>(string index, string name, PostData body, PutAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}/_alias/{name:name}"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_alias/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "index">A comma-separated list of index names the alias should point to (supports wildcards); use `_all` to perform the operation on all indices.</param>
		///<param name = "name">The name of the alias to be created or updated</param>
		///<param name = "body">The settings for the alias, such as `routing` or `filter`</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutAliasAsync<TResponse>(string index, string name, PostData body, PutAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}/_alias/{name:name}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-put-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names the mapping should be added to (supports wildcards); use `_all` or omit to add the mapping on all indices.</param>
		///<param name = "body">The mapping definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutMapping<TResponse>(string index, PostData body, PutMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}/_mapping"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_mapping <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-put-mapping.html</para></summary>
		///<param name = "index">A comma-separated list of index names the mapping should be added to (supports wildcards); use `_all` or omit to add the mapping on all indices.</param>
		///<param name = "body">The mapping definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutMappingAsync<TResponse>(string index, PostData body, PutMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}/_mapping"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-update-settings.html</para></summary>
		///<param name = "body">The index settings to be updated</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateSettingsForAll<TResponse>(PostData body, UpdateIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, "_settings", body, RequestParams(requestParameters));
		///<summary>PUT on /_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-update-settings.html</para></summary>
		///<param name = "body">The index settings to be updated</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateSettingsForAllAsync<TResponse>(PostData body, UpdateIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, "_settings", ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-update-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">The index settings to be updated</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateSettings<TResponse>(string index, PostData body, UpdateIndexSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}/_settings"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_settings <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-update-settings.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">The index settings to be updated</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateSettingsAsync<TResponse>(string index, PostData body, UpdateIndexSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}/_settings"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "body">The template definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutTemplateForAll<TResponse>(string name, PostData body, PutIndexTemplateRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_template/{name:name}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_template/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-templates.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "body">The template definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutTemplateForAllAsync<TResponse>(string name, PostData body, PutIndexTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_template/{name:name}"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-recovery.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RecoveryStatusForAll<TResponse>(RecoveryStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_recovery", null, RequestParams(requestParameters));
		///<summary>GET on /_recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-recovery.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RecoveryStatusForAllAsync<TResponse>(RecoveryStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_recovery", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-recovery.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RecoveryStatus<TResponse>(string index, RecoveryStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_recovery"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-recovery.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RecoveryStatusAsync<TResponse>(string index, RecoveryStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_recovery"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_refresh <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-refresh.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RefreshForAll<TResponse>(RefreshRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_refresh", null, RequestParams(requestParameters));
		///<summary>POST on /_refresh <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-refresh.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RefreshForAllAsync<TResponse>(RefreshRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_refresh", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_refresh <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-refresh.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Refresh<TResponse>(string index, RefreshRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_refresh"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_refresh <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-refresh.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RefreshAsync<TResponse>(string index, RefreshRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_refresh"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{alias}/_rollover <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-rollover-index.html</para></summary>
		///<param name = "alias">The name of the alias to rollover</param>
		///<param name = "body">The conditions that needs to be met for executing rollover</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RolloverForAll<TResponse>(string alias, PostData body, RolloverIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{alias:alias}/_rollover"), body, RequestParams(requestParameters));
		///<summary>POST on /{alias}/_rollover <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-rollover-index.html</para></summary>
		///<param name = "alias">The name of the alias to rollover</param>
		///<param name = "body">The conditions that needs to be met for executing rollover</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RolloverForAllAsync<TResponse>(string alias, PostData body, RolloverIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{alias:alias}/_rollover"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /{alias}/_rollover/{new_index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-rollover-index.html</para></summary>
		///<param name = "alias">The name of the alias to rollover</param>
		///<param name = "new_index">The name of the rollover index</param>
		///<param name = "body">The conditions that needs to be met for executing rollover</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RolloverForAll<TResponse>(string alias, string new_index, PostData body, RolloverIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{alias:alias}/_rollover/{new_index:new_index}"), body, RequestParams(requestParameters));
		///<summary>POST on /{alias}/_rollover/{new_index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-rollover-index.html</para></summary>
		///<param name = "alias">The name of the alias to rollover</param>
		///<param name = "new_index">The name of the rollover index</param>
		///<param name = "body">The conditions that needs to be met for executing rollover</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RolloverForAllAsync<TResponse>(string alias, string new_index, PostData body, RolloverIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{alias:alias}/_rollover/{new_index:new_index}"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-segments.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse SegmentsForAll<TResponse>(SegmentsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_segments", null, RequestParams(requestParameters));
		///<summary>GET on /_segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-segments.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SegmentsForAllAsync<TResponse>(SegmentsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_segments", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-segments.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Segments<TResponse>(string index, SegmentsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_segments"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-segments.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SegmentsAsync<TResponse>(string index, SegmentsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_segments"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_shard_stores <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shards-stores.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ShardStoresForAll<TResponse>(IndicesShardStoresRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_shard_stores", null, RequestParams(requestParameters));
		///<summary>GET on /_shard_stores <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shards-stores.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ShardStoresForAllAsync<TResponse>(IndicesShardStoresRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_shard_stores", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_shard_stores <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shards-stores.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ShardStores<TResponse>(string index, IndicesShardStoresRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_shard_stores"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_shard_stores <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shards-stores.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ShardStoresAsync<TResponse>(string index, IndicesShardStoresRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_shard_stores"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_shrink/{target} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shrink-index.html</para></summary>
		///<param name = "index">The name of the source index to shrink</param>
		///<param name = "target">The name of the target index to shrink into</param>
		///<param name = "body">The configuration for the target index (`settings` and `aliases`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Shrink<TResponse>(string index, string target, PostData body, ShrinkIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}/_shrink/{target:target}"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_shrink/{target} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-shrink-index.html</para></summary>
		///<param name = "index">The name of the source index to shrink</param>
		///<param name = "target">The name of the target index to shrink into</param>
		///<param name = "body">The configuration for the target index (`settings` and `aliases`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ShrinkAsync<TResponse>(string index, string target, PostData body, ShrinkIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}/_shrink/{target:target}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_split/{target} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-split-index.html</para></summary>
		///<param name = "index">The name of the source index to split</param>
		///<param name = "target">The name of the target index to split into</param>
		///<param name = "body">The configuration for the target index (`settings` and `aliases`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Split<TResponse>(string index, string target, PostData body, SplitIndexRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"{index:index}/_split/{target:target}"), body, RequestParams(requestParameters));
		///<summary>PUT on /{index}/_split/{target} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-split-index.html</para></summary>
		///<param name = "index">The name of the source index to split</param>
		///<param name = "target">The name of the target index to split into</param>
		///<param name = "body">The configuration for the target index (`settings` and `aliases`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SplitAsync<TResponse>(string index, string target, PostData body, SplitIndexRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"{index:index}/_split/{target:target}"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StatsForAll<TResponse>(IndicesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_stats", null, RequestParams(requestParameters));
		///<summary>GET on /_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsForAllAsync<TResponse>(IndicesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "metric">Limit the information returned the specific metrics.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StatsForAll<TResponse>(string metric, IndicesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_stats/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "metric">Limit the information returned the specific metrics.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsForAllAsync<TResponse>(string metric, IndicesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_stats/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string index, IndicesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_stats"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string index, IndicesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_stats"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "metric">Limit the information returned the specific metrics.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string index, string metric, IndicesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_stats/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-stats.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "metric">Limit the information returned the specific metrics.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string index, string metric, IndicesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_stats/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_aliases <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "body">The definition of `actions` to perform</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse BulkAliasForAll<TResponse>(PostData body, BulkAliasRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_aliases", body, RequestParams(requestParameters));
		///<summary>POST on /_aliases <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-aliases.html</para></summary>
		///<param name = "body">The definition of `actions` to perform</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> BulkAliasForAllAsync<TResponse>(PostData body, BulkAliasRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_aliases", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpgradeForAll<TResponse>(UpgradeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_upgrade", null, RequestParams(requestParameters));
		///<summary>POST on /_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpgradeForAllAsync<TResponse>(UpgradeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_upgrade", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Upgrade<TResponse>(string index, UpgradeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_upgrade"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_upgrade <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/indices-upgrade.html</para></summary>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpgradeAsync<TResponse>(string index, UpgradeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_upgrade"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_validate/query <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-validate.html</para></summary>
		///<param name = "body">The query definition specified with the Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ValidateQueryForAll<TResponse>(PostData body, ValidateQueryRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_validate/query", body, RequestParams(requestParameters));
		///<summary>POST on /_validate/query <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-validate.html</para></summary>
		///<param name = "body">The query definition specified with the Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ValidateQueryForAllAsync<TResponse>(PostData body, ValidateQueryRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_validate/query", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_validate/query <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-validate.html</para></summary>
		///<param name = "index">A comma-separated list of index names to restrict the operation; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">The query definition specified with the Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ValidateQuery<TResponse>(string index, PostData body, ValidateQueryRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_validate/query"), body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_validate/query <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-validate.html</para></summary>
		///<param name = "index">A comma-separated list of index names to restrict the operation; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "body">The query definition specified with the Query DSL</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ValidateQueryAsync<TResponse>(string index, PostData body, ValidateQueryRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_validate/query"), ctx, body, RequestParams(requestParameters));
	}
}