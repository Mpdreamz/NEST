﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Nest
{
	[Obsolete("Facets are deprecated and will be removed in a future release. You are encouraged to migrate to aggregations instead.")]
	public interface IFacetDescriptor<out T> : IFacetRequest { }

	[Obsolete("Facets are deprecated and will be removed in a future release. You are encouraged to migrate to aggregations instead.")]
	public class BaseFacetDescriptor<TFacetDescriptor, T> : IFacetDescriptor<T> 
		where TFacetDescriptor : BaseFacetDescriptor<TFacetDescriptor, T> 
		where T : class 
	{
		bool? IFacetRequest.Global { get; set; }
		public TFacetDescriptor Global(bool global = true)
		{
			((IFacetRequest)this).Global = global;
			return (TFacetDescriptor) this;
		}

		IFilterContainer IFacetRequest.FacetFilter { get; set; }
		public TFacetDescriptor FacetFilter(Func<FilterDescriptor<T>, FilterContainer> facetFilter)
		{
			facetFilter.ThrowIfNull("facetFilter");
			var filter = facetFilter(new FilterDescriptor<T>());
			if (filter.IsConditionless)
				filter = null;
			((IFacetRequest) this).FacetFilter = filter;
			return (TFacetDescriptor) this;
		}

		PropertyPathMarker IFacetRequest.Nested { get; set; }

		public TFacetDescriptor Nested(string nested)
		{
			((IFacetRequest)this).Nested = nested;
			return (TFacetDescriptor) this;
		}
		public TFacetDescriptor Nested(Expression<Func<T, object>> objectPath)
		{
			((IFacetRequest)this).Nested = objectPath;
			return (TFacetDescriptor) this;
		}
	}
}
