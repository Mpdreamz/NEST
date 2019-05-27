﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Modules.SnapshotAndRestore.Snapshot.DeleteSnapshot
{
	public class DeleteSnapshotUrlTests
	{
		[U] public async Task Urls()
		{
			var repository = "repos";
			var snapshot = "snap";

			await DELETE($"/_snapshot/{repository}/{snapshot}")
					.Fluent(c => c.Snapshot.Delete(repository, snapshot))
					.Request(c => c.Snapshot.Delete(new DeleteSnapshotRequest(repository, snapshot)))
					.FluentAsync(c => c.Snapshot.DeleteAsync(repository, snapshot))
					.RequestAsync(c => c.Snapshot.DeleteAsync(new DeleteSnapshotRequest(repository, snapshot)))
				;
		}
	}
}
