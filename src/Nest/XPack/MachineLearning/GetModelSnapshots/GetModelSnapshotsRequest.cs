using System;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	/// <summary>
	/// Retrieve usage information for machine learning jobs.
	/// </summary>
	[MapsApi("ml.get_model_snapshots.json")]
	public partial interface IGetModelSnapshotsRequest
	{
		/// <summary>
		/// If true, the results are sorted in descending order.
		/// </summary>
		[DataMember(Name = "desc")]
		bool? Descending { get; set; }

		/// <summary>
		/// Returns snapshots with timestamps earlier than this time.
		/// </summary>
		[DataMember(Name = "end")]
		[JsonFormatter(typeof(NullableDateTimeOffsetEpochMillisecondsFormatter))]
		DateTimeOffset? End { get; set; }

		/// <summary>
		/// Specifies pagination for the snapshots.
		/// </summary>
		[DataMember(Name = "page")]
		IPage Page { get; set; }

		/// <summary>
		/// Specifies the sort field for the requested snapshots. By default, snapshots are sorted by their timestamp.
		/// </summary>
		[DataMember(Name = "sort")]
		Field Sort { get; set; }

		/// <summary>
		/// Returns snapshots with timestamps after this time.
		/// </summary>
		[DataMember(Name = "start")]
		[JsonFormatter(typeof(NullableDateTimeOffsetEpochMillisecondsFormatter))]
		DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	public partial class GetModelSnapshotsRequest
	{
		/// <inheritdoc />
		public bool? Descending { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? End { get; set; }

		/// <inheritdoc />
		public IPage Page { get; set; }

		/// <inheritdoc />
		public Field Sort { get; set; }

		/// <inheritdoc />
		public DateTimeOffset? Start { get; set; }
	}

	/// <inheritdoc />
	public partial class GetModelSnapshotsDescriptor
	{
		bool? IGetModelSnapshotsRequest.Descending { get; set; }
		DateTimeOffset? IGetModelSnapshotsRequest.End { get; set; }
		IPage IGetModelSnapshotsRequest.Page { get; set; }
		Field IGetModelSnapshotsRequest.Sort { get; set; }
		DateTimeOffset? IGetModelSnapshotsRequest.Start { get; set; }

		/// <inheritdoc />
		public GetModelSnapshotsDescriptor Descending(bool? desc = true) => Assign(a => a.Descending = desc);

		/// <inheritdoc />
		public GetModelSnapshotsDescriptor End(DateTimeOffset? end) => Assign(a => a.End = end);

		/// <inheritdoc />
		public GetModelSnapshotsDescriptor Page(Func<PageDescriptor, IPage> selector) =>
			Assign(a => a.Page = selector?.Invoke(new PageDescriptor()));

		/// <inheritdoc />
		public GetModelSnapshotsDescriptor Sort(Field field) => Assign(a => a.Sort = field);

		/// <inheritdoc />
		public GetModelSnapshotsDescriptor Start(DateTimeOffset? start) => Assign(a => a.Start = start);
	}
}
