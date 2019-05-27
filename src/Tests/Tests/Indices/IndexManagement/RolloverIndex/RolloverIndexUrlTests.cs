﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.IndexManagement.RolloverIndex
{
	public class RolloverIndexUrlTests
	{
		[U] public async Task Urls()
		{
			var alias = "alias1";
			await POST($"/{alias}/_rollover")
				.Fluent(c => c.Indices.Rollover(alias))
				.Request(c => c.Indices.Rollover(new RolloverIndexRequest(alias)))
				.FluentAsync(c => c.Indices.RolloverAsync(alias))
				.RequestAsync(C => C.Indices.RolloverAsync(new RolloverIndexRequest(alias)));

			var index = "newindex";

			await POST($"/{alias}/_rollover/{index}")
				.Fluent(c => c.Indices.Rollover(alias, r => r.NewIndex(index)))
				.Request(c => c.Indices.Rollover(new RolloverIndexRequest(alias, index)))
				.FluentAsync(c => c.Indices.RolloverAsync(alias, r => r.NewIndex(index)))
				.RequestAsync(C => C.Indices.RolloverAsync(new RolloverIndexRequest(alias, index)));
		}
	}
}
