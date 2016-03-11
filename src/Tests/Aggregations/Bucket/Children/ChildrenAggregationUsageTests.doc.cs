﻿using System;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;
using static Nest.Infer;

namespace Tests.Aggregations.Bucket.Children
{
	/** == Children Aggregation
	 * A special single bucket aggregation that enables aggregating from buckets on parent document types to
	 * buckets on child documents.
	 *
	 * Be sure to read the elasticsearch documentation {ref_current}/search-aggregations-bucket-children-aggregation.html[on this subject here]
	 */
	public class ChildrenAggregationUsageTests : AggregationUsageTestBase
	{
		public ChildrenAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object ExpectJson => new
		{
			aggs = new
			{
				name_of_child_agg = new
				{
					children = new { type = "commits" },
					aggs = new
					{
						average_per_child = new
						{
							avg = new { field = "confidenceFactor" }
						},
						max_per_child = new
						{
							max = new { field = "confidenceFactor" }
						}
					}
				}
			}
		};

		/** Fluent DSL Example */
		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(aggs => aggs
				.Children<CommitActivity>("name_of_child_agg", child => child
					.Aggregations(childAggs => childAggs
						.Average("average_per_child", avg => avg.Field(p => p.ConfidenceFactor))
						.Max("max_per_child", avg => avg.Field(p => p.ConfidenceFactor))
					)
				)
			);

		/** Object Initializer Syntax Example */
		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new ChildrenAggregation("name_of_child_agg", typeof(CommitActivity))
				{
					Aggregations = 
						new AverageAggregation("average_per_child", "confidenceFactor") &&
						new MaxAggregation("max_per_child", "confidenceFactor")
				}
			};
	}

	// TODO: This looks to be a duplicate of what is in the writing aggregations documentation
	public class ChildrenAggregationDslUsage : ChildrenAggregationUsageTests
	{
		public ChildrenAggregationDslUsage(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new ChildrenAggregation("name_of_child_agg", typeof(CommitActivity))
				{
					Aggregations =
						new AverageAggregation("average_per_child", Field<CommitActivity>(p => p.ConfidenceFactor))
						&& new MaxAggregation("max_per_child", Field<CommitActivity>(p => p.ConfidenceFactor))
				}
			};
	}
}
