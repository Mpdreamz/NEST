using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<AnonymousFiltersAggregation>))]
	[AggregateType(typeof(AnonymousFiltersAggregate))]
	public interface IAnonymousFiltersAggregation : IFiltersAggregation
	{
		[JsonProperty("filters")]
		List<QueryContainer> Filters { get; set; }
	}

	public class AnonymousFiltersAggregation : FiltersAggregationBase, IAnonymousFiltersAggregation
	{
		public List<QueryContainer> Filters { get; set; }

		public AnonymousFiltersAggregation(string name) : base(name) { }

		internal override void WrapInContainer(AggregationContainer c) => c.Filters = this;
	}

	public class AnonymousFiltersAggregationDescriptor<T>
		: FiltersAggregationDescriptorBase<AnonymousFiltersAggregationDescriptor<T>, IAnonymousFiltersAggregation, T>
		, IAnonymousFiltersAggregation
		where T : class
	{
		List<QueryContainer> IAnonymousFiltersAggregation.Filters { get; set; }

		public AnonymousFiltersAggregationDescriptor<T> Filters(params Func<QueryContainerDescriptor<T>, QueryContainer>[] selectors) =>
			Assign(a => a.Filters = selectors.Select(s=>s?.InvokeQuery(new QueryContainerDescriptor<T>())).ToList());

		public AnonymousFiltersAggregationDescriptor<T> Filters(IEnumerable<Func<QueryContainerDescriptor<T>, QueryContainer>> selectors) =>
			Assign(a => a.Filters = selectors.Select(s=>s?.InvokeQuery(new QueryContainerDescriptor<T>())).ToList());
	}
}
