﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.XPack.Watcher.StartWatcher
{
	public class StartWatcherUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await POST("/_watcher/_start")
			.Fluent(c => c.Watcher.Start())
			.Request(c => c.Watcher.Start(new StartWatcherRequest()))
			.FluentAsync(c => c.Watcher.StartAsync())
			.RequestAsync(c => c.Watcher.StartAsync(new StartWatcherRequest()));
	}
}
