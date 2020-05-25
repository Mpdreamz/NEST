﻿using System;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using FluentAssertions;
using Nest;
using Tests.Domain;

namespace Tests.Reproduce
{
	public class GithubIssue3220
	{
		[U] public void CanExplicitCastTimeFromString()
		{
			var searchRequest = new SearchRequest<Project> { Scroll = "1s" };

			Action getScroll = () =>
			{
				// ReSharper disable once UnusedVariable
				var scroll = searchRequest.Scroll;
			};

			getScroll.Should().NotThrow();
		}
	}
}
