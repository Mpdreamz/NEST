﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using Elastic.Managed.FileSystem;
using Elasticsearch.Net;
using Nest;
using Tests.Core.Client;
using Tests.Core.Extensions;
using Tests.Domain;

namespace Tests.Framework.ManagedElasticsearch.NodeSeeders
{
	public class MachineLearningSeeder
	{
		public const string MachineLearningTestsIndexTemplateName = "server-metrics";

		public MachineLearningSeeder(IElasticClient client, INodeFileSystem fileSystem)
		{
			RoamingFolder = fileSystem.LocalFolder;
			Client = client;
		}

		public string RoamingFolder { get; }

		private IElasticClient Client { get; }

		// Sometimes we run against an manually started elasticsearch when
		// writing tests to cut down on cluster startup times.
		// If template exists assume this cluster is already seeded with the machine learning data.
		private bool AlreadySeeded() => Client.IndexTemplateExists(MachineLearningTestsIndexTemplateName).Exists;

		public void SeedNode()
		{
			if (!TestClient.Configuration.ForceReseed && AlreadySeeded()) return;

			// Ensure a clean slate by deleting everything regardless of whether they may already exist
			DeleteIndicesAndTemplates();
			// and now recreate everything
			CreateIndicesAndSeedIndexData();
		}

		public void DeleteIndicesAndTemplates()
		{
			if (Client.IndexTemplateExists(MachineLearningTestsIndexTemplateName).Exists)
				Client.DeleteIndexTemplate(MachineLearningTestsIndexTemplateName);
		}

		private void CreateIndicesAndSeedIndexData()
		{
			CreateIndices();
			SeedIndexData();
		}

		public void CreateIndices()
		{
			CreateIndexTemplate();
			CreateMetricIndex();
		}

		private void SeedIndexData()
		{
			Console.WriteLine("Bulk importing starting ...");
			var folder = Path.Combine(RoamingFolder, "server_metrics");
			Enumerable.Range(1, 4)
				.ToList()
				.ForEach(i =>
				{
					var metricsFile = Path.Combine(folder, $"server-metrics_{i}.json");
					var bulkResponse = Client.LowLevel.Bulk<BulkResponse>(
						File.ReadAllBytes(metricsFile),
						r => r
							.RequestConfiguration(rc => rc
								.RequestTimeout(TimeSpan.FromMinutes(3)
								)
							)
					);

					if (!bulkResponse.Success || bulkResponse.Body != null && !bulkResponse.Body.IsValid)
					{
						// only use the Audit trail as failed bulk items will be YUGE
						var sb = new StringBuilder();
						ResponseStatics.DebugAuditTrail(bulkResponse.AuditTrail, sb);
						throw new Exception($"Problem seeding server-metrics data for Machine Learning: {sb}");
					}

					Console.WriteLine($"Indexed docs from {metricsFile}");
				});
			Console.WriteLine("Bulk importing finished.");
		}

		private void CreateMetricIndex()
		{
			var createProjectIndex = Client.CreateIndex(MachineLearningTestsIndexTemplateName, c => c
				.Mappings(map => map
					.Map<Metric>(m => m
						.AutoMap()
						.Properties(props => props
							.Keyword(t => t
								.Name(p => p.Host)
							)
							.Keyword(t => t
								.Name(p => p.Service)
							)
						)
					)
				)
			);
			createProjectIndex.ShouldBeValid();
		}

		private void CreateIndexTemplate()
		{
			var putTemplateResult = Client.PutIndexTemplate(new PutIndexTemplateRequest(MachineLearningTestsIndexTemplateName)
			{
#pragma warning disable 618
				Template = "*",
#pragma warning restore 618
				Settings = new IndexSettings
				{
					NumberOfShards = 1,
					NumberOfReplicas = 0
				}
			});
			putTemplateResult.ShouldBeValid();
		}
	}
}
