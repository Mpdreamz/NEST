﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	[DataContract]
	[JsonFormatter(typeof(ConcreteBulkIndexResponseItemFormatter<BulkIndexResponseItem>))]
	public class BulkIndexResponseItem : BulkResponseItemBase
	{
		/// <summary>
		/// The _ids that matched (if any) for the Percolate API.
		/// Will be null if the operation is not in response to Percolate API.
		/// </summary>
		[DataMember(Name = "matches")]
		public IEnumerable<string> Matches { get; internal set; }

		public override string Operation { get; } = "index";
	}
}
