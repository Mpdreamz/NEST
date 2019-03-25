﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;

namespace Nest
{
	internal class TermsExcludeFormatter : IJsonFormatter<TermsExclude>
	{
		public TermsExclude Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			var token = reader.GetCurrentJsonToken();
			if (token == JsonToken.Null)
				return null;

			TermsExclude termsExclude;
			switch (token)
			{
				case JsonToken.BeginArray:
					var formatter = formatterResolver.GetFormatter<IEnumerable<string>>();
					termsExclude = new TermsExclude(formatter.Deserialize(ref reader, formatterResolver));
					break;
				case JsonToken.String:
					termsExclude = new TermsExclude(reader.ReadString());
					break;
				default:
					throw new Exception($"Unexpected token {token} when deserializing {nameof(TermsInclude)}");
			}

			return termsExclude;
		}

		public void Serialize(ref JsonWriter writer, TermsExclude value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null)
				writer.WriteNull();
			else if (value.Values != null)
			{
				var formatter = formatterResolver.GetFormatter<IEnumerable<string>>();
				formatter.Serialize(ref writer, value.Values, formatterResolver);
			}
			else
				writer.WriteString(value.Pattern);
		}
	}
}
