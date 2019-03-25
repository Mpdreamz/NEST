﻿using System.Runtime.Serialization;

namespace Nest
{
	[ReadAs(typeof(RoutingField))]
	public interface IRoutingField : IFieldMapping
	{
		[DataMember(Name ="required")]
		bool? Required { get; set; }
	}

	public class RoutingField : IRoutingField
	{
		public bool? Required { get; set; }
	}

	public class RoutingFieldDescriptor<T>
		: DescriptorBase<RoutingFieldDescriptor<T>, IRoutingField>, IRoutingField
	{
		bool? IRoutingField.Required { get; set; }

		public RoutingFieldDescriptor<T> Required(bool? required = true) => Assign(a => a.Required = required);
	}
}
