using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.XPackApi
{
	///<summary>Request options for Info<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/info-api.html</pre></summary>
	public class XPackInfoRequestParameters : RequestParameters<XPackInfoRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Comma-separated list of info categories. Can be any of: build, license, features</summary>
		public string[] Categories
		{
			get => Q<string[]>("categories");
			set => Q("categories", value);
		}
	}

	///<summary>Request options for Usage<pre>Retrieve information about xpack features usage</pre></summary>
	public class XPackUsageRequestParameters : RequestParameters<XPackUsageRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>Specify timeout for watch write operation</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}
	}
}