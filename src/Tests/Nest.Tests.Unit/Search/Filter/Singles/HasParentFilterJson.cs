﻿using NUnit.Framework;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Unit.Search.Filter.Singles
{
	[TestFixture]
	public class HasParentFilterJson
	{
		[Test]
		public void HasParentFilter()
		{
			var s = new SearchDescriptor<Person>().From(0).Size(10)
				.PostFilter(ff=>ff
					.HasParent<ElasticsearchProject>(d=>d
						.Query(q=>q.Term(p=>p.Country, "value"))
					)
				);
				
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				post_filter : {
					""has_parent"": {
					  ""type"": ""elasticsearchprojects"",
					  ""query"": {
						""term"": {
						  ""country"": {
							""value"": ""value""
						  }
						}
					  }
					}
				}
			}";
			Assert.True(json.JsonEquals(expected), json);		
		}
	}
}
