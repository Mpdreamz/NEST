﻿using System;
using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	[ReadAs(typeof(HasChildQueryDescriptor<object>))]
	public interface IHasChildQuery : IQuery
	{
		[DataMember(Name ="ignore_unmapped")]
		bool? IgnoreUnmapped { get; set; }

		[DataMember(Name ="inner_hits")]
		IInnerHits InnerHits { get; set; }

		/// <summary>
		/// Specify how many child documents are allowed to match.
		/// </summary>
		[DataMember(Name ="max_children")]
		int? MaxChildren { get; set; }

		[DataMember(Name ="min_children")]
		int? MinChildren { get; set; }

		[DataMember(Name ="query")]
		QueryContainer Query { get; set; }

		[DataMember(Name ="score_mode")]
		ChildScoreMode? ScoreMode { get; set; }

		[DataMember(Name = "type")]
		RelationName Type { get; set; }
	}

	public class HasChildQuery : QueryBase, IHasChildQuery
	{
		public bool? IgnoreUnmapped { get; set; }
		public IInnerHits InnerHits { get; set; }

		/// <summary>
		/// Specify how many child documents are allowed to match.
		/// </summary>
		public int? MaxChildren { get; set; }

		public int? MinChildren { get; set; }
		public QueryContainer Query { get; set; }
		public ChildScoreMode? ScoreMode { get; set; }
		public RelationName Type { get; set; }
		protected override bool Conditionless => IsConditionless(this);

		internal override void InternalWrapInContainer(IQueryContainer c) => c.HasChild = this;

		internal static bool IsConditionless(IHasChildQuery q) => q.Query == null || q.Query.IsConditionless || q.Type == null;
	}

	public class HasChildQueryDescriptor<T>
		: QueryDescriptorBase<HasChildQueryDescriptor<T>, IHasChildQuery>
			, IHasChildQuery where T : class
	{
		public HasChildQueryDescriptor() => Self.Type = RelationName.Create<T>();

		protected override bool Conditionless => HasChildQuery.IsConditionless(this);
		bool? IHasChildQuery.IgnoreUnmapped { get; set; }
		IInnerHits IHasChildQuery.InnerHits { get; set; }

		/// <summary>
		/// Specify how many child documents are allowed to match.
		/// </summary>
		int? IHasChildQuery.MaxChildren { get; set; }

		int? IHasChildQuery.MinChildren { get; set; }
		QueryContainer IHasChildQuery.Query { get; set; }
		ChildScoreMode? IHasChildQuery.ScoreMode { get; set; }
		RelationName IHasChildQuery.Type { get; set; }

		public HasChildQueryDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(a => a.Query = selector?.Invoke(new QueryContainerDescriptor<T>()));

		public HasChildQueryDescriptor<T> Type(string type) => Assign(a => a.Type = type);

		public HasChildQueryDescriptor<T> ScoreMode(ChildScoreMode? scoreMode) => Assign(a => a.ScoreMode = scoreMode);

		public HasChildQueryDescriptor<T> MinChildren(int? minChildren) => Assign(a => a.MinChildren = minChildren);

		/// <summary>
		/// Specify how many child documents are allowed to match.
		/// </summary>
		public HasChildQueryDescriptor<T> MaxChildren(int? maxChildren) => Assign(a => a.MaxChildren = maxChildren);

		public HasChildQueryDescriptor<T> InnerHits(Func<InnerHitsDescriptor<T>, IInnerHits> selector = null) =>
			Assign(a => a.InnerHits = selector.InvokeOrDefault(new InnerHitsDescriptor<T>()));

		public HasChildQueryDescriptor<T> IgnoreUnmapped(bool? ignoreUnmapped = true) =>
			Assign(a => a.IgnoreUnmapped = ignoreUnmapped);
	}
}
