using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ingest.Apis
{
	public class SimulatePipelinePage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ingest/apis/simulate-pipeline.asciidoc:31")]
		public void Line31()
		{
			// tag::67ffa135c50c43d6788636c88078c7d1[]
			var response0 = new SearchResponse<object>();
			// end::67ffa135c50c43d6788636c88078c7d1[]

			response0.MatchesExample(@"POST /_ingest/pipeline/my-pipeline-id/_simulate
			{
			  ""docs"": [
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""bar""
			      }
			    },
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""rab""
			      }
			    }
			  ]
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ingest/apis/simulate-pipeline.asciidoc:212")]
		public void Line212()
		{
			// tag::17c2b0a6b0305804ff3b7fd3b4a68df3[]
			var response0 = new SearchResponse<object>();
			// end::17c2b0a6b0305804ff3b7fd3b4a68df3[]

			response0.MatchesExample(@"POST /_ingest/pipeline/_simulate
			{
			  ""pipeline"" :
			  {
			    ""description"": ""_description"",
			    ""processors"": [
			      {
			        ""set"" : {
			          ""field"" : ""field2"",
			          ""value"" : ""_value""
			        }
			      }
			    ]
			  },
			  ""docs"": [
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""bar""
			      }
			    },
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""rab""
			      }
			    }
			  ]
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ingest/apis/simulate-pipeline.asciidoc:296")]
		public void Line296()
		{
			// tag::463de55bb164cde9ac51acd4a7384901[]
			var response0 = new SearchResponse<object>();
			// end::463de55bb164cde9ac51acd4a7384901[]

			response0.MatchesExample(@"POST /_ingest/pipeline/_simulate?verbose
			{
			  ""pipeline"" :
			  {
			    ""description"": ""_description"",
			    ""processors"": [
			      {
			        ""set"" : {
			          ""field"" : ""field2"",
			          ""value"" : ""_value2""
			        }
			      },
			      {
			        ""set"" : {
			          ""field"" : ""field3"",
			          ""value"" : ""_value3""
			        }
			      }
			    ]
			  },
			  ""docs"": [
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""bar""
			      }
			    },
			    {
			      ""_index"": ""index"",
			      ""_id"": ""id"",
			      ""_source"": {
			        ""foo"": ""rab""
			      }
			    }
			  ]
			}");
		}
	}
}