using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.ClusterApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.ClusterApi
{
	///<summary>
	/// Logically groups all Cluster API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Cluster"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class ClusterNamespace : NamespacedClientProxy
	{
		internal ClusterNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IClusterAllocationExplainRequest"/>
		public ClusterAllocationExplainResponse AllocationExplain(Func<ClusterAllocationExplainDescriptor, IClusterAllocationExplainRequest> selector = null) => AllocationExplain(selector.InvokeOrDefault(new ClusterAllocationExplainDescriptor()));
		///<inheritdoc cref = "IClusterAllocationExplainRequest"/>
		public Task<ClusterAllocationExplainResponse> AllocationExplainAsync(Func<ClusterAllocationExplainDescriptor, IClusterAllocationExplainRequest> selector = null, CancellationToken ct = default) => AllocationExplainAsync(selector.InvokeOrDefault(new ClusterAllocationExplainDescriptor()), ct);
		///<inheritdoc cref = "IClusterAllocationExplainRequest"/>
		public ClusterAllocationExplainResponse AllocationExplain(IClusterAllocationExplainRequest request) => DoRequest<IClusterAllocationExplainRequest, ClusterAllocationExplainResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterAllocationExplainRequest"/>
		public Task<ClusterAllocationExplainResponse> AllocationExplainAsync(IClusterAllocationExplainRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterAllocationExplainRequest, ClusterAllocationExplainResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterGetSettingsRequest"/>
		public ClusterGetSettingsResponse GetSettings(Func<ClusterGetSettingsDescriptor, IClusterGetSettingsRequest> selector = null) => GetSettings(selector.InvokeOrDefault(new ClusterGetSettingsDescriptor()));
		///<inheritdoc cref = "IClusterGetSettingsRequest"/>
		public Task<ClusterGetSettingsResponse> GetSettingsAsync(Func<ClusterGetSettingsDescriptor, IClusterGetSettingsRequest> selector = null, CancellationToken ct = default) => GetSettingsAsync(selector.InvokeOrDefault(new ClusterGetSettingsDescriptor()), ct);
		///<inheritdoc cref = "IClusterGetSettingsRequest"/>
		public ClusterGetSettingsResponse GetSettings(IClusterGetSettingsRequest request) => DoRequest<IClusterGetSettingsRequest, ClusterGetSettingsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterGetSettingsRequest"/>
		public Task<ClusterGetSettingsResponse> GetSettingsAsync(IClusterGetSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterGetSettingsRequest, ClusterGetSettingsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterHealthRequest"/>
		public ClusterHealthResponse Health(Indices index = null, Func<ClusterHealthDescriptor, IClusterHealthRequest> selector = null) => Health(selector.InvokeOrDefault(new ClusterHealthDescriptor().Index(index: index)));
		///<inheritdoc cref = "IClusterHealthRequest"/>
		public Task<ClusterHealthResponse> HealthAsync(Indices index = null, Func<ClusterHealthDescriptor, IClusterHealthRequest> selector = null, CancellationToken ct = default) => HealthAsync(selector.InvokeOrDefault(new ClusterHealthDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IClusterHealthRequest"/>
		public ClusterHealthResponse Health(IClusterHealthRequest request) => DoRequest<IClusterHealthRequest, ClusterHealthResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterHealthRequest"/>
		public Task<ClusterHealthResponse> HealthAsync(IClusterHealthRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterHealthRequest, ClusterHealthResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterPendingTasksRequest"/>
		public ClusterPendingTasksResponse PendingTasks(Func<ClusterPendingTasksDescriptor, IClusterPendingTasksRequest> selector = null) => PendingTasks(selector.InvokeOrDefault(new ClusterPendingTasksDescriptor()));
		///<inheritdoc cref = "IClusterPendingTasksRequest"/>
		public Task<ClusterPendingTasksResponse> PendingTasksAsync(Func<ClusterPendingTasksDescriptor, IClusterPendingTasksRequest> selector = null, CancellationToken ct = default) => PendingTasksAsync(selector.InvokeOrDefault(new ClusterPendingTasksDescriptor()), ct);
		///<inheritdoc cref = "IClusterPendingTasksRequest"/>
		public ClusterPendingTasksResponse PendingTasks(IClusterPendingTasksRequest request) => DoRequest<IClusterPendingTasksRequest, ClusterPendingTasksResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterPendingTasksRequest"/>
		public Task<ClusterPendingTasksResponse> PendingTasksAsync(IClusterPendingTasksRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterPendingTasksRequest, ClusterPendingTasksResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterPutSettingsRequest"/>
		public ClusterPutSettingsResponse PutSettings(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector) => PutSettings(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()));
		///<inheritdoc cref = "IClusterPutSettingsRequest"/>
		public Task<ClusterPutSettingsResponse> PutSettingsAsync(Func<ClusterPutSettingsDescriptor, IClusterPutSettingsRequest> selector, CancellationToken ct = default) => PutSettingsAsync(selector.InvokeOrDefault(new ClusterPutSettingsDescriptor()), ct);
		///<inheritdoc cref = "IClusterPutSettingsRequest"/>
		public ClusterPutSettingsResponse PutSettings(IClusterPutSettingsRequest request) => DoRequest<IClusterPutSettingsRequest, ClusterPutSettingsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterPutSettingsRequest"/>
		public Task<ClusterPutSettingsResponse> PutSettingsAsync(IClusterPutSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterPutSettingsRequest, ClusterPutSettingsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IRemoteInfoRequest"/>
		public RemoteInfoResponse RemoteInfo(Func<RemoteInfoDescriptor, IRemoteInfoRequest> selector = null) => RemoteInfo(selector.InvokeOrDefault(new RemoteInfoDescriptor()));
		///<inheritdoc cref = "IRemoteInfoRequest"/>
		public Task<RemoteInfoResponse> RemoteInfoAsync(Func<RemoteInfoDescriptor, IRemoteInfoRequest> selector = null, CancellationToken ct = default) => RemoteInfoAsync(selector.InvokeOrDefault(new RemoteInfoDescriptor()), ct);
		///<inheritdoc cref = "IRemoteInfoRequest"/>
		public RemoteInfoResponse RemoteInfo(IRemoteInfoRequest request) => DoRequest<IRemoteInfoRequest, RemoteInfoResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IRemoteInfoRequest"/>
		public Task<RemoteInfoResponse> RemoteInfoAsync(IRemoteInfoRequest request, CancellationToken ct = default) => DoRequestAsync<IRemoteInfoRequest, RemoteInfoResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterRerouteRequest"/>
		public ClusterRerouteResponse Reroute(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector = null) => Reroute(selector.InvokeOrDefault(new ClusterRerouteDescriptor()));
		///<inheritdoc cref = "IClusterRerouteRequest"/>
		public Task<ClusterRerouteResponse> RerouteAsync(Func<ClusterRerouteDescriptor, IClusterRerouteRequest> selector = null, CancellationToken ct = default) => RerouteAsync(selector.InvokeOrDefault(new ClusterRerouteDescriptor()), ct);
		///<inheritdoc cref = "IClusterRerouteRequest"/>
		public ClusterRerouteResponse Reroute(IClusterRerouteRequest request) => DoRequest<IClusterRerouteRequest, ClusterRerouteResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterRerouteRequest"/>
		public Task<ClusterRerouteResponse> RerouteAsync(IClusterRerouteRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterRerouteRequest, ClusterRerouteResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterStateRequest"/>
		public ClusterStateResponse State(Indices index = null, Func<ClusterStateDescriptor, IClusterStateRequest> selector = null) => State(selector.InvokeOrDefault(new ClusterStateDescriptor().Index(index: index)));
		///<inheritdoc cref = "IClusterStateRequest"/>
		public Task<ClusterStateResponse> StateAsync(Indices index = null, Func<ClusterStateDescriptor, IClusterStateRequest> selector = null, CancellationToken ct = default) => StateAsync(selector.InvokeOrDefault(new ClusterStateDescriptor().Index(index: index)), ct);
		///<inheritdoc cref = "IClusterStateRequest"/>
		public ClusterStateResponse State(IClusterStateRequest request) => DoRequest<IClusterStateRequest, ClusterStateResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterStateRequest"/>
		public Task<ClusterStateResponse> StateAsync(IClusterStateRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterStateRequest, ClusterStateResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClusterStatsRequest"/>
		public ClusterStatsResponse Stats(Func<ClusterStatsDescriptor, IClusterStatsRequest> selector = null) => Stats(selector.InvokeOrDefault(new ClusterStatsDescriptor()));
		///<inheritdoc cref = "IClusterStatsRequest"/>
		public Task<ClusterStatsResponse> StatsAsync(Func<ClusterStatsDescriptor, IClusterStatsRequest> selector = null, CancellationToken ct = default) => StatsAsync(selector.InvokeOrDefault(new ClusterStatsDescriptor()), ct);
		///<inheritdoc cref = "IClusterStatsRequest"/>
		public ClusterStatsResponse Stats(IClusterStatsRequest request) => DoRequest<IClusterStatsRequest, ClusterStatsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClusterStatsRequest"/>
		public Task<ClusterStatsResponse> StatsAsync(IClusterStatsRequest request, CancellationToken ct = default) => DoRequestAsync<IClusterStatsRequest, ClusterStatsResponse>(request, request.RequestParameters, ct);
	}
}