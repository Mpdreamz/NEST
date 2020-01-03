using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Mapping.Params
{
	public class EagerGlobalOrdinalsPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line53()
		{
			// tag::f7682345a4e36a4c6e553902039a9410[]
			var response0 = new SearchResponse<object>();
			// end::f7682345a4e36a4c6e553902039a9410[]

			response0.MatchesExample(@"PUT my_index/_mapping
			{
			  ""properties"": {
			    ""tags"": {
			      ""type"": ""keyword"",
			      ""eager_global_ordinals"": true
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line76()
		{
			// tag::9c9221059c06dd26041a95b93ec9b6df[]
			var response0 = new SearchResponse<object>();
			// end::9c9221059c06dd26041a95b93ec9b6df[]

			response0.MatchesExample(@"PUT my_index/_mapping
			{
			  ""properties"": {
			    ""tags"": {
			      ""type"": ""keyword"",
			      ""eager_global_ordinals"": false
			    }
			  }
			}");
		}
	}
}