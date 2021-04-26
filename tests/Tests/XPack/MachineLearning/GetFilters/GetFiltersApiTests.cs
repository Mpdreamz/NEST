/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Linq;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.XPack.MachineLearning.GetFilters
{
	[SkipVersion("<6.4.0", "Filter functions for machine learning stabilised in 6.4.0")]
	public class GetFiltersApiTests : MachineLearningIntegrationTestBase<GetFiltersResponse, IGetFiltersRequest, GetFiltersDescriptor, GetFiltersRequest>
	{
		public GetFiltersApiTests(MachineLearningCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override void IntegrationSetup(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values)
				PutFilter(client, callUniqueValue.Value);
		}

		protected override void IntegrationTeardown(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values)
				DeleteFilter(client, callUniqueValue.Value);
		}

		protected override bool ExpectIsValid => true;

		protected override object ExpectJson => null;

		protected override int ExpectStatusCode => 200;

		protected override Func<GetFiltersDescriptor, IGetFiltersRequest> Fluent => f => f.FilterId(CallIsolatedValue);

		protected override HttpMethod HttpMethod => HttpMethod.GET;

		protected override GetFiltersRequest Initializer => new GetFiltersRequest(CallIsolatedValue);

		protected override bool SupportsDeserialization => false;

		protected override string UrlPath => $"_ml/filters/{CallIsolatedValue}";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.MachineLearning.GetFilters(f),
			(client, f) => client.MachineLearning.GetFiltersAsync(f),
			(client, r) => client.MachineLearning.GetFilters(r),
			(client, r) => client.MachineLearning.GetFiltersAsync(r)
		);

		protected override GetFiltersDescriptor NewDescriptor() => new GetFiltersDescriptor().FilterId(CallIsolatedValue);

		protected override void ExpectResponse(GetFiltersResponse response)
		{
			response.ShouldBeValid();
			response.Filters.Should().NotBeEmpty();
			var filter = response.Filters.First();
			filter.FilterId.Should().NotBeNullOrEmpty();
			filter.Items.Should().NotBeNull()
				.And.HaveCount(2)
				.And.Contain("*.google.com")
				.And.Contain("wikipedia.org");
			filter.Description.Should().Be("A list of safe domains");
		}
	}

	[SkipVersion("<6.4.0", "Filter functions for machine learning stabilised in 6.4.0")]
	public class GetFiltersPagingApiTests : MachineLearningIntegrationTestBase<GetFiltersResponse, IGetFiltersRequest, GetFiltersDescriptor, GetFiltersRequest>
	{
		public GetFiltersPagingApiTests(MachineLearningCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override void IntegrationSetup(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values)
				for (var i = 0; i < 3; i++)
					PutFilter(client, callUniqueValue.Value + "_" + (i + 1));
		}

		protected override void IntegrationTeardown(IElasticClient client, CallUniqueValues values)
		{
			foreach (var callUniqueValue in values)
				for (var i = 0; i < 3; i++)
					DeleteFilter(client, callUniqueValue.Value + "_" + (i + 1));
		}

		protected override bool ExpectIsValid => true;

		protected override object ExpectJson => null;

		protected override int ExpectStatusCode => 200;

		protected override Func<GetFiltersDescriptor, IGetFiltersRequest> Fluent => f => f
			.Size(10)
			.From(10);

		protected override HttpMethod HttpMethod => HttpMethod.GET;

		protected override GetFiltersRequest Initializer => new GetFiltersRequest
		{
			Size = 10,
			From = 10
		};

		protected override bool SupportsDeserialization => false;

		protected override string UrlPath => $"_ml/filters?from=10&size=10";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.MachineLearning.GetFilters(f),
			(client, f) => client.MachineLearning.GetFiltersAsync(f),
			(client, r) => client.MachineLearning.GetFilters(r),
			(client, r) => client.MachineLearning.GetFiltersAsync(r)
		);

		protected override void ExpectResponse(GetFiltersResponse response)
		{
			response.ShouldBeValid();
			response.Filters.Should().NotBeEmpty();
			var filter = response.Filters.First();
			filter.FilterId.Should().NotBeNullOrEmpty();
			filter.Items.Should().NotBeNull()
				.And.HaveCount(2)
				.And.Contain("*.google.com")
				.And.Contain("wikipedia.org");
			filter.Description.Should().Be("A list of safe domains");
		}
	}
}
