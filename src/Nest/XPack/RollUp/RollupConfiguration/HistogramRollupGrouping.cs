﻿using System;
using System.Runtime.Serialization;

namespace Nest
{
	/// <summary> The histogram group aggregates one or more numeric fields into numeric histogram intervals. </summary>
	[ReadAs(typeof(HistogramRollupGrouping))]
	public interface IHistogramRollupGrouping
	{
		/// <summary>
		/// The set of fields that you wish to build histograms for. All fields specified must be some kind of numeric. Order does not matter
		/// </summary>
		[DataMember(Name ="fields")]
		Fields Fields { get; set; }

		/// <summary>
		/// The interval of histogram buckets to be generated when rolling up. Note that only one interval can be specified in the
		/// histogram group, meaning that all fields being grouped via the histogram must share the same interval.
		/// </summary>
		[DataMember(Name ="interval")]
		long? Interval { get; set; }
	}

	/// <inheritdoc />
	public class HistogramRollupGrouping : IHistogramRollupGrouping
	{
		/// <inheritdoc />
		public Fields Fields { get; set; }

		/// <inheritdoc />
		public long? Interval { get; set; }
	}

	/// <inheritdoc cref="IHistogramRollupGrouping" />
	public class HistogramRollupGroupingDescriptor<T>
		: DescriptorBase<HistogramRollupGroupingDescriptor<T>, IHistogramRollupGrouping>, IHistogramRollupGrouping
		where T : class
	{
		Fields IHistogramRollupGrouping.Fields { get; set; }
		long? IHistogramRollupGrouping.Interval { get; set; }

		/// <inheritdoc cref="IHistogramRollupGrouping.Fields" />
		public HistogramRollupGroupingDescriptor<T> Fields(Func<FieldsDescriptor<T>, IPromise<Fields>> fields) =>
			Assign(a => a.Fields = fields?.Invoke(new FieldsDescriptor<T>())?.Value);

		/// <inheritdoc cref="IHistogramRollupGrouping.Fields" />
		public HistogramRollupGroupingDescriptor<T> Fields(Fields fields) => Assign(a => a.Fields = fields);

		/// <inheritdoc cref="IHistogramRollupGrouping.Interval" />
		public HistogramRollupGroupingDescriptor<T> Interval(long? interval) => Assign(a => a.Interval = interval);
	}
}
