using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.NodesApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.NodesApi
{
	///<summary>
	/// Logically groups all Nodes API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Nodes"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class NodesNamespace : NamespacedClientProxy
	{
		internal NodesNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "INodesHotThreadsRequest"/>
		public NodesHotThreadsResponse HotThreads(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null) => HotThreads(selector.InvokeOrDefault(new NodesHotThreadsDescriptor()));
		///<inheritdoc cref = "INodesHotThreadsRequest"/>
		public Task<NodesHotThreadsResponse> HotThreadsAsync(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null, CancellationToken ct = default) => HotThreadsAsync(selector.InvokeOrDefault(new NodesHotThreadsDescriptor()), ct);
		///<inheritdoc cref = "INodesHotThreadsRequest"/>
		public NodesHotThreadsResponse HotThreads(INodesHotThreadsRequest request) => DoRequest<INodesHotThreadsRequest, NodesHotThreadsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "INodesHotThreadsRequest"/>
		public Task<NodesHotThreadsResponse> HotThreadsAsync(INodesHotThreadsRequest request, CancellationToken ct = default) => DoRequestAsync<INodesHotThreadsRequest, NodesHotThreadsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "INodesInfoRequest"/>
		public NodesInfoResponse Info(Func<NodesInfoDescriptor, INodesInfoRequest> selector = null) => Info(selector.InvokeOrDefault(new NodesInfoDescriptor()));
		///<inheritdoc cref = "INodesInfoRequest"/>
		public Task<NodesInfoResponse> InfoAsync(Func<NodesInfoDescriptor, INodesInfoRequest> selector = null, CancellationToken ct = default) => InfoAsync(selector.InvokeOrDefault(new NodesInfoDescriptor()), ct);
		///<inheritdoc cref = "INodesInfoRequest"/>
		public NodesInfoResponse Info(INodesInfoRequest request) => DoRequest<INodesInfoRequest, NodesInfoResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "INodesInfoRequest"/>
		public Task<NodesInfoResponse> InfoAsync(INodesInfoRequest request, CancellationToken ct = default) => DoRequestAsync<INodesInfoRequest, NodesInfoResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IReloadSecureSettingsRequest"/>
		public ReloadSecureSettingsResponse ReloadSecureSettings(Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null) => ReloadSecureSettings(selector.InvokeOrDefault(new ReloadSecureSettingsDescriptor()));
		///<inheritdoc cref = "IReloadSecureSettingsRequest"/>
		public Task<ReloadSecureSettingsResponse> ReloadSecureSettingsAsync(Func<ReloadSecureSettingsDescriptor, IReloadSecureSettingsRequest> selector = null, CancellationToken ct = default) => ReloadSecureSettingsAsync(selector.InvokeOrDefault(new ReloadSecureSettingsDescriptor()), ct);
		///<inheritdoc cref = "IReloadSecureSettingsRequest"/>
		public ReloadSecureSettingsResponse ReloadSecureSettings(IReloadSecureSettingsRequest request) => DoRequest<IReloadSecureSettingsRequest, ReloadSecureSettingsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IReloadSecureSettingsRequest"/>
		public Task<ReloadSecureSettingsResponse> ReloadSecureSettingsAsync(IReloadSecureSettingsRequest request, CancellationToken ct = default) => DoRequestAsync<IReloadSecureSettingsRequest, ReloadSecureSettingsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "INodesStatsRequest"/>
		public NodesStatsResponse Stats(Func<NodesStatsDescriptor, INodesStatsRequest> selector = null) => Stats(selector.InvokeOrDefault(new NodesStatsDescriptor()));
		///<inheritdoc cref = "INodesStatsRequest"/>
		public Task<NodesStatsResponse> StatsAsync(Func<NodesStatsDescriptor, INodesStatsRequest> selector = null, CancellationToken ct = default) => StatsAsync(selector.InvokeOrDefault(new NodesStatsDescriptor()), ct);
		///<inheritdoc cref = "INodesStatsRequest"/>
		public NodesStatsResponse Stats(INodesStatsRequest request) => DoRequest<INodesStatsRequest, NodesStatsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "INodesStatsRequest"/>
		public Task<NodesStatsResponse> StatsAsync(INodesStatsRequest request, CancellationToken ct = default) => DoRequestAsync<INodesStatsRequest, NodesStatsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "INodesUsageRequest"/>
		public NodesUsageResponse Usage(Func<NodesUsageDescriptor, INodesUsageRequest> selector = null) => Usage(selector.InvokeOrDefault(new NodesUsageDescriptor()));
		///<inheritdoc cref = "INodesUsageRequest"/>
		public Task<NodesUsageResponse> UsageAsync(Func<NodesUsageDescriptor, INodesUsageRequest> selector = null, CancellationToken ct = default) => UsageAsync(selector.InvokeOrDefault(new NodesUsageDescriptor()), ct);
		///<inheritdoc cref = "INodesUsageRequest"/>
		public NodesUsageResponse Usage(INodesUsageRequest request) => DoRequest<INodesUsageRequest, NodesUsageResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "INodesUsageRequest"/>
		public Task<NodesUsageResponse> UsageAsync(INodesUsageRequest request, CancellationToken ct = default) => DoRequestAsync<INodesUsageRequest, NodesUsageResponse>(request, request.RequestParameters, ct);
	}
}