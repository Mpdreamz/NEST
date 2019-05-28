using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.SecurityApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.SecurityApi
{
	///<summary>
	/// Logically groups all Security API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Security"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class SecurityNamespace : NamespacedClientProxy
	{
		internal SecurityNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IAuthenticateRequest"/>
		public AuthenticateResponse Authenticate(Func<AuthenticateDescriptor, IAuthenticateRequest> selector = null) => Authenticate(selector.InvokeOrDefault(new AuthenticateDescriptor()));
		///<inheritdoc cref = "IAuthenticateRequest"/>
		public Task<AuthenticateResponse> AuthenticateAsync(Func<AuthenticateDescriptor, IAuthenticateRequest> selector = null, CancellationToken ct = default) => AuthenticateAsync(selector.InvokeOrDefault(new AuthenticateDescriptor()), ct);
		///<inheritdoc cref = "IAuthenticateRequest"/>
		public AuthenticateResponse Authenticate(IAuthenticateRequest request) => DoRequest<IAuthenticateRequest, AuthenticateResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IAuthenticateRequest"/>
		public Task<AuthenticateResponse> AuthenticateAsync(IAuthenticateRequest request, CancellationToken ct = default) => DoRequestAsync<IAuthenticateRequest, AuthenticateResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IChangePasswordRequest"/>
		public ChangePasswordResponse ChangePassword(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector) => ChangePassword(selector.InvokeOrDefault(new ChangePasswordDescriptor()));
		///<inheritdoc cref = "IChangePasswordRequest"/>
		public Task<ChangePasswordResponse> ChangePasswordAsync(Func<ChangePasswordDescriptor, IChangePasswordRequest> selector, CancellationToken ct = default) => ChangePasswordAsync(selector.InvokeOrDefault(new ChangePasswordDescriptor()), ct);
		///<inheritdoc cref = "IChangePasswordRequest"/>
		public ChangePasswordResponse ChangePassword(IChangePasswordRequest request) => DoRequest<IChangePasswordRequest, ChangePasswordResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IChangePasswordRequest"/>
		public Task<ChangePasswordResponse> ChangePasswordAsync(IChangePasswordRequest request, CancellationToken ct = default) => DoRequestAsync<IChangePasswordRequest, ChangePasswordResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClearCachedRealmsRequest"/>
		public ClearCachedRealmsResponse ClearCachedRealms(Names realms, Func<ClearCachedRealmsDescriptor, IClearCachedRealmsRequest> selector = null) => ClearCachedRealms(selector.InvokeOrDefault(new ClearCachedRealmsDescriptor(realms: realms)));
		///<inheritdoc cref = "IClearCachedRealmsRequest"/>
		public Task<ClearCachedRealmsResponse> ClearCachedRealmsAsync(Names realms, Func<ClearCachedRealmsDescriptor, IClearCachedRealmsRequest> selector = null, CancellationToken ct = default) => ClearCachedRealmsAsync(selector.InvokeOrDefault(new ClearCachedRealmsDescriptor(realms: realms)), ct);
		///<inheritdoc cref = "IClearCachedRealmsRequest"/>
		public ClearCachedRealmsResponse ClearCachedRealms(IClearCachedRealmsRequest request) => DoRequest<IClearCachedRealmsRequest, ClearCachedRealmsResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClearCachedRealmsRequest"/>
		public Task<ClearCachedRealmsResponse> ClearCachedRealmsAsync(IClearCachedRealmsRequest request, CancellationToken ct = default) => DoRequestAsync<IClearCachedRealmsRequest, ClearCachedRealmsResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IClearCachedRolesRequest"/>
		public ClearCachedRolesResponse ClearCachedRoles(Names name, Func<ClearCachedRolesDescriptor, IClearCachedRolesRequest> selector = null) => ClearCachedRoles(selector.InvokeOrDefault(new ClearCachedRolesDescriptor(name: name)));
		///<inheritdoc cref = "IClearCachedRolesRequest"/>
		public Task<ClearCachedRolesResponse> ClearCachedRolesAsync(Names name, Func<ClearCachedRolesDescriptor, IClearCachedRolesRequest> selector = null, CancellationToken ct = default) => ClearCachedRolesAsync(selector.InvokeOrDefault(new ClearCachedRolesDescriptor(name: name)), ct);
		///<inheritdoc cref = "IClearCachedRolesRequest"/>
		public ClearCachedRolesResponse ClearCachedRoles(IClearCachedRolesRequest request) => DoRequest<IClearCachedRolesRequest, ClearCachedRolesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClearCachedRolesRequest"/>
		public Task<ClearCachedRolesResponse> ClearCachedRolesAsync(IClearCachedRolesRequest request, CancellationToken ct = default) => DoRequestAsync<IClearCachedRolesRequest, ClearCachedRolesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ICreateApiKeyRequest"/>
		public CreateApiKeyResponse CreateApiKey(Func<CreateApiKeyDescriptor, ICreateApiKeyRequest> selector) => CreateApiKey(selector.InvokeOrDefault(new CreateApiKeyDescriptor()));
		///<inheritdoc cref = "ICreateApiKeyRequest"/>
		public Task<CreateApiKeyResponse> CreateApiKeyAsync(Func<CreateApiKeyDescriptor, ICreateApiKeyRequest> selector, CancellationToken ct = default) => CreateApiKeyAsync(selector.InvokeOrDefault(new CreateApiKeyDescriptor()), ct);
		///<inheritdoc cref = "ICreateApiKeyRequest"/>
		public CreateApiKeyResponse CreateApiKey(ICreateApiKeyRequest request) => DoRequest<ICreateApiKeyRequest, CreateApiKeyResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ICreateApiKeyRequest"/>
		public Task<CreateApiKeyResponse> CreateApiKeyAsync(ICreateApiKeyRequest request, CancellationToken ct = default) => DoRequestAsync<ICreateApiKeyRequest, CreateApiKeyResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeletePrivilegesRequest"/>
		public DeletePrivilegesResponse DeletePrivileges(Name application, Name name, Func<DeletePrivilegesDescriptor, IDeletePrivilegesRequest> selector = null) => DeletePrivileges(selector.InvokeOrDefault(new DeletePrivilegesDescriptor(application: application, name: name)));
		///<inheritdoc cref = "IDeletePrivilegesRequest"/>
		public Task<DeletePrivilegesResponse> DeletePrivilegesAsync(Name application, Name name, Func<DeletePrivilegesDescriptor, IDeletePrivilegesRequest> selector = null, CancellationToken ct = default) => DeletePrivilegesAsync(selector.InvokeOrDefault(new DeletePrivilegesDescriptor(application: application, name: name)), ct);
		///<inheritdoc cref = "IDeletePrivilegesRequest"/>
		public DeletePrivilegesResponse DeletePrivileges(IDeletePrivilegesRequest request) => DoRequest<IDeletePrivilegesRequest, DeletePrivilegesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeletePrivilegesRequest"/>
		public Task<DeletePrivilegesResponse> DeletePrivilegesAsync(IDeletePrivilegesRequest request, CancellationToken ct = default) => DoRequestAsync<IDeletePrivilegesRequest, DeletePrivilegesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteRoleRequest"/>
		public DeleteRoleResponse DeleteRole(Name name, Func<DeleteRoleDescriptor, IDeleteRoleRequest> selector = null) => DeleteRole(selector.InvokeOrDefault(new DeleteRoleDescriptor(name: name)));
		///<inheritdoc cref = "IDeleteRoleRequest"/>
		public Task<DeleteRoleResponse> DeleteRoleAsync(Name name, Func<DeleteRoleDescriptor, IDeleteRoleRequest> selector = null, CancellationToken ct = default) => DeleteRoleAsync(selector.InvokeOrDefault(new DeleteRoleDescriptor(name: name)), ct);
		///<inheritdoc cref = "IDeleteRoleRequest"/>
		public DeleteRoleResponse DeleteRole(IDeleteRoleRequest request) => DoRequest<IDeleteRoleRequest, DeleteRoleResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteRoleRequest"/>
		public Task<DeleteRoleResponse> DeleteRoleAsync(IDeleteRoleRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteRoleRequest, DeleteRoleResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteRoleMappingRequest"/>
		public DeleteRoleMappingResponse DeleteRoleMapping(Name name, Func<DeleteRoleMappingDescriptor, IDeleteRoleMappingRequest> selector = null) => DeleteRoleMapping(selector.InvokeOrDefault(new DeleteRoleMappingDescriptor(name: name)));
		///<inheritdoc cref = "IDeleteRoleMappingRequest"/>
		public Task<DeleteRoleMappingResponse> DeleteRoleMappingAsync(Name name, Func<DeleteRoleMappingDescriptor, IDeleteRoleMappingRequest> selector = null, CancellationToken ct = default) => DeleteRoleMappingAsync(selector.InvokeOrDefault(new DeleteRoleMappingDescriptor(name: name)), ct);
		///<inheritdoc cref = "IDeleteRoleMappingRequest"/>
		public DeleteRoleMappingResponse DeleteRoleMapping(IDeleteRoleMappingRequest request) => DoRequest<IDeleteRoleMappingRequest, DeleteRoleMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteRoleMappingRequest"/>
		public Task<DeleteRoleMappingResponse> DeleteRoleMappingAsync(IDeleteRoleMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteRoleMappingRequest, DeleteRoleMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDeleteUserRequest"/>
		public DeleteUserResponse DeleteUser(Name username, Func<DeleteUserDescriptor, IDeleteUserRequest> selector = null) => DeleteUser(selector.InvokeOrDefault(new DeleteUserDescriptor(username: username)));
		///<inheritdoc cref = "IDeleteUserRequest"/>
		public Task<DeleteUserResponse> DeleteUserAsync(Name username, Func<DeleteUserDescriptor, IDeleteUserRequest> selector = null, CancellationToken ct = default) => DeleteUserAsync(selector.InvokeOrDefault(new DeleteUserDescriptor(username: username)), ct);
		///<inheritdoc cref = "IDeleteUserRequest"/>
		public DeleteUserResponse DeleteUser(IDeleteUserRequest request) => DoRequest<IDeleteUserRequest, DeleteUserResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDeleteUserRequest"/>
		public Task<DeleteUserResponse> DeleteUserAsync(IDeleteUserRequest request, CancellationToken ct = default) => DoRequestAsync<IDeleteUserRequest, DeleteUserResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IDisableUserRequest"/>
		public DisableUserResponse DisableUser(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null) => DisableUser(selector.InvokeOrDefault(new DisableUserDescriptor(username: username)));
		///<inheritdoc cref = "IDisableUserRequest"/>
		public Task<DisableUserResponse> DisableUserAsync(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null, CancellationToken ct = default) => DisableUserAsync(selector.InvokeOrDefault(new DisableUserDescriptor(username: username)), ct);
		///<inheritdoc cref = "IDisableUserRequest"/>
		public DisableUserResponse DisableUser(IDisableUserRequest request) => DoRequest<IDisableUserRequest, DisableUserResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IDisableUserRequest"/>
		public Task<DisableUserResponse> DisableUserAsync(IDisableUserRequest request, CancellationToken ct = default) => DoRequestAsync<IDisableUserRequest, DisableUserResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IEnableUserRequest"/>
		public EnableUserResponse EnableUser(Name username, Func<EnableUserDescriptor, IEnableUserRequest> selector = null) => EnableUser(selector.InvokeOrDefault(new EnableUserDescriptor(username: username)));
		///<inheritdoc cref = "IEnableUserRequest"/>
		public Task<EnableUserResponse> EnableUserAsync(Name username, Func<EnableUserDescriptor, IEnableUserRequest> selector = null, CancellationToken ct = default) => EnableUserAsync(selector.InvokeOrDefault(new EnableUserDescriptor(username: username)), ct);
		///<inheritdoc cref = "IEnableUserRequest"/>
		public EnableUserResponse EnableUser(IEnableUserRequest request) => DoRequest<IEnableUserRequest, EnableUserResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IEnableUserRequest"/>
		public Task<EnableUserResponse> EnableUserAsync(IEnableUserRequest request, CancellationToken ct = default) => DoRequestAsync<IEnableUserRequest, EnableUserResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetApiKeyRequest"/>
		public GetApiKeyResponse GetApiKey(Func<GetApiKeyDescriptor, IGetApiKeyRequest> selector = null) => GetApiKey(selector.InvokeOrDefault(new GetApiKeyDescriptor()));
		///<inheritdoc cref = "IGetApiKeyRequest"/>
		public Task<GetApiKeyResponse> GetApiKeyAsync(Func<GetApiKeyDescriptor, IGetApiKeyRequest> selector = null, CancellationToken ct = default) => GetApiKeyAsync(selector.InvokeOrDefault(new GetApiKeyDescriptor()), ct);
		///<inheritdoc cref = "IGetApiKeyRequest"/>
		public GetApiKeyResponse GetApiKey(IGetApiKeyRequest request) => DoRequest<IGetApiKeyRequest, GetApiKeyResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetApiKeyRequest"/>
		public Task<GetApiKeyResponse> GetApiKeyAsync(IGetApiKeyRequest request, CancellationToken ct = default) => DoRequestAsync<IGetApiKeyRequest, GetApiKeyResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetPrivilegesRequest"/>
		public GetPrivilegesResponse GetPrivileges(Name name = null, Func<GetPrivilegesDescriptor, IGetPrivilegesRequest> selector = null) => GetPrivileges(selector.InvokeOrDefault(new GetPrivilegesDescriptor().Name(name: name)));
		///<inheritdoc cref = "IGetPrivilegesRequest"/>
		public Task<GetPrivilegesResponse> GetPrivilegesAsync(Name name = null, Func<GetPrivilegesDescriptor, IGetPrivilegesRequest> selector = null, CancellationToken ct = default) => GetPrivilegesAsync(selector.InvokeOrDefault(new GetPrivilegesDescriptor().Name(name: name)), ct);
		///<inheritdoc cref = "IGetPrivilegesRequest"/>
		public GetPrivilegesResponse GetPrivileges(IGetPrivilegesRequest request) => DoRequest<IGetPrivilegesRequest, GetPrivilegesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetPrivilegesRequest"/>
		public Task<GetPrivilegesResponse> GetPrivilegesAsync(IGetPrivilegesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetPrivilegesRequest, GetPrivilegesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetRoleRequest"/>
		public GetRoleResponse GetRole(Name name = null, Func<GetRoleDescriptor, IGetRoleRequest> selector = null) => GetRole(selector.InvokeOrDefault(new GetRoleDescriptor().Name(name: name)));
		///<inheritdoc cref = "IGetRoleRequest"/>
		public Task<GetRoleResponse> GetRoleAsync(Name name = null, Func<GetRoleDescriptor, IGetRoleRequest> selector = null, CancellationToken ct = default) => GetRoleAsync(selector.InvokeOrDefault(new GetRoleDescriptor().Name(name: name)), ct);
		///<inheritdoc cref = "IGetRoleRequest"/>
		public GetRoleResponse GetRole(IGetRoleRequest request) => DoRequest<IGetRoleRequest, GetRoleResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetRoleRequest"/>
		public Task<GetRoleResponse> GetRoleAsync(IGetRoleRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRoleRequest, GetRoleResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetRoleMappingRequest"/>
		public GetRoleMappingResponse GetRoleMapping(Name name = null, Func<GetRoleMappingDescriptor, IGetRoleMappingRequest> selector = null) => GetRoleMapping(selector.InvokeOrDefault(new GetRoleMappingDescriptor().Name(name: name)));
		///<inheritdoc cref = "IGetRoleMappingRequest"/>
		public Task<GetRoleMappingResponse> GetRoleMappingAsync(Name name = null, Func<GetRoleMappingDescriptor, IGetRoleMappingRequest> selector = null, CancellationToken ct = default) => GetRoleMappingAsync(selector.InvokeOrDefault(new GetRoleMappingDescriptor().Name(name: name)), ct);
		///<inheritdoc cref = "IGetRoleMappingRequest"/>
		public GetRoleMappingResponse GetRoleMapping(IGetRoleMappingRequest request) => DoRequest<IGetRoleMappingRequest, GetRoleMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetRoleMappingRequest"/>
		public Task<GetRoleMappingResponse> GetRoleMappingAsync(IGetRoleMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IGetRoleMappingRequest, GetRoleMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetUserAccessTokenRequest"/>
		public GetUserAccessTokenResponse GetUserAccessToken(string username, string password, Func<GetUserAccessTokenDescriptor, IGetUserAccessTokenRequest> selector = null) => GetUserAccessToken(selector.InvokeOrDefault(new GetUserAccessTokenDescriptor(username, password)));
		///<inheritdoc cref = "IGetUserAccessTokenRequest"/>
		public Task<GetUserAccessTokenResponse> GetUserAccessTokenAsync(string username, string password, Func<GetUserAccessTokenDescriptor, IGetUserAccessTokenRequest> selector = null, CancellationToken ct = default) => GetUserAccessTokenAsync(selector.InvokeOrDefault(new GetUserAccessTokenDescriptor(username, password)), ct);
		///<inheritdoc cref = "IGetUserAccessTokenRequest"/>
		public GetUserAccessTokenResponse GetUserAccessToken(IGetUserAccessTokenRequest request) => DoRequest<IGetUserAccessTokenRequest, GetUserAccessTokenResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetUserAccessTokenRequest"/>
		public Task<GetUserAccessTokenResponse> GetUserAccessTokenAsync(IGetUserAccessTokenRequest request, CancellationToken ct = default) => DoRequestAsync<IGetUserAccessTokenRequest, GetUserAccessTokenResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetUserRequest"/>
		public GetUserResponse GetUser(Func<GetUserDescriptor, IGetUserRequest> selector = null) => GetUser(selector.InvokeOrDefault(new GetUserDescriptor()));
		///<inheritdoc cref = "IGetUserRequest"/>
		public Task<GetUserResponse> GetUserAsync(Func<GetUserDescriptor, IGetUserRequest> selector = null, CancellationToken ct = default) => GetUserAsync(selector.InvokeOrDefault(new GetUserDescriptor()), ct);
		///<inheritdoc cref = "IGetUserRequest"/>
		public GetUserResponse GetUser(IGetUserRequest request) => DoRequest<IGetUserRequest, GetUserResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetUserRequest"/>
		public Task<GetUserResponse> GetUserAsync(IGetUserRequest request, CancellationToken ct = default) => DoRequestAsync<IGetUserRequest, GetUserResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetUserPrivilegesRequest"/>
		public GetUserPrivilegesResponse GetUserPrivileges(Func<GetUserPrivilegesDescriptor, IGetUserPrivilegesRequest> selector = null) => GetUserPrivileges(selector.InvokeOrDefault(new GetUserPrivilegesDescriptor()));
		///<inheritdoc cref = "IGetUserPrivilegesRequest"/>
		public Task<GetUserPrivilegesResponse> GetUserPrivilegesAsync(Func<GetUserPrivilegesDescriptor, IGetUserPrivilegesRequest> selector = null, CancellationToken ct = default) => GetUserPrivilegesAsync(selector.InvokeOrDefault(new GetUserPrivilegesDescriptor()), ct);
		///<inheritdoc cref = "IGetUserPrivilegesRequest"/>
		public GetUserPrivilegesResponse GetUserPrivileges(IGetUserPrivilegesRequest request) => DoRequest<IGetUserPrivilegesRequest, GetUserPrivilegesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetUserPrivilegesRequest"/>
		public Task<GetUserPrivilegesResponse> GetUserPrivilegesAsync(IGetUserPrivilegesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetUserPrivilegesRequest, GetUserPrivilegesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IHasPrivilegesRequest"/>
		public HasPrivilegesResponse HasPrivileges(Func<HasPrivilegesDescriptor, IHasPrivilegesRequest> selector = null) => HasPrivileges(selector.InvokeOrDefault(new HasPrivilegesDescriptor()));
		///<inheritdoc cref = "IHasPrivilegesRequest"/>
		public Task<HasPrivilegesResponse> HasPrivilegesAsync(Func<HasPrivilegesDescriptor, IHasPrivilegesRequest> selector = null, CancellationToken ct = default) => HasPrivilegesAsync(selector.InvokeOrDefault(new HasPrivilegesDescriptor()), ct);
		///<inheritdoc cref = "IHasPrivilegesRequest"/>
		public HasPrivilegesResponse HasPrivileges(IHasPrivilegesRequest request) => DoRequest<IHasPrivilegesRequest, HasPrivilegesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IHasPrivilegesRequest"/>
		public Task<HasPrivilegesResponse> HasPrivilegesAsync(IHasPrivilegesRequest request, CancellationToken ct = default) => DoRequestAsync<IHasPrivilegesRequest, HasPrivilegesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IInvalidateApiKeyRequest"/>
		public InvalidateApiKeyResponse InvalidateApiKey(Func<InvalidateApiKeyDescriptor, IInvalidateApiKeyRequest> selector) => InvalidateApiKey(selector.InvokeOrDefault(new InvalidateApiKeyDescriptor()));
		///<inheritdoc cref = "IInvalidateApiKeyRequest"/>
		public Task<InvalidateApiKeyResponse> InvalidateApiKeyAsync(Func<InvalidateApiKeyDescriptor, IInvalidateApiKeyRequest> selector, CancellationToken ct = default) => InvalidateApiKeyAsync(selector.InvokeOrDefault(new InvalidateApiKeyDescriptor()), ct);
		///<inheritdoc cref = "IInvalidateApiKeyRequest"/>
		public InvalidateApiKeyResponse InvalidateApiKey(IInvalidateApiKeyRequest request) => DoRequest<IInvalidateApiKeyRequest, InvalidateApiKeyResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IInvalidateApiKeyRequest"/>
		public Task<InvalidateApiKeyResponse> InvalidateApiKeyAsync(IInvalidateApiKeyRequest request, CancellationToken ct = default) => DoRequestAsync<IInvalidateApiKeyRequest, InvalidateApiKeyResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IInvalidateUserAccessTokenRequest"/>
		public InvalidateUserAccessTokenResponse InvalidateUserAccessToken(string token, Func<InvalidateUserAccessTokenDescriptor, IInvalidateUserAccessTokenRequest> selector = null) => InvalidateUserAccessToken(selector.InvokeOrDefault(new InvalidateUserAccessTokenDescriptor(token)));
		///<inheritdoc cref = "IInvalidateUserAccessTokenRequest"/>
		public Task<InvalidateUserAccessTokenResponse> InvalidateUserAccessTokenAsync(string token, Func<InvalidateUserAccessTokenDescriptor, IInvalidateUserAccessTokenRequest> selector = null, CancellationToken ct = default) => InvalidateUserAccessTokenAsync(selector.InvokeOrDefault(new InvalidateUserAccessTokenDescriptor(token)), ct);
		///<inheritdoc cref = "IInvalidateUserAccessTokenRequest"/>
		public InvalidateUserAccessTokenResponse InvalidateUserAccessToken(IInvalidateUserAccessTokenRequest request) => DoRequest<IInvalidateUserAccessTokenRequest, InvalidateUserAccessTokenResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IInvalidateUserAccessTokenRequest"/>
		public Task<InvalidateUserAccessTokenResponse> InvalidateUserAccessTokenAsync(IInvalidateUserAccessTokenRequest request, CancellationToken ct = default) => DoRequestAsync<IInvalidateUserAccessTokenRequest, InvalidateUserAccessTokenResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutPrivilegesRequest"/>
		public PutPrivilegesResponse PutPrivileges(Func<PutPrivilegesDescriptor, IPutPrivilegesRequest> selector) => PutPrivileges(selector.InvokeOrDefault(new PutPrivilegesDescriptor()));
		///<inheritdoc cref = "IPutPrivilegesRequest"/>
		public Task<PutPrivilegesResponse> PutPrivilegesAsync(Func<PutPrivilegesDescriptor, IPutPrivilegesRequest> selector, CancellationToken ct = default) => PutPrivilegesAsync(selector.InvokeOrDefault(new PutPrivilegesDescriptor()), ct);
		///<inheritdoc cref = "IPutPrivilegesRequest"/>
		public PutPrivilegesResponse PutPrivileges(IPutPrivilegesRequest request) => DoRequest<IPutPrivilegesRequest, PutPrivilegesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutPrivilegesRequest"/>
		public Task<PutPrivilegesResponse> PutPrivilegesAsync(IPutPrivilegesRequest request, CancellationToken ct = default) => DoRequestAsync<IPutPrivilegesRequest, PutPrivilegesResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutRoleRequest"/>
		public PutRoleResponse PutRole(Name name, Func<PutRoleDescriptor, IPutRoleRequest> selector) => PutRole(selector.InvokeOrDefault(new PutRoleDescriptor(name: name)));
		///<inheritdoc cref = "IPutRoleRequest"/>
		public Task<PutRoleResponse> PutRoleAsync(Name name, Func<PutRoleDescriptor, IPutRoleRequest> selector, CancellationToken ct = default) => PutRoleAsync(selector.InvokeOrDefault(new PutRoleDescriptor(name: name)), ct);
		///<inheritdoc cref = "IPutRoleRequest"/>
		public PutRoleResponse PutRole(IPutRoleRequest request) => DoRequest<IPutRoleRequest, PutRoleResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutRoleRequest"/>
		public Task<PutRoleResponse> PutRoleAsync(IPutRoleRequest request, CancellationToken ct = default) => DoRequestAsync<IPutRoleRequest, PutRoleResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutRoleMappingRequest"/>
		public PutRoleMappingResponse PutRoleMapping(Name name, Func<PutRoleMappingDescriptor, IPutRoleMappingRequest> selector) => PutRoleMapping(selector.InvokeOrDefault(new PutRoleMappingDescriptor(name: name)));
		///<inheritdoc cref = "IPutRoleMappingRequest"/>
		public Task<PutRoleMappingResponse> PutRoleMappingAsync(Name name, Func<PutRoleMappingDescriptor, IPutRoleMappingRequest> selector, CancellationToken ct = default) => PutRoleMappingAsync(selector.InvokeOrDefault(new PutRoleMappingDescriptor(name: name)), ct);
		///<inheritdoc cref = "IPutRoleMappingRequest"/>
		public PutRoleMappingResponse PutRoleMapping(IPutRoleMappingRequest request) => DoRequest<IPutRoleMappingRequest, PutRoleMappingResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutRoleMappingRequest"/>
		public Task<PutRoleMappingResponse> PutRoleMappingAsync(IPutRoleMappingRequest request, CancellationToken ct = default) => DoRequestAsync<IPutRoleMappingRequest, PutRoleMappingResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IPutUserRequest"/>
		public PutUserResponse PutUser(Name username, Func<PutUserDescriptor, IPutUserRequest> selector) => PutUser(selector.InvokeOrDefault(new PutUserDescriptor(username: username)));
		///<inheritdoc cref = "IPutUserRequest"/>
		public Task<PutUserResponse> PutUserAsync(Name username, Func<PutUserDescriptor, IPutUserRequest> selector, CancellationToken ct = default) => PutUserAsync(selector.InvokeOrDefault(new PutUserDescriptor(username: username)), ct);
		///<inheritdoc cref = "IPutUserRequest"/>
		public PutUserResponse PutUser(IPutUserRequest request) => DoRequest<IPutUserRequest, PutUserResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IPutUserRequest"/>
		public Task<PutUserResponse> PutUserAsync(IPutUserRequest request, CancellationToken ct = default) => DoRequestAsync<IPutUserRequest, PutUserResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IGetCertificatesRequest"/>
		public GetCertificatesResponse GetCertificates(Func<GetCertificatesDescriptor, IGetCertificatesRequest> selector = null) => GetCertificates(selector.InvokeOrDefault(new GetCertificatesDescriptor()));
		///<inheritdoc cref = "IGetCertificatesRequest"/>
		public Task<GetCertificatesResponse> GetCertificatesAsync(Func<GetCertificatesDescriptor, IGetCertificatesRequest> selector = null, CancellationToken ct = default) => GetCertificatesAsync(selector.InvokeOrDefault(new GetCertificatesDescriptor()), ct);
		///<inheritdoc cref = "IGetCertificatesRequest"/>
		public GetCertificatesResponse GetCertificates(IGetCertificatesRequest request) => DoRequest<IGetCertificatesRequest, GetCertificatesResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGetCertificatesRequest"/>
		public Task<GetCertificatesResponse> GetCertificatesAsync(IGetCertificatesRequest request, CancellationToken ct = default) => DoRequestAsync<IGetCertificatesRequest, GetCertificatesResponse>(request, request.RequestParameters, ct);
	}
}