﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Nest
{
	public partial class ElasticClient
	{

		public IIndexSettingsResponse GetIndexSettings(Func<GetIndexSettingsDescriptor, GetIndexSettingsDescriptor> selector)
		{
			return this.Dispatch<GetIndexSettingsDescriptor, GetIndexSettingsQueryString, IndexSettingsResponse>(
				selector,
				(p, d) => this.RawDispatch.IndicesGetSettingsDispatch<IndexSettingsResponse>(p)
			);
		}

		public Task<IIndexSettingsResponse> GetIndexSettingsAsync(Func<GetIndexSettingsDescriptor, GetIndexSettingsDescriptor> selector)
		{
			return this.DispatchAsync<GetIndexSettingsDescriptor, GetIndexSettingsQueryString, IndexSettingsResponse, IIndexSettingsResponse>(
				selector,
				(p, d) => this.RawDispatch.IndicesGetSettingsDispatchAsync<IndexSettingsResponse>(p)
			);
		}
	
		public IIndicesResponse DeleteIndex(Func<DeleteIndexDescriptor, DeleteIndexDescriptor> selector)
		{
			return this.Dispatch<DeleteIndexDescriptor, DeleteIndexQueryString, IndicesResponse>(
				selector, 
				(p, d)=> this.RawDispatch.IndicesDeleteDispatch<IndicesResponse>(p)
			);
		}
		public Task<IIndicesResponse> DeleteIndexAsync(Func<DeleteIndexDescriptor, DeleteIndexDescriptor> selector)
		{
			return this.DispatchAsync<DeleteIndexDescriptor, DeleteIndexQueryString, IndicesResponse, IIndicesResponse>(
				selector, 
				(p, d)=> this.RawDispatch.IndicesDeleteDispatchAsync<IndicesResponse>(p)
			);
		}

	}
}