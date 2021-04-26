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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;


namespace Nest
{
	public class WatcherStatsResponse : ResponseBase
	{
		[DataMember(Name ="cluster_name")]
		public string ClusterName { get; internal set; }

		[DataMember(Name ="manually_stopped")]
		public bool ManuallyStopped { get; internal set; }

		[DataMember(Name ="stats")]
		public IReadOnlyCollection<WatcherNodeStats> Stats { get; internal set; } = EmptyReadOnly<WatcherNodeStats>.Collection;
	}

	public class WatcherNodeStats
	{
		[DataMember(Name ="current_watches")]
		public IReadOnlyCollection<WatchRecordStats> CurrentWatches { get; internal set; } = EmptyReadOnly<WatchRecordStats>.Collection;

		[DataMember(Name ="execution_thread_pool")]
		public ExecutionThreadPool ExecutionThreadPool { get; internal set; }

		[DataMember(Name ="queued_watches")]
		public IReadOnlyCollection<WatchRecordQueuedStats> QueuedWatches { get; internal set; } = EmptyReadOnly<WatchRecordQueuedStats>.Collection;

		[DataMember(Name ="watch_count")]
		public long WatchCount { get; internal set; }

		[DataMember(Name ="watcher_state")]
		public WatcherState WatcherState { get; internal set; }
	}

	[StringEnum]
	public enum WatcherState
	{
		[EnumMember(Value = "stopped")]
		Stopped,

		[EnumMember(Value = "starting")]
		Starting,

		[EnumMember(Value = "started")]
		Started,

		[EnumMember(Value = "stopping")]
		Stopping,
	}

	public class WatchRecordQueuedStats
	{
		[DataMember(Name ="execution_time")]
		public DateTimeOffset? ExecutionTime { get; internal set; }

		[DataMember(Name ="triggered_time")]
		public DateTimeOffset? TriggeredTime { get; internal set; }

		[DataMember(Name ="watch_id")]
		public string WatchId { get; internal set; }

		[DataMember(Name ="watch_record_id")]
		public string WatchRecordId { get; internal set; }
	}

	public class WatchRecordStats : WatchRecordQueuedStats
	{
		[DataMember(Name ="execution_phase")]
		public ExecutionPhase? ExecutionPhase { get; internal set; }
	}

	[DataContract]
	public class ExecutionThreadPool
	{
		[DataMember(Name ="max_size")]
		public long MaxSize { get; internal set; }

		[DataMember(Name ="queue_size")]
		public long QueueSize { get; internal set; }
	}

	[StringEnum]
	public enum ExecutionPhase
	{
		[EnumMember(Value = "awaits_execution")]
		AwaitsExecution,

		[EnumMember(Value = "started")]
		Started,

		[EnumMember(Value = "input")]
		Input,

		[EnumMember(Value = "condition")]
		Condition,

		[EnumMember(Value = "actions")]
		Actions,

		[EnumMember(Value = "watch_transform")]
		WatchTransform,

		[EnumMember(Value = "aborted")]
		Aborted,

		[EnumMember(Value = "finished")]
		Finished,
	}
}
