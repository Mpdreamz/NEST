﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elastic.Xunit;
using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Core.Client;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Core.Serialization;
using Tests.Framework.Integration;

namespace Tests.Analysis.Tokenizers
{

	[IntegrationTestCluster(typeof(ReadOnlyCluster))]
	public abstract class TokenizerAssertionBase<TAssertion> : ITokenizerAssertion
		where TAssertion : TokenizerAssertionBase<TAssertion>, new()
	{
		private static readonly SingleEndpointUsage<ICreateIndexResponse> Usage = new SingleEndpointUsage<ICreateIndexResponse>
		(
			fluent: (s, c) => c.CreateIndex(s, FluentCall),
			fluentAsync: (s, c) => c.CreateIndexAsync(s, FluentCall),
			request: (s, c) => c.CreateIndex(InitializerCall(s)),
			requestAsync: (s, c) => c.CreateIndexAsync(InitializerCall(s)),
			valuePrefix: $"test-{typeof(TAssertion).Name.ToLowerInvariant()}"
		)
		{
			OnAfterCall = c=> c.DeleteIndex(Usage.CallUniqueValues.Value)
		};
		private static TAssertion AssertionSetup { get; } = new TAssertion();

		protected TokenizerAssertionBase()
		{
			this.Client = (ElasticXunitRunner.CurrentCluster as ReadOnlyCluster)?.Client ?? TestClient.DefaultInMemoryClient;
			Usage.KickOffOnce(this.Client, oneRandomCall: true);
		}

		private IElasticClient Client { get; }

		public abstract string Name { get; }
		public abstract ITokenizer Initializer { get; }
		public abstract Func<string, TokenizersDescriptor, IPromise<ITokenizers>> Fluent { get; }
		public abstract object Json { get; }

		[U] public async Task TestPutSettingsRequest() => await Usage.AssertOnAllResponses(r =>
		{
			var json = new
			{
				settings = new
				{
					analysis = new
					{
						tokenizer = new Dictionary<string, object>
						{
							{ AssertionSetup.Name, AssertionSetup.Json}
						}
					}
				}
			};
			SerializationTestHelper.Expect(json).FromRequest(r);
		});

		[I] public async Task TestPutSettingsResponse() => await Usage.AssertOnAllResponses(r =>
		{
			r.ApiCall.HttpStatusCode.Should().Be(200);
		});

		private static CreateIndexRequest InitializerCall(string index) => new CreateIndexRequest(index)
		{
			Settings = new IndexSettings
			{
				Analysis = new Nest.Analysis
				{
					Tokenizers = new Nest.Tokenizers { { AssertionSetup.Name, AssertionSetup.Initializer } }
				}
			}
		};

		private static Func<CreateIndexDescriptor, ICreateIndexRequest> FluentCall => i => i
			.Settings(s => s
				.Analysis(a => a
					.Tokenizers(d => AssertionSetup.Fluent(AssertionSetup.Name, d))
				)
			);

	}
}
