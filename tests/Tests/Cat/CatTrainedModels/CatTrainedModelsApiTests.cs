﻿using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.Cat.CatTrainedModels
{
	[SkipVersion("<7.7.0", "Introduced in 7.7.0")]
	public class CatTrainedModelsApiTests
		: ApiIntegrationTestBase<ReadOnlyCluster, CatResponse<CatTrainedModelsRecord>, ICatTrainedModelsRequest, CatTrainedModelsDescriptor, CatTrainedModelsRequest>
	{
		public CatTrainedModelsApiTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override string UrlPath => "/_cat/ml/trained_models";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Cat.TrainedModels(),
			(client, f) => client.Cat.TrainedModelsAsync(),
			(client, r) => client.Cat.TrainedModels(r),
			(client, r) => client.Cat.TrainedModelsAsync(r)
		);

		protected override void ExpectResponse(CatResponse<CatTrainedModelsRecord> response) => response.ShouldBeValid();
	}
}
