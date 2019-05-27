﻿using System;
using Elasticsearch.Net;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework;
using Tests.Framework.Integration;

namespace Tests.Indices.IndexSettings.IndexTemplates.IndexTemplateExists
{
	public class IndexTemplateExistsApiTests
		: ApiTestBase<WritableCluster, ExistsResponse, IIndexTemplateExistsRequest, IndexTemplateExistsDescriptor, IndexTemplateExistsRequest>
	{
		public IndexTemplateExistsApiTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override Func<IndexTemplateExistsDescriptor, IIndexTemplateExistsRequest> Fluent => d => d;

		protected override HttpMethod HttpMethod => HttpMethod.HEAD;

		protected override IndexTemplateExistsRequest Initializer => new IndexTemplateExistsRequest(CallIsolatedValue);
		protected override string UrlPath => $"/_template/{CallIsolatedValue}";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Indices.TemplateExists(CallIsolatedValue, f),
			(client, f) => client.Indices.TemplateExistsAsync(CallIsolatedValue, f),
			(client, r) => client.Indices.TemplateExists(r),
			(client, r) => client.Indices.TemplateExistsAsync(r)
		);

		protected override IndexTemplateExistsDescriptor NewDescriptor() => new IndexTemplateExistsDescriptor(CallIsolatedValue);
	}
}
