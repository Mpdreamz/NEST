﻿using System;
using System.Runtime.Serialization;

namespace Nest
{
	public class XPackInfoResponse : ResponseBase
	{
		[DataMember(Name ="build")]
		public XPackBuildInformation Build { get; internal set; }
		[DataMember(Name ="features")]
		public XPackFeatures Features { get; internal set; }
		[DataMember(Name ="license")]
		public MinimalLicenseInformation License { get; internal set; }
		[DataMember(Name ="tagline")]
		public string Tagline { get; internal set; }
	}

	public class XPackBuildInformation
	{
		[DataMember(Name ="date")]
		public DateTimeOffset Date { get; internal set; }

		[DataMember(Name ="hash")]
		public string Hash { get; internal set; }
	}

	public class MinimalLicenseInformation
	{
		[DataMember(Name ="expiry_date_in_millis")]
		public long ExpiryDateInMilliseconds { get; set; }

		[DataMember(Name ="mode")]
		public LicenseType Mode { get; internal set; }

		[DataMember(Name ="status")]
		public LicenseStatus Status { get; internal set; }

		[DataMember(Name ="type")]
		public LicenseType Type { get; internal set; }

		[DataMember(Name ="uid")]
		public string UID { get; internal set; }
	}

	public class XPackFeatures
	{
		[DataMember(Name ="graph")]
		public XPackFeature Graph { get; internal set; }

		[DataMember(Name ="ml")]
		public XPackFeature MachineLearning { get; internal set; }

		[DataMember(Name ="monitoring")]
		public XPackFeature Monitoring { get; internal set; }

		[DataMember(Name ="security")]
		public XPackFeature Security { get; internal set; }

		[DataMember(Name ="watcher")]
		public XPackFeature Watcher { get; internal set; }
	}

	public class XPackFeature
	{
		[DataMember(Name ="available")]
		public bool Available { get; internal set; }

		[DataMember(Name ="description")]
		public string Description { get; internal set; }

		[DataMember(Name ="enabled")]
		public bool Enabled { get; internal set; }

		[DataMember(Name ="native_code_info")]
		public NativeCodeInformation NativeCodeInformation { get; internal set; }
	}

	public class NativeCodeInformation
	{
		[DataMember(Name ="build_hash")]
		public string BuildHash { get; internal set; }

		[DataMember(Name ="version")]
		public string Version { get; internal set; }
	}
}
