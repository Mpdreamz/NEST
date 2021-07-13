// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information
// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elastic.Transport;
using static Elastic.Transport.HttpMethod;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable once CheckNamespace
// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable RedundantExtendsListEntry
namespace Elasticsearch.Net.Specification.SqlApi
{
	///<summary>
	/// Sql APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticLowLevelClient.Sql"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public class LowLevelSqlNamespace : NamespacedClientProxy
	{
		internal LowLevelSqlNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>POST on /_sql/close <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-pagination.html</para></summary>
		///<param name = "body">Specify the cursor value in the `cursor` element to clean the cursor.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse ClearCursor<TResponse>(PostData body, ClearSqlCursorRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_sql/close", body, RequestParams(requestParameters));
		///<summary>POST on /_sql/close <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-pagination.html</para></summary>
		///<param name = "body">Specify the cursor value in the `cursor` element to clean the cursor.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.clear_cursor", "body")]
		public Task<TResponse> ClearCursorAsync<TResponse>(PostData body, ClearSqlCursorRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_sql/close", ctx, body, RequestParams(requestParameters));
		///<summary>DELETE on /_sql/async/delete/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-async-sql-search-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeleteAsync<TResponse>(string id, DeleteAsyncRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(DELETE, Url($"_sql/async/delete/{id:id}"), null, RequestParams(requestParameters));
		///<summary>DELETE on /_sql/async/delete/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-async-sql-search-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.delete_async", "id")]
		public Task<TResponse> DeleteAsyncAsync<TResponse>(string id, DeleteAsyncRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(DELETE, Url($"_sql/async/delete/{id:id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_sql/async/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-async-sql-search-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetAsync<TResponse>(string id, GetAsyncRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_sql/async/{id:id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_sql/async/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-async-sql-search-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.get_async", "id")]
		public Task<TResponse> GetAsyncAsync<TResponse>(string id, GetAsyncRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_sql/async/{id:id}"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_sql/async/status/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-async-sql-search-status-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse SearchStatus<TResponse>(string id, SqlSearchStatusRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(GET, Url($"_sql/async/status/{id:id}"), null, RequestParams(requestParameters));
		///<summary>GET on /_sql/async/status/{id} <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-async-sql-search-status-api.html</para></summary>
		///<param name = "id">The async search ID</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.get_async_status", "id")]
		public Task<TResponse> SearchStatusAsync<TResponse>(string id, SqlSearchStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(GET, Url($"_sql/async/status/{id:id}"), ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_sql <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-rest-overview.html</para></summary>
		///<param name = "body">Use the `query` element to start a query. Use the `cursor` element to continue a query.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Query<TResponse>(PostData body, QuerySqlRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_sql", body, RequestParams(requestParameters));
		///<summary>POST on /_sql <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-rest-overview.html</para></summary>
		///<param name = "body">Use the `query` element to start a query. Use the `cursor` element to continue a query.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.query", "body")]
		public Task<TResponse> QueryAsync<TResponse>(PostData body, QuerySqlRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_sql", ctx, body, RequestParams(requestParameters));
		///<summary>POST on /_sql/translate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-translate.html</para></summary>
		///<param name = "body">Specify the query in the `query` element.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse Translate<TResponse>(PostData body, TranslateSqlRequestParameters requestParameters = null)
			where TResponse : class, ITransportResponse, new() => DoRequest<TResponse>(POST, "_sql/translate", body, RequestParams(requestParameters));
		///<summary>POST on /_sql/translate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-translate.html</para></summary>
		///<param name = "body">Specify the query in the `query` element.</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("sql.translate", "body")]
		public Task<TResponse> TranslateAsync<TResponse>(PostData body, TranslateSqlRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, ITransportResponse, new() => DoRequestAsync<TResponse>(POST, "_sql/translate", ctx, body, RequestParams(requestParameters));
	}
}