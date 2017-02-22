using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest_5_2_0
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum RecoveryInitialShards
	{
		[EnumMember(Value = "quorem")]
		Quorem,
		[EnumMember(Value = "quorem-1")]
		QuoremMinusOne,
		[EnumMember(Value = "full")]
		Full,
		[EnumMember(Value = "full-1")]
		FullMinusOne
	}
}