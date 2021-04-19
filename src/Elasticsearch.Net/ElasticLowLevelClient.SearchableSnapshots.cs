// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elastic.Transport;
using static Elastic.Transport.HttpMethod;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable once CheckNamespace
// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable RedundantExtendsListEntry
namespace Elasticsearch.Net.Specification.SearchableSnapshotsApi
{
	///<summary>
	/// Searchable Snapshots APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticLowLevelClient.SearchableSnapshots"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelSearchableSnapshotsNamespace : NamespacedClientProxy
	{
		internal LowLevelSearchableSnapshotsNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>GET on /_searchable_snapshots/cache/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse CacheStats<TResponse>(CacheStatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_searchable_snapshots/cache/stats", null, RequestParams(requestParameters));
		///<summary>GET on /_searchable_snapshots/cache/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.cache_stats", "")]
		public Task<TResponse> CacheStatsAsync<TResponse>(CacheStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_searchable_snapshots/cache/stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_searchable_snapshots/{node_id}/cache/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "nodeId">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse CacheStats<TResponse>(string nodeId, CacheStatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_searchable_snapshots/{nodeId:nodeId}/cache/stats"), null, RequestParams(requestParameters));
		///<summary>GET on /_searchable_snapshots/{node_id}/cache/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "nodeId">A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you&#x27;re connecting to, leave empty to get information from all nodes</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.cache_stats", "node_id")]
		public Task<TResponse> CacheStatsAsync<TResponse>(string nodeId, CacheStatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_searchable_snapshots/{nodeId:nodeId}/cache/stats"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_searchable_snapshots/cache/clear <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse ClearCache<TResponse>(ClearCacheRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_searchable_snapshots/cache/clear", null, RequestParams(requestParameters));
		///<summary>POST on /_searchable_snapshots/cache/clear <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.clear_cache", "")]
		public Task<TResponse> ClearCacheAsync<TResponse>(ClearCacheRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_searchable_snapshots/cache/clear", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_searchable_snapshots/cache/clear <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse ClearCache<TResponse>(string index, ClearCacheRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, Url($"{index:index}/_searchable_snapshots/cache/clear"), null, RequestParams(requestParameters));
		///<summary>POST on /{index}/_searchable_snapshots/cache/clear <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.clear_cache", "index")]
		public Task<TResponse> ClearCacheAsync<TResponse>(string index, ClearCacheRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, Url($"{index:index}/_searchable_snapshots/cache/clear"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_snapshot/{repository}/{snapshot}/_mount <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-api-mount-snapshot.html</para></summary>
		///<param name = "repository">The name of the repository containing the snapshot of the index to mount</param>
		///<param name = "snapshot">The name of the snapshot of the index to mount</param>
		///<param name = "body">The restore configuration for mounting the snapshot as searchable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse Mount<TResponse>(string repository, string snapshot, PostData body, MountRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, Url($"_snapshot/{repository:repository}/{snapshot:snapshot}/_mount"), body, RequestParams(requestParameters));
		///<summary>POST on /_snapshot/{repository}/{snapshot}/_mount <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-api-mount-snapshot.html</para></summary>
		///<param name = "repository">The name of the repository containing the snapshot of the index to mount</param>
		///<param name = "snapshot">The name of the snapshot of the index to mount</param>
		///<param name = "body">The restore configuration for mounting the snapshot as searchable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.mount", "repository, snapshot, body")]
		public Task<TResponse> MountAsync<TResponse>(string repository, string snapshot, PostData body, MountRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_snapshot/{repository:repository}/{snapshot:snapshot}/_mount"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_searchable_snapshots/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse Stats<TResponse>(StatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, "_searchable_snapshots/stats", null, RequestParams(requestParameters));
		///<summary>GET on /_searchable_snapshots/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.stats", "")]
		public Task<TResponse> StatsAsync<TResponse>(StatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, "_searchable_snapshots/stats", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_searchable_snapshots/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		public TResponse Stats<TResponse>(string index, StatsRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_searchable_snapshots/stats"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_searchable_snapshots/stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
		///<param name = "index">A comma-separated list of index names</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		///<remarks>Note: Experimental within the Elasticsearch server, this functionality is Experimental and may be changed or removed completely in a future release. Elastic will take a best effort approach to fix any issues, but experimental features are not subject to the support SLA of official GA features. This functionality is subject to potential breaking changes within a minor version, meaning that your referencing code may break when this library is upgraded.</remarks>
		[MapsApi("searchable_snapshots.stats", "index")]
		public Task<TResponse> StatsAsync<TResponse>(string index, StatsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_searchable_snapshots/stats"), ctx, null, RequestParams(requestParameters));
	}
}