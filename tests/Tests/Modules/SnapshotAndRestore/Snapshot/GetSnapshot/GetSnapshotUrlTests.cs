﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Modules.SnapshotAndRestore.Snapshot.GetSnapshot
{
	public class GetSnapshotUrlTests
	{
		[U] public async Task Urls()
		{
			var repository = "repos";
			var snapshot = "snap";

			await GET($"/_snapshot/{repository}/{snapshot}")
					.Fluent(c => c.Snapshot.Get(repository, snapshot))
					.Request(c => c.Snapshot.Get(new GetSnapshotRequest(repository, snapshot)))
					.FluentAsync(c => c.Snapshot.GetAsync(repository, snapshot))
					.RequestAsync(c => c.Snapshot.GetAsync(new GetSnapshotRequest(repository, snapshot)))
				;
		}
	}
}
