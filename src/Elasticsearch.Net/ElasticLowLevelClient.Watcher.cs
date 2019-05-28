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
namespace Elasticsearch.Net.Specification.WatcherApi
{
	///<summary>
	/// Logically groups all Watcher API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Watcher"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelWatcherNamespace : NamespacedClientProxy
	{
		internal LowLevelWatcherNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>PUT on /_watcher/watch/{watch_id}/_ack <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-ack-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Acknowledge<TResponse>(string watch_id, AcknowledgeWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_ack"), null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_ack <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-ack-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AcknowledgeAsync<TResponse>(string watch_id, AcknowledgeWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_ack"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_ack/{action_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-ack-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "action_id">A comma-separated list of the action ids to be acked</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Acknowledge<TResponse>(string watch_id, string action_id, AcknowledgeWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_ack/{action_id:action_id}"), null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_ack/{action_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-ack-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "action_id">A comma-separated list of the action ids to be acked</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AcknowledgeAsync<TResponse>(string watch_id, string action_id, AcknowledgeWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_ack/{action_id:action_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_activate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-activate-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Activate<TResponse>(string watch_id, ActivateWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_activate"), null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_activate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-activate-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ActivateAsync<TResponse>(string watch_id, ActivateWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_activate"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_deactivate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-deactivate-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Deactivate<TResponse>(string watch_id, DeactivateWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_deactivate"), null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{watch_id}/_deactivate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-deactivate-watch.html</para></summary>
		///<param name = "watch_id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeactivateAsync<TResponse>(string watch_id, DeactivateWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{watch_id:watch_id}/_deactivate"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-delete-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Delete<TResponse>(string id, DeleteWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_watcher/watch/{id:id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-delete-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteAsync<TResponse>(string id, DeleteWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_watcher/watch/{id:id}"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{id}/_execute <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-execute-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "body">Execution control</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Execute<TResponse>(string id, PostData body, ExecuteWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{id:id}/_execute"), body, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{id}/_execute <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-execute-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "body">Execution control</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ExecuteAsync<TResponse>(string id, PostData body, ExecuteWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{id:id}/_execute"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/_execute <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-execute-watch.html</para></summary>
		///<param name = "body">Execution control</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Execute<TResponse>(PostData body, ExecuteWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, "_watcher/watch/_execute", body, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/_execute <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-execute-watch.html</para></summary>
		///<param name = "body">Execution control</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ExecuteAsync<TResponse>(PostData body, ExecuteWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, "_watcher/watch/_execute", ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-get-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Get<TResponse>(string id, GetWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_watcher/watch/{id:id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-get-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAsync<TResponse>(string id, GetWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_watcher/watch/{id:id}"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-put-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "body">The watch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Put<TResponse>(string id, PostData body, PutWatchRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_watcher/watch/{id:id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_watcher/watch/{id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-put-watch.html</para></summary>
		///<param name = "id">Watch ID</param>
		///<param name = "body">The watch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutAsync<TResponse>(string id, PostData body, PutWatchRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_watcher/watch/{id:id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_watcher/_start <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-start.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Start<TResponse>(StartWatcherRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_watcher/_start", null, RequestParams(requestParameters));
		///<summary>POST on /_watcher/_start <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-start.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StartAsync<TResponse>(StartWatcherRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_watcher/_start", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_watcher/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(WatcherStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_watcher/stats", null, RequestParams(requestParameters));
		///<summary>GET on /_watcher/stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(WatcherStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_watcher/stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_watcher/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stats.html</para></summary>
		///<param name = "metric">Controls what additional stat metrics should be include in the response</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stats<TResponse>(string metric, WatcherStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_watcher/stats/{metric:metric}"), null, RequestParams(requestParameters));
		///<summary>GET on /_watcher/stats/{metric} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stats.html</para></summary>
		///<param name = "metric">Controls what additional stat metrics should be include in the response</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StatsAsync<TResponse>(string metric, WatcherStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_watcher/stats/{metric:metric}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_watcher/_stop <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stop.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Stop<TResponse>(StopWatcherRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_watcher/_stop", null, RequestParams(requestParameters));
		///<summary>POST on /_watcher/_stop <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stop.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StopAsync<TResponse>(StopWatcherRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_watcher/_stop", ctx, null, RequestParams(requestParameters));
	}
}