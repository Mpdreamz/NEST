﻿using System;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;

namespace Tests.XPack.MachineLearning.OpenJob
{
	public class OpenJobApiTests : MachineLearningIntegrationTestBase<OpenJobResponse, IOpenJobRequest, OpenJobDescriptor, OpenJobRequest>
	{
		public OpenJobApiTests(MachineLearningCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override object ExpectJson => null;
		protected override int ExpectStatusCode => 200;
		protected override Func<OpenJobDescriptor, IOpenJobRequest> Fluent => f => f;
		protected override HttpMethod HttpMethod => HttpMethod.POST;
		protected override OpenJobRequest Initializer => new OpenJobRequest(CallIsolatedValue);
		protected override string UrlPath => $"_ml/anomaly_detectors/{CallIsolatedValue}/_open";

		protected override void IntegrationSetup(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values) PutJob(client, callUniqueValue.Value);
		}

		protected override void IntegrationTeardown(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values)
			{
				CloseJob(client, callUniqueValue.Value);
				DeleteJob(client, callUniqueValue.Value);
			}
		}

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.OpenJob(CallIsolatedValue, f),
			(client, f) => client.OpenJobAsync(CallIsolatedValue, f),
			(client, r) => client.OpenJob(r),
			(client, r) => client.OpenJobAsync(r)
		);

		protected override OpenJobDescriptor NewDescriptor() => new OpenJobDescriptor(CallIsolatedValue);

		protected override void ExpectResponse(OpenJobResponse response) => response.Opened.Should().BeTrue();
	}
}
