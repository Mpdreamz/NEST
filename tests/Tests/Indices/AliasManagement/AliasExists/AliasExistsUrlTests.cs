/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System.Threading.Tasks;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using Tests.Framework.EndpointTests;
using static Tests.Framework.EndpointTests.UrlTester;

namespace Tests.Indices.AliasManagement.AliasExists
{
	public class AliasExistsUrlTests
	{
		[U] public async Task Urls()
		{
			Name name = "hardcoded";
			IndexName index = "index";
			await HEAD($"/_alias/hardcoded")
					.Fluent(c => c.Indices.AliasExists(name))
					.Request(c => c.Indices.AliasExists(new AliasExistsRequest(name)))
					.FluentAsync(c => c.Indices.AliasExistsAsync(name))
					.RequestAsync(c => c.Indices.AliasExistsAsync(new AliasExistsRequest(name)))
				;

			await HEAD($"/index/_alias/hardcoded")
					.Fluent(c => c.Indices.AliasExists(name, b => b.Index(index)))
					.Request(c => c.Indices.AliasExists(new AliasExistsRequest(index, name)))
					.FluentAsync(c => c.Indices.AliasExistsAsync(name, b => b.Index(index)))
					.RequestAsync(c => c.Indices.AliasExistsAsync(new AliasExistsRequest(index, name)))
				;
		}
	}
}
