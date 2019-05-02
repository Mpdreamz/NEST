﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework;
using Tests.Framework.Integration;

namespace Tests.Cat.CatMaster
{
	public class CatMasterApiTests
		: ApiIntegrationTestBase<ReadOnlyCluster, CatResponse<CatMasterRecord>, ICatMasterRequest, CatMasterDescriptor, CatMasterRequest>
	{
		public CatMasterApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/master";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.CatMaster(),
			(client, f) => client.CatMasterAsync(),
			(client, r) => client.CatMaster(r),
			(client, r) => client.CatMasterAsync(r)
		);

		protected override void ExpectResponse(CatResponse<CatMasterRecord> response) =>
			response.Records.Should().NotBeEmpty().And.Contain(a => !string.IsNullOrEmpty(a.Node));
	}
}
