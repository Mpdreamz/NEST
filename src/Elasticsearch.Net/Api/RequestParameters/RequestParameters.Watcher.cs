using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.WatcherApi
{
	///<summary>Request options for Acknowledge<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-ack-watch.html</pre></summary>
	public class AcknowledgeWatchRequestParameters : RequestParameters<AcknowledgeWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for Activate<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-activate-watch.html</pre></summary>
	public class ActivateWatchRequestParameters : RequestParameters<ActivateWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for Deactivate<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-deactivate-watch.html</pre></summary>
	public class DeactivateWatchRequestParameters : RequestParameters<DeactivateWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for Delete<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-delete-watch.html</pre></summary>
	public class DeleteWatchRequestParameters : RequestParameters<DeleteWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for Execute<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-execute-watch.html</pre></summary>
	public class ExecuteWatchRequestParameters : RequestParameters<ExecuteWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>indicates whether the watch should execute in debug mode</summary>
		public bool? Debug
		{
			get => Q<bool? >("debug");
			set => Q("debug", value);
		}
	}

	///<summary>Request options for Get<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-get-watch.html</pre></summary>
	public class GetWatchRequestParameters : RequestParameters<GetWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for Put<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-put-watch.html</pre></summary>
	public class PutWatchRequestParameters : RequestParameters<PutWatchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>Specify whether the watch is in/active by default</summary>
		public bool? Active
		{
			get => Q<bool? >("active");
			set => Q("active", value);
		}

		///<summary>only update the watch if the last operation that has changed the watch has the specified primary term</summary>
		public long? IfPrimaryTerm
		{
			get => Q<long? >("if_primary_term");
			set => Q("if_primary_term", value);
		}

		///<summary>only update the watch if the last operation that has changed the watch has the specified sequence number</summary>
		public long? IfSequenceNumber
		{
			get => Q<long? >("if_seq_no");
			set => Q("if_seq_no", value);
		}

		///<summary>Explicit version number for concurrency control</summary>
		public long? Version
		{
			get => Q<long? >("version");
			set => Q("version", value);
		}
	}

	///<summary>Request options for Start<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-start.html</pre></summary>
	public class StartWatcherRequestParameters : RequestParameters<StartWatcherRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Stats<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stats.html</pre></summary>
	public class WatcherStatsRequestParameters : RequestParameters<WatcherStatsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Emits stack traces of currently running watches</summary>
		public bool? EmitStacktraces
		{
			get => Q<bool? >("emit_stacktraces");
			set => Q("emit_stacktraces", value);
		}
	}

	///<summary>Request options for Stop<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current/watcher-api-stop.html</pre></summary>
	public class StopWatcherRequestParameters : RequestParameters<StopWatcherRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}
}