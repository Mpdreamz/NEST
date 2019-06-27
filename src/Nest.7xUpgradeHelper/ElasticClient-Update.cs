﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public static partial class ElasticClientExtensions
	{
		/// <summary>
		/// The update API allows to update a document based on a script provided.
		/// <para>
		/// The operation gets the document (collocated with the shard) from the index, runs the script
		/// (with optional script language and parameters), and index back the result
		/// (also allows to delete, or ignore the operation).
		/// </para>
		/// <para>It uses versioning to make sure no updates have happened during the "get" and "reindex".</para>
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/docs-update.html
		/// </summary>
		/// <typeparam name="TDocument">The type to describe the document to be updated</typeparam>
		/// <param name="selector">a descriptor that describes the update operation</param>
		public static UpdateResponse<TDocument> Update<TDocument>(this IElasticClient client,DocumentPath<TDocument> documentPath,
			Func<UpdateDescriptor<TDocument, TDocument>, IUpdateRequest<TDocument, TDocument>> selector
		) where TDocument : class;

		/// <inheritdoc />
		public static UpdateResponse<TDocument> Update<TDocument>(this IElasticClient client,IUpdateRequest<TDocument, TDocument> request) where TDocument : class;

		/// <inheritdoc />
		UpdateResponse<TDocument> Update<TDocument, TPartialDocument>(DocumentPath<TDocument> documentPath,
			Func<UpdateDescriptor<TDocument, TPartialDocument>, IUpdateRequest<TDocument, TPartialDocument>> selector
		)
			where TDocument : class
			where TPartialDocument : class;

		/// <inheritdoc />
		UpdateResponse<TDocument> Update<TDocument, TPartialDocument>(IUpdateRequest<TDocument, TPartialDocument> request)
			where TDocument : class
			where TPartialDocument : class;

		/// <inheritdoc />
		public static Task<UpdateResponse<TDocument>> UpdateAsync<TDocument>(this IElasticClient client,
			DocumentPath<TDocument> documentPath,
			Func<UpdateDescriptor<TDocument, TDocument>, IUpdateRequest<TDocument, TDocument>> selector,
			CancellationToken ct = default
		) where TDocument : class;

		/// <inheritdoc />
		public static Task<UpdateResponse<TDocument>> UpdateAsync<TDocument>(this IElasticClient client,
			IUpdateRequest<TDocument, TDocument> request,
			CancellationToken ct = default
		) where TDocument : class;

		/// <inheritdoc />
		Task<UpdateResponse<TDocument>> UpdateAsync<TDocument, TPartialDocument>(
			DocumentPath<TDocument> documentPath,
			Func<UpdateDescriptor<TDocument, TPartialDocument>, IUpdateRequest<TDocument, TPartialDocument>> selector,
			CancellationToken ct = default
		)
			where TDocument : class
			where TPartialDocument : class;

		/// <inheritdoc />
		Task<UpdateResponse<TDocument>> UpdateAsync<TDocument, TPartialDocument>(
			IUpdateRequest<TDocument, TPartialDocument> request,
			CancellationToken ct = default
		)
			where TDocument : class
			where TPartialDocument : class;
	}


}
