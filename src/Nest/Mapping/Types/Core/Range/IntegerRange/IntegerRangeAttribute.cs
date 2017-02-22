﻿using System;
using Elasticsearch.Net;

namespace Nest_5_2_0
{
	public class FloatRangeAttribute : RangePropertyAttributeBase, IFloatRangeProperty
	{
		public FloatRangeAttribute() : base(RangeType.FloatRange) { }
	}
}
