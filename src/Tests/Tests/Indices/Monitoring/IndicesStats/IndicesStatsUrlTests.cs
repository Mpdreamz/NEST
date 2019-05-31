﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;
using static Nest.Indices;

namespace Tests.Indices.Monitoring.IndicesStats
{
	public class IndicesStatsUrlTests
	{
		[U] public async Task Urls()
		{
			await GET($"/_stats")
					.Request(c => c.Indices.Stats(new IndicesStatsRequest()))
					.RequestAsync(c => c.Indices.StatsAsync(new IndicesStatsRequest()))
				;

			await GET($"/_all/_stats")
					.Fluent(c => c.Indices.Stats(All))
					.Request(c => c.Indices.Stats(new IndicesStatsRequest(All)))
					.FluentAsync(c => c.Indices.StatsAsync(All))
					.RequestAsync(c => c.Indices.StatsAsync(new IndicesStatsRequest(All)))
				;
			var index = "index1,index2";
			await GET($"/index1%2Cindex2/_stats")
					.Fluent(c => c.Indices.Stats(index))
					.Request(c => c.Indices.Stats(new IndicesStatsRequest(index)))
					.FluentAsync(c => c.Indices.StatsAsync(index))
					.RequestAsync(c => c.Indices.StatsAsync(new IndicesStatsRequest(index)))
				;

			var metrics = IndicesStatsMetric.Completion | IndicesStatsMetric.Flush;
			await GET($"/index1%2Cindex2/_stats/completion%2Cflush")
					.Fluent(c => c.Indices.Stats(index, i => i.Metric(metrics)))
					.Request(c => c.Indices.Stats(new IndicesStatsRequest(index, metrics)))
					.FluentAsync(c => c.Indices.StatsAsync(index, i => i.Metric(metrics)))
					.RequestAsync(c => c.Indices.StatsAsync(new IndicesStatsRequest(index, metrics)))
				;

			metrics = IndicesStatsMetric.Completion | IndicesStatsMetric.Flush | IndicesStatsMetric.All;
			var request = new IndicesStatsRequest(index, metrics) { };
			await GET($"/index1%2Cindex2/_stats/_all")
					.Fluent(c => c.Indices.Stats(index, i => i.Metric(metrics)))
					.Request(c => c.Indices.Stats(request))
					.FluentAsync(c => c.Indices.StatsAsync(index, i => i.Metric(metrics)))
					.RequestAsync(c => c.Indices.StatsAsync(request))
				;
		}
	}
}
