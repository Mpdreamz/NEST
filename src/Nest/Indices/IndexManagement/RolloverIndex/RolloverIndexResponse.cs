﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nest
{
	public class RolloverIndexResponse : AcknowledgedResponseBase
	{
		[DataMember(Name = "conditions")]
		public IReadOnlyDictionary<string, bool> Conditions { get; internal set; } = EmptyReadOnly<string, bool>.Dictionary;

		[DataMember(Name = "dry_run")]
		public bool DryRun { get; internal set; }

		[DataMember(Name = "new_index")]
		public string NewIndex { get; internal set; }

		[DataMember(Name = "old_index")]
		public string OldIndex { get; internal set; }

		[DataMember(Name = "rolled_over")]
		public bool RolledOver { get; internal set; }

		[DataMember(Name = "shards_acknowledged")]
		public bool ShardsAcknowledged { get; internal set; }
	}
}
