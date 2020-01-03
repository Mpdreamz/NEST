using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Aggregations.Bucket
{
	public class AdjacencyMatrixAggregationPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line32()
		{
			// tag::f88cdb3a962bb6f305f4a7ccc07bc0b0[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::f88cdb3a962bb6f305f4a7ccc07bc0b0[]

			response0.MatchesExample(@"PUT /emails/_bulk?refresh
			{ ""index"" : { ""_id"" : 1 } }
			{ ""accounts"" : [""hillary"", ""sidney""]}
			{ ""index"" : { ""_id"" : 2 } }
			{ ""accounts"" : [""hillary"", ""donald""]}
			{ ""index"" : { ""_id"" : 3 } }
			{ ""accounts"" : [""vladimir"", ""donald""]}");

			response1.MatchesExample(@"GET emails/_search
			{
			  ""size"": 0,
			  ""aggs"" : {
			    ""interactions"" : {
			      ""adjacency_matrix"" : {
			        ""filters"" : {
			          ""grpA"" : { ""terms"" : { ""accounts"" : [""hillary"", ""sidney""] }},
			          ""grpB"" : { ""terms"" : { ""accounts"" : [""donald"", ""mitt""] }},
			          ""grpC"" : { ""terms"" : { ""accounts"" : [""vladimir"", ""nigel""] }}
			        }
			      }
			    }
			  }
			}");
		}
	}
}