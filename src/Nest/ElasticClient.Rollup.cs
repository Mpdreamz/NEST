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
using Elasticsearch.Net.Specification.RollupApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace Nest.Specification.RollupApi
{
	///<summary>
	/// Rollup APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticClient.Rollup"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class RollupNamespace : NamespacedClientProxy
	{
		internal RollupNamespace(ElasticClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>rollup.delete_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html</a>
		/// </summary>
		public DeleteRollupJobResponse DeleteJob(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null) => DeleteJob(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id: id)));
		/// <summary>
		/// <c>DELETE</c> request to the <c>rollup.delete_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html</a>
		/// </summary>
		public Task<DeleteRollupJobResponse> DeleteJobAsync(Id id, Func<DeleteRollupJobDescriptor, IDeleteRollupJobRequest> selector = null, CancellationToken ct = default) => DeleteJobAsync(selector.InvokeOrDefault(new DeleteRollupJobDescriptor(id: id)), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>rollup.delete_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html</a>
		/// </summary>
		public DeleteRollupJobResponse DeleteJob(IDeleteRollupJobRequest request) => DoRequest<IDeleteRollupJobRequest, DeleteRollupJobResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>rollup.delete_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html</a>
		/// </summary>
		public Task<DeleteRollupJobResponse> DeleteJobAsync(IDeleteRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteRollupJobRequest, DeleteRollupJobResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_jobs</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html</a>
		/// </summary>
		public GetRollupJobResponse GetJob(Func<GetRollupJobDescriptor, IGetRollupJobRequest> selector = null) => GetJob(selector.InvokeOrDefault(new GetRollupJobDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_jobs</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html</a>
		/// </summary>
		public Task<GetRollupJobResponse> GetJobAsync(Func<GetRollupJobDescriptor, IGetRollupJobRequest> selector = null, CancellationToken ct = default) => GetJobAsync(selector.InvokeOrDefault(new GetRollupJobDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_jobs</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html</a>
		/// </summary>
		public GetRollupJobResponse GetJob(IGetRollupJobRequest request) => DoRequest<IGetRollupJobRequest, GetRollupJobResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_jobs</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html</a>
		/// </summary>
		public Task<GetRollupJobResponse> GetJobAsync(IGetRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupJobRequest, GetRollupJobResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html</a>
		/// </summary>
		public GetRollupCapabilitiesResponse GetCapabilities(Func<GetRollupCapabilitiesDescriptor, IGetRollupCapabilitiesRequest> selector = null) => GetCapabilities(selector.InvokeOrDefault(new GetRollupCapabilitiesDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html</a>
		/// </summary>
		public Task<GetRollupCapabilitiesResponse> GetCapabilitiesAsync(Func<GetRollupCapabilitiesDescriptor, IGetRollupCapabilitiesRequest> selector = null, CancellationToken ct = default) => GetCapabilitiesAsync(selector.InvokeOrDefault(new GetRollupCapabilitiesDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html</a>
		/// </summary>
		public GetRollupCapabilitiesResponse GetCapabilities(IGetRollupCapabilitiesRequest request) => DoRequest<IGetRollupCapabilitiesRequest, GetRollupCapabilitiesResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html</a>
		/// </summary>
		public Task<GetRollupCapabilitiesResponse> GetCapabilitiesAsync(IGetRollupCapabilitiesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupCapabilitiesRequest, GetRollupCapabilitiesResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_index_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html</a>
		/// </summary>
		public GetRollupIndexCapabilitiesResponse GetIndexCapabilities(IndexName index, Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null) => GetIndexCapabilities(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index: index)));
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_index_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html</a>
		/// </summary>
		public Task<GetRollupIndexCapabilitiesResponse> GetIndexCapabilitiesAsync(IndexName index, Func<GetRollupIndexCapabilitiesDescriptor, IGetRollupIndexCapabilitiesRequest> selector = null, CancellationToken ct = default) => GetIndexCapabilitiesAsync(selector.InvokeOrDefault(new GetRollupIndexCapabilitiesDescriptor(index: index)), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_index_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html</a>
		/// </summary>
		public GetRollupIndexCapabilitiesResponse GetIndexCapabilities(IGetRollupIndexCapabilitiesRequest request) => DoRequest<IGetRollupIndexCapabilitiesRequest, GetRollupIndexCapabilitiesResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>rollup.get_rollup_index_caps</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html</a>
		/// </summary>
		public Task<GetRollupIndexCapabilitiesResponse> GetIndexCapabilitiesAsync(IGetRollupIndexCapabilitiesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRollupIndexCapabilitiesRequest, GetRollupIndexCapabilitiesResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>rollup.put_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html</a>
		/// </summary>
		public CreateRollupJobResponse CreateJob<TDocument>(Id id, Func<CreateRollupJobDescriptor<TDocument>, ICreateRollupJobRequest> selector)
			where TDocument : class => CreateJob(selector.InvokeOrDefault(new CreateRollupJobDescriptor<TDocument>(id: id)));
		/// <summary>
		/// <c>PUT</c> request to the <c>rollup.put_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html</a>
		/// </summary>
		public Task<CreateRollupJobResponse> CreateJobAsync<TDocument>(Id id, Func<CreateRollupJobDescriptor<TDocument>, ICreateRollupJobRequest> selector, CancellationToken ct = default)
			where TDocument : class => CreateJobAsync(selector.InvokeOrDefault(new CreateRollupJobDescriptor<TDocument>(id: id)), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>rollup.put_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html</a>
		/// </summary>
		public CreateRollupJobResponse CreateJob(ICreateRollupJobRequest request) => DoRequest<ICreateRollupJobRequest, CreateRollupJobResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>rollup.put_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html</a>
		/// </summary>
		public Task<CreateRollupJobResponse> CreateJobAsync(ICreateRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateRollupJobRequest, CreateRollupJobResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.rollup_search</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html</a>
		/// </summary>
		public RollupSearchResponse<TDocument> Search<TDocument>(Func<RollupSearchDescriptor<TDocument>, IRollupSearchRequest> selector = null)
			where TDocument : class => Search<TDocument>(selector.InvokeOrDefault(new RollupSearchDescriptor<TDocument>()));
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.rollup_search</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html</a>
		/// </summary>
		public Task<RollupSearchResponse<TDocument>> SearchAsync<TDocument>(Func<RollupSearchDescriptor<TDocument>, IRollupSearchRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => SearchAsync<TDocument>(selector.InvokeOrDefault(new RollupSearchDescriptor<TDocument>()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.rollup_search</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html</a>
		/// </summary>
		public RollupSearchResponse<TDocument> Search<TDocument>(IRollupSearchRequest request)
			where TDocument : class => DoRequest<IRollupSearchRequest, RollupSearchResponse<TDocument>>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.rollup_search</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html</a>
		/// </summary>
		public Task<RollupSearchResponse<TDocument>> SearchAsync<TDocument>(IRollupSearchRequest request, CancellationToken ct = default)
			where TDocument : class => DoRequestAsync<IRollupSearchRequest, RollupSearchResponse<TDocument>>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.start_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html</a>
		/// </summary>
		public StartRollupJobResponse StartJob(Id id, Func<StartRollupJobDescriptor, IStartRollupJobRequest> selector = null) => StartJob(selector.InvokeOrDefault(new StartRollupJobDescriptor(id: id)));
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.start_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html</a>
		/// </summary>
		public Task<StartRollupJobResponse> StartJobAsync(Id id, Func<StartRollupJobDescriptor, IStartRollupJobRequest> selector = null, CancellationToken ct = default) => StartJobAsync(selector.InvokeOrDefault(new StartRollupJobDescriptor(id: id)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.start_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html</a>
		/// </summary>
		public StartRollupJobResponse StartJob(IStartRollupJobRequest request) => DoRequest<IStartRollupJobRequest, StartRollupJobResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.start_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html</a>
		/// </summary>
		public Task<StartRollupJobResponse> StartJobAsync(IStartRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IStartRollupJobRequest, StartRollupJobResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.stop_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html</a>
		/// </summary>
		public StopRollupJobResponse StopJob(Id id, Func<StopRollupJobDescriptor, IStopRollupJobRequest> selector = null) => StopJob(selector.InvokeOrDefault(new StopRollupJobDescriptor(id: id)));
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.stop_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html</a>
		/// </summary>
		public Task<StopRollupJobResponse> StopJobAsync(Id id, Func<StopRollupJobDescriptor, IStopRollupJobRequest> selector = null, CancellationToken ct = default) => StopJobAsync(selector.InvokeOrDefault(new StopRollupJobDescriptor(id: id)), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.stop_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html</a>
		/// </summary>
		public StopRollupJobResponse StopJob(IStopRollupJobRequest request) => DoRequest<IStopRollupJobRequest, StopRollupJobResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>rollup.stop_job</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html</a>
		/// </summary>
		public Task<StopRollupJobResponse> StopJobAsync(IStopRollupJobRequest request, CancellationToken ct = default) => DoRequestAsync<IStopRollupJobRequest, StopRollupJobResponse>(request, request.RequestParameters, ct);
	}
}