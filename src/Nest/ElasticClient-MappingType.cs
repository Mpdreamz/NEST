﻿using Elasticsearch.Net;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nest
{
	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IIndicesResponse Map<T>(Func<PutMappingDescriptor<T>, PutMappingDescriptor<T>> mappingSelector) where T : class
		{
			mappingSelector.ThrowIfNull("mappingSelector");
			var descriptor = mappingSelector(new PutMappingDescriptor<T>(_connectionSettings));
			return this.Dispatch<PutMappingDescriptor<T>, PutMappingRequestParameters, IndicesResponse>(
				descriptor,
				(p, d) =>
				{
					var o = new Dictionary<string, RootObjectMapping>
					{
						{p.Type, d._Mapping}
					};
					return this.RawDispatch.IndicesPutMappingDispatch<IndicesResponse>(p, o);
				}
			);
		}

		/// <inheritdoc />
		public Task<IIndicesResponse> MapAsync<T>(Func<PutMappingDescriptor<T>, PutMappingDescriptor<T>> mappingSelector)
			where T : class
		{
			mappingSelector.ThrowIfNull("mappingSelector");
			var descriptor = mappingSelector(new PutMappingDescriptor<T>(_connectionSettings));
			return this.DispatchAsync<PutMappingDescriptor<T>, PutMappingRequestParameters, IndicesResponse, IIndicesResponse>(
				descriptor,
				(p, d) =>
				{
					var o = new Dictionary<string, RootObjectMapping>
					{
						{p.Type, d._Mapping}
					};
					return this.RawDispatch.IndicesPutMappingDispatchAsync<IndicesResponse>(p, o);
				}
			);
		}
	}
}