using System.Collections.ObjectModel;
using Elasticsearch.Managed.Versions;

namespace Elasticsearch.Managed.Plugins
{
	public class ElasticsearchPluginCollection : KeyedCollection<ElasticsearchPlugin, ElasticsearchPluginConfiguration>
	{
		public static ElasticsearchPluginCollection Supported { get; } =
			new ElasticsearchPluginCollection
			{
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.DeleteByQuery, version => version < new ElasticsearchVersion("5.0.0-alpha3")),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.MapperAttachments),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.MapperMurmer3),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.XPack),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.IngestGeoIp, version => version >= new ElasticsearchVersion("5.0.0-alpha3")),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.IngestAttachment, version => version >= new ElasticsearchVersion("5.0.0-alpha3")),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.AnalysisKuromoji),
				new ElasticsearchPluginConfiguration(ElasticsearchPlugin.AnalysisIcu)
			};

		protected override ElasticsearchPlugin GetKeyForItem(ElasticsearchPluginConfiguration item) => item.Plugin;
	}
}