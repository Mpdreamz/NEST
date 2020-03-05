using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Analysis.Analyzers
{
	public class StopAnalyzerPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/analyzers/stop-analyzer.asciidoc:12")]
		public void Line12()
		{
			// tag::42d02087f1c8ab0452ef373079a76843[]
			var response0 = new SearchResponse<object>();
			// end::42d02087f1c8ab0452ef373079a76843[]

			response0.MatchesExample(@"POST _analyze
			{
			  ""analyzer"": ""stop"",
			  ""text"": ""The 2 QUICK Brown-Foxes jumped over the lazy dog's bone.""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/analyzers/stop-analyzer.asciidoc:130")]
		public void Line130()
		{
			// tag::5a676e5f09ba584408ce6ecacda13d1d[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::5a676e5f09ba584408ce6ecacda13d1d[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""my_stop_analyzer"": {
			          ""type"": ""stop"",
			          ""stopwords"": [""the"", ""over""]
			        }
			      }
			    }
			  }
			}");

			response1.MatchesExample(@"POST my_index/_analyze
			{
			  ""analyzer"": ""my_stop_analyzer"",
			  ""text"": ""The 2 QUICK Brown-Foxes jumped over the lazy dog's bone.""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/analyzers/stop-analyzer.asciidoc:246")]
		public void Line246()
		{
			// tag::42deb4fe32afbe0f94185e256a79c447[]
			var response0 = new SearchResponse<object>();
			// end::42deb4fe32afbe0f94185e256a79c447[]

			response0.MatchesExample(@"PUT /stop_example
			{
			  ""settings"": {
			    ""analysis"": {
			      ""filter"": {
			        ""english_stop"": {
			          ""type"":       ""stop"",
			          ""stopwords"":  ""_english_"" \<1>
			        }
			      },
			      ""analyzer"": {
			        ""rebuilt_stop"": {
			          ""tokenizer"": ""lowercase"",
			          ""filter"": [
			            ""english_stop""          \<2>
			          ]
			        }
			      }
			    }
			  }
			}");
		}
	}
}