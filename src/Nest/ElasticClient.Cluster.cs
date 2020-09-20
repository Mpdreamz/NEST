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
using System.Threading;
using System.Threading.Tasks;
using Elastic.Transport;
using Elasticsearch.Net.Specification.ClusterApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace Nest.Specification.ClusterApi
{
	///<summary>
	/// Cluster APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticClient.Cluster"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class ClusterNamespace : NamespacedClientProxy
	{
		internal ClusterNamespace(ElasticClient client): base(client)
		{
		}

		/// <summary>
		/// <c>POST</c> request to the <c>cluster.allocation_explain</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</a>
		/// </summary>
		public ClusterAllocationExplainResponse AllocationExplain(Func<ClusterAllocationExplainDescriptor, IClusterAllocationExplainRequest> selector = null) => AllocationExplain(selector.InvokeOrDefault(new ClusterAllocationExplainDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.allocation_explain</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</a>
		/// </summary>
		public Task<ClusterAllocationExplainResponse> AllocationExplainAsync(Func<ClusterAllocationExplainDescriptor, IClusterAllocationExplainRequest> selector = null, CancellationToken ct = default) => AllocationExplainAsync(selector.InvokeOrDefault(new ClusterAllocationExplainDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.allocation_explain</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</a>
		/// </summary>
		public ClusterAllocationExplainResponse AllocationExplain(IClusterAllocationExplainRequest request) => DoRequest<IClusterAllocationExplainRequest, ClusterAllocationExplainResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.allocation_explain</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-allocation-explain.html</a>
		/// </summary>
		public Task<ClusterAllocationExplainResponse> AllocationExplainAsync(IClusterAllocationExplainRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterAllocationExplainRequest, ClusterAllocationExplainResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>cluster.delete_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public DeleteVotingConfigExclusionsResponse DeleteVotingConfigExclusions(Func<DeleteVotingConfigExclusionsDescriptor, IDeleteVotingConfigExclusionsRequest> selector = null) => DeleteVotingConfigExclusions(selector.InvokeOrDefault(new DeleteVotingConfigExclusionsDescriptor()));
		/// <summary>
		/// <c>DELETE</c> request to the <c>cluster.delete_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public Task<DeleteVotingConfigExclusionsResponse> DeleteVotingConfigExclusionsAsync(Func<DeleteVotingConfigExclusionsDescriptor, IDeleteVotingConfigExclusionsRequest> selector = null, CancellationToken ct = default) => DeleteVotingConfigExclusionsAsync(selector.InvokeOrDefault(new DeleteVotingConfigExclusionsDescriptor()), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>cluster.delete_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public DeleteVotingConfigExclusionsResponse DeleteVotingConfigExclusions(IDeleteVotingConfigExclusionsRequest request) => DoRequest<IDeleteVotingConfigExclusionsRequest, DeleteVotingConfigExclusionsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>cluster.delete_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public Task<DeleteVotingConfigExclusionsResponse> DeleteVotingConfigExclusionsAsync(IDeleteVotingConfigExclusionsRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteVotingConfigExclusionsRequest, DeleteVotingConfigExclusionsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.get_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public ClusterGetSettingsResponse GetSettings(Func<ClusterGetSettingsDescriptor, IClusterGetSettingsRequest> selector = null) => GetSettings(selector.InvokeOrDefault(new ClusterGetSettingsDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.get_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public Task<ClusterGetSettingsResponse> GetSettingsAsync(Func<ClusterGetSettingsDescriptor, IClusterGetSettingsRequest> selector = null, CancellationToken ct = default) => GetSettingsAsync(selector.InvokeOrDefault(new ClusterGetSettingsDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.get_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public ClusterGetSettingsResponse GetSettings(IClusterGetSettingsRequest request) => DoRequest<IClusterGetSettingsRequest, ClusterGetSettingsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.get_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public Task<ClusterGetSettingsResponse> GetSettingsAsync(IClusterGetSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterGetSettingsRequest, ClusterGetSettingsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.health</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</a>
		/// </summary>
		public ClusterHealthResponse Health(Indices index = null, Func<ClusterHealthDescriptor, IClusterHealthRequest> selector = null) => Health(selector.InvokeOrDefault(new ClusterHealthDescriptor().Index(index: index)));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.health</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</a>
		/// </summary>
		public Task<ClusterHealthResponse> HealthAsync(Indices index = null, Func<ClusterHealthDescriptor, IClusterHealthRequest> selector = null, CancellationToken ct = default) => HealthAsync(selector.InvokeOrDefault(new ClusterHealthDescriptor().Index(index: index)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.health</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</a>
		/// </summary>
		public ClusterHealthResponse Health(IClusterHealthRequest request) => DoRequest<IClusterHealthRequest, ClusterHealthResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.health</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-health.html</a>
		/// </summary>
		public Task<ClusterHealthResponse> HealthAsync(IClusterHealthRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterHealthRequest, ClusterHealthResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.pending_tasks</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</a>
		/// </summary>
		public ClusterPendingTasksResponse PendingTasks(Func<ClusterPendingTasksDescriptor, IClusterPendingTasksRequest> selector = null) => PendingTasks(selector.InvokeOrDefault(new ClusterPendingTasksDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.pending_tasks</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</a>
		/// </summary>
		public Task<ClusterPendingTasksResponse> PendingTasksAsync(Func<ClusterPendingTasksDescriptor, IClusterPendingTasksRequest> selector = null, CancellationToken ct = default) => PendingTasksAsync(selector.InvokeOrDefault(new ClusterPendingTasksDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.pending_tasks</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</a>
		/// </summary>
		public ClusterPendingTasksResponse PendingTasks(IClusterPendingTasksRequest request) => DoRequest<IClusterPendingTasksRequest, ClusterPendingTasksResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.pending_tasks</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-pending.html</a>
		/// </summary>
		public Task<ClusterPendingTasksResponse> PendingTasksAsync(IClusterPendingTasksRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterPendingTasksRequest, ClusterPendingTasksResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.post_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public PostVotingConfigExclusionsResponse PostVotingConfigExclusions(Func<PostVotingConfigExclusionsDescriptor, IPostVotingConfigExclusionsRequest> selector = null) => PostVotingConfigExclusions(selector.InvokeOrDefault(new PostVotingConfigExclusionsDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.post_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public Task<PostVotingConfigExclusionsResponse> PostVotingConfigExclusionsAsync(Func<PostVotingConfigExclusionsDescriptor, IPostVotingConfigExclusionsRequest> selector = null, CancellationToken ct = default) => PostVotingConfigExclusionsAsync(selector.InvokeOrDefault(new PostVotingConfigExclusionsDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.post_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public PostVotingConfigExclusionsResponse PostVotingConfigExclusions(IPostVotingConfigExclusionsRequest request) => DoRequest<IPostVotingConfigExclusionsRequest, PostVotingConfigExclusionsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.post_voting_config_exclusions</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/voting-config-exclusions.html</a>
		/// </summary>
		public Task<PostVotingConfigExclusionsResponse> PostVotingConfigExclusionsAsync(IPostVotingConfigExclusionsRequest request, CancellationToken ct = default) => DoRequestAsync<IPostVotingConfigExclusionsRequest, PostVotingConfigExclusionsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>cluster.put_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public ClusterPutSettingsResponse PutSettings(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector) => PutSettings(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()));
		/// <summary>
		/// <c>PUT</c> request to the <c>cluster.put_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public Task<ClusterPutSettingsResponse> PutSettingsAsync(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector, CancellationToken ct = default) => PutSettingsAsync(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>cluster.put_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public ClusterPutSettingsResponse PutSettings(IClusterPutSettingsRequest request) => DoRequest<IClusterPutSettingsRequest, ClusterPutSettingsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>cluster.put_settings</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-update-settings.html</a>
		/// </summary>
		public Task<ClusterPutSettingsResponse> PutSettingsAsync(IClusterPutSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterPutSettingsRequest, ClusterPutSettingsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.remote_info</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</a>
		/// </summary>
		public RemoteInfoResponse RemoteInfo(Func<RemoteInfoDescriptor, IRemoteInfoRequest> selector = null) => RemoteInfo(selector.InvokeOrDefault(new RemoteInfoDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.remote_info</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</a>
		/// </summary>
		public Task<RemoteInfoResponse> RemoteInfoAsync(Func<RemoteInfoDescriptor, IRemoteInfoRequest> selector = null, CancellationToken ct = default) => RemoteInfoAsync(selector.InvokeOrDefault(new RemoteInfoDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.remote_info</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</a>
		/// </summary>
		public RemoteInfoResponse RemoteInfo(IRemoteInfoRequest request) => DoRequest<IRemoteInfoRequest, RemoteInfoResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.remote_info</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-remote-info.html</a>
		/// </summary>
		public Task<RemoteInfoResponse> RemoteInfoAsync(IRemoteInfoRequest request, CancellationToken ct = default) => DoRequestAsync<IRemoteInfoRequest, RemoteInfoResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.reroute</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</a>
		/// </summary>
		public ClusterRerouteResponse Reroute(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector = null) => Reroute(selector.InvokeOrDefault(new ClusterRerouteDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.reroute</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</a>
		/// </summary>
		public Task<ClusterRerouteResponse> RerouteAsync(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector = null, CancellationToken ct = default) => RerouteAsync(selector.InvokeOrDefault(new ClusterRerouteDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.reroute</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</a>
		/// </summary>
		public ClusterRerouteResponse Reroute(IClusterRerouteRequest request) => DoRequest<IClusterRerouteRequest, ClusterRerouteResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>cluster.reroute</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-reroute.html</a>
		/// </summary>
		public Task<ClusterRerouteResponse> RerouteAsync(IClusterRerouteRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterRerouteRequest, ClusterRerouteResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.state</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</a>
		/// </summary>
		public ClusterStateResponse State(Indices index = null, Func<ClusterStateDescriptor, IClusterStateRequest> selector = null) => State(selector.InvokeOrDefault(new ClusterStateDescriptor().Index(index: index)));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.state</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</a>
		/// </summary>
		public Task<ClusterStateResponse> StateAsync(Indices index = null, Func<ClusterStateDescriptor, IClusterStateRequest> selector = null, CancellationToken ct = default) => StateAsync(selector.InvokeOrDefault(new ClusterStateDescriptor().Index(index: index)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.state</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</a>
		/// </summary>
		public ClusterStateResponse State(IClusterStateRequest request) => DoRequest<IClusterStateRequest, ClusterStateResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.state</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-state.html</a>
		/// </summary>
		public Task<ClusterStateResponse> StateAsync(IClusterStateRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterStateRequest, ClusterStateResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</a>
		/// </summary>
		public ClusterStatsResponse Stats(Func<ClusterStatsDescriptor, IClusterStatsRequest> selector = null) => Stats(selector.InvokeOrDefault(new ClusterStatsDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</a>
		/// </summary>
		public Task<ClusterStatsResponse> StatsAsync(Func<ClusterStatsDescriptor, IClusterStatsRequest> selector = null, CancellationToken ct = default) => StatsAsync(selector.InvokeOrDefault(new ClusterStatsDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</a>
		/// </summary>
		public ClusterStatsResponse Stats(IClusterStatsRequest request) => DoRequest<IClusterStatsRequest, ClusterStatsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>cluster.stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-stats.html</a>
		/// </summary>
		public Task<ClusterStatsResponse> StatsAsync(IClusterStatsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterStatsRequest, ClusterStatsResponse>(request, request.RequestParameters, ct);
	}
}