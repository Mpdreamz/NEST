﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net_5_2_0;
using System.Threading;

namespace Nest_5_2_0
{
	public partial interface IElasticClient
	{
		/// <inheritdoc/>
		IDisableUserResponse DisableUser(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null);

		/// <inheritdoc/>
		IDisableUserResponse DisableUser(IDisableUserRequest request);

		/// <inheritdoc/>
		Task<IDisableUserResponse> DisableUserAsync(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null, CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<IDisableUserResponse> DisableUserAsync(IDisableUserRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public IDisableUserResponse DisableUser(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null) =>
			this.DisableUser(selector.InvokeOrDefault(new DisableUserDescriptor()));

		/// <inheritdoc/>
		public IDisableUserResponse DisableUser(IDisableUserRequest request) =>
			this.Dispatcher.Dispatch<IDisableUserRequest, DisableUserRequestParameters, DisableUserResponse>(
				request,
				(p, d) =>this.LowLevelDispatch.XpackSecurityDisableUserDispatch<DisableUserResponse>(p)
			);

		/// <inheritdoc/>
		public Task<IDisableUserResponse> DisableUserAsync(Name username, Func<DisableUserDescriptor, IDisableUserRequest> selector = null, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.DisableUserAsync(selector.InvokeOrDefault(new DisableUserDescriptor()), cancellationToken);

		/// <inheritdoc/>
		public Task<IDisableUserResponse> DisableUserAsync(IDisableUserRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IDisableUserRequest, DisableUserRequestParameters, DisableUserResponse, IDisableUserResponse>(
				request,
				cancellationToken,
				(p, d, c) => this.LowLevelDispatch.XpackSecurityDisableUserDispatchAsync<DisableUserResponse>(p, c)
			);
	}
}
