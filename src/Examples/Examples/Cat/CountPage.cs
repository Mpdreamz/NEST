using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Cat
{
	public class CountPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line52()
		{
			// tag::e7553d4bb4fd82d8f80a4d7af2624afb[]
			var response0 = new SearchResponse<object>();
			// end::e7553d4bb4fd82d8f80a4d7af2624afb[]

			response0.MatchesExample(@"GET /_cat/count/twitter?v");
		}

		[U(Skip = "Example not implemented")]
		public void Line74()
		{
			// tag::0a1f8ad54b1d8c9feeaceaeed16c8490[]
			var response0 = new SearchResponse<object>();
			// end::0a1f8ad54b1d8c9feeaceaeed16c8490[]

			response0.MatchesExample(@"GET /_cat/count?v");
		}
	}
}