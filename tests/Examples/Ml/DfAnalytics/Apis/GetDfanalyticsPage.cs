using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ml.DfAnalytics.Apis
{
	public class GetDfanalyticsPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ml/df-analytics/apis/get-dfanalytics.asciidoc:183")]
		public void Line183()
		{
			// tag::5ccfd9f4698dcd7cdfbc6bad60081aab[]
			var response0 = new SearchResponse<object>();
			// end::5ccfd9f4698dcd7cdfbc6bad60081aab[]

			response0.MatchesExample(@"GET _ml/data_frame/analytics/loganalytics");
		}
	}
}