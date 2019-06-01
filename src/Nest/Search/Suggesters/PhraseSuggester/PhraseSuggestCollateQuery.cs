﻿using System.Runtime.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// A query to run for a phrase suggester collate
	/// </summary>
	[InterfaceDataContract]
	[ReadAs(typeof(PhraseSuggestCollateQuery))]
	public interface IPhraseSuggestCollateQuery
	{
		/// <summary>
		/// The id for a stored script to execute
		/// </summary>
		[DataMember(Name = "id")]
		Id Id { get; set; }

		/// <summary>
		/// The source script to be executed
		/// </summary>
		[DataMember(Name = "source")]
		string Source { get; set; }
	}

	/// <inheritdoc />
	public class PhraseSuggestCollateQuery : IPhraseSuggestCollateQuery
	{
		/// <inheritdoc />
		public Id Id { get; set; }

		/// <inheritdoc />
		public string Source { get; set; }
	}

	/// <inheritdoc cref="IPhraseSuggestCollateQuery" />
	public class PhraseSuggestCollateQueryDescriptor
		: DescriptorBase<PhraseSuggestCollateQueryDescriptor, IPhraseSuggestCollateQuery>, IPhraseSuggestCollateQuery
	{
		Id IPhraseSuggestCollateQuery.Id { get; set; }
		string IPhraseSuggestCollateQuery.Source { get; set; }

		/// <inheritdoc cref="IPhraseSuggestCollateQuery.Source" />
		public PhraseSuggestCollateQueryDescriptor Source(string source) => Assign(source, (a, v) => a.Source = v);

		/// <inheritdoc cref="IPhraseSuggestCollateQuery.Id" />
		public PhraseSuggestCollateQueryDescriptor Id(Id id) => Assign(id, (a, v) => a.Id = v);
	}
}
