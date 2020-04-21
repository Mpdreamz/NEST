using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Cluster
{
	public class ReroutePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("cluster/reroute.asciidoc:185")]
		public void Line185()
		{
			// tag::c5488b3888749d3d5b9808ab28d384eb[]
			var response0 = new SearchResponse<object>();
			// end::c5488b3888749d3d5b9808ab28d384eb[]

			response0.MatchesExample(@"POST /_cluster/reroute
			{
			    ""commands"" : [
			        {
			            ""move"" : {
			                ""index"" : ""test"", ""shard"" : 0,
			                ""from_node"" : ""node1"", ""to_node"" : ""node2""
			            }
			        },
			        {
			          ""allocate_replica"" : {
			                ""index"" : ""test"", ""shard"" : 1,
			                ""node"" : ""node3""
			          }
			        }
			    ]
			}");
		}
	}
}