﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization.OptIn)]
	public interface ISimulatePipelineDocument
	{
		[JsonProperty("_id")]
		Id Id { get; set; }

		[JsonProperty("_index")]
		IndexName Index { get; set; }

		[JsonProperty("_source")]
		[JsonConverter(typeof(SourceConverter))]
		object Source { get; set; }

		[JsonProperty("_type")]
		TypeName Type { get; set; }
	}

	public class SimulatePipelineDocument : ISimulatePipelineDocument
	{
		private object _source;

		public Id Id { get; set; }
		public IndexName Index { get; set; }

		public object Source
		{
			get => _source;
			set
			{
				_source = value;
				Index = Index ?? _source.GetType();
				Type = Type ?? _source.GetType();
				Id = Id ?? Id.From(_source);
			}
		}

		public TypeName Type { get; set; }
	}

	public class SimulatePipelineDocumentDescriptor
		: DescriptorBase<SimulatePipelineDocumentDescriptor, ISimulatePipelineDocument>, ISimulatePipelineDocument
	{
		Id ISimulatePipelineDocument.Id { get; set; }
		IndexName ISimulatePipelineDocument.Index { get; set; }
		object ISimulatePipelineDocument.Source { get; set; }
		TypeName ISimulatePipelineDocument.Type { get; set; }

		public SimulatePipelineDocumentDescriptor Id(Id id) => Assign(a => a.Id = id);

		public SimulatePipelineDocumentDescriptor Index(IndexName index) => Assign(a => a.Index = index);

		public SimulatePipelineDocumentDescriptor Type(TypeName type) => Assign(a => a.Type = type);

		public SimulatePipelineDocumentDescriptor Source<T>(T source) where T : class => Assign(a =>
		{
			a.Source = source;
			a.Index = a.Index ?? source.GetType();
			a.Type = a.Type ?? source.GetType();
			a.Id = a.Id ?? Nest.Id.From(source);
		});
	}

	public class SimulatePipelineDocumentsDescriptor
		: DescriptorPromiseBase<SimulatePipelineDocumentsDescriptor, IList<ISimulatePipelineDocument>>
	{
		public SimulatePipelineDocumentsDescriptor() : base(new List<ISimulatePipelineDocument>()) { }

		public SimulatePipelineDocumentsDescriptor Document(Func<SimulatePipelineDocumentDescriptor, ISimulatePipelineDocument> selector) =>
			Assign(a => a.AddIfNotNull(selector?.Invoke(new SimulatePipelineDocumentDescriptor())));
	}
}
