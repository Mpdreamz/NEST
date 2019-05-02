﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Provide low level segments information that a Lucene index (shard level) is built with.
		/// Allows to be used to provide more information on the state of a shard and an index, possibly optimization information,
		/// data "wasted" on deletes, and so on.
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-segments.html
		/// </summary>
		/// <param name="selector">A descriptor that describes the parameters for the segments operation</param>
		SegmentsResponse Segments(Indices indices, Func<SegmentsDescriptor, ISegmentsRequest> selector = null);

		/// <inheritdoc />
		SegmentsResponse Segments(ISegmentsRequest request);

		/// <inheritdoc />
		Task<SegmentsResponse> SegmentsAsync(
			Indices indices,
			Func<SegmentsDescriptor, ISegmentsRequest> selector = null,
			CancellationToken cancellationToken = default
		);

		/// <inheritdoc />
		Task<SegmentsResponse> SegmentsAsync(ISegmentsRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public SegmentsResponse Segments(Indices indices, Func<SegmentsDescriptor, ISegmentsRequest> selector = null) =>
			Segments(selector.InvokeOrDefault(new SegmentsDescriptor().Index(indices)));

		/// <inheritdoc />
		public SegmentsResponse Segments(ISegmentsRequest request) =>
			DoRequest<ISegmentsRequest, SegmentsResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<SegmentsResponse> SegmentsAsync(
			Indices indices,
			Func<SegmentsDescriptor, ISegmentsRequest> selector = null,
			CancellationToken cancellationToken = default
		) => SegmentsAsync(selector.InvokeOrDefault(new SegmentsDescriptor().Index(indices)), cancellationToken);

		/// <inheritdoc />
		public Task<SegmentsResponse> SegmentsAsync(ISegmentsRequest request, CancellationToken ct = default) =>
			DoRequestAsync<ISegmentsRequest, SegmentsResponse>(request, request.RequestParameters, ct);
	}
}
