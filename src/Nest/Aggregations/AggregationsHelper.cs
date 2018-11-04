using System;
using System.Collections.Generic;
using System.Linq;

namespace Nest
{
	public class AggregationsHelper
	{
		public AggregationsHelper() { }

		protected AggregationsHelper(IDictionary<string, IAggregate> aggregations) => Aggregations = aggregations != null
			? new Dictionary<string, IAggregate>(aggregations)
			: EmptyReadOnly<string, IAggregate>.Dictionary;

		public AggregationsHelper(IReadOnlyDictionary<string, IAggregate> aggregations) =>
			Aggregations = aggregations ?? EmptyReadOnly<string, IAggregate>.Dictionary;

		public IReadOnlyDictionary<string, IAggregate> Aggregations { get; protected internal set; } = EmptyReadOnly<string, IAggregate>.Dictionary;

		public ValueAggregate Min(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate Max(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate Sum(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate Cardinality(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate Average(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate ValueCount(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate AverageBucket(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate Derivative(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate SumBucket(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate MovingAverage(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate CumulativeSum(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate BucketScript(string key) => TryGet<ValueAggregate>(key);

		public ValueAggregate SerialDifferencing(string key) => TryGet<ValueAggregate>(key);

		public KeyedValueAggregate MaxBucket(string key) => TryGet<KeyedValueAggregate>(key);

		public KeyedValueAggregate MinBucket(string key) => TryGet<KeyedValueAggregate>(key);

		public ScriptedMetricAggregate ScriptedMetric(string key)
		{
			var valueMetric = TryGet<ValueAggregate>(key);

			return valueMetric != null
				? new ScriptedMetricAggregate { _Value = valueMetric.Value, Meta = valueMetric.Meta }
				: TryGet<ScriptedMetricAggregate>(key);
		}

		public StatsAggregate Stats(string key) => TryGet<StatsAggregate>(key);

		public StatsAggregate StatsBucket(string key) => TryGet<StatsAggregate>(key);

		public ExtendedStatsAggregate ExtendedStats(string key) => TryGet<ExtendedStatsAggregate>(key);

		public ExtendedStatsAggregate ExtendedStatsBucket(string key) => TryGet<ExtendedStatsAggregate>(key);

		public GeoBoundsAggregate GeoBounds(string key) => TryGet<GeoBoundsAggregate>(key);

		public PercentilesAggregate Percentiles(string key) => TryGet<PercentilesAggregate>(key);

		public PercentilesAggregate PercentilesBucket(string key) => TryGet<PercentilesAggregate>(key);

		public PercentilesAggregate PercentileRanks(string key) => TryGet<PercentilesAggregate>(key);

		public TopHitsAggregate TopHits(string key) => TryGet<TopHitsAggregate>(key);

		public FiltersAggregate Filters(string key)
		{
			var named = TryGet<FiltersAggregate>(key);
			if (named != null)
				return named;

			var anonymous = TryGet<BucketAggregate>(key);
			return anonymous != null
				? new FiltersAggregate { Buckets = anonymous.Items.OfType<FiltersBucketItem>().ToList(), Meta = anonymous.Meta }
				: null;
		}

		public SingleBucketAggregate Global(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate Filter(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate Missing(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate Nested(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate ReverseNested(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate Children(string key) => TryGet<SingleBucketAggregate>(key);

		public SingleBucketAggregate Sampler(string key) => TryGet<SingleBucketAggregate>(key);

		public GeoCentroidAggregate GeoCentroid(string key)
		{
			var geoCentroid = TryGet<GeoCentroidAggregate>(key);
			if (geoCentroid != null) return geoCentroid;

			var singleBucket = TryGet<SingleBucketAggregate>(key);
			return new GeoCentroidAggregate()
			{
				Count = singleBucket?.DocCount ?? 0
			};
		}

		public SignificantTermsAggregate SignificantTerms(string key)
		{
			var bucket = TryGet<BucketAggregate>(key);
			return bucket == null
				? null
				: new SignificantTermsAggregate
				{
					BgCount = bucket.BgCount,
					DocCount = bucket.DocCount,
					Buckets = bucket.Items.OfType<SignificantTermsBucket>().ToList(),
					Meta = bucket.Meta
				};
		}

		public TermsAggregate<TKey> Terms<TKey>(string key)
		{
			var bucket = TryGet<BucketAggregate>(key);
			return bucket == null
				? null
				: new TermsAggregate<TKey>
				{
					DocCountErrorUpperBound = bucket.DocCountErrorUpperBound,
					SumOtherDocCount = bucket.SumOtherDocCount,
					Buckets = GetKeyedBuckets<TKey>(bucket.Items).ToList(),
					Meta = bucket.Meta
				};
		}

		public TermsAggregate<string> Terms(string key) => Terms<string>(key);

		public MultiBucketAggregate<KeyedBucket<double>> Histogram(string key) => GetMultiKeyedBucketAggregate<double>(key);

		public MultiBucketAggregate<KeyedBucket<string>> GeoHash(string key) => GetMultiKeyedBucketAggregate<string>(key);

		public MultiBucketAggregate<KeyedBucket<string>> AdjacencyMatrix(string key) => GetMultiKeyedBucketAggregate<string>(key);

		public MultiBucketAggregate<RangeBucket> Range(string key) => GetMultiBucketAggregate<RangeBucket>(key);

		public MultiBucketAggregate<RangeBucket> DateRange(string key) => GetMultiBucketAggregate<RangeBucket>(key);

		public MultiBucketAggregate<RangeBucket> IpRange(string key) => GetMultiBucketAggregate<RangeBucket>(key);

		public MultiBucketAggregate<RangeBucket> GeoDistance(string key) => GetMultiBucketAggregate<RangeBucket>(key);

		public MultiBucketAggregate<DateHistogramBucket> DateHistogram(string key) => GetMultiBucketAggregate<DateHistogramBucket>(key);

		public MatrixStatsAggregate MatrixStats(string key) => TryGet<MatrixStatsAggregate>(key);

		private TAggregate TryGet<TAggregate>(string key)
			where TAggregate : class, IAggregate
		{
			IAggregate agg;
			return Aggregations.TryGetValue(key, out agg) ? agg as TAggregate : null;
		}

		private MultiBucketAggregate<TBucket> GetMultiBucketAggregate<TBucket>(string key)
			where TBucket : IBucket
		{
			var bucket = TryGet<BucketAggregate>(key);
			if (bucket == null) return null;

			return new MultiBucketAggregate<TBucket>
			{
				Buckets = bucket.Items.OfType<TBucket>().ToList(),
				Meta = bucket.Meta,
			};
		}

		private MultiBucketAggregate<KeyedBucket<TKey>> GetMultiKeyedBucketAggregate<TKey>(string key)
		{
			var bucket = TryGet<BucketAggregate>(key);
			if (bucket == null) return null;

			return new MultiBucketAggregate<KeyedBucket<TKey>>
			{
				Buckets = GetKeyedBuckets<TKey>(bucket.Items).ToList(),
				Meta = bucket.Meta,
			};
		}


		private IEnumerable<KeyedBucket<TKey>> GetKeyedBuckets<TKey>(IEnumerable<IBucket> items)
		{
			var buckets = items.Cast<KeyedBucket<object>>();

			foreach (var bucket in buckets)
				yield return new KeyedBucket<TKey>
				{
					Key = (TKey)Convert.ChangeType(bucket.Key, typeof(TKey)),
					KeyAsString = bucket.KeyAsString,
					Aggregations = bucket.Aggregations,
					DocCount = bucket.DocCount,
					DocCountErrorUpperBound = bucket.DocCountErrorUpperBound
				};
		}
	}
}
