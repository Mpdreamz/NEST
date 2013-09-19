﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq.Expressions;
using Nest.Resolvers;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class MultiMatchQueryDescriptor<T> : IQuery where T : class
	{
		[JsonProperty(PropertyName = "type")]
		internal virtual string _Type { get; set; }

		[JsonProperty(PropertyName = "query")]
		internal string _Query { get; set; }

		[JsonProperty(PropertyName = "analyzer")]
		internal string _Analyzer { get; set; }

		[JsonProperty(PropertyName = "rewrite")]
		[JsonConverter(typeof(StringEnumConverter))]
		internal RewriteMultiTerm? _Rewrite { get; set; }

		[JsonProperty(PropertyName = "fuzziness")]
		internal double? _Fuzziness { get; set; }

		[JsonProperty(PropertyName = "cutoff_frequency")]
		internal double? _CutoffFrequency { get; set; }

		[JsonProperty(PropertyName = "prefix_length")]
		internal int? _PrefixLength { get; set; }

		[JsonProperty(PropertyName = "max_expansions")]
		internal int? _MaxExpansions { get; set; }

		[JsonProperty(PropertyName = "slop")]
		internal int? _Slop { get; set; }

		[JsonProperty(PropertyName = "boost")]
		internal double? _Boost { get; set; }

		[JsonProperty(PropertyName = "use_dis_max")]
		internal bool? _UseDisMax { get; set; }

		[JsonProperty(PropertyName = "tie_breaker")]
		internal double? _TieBreaker { get; set; }


		[JsonProperty(PropertyName = "operator")]
		[JsonConverter(typeof(StringEnumConverter))]
		internal Operator? _Operator { get; set; }

		internal bool IsConditionless
		{
			get
			{
				return !this._Fields.HasAny() || this._Query.IsNullOrEmpty();
			}
		}

		[JsonProperty(PropertyName = "fields")]
		internal IEnumerable<string> _Fields { get; set; }

		public MultiMatchQueryDescriptor<T> OnFields(IEnumerable<string> fields)
		{
			this._Fields = fields;
			return this;
		}
		public MultiMatchQueryDescriptor<T> OnFields(
			params Expression<Func<T, object>>[] objectPaths)
		{
			var fieldNames = objectPaths
				.Select(o => new PropertyNameResolver().Resolve(o));
			return this.OnFields(fieldNames);
		}

		public MultiMatchQueryDescriptor<T> QueryString(string queryString)
		{
			this._Query = queryString;
			return this;
		}
		public MultiMatchQueryDescriptor<T> Analyzer(string analyzer)
		{
			analyzer.ThrowIfNullOrEmpty("analyzer");
			this._Analyzer = analyzer;
			return this;
		}
		public MultiMatchQueryDescriptor<T> Fuzziness(double fuzziness)
		{
			fuzziness.ThrowIfNull("fuzziness");
			this._Fuzziness = fuzziness;
			return this;
		}
		public MultiMatchQueryDescriptor<T> CutoffFrequency(double cutoffFrequency)
		{
			cutoffFrequency.ThrowIfNull("cutoffFrequency");
			this._CutoffFrequency = cutoffFrequency;
			return this;
		}

		public MultiMatchQueryDescriptor<T> Rewrite(RewriteMultiTerm rewrite)
		{
			rewrite.ThrowIfNull("rewrite");
			this._Rewrite = rewrite;
			return this;
		}

		public MultiMatchQueryDescriptor<T> Boost(double boost)
		{
			boost.ThrowIfNull("boost");
			this._Boost = boost;
			return this;
		}
		public MultiMatchQueryDescriptor<T> PrefixLength(int prefixLength)
		{
			prefixLength.ThrowIfNull("prefixLength");
			this._PrefixLength = prefixLength;
			return this;
		}
		public MultiMatchQueryDescriptor<T> MaxExpansions(int maxExpansions)
		{
			maxExpansions.ThrowIfNull("maxExpansions");
			this._MaxExpansions = maxExpansions;
			return this;
		}
		public MultiMatchQueryDescriptor<T> Slop(int slop)
		{
			slop.ThrowIfNull("slop");
			this._Slop = slop;
			return this;
		}
		public MultiMatchQueryDescriptor<T> Operator(Operator op)
		{
			this._Operator = op;
			return this;
		}

		public MultiMatchQueryDescriptor<T> UseDisMax(bool useDismax)
		{
			this._UseDisMax = useDismax;
			return this;
		}

		public MultiMatchQueryDescriptor<T> TieBreaker(double tieBreaker)
		{
			this._TieBreaker = tieBreaker;
			return this;
		}

		public MultiMatchQueryDescriptor<T> Type(TextQueryType type)
		{
			this._Type = type.ToString().ToLower();
			return this;
		}
	}
}
