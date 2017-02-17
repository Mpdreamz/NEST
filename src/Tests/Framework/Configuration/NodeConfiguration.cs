using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Framework.Configuration;
using Tests.Framework.Versions;

namespace Tests.Framework.Integration
{
	public class NodeConfiguration : ITestConfiguration
	{
		public TestMode Mode { get; }
		public ElasticsearchVersion ElasticsearchVersion { get; }
		public bool ForceReseed { get; }
		public bool TestAgainstAlreadyRunningElasticsearch { get; }
		public bool RunIntegrationTests { get; }
		public bool RunUnitTests { get; }
		public string ClusterFilter { get; }
		public string TestFilter { get; }
		public string TypeOfCluster { get; }
		public INodeFileSystem FileSystem { get; }

		public ElasticsearchPlugin[] RequiredPlugins { get; } = { };

		public bool XPackEnabled => this.RequiredPlugins.Contains(ElasticsearchPlugin.XPack);

		private List<string> DefaultNodeSettings { get; }

		public NodeConfiguration(ITestConfiguration configuration, Type clusterType)
		{
			var name = clusterType.Name.Replace("Cluster", "");
			this.TypeOfCluster = name;
			this.RequiredPlugins = ClusterRequiredPlugins(clusterType);
			this.Mode = configuration.Mode;
			var v = configuration.ElasticsearchVersion;
			this.ElasticsearchVersion = configuration.ElasticsearchVersion;
			this.ForceReseed = configuration.ForceReseed;
			this.TestAgainstAlreadyRunningElasticsearch = configuration.TestAgainstAlreadyRunningElasticsearch;
			this.RunIntegrationTests = configuration.RunIntegrationTests;
			this.RunUnitTests = configuration.RunUnitTests;
			this.ClusterFilter = configuration.ClusterFilter;
			this.TestFilter = configuration.TestFilter;
			this.FileSystem = new TestRunnerFileSystem(this);

			var attr = v.Major >= 5 ? "attr." : "";
			var indexedOrStored = v > new ElasticsearchVersion("5.0.0-alpha1") ? "stored" : "indexed";
			var shieldOrSecurity = v > new ElasticsearchVersion("5.0.0-alpha1") ? "security" : "shield";
			var es = v > new ElasticsearchVersion("5.0.0-alpha2") ? "" : "es.";
			this.DefaultNodeSettings = new List<string>
			{
				$"{es}cluster.name={this.FileSystem.ClusterName}",
				$"{es}node.name={this.FileSystem.NodeName}",
				$"{es}path.repo={this.FileSystem.RepositoryPath}",
				$"{es}path.data={this.FileSystem.DataPath}",
				$"{es}script.inline=true",
				$"{es}script.max_compilations_per_minute=10000",
				$"{es}script.{indexedOrStored}=true",
				$"{es}node.{attr}testingcluster=true"
			};

			if (!this.ElasticsearchVersion.IsSnapshot)
			{
				var b = this.XPackEnabled.ToString().ToLowerInvariant();
				this.DefaultNodeSettings.Add($"{es}xpack.{shieldOrSecurity}.enabled={b}");
			}

		}

		public string[] CreateSettings(string[] additionalSettings)
		{
			var settingMarker = this.ElasticsearchVersion.Major >= 5 ? "-E " : "-D";
			return DefaultNodeSettings
				.Concat(additionalSettings ?? Enumerable.Empty<string>())
				.Select(s => $"{settingMarker}{s}")
				.ToArray();
		}

		private static ElasticsearchPlugin[] ClusterRequiredPlugins(Type type) =>
			type.GetAttributes<RequiresPluginAttribute>().SelectMany(a => a.Plugins).ToArray();
	}
}
