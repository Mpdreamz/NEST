using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.CatApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.CatApi
{
	///<summary>
	/// Logically groups all Cat API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Cat"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class CatNamespace : NamespacedClientProxy
	{
		internal CatNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "ICatAliasesRequest"/>
		public CatResponse<CatAliasesRecord> Aliases(Func<CatAliasesDescriptor, ICatAliasesRequest> selector = null) => Aliases(selector.InvokeOrDefault(new CatAliasesDescriptor()));
		///<inheritdoc cref = "ICatAliasesRequest"/>
		public Task<CatResponse<CatAliasesRecord>> AliasesAsync(Func<CatAliasesDescriptor, ICatAliasesRequest> selector = null, CancellationToken ct = default) => AliasesAsync(selector.InvokeOrDefault(new CatAliasesDescriptor()), ct);
		///<inheritdoc cref = "ICatAliasesRequest"/>
		public CatResponse<CatAliasesRecord> Aliases(ICatAliasesRequest request) => DoCat<ICatAliasesRequest, CatAliasesRequestParameters, CatAliasesRecord>(request);
		///<inheritdoc cref = "ICatAliasesRequest"/>
		public Task<CatResponse<CatAliasesRecord>> AliasesAsync(ICatAliasesRequest request, CancellationToken ct = default) => DoCatAsync<ICatAliasesRequest, CatAliasesRequestParameters, CatAliasesRecord>(request, ct);
		///<inheritdoc cref = "ICatAllocationRequest"/>
		public CatResponse<CatAllocationRecord> Allocation(Func<CatAllocationDescriptor, ICatAllocationRequest> selector = null) => Allocation(selector.InvokeOrDefault(new CatAllocationDescriptor()));
		///<inheritdoc cref = "ICatAllocationRequest"/>
		public Task<CatResponse<CatAllocationRecord>> AllocationAsync(Func<CatAllocationDescriptor, ICatAllocationRequest> selector = null, CancellationToken ct = default) => AllocationAsync(selector.InvokeOrDefault(new CatAllocationDescriptor()), ct);
		///<inheritdoc cref = "ICatAllocationRequest"/>
		public CatResponse<CatAllocationRecord> Allocation(ICatAllocationRequest request) => DoCat<ICatAllocationRequest, CatAllocationRequestParameters, CatAllocationRecord>(request);
		///<inheritdoc cref = "ICatAllocationRequest"/>
		public Task<CatResponse<CatAllocationRecord>> AllocationAsync(ICatAllocationRequest request, CancellationToken ct = default) => DoCatAsync<ICatAllocationRequest, CatAllocationRequestParameters, CatAllocationRecord>(request, ct);
		///<inheritdoc cref = "ICatCountRequest"/>
		public CatResponse<CatCountRecord> Count(Func<CatCountDescriptor, ICatCountRequest> selector = null) => Count(selector.InvokeOrDefault(new CatCountDescriptor()));
		///<inheritdoc cref = "ICatCountRequest"/>
		public Task<CatResponse<CatCountRecord>> CountAsync(Func<CatCountDescriptor, ICatCountRequest> selector = null, CancellationToken ct = default) => CountAsync(selector.InvokeOrDefault(new CatCountDescriptor()), ct);
		///<inheritdoc cref = "ICatCountRequest"/>
		public CatResponse<CatCountRecord> Count(ICatCountRequest request) => DoCat<ICatCountRequest, CatCountRequestParameters, CatCountRecord>(request);
		///<inheritdoc cref = "ICatCountRequest"/>
		public Task<CatResponse<CatCountRecord>> CountAsync(ICatCountRequest request, CancellationToken ct = default) => DoCatAsync<ICatCountRequest, CatCountRequestParameters, CatCountRecord>(request, ct);
		///<inheritdoc cref = "ICatFielddataRequest"/>
		public CatResponse<CatFielddataRecord> Fielddata(Func<CatFielddataDescriptor, ICatFielddataRequest> selector = null) => Fielddata(selector.InvokeOrDefault(new CatFielddataDescriptor()));
		///<inheritdoc cref = "ICatFielddataRequest"/>
		public Task<CatResponse<CatFielddataRecord>> FielddataAsync(Func<CatFielddataDescriptor, ICatFielddataRequest> selector = null, CancellationToken ct = default) => FielddataAsync(selector.InvokeOrDefault(new CatFielddataDescriptor()), ct);
		///<inheritdoc cref = "ICatFielddataRequest"/>
		public CatResponse<CatFielddataRecord> Fielddata(ICatFielddataRequest request) => DoCat<ICatFielddataRequest, CatFielddataRequestParameters, CatFielddataRecord>(request);
		///<inheritdoc cref = "ICatFielddataRequest"/>
		public Task<CatResponse<CatFielddataRecord>> FielddataAsync(ICatFielddataRequest request, CancellationToken ct = default) => DoCatAsync<ICatFielddataRequest, CatFielddataRequestParameters, CatFielddataRecord>(request, ct);
		///<inheritdoc cref = "ICatHealthRequest"/>
		public CatResponse<CatHealthRecord> Health(Func<CatHealthDescriptor, ICatHealthRequest> selector = null) => Health(selector.InvokeOrDefault(new CatHealthDescriptor()));
		///<inheritdoc cref = "ICatHealthRequest"/>
		public Task<CatResponse<CatHealthRecord>> HealthAsync(Func<CatHealthDescriptor, ICatHealthRequest> selector = null, CancellationToken ct = default) => HealthAsync(selector.InvokeOrDefault(new CatHealthDescriptor()), ct);
		///<inheritdoc cref = "ICatHealthRequest"/>
		public CatResponse<CatHealthRecord> Health(ICatHealthRequest request) => DoCat<ICatHealthRequest, CatHealthRequestParameters, CatHealthRecord>(request);
		///<inheritdoc cref = "ICatHealthRequest"/>
		public Task<CatResponse<CatHealthRecord>> HealthAsync(ICatHealthRequest request, CancellationToken ct = default) => DoCatAsync<ICatHealthRequest, CatHealthRequestParameters, CatHealthRecord>(request, ct);
		///<inheritdoc cref = "ICatHelpRequest"/>
		public CatResponse<CatHelpRecord> Help(Func<CatHelpDescriptor, ICatHelpRequest> selector = null) => Help(selector.InvokeOrDefault(new CatHelpDescriptor()));
		///<inheritdoc cref = "ICatHelpRequest"/>
		public Task<CatResponse<CatHelpRecord>> HelpAsync(Func<CatHelpDescriptor, ICatHelpRequest> selector = null, CancellationToken ct = default) => HelpAsync(selector.InvokeOrDefault(new CatHelpDescriptor()), ct);
		///<inheritdoc cref = "ICatHelpRequest"/>
		public CatResponse<CatHelpRecord> Help(ICatHelpRequest request) => DoCat<ICatHelpRequest, CatHelpRequestParameters, CatHelpRecord>(request);
		///<inheritdoc cref = "ICatHelpRequest"/>
		public Task<CatResponse<CatHelpRecord>> HelpAsync(ICatHelpRequest request, CancellationToken ct = default) => DoCatAsync<ICatHelpRequest, CatHelpRequestParameters, CatHelpRecord>(request, ct);
		///<inheritdoc cref = "ICatIndicesRequest"/>
		public CatResponse<CatIndicesRecord> Indices(Func<CatIndicesDescriptor, ICatIndicesRequest> selector = null) => Indices(selector.InvokeOrDefault(new CatIndicesDescriptor()));
		///<inheritdoc cref = "ICatIndicesRequest"/>
		public Task<CatResponse<CatIndicesRecord>> IndicesAsync(Func<CatIndicesDescriptor, ICatIndicesRequest> selector = null, CancellationToken ct = default) => IndicesAsync(selector.InvokeOrDefault(new CatIndicesDescriptor()), ct);
		///<inheritdoc cref = "ICatIndicesRequest"/>
		public CatResponse<CatIndicesRecord> Indices(ICatIndicesRequest request) => DoCat<ICatIndicesRequest, CatIndicesRequestParameters, CatIndicesRecord>(request);
		///<inheritdoc cref = "ICatIndicesRequest"/>
		public Task<CatResponse<CatIndicesRecord>> IndicesAsync(ICatIndicesRequest request, CancellationToken ct = default) => DoCatAsync<ICatIndicesRequest, CatIndicesRequestParameters, CatIndicesRecord>(request, ct);
		///<inheritdoc cref = "ICatMasterRequest"/>
		public CatResponse<CatMasterRecord> Master(Func<CatMasterDescriptor, ICatMasterRequest> selector = null) => Master(selector.InvokeOrDefault(new CatMasterDescriptor()));
		///<inheritdoc cref = "ICatMasterRequest"/>
		public Task<CatResponse<CatMasterRecord>> MasterAsync(Func<CatMasterDescriptor, ICatMasterRequest> selector = null, CancellationToken ct = default) => MasterAsync(selector.InvokeOrDefault(new CatMasterDescriptor()), ct);
		///<inheritdoc cref = "ICatMasterRequest"/>
		public CatResponse<CatMasterRecord> Master(ICatMasterRequest request) => DoCat<ICatMasterRequest, CatMasterRequestParameters, CatMasterRecord>(request);
		///<inheritdoc cref = "ICatMasterRequest"/>
		public Task<CatResponse<CatMasterRecord>> MasterAsync(ICatMasterRequest request, CancellationToken ct = default) => DoCatAsync<ICatMasterRequest, CatMasterRequestParameters, CatMasterRecord>(request, ct);
		///<inheritdoc cref = "ICatNodeAttributesRequest"/>
		public CatResponse<CatNodeAttributesRecord> NodeAttributes(Func<CatNodeAttributesDescriptor, ICatNodeAttributesRequest> selector = null) => NodeAttributes(selector.InvokeOrDefault(new CatNodeAttributesDescriptor()));
		///<inheritdoc cref = "ICatNodeAttributesRequest"/>
		public Task<CatResponse<CatNodeAttributesRecord>> NodeAttributesAsync(Func<CatNodeAttributesDescriptor, ICatNodeAttributesRequest> selector = null, CancellationToken ct = default) => NodeAttributesAsync(selector.InvokeOrDefault(new CatNodeAttributesDescriptor()), ct);
		///<inheritdoc cref = "ICatNodeAttributesRequest"/>
		public CatResponse<CatNodeAttributesRecord> NodeAttributes(ICatNodeAttributesRequest request) => DoCat<ICatNodeAttributesRequest, CatNodeAttributesRequestParameters, CatNodeAttributesRecord>(request);
		///<inheritdoc cref = "ICatNodeAttributesRequest"/>
		public Task<CatResponse<CatNodeAttributesRecord>> NodeAttributesAsync(ICatNodeAttributesRequest request, CancellationToken ct = default) => DoCatAsync<ICatNodeAttributesRequest, CatNodeAttributesRequestParameters, CatNodeAttributesRecord>(request, ct);
		///<inheritdoc cref = "ICatNodesRequest"/>
		public CatResponse<CatNodesRecord> Nodes(Func<CatNodesDescriptor, ICatNodesRequest> selector = null) => Nodes(selector.InvokeOrDefault(new CatNodesDescriptor()));
		///<inheritdoc cref = "ICatNodesRequest"/>
		public Task<CatResponse<CatNodesRecord>> NodesAsync(Func<CatNodesDescriptor, ICatNodesRequest> selector = null, CancellationToken ct = default) => NodesAsync(selector.InvokeOrDefault(new CatNodesDescriptor()), ct);
		///<inheritdoc cref = "ICatNodesRequest"/>
		public CatResponse<CatNodesRecord> Nodes(ICatNodesRequest request) => DoCat<ICatNodesRequest, CatNodesRequestParameters, CatNodesRecord>(request);
		///<inheritdoc cref = "ICatNodesRequest"/>
		public Task<CatResponse<CatNodesRecord>> NodesAsync(ICatNodesRequest request, CancellationToken ct = default) => DoCatAsync<ICatNodesRequest, CatNodesRequestParameters, CatNodesRecord>(request, ct);
		///<inheritdoc cref = "ICatPendingTasksRequest"/>
		public CatResponse<CatPendingTasksRecord> PendingTasks(Func<CatPendingTasksDescriptor, ICatPendingTasksRequest> selector = null) => PendingTasks(selector.InvokeOrDefault(new CatPendingTasksDescriptor()));
		///<inheritdoc cref = "ICatPendingTasksRequest"/>
		public Task<CatResponse<CatPendingTasksRecord>> PendingTasksAsync(Func<CatPendingTasksDescriptor, ICatPendingTasksRequest> selector = null, CancellationToken ct = default) => PendingTasksAsync(selector.InvokeOrDefault(new CatPendingTasksDescriptor()), ct);
		///<inheritdoc cref = "ICatPendingTasksRequest"/>
		public CatResponse<CatPendingTasksRecord> PendingTasks(ICatPendingTasksRequest request) => DoCat<ICatPendingTasksRequest, CatPendingTasksRequestParameters, CatPendingTasksRecord>(request);
		///<inheritdoc cref = "ICatPendingTasksRequest"/>
		public Task<CatResponse<CatPendingTasksRecord>> PendingTasksAsync(ICatPendingTasksRequest request, CancellationToken ct = default) => DoCatAsync<ICatPendingTasksRequest, CatPendingTasksRequestParameters, CatPendingTasksRecord>(request, ct);
		///<inheritdoc cref = "ICatPluginsRequest"/>
		public CatResponse<CatPluginsRecord> Plugins(Func<CatPluginsDescriptor, ICatPluginsRequest> selector = null) => Plugins(selector.InvokeOrDefault(new CatPluginsDescriptor()));
		///<inheritdoc cref = "ICatPluginsRequest"/>
		public Task<CatResponse<CatPluginsRecord>> PluginsAsync(Func<CatPluginsDescriptor, ICatPluginsRequest> selector = null, CancellationToken ct = default) => PluginsAsync(selector.InvokeOrDefault(new CatPluginsDescriptor()), ct);
		///<inheritdoc cref = "ICatPluginsRequest"/>
		public CatResponse<CatPluginsRecord> Plugins(ICatPluginsRequest request) => DoCat<ICatPluginsRequest, CatPluginsRequestParameters, CatPluginsRecord>(request);
		///<inheritdoc cref = "ICatPluginsRequest"/>
		public Task<CatResponse<CatPluginsRecord>> PluginsAsync(ICatPluginsRequest request, CancellationToken ct = default) => DoCatAsync<ICatPluginsRequest, CatPluginsRequestParameters, CatPluginsRecord>(request, ct);
		///<inheritdoc cref = "ICatRecoveryRequest"/>
		public CatResponse<CatRecoveryRecord> Recovery(Func<CatRecoveryDescriptor, ICatRecoveryRequest> selector = null) => Recovery(selector.InvokeOrDefault(new CatRecoveryDescriptor()));
		///<inheritdoc cref = "ICatRecoveryRequest"/>
		public Task<CatResponse<CatRecoveryRecord>> RecoveryAsync(Func<CatRecoveryDescriptor, ICatRecoveryRequest> selector = null, CancellationToken ct = default) => RecoveryAsync(selector.InvokeOrDefault(new CatRecoveryDescriptor()), ct);
		///<inheritdoc cref = "ICatRecoveryRequest"/>
		public CatResponse<CatRecoveryRecord> Recovery(ICatRecoveryRequest request) => DoCat<ICatRecoveryRequest, CatRecoveryRequestParameters, CatRecoveryRecord>(request);
		///<inheritdoc cref = "ICatRecoveryRequest"/>
		public Task<CatResponse<CatRecoveryRecord>> RecoveryAsync(ICatRecoveryRequest request, CancellationToken ct = default) => DoCatAsync<ICatRecoveryRequest, CatRecoveryRequestParameters, CatRecoveryRecord>(request, ct);
		///<inheritdoc cref = "ICatRepositoriesRequest"/>
		public CatResponse<CatRepositoriesRecord> Repositories(Func<CatRepositoriesDescriptor, ICatRepositoriesRequest> selector = null) => Repositories(selector.InvokeOrDefault(new CatRepositoriesDescriptor()));
		///<inheritdoc cref = "ICatRepositoriesRequest"/>
		public Task<CatResponse<CatRepositoriesRecord>> RepositoriesAsync(Func<CatRepositoriesDescriptor, ICatRepositoriesRequest> selector = null, CancellationToken ct = default) => RepositoriesAsync(selector.InvokeOrDefault(new CatRepositoriesDescriptor()), ct);
		///<inheritdoc cref = "ICatRepositoriesRequest"/>
		public CatResponse<CatRepositoriesRecord> Repositories(ICatRepositoriesRequest request) => DoCat<ICatRepositoriesRequest, CatRepositoriesRequestParameters, CatRepositoriesRecord>(request);
		///<inheritdoc cref = "ICatRepositoriesRequest"/>
		public Task<CatResponse<CatRepositoriesRecord>> RepositoriesAsync(ICatRepositoriesRequest request, CancellationToken ct = default) => DoCatAsync<ICatRepositoriesRequest, CatRepositoriesRequestParameters, CatRepositoriesRecord>(request, ct);
		///<inheritdoc cref = "ICatSegmentsRequest"/>
		public CatResponse<CatSegmentsRecord> Segments(Func<CatSegmentsDescriptor, ICatSegmentsRequest> selector = null) => Segments(selector.InvokeOrDefault(new CatSegmentsDescriptor()));
		///<inheritdoc cref = "ICatSegmentsRequest"/>
		public Task<CatResponse<CatSegmentsRecord>> SegmentsAsync(Func<CatSegmentsDescriptor, ICatSegmentsRequest> selector = null, CancellationToken ct = default) => SegmentsAsync(selector.InvokeOrDefault(new CatSegmentsDescriptor()), ct);
		///<inheritdoc cref = "ICatSegmentsRequest"/>
		public CatResponse<CatSegmentsRecord> Segments(ICatSegmentsRequest request) => DoCat<ICatSegmentsRequest, CatSegmentsRequestParameters, CatSegmentsRecord>(request);
		///<inheritdoc cref = "ICatSegmentsRequest"/>
		public Task<CatResponse<CatSegmentsRecord>> SegmentsAsync(ICatSegmentsRequest request, CancellationToken ct = default) => DoCatAsync<ICatSegmentsRequest, CatSegmentsRequestParameters, CatSegmentsRecord>(request, ct);
		///<inheritdoc cref = "ICatShardsRequest"/>
		public CatResponse<CatShardsRecord> Shards(Func<CatShardsDescriptor, ICatShardsRequest> selector = null) => Shards(selector.InvokeOrDefault(new CatShardsDescriptor()));
		///<inheritdoc cref = "ICatShardsRequest"/>
		public Task<CatResponse<CatShardsRecord>> ShardsAsync(Func<CatShardsDescriptor, ICatShardsRequest> selector = null, CancellationToken ct = default) => ShardsAsync(selector.InvokeOrDefault(new CatShardsDescriptor()), ct);
		///<inheritdoc cref = "ICatShardsRequest"/>
		public CatResponse<CatShardsRecord> Shards(ICatShardsRequest request) => DoCat<ICatShardsRequest, CatShardsRequestParameters, CatShardsRecord>(request);
		///<inheritdoc cref = "ICatShardsRequest"/>
		public Task<CatResponse<CatShardsRecord>> ShardsAsync(ICatShardsRequest request, CancellationToken ct = default) => DoCatAsync<ICatShardsRequest, CatShardsRequestParameters, CatShardsRecord>(request, ct);
		///<inheritdoc cref = "ICatSnapshotsRequest"/>
		public CatResponse<CatSnapshotsRecord> Snapshots(Func<CatSnapshotsDescriptor, ICatSnapshotsRequest> selector = null) => Snapshots(selector.InvokeOrDefault(new CatSnapshotsDescriptor()));
		///<inheritdoc cref = "ICatSnapshotsRequest"/>
		public Task<CatResponse<CatSnapshotsRecord>> SnapshotsAsync(Func<CatSnapshotsDescriptor, ICatSnapshotsRequest> selector = null, CancellationToken ct = default) => SnapshotsAsync(selector.InvokeOrDefault(new CatSnapshotsDescriptor()), ct);
		///<inheritdoc cref = "ICatSnapshotsRequest"/>
		public CatResponse<CatSnapshotsRecord> Snapshots(ICatSnapshotsRequest request) => DoCat<ICatSnapshotsRequest, CatSnapshotsRequestParameters, CatSnapshotsRecord>(request);
		///<inheritdoc cref = "ICatSnapshotsRequest"/>
		public Task<CatResponse<CatSnapshotsRecord>> SnapshotsAsync(ICatSnapshotsRequest request, CancellationToken ct = default) => DoCatAsync<ICatSnapshotsRequest, CatSnapshotsRequestParameters, CatSnapshotsRecord>(request, ct);
		///<inheritdoc cref = "ICatTasksRequest"/>
		public CatResponse<CatTasksRecord> Tasks(Func<CatTasksDescriptor, ICatTasksRequest> selector = null) => Tasks(selector.InvokeOrDefault(new CatTasksDescriptor()));
		///<inheritdoc cref = "ICatTasksRequest"/>
		public Task<CatResponse<CatTasksRecord>> TasksAsync(Func<CatTasksDescriptor, ICatTasksRequest> selector = null, CancellationToken ct = default) => TasksAsync(selector.InvokeOrDefault(new CatTasksDescriptor()), ct);
		///<inheritdoc cref = "ICatTasksRequest"/>
		public CatResponse<CatTasksRecord> Tasks(ICatTasksRequest request) => DoCat<ICatTasksRequest, CatTasksRequestParameters, CatTasksRecord>(request);
		///<inheritdoc cref = "ICatTasksRequest"/>
		public Task<CatResponse<CatTasksRecord>> TasksAsync(ICatTasksRequest request, CancellationToken ct = default) => DoCatAsync<ICatTasksRequest, CatTasksRequestParameters, CatTasksRecord>(request, ct);
		///<inheritdoc cref = "ICatTemplatesRequest"/>
		public CatResponse<CatTemplatesRecord> Templates(Func<CatTemplatesDescriptor, ICatTemplatesRequest> selector = null) => Templates(selector.InvokeOrDefault(new CatTemplatesDescriptor()));
		///<inheritdoc cref = "ICatTemplatesRequest"/>
		public Task<CatResponse<CatTemplatesRecord>> TemplatesAsync(Func<CatTemplatesDescriptor, ICatTemplatesRequest> selector = null, CancellationToken ct = default) => TemplatesAsync(selector.InvokeOrDefault(new CatTemplatesDescriptor()), ct);
		///<inheritdoc cref = "ICatTemplatesRequest"/>
		public CatResponse<CatTemplatesRecord> Templates(ICatTemplatesRequest request) => DoCat<ICatTemplatesRequest, CatTemplatesRequestParameters, CatTemplatesRecord>(request);
		///<inheritdoc cref = "ICatTemplatesRequest"/>
		public Task<CatResponse<CatTemplatesRecord>> TemplatesAsync(ICatTemplatesRequest request, CancellationToken ct = default) => DoCatAsync<ICatTemplatesRequest, CatTemplatesRequestParameters, CatTemplatesRecord>(request, ct);
		///<inheritdoc cref = "ICatThreadPoolRequest"/>
		public CatResponse<CatThreadPoolRecord> ThreadPool(Func<CatThreadPoolDescriptor, ICatThreadPoolRequest> selector = null) => ThreadPool(selector.InvokeOrDefault(new CatThreadPoolDescriptor()));
		///<inheritdoc cref = "ICatThreadPoolRequest"/>
		public Task<CatResponse<CatThreadPoolRecord>> ThreadPoolAsync(Func<CatThreadPoolDescriptor, ICatThreadPoolRequest> selector = null, CancellationToken ct = default) => ThreadPoolAsync(selector.InvokeOrDefault(new CatThreadPoolDescriptor()), ct);
		///<inheritdoc cref = "ICatThreadPoolRequest"/>
		public CatResponse<CatThreadPoolRecord> ThreadPool(ICatThreadPoolRequest request) => DoCat<ICatThreadPoolRequest, CatThreadPoolRequestParameters, CatThreadPoolRecord>(request);
		///<inheritdoc cref = "ICatThreadPoolRequest"/>
		public Task<CatResponse<CatThreadPoolRecord>> ThreadPoolAsync(ICatThreadPoolRequest request, CancellationToken ct = default) => DoCatAsync<ICatThreadPoolRequest, CatThreadPoolRequestParameters, CatThreadPoolRecord>(request, ct);
	}
}