using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Indices.Apis
{
	public class FreezePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line43()
		{
			// tag::ffea06f77c9df5720412aa06be964118[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::ffea06f77c9df5720412aa06be964118[]

			response0.MatchesExample(@"POST /my_index/_freeze");

			response1.MatchesExample(@"POST /my_index/_unfreeze");
		}
	}
}