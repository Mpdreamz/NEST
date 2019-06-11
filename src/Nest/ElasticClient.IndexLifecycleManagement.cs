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
using Elasticsearch.Net.Specification.IndexLifecycleManagementApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace Nest.Specification.IndexLifecycleManagementApi
{
	///<summary>
	/// Logically groups all <c>IndexLifecycleManagement</c> API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.IndexLifecycleManagement"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class IndexLifecycleManagementNamespace : NamespacedClientProxy
	{
		internal IndexLifecycleManagementNamespace(ElasticClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>ilm.delete_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</a>
		/// </summary>
		public DeleteLifecycleResponse DeleteLifecycle(Id policyId, Func<DeleteLifecycleDescriptor, IDeleteLifecycleRequest> selector = null) => DeleteLifecycle(selector.InvokeOrDefault(new DeleteLifecycleDescriptor(policyId: policyId)));
		/// <summary>
		/// <c>DELETE</c> request to the <c>ilm.delete_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</a>
		/// </summary>
		public Task<DeleteLifecycleResponse> DeleteLifecycleAsync(Id policyId, Func<DeleteLifecycleDescriptor, IDeleteLifecycleRequest> selector = null, CancellationToken ct = default) => DeleteLifecycleAsync(selector.InvokeOrDefault(new DeleteLifecycleDescriptor(policyId: policyId)), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>ilm.delete_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</a>
		/// </summary>
		public DeleteLifecycleResponse DeleteLifecycle(IDeleteLifecycleRequest request) => DoRequest<IDeleteLifecycleRequest, DeleteLifecycleResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>ilm.delete_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</a>
		/// </summary>
		public Task<DeleteLifecycleResponse> DeleteLifecycleAsync(IDeleteLifecycleRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteLifecycleRequest, DeleteLifecycleResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.explain_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</a>
		/// </summary>
		public ExplainLifecycleResponse ExplainLifecycle(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null) => ExplainLifecycle(selector.InvokeOrDefault(new ExplainLifecycleDescriptor(index: index)));
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.explain_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</a>
		/// </summary>
		public Task<ExplainLifecycleResponse> ExplainLifecycleAsync(IndexName index, Func<ExplainLifecycleDescriptor, IExplainLifecycleRequest> selector = null, CancellationToken ct = default) => ExplainLifecycleAsync(selector.InvokeOrDefault(new ExplainLifecycleDescriptor(index: index)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.explain_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</a>
		/// </summary>
		public ExplainLifecycleResponse ExplainLifecycle(IExplainLifecycleRequest request) => DoRequest<IExplainLifecycleRequest, ExplainLifecycleResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.explain_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</a>
		/// </summary>
		public Task<ExplainLifecycleResponse> ExplainLifecycleAsync(IExplainLifecycleRequest request, CancellationToken ct = default) => DoRequestAsync<IExplainLifecycleRequest, ExplainLifecycleResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</a>
		/// </summary>
		public GetLifecycleResponse GetLifecycle(Func<GetLifecycleDescriptor, IGetLifecycleRequest> selector = null) => GetLifecycle(selector.InvokeOrDefault(new GetLifecycleDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</a>
		/// </summary>
		public Task<GetLifecycleResponse> GetLifecycleAsync(Func<GetLifecycleDescriptor, IGetLifecycleRequest> selector = null, CancellationToken ct = default) => GetLifecycleAsync(selector.InvokeOrDefault(new GetLifecycleDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</a>
		/// </summary>
		public GetLifecycleResponse GetLifecycle(IGetLifecycleRequest request) => DoRequest<IGetLifecycleRequest, GetLifecycleResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</a>
		/// </summary>
		public Task<GetLifecycleResponse> GetLifecycleAsync(IGetLifecycleRequest request, CancellationToken ct = default) => DoRequestAsync<IGetLifecycleRequest, GetLifecycleResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_status</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</a>
		/// </summary>
		public GetIlmStatusResponse GetStatus(Func<GetIlmStatusDescriptor, IGetIlmStatusRequest> selector = null) => GetStatus(selector.InvokeOrDefault(new GetIlmStatusDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_status</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</a>
		/// </summary>
		public Task<GetIlmStatusResponse> GetStatusAsync(Func<GetIlmStatusDescriptor, IGetIlmStatusRequest> selector = null, CancellationToken ct = default) => GetStatusAsync(selector.InvokeOrDefault(new GetIlmStatusDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_status</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</a>
		/// </summary>
		public GetIlmStatusResponse GetStatus(IGetIlmStatusRequest request) => DoRequest<IGetIlmStatusRequest, GetIlmStatusResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>ilm.get_status</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</a>
		/// </summary>
		public Task<GetIlmStatusResponse> GetStatusAsync(IGetIlmStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IGetIlmStatusRequest, GetIlmStatusResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.move_to_step</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</a>
		/// </summary>
		public MoveToStepResponse MoveToStep(IndexName index, Func<MoveToStepDescriptor, IMoveToStepRequest> selector = null) => MoveToStep(selector.InvokeOrDefault(new MoveToStepDescriptor(index: index)));
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.move_to_step</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</a>
		/// </summary>
		public Task<MoveToStepResponse> MoveToStepAsync(IndexName index, Func<MoveToStepDescriptor, IMoveToStepRequest> selector = null, CancellationToken ct = default) => MoveToStepAsync(selector.InvokeOrDefault(new MoveToStepDescriptor(index: index)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.move_to_step</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</a>
		/// </summary>
		public MoveToStepResponse MoveToStep(IMoveToStepRequest request) => DoRequest<IMoveToStepRequest, MoveToStepResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.move_to_step</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</a>
		/// </summary>
		public Task<MoveToStepResponse> MoveToStepAsync(IMoveToStepRequest request, CancellationToken ct = default) => DoRequestAsync<IMoveToStepRequest, MoveToStepResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>ilm.put_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</a>
		/// </summary>
		public PutLifecycleResponse PutLifecycle(Id policyId, Func<PutLifecycleDescriptor, IPutLifecycleRequest> selector = null) => PutLifecycle(selector.InvokeOrDefault(new PutLifecycleDescriptor(policyId: policyId)));
		/// <summary>
		/// <c>PUT</c> request to the <c>ilm.put_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</a>
		/// </summary>
		public Task<PutLifecycleResponse> PutLifecycleAsync(Id policyId, Func<PutLifecycleDescriptor, IPutLifecycleRequest> selector = null, CancellationToken ct = default) => PutLifecycleAsync(selector.InvokeOrDefault(new PutLifecycleDescriptor(policyId: policyId)), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>ilm.put_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</a>
		/// </summary>
		public PutLifecycleResponse PutLifecycle(IPutLifecycleRequest request) => DoRequest<IPutLifecycleRequest, PutLifecycleResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>ilm.put_lifecycle</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</a>
		/// </summary>
		public Task<PutLifecycleResponse> PutLifecycleAsync(IPutLifecycleRequest request, CancellationToken ct = default) => DoRequestAsync<IPutLifecycleRequest, PutLifecycleResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.remove_policy</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</a>
		/// </summary>
		public RemovePolicyResponse RemovePolicy(IndexName index, Func<RemovePolicyDescriptor, IRemovePolicyRequest> selector = null) => RemovePolicy(selector.InvokeOrDefault(new RemovePolicyDescriptor(index: index)));
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.remove_policy</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</a>
		/// </summary>
		public Task<RemovePolicyResponse> RemovePolicyAsync(IndexName index, Func<RemovePolicyDescriptor, IRemovePolicyRequest> selector = null, CancellationToken ct = default) => RemovePolicyAsync(selector.InvokeOrDefault(new RemovePolicyDescriptor(index: index)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.remove_policy</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</a>
		/// </summary>
		public RemovePolicyResponse RemovePolicy(IRemovePolicyRequest request) => DoRequest<IRemovePolicyRequest, RemovePolicyResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.remove_policy</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</a>
		/// </summary>
		public Task<RemovePolicyResponse> RemovePolicyAsync(IRemovePolicyRequest request, CancellationToken ct = default) => DoRequestAsync<IRemovePolicyRequest, RemovePolicyResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.retry</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</a>
		/// </summary>
		public RetryIlmResponse Retry(IndexName index, Func<RetryIlmDescriptor, IRetryIlmRequest> selector = null) => Retry(selector.InvokeOrDefault(new RetryIlmDescriptor(index: index)));
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.retry</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</a>
		/// </summary>
		public Task<RetryIlmResponse> RetryAsync(IndexName index, Func<RetryIlmDescriptor, IRetryIlmRequest> selector = null, CancellationToken ct = default) => RetryAsync(selector.InvokeOrDefault(new RetryIlmDescriptor(index: index)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.retry</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</a>
		/// </summary>
		public RetryIlmResponse Retry(IRetryIlmRequest request) => DoRequest<IRetryIlmRequest, RetryIlmResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.retry</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</a>
		/// </summary>
		public Task<RetryIlmResponse> RetryAsync(IRetryIlmRequest request, CancellationToken ct = default) => DoRequestAsync<IRetryIlmRequest, RetryIlmResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.start</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</a>
		/// </summary>
		public StartIlmResponse Start(Func<StartIlmDescriptor, IStartIlmRequest> selector = null) => Start(selector.InvokeOrDefault(new StartIlmDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.start</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</a>
		/// </summary>
		public Task<StartIlmResponse> StartAsync(Func<StartIlmDescriptor, IStartIlmRequest> selector = null, CancellationToken ct = default) => StartAsync(selector.InvokeOrDefault(new StartIlmDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.start</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</a>
		/// </summary>
		public StartIlmResponse Start(IStartIlmRequest request) => DoRequest<IStartIlmRequest, StartIlmResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.start</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</a>
		/// </summary>
		public Task<StartIlmResponse> StartAsync(IStartIlmRequest request, CancellationToken ct = default) => DoRequestAsync<IStartIlmRequest, StartIlmResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.stop</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</a>
		/// </summary>
		public StopIlmResponse Stop(Func<StopIlmDescriptor, IStopIlmRequest> selector = null) => Stop(selector.InvokeOrDefault(new StopIlmDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.stop</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</a>
		/// </summary>
		public Task<StopIlmResponse> StopAsync(Func<StopIlmDescriptor, IStopIlmRequest> selector = null, CancellationToken ct = default) => StopAsync(selector.InvokeOrDefault(new StopIlmDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.stop</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</a>
		/// </summary>
		public StopIlmResponse Stop(IStopIlmRequest request) => DoRequest<IStopIlmRequest, StopIlmResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>ilm.stop</c> API, read more about this API online:
		/// <para> </para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</a>
		/// </summary>
		public Task<StopIlmResponse> StopAsync(IStopIlmRequest request, CancellationToken ct = default) => DoRequestAsync<IStopIlmRequest, StopIlmResponse>(request, request.RequestParameters, ct);
	}
}