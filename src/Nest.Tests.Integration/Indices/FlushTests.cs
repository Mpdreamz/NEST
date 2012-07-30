﻿using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Indices
{
	[TestFixture]
	public class FlushTests : BaseElasticSearchTests
	{
		[Test]
		public void FlushAll()
		{
			var r = this.ConnectedClient.Flush();
			Assert.True(r.OK);
		}
		[Test]
		public void FlushIndex()
		{
			var r = this.ConnectedClient.Flush(Test.Default.DefaultIndex);
			Assert.True(r.OK);
		}
		[Test]
		public void FlushIndeces()
		{
			var r = this.ConnectedClient.Flush(
				new[] { Test.Default.DefaultIndex, Test.Default.DefaultIndex + "_clone" });
			Assert.True(r.OK);
		}
		[Test]
		public void FlushTyped()
		{
			var r = this.ConnectedClient.Flush<ElasticSearchProject>();
			Assert.True(r.OK);
		}
		[Test]
		public void FlushAllRefresh()
		{
			var r = this.ConnectedClient.Flush(true);
			Assert.True(r.OK);
		}
		[Test]
		public void FlushIndexRefresh()
		{
			var r = this.ConnectedClient.Flush(Test.Default.DefaultIndex, true);
			Assert.True(r.OK);
		}
		[Test]
		public void FlushIndecesRefresh()
		{
			var r = this.ConnectedClient.Flush(
				new[] { Test.Default.DefaultIndex, Test.Default.DefaultIndex + "_clone" }, true);
			Assert.True(r.OK);
		}
		[Test]
		public void FlushTypedRefresh()
		{
			var r = this.ConnectedClient.Flush<ElasticSearchProject>(true);
			Assert.True(r.OK);
		}
	}
}