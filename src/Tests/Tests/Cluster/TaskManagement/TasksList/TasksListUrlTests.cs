﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;

namespace Tests.Cluster.TaskManagement.TasksList
{
	public class TasksListUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await UrlTester.GET("/_tasks")
			.Fluent(c => c.Tasks.List())
			.Request(c => c.Tasks.List(new ListTasksRequest()))
			.FluentAsync(c => c.Tasks.ListAsync())
			.RequestAsync(c => c.Tasks.ListAsync(new ListTasksRequest()));
	}
}
