// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Transport;
using FluentAssertions;
using Tests.Framework;
using static Elasticsearch.Net.VirtualizedCluster.Rules.TimesHelper;
using static Elastic.Transport.AuditEvent;

namespace Tests.ClientConcepts.ConnectionPooling.Sticky
{
	public class Sticky
	{
		/** Sticky Connection Pool
		 * Each connection pool returns the first `live` node so that it is sticky between requests
		*/
		[U]
		public void EachViewStartsAtNextPositionAndWrapsOver()
		{
			var numberOfNodes = 10;
			var uris = Enumerable.Range(9200, numberOfNodes).Select(p => new Uri("http://localhost:" + p));
			var pool = new StickyConnectionPool(uris);

			/**
			* Here we have setup a sticky connection pool seeded with 10 nodes.
			* So what order we expect? Imagine the following:
			*
			* Thread A calls `.CreateView()` and gets returned the first live node
			* Thread B calls `.CreateView()` and gets returned the same node, since the first
			* node is still good
			*/
			var startingPositions = Enumerable.Range(0, numberOfNodes)
				.Select(i => pool.CreateView().First())
				.Select(n => n.Uri.Port)
				.ToList();

			var expectedOrder = Enumerable.Repeat(9200, numberOfNodes);
			startingPositions.Should().ContainInOrder(expectedOrder);
		}

	}
}
