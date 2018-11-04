using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	public interface IReindexSource
	{
		[JsonProperty("index")]
		Indices Index { get; set; }

		[JsonProperty("query")]
		QueryContainer Query { get; set; }

		[JsonProperty("remote")]
		IRemoteSource Remote { get; set; }

		[JsonProperty("size")]
		int? Size { get; set; }

		[JsonProperty("sort")]
		IList<ISort> Sort { get; set; }

		/// <summary>
		/// Individual fields from _source to reindex
		/// </summary>
		[JsonProperty("_source")]
		Fields Source { get; set; }

		[JsonProperty("type")]
		Types Type { get; set; }
	}

	public class ReindexSource : IReindexSource
	{
		public Indices Index { get; set; }
		public QueryContainer Query { get; set; }

		public IRemoteSource Remote { get; set; }

		public int? Size { get; set; }

		public IList<ISort> Sort { get; set; }

		/// <inheritdoc />
		public Fields Source { get; set; }

		public Types Type { get; set; }
	}

	public class ReindexSourceDescriptor : DescriptorBase<ReindexSourceDescriptor, IReindexSource>, IReindexSource
	{
		Indices IReindexSource.Index { get; set; }
		QueryContainer IReindexSource.Query { get; set; }
		IRemoteSource IReindexSource.Remote { get; set; }
		int? IReindexSource.Size { get; set; }
		IList<ISort> IReindexSource.Sort { get; set; }
		Fields IReindexSource.Source { get; set; }
		Types IReindexSource.Type { get; set; }

		public ReindexSourceDescriptor Query<T>(Func<QueryContainerDescriptor<T>, QueryContainer> querySelector) where T : class =>
			Assign(a => a.Query = querySelector?.Invoke(new QueryContainerDescriptor<T>()));

		public ReindexSourceDescriptor Sort<T>(Func<SortDescriptor<T>, IPromise<IList<ISort>>> selector) where T : class =>
			Assign(a => a.Sort = selector?.Invoke(new SortDescriptor<T>())?.Value);

		public ReindexSourceDescriptor Remote(Func<RemoteSourceDescriptor, IRemoteSource> selector) =>
			Assign(a => a.Remote = selector?.Invoke(new RemoteSourceDescriptor()));

		public ReindexSourceDescriptor Index(Indices indices) => Assign(a => a.Index = indices);

		public ReindexSourceDescriptor Type(Types types) => Assign(a => a.Type = types);

		public ReindexSourceDescriptor Size(int? size) => Assign(a => a.Size = size);

		/// <inheritdoc cref="IReindexSource.Source" />
		public ReindexSourceDescriptor Source<T>(Func<FieldsDescriptor<T>, IPromise<Fields>> fields) where T : class =>
			Assign(a => a.Source = fields?.Invoke(new FieldsDescriptor<T>())?.Value);
	}
}
