﻿using System;
using Nest_5_2_0;

namespace Tests.Mapping.Types.Specialized.Ip
{
	public class IpTest
	{
		[Ip(
			Index = false,
			Boost = 1.3,
			NullValue = "127.0.0.1",
			IncludeInAll = true)]
		public string Full { get; set; }

		[Ip]
		public string Minimal { get; set; }
	}

	public class IpAttributeTests : AttributeTestsBase<IpTest>
	{
		protected override object ExpectJson => new
		{
			properties = new
			{
				full = new
				{
					type = "ip",
					index = false,
					boost = 1.3,
					null_value = "127.0.0.1",
					include_in_all = true
				},
				minimal = new
				{
					type = "ip"
				}
			}
		};
	}
}
