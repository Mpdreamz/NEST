﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	using TypeExistConverter = Func<IApiCallDetails, Stream, ExistsResponse>;

	public static partial class ElasticClientExtensions
	{
		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static ExistsResponse TypeExists(this IElasticClient client, Indices indices, string type,
			Func<TypeExistsDescriptor, ITypeExistsRequest> selector = null
		)
			=> client.Indices.TypeExists(indices, type, selector);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static ExistsResponse TypeExists(this IElasticClient client, ITypeExistsRequest request)
			=> client.Indices.TypeExists(request);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static Task<ExistsResponse> TypeExistsAsync(this IElasticClient client, Indices indices, string type,
			Func<TypeExistsDescriptor, ITypeExistsRequest> selector = null,
			CancellationToken ct = default
		)
			=> client.Indices.TypeExistsAsync(indices, type, selector, ct);

		/// <inheritdoc />
		[Obsolete("Moved to client.XX.XX(), please update this usage.")]
public static Task<ExistsResponse> TypeExistsAsync(this IElasticClient client, ITypeExistsRequest request, CancellationToken ct = default)
			=> client.Indices.TypeExistsAsync(request, ct);
	}
}
