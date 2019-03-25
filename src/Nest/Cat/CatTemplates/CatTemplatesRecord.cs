﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[DataContract]
	public class CatTemplatesRecord : ICatRecord
	{
		[DataMember(Name ="index_patterns")]
		public string IndexPatterns { get; set; }

		[DataMember(Name ="name")]
		public string Name { get; set; }

		[DataMember(Name ="order")]
		[JsonFormatter(typeof(StringLongFormatter))]
		public long Order { get; set; }

		[DataMember(Name ="version")]
		[JsonFormatter(typeof(NullableStringLongFormatter))]
		public long? Version { get; set; }
	}
}
