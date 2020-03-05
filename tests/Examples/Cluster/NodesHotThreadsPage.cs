using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Cluster
{
	public class NodesHotThreadsPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("cluster/nodes-hot-threads.asciidoc:64")]
		public void Line64()
		{
			// tag::77c099c97ea6911e2dd6e996da7dcca0[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::77c099c97ea6911e2dd6e996da7dcca0[]

			response0.MatchesExample(@"GET /_nodes/hot_threads");

			response1.MatchesExample(@"GET /_nodes/nodeId1,nodeId2/hot_threads");
		}
	}
}