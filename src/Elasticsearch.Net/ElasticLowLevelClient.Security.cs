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
namespace Elasticsearch.Net.Specification.SecurityApi
{
	///<summary>
	/// Logically groups all Security API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticLowLevelClient.Security"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelSecurityNamespace : NamespacedClientProxy
	{
		internal LowLevelSecurityNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>GET on /_security/_authenticate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-authenticate.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Authenticate<TResponse>(AuthenticateRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/_authenticate", null, RequestParams(requestParameters));
		///<summary>GET on /_security/_authenticate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-authenticate.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> AuthenticateAsync<TResponse>(AuthenticateRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/_authenticate", ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_password <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</para></summary>
		///<param name = "username">The username of the user to change the password for</param>
		///<param name = "body">the new password for the user</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ChangePassword<TResponse>(string username, PostData body, ChangePasswordRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/user/{username:username}/_password"), body, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_password <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</para></summary>
		///<param name = "username">The username of the user to change the password for</param>
		///<param name = "body">the new password for the user</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ChangePasswordAsync<TResponse>(string username, PostData body, ChangePasswordRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/user/{username:username}/_password"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/_password <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</para></summary>
		///<param name = "body">the new password for the user</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ChangePassword<TResponse>(PostData body, ChangePasswordRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, "_security/user/_password", body, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/_password <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</para></summary>
		///<param name = "body">the new password for the user</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ChangePasswordAsync<TResponse>(PostData body, ChangePasswordRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, "_security/user/_password", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_security/realm/{realms}/_clear_cache <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-cache.html</para></summary>
		///<param name = "realms">Comma-separated list of realms to clear</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ClearCachedRealms<TResponse>(string realms, ClearCachedRealmsRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_security/realm/{realms:realms}/_clear_cache"), null, RequestParams(requestParameters));
		///<summary>POST on /_security/realm/{realms}/_clear_cache <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-cache.html</para></summary>
		///<param name = "realms">Comma-separated list of realms to clear</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ClearCachedRealmsAsync<TResponse>(string realms, ClearCachedRealmsRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_security/realm/{realms:realms}/_clear_cache"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_security/role/{name}/_clear_cache <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-role-cache.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ClearCachedRoles<TResponse>(string name, ClearCachedRolesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_security/role/{name:name}/_clear_cache"), null, RequestParams(requestParameters));
		///<summary>POST on /_security/role/{name}/_clear_cache <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-role-cache.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> ClearCachedRolesAsync<TResponse>(string name, ClearCachedRolesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_security/role/{name:name}/_clear_cache"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-create-api-key.html</para></summary>
		///<param name = "body">The api key request to create an API key</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse CreateApiKey<TResponse>(PostData body, CreateApiKeyRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, "_security/api_key", body, RequestParams(requestParameters));
		///<summary>PUT on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-create-api-key.html</para></summary>
		///<param name = "body">The api key request to create an API key</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> CreateApiKeyAsync<TResponse>(PostData body, CreateApiKeyRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, "_security/api_key", ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_security/privilege/{application}/{name} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "name">Privilege name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeletePrivileges<TResponse>(string application, string name, DeletePrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_security/privilege/{application:application}/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/privilege/{application}/{name} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "name">Privilege name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeletePrivilegesAsync<TResponse>(string application, string name, DeletePrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_security/privilege/{application:application}/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteRole<TResponse>(string name, DeleteRoleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_security/role/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteRoleAsync<TResponse>(string name, DeleteRoleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_security/role/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role-mapping.html</para></summary>
		///<param name = "name">Role-mapping name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteRoleMapping<TResponse>(string name, DeleteRoleMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_security/role_mapping/{name:name}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role-mapping.html</para></summary>
		///<param name = "name">Role-mapping name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteRoleMappingAsync<TResponse>(string name, DeleteRoleMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_security/role_mapping/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-user.html</para></summary>
		///<param name = "username">username</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteUser<TResponse>(string username, DeleteUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, Url($"_security/user/{username:username}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-user.html</para></summary>
		///<param name = "username">username</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DeleteUserAsync<TResponse>(string username, DeleteUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_security/user/{username:username}"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_disable <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-disable-user.html</para></summary>
		///<param name = "username">The username of the user to disable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DisableUser<TResponse>(string username, DisableUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/user/{username:username}/_disable"), null, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_disable <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-disable-user.html</para></summary>
		///<param name = "username">The username of the user to disable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> DisableUserAsync<TResponse>(string username, DisableUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/user/{username:username}/_disable"), ctx, null, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_enable <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-enable-user.html</para></summary>
		///<param name = "username">The username of the user to enable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse EnableUser<TResponse>(string username, EnableUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/user/{username:username}/_enable"), null, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username}/_enable <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-enable-user.html</para></summary>
		///<param name = "username">The username of the user to enable</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> EnableUserAsync<TResponse>(string username, EnableUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/user/{username:username}/_enable"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-api-key.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetApiKey<TResponse>(GetApiKeyRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/api_key", null, RequestParams(requestParameters));
		///<summary>GET on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-api-key.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetApiKeyAsync<TResponse>(GetApiKeyRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/api_key", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege <para>TODO</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetPrivileges<TResponse>(GetPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/privilege", null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege <para>TODO</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetPrivilegesAsync<TResponse>(GetPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/privilege", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege/{application} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetPrivileges<TResponse>(string application, GetPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_security/privilege/{application:application}"), null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege/{application} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetPrivilegesAsync<TResponse>(string application, GetPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_security/privilege/{application:application}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege/{application}/{name} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "name">Privilege name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetPrivileges<TResponse>(string application, string name, GetPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_security/privilege/{application:application}/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_security/privilege/{application}/{name} <para>TODO</para></summary>
		///<param name = "application">Application name</param>
		///<param name = "name">Privilege name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetPrivilegesAsync<TResponse>(string application, string name, GetPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_security/privilege/{application:application}/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetRole<TResponse>(string name, GetRoleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_security/role/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetRoleAsync<TResponse>(string name, GetRoleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_security/role/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/role <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetRole<TResponse>(GetRoleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/role", null, RequestParams(requestParameters));
		///<summary>GET on /_security/role <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetRoleAsync<TResponse>(GetRoleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/role", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</para></summary>
		///<param name = "name">Role-Mapping name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetRoleMapping<TResponse>(string name, GetRoleMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_security/role_mapping/{name:name}"), null, RequestParams(requestParameters));
		///<summary>GET on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</para></summary>
		///<param name = "name">Role-Mapping name</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetRoleMappingAsync<TResponse>(string name, GetRoleMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_security/role_mapping/{name:name}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/role_mapping <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetRoleMapping<TResponse>(GetRoleMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/role_mapping", null, RequestParams(requestParameters));
		///<summary>GET on /_security/role_mapping <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetRoleMappingAsync<TResponse>(GetRoleMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/role_mapping", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_security/oauth2/token <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-token.html</para></summary>
		///<param name = "body">The token request to get</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetUserAccessToken<TResponse>(PostData body, GetUserAccessTokenRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_security/oauth2/token", body, RequestParams(requestParameters));
		///<summary>POST on /_security/oauth2/token <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-token.html</para></summary>
		///<param name = "body">The token request to get</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetUserAccessTokenAsync<TResponse>(PostData body, GetUserAccessTokenRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_security/oauth2/token", ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</para></summary>
		///<param name = "username">A comma-separated list of usernames</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetUser<TResponse>(string username, GetUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"_security/user/{username:username}"), null, RequestParams(requestParameters));
		///<summary>GET on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</para></summary>
		///<param name = "username">A comma-separated list of usernames</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetUserAsync<TResponse>(string username, GetUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_security/user/{username:username}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/user <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetUser<TResponse>(GetUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/user", null, RequestParams(requestParameters));
		///<summary>GET on /_security/user <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetUserAsync<TResponse>(GetUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/user", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_security/user/_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user-privileges.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetUserPrivileges<TResponse>(GetUserPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_security/user/_privileges", null, RequestParams(requestParameters));
		///<summary>GET on /_security/user/_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user-privileges.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetUserPrivilegesAsync<TResponse>(GetUserPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_security/user/_privileges", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_security/user/_has_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</para></summary>
		///<param name = "body">The privileges to test</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse HasPrivileges<TResponse>(PostData body, HasPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_security/user/_has_privileges", body, RequestParams(requestParameters));
		///<summary>POST on /_security/user/_has_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</para></summary>
		///<param name = "body">The privileges to test</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HasPrivilegesAsync<TResponse>(PostData body, HasPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_security/user/_has_privileges", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_security/user/{user}/_has_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</para></summary>
		///<param name = "user">Username</param>
		///<param name = "body">The privileges to test</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse HasPrivileges<TResponse>(string user, PostData body, HasPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, Url($"_security/user/{user:user}/_has_privileges"), body, RequestParams(requestParameters));
		///<summary>POST on /_security/user/{user}/_has_privileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</para></summary>
		///<param name = "user">Username</param>
		///<param name = "body">The privileges to test</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> HasPrivilegesAsync<TResponse>(string user, PostData body, HasPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, Url($"_security/user/{user:user}/_has_privileges"), ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-api-key.html</para></summary>
		///<param name = "body">The api key request to invalidate API key(s)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse InvalidateApiKey<TResponse>(PostData body, InvalidateApiKeyRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, "_security/api_key", body, RequestParams(requestParameters));
		///<summary>DELETE on /_security/api_key <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-api-key.html</para></summary>
		///<param name = "body">The api key request to invalidate API key(s)</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InvalidateApiKeyAsync<TResponse>(PostData body, InvalidateApiKeyRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, "_security/api_key", ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_security/oauth2/token <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-token.html</para></summary>
		///<param name = "body">The token to invalidate</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse InvalidateUserAccessToken<TResponse>(PostData body, InvalidateUserAccessTokenRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(DELETE, "_security/oauth2/token", body, RequestParams(requestParameters));
		///<summary>DELETE on /_security/oauth2/token <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-token.html</para></summary>
		///<param name = "body">The token to invalidate</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> InvalidateUserAccessTokenAsync<TResponse>(PostData body, InvalidateUserAccessTokenRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(DELETE, "_security/oauth2/token", ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_security/privilege/ <para>TODO</para></summary>
		///<param name = "body">The privilege(s) to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutPrivileges<TResponse>(PostData body, PutPrivilegesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, "_security/privilege/", body, RequestParams(requestParameters));
		///<summary>PUT on /_security/privilege/ <para>TODO</para></summary>
		///<param name = "body">The privilege(s) to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutPrivilegesAsync<TResponse>(PostData body, PutPrivilegesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, "_security/privilege/", ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "body">The role to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutRole<TResponse>(string name, PostData body, PutRoleRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/role/{name:name}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_security/role/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role.html</para></summary>
		///<param name = "name">Role name</param>
		///<param name = "body">The role to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutRoleAsync<TResponse>(string name, PostData body, PutRoleRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/role/{name:name}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role-mapping.html</para></summary>
		///<param name = "name">Role-mapping name</param>
		///<param name = "body">The role to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutRoleMapping<TResponse>(string name, PostData body, PutRoleMappingRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/role_mapping/{name:name}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_security/role_mapping/{name} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role-mapping.html</para></summary>
		///<param name = "name">Role-mapping name</param>
		///<param name = "body">The role to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutRoleMappingAsync<TResponse>(string name, PostData body, PutRoleMappingRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/role_mapping/{name:name}"), ctx, body, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-user.html</para></summary>
		///<param name = "username">The username of the User</param>
		///<param name = "body">The user to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PutUser<TResponse>(string username, PostData body, PutUserRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(PUT, Url($"_security/user/{username:username}"), body, RequestParams(requestParameters));
		///<summary>PUT on /_security/user/{username} <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-user.html</para></summary>
		///<param name = "username">The username of the User</param>
		///<param name = "body">The user to add</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> PutUserAsync<TResponse>(string username, PostData body, PutUserRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(PUT, Url($"_security/user/{username:username}"), ctx, body, RequestParams(requestParameters));
		///<summary>GET on /_ssl/certificates <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-ssl.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetCertificates<TResponse>(GetCertificatesRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_ssl/certificates", null, RequestParams(requestParameters));
		///<summary>GET on /_ssl/certificates <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-ssl.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public Task<TResponse> GetCertificatesAsync<TResponse>(GetCertificatesRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_ssl/certificates", ctx, null, RequestParams(requestParameters));
	}
}