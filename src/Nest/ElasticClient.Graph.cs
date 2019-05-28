using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.GraphApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.GraphApi
{
	///<summary>
	/// Logically groups all Graph API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Graph"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class GraphNamespace : NamespacedClientProxy
	{
		internal GraphNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IGraphExploreRequest"/>
		public GraphExploreResponse Explore<TDocument>(Func<GraphExploreDescriptor<TDocument>, IGraphExploreRequest> selector = null)
			where TDocument : class => Explore(selector.InvokeOrDefault(new GraphExploreDescriptor<TDocument>()));
		///<inheritdoc cref = "IGraphExploreRequest"/>
		public Task<GraphExploreResponse> ExploreAsync<TDocument>(Func<GraphExploreDescriptor<TDocument>, IGraphExploreRequest> selector = null, CancellationToken ct = default)
			where TDocument : class => ExploreAsync(selector.InvokeOrDefault(new GraphExploreDescriptor<TDocument>()), ct);
		///<inheritdoc cref = "IGraphExploreRequest"/>
		public GraphExploreResponse Explore(IGraphExploreRequest request) => DoRequest<IGraphExploreRequest, GraphExploreResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IGraphExploreRequest"/>
		public Task<GraphExploreResponse> ExploreAsync(IGraphExploreRequest request, CancellationToken ct = default) => DoRequestAsync<IGraphExploreRequest, GraphExploreResponse>(request, request.RequestParameters, ct);
	}
}