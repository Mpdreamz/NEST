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

using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	public class GetDataStreamResponse : ResponseBase
	{
		/// <summary>
		/// Contains information about retrieved data streams.
		/// </summary>
		[DataMember(Name = "data_streams")]
		public IReadOnlyCollection<DataStreamInfo> DataStreams { get; internal set; } = EmptyReadOnly<DataStreamInfo>.Collection;
	}

	[DataContract]
	public class DataStreamInfo
	{
		/// <summary>
		/// Name of the data stream.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; internal set; }

		/// <summary>
		/// Contains information about the data stream's timestamp field.
		/// </summary>
		[DataMember(Name = "timestamp_field")]
		public TimestampField TimestampField { get; internal set; }

		/// <summary>
		/// The current backing indices. The last item contains information
		/// about the stream's current write index.
		/// </summary>
		[DataMember(Name = "indices")]
		public IReadOnlyCollection<Index> Indices { get; internal set; }

		/// <summary>
		/// The current generation
		/// </summary>
		[DataMember(Name = "generation")]
		public long Generation { get; internal set; }

		/// <summary>
		/// The data stream's health status
		/// </summary>
		[DataMember(Name = "status")]
		public Health Status { get; internal set; }

		/// <summary>
		/// The index template used to create the stream's backing indices
		/// </summary>
		[DataMember(Name = "template")]
		public string Template { get; internal set; }

		/// <summary>
		/// The current Index Lifecycle Management policy in the stream's matching index template
		/// </summary>
		[DataMember(Name = "ilm_policy")]
		public string IlmPolicy { get; internal set; }
	}

	[DataContract]
	public class Index
	{
		/// <summary>
		/// Name of the backing index.
		/// </summary>
		[DataMember(Name = "index_name")]
		public string IndexName { get; internal set; }

		/// <summary>
		/// Universally unique identifier (UUID) for the index.
		/// </summary>
		[DataMember(Name = "index_uuid")]
		public string IndexUUID { get; internal set; }
	}

	[DataContract]
	public class TimestampField
	{
		/// <summary>
		/// Name of the data stream's timestamp field. This field must be included in every document indexed to the data stream.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; internal set; }
	}
}
