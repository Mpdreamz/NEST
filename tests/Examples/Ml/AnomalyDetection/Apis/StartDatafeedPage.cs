// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Ml.AnomalyDetection.Apis
{
	public class StartDatafeedPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("ml/anomaly-detection/apis/start-datafeed.asciidoc:99")]
		public void Line99()
		{
			// tag::d7ae456f119246e95f2f4c37e7544b8c[]
			var response0 = new SearchResponse<object>();
			// end::d7ae456f119246e95f2f4c37e7544b8c[]

			response0.MatchesExample(@"POST _ml/datafeeds/datafeed-low_request_rate/_start
			{
			  ""start"": ""2019-04-07T18:22:16Z""
			}");
		}
	}
}
