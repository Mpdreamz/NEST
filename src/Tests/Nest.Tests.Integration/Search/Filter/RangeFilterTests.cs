﻿using Elasticsearch.Net;
using Nest.Tests.MockData;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;
using System.Linq;

namespace Nest.Tests.Integration.Search.Filter
{
	/// <summary>
	/// Integrated tests of RangeFilter with elasticsearch.
	/// </summary>
	[TestFixture]
	public class RangeFilterTests : IntegrationTests
	{
		/// <summary>
		/// Document used in test.
		/// </summary>
		private ElasticsearchProject _LookFor;

		[TestFixtureSetUp]
		public void Initialize()
		{
			_LookFor = NestTestData.Session.Single<ElasticsearchProject>().Get();
			_LookFor.Name = "mmm";
			_LookFor.LOC = 9;
			var status = this.Client.Index(_LookFor, i => i.Refresh()).ConnectionStatus;
			Assert.True(status.Success, status.ResponseRaw.Utf8String());
		}

		/// <summary>
		/// Set of filters that should not filter de documento _LookFor.
		/// </summary>
		[Test]
		public void TestNotFiltered()
		{
			var name = _LookFor.Name;

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).GreaterOrEquals(name).LowerOrEquals(name)), _LookFor, true);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).GreaterOrEquals("aaa").LowerOrEquals("zzz")), _LookFor, true);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).GreaterOrEquals(name)), _LookFor, true);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).LowerOrEquals(name)), _LookFor, true);

		}

		/// <summary>
		/// Set of filters that should filter de documento _LookFor.
		/// </summary>
		[Test]
		public void TestFiltered()
		{
			var name = _LookFor.Name;

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).GreaterOrEquals("zzz")), _LookFor, false);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).LowerOrEquals("aaa")), _LookFor, false);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).GreaterOrEquals(name)), _LookFor, true);

			this.DoFilterTest(f => f.Range(range => range.OnField(e => e.Name).LowerOrEquals(name)), _LookFor, true);
		}

		/// <summary>
		/// Set of filters that should filter de documento _LookFor.
		/// </summary>
		[Test]
		public void TestNumericFiltered()
		{
			var name = _LookFor.Id;

			this.DoFilterTest(
				f => f.Range(range => range.OnField(e => e.LOC, FilterRangeExecutionType.FieldData).GreaterOrEquals(2)), _LookFor,
				true);

			this.DoFilterTest(
				f => f.Range(range => range.OnField(e => e.LOC, FilterRangeExecutionType.FieldData).Lower(2)), _LookFor,
				false);
		}
	}
}