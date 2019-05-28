using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.RollupApi
{
	///<summary>Request options for DeleteJob<pre></pre></summary>
	public class DeleteRollupJobRequestParameters : RequestParameters<DeleteRollupJobRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for GetJob<pre></pre></summary>
	public class GetRollupJobRequestParameters : RequestParameters<GetRollupJobRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetCapabilities<pre></pre></summary>
	public class GetRollupCapabilitiesRequestParameters : RequestParameters<GetRollupCapabilitiesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetIndexCapabilities<pre></pre></summary>
	public class GetRollupIndexCapabilitiesRequestParameters : RequestParameters<GetRollupIndexCapabilitiesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for CreateJob<pre></pre></summary>
	public class CreateRollupJobRequestParameters : RequestParameters<CreateRollupJobRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for Search<pre></pre></summary>
	public class RollupSearchRequestParameters : RequestParameters<RollupSearchRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
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

	///<summary>Request options for StartJob<pre></pre></summary>
	public class StartRollupJobRequestParameters : RequestParameters<StartRollupJobRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for StopJob<pre></pre></summary>
	public class StopRollupJobRequestParameters : RequestParameters<StopRollupJobRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Block for (at maximum) the specified duration while waiting for the job to stop. Defaults to 30s.</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>True if the API should block until the job has fully stopped, false if should be executed async. Defaults to false.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}
}