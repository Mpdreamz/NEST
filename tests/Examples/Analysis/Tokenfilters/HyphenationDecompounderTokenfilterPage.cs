using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class HyphenationDecompounderTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line25()
		{
			// tag::f34c02351662481dd61a5c2a3e206c60[]
			var response0 = new SearchResponse<object>();
			// end::f34c02351662481dd61a5c2a3e206c60[]

			response0.MatchesExample(@"GET _analyze
			{
			  ""tokenizer"": ""standard"",
			  ""filter"": [
			    {
			      ""type"": ""hyphenation_decompounder"",
			      ""hyphenation_patterns_path"": ""analysis/hyphenation_patterns.xml"",
			      ""word_list"": [""Kaffee"", ""zucker"", ""tasse""]
			    }
			  ],
			  ""text"": ""Kaffeetasse""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line132()
		{
			// tag::5f8acd1e367b048b5542dbc6079bcc88[]
			var response0 = new SearchResponse<object>();
			// end::5f8acd1e367b048b5542dbc6079bcc88[]

			response0.MatchesExample(@"PUT hyphenation_decompound_example
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""standard_hyphenation_decompound"": {
			          ""tokenizer"": ""standard"",
			          ""filter"": [ ""22_char_hyphenation_decompound"" ]
			        }
			      },
			      ""filter"": {
			        ""22_char_hyphenation_decompound"": {
			          ""type"": ""hyphenation_decompounder"",
			          ""word_list_path"": ""analysis/example_word_list.txt"",
			          ""hyphenation_patterns_path"": ""analysis/hyphenation_patterns.xml"",
			          ""max_subword_size"": 22
			        }
			      }
			    }
			  }
			}");
		}
	}
}