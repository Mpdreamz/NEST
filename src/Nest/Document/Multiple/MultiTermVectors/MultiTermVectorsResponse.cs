﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	public interface IMultiTermVectorsResponse : IResponse
	{
		IEnumerable<TermVectorsResponse> Documents { get; }
	}

	[JsonObject]
	public class MultiTermVectorsResponse : ResponseBase, IMultiTermVectorsResponse
	{
		[JsonProperty("docs")]
		public IEnumerable<TermVectorsResponse> Documents { get; internal set; } = new List<TermVectorsResponse>();
	}
}
