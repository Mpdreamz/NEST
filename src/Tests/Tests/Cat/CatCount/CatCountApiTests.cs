﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.Cat.CatCount
{
	public class CatCountApiTests
		: ApiIntegrationTestBase<ReadOnlyCluster, CatResponse<CatCountRecord>, ICatCountRequest, CatCountDescriptor, CatCountRequest>
	{
		public CatCountApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/count";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Cat.Count(),
			(client, f) => client.Cat.CountAsync(),
			(client, r) => client.Cat.Count(r),
			(client, r) => client.Cat.CountAsync(r)
		);

		protected override void ExpectResponse(CatResponse<CatCountRecord> response) =>
			response.Records.Should().NotBeEmpty().And.Contain(a => a.Count != "0" && !string.IsNullOrEmpty(a.Count));
	}

	public class CatCountSingleIndexApiTests
		: ApiIntegrationTestBase<ReadOnlyCluster, CatResponse<CatCountRecord>, ICatCountRequest, CatCountDescriptor, CatCountRequest>
	{
		public CatCountSingleIndexApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/count/project";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Cat.Count(c => c.Index<Project>()),
			(client, f) => client.Cat.CountAsync(c => c.Index<Project>()),
			(client, r) => client.Cat.Count(new CatCountRequest(typeof(Project))),
			(client, r) => client.Cat.CountAsync(new CatCountRequest(typeof(Project)))
		);

		protected override void ExpectResponse(CatResponse<CatCountRecord> response) =>
			response.Records.Should().NotBeEmpty().And.Contain(a => a.Count != "0" && !string.IsNullOrEmpty(a.Count));
	}
}
