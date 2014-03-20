﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Nest.Resolvers.Writers;

namespace Nest
{
	public partial class ElasticClient
	{
		public IIndicesResponse DeleteMapping(Func<DeleteMappingDescriptor, DeleteMappingDescriptor> selector)
		{
			return this.Dispatch<DeleteMappingDescriptor, DeleteMappingQueryString, IndicesResponse>(
				selector,
				(p, d) => this.RawDispatch.IndicesDeleteMappingDispatch<IndicesResponse>(p)
			);
		}

		public Task<IIndicesResponse> DeleteMappingAsync(Func<DeleteMappingDescriptor, DeleteMappingDescriptor> selector)
		{
			return this.DispatchAsync<DeleteMappingDescriptor, DeleteMappingQueryString, IndicesResponse, IIndicesResponse>(
				selector,
				(p, d) => this.RawDispatch.IndicesDeleteMappingDispatchAsync<IndicesResponse>(p)
			);
		}
	}
}