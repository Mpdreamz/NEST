using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using static Elasticsearch.Net.HttpMethod;

//This file is automatically generated from https://github.com/elastic/elasticsearch/tree/master/rest-api-spec
// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.IndexLifecycleManagementApi
{
	///<summary>
	/// Logically groups all IndexLifecycleManagement API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.IndexLifecycleManagement"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelIndexLifecycleManagementNamespace : NamespacedClientProxy
	{
		internal LowLevelIndexLifecycleManagementNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>DELETE on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteLifecycle<TResponse>(string policy_id, DeleteLifecycleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ilm/policy/{policy_id:policy_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteLifecycleAsync<TResponse>(string policy_id, DeleteLifecycleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ilm/policy/{policy_id:policy_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_ilm/explain <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</para></summary>
		///<param name = "index">The name of the index to explain</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ExplainLifecycle<TResponse>(string index, ExplainLifecycleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_ilm/explain"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_ilm/explain <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</para></summary>
		///<param name = "index">The name of the index to explain</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ExplainLifecycleAsync<TResponse>(string index, ExplainLifecycleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_ilm/explain"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetLifecycle<TResponse>(string policy_id, GetLifecycleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ilm/policy/{policy_id:policy_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetLifecycleAsync<TResponse>(string policy_id, GetLifecycleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ilm/policy/{policy_id:policy_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/policy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetLifecycle<TResponse>(GetLifecycleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ilm/policy", null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/policy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetLifecycleAsync<TResponse>(GetLifecycleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ilm/policy", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/status <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetStatus<TResponse>(GetIlmStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ilm/status", null, RequestParams(requestParameters));
		///<summary>GET on /_ilm/status <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetStatusAsync<TResponse>(GetIlmStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ilm/status", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ilm/move/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</para></summary>
		///<param name = "index">The name of the index whose lifecycle step is to change</param>
		///<param name = "body">The new lifecycle step to move to</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse MoveToStep<TResponse>(string index, PostData body, MoveToStepRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ilm/move/{index:index}"), body, RequestParams(requestParameters));
		///<summary>POST on /_ilm/move/{index} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</para></summary>
		///<param name = "index">The name of the index whose lifecycle step is to change</param>
		///<param name = "body">The new lifecycle step to move to</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> MoveToStepAsync<TResponse>(string index, PostData body, MoveToStepRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ilm/move/{index:index}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "body">The lifecycle policy definition to register</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutLifecycle<TResponse>(string policy_id, PostData body, PutLifecycleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ilm/policy/{policy_id:policy_id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_ilm/policy/{policy_id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</para></summary>
		///<param name = "policy_id">The name of the index lifecycle policy</param>
		///<param name = "body">The lifecycle policy definition to register</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutLifecycleAsync<TResponse>(string policy_id, PostData body, PutLifecycleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ilm/policy/{policy_id:policy_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /{index}/_ilm/remove <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</para></summary>
		///<param name = "index">The name of the index to remove policy on</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RemovePolicy<TResponse>(string index, RemovePolicyRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_ilm/remove"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_ilm/remove <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</para></summary>
		///<param name = "index">The name of the index to remove policy on</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RemovePolicyAsync<TResponse>(string index, RemovePolicyRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_ilm/remove"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_ilm/retry <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</para></summary>
		///<param name = "index">The name of the indices (comma-separated) whose failed lifecycle step is to be retry</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Retry<TResponse>(string index, RetryIlmRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_ilm/retry"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_ilm/retry <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</para></summary>
		///<param name = "index">The name of the indices (comma-separated) whose failed lifecycle step is to be retry</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RetryAsync<TResponse>(string index, RetryIlmRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_ilm/retry"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ilm/start <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Start<TResponse>(StartIlmRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_ilm/start", null, RequestParams(requestParameters));
		///<summary>POST on /_ilm/start <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StartAsync<TResponse>(StartIlmRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_ilm/start", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ilm/stop <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stop<TResponse>(StopIlmRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_ilm/stop", null, RequestParams(requestParameters));
		///<summary>POST on /_ilm/stop <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StopAsync<TResponse>(StopIlmRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_ilm/stop", ctx, null, RequestParams(requestParameters));
	}
}