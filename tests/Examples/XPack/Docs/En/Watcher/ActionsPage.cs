using Elastic.Xunit.XunitPlumbing;
using Nest;

namespace Examples.XPack.Docs.En.Watcher
{
	public class ActionsPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		public void Line49()
		{
			// tag::85d2e33791f1a74a69dfb04a60e69306[]
			var response0 = new SearchResponse<object>();
			// end::85d2e33791f1a74a69dfb04a60e69306[]

			response0.MatchesExample(@"PUT _watcher/watch/error_logs_alert
			{
			  ""metadata"" : {
			    ""color"" : ""red""
			  },
			  ""trigger"" : {
			    ""schedule"" : {
			      ""interval"" : ""5m""
			    }
			  },
			  ""input"" : {
			    ""search"" : {
			      ""request"" : {
			        ""indices"" : ""log-events"",
			        ""body"" : {
			          ""size"" : 0,
			          ""query"" : { ""match"" : { ""status"" : ""error"" } }
			        }
			      }
			    }
			  },
			  ""condition"" : {
			    ""compare"" : { ""ctx.payload.hits.total"" : { ""gt"" : 5 }}
			  },
			  ""actions"" : {
			    ""email_administrator"" : {
			      ""throttle_period"": ""15m"", <1>
			      ""email"" : { <2>
			        ""to"" : ""sys.admino@host.domain"",
			        ""subject"" : ""Encountered {{ctx.payload.hits.total}} errors"",
			        ""body"" : ""Too many error in the system, see attached data"",
			        ""attachments"" : {
			          ""attached_data"" : {
			            ""data"" : {
			              ""format"" : ""json""
			            }
			          }
			        },
			        ""priority"" : ""high""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line104()
		{
			// tag::406a0f1c1aac947bcee58f86b6d036c1[]
			var response0 = new SearchResponse<object>();
			// end::406a0f1c1aac947bcee58f86b6d036c1[]

			response0.MatchesExample(@"PUT _watcher/watch/log_event_watch
			{
			  ""trigger"" : {
			    ""schedule"" : { ""interval"" : ""5m"" }
			  },
			  ""input"" : {
			    ""search"" : {
			      ""request"" : {
			        ""indices"" : ""log-events"",
			        ""body"" : {
			          ""size"" : 0,
			          ""query"" : { ""match"" : { ""status"" : ""error"" } }
			        }
			      }
			    }
			  },
			  ""condition"" : {
			    ""compare"" : { ""ctx.payload.hits.total"" : { ""gt"" : 5 }}
			  },
			  ""throttle_period"" : ""15m"", <1>
			  ""actions"" : {
			    ""email_administrator"" : {
			      ""email"" : {
			        ""to"" : ""sys.admino@host.domain"",
			        ""subject"" : ""Encountered {{ctx.payload.hits.total}} errors"",
			        ""body"" : ""Too many error in the system, see attached data"",
			        ""attachments"" : {
			          ""attached_data"" : {
			            ""data"" : {
			              ""format"" : ""json""
			            }
			          }
			        },
			        ""priority"" : ""high""
			      }
			    },
			    ""notify_pager"" : {
			      ""webhook"" : {
			        ""method"" : ""POST"",
			        ""host"" : ""pager.service.domain"",
			        ""port"" : 1234,
			        ""path"" : ""/{{watch_id}}"",
			        ""body"" : ""Encountered {{ctx.payload.hits.total}} errors""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line178()
		{
			// tag::3d48d1ba49f680aac32177d653944623[]
			var response0 = new SearchResponse<object>();
			// end::3d48d1ba49f680aac32177d653944623[]

			response0.MatchesExample(@"POST _watcher/watch/<id>/_ack/<action_ids>");
		}

		[U(Skip = "Example not implemented")]
		public void Line205()
		{
			// tag::9eef31d85ebaf6c27054d7375715dbe0[]
			var response0 = new SearchResponse<object>();
			// end::9eef31d85ebaf6c27054d7375715dbe0[]

			response0.MatchesExample(@"PUT _watcher/watch/log_event_watch
			{
			  ""trigger"" : {
			    ""schedule"" : { ""interval"" : ""5m"" }
			  },
			  ""input"" : {
			    ""search"" : {
			      ""request"" : {
			        ""indices"" : ""log-events"",
			        ""body"" : {
			          ""query"" : { ""match"" : { ""status"" : ""error"" } }
			        }
			      }
			    }
			  },
			  ""condition"" : {
			    ""compare"" : { ""ctx.payload.hits.total"" : { ""gt"" : 0 } }
			  },
			  ""actions"" : {
			    ""log_hits"" : {
			      ""foreach"" : ""ctx.payload.hits.hits"", <1>
			      ""max_iterations"" : 500,
			      ""logging"" : {
			        ""text"" : ""Found id {{ctx.payload._id}} with field {{ctx.payload._source.my_field}}""
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		public void Line250()
		{
			// tag::f67d8aab9106ad24b1d2c771d3840ed1[]
			var response0 = new SearchResponse<object>();
			// end::f67d8aab9106ad24b1d2c771d3840ed1[]

			response0.MatchesExample(@"PUT _watcher/watch/log_event_watch
			{
			  ""trigger"" : {
			    ""schedule"" : { ""interval"" : ""5m"" }
			  },
			  ""input"" : {
			    ""search"" : {
			      ""request"" : {
			        ""indices"" : ""log-events"",
			        ""body"" : {
			          ""size"" : 0,
			          ""query"" : { ""match"" : { ""status"" : ""error"" } }
			        }
			      }
			    }
			  },
			  ""condition"" : {
			    ""compare"" : { ""ctx.payload.hits.total"" : { ""gt"" : 0 } }
			  },
			  ""actions"" : {
			    ""email_administrator"" : {
			      ""email"" : {
			        ""to"" : ""sys.admino@host.domain"",
			        ""subject"" : ""Encountered {{ctx.payload.hits.total}} errors"",
			        ""body"" : ""Too many error in the system, see attached data"",
			        ""attachments"" : {
			          ""attached_data"" : {
			            ""data"" : {
			              ""format"" : ""json""
			            }
			          }
			        },
			        ""priority"" : ""high""
			      }
			    },
			    ""notify_pager"" : {
			      ""condition"": { <1>
			        ""compare"" : { ""ctx.payload.hits.total"" : { ""gt"" : 5 } }
			      },
			      ""webhook"" : {
			        ""method"" : ""POST"",
			        ""host"" : ""pager.service.domain"",
			        ""port"" : 1234,
			        ""path"" : ""/{{watch_id}}"",
			        ""body"" : ""Encountered {{ctx.payload.hits.total}} errors""
			      }
			    }
			  }
			}");
		}
	}
}