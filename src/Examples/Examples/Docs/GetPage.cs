using System;
using Elastic.Xunit.XunitPlumbing;
using Examples.Models;
using Nest;

namespace Examples.Docs
{
	public class GetPage : ExampleBase
	{
		[U]
		public void Line10()
		{
			// tag::fbcf5078a6a9e09790553804054c36b3[]
			var getResponse = client.Get<Tweet>(0, g => g.Index("twitter"));
			// end::fbcf5078a6a9e09790553804054c36b3[]

			getResponse.MatchesExample("GET twitter/_doc/0");
		}

		[U]
		public void Line53()
		{
			// tag::138ccd89f72aa7502dd9578403dcc589[]
			var getResponse = client.Get<Tweet>(0, g => g
				.Index("twitter")
				.SourceEnabled(false)
			);
			// end::138ccd89f72aa7502dd9578403dcc589[]

			getResponse.MatchesExample(@"GET twitter/_doc/0?_source=false");
		}

		[U]
		public void Line65()
		{
			// tag::8fdf2344c4fb3de6902ad7c5735270df[]
			var getResponse = client.Get<Tweet>(0, g => g
				.Index("twitter")
				.SourceIncludes("*.id")
				.SourceExcludes("entities")
			);
			// end::8fdf2344c4fb3de6902ad7c5735270df[]

			getResponse.MatchesExample(@"GET twitter/_doc/0?_source_includes=*.id&_source_excludes=entities");
		}

		[U]
		public void Line73()
		{
			// tag::745f9b8cdb8e91073f6e520e1d9f8c05[]
			var getResponse = client.Get<Tweet>(0, g => g
				.Index("twitter")
				.SourceIncludes("*.id,retweeted")
			);
			// end::745f9b8cdb8e91073f6e520e1d9f8c05[]

			getResponse.MatchesExample(@"GET twitter/_doc/0?_source=*.id,retweeted", e =>
			{
				// client does not support short hand _source for _source_includes
				var uri = e.Uri.ToString();
				uri = uri.Replace("_source", "_source_includes");
				e.Uri = new Uri(uri);
				return e;
			});
		}

		[U]
		public void Line86()
		{
			// tag::1d65cb6d055c46a1bde809687d835b71[]
			var getResponse = client.Get<Tweet>(2, g => g
				.Index("twitter")
				.Routing("user1")
			);
			// end::1d65cb6d055c46a1bde809687d835b71[]

			getResponse.MatchesExample(@"GET twitter/_doc/2?routing=user1");
		}

		[U]
		public void Line250()
		{
			// tag::98234499cfec70487cec5d013e976a84[]
			var existsResponse = client.DocumentExists<Tweet>(0, g => g.Index("twitter"));
			// end::98234499cfec70487cec5d013e976a84[]

			existsResponse.MatchesExample(@"HEAD twitter/_doc/0");
		}

		[U]
		public void Line266()
		{
			// tag::89a8ac1509936acc272fc2d72907bc45[]
			var sourceResponse = client.Source<Tweet>(1, s => s.Index("twitter"));
			// end::89a8ac1509936acc272fc2d72907bc45[]

			sourceResponse.MatchesExample(@"GET twitter/_source/1");
		}

		[U]
		public void Line275()
		{
			// tag::d222c6a6ec7a3beca6c97011b0874512[]
			var sourceFilteringResponse = client.Source<Tweet>(1, s => s
				.Index("twitter")
				.SourceIncludes("*.id")
				.SourceExcludes("entities")
			);
			// end::d222c6a6ec7a3beca6c97011b0874512[]

			sourceFilteringResponse.MatchesExample(@"GET twitter/_source/1/?_source_includes=*.id&_source_excludes=entities");
		}

		[U]
		public void Line285()
		{
			// tag::2468ab381257d759d8a88af1141f6f9c[]
			var sourceExistsResponse = client.SourceExists<Tweet>(1, s => s.Index("twitter"));
			// end::2468ab381257d759d8a88af1141f6f9c[]

			sourceExistsResponse.MatchesExample(@"HEAD twitter/_source/1");
		}

		[U]
		public void Line299()
		{
			// tag::913770050ebbf3b9b549a899bc11060a[]
			var createIndexResponse = client.Indices.Create("twitter", c => c
				.Map<Tweet>(m => m
					.Properties(p => p
						.Number(n => n
							.Name(f => f.Counter)
							.Type(NumberType.Integer)
							.Store(false)
						)
						.Keyword(k => k
							.Name(f => f.Tags)
							.Store(true)
						)
					)
				)
			);
			// end::913770050ebbf3b9b549a899bc11060a[]

			createIndexResponse.MatchesExample(@"PUT twitter
			{
			   ""mappings"": {
			       ""properties"": {
			          ""counter"": {
			             ""type"": ""integer"",
			             ""store"": false
			          },
			          ""tags"": {
			             ""type"": ""keyword"",
			             ""store"": true
			          }
			       }
			   }
			}");
		}

		[U]
		public void Line320()
		{
			// tag::5eabcdbf61bfcb484dc694f25c2bba36[]
			var indexResponse = client.Index(new Tweet
			{
				Counter = 1,
				Tags = new[] { "red" }
			}, i => i.Index("twitter").Id(1));
			// end::5eabcdbf61bfcb484dc694f25c2bba36[]

			indexResponse.MatchesExample(@"PUT twitter/_doc/1
			{
			    ""counter"" : 1,
			    ""tags"" : [""red""]
			}");
		}

		[U]
		public void Line332()
		{
			// tag::710c7871f20f176d51209b1574b0d61b[]
			var getResponse = client.Get<Tweet>(1, g => g
				.Index("twitter")
				.StoredFields(
					f => f.Tags,
					f => f.Counter)
			);
			// end::710c7871f20f176d51209b1574b0d61b[]

			getResponse.MatchesExample(@"GET twitter/_doc/1?stored_fields=tags,counter");
		}

		[U]
		public void Line363()
		{
			// tag::0ba0b2db24852abccb7c0fc1098d566e[]
			var indexResponse = client.Index(new Tweet
			{
				Counter = 1,
				Tags = new[] { "white" }
			}, i => i
			.Index("twitter")
			.Id(2)
			.Routing("user1")
			);
			// end::0ba0b2db24852abccb7c0fc1098d566e[]

			indexResponse.MatchesExample(@"PUT twitter/_doc/2?routing=user1
			{
			    ""counter"" : 1,
			    ""tags"" : [""white""]
			}");
		}

		[U]
		public void Line373()
		{
			// tag::69a7be47f85138b10437113ab2f0d72d[]
			var getResponse = client.Get<Tweet>(2, g => g
				.Index("twitter")
				.Routing("user1")
				.StoredFields(
					f => f.Tags,
					f => f.Counter)
			);
			// end::69a7be47f85138b10437113ab2f0d72d[]

			getResponse.MatchesExample(@"GET twitter/_doc/2?routing=user1&stored_fields=tags,counter");
		}
	}
}
