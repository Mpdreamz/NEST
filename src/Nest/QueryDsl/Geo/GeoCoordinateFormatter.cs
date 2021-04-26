/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	internal class GeoCoordinateFormatter : IJsonFormatter<GeoCoordinate>
	{
		public GeoCoordinate Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			if (reader.GetCurrentJsonToken() != JsonToken.BeginArray)
				return null;

			var doubles = formatterResolver.GetFormatter<double[]>()
				.Deserialize(ref reader, formatterResolver);
			switch (doubles.Length)
			{
				case 2:
					return new GeoCoordinate(doubles[1], doubles[0]);
				case 3:
					return new GeoCoordinate(doubles[1], doubles[0], doubles[2]);
				default:
					return null;
			}
		}

		public void Serialize(ref JsonWriter writer, GeoCoordinate value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			writer.WriteBeginArray();
			writer.WriteDouble(value.Longitude);
			writer.WriteValueSeparator();
			writer.WriteDouble(value.Latitude);
			if (value.Z.HasValue)
			{
				writer.WriteValueSeparator();
				writer.WriteDouble(value.Z.Value);
			}
			writer.WriteEndArray();
		}
	}
}
