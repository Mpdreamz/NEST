﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Framework.Integration;
using Elastic.Managed;
using Elastic.Managed.Configuration;
using Elastic.Managed.Ephemeral;
using Tests.Configuration;
using Tests.Core.Client;
using Tests.Core.Serialization;
using Xunit;

namespace Tests.Framework
{
	public abstract class ApiTestBase<TCluster, TResponse, TInterface, TDescriptor, TInitializer>
		: ExpectJsonTestBase, IClusterFixture<TCluster>, IClassFixture<EndpointUsage>
		where TCluster : ICluster<EphemeralClusterConfiguration>, INestTestCluster , new()
		where TResponse : class, IResponse
		where TDescriptor : class, TInterface
		where TInitializer : class, TInterface
		where TInterface : class
	{
		protected override object ExpectJson { get; } = null;
		private readonly EndpointUsage _usage;
		private readonly LazyResponses _responses;
		private readonly CallUniqueValues _uniqueValues;

		protected static string RandomString() => Guid.NewGuid().ToString("N").Substring(0, 8);
		protected bool RanIntegrationSetup => this._usage?.CalledSetup ?? false;
	    protected string UrlEncode(string s) => Uri.EscapeDataString(s);

        protected TCluster Cluster { get; }
		protected virtual IElasticClient Client => TestClient.DefaultInMemoryClient;

		protected string CallIsolatedValue => _uniqueValues.Value;
		protected T ExtendedValue<T>(string key) where T : class => this._uniqueValues.ExtendedValue<T>(key);
		protected void ExtendedValue<T>(string key, T value) where T : class => this._uniqueValues.ExtendedValue(key, value);

		protected virtual void IntegrationSetup(IElasticClient client, CallUniqueValues values) { }
		protected virtual void IntegrationTeardown(IElasticClient client, CallUniqueValues values) { }
		protected virtual void OnBeforeCall(IElasticClient client) { }
		protected virtual void OnAfterCall(IElasticClient client) { }

		protected virtual TDescriptor NewDescriptor() => Activator.CreateInstance<TDescriptor>();
		protected virtual Func<TDescriptor, TInterface> Fluent { get; }
		protected virtual TInitializer Initializer { get; }

		protected abstract LazyResponses ClientUsage();

		protected abstract string UrlPath { get; }
		protected abstract HttpMethod HttpMethod { get; }

		protected ApiTestBase(TCluster cluster, EndpointUsage usage) : base(cluster.Client)
		{
			this._usage = usage ?? throw new ArgumentNullException(nameof(usage));
			if (cluster == null) throw new ArgumentNullException(nameof(cluster));
			this.Cluster = cluster;

			this._responses = usage.CallOnce(this.ClientUsage, 0);
			this._uniqueValues = usage.CallUniqueValues;
		}

		[U] protected async Task HitsTheCorrectUrl() =>
			await this.AssertOnAllResponses(r => this.AssertUrl(r.ApiCall.Uri));

		[U] protected async Task UsesCorrectHttpMethod() =>
			await this.AssertOnAllResponses(
				r => r.ApiCall.HttpMethod.Should().Be(this.HttpMethod,
					this._uniqueValues.CurrentView.GetStringValue()));

		[U] protected void SerializesInitializer() => this.RoundTripsOrSerializes<TInterface>(this.Initializer);

		[U] protected void SerializesFluent() => this.RoundTripsOrSerializes(this.Fluent?.Invoke(NewDescriptor()));

		protected LazyResponses Calls(
			Func<IElasticClient, Func<TDescriptor, TInterface>, TResponse> fluent,
			Func<IElasticClient, Func<TDescriptor, TInterface>, Task<TResponse>> fluentAsync,
			Func<IElasticClient, TInitializer, TResponse> request,
			Func<IElasticClient, TInitializer, Task<TResponse>> requestAsync
		)
		{
			//this client is outside the lambda so that the callstack is one where we can get the method name
			//of the current running test and send that as a header, great for e.g fiddler to relate requests with the test that sent it
			var client = this.Cluster.Client;
			return new LazyResponses(async () =>
			{
				if (TestConfiguration.Instance.RunIntegrationTests)
				{
					this.IntegrationSetup(client, _uniqueValues);
					this._usage.CalledSetup = true;
				}

				var dict = new Dictionary<ClientMethod, IResponse>();
				_uniqueValues.CurrentView = ClientMethod.Fluent;

				OnBeforeCall(client);
				dict.Add(ClientMethod.Fluent, fluent(client, this.Fluent));
				OnAfterCall(client);

				_uniqueValues.CurrentView = ClientMethod.FluentAsync;
				OnBeforeCall(client);
				dict.Add(ClientMethod.FluentAsync, await fluentAsync(client, this.Fluent));
				OnAfterCall(client);

				_uniqueValues.CurrentView = ClientMethod.Initializer;
				OnBeforeCall(client);
				dict.Add(ClientMethod.Initializer, request(client, this.Initializer));
				OnAfterCall(client);

				_uniqueValues.CurrentView = ClientMethod.InitializerAsync;
				OnBeforeCall(client);
				dict.Add(ClientMethod.InitializerAsync, await requestAsync(client, this.Initializer));
				OnAfterCall(client);

				if (TestClient.Configuration.RunIntegrationTests)
				{
					this.IntegrationTeardown(client, _uniqueValues);
					this._usage.CalledTeardown = true;
				}

				return dict;
			});
		}

		private void AssertUrl(Uri u) => u.PathEquals(this.UrlPath, this._uniqueValues.CurrentView.GetStringValue());

		protected virtual async Task AssertOnAllResponses(Action<TResponse> assert)
		{
			var responses = await this._responses;
			foreach (var kv in responses)
			{
				var response = kv.Value as TResponse;
				try
				{
					this._uniqueValues.CurrentView = kv.Key;
					assert(response);
				}
#pragma warning disable 8360 //enable this if you expect a single overload to act up
#pragma warning disable 7095 //enable this if you expect a single overload to act up
				catch (Exception ex) when (false)
#pragma warning restore 7095
#pragma warning restore 8360
#pragma warning disable 0162 //dead code while the previous exception filter is false
				{
					throw new Exception($"asserting over the response from: {kv.Key} failed: {ex.Message}", ex);
				}
#pragma warning restore 0162
			}
		}

	}
}
