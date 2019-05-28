using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.NodesApi
{
	///<summary>Request options for HotThreads<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-hot-threads.html</pre></summary>
	public class NodesHotThreadsRequestParameters : RequestParameters<NodesHotThreadsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Don't show threads that are in known-idle places, such as waiting on a socket select or pulling from an empty task queue (default: true)</summary>
		public bool? IgnoreIdleThreads
		{
			get => Q<bool? >("ignore_idle_threads");
			set => Q("ignore_idle_threads", value);
		}

		///<summary>The interval for the second sampling of threads</summary>
		public TimeSpan Interval
		{
			get => Q<TimeSpan>("interval");
			set => Q("interval", value);
		}

		///<summary>Number of samples of thread stacktrace (default: 10)</summary>
		public long? Snapshots
		{
			get => Q<long? >("snapshots");
			set => Q("snapshots", value);
		}

		///<summary>The type to sample (default: cpu)</summary>
		public ThreadType? ThreadType
		{
			get => Q<ThreadType? >("type");
			set => Q("type", value);
		}

		///<summary>Specify the number of threads to provide information for (default: 3)</summary>
		public long? Threads
		{
			get => Q<long? >("threads");
			set => Q("threads", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for Info<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-info.html</pre></summary>
	public class NodesInfoRequestParameters : RequestParameters<NodesInfoRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Return settings in flat format (default: false)</summary>
		public bool? FlatSettings
		{
			get => Q<bool? >("flat_settings");
			set => Q("flat_settings", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for ReloadSecureSettings<pre>https://www.elastic.co/guide/en/elasticsearch/reference/master/secure-settings.html#reloadable-secure-settings</pre></summary>
	public class ReloadSecureSettingsRequestParameters : RequestParameters<ReloadSecureSettingsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for Stats<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-stats.html</pre></summary>
	public class NodesStatsRequestParameters : RequestParameters<NodesStatsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>A comma-separated list of fields for `fielddata` and `suggest` index metric (supports wildcards)</summary>
		public string[] CompletionFields
		{
			get => Q<string[]>("completion_fields");
			set => Q("completion_fields", value);
		}

		///<summary>A comma-separated list of fields for `fielddata` index metric (supports wildcards)</summary>
		public string[] FielddataFields
		{
			get => Q<string[]>("fielddata_fields");
			set => Q("fielddata_fields", value);
		}

		///<summary>A comma-separated list of fields for `fielddata` and `completion` index metric (supports wildcards)</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
		}

		///<summary>A comma-separated list of search groups for `search` index metric</summary>
		public bool? Groups
		{
			get => Q<bool? >("groups");
			set => Q("groups", value);
		}

		///<summary>Whether to report the aggregated disk usage of each one of the Lucene index files (only applies if segment stats are requested)</summary>
		public bool? IncludeSegmentFileSizes
		{
			get => Q<bool? >("include_segment_file_sizes");
			set => Q("include_segment_file_sizes", value);
		}

		///<summary>Return indices stats aggregated at index, node or shard level</summary>
		public Level? Level
		{
			get => Q<Level? >("level");
			set => Q("level", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>A comma-separated list of document types for the `indexing` index metric</summary>
		public string[] Types
		{
			get => Q<string[]>("types");
			set => Q("types", value);
		}
	}

	///<summary>Request options for Usage<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cluster-nodes-usage.html</pre></summary>
	public class NodesUsageRequestParameters : RequestParameters<NodesUsageRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}
}