﻿using System.Collections.Generic;
using System.Linq;
using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework;
using Tests.Framework.Integration;

namespace Tests.XPack.Security.Role
{
	[SkipVersion("<2.3.0", "")]
	public class RoleCrudTests
		: CrudTestBase<XPackCluster, IPutRoleResponse, IGetRoleResponse, IPutRoleResponse, IDeleteRoleResponse>
	{
		public RoleCrudTests(XPackCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		//callisolated value can sometimes start with a digit which is not allowed for rolenames
		private string CreateRoleName(string s) => $"role-{s}";

		protected override LazyResponses Create() => Calls<PutRoleDescriptor, PutRoleRequest, IPutRoleRequest, IPutRoleResponse>(
			CreateInitializer,
			CreateFluent,
			(s, c, f) => c.PutRole(CreateRoleName(s), f),
			(s, c, f) => c.PutRoleAsync(CreateRoleName(s), f),
			(s, c, r) => c.PutRole(r),
			(s, c, r) => c.PutRoleAsync(r)
		);

		protected PutRoleRequest CreateInitializer(string role) => new PutRoleRequest(CreateRoleName(role))
		{
			Cluster = new[] { "all" },
			Indices = new List<IIndicesPrivileges>
			{
				new IndicesPrivileges
				{
					FieldSecurity = new FieldSecurity
					{
						Grant = Infer.Fields<Project>(p => p.Name).And<Project>(p => p.Description),
					},
					Names = Infer.Indices<Project>(),
					Privileges = new[] { "all" },
					Query = new MatchAllQuery()
				}
			}
		};

		protected IPutRoleRequest CreateFluent(string role, PutRoleDescriptor d) => d
			.Cluster("all")
			.Indices(i => i
				.Add<Project>(ii => ii
					.FieldSecurity(fs => fs
						.Grant(f => f
							.Field(p => p.Name)
							.Field(p => p.Description)
						)
					)
					.Names(Infer.Indices<Project>())
					.Privileges("all")
					.Query(q => q.MatchAll())
				)
			);

		protected override LazyResponses Read() => Calls<GetRoleDescriptor, GetRoleRequest, IGetRoleRequest, IGetRoleResponse>(
			ReadInitializer,
			ReadFluent,
			(s, c, f) => c.GetRole(f),
			(s, c, f) => c.GetRoleAsync(f),
			(s, c, r) => c.GetRole(r),
			(s, c, r) => c.GetRoleAsync(r)
		);

		protected GetRoleRequest ReadInitializer(string role) => new GetRoleRequest(CreateRoleName(role));

		protected IGetRoleRequest ReadFluent(string role, GetRoleDescriptor d) => d.Name(CreateRoleName(role));

		protected override LazyResponses Update() => Calls<PutRoleDescriptor, PutRoleRequest, IPutRoleRequest, IPutRoleResponse>(
			UpdateInitializer,
			UpdateFluent,
			(s, c, f) => c.PutRole(CreateRoleName(s), f),
			(s, c, f) => c.PutRoleAsync(CreateRoleName(s), f),
			(s, c, r) => c.PutRole(r),
			(s, c, r) => c.PutRoleAsync(r)
		);

		protected PutRoleRequest UpdateInitializer(string role) => new PutRoleRequest(CreateRoleName(role))
		{
			Cluster = new[] { "all" },
			RunAs = new[] { "user" },
			Indices = new List<IIndicesPrivileges>
			{
				new IndicesPrivileges
				{
					FieldSecurity = new FieldSecurity
					{
						Grant = Infer.Fields<Project>(p => p.Name).And<Project>(p => p.Description)
					},
					Names = Infer.Indices<Project>(),
					Privileges = new[] { "all" },
					Query = new MatchAllQuery()
				}
			}
		};

		protected IPutRoleRequest UpdateFluent(string role, PutRoleDescriptor d) => d
			.RunAs("user")
			.Cluster("all")
			.Indices(i => i
				.Add<Project>(ii => ii
					.FieldSecurity(fs => fs
						.Grant(f => f
							.Field(p => p.Name)
							.Field(p => p.Description)
						)
					)
					.Names(Infer.Indices<Project>())
					.Privileges("all")
					.Query(q => q.MatchAll())
				)
			);

		protected override LazyResponses Delete() => Calls<DeleteRoleDescriptor, DeleteRoleRequest, IDeleteRoleRequest, IDeleteRoleResponse>(
			DeleteInitializer,
			DeleteFluent,
			(s, c, f) => c.DeleteRole(CreateRoleName(s), f),
			(s, c, f) => c.DeleteRoleAsync(CreateRoleName(s), f),
			(s, c, r) => c.DeleteRole(r),
			(s, c, r) => c.DeleteRoleAsync(r)
		);

		protected DeleteRoleRequest DeleteInitializer(string role) => new DeleteRoleRequest(CreateRoleName(role));

		protected IDeleteRoleRequest DeleteFluent(string role, DeleteRoleDescriptor d) => d;

		protected override void ExpectAfterCreate(IGetRoleResponse response)
		{
			response.Roles.Should().NotBeEmpty();
			var role = response.Roles.First().Value;
			role.Cluster.Should().NotBeNullOrEmpty().And.Contain("all");
			role.RunAs.Should().BeNullOrEmpty();
			role.Indices.Should().NotBeNullOrEmpty().And.HaveCount(1);

			var indexPrivilege = role.Indices.First();
			indexPrivilege.Names.Should().NotBeNull().And.Be(Infer.Indices("project"));
			indexPrivilege.FieldSecurity.Should().NotBeNull();
			indexPrivilege.FieldSecurity.Grant.Should().NotBeNull().And.HaveCount(2);
			indexPrivilege.Privileges.Should().NotBeNull().And.Contain("all");
			indexPrivilege.Query.Should().NotBeNull();
			var q = indexPrivilege.Query as IQueryContainer;
			q.MatchAll.Should().NotBeNull();
		}

		protected override void ExpectAfterUpdate(IGetRoleResponse response)
		{
			response.Roles.Should().NotBeEmpty();
			var role = response.Roles.First().Value;
			role.Cluster.Should().NotBeNullOrEmpty().And.Contain("all");
			role.RunAs.Should().NotBeNullOrEmpty();
			role.Indices.Should().NotBeNullOrEmpty().And.HaveCount(1);

			var indexPrivilege = role.Indices.First();
			indexPrivilege.Names.Should().NotBeNull().And.Be(Infer.Indices("project"));
			indexPrivilege.FieldSecurity.Should().NotBeNull();
			indexPrivilege.FieldSecurity.Grant.Should().NotBeNull().And.HaveCount(2);
			indexPrivilege.Privileges.Should().NotBeNull().And.Contain("all");
			indexPrivilege.Query.Should().NotBeNull();
			var q = indexPrivilege.Query as IQueryContainer;
			q.MatchAll.Should().NotBeNull();
		}
	}
}
