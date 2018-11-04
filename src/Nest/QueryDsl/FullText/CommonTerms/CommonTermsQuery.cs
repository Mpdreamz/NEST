﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(FieldNameQueryJsonConverter<CommonTermsQuery>))]
	public interface ICommonTermsQuery : IFieldNameQuery
	{
		[JsonProperty(PropertyName = "analyzer")]
		string Analyzer { get; set; }

		[JsonProperty(PropertyName = "cutoff_frequency")]
		double? CutoffFrequency { get; set; }

		[JsonProperty(PropertyName = "disable_coord")]
		[Obsolete("Removed in 6.0.")]
		bool? DisableCoord { get; set; }

		[JsonProperty(PropertyName = "high_freq_operator")]
		[JsonConverter(typeof(StringEnumConverter))]
		Operator? HighFrequencyOperator { get; set; }

		[JsonProperty(PropertyName = "low_freq_operator")]
		[JsonConverter(typeof(StringEnumConverter))]
		Operator? LowFrequencyOperator { get; set; }

		[JsonProperty(PropertyName = "minimum_should_match")]
		MinimumShouldMatch MinimumShouldMatch { get; set; }

		[JsonProperty(PropertyName = "query")]
		string Query { get; set; }
	}

	public class CommonTermsQuery : FieldNameQueryBase, ICommonTermsQuery
	{
		public string Analyzer { get; set; }
		public double? CutoffFrequency { get; set; }

		[Obsolete("Removed in 6.0.")]
		public bool? DisableCoord { get; set; }

		public Operator? HighFrequencyOperator { get; set; }
		public Operator? LowFrequencyOperator { get; set; }
		public MinimumShouldMatch MinimumShouldMatch { get; set; }
		public string Query { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.CommonTerms = this;

		internal static bool IsConditionless(ICommonTermsQuery q) => q.Field.IsConditionless() || q.Query.IsNullOrEmpty();
	}

	public class CommonTermsQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<CommonTermsQueryDescriptor<T>, ICommonTermsQuery, T>
			, ICommonTermsQuery
		where T : class
	{
		protected override bool Conditionless => CommonTermsQuery.IsConditionless(this);
		string ICommonTermsQuery.Analyzer { get; set; }
		double? ICommonTermsQuery.CutoffFrequency { get; set; }
		bool? ICommonTermsQuery.DisableCoord { get; set; }
		Field IFieldNameQuery.Field { get; set; }
		Operator? ICommonTermsQuery.HighFrequencyOperator { get; set; }
		Operator? ICommonTermsQuery.LowFrequencyOperator { get; set; }
		MinimumShouldMatch ICommonTermsQuery.MinimumShouldMatch { get; set; }
		string IQuery.Name { get; set; }
		string ICommonTermsQuery.Query { get; set; }

		/// <inheritdoc />
		public CommonTermsQueryDescriptor<T> Query(string query) => Assign(a => a.Query = query);

		/// <inheritdoc />
		public CommonTermsQueryDescriptor<T> HighFrequencyOperator(Operator? op) => Assign(a => a.HighFrequencyOperator = op);

		public CommonTermsQueryDescriptor<T> LowFrequencyOperator(Operator? op) => Assign(a => a.LowFrequencyOperator = op);

		/// <inheritdoc />
		public CommonTermsQueryDescriptor<T> Analyzer(string analyzer) => Assign(a => a.Analyzer = analyzer);

		/// <inheritdoc />
		public CommonTermsQueryDescriptor<T> CutoffFrequency(double? cutOffFrequency) => Assign(a => a.CutoffFrequency = cutOffFrequency);

		/// <inheritdoc />
		public CommonTermsQueryDescriptor<T> MinimumShouldMatch(MinimumShouldMatch minimumShouldMatch) =>
			Assign(a => a.MinimumShouldMatch = minimumShouldMatch);

		/// <inheritdoc />
		[Obsolete("Removed in 6.0.")]
		public CommonTermsQueryDescriptor<T> DisableCoord(bool? disable = true) => Assign(a => a.DisableCoord = disable);
	}
}
