using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.RestApi.Security
{
	public class CreateRolesPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line85()
		{
			// tag::850a6d4aaf112ec1279260a2b7400a89[]
			var response0 = new SearchResponse<object>();
			// end::850a6d4aaf112ec1279260a2b7400a89[]

			response0.MatchesExample(@"POST /_security/role/my_admin_role
			{
			  ""cluster"": [""all""],
			  ""indices"": [
			    {
			      ""names"": [ ""index1"", ""index2"" ],
			      ""privileges"": [""all""],
			      ""field_security"" : { // optional
			        ""grant"" : [ ""title"", ""body"" ]
			      },
			      ""query"": ""{\""match\"": {\""title\"": \""foo\""}}"" // optional
			    }
			  ],
			  ""applications"": [
			    {
			      ""application"": ""myapp"",
			      ""privileges"": [ ""admin"", ""read"" ],
			      ""resources"": [ ""*"" ]
			    }
			  ],
			  ""run_as"": [ ""other_user"" ], // optional
			  ""metadata"" : { // optional
			    ""version"" : 1
			  }
			}");
		}
	}
}