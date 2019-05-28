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
using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.CrossClusterReplicationApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.CrossClusterReplicationApi
{
	///<summary>
	/// Logically groups all CrossClusterReplication API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.CrossClusterReplication"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class CrossClusterReplicationNamespace : NamespacedClientProxy
	{
		internal CrossClusterReplicationNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IDeleteAutoFollowPatternRequest"/>
		public DeleteAutoFollowPatternResponse DeleteAutoFollowPattern(Name name, Func<DeleteAutoFollowPatternDescriptor, IDeleteAutoFollowPatternRequest> selector = null) => DeleteAutoFollowPattern(selector.InvokeOrDefault(new DeleteAutoFollowPatternDescriptor(name: name)));
		///<inheritdoc cref = "IDeleteAutoFollowPatternRequest"/>
		public Task<DeleteAutoFollowPatternResponse> DeleteAutoFollowPatternAsync(Name name, Func<DeleteAutoFollowPatternDescriptor, IDeleteAutoFollowPatternRequest> selector = null, CancellationToken ct = default) => DeleteAutoFollowPatternAsync(selector.InvokeOrDefault(new DeleteAutoFollowPatternDescriptor(name: name)), ct);
		///<inheritdoc cref = "IDeleteAutoFollowPatternRequest"/>
		public DeleteAutoFollowPatternResponse DeleteAutoFollowPattern(IDeleteAutoFollowPatternRequest request) => DoRequest<IDeleteAutoFollowPatternRequest, DeleteAutoFollowPatternResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteAutoFollowPatternRequest"/>
		public Task<DeleteAutoFollowPatternResponse> DeleteAutoFollowPatternAsync(IDeleteAutoFollowPatternRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteAutoFollowPatternRequest, DeleteAutoFollowPatternResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICreateFollowIndexRequest"/>
		public CreateFollowIndexResponse CreateFollowIndex(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector) => CreateFollowIndex(selector.InvokeOrDefault(new CreateFollowIndexDescriptor(index: index)));
		///<inheritdoc cref = "ICreateFollowIndexRequest"/>
		public Task<CreateFollowIndexResponse> CreateFollowIndexAsync(IndexName index, Func<CreateFollowIndexDescriptor, ICreateFollowIndexRequest> selector, CancellationToken ct = default) => CreateFollowIndexAsync(selector.InvokeOrDefault(new CreateFollowIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "ICreateFollowIndexRequest"/>
		public CreateFollowIndexResponse CreateFollowIndex(ICreateFollowIndexRequest request) => DoRequest<ICreateFollowIndexRequest, CreateFollowIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICreateFollowIndexRequest"/>
		public Task<CreateFollowIndexResponse> CreateFollowIndexAsync(ICreateFollowIndexRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateFollowIndexRequest, CreateFollowIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IFollowIndexStatsRequest"/>
		public FollowIndexStatsResponse FollowIndexStats(Indices index, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null) => FollowIndexStats(selector.InvokeOrDefault(new FollowIndexStatsDescriptor(index: index)));
		///<inheritdoc cref = "IFollowIndexStatsRequest"/>
		public Task<FollowIndexStatsResponse> FollowIndexStatsAsync(Indices index, Func<FollowIndexStatsDescriptor, IFollowIndexStatsRequest> selector = null, CancellationToken ct = default) => FollowIndexStatsAsync(selector.InvokeOrDefault(new FollowIndexStatsDescriptor(index: index)), ct);
		///<inheritdoc cref = "IFollowIndexStatsRequest"/>
		public FollowIndexStatsResponse FollowIndexStats(IFollowIndexStatsRequest request) => DoRequest<IFollowIndexStatsRequest, FollowIndexStatsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IFollowIndexStatsRequest"/>
		public Task<FollowIndexStatsResponse> FollowIndexStatsAsync(IFollowIndexStatsRequest request, CancellationToken ct = default) => DoRequestAsync<IFollowIndexStatsRequest, FollowIndexStatsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetAutoFollowPatternRequest"/>
		public GetAutoFollowPatternResponse GetAutoFollowPattern(Name name = null, Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null) => GetAutoFollowPattern(selector.InvokeOrDefault(new GetAutoFollowPatternDescriptor().Name(name: name)));
		///<inheritdoc cref = "IGetAutoFollowPatternRequest"/>
		public Task<GetAutoFollowPatternResponse> GetAutoFollowPatternAsync(Name name = null, Func<GetAutoFollowPatternDescriptor, IGetAutoFollowPatternRequest> selector = null, CancellationToken ct = default) => GetAutoFollowPatternAsync(selector.InvokeOrDefault(new GetAutoFollowPatternDescriptor().Name(name: name)), ct);
		///<inheritdoc cref = "IGetAutoFollowPatternRequest"/>
		public GetAutoFollowPatternResponse GetAutoFollowPattern(IGetAutoFollowPatternRequest request) => DoRequest<IGetAutoFollowPatternRequest, GetAutoFollowPatternResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetAutoFollowPatternRequest"/>
		public Task<GetAutoFollowPatternResponse> GetAutoFollowPatternAsync(IGetAutoFollowPatternRequest request, CancellationToken ct = default) => DoRequestAsync<IGetAutoFollowPatternRequest, GetAutoFollowPatternResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPauseFollowIndexRequest"/>
		public PauseFollowIndexResponse PauseFollowIndex(IndexName index, Func<PauseFollowIndexDescriptor, IPauseFollowIndexRequest> selector = null) => PauseFollowIndex(selector.InvokeOrDefault(new PauseFollowIndexDescriptor(index: index)));
		///<inheritdoc cref = "IPauseFollowIndexRequest"/>
		public Task<PauseFollowIndexResponse> PauseFollowIndexAsync(IndexName index, Func<PauseFollowIndexDescriptor, IPauseFollowIndexRequest> selector = null, CancellationToken ct = default) => PauseFollowIndexAsync(selector.InvokeOrDefault(new PauseFollowIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IPauseFollowIndexRequest"/>
		public PauseFollowIndexResponse PauseFollowIndex(IPauseFollowIndexRequest request) => DoRequest<IPauseFollowIndexRequest, PauseFollowIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPauseFollowIndexRequest"/>
		public Task<PauseFollowIndexResponse> PauseFollowIndexAsync(IPauseFollowIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IPauseFollowIndexRequest, PauseFollowIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICreateAutoFollowPatternRequest"/>
		public CreateAutoFollowPatternResponse CreateAutoFollowPattern(Name name, Func<CreateAutoFollowPatternDescriptor, ICreateAutoFollowPatternRequest> selector) => CreateAutoFollowPattern(selector.InvokeOrDefault(new CreateAutoFollowPatternDescriptor(name: name)));
		///<inheritdoc cref = "ICreateAutoFollowPatternRequest"/>
		public Task<CreateAutoFollowPatternResponse> CreateAutoFollowPatternAsync(Name name, Func<CreateAutoFollowPatternDescriptor, ICreateAutoFollowPatternRequest> selector, CancellationToken ct = default) => CreateAutoFollowPatternAsync(selector.InvokeOrDefault(new CreateAutoFollowPatternDescriptor(name: name)), ct);
		///<inheritdoc cref = "ICreateAutoFollowPatternRequest"/>
		public CreateAutoFollowPatternResponse CreateAutoFollowPattern(ICreateAutoFollowPatternRequest request) => DoRequest<ICreateAutoFollowPatternRequest, CreateAutoFollowPatternResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICreateAutoFollowPatternRequest"/>
		public Task<CreateAutoFollowPatternResponse> CreateAutoFollowPatternAsync(ICreateAutoFollowPatternRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateAutoFollowPatternRequest, CreateAutoFollowPatternResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IResumeFollowIndexRequest"/>
		public ResumeFollowIndexResponse ResumeFollowIndex(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null) => ResumeFollowIndex(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index: index)));
		///<inheritdoc cref = "IResumeFollowIndexRequest"/>
		public Task<ResumeFollowIndexResponse> ResumeFollowIndexAsync(IndexName index, Func<ResumeFollowIndexDescriptor, IResumeFollowIndexRequest> selector = null, CancellationToken ct = default) => ResumeFollowIndexAsync(selector.InvokeOrDefault(new ResumeFollowIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IResumeFollowIndexRequest"/>
		public ResumeFollowIndexResponse ResumeFollowIndex(IResumeFollowIndexRequest request) => DoRequest<IResumeFollowIndexRequest, ResumeFollowIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IResumeFollowIndexRequest"/>
		public Task<ResumeFollowIndexResponse> ResumeFollowIndexAsync(IResumeFollowIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IResumeFollowIndexRequest, ResumeFollowIndexResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICcrStatsRequest"/>
		public CcrStatsResponse Stats(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null) => Stats(selector.InvokeOrDefault(new CcrStatsDescriptor()));
		///<inheritdoc cref = "ICcrStatsRequest"/>
		public Task<CcrStatsResponse> StatsAsync(Func<CcrStatsDescriptor, ICcrStatsRequest> selector = null, CancellationToken ct = default) => StatsAsync(selector.InvokeOrDefault(new CcrStatsDescriptor()), ct);
		///<inheritdoc cref = "ICcrStatsRequest"/>
		public CcrStatsResponse Stats(ICcrStatsRequest request) => DoRequest<ICcrStatsRequest, CcrStatsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICcrStatsRequest"/>
		public Task<CcrStatsResponse> StatsAsync(ICcrStatsRequest request, CancellationToken ct = default) => DoRequestAsync<ICcrStatsRequest, CcrStatsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IUnfollowIndexRequest"/>
		public UnfollowIndexResponse UnfollowIndex(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null) => UnfollowIndex(selector.InvokeOrDefault(new UnfollowIndexDescriptor(index: index)));
		///<inheritdoc cref = "IUnfollowIndexRequest"/>
		public Task<UnfollowIndexResponse> UnfollowIndexAsync(IndexName index, Func<UnfollowIndexDescriptor, IUnfollowIndexRequest> selector = null, CancellationToken ct = default) => UnfollowIndexAsync(selector.InvokeOrDefault(new UnfollowIndexDescriptor(index: index)), ct);
		///<inheritdoc cref = "IUnfollowIndexRequest"/>
		public UnfollowIndexResponse UnfollowIndex(IUnfollowIndexRequest request) => DoRequest<IUnfollowIndexRequest, UnfollowIndexResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IUnfollowIndexRequest"/>
		public Task<UnfollowIndexResponse> UnfollowIndexAsync(IUnfollowIndexRequest request, CancellationToken ct = default) => DoRequestAsync<IUnfollowIndexRequest, UnfollowIndexResponse>(request, request.RequestParameters, ct);
	}
}