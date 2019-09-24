﻿using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	public class RefreshStats
	{
		[DataMember(Name ="total")]
		public long Total { get; set; }

		[DataMember(Name ="total_time")]
		public string TotalTime { get; set; }

		[DataMember(Name ="total_time_in_millis")]
		public long TotalTimeInMilliseconds { get; set; }

		/// <summary>
		/// Only valid for Elasticsearch 7.2.0 and above.
		/// </summary>
		[DataMember(Name ="external_total")]
		public long ExternalTotal { get; set; }

		/// <summary>
		/// Only valid for Elasticsearch 7.2.0 and above.
		/// </summary>
		[DataMember(Name ="external_total_time_in_millis")]
		public long ExternalTotalTimeInMilliseconds { get; set; }
	}
}
