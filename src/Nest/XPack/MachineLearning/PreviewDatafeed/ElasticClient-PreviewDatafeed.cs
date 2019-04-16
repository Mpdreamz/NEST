﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Preview a machine learning datafeed.
		/// This preview shows the structure of the data that will be passed to the anomaly detection engine.
		/// </summary>
		PreviewDatafeedResponse<T> PreviewDatafeed<T>(Id datafeedId, Func<PreviewDatafeedDescriptor, IPreviewDatafeedRequest> selector = null);

		/// <inheritdoc />
		PreviewDatafeedResponse<T> PreviewDatafeed<T>(IPreviewDatafeedRequest request);

		/// <inheritdoc />
		Task<PreviewDatafeedResponse<T>> PreviewDatafeedAsync<T>(Id datafeedId,
			Func<PreviewDatafeedDescriptor, IPreviewDatafeedRequest> selector = null, CancellationToken cancellationToken = default
		);

		/// <inheritdoc />
		Task<PreviewDatafeedResponse<T>> PreviewDatafeedAsync<T>(IPreviewDatafeedRequest request,
			CancellationToken ct = default
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public PreviewDatafeedResponse<T>
			PreviewDatafeed<T>(Id datafeedId, Func<PreviewDatafeedDescriptor, IPreviewDatafeedRequest> selector = null) =>
			PreviewDatafeed<T>(selector.InvokeOrDefault(new PreviewDatafeedDescriptor(datafeedId)));

		/// <inheritdoc />
		public PreviewDatafeedResponse<T> PreviewDatafeed<T>(IPreviewDatafeedRequest request)
		{
			request.RequestParameters.DeserializationOverride = PreviewDatafeedResponse<T>;
			return DoRequest<IPreviewDatafeedRequest, PreviewDatafeedResponse<T>>(request, request.RequestParameters);
		}

		/// <inheritdoc />
		public Task<PreviewDatafeedResponse<T>> PreviewDatafeedAsync<T>(Id datafeedId,
			Func<PreviewDatafeedDescriptor, IPreviewDatafeedRequest> selector = null, CancellationToken cancellationToken = default
		) =>
			PreviewDatafeedAsync<T>(selector.InvokeOrDefault(new PreviewDatafeedDescriptor(datafeedId)), cancellationToken);

		/// <inheritdoc />
		public Task<PreviewDatafeedResponse<T>> PreviewDatafeedAsync<T>(IPreviewDatafeedRequest request, CancellationToken ct = default)
		{
			request.RequestParameters.DeserializationOverride = PreviewDatafeedResponse<T>;
			return DoRequestAsync<IPreviewDatafeedRequest, PreviewDatafeedResponse<T>, PreviewDatafeedResponse<T>>(request, request.RequestParameters, ct);
		}

		private PreviewDatafeedResponse<T> PreviewDatafeedResponse<T>(IApiCallDetails response, Stream stream) => response.Success
			? new PreviewDatafeedResponse<T> { Data = ConnectionSettings.RequestResponseSerializer.Deserialize<IReadOnlyCollection<T>>(stream) }
			: null; //ResponseBuilder can handle null, consolidate null coalescing there.
	}
}
