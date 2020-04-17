﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Cat.CatDataFrameAnalytics
{
	public class CatDataFrameAnalyticsUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls()
		{
			await GET("/_cat/ml/data_frame/analytics")
				.Fluent(c => c.Cat.DataFrameAnalytics())
				.Request(c => c.Cat.DataFrameAnalytics(new CatDataFrameAnalyticsRequest()))
				.FluentAsync(c => c.Cat.DataFrameAnalyticsAsync())
				.RequestAsync(c => c.Cat.DataFrameAnalyticsAsync(new CatDataFrameAnalyticsRequest()));

			await GET("/_cat/ml/data_frame/analytics/analytics-id")
				.Fluent(c => c.Cat.DataFrameAnalytics(f => f.Id("analytics-id")))
				.Request(c => c.Cat.DataFrameAnalytics(new CatDataFrameAnalyticsRequest("analytics-id")))
				.FluentAsync(c => c.Cat.DataFrameAnalyticsAsync(f => f.Id("analytics-id")))
				.RequestAsync(c => c.Cat.DataFrameAnalyticsAsync(new CatDataFrameAnalyticsRequest("analytics-id")));
		}
	}
}
