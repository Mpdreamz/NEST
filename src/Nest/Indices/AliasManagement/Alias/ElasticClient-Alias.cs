﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// APIs in elasticsearch accept an index name when working against a specific index, and several indices when applicable.
		/// <para>
		/// The index aliases API allow to alias an index with a name, with all APIs automatically converting the alias name to the
		/// actual index name.
		/// </para>
		/// <para>
		/// An alias can also be mapped to more than one index, and when specifying it, the alias
		/// will automatically expand to the aliases indices.i
		/// </para>
		/// <para>
		/// An alias can also be associated with a filter that will
		/// automatically be applied when searching, and routing values.
		/// </para>
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-aliases.html
		/// </summary>
		/// <param name="selector">A descriptor that describes the parameters for the alias operation</param>
		BulkAliasResponse Alias(Func<BulkAliasDescriptor, IBulkAliasRequest> selector);

		/// <inheritdoc />
		BulkAliasResponse Alias(IBulkAliasRequest request);

		/// <inheritdoc />
		Task<BulkAliasResponse> AliasAsync(Func<BulkAliasDescriptor, IBulkAliasRequest> selector,
			CancellationToken ct = default
		);

		/// <inheritdoc />
		Task<BulkAliasResponse> AliasAsync(IBulkAliasRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public BulkAliasResponse Alias(IBulkAliasRequest request) =>
			DoRequest<IBulkAliasRequest, BulkAliasResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public BulkAliasResponse Alias(Func<BulkAliasDescriptor, IBulkAliasRequest> selector) =>
			Alias(selector?.Invoke(new BulkAliasDescriptor()));

		/// <inheritdoc />
		public Task<BulkAliasResponse> AliasAsync(IBulkAliasRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IBulkAliasRequest, BulkAliasResponse, BulkAliasResponse>(request, request.RequestParameters, ct);

		/// <inheritdoc />
		public Task<BulkAliasResponse> AliasAsync(Func<BulkAliasDescriptor, IBulkAliasRequest> selector, CancellationToken ct = default) =>
			AliasAsync(selector?.Invoke(new BulkAliasDescriptor()), ct);
	}
}
