﻿using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using Nest.Tests.MockData;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Integration.Integration.Filter
{
	/// <summary>
	/// Integrated tests of RangeFilter with elasticsearch.
	/// </summary>
	[TestFixture]
	public class MissingExistsFilterTests : BaseElasticSearchTests
	{
		/// <summary>
		/// Document used in test.
		/// </summary>
		private ElasticSearchProject _LookFor;

		/// <summary>
		/// Field missing on document.
		/// </summary>
		private Expression<Func<ElasticSearchProject, object>> _MissingField;

		/// <summary>
		/// Field exists on document.
		/// </summary>
		private Expression<Func<ElasticSearchProject, object>> _ExistsField;


		/// <summary>
		/// Create document for test.
		/// </summary>
		protected override void ResetIndexes()
		{
			base.ResetIndexes();
			var client = this.ConnectedClient;
			if (client.IsValid)
			{
				_LookFor = NestTestData.Session.Single<ElasticSearchProject>().Get();
				_MissingField = f => f.Name;
				_ExistsField = f => f.Id;

				// missing
				_LookFor.Name = null;

				var status = this.ConnectedClient.Index(_LookFor);
				Assert.True(status.Success, status.Result);

				Assert.True(this.ConnectedClient.Flush<ElasticSearchProject>().OK, "Flush");
			}
		}

		/// <summary>
		/// Set of filters that should not filter de documento _LookFor.
		/// </summary>
		[Test]
		public void TestMissingFilter()
		{
			this.DoFilterTest(
				f => f.Missing(_MissingField),
				_LookFor,
				true);

			this.DoFilterTest(
				f => f.Missing(_ExistsField),
				_LookFor,
				false);
		}

		/// <summary>
		/// Set of filters that should not filter de documento _LookFor.
		/// </summary>
		[Test]
		public void TestExistsFilter()
		{
			this.DoFilterTest(
				f => f.Exists(_ExistsField),
				_LookFor,
				true);

			this.DoFilterTest(
				f => f.Exists(_MissingField),
				_LookFor,
				false);
		}

	}
}
