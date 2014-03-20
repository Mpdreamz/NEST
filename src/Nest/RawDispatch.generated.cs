using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;

///Generated File Please Do Not Edit Manually


namespace Nest
{
	///<summary>
	///Raw operations with elasticsearch
	///</summary>
	internal partial class RawDispatch
	{
	
		
		internal ElasticsearchResponse<T> BulkDispatch<T>(ElasticsearchPathInfo<BulkQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Bulk<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Bulk<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_bulk
					if (body != null)
						return this.Raw.Bulk<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.BulkPut<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.BulkPut<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_bulk
					if (body != null)
						return this.Raw.BulkPut<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Bulk() into any of the following paths: \r\n - /_bulk\r\n - /{index}/_bulk\r\n - /{index}/{type}/_bulk");
		}
		
		
		internal Task<ElasticsearchResponse<T>> BulkDispatchAsync<T>(ElasticsearchPathInfo<BulkQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.BulkAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.BulkAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_bulk
					if (body != null)
						return this.Raw.BulkAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.BulkPutAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/_bulk
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.BulkPutAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_bulk
					if (body != null)
						return this.Raw.BulkPutAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Bulk() into any of the following paths: \r\n - /_bulk\r\n - /{index}/_bulk\r\n - /{index}/{type}/_bulk");
		}
		
		
		internal ElasticsearchResponse<T> CatAliasesDispatch<T>(ElasticsearchPathInfo<CatAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/aliases/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.CatAliases<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/aliases
					return this.Raw.CatAliases<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatAliases() into any of the following paths: \r\n - /_cat/aliases\r\n - /_cat/aliases/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatAliasesDispatchAsync<T>(ElasticsearchPathInfo<CatAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/aliases/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.CatAliasesAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/aliases
					return this.Raw.CatAliasesAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatAliases() into any of the following paths: \r\n - /_cat/aliases\r\n - /_cat/aliases/{name}");
		}
		
		
		internal ElasticsearchResponse<T> CatAllocationDispatch<T>(ElasticsearchPathInfo<CatAllocationQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/allocation/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.CatAllocation<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/allocation
					return this.Raw.CatAllocation<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatAllocation() into any of the following paths: \r\n - /_cat/allocation\r\n - /_cat/allocation/{node_id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatAllocationDispatchAsync<T>(ElasticsearchPathInfo<CatAllocationQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/allocation/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.CatAllocationAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/allocation
					return this.Raw.CatAllocationAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatAllocation() into any of the following paths: \r\n - /_cat/allocation\r\n - /_cat/allocation/{node_id}");
		}
		
		
		internal ElasticsearchResponse<T> CatCountDispatch<T>(ElasticsearchPathInfo<CatCountQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/count/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatCount<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/count
					return this.Raw.CatCount<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatCount() into any of the following paths: \r\n - /_cat/count\r\n - /_cat/count/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatCountDispatchAsync<T>(ElasticsearchPathInfo<CatCountQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/count/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatCountAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/count
					return this.Raw.CatCountAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatCount() into any of the following paths: \r\n - /_cat/count\r\n - /_cat/count/{index}");
		}
		
		
		internal ElasticsearchResponse<T> CatHealthDispatch<T>(ElasticsearchPathInfo<CatHealthQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/health
					return this.Raw.CatHealth<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatHealth() into any of the following paths: \r\n - /_cat/health");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatHealthDispatchAsync<T>(ElasticsearchPathInfo<CatHealthQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/health
					return this.Raw.CatHealthAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatHealth() into any of the following paths: \r\n - /_cat/health");
		}
		
		
		internal ElasticsearchResponse<T> CatHelpDispatch<T>(ElasticsearchPathInfo<CatHelpQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat
					return this.Raw.CatHelp<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatHelp() into any of the following paths: \r\n - /_cat");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatHelpDispatchAsync<T>(ElasticsearchPathInfo<CatHelpQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat
					return this.Raw.CatHelpAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatHelp() into any of the following paths: \r\n - /_cat");
		}
		
		
		internal ElasticsearchResponse<T> CatIndicesDispatch<T>(ElasticsearchPathInfo<CatIndicesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/indices/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatIndices<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/indices
					return this.Raw.CatIndices<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatIndices() into any of the following paths: \r\n - /_cat/indices\r\n - /_cat/indices/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatIndicesDispatchAsync<T>(ElasticsearchPathInfo<CatIndicesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/indices/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatIndicesAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/indices
					return this.Raw.CatIndicesAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatIndices() into any of the following paths: \r\n - /_cat/indices\r\n - /_cat/indices/{index}");
		}
		
		
		internal ElasticsearchResponse<T> CatMasterDispatch<T>(ElasticsearchPathInfo<CatMasterQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/master
					return this.Raw.CatMaster<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatMaster() into any of the following paths: \r\n - /_cat/master");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatMasterDispatchAsync<T>(ElasticsearchPathInfo<CatMasterQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/master
					return this.Raw.CatMasterAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatMaster() into any of the following paths: \r\n - /_cat/master");
		}
		
		
		internal ElasticsearchResponse<T> CatNodesDispatch<T>(ElasticsearchPathInfo<CatNodesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/nodes
					return this.Raw.CatNodes<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatNodes() into any of the following paths: \r\n - /_cat/nodes");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatNodesDispatchAsync<T>(ElasticsearchPathInfo<CatNodesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/nodes
					return this.Raw.CatNodesAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatNodes() into any of the following paths: \r\n - /_cat/nodes");
		}
		
		
		internal ElasticsearchResponse<T> CatPendingTasksDispatch<T>(ElasticsearchPathInfo<CatPendingTasksQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/pending_tasks
					return this.Raw.CatPendingTasks<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatPendingTasks() into any of the following paths: \r\n - /_cat/pending_tasks");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatPendingTasksDispatchAsync<T>(ElasticsearchPathInfo<CatPendingTasksQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/pending_tasks
					return this.Raw.CatPendingTasksAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatPendingTasks() into any of the following paths: \r\n - /_cat/pending_tasks");
		}
		
		
		internal ElasticsearchResponse<T> CatRecoveryDispatch<T>(ElasticsearchPathInfo<CatRecoveryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/recovery/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatRecovery<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/recovery
					return this.Raw.CatRecovery<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatRecovery() into any of the following paths: \r\n - /_cat/recovery\r\n - /_cat/recovery/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatRecoveryDispatchAsync<T>(ElasticsearchPathInfo<CatRecoveryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/recovery/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatRecoveryAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/recovery
					return this.Raw.CatRecoveryAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatRecovery() into any of the following paths: \r\n - /_cat/recovery\r\n - /_cat/recovery/{index}");
		}
		
		
		internal ElasticsearchResponse<T> CatShardsDispatch<T>(ElasticsearchPathInfo<CatShardsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/shards/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatShards<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/shards
					return this.Raw.CatShards<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatShards() into any of the following paths: \r\n - /_cat/shards\r\n - /_cat/shards/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatShardsDispatchAsync<T>(ElasticsearchPathInfo<CatShardsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/shards/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CatShardsAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cat/shards
					return this.Raw.CatShardsAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatShards() into any of the following paths: \r\n - /_cat/shards\r\n - /_cat/shards/{index}");
		}
		
		
		internal ElasticsearchResponse<T> CatThreadPoolDispatch<T>(ElasticsearchPathInfo<CatThreadPoolQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/thread_pool
					return this.Raw.CatThreadPool<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatThreadPool() into any of the following paths: \r\n - /_cat/thread_pool");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CatThreadPoolDispatchAsync<T>(ElasticsearchPathInfo<CatThreadPoolQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cat/thread_pool
					return this.Raw.CatThreadPoolAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.CatThreadPool() into any of the following paths: \r\n - /_cat/thread_pool");
		}
		
		
		internal ElasticsearchResponse<T> ClearScrollDispatch<T>(ElasticsearchPathInfo<ClearScrollQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty())
						return this.Raw.ClearScroll<T>(pathInfo.ScrollId,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClearScroll() into any of the following paths: \r\n - /_search/scroll/{scroll_id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClearScrollDispatchAsync<T>(ElasticsearchPathInfo<ClearScrollQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty())
						return this.Raw.ClearScrollAsync<T>(pathInfo.ScrollId,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClearScroll() into any of the following paths: \r\n - /_search/scroll/{scroll_id}");
		}
		
		
		internal ElasticsearchResponse<T> ClusterGetSettingsDispatch<T>(ElasticsearchPathInfo<ClusterGetSettingsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/settings
					return this.Raw.ClusterGetSettings<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterGetSettings() into any of the following paths: \r\n - /_cluster/settings");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterGetSettingsDispatchAsync<T>(ElasticsearchPathInfo<ClusterGetSettingsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/settings
					return this.Raw.ClusterGetSettingsAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterGetSettings() into any of the following paths: \r\n - /_cluster/settings");
		}
		
		
		internal ElasticsearchResponse<T> ClusterHealthDispatch<T>(ElasticsearchPathInfo<ClusterHealthQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/health/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.ClusterHealth<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/health
					return this.Raw.ClusterHealth<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterHealth() into any of the following paths: \r\n - /_cluster/health\r\n - /_cluster/health/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterHealthDispatchAsync<T>(ElasticsearchPathInfo<ClusterHealthQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/health/{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.ClusterHealthAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/health
					return this.Raw.ClusterHealthAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterHealth() into any of the following paths: \r\n - /_cluster/health\r\n - /_cluster/health/{index}");
		}
		
		
		internal ElasticsearchResponse<T> ClusterPendingTasksDispatch<T>(ElasticsearchPathInfo<ClusterPendingTasksQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/pending_tasks
					return this.Raw.ClusterPendingTasks<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterPendingTasks() into any of the following paths: \r\n - /_cluster/pending_tasks");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterPendingTasksDispatchAsync<T>(ElasticsearchPathInfo<ClusterPendingTasksQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/pending_tasks
					return this.Raw.ClusterPendingTasksAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterPendingTasks() into any of the following paths: \r\n - /_cluster/pending_tasks");
		}
		
		
		internal ElasticsearchResponse<T> ClusterPutSettingsDispatch<T>(ElasticsearchPathInfo<ClusterPutSettingsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_cluster/settings
					if (body != null)
						return this.Raw.ClusterPutSettings<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterPutSettings() into any of the following paths: \r\n - /_cluster/settings");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterPutSettingsDispatchAsync<T>(ElasticsearchPathInfo<ClusterPutSettingsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_cluster/settings
					if (body != null)
						return this.Raw.ClusterPutSettingsAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterPutSettings() into any of the following paths: \r\n - /_cluster/settings");
		}
		
		
		internal ElasticsearchResponse<T> ClusterRerouteDispatch<T>(ElasticsearchPathInfo<ClusterRerouteQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_cluster/reroute
					if (body != null)
						return this.Raw.ClusterReroute<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterReroute() into any of the following paths: \r\n - /_cluster/reroute");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterRerouteDispatchAsync<T>(ElasticsearchPathInfo<ClusterRerouteQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_cluster/reroute
					if (body != null)
						return this.Raw.ClusterRerouteAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterReroute() into any of the following paths: \r\n - /_cluster/reroute");
		}
		
		
		internal ElasticsearchResponse<T> ClusterStateDispatch<T>(ElasticsearchPathInfo<ClusterStateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/state/{metric}/{index}
					if (!pathInfo.Metric.IsNullOrEmpty() && !pathInfo.Index.IsNullOrEmpty())
						return this.Raw.ClusterState<T>(pathInfo.Metric,pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/state/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.ClusterState<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/state
					return this.Raw.ClusterState<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterState() into any of the following paths: \r\n - /_cluster/state\r\n - /_cluster/state/{metric}\r\n - /_cluster/state/{metric}/{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterStateDispatchAsync<T>(ElasticsearchPathInfo<ClusterStateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/state/{metric}/{index}
					if (!pathInfo.Metric.IsNullOrEmpty() && !pathInfo.Index.IsNullOrEmpty())
						return this.Raw.ClusterStateAsync<T>(pathInfo.Metric,pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/state/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.ClusterStateAsync<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/state
					return this.Raw.ClusterStateAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterState() into any of the following paths: \r\n - /_cluster/state\r\n - /_cluster/state/{metric}\r\n - /_cluster/state/{metric}/{index}");
		}
		
		
		internal ElasticsearchResponse<T> ClusterStatsDispatch<T>(ElasticsearchPathInfo<ClusterStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/stats/nodes/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.ClusterStats<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/stats
					return this.Raw.ClusterStats<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterStats() into any of the following paths: \r\n - /_cluster/stats\r\n - /_cluster/stats/nodes/{node_id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ClusterStatsDispatchAsync<T>(ElasticsearchPathInfo<ClusterStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/stats/nodes/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.ClusterStatsAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/stats
					return this.Raw.ClusterStatsAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.ClusterStats() into any of the following paths: \r\n - /_cluster/stats\r\n - /_cluster/stats/nodes/{node_id}");
		}
		
		
		internal ElasticsearchResponse<T> CountDispatch<T>(ElasticsearchPathInfo<CountQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Count<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Count<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_count
					if (body != null)
						return this.Raw.Count<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.CountGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_count
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CountGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_count
					return this.Raw.CountGet<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Count() into any of the following paths: \r\n - /_count\r\n - /{index}/_count\r\n - /{index}/{type}/_count");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CountDispatchAsync<T>(ElasticsearchPathInfo<CountQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.CountAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.CountAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_count
					if (body != null)
						return this.Raw.CountAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.CountGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_count
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.CountGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_count
					return this.Raw.CountGetAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Count() into any of the following paths: \r\n - /_count\r\n - /{index}/_count\r\n - /{index}/{type}/_count");
		}
		
		
		internal ElasticsearchResponse<T> CountPercolateDispatch<T>(ElasticsearchPathInfo<CountPercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.CountPercolateGet<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/{type}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.CountPercolateGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.CountPercolate<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.CountPercolate<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.CountPercolate() into any of the following paths: \r\n - /{index}/{type}/_percolate/count\r\n - /{index}/{type}/{id}/_percolate/count");
		}
		
		
		internal Task<ElasticsearchResponse<T>> CountPercolateDispatchAsync<T>(ElasticsearchPathInfo<CountPercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.CountPercolateGetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/{type}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.CountPercolateGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.CountPercolateAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}/_percolate/count
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.CountPercolateAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.CountPercolate() into any of the following paths: \r\n - /{index}/{type}/_percolate/count\r\n - /{index}/{type}/{id}/_percolate/count");
		}
		
		
		internal ElasticsearchResponse<T> DeleteDispatch<T>(ElasticsearchPathInfo<DeleteQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.Delete<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Delete() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> DeleteDispatchAsync<T>(ElasticsearchPathInfo<DeleteQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.DeleteAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Delete() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal ElasticsearchResponse<T> DeleteByQueryDispatch<T>(ElasticsearchPathInfo<DeleteByQueryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/_query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.DeleteByQuery<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//DELETE /{index}/_query
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.DeleteByQuery<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.DeleteByQuery() into any of the following paths: \r\n - /{index}/_query\r\n - /{index}/{type}/_query");
		}
		
		
		internal Task<ElasticsearchResponse<T>> DeleteByQueryDispatchAsync<T>(ElasticsearchPathInfo<DeleteByQueryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/_query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.DeleteByQueryAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//DELETE /{index}/_query
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.DeleteByQueryAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.DeleteByQuery() into any of the following paths: \r\n - /{index}/_query\r\n - /{index}/{type}/_query");
		}
		
		
		internal ElasticsearchResponse<T> ExistsDispatch<T>(ElasticsearchPathInfo<ExistsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.Exists<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Exists() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ExistsDispatchAsync<T>(ElasticsearchPathInfo<ExistsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.ExistsAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Exists() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal ElasticsearchResponse<T> ExplainDispatch<T>(ElasticsearchPathInfo<ExplainQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_explain
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.ExplainGet<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_explain
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Explain<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Explain() into any of the following paths: \r\n - /{index}/{type}/{id}/_explain");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ExplainDispatchAsync<T>(ElasticsearchPathInfo<ExplainQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_explain
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.ExplainGetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_explain
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.ExplainAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Explain() into any of the following paths: \r\n - /{index}/{type}/{id}/_explain");
		}
		
		
		internal ElasticsearchResponse<T> GetDispatch<T>(ElasticsearchPathInfo<GetQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.Get<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Get() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> GetDispatchAsync<T>(ElasticsearchPathInfo<GetQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.GetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Get() into any of the following paths: \r\n - /{index}/{type}/{id}");
		}
		
		
		internal ElasticsearchResponse<T> GetSourceDispatch<T>(ElasticsearchPathInfo<SourceQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_source
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.GetSource<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.GetSource() into any of the following paths: \r\n - /{index}/{type}/{id}/_source");
		}
		
		
		internal Task<ElasticsearchResponse<T>> GetSourceDispatchAsync<T>(ElasticsearchPathInfo<SourceQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_source
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.GetSourceAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.GetSource() into any of the following paths: \r\n - /{index}/{type}/{id}/_source");
		}
		
		
		internal ElasticsearchResponse<T> IndexDispatch<T>(ElasticsearchPathInfo<IndexQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Index<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Index<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.IndexPut<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndexPut<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Index() into any of the following paths: \r\n - /{index}/{type}\r\n - /{index}/{type}/{id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndexDispatchAsync<T>(ElasticsearchPathInfo<IndexQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.IndexAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndexAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/{id}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.IndexPutAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndexPutAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Index() into any of the following paths: \r\n - /{index}/{type}\r\n - /{index}/{type}/{id}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesAnalyzeDispatch<T>(ElasticsearchPathInfo<AnalyzeQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_analyze
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesAnalyzeGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_analyze
					return this.Raw.IndicesAnalyzeGetForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/_analyze
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesAnalyze<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_analyze
					if (body != null)
						return this.Raw.IndicesAnalyzeForAll<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesAnalyze() into any of the following paths: \r\n - /_analyze\r\n - /{index}/_analyze");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesAnalyzeDispatchAsync<T>(ElasticsearchPathInfo<AnalyzeQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_analyze
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesAnalyzeGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_analyze
					return this.Raw.IndicesAnalyzeGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/_analyze
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesAnalyzeAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_analyze
					if (body != null)
						return this.Raw.IndicesAnalyzeForAllAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesAnalyze() into any of the following paths: \r\n - /_analyze\r\n - /{index}/_analyze");
		}
		
		
		internal ElasticsearchResponse<T> IndicesClearCacheDispatch<T>(ElasticsearchPathInfo<ClearCacheQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_cache/clear
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesClearCache<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_cache/clear
					return this.Raw.IndicesClearCacheForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_cache/clear
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesClearCacheGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cache/clear
					return this.Raw.IndicesClearCacheGetForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesClearCache() into any of the following paths: \r\n - /_cache/clear\r\n - /{index}/_cache/clear");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesClearCacheDispatchAsync<T>(ElasticsearchPathInfo<ClearCacheQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_cache/clear
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesClearCacheAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_cache/clear
					return this.Raw.IndicesClearCacheForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_cache/clear
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesClearCacheGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_cache/clear
					return this.Raw.IndicesClearCacheGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesClearCache() into any of the following paths: \r\n - /_cache/clear\r\n - /{index}/_cache/clear");
		}
		
		
		internal ElasticsearchResponse<T> IndicesCloseDispatch<T>(ElasticsearchPathInfo<CloseIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_close
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesClose<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesClose() into any of the following paths: \r\n - /{index}/_close");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesCloseDispatchAsync<T>(ElasticsearchPathInfo<CloseIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_close
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesCloseAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesClose() into any of the following paths: \r\n - /{index}/_close");
		}
		
		
		internal ElasticsearchResponse<T> IndicesCreateDispatch<T>(ElasticsearchPathInfo<CreateIndexQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesCreate<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesCreatePost<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesCreate() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesCreateDispatchAsync<T>(ElasticsearchPathInfo<CreateIndexQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesCreateAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesCreatePostAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesCreate() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesDeleteDispatch<T>(ElasticsearchPathInfo<DeleteIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesDelete<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDelete() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesDeleteDispatchAsync<T>(ElasticsearchPathInfo<DeleteIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesDeleteAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDelete() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesDeleteAliasDispatch<T>(ElasticsearchPathInfo<IndicesDeleteAliasQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteAlias<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteAlias() into any of the following paths: \r\n - /{index}/_alias/{name}\r\n - /{index}/_aliases/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesDeleteAliasDispatchAsync<T>(ElasticsearchPathInfo<IndicesDeleteAliasQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteAliasAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteAlias() into any of the following paths: \r\n - /{index}/_alias/{name}\r\n - /{index}/_aliases/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesDeleteMappingDispatch<T>(ElasticsearchPathInfo<DeleteMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesDeleteMapping<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteMapping() into any of the following paths: \r\n - /{index}/{type}/_mapping\r\n - /{index}/{type}\r\n - /{index}/_mapping/{type}\r\n - /{index}/{type}/_mappings\r\n - /{index}/_mappings/{type}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesDeleteMappingDispatchAsync<T>(ElasticsearchPathInfo<DeleteMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesDeleteMappingAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteMapping() into any of the following paths: \r\n - /{index}/{type}/_mapping\r\n - /{index}/{type}\r\n - /{index}/_mapping/{type}\r\n - /{index}/{type}/_mappings\r\n - /{index}/_mappings/{type}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesDeleteTemplateDispatch<T>(ElasticsearchPathInfo<DeleteTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteTemplateForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesDeleteTemplateDispatchAsync<T>(ElasticsearchPathInfo<DeleteTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteTemplateForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesDeleteWarmerDispatch<T>(ElasticsearchPathInfo<DeleteWarmerQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteWarmer<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteWarmer() into any of the following paths: \r\n - /{index}/_warmer/{name}\r\n - /{index}/_warmers/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesDeleteWarmerDispatchAsync<T>(ElasticsearchPathInfo<DeleteWarmerQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesDeleteWarmerAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesDeleteWarmer() into any of the following paths: \r\n - /{index}/_warmer/{name}\r\n - /{index}/_warmers/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesExistsDispatch<T>(ElasticsearchPathInfo<IndexExistsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesExists<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExists() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesExistsDispatchAsync<T>(ElasticsearchPathInfo<IndexExistsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesExistsAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExists() into any of the following paths: \r\n - /{index}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesExistsAliasDispatch<T>(ElasticsearchPathInfo<IndicesExistsAliasQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsAlias<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//HEAD /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsAliasForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//HEAD /{index}/_alias
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesExistsAlias<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsAlias() into any of the following paths: \r\n - /_alias/{name}\r\n - /{index}/_alias/{name}\r\n - /{index}/_alias");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesExistsAliasDispatchAsync<T>(ElasticsearchPathInfo<IndicesExistsAliasQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsAliasAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//HEAD /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsAliasForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//HEAD /{index}/_alias
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesExistsAliasAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsAlias() into any of the following paths: \r\n - /_alias/{name}\r\n - /{index}/_alias/{name}\r\n - /{index}/_alias");
		}
		
		
		internal ElasticsearchResponse<T> IndicesExistsTemplateDispatch<T>(ElasticsearchPathInfo<IndicesExistsTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsTemplateForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesExistsTemplateDispatchAsync<T>(ElasticsearchPathInfo<IndicesExistsTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesExistsTemplateForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesExistsTypeDispatch<T>(ElasticsearchPathInfo<IndicesExistsTypeQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesExistsType<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsType() into any of the following paths: \r\n - /{index}/{type}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesExistsTypeDispatchAsync<T>(ElasticsearchPathInfo<IndicesExistsTypeQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /{index}/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesExistsTypeAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesExistsType() into any of the following paths: \r\n - /{index}/{type}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesFlushDispatch<T>(ElasticsearchPathInfo<FlushQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_flush
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesFlush<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_flush
					return this.Raw.IndicesFlushForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_flush
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesFlushGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_flush
					return this.Raw.IndicesFlushGetForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesFlush() into any of the following paths: \r\n - /_flush\r\n - /{index}/_flush");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesFlushDispatchAsync<T>(ElasticsearchPathInfo<FlushQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_flush
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesFlushAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_flush
					return this.Raw.IndicesFlushForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_flush
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesFlushGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_flush
					return this.Raw.IndicesFlushGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesFlush() into any of the following paths: \r\n - /_flush\r\n - /{index}/_flush");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetAliasDispatch<T>(ElasticsearchPathInfo<GetAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAlias<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_alias
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetAlias<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_alias
					return this.Raw.IndicesGetAliasForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetAlias() into any of the following paths: \r\n - /_alias\r\n - /_alias/{name}\r\n - /{index}/_alias/{name}\r\n - /{index}/_alias");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetAliasDispatchAsync<T>(ElasticsearchPathInfo<GetAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_alias
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_alias
					return this.Raw.IndicesGetAliasForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetAlias() into any of the following paths: \r\n - /_alias\r\n - /_alias/{name}\r\n - /{index}/_alias/{name}\r\n - /{index}/_alias");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetAliasesDispatch<T>(ElasticsearchPathInfo<IndicesGetAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_aliases/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliases<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_aliases
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetAliases<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_aliases/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasesForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_aliases
					return this.Raw.IndicesGetAliasesForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetAliases() into any of the following paths: \r\n - /_aliases\r\n - /{index}/_aliases\r\n - /{index}/_aliases/{name}\r\n - /_aliases/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetAliasesDispatchAsync<T>(ElasticsearchPathInfo<IndicesGetAliasesQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_aliases/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasesAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_aliases
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasesAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_aliases/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetAliasesForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_aliases
					return this.Raw.IndicesGetAliasesForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetAliases() into any of the following paths: \r\n - /_aliases\r\n - /{index}/_aliases\r\n - /{index}/_aliases/{name}\r\n - /_aliases/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetFieldMappingDispatch<T>(ElasticsearchPathInfo<IndicesGetFieldMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_mapping/{type}/field/{field}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMapping<T>(pathInfo.Index,pathInfo.Type,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mapping/field/{field}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMapping<T>(pathInfo.Index,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/{type}/field/{field}
					if (!pathInfo.Type.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingForAll<T>(pathInfo.Type,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/field/{field}
					if (!pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingForAll<T>(pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetFieldMapping() into any of the following paths: \r\n - /_mapping/field/{field}\r\n - /{index}/_mapping/field/{field}\r\n - /_mapping/{type}/field/{field}\r\n - /{index}/_mapping/{type}/field/{field}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetFieldMappingDispatchAsync<T>(ElasticsearchPathInfo<IndicesGetFieldMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_mapping/{type}/field/{field}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mapping/field/{field}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingAsync<T>(pathInfo.Index,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/{type}/field/{field}
					if (!pathInfo.Type.IsNullOrEmpty() && !pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingForAllAsync<T>(pathInfo.Type,pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/field/{field}
					if (!pathInfo.Field.IsNullOrEmpty())
						return this.Raw.IndicesGetFieldMappingForAllAsync<T>(pathInfo.Field,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetFieldMapping() into any of the following paths: \r\n - /_mapping/field/{field}\r\n - /{index}/_mapping/field/{field}\r\n - /_mapping/{type}/field/{field}\r\n - /{index}/_mapping/{type}/field/{field}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetMappingDispatch<T>(ElasticsearchPathInfo<GetMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_mapping/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesGetMapping<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetMapping<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesGetMappingForAll<T>(pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping
					return this.Raw.IndicesGetMappingForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetMapping() into any of the following paths: \r\n - /_mapping\r\n - /{index}/_mapping\r\n - /_mapping/{type}\r\n - /{index}/_mapping/{type}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetMappingDispatchAsync<T>(ElasticsearchPathInfo<GetMappingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_mapping/{type}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesGetMappingAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetMappingAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesGetMappingForAllAsync<T>(pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /_mapping
					return this.Raw.IndicesGetMappingForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetMapping() into any of the following paths: \r\n - /_mapping\r\n - /{index}/_mapping\r\n - /_mapping/{type}\r\n - /{index}/_mapping/{type}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetSettingsDispatch<T>(ElasticsearchPathInfo<GetIndexSettingsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_settings/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetSettings<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_settings
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetSettings<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_settings/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetSettingsForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_settings
					return this.Raw.IndicesGetSettingsForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetSettings() into any of the following paths: \r\n - /_settings\r\n - /{index}/_settings\r\n - /{index}/_settings/{name}\r\n - /_settings/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetSettingsDispatchAsync<T>(ElasticsearchPathInfo<GetIndexSettingsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_settings/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetSettingsAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_settings
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetSettingsAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_settings/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetSettingsForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_settings
					return this.Raw.IndicesGetSettingsForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetSettings() into any of the following paths: \r\n - /_settings\r\n - /{index}/_settings\r\n - /{index}/_settings/{name}\r\n - /_settings/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetTemplateDispatch<T>(ElasticsearchPathInfo<GetTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetTemplateForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_template
					return this.Raw.IndicesGetTemplateForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetTemplate() into any of the following paths: \r\n - /_template\r\n - /_template/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetTemplateDispatchAsync<T>(ElasticsearchPathInfo<GetTemplateQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetTemplateForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_template
					return this.Raw.IndicesGetTemplateForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetTemplate() into any of the following paths: \r\n - /_template\r\n - /_template/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesGetWarmerDispatch<T>(ElasticsearchPathInfo<GetWarmerQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmer<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmer<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_warmer
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmer<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmerForAll<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_warmer
					return this.Raw.IndicesGetWarmerForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetWarmer() into any of the following paths: \r\n - /_warmer\r\n - /{index}/_warmer\r\n - /{index}/_warmer/{name}\r\n - /_warmer/{name}\r\n - /{index}/{type}/_warmer/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesGetWarmerDispatchAsync<T>(ElasticsearchPathInfo<GetWarmerQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmerAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmerAsync<T>(pathInfo.Index,pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_warmer
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmerAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty())
						return this.Raw.IndicesGetWarmerForAllAsync<T>(pathInfo.Name,u => pathInfo.QueryString, deserializationState);
					//GET /_warmer
					return this.Raw.IndicesGetWarmerForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesGetWarmer() into any of the following paths: \r\n - /_warmer\r\n - /{index}/_warmer\r\n - /{index}/_warmer/{name}\r\n - /_warmer/{name}\r\n - /{index}/{type}/_warmer/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesOpenDispatch<T>(ElasticsearchPathInfo<OpenIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_open
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOpen<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesOpen() into any of the following paths: \r\n - /{index}/_open");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesOpenDispatchAsync<T>(ElasticsearchPathInfo<OpenIndexQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_open
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOpenAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesOpen() into any of the following paths: \r\n - /{index}/_open");
		}
		
		
		internal ElasticsearchResponse<T> IndicesOptimizeDispatch<T>(ElasticsearchPathInfo<OptimizeQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_optimize
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOptimize<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_optimize
					return this.Raw.IndicesOptimizeForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_optimize
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOptimizeGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_optimize
					return this.Raw.IndicesOptimizeGetForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesOptimize() into any of the following paths: \r\n - /_optimize\r\n - /{index}/_optimize");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesOptimizeDispatchAsync<T>(ElasticsearchPathInfo<OptimizeQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_optimize
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOptimizeAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_optimize
					return this.Raw.IndicesOptimizeForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_optimize
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesOptimizeGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_optimize
					return this.Raw.IndicesOptimizeGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesOptimize() into any of the following paths: \r\n - /_optimize\r\n - /{index}/_optimize");
		}
		
		
		internal ElasticsearchResponse<T> IndicesPutAliasDispatch<T>(ElasticsearchPathInfo<IndicesPutAliasQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAlias<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasPost<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasPostForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutAlias() into any of the following paths: \r\n - /{index}/_alias/{name}\r\n - /_alias/{name}\r\n - /{index}/_aliases/{name}\r\n - /_aliases/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesPutAliasDispatchAsync<T>(ElasticsearchPathInfo<IndicesPutAliasQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasAsync<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/_alias/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasPostAsync<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /_alias/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutAliasPostForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutAlias() into any of the following paths: \r\n - /{index}/_alias/{name}\r\n - /_alias/{name}\r\n - /{index}/_aliases/{name}\r\n - /_aliases/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesPutMappingDispatch<T>(ElasticsearchPathInfo<PutMappingQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMapping<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingForAll<T>(pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingPost<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingPostForAll<T>(pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutMapping() into any of the following paths: \r\n - /{index}/{type}/_mapping\r\n - /{index}/_mapping/{type}\r\n - /_mapping/{type}\r\n - /{index}/{type}/_mappings\r\n - /{index}/_mappings/{type}\r\n - /_mappings/{type}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesPutMappingDispatchAsync<T>(ElasticsearchPathInfo<PutMappingQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingForAllAsync<T>(pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mapping
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingPostAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mapping/{type}
					if (!pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutMappingPostForAllAsync<T>(pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutMapping() into any of the following paths: \r\n - /{index}/{type}/_mapping\r\n - /{index}/_mapping/{type}\r\n - /_mapping/{type}\r\n - /{index}/{type}/_mappings\r\n - /{index}/_mappings/{type}\r\n - /_mappings/{type}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesPutSettingsDispatch<T>(ElasticsearchPathInfo<UpdateSettingsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/_settings
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutSettings<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_settings
					if (body != null)
						return this.Raw.IndicesPutSettingsForAll<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutSettings() into any of the following paths: \r\n - /_settings\r\n - /{index}/_settings");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesPutSettingsDispatchAsync<T>(ElasticsearchPathInfo<UpdateSettingsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/_settings
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutSettingsAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_settings
					if (body != null)
						return this.Raw.IndicesPutSettingsForAllAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutSettings() into any of the following paths: \r\n - /_settings\r\n - /{index}/_settings");
		}
		
		
		internal ElasticsearchResponse<T> IndicesPutTemplateDispatch<T>(ElasticsearchPathInfo<PutTemplateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutTemplateForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutTemplatePostForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesPutTemplateDispatchAsync<T>(ElasticsearchPathInfo<PutTemplateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutTemplateForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_template/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutTemplatePostForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutTemplate() into any of the following paths: \r\n - /_template/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesPutWarmerDispatch<T>(ElasticsearchPathInfo<PutWarmerQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmer<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmer<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPost<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPost<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPostForAll<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutWarmer() into any of the following paths: \r\n - /_warmer/{name}\r\n - /{index}/_warmer/{name}\r\n - /{index}/{type}/_warmer/{name}\r\n - /_warmers/{name}\r\n - /{index}/_warmers/{name}\r\n - /{index}/{type}/_warmers/{name}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesPutWarmerDispatchAsync<T>(ElasticsearchPathInfo<PutWarmerQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerAsync<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//PUT /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPostAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_warmer/{name}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPostAsync<T>(pathInfo.Index,pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					//POST /_warmer/{name}
					if (!pathInfo.Name.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesPutWarmerPostForAllAsync<T>(pathInfo.Name,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesPutWarmer() into any of the following paths: \r\n - /_warmer/{name}\r\n - /{index}/_warmer/{name}\r\n - /{index}/{type}/_warmer/{name}\r\n - /_warmers/{name}\r\n - /{index}/_warmers/{name}\r\n - /{index}/{type}/_warmers/{name}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesRefreshDispatch<T>(ElasticsearchPathInfo<RefreshQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_refresh
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesRefresh<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_refresh
					return this.Raw.IndicesRefreshForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_refresh
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesRefreshGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_refresh
					return this.Raw.IndicesRefreshGetForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesRefresh() into any of the following paths: \r\n - /_refresh\r\n - /{index}/_refresh");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesRefreshDispatchAsync<T>(ElasticsearchPathInfo<RefreshQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_refresh
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesRefreshAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_refresh
					return this.Raw.IndicesRefreshForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.GET:
					//GET /{index}/_refresh
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesRefreshGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_refresh
					return this.Raw.IndicesRefreshGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesRefresh() into any of the following paths: \r\n - /_refresh\r\n - /{index}/_refresh");
		}
		
		
		internal ElasticsearchResponse<T> IndicesSegmentsDispatch<T>(ElasticsearchPathInfo<SegmentsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_segments
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesSegments<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_segments
					return this.Raw.IndicesSegmentsForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesSegments() into any of the following paths: \r\n - /_segments\r\n - /{index}/_segments");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesSegmentsDispatchAsync<T>(ElasticsearchPathInfo<SegmentsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_segments
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesSegmentsAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_segments
					return this.Raw.IndicesSegmentsForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesSegments() into any of the following paths: \r\n - /_segments\r\n - /{index}/_segments");
		}
		
		
		internal ElasticsearchResponse<T> IndicesSnapshotIndexDispatch<T>(ElasticsearchPathInfo<SnapshotQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_gateway/snapshot
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesSnapshotIndex<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_gateway/snapshot
					return this.Raw.IndicesSnapshotIndexForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesSnapshotIndex() into any of the following paths: \r\n - /_gateway/snapshot\r\n - /{index}/_gateway/snapshot");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesSnapshotIndexDispatchAsync<T>(ElasticsearchPathInfo<SnapshotQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_gateway/snapshot
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesSnapshotIndexAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//POST /_gateway/snapshot
					return this.Raw.IndicesSnapshotIndexForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesSnapshotIndex() into any of the following paths: \r\n - /_gateway/snapshot\r\n - /{index}/_gateway/snapshot");
		}
		
		
		internal ElasticsearchResponse<T> IndicesStatsDispatch<T>(ElasticsearchPathInfo<IndicesStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_stats/{metric}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.IndicesStats<T>(pathInfo.Index,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_stats/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.IndicesStatsForAll<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_stats
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesStats<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_stats
					return this.Raw.IndicesStatsForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesStats() into any of the following paths: \r\n - /_stats\r\n - /_stats/{metric}\r\n - /{index}/_stats\r\n - /{index}/_stats/{metric}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesStatsDispatchAsync<T>(ElasticsearchPathInfo<IndicesStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_stats/{metric}
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.IndicesStatsAsync<T>(pathInfo.Index,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_stats/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.IndicesStatsForAllAsync<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_stats
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesStatsAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_stats
					return this.Raw.IndicesStatsForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesStats() into any of the following paths: \r\n - /_stats\r\n - /_stats/{metric}\r\n - /{index}/_stats\r\n - /{index}/_stats/{metric}");
		}
		
		
		internal ElasticsearchResponse<T> IndicesStatusDispatch<T>(ElasticsearchPathInfo<IndicesStatusQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_status
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesStatus<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_status
					return this.Raw.IndicesStatusForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesStatus() into any of the following paths: \r\n - /_status\r\n - /{index}/_status");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesStatusDispatchAsync<T>(ElasticsearchPathInfo<IndicesStatusQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/_status
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesStatusAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_status
					return this.Raw.IndicesStatusForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesStatus() into any of the following paths: \r\n - /_status\r\n - /{index}/_status");
		}
		
		
		internal ElasticsearchResponse<T> IndicesUpdateAliasesDispatch<T>(ElasticsearchPathInfo<AliasQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_aliases
					if (body != null)
						return this.Raw.IndicesUpdateAliasesForAll<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesUpdateAliases() into any of the following paths: \r\n - /_aliases");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesUpdateAliasesDispatchAsync<T>(ElasticsearchPathInfo<AliasQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_aliases
					if (body != null)
						return this.Raw.IndicesUpdateAliasesForAllAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesUpdateAliases() into any of the following paths: \r\n - /_aliases");
		}
		
		
		internal ElasticsearchResponse<T> IndicesValidateQueryDispatch<T>(ElasticsearchPathInfo<ValidateQueryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesValidateQueryGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesValidateQueryGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_validate/query
					return this.Raw.IndicesValidateQueryGetForAll<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesValidateQuery<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesValidateQuery<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_validate/query
					if (body != null)
						return this.Raw.IndicesValidateQueryForAll<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesValidateQuery() into any of the following paths: \r\n - /_validate/query\r\n - /{index}/_validate/query\r\n - /{index}/{type}/_validate/query");
		}
		
		
		internal Task<ElasticsearchResponse<T>> IndicesValidateQueryDispatchAsync<T>(ElasticsearchPathInfo<ValidateQueryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.IndicesValidateQueryGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.IndicesValidateQueryGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_validate/query
					return this.Raw.IndicesValidateQueryGetForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesValidateQueryAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_validate/query
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.IndicesValidateQueryAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_validate/query
					if (body != null)
						return this.Raw.IndicesValidateQueryForAllAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.IndicesValidateQuery() into any of the following paths: \r\n - /_validate/query\r\n - /{index}/_validate/query\r\n - /{index}/{type}/_validate/query");
		}
		
		
		internal ElasticsearchResponse<T> InfoDispatch<T>(ElasticsearchPathInfo<InfoQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /
					return this.Raw.Info<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Info() into any of the following paths: \r\n - /");
		}
		
		
		internal Task<ElasticsearchResponse<T>> InfoDispatchAsync<T>(ElasticsearchPathInfo<InfoQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /
					return this.Raw.InfoAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Info() into any of the following paths: \r\n - /");
		}
		
		
		internal ElasticsearchResponse<T> MgetDispatch<T>(ElasticsearchPathInfo<MultiGetQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MgetGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mget
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MgetGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mget
					return this.Raw.MgetGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Mget<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Mget<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mget
					if (body != null)
						return this.Raw.Mget<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mget() into any of the following paths: \r\n - /_mget\r\n - /{index}/_mget\r\n - /{index}/{type}/_mget");
		}
		
		
		internal Task<ElasticsearchResponse<T>> MgetDispatchAsync<T>(ElasticsearchPathInfo<MultiGetQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MgetGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mget
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MgetGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mget
					return this.Raw.MgetGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.MgetAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mget
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.MgetAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mget
					if (body != null)
						return this.Raw.MgetAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mget() into any of the following paths: \r\n - /_mget\r\n - /{index}/_mget\r\n - /{index}/{type}/_mget");
		}
		
		
		internal ElasticsearchResponse<T> MltDispatch<T>(ElasticsearchPathInfo<MoreLikeThisQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_mlt
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.MltGet<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_mlt
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Mlt<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mlt() into any of the following paths: \r\n - /{index}/{type}/{id}/_mlt");
		}
		
		
		internal Task<ElasticsearchResponse<T>> MltDispatchAsync<T>(ElasticsearchPathInfo<MoreLikeThisQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_mlt
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.MltGetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_mlt
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.MltAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mlt() into any of the following paths: \r\n - /{index}/{type}/{id}/_mlt");
		}
		
		
		internal ElasticsearchResponse<T> MpercolateDispatch<T>(ElasticsearchPathInfo<MpercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MpercolateGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MpercolateGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mpercolate
					return this.Raw.MpercolateGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Mpercolate<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Mpercolate<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mpercolate
					if (body != null)
						return this.Raw.Mpercolate<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mpercolate() into any of the following paths: \r\n - /_mpercolate\r\n - /{index}/_mpercolate\r\n - /{index}/{type}/_mpercolate");
		}
		
		
		internal Task<ElasticsearchResponse<T>> MpercolateDispatchAsync<T>(ElasticsearchPathInfo<MpercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MpercolateGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MpercolateGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mpercolate
					return this.Raw.MpercolateGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.MpercolateAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mpercolate
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.MpercolateAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mpercolate
					if (body != null)
						return this.Raw.MpercolateAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mpercolate() into any of the following paths: \r\n - /_mpercolate\r\n - /{index}/_mpercolate\r\n - /{index}/{type}/_mpercolate");
		}
		
		
		internal ElasticsearchResponse<T> MsearchDispatch<T>(ElasticsearchPathInfo<MultiSearchQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MsearchGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MsearchGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_msearch
					return this.Raw.MsearchGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Msearch<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Msearch<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_msearch
					if (body != null)
						return this.Raw.Msearch<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Msearch() into any of the following paths: \r\n - /_msearch\r\n - /{index}/_msearch\r\n - /{index}/{type}/_msearch");
		}
		
		
		internal Task<ElasticsearchResponse<T>> MsearchDispatchAsync<T>(ElasticsearchPathInfo<MultiSearchQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MsearchGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MsearchGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_msearch
					return this.Raw.MsearchGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.MsearchAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_msearch
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.MsearchAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_msearch
					if (body != null)
						return this.Raw.MsearchAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Msearch() into any of the following paths: \r\n - /_msearch\r\n - /{index}/_msearch\r\n - /{index}/{type}/_msearch");
		}
		
		
		internal ElasticsearchResponse<T> MtermvectorsDispatch<T>(ElasticsearchPathInfo<MtermvectorsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MtermvectorsGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MtermvectorsGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mtermvectors
					return this.Raw.MtermvectorsGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Mtermvectors<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Mtermvectors<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mtermvectors
					if (body != null)
						return this.Raw.Mtermvectors<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mtermvectors() into any of the following paths: \r\n - /_mtermvectors\r\n - /{index}/_mtermvectors\r\n - /{index}/{type}/_mtermvectors");
		}
		
		
		internal Task<ElasticsearchResponse<T>> MtermvectorsDispatchAsync<T>(ElasticsearchPathInfo<MtermvectorsQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.MtermvectorsGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.MtermvectorsGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_mtermvectors
					return this.Raw.MtermvectorsGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.MtermvectorsAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_mtermvectors
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.MtermvectorsAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_mtermvectors
					if (body != null)
						return this.Raw.MtermvectorsAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Mtermvectors() into any of the following paths: \r\n - /_mtermvectors\r\n - /{index}/_mtermvectors\r\n - /{index}/{type}/_mtermvectors");
		}
		
		
		internal ElasticsearchResponse<T> NodesHotThreadsDispatch<T>(ElasticsearchPathInfo<NodesHotThreadsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/nodes/{node_id}/hotthreads
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesHotThreads<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/nodes/hotthreads
					return this.Raw.NodesHotThreadsForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesHotThreads() into any of the following paths: \r\n - /_cluster/nodes/hotthreads\r\n - /_cluster/nodes/hot_threads\r\n - /_cluster/nodes/{node_id}/hotthreads\r\n - /_cluster/nodes/{node_id}/hot_threads\r\n - /_nodes/hotthreads\r\n - /_nodes/hot_threads\r\n - /_nodes/{node_id}/hotthreads\r\n - /_nodes/{node_id}/hot_threads");
		}
		
		
		internal Task<ElasticsearchResponse<T>> NodesHotThreadsDispatchAsync<T>(ElasticsearchPathInfo<NodesHotThreadsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_cluster/nodes/{node_id}/hotthreads
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesHotThreadsAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_cluster/nodes/hotthreads
					return this.Raw.NodesHotThreadsForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesHotThreads() into any of the following paths: \r\n - /_cluster/nodes/hotthreads\r\n - /_cluster/nodes/hot_threads\r\n - /_cluster/nodes/{node_id}/hotthreads\r\n - /_cluster/nodes/{node_id}/hot_threads\r\n - /_nodes/hotthreads\r\n - /_nodes/hot_threads\r\n - /_nodes/{node_id}/hotthreads\r\n - /_nodes/{node_id}/hot_threads");
		}
		
		
		internal ElasticsearchResponse<T> NodesInfoDispatch<T>(ElasticsearchPathInfo<NodesInfoQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_nodes/{node_id}/{metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesInfo<T>(pathInfo.NodeId,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesInfo<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesInfoForAll<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes
					return this.Raw.NodesInfoForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesInfo() into any of the following paths: \r\n - /_nodes\r\n - /_nodes/{node_id}\r\n - /_nodes/{metric}\r\n - /_nodes/{node_id}/{metric}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> NodesInfoDispatchAsync<T>(ElasticsearchPathInfo<NodesInfoQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_nodes/{node_id}/{metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesInfoAsync<T>(pathInfo.NodeId,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesInfoAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesInfoForAllAsync<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes
					return this.Raw.NodesInfoForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesInfo() into any of the following paths: \r\n - /_nodes\r\n - /_nodes/{node_id}\r\n - /_nodes/{metric}\r\n - /_nodes/{node_id}/{metric}");
		}
		
		
		internal ElasticsearchResponse<T> NodesShutdownDispatch<T>(ElasticsearchPathInfo<NodesShutdownQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_cluster/nodes/{node_id}/_shutdown
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesShutdown<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//POST /_shutdown
					return this.Raw.NodesShutdownForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesShutdown() into any of the following paths: \r\n - /_shutdown\r\n - /_cluster/nodes/_shutdown\r\n - /_cluster/nodes/{node_id}/_shutdown");
		}
		
		
		internal Task<ElasticsearchResponse<T>> NodesShutdownDispatchAsync<T>(ElasticsearchPathInfo<NodesShutdownQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_cluster/nodes/{node_id}/_shutdown
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesShutdownAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//POST /_shutdown
					return this.Raw.NodesShutdownForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesShutdown() into any of the following paths: \r\n - /_shutdown\r\n - /_cluster/nodes/_shutdown\r\n - /_cluster/nodes/{node_id}/_shutdown");
		}
		
		
		internal ElasticsearchResponse<T> NodesStatsDispatch<T>(ElasticsearchPathInfo<NodesStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_nodes/{node_id}/stats/{metric}/{index_metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty() && !pathInfo.IndexMetric.IsNullOrEmpty())
						return this.Raw.NodesStats<T>(pathInfo.NodeId,pathInfo.Metric,pathInfo.IndexMetric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}/stats/{metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesStats<T>(pathInfo.NodeId,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats/{metric}/{index_metric}
					if (!pathInfo.Metric.IsNullOrEmpty() && !pathInfo.IndexMetric.IsNullOrEmpty())
						return this.Raw.NodesStatsForAll<T>(pathInfo.Metric,pathInfo.IndexMetric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}/stats
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesStats<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesStatsForAll<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats
					return this.Raw.NodesStatsForAll<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesStats() into any of the following paths: \r\n - /_nodes/stats\r\n - /_nodes/{node_id}/stats\r\n - /_nodes/stats/{metric}\r\n - /_nodes/{node_id}/stats/{metric}\r\n - /_nodes/stats/{metric}/{index_metric}\r\n - /_nodes/{node_id}/stats/{metric}/{index_metric}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> NodesStatsDispatchAsync<T>(ElasticsearchPathInfo<NodesStatsQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_nodes/{node_id}/stats/{metric}/{index_metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty() && !pathInfo.IndexMetric.IsNullOrEmpty())
						return this.Raw.NodesStatsAsync<T>(pathInfo.NodeId,pathInfo.Metric,pathInfo.IndexMetric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}/stats/{metric}
					if (!pathInfo.NodeId.IsNullOrEmpty() && !pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesStatsAsync<T>(pathInfo.NodeId,pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats/{metric}/{index_metric}
					if (!pathInfo.Metric.IsNullOrEmpty() && !pathInfo.IndexMetric.IsNullOrEmpty())
						return this.Raw.NodesStatsForAllAsync<T>(pathInfo.Metric,pathInfo.IndexMetric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/{node_id}/stats
					if (!pathInfo.NodeId.IsNullOrEmpty())
						return this.Raw.NodesStatsAsync<T>(pathInfo.NodeId,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats/{metric}
					if (!pathInfo.Metric.IsNullOrEmpty())
						return this.Raw.NodesStatsForAllAsync<T>(pathInfo.Metric,u => pathInfo.QueryString, deserializationState);
					//GET /_nodes/stats
					return this.Raw.NodesStatsForAllAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.NodesStats() into any of the following paths: \r\n - /_nodes/stats\r\n - /_nodes/{node_id}/stats\r\n - /_nodes/stats/{metric}\r\n - /_nodes/{node_id}/stats/{metric}\r\n - /_nodes/stats/{metric}/{index_metric}\r\n - /_nodes/{node_id}/stats/{metric}/{index_metric}");
		}
		
		
		internal ElasticsearchResponse<T> PercolateDispatch<T>(ElasticsearchPathInfo<PercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.PercolateGet<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/{type}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.PercolateGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Percolate<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Percolate<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Percolate() into any of the following paths: \r\n - /{index}/{type}/_percolate\r\n - /{index}/{type}/{id}/_percolate");
		}
		
		
		internal Task<ElasticsearchResponse<T>> PercolateDispatchAsync<T>(ElasticsearchPathInfo<PercolateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.PercolateGetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/{type}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.PercolateGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.PercolateAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/{type}/_percolate
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.PercolateAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Percolate() into any of the following paths: \r\n - /{index}/{type}/_percolate\r\n - /{index}/{type}/{id}/_percolate");
		}
		
		
		internal ElasticsearchResponse<T> PingDispatch<T>(ElasticsearchPathInfo<PingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /
					return this.Raw.Ping<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Ping() into any of the following paths: \r\n - /");
		}
		
		
		internal Task<ElasticsearchResponse<T>> PingDispatchAsync<T>(ElasticsearchPathInfo<PingQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.HEAD:
					//HEAD /
					return this.Raw.PingAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Ping() into any of the following paths: \r\n - /");
		}
		
		
		internal ElasticsearchResponse<T> ScrollDispatch<T>(ElasticsearchPathInfo<ScrollQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty())
						return this.Raw.ScrollGet<T>(pathInfo.ScrollId,u => pathInfo.QueryString, deserializationState);
					//GET /_search/scroll
					return this.Raw.ScrollGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty() && body != null)
						return this.Raw.Scroll<T>(pathInfo.ScrollId,body,u => pathInfo.QueryString, deserializationState);
					//POST /_search/scroll
					if (body != null)
						return this.Raw.Scroll<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Scroll() into any of the following paths: \r\n - /_search/scroll\r\n - /_search/scroll/{scroll_id}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> ScrollDispatchAsync<T>(ElasticsearchPathInfo<ScrollQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty())
						return this.Raw.ScrollGetAsync<T>(pathInfo.ScrollId,u => pathInfo.QueryString, deserializationState);
					//GET /_search/scroll
					return this.Raw.ScrollGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /_search/scroll/{scroll_id}
					if (!pathInfo.ScrollId.IsNullOrEmpty() && body != null)
						return this.Raw.ScrollAsync<T>(pathInfo.ScrollId,body,u => pathInfo.QueryString, deserializationState);
					//POST /_search/scroll
					if (body != null)
						return this.Raw.ScrollAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Scroll() into any of the following paths: \r\n - /_search/scroll\r\n - /_search/scroll/{scroll_id}");
		}
		
		
		internal ElasticsearchResponse<T> SearchDispatch<T>(ElasticsearchPathInfo<SearchQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.SearchGet<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_search
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.SearchGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_search
					return this.Raw.SearchGet<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.Search<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Search<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_search
					if (body != null)
						return this.Raw.Search<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Search() into any of the following paths: \r\n - /_search\r\n - /{index}/_search\r\n - /{index}/{type}/_search");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SearchDispatchAsync<T>(ElasticsearchPathInfo<SearchQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty())
						return this.Raw.SearchGetAsync<T>(pathInfo.Index,pathInfo.Type,u => pathInfo.QueryString, deserializationState);
					//GET /{index}/_search
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.SearchGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_search
					return this.Raw.SearchGetAsync<T>(u => pathInfo.QueryString, deserializationState);

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && body != null)
						return this.Raw.SearchAsync<T>(pathInfo.Index,pathInfo.Type,body,u => pathInfo.QueryString, deserializationState);
					//POST /{index}/_search
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.SearchAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_search
					if (body != null)
						return this.Raw.SearchAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Search() into any of the following paths: \r\n - /_search\r\n - /{index}/_search\r\n - /{index}/{type}/_search");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotCreateDispatch<T>(ElasticsearchPathInfo<SnapshotCreateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreate<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreatePost<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotCreate() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}\r\n - /_snapshot/{repository}/{snapshot}/_create");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotCreateDispatchAsync<T>(ElasticsearchPathInfo<SnapshotCreateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreateAsync<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreatePostAsync<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotCreate() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}\r\n - /_snapshot/{repository}/{snapshot}/_create");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotCreateRepositoryDispatch<T>(ElasticsearchPathInfo<SnapshotCreateRepositoryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreateRepository<T>(pathInfo.Repository,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreateRepositoryPost<T>(pathInfo.Repository,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotCreateRepository() into any of the following paths: \r\n - /_snapshot/{repository}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotCreateRepositoryDispatchAsync<T>(ElasticsearchPathInfo<SnapshotCreateRepositoryQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreateRepositoryAsync<T>(pathInfo.Repository,body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotCreateRepositoryPostAsync<T>(pathInfo.Repository,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotCreateRepository() into any of the following paths: \r\n - /_snapshot/{repository}");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotDeleteDispatch<T>(ElasticsearchPathInfo<SnapshotDeleteQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty())
						return this.Raw.SnapshotDelete<T>(pathInfo.Repository,pathInfo.Snapshot,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotDelete() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotDeleteDispatchAsync<T>(ElasticsearchPathInfo<SnapshotDeleteQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty())
						return this.Raw.SnapshotDeleteAsync<T>(pathInfo.Repository,pathInfo.Snapshot,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotDelete() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotDeleteRepositoryDispatch<T>(ElasticsearchPathInfo<SnapshotDeleteRepositoryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty())
						return this.Raw.SnapshotDeleteRepository<T>(pathInfo.Repository,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotDeleteRepository() into any of the following paths: \r\n - /_snapshot/{repository}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotDeleteRepositoryDispatchAsync<T>(ElasticsearchPathInfo<SnapshotDeleteRepositoryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty())
						return this.Raw.SnapshotDeleteRepositoryAsync<T>(pathInfo.Repository,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotDeleteRepository() into any of the following paths: \r\n - /_snapshot/{repository}");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotGetDispatch<T>(ElasticsearchPathInfo<SnapshotGetQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty())
						return this.Raw.SnapshotGet<T>(pathInfo.Repository,pathInfo.Snapshot,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotGet() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotGetDispatchAsync<T>(ElasticsearchPathInfo<SnapshotGetQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_snapshot/{repository}/{snapshot}
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty())
						return this.Raw.SnapshotGetAsync<T>(pathInfo.Repository,pathInfo.Snapshot,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotGet() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotGetRepositoryDispatch<T>(ElasticsearchPathInfo<SnapshotGetRepositoryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty())
						return this.Raw.SnapshotGetRepository<T>(pathInfo.Repository,u => pathInfo.QueryString, deserializationState);
					//GET /_snapshot
					return this.Raw.SnapshotGetRepository<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotGetRepository() into any of the following paths: \r\n - /_snapshot\r\n - /_snapshot/{repository}");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotGetRepositoryDispatchAsync<T>(ElasticsearchPathInfo<SnapshotGetRepositoryQueryString> pathInfo , object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_snapshot/{repository}
					if (!pathInfo.Repository.IsNullOrEmpty())
						return this.Raw.SnapshotGetRepositoryAsync<T>(pathInfo.Repository,u => pathInfo.QueryString, deserializationState);
					//GET /_snapshot
					return this.Raw.SnapshotGetRepositoryAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotGetRepository() into any of the following paths: \r\n - /_snapshot\r\n - /_snapshot/{repository}");
		}
		
		
		internal ElasticsearchResponse<T> SnapshotRestoreDispatch<T>(ElasticsearchPathInfo<SnapshotRestoreQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}/{snapshot}/_restore
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotRestore<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotRestore() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}/_restore");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SnapshotRestoreDispatchAsync<T>(ElasticsearchPathInfo<SnapshotRestoreQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /_snapshot/{repository}/{snapshot}/_restore
					if (!pathInfo.Repository.IsNullOrEmpty() && !pathInfo.Snapshot.IsNullOrEmpty() && body != null)
						return this.Raw.SnapshotRestoreAsync<T>(pathInfo.Repository,pathInfo.Snapshot,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.SnapshotRestore() into any of the following paths: \r\n - /_snapshot/{repository}/{snapshot}/_restore");
		}
		
		
		internal ElasticsearchResponse<T> SuggestDispatch<T>(ElasticsearchPathInfo<SuggestQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_suggest
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.Suggest<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_suggest
					if (body != null)
						return this.Raw.Suggest<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.GET:
					//GET /{index}/_suggest
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.SuggestGet<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_suggest
					return this.Raw.SuggestGet<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Suggest() into any of the following paths: \r\n - /_suggest\r\n - /{index}/_suggest");
		}
		
		
		internal Task<ElasticsearchResponse<T>> SuggestDispatchAsync<T>(ElasticsearchPathInfo<SuggestQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/_suggest
					if (!pathInfo.Index.IsNullOrEmpty() && body != null)
						return this.Raw.SuggestAsync<T>(pathInfo.Index,body,u => pathInfo.QueryString, deserializationState);
					//POST /_suggest
					if (body != null)
						return this.Raw.SuggestAsync<T>(body,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.GET:
					//GET /{index}/_suggest
					if (!pathInfo.Index.IsNullOrEmpty())
						return this.Raw.SuggestGetAsync<T>(pathInfo.Index,u => pathInfo.QueryString, deserializationState);
					//GET /_suggest
					return this.Raw.SuggestGetAsync<T>(u => pathInfo.QueryString, deserializationState);

			}
			throw new DispatchException("Could not dispatch IElasticClient.Suggest() into any of the following paths: \r\n - /_suggest\r\n - /{index}/_suggest");
		}
		
		
		internal ElasticsearchResponse<T> TermvectorDispatch<T>(ElasticsearchPathInfo<TermvectorQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_termvector
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.TermvectorGet<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_termvector
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Termvector<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Termvector() into any of the following paths: \r\n - /{index}/{type}/{id}/_termvector");
		}
		
		
		internal Task<ElasticsearchResponse<T>> TermvectorDispatchAsync<T>(ElasticsearchPathInfo<TermvectorQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /{index}/{type}/{id}/_termvector
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty())
						return this.Raw.TermvectorGetAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,u => pathInfo.QueryString, deserializationState);
					break;

				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_termvector
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.TermvectorAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Termvector() into any of the following paths: \r\n - /{index}/{type}/{id}/_termvector");
		}
		
		
		internal ElasticsearchResponse<T> UpdateDispatch<T>(ElasticsearchPathInfo<UpdateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_update
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.Update<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Update() into any of the following paths: \r\n - /{index}/{type}/{id}/_update");
		}
		
		
		internal Task<ElasticsearchResponse<T>> UpdateDispatchAsync<T>(ElasticsearchPathInfo<UpdateQueryString> pathInfo , object body, object deserializationState = null)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.POST:
					//POST /{index}/{type}/{id}/_update
					if (!pathInfo.Index.IsNullOrEmpty() && !pathInfo.Type.IsNullOrEmpty() && !pathInfo.Id.IsNullOrEmpty() && body != null)
						return this.Raw.UpdateAsync<T>(pathInfo.Index,pathInfo.Type,pathInfo.Id,body,u => pathInfo.QueryString, deserializationState);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.Update() into any of the following paths: \r\n - /{index}/{type}/{id}/_update");
		}
		
	}	
}
