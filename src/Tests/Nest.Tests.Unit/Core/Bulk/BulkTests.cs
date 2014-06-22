﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;
using Shared.Extensions;
using System;
using System.Reflection;

namespace Nest.Tests.Unit.Core.Bulk
{
	[TestFixture]
	public class BulkTests : BaseJsonTests
	{
		[Test]
		public void BulkOperations()
		{
			var result = this._client.Bulk(b => b
				.Index<ElasticsearchProject>(i => i
					.Object(new ElasticsearchProject {Id = 2})
					.VersionType(VersionTypeOptions.Force))
				.Create<ElasticsearchProject>(i => i
					.Object(new ElasticsearchProject { Id = 3 })
					.VersionType(VersionTypeOptions.Internal))
				.Delete<ElasticsearchProject>(i => i
					.Object(new ElasticsearchProject { Id = 4 })
					.VersionType(VersionTypeOptions.ExternalGte))
				.Update<ElasticsearchProject, object>(i => i
					.Object(new ElasticsearchProject { Id = 3 })
					.VersionType(VersionTypeOptions.External)
					.Document(new { name = "NEST"})
				)
			);
			var status = result.ConnectionStatus;
			this.BulkJsonEquals(status.Request.Utf8String(), MethodInfo.GetCurrentMethod());
		}
		[Test]
		public void BulkUpdateDetails()
		{
			var result = this._client.Bulk(b => b
				.Update<ElasticsearchProject, object>(i => i
					.Object(new ElasticsearchProject { Id = 3 })
					.Document(new { name = "NEST" })
					.RetriesOnConflict(4)
				)
				.Index<ElasticsearchProject>(i=>i
					.Object(new ElasticsearchProject { Name = "yodawg", Id = 90})
					.Percolate("percolateme")
				)
			);
			var status = result.ConnectionStatus;
			this.BulkJsonEquals(status.Request.Utf8String(), MethodInfo.GetCurrentMethod());
		}
	}
}
