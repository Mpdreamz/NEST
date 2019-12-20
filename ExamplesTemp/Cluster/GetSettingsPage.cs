using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Cluster
{
	public class GetSettingsPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line7()
		{
			// tag::4029af36cb3f8202549017f7378803b4[]
			var response0 = new SearchResponse<object>();
			// end::4029af36cb3f8202549017f7378803b4[]

			response0.MatchesExample(@"GET /_cluster/settings");
		}

		[U(Skip = "Example not implemented")]
		public void Line14()
		{
			// tag::e72a172629bd9ce8dd971c0fdf112073[]
			var response0 = new SearchResponse<object>();
			// end::e72a172629bd9ce8dd971c0fdf112073[]

			response0.MatchesExample(@"GET /_cluster/settings?include_defaults=true");
		}
	}
}