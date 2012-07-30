﻿using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Indices
{
	[TestFixture]
	public class SnapshotTests : BaseElasticSearchTests
	{
		[Test]
		public void SnapshotAll()
		{
			var r = this.ConnectedClient.Snapshot();
			Assert.True(r.OK);
		}
		[Test]
		public void SnapshotIndex()
		{
			var r = this.ConnectedClient.Snapshot(Test.Default.DefaultIndex);
			Assert.True(r.OK);
		}
		[Test]
		public void SnapshotIndeces()
		{
			var r = this.ConnectedClient.Snapshot(
				new []{Test.Default.DefaultIndex, Test.Default.DefaultIndex + "_clone" });
			Assert.True(r.OK);
		}
		[Test]
		public void SnapshotTyped()
		{
			var r = this.ConnectedClient.Snapshot<ElasticSearchProject>();
			Assert.True(r.OK);
		}
	}
}