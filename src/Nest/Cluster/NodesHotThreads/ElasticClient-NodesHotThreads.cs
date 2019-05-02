﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	using NodesHotThreadConverter = Func<IApiCallDetails, Stream, NodesHotThreadsResponse>;

	public partial interface IElasticClient
	{
		/// <summary>
		/// An API allowing to get the current hot threads on each node in the cluster.
		/// </summary>
		/// <param name="selector"></param>
		/// <returns>An optional descriptor to further describe the nodes hot threads operation</returns>
		NodesHotThreadsResponse NodesHotThreads(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null);

		/// <inheritdoc />
		NodesHotThreadsResponse NodesHotThreads(INodesHotThreadsRequest request);

		/// <inheritdoc />
		Task<NodesHotThreadsResponse> NodesHotThreadsAsync(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null,
			CancellationToken ct = default
		);

		/// <inheritdoc />
		Task<NodesHotThreadsResponse> NodesHotThreadsAsync(INodesHotThreadsRequest request, CancellationToken ct = default);
	}

	public partial class ElasticClient
	{
		//::: {Dragonfly}{lvtIV72sRIWBGik7ulbuaw}{127.0.0.1}{127.0.0.1:9300}
		private static readonly Regex NodeRegex = new Regex(@"^\s\{(?<name>.+?)\}\{(?<id>.+?)\}(?<hosts>.+)\n");

		/// <inheritdoc />
		public NodesHotThreadsResponse NodesHotThreads(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null) =>
			NodesHotThreads(selector.InvokeOrDefault(new NodesHotThreadsDescriptor()));

		/// <inheritdoc />
		public NodesHotThreadsResponse NodesHotThreads(INodesHotThreadsRequest request)
		{
			request.RequestParameters.DeserializationOverride = DeserializeNodesHotThreadResponse;
			return DoRequest<INodesHotThreadsRequest, NodesHotThreadsResponse>(request, request.RequestParameters);
		}

		/// <inheritdoc />
		public Task<NodesHotThreadsResponse> NodesHotThreadsAsync(Func<NodesHotThreadsDescriptor, INodesHotThreadsRequest> selector = null,
			CancellationToken ct = default
		) =>
			NodesHotThreadsAsync(selector.InvokeOrDefault(new NodesHotThreadsDescriptor()), ct);

		/// <inheritdoc />
		public Task<NodesHotThreadsResponse> NodesHotThreadsAsync(INodesHotThreadsRequest request, CancellationToken ct = default)
		{
			request.RequestParameters.DeserializationOverride = DeserializeNodesHotThreadResponse;
			return DoRequestAsync<INodesHotThreadsRequest, NodesHotThreadsResponse>(request, request.RequestParameters, ct);
		}

		/// <summary>
		/// Because the nodes.hot_threads endpoint returns plain text instead of JSON, we have to
		/// manually parse the response text into a typed response object.
		/// </summary>
		private NodesHotThreadsResponse DeserializeNodesHotThreadResponse(IApiCallDetails response, Stream stream)
		{
			using (stream)
			using (var sr = new StreamReader(stream, Encoding.UTF8))
			{
				var plainTextResponse = sr.ReadToEnd();

				// If the response doesn't start with :::, which is the pattern that delimits
				// each node section in the response, then the response format isn't recognized.
				// Just return an empty response object. This is especially useful when unit
				// testing against an in-memory connection where you won't get a real response.
				if (!plainTextResponse.StartsWith(":::", StringComparison.Ordinal))
					return new NodesHotThreadsResponse();

				var sections = plainTextResponse.Split(new string[] { ":::" }, StringSplitOptions.RemoveEmptyEntries);
				var info =
					from section in sections
					select section.Split(new string[] { "\n   \n" }, StringSplitOptions.None)
					into sectionLines
					where sectionLines.Length > 0
					let nodeLine = sectionLines.FirstOrDefault()
					where nodeLine != null
					let matches = NodeRegex.Match(nodeLine)
					where matches.Success
					let node = matches.Groups["name"].Value
					let nodeId = matches.Groups["id"].Value
					let hosts = matches.Groups["hosts"].Value.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
					let threads = sectionLines.Skip(1).Take(sectionLines.Length - 1).ToList()
					select new HotThreadInformation
					{
						NodeName = node,
						NodeId = nodeId,
						Threads = threads,
						Hosts = hosts
					};
				return new NodesHotThreadsResponse(info.ToList());
			}
		}
	}
}
