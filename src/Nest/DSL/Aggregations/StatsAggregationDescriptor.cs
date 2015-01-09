﻿using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeConverter<StatsAggregator>))]
	public interface IStatsAggregator : IMetricAggregator
	{
	}

	public class StatsAggregator : MetricAggregator, IStatsAggregator
	{
	}

	public class StatsAggregationDescriptor<T> : MetricAggregationBaseDescriptor<StatsAggregationDescriptor<T>, T>, IStatsAggregator where T : class
	{
		
	}
}
