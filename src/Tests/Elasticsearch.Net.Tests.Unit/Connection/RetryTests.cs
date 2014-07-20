﻿using System;
using System.IO;
using System.Threading.Tasks;
using Autofac.Extras.FakeItEasy;
using Elasticsearch.Net.Connection;
using Elasticsearch.Net.Exceptions;
using Elasticsearch.Net.Tests.Unit.Stubs;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Elasticsearch.Net.Tests.Unit.Connection
{
	[TestFixture]
	public class RetryTests
	{
		private static readonly int _retries = 4;

		//we do not pass a Uri or IConnectionPool so this config
		//defaults to SingleNodeConnectionPool()
		private readonly ConnectionConfiguration _connectionConfig = new ConnectionConfiguration()
			.MaximumRetries(_retries);

		[Test]
		public void ThrowsMaxRetryException_AndRetriesTheSpecifiedTimes()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetSyncCall(fake);
				getCall.Throws<Exception>();

				var client = fake.Resolve<ElasticsearchClient>();

				client.Settings.MaxRetries.Should().Be(_retries);

				Assert.Throws<MaxRetryException>(() => client.Info());
				getCall.MustHaveHappened(Repeated.Exactly.Times(_retries + 1));

			}
		}
		
		[Test]
		public void ThrowsMaxRetryException_AndRetriesTheSpecifiedTimes_HardIConnectionException_Async()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);
				var getCall = FakeCalls.GetCall(fake);

				//return a started task that throws
				getCall.Throws<Exception>();

				var client = fake.Resolve<ElasticsearchClient>();

				client.Settings.MaxRetries.Should().Be(_retries);

				Assert.Throws<MaxRetryException>(async () => await client.InfoAsync());
				getCall.MustHaveHappened(Repeated.Exactly.Times(_retries + 1));
			}
		}

		[Test]
		public void ThrowsMaxRetryException_AndRetriesTheSpecifiedTimes_Async()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);
				var getCall = FakeCalls.GetCall(fake);

				//return a started task that throws
				Func<ElasticsearchResponse<Stream>> badTask = () => { throw new Exception(); };
				var t = new Task<ElasticsearchResponse<Stream>>(badTask);
				t.Start();
				getCall.Returns(t);

				var client = fake.Resolve<ElasticsearchClient>();

				client.Settings.MaxRetries.Should().Be(_retries);

				Assert.Throws<MaxRetryException>(async () => await client.InfoAsync());
				getCall.MustHaveHappened(Repeated.Exactly.Times(_retries + 1));
			}
		}

		[Test]
		public void ShouldNotRetryOn400()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetSyncCall(fake);
				getCall.Returns(FakeResponse.Any(_connectionConfig, 400));

				var client = fake.Resolve<ElasticsearchClient>();

				Assert.DoesNotThrow(() => client.Info());
				getCall.MustHaveHappened(Repeated.Exactly.Once);

			}
		}

		[Test]
		public async void ShouldNotRetryOn400_Async()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetCall(fake);
				var task = Task.FromResult(FakeResponse.Any(_connectionConfig, 400));
				getCall.Returns(task);

				var client = fake.Resolve<ElasticsearchClient>();

				var result = await client.InfoAsync();
				getCall.MustHaveHappened(Repeated.Exactly.Once);

			}
		}

		[Test]
		public void ShouldNotRetryOn500()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetSyncCall(fake);
				getCall.Returns(FakeResponse.Any(_connectionConfig, 500));

				var client = fake.Resolve<ElasticsearchClient>();

				Assert.DoesNotThrow(() => client.Info());
				getCall.MustHaveHappened(Repeated.Exactly.Once);

			}
		}

		[Test]
		public void ShouldNotRetryOn201()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetSyncCall(fake);
				getCall.Returns(FakeResponse.Any(_connectionConfig, 201));

				var client = fake.Resolve<ElasticsearchClient>();

				Assert.DoesNotThrow(() => client.Info());
				getCall.MustHaveHappened(Repeated.Exactly.Once);

			}
		}

		[Test]
		public void ShouldRetryOn503()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetSyncCall(fake);
				getCall.Returns(FakeResponse.Bad(_connectionConfig));

				var client = fake.Resolve<ElasticsearchClient>();

				Assert.Throws<MaxRetryException>(() => client.Info());
				getCall.MustHaveHappened(Repeated.Exactly.Times(_retries + 1));

			}
		}

		[Test]
		public void ShouldRetryOn503_Async()
		{
			using (var fake = new AutoFake(callsDoNothing: true))
			{
				fake.Provide<IConnectionConfigurationValues>(_connectionConfig);
				FakeCalls.ProvideDefaultTransport(fake);

				var getCall = FakeCalls.GetCall(fake);
				getCall.Returns(Task.FromResult(FakeResponse.Bad(_connectionConfig)));

				var client = fake.Resolve<ElasticsearchClient>();

				Assert.Throws<MaxRetryException>(async () => await client.InfoAsync());
				getCall.MustHaveHappened(Repeated.Exactly.Times(_retries + 1));
			}
		}
		
	}
}
