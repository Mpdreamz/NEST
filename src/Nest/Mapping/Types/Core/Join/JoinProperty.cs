﻿using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// The join datatype is a special field that creates parent/child relation within documents of the same index.
	/// </summary>
	[InterfaceDataContract]
	public interface IJoinProperty : IProperty
	{
		/// <summary>
		/// Defines a set of possible relations within the documents,
		/// each relation being a parent name and a child name.
		/// </summary>
		[DataMember(Name = "relations")]
		IRelations Relations { get; set; }
	}

	/// <inheritdoc cref="IJoinProperty"/>
	[DebuggerDisplay("{DebugDisplay}")]
	public class JoinProperty : PropertyBase, IJoinProperty
	{
		public JoinProperty() : base(FieldType.Join) { }

		public IRelations Relations { get; set; }
	}

	/// <inheritdoc cref="IJoinProperty"/>
	[DebuggerDisplay("{DebugDisplay}")]
	public class JoinPropertyDescriptor<T> : PropertyDescriptorBase<JoinPropertyDescriptor<T>, IJoinProperty, T>, IJoinProperty
		where T : class
	{
		public JoinPropertyDescriptor() : base(FieldType.Join) { }

		IRelations IJoinProperty.Relations { get; set; }

		/// <inheritdoc cref="IJoinProperty.Relations"/>
		public JoinPropertyDescriptor<T> Relations(Func<RelationsDescriptor, IPromise<IRelations>> selector) =>
			Assign(selector, (a, v) => a.Relations = v?.Invoke(new RelationsDescriptor())?.Value);
	}
}
