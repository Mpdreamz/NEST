﻿using System;
using System.Collections.Generic;
using System.Text;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Newtonsoft.Json;

namespace Tests.ClientConcepts.Serializer
{
	/// <summary>
	/// This is the happy flow for the now deprecated ModifyJsonSerializerSettings override
	/// </summary>
	public class ModifySerializationSettingsTests
	{
		public IElasticClient CreateClient(string jsonResponse)
		{
			var connection = new InMemoryConnection(Encoding.UTF8.GetBytes(jsonResponse));
			var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
#pragma warning disable CS0618 // Type or member is obsolete
			var connectionSettings = new ConnectionSettings(connectionPool, connection, settings => new LocalJsonNetSerializer(settings
				.DefaultIndex("default-index")
			));
#pragma warning restore CS0618 // Type or member is obsolete
			var client = new ElasticClient(connectionSettings);
			return client;
		}

		[U]
		public void RespectsDateParseHandling()
		{
			var expectedDateString = "2015-02-06T23:45:05Z";
			var jsonResponse = $@"{{ ""dateString"": ""{expectedDateString}"" }}";
			var client = CreateClient(jsonResponse);

			var hit = client.Source<HasDateString>(1);
			hit.Should().NotBeNull();
			hit.DateString.Should().Be(expectedDateString);
		}

		[U]
		public void RespectsMaxDepth()
		{
			var expectedDateString = "12-06-06 12:32:01";
			var jsonResponse = $@"{{ ""_id"": ""1"", ""_source"": {{ ""dateString"": ""{expectedDateString}"" }}}}";
			var client = CreateClient(jsonResponse);

			Action act = () => client.Get<HasDateString>(1);
			act.ShouldThrow<UnexpectedElasticsearchClientException>()
				.WithMessage("The reader's MaxDepth of 1 has been exceeded. Path '_source', line 1, position 26.");
		}

		[U]
		public void RespectsContractResolver()
		{
			var client = CreateClient("{}");
			var serialized = client.Serializer.SerializeToString(new HasDateString { DateString = "1" }, SerializationFormatting.None);

			serialized.Should().Be($@"{{""DATESTRING"":""1""}}");
		}

		[U]
		public void DoesNotRespectDateTimeHandling()
		{
			// our contract converters are pretty aggressive in making sure datetimes get written to IsoDateTime
			// not intending on supporting json.net various dateformats

			var client = CreateClient("{}");
			var date = new DateTime(1999, 12, 30, 1, 2, 3);
			var serialized = client.Serializer.SerializeToString(new HasDateString { Date = date }, SerializationFormatting.None);

			serialized.Should().Be($@"{{""DATE"":""1999-12-30T01:02:03""}}");
		}

		public class MyCustomResolver : ElasticContractResolver
		{
			public MyCustomResolver(IConnectionSettingsValues connectionSettings, IList<Func<Type, JsonConverter>> contractConverters) : base(
				connectionSettings, contractConverters) { }

			protected override string ResolvePropertyName(string fieldName) => fieldName.ToUpperInvariant();
		}

		private sealed class LocalJsonNetSerializer : JsonNetSerializer
		{
			public LocalJsonNetSerializer(IConnectionSettingsValues settings) : base(settings) => OverwriteDefaultSerializers((s, cvs) =>
				{
					s.DateParseHandling = DateParseHandling.None;
					s.MaxDepth = 1;
					s.ContractResolver = new MyCustomResolver(Settings, null);
					s.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
				}
			);
		}

		public class HasDateString
		{
			public DateTime? Date { get; set; }
			public string DateString { get; set; }
		}
	}
}
