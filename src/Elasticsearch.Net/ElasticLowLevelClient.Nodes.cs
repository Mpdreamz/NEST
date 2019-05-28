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
namespace Elasticsearch.Net.Specification.NodesApi
{
	///<summary>
	/// Logically groups all Nodes API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Nodes"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelNodesNamespace : NamespacedClientProxy
	{
		internal LowLevelNodesNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>GET on /_nodes/hot_threads <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-hot-threads.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse HotThreadsForAll<TResponse>(NodesHotThreadsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_nodes/hot_threads", null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/hot_threads <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-hot-threads.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HotThreadsForAllAsync<TResponse>(NodesHotThreadsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_nodes/hot_threads", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/hot_threads <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-hot-threads.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse HotThreads<TResponse>(string node_id, NodesHotThreadsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/hot_threads"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/hot_threads <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-hot-threads.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HotThreadsAsync<TResponse>(string node_id, NodesHotThreadsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/hot_threads"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse InfoForAll<TResponse>(NodesInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_nodes", null, RequestParams(requestParameters));
		///<summary>GET on /_nodes <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoForAllAsync<TResponse>(NodesInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_nodes", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Info<TResponse>(string node_id, NodesInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoAsync<TResponse>(string node_id, NodesInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "metric">A comma-separated list of metrics you wish returned. Leave empty to return all.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse InfoForAll<TResponse>(string metric, NodesInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "metric">A comma-separated list of metrics you wish returned. Leave empty to return all.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoForAllAsync<TResponse>(string metric, NodesInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">A comma-separated list of metrics you wish returned. Leave empty to return all.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Info<TResponse>(string node_id, string metric, NodesInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">A comma-separated list of metrics you wish returned. Leave empty to return all.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoAsync<TResponse>(string node_id, string metric, NodesInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_nodes/reload_secure_settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/secure-settings.html#reloadable-secure-settings</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ReloadSecureSettingsForAll<TResponse>(ReloadSecureSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_nodes/reload_secure_settings", null, RequestParams(requestParameters));
		///<summary>POST on /_nodes/reload_secure_settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/secure-settings.html#reloadable-secure-settings</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ReloadSecureSettingsForAllAsync<TResponse>(ReloadSecureSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_nodes/reload_secure_settings", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_nodes/{node_id}/reload_secure_settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/secure-settings.html#reloadable-secure-settings</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs to span the reload/reinit call. Should stay empty because reloading usually involves all cluster nodes.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ReloadSecureSettings<TResponse>(string node_id, ReloadSecureSettingsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_nodes/{node_id:node_id}/reload_secure_settings"), null, RequestParams(requestParameters));
		///<summary>POST on /_nodes/{node_id}/reload_secure_settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/secure-settings.html#reloadable-secure-settings</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs to span the reload/reinit call. Should stay empty because reloading usually involves all cluster nodes.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ReloadSecureSettingsAsync<TResponse>(string node_id, ReloadSecureSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_nodes/{node_id:node_id}/reload_secure_settings"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StatsForAll<TResponse>(NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_nodes/stats", null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsForAllAsync<TResponse>(NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_nodes/stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string node_id, NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string node_id, NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StatsForAll<TResponse>(string metric, NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/stats/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsForAllAsync<TResponse>(string metric, NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/stats/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string node_id, string metric, NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string node_id, string metric, NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats/{metric}/{index_metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index_metric">Limit the information returned for `indices` metric to the specific index metrics. Isn&#x27;t used if `indices` (or `all`) metric isn&#x27;t specified.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StatsForAll<TResponse>(string metric, string index_metric, NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/stats/{metric:metric}/{index_metric:index_metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/stats/{metric}/{index_metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index_metric">Limit the information returned for `indices` metric to the specific index metrics. Isn&#x27;t used if `indices` (or `all`) metric isn&#x27;t specified.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsForAllAsync<TResponse>(string metric, string index_metric, NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/stats/{metric:metric}/{index_metric:index_metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats/{metric}/{index_metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index_metric">Limit the information returned for `indices` metric to the specific index metrics. Isn&#x27;t used if `indices` (or `all`) metric isn&#x27;t specified.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string node_id, string metric, string index_metric, NodesStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats/{metric:metric}/{index_metric:index_metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/stats/{metric}/{index_metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index_metric">Limit the information returned for `indices` metric to the specific index metrics. Isn&#x27;t used if `indices` (or `all`) metric isn&#x27;t specified.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string node_id, string metric, string index_metric, NodesStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/stats/{metric:metric}/{index_metric:index_metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/usage <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UsageForAll<TResponse>(NodesUsageRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_nodes/usage", null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/usage <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UsageForAllAsync<TResponse>(NodesUsageRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_nodes/usage", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/usage <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Usage<TResponse>(string node_id, NodesUsageRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/usage"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/usage <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UsageAsync<TResponse>(string node_id, NodesUsageRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/usage"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/usage/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UsageForAll<TResponse>(string metric, NodesUsageRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/usage/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/usage/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UsageForAllAsync<TResponse>(string metric, NodesUsageRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/usage/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/usage/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Usage<TResponse>(string node_id, string metric, NodesUsageRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_nodes/{node_id:node_id}/usage/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_nodes/{node_id}/usage/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UsageAsync<TResponse>(string node_id, string metric, NodesUsageRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_nodes/{node_id:node_id}/usage/{metric:metric}"), ctx, null, RequestParams(requestParameters));
	}
}