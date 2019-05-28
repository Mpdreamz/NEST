using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.TasksApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.TasksApi
{
	///<summary>
	/// Logically groups all Tasks API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Tasks"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class TasksNamespace : NamespacedClientProxy
	{
		internal TasksNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "ICancelTasksRequest"/>
		public CancelTasksResponse Cancel(Func<CancelTasksDescriptor, ICancelTasksRequest> selector = null) => Cancel(selector.InvokeOrDefault(new CancelTasksDescriptor()));
		///<inheritdoc cref = "ICancelTasksRequest"/>
		public Task<CancelTasksResponse> CancelAsync(Func<CancelTasksDescriptor, ICancelTasksRequest> selector = null, CancellationToken ct = default) => CancelAsync(selector.InvokeOrDefault(new CancelTasksDescriptor()), ct);
		///<inheritdoc cref = "ICancelTasksRequest"/>
		public CancelTasksResponse Cancel(ICancelTasksRequest request) => DoRequest<ICancelTasksRequest, CancelTasksResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICancelTasksRequest"/>
		public Task<CancelTasksResponse> CancelAsync(ICancelTasksRequest request, CancellationToken ct = default) => DoRequestAsync<ICancelTasksRequest, CancelTasksResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetTaskRequest"/>
		public GetTaskResponse GetTask(TaskId taskId, Func<GetTaskDescriptor, IGetTaskRequest> selector = null) => GetTask(selector.InvokeOrDefault(new GetTaskDescriptor(taskId: taskId)));
		///<inheritdoc cref = "IGetTaskRequest"/>
		public Task<GetTaskResponse> GetTaskAsync(TaskId taskId, Func<GetTaskDescriptor, IGetTaskRequest> selector = null, CancellationToken ct = default) => GetTaskAsync(selector.InvokeOrDefault(new GetTaskDescriptor(taskId: taskId)), ct);
		///<inheritdoc cref = "IGetTaskRequest"/>
		public GetTaskResponse GetTask(IGetTaskRequest request) => DoRequest<IGetTaskRequest, GetTaskResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetTaskRequest"/>
		public Task<GetTaskResponse> GetTaskAsync(IGetTaskRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTaskRequest, GetTaskResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IListTasksRequest"/>
		public ListTasksResponse List(Func<ListTasksDescriptor, IListTasksRequest> selector = null) => List(selector.InvokeOrDefault(new ListTasksDescriptor()));
		///<inheritdoc cref = "IListTasksRequest"/>
		public Task<ListTasksResponse> ListAsync(Func<ListTasksDescriptor, IListTasksRequest> selector = null, CancellationToken ct = default) => ListAsync(selector.InvokeOrDefault(new ListTasksDescriptor()), ct);
		///<inheritdoc cref = "IListTasksRequest"/>
		public ListTasksResponse List(IListTasksRequest request) => DoRequest<IListTasksRequest, ListTasksResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IListTasksRequest"/>
		public Task<ListTasksResponse> ListAsync(IListTasksRequest request, CancellationToken ct = default) => DoRequestAsync<IListTasksRequest, ListTasksResponse>(request, request.RequestParameters, ct);
	}
}