using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using System.ComponentModel;
using Nest;

namespace Examples.Ilm.Actions
{
	public class IlmReadonlyPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ilm/actions/ilm-readonly.asciidoc:18")]
		public void Line18()
		{
			// tag::fc9a1b1173690a911725cff3912e9755[]
			var response0 = new SearchResponse<object>();
			// end::fc9a1b1173690a911725cff3912e9755[]

			response0.MatchesExample(@"PUT _ilm/policy/my_policy
			{
			  ""policy"": {
			    ""phases"": {
			      ""warm"": {
			        ""actions"": {
			          ""readonly"" : { }
			        }
			      }
			    }
			  }
			}");
		}
	}
}