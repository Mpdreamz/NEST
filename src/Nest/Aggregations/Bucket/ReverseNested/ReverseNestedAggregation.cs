﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<ReverseNestedAggregation>))]
	public interface IReverseNestedAggregation : IBucketAggregation
	{
		[JsonProperty("path")]
		Field Path { get; set; }
	}

	[AggregateType(typeof(SingleBucketAggregate))]
	public class ReverseNestedAggregation : BucketAggregationBase, IReverseNestedAggregation
	{
		[JsonProperty("path")]
		public Field Path { get; set; }

		internal ReverseNestedAggregation() { }

		public ReverseNestedAggregation(string name) : base(name) { }

		internal override void WrapInContainer(AggregationContainer c) => c.ReverseNested = this;
	}

	[AggregateType(typeof(SingleBucketAggregate))]
	public class ReverseNestedAggregationDescriptor<T> 
		: BucketAggregationDescriptorBase<ReverseNestedAggregationDescriptor<T>,IReverseNestedAggregation, T>
			, IReverseNestedAggregation 
		where T : class
	{
		Field IReverseNestedAggregation.Path { get; set; }

		public ReverseNestedAggregationDescriptor<T> Path(string path) => Assign(a => a.Path = path);

		public ReverseNestedAggregationDescriptor<T> Path(Expression<Func<T, object>> path) => Assign(a => a.Path = path);
	}
}
