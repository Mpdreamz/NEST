// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Search.Request
{
	public class CollapsePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("search/request/collapse.asciidoc:9")]
		public void Line9()
		{
			// tag::032f67ced3e7d106f8722432ebbd94d3[]
			var response0 = new SearchResponse<object>();
			// end::032f67ced3e7d106f8722432ebbd94d3[]

			response0.MatchesExample(@"GET /twitter/_search
			{
			    ""query"": {
			        ""match"": {
			            ""message"": ""elasticsearch""
			        }
			    },
			    ""collapse"" : {
			        ""field"" : ""user"" \<1>
			    },
			    ""sort"": [""likes""], \<2>
			    ""from"": 10 \<3>
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("search/request/collapse.asciidoc:43")]
		public void Line43()
		{
			// tag::63d36a10d9475be2e2fa73d2415e20e6[]
			var response0 = new SearchResponse<object>();
			// end::63d36a10d9475be2e2fa73d2415e20e6[]

			response0.MatchesExample(@"GET /twitter/_search
			{
			    ""query"": {
			        ""match"": {
			            ""message"": ""elasticsearch""
			        }
			    },
			    ""collapse"" : {
			        ""field"" : ""user"", \<1>
			        ""inner_hits"": {
			            ""name"": ""last_tweets"", \<2>
			            ""size"": 5, \<3>
			            ""sort"": [{ ""date"": ""asc"" }] \<4>
			        },
			        ""max_concurrent_group_searches"": 4 \<5>
			    },
			    ""sort"": [""likes""]
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("search/request/collapse.asciidoc:77")]
		public void Line77()
		{
			// tag::4f20ca49fbaac83620d4cb23fd355f3b[]
			var response0 = new SearchResponse<object>();
			// end::4f20ca49fbaac83620d4cb23fd355f3b[]

			response0.MatchesExample(@"GET /twitter/_search
			{
			    ""query"": {
			        ""match"": {
			            ""message"": ""elasticsearch""
			        }
			    },
			    ""collapse"" : {
			        ""field"" : ""user"", \<1>
			        ""inner_hits"": [
			            {
			                ""name"": ""most_liked"",  \<2>
			                ""size"": 3,
			                ""sort"": [""likes""]
			            },
			            {
			                ""name"": ""most_recent"", \<3>
			                ""size"": 3,
			                ""sort"": [{ ""date"": ""asc"" }]
			            }
			        ]
			    },
			    ""sort"": [""likes""]
			}");
		}
	}
}
