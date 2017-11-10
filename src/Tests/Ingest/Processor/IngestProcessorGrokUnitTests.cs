﻿using System.Linq;
using FluentAssertions;
using Nest;
using Tests.Framework;

namespace Tests.XPack.IngestProcessorGrok
{
	public class IngestProcessorGrokUnitTests
	{
		[U]
		public void ShouldDeserialize()
		{
			const string fixedResponse = "{ \"patterns\" : { \"BACULA_CAPACITY\" : \"%{INT}{1,3}(,%{INT}{3})*\", \"PATH\" : \"(?:%{UNIXPATH}|%{WINPATH})\" } }";
			var client = TestClient.GetFixedReturnClient(fixedResponse);

			//warmup
			var response = client.IngestProcessorGrok();
			response.ShouldBeValid();

			response.Patterns.Should().NotBeNull();
			response.Patterns.Should().HaveCount(2);
			response.Patterns.Should().ContainKey("BACULA_CAPACITY");
			response.Patterns.Should().ContainKey("PATH");
		}
	}
}
