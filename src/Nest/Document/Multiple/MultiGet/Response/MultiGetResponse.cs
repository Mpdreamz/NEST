﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	[DataContract]
	[JsonFormatter(typeof(MultiGetResponseFormatter))]
	public class MultiGetResponse : ResponseBase
	{
		public IReadOnlyCollection<IMultiGetHit<object>> Hits => InternalHits.ToList().AsReadOnly();
		public override bool IsValid => base.IsValid && !InternalHits.HasAny(d => d.Error != null);

		internal ICollection<IMultiGetHit<object>> InternalHits { get; set; } = new List<IMultiGetHit<object>>();

		public MultiGetHit<T> Get<T>(string id) where T : class => Hits.OfType<MultiGetHit<T>>().FirstOrDefault(m => m.Id == id);

		public MultiGetHit<T> Get<T>(long id) where T : class => Get<T>(id.ToString(CultureInfo.InvariantCulture));

		public FieldValues GetFieldSelection<T>(long id) where T : class => GetFieldValues<T>(id.ToString(CultureInfo.InvariantCulture));

		public FieldValues GetFieldValues<T>(string id) where T : class
		{
			var multiHit = Get<T>(id);
			return multiHit?.Fields ?? FieldValues.Empty;
		}

		public IEnumerable<IMultiGetHit<T>> GetMany<T>(IEnumerable<string> ids) where T : class
		{
			var docs = Hits.OfType<IMultiGetHit<T>>();
			var seenIndices = new HashSet<string>();

			foreach (var id in ids)
			{
				seenIndices.Clear();
				foreach (var doc in docs)
				{
					if (string.Equals(doc.Id, id) && seenIndices.Add(doc.Index))
						yield return doc;
				}
			}
		}

		public IEnumerable<IMultiGetHit<T>> GetMany<T>(IEnumerable<long> ids) where T : class =>
			GetMany<T>(ids.Select(i => i.ToString(CultureInfo.InvariantCulture)));

		public T Source<T>(string id) where T : class
		{
			var multiHit = Get<T>(id);
			return multiHit?.Source;
		}

		public T Source<T>(long id) where T : class => Source<T>(id.ToString(CultureInfo.InvariantCulture));

		public IEnumerable<T> SourceMany<T>(IEnumerable<string> ids) where T : class
		{
			var docs = Hits.OfType<IMultiGetHit<T>>();
			var seenIndices = new HashSet<string>();

			foreach (var id in ids)
			{
				seenIndices.Clear();
				foreach (var doc in docs)
				{
					if (string.Equals(doc.Id, id) && doc.Found && seenIndices.Add(doc.Index))
						yield return doc.Source;
				}
			}
		}

		public IEnumerable<T> SourceMany<T>(IEnumerable<long> ids) where T : class =>
			SourceMany<T>(ids.Select(i => i.ToString(CultureInfo.InvariantCulture)));
	}
}
