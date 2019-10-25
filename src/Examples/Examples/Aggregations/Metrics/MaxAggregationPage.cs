using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Aggregations.Metrics
{
	public class MaxAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line16()
		{
			// tag::9498a707be49e14dad801db6b6824e34[]
			var response0 = new SearchResponse<object>();
			// end::9498a707be49e14dad801db6b6824e34[]

			response0.MatchesExample(@"POST /sales/_search?size=0
			{
			    ""aggs"" : {
			        ""max_price"" : { ""max"" : { ""field"" : ""price"" } }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line51()
		{
			// tag::736fc5448b66962ceef1e6d5948ef691[]
			var response0 = new SearchResponse<object>();
			// end::736fc5448b66962ceef1e6d5948ef691[]

			response0.MatchesExample(@"POST /sales/_search
			{
			    ""aggs"" : {
			        ""max_price"" : {
			            ""max"" : {
			                ""script"" : {
			                    ""source"" : ""doc.price.value""
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line71()
		{
			// tag::b5e782e309a2a10db272414e8483d8dc[]
			var response0 = new SearchResponse<object>();
			// end::b5e782e309a2a10db272414e8483d8dc[]

			response0.MatchesExample(@"POST /sales/_search
			{
			    ""aggs"" : {
			        ""max_price"" : {
			            ""max"" : {
			                ""script"" : {
			                    ""id"": ""my_script"",
			                    ""params"": {
			                        ""field"": ""price""
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line98()
		{
			// tag::23fdba37454d6d7abf6bfbb4fd01692f[]
			var response0 = new SearchResponse<object>();
			// end::23fdba37454d6d7abf6bfbb4fd01692f[]

			response0.MatchesExample(@"POST /sales/_search
			{
			    ""aggs"" : {
			        ""max_price_in_euros"" : {
			            ""max"" : {
			                ""field"" : ""price"",
			                ""script"" : {
			                    ""source"" : ""_value * params.conversion_rate"",
			                    ""params"" : {
			                        ""conversion_rate"" : 1.2
			                    }
			                }
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line125()
		{
			// tag::41518c094db4a5b03cca3b21497f79cf[]
			var response0 = new SearchResponse<object>();
			// end::41518c094db4a5b03cca3b21497f79cf[]

			response0.MatchesExample(@"POST /sales/_search
			{
			    ""aggs"" : {
			        ""grade_max"" : {
			            ""max"" : {
			                ""field"" : ""grade"",
			                ""missing"": 10 \<1>
			            }
			        }
			    }
			}");
		}
	}
}