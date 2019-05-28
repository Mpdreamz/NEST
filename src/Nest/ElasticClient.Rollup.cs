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
using Elasticsearch.Net.Specification.RollupApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.RollupApi
{
	///<summary>
	/// Logically groups all Rollup API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Rollup"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class RollupNamespace : NamespacedClientProxy
	{
		internal RollupNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IDeleteRollupJobRequest"/>
		public DeleteRollupJobResponse DeleteJob(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null) => DeleteJob(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id: id)));
		///<inheritdoc cref = "IDeleteRollupJobRequest"/>
		public Task<DeleteRollupJobResponse> DeleteJobAsync(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null, CancellationToken ct = default) => DeleteJobAsync(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id: id)), ct);
		///<inheritdoc cref = "IDeleteRollupJobRequest"/>
		public DeleteRollupJobResponse DeleteJob(IDeleteRollupJobRequest request) => DoRequest<IDeleteRollupJobRequest, DeleteRollupJobResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteRollupJobRequest"/>
		public Task<DeleteRollupJobResponse> DeleteJobAsync(IDeleteRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteRollupJobRequest, DeleteRollupJobResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetRollupJobRequest"/>
		public GetRollupJobResponse GetJob(Func<GetRollupJobDescriptor, IGetRollupJobRequest> selector = null) => GetJob(selector.InvokeOrDefault(new GetRollupJobDescriptor()));
		///<inheritdoc cref = "IGetRollupJobRequest"/>
		public Task<GetRollupJobResponse> GetJobAsync(Func<GetRollupJobDescriptor, IGetRollupJobRequest> selector = null, CancellationToken ct = default) => GetJobAsync(selector.InvokeOrDefault(new GetRollupJobDescriptor()), ct);
		///<inheritdoc cref = "IGetRollupJobRequest"/>
		public GetRollupJobResponse GetJob(IGetRollupJobRequest request) => DoRequest<IGetRollupJobRequest, GetRollupJobResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetRollupJobRequest"/>
		public Task<GetRollupJobResponse> GetJobAsync(IGetRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupJobRequest, GetRollupJobResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetRollupCapabilitiesRequest"/>
		public GetRollupCapabilitiesResponse GetCapabilities(Func<GetRollupCapabilitiesDescriptor, IGetRollupCapabilitiesRequest> selector = null) => GetCapabilities(selector.InvokeOrDefault(new GetRollupCapabilitiesDescriptor()));
		///<inheritdoc cref = "IGetRollupCapabilitiesRequest"/>
		public Task<GetRollupCapabilitiesResponse> GetCapabilitiesAsync(Func<GetRollupCapabilitiesDescriptor, IGetRollupCapabilitiesRequest> selector = null, CancellationToken ct = default) => GetCapabilitiesAsync(selector.InvokeOrDefault(new GetRollupCapabilitiesDescriptor()), ct);
		///<inheritdoc cref = "IGetRollupCapabilitiesRequest"/>
		public GetRollupCapabilitiesResponse GetCapabilities(IGetRollupCapabilitiesRequest request) => DoRequest<IGetRollupCapabilitiesRequest, GetRollupCapabilitiesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetRollupCapabilitiesRequest"/>
		public Task<GetRollupCapabilitiesResponse> GetCapabilitiesAsync(IGetRollupCapabilitiesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupCapabilitiesRequest, GetRollupCapabilitiesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetRollupIndexCapabilitiesRequest"/>
		public GetRollupIndexCapabilitiesResponse GetIndexCapabilities(IndexName index, Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null) => GetIndexCapabilities(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index: index)));
		///<inheritdoc cref = "IGetRollupIndexCapabilitiesRequest"/>
		public Task<GetRollupIndexCapabilitiesResponse> GetIndexCapabilitiesAsync(IndexName index, Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null, CancellationToken ct = default) => GetIndexCapabilitiesAsync(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index: index)), ct);
		///<inheritdoc cref = "IGetRollupIndexCapabilitiesRequest"/>
		public GetRollupIndexCapabilitiesResponse GetIndexCapabilities(IGetRollupIndexCapabilitiesRequest request) => DoRequest<IGetRollupIndexCapabilitiesRequest, GetRollupIndexCapabilitiesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetRollupIndexCapabilitiesRequest"/>
		public Task<GetRollupIndexCapabilitiesResponse> GetIndexCapabilitiesAsync(IGetRollupIndexCapabilitiesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupIndexCapabilitiesRequest, GetRollupIndexCapabilitiesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICreateRollupJobRequest"/>
		public CreateRollupJobResponse CreateJob<TDocument>(Id id, Func<CreateRollupJobDescriptor<TDocument>, ICreateRollupJobRequest> selector)
			where TDocument : class => CreateJob(selector.InvokeOrDefault(new CreateRollupJobDescriptor<TDocument>(id: id)));
		///<inheritdoc cref = "ICreateRollupJobRequest"/>
		public Task<CreateRollupJobResponse> CreateJobAsync<TDocument>(Id id, Func<CreateRollupJobDescriptor<TDocument>, ICreateRollupJobRequest> selector, CancellationToken ct = default)
			where TDocument : class => CreateJobAsync(selector.InvokeOrDefault(new CreateRollupJobDescriptor<TDocument>(id: id)), ct);
		///<inheritdoc cref = "ICreateRollupJobRequest"/>
		public CreateRollupJobResponse CreateJob(ICreateRollupJobRequest request) => DoRequest<ICreateRollupJobRequest, CreateRollupJobResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICreateRollupJobRequest"/>
		public Task<CreateRollupJobResponse> CreateJobAsync(ICreateRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateRollupJobRequest, CreateRollupJobResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IRollupSearchRequest"/>
		public RollupSearchResponse<TDocument> Search<TDocument>(Func<RollupSearchDescriptor<TDocument>, IRollupSearchRequest> selector = null)
			where TDocument : class => Search<TDocument>(selector.InvokeOrDefault(new RollupSearchDescriptor<TDocument>()));
		///<inheritdoc cref = "IRollupSearchRequest"/>
		public Task<RollupSearchResponse<TDocument>> SearchAsync<TDocument>(Func<RollupSearchDescriptor<TDocument>, IRollupSearchRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => SearchAsync<TDocument>(selector.InvokeOrDefault(new RollupSearchDescriptor<TDocument>()), ct);
		///<inheritdoc cref = "IRollupSearchRequest"/>
		public RollupSearchResponse<TDocument> Search<TDocument>(IRollupSearchRequest request)
			where TDocument : class => DoRequest<IRollupSearchRequest, RollupSearchResponse<TDocument>>(request, request.RequestParameters);
		///<inheritdoc cref = "IRollupSearchRequest"/>
		public Task<RollupSearchResponse<TDocument>> SearchAsync<TDocument>(IRollupSearchRequest request, CancellationToken ct = default)
			where TDocument : class => DoRequestAsync<IRollupSearchRequest, RollupSearchResponse<TDocument>>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IStartRollupJobRequest"/>
		public StartRollupJobResponse StartJob(Id id, Func<StartRollupJobDescriptor, IStartRollupJobRequest> selector = null) => StartJob(selector.InvokeOrDefault(new StartRollupJobDescriptor(id: id)));
		///<inheritdoc cref = "IStartRollupJobRequest"/>
		public Task<StartRollupJobResponse> StartJobAsync(Id id, Func<StartRollupJobDescriptor, IStartRollupJobRequest> selector = null, CancellationToken ct = default) => StartJobAsync(selector.InvokeOrDefault(new StartRollupJobDescriptor(id: id)), ct);
		///<inheritdoc cref = "IStartRollupJobRequest"/>
		public StartRollupJobResponse StartJob(IStartRollupJobRequest request) => DoRequest<IStartRollupJobRequest, StartRollupJobResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IStartRollupJobRequest"/>
		public Task<StartRollupJobResponse> StartJobAsync(IStartRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IStartRollupJobRequest, StartRollupJobResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IStopRollupJobRequest"/>
		public StopRollupJobResponse StopJob(Id id, Func<StopRollupJobDescriptor, IStopRollupJobRequest> selector = null) => StopJob(selector.InvokeOrDefault(new StopRollupJobDescriptor(id: id)));
		///<inheritdoc cref = "IStopRollupJobRequest"/>
		public Task<StopRollupJobResponse> StopJobAsync(Id id, Func<StopRollupJobDescriptor, IStopRollupJobRequest> selector = null, CancellationToken ct = default) => StopJobAsync(selector.InvokeOrDefault(new StopRollupJobDescriptor(id: id)), ct);
		///<inheritdoc cref = "IStopRollupJobRequest"/>
		public StopRollupJobResponse StopJob(IStopRollupJobRequest request) => DoRequest<IStopRollupJobRequest, StopRollupJobResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IStopRollupJobRequest"/>
		public Task<StopRollupJobResponse> StopJobAsync(IStopRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IStopRollupJobRequest, StopRollupJobResponse>(request, request.RequestParameters, ct);
	}
}