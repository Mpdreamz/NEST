﻿using System;
using System.Linq;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;
using static Elasticsearch.Net.HttpMethod;

namespace Tests.XPack.Enrich.GetPolicy
{
	[SkipVersion("<7.5.0", "Introduced in 7.5.0")]
	public class GetPolicyApiTests
		: ApiTestBase<EnrichCluster, GetEnrichPolicyResponse, IGetEnrichPolicyRequest, GetEnrichPolicyDescriptor, GetEnrichPolicyRequest>
	{
		private static readonly string PolicyName = "example_policy";

		public GetPolicyApiTests(EnrichCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override HttpMethod HttpMethod => GET;

		protected override string UrlPath => $"/_enrich/policy/{PolicyName}";

		protected override GetEnrichPolicyRequest Initializer => new GetEnrichPolicyRequest(PolicyName);

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Enrich.GetPolicy(PolicyName, f),
			(client, f) => client.Enrich.GetPolicyAsync(PolicyName, f),
			(client, r) => client.Enrich.GetPolicy(r),
			(client, r) => client.Enrich.GetPolicyAsync(r)
		);
	}
}
