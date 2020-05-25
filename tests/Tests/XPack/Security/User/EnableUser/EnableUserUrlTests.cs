﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.XPack.Security.User.EnableUser
{
	public class EnableUserUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls() => await PUT("/_security/user/ironman/_disable")
			.Fluent(c => c.Security.DisableUser("ironman"))
			.Request(c => c.Security.DisableUser(new DisableUserRequest("ironman")))
			.FluentAsync(c => c.Security.DisableUserAsync("ironman"))
			.RequestAsync(c => c.Security.DisableUserAsync(new DisableUserRequest("ironman")));
	}
}
