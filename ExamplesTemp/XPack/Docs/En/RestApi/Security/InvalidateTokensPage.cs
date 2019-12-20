using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.RestApi.Security
{
	public class InvalidateTokensPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line72()
		{
			// tag::cee591c1fc70d4f180c623a3a6d07755[]
			var response0 = new SearchResponse<object>();
			// end::cee591c1fc70d4f180c623a3a6d07755[]

			response0.MatchesExample(@"POST /_security/oauth2/token
			{
			  ""grant_type"" : ""client_credentials""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line95()
		{
			// tag::dbf9abc37899352751dab0ede62af2fd[]
			var response0 = new SearchResponse<object>();
			// end::dbf9abc37899352751dab0ede62af2fd[]

			response0.MatchesExample(@"DELETE /_security/oauth2/token
			{
			  ""token"" : ""dGhpcyBpcyBub3QgYSByZWFsIHRva2VuIGJ1dCBpdCBpcyBvbmx5IHRlc3QgZGF0YS4gZG8gbm90IHRyeSB0byByZWFkIHRva2VuIQ==""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line108()
		{
			// tag::e1337c6b76defd5a46d05220f9d9c9fc[]
			var response0 = new SearchResponse<object>();
			// end::e1337c6b76defd5a46d05220f9d9c9fc[]

			response0.MatchesExample(@"POST /_security/oauth2/token
			{
			  ""grant_type"" : ""password"",
			  ""username"" : ""test_admin"",
			  ""password"" : ""x-pack-test-password""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line135()
		{
			// tag::0c6f9c9da75293fae69659ac1d6329de[]
			var response0 = new SearchResponse<object>();
			// end::0c6f9c9da75293fae69659ac1d6329de[]

			response0.MatchesExample(@"DELETE /_security/oauth2/token
			{
			  ""refresh_token"" : ""vLBPvmAB6KvwvJZr27cS""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line148()
		{
			// tag::4bc4db44b8c74610b73f21a421099a13[]
			var response0 = new SearchResponse<object>();
			// end::4bc4db44b8c74610b73f21a421099a13[]

			response0.MatchesExample(@"DELETE /_security/oauth2/token
			{
			  ""realm_name"" : ""saml1""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line159()
		{
			// tag::0280247e0cf2e561c548f22c9fb31163[]
			var response0 = new SearchResponse<object>();
			// end::0280247e0cf2e561c548f22c9fb31163[]

			response0.MatchesExample(@"DELETE /_security/oauth2/token
			{
			  ""username"" : ""myuser""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line170()
		{
			// tag::6dd2a107bc64fd6f058fb17c21640649[]
			var response0 = new SearchResponse<object>();
			// end::6dd2a107bc64fd6f058fb17c21640649[]

			response0.MatchesExample(@"DELETE /_security/oauth2/token
			{
			  ""username"" : ""myuser"",
			  ""realm_name"" : ""saml1""
			}");
		}
	}
}