﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Starts the Watcher/Alerting service, if the service is not already running
		/// </summary>
		StartWatcherResponse StartWatcher(Func<StartWatcherDescriptor, IStartWatcherRequest> selector = null);

		/// <inheritdoc />
		StartWatcherResponse StartWatcher(IStartWatcherRequest request);

		/// <inheritdoc />
		Task<StartWatcherResponse> StartWatcherAsync(Func<StartWatcherDescriptor, IStartWatcherRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc />
		Task<StartWatcherResponse> StartWatcherAsync(IStartWatcherRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public StartWatcherResponse StartWatcher(Func<StartWatcherDescriptor, IStartWatcherRequest> selector = null) =>
			StartWatcher(selector.InvokeOrDefault(new StartWatcherDescriptor()));

		/// <inheritdoc />
		public StartWatcherResponse StartWatcher(IStartWatcherRequest request) =>
			DoRequest<IStartWatcherRequest, StartWatcherResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<StartWatcherResponse> StartWatcherAsync(
			Func<StartWatcherDescriptor, IStartWatcherRequest> selector = null,
			CancellationToken ct = default
		) => StartWatcherAsync(selector.InvokeOrDefault(new StartWatcherDescriptor()), ct);

		/// <inheritdoc />
		public Task<StartWatcherResponse> StartWatcherAsync(IStartWatcherRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IStartWatcherRequest, StartWatcherResponse>
				(request, request.RequestParameters, ct);
	}
}
