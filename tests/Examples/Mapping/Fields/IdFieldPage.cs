// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Mapping.Fields
{
	public class IdFieldPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("mapping/fields/id-field.asciidoc:12")]
		public void Line12()
		{
			// tag::8d9a63d7c31f08bd27d92ece3de1649c[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();

			var response2 = new SearchResponse<object>();

			var response3 = new SearchResponse<object>();
			// end::8d9a63d7c31f08bd27d92ece3de1649c[]

			response0.MatchesExample(@"# Example documents");

			response1.MatchesExample(@"PUT my_index/_doc/1
			{
			  ""text"": ""Document with ID 1""
			}");

			response2.MatchesExample(@"PUT my_index/_doc/2?refresh=true
			{
			  ""text"": ""Document with ID 2""
			}");

			response3.MatchesExample(@"GET my_index/_search
			{
			  ""query"": {
			    ""terms"": {
			      ""_id"": [ ""1"", ""2"" ] <1>
			    }
			  }
			}");
		}
	}
}
