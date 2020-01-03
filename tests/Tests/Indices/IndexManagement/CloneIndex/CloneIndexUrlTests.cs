﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Indices.IndexManagement.CloneIndex
{
	public class CloneIndexUrlTests
	{
		[U] public async Task Urls()
		{
			var index = "index1";
			var target = "target";
			await PUT($"/{index}/_clone/{target}")
					.Fluent(c => c.Indices.Clone(index, target))
					.Request(c => c.Indices.Clone(new CloneIndexRequest(index, target)))
					.FluentAsync(c => c.Indices.CloneAsync(index, target))
					.RequestAsync(c => c.Indices.CloneAsync(new CloneIndexRequest(index, target)))
				;
		}
	}
}
