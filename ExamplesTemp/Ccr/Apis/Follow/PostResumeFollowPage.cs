using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Ccr.Apis.Follow
{
	public class PostResumeFollowPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line38()
		{
			// tag::109db8ff7b715aca98de8ef1ab7e44ab[]
			var response0 = new SearchResponse<object>();
			// end::109db8ff7b715aca98de8ef1ab7e44ab[]

			response0.MatchesExample(@"POST /<follower_index>/_ccr/resume_follow
			{
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line80()
		{
			// tag::824fded1f9db28906ae7e85ae8de9bd0[]
			var response0 = new SearchResponse<object>();
			// end::824fded1f9db28906ae7e85ae8de9bd0[]

			response0.MatchesExample(@"POST /follower_index/_ccr/resume_follow
			{
			  ""max_read_request_operation_count"" : 1024,
			  ""max_outstanding_read_requests"" : 16,
			  ""max_read_request_size"" : ""1024k"",
			  ""max_write_request_operation_count"" : 32768,
			  ""max_write_request_size"" : ""16k"",
			  ""max_outstanding_write_requests"" : 8,
			  ""max_write_buffer_count"" : 512,
			  ""max_write_buffer_size"" : ""512k"",
			  ""max_retry_delay"" : ""10s"",
			  ""read_poll_timeout"" : ""30s""
			}");
		}
	}
}