﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	public partial class ElasticClient
	{
		public IIndicesOperationResponse Alias(Func<AliasDescriptor, AliasDescriptor> aliasSelector)
		{
			return this.Dispatch<AliasDescriptor, AliasQueryString, IndicesOperationResponse>(
				aliasSelector,
				(p, d) => this.RawDispatch.IndicesUpdateAliasesDispatch<IndicesOperationResponse>(p, d)
			);
		}
		
		public Task<IIndicesOperationResponse> AliasAsync(Func<AliasDescriptor, AliasDescriptor> aliasSelector)
		{
			return this.DispatchAsync<AliasDescriptor, AliasQueryString, IndicesOperationResponse, IIndicesOperationResponse>(
				aliasSelector,
				(p, d) => this.RawDispatch.IndicesUpdateAliasesDispatchAsync<IndicesOperationResponse>(p, d)
			);
		}

		public IGetAliasesResponse GetAliases(Func<GetAliasesDescriptor, GetAliasesDescriptor> getAliasesDescriptor)
		{
			return this.Dispatch<GetAliasesDescriptor, GetAliasesQueryString, GetAliasesResponse>(
				getAliasesDescriptor,
				(p, d) => this.RawDispatch.IndicesGetAliasDispatch<GetAliasesResponse>(p)
			);
		}
		public Task<IGetAliasesResponse> GetAliasesAsync(Func<GetAliasesDescriptor, GetAliasesDescriptor> getAliasesDescriptor)
		{
			return this.DispatchAsync<GetAliasesDescriptor, GetAliasesQueryString, GetAliasesResponse, IGetAliasesResponse>(
				getAliasesDescriptor,
				(p, d) => this.RawDispatch.IndicesGetAliasDispatchAsync<GetAliasesResponse>(p)
			);
		}
	}
}
