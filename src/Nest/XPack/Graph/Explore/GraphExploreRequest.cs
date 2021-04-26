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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nest
{
	[MapsApi("graph.explore.json")]
	public partial interface IGraphExploreRequest : IHop
	{
		[DataMember(Name ="controls")]
		IGraphExploreControls Controls { get; set; }
	}

	// ReSharper disable once UnusedTypeParameter
	public partial interface IGraphExploreRequest<TDocument> where TDocument : class { }

	public partial class GraphExploreRequest
	{
		public IHop Connections { get; set; }
		public IGraphExploreControls Controls { get; set; }
		public QueryContainer Query { get; set; }
		public IEnumerable<IGraphVertexDefinition> Vertices { get; set; }
	}

	// ReSharper disable once UnusedTypeParameter
	public partial class GraphExploreRequest<TDocument> where TDocument : class { }

	public partial class GraphExploreDescriptor<TDocument> where TDocument : class
	{
		IHop IHop.Connections { get; set; }
		IGraphExploreControls IGraphExploreRequest.Controls { get; set; }
		QueryContainer IHop.Query { get; set; }
		IEnumerable<IGraphVertexDefinition> IHop.Vertices { get; set; }

		public GraphExploreDescriptor<TDocument> Query(Func<QueryContainerDescriptor<TDocument>, QueryContainer> querySelector) =>
			Assign(querySelector, (a, v) => a.Query = v?.Invoke(new QueryContainerDescriptor<TDocument>()));

		public GraphExploreDescriptor<TDocument> Vertices(Func<GraphVerticesDescriptor<TDocument>, IPromise<IList<IGraphVertexDefinition>>> selector) =>
			Assign(selector, (a, v) => a.Vertices = v?.Invoke(new GraphVerticesDescriptor<TDocument>())?.Value);

		public GraphExploreDescriptor<TDocument> Connections(Func<HopDescriptor<TDocument>, IHop> selector) =>
			Assign(selector, (a, v) => a.Connections = v?.Invoke(new HopDescriptor<TDocument>()));

		public GraphExploreDescriptor<TDocument> Controls(Func<GraphExploreControlsDescriptor<TDocument>, IGraphExploreControls> selector) =>
			Assign(selector, (a, v) => a.Controls = v?.Invoke(new GraphExploreControlsDescriptor<TDocument>()));
	}
}
