using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.MigrationApi
{
	///<summary>Request options for DeprecationInfo<pre>http://www.elastic.co/guide/en/migration/current/migration-api-deprecation.html</pre></summary>
	public class DeprecationInfoRequestParameters : RequestParameters<DeprecationInfoRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
	}

	///<summary>Request options for Assistance<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-assistance.html</pre></summary>
	public class MigrationAssistanceRequestParameters : RequestParameters<MigrationAssistanceRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		///<summary>
		/// Whether to ignore if a wildcard indices expression resolves into no concrete indices. (This includes `_all` string or when no indices have
		/// been specified)
		///</summary>
		public bool? AllowNoIndices
		{
			get => Q<bool? >("allow_no_indices");
			set => Q("allow_no_indices", value);
		}

		///<summary>Whether to expand wildcard expression to concrete indices that are open, closed or both.</summary>
		public ExpandWildcards? ExpandWildcards
		{
			get => Q<ExpandWildcards? >("expand_wildcards");
			set => Q("expand_wildcards", value);
		}

		///<summary>Whether specified concrete indices should be ignored when unavailable (missing or closed)</summary>
		public bool? IgnoreUnavailable
		{
			get => Q<bool? >("ignore_unavailable");
			set => Q("ignore_unavailable", value);
		}
	}

	///<summary>Request options for Upgrade<pre>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-upgrade.html</pre></summary>
	public class MigrationUpgradeRequestParameters : RequestParameters<MigrationUpgradeRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		///<summary>Should the request block until the upgrade operation is completed</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}
}