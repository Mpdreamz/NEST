﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest_5_2_0
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SamplerAggregationExecutionHint
	{
		[EnumMember(Value = "map")]
		Map,
        [EnumMember(Value = "global_ordinals")]
		GlobalOrdinals,
        [EnumMember(Value = "bytes_hash")]
		BytesHash
	}
}
