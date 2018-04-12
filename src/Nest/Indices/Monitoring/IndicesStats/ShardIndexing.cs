﻿using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class ShardIndexing
	{
		/// <summary>
		/// The total number of indexing operations
		/// </summary>
		[JsonProperty("index_total")]
		public long IndexTotal { get; set; }

		/// <summary>
		/// The total amount of time spend on executing index operations.
		/// </summary>
		[JsonProperty("index_time_in_millis")]
		public long IndexTimeInMilliseconds { get; set; }

		/// <summary>
		/// Returns the currently in-flight indexing operations.
		/// </summary>
		[JsonProperty("index_current")]
		public long IndexCurrent { get; set; }

		/// <summary>
		/// The number of failed indexing operations
		/// </summary>
		[JsonProperty("index_failed")]
		public long IndexFailed { get; set; }

		/// <summary>
		/// Returns the number of delete operation executed
		/// </summary>
		[JsonProperty("delete_total")]
		public long DeleteTotal { get; set; }

		/// <summary>
		/// The total amount of time spend on executing delete operations.
		/// </summary>
		[JsonProperty("delete_time_in_millis")]
		public long DeleteTimeInMilliseconds { get; set; }

		/// <summary>
		/// Returns the currently in-flight delete operations
		/// </summary>
		[JsonProperty("delete_current")]
		public long DeleteCurrent { get; set; }

		/// <summary>
		/// Returns the number of noop update operations
		/// </summary>
		[JsonProperty("noop_update_total")]
		public long NoopUpdateTotal { get; set; }

		/// <summary>
		/// Returns if the index is under merge throttling control
		/// </summary>
		[JsonProperty("is_throttled")]
		public bool IsThrottled { get; set; }

		/// <summary>
		/// Gets the amount of time that the index has been under merge throttling control
		/// </summary>
		[JsonProperty("throttle_time_in_millis")]
		public long ThrottleTimeInMilliseconds { get; set; }
	}
}