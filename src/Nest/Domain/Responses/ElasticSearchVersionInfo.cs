﻿using System;
using Newtonsoft.Json;

namespace Nest
{

    public class ElasticSearchVersionInfo
    {
		public string Number { get; set; }

		[JsonProperty(PropertyName = "snapshot_build")]
		public bool IsSnapShotBuild { get; set; }

		[JsonProperty(PropertyName = "lucene_version")]
		public string LuceneVersion { get; set; }
	}
}
