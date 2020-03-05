using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Analysis
{
	public class TestingPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("analysis/testing.asciidoc:9")]
		public void Line9()
		{
			// tag::035a7a919eb6513b4769a3727b7d6447[]
			var response0 = new SearchResponse<object>();
			// end::035a7a919eb6513b4769a3727b7d6447[]

			response0.MatchesExample(@"POST _analyze
			{
			  ""analyzer"": ""whitespace"",
			  ""text"":     ""The quick brown fox.""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/testing.asciidoc:62")]
		public void Line62()
		{
			// tag::f7ec9062b3a7578fed55f119d7c22b74[]
			var response0 = new SearchResponse<object>();
			// end::f7ec9062b3a7578fed55f119d7c22b74[]

			response0.MatchesExample(@"POST _analyze
			{
			  ""tokenizer"": ""standard"",
			  ""filter"":  [ ""lowercase"", ""asciifolding"" ],
			  ""text"":      ""Is this déja vu?""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("analysis/testing.asciidoc:125")]
		public void Line125()
		{
			// tag::acebf0b821acfbd6089f71e0359a56d3[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();

			var response2 = new SearchResponse<object>();
			// end::acebf0b821acfbd6089f71e0359a56d3[]

			response0.MatchesExample(@"PUT my_index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""analyzer"": {
			        ""std_folded"": { \<1>
			          ""type"": ""custom"",
			          ""tokenizer"": ""standard"",
			          ""filter"": [
			            ""lowercase"",
			            ""asciifolding""
			          ]
			        }
			      }
			    }
			  },
			  ""mappings"": {
			    ""properties"": {
			      ""my_text"": {
			        ""type"": ""text"",
			        ""analyzer"": ""std_folded"" \<2>
			      }
			    }
			  }
			}");

			response1.MatchesExample(@"GET my_index/_analyze \<3>
			{
			  ""analyzer"": ""std_folded"", \<4>
			  ""text"":     ""Is this déjà vu?""
			}");

			response2.MatchesExample(@"GET my_index/_analyze \<3>
			{
			  ""field"": ""my_text"", \<5>
			  ""text"":  ""Is this déjà vu?""
			}");
		}
	}
}