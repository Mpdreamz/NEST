// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;

namespace Elasticsearch.Net.VirtualizedCluster
{
	public static class VirtualClusterWith
	{
		public static VirtualCluster Nodes(int numberOfNodes, int startFrom = 9200, bool productCheckAlwaysSucceeds = true) =>
			new (Enumerable.Range(startFrom, numberOfNodes).Select(n => new Node(new Uri($"http://localhost:{n}"))), productCheckAlwaysSucceeds);

		public static VirtualCluster MasterOnlyNodes(int numberOfNodes, int startFrom = 9200, bool productCheckSucceeds = true) =>
			new (Enumerable.Range(startFrom, numberOfNodes).Select(n => new Node(new Uri($"http://localhost:{n}")) { HoldsData = false, MasterEligible = true }), productCheckSucceeds);

		public static VirtualCluster Nodes(IEnumerable<Node> nodes, bool productCheckSucceeds = true) => new (nodes, productCheckSucceeds);
	}
}
