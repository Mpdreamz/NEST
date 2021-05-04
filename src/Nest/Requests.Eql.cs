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
using Elastic.Transport;
using Elasticsearch.Net;
using Nest.Utf8Json;
using Elasticsearch.Net.Specification.EqlApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	[InterfaceDataContract]
	public partial interface IEqlSearchRequest : IRequest<EqlSearchRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	public partial interface IEqlSearchRequest<TInferDocument> : IEqlSearchRequest
	{
	}

	///<summary>Request for Search <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/eql-search-api.html</para></summary>
	public partial class EqlSearchRequest : PlainRequestBase<EqlSearchRequestParameters>, IEqlSearchRequest
	{
		protected IEqlSearchRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.EqlSearch;
		protected override HttpMethod HttpMethod => HttpMethod.POST;
		protected override bool SupportsBody => true;
		///<summary>/{index}/_eql/search</summary>
		///<param name = "index">this parameter is required</param>
		public EqlSearchRequest(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected EqlSearchRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices IEqlSearchRequest.Index => Self.RouteValues.Get<Indices>("index");
		// Request parameters
		///<summary>Update the time interval in which the results (partial or final) for this search will be available</summary>
		public Time KeepAlive
		{
			get => Q<Time>("keep_alive");
			set => Q("keep_alive", value);
		}

		///<summary>
		/// Control whether the response should be stored in the cluster if it completed within the provided [wait_for_completion] time (default:
		/// false)
		///</summary>
		public bool? KeepOnCompletion
		{
			get => Q<bool? >("keep_on_completion");
			set => Q("keep_on_completion", value);
		}

		///<summary>Specify the time that the request should block waiting for the final response</summary>
		public Time WaitForCompletionTimeout
		{
			get => Q<Time>("wait_for_completion_timeout");
			set => Q("wait_for_completion_timeout", value);
		}
	}

	public partial class EqlSearchRequest<TInferDocument> : EqlSearchRequest, IEqlSearchRequest<TInferDocument>
	{
		protected IEqlSearchRequest<TInferDocument> TypedSelf => this;
		///<summary>/{index}/_eql/search</summary>
		///<param name = "index">this parameter is required</param>
		public EqlSearchRequest(Indices index): base(index)
		{
		}

		///<summary>/{index}/_eql/search</summary>
		public EqlSearchRequest(): base(typeof(TInferDocument))
		{
		}
	}
}