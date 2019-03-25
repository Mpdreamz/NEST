﻿using System.Runtime.Serialization;
using Utf8Json;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(CardinalityAggregation))]
	public interface ICardinalityAggregation : IMetricAggregation
	{
		[DataMember(Name ="precision_threshold")]
		int? PrecisionThreshold { get; set; }

		[DataMember(Name ="rehash")]
		bool? Rehash { get; set; }
	}

	public class CardinalityAggregation : MetricAggregationBase, ICardinalityAggregation
	{
		internal CardinalityAggregation() { }

		public CardinalityAggregation(string name, Field field) : base(name, field) { }

		public int? PrecisionThreshold { get; set; }
		public bool? Rehash { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Cardinality = this;
	}

	public class CardinalityAggregationDescriptor<T>
		: MetricAggregationDescriptorBase<CardinalityAggregationDescriptor<T>, ICardinalityAggregation, T>
			, ICardinalityAggregation
		where T : class
	{
		int? ICardinalityAggregation.PrecisionThreshold { get; set; }

		bool? ICardinalityAggregation.Rehash { get; set; }

		public CardinalityAggregationDescriptor<T> PrecisionThreshold(int? precisionThreshold)
			=> Assign(a => a.PrecisionThreshold = precisionThreshold);

		public CardinalityAggregationDescriptor<T> Rehash(bool? rehash = true) => Assign(a => a.Rehash = rehash);
	}
}
