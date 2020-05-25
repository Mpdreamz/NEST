﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Cluster.ClusterSettings.ClusterPutSettings
{
	public class ClusterPutUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await PUT("/_cluster/settings")
			.Fluent(c => c.ClusterPutSettings(s => s))
			.Request(c => c.ClusterPutSettings(new ClusterPutSettingsRequest()))
			.FluentAsync(c => c.ClusterPutSettingsAsync(s => s))
			.RequestAsync(c => c.ClusterPutSettingsAsync(new ClusterPutSettingsRequest()));
	}
}
