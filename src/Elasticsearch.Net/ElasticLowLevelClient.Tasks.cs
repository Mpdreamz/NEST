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
namespace Elasticsearch.Net.Specification.TasksApi
{
	///<summary>
	/// Logically groups all Tasks API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Tasks"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelTasksNamespace : NamespacedClientProxy
	{
		internal LowLevelTasksNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /_tasks/_cancel <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Cancel<TResponse>(CancelTasksRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_tasks/_cancel", null, RequestParams(requestParameters));
		///<summary>POST on /_tasks/_cancel <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CancelAsync<TResponse>(CancelTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_tasks/_cancel", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_tasks/{task_id}/_cancel <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "task_id">Cancel the task with specified task id (node_id:task_number)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Cancel<TResponse>(string task_id, CancelTasksRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_tasks/{task_id:task_id}/_cancel"), null, RequestParams(requestParameters));
		///<summary>POST on /_tasks/{task_id}/_cancel <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "task_id">Cancel the task with specified task id (node_id:task_number)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CancelAsync<TResponse>(string task_id, CancelTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_tasks/{task_id:task_id}/_cancel"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_tasks/{task_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "task_id">Return the task with specified id (node_id:task_number)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetTask<TResponse>(string task_id, GetTaskRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_tasks/{task_id:task_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_tasks/{task_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "task_id">Return the task with specified id (node_id:task_number)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetTaskAsync<TResponse>(string task_id, GetTaskRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_tasks/{task_id:task_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse List<TResponse>(ListTasksRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_tasks", null, RequestParams(requestParameters));
		///<summary>GET on /_tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ListAsync<TResponse>(ListTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_tasks", ctx, null, RequestParams(requestParameters));
	}
}