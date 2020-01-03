using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Mapping.Types
{
	public class ArrayPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line42()
		{
			// tag::4d6997c70a1851f9151443c0d38b532e[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();

			var response2 = new SearchResponse<object>();
			// end::4d6997c70a1851f9151443c0d38b532e[]

			response0.MatchesExample(@"PUT my_index/_doc/1
			{
			  ""message"": ""some arrays in this document..."",
			  ""tags"":  [ ""elasticsearch"", ""wow"" ], \<1>
			  ""lists"": [ \<2>
			    {
			      ""name"": ""prog_list"",
			      ""description"": ""programming list""
			    },
			    {
			      ""name"": ""cool_list"",
			      ""description"": ""cool stuff list""
			    }
			  ]
			}");

			response1.MatchesExample(@"PUT my_index/_doc/2 \<3>
			{
			  ""message"": ""no arrays in this document..."",
			  ""tags"":  ""elasticsearch"",
			  ""lists"": {
			    ""name"": ""prog_list"",
			    ""description"": ""programming list""
			  }
			}");

			response2.MatchesExample(@"GET my_index/_search
			{
			  ""query"": {
			    ""match"": {
			      ""tags"": ""elasticsearch"" \<4>
			    }
			  }
			}");
		}
	}
}