using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Transform.Apis
{
	public class PutTransformPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line143()
		{
			// tag::23994a14e6b0681cd279b427324945db[]
			var response0 = new SearchResponse<object>();
			// end::23994a14e6b0681cd279b427324945db[]

			response0.MatchesExample(@"PUT _transform/ecommerce_transform
			{
			  ""source"": {
			    ""index"": ""kibana_sample_data_ecommerce"",
			    ""query"": {
			      ""term"": {
			        ""geoip.continent_name"": {
			          ""value"": ""Asia""
			        }
			      }
			    }
			  },
			  ""pivot"": {
			    ""group_by"": {
			      ""customer_id"": {
			        ""terms"": {
			          ""field"": ""customer_id""
			        }
			      }
			    },
			    ""aggregations"": {
			      ""max_price"": {
			        ""max"": {
			          ""field"": ""taxful_total_price""
			        }
			      }
			    }
			  },
			  ""description"": ""Maximum priced ecommerce data by customer_id in Asia"",
			  ""dest"": {
			    ""index"": ""kibana_sample_data_ecommerce_transform"",
			    ""pipeline"": ""add_timestamp_pipeline""
			  },
			  ""frequency"": ""5m"",
			  ""sync"": {
			    ""time"": {
			      ""field"": ""order_date"",
			      ""delay"": ""60s""
			    }
			  }
			}");
		}
	}
}