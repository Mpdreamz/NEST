using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Indices.Apis
{
	public class ReloadAnalyzersPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line14()
		{
			// tag::b0015e63323171f38995b8e4aa2b52d5[]
			var response0 = new SearchResponse<object>();
			// end::b0015e63323171f38995b8e4aa2b52d5[]

			response0.MatchesExample(@"POST /twitter/_reload_search_analyzers");
		}

		[U(Skip = "Example not implemented")]
		public void Line98()
		{
			// tag::db8cbfa2afece5d21b3ca69ffee8f5c0[]
			var response0 = new SearchResponse<object>();
			// end::db8cbfa2afece5d21b3ca69ffee8f5c0[]

			response0.MatchesExample(@"PUT /my_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""analyzer"" : {
			                    ""my_synonyms"" : {
			                        ""tokenizer"" : ""whitespace"",
			                        ""filter"" : [""synonym""]
			                    }
			                },
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym_graph"",
			                        ""synonyms_path"" : ""analysis/synonym.txt"", <1>
			                        ""updateable"" : true <2>
			                    }
			                }
			            }
			        }
			    },
			    ""mappings"": {
			        ""properties"": {
			            ""text"": {
			                ""type"": ""text"",
			                ""analyzer"" : ""standard"",
			                ""search_analyzer"": ""my_synonyms"" <3>
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line142()
		{
			// tag::7554da505cc27f6bd0d028b66e85f4a5[]
			var response0 = new SearchResponse<object>();
			// end::7554da505cc27f6bd0d028b66e85f4a5[]

			response0.MatchesExample(@"POST /my_index/_reload_search_analyzers");
		}
	}
}