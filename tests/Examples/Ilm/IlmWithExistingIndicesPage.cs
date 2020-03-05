using Elastic.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ilm
{
	public class IlmWithExistingIndicesPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:23")]
		public void Line23()
		{
			// tag::4e2027438393cf93b9c9402b8511eab5[]
			var response0 = new SearchResponse<object>();
			// end::4e2027438393cf93b9c9402b8511eab5[]

			response0.MatchesExample(@"PUT _template/mylogs_template
			{
			  ""index_patterns"": [
			    ""mylogs-*""
			  ],
			  ""settings"": {
			    ""number_of_shards"": 1,
			    ""number_of_replicas"": 1
			  },
			  ""mappings"": {
			    ""properties"": {
			      ""message"": {
			        ""type"": ""text""
			      },
			      ""@timestamp"": {
			        ""type"": ""date""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:49")]
		public void Line49()
		{
			// tag::8502a9281f5393a7160e4e46988da672[]
			var response0 = new SearchResponse<object>();
			// end::8502a9281f5393a7160e4e46988da672[]

			response0.MatchesExample(@"POST mylogs-pre-ilm-2019.06.24/_doc
			{
			  ""@timestamp"": ""2019-06-24T10:34:00"",
			  ""message"": ""this is one log message""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:59")]
		public void Line59()
		{
			// tag::7d51f0436e87dec4274133856866b07d[]
			var response0 = new SearchResponse<object>();
			// end::7d51f0436e87dec4274133856866b07d[]

			response0.MatchesExample(@"POST mylogs-pre-ilm-2019.06.25/_doc
			{
			  ""@timestamp"": ""2019-06-25T17:42:00"",
			  ""message"": ""this is another log message""
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:128")]
		public void Line128()
		{
			// tag::75097f73665235b20df09739c820ad35[]
			var response0 = new SearchResponse<object>();
			// end::75097f73665235b20df09739c820ad35[]

			response0.MatchesExample(@"PUT _ilm/policy/mylogs_policy
			{
			  ""policy"": {
			    ""phases"": {
			      ""hot"": {
			        ""actions"": {
			          ""rollover"": {
			            ""max_size"": ""25GB""
			          }
			        }
			      },
			      ""warm"": {
			        ""min_age"": ""1d"",
			        ""actions"": {
			          ""forcemerge"": {
			            ""max_num_segments"": 1
			          }
			        }
			      },
			      ""cold"": {
			        ""min_age"": ""7d"",
			        ""actions"": {
			          ""freeze"": {}
			        }
			      },
			      ""delete"": {
			        ""min_age"": ""30d"",
			        ""actions"": {
			          ""delete"": {}
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:171")]
		public void Line171()
		{
			// tag::3feab5c602192b8dc58435654b17d3fe[]
			var response0 = new SearchResponse<object>();
			// end::3feab5c602192b8dc58435654b17d3fe[]

			response0.MatchesExample(@"PUT _ilm/policy/mylogs_policy_existing
			{
			  ""policy"": {
			    ""phases"": {
			      ""warm"": {
			        ""min_age"": ""1d"",
			        ""actions"": {
			          ""forcemerge"": {
			            ""max_num_segments"": 1
			          }
			        }
			      },
			      ""cold"": {
			        ""min_age"": ""7d"",
			        ""actions"": {
			          ""freeze"": {}
			        }
			      },
			      ""delete"": {
			        ""min_age"": ""30d"",
			        ""actions"": {
			          ""delete"": {}
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:213")]
		public void Line213()
		{
			// tag::ec195297eb804cba1cb19c9926773059[]
			var response0 = new SearchResponse<object>();
			// end::ec195297eb804cba1cb19c9926773059[]

			response0.MatchesExample(@"PUT mylogs-pre-ilm*/_settings \<1>
			{
			  ""index"": {
			    ""lifecycle"": {
			      ""name"": ""mylogs_policy_existing""
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:255")]
		public void Line255()
		{
			// tag::8d39a0f0116702e981545d13371cd0eb[]
			var response0 = new SearchResponse<object>();
			// end::8d39a0f0116702e981545d13371cd0eb[]

			response0.MatchesExample(@"PUT _ilm/policy/mylogs_condensed_policy
			{
			  ""policy"": {
			    ""phases"": {
			      ""hot"": {
			        ""actions"": {
			          ""rollover"": {
			            ""max_age"": ""7d"",
			            ""max_size"": ""50G""
			          }
			        }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:278")]
		public void Line278()
		{
			// tag::bce0d86353e212cee466ccbc90bdc6e7[]
			var response0 = new SearchResponse<object>();
			// end::bce0d86353e212cee466ccbc90bdc6e7[]

			response0.MatchesExample(@"PUT _template/mylogs_template
			{
			  ""index_patterns"": [
			    ""ilm-mylogs-*"" \<1>
			  ],
			  ""settings"": {
			    ""number_of_shards"": 1,
			    ""number_of_replicas"": 1,
			    ""index"": {
			      ""lifecycle"": {
			        ""name"": ""mylogs_condensed_policy"", \<2>
			        ""rollover_alias"": ""mylogs"" \<3>
			      }
			    }
			  },
			  ""mappings"": {
			    ""properties"": {
			      ""message"": {
			        ""type"": ""text""
			      },
			      ""@timestamp"": {
			        ""type"": ""date""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:317")]
		public void Line317()
		{
			// tag::89115f8d40d9a13b0b01dc7c33ffd1cc[]
			var response0 = new SearchResponse<object>();
			// end::89115f8d40d9a13b0b01dc7c33ffd1cc[]

			response0.MatchesExample(@"PUT ilm-mylogs-000001
			{
			  ""aliases"": {
			    ""mylogs"": {
			      ""is_write_index"": true
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:356")]
		public void Line356()
		{
			// tag::5df1ed33b5fcf3b9d85c20d100780d43[]
			var response0 = new SearchResponse<object>();
			// end::5df1ed33b5fcf3b9d85c20d100780d43[]

			response0.MatchesExample(@"PUT _cluster/settings
			{
			  ""transient"": {
			    ""indices.lifecycle.poll_interval"": ""1m"" \<1>
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:387")]
		public void Line387()
		{
			// tag::41f211cc838f1bee7eac264784f905e2[]
			var response0 = new SearchResponse<object>();
			// end::41f211cc838f1bee7eac264784f905e2[]

			response0.MatchesExample(@"POST _reindex
			{
			  ""source"": {
			    ""index"": ""mylogs-*"", \<1>
			    ""sort"": { ""@timestamp"": ""desc"" }
			  },
			  ""dest"": {
			    ""index"": ""mylogs"", \<2>
			    ""op_type"": ""create"" \<3>
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("ilm/ilm-with-existing-indices.asciidoc:417")]
		public void Line417()
		{
			// tag::227e19aecb349f31e74898384322ae01[]
			var response0 = new SearchResponse<object>();

			var response1 = new SearchResponse<object>();
			// end::227e19aecb349f31e74898384322ae01[]

			response0.MatchesExample(@"PUT _cluster/settings
			{
			  ""transient"": {
			    ""indices.lifecycle.poll_interval"": null
			  }
			}");

			response1.MatchesExample(@"");
		}
	}
}