using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Mapping.Params
{
	public class NormalizerPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("mapping/params/normalizer.asciidoc:18")]
		public void Line18()
		{
			// tag::4cd40113e0fc90c37976f28d7e4a2327[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();

			var response2 = new SearchResponse<object>();

			var response3 = new SearchResponse<object>();

			var response4 = new SearchResponse<object>();

			var response5 = new SearchResponse<object>();

			var response6 = new SearchResponse<object>();
			// end::4cd40113e0fc90c37976f28d7e4a2327[]

			response0.MatchesExample(@"PUT index
			{
			  ""settings"": {
			    ""analysis"": {
			      ""normalizer"": {
			        ""my_normalizer"": {
			          ""type"": ""custom"",
			          ""char_filter"": [],
			          ""filter"": [""lowercase"", ""asciifolding""]
			        }
			      }
			    }
			  },
			  ""mappings"": {
			    ""properties"": {
			      ""foo"": {
			        ""type"": ""keyword"",
			        ""normalizer"": ""my_normalizer""
			      }
			    }
			  }
			}");

			response1.MatchesExample(@"PUT index/_doc/1
			{
			  ""foo"": ""BÀR""
			}");

			response2.MatchesExample(@"PUT index/_doc/2
			{
			  ""foo"": ""bar""
			}");

			response3.MatchesExample(@"PUT index/_doc/3
			{
			  ""foo"": ""baz""
			}");

			response4.MatchesExample(@"POST index/_refresh");

			response5.MatchesExample(@"GET index/_search
			{
			  ""query"": {
			    ""term"": {
			      ""foo"": ""BAR""
			    }
			  }
			}");

			response6.MatchesExample(@"GET index/_search
			{
			  ""query"": {
			    ""match"": {
			      ""foo"": ""BAR""
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("mapping/params/normalizer.asciidoc:125")]
		public void Line125()
		{
			// tag::6f842819c50e8490080dd085e0c6aca3[]
			var response0 = new SearchResponse<object>();
			// end::6f842819c50e8490080dd085e0c6aca3[]

			response0.MatchesExample(@"GET index/_search
			{
			  ""size"": 0,
			  ""aggs"": {
			    ""foo_terms"": {
			      ""terms"": {
			        ""field"": ""foo""
			      }
			    }
			  }
			}");
		}
	}
}