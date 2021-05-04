// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information
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
namespace Elasticsearch.Net.Specification.EnrichApi
{
	///<summary>Request options for DeletePolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-enrich-policy-api.html</para></summary>
	public class DeleteEnrichPolicyRequestParameters : RequestParameters<DeleteEnrichPolicyRequestParameters>
	{
	}

	///<summary>Request options for ExecutePolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/execute-enrich-policy-api.html</para></summary>
	public class ExecuteEnrichPolicyRequestParameters : RequestParameters<ExecuteEnrichPolicyRequestParameters>
	{
		///<summary>Should the request should block until the execution is complete.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for GetPolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/enrich-get-policy.html</para></summary>
	public class GetEnrichPolicyRequestParameters : RequestParameters<GetEnrichPolicyRequestParameters>
	{
	}

	///<summary>Request options for PutPolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/put-enrich-policy-api.html</para></summary>
	public class PutEnrichPolicyRequestParameters : RequestParameters<PutEnrichPolicyRequestParameters>
	{
	}

	///<summary>Request options for Stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/enrich-stats-api.html</para></summary>
	public class EnrichStatsRequestParameters : RequestParameters<EnrichStatsRequestParameters>
	{
	}
}