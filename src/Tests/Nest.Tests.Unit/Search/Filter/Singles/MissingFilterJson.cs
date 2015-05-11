﻿using NUnit.Framework;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Unit.Search.Filter.Singles
{
	[TestFixture]
	public class MissingFilterJson
	{
		[Test]
		public void MissingFilter()
		{
			var s = new SearchDescriptor<ElasticsearchProject>().From(0).Size(10)
				.PostFilter(ff=>ff.Missing(f=>f.Name));
				
			var json = TestElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				post_filter : {
						missing : { field : ""name"" }
					}
			}";
			Assert.True(json.JsonEquals(expected), json);		
		}
	}
}
