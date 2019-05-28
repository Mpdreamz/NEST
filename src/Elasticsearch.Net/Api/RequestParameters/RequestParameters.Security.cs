using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.SecurityApi
{
	///<summary>Request options for Authenticate<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-authenticate.html</pre></summary>
	public class AuthenticateRequestParameters : RequestParameters<AuthenticateRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for ChangePassword<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</pre></summary>
	public class ChangePasswordRequestParameters : RequestParameters<ChangePasswordRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for ClearCachedRealms<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-cache.html</pre></summary>
	public class ClearCachedRealmsRequestParameters : RequestParameters<ClearCachedRealmsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Comma-separated list of usernames to clear from the cache</summary>
		public string[] Usernames
		{
			get => Q<string[]>("usernames");
			set => Q("usernames", value);
		}
	}

	///<summary>Request options for ClearCachedRoles<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-role-cache.html</pre></summary>
	public class ClearCachedRolesRequestParameters : RequestParameters<ClearCachedRolesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for CreateApiKey<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-create-api-key.html</pre></summary>
	public class CreateApiKeyRequestParameters : RequestParameters<CreateApiKeyRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for DeletePrivileges<pre>TODO</pre></summary>
	public class DeletePrivilegesRequestParameters : RequestParameters<DeletePrivilegesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for DeleteRole<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role.html</pre></summary>
	public class DeleteRoleRequestParameters : RequestParameters<DeleteRoleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for DeleteRoleMapping<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role-mapping.html</pre></summary>
	public class DeleteRoleMappingRequestParameters : RequestParameters<DeleteRoleMappingRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for DeleteUser<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-user.html</pre></summary>
	public class DeleteUserRequestParameters : RequestParameters<DeleteUserRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for DisableUser<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-disable-user.html</pre></summary>
	public class DisableUserRequestParameters : RequestParameters<DisableUserRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for EnableUser<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-enable-user.html</pre></summary>
	public class EnableUserRequestParameters : RequestParameters<EnableUserRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for GetApiKey<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-api-key.html</pre></summary>
	public class GetApiKeyRequestParameters : RequestParameters<GetApiKeyRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>API key id of the API key to be retrieved</summary>
		public string Id
		{
			get => Q<string>("id");
			set => Q("id", value);
		}

		///<summary>API key name of the API key to be retrieved</summary>
		public string Name
		{
			get => Q<string>("name");
			set => Q("name", value);
		}

		///<summary>realm name of the user who created this API key to be retrieved</summary>
		public string RealmName
		{
			get => Q<string>("realm_name");
			set => Q("realm_name", value);
		}

		///<summary>user name of the user who created this API key to be retrieved</summary>
		public string Username
		{
			get => Q<string>("username");
			set => Q("username", value);
		}
	}

	///<summary>Request options for GetPrivileges<pre>TODO</pre></summary>
	public class GetPrivilegesRequestParameters : RequestParameters<GetPrivilegesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetRole<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</pre></summary>
	public class GetRoleRequestParameters : RequestParameters<GetRoleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetRoleMapping<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</pre></summary>
	public class GetRoleMappingRequestParameters : RequestParameters<GetRoleMappingRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetUserAccessToken<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-token.html</pre></summary>
	public class GetUserAccessTokenRequestParameters : RequestParameters<GetUserAccessTokenRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for GetUser<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</pre></summary>
	public class GetUserRequestParameters : RequestParameters<GetUserRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for GetUserPrivileges<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user-privileges.html</pre></summary>
	public class GetUserPrivilegesRequestParameters : RequestParameters<GetUserPrivilegesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for HasPrivileges<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</pre></summary>
	public class HasPrivilegesRequestParameters : RequestParameters<HasPrivilegesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
	}

	///<summary>Request options for InvalidateApiKey<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-api-key.html</pre></summary>
	public class InvalidateApiKeyRequestParameters : RequestParameters<InvalidateApiKeyRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for InvalidateUserAccessToken<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-token.html</pre></summary>
	public class InvalidateUserAccessTokenRequestParameters : RequestParameters<InvalidateUserAccessTokenRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
	}

	///<summary>Request options for PutPrivileges<pre>TODO</pre></summary>
	public class PutPrivilegesRequestParameters : RequestParameters<PutPrivilegesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for PutRole<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role.html</pre></summary>
	public class PutRoleRequestParameters : RequestParameters<PutRoleRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for PutRoleMapping<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role-mapping.html</pre></summary>
	public class PutRoleMappingRequestParameters : RequestParameters<PutRoleMappingRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for PutUser<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-user.html</pre></summary>
	public class PutUserRequestParameters : RequestParameters<PutUserRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	///<summary>Request options for GetCertificates<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-ssl.html</pre></summary>
	public class GetCertificatesRequestParameters : RequestParameters<GetCertificatesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}
}