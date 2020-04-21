using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Analysis.Tokenfilters
{
	public class KeywordRepeatTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/keyword-repeat-tokenfilter.asciidoc:49")]
		public void Line49()
		{
			// tag::a037beb3d02296e1d36dd43ef5c935dd[]
			var response0 = new SearchResponse<object>();
			// end::a037beb3d02296e1d36dd43ef5c935dd[]

			response0.MatchesExample(@"GET /_analyze
			{
			  ""tokenizer"": ""whitespace"",
			  ""filter"": [
			    ""keyword_repeat""
			  ],
			  ""text"": ""fox running and jumping"",
			  ""explain"": true,
			  ""attributes"": ""keyword""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/keyword-repeat-tokenfilter.asciidoc:156")]
		public void Line156()
		{
			// tag::8cbf9b46ce3ccc966c4902d2e0c56317[]
			var response0 = new SearchResponse<object>();
			// end::8cbf9b46ce3ccc966c4902d2e0c56317[]

			response0.MatchesExample(@"GET /_analyze
			{
			  ""tokenizer"": ""whitespace"",
			  ""filter"": [
			    ""keyword_repeat"",
			    ""stemmer""
			  ],
			  ""text"": ""fox running and jumping"",
			  ""explain"": true,
			  ""attributes"": ""keyword""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/keyword-repeat-tokenfilter.asciidoc:274")]
		public void Line274()
		{
			// tag::29783e5de3a5f3c985cbf11094cf49a0[]
			var response0 = new SearchResponse<object>();
			// end::29783e5de3a5f3c985cbf11094cf49a0[]

			response0.MatchesExample(@"GET /_analyze
			{
			  ""tokenizer"": ""whitespace"",
			  ""filter"": [
			    ""keyword_repeat"",
			    ""stemmer"",
			    ""remove_duplicates""
			  ],
			  ""text"": ""fox running and jumping"",
			  ""explain"": true,
			  ""attributes"": ""keyword""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/keyword-repeat-tokenfilter.asciidoc:384")]
		public void Line384()
		{
			// tag::4710188da1085a6be9a1e0bdd66c4f26[]
			var response0 = new SearchResponse<object>();
			// end::4710188da1085a6be9a1e0bdd66c4f26[]

			response0.MatchesExample(@"PUT /my_index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""my_custom_analyzer"": {
			          ""tokenizer"": ""standard"",
			          ""filter"": [
			            ""keyword_repeat"",
			            ""porter_stem"",
			            ""remove_duplicates""
			          ]
			        }
			      }
			    }
			  }
			}");
		}
	}
}