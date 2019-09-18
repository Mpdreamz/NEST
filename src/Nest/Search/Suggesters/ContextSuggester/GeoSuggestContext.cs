﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	[InterfaceDataContract]
	public interface IGeoSuggestContext : ISuggestContext
	{
		[DataMember(Name = "neighbors")]
		bool? Neighbors { get; set; }

		[DataMember(Name = "precision")]
		string Precision { get; set; }
	}

	[DataContract]
	public class GeoSuggestContext : SuggestContextBase, IGeoSuggestContext
	{
		public bool? Neighbors { get; set; }

		public string Precision { get; set; }
		public override string Type => "geo";
	}

	[DataContract]
	public class GeoSuggestContextDescriptor<T>
		: SuggestContextDescriptorBase<GeoSuggestContextDescriptor<T>, IGeoSuggestContext, T>, IGeoSuggestContext
		where T : class
	{
		protected override string Type => "geo";
		bool? IGeoSuggestContext.Neighbors { get; set; }
		string IGeoSuggestContext.Precision { get; set; }

		public GeoSuggestContextDescriptor<T> Precision(string precision) => Assign(precision, (a, v) => a.Precision = v);

		public GeoSuggestContextDescriptor<T> Neighbors(bool? neighbors = true) => Assign(neighbors, (a, v) => a.Neighbors = v);
	}
}
