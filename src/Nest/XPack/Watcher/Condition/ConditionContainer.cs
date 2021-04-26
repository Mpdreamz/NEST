/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// Conditions for a watch
	/// </summary>
	[InterfaceDataContract]
	[ReadAs(typeof(ConditionContainer))]
	public interface IConditionContainer
	{
		/// <summary>
		/// Forces the watch actions to be executed unless they are throttled.
		/// </summary>
		[DataMember(Name = "always")]
		IAlwaysCondition Always { get; set; }

		/// <summary>
		/// Compares an array of values in the execution context to a given value.
		/// </summary>
		[DataMember(Name = "array_compare")]
		IArrayCompareCondition ArrayCompare { get; set; }

		/// <summary>
		/// Performs a simple comparison against a value in the watch payload.
		/// </summary>
		[DataMember(Name = "compare")]
		ICompareCondition Compare { get; set; }

		/// <summary>
		/// Watch actions are never executed when the watch is triggered.
		/// The watch input is executed, a record is added to the watch history,
		/// and the watch execution ends.
		/// </summary>
		/// <remarks>
		/// This condition is generally used for testing.
		/// </remarks>
		[DataMember(Name = "never")]
		INeverCondition Never { get; set; }

		/// <summary>
		/// A watch condition that evaluates a script.
		/// You can use any of the scripting languages supported by Elasticsearch as long as the
		/// language supports evaluating expressions to Boolean values.
		/// Note that the mustache and expression languages are too limited to be used by this condition.
		/// </summary>
		[DataMember(Name = "script")]
		IScriptCondition Script { get; set; }
	}

	/// <inheritdoc />
	[DataContract]
	public class ConditionContainer : IConditionContainer, IDescriptor
	{
		internal ConditionContainer() { }

		public ConditionContainer(ConditionBase condition)
		{
			condition.ThrowIfNull(nameof(condition));
			condition.WrapInContainer(this);
		}

		/// <inheritdoc />
		IAlwaysCondition IConditionContainer.Always { get; set; }

		/// <inheritdoc />
		IArrayCompareCondition IConditionContainer.ArrayCompare { get; set; }

		/// <inheritdoc />
		ICompareCondition IConditionContainer.Compare { get; set; }

		/// <inheritdoc />
		INeverCondition IConditionContainer.Never { get; set; }

		/// <inheritdoc />
		IScriptCondition IConditionContainer.Script { get; set; }

		public static implicit operator ConditionContainer(ConditionBase condition) => condition == null
			? null
			: new ConditionContainer(condition);
	}

	/// <inheritdoc />
	public class ConditionDescriptor : ConditionContainer
	{
		private ConditionDescriptor Assign<TValue>(TValue value, Action<IConditionContainer, TValue> assigner) => Fluent.Assign(this, value, assigner);

		/// <inheritdoc />
		public ConditionDescriptor Always() => Assign(new AlwaysCondition(), (a,v) => a.Always = v);

		/// <inheritdoc />
		public ConditionDescriptor Never() => Assign(new NeverCondition(), (a, v) => a.Never = v);

		/// <inheritdoc />
		public ConditionDescriptor Compare(Func<CompareConditionDescriptor, ICompareCondition> selector) =>
			Assign(selector, (a, v) => a.Compare = v?.Invoke(new CompareConditionDescriptor()));

		/// <inheritdoc />
		public ConditionDescriptor ArrayCompare(Func<ArrayCompareConditionDescriptor, IArrayCompareCondition> selector) =>
			Assign(selector,(a, v) => a.ArrayCompare = v?.Invoke(new ArrayCompareConditionDescriptor()));

		/// <inheritdoc />
		public ConditionDescriptor Script(Func<ScriptConditionDescriptor, IScriptCondition> selector) =>
			Assign(selector, (a, v) => a.Script = v?.Invoke(new ScriptConditionDescriptor()));
	}
}
