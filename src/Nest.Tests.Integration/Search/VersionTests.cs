﻿using System.Linq;
using Nest.Tests.MockData;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Search
{
	[TestFixture]
	public class VersionTests : BaseElasticSearchTests
	{
		private string _LookFor = NestTestData.Data.First().Followers.First().FirstName;

		[Test]
		public void SimpleVersion()
		{
			var queryResults = this.ConnectedClient.SearchRaw<ElasticSearchProject>(
					@" {
						""version"": true,
						""query"" : {
							""match_all"" : { }
					} }"
				);

			Assert.True(queryResults.DocumentsWithMetaData.All(h=>!h.Version.IsNullOrEmpty()));
		}
	
	}
}