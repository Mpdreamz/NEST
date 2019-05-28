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
namespace Elasticsearch.Net.Specification.MachineLearningApi
{
	///<summary>
	/// Logically groups all MachineLearning API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.MachineLearning"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelMachineLearningNamespace : NamespacedClientProxy
	{
		internal LowLevelMachineLearningNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_close <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-close-job.html</para></summary>
		///<param name = "job_id">The name of the job to close</param>
		///<param name = "body">The URL params optionally sent in the body</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse CloseJob<TResponse>(string job_id, PostData body, CloseJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_close"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_close <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-close-job.html</para></summary>
		///<param name = "job_id">The name of the job to close</param>
		///<param name = "body">The URL params optionally sent in the body</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CloseJobAsync<TResponse>(string job_id, PostData body, CloseJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_close"), ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteCalendar<TResponse>(string calendar_id, DeleteCalendarRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteCalendarAsync<TResponse>(string calendar_id, DeleteCalendarRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id}/events/{event_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "event_id">The ID of the event to remove from the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteCalendarEvent<TResponse>(string calendar_id, string event_id, DeleteCalendarEventRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}/events/{event_id:event_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id}/events/{event_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "event_id">The ID of the event to remove from the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteCalendarEventAsync<TResponse>(string calendar_id, string event_id, DeleteCalendarEventRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}/events/{event_id:event_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id}/jobs/{job_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "job_id">The ID of the job to remove from the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteCalendarJob<TResponse>(string calendar_id, string job_id, DeleteCalendarJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}/jobs/{job_id:job_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/calendars/{calendar_id}/jobs/{job_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "job_id">The ID of the job to remove from the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteCalendarJobAsync<TResponse>(string calendar_id, string job_id, DeleteCalendarJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/calendars/{calendar_id:calendar_id}/jobs/{job_id:job_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteDatafeed<TResponse>(string datafeed_id, DeleteDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteDatafeedAsync<TResponse>(string datafeed_id, DeleteDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/_delete_expired_data <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteExpiredData<TResponse>(DeleteExpiredDataRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, "_ml/_delete_expired_data", null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/_delete_expired_data <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteExpiredDataAsync<TResponse>(DeleteExpiredDataRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, "_ml/_delete_expired_data", ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteFilter<TResponse>(string filter_id, DeleteFilterRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/filters/{filter_id:filter_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteFilterAsync<TResponse>(string filter_id, DeleteFilterRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/filters/{filter_id:filter_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id}/_forecast/{forecast_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-forecast.html</para></summary>
		///<param name = "job_id">The ID of the job from which to delete forecasts</param>
		///<param name = "forecast_id">The ID of the forecast to delete, can be comma delimited list or `_all`</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteForecast<TResponse>(string job_id, string forecast_id, DeleteForecastRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}/_forecast/{forecast_id:forecast_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id}/_forecast/{forecast_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-forecast.html</para></summary>
		///<param name = "job_id">The ID of the job from which to delete forecasts</param>
		///<param name = "forecast_id">The ID of the forecast to delete, can be comma delimited list or `_all`</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteForecastAsync<TResponse>(string job_id, string forecast_id, DeleteForecastRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}/_forecast/{forecast_id:forecast_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-job.html</para></summary>
		///<param name = "job_id">The ID of the job to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteJob<TResponse>(string job_id, DeleteJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-job.html</para></summary>
		///<param name = "job_id">The ID of the job to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteJobAsync<TResponse>(string job_id, DeleteJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteModelSnapshot<TResponse>(string job_id, string snapshot_id, DeleteModelSnapshotRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-delete-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to delete</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteModelSnapshotAsync<TResponse>(string job_id, string snapshot_id, DeleteModelSnapshotRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-flush-job.html</para></summary>
		///<param name = "job_id">The name of the job to flush</param>
		///<param name = "body">Flush parameters</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse FlushJob<TResponse>(string job_id, PostData body, FlushJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_flush"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_flush <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-flush-job.html</para></summary>
		///<param name = "job_id">The name of the job to flush</param>
		///<param name = "body">Flush parameters</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> FlushJobAsync<TResponse>(string job_id, PostData body, FlushJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_flush"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_forecast <para></para></summary>
		///<param name = "job_id">The ID of the job to forecast for</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ForecastJob<TResponse>(string job_id, ForecastJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_forecast"), null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_forecast <para></para></summary>
		///<param name = "job_id">The ID of the job to forecast for</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ForecastJobAsync<TResponse>(string job_id, ForecastJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_forecast"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/buckets/{timestamp} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-bucket.html</para></summary>
		///<param name = "job_id">ID of the job to get bucket results from</param>
		///<param name = "timestamp">The timestamp of the desired single bucket result</param>
		///<param name = "body">Bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetBuckets<TResponse>(string job_id, string timestamp, PostData body, GetBucketsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/buckets/{timestamp:timestamp}"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/buckets/{timestamp} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-bucket.html</para></summary>
		///<param name = "job_id">ID of the job to get bucket results from</param>
		///<param name = "timestamp">The timestamp of the desired single bucket result</param>
		///<param name = "body">Bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetBucketsAsync<TResponse>(string job_id, string timestamp, PostData body, GetBucketsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/buckets/{timestamp:timestamp}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/buckets <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-bucket.html</para></summary>
		///<param name = "job_id">ID of the job to get bucket results from</param>
		///<param name = "body">Bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetBuckets<TResponse>(string job_id, PostData body, GetBucketsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/buckets"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/buckets <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-bucket.html</para></summary>
		///<param name = "job_id">ID of the job to get bucket results from</param>
		///<param name = "body">Bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetBucketsAsync<TResponse>(string job_id, PostData body, GetBucketsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/buckets"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ml/calendars/{calendar_id}/events <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar containing the events</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCalendarEvents<TResponse>(string calendar_id, GetCalendarEventsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/calendars/{calendar_id:calendar_id}/events"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/calendars/{calendar_id}/events <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar containing the events</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCalendarEventsAsync<TResponse>(string calendar_id, GetCalendarEventsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/calendars/{calendar_id:calendar_id}/events"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars <para></para></summary>
		///<param name = "body">Calendar selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCalendars<TResponse>(PostData body, GetCalendarsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_ml/calendars", body, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars <para></para></summary>
		///<param name = "body">Calendar selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCalendarsAsync<TResponse>(PostData body, GetCalendarsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_ml/calendars", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to fetch</param>
		///<param name = "body">Calendar selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCalendars<TResponse>(string calendar_id, PostData body, GetCalendarsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/calendars/{calendar_id:calendar_id}"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to fetch</param>
		///<param name = "body">Calendar selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCalendarsAsync<TResponse>(string calendar_id, PostData body, GetCalendarsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/calendars/{calendar_id:calendar_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/categories/{category_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-category.html</para></summary>
		///<param name = "job_id">The name of the job</param>
		///<param name = "category_id">The identifier of the category definition of interest</param>
		///<param name = "body">Category selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCategories<TResponse>(string job_id, long category_id, PostData body, GetCategoriesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/categories/{category_id:category_id}"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/categories/{category_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-category.html</para></summary>
		///<param name = "job_id">The name of the job</param>
		///<param name = "category_id">The identifier of the category definition of interest</param>
		///<param name = "body">Category selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCategoriesAsync<TResponse>(string job_id, long category_id, PostData body, GetCategoriesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/categories/{category_id:category_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/categories/ <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-category.html</para></summary>
		///<param name = "job_id">The name of the job</param>
		///<param name = "body">Category selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCategories<TResponse>(string job_id, PostData body, GetCategoriesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/categories/"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/categories/ <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-category.html</para></summary>
		///<param name = "job_id">The name of the job</param>
		///<param name = "body">Category selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCategoriesAsync<TResponse>(string job_id, PostData body, GetCategoriesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/categories/"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed-stats.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeeds stats to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetDatafeedStats<TResponse>(string datafeed_id, GetDatafeedStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_stats"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed-stats.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeeds stats to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetDatafeedStatsAsync<TResponse>(string datafeed_id, GetDatafeedStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_stats"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetDatafeedStats<TResponse>(GetDatafeedStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/datafeeds/_stats", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetDatafeedStatsAsync<TResponse>(GetDatafeedStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/datafeeds/_stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeeds to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetDatafeeds<TResponse>(string datafeed_id, GetDatafeedsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeeds to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetDatafeedsAsync<TResponse>(string datafeed_id, GetDatafeedsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetDatafeeds<TResponse>(GetDatafeedsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/datafeeds", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-datafeed.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetDatafeedsAsync<TResponse>(GetDatafeedsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/datafeeds", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/filters <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetFilters<TResponse>(GetFiltersRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/filters", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/filters <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetFiltersAsync<TResponse>(GetFiltersRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/filters", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetFilters<TResponse>(string filter_id, GetFiltersRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/filters/{filter_id:filter_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetFiltersAsync<TResponse>(string filter_id, GetFiltersRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/filters/{filter_id:filter_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/influencers <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-influencer.html</para></summary>
		///<param name = "job_id"></param>
		///<param name = "body">Influencer selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetInfluencers<TResponse>(string job_id, PostData body, GetInfluencersRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/influencers"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/influencers <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-influencer.html</para></summary>
		///<param name = "job_id"></param>
		///<param name = "body">Influencer selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetInfluencersAsync<TResponse>(string job_id, PostData body, GetInfluencersRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/influencers"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetJobStats<TResponse>(GetJobStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/anomaly_detectors/_stats", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job-stats.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetJobStatsAsync<TResponse>(GetJobStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/anomaly_detectors/_stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/{job_id}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job-stats.html</para></summary>
		///<param name = "job_id">The ID of the jobs stats to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetJobStats<TResponse>(string job_id, GetJobStatsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/anomaly_detectors/{job_id:job_id}/_stats"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/{job_id}/_stats <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job-stats.html</para></summary>
		///<param name = "job_id">The ID of the jobs stats to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetJobStatsAsync<TResponse>(string job_id, GetJobStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/anomaly_detectors/{job_id:job_id}/_stats"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job.html</para></summary>
		///<param name = "job_id">The ID of the jobs to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetJobs<TResponse>(string job_id, GetJobsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/anomaly_detectors/{job_id:job_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job.html</para></summary>
		///<param name = "job_id">The ID of the jobs to fetch</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetJobsAsync<TResponse>(string job_id, GetJobsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/anomaly_detectors/{job_id:job_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetJobs<TResponse>(GetJobsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/anomaly_detectors", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/anomaly_detectors <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-job.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetJobsAsync<TResponse>(GetJobsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/anomaly_detectors", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to fetch</param>
		///<param name = "body">Model snapshot selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetModelSnapshots<TResponse>(string job_id, string snapshot_id, PostData body, GetModelSnapshotsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to fetch</param>
		///<param name = "body">Model snapshot selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetModelSnapshotsAsync<TResponse>(string job_id, string snapshot_id, PostData body, GetModelSnapshotsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "body">Model snapshot selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetModelSnapshots<TResponse>(string job_id, PostData body, GetModelSnapshotsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "body">Model snapshot selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetModelSnapshotsAsync<TResponse>(string job_id, PostData body, GetModelSnapshotsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/overall_buckets <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-overall-buckets.html</para></summary>
		///<param name = "job_id">The job IDs for which to calculate overall bucket results</param>
		///<param name = "body">Overall bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetOverallBuckets<TResponse>(string job_id, PostData body, GetOverallBucketsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/overall_buckets"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/overall_buckets <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-overall-buckets.html</para></summary>
		///<param name = "job_id">The job IDs for which to calculate overall bucket results</param>
		///<param name = "body">Overall bucket selection details if not provided in URI</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetOverallBucketsAsync<TResponse>(string job_id, PostData body, GetOverallBucketsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/overall_buckets"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/records <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-record.html</para></summary>
		///<param name = "job_id"></param>
		///<param name = "body">Record selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAnomalyRecords<TResponse>(string job_id, PostData body, GetAnomalyRecordsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/records"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/results/records <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-get-record.html</para></summary>
		///<param name = "job_id"></param>
		///<param name = "body">Record selection criteria</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetAnomalyRecordsAsync<TResponse>(string job_id, PostData body, GetAnomalyRecordsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/results/records"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ml/info <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Info<TResponse>(MachineLearningInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ml/info", null, RequestParams(requestParameters));
		///<summary>GET on /_ml/info <para></para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InfoAsync<TResponse>(MachineLearningInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ml/info", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_open <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-open-job.html</para></summary>
		///<param name = "job_id">The ID of the job to open</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse OpenJob<TResponse>(string job_id, OpenJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_open"), null, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_open <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-open-job.html</para></summary>
		///<param name = "job_id">The ID of the job to open</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> OpenJobAsync<TResponse>(string job_id, OpenJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_open"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars/{calendar_id}/events <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "body">A list of events</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PostCalendarEvents<TResponse>(string calendar_id, PostData body, PostCalendarEventsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/calendars/{calendar_id:calendar_id}/events"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/calendars/{calendar_id}/events <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "body">A list of events</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PostCalendarEventsAsync<TResponse>(string calendar_id, PostData body, PostCalendarEventsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/calendars/{calendar_id:calendar_id}/events"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_data <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-post-data.html</para></summary>
		///<param name = "job_id">The name of the job receiving the data</param>
		///<param name = "body">The data to process</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PostJobData<TResponse>(string job_id, PostData body, PostJobDataRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_data"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_data <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-post-data.html</para></summary>
		///<param name = "job_id">The name of the job receiving the data</param>
		///<param name = "body">The data to process</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PostJobDataAsync<TResponse>(string job_id, PostData body, PostJobDataRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_data"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id}/_preview <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-preview-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to preview</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PreviewDatafeed<TResponse>(string datafeed_id, PreviewDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_preview"), null, RequestParams(requestParameters));
		///<summary>GET on /_ml/datafeeds/{datafeed_id}/_preview <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-preview-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to preview</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PreviewDatafeedAsync<TResponse>(string datafeed_id, PreviewDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_preview"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to create</param>
		///<param name = "body">The calendar details</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutCalendar<TResponse>(string calendar_id, PostData body, PutCalendarRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ml/calendars/{calendar_id:calendar_id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/calendars/{calendar_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to create</param>
		///<param name = "body">The calendar details</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutCalendarAsync<TResponse>(string calendar_id, PostData body, PutCalendarRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ml/calendars/{calendar_id:calendar_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/calendars/{calendar_id}/jobs/{job_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "job_id">The ID of the job to add to the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutCalendarJob<TResponse>(string calendar_id, string job_id, PutCalendarJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ml/calendars/{calendar_id:calendar_id}/jobs/{job_id:job_id}"), null, RequestParams(requestParameters));
		///<summary>PUT on /_ml/calendars/{calendar_id}/jobs/{job_id} <para></para></summary>
		///<param name = "calendar_id">The ID of the calendar to modify</param>
		///<param name = "job_id">The ID of the job to add to the calendar</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutCalendarJobAsync<TResponse>(string calendar_id, string job_id, PutCalendarJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ml/calendars/{calendar_id:calendar_id}/jobs/{job_id:job_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-put-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to create</param>
		///<param name = "body">The datafeed config</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutDatafeed<TResponse>(string datafeed_id, PostData body, PutDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/datafeeds/{datafeed_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-put-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to create</param>
		///<param name = "body">The datafeed config</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutDatafeedAsync<TResponse>(string datafeed_id, PostData body, PutDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to create</param>
		///<param name = "body">The filter details</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutFilter<TResponse>(string filter_id, PostData body, PutFilterRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ml/filters/{filter_id:filter_id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/filters/{filter_id} <para></para></summary>
		///<param name = "filter_id">The ID of the filter to create</param>
		///<param name = "body">The filter details</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutFilterAsync<TResponse>(string filter_id, PostData body, PutFilterRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ml/filters/{filter_id:filter_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-put-job.html</para></summary>
		///<param name = "job_id">The ID of the job to create</param>
		///<param name = "body">The job</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutJob<TResponse>(string job_id, PostData body, PutJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_ml/anomaly_detectors/{job_id:job_id}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_ml/anomaly_detectors/{job_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-put-job.html</para></summary>
		///<param name = "job_id">The ID of the job to create</param>
		///<param name = "body">The job</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutJobAsync<TResponse>(string job_id, PostData body, PutJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_ml/anomaly_detectors/{job_id:job_id}"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id}/_revert <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-revert-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to revert to</param>
		///<param name = "body">Reversion options</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse RevertModelSnapshot<TResponse>(string job_id, string snapshot_id, PostData body, RevertModelSnapshotRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}/_revert"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id}/_revert <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-revert-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to revert to</param>
		///<param name = "body">Reversion options</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RevertModelSnapshotAsync<TResponse>(string job_id, string snapshot_id, PostData body, RevertModelSnapshotRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}/_revert"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_start <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-start-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to start</param>
		///<param name = "body">The start datafeed parameters</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StartDatafeed<TResponse>(string datafeed_id, PostData body, StartDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_start"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_start <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-start-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to start</param>
		///<param name = "body">The start datafeed parameters</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StartDatafeedAsync<TResponse>(string datafeed_id, PostData body, StartDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_start"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_stop <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-stop-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to stop</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse StopDatafeed<TResponse>(string datafeed_id, StopDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_stop"), null, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_stop <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-stop-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to stop</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> StopDatafeedAsync<TResponse>(string datafeed_id, StopDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_stop"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to update</param>
		///<param name = "body">The datafeed update settings</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateDatafeed<TResponse>(string datafeed_id, PostData body, UpdateDatafeedRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_update"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/datafeeds/{datafeed_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-datafeed.html</para></summary>
		///<param name = "datafeed_id">The ID of the datafeed to update</param>
		///<param name = "body">The datafeed update settings</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateDatafeedAsync<TResponse>(string datafeed_id, PostData body, UpdateDatafeedRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/datafeeds/{datafeed_id:datafeed_id}/_update"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/filters/{filter_id}/_update <para></para></summary>
		///<param name = "filter_id">The ID of the filter to update</param>
		///<param name = "body">The filter update</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateFilter<TResponse>(string filter_id, PostData body, UpdateFilterRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/filters/{filter_id:filter_id}/_update"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/filters/{filter_id}/_update <para></para></summary>
		///<param name = "filter_id">The ID of the filter to update</param>
		///<param name = "body">The filter update</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateFilterAsync<TResponse>(string filter_id, PostData body, UpdateFilterRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/filters/{filter_id:filter_id}/_update"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-job.html</para></summary>
		///<param name = "job_id">The ID of the job to create</param>
		///<param name = "body">The job update settings</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateJob<TResponse>(string job_id, PostData body, UpdateJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_update"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-job.html</para></summary>
		///<param name = "job_id">The ID of the job to create</param>
		///<param name = "body">The job update settings</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateJobAsync<TResponse>(string job_id, PostData body, UpdateJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/_update"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to update</param>
		///<param name = "body">The model snapshot properties to update</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse UpdateModelSnapshot<TResponse>(string job_id, string snapshot_id, PostData body, UpdateModelSnapshotRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}/_update"), body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/{job_id}/model_snapshots/{snapshot_id}/_update <para>http://www.elastic.co/guide/en/elasticsearch/reference/current/ml-update-snapshot.html</para></summary>
		///<param name = "job_id">The ID of the job to fetch</param>
		///<param name = "snapshot_id">The ID of the snapshot to update</param>
		///<param name = "body">The model snapshot properties to update</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> UpdateModelSnapshotAsync<TResponse>(string job_id, string snapshot_id, PostData body, UpdateModelSnapshotRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_ml/anomaly_detectors/{job_id:job_id}/model_snapshots/{snapshot_id:snapshot_id}/_update"), ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/_validate <para></para></summary>
		///<param name = "body">The job config</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ValidateJob<TResponse>(PostData body, ValidateJobRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_ml/anomaly_detectors/_validate", body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/_validate <para></para></summary>
		///<param name = "body">The job config</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ValidateJobAsync<TResponse>(PostData body, ValidateJobRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_ml/anomaly_detectors/_validate", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/_validate/detector <para></para></summary>
		///<param name = "body">The detector</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ValidateDetector<TResponse>(PostData body, ValidateDetectorRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_ml/anomaly_detectors/_validate/detector", body, RequestParams(requestParameters));
		///<summary>POST on /_ml/anomaly_detectors/_validate/detector <para></para></summary>
		///<param name = "body">The detector</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ValidateDetectorAsync<TResponse>(PostData body, ValidateDetectorRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_ml/anomaly_detectors/_validate/detector", ctx, body, RequestParams(requestParameters));
	}
}