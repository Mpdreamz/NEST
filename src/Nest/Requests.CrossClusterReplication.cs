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
using Elastic.Transport.Utf8Json;
using Elasticsearch.Net;
using Elasticsearch.Net.Specification.CrossClusterReplicationApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	[InterfaceDataContract]
	public partial interface IDeleteAutoFollowPatternRequest : IRequest<DeleteAutoFollowPatternRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for DeleteAutoFollowPattern <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-delete-auto-follow-pattern.html</para></summary>
	public partial class DeleteAutoFollowPatternRequest : PlainRequestBase<DeleteAutoFollowPatternRequestParameters>, IDeleteAutoFollowPatternRequest
	{
		protected IDeleteAutoFollowPatternRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationDeleteAutoFollowPattern;
		///<summary>/_ccr/auto_follow/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public DeleteAutoFollowPatternRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteAutoFollowPatternRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeleteAutoFollowPatternRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface ICreateFollowIndexRequest : IRequest<CreateFollowIndexRequestParameters>
	{
		[IgnoreDataMember]
		IndexName Index
		{
			get;
		}
	}

	///<summary>Request for CreateFollowIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-put-follow.html</para></summary>
	public partial class CreateFollowIndexRequest : PlainRequestBase<CreateFollowIndexRequestParameters>, ICreateFollowIndexRequest
	{
		protected ICreateFollowIndexRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationCreateFollowIndex;
		///<summary>/{index}/_ccr/follow</summary>
		///<param name = "index">this parameter is required</param>
		public CreateFollowIndexRequest(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CreateFollowIndexRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		IndexName ICreateFollowIndexRequest.Index => Self.RouteValues.Get<IndexName>("index");
		// Request parameters
		///<summary>
		/// Sets the number of shard copies that must be active before returning. Defaults to 0. Set to `all` for all shard copies, otherwise set to
		/// any non-negative value less than or equal to the total number of copies for the shard (number of replicas + 1)
		///</summary>
		public string WaitForActiveShards
		{
			get => Q<string>("wait_for_active_shards");
			set => Q("wait_for_active_shards", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IFollowInfoRequest : IRequest<FollowInfoRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for FollowInfo <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-follow-info.html</para></summary>
	public partial class FollowInfoRequest : PlainRequestBase<FollowInfoRequestParameters>, IFollowInfoRequest
	{
		protected IFollowInfoRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationFollowInfo;
		///<summary>/{index}/_ccr/info</summary>
		///<param name = "index">this parameter is required</param>
		public FollowInfoRequest(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected FollowInfoRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices IFollowInfoRequest.Index => Self.RouteValues.Get<Indices>("index");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IFollowIndexStatsRequest : IRequest<FollowIndexStatsRequestParameters>
	{
		[IgnoreDataMember]
		Indices Index
		{
			get;
		}
	}

	///<summary>Request for FollowIndexStats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-follow-stats.html</para></summary>
	public partial class FollowIndexStatsRequest : PlainRequestBase<FollowIndexStatsRequestParameters>, IFollowIndexStatsRequest
	{
		protected IFollowIndexStatsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationFollowIndexStats;
		///<summary>/{index}/_ccr/stats</summary>
		///<param name = "index">this parameter is required</param>
		public FollowIndexStatsRequest(Indices index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected FollowIndexStatsRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Indices IFollowIndexStatsRequest.Index => Self.RouteValues.Get<Indices>("index");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IForgetFollowerIndexRequest : IRequest<ForgetFollowerIndexRequestParameters>
	{
		[IgnoreDataMember]
		IndexName Index
		{
			get;
		}
	}

	///<summary>Request for ForgetFollowerIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-forget-follower.html</para></summary>
	public partial class ForgetFollowerIndexRequest : PlainRequestBase<ForgetFollowerIndexRequestParameters>, IForgetFollowerIndexRequest
	{
		protected IForgetFollowerIndexRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationForgetFollowerIndex;
		///<summary>/{index}/_ccr/forget_follower</summary>
		///<param name = "index">this parameter is required</param>
		public ForgetFollowerIndexRequest(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ForgetFollowerIndexRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		IndexName IForgetFollowerIndexRequest.Index => Self.RouteValues.Get<IndexName>("index");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetAutoFollowPatternRequest : IRequest<GetAutoFollowPatternRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for GetAutoFollowPattern <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-auto-follow-pattern.html</para></summary>
	public partial class GetAutoFollowPatternRequest : PlainRequestBase<GetAutoFollowPatternRequestParameters>, IGetAutoFollowPatternRequest
	{
		protected IGetAutoFollowPatternRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationGetAutoFollowPattern;
		///<summary>/_ccr/auto_follow</summary>
		public GetAutoFollowPatternRequest(): base()
		{
		}

		///<summary>/_ccr/auto_follow/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public GetAutoFollowPatternRequest(Name name): base(r => r.Optional("name", name))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IGetAutoFollowPatternRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IPauseAutoFollowPatternRequest : IRequest<PauseAutoFollowPatternRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for PauseAutoFollowPattern <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-pause-auto-follow-pattern.html</para></summary>
	public partial class PauseAutoFollowPatternRequest : PlainRequestBase<PauseAutoFollowPatternRequestParameters>, IPauseAutoFollowPatternRequest
	{
		protected IPauseAutoFollowPatternRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationPauseAutoFollowPattern;
		///<summary>/_ccr/auto_follow/{name}/pause</summary>
		///<param name = "name">this parameter is required</param>
		public PauseAutoFollowPatternRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PauseAutoFollowPatternRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IPauseAutoFollowPatternRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IPauseFollowIndexRequest : IRequest<PauseFollowIndexRequestParameters>
	{
		[IgnoreDataMember]
		IndexName Index
		{
			get;
		}
	}

	///<summary>Request for PauseFollowIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-pause-follow.html</para></summary>
	public partial class PauseFollowIndexRequest : PlainRequestBase<PauseFollowIndexRequestParameters>, IPauseFollowIndexRequest
	{
		protected IPauseFollowIndexRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationPauseFollowIndex;
		///<summary>/{index}/_ccr/pause_follow</summary>
		///<param name = "index">this parameter is required</param>
		public PauseFollowIndexRequest(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PauseFollowIndexRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		IndexName IPauseFollowIndexRequest.Index => Self.RouteValues.Get<IndexName>("index");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface ICreateAutoFollowPatternRequest : IRequest<CreateAutoFollowPatternRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for CreateAutoFollowPattern <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-put-auto-follow-pattern.html</para></summary>
	public partial class CreateAutoFollowPatternRequest : PlainRequestBase<CreateAutoFollowPatternRequestParameters>, ICreateAutoFollowPatternRequest
	{
		protected ICreateAutoFollowPatternRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationCreateAutoFollowPattern;
		///<summary>/_ccr/auto_follow/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public CreateAutoFollowPatternRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected CreateAutoFollowPatternRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name ICreateAutoFollowPatternRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IResumeAutoFollowPatternRequest : IRequest<ResumeAutoFollowPatternRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for ResumeAutoFollowPattern <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-resume-auto-follow-pattern.html</para></summary>
	public partial class ResumeAutoFollowPatternRequest : PlainRequestBase<ResumeAutoFollowPatternRequestParameters>, IResumeAutoFollowPatternRequest
	{
		protected IResumeAutoFollowPatternRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationResumeAutoFollowPattern;
		///<summary>/_ccr/auto_follow/{name}/resume</summary>
		///<param name = "name">this parameter is required</param>
		public ResumeAutoFollowPatternRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ResumeAutoFollowPatternRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IResumeAutoFollowPatternRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IResumeFollowIndexRequest : IRequest<ResumeFollowIndexRequestParameters>
	{
		[IgnoreDataMember]
		IndexName Index
		{
			get;
		}
	}

	///<summary>Request for ResumeFollowIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-resume-follow.html</para></summary>
	public partial class ResumeFollowIndexRequest : PlainRequestBase<ResumeFollowIndexRequestParameters>, IResumeFollowIndexRequest
	{
		protected IResumeFollowIndexRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationResumeFollowIndex;
		///<summary>/{index}/_ccr/resume_follow</summary>
		///<param name = "index">this parameter is required</param>
		public ResumeFollowIndexRequest(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ResumeFollowIndexRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		IndexName IResumeFollowIndexRequest.Index => Self.RouteValues.Get<IndexName>("index");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface ICcrStatsRequest : IRequest<CcrStatsRequestParameters>
	{
	}

	///<summary>Request for Stats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-get-stats.html</para></summary>
	public partial class CcrStatsRequest : PlainRequestBase<CcrStatsRequestParameters>, ICcrStatsRequest
	{
		protected ICcrStatsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationStats;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IUnfollowIndexRequest : IRequest<UnfollowIndexRequestParameters>
	{
		[IgnoreDataMember]
		IndexName Index
		{
			get;
		}
	}

	///<summary>Request for UnfollowIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/ccr-post-unfollow.html</para></summary>
	public partial class UnfollowIndexRequest : PlainRequestBase<UnfollowIndexRequestParameters>, IUnfollowIndexRequest
	{
		protected IUnfollowIndexRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.CrossClusterReplicationUnfollowIndex;
		///<summary>/{index}/_ccr/unfollow</summary>
		///<param name = "index">this parameter is required</param>
		public UnfollowIndexRequest(IndexName index): base(r => r.Required("index", index))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected UnfollowIndexRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		IndexName IUnfollowIndexRequest.Index => Self.RouteValues.Get<IndexName>("index");
	// Request parameters
	}
}