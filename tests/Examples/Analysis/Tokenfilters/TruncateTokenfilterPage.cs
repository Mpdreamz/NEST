using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class TruncateTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line24()
		{
			// tag::ee2d97090d617ed8aa2a87ea33556dd7[]
			var response0 = new SearchResponse<object>();
			// end::ee2d97090d617ed8aa2a87ea33556dd7[]

			response0.MatchesExample(@"GET _analyze
			{
			  ""tokenizer"" : ""whitespace"",
			  ""filter"" : [""truncate""],
			  ""text"" : ""the quinquennial extravaganza carried on""
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line93()
		{
			// tag::f8651356ce2e7e93fa306c30f57ed588[]
			var response0 = new SearchResponse<object>();
			// end::f8651356ce2e7e93fa306c30f57ed588[]

			response0.MatchesExample(@"PUT custom_truncate_example
			{
			  ""settings"" : {
			    ""analysis"" : {
			      ""analyzer"" : {
			        ""standard_truncate"" : {
			        ""tokenizer"" : ""standard"",
			        ""filter"" : [""truncate""]
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line128()
		{
			// tag::af84b3995564a7ca84360a526a4ac896[]
			var response0 = new SearchResponse<object>();
			// end::af84b3995564a7ca84360a526a4ac896[]

			response0.MatchesExample(@"PUT 5_char_words_example
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""lowercase_5_char"": {
			          ""tokenizer"": ""lowercase"",
			          ""filter"": [ ""5_char_trunc"" ]
			        }
			      },
			      ""filter"": {
			        ""5_char_trunc"": {
			          ""type"": ""truncate"",
			          ""length"": 5
			        }
			      }
			    }
			  }
			}");
		}
	}
}