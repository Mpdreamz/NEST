﻿using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;

namespace Tests.ClientConcepts.HighLevel.Inference
{
	public class IndicesPaths
	{
		/**== Indices paths
		*
		* Some APIs in Elasticsearch take one or many index name or a special `_all` marker to send the request to all the indices
		* In NEST, this is encoded using `Indices`.
		*
		*=== Implicit Conversion
		* Several types implicitly convert to `Indices`
		*/
		[U]
		public void ImplicitConversionFromString()
		{
			Nest.Indices singleIndexFromString = "name";
			Nest.Indices multipleIndicesFromString = "name1, name2";
			Nest.Indices allFromString = "_all";
			Nest.Indices allFromEmptyString = string.Empty;
			Nest.Indices allWithOthersFromString = "_all, name2";

			singleIndexFromString.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(1).And.Contain("name")
			);

			multipleIndicesFromString.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(2).And.Contain("name2")
			);

			allFromString.Match(
				all => all.Should().NotBeNull(),
				many => many.Indices.Should().BeNull()
			);

			allFromEmptyString.Match(
				all => all.Should().NotBeNull(),
				many => many.Indices.Should().BeNull()
			);

			allWithOthersFromString.Match(
				all => all.Should().NotBeNull(),
				many => many.Indices.Should().BeNull()
			);
		}

		/**[[nest-indices]]
		*=== Using Nest.Indices
		* To ease creating `IndexName` or `Indices` from expressions, there is a static `Nest.Indices` class you can use
		*
		*==== Specifying a single index
		* A single index can be specified using a CLR type or a string
		*/
		[U]
		public void UsingStaticPropertyField()
		{
			var client = TestClient.Default;

			var singleString = Nest.Indices.Index("name1"); // <1> specifying a single index using a string
			var singleTyped = Nest.Indices.Index<Project>(); //<2> specifying a single index using a type

			ISearchRequest singleStringRequest = new SearchDescriptor<Project>().Index(singleString);
			ISearchRequest singleTypedRequest = new SearchDescriptor<Project>().Index(singleTyped);

			((IUrlParameter)singleStringRequest.Index).GetString(client.ConnectionSettings).Should().Be("name1");
			((IUrlParameter)singleTypedRequest.Index).GetString(client.ConnectionSettings).Should().Be("project");

			var invalidSingleString = Nest.Indices.Index("name1, name2"); //<3> an **invalid** single index name
		}

		/**==== Specifying multiple indices
		* Similarly to a single index, multiple indices can be specified using multiple CLR types and multiple strings
		*/
		[U]
		public void MultipleIndices()
		{
			var client = TestClient.Default;

			var manyStrings = Nest.Indices.Index("name1", "name2"); //<1> specifying multiple indices using strings
			var manyTypes = Nest.Indices.Index<Project>().And<Developer>(); //<2> specifying multiple indices using types

			ISearchRequest manyStringRequest = new SearchDescriptor<Project>().Index(manyStrings);
			ISearchRequest manyTypedRequest = new SearchDescriptor<Project>().Index(manyTypes);

			((IUrlParameter)manyStringRequest.Index).GetString(client.ConnectionSettings).Should().Be("name1,name2");
			((IUrlParameter)manyTypedRequest.Index).GetString(client.ConnectionSettings).Should().Be("project,devs"); // <3> The index names here come from the Connection Settings passed to `TestClient`. See the documentation on <<index-name-inference, Index Name Inference>> for more details.
		}

		/**==== Specifying All Indices
		* Elasticsearch allows searching across multiple indices using the special `_all` marker.
		*
		* NEST exposes `_all` with `Indices.All` and `Indices.AllIndices`. Why expose it in two ways, you ask?
		* Well, you may be using both `Nest.Indices` and `Nest.Types` in the same file and you may also be using C#6
		* static imports too; in this scenario, `All` becomes ambiguous between `Indices.All` and `Types.All`, so the
		* `_all` marker is exposed as `Indices.AllIndices` to alleviate this ambiguity
		*/
		[U]
		public void IndicesAllAndAllIndicesSpecifiedWhenUsingStaticUsingDirective()
		{
			var client = TestClient.Default;

			var indicesAll = Nest.Indices.All;
			var allIndices = Nest.Indices.AllIndices;

			ISearchRequest indicesAllRequest = new SearchDescriptor<Project>().Index(indicesAll);
			ISearchRequest allIndicesRequest = new SearchDescriptor<Project>().Index(allIndices);

			((IUrlParameter)indicesAllRequest.Index).GetString(client.ConnectionSettings).Should().Be("_all");
			((IUrlParameter)allIndicesRequest.Index).GetString(client.ConnectionSettings).Should().Be("_all");
		}

		/**
		 * You can also use an empty string to map to all indices
		 */
		[U]
		public void IndicesAllWhenUsingEmptyString()
		{
			var client = TestClient.GetInMemoryClient();

			ISearchRequest indicesAllRequest = new SearchDescriptor<Project>().Index(string.Empty);

			((IUrlParameter)indicesAllRequest.Index).GetString(client.ConnectionSettings).Should().Be("_all");
		}
	}
}
