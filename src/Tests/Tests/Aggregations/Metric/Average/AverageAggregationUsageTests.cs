﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.Integration;
using static Nest.Infer;

namespace Tests.Aggregations.Metric.Average
{
	public class AverageAggregationUsageTests : AggregationUsageTestBase
	{
		public AverageAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object ExpectJson => new
		{
			aggs = new
			{
				average_commits = new
				{
					meta = new
					{
						foo = "bar"
					},
					avg = new
					{
						field = "numberOfCommits",
						missing = 10.0,
						script = new
						{
							inline = "_value * 1.2",
							lang = "groovy"
						}
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(a => a
				.Average("average_commits", avg => avg
					.Meta(m => m
						.Add("foo", "bar")
					)
					.Field(p => p.NumberOfCommits)
					.Missing(10)
					.Script(ss => ss.Inline("_value * 1.2").Lang("groovy"))
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new AverageAggregation("average_commits", Field<Project>(p => p.NumberOfCommits))
				{
					Meta = new Dictionary<string, object>
					{
						{ "foo", "bar" }
					},
					Missing = 10,
					Script = new InlineScript("_value * 1.2") { Lang = "groovy" }
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();
			var commitsAvg = response.Aggs.Average("average_commits");
			commitsAvg.Should().NotBeNull();
			commitsAvg.Value.Should().BeGreaterThan(0);
			commitsAvg.Meta.Should().NotBeNull().And.HaveCount(1);
			commitsAvg.Meta["foo"].Should().Be("bar");
		}
	}
}
