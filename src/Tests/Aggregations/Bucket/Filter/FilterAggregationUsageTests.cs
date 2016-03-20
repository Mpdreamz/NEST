﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;
using static Nest.Infer;

namespace Tests.Aggregations.Bucket.Filter
{
	/**== Filter Aggregation
	 * Defines a single bucket of all the documents in the current document set context that match a specified filter. 
	 * Often this will be used to narrow down the current aggregation context to a specific set of documents.
	 *
	 * Be sure to read {ref_current}/search-aggregations-bucket-filter-aggregation.html[the elasticsearch documentation on Filter Aggregation]
	*/
	public class FilterAggregationUsageTests : AggregationUsageTestBase
	{
		public FilterAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage)
		{
		}

		public static string FirstNameToFind = Project.Projects.First().LeadDeveloper.FirstName.ToLowerInvariant();

		protected override object ExpectJson => new
		{
			aggs = new
			{
				bethels_projects = new
				{
					filter = new
					{
						term = new Dictionary<string, object>
						{
							{"leadDeveloper.firstName", new {value = FirstNameToFind}}
						}
					},
					aggs = new
					{
						project_tags = new {terms = new {field = "curatedTags.name"}}
					}
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(aggs => aggs
				.Filter("bethels_projects", date => date
					.Filter(q => q.Term(p => p.LeadDeveloper.FirstName, FirstNameToFind))
					.Aggregations(childAggs => childAggs
						.Terms("project_tags", avg => avg.Field(p => p.CuratedTags.First().Name))
					)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new FilterAggregation("bethels_projects")
				{
					Filter = new TermQuery {Field = Field<Project>(p => p.LeadDeveloper.FirstName), Value = FirstNameToFind},
					Aggregations =
						new TermsAggregation("project_tags") {Field = Field<Project>(p => p.CuratedTags.First().Name)}
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			/** === Handling Responses
			* Using the `.Aggs` aggregation helper we can fetch our aggregation results easily 
			* in the correct type. [Be sure to read more about `.Agg` vs `.Aggregations` on the response here]()
			*/
			response.IsValid.Should().BeTrue();

			var filterAgg = response.Aggs.Filter("bethels_projects");
			filterAgg.Should().NotBeNull();
			filterAgg.DocCount.Should().BeGreaterThan(0);
			var tags = filterAgg.Terms("project_tags");
			tags.Should().NotBeNull();
			tags.Buckets.Should().NotBeEmpty();
		}
	}
	
	/**[float] 
	* == Empty Filter
	* When the collection of filters is empty or all are conditionless, NEST will serialize them
	* to an empty object.
	*/
	public class EmptyFilterAggregationUsageTests : AggregationUsageTestBase
	{
		public EmptyFilterAggregationUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage)
		{
		}

		protected override object ExpectJson => new
		{
			aggs = new
			{
				empty_filter = new
				{
					filter = new object()
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Aggregations(aggs => aggs
				.Filter("empty_filter", date => date
					.Filter(f => f
						.Bool(b => b
							.Filter(new QueryContainer[0])
						)
					)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Aggregations = new FilterAggregation("empty_filter")
				{
					Filter = new BoolQuery
					{
						Filter = new List<QueryContainer>()
					}
				}
			};

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.IsValid.Should().BeTrue();
			response.Aggs.Filter("empty_filter").DocCount.Should().BeGreaterThan(0);
		}
	}
}
