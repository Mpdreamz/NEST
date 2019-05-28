using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net
{
	///<summary>Request options for Bulk<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-bulk.html</pre></summary>
	public class BulkRequestParameters : RequestParameters<BulkRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public string Pipeline
		{
			get => Q<string>("pipeline");
			set => Q("pipeline", value);
		}

		///<summary>
		/// If `true` then refresh the effected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this
		/// operation visible to search, if `false` (the default) then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or default list of fields to return, can be overridden on each sub-request</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>Default list of fields to exclude from the returned _source field, can be overridden on each sub-request</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>Default list of fields to extract and return from the _source field, can be overridden on each sub-request</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Default document type for items which don't provide one</summary>
		public string TypeQueryString
		{
			get => Q<string>("type");
			set => Q("type", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the bulk operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for ClearScroll<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-request-scroll.html</pre></summary>
	public class ClearScrollRequestParameters : RequestParameters<ClearScrollRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for Count<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-count.html</pre></summary>
	public class CountRequestParameters : RequestParameters<CountRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public bool? AnalyzeWildcard
		{
			get => Q<bool? >("analyze_wildcard");
			set => Q("analyze_wildcard", value);
		}

		///<summary>The analyzer to use for the query string</summary>
		public string Analyzer
		{
			get => Q<string>("analyzer");
			set => Q("analyzer", value);
		}

		///<summary>The default operator for query string query (AND or OR)</summary>
		public DefaultOperator? DefaultOperator
		{
			get => Q<DefaultOperator? >("default_operator");
			set => Q("default_operator", value);
		}

		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public string Df
		{
			get => Q<string>("df");
			set => Q("df", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public bool? IgnoreThrottled
		{
			get => Q<bool? >("ignore_throttled");
			set => Q("ignore_throttled", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public bool? Lenient
		{
			get => Q<bool? >("lenient");
			set => Q("lenient", value);
		}

		///<summary>Include only documents with a specific `_score` value in the result</summary>
		public double? MinScore
		{
			get => Q<double? >("min_score");
			set => Q("min_score", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Query in the Lucene query string syntax</summary>
		public string QueryOnQueryString
		{
			get => Q<string>("q");
			set => Q("q", value);
		}

		///<summary>A comma-separated list of specific routing values</summary>
		public string[] Routing
		{
			get => Q<string[]>("routing");
			set => Q("routing", value);
		}

		///<summary>The maximum count for each shard, upon reaching which the query execution will terminate early</summary>
		public long? TerminateAfter
		{
			get => Q<long? >("terminate_after");
			set => Q("terminate_after", value);
		}
	}

	///<summary>Request options for Create<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-index_.html</pre></summary>
	public class CreateRequestParameters : RequestParameters<CreateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public string Pipeline
		{
			get => Q<string>("pipeline");
			set => Q("pipeline", value);
		}

		///<summary>
		/// If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this
		/// operation visible to search, if `false` (the default) then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the index operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for Delete<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-delete.html</pre></summary>
	public class DeleteRequestParameters : RequestParameters<DeleteRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>only perform the delete operation if the last operation that has changed the document has the specified primary term</summary>
		public long? IfPrimaryTerm
		{
			get => Q<long? >("if_primary_term");
			set => Q("if_primary_term", value);
		}

		///<summary>only perform the delete operation if the last operation that has changed the document has the specified sequence number</summary>
		public long? IfSequenceNumber
		{
			get => Q<long? >("if_seq_no");
			set => Q("if_seq_no", value);
		}

		///<summary>
		/// If `true` then refresh the effected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this
		/// operation visible to search, if `false` (the default) then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the delete operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for DeleteByQuery<pre>https://www.elastic.co/guide/en/elasticsearch/reference/master/docs-delete-by-query.html</pre></summary>
	public class DeleteByQueryRequestParameters : RequestParameters<DeleteByQueryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public bool? AnalyzeWildcard
		{
			get => Q<bool? >("analyze_wildcard");
			set => Q("analyze_wildcard", value);
		}

		///<summary>The analyzer to use for the query string</summary>
		public string Analyzer
		{
			get => Q<string>("analyzer");
			set => Q("analyzer", value);
		}

		///<summary>What to do when the delete by query hits version conflicts?</summary>
		public Conflicts? Conflicts
		{
			get => Q<Conflicts? >("conflicts");
			set => Q("conflicts", value);
		}

		///<summary>The default operator for query string query (AND or OR)</summary>
		public DefaultOperator? DefaultOperator
		{
			get => Q<DefaultOperator? >("default_operator");
			set => Q("default_operator", value);
		}

		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public string Df
		{
			get => Q<string>("df");
			set => Q("df", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Starting offset (default: 0)</summary>
		public long? From
		{
			get => Q<long? >("from");
			set => Q("from", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public bool? Lenient
		{
			get => Q<bool? >("lenient");
			set => Q("lenient", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Query in the Lucene query string syntax</summary>
		public string QueryOnQueryString
		{
			get => Q<string>("q");
			set => Q("q", value);
		}

		///<summary>Should the effected indexes be refreshed?</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public bool? RequestCache
		{
			get => Q<bool? >("request_cache");
			set => Q("request_cache", value);
		}

		///<summary>The throttle for this request in sub-requests per second. -1 means no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}

		///<summary>A comma-separated list of specific routing values</summary>
		public string[] Routing
		{
			get => Q<string[]>("routing");
			set => Q("routing", value);
		}

		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public TimeSpan Scroll
		{
			get => Q<TimeSpan>("scroll");
			set => Q("scroll", value);
		}

		///<summary>Size on the scroll request powering the delete by query</summary>
		public long? ScrollSize
		{
			get => Q<long? >("scroll_size");
			set => Q("scroll_size", value);
		}

		///<summary>Explicit timeout for each search request. Defaults to no timeout.</summary>
		public TimeSpan SearchTimeout
		{
			get => Q<TimeSpan>("search_timeout");
			set => Q("search_timeout", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Number of hits to return (default: 10)</summary>
		public long? Size
		{
			get => Q<long? >("size");
			set => Q("size", value);
		}

		///<summary>The number of slices this task should be divided into. Defaults to 1 meaning the task isn't sliced into subtasks.</summary>
		public long? Slices
		{
			get => Q<long? >("slices");
			set => Q("slices", value);
		}

		///<summary>A comma-separated list of <field>:<direction> pairs</summary>
		public string[] Sort
		{
			get => Q<string[]>("sort");
			set => Q("sort", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public string[] Stats
		{
			get => Q<string[]>("stats");
			set => Q("stats", value);
		}

		///<summary>The maximum number of documents to collect for each shard, upon reaching which the query execution will terminate early.</summary>
		public long? TerminateAfter
		{
			get => Q<long? >("terminate_after");
			set => Q("terminate_after", value);
		}

		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Specify whether to return document version as part of a hit</summary>
		public bool? Version
		{
			get => Q<bool? >("version");
			set => Q("version", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the delete by query operation. Defaults to 1, meaning the
		/// primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of
		/// copies for the shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}

		///<summary>Should the request should block until the delete by query is complete.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for DeleteByQueryRethrottle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/docs-delete-by-query.html</pre></summary>
	public class DeleteByQueryRethrottleRequestParameters : RequestParameters<DeleteByQueryRethrottleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}
	}

	///<summary>Request options for DeleteScript<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-scripting.html</pre></summary>
	public class DeleteScriptRequestParameters : RequestParameters<DeleteScriptRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>Specify timeout for connection to master</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for DocumentExists<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-get.html</pre></summary>
	public class DocumentExistsRequestParameters : RequestParameters<DocumentExistsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.HEAD;
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public string[] StoredFields
		{
			get => Q<string[]>("stored_fields");
			set => Q("stored_fields", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for SourceExists<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-get.html</pre></summary>
	public class SourceExistsRequestParameters : RequestParameters<SourceExistsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.HEAD;
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for Explain<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-explain.html</pre></summary>
	public class ExplainRequestParameters : RequestParameters<ExplainRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Specify whether wildcards and prefix queries in the query string query should be analyzed (default: false)</summary>
		public bool? AnalyzeWildcard
		{
			get => Q<bool? >("analyze_wildcard");
			set => Q("analyze_wildcard", value);
		}

		///<summary>The analyzer for the query string query</summary>
		public string Analyzer
		{
			get => Q<string>("analyzer");
			set => Q("analyzer", value);
		}

		///<summary>The default operator for query string query (AND or OR)</summary>
		public DefaultOperator? DefaultOperator
		{
			get => Q<DefaultOperator? >("default_operator");
			set => Q("default_operator", value);
		}

		///<summary>The default field for query string query (default: _all)</summary>
		public string Df
		{
			get => Q<string>("df");
			set => Q("df", value);
		}

		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public bool? Lenient
		{
			get => Q<bool? >("lenient");
			set => Q("lenient", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Query in the Lucene query string syntax</summary>
		public string QueryOnQueryString
		{
			get => Q<string>("q");
			set => Q("q", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public string[] StoredFields
		{
			get => Q<string[]>("stored_fields");
			set => Q("stored_fields", value);
		}
	}

	///<summary>Request options for FieldCapabilities<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-field-caps.html</pre></summary>
	public class FieldCapabilitiesRequestParameters : RequestParameters<FieldCapabilitiesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>A comma-separated list of field names</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}
	}

	///<summary>Request options for Get<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-get.html</pre></summary>
	public class GetRequestParameters : RequestParameters<GetRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public string[] StoredFields
		{
			get => Q<string[]>("stored_fields");
			set => Q("stored_fields", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for GetScript<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-scripting.html</pre></summary>
	public class GetScriptRequestParameters : RequestParameters<GetScriptRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Specify timeout for connection to master</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}
	}

	///<summary>Request options for Source<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-get.html</pre></summary>
	public class SourceRequestParameters : RequestParameters<SourceRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for Index<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-index_.html</pre></summary>
	public class IndexRequestParameters : RequestParameters<IndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>only perform the index operation if the last operation that has changed the document has the specified primary term</summary>
		public long? IfPrimaryTerm
		{
			get => Q<long? >("if_primary_term");
			set => Q("if_primary_term", value);
		}

		///<summary>only perform the index operation if the last operation that has changed the document has the specified sequence number</summary>
		public long? IfSequenceNumber
		{
			get => Q<long? >("if_seq_no");
			set => Q("if_seq_no", value);
		}

		///<summary>Explicit operation type</summary>
		public OpType? OpType
		{
			get => Q<OpType? >("op_type");
			set => Q("op_type", value);
		}

		///<summary>The pipeline id to preprocess incoming documents with</summary>
		public string Pipeline
		{
			get => Q<string>("pipeline");
			set => Q("pipeline", value);
		}

		///<summary>
		/// If `true` then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this
		/// operation visible to search, if `false` (the default) then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the index operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for RootNodeInfo<pre>http://www.elastic.co/guide/</pre></summary>
	public class RootNodeInfoRequestParameters : RequestParameters<RootNodeInfoRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for MultiGet<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-multi-get.html</pre></summary>
	public class MultiGetRequestParameters : RequestParameters<MultiGetRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to perform the operation in realtime or search mode</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Refresh the shard containing the document before performing the operation</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>A comma-separated list of stored fields to return in the response</summary>
		public string[] StoredFields
		{
			get => Q<string[]>("stored_fields");
			set => Q("stored_fields", value);
		}
	}

	///<summary>Request options for MultiSearch<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-multi-search.html</pre></summary>
	public class MultiSearchRequestParameters : RequestParameters<MultiSearchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public bool? CcsMinimizeRoundtrips
		{
			get => Q<bool? >("ccs_minimize_roundtrips");
			set => Q("ccs_minimize_roundtrips", value);
		}

		///<summary>Controls the maximum number of concurrent searches the multi search api will execute</summary>
		public long? MaxConcurrentSearches
		{
			get => Q<long? >("max_concurrent_searches");
			set => Q("max_concurrent_searches", value);
		}

		///<summary>
		/// The number of concurrent shard requests each sub search executes concurrently. This value should be used to limit the impact of the search
		/// on the cluster in order to limit the number of concurrent shard requests
		///</summary>
		public long? MaxConcurrentShardRequests
		{
			get => Q<long? >("max_concurrent_shard_requests");
			set => Q("max_concurrent_shard_requests", value);
		}

		///<summary>
		/// A threshold that enforces a pre-filter roundtrip to prefilter search shards based on query rewriting if the number of shards the search
		/// request expands to exceeds the threshold. This filter roundtrip can limit the number of shards significantly if for instance a shard can
		/// not match any documents based on it's rewrite method ie. if date filters are mandatory to match but the shard bounds and the query are
		/// disjoint.
		///</summary>
		public long? PreFilterShardSize
		{
			get => Q<long? >("pre_filter_shard_size");
			set => Q("pre_filter_shard_size", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public bool? TotalHitsAsInteger
		{
			get => Q<bool? >("rest_total_hits_as_int");
			set => Q("rest_total_hits_as_int", value);
		}

		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public bool? TypedKeys
		{
			get => Q<bool? >("typed_keys");
			set => Q("typed_keys", value);
		}
	}

	///<summary>Request options for MultiSearchTemplate<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/search-multi-search.html</pre></summary>
	public class MultiSearchTemplateRequestParameters : RequestParameters<MultiSearchTemplateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public bool? CcsMinimizeRoundtrips
		{
			get => Q<bool? >("ccs_minimize_roundtrips");
			set => Q("ccs_minimize_roundtrips", value);
		}

		///<summary>Controls the maximum number of concurrent searches the multi search api will execute</summary>
		public long? MaxConcurrentSearches
		{
			get => Q<long? >("max_concurrent_searches");
			set => Q("max_concurrent_searches", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public bool? TotalHitsAsInteger
		{
			get => Q<bool? >("rest_total_hits_as_int");
			set => Q("rest_total_hits_as_int", value);
		}

		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public bool? TypedKeys
		{
			get => Q<bool? >("typed_keys");
			set => Q("typed_keys", value);
		}
	}

	///<summary>Request options for MultiTermVectors<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-multi-termvectors.html</pre></summary>
	public class MultiTermVectorsRequestParameters : RequestParameters<MultiTermVectorsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Specifies if document count, sum of document frequencies and sum of total term frequencies should be returned. Applies to all returned
		/// documents unless otherwise specified in body "params" or "docs".
		///</summary>
		public bool? FieldStatistics
		{
			get => Q<bool? >("field_statistics");
			set => Q("field_statistics", value);
		}

		///<summary>A comma-separated list of fields to return. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
		}

		///<summary>Specifies if term offsets should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public bool? Offsets
		{
			get => Q<bool? >("offsets");
			set => Q("offsets", value);
		}

		///<summary>Specifies if term payloads should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public bool? Payloads
		{
			get => Q<bool? >("payloads");
			set => Q("payloads", value);
		}

		///<summary>Specifies if term positions should be returned. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public bool? Positions
		{
			get => Q<bool? >("positions");
			set => Q("positions", value);
		}

		///<summary>
		/// Specify the node or shard the operation should be performed on (default: random) .Applies to all returned documents unless otherwise
		/// specified in body "params" or "docs".
		///</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specifies if requests are real-time as opposed to near-real-time (default: true).</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Specific routing value. Applies to all returned documents unless otherwise specified in body "params" or "docs".</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>
		/// Specifies if total term frequency and document frequency should be returned. Applies to all returned documents unless otherwise specified
		/// in body "params" or "docs".
		///</summary>
		public bool? TermStatistics
		{
			get => Q<bool? >("term_statistics");
			set => Q("term_statistics", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for Ping<pre>http://www.elastic.co/guide/</pre></summary>
	public class PingRequestParameters : RequestParameters<PingRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.HEAD;
	}

	///<summary>Request options for PutScript<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-scripting.html</pre></summary>
	public class PutScriptRequestParameters : RequestParameters<PutScriptRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>Context name to compile script against</summary>
		public string Context
		{
			get => Q<string>("context");
			set => Q("context", value);
		}

		///<summary>Specify timeout for connection to master</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for ReindexOnServer<pre>https://www.elastic.co/guide/en/elasticsearch/reference/master/docs-reindex.html</pre></summary>
	public class ReindexOnServerRequestParameters : RequestParameters<ReindexOnServerRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Should the effected indexes be refreshed?</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>The throttle to set on this request in sub-requests per second. -1 means no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}

		///<summary>Control how long to keep the search context alive</summary>
		public TimeSpan Scroll
		{
			get => Q<TimeSpan>("scroll");
			set => Q("scroll", value);
		}

		///<summary>The number of slices this task should be divided into. Defaults to 1 meaning the task isn't sliced into subtasks.</summary>
		public long? Slices
		{
			get => Q<long? >("slices");
			set => Q("slices", value);
		}

		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the reindex operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}

		///<summary>Should the request should block until the reindex is complete.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for ReindexRethrottle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/master/docs-reindex.html</pre></summary>
	public class ReindexRethrottleRequestParameters : RequestParameters<ReindexRethrottleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}
	}

	///<summary>Request options for RenderSearchTemplate<pre>http://www.elasticsearch.org/guide/en/elasticsearch/reference/master/search-template.html</pre></summary>
	public class RenderSearchTemplateRequestParameters : RequestParameters<RenderSearchTemplateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for ExecutePainlessScript<pre>https://www.elastic.co/guide/en/elasticsearch/painless/master/painless-execute-api.html</pre></summary>
	public class ExecutePainlessScriptRequestParameters : RequestParameters<ExecutePainlessScriptRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Scroll<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-request-scroll.html</pre></summary>
	public class ScrollRequestParameters : RequestParameters<ScrollRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public bool? TotalHitsAsInteger
		{
			get => Q<bool? >("rest_total_hits_as_int");
			set => Q("rest_total_hits_as_int", value);
		}
	}

	///<summary>Request options for Search<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-search.html</pre></summary>
	public class SearchRequestParameters : RequestParameters<SearchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Indicate if an error should be returned if there is a partial search failure or timeout</summary>
		public bool? AllowPartialSearchResults
		{
			get => Q<bool? >("allow_partial_search_results");
			set => Q("allow_partial_search_results", value);
		}

		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public bool? AnalyzeWildcard
		{
			get => Q<bool? >("analyze_wildcard");
			set => Q("analyze_wildcard", value);
		}

		///<summary>The analyzer to use for the query string</summary>
		public string Analyzer
		{
			get => Q<string>("analyzer");
			set => Q("analyzer", value);
		}

		///<summary>
		/// The number of shard results that should be reduced at once on the coordinating node. This value should be used as a protection mechanism
		/// to reduce the memory overhead per search request if the potential number of shards in the request can be large.
		///</summary>
		public long? BatchedReduceSize
		{
			get => Q<long? >("batched_reduce_size");
			set => Q("batched_reduce_size", value);
		}

		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public bool? CcsMinimizeRoundtrips
		{
			get => Q<bool? >("ccs_minimize_roundtrips");
			set => Q("ccs_minimize_roundtrips", value);
		}

		///<summary>The default operator for query string query (AND or OR)</summary>
		public DefaultOperator? DefaultOperator
		{
			get => Q<DefaultOperator? >("default_operator");
			set => Q("default_operator", value);
		}

		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public string Df
		{
			get => Q<string>("df");
			set => Q("df", value);
		}

		///<summary>A comma-separated list of fields to return as the docvalue representation of a field for each hit</summary>
		public string[] DocValueFields
		{
			get => Q<string[]>("docvalue_fields");
			set => Q("docvalue_fields", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public bool? IgnoreThrottled
		{
			get => Q<bool? >("ignore_throttled");
			set => Q("ignore_throttled", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public bool? Lenient
		{
			get => Q<bool? >("lenient");
			set => Q("lenient", value);
		}

		///<summary>
		/// The number of concurrent shard requests per node this search executes concurrently. This value should be used to limit the impact of the
		/// search on the cluster in order to limit the number of concurrent shard requests
		///</summary>
		public long? MaxConcurrentShardRequests
		{
			get => Q<long? >("max_concurrent_shard_requests");
			set => Q("max_concurrent_shard_requests", value);
		}

		///<summary>
		/// A threshold that enforces a pre-filter roundtrip to prefilter search shards based on query rewriting if the number of shards the search
		/// request expands to exceeds the threshold. This filter roundtrip can limit the number of shards significantly if for instance a shard can
		/// not match any documents based on it's rewrite method ie. if date filters are mandatory to match but the shard bounds and the query are
		/// disjoint.
		///</summary>
		public long? PreFilterShardSize
		{
			get => Q<long? >("pre_filter_shard_size");
			set => Q("pre_filter_shard_size", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public bool? RequestCache
		{
			get => Q<bool? >("request_cache");
			set => Q("request_cache", value);
		}

		///<summary>A comma-separated list of specific routing values</summary>
		public string[] Routing
		{
			get => Q<string[]>("routing");
			set => Q("routing", value);
		}

		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public TimeSpan Scroll
		{
			get => Q<TimeSpan>("scroll");
			set => Q("scroll", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Specify whether to return sequence number and primary term of the last modification of each hit</summary>
		public bool? SequenceNumberPrimaryTerm
		{
			get => Q<bool? >("seq_no_primary_term");
			set => Q("seq_no_primary_term", value);
		}

		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public string[] Stats
		{
			get => Q<string[]>("stats");
			set => Q("stats", value);
		}

		///<summary>A comma-separated list of stored fields to return as part of a hit</summary>
		public string[] StoredFields
		{
			get => Q<string[]>("stored_fields");
			set => Q("stored_fields", value);
		}

		///<summary>Specify which field to use for suggestions</summary>
		public string SuggestField
		{
			get => Q<string>("suggest_field");
			set => Q("suggest_field", value);
		}

		///<summary>Specify suggest mode</summary>
		public SuggestMode? SuggestMode
		{
			get => Q<SuggestMode? >("suggest_mode");
			set => Q("suggest_mode", value);
		}

		///<summary>How many suggestions to return in response</summary>
		public long? SuggestSize
		{
			get => Q<long? >("suggest_size");
			set => Q("suggest_size", value);
		}

		///<summary>The source text for which the suggestions should be returned</summary>
		public string SuggestText
		{
			get => Q<string>("suggest_text");
			set => Q("suggest_text", value);
		}

		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public bool? TotalHitsAsInteger
		{
			get => Q<bool? >("rest_total_hits_as_int");
			set => Q("rest_total_hits_as_int", value);
		}

		///<summary>Indicate if the number of documents that match the query should be tracked</summary>
		public bool? TrackTotalHits
		{
			get => Q<bool? >("track_total_hits");
			set => Q("track_total_hits", value);
		}

		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public bool? TypedKeys
		{
			get => Q<bool? >("typed_keys");
			set => Q("typed_keys", value);
		}
	}

	///<summary>Request options for SearchShards<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/search-shards.html</pre></summary>
	public class SearchShardsRequestParameters : RequestParameters<SearchShardsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}
	}

	///<summary>Request options for SearchTemplate<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/search-template.html</pre></summary>
	public class SearchTemplateRequestParameters : RequestParameters<SearchTemplateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution</summary>
		public bool? CcsMinimizeRoundtrips
		{
			get => Q<bool? >("ccs_minimize_roundtrips");
			set => Q("ccs_minimize_roundtrips", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Specify whether to return detailed information about score computation as part of a hit</summary>
		public bool? Explain
		{
			get => Q<bool? >("explain");
			set => Q("explain", value);
		}

		///<summary>Whether specified concrete, expanded or aliased indices should be ignored when throttled</summary>
		public bool? IgnoreThrottled
		{
			get => Q<bool? >("ignore_throttled");
			set => Q("ignore_throttled", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specify whether to profile the query execution</summary>
		public bool? Profile
		{
			get => Q<bool? >("profile");
			set => Q("profile", value);
		}

		///<summary>A comma-separated list of specific routing values</summary>
		public string[] Routing
		{
			get => Q<string[]>("routing");
			set => Q("routing", value);
		}

		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public TimeSpan Scroll
		{
			get => Q<TimeSpan>("scroll");
			set => Q("scroll", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public bool? TotalHitsAsInteger
		{
			get => Q<bool? >("rest_total_hits_as_int");
			set => Q("rest_total_hits_as_int", value);
		}

		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public bool? TypedKeys
		{
			get => Q<bool? >("typed_keys");
			set => Q("typed_keys", value);
		}
	}

	///<summary>Request options for TermVectors<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-termvectors.html</pre></summary>
	public class TermVectorsRequestParameters : RequestParameters<TermVectorsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Specifies if document count, sum of document frequencies and sum of total term frequencies should be returned.</summary>
		public bool? FieldStatistics
		{
			get => Q<bool? >("field_statistics");
			set => Q("field_statistics", value);
		}

		///<summary>A comma-separated list of fields to return.</summary>
		public string[] Fields
		{
			get => Q<string[]>("fields");
			set => Q("fields", value);
		}

		///<summary>Specifies if term offsets should be returned.</summary>
		public bool? Offsets
		{
			get => Q<bool? >("offsets");
			set => Q("offsets", value);
		}

		///<summary>Specifies if term payloads should be returned.</summary>
		public bool? Payloads
		{
			get => Q<bool? >("payloads");
			set => Q("payloads", value);
		}

		///<summary>Specifies if term positions should be returned.</summary>
		public bool? Positions
		{
			get => Q<bool? >("positions");
			set => Q("positions", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random).</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Specifies if request is real-time as opposed to near-real-time (default: true).</summary>
		public bool? Realtime
		{
			get => Q<bool? >("realtime");
			set => Q("realtime", value);
		}

		///<summary>Specific routing value.</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>Specifies if total term frequency and document frequency should be returned.</summary>
		public bool? TermStatistics
		{
			get => Q<bool? >("term_statistics");
			set => Q("term_statistics", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}

		///<summary>Specific version type</summary>
		public VersionType? VersionType
		{
			get => Q<VersionType? >("version_type");
			set => Q("version_type", value);
		}
	}

	///<summary>Request options for Update<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/docs-update.html</pre></summary>
	public class UpdateRequestParameters : RequestParameters<UpdateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>only perform the update operation if the last operation that has changed the document has the specified primary term</summary>
		public long? IfPrimaryTerm
		{
			get => Q<long? >("if_primary_term");
			set => Q("if_primary_term", value);
		}

		///<summary>only perform the update operation if the last operation that has changed the document has the specified sequence number</summary>
		public long? IfSequenceNumber
		{
			get => Q<long? >("if_seq_no");
			set => Q("if_seq_no", value);
		}

		///<summary>The script language (default: painless)</summary>
		public string Lang
		{
			get => Q<string>("lang");
			set => Q("lang", value);
		}

		///<summary>
		/// If `true` then refresh the effected shards to make this operation visible to search, if `wait_for` then wait for a refresh to make this
		/// operation visible to search, if `false` (the default) then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specify how many times should the operation be retried when a conflict occurs (default: 0)</summary>
		public long? RetryOnConflict
		{
			get => Q<long? >("retry_on_conflict");
			set => Q("retry_on_conflict", value);
		}

		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the update operation. Defaults to 1, meaning the primary shard
		/// only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of copies for the
		/// shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for UpdateByQuery<pre>https://www.elastic.co/guide/en/elasticsearch/reference/master/docs-update-by-query.html</pre></summary>
	public class UpdateByQueryRequestParameters : RequestParameters<UpdateByQueryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Specify whether wildcard and prefix queries should be analyzed (default: false)</summary>
		public bool? AnalyzeWildcard
		{
			get => Q<bool? >("analyze_wildcard");
			set => Q("analyze_wildcard", value);
		}

		///<summary>The analyzer to use for the query string</summary>
		public string Analyzer
		{
			get => Q<string>("analyzer");
			set => Q("analyzer", value);
		}

		///<summary>What to do when the update by query hits version conflicts?</summary>
		public Conflicts? Conflicts
		{
			get => Q<Conflicts? >("conflicts");
			set => Q("conflicts", value);
		}

		///<summary>The default operator for query string query (AND or OR)</summary>
		public DefaultOperator? DefaultOperator
		{
			get => Q<DefaultOperator? >("default_operator");
			set => Q("default_operator", value);
		}

		///<summary>The field to use as default where no field prefix is given in the query string</summary>
		public string Df
		{
			get => Q<string>("df");
			set => Q("df", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Starting offset (default: 0)</summary>
		public long? From
		{
			get => Q<long? >("from");
			set => Q("from", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}

		///<summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored</summary>
		public bool? Lenient
		{
			get => Q<bool? >("lenient");
			set => Q("lenient", value);
		}

		///<summary>Ingest pipeline to set on index requests made by this action. (default: none)</summary>
		public string Pipeline
		{
			get => Q<string>("pipeline");
			set => Q("pipeline", value);
		}

		///<summary>Specify the node or shard the operation should be performed on (default: random)</summary>
		public string Preference
		{
			get => Q<string>("preference");
			set => Q("preference", value);
		}

		///<summary>Query in the Lucene query string syntax</summary>
		public string QueryOnQueryString
		{
			get => Q<string>("q");
			set => Q("q", value);
		}

		///<summary>Should the effected indexes be refreshed?</summary>
		public bool? Refresh
		{
			get => Q<bool? >("refresh");
			set => Q("refresh", value);
		}

		///<summary>Specify if request cache should be used for this request or not, defaults to index level setting</summary>
		public bool? RequestCache
		{
			get => Q<bool? >("request_cache");
			set => Q("request_cache", value);
		}

		///<summary>The throttle to set on this request in sub-requests per second. -1 means no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}

		///<summary>A comma-separated list of specific routing values</summary>
		public string[] Routing
		{
			get => Q<string[]>("routing");
			set => Q("routing", value);
		}

		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public TimeSpan Scroll
		{
			get => Q<TimeSpan>("scroll");
			set => Q("scroll", value);
		}

		///<summary>Size on the scroll request powering the update by query</summary>
		public long? ScrollSize
		{
			get => Q<long? >("scroll_size");
			set => Q("scroll_size", value);
		}

		///<summary>Explicit timeout for each search request. Defaults to no timeout.</summary>
		public TimeSpan SearchTimeout
		{
			get => Q<TimeSpan>("search_timeout");
			set => Q("search_timeout", value);
		}

		///<summary>Search operation type</summary>
		public SearchType? SearchType
		{
			get => Q<SearchType? >("search_type");
			set => Q("search_type", value);
		}

		///<summary>Number of hits to return (default: 10)</summary>
		public long? Size
		{
			get => Q<long? >("size");
			set => Q("size", value);
		}

		///<summary>The number of slices this task should be divided into. Defaults to 1 meaning the task isn't sliced into subtasks.</summary>
		public long? Slices
		{
			get => Q<long? >("slices");
			set => Q("slices", value);
		}

		///<summary>A comma-separated list of <field>:<direction> pairs</summary>
		public string[] Sort
		{
			get => Q<string[]>("sort");
			set => Q("sort", value);
		}

		///<summary>True or false to return the _source field or not, or a list of fields to return</summary>
		public bool? SourceEnabled
		{
			get => Q<bool? >("_source");
			set => Q("_source", value);
		}

		///<summary>A list of fields to exclude from the returned _source field</summary>
		public string[] SourceExcludes
		{
			get => Q<string[]>("_source_excludes");
			set => Q("_source_excludes", value);
		}

		///<summary>A list of fields to extract and return from the _source field</summary>
		public string[] SourceIncludes
		{
			get => Q<string[]>("_source_includes");
			set => Q("_source_includes", value);
		}

		///<summary>Specific 'tag' of the request for logging and statistical purposes</summary>
		public string[] Stats
		{
			get => Q<string[]>("stats");
			set => Q("stats", value);
		}

		///<summary>The maximum number of documents to collect for each shard, upon reaching which the query execution will terminate early.</summary>
		public long? TerminateAfter
		{
			get => Q<long? >("terminate_after");
			set => Q("terminate_after", value);
		}

		///<summary>Time each individual bulk request should wait for shards that are unavailable.</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Specify whether to return document version as part of a hit</summary>
		public bool? Version
		{
			get => Q<bool? >("version");
			set => Q("version", value);
		}

		///<summary>Should the document increment the version number (internal) on hit or not (reindex)</summary>
		public bool? VersionType
		{
			get => Q<bool? >("version_type");
			set => Q("version_type", value);
		}

		///<summary>
		/// Sets the number of shard copies that must be active before proceeding with the update by query operation. Defaults to 1, meaning the
		/// primary shard only. Set to `all` for all shard copies, otherwise set to any non-negative value less than or equal to the total number of
		/// copies for the shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}

		///<summary>Should the request should block until the update by query operation is complete.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for UpdateByQueryRethrottle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/docs-update-by-query.html</pre></summary>
	public class UpdateByQueryRethrottleRequestParameters : RequestParameters<UpdateByQueryRethrottleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>The throttle to set on this request in floating sub-requests per second. -1 means set no throttle.</summary>
		public long? RequestsPerSecond
		{
			get => Q<long? >("requests_per_second");
			set => Q("requests_per_second", value);
		}
	}
}