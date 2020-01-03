﻿using System;
using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Core.Extensions;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests.TestState;

namespace Tests.Aggregations.Pipeline.MovingAverage
{
	/*
	 *{
  "error" : {
    [xUnit.net 00:01:25.9675447]     Tests.Aggregations.Pipeline.MovingAverage.MovingAverageLinearAggregationUsageTests.ReturnsExpectedResponse [FAIL]
"root_cause" : [
      {
        "type" : "named_object_not_found_exception",
        "reason" : "[1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found",
"stack_trace" : "[[1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found]; nested: NamedObjectNotFoundException[[1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found];\n\tat org.elasticsearch.ElasticsearchException.guessRootCauses(ElasticsearchException.java:639)\n\tat org.elasticsearch.ElasticsearchException.generateFailureXContent(ElasticsearchException.java:567)\n\tat org.elasticsearch.rest.BytesRestResponse.build(BytesRestResponse.java:138)\n\tat org.elasticsearch.rest.BytesRestResponse.<init>(BytesRestResponse.java:96)\n\tat org.elasticsearch.rest.BytesRestResponse.<init>(BytesRestResponse.java:91)\n\tat org.elasticsearch.rest.RestController.dispatchRequest(RestController.java:243)\n\tat org.elasticsearch.rest.RestController.tryAllHandlers(RestController.java:344)\n\tat org.elasticsearch.rest.RestController.dispatchRequest(RestController.java:174)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.dispatchRequest(AbstractHttpServerTransport.java:322)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.handleIncomingRequest(AbstractHttpServerTransport.java:372)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.incomingRequest(AbstractHttpServerTransport.java:301)\n\tat org.elasticsearch.http.netty4.Netty4HttpRequestHandler.channelRead0(Netty4HttpRequestHandler.java:69)\n\tat org.elasticsearch.http.netty4.Netty4HttpRequestHandler.channelRead0(Netty4HttpRequestHandler.java:31)\n\tat io.netty.channel.SimpleChannelInboundHandler.channelRead(SimpleChannelInboundHandler.java:105)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat org.elasticsearch.http.netty4.Netty4HttpPipeliningHandler.channelRead(Netty4HttpPipeliningHandler.java:58)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.handler.codec.MessageToMessageCodec.channelRead(MessageToMessageCodec.java:111)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.ByteToMessageDecoder.fireChannelRead(ByteToMessageDecoder.java:323)\n\tat io.netty.handler.codec.ByteToMessageDecoder.channelRead(ByteToMessageDecoder.java:297)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.timeout.IdleStateHandler.channelRead(IdleStateHandler.java:287)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.channel.DefaultChannelPipeline$HeadContext.channelRead(DefaultChannelPipeline.java:1408)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.DefaultChannelPipeline.fireChannelRead(DefaultChannelPipeline.java:930)\n\tat io.netty.channel.nio.AbstractNioByteChannel$NioByteUnsafe.read(AbstractNioByteChannel.java:163)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKey(NioEventLoop.java:682)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKeysPlain(NioEventLoop.java:582)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKeys(NioEventLoop.java:536)\n\tat io.netty.channel.nio.NioEventLoop.run(NioEventLoop.java:496)\n\tat io.netty.util.concurrent.SingleThreadEventExecutor$5.run(SingleThreadEventExecutor.java:906)\n\tat io.netty.util.internal.ThreadExecutorMap$2.run(ThreadExecutorMap.java:74)\n\tat java.base/java.lang.Thread.run(Thread.java:835)\nCaused by: org.elasticsearch.common.xcontent.NamedObjectNotFoundException: [1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found\n\tat org.elasticsearch.common.xcontent.NamedXContentRegistry.parseNamedObject(NamedXContentRegistry.java:132)\n\tat org.elasticsearch.common.xcontent.support.AbstractXContentParser.namedObject(AbstractXContentParser.java:385)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:121)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:113)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:62)\n\tat org.elasticsearch.search.builder.SearchSourceBuilder.parseXContent(SearchSourceBuilder.java:1090)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.parseSearchRequest(RestSearchAction.java:121)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.lambda$prepareRequest$1(RestSearchAction.java:100)\n\tat org.elasticsearch.rest.RestRequest.withContentOrSourceParamParserOrNull(RestRequest.java:449)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.prepareRequest(RestSearchAction.java:99)\n\tat org.elasticsearch.rest.BaseRestHandler.handleRequest(BaseRestHandler.java:92)\n\tat org.elasticsearch.rest.RestController.dispatchRequest(RestController.java:240)\n\t... 49 more\n"
      }
    ],
    "type" : "named_object_not_found_exception",
    "reason" : "[1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found",
"stack_trace" : "org.elasticsearch.common.xcontent.NamedObjectNotFoundException: [1:129] unable to parse BaseAggregationBuilder with name [moving_avg]: parser not found\n\tat org.elasticsearch.common.xcontent.NamedXContentRegistry.parseNamedObject(NamedXContentRegistry.java:132)\n\tat org.elasticsearch.common.xcontent.support.AbstractXContentParser.namedObject(AbstractXContentParser.java:385)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:121)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:113)\n\tat org.elasticsearch.search.aggregations.AggregatorFactories.parseAggregators(AggregatorFactories.java:62)\n\tat org.elasticsearch.search.builder.SearchSourceBuilder.parseXContent(SearchSourceBuilder.java:1090)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.parseSearchRequest(RestSearchAction.java:121)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.lambda$prepareRequest$1(RestSearchAction.java:100)\n\tat org.elasticsearch.rest.RestRequest.withContentOrSourceParamParserOrNull(RestRequest.java:449)\n\tat org.elasticsearch.rest.action.search.RestSearchAction.prepareRequest(RestSearchAction.java:99)\n\tat org.elasticsearch.rest.BaseRestHandler.handleRequest(BaseRestHandler.java:92)\n\tat org.elasticsearch.rest.RestController.dispatchRequest(RestController.java:240)\n\tat org.elasticsearch.rest.RestController.tryAllHandlers(RestController.java:344)\n\tat org.elasticsearch.rest.RestController.dispatchRequest(RestController.java:174)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.dispatchRequest(AbstractHttpServerTransport.java:322)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.handleIncomingRequest(AbstractHttpServerTransport.java:372)\n\tat org.elasticsearch.http.AbstractHttpServerTransport.incomingRequest(AbstractHttpServerTransport.java:301)\n\tat org.elasticsearch.http.netty4.Netty4HttpRequestHandler.channelRead0(Netty4HttpRequestHandler.java:69)\n\tat org.elasticsearch.http.netty4.Netty4HttpRequestHandler.channelRead0(Netty4HttpRequestHandler.java:31)\n\tat io.netty.channel.SimpleChannelInboundHandler.channelRead(SimpleChannelInboundHandler.java:105)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat org.elasticsearch.http.netty4.Netty4HttpPipeliningHandler.channelRead(Netty4HttpPipeliningHandler.java:58)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.handler.codec.MessageToMessageCodec.channelRead(MessageToMessageCodec.java:111)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.MessageToMessageDecoder.channelRead(MessageToMessageDecoder.java:102)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.codec.ByteToMessageDecoder.fireChannelRead(ByteToMessageDecoder.java:323)\n\tat io.netty.handler.codec.ByteToMessageDecoder.channelRead(ByteToMessageDecoder.java:297)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.handler.timeout.IdleStateHandler.channelRead(IdleStateHandler.java:287)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.AbstractChannelHandlerContext.fireChannelRead(AbstractChannelHandlerContext.java:352)\n\tat io.netty.channel.DefaultChannelPipeline$HeadContext.channelRead(DefaultChannelPipeline.java:1408)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:374)\n\tat io.netty.channel.AbstractChannelHandlerContext.invokeChannelRead(AbstractChannelHandlerContext.java:360)\n\tat io.netty.channel.DefaultChannelPipeline.fireChannelRead(DefaultChannelPipeline.java:930)\n\tat io.netty.channel.nio.AbstractNioByteChannel$NioByteUnsafe.read(AbstractNioByteChannel.java:163)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKey(NioEventLoop.java:682)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKeysPlain(NioEventLoop.java:582)\n\tat io.netty.channel.nio.NioEventLoop.processSelectedKeys(NioEventLoop.java:536)\n\tat io.netty.channel.nio.NioEventLoop.run(NioEventLoop.java:496)\n\tat io.netty.util.concurrent.SingleThreadEventExecutor$5.run(SingleThreadEventExecutor.java:906)\n\tat io.netty.util.internal.ThreadExecutorMap$2.run(ThreadExecutorMap.java:74)\n\tat java.base/java.lang.Thread.run(Thread.java:835)\n"
  },
  "status" : 400
}
	 */
	[SkipVersion(">=8.0.0-SNAPSHOT", "TODO broken in snapshot")]
	public class MovingAverageHoltWintersUsageTests : AggregationUsageTestBase
	{
		public MovingAverageHoltWintersUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object AggregationJson => new
		{
			projects_started_per_month = new
			{
				date_histogram = new
				{
					field = "startedOn",
					interval = "month",
					min_doc_count = 1
				},
				aggs = new
				{
					commits = new
					{
						sum = new
						{
							field = "numberOfCommits"
						}
					},
					commits_moving_avg = new
					{
						moving_avg = new
						{
							buckets_path = "commits",
							window = 4,
							model = "holt_winters",
							settings = new
							{
								type = "mult",
								alpha = 0.5,
								beta = 0.5,
								gamma = 0.5,
								period = 2,
								pad = false
							}
						}
					}
				}
			}
		};

#pragma warning disable 618, 612
		protected override Func<AggregationContainerDescriptor<Project>, IAggregationContainer> FluentAggs => a => a
			.DateHistogram("projects_started_per_month", dh => dh
				.Field(p => p.StartedOn)
				.Interval(DateInterval.Month)
				.MinimumDocumentCount(1)
				.Aggregations(aa => aa
					.Sum("commits", sm => sm
						.Field(p => p.NumberOfCommits)
					)
					.MovingAverage("commits_moving_avg", mv => mv
						.BucketsPath("commits")
						.Window(4)
						.Model(m => m
							.HoltWinters(hw => hw
								.Type(HoltWintersType.Multiplicative)
								.Alpha(0.5f)
								.Beta(0.5f)
								.Gamma(0.5f)
								.Period(2)
								.Pad(false)
							)
						)
					)
				)
			);

		protected override AggregationDictionary InitializerAggs =>
			new DateHistogramAggregation("projects_started_per_month")
			{
				Field = "startedOn",
				Interval = DateInterval.Month,
				MinimumDocumentCount = 1,
				Aggregations =
					new SumAggregation("commits", "numberOfCommits")
					&& new MovingAverageAggregation("commits_moving_avg", "commits")
					{
						Window = 4,
						Model = new HoltWintersModel
						{
							Type = HoltWintersType.Multiplicative,
							Alpha = 0.5f,
							Beta = 0.5f,
							Gamma = 0.5f,
							Period = 2,
							Pad = false
						}
					}
			};
#pragma warning restore 618, 612

		protected override void ExpectResponse(ISearchResponse<Project> response)
		{
			response.ShouldBeValid();

			var projectsPerMonth = response.Aggregations.DateHistogram("projects_started_per_month");
			projectsPerMonth.Should().NotBeNull();
			projectsPerMonth.Buckets.Should().NotBeNull();
			projectsPerMonth.Buckets.Count.Should().BeGreaterThan(0);

			var bucketCount = 0;
			foreach (var item in projectsPerMonth.Buckets)
			{
				bucketCount++;

				var commits = item.Sum("commits");
				commits.Should().NotBeNull();
				commits.Value.Should().BeGreaterThan(0);

				var movingAverage = item.MovingAverage("commits_moving_avg");

				// Moving Average specifies a window of 4 so
				// moving average values should exist from 5th bucket onwards
				if (bucketCount <= 4)
					movingAverage.Should().BeNull();
				else
				{
					movingAverage.Should().NotBeNull();
					movingAverage.Value.Should().HaveValue();
				}
			}
		}
	}
}
