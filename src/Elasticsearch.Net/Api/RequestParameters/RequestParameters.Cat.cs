using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.CatApi
{
	///<summary>Request options for Aliases<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-alias.html</pre></summary>
	public class CatAliasesRequestParameters : RequestParameters<CatAliasesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Allocation<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-allocation.html</pre></summary>
	public class CatAllocationRequestParameters : RequestParameters<CatAllocationRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Count<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-count.html</pre></summary>
	public class CatCountRequestParameters : RequestParameters<CatCountRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Fielddata<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-fielddata.html</pre></summary>
	public class CatFielddataRequestParameters : RequestParameters<CatFielddataRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>A comma-separated list of fields to return in the output</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Health<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-health.html</pre></summary>
	public class CatHealthRequestParameters : RequestParameters<CatHealthRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Set to false to disable timestamping</summary>
		public bool? IncludeTimestamp
		{
			get => Q<bool? >("ts");
			set => Q("ts", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Help<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat.html</pre></summary>
	public class CatHelpRequestParameters : RequestParameters<CatHelpRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}
	}

	///<summary>Request options for Indices<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-indices.html</pre></summary>
	public class CatIndicesRequestParameters : RequestParameters<CatIndicesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>A health status ("green", "yellow", or "red" to filter only indices matching the specified health status</summary>
		public Health? Health
		{
			get => Q<Health? >("health");
			set => Q("health", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Set to true to return stats only for primary shards</summary>
		public bool? Pri
		{
			get => Q<bool? >("pri");
			set => Q("pri", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Master<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-master.html</pre></summary>
	public class CatMasterRequestParameters : RequestParameters<CatMasterRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for NodeAttributes<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodeattrs.html</pre></summary>
	public class CatNodeAttributesRequestParameters : RequestParameters<CatNodeAttributesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Nodes<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodes.html</pre></summary>
	public class CatNodesRequestParameters : RequestParameters<CatNodesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Return the full node ID instead of the shortened version (default: false)</summary>
		public bool? FullId
		{
			get => Q<bool? >("full_id");
			set => Q("full_id", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for PendingTasks<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-pending-tasks.html</pre></summary>
	public class CatPendingTasksRequestParameters : RequestParameters<CatPendingTasksRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Plugins<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-plugins.html</pre></summary>
	public class CatPluginsRequestParameters : RequestParameters<CatPluginsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Recovery<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-recovery.html</pre></summary>
	public class CatRecoveryRequestParameters : RequestParameters<CatRecoveryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Repositories<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-repositories.html</pre></summary>
	public class CatRepositoriesRequestParameters : RequestParameters<CatRepositoriesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Segments<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-segments.html</pre></summary>
	public class CatSegmentsRequestParameters : RequestParameters<CatSegmentsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Shards<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-shards.html</pre></summary>
	public class CatShardsRequestParameters : RequestParameters<CatShardsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>The unit in which to display byte values</summary>
		public Bytes? Bytes
		{
			get => Q<Bytes? >("bytes");
			set => Q("bytes", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Snapshots<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-snapshots.html</pre></summary>
	public class CatSnapshotsRequestParameters : RequestParameters<CatSnapshotsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Set to true to ignore unavailable snapshots</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Tasks<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</pre></summary>
	public class CatTasksRequestParameters : RequestParameters<CatTasksRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>A comma-separated list of actions that should be returned. Leave empty to return all.</summary>
		public string[] Actions
		{
			get => Q<string[]>("actions");
			set => Q("actions", value);
		}

		///<summary>Return detailed task information (default: false)</summary>
		public bool? Detailed
		{
			get => Q<bool? >("detailed");
			set => Q("detailed", value);
		}

		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>
		/// A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you're
		/// connecting to, leave empty to get information from all nodes
		///</summary>
		public string[] NodeId
		{
			get => Q<string[]>("node_id");
			set => Q("node_id", value);
		}

		///<summary>Return tasks with specified parent task id. Set to -1 to return all.</summary>
		public long? ParentTask
		{
			get => Q<long? >("parent_task");
			set => Q("parent_task", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for Templates<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-templates.html</pre></summary>
	public class CatTemplatesRequestParameters : RequestParameters<CatTemplatesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}

	///<summary>Request options for ThreadPool<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-thread-pool.html</pre></summary>
	public class CatThreadPoolRequestParameters : RequestParameters<CatThreadPoolRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public string Format
		{
			get => Q<string>("format");
			set => Q("format", value);
		}

		///<summary>Comma-separated list of column names to display</summary>
		public string[] Headers
		{
			get => Q<string[]>("h");
			set => Q("h", value);
		}

		///<summary>Return help information</summary>
		public bool? Help
		{
			get => Q<bool? >("help");
			set => Q("help", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>The multiplier in which to display values</summary>
		public Size? Size
		{
			get => Q<Size? >("size");
			set => Q("size", value);
		}

		///<summary>Comma-separated list of column names or column aliases to sort by</summary>
		public string[] SortByColumns
		{
			get => Q<string[]>("s");
			set => Q("s", value);
		}

		///<summary>Verbose mode. Display column headers</summary>
		public bool? Verbose
		{
			get => Q<bool? >("v");
			set => Q("v", value);
		}
	}
}