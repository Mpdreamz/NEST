﻿using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Core.Xunit;
using Tests.Framework;
using Tests.Framework.Integration;

namespace Tests.XPack.License.GetTrialLicenseStatus
{
	[SkipVersion("<6.1.0", "Only exists in Elasticsearch 6.1.0+")]
	[SkipOnTeamCity]
	public class GetTrialLicenseStatusApiTests
		: ApiIntegrationTestBase<XPackCluster, GetTrialLicenseStatusResponse, IGetTrialLicenseStatusRequest, GetTrialLicenseStatusDescriptor,
			GetTrialLicenseStatusRequest>
	{
		public GetTrialLicenseStatusApiTests(XPackCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.GET;
		protected override bool SupportsDeserialization => false;
		protected override string UrlPath => $"/_license/trial_status";

		protected bool BootstrappedWithLicense => !string.IsNullOrEmpty(Cluster.ClusterConfiguration.XPackLicenseJson);

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.License.GetTrialStatus(f),
			(client, f) => client.License.GetTrialStatusAsync(f),
			(client, r) => client.License.GetTrialStatus(r),
			(client, r) => client.License.GetTrialStatusAsync(r)
		);

		protected override void ExpectResponse(GetTrialLicenseStatusResponse response)
		{
			response.ShouldBeValid();
			// returns false if bootstrap already started the trial
			response.EligibleToStartTrial.Should().Be(BootstrappedWithLicense);
		}
	}
}
