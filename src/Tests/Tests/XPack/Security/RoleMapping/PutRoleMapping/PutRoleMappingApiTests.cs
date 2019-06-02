﻿using System;
using System.Collections.Generic;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.EndpointTests;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.XPack.Security.RoleMapping.PutRoleMapping
{
	[SkipVersion("<5.5.0", "")]
	public class PutRoleMappingApiTests
		: ApiIntegrationTestBase<XPackCluster, PutRoleMappingResponse, IPutRoleMappingRequest,
			PutRoleMappingDescriptor, PutRoleMappingRequest>
	{
		private readonly string _dn = "*,ou=admin,dc=example,dc=com";
		private readonly string[] _groups = { "group1", "group2" };
		private readonly Tuple<string, string> _metadata = Tuple.Create("a", "b");
		private readonly string _realm = "some_realm";
		private readonly string _username = "mpdreamz";

		public PutRoleMappingApiTests(XPackCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override bool ExpectIsValid => true;

		protected override object ExpectJson => new
		{
			enabled = true,
			roles = new[] { "admin" },
			metadata = new
			{
				x = "y",
				z = (object)null
			},
			rules = new
			{
				all = new object[]
				{
					new
					{
						any = new object[]
						{
							new { field = new { dn = "*,ou=admin,dc=example,dc=com" } },
							new { field = new { username = "mpdreamz" } },
							new { field = new Dictionary<string, object>() { { "realm.name", "some_realm" } } }
						}
					},
					new { field = new Dictionary<string, object>() { { "metadata.a", "b" } } },
					new { except = new { field = new { groups = new[] { "group1", "group2" } } } }
				}
			}
		};

		protected override int ExpectStatusCode => 200;

		protected override Func<PutRoleMappingDescriptor, IPutRoleMappingRequest> Fluent => d => d
			.Enabled()
			.Roles("admin")
			.Metadata(f => f.Add("x", "y").Add("z", null))
			.Rules(r => r
				.All(all => all
					.Any(any => any
						.DistinguishedName(_dn)
						.Username(_username)
						.Realm(_realm)
					)
					.Metadata(_metadata.Item1, _metadata.Item2)
					.Except(e => e.Groups(_groups))
				)
			);

		protected override HttpMethod HttpMethod => HttpMethod.PUT;

		protected override PutRoleMappingRequest Initializer => new PutRoleMappingRequest(Role)
		{
			Enabled = true,
			Roles = new[] { "admin" },
			Metadata = new Dictionary<string, object>
			{
				{ "x", "y" },
				{ "z", null }
			},
			Rules =
				(new DistinguishedNameRule(_dn) | new UsernameRule(_username) | new RealmRule(_realm))
				& new MetadataRule(_metadata.Item1, _metadata.Item2)
				& !new GroupsRule(_groups)
		};

		protected override bool SupportsDeserialization => false;

		protected override string UrlPath => $"/_security/role_mapping/{Role}";

		//callisolated value can sometimes start with a digit which is not allowed for rolenames
		private string Role => $"role-{CallIsolatedValue}";

		protected override LazyResponses ClientUsage() => Calls(
			(client, f) => client.Security.PutRoleMapping(Role, f),
			(client, f) => client.Security.PutRoleMappingAsync(Role, f),
			(client, r) => client.Security.PutRoleMapping(r),
			(client, r) => client.Security.PutRoleMappingAsync(r)
		);

		protected override PutRoleMappingDescriptor NewDescriptor() => new PutRoleMappingDescriptor(Role);

		protected override void ExpectResponse(PutRoleMappingResponse response)
		{
			response.RoleMapping.Should().NotBeNull();
			response.RoleMapping.Created.Should().BeTrue();
		}
	}
}
