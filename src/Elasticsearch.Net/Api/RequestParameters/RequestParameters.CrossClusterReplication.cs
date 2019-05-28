using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.CrossClusterReplicationApi
{
	///<summary>Request options for DeleteAutoFollowPattern<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-delete-auto-follow-pattern.html</pre></summary>
	public class DeleteAutoFollowPatternRequestParameters : RequestParameters<DeleteAutoFollowPatternRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for CreateFollowIndex<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-put-follow.html</pre></summary>
	public class CreateFollowIndexRequestParameters : RequestParameters<CreateFollowIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// Sets the number of shard copies that must be active before returning. Defaults to 0. Set to `all` for all shard copies, otherwise set to
		/// any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	///<summary>Request options for FollowIndexStats<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-follow-stats.html</pre></summary>
	public class FollowIndexStatsRequestParameters : RequestParameters<FollowIndexStatsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetAutoFollowPattern<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-auto-follow-pattern.html</pre></summary>
	public class GetAutoFollowPatternRequestParameters : RequestParameters<GetAutoFollowPatternRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for PauseFollowIndex<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-pause-follow.html</pre></summary>
	public class PauseFollowIndexRequestParameters : RequestParameters<PauseFollowIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for CreateAutoFollowPattern<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-put-auto-follow-pattern.html</pre></summary>
	public class CreateAutoFollowPatternRequestParameters : RequestParameters<CreateAutoFollowPatternRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for ResumeFollowIndex<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-resume-follow.html</pre></summary>
	public class ResumeFollowIndexRequestParameters : RequestParameters<ResumeFollowIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Stats<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-stats.html</pre></summary>
	public class CcrStatsRequestParameters : RequestParameters<CcrStatsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for UnfollowIndex<pre>http://www.elastic.co/guide/en/elasticsearch/reference/current</pre></summary>
	public class UnfollowIndexRequestParameters : RequestParameters<UnfollowIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}
}