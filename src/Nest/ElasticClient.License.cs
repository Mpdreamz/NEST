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
using Elastic.Transport;
using Elasticsearch.Net.Specification.LicenseApi;

// ReSharper disable once CheckNamespace
// ReSharper disable RedundantTypeArgumentsOfMethod
namespace Nest.Specification.LicenseApi
{
	///<summary>
	/// License APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticClient.License"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class LicenseNamespace : NamespacedClientProxy
	{
		internal LicenseNamespace(ElasticClient client): base(client)
		{
		}

		/// <summary>
		/// <c>DELETE</c> request to the <c>license.delete</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html</a>
		/// </summary>
		public DeleteLicenseResponse Delete(Func<DeleteLicenseDescriptor, IDeleteLicenseRequest> selector = null) => Delete(selector.InvokeOrDefault(new DeleteLicenseDescriptor()));
		/// <summary>
		/// <c>DELETE</c> request to the <c>license.delete</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html</a>
		/// </summary>
		public Task<DeleteLicenseResponse> DeleteAsync(Func<DeleteLicenseDescriptor, IDeleteLicenseRequest> selector = null, CancellationToken ct = default) => DeleteAsync(selector.InvokeOrDefault(new DeleteLicenseDescriptor()), ct);
		/// <summary>
		/// <c>DELETE</c> request to the <c>license.delete</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html</a>
		/// </summary>
		public DeleteLicenseResponse Delete(IDeleteLicenseRequest request) => DoRequest<IDeleteLicenseRequest, DeleteLicenseResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>DELETE</c> request to the <c>license.delete</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html</a>
		/// </summary>
		public Task<DeleteLicenseResponse> DeleteAsync(IDeleteLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteLicenseRequest, DeleteLicenseResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html</a>
		/// </summary>
		public GetLicenseResponse Get(Func<GetLicenseDescriptor, IGetLicenseRequest> selector = null) => Get(selector.InvokeOrDefault(new GetLicenseDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>license.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html</a>
		/// </summary>
		public Task<GetLicenseResponse> GetAsync(Func<GetLicenseDescriptor, IGetLicenseRequest> selector = null, CancellationToken ct = default) => GetAsync(selector.InvokeOrDefault(new GetLicenseDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html</a>
		/// </summary>
		public GetLicenseResponse Get(IGetLicenseRequest request) => DoRequest<IGetLicenseRequest, GetLicenseResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html</a>
		/// </summary>
		public Task<GetLicenseResponse> GetAsync(IGetLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IGetLicenseRequest, GetLicenseResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_basic_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html</a>
		/// </summary>
		public GetBasicLicenseStatusResponse GetBasicStatus(Func<GetBasicLicenseStatusDescriptor, IGetBasicLicenseStatusRequest> selector = null) => GetBasicStatus(selector.InvokeOrDefault(new GetBasicLicenseStatusDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_basic_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html</a>
		/// </summary>
		public Task<GetBasicLicenseStatusResponse> GetBasicStatusAsync(Func<GetBasicLicenseStatusDescriptor, IGetBasicLicenseStatusRequest> selector = null, CancellationToken ct = default) => GetBasicStatusAsync(selector.InvokeOrDefault(new GetBasicLicenseStatusDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_basic_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html</a>
		/// </summary>
		public GetBasicLicenseStatusResponse GetBasicStatus(IGetBasicLicenseStatusRequest request) => DoRequest<IGetBasicLicenseStatusRequest, GetBasicLicenseStatusResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_basic_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html</a>
		/// </summary>
		public Task<GetBasicLicenseStatusResponse> GetBasicStatusAsync(IGetBasicLicenseStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IGetBasicLicenseStatusRequest, GetBasicLicenseStatusResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_trial_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html</a>
		/// </summary>
		public GetTrialLicenseStatusResponse GetTrialStatus(Func<GetTrialLicenseStatusDescriptor, IGetTrialLicenseStatusRequest> selector = null) => GetTrialStatus(selector.InvokeOrDefault(new GetTrialLicenseStatusDescriptor()));
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_trial_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html</a>
		/// </summary>
		public Task<GetTrialLicenseStatusResponse> GetTrialStatusAsync(Func<GetTrialLicenseStatusDescriptor, IGetTrialLicenseStatusRequest> selector = null, CancellationToken ct = default) => GetTrialStatusAsync(selector.InvokeOrDefault(new GetTrialLicenseStatusDescriptor()), ct);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_trial_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html</a>
		/// </summary>
		public GetTrialLicenseStatusResponse GetTrialStatus(IGetTrialLicenseStatusRequest request) => DoRequest<IGetTrialLicenseStatusRequest, GetTrialLicenseStatusResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>GET</c> request to the <c>license.get_trial_status</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html</a>
		/// </summary>
		public Task<GetTrialLicenseStatusResponse> GetTrialStatusAsync(IGetTrialLicenseStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTrialLicenseStatusRequest, GetTrialLicenseStatusResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>license.post</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html</a>
		/// </summary>
		public PostLicenseResponse Post(Func<PostLicenseDescriptor, IPostLicenseRequest> selector = null) => Post(selector.InvokeOrDefault(new PostLicenseDescriptor()));
		/// <summary>
		/// <c>PUT</c> request to the <c>license.post</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html</a>
		/// </summary>
		public Task<PostLicenseResponse> PostAsync(Func<PostLicenseDescriptor, IPostLicenseRequest> selector = null, CancellationToken ct = default) => PostAsync(selector.InvokeOrDefault(new PostLicenseDescriptor()), ct);
		/// <summary>
		/// <c>PUT</c> request to the <c>license.post</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html</a>
		/// </summary>
		public PostLicenseResponse Post(IPostLicenseRequest request) => DoRequest<IPostLicenseRequest, PostLicenseResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>PUT</c> request to the <c>license.post</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html</a>
		/// </summary>
		public Task<PostLicenseResponse> PostAsync(IPostLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IPostLicenseRequest, PostLicenseResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_basic</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html</a>
		/// </summary>
		public StartBasicLicenseResponse StartBasic(Func<StartBasicLicenseDescriptor, IStartBasicLicenseRequest> selector = null) => StartBasic(selector.InvokeOrDefault(new StartBasicLicenseDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_basic</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html</a>
		/// </summary>
		public Task<StartBasicLicenseResponse> StartBasicAsync(Func<StartBasicLicenseDescriptor, IStartBasicLicenseRequest> selector = null, CancellationToken ct = default) => StartBasicAsync(selector.InvokeOrDefault(new StartBasicLicenseDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_basic</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html</a>
		/// </summary>
		public StartBasicLicenseResponse StartBasic(IStartBasicLicenseRequest request) => DoRequest<IStartBasicLicenseRequest, StartBasicLicenseResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_basic</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html</a>
		/// </summary>
		public Task<StartBasicLicenseResponse> StartBasicAsync(IStartBasicLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IStartBasicLicenseRequest, StartBasicLicenseResponse>(request, request.RequestParameters, ct);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_trial</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html</a>
		/// </summary>
		public StartTrialLicenseResponse StartTrial(Func<StartTrialLicenseDescriptor, IStartTrialLicenseRequest> selector = null) => StartTrial(selector.InvokeOrDefault(new StartTrialLicenseDescriptor()));
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_trial</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html</a>
		/// </summary>
		public Task<StartTrialLicenseResponse> StartTrialAsync(Func<StartTrialLicenseDescriptor, IStartTrialLicenseRequest> selector = null, CancellationToken ct = default) => StartTrialAsync(selector.InvokeOrDefault(new StartTrialLicenseDescriptor()), ct);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_trial</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html</a>
		/// </summary>
		public StartTrialLicenseResponse StartTrial(IStartTrialLicenseRequest request) => DoRequest<IStartTrialLicenseRequest, StartTrialLicenseResponse>(request, request.RequestParameters);
		/// <summary>
		/// <c>POST</c> request to the <c>license.post_start_trial</c> API, read more about this API online:
		/// <para></para>
		/// <a href = "https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html">https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html</a>
		/// </summary>
		public Task<StartTrialLicenseResponse> StartTrialAsync(IStartTrialLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IStartTrialLicenseRequest, StartTrialLicenseResponse>(request, request.RequestParameters, ct);
	}
}