﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Document.Multiple.Bulk
{
	public class BulkUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls()
		{
			await POST("/_bulk")
					.Fluent(c => c.Bulk(s => s))
					.Request(c => c.Bulk(new BulkRequest()))
					.FluentAsync(c => c.BulkAsync(s => s))
					.RequestAsync(c => c.BulkAsync(new BulkRequest()))
				;

			await POST("/project/_bulk")
					.Fluent(c => c.Bulk(b => b.Index<Project>()))
					.Request(c => c.Bulk(new BulkRequest(typeof(Project))))
					.FluentAsync(c => c.BulkAsync(b => b.Index<Project>()))
					.RequestAsync(c => c.BulkAsync(new BulkRequest(typeof(Project))))
				;
		}
	}
}
