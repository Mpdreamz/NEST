﻿using System.Collections.Generic;

namespace ApiGenerator.Overrides.Endpoints
{
	public class GetCalendarEventsOverrides : EndpointOverridesBase
	{
		public override IEnumerable<string> SkipQueryStringParams => new[]
		{
			"from",
			"size"
		};
	}
}
