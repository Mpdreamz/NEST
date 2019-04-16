﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Clear a cursor returned by <see cref="QuerySqlResponse.Cursor" />. Not that this is only necessary if you wish to bail out early
		/// </summary>
		ClearSqlCursorResponse ClearSqlCursor(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		ClearSqlCursorResponse ClearSqlCursor(IClearSqlCursorRequest request);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		Task<ClearSqlCursorResponse> ClearSqlCursorAsync(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		Task<ClearSqlCursorResponse> ClearSqlCursorAsync(IClearSqlCursorRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		public ClearSqlCursorResponse ClearSqlCursor(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null) =>
			ClearSqlCursor(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()));

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		public ClearSqlCursorResponse ClearSqlCursor(IClearSqlCursorRequest request) =>
			DoRequest<IClearSqlCursorRequest, ClearSqlCursorResponse>(request, request.RequestParameters);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		public Task<ClearSqlCursorResponse> ClearSqlCursorAsync(
			Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector = null,
			CancellationToken ct = default
		) => ClearSqlCursorAsync(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()), ct);

		/// <inheritdoc cref="ClearSqlCursor(System.Func{Nest.ClearSqlCursorDescriptor,Nest.IClearSqlCursorRequest})" />
		public Task<ClearSqlCursorResponse> ClearSqlCursorAsync(IClearSqlCursorRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IClearSqlCursorRequest, ClearSqlCursorResponse, ClearSqlCursorResponse>
				(request, request.RequestParameters, ct);
	}
}
