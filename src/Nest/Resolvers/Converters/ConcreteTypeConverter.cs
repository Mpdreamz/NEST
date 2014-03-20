﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using Nest.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nest.Resolvers;

namespace Nest
{
	internal class DefaultHitConverter : JsonConverter
	{
		private static readonly ConcurrentDictionary<Type, JsonConverter> _hitTypes = new ConcurrentDictionary<Type, JsonConverter>();

		public override bool CanWrite { get { return false; } }
		public override bool CanRead { get { return true; } }


		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JsonConverter converter;
			if (_hitTypes.TryGetValue(objectType, out converter))
				return converter.ReadJson(reader, objectType, existingValue, serializer);

			var genericType = typeof(ConcreteTypeConverter<>);
			var closedType = genericType.MakeGenericType(objectType.GetGenericArguments()[0]);
			converter = (JsonConverter)closedType.CreateInstance();
			_hitTypes.TryAdd(objectType, converter);
			return converter.ReadJson(reader, objectType, existingValue, serializer);
		}

	}


	internal class ConcreteTypeConverter<T> : JsonConverter where T : class
	{
		internal readonly Type _baseType;
		internal readonly Func<dynamic, Hit<dynamic>, Type> _concreteTypeSelector;

		public override bool CanWrite { get { return false; } }
		public override bool CanRead { get { return true; } }

		public ConcreteTypeConverter() {}


		public ConcreteTypeConverter(Func<dynamic, Hit<dynamic>, Type> concreteTypeSelector)
		{
			concreteTypeSelector.ThrowIfNull("concreteTypeSelector");

			this._baseType = typeof(T);
			this._concreteTypeSelector = concreteTypeSelector;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var elasticContractResolver = serializer.ContractResolver as ElasticContractResolver;
			if (elasticContractResolver != null && elasticContractResolver.PiggyBackState != null
				&& elasticContractResolver.PiggyBackState.ActualJsonConverter != null)
			{
				var realConcreteConverter = elasticContractResolver.PiggyBackState.ActualJsonConverter as ConcreteTypeConverter<T>;
				if (realConcreteConverter != null)
					return GetUsingConcreteTypeConverter(reader, serializer, realConcreteConverter);
			}

			var instance = (Hit<T>)(typeof(Hit<T>).CreateInstance());
			serializer.Populate(reader, instance);
			instance.Fields = new FieldSelection<T>(elasticContractResolver.ConnectionSettings, instance._fields);
			return instance;
		}

		private static object GetUsingConcreteTypeConverter(JsonReader reader, JsonSerializer serializer, ConcreteTypeConverter<T> realConcreteConverter)
		{
			var jObject = CreateIntermediateJObject(reader);
			var concreteType = GetConcreteTypeUsingSelector(serializer, realConcreteConverter, jObject);
			var hit = GetHitTypeInstance(concreteType);
			PopulateHit(serializer, jObject.CreateReader(), hit);

			return hit;
		}

		private static void PopulateHit(JsonSerializer serializer, JsonReader reader, object hit) {
			serializer.Populate(reader, hit);
		}

		private static JObject CreateIntermediateJObject(JsonReader reader)
		{
			JObject jObject = JObject.Load(reader);
			return jObject;
		}

		private static object GetHitTypeInstance(Type concreteType)
		{
			var hitType = typeof (Hit<>).MakeGenericType(concreteType);
			return hitType.CreateInstance();
		}


		private static dynamic GetConcreteTypeUsingSelector(
			JsonSerializer serializer,
			ConcreteTypeConverter<T> realConcreteConverter,
			JObject jObject)
		{
			var elasticContractResolver = serializer.ContractResolver as ElasticContractResolver;
			var baseType = realConcreteConverter._baseType;
			var selector = realConcreteConverter._concreteTypeSelector;

			Hit<dynamic> hitDynamic = new Hit<dynamic>();
			dynamic d = jObject;
			var fields = jObject["fields"];
			var fieldSelection = fields != null ? fields.ToObject<IDictionary<string, object>>() : null;
			//favor manual mapping over doing Populate twice.
			hitDynamic._fields = fieldSelection;
			hitDynamic.Fields = new FieldSelection<dynamic>(elasticContractResolver.ConnectionSettings, fieldSelection);
			hitDynamic.Source = d._source;
			hitDynamic.Index = d._index;
			hitDynamic.Score = (d._score is double) ? d._score : default(double);
			hitDynamic.Type = d._type;
			hitDynamic.Version = d._version;
			hitDynamic.Id = d._id;
			hitDynamic.Sorts = d.sort;
			hitDynamic._Highlight = d.highlight is Dictionary<string, List<string>> ? d.highlight : null;
			hitDynamic.Explanation = d._explanation is Explanation ? d._explanation : null;
			object o = hitDynamic.Source ?? DynamicDictionary.Create(fieldSelection) ?? new object {};
			var concreteType = selector(o, hitDynamic);
			return concreteType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IHit<object>).IsAssignableFrom(objectType);
		}
	}
}