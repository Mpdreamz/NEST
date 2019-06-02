﻿using System;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	public class CreateApiKeyResponse : ResponseBase
	{
		/// <summary>
		/// Id for the API key
		/// </summary>
		[DataMember(Name = "id")]
		public string Id { get; internal set; }

		/// <summary>
		/// Name of the API key
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; internal set; }

		/// <summary>
		/// Optional expiration time for the API key in milliseconds
		/// </summary>
		[DataMember(Name = "expiration")]
		[JsonFormatter(typeof(NullableDateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset? Expiration { get; internal set; }

		/// <summary>
		/// Generated API key
		/// </summary>
		[DataMember(Name = "api_key")]
		public string ApiKey { get; internal set; }
	}
}
