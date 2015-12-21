using System;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	internal class IndexRequestJsonConverter : JsonConverter
	{
		public override bool CanRead => true;
		public override bool CanWrite => true;
		public override bool CanConvert(Type objectType) => true;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			//not optimized but deserializing index requests is far from common practice
			var genericType = objectType.GetGenericArguments().First();
			var o = serializer.Deserialize(reader, genericType);
			var x = typeof(IndexRequest<>).CreateGenericInstance(genericType, typeof(DocumentPath<>).CreateGenericInstance(genericType, o));
			return x;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var v = value as IIndexRequest;
			serializer.Serialize(writer, v.UntypedDocument);
		}
	}
}