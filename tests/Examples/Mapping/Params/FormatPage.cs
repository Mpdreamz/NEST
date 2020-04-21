using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Mapping.Params
{
	public class FormatPage : ExampleBase
	{
		[U]
		[Description("mapping/params/format.asciidoc:13")]
		public void Line13()
		{
			// tag::7f465b7e8ed42df6c42251b4481e699e[]
			var createIndexResponse = client.Indices.Create("my_index", c => c
				.Map<object>(m => m
					.Properties(p => p
						.Date(d => d
							.Name("date")
							.Format("yyyy-MM-dd")
						)
					)
				)
			);
			// end::7f465b7e8ed42df6c42251b4481e699e[]

			createIndexResponse.MatchesExample(@"PUT my_index
			{
			  ""mappings"": {
			    ""properties"": {
			      ""date"": {
			        ""type"":   ""date"",
			        ""format"": ""yyyy-MM-dd""
			      }
			    }
			  }
			}");
		}
	}
}
