/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

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
using System.Runtime.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;
using Elasticsearch.Net.Specification.EnrichApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	[InterfaceDataContract]
	public partial interface IDeleteEnrichPolicyRequest : IRequest<DeleteEnrichPolicyRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for DeletePolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-enrich-policy-api.html</para></summary>
	public partial class DeleteEnrichPolicyRequest : PlainRequestBase<DeleteEnrichPolicyRequestParameters>, IDeleteEnrichPolicyRequest
	{
		protected IDeleteEnrichPolicyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EnrichDeletePolicy;
		///<summary>/_enrich/policy/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public DeleteEnrichPolicyRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteEnrichPolicyRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeleteEnrichPolicyRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IExecuteEnrichPolicyRequest : IRequest<ExecuteEnrichPolicyRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for ExecutePolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/execute-enrich-policy-api.html</para></summary>
	public partial class ExecuteEnrichPolicyRequest : PlainRequestBase<ExecuteEnrichPolicyRequestParameters>, IExecuteEnrichPolicyRequest
	{
		protected IExecuteEnrichPolicyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EnrichExecutePolicy;
		///<summary>/_enrich/policy/{name}/_execute</summary>
		///<param name = "name">this parameter is required</param>
		public ExecuteEnrichPolicyRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ExecuteEnrichPolicyRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IExecuteEnrichPolicyRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>Should the request should block until the execution is complete.</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IGetEnrichPolicyRequest : IRequest<GetEnrichPolicyRequestParameters>
	{
		[IgnoreDataMember]
		Names Name
		{
			get;
		}
	}

	///<summary>Request for GetPolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/enrich-get-policy.html</para></summary>
	public partial class GetEnrichPolicyRequest : PlainRequestBase<GetEnrichPolicyRequestParameters>, IGetEnrichPolicyRequest
	{
		protected IGetEnrichPolicyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EnrichGetPolicy;
		///<summary>/_enrich/policy/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public GetEnrichPolicyRequest(Names name): base(r => r.Optional("name", name))
		{
		}

		///<summary>/_enrich/policy/</summary>
		public GetEnrichPolicyRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IGetEnrichPolicyRequest.Name => Self.RouteValues.Get<Names>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IPutEnrichPolicyRequest : IRequest<PutEnrichPolicyRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for PutPolicy <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/put-enrich-policy-api.html</para></summary>
	public partial class PutEnrichPolicyRequest : PlainRequestBase<PutEnrichPolicyRequestParameters>, IPutEnrichPolicyRequest
	{
		protected IPutEnrichPolicyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EnrichPutPolicy;
		///<summary>/_enrich/policy/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public PutEnrichPolicyRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutEnrichPolicyRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IPutEnrichPolicyRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IEnrichStatsRequest : IRequest<EnrichStatsRequestParameters>
	{
	}

	///<summary>Request for Stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/enrich-stats-api.html</para></summary>
	public partial class EnrichStatsRequest : PlainRequestBase<EnrichStatsRequestParameters>, IEnrichStatsRequest
	{
		protected IEnrichStatsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EnrichStats;
	// values part of the url path
	// Request parameters
	}
}