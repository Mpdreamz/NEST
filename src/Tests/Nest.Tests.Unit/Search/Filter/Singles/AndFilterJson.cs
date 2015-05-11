﻿using NUnit.Framework;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Unit.Search.Filter.Singles
{
	[TestFixture]
	public class AndFilterJson
	{
		[Test]
		public void AndFilter()
		{
			var s = new SearchDescriptor<ElasticsearchProject>()
				.From(0)
				.Size(10)
				.PostFilter(filter=>filter
					.And(
						f=>f.MatchAll(),
						f=>f.Missing(p=>p.LOC)
					)
					
				);
				
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				post_filter : {
						""and"": {
							""filters"": [
								{
									""match_all"": {}
								},
								{
									""missing"": {
										""field"": ""loc""
									}
								}
							]
						}
					}
			}";
			Assert.True(json.JsonEquals(expected), json);		
		}
		[Test]
		public void AndFilterCacheNamed()
		{
			var s = new SearchDescriptor<ElasticsearchProject>()
				.From(0)
				.Size(10)
				.PostFilter(filter => filter.Cache(true).Name("and_filter")
					.And(
						f => f.MatchAll(),
						f => f.Missing(p => p.LOC)
					)

				);

			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				post_filter : {
						""and"": {
							""filters"": [
								{
									""match_all"": {}
								},
								{
									""missing"": {
										""field"": ""loc""
									}
								}
							],
							_cache:true,
							_name:""and_filter""
						}
					}
			}";
			Assert.True(json.JsonEquals(expected), json);
		}
	}
}
