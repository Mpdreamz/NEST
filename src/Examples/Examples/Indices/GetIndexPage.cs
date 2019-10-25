using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Indices
{
	public class GetIndexPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line10()
		{
			// tag::be8f28f31207b173de61be032fcf239c[]
			var response0 = new SearchResponse<object>();
			// end::be8f28f31207b173de61be032fcf239c[]

			response0.MatchesExample(@"GET /twitter");
		}
	}
}