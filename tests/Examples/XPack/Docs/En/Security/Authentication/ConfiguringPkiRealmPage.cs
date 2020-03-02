using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.Security.Authentication
{
	public class ConfiguringPkiRealmPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line158()
		{
			// tag::70bbe14bc4d5a5d58e81ab2b02408817[]
			var response0 = new SearchResponse<object>();
			// end::70bbe14bc4d5a5d58e81ab2b02408817[]

			response0.MatchesExample(@"PUT /_security/role_mapping/users
			{
			  ""roles"" : [ ""user"" ],
			  ""rules"" : { ""field"" : {
			    ""dn"" : ""cn=John Doe,ou=example,o=com"" \<1>
			  } },
			  ""enabled"": true
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line251()
		{
			// tag::1f8a6d2cc57ed8997a52354aca371aac[]
			var response0 = new SearchResponse<object>();
			// end::1f8a6d2cc57ed8997a52354aca371aac[]

			response0.MatchesExample(@"PUT /_security/role_mapping/direct_pki_only
			{
			  ""roles"" : [ ""role_for_pki1_direct"" ],
			  ""rules"" : {
			    ""all"": [
			      {
			        ""field"": {""realm.name"": ""pki1""}
			      },
			      {
			        ""field"": {
			          ""metadata.pki_delegated_by_user"": null <1>
			        }
			      }
			    ]
			  },
			  ""enabled"": true
			}");
		}
	}
}