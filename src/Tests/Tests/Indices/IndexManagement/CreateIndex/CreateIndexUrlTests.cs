﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.IndexManagement.CreateIndex
{
	public class CreateIndexUrlTests
	{
		[U] public async Task Urls()
		{
			var index = "index1";
			await PUT($"/{index}")
					.Fluent(c => c.Indices.Create(index, s => s))
					.Request(c => c.Indices.Create(new CreateIndexRequest(index)))
					.FluentAsync(c => c.Indices.CreateAsync(index))
					.RequestAsync(c => c.Indices.CreateAsync(new CreateIndexRequest(index)))
				;
		}
	}
}
