using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.RestApi.Security
{
	public class OidcAuthenticateApiPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line65()
		{
			// tag::9e5d5a6c9adcba75b906e81c1496bd01[]
			var response0 = new SearchResponse<object>();
			// end::9e5d5a6c9adcba75b906e81c1496bd01[]

			response0.MatchesExample(@"POST /_security/oidc/authenticate
			{
			  ""redirect_uri"" : ""https://oidc-kibana.elastic.co:5603/api/security/v1/oidc?code=jtI3Ntt8v3_XvcLzCFGq&state=4dbrihtIAt3wBTwo6DxK-vdk-sSyDBV8Yf0AjdkdT5I"",
			  ""state"" : ""4dbrihtIAt3wBTwo6DxK-vdk-sSyDBV8Yf0AjdkdT5I"",
			  ""nonce"" : ""WaBPH0KqPVdG5HHdSxPRjfoZbXMCicm5v1OiAj0DUFM"",
			  ""realm"" : ""oidc1""
			}");
		}
	}
}