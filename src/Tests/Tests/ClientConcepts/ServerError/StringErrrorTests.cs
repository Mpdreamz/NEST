﻿using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;

namespace Tests.ClientConcepts.ServerError
{
	public class StringErrorTests : ServerErrorTestsBase
	{
		protected override string Json => @"""alias [x] is missing""";

		[U] protected override void AssertServerError() => base.AssertServerError();

		protected override void AssertResponseError(string origin, Error error)
		{
			error.Type.Should().BeNullOrEmpty(origin);
			error.Reason.Should().NotBeNullOrWhiteSpace(origin).And.Contain("is missing");
			error.RootCause.Should().BeNull(origin);
		}
	}

	public class TempErrorTests : ServerErrorTestsBase
	{
		protected override string Json =>
			@"{""root_cause"":[{""type"":""index_not_found_exception"",""reason"":""no such index"",""index_uuid"":""_na_"",""index"":""non-existent-index""}],""type"":""index_not_found_exception"",""reason"":""no such index"",""index_uuid"":""_na_"",""index"":""non-existent-index""}";

		[U] protected override void AssertServerError() => base.AssertServerError();

		protected override void AssertResponseError(string origin, Error error)
		{
			error.Type.Should().NotBeNullOrEmpty(origin);
			error.Reason.Should().NotBeNullOrWhiteSpace(origin);
			error.RootCause.Should().NotBeNull(origin).And.HaveCount(1);
		}
	}
}
