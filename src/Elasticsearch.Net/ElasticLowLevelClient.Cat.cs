using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using static Elasticsearch.Net.HttpMethod;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.CatApi
{
	///<summary>
	/// Logically groups all Cat API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Cat"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelCatNamespace : NamespacedClientProxy
	{
		internal LowLevelCatNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		protected override string ContentType
		{
			get;
		}

		= "text/plain";
		///<summary>GET on /_cat/aliases <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-alias.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Aliases<TResponse>(CatAliasesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/aliases", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/aliases <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-alias.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AliasesAsync<TResponse>(CatAliasesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/aliases", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/aliases/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-alias.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Aliases<TResponse>(string name, CatAliasesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/aliases/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/aliases/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-alias.html</para></summary>
		///<param name = "name">A comma-separated list of alias names to return</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AliasesAsync<TResponse>(string name, CatAliasesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/aliases/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/allocation <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-allocation.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Allocation<TResponse>(CatAllocationRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/allocation", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/allocation <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-allocation.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AllocationAsync<TResponse>(CatAllocationRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/allocation", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/allocation/{node_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-allocation.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Allocation<TResponse>(string node_id, CatAllocationRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/allocation/{node_id:node_id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/allocation/{node_id} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-allocation.html</para></summary>
		///<param name = "node_id">A comma-separated list of node IDs or names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AllocationAsync<TResponse>(string node_id, CatAllocationRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/allocation/{node_id:node_id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/count <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-count.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Count<TResponse>(CatCountRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/count", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/count <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-count.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CountAsync<TResponse>(CatCountRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/count", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/count/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-count.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Count<TResponse>(string index, CatCountRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/count/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/count/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-count.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CountAsync<TResponse>(string index, CatCountRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/count/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/fielddata <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-fielddata.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Fielddata<TResponse>(CatFielddataRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/fielddata", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/fielddata <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-fielddata.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> FielddataAsync<TResponse>(CatFielddataRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/fielddata", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/fielddata/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-fielddata.html</para></summary>
		///<param name = "fields">A comma-separated list of fields to return the fielddata size</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Fielddata<TResponse>(string fields, CatFielddataRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/fielddata/{fields:fields}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/fielddata/{fields} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-fielddata.html</para></summary>
		///<param name = "fields">A comma-separated list of fields to return the fielddata size</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> FielddataAsync<TResponse>(string fields, CatFielddataRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/fielddata/{fields:fields}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/health <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-health.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Health<TResponse>(CatHealthRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/health", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/health <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-health.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HealthAsync<TResponse>(CatHealthRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/health", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Help<TResponse>(CatHelpRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat", null, RequestParams(requestParameters));
		///<summary>GET on /_cat <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HelpAsync<TResponse>(CatHelpRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/indices <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-indices.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Indices<TResponse>(CatIndicesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/indices", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/indices <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-indices.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> IndicesAsync<TResponse>(CatIndicesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/indices", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/indices/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-indices.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Indices<TResponse>(string index, CatIndicesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/indices/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/indices/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-indices.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> IndicesAsync<TResponse>(string index, CatIndicesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/indices/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/master <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-master.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Master<TResponse>(CatMasterRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/master", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/master <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-master.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> MasterAsync<TResponse>(CatMasterRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/master", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/nodeattrs <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodeattrs.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse NodeAttributes<TResponse>(CatNodeAttributesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/nodeattrs", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/nodeattrs <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodeattrs.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> NodeAttributesAsync<TResponse>(CatNodeAttributesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/nodeattrs", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/nodes <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodes.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Nodes<TResponse>(CatNodesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/nodes", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/nodes <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-nodes.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> NodesAsync<TResponse>(CatNodesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/nodes", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/pending_tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-pending-tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PendingTasks<TResponse>(CatPendingTasksRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/pending_tasks", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/pending_tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-pending-tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PendingTasksAsync<TResponse>(CatPendingTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/pending_tasks", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/plugins <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-plugins.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Plugins<TResponse>(CatPluginsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/plugins", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/plugins <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-plugins.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PluginsAsync<TResponse>(CatPluginsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/plugins", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-recovery.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Recovery<TResponse>(CatRecoveryRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/recovery", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/recovery <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-recovery.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RecoveryAsync<TResponse>(CatRecoveryRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/recovery", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/recovery/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-recovery.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Recovery<TResponse>(string index, CatRecoveryRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/recovery/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/recovery/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-recovery.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RecoveryAsync<TResponse>(string index, CatRecoveryRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/recovery/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/repositories <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-repositories.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Repositories<TResponse>(CatRepositoriesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/repositories", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/repositories <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-repositories.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> RepositoriesAsync<TResponse>(CatRepositoriesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/repositories", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-segments.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Segments<TResponse>(CatSegmentsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/segments", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/segments <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-segments.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SegmentsAsync<TResponse>(CatSegmentsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/segments", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/segments/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-segments.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Segments<TResponse>(string index, CatSegmentsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/segments/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/segments/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-segments.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SegmentsAsync<TResponse>(string index, CatSegmentsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/segments/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/shards <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-shards.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Shards<TResponse>(CatShardsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/shards", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/shards <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-shards.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ShardsAsync<TResponse>(CatShardsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/shards", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/shards/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-shards.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Shards<TResponse>(string index, CatShardsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/shards/{index:index}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/shards/{index} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-shards.html</para></summary>
		///<param name = "index">A comma-separated list of index names to limit the returned information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ShardsAsync<TResponse>(string index, CatShardsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/shards/{index:index}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/snapshots <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-snapshots.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Snapshots<TResponse>(CatSnapshotsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/snapshots", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/snapshots <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-snapshots.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SnapshotsAsync<TResponse>(CatSnapshotsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/snapshots", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/snapshots/{repository} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-snapshots.html</para></summary>
		///<param name = "repository">Name of repository from which to fetch the snapshot information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Snapshots<TResponse>(string repository, CatSnapshotsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/snapshots/{repository:repository}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/snapshots/{repository} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-snapshots.html</para></summary>
		///<param name = "repository">Name of repository from which to fetch the snapshot information</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> SnapshotsAsync<TResponse>(string repository, CatSnapshotsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/snapshots/{repository:repository}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Tasks<TResponse>(CatTasksRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/tasks", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/tasks <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/tasks.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> TasksAsync<TResponse>(CatTasksRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/tasks", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/templates <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-templates.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Templates<TResponse>(CatTemplatesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/templates", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/templates <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-templates.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> TemplatesAsync<TResponse>(CatTemplatesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/templates", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/templates/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-templates.html</para></summary>
		///<param name = "name">A pattern that returned template names must match</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Templates<TResponse>(string name, CatTemplatesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/templates/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/templates/{name} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-templates.html</para></summary>
		///<param name = "name">A pattern that returned template names must match</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> TemplatesAsync<TResponse>(string name, CatTemplatesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/templates/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/thread_pool <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-thread-pool.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ThreadPool<TResponse>(CatThreadPoolRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_cat/thread_pool", null, RequestParams(requestParameters));
		///<summary>GET on /_cat/thread_pool <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-thread-pool.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ThreadPoolAsync<TResponse>(CatThreadPoolRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_cat/thread_pool", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_cat/thread_pool/{thread_pool_patterns} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-thread-pool.html</para></summary>
		///<param name = "thread_pool_patterns">A comma-separated list of regular-expressions to filter the thread pools in the output</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ThreadPool<TResponse>(string thread_pool_patterns, CatThreadPoolRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_cat/thread_pool/{thread_pool_patterns:thread_pool_patterns}"), null, RequestParams(requestParameters));
		///<summary>GET on /_cat/thread_pool/{thread_pool_patterns} <para>http://www.elastic.co/guide/en/elasticsearch/reference/master/cat-thread-pool.html</para></summary>
		///<param name = "thread_pool_patterns">A comma-separated list of regular-expressions to filter the thread pools in the output</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ThreadPoolAsync<TResponse>(string thread_pool_patterns, CatThreadPoolRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_cat/thread_pool/{thread_pool_patterns:thread_pool_patterns}"), ctx, null, RequestParams(requestParameters));
	}
}