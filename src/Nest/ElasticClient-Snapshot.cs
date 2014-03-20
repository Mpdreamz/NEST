﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial class ElasticClient
	{
		public IShardsOperationResponse Snapshot(Func<SnapshotDescriptor, SnapshotDescriptor> snapshotSelector = null)
		{
			snapshotSelector = snapshotSelector ?? (s => s);
			return this.Dispatch<SnapshotDescriptor, SnapshotQueryString, ShardsOperationResponse>(
				snapshotSelector,
				(p, d) => this.RawDispatch.IndicesSnapshotIndexDispatch<ShardsOperationResponse>(p)
			);
		}

		public Task<IShardsOperationResponse> SnapshotAsync(Func<SnapshotDescriptor, SnapshotDescriptor> snapshotSelector = null)
		{
			snapshotSelector = snapshotSelector ?? (s => s);
			return this.DispatchAsync<SnapshotDescriptor, SnapshotQueryString, ShardsOperationResponse, IShardsOperationResponse>(
				snapshotSelector,
				(p, d) => this.RawDispatch.IndicesSnapshotIndexDispatchAsync<ShardsOperationResponse>(p)
			);
		}

	}
}
