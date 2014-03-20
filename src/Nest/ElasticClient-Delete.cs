﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial class ElasticClient
	{
		public IDeleteResponse Delete<T>(Func<DeleteDescriptor<T>, DeleteDescriptor<T>> deleteSelector) where T : class
		{
			return this.Dispatch<DeleteDescriptor<T>, DeleteQueryString, DeleteResponse>(
				deleteSelector,
				(p, d) => this.RawDispatch.DeleteDispatch<DeleteResponse>(p)
			);
		}

		public Task<IDeleteResponse> DeleteAsync<T>(Func<DeleteDescriptor<T>, DeleteDescriptor<T>> deleteSelector) where T : class
		{
			return this.DispatchAsync<DeleteDescriptor<T>, DeleteQueryString, DeleteResponse, IDeleteResponse>(
				deleteSelector,
				(p, d) => this.RawDispatch.DeleteDispatchAsync<DeleteResponse>(p)
			);
		}
	
	}
}
