﻿using System;
using System.Runtime.Serialization;
using Utf8Json;

namespace Nest
{
	/// <summary>
	/// The Post Job Data API response
	/// </summary>
	public interface IPostJobDataResponse : IResponse
	{
		/// <summary>
		/// The count of buckets.
		/// </summary>
		[DataMember(Name = "bucket_count")]
		long BucketCount { get; }

		/// <summary>
		/// The earliest record timestamp
		/// </summary>
		[DataMember(Name = "earliest_record_timestamp")]
		[JsonFormatter(typeof(EpochMillisecondsNullableDateTimeOffsetFormatter))]
		DateTimeOffset? EarliestRecordTimestamp { get; }

		/// <summary>
		/// The count of empty buckets.
		/// </summary>
		[DataMember(Name = "empty_bucket_count")]
		long EmptyBucketCount { get; }

		/// <summary>
		/// Total input bytes.
		/// </summary>
		[DataMember(Name = "input_bytes")]
		long InputBytes { get; }

		/// <summary>
		/// The count of input fields.
		/// </summary>
		[DataMember(Name = "input_field_count")]
		long InputFieldCount { get; }

		/// <summary>
		/// The count of input records.
		/// </summary>
		[DataMember(Name = "input_record_count")]
		long InputRecordCount { get; }

		/// <summary>
		/// The count of invalid dates.
		/// </summary>
		[DataMember(Name = "invalid_date_count")]
		long InvalidDateCount { get; }

		/// <summary>
		/// The unique identifier for the job.
		/// </summary>
		[DataMember(Name = "job_id")]
		string JobId { get; }

		/// <summary>
		/// The time of the last data item.
		/// </summary>
		[DataMember(Name = "last_data_time")]
		[JsonFormatter(typeof(EpochMillisecondsDateTimeOffsetFormatter))]
		DateTimeOffset LastDataTime { get; }

		/// <summary>
		/// The latest record timestamp
		/// </summary>
		[DataMember(Name = "latest_record_timestamp")]
		[JsonFormatter(typeof(EpochMillisecondsNullableDateTimeOffsetFormatter))]
		DateTimeOffset? LatestRecordTimestamp { get; }

		/// <summary>
		/// The count of missing fields.
		/// </summary>
		[DataMember(Name = "missing_field_count")]
		long MissingFieldCount { get; }

		/// <summary>
		/// The count of out of order timestamps.
		/// </summary>
		[DataMember(Name = "out_of_order_timestamp_count")]
		long OutOfOrderTimestampCount { get; }

		/// <summary>
		/// The count of processed fields.
		/// </summary>
		[DataMember(Name = "processed_field_count")]
		long ProcessedFieldCount { get; }

		/// <summary>
		/// The count of processed records.
		/// </summary>
		[DataMember(Name = "processed_record_count")]
		long ProcessedRecordCount { get; }

		/// <summary>
		/// The count of sparse buckets.
		/// </summary>
		[DataMember(Name = "sparse_bucket_count")]
		long SparseBucketCount { get; }
	}

	/// <inheritdoc cref="IPostJobDataResponse" />
	public class PostJobDataResponse : ResponseBase, IPostJobDataResponse
	{
		/// <inheritdoc />
		public long BucketCount { get; internal set; }

		/// <inheritdoc />
		public DateTimeOffset? EarliestRecordTimestamp { get; internal set; }

		/// <inheritdoc />
		public long EmptyBucketCount { get; internal set; }

		/// <inheritdoc />
		public long InputBytes { get; internal set; }

		/// <inheritdoc />
		public long InputFieldCount { get; internal set; }

		/// <inheritdoc />
		public long InputRecordCount { get; internal set; }

		/// <inheritdoc />
		public long InvalidDateCount { get; internal set; }

		/// <inheritdoc />
		public string JobId { get; internal set; }

		/// <inheritdoc />
		public DateTimeOffset LastDataTime { get; internal set; }

		/// <inheritdoc />
		public DateTimeOffset? LatestRecordTimestamp { get; internal set; }

		/// <inheritdoc />
		public long MissingFieldCount { get; internal set; }

		/// <inheritdoc />
		public long OutOfOrderTimestampCount { get; internal set; }

		/// <inheritdoc />
		public long ProcessedFieldCount { get; internal set; }

		/// <inheritdoc />
		public long ProcessedRecordCount { get; internal set; }

		/// <inheritdoc />
		public long SparseBucketCount { get; internal set; }
	}
}
