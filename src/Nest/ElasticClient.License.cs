using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.LicenseApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.LicenseApi
{
	///<summary>
	/// Logically groups all License API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.License"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class LicenseNamespace : NamespacedClientProxy
	{
		internal LicenseNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IDeleteLicenseRequest"/>
		public DeleteLicenseResponse Delete(Func<DeleteLicenseDescriptor, IDeleteLicenseRequest> selector = null) => Delete(selector.InvokeOrDefault(new DeleteLicenseDescriptor()));
		///<inheritdoc cref = "IDeleteLicenseRequest"/>
		public Task<DeleteLicenseResponse> DeleteAsync(Func<DeleteLicenseDescriptor, IDeleteLicenseRequest> selector = null, CancellationToken ct = default) => DeleteAsync(selector.InvokeOrDefault(new DeleteLicenseDescriptor()), ct);
		///<inheritdoc cref = "IDeleteLicenseRequest"/>
		public DeleteLicenseResponse Delete(IDeleteLicenseRequest request) => DoRequest<IDeleteLicenseRequest, DeleteLicenseResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteLicenseRequest"/>
		public Task<DeleteLicenseResponse> DeleteAsync(IDeleteLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteLicenseRequest, DeleteLicenseResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetLicenseRequest"/>
		public GetLicenseResponse Get(Func<GetLicenseDescriptor, IGetLicenseRequest> selector = null) => Get(selector.InvokeOrDefault(new GetLicenseDescriptor()));
		///<inheritdoc cref = "IGetLicenseRequest"/>
		public Task<GetLicenseResponse> GetAsync(Func<GetLicenseDescriptor, IGetLicenseRequest> selector = null, CancellationToken ct = default) => GetAsync(selector.InvokeOrDefault(new GetLicenseDescriptor()), ct);
		///<inheritdoc cref = "IGetLicenseRequest"/>
		public GetLicenseResponse Get(IGetLicenseRequest request) => DoRequest<IGetLicenseRequest, GetLicenseResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetLicenseRequest"/>
		public Task<GetLicenseResponse> GetAsync(IGetLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IGetLicenseRequest, GetLicenseResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetBasicLicenseStatusRequest"/>
		public GetBasicLicenseStatusResponse GetBasicStatus(Func<GetBasicLicenseStatusDescriptor, IGetBasicLicenseStatusRequest> selector = null) => GetBasicStatus(selector.InvokeOrDefault(new GetBasicLicenseStatusDescriptor()));
		///<inheritdoc cref = "IGetBasicLicenseStatusRequest"/>
		public Task<GetBasicLicenseStatusResponse> GetBasicStatusAsync(Func<GetBasicLicenseStatusDescriptor, IGetBasicLicenseStatusRequest> selector = null, CancellationToken ct = default) => GetBasicStatusAsync(selector.InvokeOrDefault(new GetBasicLicenseStatusDescriptor()), ct);
		///<inheritdoc cref = "IGetBasicLicenseStatusRequest"/>
		public GetBasicLicenseStatusResponse GetBasicStatus(IGetBasicLicenseStatusRequest request) => DoRequest<IGetBasicLicenseStatusRequest, GetBasicLicenseStatusResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetBasicLicenseStatusRequest"/>
		public Task<GetBasicLicenseStatusResponse> GetBasicStatusAsync(IGetBasicLicenseStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IGetBasicLicenseStatusRequest, GetBasicLicenseStatusResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetTrialLicenseStatusRequest"/>
		public GetTrialLicenseStatusResponse GetTrialStatus(Func<GetTrialLicenseStatusDescriptor, IGetTrialLicenseStatusRequest> selector = null) => GetTrialStatus(selector.InvokeOrDefault(new GetTrialLicenseStatusDescriptor()));
		///<inheritdoc cref = "IGetTrialLicenseStatusRequest"/>
		public Task<GetTrialLicenseStatusResponse> GetTrialStatusAsync(Func<GetTrialLicenseStatusDescriptor, IGetTrialLicenseStatusRequest> selector = null, CancellationToken ct = default) => GetTrialStatusAsync(selector.InvokeOrDefault(new GetTrialLicenseStatusDescriptor()), ct);
		///<inheritdoc cref = "IGetTrialLicenseStatusRequest"/>
		public GetTrialLicenseStatusResponse GetTrialStatus(IGetTrialLicenseStatusRequest request) => DoRequest<IGetTrialLicenseStatusRequest, GetTrialLicenseStatusResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetTrialLicenseStatusRequest"/>
		public Task<GetTrialLicenseStatusResponse> GetTrialStatusAsync(IGetTrialLicenseStatusRequest request, CancellationToken ct = default) => DoRequestAsync<IGetTrialLicenseStatusRequest, GetTrialLicenseStatusResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPostLicenseRequest"/>
		public PostLicenseResponse Post(Func<PostLicenseDescriptor, IPostLicenseRequest> selector = null) => Post(selector.InvokeOrDefault(new PostLicenseDescriptor()));
		///<inheritdoc cref = "IPostLicenseRequest"/>
		public Task<PostLicenseResponse> PostAsync(Func<PostLicenseDescriptor, IPostLicenseRequest> selector = null, CancellationToken ct = default) => PostAsync(selector.InvokeOrDefault(new PostLicenseDescriptor()), ct);
		///<inheritdoc cref = "IPostLicenseRequest"/>
		public PostLicenseResponse Post(IPostLicenseRequest request) => DoRequest<IPostLicenseRequest, PostLicenseResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPostLicenseRequest"/>
		public Task<PostLicenseResponse> PostAsync(IPostLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IPostLicenseRequest, PostLicenseResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IStartBasicLicenseRequest"/>
		public StartBasicLicenseResponse StartBasic(Func<StartBasicLicenseDescriptor, IStartBasicLicenseRequest> selector = null) => StartBasic(selector.InvokeOrDefault(new StartBasicLicenseDescriptor()));
		///<inheritdoc cref = "IStartBasicLicenseRequest"/>
		public Task<StartBasicLicenseResponse> StartBasicAsync(Func<StartBasicLicenseDescriptor, IStartBasicLicenseRequest> selector = null, CancellationToken ct = default) => StartBasicAsync(selector.InvokeOrDefault(new StartBasicLicenseDescriptor()), ct);
		///<inheritdoc cref = "IStartBasicLicenseRequest"/>
		public StartBasicLicenseResponse StartBasic(IStartBasicLicenseRequest request) => DoRequest<IStartBasicLicenseRequest, StartBasicLicenseResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IStartBasicLicenseRequest"/>
		public Task<StartBasicLicenseResponse> StartBasicAsync(IStartBasicLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IStartBasicLicenseRequest, StartBasicLicenseResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IStartTrialLicenseRequest"/>
		public StartTrialLicenseResponse StartTrial(Func<StartTrialLicenseDescriptor, IStartTrialLicenseRequest> selector = null) => StartTrial(selector.InvokeOrDefault(new StartTrialLicenseDescriptor()));
		///<inheritdoc cref = "IStartTrialLicenseRequest"/>
		public Task<StartTrialLicenseResponse> StartTrialAsync(Func<StartTrialLicenseDescriptor, IStartTrialLicenseRequest> selector = null, CancellationToken ct = default) => StartTrialAsync(selector.InvokeOrDefault(new StartTrialLicenseDescriptor()), ct);
		///<inheritdoc cref = "IStartTrialLicenseRequest"/>
		public StartTrialLicenseResponse StartTrial(IStartTrialLicenseRequest request) => DoRequest<IStartTrialLicenseRequest, StartTrialLicenseResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IStartTrialLicenseRequest"/>
		public Task<StartTrialLicenseResponse> StartTrialAsync(IStartTrialLicenseRequest request, CancellationToken ct = default) => DoRequestAsync<IStartTrialLicenseRequest, StartTrialLicenseResponse>(request, request.RequestParameters, ct);
	}
}