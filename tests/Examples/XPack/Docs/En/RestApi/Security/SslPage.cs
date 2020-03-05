using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.XPack.Docs.En.RestApi.Security
{
	public class SslPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("../../x-pack/docs/en/rest-api/security/ssl.asciidoc:84")]
		public void Line84()
		{
			// tag::05f6049c677a156bdf9b83e71a3b87ed[]
			var response0 = new SearchResponse<object>();
			// end::05f6049c677a156bdf9b83e71a3b87ed[]

			response0.MatchesExample(@"GET /_ssl/certificates");
		}
	}
}