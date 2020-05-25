﻿using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Search.FieldCapabilities
{
	public class FieldCapabilitiesUrlTests
	{
		[U] public async Task Urls() => await GET("/project/_field_caps")
			.Fluent(c => c.FieldCapabilities(Nest.Indices.Index<Project>()))
			.Request(c => c.FieldCapabilities(new FieldCapabilitiesRequest("project")))
			.FluentAsync(c => c.FieldCapabilitiesAsync(typeof(Project)))
			.RequestAsync(c => c.FieldCapabilitiesAsync(new FieldCapabilitiesRequest("project")));
	}
}
