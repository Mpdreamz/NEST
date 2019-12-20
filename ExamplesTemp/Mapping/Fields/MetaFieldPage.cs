using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Mapping.Fields
{
	public class MetaFieldPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line9()
		{
			// tag::e10d7f411744eb1d5ddaa2f70a368490[]
			var response0 = new SearchResponse<object>();
			// end::e10d7f411744eb1d5ddaa2f70a368490[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""mappings"": {
			    ""_meta"": { \<1>
			      ""class"": ""MyApp::User"",
			      ""version"": {
			        ""min"": ""1.0"",
			        ""max"": ""1.3""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line31()
		{
			// tag::019eab381444c3d77ad3bb4e39edfac6[]
			var response0 = new SearchResponse<object>();
			// end::019eab381444c3d77ad3bb4e39edfac6[]

			response0.MatchesExample(@"PUT my_index/_mapping
			{
			  ""_meta"": {
			    ""class"": ""MyApp2::User3"",
			    ""version"": {
			      ""min"": ""1.3"",
			      ""max"": ""1.5""
			    }
			  }
			}");
		}
	}
}