﻿using System.Runtime.Serialization;

namespace Nest
{
	public class ExtendedBounds<T>
	{
		[DataMember(Name ="max")]
		public T Maximum { get; set; }

		[DataMember(Name ="min")]
		public T Minimum { get; set; }
	}
}
