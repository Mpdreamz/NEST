using Elastic.Xunit.XunitPlumbing;
using System.ComponentModel;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class NgramTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/ngram-tokenfilter.asciidoc:30")]
		public void Line30()
		{
			// tag::f65abb38dd0cfedeb06e0cef206fbdab[]
			var response0 = new SearchResponse<object>();
			// end::f65abb38dd0cfedeb06e0cef206fbdab[]

			response0.MatchesExample(@"GET _analyze
			{
			  ""tokenizer"": ""standard"",
			  ""filter"": [ ""ngram"" ],
			  ""text"": ""Quick fox""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/ngram-tokenfilter.asciidoc:161")]
		public void Line161()
		{
			// tag::923aee95078219ee6eb321a252e1121b[]
			var response0 = new SearchResponse<object>();
			// end::923aee95078219ee6eb321a252e1121b[]

			response0.MatchesExample(@"PUT ngram_example
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""standard_ngram"": {
			          ""tokenizer"": ""standard"",
			          ""filter"": [ ""ngram"" ]
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/tokenfilters/ngram-tokenfilter.asciidoc:204")]
		public void Line204()
		{
			// tag::2793fa53b7d269852aa74f6bf57e34dc[]
			var response0 = new SearchResponse<object>();
			// end::2793fa53b7d269852aa74f6bf57e34dc[]

			response0.MatchesExample(@"PUT ngram_custom_example
			{
			  ""settings"": {
			    ""index"": {
			      ""max_ngram_diff"": 2
			    },
			    ""analysis"": {
			      ""analyzer"": {
			        ""default"": {
			          ""tokenizer"": ""whitespace"",
			          ""filter"": [ ""3_5_grams"" ]
			        }
			      },
			      ""filter"": {
			        ""3_5_grams"": {
			          ""type"": ""ngram"",
			          ""min_gram"": 3,
			          ""max_gram"": 5
			        }
			      }
			    }
			  }
			}");
		}
	}
}