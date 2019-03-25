﻿using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	[JsonConverter(typeof(FieldNameQueryJsonConverter<DateRangeQuery>))]
	public interface IDateRangeQuery : IRangeQuery
	{
		[DataMember(Name ="format")]
		string Format { get; set; }

		[DataMember(Name ="gt")]
		DateMath GreaterThan { get; set; }

		[DataMember(Name ="gte")]
		DateMath GreaterThanOrEqualTo { get; set; }

		[DataMember(Name ="lt")]
		DateMath LessThan { get; set; }

		[DataMember(Name ="lte")]
		DateMath LessThanOrEqualTo { get; set; }

		[DataMember(Name ="relation")]
		RangeRelation? Relation { get; set; }

		[DataMember(Name ="time_zone")]
		string TimeZone { get; set; }
	}

	public class DateRangeQuery : FieldNameQueryBase, IDateRangeQuery
	{
		public string Format { get; set; }
		public DateMath GreaterThan { get; set; }

		public DateMath GreaterThanOrEqualTo { get; set; }
		public DateMath LessThan { get; set; }
		public DateMath LessThanOrEqualTo { get; set; }
		public RangeRelation? Relation { get; set; }
		public string TimeZone { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Range = this;

		internal static bool IsConditionless(IDateRangeQuery q) => q.Field.IsConditionless()
			|| ((q.GreaterThanOrEqualTo == null || !q.GreaterThanOrEqualTo.IsValid)
			&& (q.LessThanOrEqualTo == null || !q.LessThanOrEqualTo.IsValid)
			&& (q.GreaterThan == null || !q.GreaterThan.IsValid)
			&& (q.LessThan == null || !q.LessThan.IsValid));
	}

	[DataContract]
	public class DateRangeQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<DateRangeQueryDescriptor<T>, IDateRangeQuery, T>
			, IDateRangeQuery where T : class
	{
		protected override bool Conditionless => DateRangeQuery.IsConditionless(this);
		string IDateRangeQuery.Format { get; set; }
		DateMath IDateRangeQuery.GreaterThan { get; set; }
		DateMath IDateRangeQuery.GreaterThanOrEqualTo { get; set; }
		DateMath IDateRangeQuery.LessThan { get; set; }
		DateMath IDateRangeQuery.LessThanOrEqualTo { get; set; }
		RangeRelation? IDateRangeQuery.Relation { get; set; }
		string IDateRangeQuery.TimeZone { get; set; }

		public DateRangeQueryDescriptor<T> GreaterThan(DateMath from) => Assign(a => a.GreaterThan = from);

		public DateRangeQueryDescriptor<T> GreaterThanOrEquals(DateMath from) => Assign(a => a.GreaterThanOrEqualTo = from);

		public DateRangeQueryDescriptor<T> LessThan(DateMath to) => Assign(a => a.LessThan = to);

		public DateRangeQueryDescriptor<T> LessThanOrEquals(DateMath to) => Assign(a => a.LessThanOrEqualTo = to);

		public DateRangeQueryDescriptor<T> TimeZone(string timeZone) => Assign(a => a.TimeZone = timeZone);

		public DateRangeQueryDescriptor<T> Format(string format) => Assign(a => a.Format = format);

		public DateRangeQueryDescriptor<T> Relation(RangeRelation? relation) => Assign(a => a.Relation = relation);
	}
}
