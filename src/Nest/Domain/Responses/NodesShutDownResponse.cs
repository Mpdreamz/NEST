﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nest
{

	public interface INodesShutdownResponse : IResponse
	{
		string ClusterName { get; set; }
		Dictionary<string, Dictionary<string, string>> Nodes { get; set; }
	}

	[JsonObject]
	public class NodesShutdownResponse : BaseResponse, INodesShutdownResponse
	{
		[JsonProperty("cluster_name")]
		public string ClusterName { get; set; }

		[JsonProperty("nodes")]
		public Dictionary<string, Dictionary<string, string>> Nodes { get; set; }
	}
}
