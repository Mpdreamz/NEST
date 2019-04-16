﻿using System.Collections.Generic;
using Elasticsearch.Net;

namespace Nest
{
	[JsonFormatter(typeof(ResolvableDictionaryResponseFormatter<GetIndexResponse, IndexName, IndexState>))]
	public class GetIndexResponse : DictionaryResponseBase<IndexName, IndexState>
	{
		public IReadOnlyDictionary<IndexName, IndexState> Indices => Self.BackingDictionary;
	}
}
