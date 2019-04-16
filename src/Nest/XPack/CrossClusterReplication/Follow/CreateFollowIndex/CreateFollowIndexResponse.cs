﻿using System.Runtime.Serialization;

namespace Nest
{
	public class CreateFollowIndexResponse : ResponseBase
	{
		[DataMember(Name = "follow_index_created")]
		public bool FollowIndexCreated { get; internal set; }
		[DataMember(Name = "follow_index_shards_acked")]
		public bool FollowIndexShardsAcked { get; internal set; }
		[DataMember(Name = "index_following_started")]
		public bool IndexFollowingStarted { get; internal set; }
	}
}
