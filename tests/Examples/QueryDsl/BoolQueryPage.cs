using Elastic.Xunit.XunitPlumbing;
using Examples.Models;
using FluentAssertions;
using Nest;
using Newtonsoft.Json.Linq;

namespace Examples.QueryDsl
{
	public class BoolQueryPage : ExampleBase
	{
		[U]
		public void Line36()
		{
			// tag::06afce2955f9094d96d27067ebca32e8[]
			var searchResponse = client.Search<Account>(s => s
				.AllIndices()
				.Query(q => q
					.Bool(b => b
						.Must(m => m.Term(p => p.User, "kimchy"))
						.Filter(f => f.Term(p => p.Tags, "tech"))
						.MustNot(m => m
							.Range(r => r
								.Field(p => p.Age)
								.GreaterThanOrEquals(10)
								.LessThanOrEquals(20)
							)
						)
						.Should(
							sh => sh.Term(p => p.Tags, "wow"),
							sh => sh.Term(p => p.Tags, "elasticsearch")
						)
						.MinimumShouldMatch(1)
						.Boost(1.0)
					)
				)
			);
			// end::06afce2955f9094d96d27067ebca32e8[]

			searchResponse.MatchesExample(@"POST _search
			{
			  ""query"": {
			    ""bool"" : {
			      ""must"" : {
			        ""term"" : { ""user"" : ""kimchy"" }
			      },
			      ""filter"": {
			        ""term"" : { ""tag"" : ""tech"" }
			      },
			      ""must_not"" : {
			        ""range"" : {
			          ""age"" : { ""gte"" : 10, ""lte"" : 20 }
			        }
			      },
			      ""should"" : [
			        { ""term"" : { ""tag"" : ""wow"" } },
			        { ""term"" : { ""tag"" : ""elasticsearch"" } }
			      ],
			      ""minimum_should_match"" : 1,
			      ""boost"" : 1.0
			    }
			  }
			}", e =>
			{
				e.ApplyBodyChanges(b =>
				{
					var must = b["query"]["bool"]["must"].ToJArray();
					var filter = b["query"]["bool"]["filter"].ToJArray();
					var mustNot = b["query"]["bool"]["must_not"].ToJArray();
					var should = b["query"]["bool"]["should"];
					must[0]["term"]["user"].ToLongFormTermQuery();
					filter[0]["term"]["tag"].ToLongFormTermQuery();
					should[0]["term"]["tag"].ToLongFormTermQuery();
					should[1]["term"]["tag"].ToLongFormTermQuery();

					//NEST sends double
					var ageQuery = mustNot[0]["range"]["age"];
					ageQuery["gte"] = 10.0;
					ageQuery["lte"] = 20.0;
				});
				return e;
			});
		}

		[U]
		public void Line88()
		{
			// tag::f70a54cd9a9f4811bf962e469f2ca2ea[]
			var searchResponse = client.Search<Blog>(s => s
				.AllIndices()
				.Query(q => +q.Term(p => p.Status, PublishStatus.Active))
			);
			// end::f70a54cd9a9f4811bf962e469f2ca2ea[]

			searchResponse.MatchesExample(@"GET _search
			{
			  ""query"": {
			    ""bool"": {
			      ""filter"": {
			        ""term"": {
			          ""status"": ""active""
			        }
			      }
			    }
			  }
			}", e =>
			{
				e.ApplyBodyChanges(b =>
				{
					var filter = b["query"]["bool"]["filter"].ToJArray();
					filter[0]["term"]["status"].ToLongFormTermQuery();
				});
				return e;
			});
		}

		[U]
		public void Line107()
		{
			// tag::fa88f6f5a7d728ec4f1d05244228cb09[]
			var searchResponse = client.Search<Blog>(s => s
				.AllIndices()
				.Query(q =>
					+q.Term(p => p.Status, PublishStatus.Active)
					&& q.MatchAll()
				)
			);
			// end::fa88f6f5a7d728ec4f1d05244228cb09[]

			searchResponse.MatchesExample(@"GET _search
			{
			  ""query"": {
			    ""bool"": {
			      ""must"": {
			        ""match_all"": {}
			      },
			      ""filter"": {
			        ""term"": {
			          ""status"": ""active""
			        }
			      }
			    }
			  }
			}", (e, body) =>
			{
				body["query"]["bool"].ToLongFormBoolQuery(b =>
				{
					b["filter"][0]["term"]["status"].ToLongFormTermQuery();
				});
			});
		}

		[U]
		public void Line130()
		{
			// tag::162b5b693b713f0bfab1209d59443c46[]
			var searchResponse = client.Search<Blog>(s => s
				.AllIndices()
				.Query(q =>
					q.ConstantScore(cs => cs
						.Filter(f => f
							.Term(p => p.Status, PublishStatus.Active)
						)
					)
				)
			);
			// end::162b5b693b713f0bfab1209d59443c46[]

			searchResponse.MatchesExample(@"GET _search
			{
			  ""query"": {
			    ""constant_score"": {
			      ""filter"": {
			        ""term"": {
			          ""status"": ""active""
			        }
			      }
			    }
			  }
			}", (c, b) => b["query"]["constant_score"]["filter"]["term"]["status"].ToLongFormTermQuery());
		}
	}
}
