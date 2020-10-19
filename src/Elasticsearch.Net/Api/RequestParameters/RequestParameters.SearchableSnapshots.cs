// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elastic.Transport;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.SearchableSnapshotsApi
{
	///<summary>Request options for ClearCache <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
	public class ClearCacheRequestParameters : RequestParameters<ClearCacheRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		public override bool SupportsBody => false;
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

		///<summary>A comma-separated list of index name to limit the operation</summary>
		public string[] IndexQueryString
		{
			get => Q<string[]>("index");
			set => Q("index", value);
		}
	}

	///<summary>Request options for Mount <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-api-mount-snapshot.html</para></summary>
	public class MountRequestParameters : RequestParameters<MountRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		public override bool SupportsBody => true;
		///<summary>Explicit operation timeout for connection to master node</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Should this request wait until the operation has completed before returning</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for Stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/searchable-snapshots-apis.html</para></summary>
	public class StatsRequestParameters : RequestParameters<StatsRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
	}
}