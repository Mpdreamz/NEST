﻿using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	internal static class StatefulSerializerFactory
	{
		public static InternalSerializer CreateStateful(IConnectionSettingsValues settings, IJsonFormatterResolver formatterResolver) =>
			new InternalSerializer(settings, formatterResolver);
	}
}
