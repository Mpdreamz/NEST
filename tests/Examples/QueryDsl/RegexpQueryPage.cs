using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.QueryDsl
{
	public class RegexpQueryPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("query-dsl/regexp-query.asciidoc:23")]
		public void Line23()
		{
			// tag::618d5f3d35921d8cb7e9ccfbe9a4c3e3[]
			var response0 = new SearchResponse<object>();
			// end::618d5f3d35921d8cb7e9ccfbe9a4c3e3[]

			response0.MatchesExample(@"GET /_search
			{
			    ""query"": {
			        ""regexp"": {
			            ""user"": {
			                ""value"": ""k.*y"",
			                ""flags"" : ""ALL"",
			                ""max_determinized_states"": 10000,
			                ""rewrite"": ""constant_score""
			            }
			        }
			    }
			}");
		}
	}
}