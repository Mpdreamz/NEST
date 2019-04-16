﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nest
{
	/// <summary> The response from creating a calendar.</summary>
	public class PutCalendarResponse : ResponseBase
	{
		[DataMember(Name = "calendar_id")]
		public string CalendarId { get; internal set; }

		[DataMember(Name = "description")]
		public string Description { get; internal set; }

		[DataMember(Name = "job_ids")]
		public IReadOnlyCollection<string> JobIds { get; internal set; } = EmptyReadOnly<string>.Collection;
	}
}
