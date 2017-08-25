using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<HistogramAggregation>))]
	public interface IHistogramAggregation : IBucketAggregation
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }

		[JsonProperty("interval")]
		double? Interval { get; set; }

		[JsonProperty("min_doc_count")]
		int? MinimumDocumentCount { get; set; }

		[JsonProperty("order")]
		HistogramOrder Order { get; set; }

		[JsonProperty("extended_bounds")]
		ExtendedBounds<double> ExtendedBounds { get; set; }

		[Obsolete("Removed in Elasticsearch 2.0. Will be removed in the next major version of NEST")]
		long? PreOffset { get; set; }

		[Obsolete("Removed in Elasticsearch 2.0. Will be removed in the next major version of NEST")]
		long? PostOffset { get; set; }

		[JsonProperty("offset")]
		double? Offset { get; set; }

		[JsonProperty("missing")]
		double? Missing { get; set; }
	}

	public class HistogramAggregation : BucketAggregationBase, IHistogramAggregation
	{
		public Field Field { get; set; }
		public IScript Script { get; set; }
		public double? Interval { get; set; }
		public int? MinimumDocumentCount { get; set; }
		public HistogramOrder Order { get; set; }
		public ExtendedBounds<double> ExtendedBounds { get; set; }
		public long? PreOffset { get; set; }
		public long? PostOffset { get; set; }
		public double? Offset { get; set; }
		public double? Missing { get; set; }

		internal HistogramAggregation() { }

		public HistogramAggregation(string name) : base(name) { }

		internal override void WrapInContainer(AggregationContainer c) => c.Histogram = this;
	}

	public class HistogramAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<HistogramAggregationDescriptor<T>, IHistogramAggregation, T>, IHistogramAggregation
		where T : class
	{
		Field IHistogramAggregation.Field { get; set; }

		IScript IHistogramAggregation.Script { get; set; }

		double? IHistogramAggregation.Interval { get; set; }

		int? IHistogramAggregation.MinimumDocumentCount { get; set; }

		HistogramOrder IHistogramAggregation.Order { get; set; }

		ExtendedBounds<double> IHistogramAggregation.ExtendedBounds { get; set; }

		long? IHistogramAggregation.PreOffset { get; set; }
		
		long? IHistogramAggregation.PostOffset { get; set; }
		
		double? IHistogramAggregation.Offset { get; set; }

		double? IHistogramAggregation.Missing { get; set; }

		public HistogramAggregationDescriptor<T> Field(Field field) => Assign(a => a.Field = field);

		public HistogramAggregationDescriptor<T> Field(Expression<Func<T, object>> field) => Assign(a => a.Field = field);

		public HistogramAggregationDescriptor<T> Script(string script) => Assign(a => a.Script = (InlineScript)script);

		public HistogramAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(a => a.Script = scriptSelector?.Invoke(new ScriptDescriptor()));

		public HistogramAggregationDescriptor<T> Interval(double interval) => Assign(a => a.Interval = interval);

		public HistogramAggregationDescriptor<T> MinimumDocumentCount(int minimumDocumentCount) =>
			Assign(a => a.MinimumDocumentCount = minimumDocumentCount);

		public HistogramAggregationDescriptor<T> Order(HistogramOrder order) => Assign(a => a.Order = order);

		public HistogramAggregationDescriptor<T> OrderAscending(string key) =>
			Assign(a => a.Order = new HistogramOrder { Key = key, Order = SortOrder.Descending });

		public HistogramAggregationDescriptor<T> OrderDescending(string key) =>
			Assign(a => a.Order = new HistogramOrder { Key = key, Order = SortOrder.Descending });

		public HistogramAggregationDescriptor<T> ExtendedBounds(double min, double max) =>
			Assign(a => a.ExtendedBounds = new ExtendedBounds<double> { Minimum = min, Maximum = max });

		[Obsolete("Removed in Elasticsearch 2.0. Will be removed in the next major version of NEST")]
		public HistogramAggregationDescriptor<T> PreOffset(long preOffset) => this;

		[Obsolete("Removed in Elasticsearch 2.0. Will be removed in the next major version of NEST")]
		public HistogramAggregationDescriptor<T> PostOffset(long postOffset) => this;
		
		public HistogramAggregationDescriptor<T> Offset(double offset) => Assign(a => a.Offset = offset);

		public HistogramAggregationDescriptor<T> Missing(double missing) => Assign(a => a.Missing = missing);
	}
}
