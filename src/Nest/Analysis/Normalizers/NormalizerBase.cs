﻿using System.Runtime.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	[JsonFormatter(typeof(NormalizerFormatter))]
	public interface INormalizer
	{
		[DataMember(Name = "type")]
		string Type { get; }

		[DataMember(Name = "version")]
		string Version { get; set; }
	}

	public abstract class NormalizerBase : INormalizer
	{
		internal NormalizerBase() { }

		protected NormalizerBase(string type) => Type = type;

		public virtual string Type { get; protected set; }

		public string Version { get; set; }
	}

	public abstract class NormalizerDescriptorBase<TNormalizer, TNormalizerInterface>
		: DescriptorBase<TNormalizer, TNormalizerInterface>, INormalizer
		where TNormalizer : NormalizerDescriptorBase<TNormalizer, TNormalizerInterface>, TNormalizerInterface
		where TNormalizerInterface : class, INormalizer
	{
		protected abstract string Type { get; }
		string INormalizer.Type => Type;
		string INormalizer.Version { get; set; }

		public TNormalizer Version(string version) => Assign(version, (a, v) => a.Version = v);
	}
}
