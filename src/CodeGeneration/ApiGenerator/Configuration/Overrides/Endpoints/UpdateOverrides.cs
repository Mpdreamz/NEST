﻿using System.Collections.Generic;

namespace ApiGenerator.Configuration.Overrides.Endpoints
{
	// ReSharper disable once UnusedMember.Global
	public class UpdateOverrides : EndpointOverridesBase
	{
		public override IEnumerable<string> SkipQueryStringParams => new[]
		{
			"fields",
			"_source_includes", "_source_excludes"
		};
	}
}
