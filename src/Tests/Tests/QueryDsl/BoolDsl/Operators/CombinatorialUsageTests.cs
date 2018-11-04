﻿using Elastic.Xunit.XunitPlumbing;
using FluentAssertions;

namespace Tests.QueryDsl.BoolDsl.Operators
{
	public class CombinationUsageTests : OperatorUsageBase
	{
		[U]
		private void DoesNotJoinTwoShouldsUsingAnd() => ReturnsBool(
			(Query || Query) && (Query || Query),
			q => (q.Query() || q.Query()) && (q.Query() || q.Query()),
			b =>
			{
				b.Must.Should().NotBeEmpty().And.HaveCount(2);
				b.Should.Should().BeNull();
				b.MustNot.Should().BeNull();
				b.Filter.Should().BeNull();
			});

		[U]
		private void DoesJoinTwoShouldsUsingOr() => ReturnsBool(
			Query || Query || (Query || Query),
			q => q.Query() || q.Query() || (q.Query() || q.Query()),
			b =>
			{
				b.Should.Should().NotBeEmpty().And.HaveCount(4);
				b.Must.Should().BeNull();
				b.MustNot.Should().BeNull();
				b.Filter.Should().BeNull();
			});

		[U]
		private void DoesNotJoinTwoMustsUsingOr() => ReturnsBool(
			Query && Query || Query && Query,
			q => q.Query() && q.Query() || q.Query() && q.Query(),
			b =>
			{
				b.Should.Should().NotBeEmpty().And.HaveCount(2);
				b.Must.Should().BeNull();
				b.MustNot.Should().BeNull();
				b.Filter.Should().BeNull();
			});

		[U]
		private void DoesJoinTwoMustsUsingAnd() => ReturnsBool(
			Query && Query && (Query && Query),
			q => q.Query() && q.Query() && (q.Query() && q.Query()),
			b =>
			{
				b.Must.Should().NotBeEmpty().And.HaveCount(4);
				b.Should.Should().BeNull();
				b.MustNot.Should().BeNull();
				b.Filter.Should().BeNull();
			});

		[U]
		private void AndJoinsMustNot() => ReturnsBool(
			Query && !Query,
			q => q.Query() && !q.Query(),
			b =>
			{
				b.Must.Should().NotBeEmpty().And.HaveCount(1);
				b.MustNot.Should().NotBeEmpty().And.HaveCount(1);
			});

		[U]
		private void OrDoesNotJoinMustNot() => ReturnsBool(
			Query || !Query,
			q => q.Query() || !q.Query(),
			b => { b.Should.Should().NotBeEmpty().And.HaveCount(2); });

		[U]
		private void OrDoesNotJoinFilter() => ReturnsBool(
			Query || !Query,
			q => q.Query() || +q.Query(),
			b =>
			{
				b.Should.Should().NotBeEmpty().And.HaveCount(2);
				b.Filter.Should().BeNull();
			});

		[U]
		private void AndJoinsFilter() => ReturnsBool(
			Query && +Query,
			q => q.Query() && +q.Query(),
			b =>
			{
				b.Must.Should().NotBeEmpty().And.HaveCount(1);
				b.Filter.Should().NotBeEmpty().And.HaveCount(1);
			});
	}
}
