﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Deletes a machine learning calendar.
		/// Removes all scheduled events from the calendar then deletes the calendar.
		/// </summary>
		DeleteCalendarResponse DeleteCalendar(Id calendarId, Func<DeleteCalendarDescriptor, IDeleteCalendarRequest> selector = null);

		/// <inheritdoc cref="DeleteCalendar(Nest.Id,System.Func{Nest.DeleteCalendarDescriptor,Nest.IDeleteCalendarRequest})" />
		DeleteCalendarResponse DeleteCalendar(IDeleteCalendarRequest request);

		/// <inheritdoc cref="DeleteCalendar(Nest.Id,System.Func{Nest.DeleteCalendarDescriptor,Nest.IDeleteCalendarRequest})" />
		Task<DeleteCalendarResponse> DeleteCalendarAsync(Id calendarId, Func<DeleteCalendarDescriptor, IDeleteCalendarRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc cref="DeleteCalendar(Nest.Id,System.Func{Nest.DeleteCalendarDescriptor,Nest.IDeleteCalendarRequest})" />
		Task<DeleteCalendarResponse> DeleteCalendarAsync(IDeleteCalendarRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public DeleteCalendarResponse DeleteCalendar(Id calendarId, Func<DeleteCalendarDescriptor, IDeleteCalendarRequest> selector = null) =>
			DeleteCalendar(selector.InvokeOrDefault(new DeleteCalendarDescriptor(calendarId)));

		/// <inheritdoc />
		public DeleteCalendarResponse DeleteCalendar(IDeleteCalendarRequest request) =>
			DoRequest<IDeleteCalendarRequest, DeleteCalendarResponse>(request, request.RequestParameters);

		/// <inheritdoc />
		public Task<DeleteCalendarResponse> DeleteCalendarAsync(Id calendarId, Func<DeleteCalendarDescriptor, IDeleteCalendarRequest> selector = null,
			CancellationToken ct = default
		) =>
			DeleteCalendarAsync(selector.InvokeOrDefault(new DeleteCalendarDescriptor(calendarId)), ct);

		/// <inheritdoc />
		public Task<DeleteCalendarResponse> DeleteCalendarAsync(IDeleteCalendarRequest request, CancellationToken ct = default) =>
			DoRequestAsync<IDeleteCalendarRequest, DeleteCalendarResponse, DeleteCalendarResponse>(request, request.RequestParameters, ct);
	}
}
