﻿using System;
using System.Collections.Generic;
using System.Text;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Core.Client;
using Tests.Core.Extensions;
using Tests.Core.Serialization;
using Tests.Domain;

namespace Tests.Reproduce
{
	public class GithubIssue4078
	{
		[U]
		public void BulkIndexOperationIssue() {

			var indexResponse = TestClient.InMemoryWithJsonNetSerializer.Bulk(d =>
				d.Index<Project>(i => i.IfSequenceNumber(12345).IfPrimaryTerm(67890).Document(Project.Instance))
			);
			Encoding.UTF8.GetString(indexResponse.ApiCall.RequestBodyInBytes).Should().Contain("\"if_seq_no\"").And.Contain("12345")
				.And.Contain("\"if_primary_term\"").And.Contain("67890");
		}

		[U]
		public void BulkUpdateOperationIssue()
		{

			var indexResponse = TestClient.InMemoryWithJsonNetSerializer.Bulk(d =>
				d.Update<Project, object>(i => i.IfSequenceNumber(12345).IfPrimaryTerm(67890).Doc(Project.Instance))
			);
			Encoding.UTF8.GetString(indexResponse.ApiCall.RequestBodyInBytes).Should().Contain("\"if_seq_no\"").And.Contain("12345")
				.And.Contain("\"if_primary_term\"").And.Contain("67890");
		}
	}
}
