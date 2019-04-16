﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[JsonFormatter(typeof(ResolvableDictionaryResponseFormatter<GetAliasResponse, IndexName, IndexAliases>))]
	public class GetAliasResponse : DictionaryResponseBase<IndexName, IndexAliases>
	{
		[IgnoreDataMember]
		public IReadOnlyDictionary<IndexName, IndexAliases> Indices => Self.BackingDictionary;

		public override bool IsValid => Indices.Count > 0;
	}

	public class IndexAliases
	{
		[DataMember(Name ="aliases")]
		public IReadOnlyDictionary<string, AliasDefinition> Aliases { get; internal set; } = EmptyReadOnly<string, AliasDefinition>.Dictionary;
	}

}
