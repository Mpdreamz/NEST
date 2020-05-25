﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.XPack.MachineLearning.StopDatafeed
{
	public class StopDatafeedUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await POST("/_ml/datafeeds/datafeed_id/_stop")
			.Fluent(c => c.MachineLearning.StopDatafeed("datafeed_id"))
			.Request(c => c.MachineLearning.StopDatafeed(new StopDatafeedRequest("datafeed_id")))
			.FluentAsync(c => c.MachineLearning.StopDatafeedAsync("datafeed_id"))
			.RequestAsync(c => c.MachineLearning.StopDatafeedAsync(new StopDatafeedRequest("datafeed_id")));
	}
}
