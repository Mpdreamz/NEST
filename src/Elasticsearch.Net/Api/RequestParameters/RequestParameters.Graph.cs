using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.GraphApi
{
	///<summary>Request options for Explore<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/graph-explore-api.html</pre></summary>
	public class GraphExploreRequestParameters : RequestParameters<GraphExploreRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Specific routing value</summary>
		public string Routing
		{
			get => Q<string>("routing");
			set => Q("routing", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}
}