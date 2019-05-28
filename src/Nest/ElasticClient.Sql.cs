using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net.Specification.SqlApi;

// ReSharper disable once CheckNamespace
namespace Nest.Specification.SqlApi
{
	///<summary>
	/// Logically groups all Sql API's together so that they may be discovered more naturally.
	/// <para>Not intended to be instantiated directly please defer to the <see cref = "IElasticClient.Sql"/> property
	/// on <see cref = "IElasticClient"/>.
	///</para>
	///</summary>
	public class SqlNamespace : NamespacedClientProxy
	{
		internal SqlNamespace(ElasticClient client): base(client)
		{
		}

		///<inheritdoc cref = "IClearSqlCursorRequest"/>
		public ClearSqlCursorResponse ClearCursor(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector) => ClearCursor(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()));
		///<inheritdoc cref = "IClearSqlCursorRequest"/>
		public Task<ClearSqlCursorResponse> ClearCursorAsync(Func<ClearSqlCursorDescriptor, IClearSqlCursorRequest> selector, CancellationToken ct = default) => ClearCursorAsync(selector.InvokeOrDefault(new ClearSqlCursorDescriptor()), ct);
		///<inheritdoc cref = "IClearSqlCursorRequest"/>
		public ClearSqlCursorResponse ClearCursor(IClearSqlCursorRequest request) => DoRequest<IClearSqlCursorRequest, ClearSqlCursorResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IClearSqlCursorRequest"/>
		public Task<ClearSqlCursorResponse> ClearCursorAsync(IClearSqlCursorRequest request, CancellationToken ct = default) => DoRequestAsync<IClearSqlCursorRequest, ClearSqlCursorResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "IQuerySqlRequest"/>
		public QuerySqlResponse Query(Func<QuerySqlDescriptor, IQuerySqlRequest> selector = null) => Query(selector.InvokeOrDefault(new QuerySqlDescriptor()));
		///<inheritdoc cref = "IQuerySqlRequest"/>
		public Task<QuerySqlResponse> QueryAsync(Func<QuerySqlDescriptor, IQuerySqlRequest> selector = null, CancellationToken ct = default) => QueryAsync(selector.InvokeOrDefault(new QuerySqlDescriptor()), ct);
		///<inheritdoc cref = "IQuerySqlRequest"/>
		public QuerySqlResponse Query(IQuerySqlRequest request) => DoRequest<IQuerySqlRequest, QuerySqlResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "IQuerySqlRequest"/>
		public Task<QuerySqlResponse> QueryAsync(IQuerySqlRequest request, CancellationToken ct = default) => DoRequestAsync<IQuerySqlRequest, QuerySqlResponse>(request, request.RequestParameters, ct);
		///<inheritdoc cref = "ITranslateSqlRequest"/>
		public TranslateSqlResponse Translate(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null) => Translate(selector.InvokeOrDefault(new TranslateSqlDescriptor()));
		///<inheritdoc cref = "ITranslateSqlRequest"/>
		public Task<TranslateSqlResponse> TranslateAsync(Func<TranslateSqlDescriptor, ITranslateSqlRequest> selector = null, CancellationToken ct = default) => TranslateAsync(selector.InvokeOrDefault(new TranslateSqlDescriptor()), ct);
		///<inheritdoc cref = "ITranslateSqlRequest"/>
		public TranslateSqlResponse Translate(ITranslateSqlRequest request) => DoRequest<ITranslateSqlRequest, TranslateSqlResponse>(request, request.RequestParameters);
		///<inheritdoc cref = "ITranslateSqlRequest"/>
		public Task<TranslateSqlResponse> TranslateAsync(ITranslateSqlRequest request, CancellationToken ct = default) => DoRequestAsync<ITranslateSqlRequest, TranslateSqlResponse>(request, request.RequestParameters, ct);
	}
}