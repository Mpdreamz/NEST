using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ilm
{
	public class StartStopIlmPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ilm/start-stop-ilm.asciidoc:56")]
		public void Line56()
		{
			// tag::182df084f028479ecbe8d7648ddad892[]
			var response0 = new SearchResponse<object>();
			// end::182df084f028479ecbe8d7648ddad892[]

			response0.MatchesExample(@"GET _ilm/status");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/start-stop-ilm.asciidoc:88")]
		public void Line88()
		{
			// tag::585a34ad79aee16678b37da785933ac8[]
			var response0 = new SearchResponse<object>();
			// end::585a34ad79aee16678b37da785933ac8[]

			response0.MatchesExample(@"POST _ilm/stop");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/start-stop-ilm.asciidoc:141")]
		public void Line141()
		{
			// tag::72ae3851160fcf02b8e2cdfd4e57d238[]
			var response0 = new SearchResponse<object>();
			// end::72ae3851160fcf02b8e2cdfd4e57d238[]

			response0.MatchesExample(@"POST _ilm/start");
		}
	}
}