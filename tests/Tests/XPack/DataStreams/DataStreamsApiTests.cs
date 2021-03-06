// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Transport;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.XPack.DataStreams
{
	[SkipVersion("<7.9.0", "Introduced in 7.9.0")]
	public class DataStreamsApiTests : CoordinatedIntegrationTestBase<WritableCluster>
	{
		private static readonly Metric Document = new()
		{
			Timestamp = new DateTime(2020, 8, 3, 14, 0, 0, DateTimeKind.Utc),
			Accept = 3,
			Deny = 0,
			Host = "localhost",
			Service = "client_test",
			Response = 300,
			Total = 3
		};
		
		private const string CreateDataStreamStep = nameof(CreateDataStreamStep);
		private const string IndexStep = nameof(IndexStep);
		private const string GetDataStreamStep = nameof(GetDataStreamStep);
		private const string PutIndexTemplateStep = nameof(PutIndexTemplateStep);
		private const string DataStreamsStatsStep = nameof(DataStreamsStatsStep);
		private const string DeleteDataStreamStep = nameof(DeleteDataStreamStep);
		private const string PrepareIndexStep = nameof(PrepareIndexStep);
		private const string PrepareAliasStep = nameof(PrepareAliasStep);
		private const string MigrateToDataStreamStep = nameof(MigrateToDataStreamStep);

		public DataStreamsApiTests(WritableCluster cluster, EndpointUsage usage) : base(new CoordinatedUsage(cluster, usage, testOnlyOne: true)
		{
			{PutIndexTemplateStep, u =>
				u.Call((v, client) =>
				{
					// TODO: Composable templates (index templates v2) are experimental so not mapped in the high level client. Use the low level client for now
					var response = client.LowLevel.Indices.PutTemplateV2ForAll<StringResponse>($"{v}_data_stream", PostData.Serializable(new
					{
						index_patterns = new[] { $"{v}*" },
						data_stream = new { },
						template = new
						{
							mappings = new
							{
								properties = new Dictionary<string, object>
								{
									["@timestamp"] = new { type = "date" }
								}
							},
							settings = new
							{
								index = new
								{
									number_of_shards = 1,
									number_of_replicas = 1,
								}
							}
						}
					}));

					if (!response.SuccessOrKnownError)
						throw new Exception($"Invalid integration test setup {response.DebugInformation}");

					return Task.CompletedTask;
				})
			},
			{CreateDataStreamStep, u =>
				u.Calls<CreateDataStreamDescriptor, CreateDataStreamRequest, ICreateDataStreamRequest, CreateDataStreamResponse>(
					v => new CreateDataStreamRequest(v),
					(v, d) => d,
					(v, c, f) => c.Indices.CreateDataStream(v, f),
					(v, c, f) => c.Indices.CreateDataStreamAsync(v, f),
					(v, c, r) => c.Indices.CreateDataStream(r),
					(v, c, r) => c.Indices.CreateDataStreamAsync(r)
				)
			},
			{IndexStep, u =>
				u.Calls<IndexDescriptor<Metric>, IndexRequest<Metric>, IIndexRequest<Metric>, IndexResponse>(
					v => new IndexRequest<Metric>((IndexName)v)
					{
						Document = Document,
						Refresh = Refresh.WaitFor
					},
					(v, d) => d.Index(v).Refresh(Refresh.WaitFor),
					(v, c, f) => c.Index(Document, f),
					(v, c, f) => c.IndexAsync(Document, f),
					(v, c, r) => c.Index(r),
					(v, c, r) => c.IndexAsync(r)
				)
			},
			{GetDataStreamStep, u =>
				u.Calls<GetDataStreamDescriptor, GetDataStreamRequest, IGetDataStreamRequest, GetDataStreamResponse>(
					v => new GetDataStreamRequest(v),
					(v, d) => d.Name(v),
					(v, c, f) => c.Indices.GetDataStream(v, f),
					(v, c, f) => c.Indices.GetDataStreamAsync(v, f),
					(v, c, r) => c.Indices.GetDataStream(r),
					(v, c, r) => c.Indices.GetDataStreamAsync(r)
				)
			},
			{DataStreamsStatsStep, u =>
				u.Calls<DataStreamsStatsDescriptor, DataStreamsStatsRequest, IDataStreamsStatsRequest, DataStreamsStatsResponse>(
					v => new DataStreamsStatsRequest(v),
					(v, d) => d,
					(v, c, f) => c.Indices.DataStreamsStats(v, f),
					(v, c, f) => c.Indices.DataStreamsStatsAsync(v, f),
					(v, c, r) => c.Indices.DataStreamsStats(r),
					(v, c, r) => c.Indices.DataStreamsStatsAsync(r)
				)
			},
			{DeleteDataStreamStep, u =>
				u.Calls<DeleteDataStreamDescriptor, DeleteDataStreamRequest, IDeleteDataStreamRequest, DeleteDataStreamResponse>(
					v => new DeleteDataStreamRequest(v),
					(v, d) => d,
					(v, c, f) => c.Indices.DeleteDataStream(v, f),
					(v, c, f) => c.Indices.DeleteDataStreamAsync(v, f),
					(v, c, r) => c.Indices.DeleteDataStream(r),
					(v, c, r) => c.Indices.DeleteDataStreamAsync(r)
				)
			},
			// Used for migrate step
			{PrepareIndexStep, ">= 7.13.0", u =>
				u.Calls<CreateIndexDescriptor, CreateIndexRequest, ICreateIndexRequest, CreateIndexResponse>(
					v => new CreateIndexRequest($"my-index{v}-test")
					{
						Mappings = new TypeMapping
						{
							Properties = new Properties
							{
								{ "@timestamp", new DateNanosProperty() }
							}
						}
					},
					(v, d) => d.Map(m=> m.Properties(p=> p.DateNanos(dn => dn.Name("@timestamp")))),
					(v, c, f) => c.Indices.Create($"my-index{v}-test", f),
					(v, c, f) => c.Indices.CreateAsync($"my-index{v}-test", f),
					(v, c, r) => c.Indices.Create(r),
					(v, c, r) => c.Indices.CreateAsync(r)
				)
			},
			// Used for migrate step
			{PrepareAliasStep,">= 7.13.0", u =>
				u.Calls<PutAliasDescriptor, PutAliasRequest, IPutAliasRequest, PutAliasResponse>(
					v => new PutAliasRequest($"my-index{v}-test", $"{v}-alias"),
					(v, d) => d,
					(v, c, f) => c.Indices.PutAlias($"my-index{v}-test", $"{v}-alias", f),
					(v, c, f) => c.Indices.PutAliasAsync($"my-index{v}-test", $"{v}-alias", f),
					(v, c, r) => c.Indices.PutAlias(r),
					(v, c, r) => c.Indices.PutAliasAsync(r)
				)
			},
			// Migrate to data stream added in 7.13.0
			{MigrateToDataStreamStep,">= 7.13.0", u =>
				u.Calls<MigrateToDataStreamDescriptor, MigrateToDataStreamRequest, IMigrateToDataStreamRequest, MigrateToDataStreamResponse>(
					v => new MigrateToDataStreamRequest($"{v}-alias"),
					(v, d) => d,
					(v, c, f) => c.Indices.MigrateToDataStream($"{v}-alias", f),
					(v, c, f) => c.Indices.MigrateToDataStreamAsync($"{v}-alias", f),
					(v, c, r) => c.Indices.MigrateToDataStream(r),
					(v, c, r) => c.Indices.MigrateToDataStreamAsync(r)
				)
			},
		}) { }

		[I] public async Task CreateDataStreamResponse() => await Assert<CreateDataStreamResponse>(CreateDataStreamStep, (v, r) =>
		{
			r.ShouldBeValid();
			r.Acknowledged.Should().BeTrue();
		});

		[I] public async Task IndexResponse() => await Assert<IndexResponse>(IndexStep, (v, r) =>
		{
			r.ShouldBeValid();
			r.Result.Should().Be(Result.Created);
		});

		[I] public async Task GetDataStreamResponse() => await Assert<GetDataStreamResponse>(GetDataStreamStep, (v, r) =>
		{
			r.ShouldBeValid();
			r.DataStreams.Should().NotBeNull().And.HaveCount(1);
			var dataStream = r.DataStreams.First();
			dataStream.Name.Should().Be(v);
			dataStream.TimestampField.Should().NotBeNull();
			dataStream.TimestampField.Name.Should().Be("@timestamp");
			dataStream.Generation.Should().Be(1);
			dataStream.Status.Should().NotBe(Health.Green);
			dataStream.Template.Should().Be(v + "_data_stream");
			dataStream.IlmPolicy.Should().BeNull();
			dataStream.Indices.Should().NotBeNull().And.HaveCount(1);

			var index = dataStream.Indices.First();
			index.IndexName.Should().NotBeNullOrEmpty();
			index.IndexUUID.Should().NotBeNullOrEmpty();
		});

		[I] public async Task DataStreamStatsResponse() => await Assert<DataStreamsStatsResponse>(DataStreamsStatsStep, (v, r) =>
		{
			r.ShouldBeValid();
			r.Shards.Should().NotBeNull();
			r.BackingIndices.Should().Be(1);
			r.DataStreamCount.Should().Be(1);
			r.DataStreams.Should().NotBeNull().And.HaveCount(1);

			var dataStream = r.DataStreams.First();
			dataStream.BackingIndices.Should().Be(1);
			dataStream.DataStream.Should().Be(v);
			dataStream.MaximumTimestamp.Should().Be(new DateTimeOffset(2020, 8, 3, 14, 0, 0, TimeSpan.Zero).ToUnixTimeMilliseconds());
			dataStream.MaximumTimestampDateTimeOffset.Should().Be(new DateTimeOffset(2020, 8, 3, 14, 0, 0, TimeSpan.Zero));
			dataStream.StoreSizeBytes.Should().BeGreaterThan(0);
		});

		[I] public async Task DeleteDataStreamResponse() => await Assert<DeleteDataStreamResponse>(DeleteDataStreamStep, (v, r) =>
		{
			r.ShouldBeValid();
			r.Acknowledged.Should().BeTrue();
		});

		[I] public async Task MigrateToDataStreamResponse() => await Assert<MigrateToDataStreamResponse>(MigrateToDataStreamStep, r =>
		{
			r.ShouldBeValid();
			r.Acknowledged.Should().BeTrue();
		});
	}
}
