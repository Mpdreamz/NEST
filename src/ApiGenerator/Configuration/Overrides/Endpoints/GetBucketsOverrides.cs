﻿using System.Collections.Generic;

namespace ApiGenerator.Configuration.Overrides.Endpoints
{
	public class GetBucketsOverrides : EndpointOverridesBase
	{
		public override IEnumerable<string> SkipQueryStringParams => new[]
		{
			"expand",
			"exclude_interim",
			"from",
			"size",
			"start",
			"timestamp",
			"end",
			"anomaly_score",
			"sort",
			"desc"
		};
	}
}
