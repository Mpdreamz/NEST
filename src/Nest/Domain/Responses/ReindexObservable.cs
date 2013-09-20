﻿using System;

namespace Nest
{
	public class ReindexObservable<T> : IDisposable, IObservable<IReindexResponse<T>> where T : class
	{
		private ReindexDescriptor<T> _reindexDescriptor;
		private readonly IConnectionSettings _connectionSettings;
		internal IElasticClient CurrentClient { get; set; }
		internal ReindexDescriptor<T> ReindexDescriptor { get; set; } 

		public ReindexObservable(IElasticClient client, IConnectionSettings connectionSettings, ReindexDescriptor<T> reindexDescriptor)
		{
			this._connectionSettings = connectionSettings;
			this._reindexDescriptor = reindexDescriptor;
			this.CurrentClient = client;
		}

		public IDisposable Subscribe(IObserver<IReindexResponse<T>> observer)
		{
			observer.ThrowIfNull("observer");
			try 
			{
				this.Reindex(observer);
			}
			catch (Exception e)
			{
				observer.OnError(e);
			}
			return this;

		}

		private void Reindex(IObserver<IReindexResponse<T>> observer)
		{
			var fromIndex = this._reindexDescriptor._FromIndexName;
			var toIndex = this._reindexDescriptor._ToIndexName;
			var scroll = this._reindexDescriptor._Scroll ?? "2m";

			fromIndex.ThrowIfNullOrEmpty("fromIndex");
			toIndex.ThrowIfNullOrEmpty("toIndex");

			var indexSettings = this.CurrentClient.GetIndexSettings(this._reindexDescriptor._FromIndexName);
			var createSettings = new CreateIndexDescriptor(this._connectionSettings)
				.InitializeUsing(indexSettings.Settings);
			var createIndexResponse = this.CurrentClient
				.CreateIndex(toIndex, (c) =>
				{
					if (this._reindexDescriptor._CreateIndexSelector != null)
						return this._reindexDescriptor._CreateIndexSelector(createSettings);
					return c;
				});
			if (!createIndexResponse.IsValid)
				throw new ReindexException(createIndexResponse.ConnectionStatus);

			var page = 0;
			var searchResult = this.CurrentClient.Search<T>(
				s => s
					.Index(fromIndex)
					.AllTypes()
					.From(0)
					.Take(100)
					.Query(this._reindexDescriptor._QuerySelector ?? (q=>q.MatchAll()))
					.SearchType(SearchType.Scan)
					.Scroll(scroll)
				);
			if (searchResult.Total <= 0)
				throw new ReindexException(searchResult.ConnectionStatus, "index " + fromIndex + " has no documents!");
			IBulkResponse indexResult = null;
			do
			{
				searchResult = this.CurrentClient.Scroll<T>(scroll, searchResult.ScrollId);
				if (searchResult.Documents.HasAny())
					indexResult = this.IndexSearchResults(searchResult, observer, toIndex, page);
				page++;
			} while (searchResult.IsValid && indexResult != null && indexResult.IsValid && searchResult.Documents.HasAny());


			observer.OnCompleted();
		}

		public IBulkResponse IndexSearchResults(IQueryResponse<T> searchResult,IObserver<IReindexResponse<T>> observer, string toIndex, int page)
		{
			if (!searchResult.IsValid)
				throw new ReindexException(searchResult.ConnectionStatus, "reindex failed on scroll #" + page);

			var indexResult = this.CurrentClient.IndexMany(searchResult.Documents, toIndex);
			if (!indexResult.IsValid)
				throw new ReindexException(indexResult.ConnectionStatus, "reindex failed when indexing page " + page);

			observer.OnNext(new ReindexResponse<T>()
			{
				BulkResponse = indexResult,
				QueryResponse = searchResult,
				Scroll = page
			});
			return indexResult;
		}


		public void Dispose()
		{

		}
	}
}