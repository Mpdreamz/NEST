﻿using System;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;

namespace Tests.Mapping.Types.Core.Range.DateRange
{
	[SkipVersion("<5.2.0", "dedicated range types is a new 5.2.0 feature")]
	public class DateRangePropertyTests : PropertyTestsBase
	{
		private DateTime _nullValue = new DateTime(2000, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc);

		public DateRangePropertyTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson => new
		{
			properties = new
			{
				ranges = new
				{
					type = "object",
					properties = new
					{
						dates = new
						{
							type = "date_range",
							store = true,
							index = false,
							include_in_all = false,
							boost = 1.5,
							coerce = true
						}
					}
				}
			}
		};

#pragma warning disable 618 // Usage of IncludeInAll
		protected override Func<PropertiesDescriptor<Project>, IPromise<IProperties>> FluentProperties => f => f
			.Object<Ranges>(m => m
				.Name(p => p.Ranges)
				.Properties(props => props
					.DateRange(n => n
						.Name(p => p.Dates)
						.Store()
						.Index(false)
						.Boost(1.5)
						.IncludeInAll(false)
						.Coerce()
					)
				)
			);
#pragma warning restore 618

		protected override IProperties InitializerProperties => new Properties
		{
			{
				"ranges", new ObjectProperty
				{
					Properties = new Properties
					{
						{
							"dates", new DateRangeProperty
							{
								Store = true,
								Index = false,
								Boost = 1.5,
#pragma warning disable 618
								IncludeInAll = false,
#pragma warning restore 618
								Coerce = true
							}
						}
					}
				}
			}
		};
	}
}
