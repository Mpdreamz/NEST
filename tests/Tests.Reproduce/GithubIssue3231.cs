﻿using System;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;

namespace Tests.Reproduce
{
	public class GithubIssue3231 : IClusterFixture<ReadOnlyCluster>
	{
		private readonly ReadOnlyCluster _cluster;

		public GithubIssue3231(ReadOnlyCluster cluster) => _cluster = cluster;

		[I]
		public void CatIndicesUsesThrowExceptionsFromConnectionSettingsWhenRequestSettingsAreNotSetTest()
		{
			var client = new ElasticClient(_cluster.CreateConnectionSettings().ThrowExceptions());
			Action catIndicesRequest = () => client.LowLevel.Cat.Indices<StringResponse>("non-existing-index");
			catIndicesRequest.Should().Throw<ElasticsearchClientException>();
		}
	}
}
