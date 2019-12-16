﻿using System;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;
using static Elasticsearch.Net.HttpMethod;
using static Nest.Infer;

namespace Tests.XPack.Enrich.PutPolicy
{
	[SkipVersion("<7.5.0", "Introduced in 7.5.0")]
	public class PutPolicyApiTests
		: ApiIntegrationTestBase<XPackCluster, PutEnrichPolicyResponse, IPutEnrichPolicyRequest, PutEnrichPolicyDescriptor<Project>, PutEnrichPolicyRequest>
	{
		public PutPolicyApiTests(XPackCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => PUT;

		protected override object ExpectJson => new
		{
			match = new
			{
				indices = new[] { "project" },
				match_field = "name",
				enrich_fields = new[] { "description", "tags" }
			}
		};

		protected override PutEnrichPolicyRequest Initializer => new PutEnrichPolicyRequest(CallIsolatedValue)
		{
			Match = new EnrichPolicy
			{
				Indices = typeof(Project),
				MatchField = Field<Project>(f => f.Name),
				EnrichFields = Fields<Project>(
					f => f.Description,
					f => f.Tags
				)
			}
		};

		protected override PutEnrichPolicyDescriptor<Project> NewDescriptor() => new PutEnrichPolicyDescriptor<Project>(CallIsolatedValue);

		protected override Func<PutEnrichPolicyDescriptor<Project>, IPutEnrichPolicyRequest> Fluent => f => f
			.Match(m => m
				.Indices(typeof(Project))
				.MatchField(f => f.Name)
				.EnrichFields(f => f
					.Field(ff => ff.Description)
					.Field(ff => ff.Tags)
				)
			);

		protected override string UrlPath => $"/_enrich/policy/{CallIsolatedValue}";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Enrich.PutPolicy(CallIsolatedValue, f),
			(client, f) => client.Enrich.PutPolicyAsync(CallIsolatedValue, f),
			(client, r) => client.Enrich.PutPolicy(r),
			(client, r) => client.Enrich.PutPolicyAsync(r)
		);

		protected override void ExpectResponse(PutEnrichPolicyResponse response) =>
			response.Acknowledged.Should().BeTrue();
	}
}
