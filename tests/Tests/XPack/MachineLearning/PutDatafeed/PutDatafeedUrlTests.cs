﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.XPack.MachineLearning.PutDatafeed
{
	public class PutDatafeedUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await PUT("/_ml/datafeeds/datafeed_id")
			.Fluent(c => c.MachineLearning.PutDatafeed<object>("datafeed_id", p => p))
			.Request(c => c.MachineLearning.PutDatafeed(new PutDatafeedRequest("datafeed_id")))
			.FluentAsync(c => c.MachineLearning.PutDatafeedAsync<object>("datafeed_id", p => p))
			.RequestAsync(c => c.MachineLearning.PutDatafeedAsync(new PutDatafeedRequest("datafeed_id")));
	}
}
