using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Analysis.Analyzers
{
	public class CustomAnalyzerPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/analyzers/custom-analyzer.asciidoc:55")]
		public void Line55()
		{
			// tag::81db5fb0ea5b942204f4ba27b7ae836a[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::81db5fb0ea5b942204f4ba27b7ae836a[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""my_custom_analyzer"": {
			          ""type"": ""custom"", <1>
			          ""tokenizer"": ""standard"",
			          ""char_filter"": [
			            ""html_strip""
			          ],
			          ""filter"": [
			            ""lowercase"",
			            ""asciifolding""
			          ]
			        }
			      }
			    }
			  }
			}");

			response1.MatchesExample(@"POST my_index/_analyze
			{
			  ""analyzer"": ""my_custom_analyzer"",
			  ""text"": ""Is this <b>déjà vu</b>?""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/analyzers/custom-analyzer.asciidoc:157")]
		public void Line157()
		{
			// tag::8fb13998654631659f998e35922bcde6[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::8fb13998654631659f998e35922bcde6[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""my_custom_analyzer"": { <1>
			          ""type"": ""custom"",
			          ""char_filter"": [
			            ""emoticons""
			          ],
			          ""tokenizer"": ""punctuation"",
			          ""filter"": [
			            ""lowercase"",
			            ""english_stop""
			          ]
			        }
			      },
			      ""tokenizer"": {
			        ""punctuation"": { <2>
			          ""type"": ""pattern"",
			          ""pattern"": ""[ .,!?]""
			        }
			      },
			      ""char_filter"": {
			        ""emoticons"": { <3>
			          ""type"": ""mapping"",
			          ""mappings"": [
			            "":) => _happy_"",
			            "":( => _sad_""
			          ]
			        }
			      },
			      ""filter"": {
			        ""english_stop"": { <4>
			          ""type"": ""stop"",
			          ""stopwords"": ""_english_""
			        }
			      }
			    }
			  }
			}");

			response1.MatchesExample(@"POST my_index/_analyze
			{
			  ""analyzer"": ""my_custom_analyzer"",
			  ""text"": ""I'm a :) person, and you?""
			}");
		}
	}
}