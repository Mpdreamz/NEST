using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	internal class SourceWriteFormatter<T> : SourceFormatter<T>
	{
		public override void Serialize(ref JsonWriter writer, T value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			if (value.GetType().IsNestType())
				formatterResolver.GetFormatter<T>().Serialize(ref writer, value, formatterResolver);
			else
				base.Serialize(ref writer, value, formatterResolver);
		}
	}
}
