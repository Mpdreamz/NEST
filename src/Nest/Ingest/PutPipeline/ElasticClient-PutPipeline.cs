﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <inheritdoc />
		PutPipelineResponse PutPipeline(Id id, Func<PutPipelineDescriptor, IPutPipelineRequest> selector);

		/// <inheritdoc />
		PutPipelineResponse PutPipeline(IPutPipelineRequest request);

		/// <inheritdoc />
		Task<PutPipelineResponse> PutPipelineAsync(Id id, Func<PutPipelineDescriptor, IPutPipelineRequest> selector,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc />
		Task<PutPipelineResponse> PutPipelineAsync(IPutPipelineRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		public PutPipelineResponse PutPipeline(Id id, Func<PutPipelineDescriptor, IPutPipelineRequest> selector) =>
			PutPipeline(selector?.Invoke(new PutPipelineDescriptor(id)));

		public PutPipelineResponse PutPipeline(IPutPipelineRequest request) =>
			DoRequest<IPutPipelineRequest, PutPipelineResponse>(request, request.RequestParameters);

		public Task<PutPipelineResponse> PutPipelineAsync(
			Id id,
			Func<PutPipelineDescriptor, IPutPipelineRequest> selector,
			CancellationToken cancellationToken = default
		) => PutPipelineAsync(selector?.Invoke(new PutPipelineDescriptor(id)), cancellationToken);

		public Task<PutPipelineResponse> PutPipelineAsync(IPutPipelineRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IPutPipelineRequest, PutPipelineResponse, PutPipelineResponse>(request, request.RequestParameters, ct);
	}
}
