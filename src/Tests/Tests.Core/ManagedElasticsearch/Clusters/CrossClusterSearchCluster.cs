using Tests.Core.ManagedElasticsearch.NodeSeeders;

namespace Tests.Core.ManagedElasticsearch.Clusters
{
	public class CrossClusterSearchCluster : ClientTestClusterBase
	{
		protected override void SeedCluster()
		{
			new DefaultSeeder(Client).SeedNode();

			// persist settings for cross cluster search, when cluster_two is not available
			Client.ClusterPutSettings(s => s
				.Persistent(d => d
					.Add("cluster.remote.cluster_two.seeds", new [] { "127.0.0.1:9399" })
					.Add("cluster.remote.cluster_two.skip_unavailable", true)
				)
			);
		}
	}
}
