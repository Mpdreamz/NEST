﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	public class ExplainLifecycleResponse : ResponseBase
	{
		[DataMember(Name = "indices")]
		public IReadOnlyDictionary<string, LifecycleExplain> Indices { get; internal set; }
	}

	public class LifecycleExplain
	{
		[DataMember(Name = "action")]
		public string Action { get; internal set; }

		/// <summary>
		/// When the index entered the current action.
		/// </summary>
		[DataMember(Name = "action_time_millis")]
		[JsonFormatter(typeof(DateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset ActionTime { get; internal set; }

		/// <summary>
		/// The step that caused the error, if applicable.
		/// </summary>
		[DataMember(Name = "failed_step")]
		public string FailedStep { get; internal set; }

		[DataMember(Name = "index")]
		public IndexName Index { get; internal set; }

		/// <summary>
		/// The timestamp used for minimum age.
		/// </summary>
		[DataMember(Name = "lifecycle_date_millis")]
		[JsonFormatter(typeof(DateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset LifecycleDate { get; internal set; }

		/// <summary>
		/// Shows if the index is being managed by Index Lifecycle Management (ILM). If the index is not managed by ILM the other
		/// fields will not be shown.
		/// </summary>
		[DataMember(Name = "managed")]
		public bool Managed { get; internal set; }

		[DataMember(Name = "phase")]
		public string Phase { get; internal set; }

		/// <summary>
		/// When the index entered the current phase.
		/// </summary>
		[DataMember(Name = "phase_time_millis")]
		[JsonFormatter(typeof(DateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset PhaseTime { get; internal set; }

		/// <summary>
		/// The name of the policy which ILM is using for this index.
		/// </summary>
		[DataMember(Name = "policy")]
		public string Policy { get; internal set; }

		[DataMember(Name = "step")]
		public string Step { get; internal set; }

		/// <summary>
		/// Step error details, if applicable.
		/// </summary>
		[DataMember(Name = "step_info")]
		public IReadOnlyDictionary<string, object> StepInfo { get; internal set; } = EmptyReadOnly<string, object>.Dictionary;

		/// <summary>
		/// When the index entered the current step.
		/// </summary>
		[DataMember(Name = "step_time_millis")]
		[JsonFormatter(typeof(DateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset StepTime { get; internal set; }
	}

	public class PhaseExecution
	{
		/// <summary>
		/// The date the loaded policy was last modified.
		/// </summary>
		[DataMember(Name = "modified_date_in_millis")]
		[JsonFormatter(typeof(DateTimeOffsetEpochMillisecondsFormatter))]
		public DateTimeOffset ModifiedDate { get; internal set; }

		/// <summary>
		/// The phase definition loaded from the specified policy when the index entered this phase.
		/// </summary>
		[DataMember(Name = "phase_definition")]
		public IPhase PhaseDefinition { get; internal set; }

		[DataMember(Name = "policy")]
		public string Policy { get; internal set; }

		/// <summary>
		/// The version of the policy that was loaded.
		/// </summary>
		[DataMember(Name = "version")]
		public int Version { get; internal set; }
	}
}
