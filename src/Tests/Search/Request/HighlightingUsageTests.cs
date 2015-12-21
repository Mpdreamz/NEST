﻿using System;
using System.Collections.Generic;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;

namespace Tests.Search.Request
{
	public class HighlightingUsageTests : SearchUsageTestBase
	{
		public HighlightingUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson => new
		{
			highlight = new
			{
				pre_tags = new[] { "<tag1>" },
				post_tags = new[] { "</tag1>" },
				fields = new
				{
					name = new
					{
						type = "plain",
						force_source = true,
						fragment_size = 150,
						number_of_fragments = 3,
						no_match_size = 150
					},
					leadDeveloper = new { type = "fvh" },
					tags = new { type = "postings" }
				}
			}
		};

		protected override Func<SearchDescriptor<Project>, ISearchRequest> Fluent => s => s
			.Highlight(h => h
				.PreTags("<tag1>")
				.PostTags("</tag1>")
				.Fields(
					fs => fs
						.Field(p => p.Name)
						.Type(HighlighterType.Plain)
						.ForceSource()
						.FragmentSize(150)
						.NumberOfFragments(3)
						.NoMatchSize(150),
					fs => fs
						.Field(p => p.LeadDeveloper)
						.Type(HighlighterType.Fvh),
					fs => fs
						.Field(p => p.Tags)
						.Type(HighlighterType.Postings)
				)
			);

		protected override SearchRequest<Project> Initializer =>
			new SearchRequest<Project>
			{
				Highlight = new Highlight
				{
					PreTags = new[] { "<tag1>" },
					PostTags = new[] { "</tag1>" },
					Fields = new Dictionary<Field, IHighlightField>
					{
							{ "name", new HighlightField
								{
									Type = HighlighterType.Plain,
									ForceSource = true,
									FragmentSize = 150,
									NumberOfFragments = 3,
									NoMatchSize = 150
								}
							},
							{ "leadDeveloper", new HighlightField
								{
									Type = HighlighterType.Fvh,
								}
							},
							{ "tags", new HighlightField
								{
									Type = HighlighterType.Postings
								}
							}
					}
				}
			};
	}
}
