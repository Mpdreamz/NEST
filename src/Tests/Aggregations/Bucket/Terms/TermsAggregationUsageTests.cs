﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;
using static Nest.Infer;

namespace Tests.Aggregations.Bucket.Terms
{
	public class TermsAggregationUsageTests : AggregationUsageTestBase
	{
		public TermsAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object ExpectJson => new
		{
			aggs = new
			{
				states = new
				{
					meta = new
					{
						foo = "bar"
					},
					terms = new
					{
						field = Field<Project>(p => p.State),
						min_doc_count = 2,
						size = 5,
						shard_size = 100,
						show_term_doc_error_count = true,
						execution_hint = "map",
						missing = "n/a",
						script = new
						{
							inline = "'State of Being: '+_value"
						},
						order = new object[]
						{
							new { _term = "asc" },
							new { _count = "desc" }
						},
						aggs = new
						{
							commit_stats = new
							{
								extended_stats = new
								{
									field = "numberOfCommits"
								}
							}
						}
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(a => a
				.Terms("states", st => st
					.Field(p => p.State)
					.MinimumDocumentCount(2)
					.Size(5)
					.ShardSize(100)
					.ShowTermDocumentCountError()
					.ExecutionHint(TermsAggregationExecutionHint.Map)
					.Missing("n/a")
					.Script("'State of Being: '+_value")
					.Order(TermsOrder.TermAscending)
					.Order(TermsOrder.CountDescending)
					.Meta(m => m
						.Add("foo", "bar")
					)
					.Aggregations(aa => aa
						.ExtendedStats("commit_stats", es => es
							.Field(p => p.NumberOfCommits)
						)
					)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new TermsAggregation("states")
				{
					Field = Field<Project>(p => p.State),
					MinimumDocumentCount = 2,
					Size = 5,
					ShardSize = 100,
					ShowTermDocumentCountError = true,
					ExecutionHint = TermsAggregationExecutionHint.Map,
					Missing = "n/a",
					Script = new InlineScript("'State of Being: '+_value"),
					Order = new List<TermsOrder>
					{
						TermsOrder.TermAscending,
						TermsOrder.CountDescending
					},
					Meta = new Dictionary<string, object>
					{
						{ "foo", "bar" }
					},
					Aggregations = new ExtendedStatsAggregation("commit_stats", "numberOfCommits")
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.IsValid.Should().BeTrue();
			var states = response.Aggs.Terms("states");
			states.Should().NotBeNull();
			states.Meta.Should().NotBeNull().And.HaveCount(1);
			states.Meta["foo"].Should().Be("bar");
			foreach (var bucket in states.Buckets)
			{
				bucket.Key.Should().NotBeNullOrEmpty();
				bucket.DocCount.Should().BeGreaterOrEqualTo(1);
				var commitStats = bucket.ExtendedStats("commit_stats");
				commitStats.Should().NotBeNull();
			}
		}
	}
}