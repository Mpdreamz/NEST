using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Analysis.Tokenfilters
{
	public class SynonymTokenfilterPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line9()
		{
			// tag::09f74df1d07d84ee133ce90f7832e712[]
			var response0 = new SearchResponse<object>();
			// end::09f74df1d07d84ee133ce90f7832e712[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""analyzer"" : {
			                    ""synonym"" : {
			                        ""tokenizer"" : ""whitespace"",
			                        ""filter"" : [""synonym""]
			                    }
			                },
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym"",
			                        ""synonyms_path"" : ""analysis/synonym.txt""
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line48()
		{
			// tag::bcc57126b24c408b5d944928b6f08c94[]
			var response0 = new SearchResponse<object>();
			// end::bcc57126b24c408b5d944928b6f08c94[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""analyzer"" : {
			                    ""synonym"" : {
			                        ""tokenizer"" : ""standard"",
			                        ""filter"" : [""my_stop"", ""synonym""]
			                    }
			                },
			                ""filter"" : {
			                    ""my_stop"": {
			                        ""type"" : ""stop"",
			                        ""stopwords"": [""bar""]
			                    },
			                    ""synonym"" : {
			                        ""type"" : ""synonym"",
			                        ""lenient"": true,
			                        ""synonyms"" : [""foo, bar => baz""]
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line109()
		{
			// tag::9fb5e28535f396ab2eb8bc710eebc1e6[]
			var response0 = new SearchResponse<object>();
			// end::9fb5e28535f396ab2eb8bc710eebc1e6[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym"",
			                        ""synonyms"" : [
			                            ""i-pod, i pod => ipod"",
			                            ""universe, cosmos""
			                        ]
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line140()
		{
			// tag::0c0f37e409459dcd40d29ea684db4706[]
			var response0 = new SearchResponse<object>();
			// end::0c0f37e409459dcd40d29ea684db4706[]

			response0.MatchesExample(@"PUT /test_index
			{
			    ""settings"": {
			        ""index"" : {
			            ""analysis"" : {
			                ""filter"" : {
			                    ""synonym"" : {
			                        ""type"" : ""synonym"",
			                        ""format"" : ""wordnet"",
			                        ""synonyms"" : [
			                            ""s(100000001,1,'abstain',v,1,0)."",
			                            ""s(100000001,2,'refrain',v,1,0)."",
			                            ""s(100000001,3,'desist',v,1,0).""
			                        ]
			                    }
			                }
			            }
			        }
			    }
			}");
		}
	}
}