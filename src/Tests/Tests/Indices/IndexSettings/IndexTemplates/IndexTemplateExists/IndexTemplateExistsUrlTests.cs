﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.IndexSettings.IndexTemplates.IndexTemplateExists
{
	public class IndexTemplateUrlTests
	{
		[U] public async Task Urls()
		{
			var name = "temp";
			await HEAD($"/_template/{name}")
					.Fluent(c => c.Indices.TemplateExists(name))
					.Request(c => c.Indices.TemplateExists(new IndexTemplateExistsRequest(name)))
					.FluentAsync(c => c.Indices.TemplateExistsAsync(name))
					.RequestAsync(c => c.Indices.TemplateExistsAsync(new IndexTemplateExistsRequest(name)))
				;
		}
	}
}
