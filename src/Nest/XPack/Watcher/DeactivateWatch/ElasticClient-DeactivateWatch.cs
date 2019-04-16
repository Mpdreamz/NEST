﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deactivates a currently active watch.
		/// </summary>
		DeactivateWatchResponse DeactivateWatch(Id id, Func<DeactivateWatchDescriptor, IDeactivateWatchRequest> selector = null);

		/// <inheritdoc />
		DeactivateWatchResponse DeactivateWatch(IDeactivateWatchRequest request);

		/// <inheritdoc />
		Task<DeactivateWatchResponse> DeactivateWatchAsync(Id id, Func<DeactivateWatchDescriptor, IDeactivateWatchRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc />
		Task<DeactivateWatchResponse> DeactivateWatchAsync(IDeactivateWatchRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public DeactivateWatchResponse DeactivateWatch(Id id, Func<DeactivateWatchDescriptor, IDeactivateWatchRequest> selector = null) =>
			DeactivateWatch(selector.InvokeOrDefault(new DeactivateWatchDescriptor(id)));

		/// <inheritdoc />
		public DeactivateWatchResponse DeactivateWatch(IDeactivateWatchRequest request) =>
			DoRequest<IDeactivateWatchRequest, DeactivateWatchResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<DeactivateWatchResponse> DeactivateWatchAsync(
			Id id,
			Func<DeactivateWatchDescriptor, IDeactivateWatchRequest> selector = null,
			CancellationToken ct = default
		) => DeactivateWatchAsync(selector.InvokeOrDefault(new DeactivateWatchDescriptor(id)), ct);

		/// <inheritdoc />
		public Task<DeactivateWatchResponse> DeactivateWatchAsync(IDeactivateWatchRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IDeactivateWatchRequest, DeactivateWatchResponse, DeactivateWatchResponse>
				(request, request.RequestParameters, ct);
	}
}
