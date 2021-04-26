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
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;
using Elasticsearch.Net.Specification.RollupApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	///<summary>Descriptor for DeleteJob <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-delete-job.html</para></summary>
	public partial class DeleteRollupJobDescriptor : RequestDescriptorBase<DeleteRollupJobDescriptor, DeleteRollupJobRequestParameters, IDeleteRollupJobRequest>, IDeleteRollupJobRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupDeleteJob;
		///<summary>/_rollup/job/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public DeleteRollupJobDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteRollupJobDescriptor(): base()
		{
		}

		// values part of the url path
		Id IDeleteRollupJobRequest.Id => Self.RouteValues.Get<Id>("id");
	// Request parameters
	}

	///<summary>Descriptor for GetJob <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-job.html</para></summary>
	public partial class GetRollupJobDescriptor : RequestDescriptorBase<GetRollupJobDescriptor, GetRollupJobRequestParameters, IGetRollupJobRequest>, IGetRollupJobRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupGetJob;
		///<summary>/_rollup/job/{id}</summary>
		///<param name = "id">Optional, accepts null</param>
		public GetRollupJobDescriptor(Id id): base(r => r.Optional("id", id))
		{
		}

		///<summary>/_rollup/job/</summary>
		public GetRollupJobDescriptor(): base()
		{
		}

		// values part of the url path
		Id IGetRollupJobRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The ID of the job(s) to fetch. Accepts glob patterns, or left blank for all jobs</summary>
		public GetRollupJobDescriptor Id(Id id) => Assign(id, (a, v) => a.RouteValues.Optional("id", v));
	// Request parameters
	}

	///<summary>Descriptor for GetCapabilities <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-caps.html</para></summary>
	public partial class GetRollupCapabilitiesDescriptor : RequestDescriptorBase<GetRollupCapabilitiesDescriptor, GetRollupCapabilitiesRequestParameters, IGetRollupCapabilitiesRequest>, IGetRollupCapabilitiesRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupGetCapabilities;
		///<summary>/_rollup/data/{id}</summary>
		///<param name = "id">Optional, accepts null</param>
		public GetRollupCapabilitiesDescriptor(Id id): base(r => r.Optional("id", id))
		{
		}

		///<summary>/_rollup/data/</summary>
		public GetRollupCapabilitiesDescriptor(): base()
		{
		}

		// values part of the url path
		Id IGetRollupCapabilitiesRequest.Id => Self.RouteValues.Get<Id>("id");
		///<summary>The ID of the index to check rollup capabilities on, or left blank for all jobs</summary>
		public GetRollupCapabilitiesDescriptor Id(Id id) => Assign(id, (a, v) => a.RouteValues.Optional("id", v));
	// Request parameters
	}

	///<summary>Descriptor for GetIndexCapabilities <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-get-rollup-index-caps.html</para></summary>
	public partial class GetRollupIndexCapabilitiesDescriptor : RequestDescriptorBase<GetRollupIndexCapabilitiesDescriptor, GetRollupIndexCapabilitiesRequestParameters, IGetRollupIndexCapabilitiesRequest>, IGetRollupIndexCapabilitiesRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupGetIndexCapabilities;
		///<summary>/{index}/_rollup/data</summary>
		///<param name = "index">this parameter is required</param>
		public GetRollupIndexCapabilitiesDescriptor(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected GetRollupIndexCapabilitiesDescriptor(): base()
		{
		}

		// values part of the url path
		IndexName IGetRollupIndexCapabilitiesRequest.Index => Self.RouteValues.Get<IndexName>("index");
		///<summary>The rollup index or index pattern to obtain rollup capabilities from.</summary>
		public GetRollupIndexCapabilitiesDescriptor Index(IndexName index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public GetRollupIndexCapabilitiesDescriptor Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (IndexName)v));
	// Request parameters
	}

	///<summary>Descriptor for CreateJob <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-put-job.html</para></summary>
	public partial class CreateRollupJobDescriptor<TDocument> : RequestDescriptorBase<CreateRollupJobDescriptor<TDocument>, CreateRollupJobRequestParameters, ICreateRollupJobRequest>, ICreateRollupJobRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupCreateJob;
		///<summary>/_rollup/job/{id}</summary>
		///<param name = "id">this parameter is required</param>
		public CreateRollupJobDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CreateRollupJobDescriptor(): base()
		{
		}

		// values part of the url path
		Id ICreateRollupJobRequest.Id => Self.RouteValues.Get<Id>("id");
	// Request parameters
	}

	///<summary>Descriptor for Search <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-search.html</para></summary>
	public partial class RollupSearchDescriptor<TDocument> : RequestDescriptorBase<RollupSearchDescriptor<TDocument>, RollupSearchRequestParameters, IRollupSearchRequest>, IRollupSearchRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupSearch;
		///<summary>/{index}/_rollup_search</summary>
		///<param name = "index">this parameter is required</param>
		public RollupSearchDescriptor(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>/{index}/_rollup_search</summary>
		public RollupSearchDescriptor(): this(typeof(TDocument))
		{
		}

		// values part of the url path
		Indices IRollupSearchRequest.Index => Self.RouteValues.Get<Indices>("index");
		///<summary>The indices or index-pattern(s) (containing rollup or regular data) that should be searched</summary>
		public RollupSearchDescriptor<TDocument> Index(Indices index) => Assign(index, (a, v) => a.RouteValues.Required("index", v));
		///<summary>a shortcut into calling Index(typeof(TOther))</summary>
		public RollupSearchDescriptor<TDocument> Index<TOther>()
			where TOther : class => Assign(typeof(TOther), (a, v) => a.RouteValues.Required("index", (Indices)v));
		///<summary>A shortcut into calling Index(Indices.All)</summary>
		public RollupSearchDescriptor<TDocument> AllIndices() => Index(Indices.All);
		// Request parameters
		///<summary>Indicates whether hits.total should be rendered as an integer or an object in the rest search response</summary>
		public RollupSearchDescriptor<TDocument> TotalHitsAsInteger(bool? totalhitsasinteger = true) => Qs("rest_total_hits_as_int", totalhitsasinteger);
		///<summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response</summary>
		public RollupSearchDescriptor<TDocument> TypedKeys(bool? typedkeys = true) => Qs("typed_keys", typedkeys);
	}

	///<summary>Descriptor for StartJob <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-start-job.html</para></summary>
	public partial class StartRollupJobDescriptor : RequestDescriptorBase<StartRollupJobDescriptor, StartRollupJobRequestParameters, IStartRollupJobRequest>, IStartRollupJobRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupStartJob;
		///<summary>/_rollup/job/{id}/_start</summary>
		///<param name = "id">this parameter is required</param>
		public StartRollupJobDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected StartRollupJobDescriptor(): base()
		{
		}

		// values part of the url path
		Id IStartRollupJobRequest.Id => Self.RouteValues.Get<Id>("id");
	// Request parameters
	}

	///<summary>Descriptor for StopJob <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/rollup-stop-job.html</para></summary>
	public partial class StopRollupJobDescriptor : RequestDescriptorBase<StopRollupJobDescriptor, StopRollupJobRequestParameters, IStopRollupJobRequest>, IStopRollupJobRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.RollupStopJob;
		///<summary>/_rollup/job/{id}/_stop</summary>
		///<param name = "id">this parameter is required</param>
		public StopRollupJobDescriptor(Id id): base(r => r.Required("id", id))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected StopRollupJobDescriptor(): base()
		{
		}

		// values part of the url path
		Id IStopRollupJobRequest.Id => Self.RouteValues.Get<Id>("id");
		// Request parameters
		///<summary>Block for (at maximum) the specified duration while waiting for the job to stop.  Defaults to 30s.</summary>
		public StopRollupJobDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
		///<summary>True if the API should block until the job has fully stopped, false if should be executed async. Defaults to false.</summary>
		public StopRollupJobDescriptor WaitForCompletion(bool? waitforcompletion = true) => Qs("wait_for_completion", waitforcompletion);
	}
}