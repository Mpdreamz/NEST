﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace Nest.Resolvers.Converters
{

	public class FuzzinessConverter : JsonConverter
	{
		public override bool CanWrite { get { return true; } }

		public override bool CanRead { get { return true; } }

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var v = value as IFuzziness;
			if (v.Auto) writer.WriteValue("AUTO"); 
			else if (v.EditDistance.HasValue) writer.WriteValue(v.EditDistance.Value);
#pragma warning disable 618
			else if (v.Ratio.HasValue) writer.WriteValue(v.Ratio.Value);
#pragma warning restore 618
			else writer.WriteNull(); 
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.String)
				return Fuzziness.Auto;
			if (reader.TokenType == JsonToken.Integer)
			{
				var editDistance = (reader.Value as int?).GetValueOrDefault(0);
				return Fuzziness.EditDistance(editDistance);
			}
			if (reader.TokenType == JsonToken.Float)
			{
				var ratio = (reader.Value as double?).GetValueOrDefault(0);
#pragma warning disable 618
				return Fuzziness.Ratio(ratio);
#pragma warning restore 618
			}
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return true;
		}
	}
}