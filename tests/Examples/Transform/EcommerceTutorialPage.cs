using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.Transform
{
	public class EcommerceTutorialPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line88()
		{
			// tag::8345d2615f43a934fe1871a5120eca1d[]
			var response0 = new SearchResponse<object>();
			// end::8345d2615f43a934fe1871a5120eca1d[]

			response0.MatchesExample(@"POST _transform/_preview
			{
			  ""source"": {
			    ""index"": ""kibana_sample_data_ecommerce"",
			    ""query"": {
			      ""bool"": {
			        ""filter"": {
			          ""term"": {""currency"": ""EUR""}
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
			      ""total_quantity.sum"": {
			        ""sum"": {
			          ""field"": ""total_quantity""
			        }
			      },
			      ""taxless_total_price.sum"": {
			        ""sum"": {
			          ""field"": ""taxless_total_price""
			        }
			      },
			      ""total_quantity.max"": {
			        ""max"": {
			          ""field"": ""total_quantity""
			        }
			      },
			      ""order_id.cardinality"": {
			        ""cardinality"": {
			          ""field"": ""order_id""
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line164()
		{
			// tag::c68404749f090ab191c0fd5f651635cf[]
			var response0 = new SearchResponse<object>();
			// end::c68404749f090ab191c0fd5f651635cf[]

			response0.MatchesExample(@"PUT _transform/ecommerce-customer-transform
			{
			  ""source"": {
			    ""index"": [
			      ""kibana_sample_data_ecommerce""
			    ],
			    ""query"": {
			      ""bool"": {
			        ""filter"": {
			          ""term"": {
			            ""currency"": ""EUR""
			          }
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
			      ""total_quantity.sum"": {
			        ""sum"": {
			          ""field"": ""total_quantity""
			        }
			      },
			      ""taxless_total_price.sum"": {
			        ""sum"": {
			          ""field"": ""taxless_total_price""
			        }
			      },
			      ""total_quantity.max"": {
			        ""max"": {
			          ""field"": ""total_quantity""
			        }
			      },
			      ""order_id.cardinality"": {
			        ""cardinality"": {
			          ""field"": ""order_id""
			        }
			      }
			    }
			  },
			  ""dest"": {
			    ""index"": ""ecommerce-customers""
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line243()
		{
			// tag::4ded8ad815ac0e83b1c21a6c18fd0763[]
			var response0 = new SearchResponse<object>();
			// end::4ded8ad815ac0e83b1c21a6c18fd0763[]

			response0.MatchesExample(@"POST _transform/ecommerce-customer-transform/_start");
		}
	}
}