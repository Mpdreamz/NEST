﻿using Elasticsearch.Net;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.Cat.CatRecovery
{
	public class CatRecoveryApiTests
		: ApiIntegrationTestBase<ReadOnlyCluster, CatResponse<CatRecoveryRecord>, ICatRecoveryRequest, CatRecoveryDescriptor, CatRecoveryRequest>
	{
		public CatRecoveryApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/recovery";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Cat.Recovery(),
			(client, f) => client.Cat.RecoveryAsync(),
			(client, r) => client.Cat.Recovery(r),
			(client, r) => client.Cat.RecoveryAsync(r)
		);
	}
}
