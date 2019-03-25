﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Elasticsearch.Net;
using Utf8Json;

namespace Nest
{
	public interface IGetMappingResponse : IResponse
	{
		IReadOnlyDictionary<IndexName, IndexMappings> Indices { get; }

		void Accept(IMappingVisitor visitor);
	}

	public class IndexMappings
	{
		[Obsolete("Mapping are no longer grouped by type, this indexer is ignored and simply returns Mapppings")]
		public TypeMapping this[string type] => Mappings;

		[DataMember(Name = "mappings")]
		public TypeMapping Mappings { get; internal set; }
	}

	[JsonFormatter(typeof(ResolvableDictionaryResponseFormatter<GetMappingResponse, IndexName, IndexMappings>))]
	public class GetMappingResponse : DictionaryResponseBase<IndexName, IndexMappings>, IGetMappingResponse
	{
		[IgnoreDataMember]
		public IReadOnlyDictionary<IndexName, IndexMappings> Indices => Self.BackingDictionary;

		public void Accept(IMappingVisitor visitor)
		{
			var walker = new MappingWalker(visitor);
			walker.Accept(this);
		}
	}

	public static class GetMappingResponseExtensions
	{
		public static ITypeMapping GetMappingFor<T>(this IGetMappingResponse response) => response.GetMappingFor(typeof(T));

		public static ITypeMapping GetMappingFor(this IGetMappingResponse response, IndexName index)
		{
			if (index.IsNullOrEmpty()) return null;

			return response.Indices.TryGetValue(index, out var indexMappings) ? indexMappings.Mappings : null;
		}
	}
}
