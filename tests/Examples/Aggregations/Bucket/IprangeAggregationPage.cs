using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Aggregations.Bucket
{
	public class IprangeAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("aggregations/bucket/iprange-aggregation.asciidoc:9")]
		public void Line9()
		{
			// tag::01cc705f6074ab637cfbb9f92cf44e44[]
			var response0 = new SearchResponse<object>();
			// end::01cc705f6074ab637cfbb9f92cf44e44[]

			response0.MatchesExample(@"GET /ip_addresses/_search
			{
			    ""size"": 10,
			    ""aggs"" : {
			        ""ip_ranges"" : {
			            ""ip_range"" : {
			                ""field"" : ""ip"",
			                ""ranges"" : [
			                    { ""to"" : ""10.0.0.5"" },
			                    { ""from"" : ""10.0.0.5"" }
			                ]
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("aggregations/bucket/iprange-aggregation.asciidoc:58")]
		public void Line58()
		{
			// tag::9f4ba6565d80e0964e177eaac9fb0614[]
			var response0 = new SearchResponse<object>();
			// end::9f4ba6565d80e0964e177eaac9fb0614[]

			response0.MatchesExample(@"GET /ip_addresses/_search
			{
			    ""size"": 0,
			    ""aggs"" : {
			        ""ip_ranges"" : {
			            ""ip_range"" : {
			                ""field"" : ""ip"",
			                ""ranges"" : [
			                    { ""mask"" : ""10.0.0.0/25"" },
			                    { ""mask"" : ""10.0.0.127/25"" }
			                ]
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("aggregations/bucket/iprange-aggregation.asciidoc:111")]
		public void Line111()
		{
			// tag::c4db73a276175d57c6a9a0387e728028[]
			var response0 = new SearchResponse<object>();
			// end::c4db73a276175d57c6a9a0387e728028[]

			response0.MatchesExample(@"GET /ip_addresses/_search
			{
			    ""size"": 0,
			    ""aggs"": {
			        ""ip_ranges"": {
			            ""ip_range"": {
			                ""field"": ""ip"",
			                ""ranges"": [
			                    { ""to"" : ""10.0.0.5"" },
			                    { ""from"" : ""10.0.0.5"" }
			                ],
			                ""keyed"": true
			            }
			        }
			    }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("aggregations/bucket/iprange-aggregation.asciidoc:159")]
		public void Line159()
		{
			// tag::fa8ee2094af36e7ec02233a4c7b008bc[]
			var response0 = new SearchResponse<object>();
			// end::fa8ee2094af36e7ec02233a4c7b008bc[]

			response0.MatchesExample(@"GET /ip_addresses/_search
			{
			    ""size"": 0,
			    ""aggs"": {
			        ""ip_ranges"": {
			            ""ip_range"": {
			                ""field"": ""ip"",
			                ""ranges"": [
			                    { ""key"": ""infinity"", ""to"" : ""10.0.0.5"" },
			                    { ""key"": ""and-beyond"", ""from"" : ""10.0.0.5"" }
			                ],
			                ""keyed"": true
			            }
			        }
			    }
			}");
		}
	}
}