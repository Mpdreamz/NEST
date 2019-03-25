﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using System.Runtime.Serialization;


namespace Nest
{
	[DataContract]
	[ReadAs(typeof(SearchInputRequest))]
	public interface ISearchInputRequest
	{
		[DataMember(Name ="body")]
		[ReadAs(typeof(SearchRequest))]
		ISearchRequest Body { get; set; }

		[DataMember(Name ="indices")]
		IEnumerable<IndexName> Indices { get; set; }

		[DataMember(Name ="indices_options")]
		IIndicesOptions IndicesOptions { get; set; }

		[DataMember(Name ="search_type")]

		SearchType? SearchType { get; set; }

		[DataMember(Name ="template")]
		[ReadAs(typeof(SearchTemplateRequest))]
		ISearchTemplateRequest Template { get; set; }
	}

	public class SearchInputRequest : ISearchInputRequest
	{
		public ISearchRequest Body { get; set; }
		public IEnumerable<IndexName> Indices { get; set; }

		public IIndicesOptions IndicesOptions { get; set; }

		public SearchType? SearchType { get; set; }

		public ISearchTemplateRequest Template { get; set; }
	}

	public class SearchInputRequestDescriptor : DescriptorBase<SearchInputRequestDescriptor, ISearchInputRequest>, ISearchInputRequest
	{
		ISearchRequest ISearchInputRequest.Body { get; set; }
		IEnumerable<IndexName> ISearchInputRequest.Indices { get; set; }
		IIndicesOptions ISearchInputRequest.IndicesOptions { get; set; }
		SearchType? ISearchInputRequest.SearchType { get; set; }
		ISearchTemplateRequest ISearchInputRequest.Template { get; set; }

		public SearchInputRequestDescriptor Indices(IEnumerable<IndexName> indices) =>
			Assign(a => a.Indices = indices);

		public SearchInputRequestDescriptor Indices(params IndexName[] indices) =>
			Assign(a => a.Indices = indices);

		public SearchInputRequestDescriptor Indices<T>() =>
			Assign(a => a.Indices = new[] { (IndexName)typeof(T) });

		public SearchInputRequestDescriptor SearchType(SearchType? searchType) =>
			Assign(a => a.SearchType = searchType);

		public SearchInputRequestDescriptor IndicesOptions(Func<IndicesOptionsDescriptor, IIndicesOptions> selector) =>
			Assign(a => a.IndicesOptions = selector(new IndicesOptionsDescriptor()));

		public SearchInputRequestDescriptor Body<T>(Func<SearchDescriptor<T>, ISearchRequest> selector) where T : class =>
			Assign(a => a.Body = selector?.InvokeOrDefault(new SearchDescriptor<T>()));

		public SearchInputRequestDescriptor Template<T>(Func<SearchTemplateDescriptor<T>, ISearchTemplateRequest> selector) where T : class =>
			Assign(a => a.Template = selector?.InvokeOrDefault(new SearchTemplateDescriptor<T>()));
	}
}
