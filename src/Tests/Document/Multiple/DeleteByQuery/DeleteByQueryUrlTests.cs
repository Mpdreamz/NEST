﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Multiple.DeleteByQuery
{
	public class DeleteByQueryUrlTests : IUrlTests
	{
		[U] public async Task Urls()
		{
			await DELETE("/project/_query")
				.Fluent(c => c.DeleteByQuery<Project>("project", d => d))
				.Request(c => c.DeleteByQuery(new DeleteByQueryRequest<Project>("project")))
				.FluentAsync(c => c.DeleteByQueryAsync<Project>("project", d => d))
				.RequestAsync(c => c.DeleteByQueryAsync(new DeleteByQueryRequest<Project>("project")))
				;

			await DELETE("/project/project/_query")
				.Fluent(c => c.DeleteByQuery<Project>("project", d => d.Type<Project>()))
				.Request(c => c.DeleteByQuery(new DeleteByQueryRequest<Project>("project", "project")))
				.FluentAsync(c => c.DeleteByQueryAsync<Project>("project", d => d.Type<Project>()))
				.RequestAsync(c => c.DeleteByQueryAsync(new DeleteByQueryRequest<Project>("project", "project")))
				;
		}
	}
}
