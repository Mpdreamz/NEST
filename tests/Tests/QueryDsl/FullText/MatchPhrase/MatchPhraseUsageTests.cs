﻿using System.IO;
using System.Text;
using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Newtonsoft.Json;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.EndpointTests.TestState;
using static Nest.Infer;

namespace Tests.QueryDsl.FullText.MatchPhrase
{
	public class MatchPhraseUsageTests : QueryDslUsageTestsBase
	{
		public MatchPhraseUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override ConditionlessWhen ConditionlessWhen => new ConditionlessWhen<IMatchPhraseQuery>(a => a.MatchPhrase)
		{
			q => q.Query = null,
			q => q.Query = string.Empty,
			q => q.Field = null
		};

		protected override QueryContainer QueryInitializer => new MatchPhraseQuery
		{
			Field = Field<Project>(p => p.Description),
			Analyzer = "standard",
			Boost = 1.1,
			Name = "named_query",
			Query = "hello world",
			Slop = 2,
		};

		protected override object QueryJson => new
		{
			match_phrase = new
			{
				description = new
				{
					_name = "named_query",
					boost = 1.1,
					query = "hello world",
					analyzer = "standard",
					slop = 2,
				}
			}
		};

		protected override QueryContainer QueryFluent(QueryContainerDescriptor<Project> q) => q
			.MatchPhrase(c => c
				.Field(p => p.Description)
				.Analyzer("standard")
				.Boost(1.1)
				.Query("hello world")
				.Slop(2)
				.Name("named_query")
			);

		//hide
		[U] public void DeserializeShortForm()
		{
			var json = JsonConvert.SerializeObject(new { description = "project description" });
			using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
			var query = Client.RequestResponseSerializer.Deserialize<IMatchPhraseQuery>(stream);
			query.Should().NotBeNull();
			query.Field.Should().Be(new Field("description"));
			query.Query.Should().Be("project description");
		}
	}
}
