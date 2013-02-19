﻿using System.Linq;
using Nest.Tests.MockData;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Search.SearchType
{
	[TestFixture]
	public class SearchTypeTests : IntegrationTests
	{
		private string _LookFor = NestTestData.Data.First().Followers.First().FirstName;

		[Test]
		public void SearchQueryAndFetch()
		{
			var queryResults = this._client.Search<ElasticSearchProject>(s=>s
				.From(0)
				.Size(10)
				.MatchAll()
				.Fields(f=>f.Name)
				.SearchType(Nest.SearchType.QueryAndFetch)
				
			);
			Assert.True(queryResults.IsValid);
			Assert.True(queryResults.Documents.Any());
		}
		[Test]
		public void SearchQueryThenFetch()
		{
			var queryResults = this._client.Search<ElasticSearchProject>(s => s
				.From(0)
				.Size(10)
				.MatchAll()
				.Fields(f => f.Name)
				.SearchType(Nest.SearchType.QueryThenFetch)

			);
			Assert.True(queryResults.IsValid);
			Assert.True(queryResults.Documents.Any());
		}

		[Test]
		public void SearchDfsQueryAndFetch()
		{
			var queryResults = this._client.Search<ElasticSearchProject>(s => s
				.From(0)
				.Size(10)
				.MatchAll()
				.Fields(f => f.Name)
				.SearchType(Nest.SearchType.DfsQueryAndFetch)

			);
			Assert.True(queryResults.IsValid);
			Assert.True(queryResults.Documents.Any());
		}
		[Test]
		public void SearchDfsQueryThenFetch()
		{
			var queryResults = this._client.Search<ElasticSearchProject>(s => s
				.From(0)
				.Size(10)
				.MatchAll()
				.Fields(f => f.Name)
				.SearchType(Nest.SearchType.DfsQueryThenFetch)

			);
			Assert.True(queryResults.IsValid);
			Assert.True(queryResults.Documents.Any());
		}

		//TODO move to factory test project

		//[Test]
		//public void SearchDfsQueryThenFetchUsingFactory()
		//{
		//	var sb = SearchBuilder.Builder()
		//		.From(0)
		//		.Size(10)
		//		.Field("name")
		//		.Query(QueryFactory.MatchAllQuery());
		//	var queryResults = this._client.Search<ElasticSearchProject>(sb, searchType: Nest.SearchType.DfsQueryAndFetch);
		//	Assert.True(queryResults.IsValid);
		//	Assert.True(queryResults.Documents.Any());
		//}
	}
}