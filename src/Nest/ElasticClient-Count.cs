﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial class ElasticClient
	{
		public ICountResponse Count<T>(Func<CountDescriptor<T>, CountDescriptor<T>> countSelector = null) where T : class
		{
		    countSelector = countSelector ?? (s => s);
			return this.Dispatch<CountDescriptor<T>, CountQueryString, CountResponse>(
				countSelector,
				(p,d) => this.RawDispatch.CountDispatch<CountResponse>(p, d)
			);
		}

		public Task<ICountResponse> CountAsync<T>(Func<CountDescriptor<T>, CountDescriptor<T>> countSelector = null) where T : class
		{
		    countSelector = countSelector ?? (s => s);
			return this.DispatchAsync<CountDescriptor<T>, CountQueryString, CountResponse, ICountResponse>(
				countSelector,
				(p,d) => this.RawDispatch.CountDispatchAsync<CountResponse>(p, d)
			);
		}
	}
}
