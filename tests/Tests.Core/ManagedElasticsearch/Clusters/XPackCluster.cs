﻿using System;
using System.IO;
using Elastic.Managed.Ephemeral;
using Elastic.Xunit;
using Elasticsearch.Net;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.NodeSeeders;
using Tests.Core.ManagedElasticsearch.Tasks;
using Tests.Domain.Extensions;

namespace Tests.Core.ManagedElasticsearch.Clusters
{
	public class XPackClusterConfiguration : ClientTestClusterConfiguration
	{
		public XPackClusterConfiguration() : this(ClusterFeatures.SSL | ClusterFeatures.Security) { }

		public XPackClusterConfiguration(ClusterFeatures features) : base(ClusterFeatures.XPack | features)
		{
			// Get license file path from environment variable
			var licenseFilePath = Environment.GetEnvironmentVariable("ES_LICENSE_FILE");
			if (!string.IsNullOrEmpty(licenseFilePath) && File.Exists(licenseFilePath))
			{
				var licenseContents = File.ReadAllText(licenseFilePath);
				XPackLicenseJson = licenseContents;
			}
			TrialMode = XPackTrialMode.Trial;
			AdditionalBeforeNodeStartedTasks.Add(new EnsureWatcherActionConfigurationInElasticsearchYaml());
			AdditionalBeforeNodeStartedTasks.Add(new EnsureWatcherActionConfigurationSecretsInKeystore());
			AdditionalBeforeNodeStartedTasks.Add(new EnsureNativeSecurityRealmEnabledInElasticsearchYaml());
			ShowElasticsearchOutputAfterStarted = true; //this.TestConfiguration.ShowElasticsearchOutputAfterStarted;
		}
	}

	public class XPackCluster : XunitClusterBase<XPackClusterConfiguration>, INestTestCluster
	{
		public XPackCluster() : this(new XPackClusterConfiguration()) { }

		public XPackCluster(XPackClusterConfiguration configuration) : base(configuration) { }

		public virtual IElasticClient Client => this.GetOrAddClient(s => Authenticate(ConnectionSettings(s.ApplyDomainSettings())));

		protected virtual ConnectionSettings Authenticate(ConnectionSettings s) => s
			.BasicAuthentication(ClusterAuthentication.Admin.Username, ClusterAuthentication.Admin.Password);

		protected virtual ConnectionSettings ConnectionSettings(ConnectionSettings s) => s
			.ServerCertificateValidationCallback(CertificateValidations.AllowAll);

		protected sealed override void SeedCluster()
		{
			Client.Cluster.Health(new ClusterHealthRequest { WaitForStatus = WaitForStatus.Green });
			Client.Cluster.Health(new ClusterHealthRequest(".security-7") { WaitForStatus = WaitForStatus.Green });
			SeedNode();
			Client.Cluster.Health(new ClusterHealthRequest { WaitForStatus = WaitForStatus.Green });
			Client.Cluster.Health(new ClusterHealthRequest(".security-7") { WaitForStatus = WaitForStatus.Green });
		}

		protected virtual void SeedNode() => new DefaultSeeder(Client).SeedNode();
	}
}
