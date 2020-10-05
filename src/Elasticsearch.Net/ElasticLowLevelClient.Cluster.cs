// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//
// This file is automatically generated
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using static Elasticsearch.Net.HttpMethod;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable once CheckNamespace
// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable RedundantExtendsListEntry
namespace Elasticsearch.Net.Specification.ClusterApi
{
	///<summary>
	/// Cluster APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticLowLevelClient.Cluster"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelClusterNamespace : NamespacedClientProxy
	{
		internal LowLevelClusterNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /_cluster/allocation/explain <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</para></summary>
		///<param name = "body">The index, shard, and primary flag to explain. Empty means &#x27;explain the first unassigned shard&#x27;</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse AllocationExplain<TResponse>(PostData body, ClusterAllocationExplainRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_cluster/allocation/explain", body, RequestParams(requestParameters));
		///<summary>POST on /_cluster/allocation/explain <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</para></summary>
		///<param name = "body">The index, shard, and primary flag to explain. Empty means &#x27;explain the first unassigned shard&#x27;</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.allocation_explain", "body")]
		public Task<TResponse> AllocationExplainAsync<TResponse>(PostData body, ClusterAllocationExplainRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_cluster/allocation/explain", ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse DeleteComponentTemplate<TResponse>(string name, DeleteComponentTemplateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(DELETE, Url($"_component_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("cluster.delete_component_template", "name")]
		public Task<TResponse> DeleteComponentTemplateAsync<TResponse>(string name, DeleteComponentTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_component_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_cluster/voting_config_exclusions <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteVotingConfigExclusions<TResponse>(DeleteVotingConfigExclusionsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(DELETE, "_cluster/voting_config_exclusions", null, RequestParams(requestParameters));
		///<summary>DELETE on /_cluster/voting_config_exclusions <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.delete_voting_config_exclusions", "")]
		public Task<TResponse> DeleteVotingConfigExclusionsAsync<TResponse>(DeleteVotingConfigExclusionsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(DELETE, "_cluster/voting_config_exclusions", ctx, null, RequestParams(requestParameters));
		///<summary>HEAD on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse ExistsComponentTemplate<TResponse>(string name, ExistsComponentTemplateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(HEAD, Url($"_component_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>HEAD on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("cluster.exists_component_template", "name")]
		public Task<TResponse> ExistsComponentTemplateAsync<TResponse>(string name, ExistsComponentTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(HEAD, Url($"_component_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_component_template <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse GetComponentTemplate<TResponse>(GetComponentTemplateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_component_template", null, RequestParams(requestParameters));
		///<summary>GET on /_component_template <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("cluster.get_component_template", "")]
		public Task<TResponse> GetComponentTemplateAsync<TResponse>(GetComponentTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_component_template", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The comma separated names of the component templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse GetComponentTemplate<TResponse>(string name, GetComponentTemplateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_component_template/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The comma separated names of the component templates</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("cluster.get_component_template", "name")]
		public Task<TResponse> GetComponentTemplateAsync<TResponse>(string name, GetComponentTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_component_template/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetSettings<TResponse>(ClusterGetSettingsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_cluster/settings", null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.get_settings", "")]
		public Task<TResponse> GetSettingsAsync<TResponse>(ClusterGetSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_cluster/settings", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/health <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Health<TResponse>(ClusterHealthRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_cluster/health", null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/health <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.health", "")]
		public Task<TResponse> HealthAsync<TResponse>(ClusterHealthRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_cluster/health", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/health/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</para></summary>
		///<param name = "index">Limit the information returned to a specific index</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Health<TResponse>(string index, ClusterHealthRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_cluster/health/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/health/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</para></summary>
		///<param name = "index">Limit the information returned to a specific index</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.health", "index")]
		public Task<TResponse> HealthAsync<TResponse>(string index, ClusterHealthRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cluster/health/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/pending_tasks <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PendingTasks<TResponse>(ClusterPendingTasksRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_cluster/pending_tasks", null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/pending_tasks <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.pending_tasks", "")]
		public Task<TResponse> PendingTasksAsync<TResponse>(ClusterPendingTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_cluster/pending_tasks", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_cluster/voting_config_exclusions <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PostVotingConfigExclusions<TResponse>(PostVotingConfigExclusionsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_cluster/voting_config_exclusions", null, RequestParams(requestParameters));
		///<summary>POST on /_cluster/voting_config_exclusions <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.post_voting_config_exclusions", "")]
		public Task<TResponse> PostVotingConfigExclusionsAsync<TResponse>(PostVotingConfigExclusionsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_cluster/voting_config_exclusions", ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "body">The template definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse PutComponentTemplate<TResponse>(string name, PostData body, PutComponentTemplateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(PUT, Url($"_component_template/{name:name}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_component_template/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/indices-component-template.html</para></summary>
		///<param name = "name">The name of the template</param>
		///<param name = "body">The template definition</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("cluster.put_component_template", "name, body")]
		public Task<TResponse> PutComponentTemplateAsync<TResponse>(string name, PostData body, PutComponentTemplateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_component_template/{name:name}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_cluster/settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</para></summary>
		///<param name = "body">The settings to be updated. Can be either `transient` or `persistent` (survives cluster restart).</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutSettings<TResponse>(PostData body, ClusterPutSettingsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(PUT, "_cluster/settings", body, RequestParams(requestParameters));
		///<summary>PUT on /_cluster/settings <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</para></summary>
		///<param name = "body">The settings to be updated. Can be either `transient` or `persistent` (survives cluster restart).</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.put_settings", "body")]
		public Task<TResponse> PutSettingsAsync<TResponse>(PostData body, ClusterPutSettingsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(PUT, "_cluster/settings", ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_remote/info <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RemoteInfo<TResponse>(RemoteInfoRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_remote/info", null, RequestParams(requestParameters));
		///<summary>GET on /_remote/info <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.remote_info", "")]
		public Task<TResponse> RemoteInfoAsync<TResponse>(RemoteInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_remote/info", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_cluster/reroute <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</para></summary>
		///<param name = "body">The definition of `commands` to perform (`move`, `cancel`, `allocate`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Reroute<TResponse>(PostData body, ClusterRerouteRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_cluster/reroute", body, RequestParams(requestParameters));
		///<summary>POST on /_cluster/reroute <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</para></summary>
		///<param name = "body">The definition of `commands` to perform (`move`, `cancel`, `allocate`)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.reroute", "body")]
		public Task<TResponse> RerouteAsync<TResponse>(PostData body, ClusterRerouteRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_cluster/reroute", ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse State<TResponse>(ClusterStateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_cluster/state", null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.state", "")]
		public Task<TResponse> StateAsync<TResponse>(ClusterStateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_cluster/state", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state/{metric} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse State<TResponse>(string metric, ClusterStateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_cluster/state/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state/{metric} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.state", "metric")]
		public Task<TResponse> StateAsync<TResponse>(string metric, ClusterStateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cluster/state/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state/{metric}/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse State<TResponse>(string metric, string index, ClusterStateRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_cluster/state/{metric:metric}/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/state/{metric}/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</para></summary>
		///<param name = "metric">Limit the information returned to the specified metrics</param>
		///<param name = "index">A comma-separated list of index names; use the special string `_all` or Indices.All to perform the operation on all indices</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.state", "metric, index")]
		public Task<TResponse> StateAsync<TResponse>(string metric, string index, ClusterStateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cluster/state/{metric:metric}/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(ClusterStatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_cluster/stats", null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.stats", "")]
		public Task<TResponse> StatsAsync<TResponse>(ClusterStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_cluster/stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/stats/nodes/{node_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</para></summary>
		///<param name = "nodeId">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string nodeId, ClusterStatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_cluster/stats/nodes/{nodeId:nodeId}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cluster/stats/nodes/{node_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</para></summary>
		///<param name = "nodeId">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("cluster.stats", "node_id")]
		public Task<TResponse> StatsAsync<TResponse>(string nodeId, ClusterStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cluster/stats/nodes/{nodeId:nodeId}"), ctx, null, RequestParams(requestParameters));
	}
}
