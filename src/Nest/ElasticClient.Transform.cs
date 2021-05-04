/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
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
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.TransformApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace Nest.Specification.TransformApi
{
	///<summary>
	/// Transform APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticClient.Transform"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class TransformNamespace : NamespacedClientProxy
	{
		internal TransformNamespace(ElasticClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>transform.delete_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</a>
		/// </summary>
		public DeleteTransformResponse Delete(Id transformId, Func<DeleteTransformDescriptor, IDeleteTransformRequest> selector = null) => Delete(selector.InvokeOrDefault(new DeleteTransformDescriptor(transformId: transformId)));
		/// <summary>
		/// <c>DELETE</c> request to the <c>transform.delete_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</a>
		/// </summary>
		public Task<DeleteTransformResponse> DeleteAsync(Id transformId, Func<DeleteTransformDescriptor, IDeleteTransformRequest> selector = null, CancellationToken ct = default) => DeleteAsync(selector.InvokeOrDefault(new DeleteTransformDescriptor(transformId: transformId)), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>transform.delete_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</a>
		/// </summary>
		public DeleteTransformResponse Delete(IDeleteTransformRequest request) => DoRequest<IDeleteTransformRequest, DeleteTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>transform.delete_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</a>
		/// </summary>
		public Task<DeleteTransformResponse> DeleteAsync(IDeleteTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteTransformRequest, DeleteTransformResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</a>
		/// </summary>
		public GetTransformResponse Get(Func<GetTransformDescriptor, IGetTransformRequest> selector = null) => Get(selector.InvokeOrDefault(new GetTransformDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</a>
		/// </summary>
		public Task<GetTransformResponse> GetAsync(Func<GetTransformDescriptor, IGetTransformRequest> selector = null, CancellationToken ct = default) => GetAsync(selector.InvokeOrDefault(new GetTransformDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</a>
		/// </summary>
		public GetTransformResponse Get(IGetTransformRequest request) => DoRequest<IGetTransformRequest, GetTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</a>
		/// </summary>
		public Task<GetTransformResponse> GetAsync(IGetTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTransformRequest, GetTransformResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform_stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</a>
		/// </summary>
		public GetTransformStatsResponse GetStats(Id transformId, Func<GetTransformStatsDescriptor, IGetTransformStatsRequest> selector = null) => GetStats(selector.InvokeOrDefault(new GetTransformStatsDescriptor(transformId: transformId)));
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform_stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</a>
		/// </summary>
		public Task<GetTransformStatsResponse> GetStatsAsync(Id transformId, Func<GetTransformStatsDescriptor, IGetTransformStatsRequest> selector = null, CancellationToken ct = default) => GetStatsAsync(selector.InvokeOrDefault(new GetTransformStatsDescriptor(transformId: transformId)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform_stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</a>
		/// </summary>
		public GetTransformStatsResponse GetStats(IGetTransformStatsRequest request) => DoRequest<IGetTransformStatsRequest, GetTransformStatsResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>transform.get_transform_stats</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</a>
		/// </summary>
		public Task<GetTransformStatsResponse> GetStatsAsync(IGetTransformStatsRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTransformStatsRequest, GetTransformStatsResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.preview_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</a>
		/// </summary>
		public PreviewTransformResponse<TTransform> Preview<TDocument, TTransform>(Func<PreviewTransformDescriptor<TDocument>, IPreviewTransformRequest> selector)
			where TDocument : class => Preview<TTransform>(selector.InvokeOrDefault(new PreviewTransformDescriptor<TDocument>()));
		/// <summary>
		/// <c>POST</c> request to the <c>transform.preview_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</a>
		/// </summary>
		public Task<PreviewTransformResponse<TTransform>> PreviewAsync<TDocument, TTransform>(Func<PreviewTransformDescriptor<TDocument>, IPreviewTransformRequest> selector, CancellationToken ct = default)
			where TDocument : class => PreviewAsync<TTransform>(selector.InvokeOrDefault(new PreviewTransformDescriptor<TDocument>()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.preview_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</a>
		/// </summary>
		public PreviewTransformResponse<TTransform> Preview<TTransform>(IPreviewTransformRequest request) => DoRequest<IPreviewTransformRequest, PreviewTransformResponse<TTransform>>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.preview_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</a>
		/// </summary>
		public Task<PreviewTransformResponse<TTransform>> PreviewAsync<TTransform>(IPreviewTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IPreviewTransformRequest, PreviewTransformResponse<TTransform>>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>transform.put_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</a>
		/// </summary>
		public PutTransformResponse Put<TDocument>(Id transformId, Func<PutTransformDescriptor<TDocument>, IPutTransformRequest> selector)
			where TDocument : class => Put(selector.InvokeOrDefault(new PutTransformDescriptor<TDocument>(transformId: transformId)));
		/// <summary>
		/// <c>PUT</c> request to the <c>transform.put_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</a>
		/// </summary>
		public Task<PutTransformResponse> PutAsync<TDocument>(Id transformId, Func<PutTransformDescriptor<TDocument>, IPutTransformRequest> selector, CancellationToken ct = default)
			where TDocument : class => PutAsync(selector.InvokeOrDefault(new PutTransformDescriptor<TDocument>(transformId: transformId)), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>transform.put_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</a>
		/// </summary>
		public PutTransformResponse Put(IPutTransformRequest request) => DoRequest<IPutTransformRequest, PutTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>transform.put_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</a>
		/// </summary>
		public Task<PutTransformResponse> PutAsync(IPutTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IPutTransformRequest, PutTransformResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.start_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</a>
		/// </summary>
		public StartTransformResponse Start(Id transformId, Func<StartTransformDescriptor, IStartTransformRequest> selector = null) => Start(selector.InvokeOrDefault(new StartTransformDescriptor(transformId: transformId)));
		/// <summary>
		/// <c>POST</c> request to the <c>transform.start_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</a>
		/// </summary>
		public Task<StartTransformResponse> StartAsync(Id transformId, Func<StartTransformDescriptor, IStartTransformRequest> selector = null, CancellationToken ct = default) => StartAsync(selector.InvokeOrDefault(new StartTransformDescriptor(transformId: transformId)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.start_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</a>
		/// </summary>
		public StartTransformResponse Start(IStartTransformRequest request) => DoRequest<IStartTransformRequest, StartTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.start_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</a>
		/// </summary>
		public Task<StartTransformResponse> StartAsync(IStartTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IStartTransformRequest, StartTransformResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.stop_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</a>
		/// </summary>
		public StopTransformResponse Stop(Id transformId, Func<StopTransformDescriptor, IStopTransformRequest> selector = null) => Stop(selector.InvokeOrDefault(new StopTransformDescriptor(transformId: transformId)));
		/// <summary>
		/// <c>POST</c> request to the <c>transform.stop_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</a>
		/// </summary>
		public Task<StopTransformResponse> StopAsync(Id transformId, Func<StopTransformDescriptor, IStopTransformRequest> selector = null, CancellationToken ct = default) => StopAsync(selector.InvokeOrDefault(new StopTransformDescriptor(transformId: transformId)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.stop_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</a>
		/// </summary>
		public StopTransformResponse Stop(IStopTransformRequest request) => DoRequest<IStopTransformRequest, StopTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.stop_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</a>
		/// </summary>
		public Task<StopTransformResponse> StopAsync(IStopTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IStopTransformRequest, StopTransformResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.update_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</a>
		/// </summary>
		public UpdateTransformResponse Update<TDocument>(Id transformId, Func<UpdateTransformDescriptor<TDocument>, IUpdateTransformRequest> selector)
			where TDocument : class => Update(selector.InvokeOrDefault(new UpdateTransformDescriptor<TDocument>(transformId: transformId)));
		/// <summary>
		/// <c>POST</c> request to the <c>transform.update_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</a>
		/// </summary>
		public Task<UpdateTransformResponse> UpdateAsync<TDocument>(Id transformId, Func<UpdateTransformDescriptor<TDocument>, IUpdateTransformRequest> selector, CancellationToken ct = default)
			where TDocument : class => UpdateAsync(selector.InvokeOrDefault(new UpdateTransformDescriptor<TDocument>(transformId: transformId)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.update_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</a>
		/// </summary>
		public UpdateTransformResponse Update(IUpdateTransformRequest request) => DoRequest<IUpdateTransformRequest, UpdateTransformResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>transform.update_transform</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html">https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</a>
		/// </summary>
		public Task<UpdateTransformResponse> UpdateAsync(IUpdateTransformRequest request, CancellationToken ct = default) => DoRequestAsync<IUpdateTransformRequest, UpdateTransformResponse>(request, request.RequestParameters, ct);
	}
}