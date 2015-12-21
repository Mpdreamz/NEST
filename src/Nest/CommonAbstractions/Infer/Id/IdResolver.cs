﻿using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Nest
{
	public class IdResolver
	{
		private readonly IConnectionSettingsValues _connectionSettings;
		private readonly ConcurrentDictionary<Type, Func<object, string>> LocalIdDelegates = new ConcurrentDictionary<Type, Func<object, string>>();
		private static readonly ConcurrentDictionary<Type, Func<object, string>> IdDelegates = new ConcurrentDictionary<Type, Func<object, string>>();
		private static readonly MethodInfo MakeDelegateMethodInfo = typeof(IdResolver).GetMethod("MakeDelegate", BindingFlags.Static | BindingFlags.NonPublic);

		PropertyInfo GetPropertyCaseInsensitive(Type type, string fieldName)
			=> type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

		public IdResolver(IConnectionSettingsValues connectionSettings)
		{
			_connectionSettings = connectionSettings;
		}

		internal Func<T, string> CreateIdSelector<T>() where T : class
		{
			Func<T, string> idSelector = this.GetIdFor;
			return idSelector;
		}

		internal static Func<object, object> MakeDelegate<T, U>(MethodInfo @get)
		{
			var f = (Func<T, U>)Delegate.CreateDelegate(typeof(Func<T, U>), @get);
			return t => f((T)t);
		}

		public string GetIdFor(Type type, object @object)
		{
			Func<object, string> cachedLookup;
			string field;

			var preferLocal = this._connectionSettings.IdProperties.TryGetValue(type, out field);

			if (LocalIdDelegates.TryGetValue(type, out cachedLookup))
				return cachedLookup(@object);

			if (!preferLocal && IdDelegates.TryGetValue(type, out cachedLookup))
				return cachedLookup(@object);

			var idProperty = GetInferredId(type);
			if (idProperty == null)
			{
				return null;
			}
			var getMethod = idProperty.GetGetMethod();
			var generic = MakeDelegateMethodInfo.MakeGenericMethod(type, getMethod.ReturnType);
			var func = (Func<object, object>)generic.Invoke(null, new[] { getMethod });
			cachedLookup = o =>
			{
				var v = func(o);
				return v?.ToString();
			};
			if (preferLocal)
				LocalIdDelegates.TryAdd(type, cachedLookup);
			else
				IdDelegates.TryAdd(type, cachedLookup);
			return cachedLookup(@object);
		}

		public string GetIdFor<T>(T @object)
		{
			if (@object == null)
				return null;

			//var type = typeof(T);
			return GetIdFor(@object.GetType(), @object);
		}

		private PropertyInfo GetInferredId(Type type)
		{
			// if the type specifies through ElasticAttribute what the id prop is 
			// use that no matter what

			string propertyName;

			this._connectionSettings.IdProperties.TryGetValue(type, out propertyName);
			if (!propertyName.IsNullOrEmpty())
				return GetPropertyCaseInsensitive(type, propertyName);

			var esTypeAtt = ElasticsearchTypeAttribute.From(type);
			propertyName = (esTypeAtt?.IdProperty.IsNullOrEmpty() ?? true) ? "Id" : esTypeAtt?.IdProperty;

			return GetPropertyCaseInsensitive(type, propertyName);
		}
	}
}
