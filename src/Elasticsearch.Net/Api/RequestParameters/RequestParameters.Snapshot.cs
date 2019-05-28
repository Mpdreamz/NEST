using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.SnapshotApi
{
	///<summary>Request options for Snapshot<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class SnapshotRequestParameters : RequestParameters<SnapshotRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Should this request wait until the operation has completed before returning</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for CreateRepository<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class CreateRepositoryRequestParameters : RequestParameters<CreateRepositoryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>Explicit operation timeout for connection to master node</summary>
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

		///<summary>Whether to verify the repository after creation</summary>
		public bool? Verify
		{
			get => Q<bool? >("verify");
			set => Q("verify", value);
		}
	}

	///<summary>Request options for Delete<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class DeleteSnapshotRequestParameters : RequestParameters<DeleteSnapshotRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}
	}

	///<summary>Request options for DeleteRepository<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class DeleteRepositoryRequestParameters : RequestParameters<DeleteRepositoryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>Explicit operation timeout for connection to master node</summary>
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

	///<summary>Request options for Get<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class GetSnapshotRequestParameters : RequestParameters<GetSnapshotRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Whether to ignore unavailable snapshots, defaults to false which means a SnapshotMissingException is thrown</summary>
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

		///<summary>Whether to show verbose snapshot info or only show the basic info found in the repository index blob</summary>
		public bool? Verbose
		{
			get => Q<bool? >("verbose");
			set => Q("verbose", value);
		}
	}

	///<summary>Request options for GetRepository<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class GetRepositoryRequestParameters : RequestParameters<GetRepositoryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
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
	}

	///<summary>Request options for Restore<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class RestoreRequestParameters : RequestParameters<RestoreRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Should this request wait until the operation has completed before returning</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for Status<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class SnapshotStatusRequestParameters : RequestParameters<SnapshotStatusRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Whether to ignore unavailable snapshots, defaults to false which means a SnapshotMissingException is thrown</summary>
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
	}

	///<summary>Request options for VerifyRepository<pre>http://www.elastic.co/guide/en/elasticsearch/reference/master/modules-snapshots.html</pre></summary>
	public class VerifyRepositoryRequestParameters : RequestParameters<VerifyRepositoryRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Explicit operation timeout for connection to master node</summary>
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
}