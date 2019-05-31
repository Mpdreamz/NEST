// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------



// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.IndexLifecycleManagementApi
{
	///<summary>Request options for DeleteLifecycle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-delete-lifecycle.html</pre></summary>
	public class DeleteLifecycleRequestParameters : RequestParameters<DeleteLifecycleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for ExplainLifecycle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-explain-lifecycle.html</pre></summary>
	public class ExplainLifecycleRequestParameters : RequestParameters<ExplainLifecycleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetLifecycle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-lifecycle.html</pre></summary>
	public class GetLifecycleRequestParameters : RequestParameters<GetLifecycleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetStatus<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-get-status.html</pre></summary>
	public class GetIlmStatusRequestParameters : RequestParameters<GetIlmStatusRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for MoveToStep<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-move-to-step.html</pre></summary>
	public class MoveToStepRequestParameters : RequestParameters<MoveToStepRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for PutLifecycle<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-put-lifecycle.html</pre></summary>
	public class PutLifecycleRequestParameters : RequestParameters<PutLifecycleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
	}

	///<summary>Request options for RemovePolicy<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-remove-policy.html</pre></summary>
	public class RemovePolicyRequestParameters : RequestParameters<RemovePolicyRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Retry<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-retry-policy.html</pre></summary>
	public class RetryIlmRequestParameters : RequestParameters<RetryIlmRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Start<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-start.html</pre></summary>
	public class StartIlmRequestParameters : RequestParameters<StartIlmRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for Stop<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/ilm-stop.html</pre></summary>
	public class StopIlmRequestParameters : RequestParameters<StopIlmRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}
}