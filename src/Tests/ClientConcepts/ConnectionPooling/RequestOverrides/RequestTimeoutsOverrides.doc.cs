﻿using System;
using System.Threading.Tasks;
using static Elasticsearch.Net.AuditEvent;
using Tests.Framework;

namespace Tests.ClientConcepts.ConnectionPooling.RequestOverrides
{
	public class RequestTimeoutsOverrides
	{
		/** :section-number: 6.2
		* == Request Timeouts
		*
		* While you can specify Request time out globally you can override this per request too
		*/

		[U]
		public async Task RespectsRequestTimeoutOverride()
		{

			/** we set up a 10 node cluster with a global time out of 20 seconds. 
			* Each call on a node takes 10 seconds. So we can only try this call on 2 nodes
			* before the max request time out kills the client call.
			*/
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.ClientCalls(r => r.FailAlways().Takes(TimeSpan.FromSeconds(10)))
				.ClientCalls(r => r.OnPort(9209).SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.DisablePing().RequestTimeout(TimeSpan.FromSeconds(20)))
			);

			audit = await audit.TraceCalls(
				new ClientCall {
					{ BadResponse, 9200 },
					{ BadResponse, 9201 },
					{ MaxTimeoutReached }
				},
				/**
				* On the second request we specify a request timeout override to 60 seconds
				* We should now see more nodes being tried.
				*/
				new ClientCall(r => r.RequestTimeout(TimeSpan.FromSeconds(80)))
				{
					{ BadResponse, 9203 },
					{ BadResponse, 9204 },
					{ BadResponse, 9205 },
					{ BadResponse, 9206 },
					{ BadResponse, 9207 },
					{ BadResponse, 9208 },
					{ HealthyResponse, 9209 },
				}
			);

		}

		/** == Connect Timeouts
		* Connect timeouts can be overridden, webrequest/httpclient can not distinguish connect and retry timeouts however
		* we use this separate configuration value for ping requests.
		*/
		[U]
		public async Task RespectsConnectTimeoutOverride()
		{
			/** we set up a 10 node cluster with a global time out of 20 seconds. 
			* Each call on a node takes 10 seconds. So we can only try this call on 2 nodes
			* before the max request time out kills the client call.
			*/
			var audit = new Auditor(() => Framework.Cluster
				.Nodes(10)
				.Ping(p => p.SucceedAlways().Takes(TimeSpan.FromSeconds(20)))
				.ClientCalls(r => r.SucceedAlways())
				.StaticConnectionPool()
				.Settings(s => s.RequestTimeout(TimeSpan.FromSeconds(10)).PingTimeout(TimeSpan.FromSeconds(10)))
			);

			audit = await audit.TraceCalls(
				/**
				* The first call uses the configured global settings, request times out after 10 seconds and ping 
				* calls always take 20, so we should see a single ping failure
				*/
				new ClientCall {
					{ PingFailure, 9200 },
					{ MaxTimeoutReached }
				},
				/**
				* On the second request we set a request ping timeout override of 2seconds
				* We should now see more nodes being tried before the request timeout is hit.
				*/
				new ClientCall(r => r.PingTimeout(TimeSpan.FromSeconds(2)))
				{
					{ PingFailure, 9202 },
					{ PingFailure, 9203 },
					{ PingFailure, 9204 },
					{ PingFailure, 9205 },
					{ PingFailure, 9206 },
					{ MaxTimeoutReached }
				}
			);

		}
	}
}
