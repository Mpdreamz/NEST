﻿using System.Linq;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Mapping
{
	[TestFixture]
	public class NotAnalyzedTests : BaseElasticSearchTests
	{
		[Test]
		public void NotAnalyzedReturnsOneItem()
		{
			this.ConnectedClient.DeleteMapping<ElasticSearchProject>();
			this.ConnectedClient.DeleteMapping<ElasticSearchProject>(Test.Default.DefaultIndex + "_clone");
			var x = this.ConnectedClient.Map<ElasticSearchProject>();
			Assert.IsTrue(x.OK);

			var typeMapping = this.ConnectedClient.GetMapping(Test.Default.DefaultIndex, "elasticsearchprojects");
			Assert.AreEqual("not_analyzed", typeMapping.Properties["country"].Index);
			
			var indexResult = this.ConnectedClient.Index(new ElasticSearchProject
			{
				Country = "The Royal Kingdom Of The Netherlands"
			}, new IndexParameters { Refresh = true });
			Assert.IsTrue(indexResult.Success);

			var result = this.ConnectedClient.Search<ElasticSearchProject>(s=>s
				.FacetTerm(ft=>ft.OnField(f=>f.Country))
				.MatchAll()
			);
			var facets = result.FacetItems<TermItem>(f=>f.Country);
			Assert.AreEqual(1, facets.Count());
			Assert.AreEqual("The Royal Kingdom Of The Netherlands", facets.FirstOrDefault().Term);
		}

		[Test]
		public void AnalyzedReturnsTwoItems()
		{
			this.ConnectedClient.DeleteMapping<ElasticSearchProject>();
			var x = this.ConnectedClient.Map<ElasticSearchProject>();
			Assert.IsTrue(x.OK);

			var typeMapping = this.ConnectedClient.GetMapping(Test.Default.DefaultIndex, "elasticsearchprojects");
			this.ConnectedClient.DeleteMapping<ElasticSearchProject>();
			typeMapping.Properties["country"].Index = "analyzed";
			var updateMapResult = this.ConnectedClient.Map(typeMapping);
			Assert.True(updateMapResult.IsValid);

			var indexResult = this.ConnectedClient.Index(new ElasticSearchProject
			{
				Country = "The Royal Kingdom Of The Netherlands"
			}, new IndexParameters { Refresh = true });
			Assert.IsTrue(indexResult.Success);

			var result = this.ConnectedClient.Search<ElasticSearchProject>(s => s
				.FacetTerm(ft => ft.OnField(f => f.Country))
				.MatchAll()
			);
			var facets = result.FacetItems<TermItem>(f => f.Country);
			Assert.AreEqual(3, facets.Count());
			Assert.AreEqual("royal", facets.FirstOrDefault().Term);
		}


	}
}
