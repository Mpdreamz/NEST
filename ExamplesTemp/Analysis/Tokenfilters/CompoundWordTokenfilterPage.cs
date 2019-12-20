using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class CompoundWordTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line86()
		{
			// tag::349e77cfe54f857ccfdde0e47c2d7cd5[]
			var response0 = new SearchResponse<object>();
			// end::349e77cfe54f857ccfdde0e47c2d7cd5[]

			response0.MatchesExample(@"PUT /compound_word_example
			{
			    ""settings"": {
			        ""index"": {
			            ""analysis"": {
			                ""analyzer"": {
			                    ""my_analyzer"": {
			                        ""type"": ""custom"",
			                        ""tokenizer"": ""standard"",
			                        ""filter"": [""dictionary_decompounder"", ""hyphenation_decompounder""]
			                    }
			                },
			                ""filter"": {
			                    ""dictionary_decompounder"": {
			                        ""type"": ""dictionary_decompounder"",
			                        ""word_list"": [""one"", ""two"", ""three""]
			                    },
			                    ""hyphenation_decompounder"": {
			                        ""type"" : ""hyphenation_decompounder"",
			                        ""word_list_path"": ""analysis/example_word_list.txt"",
			                        ""hyphenation_patterns_path"": ""analysis/hyphenation_patterns.xml"",
			                        ""max_subword_size"": 22
			                    }
			                }
			            }
			        }
			    }
			}");
		}
	}
}