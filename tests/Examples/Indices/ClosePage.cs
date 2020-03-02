using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Indices
{
	public class ClosePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line10()
		{
			// tag::34107944bca50a003cda9fca934b2011[]
			var response0 = new SearchResponse<object>();
			// end::34107944bca50a003cda9fca934b2011[]

			response0.MatchesExample(@"POST /twitter/_close");
		}

		[U(Skip = "Example not implemented")]
		public void Line66()
		{
			// tag::3a6b9143f3de6258d44ff7e0eb38d953[]
			var response0 = new SearchResponse<object>();
			// end::3a6b9143f3de6258d44ff7e0eb38d953[]

			response0.MatchesExample(@"POST /my_index/_close");
		}
	}
}