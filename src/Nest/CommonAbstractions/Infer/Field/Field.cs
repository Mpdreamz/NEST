﻿using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using Elasticsearch.Net;

namespace Nest
{
	[ContractJsonConverter(typeof(FieldJsonConverter))]
	public class Field : IEquatable<Field>, IUrlParameter
	{
		public string Name { get; set; }
		public Expression Expression { get; set; }
		public PropertyInfo Property { get; set; }
		public double? Boost { get; set; }

		private object ComparisonValue { get; set; }

		public Fields And<T>(Expression<Func<T, object>> field) where T : class =>
			new Fields(new [] { this, field });

		public Fields And(string field) => new Fields(new [] { this, field });

		public static Field Create(string name, double? boost = null)
		{
			if (name.IsNullOrEmpty()) return null;

			double? b;
			Field field = ParseFieldName(name, out b);
			field.Boost = b ?? boost;
			return field;
		}

		public static Field Create(Expression expression, double? boost = null)
		{
			Field field = expression;
			field.Boost = boost;
			return field;
		}

		private static string ParseFieldName(string name, out double? boost)
		{
			boost = null;
			var parts = name.Split(new [] { '^' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length > 1)
			{
				name = parts[0];
				boost = Double.Parse(parts[1], CultureInfo.InvariantCulture);
			}
			return name;
		}

		public static implicit operator Field(string name)
		{
			if (name.IsNullOrEmpty()) return null;

			double? boost;
			name = ParseFieldName(name, out boost);
			return  new Field
			{
				Name = name,
				ComparisonValue = name,
				Boost = boost
				
			};
		}

		public static implicit operator Field(Expression expression)
		{
			if (expression == null) return null;

			var lambda = expression as LambdaExpression;
			if (lambda == null)
				return new Field { Expression = expression, ComparisonValue = expression.ToString() }; 

			var memberExpression = lambda.Body as MemberExpression;
			if (memberExpression == null)
				return new Field { Expression = expression, ComparisonValue = expression.ToString() }; 
			
			return new Field { Expression = expression, ComparisonValue = memberExpression}; 
		}

		public static implicit operator Field(PropertyInfo property)
		{
			return property == null ? null : new Field
			{
				Property = property,
				ComparisonValue = property
			};
		}

		public override int GetHashCode() => ComparisonValue?.GetHashCode() ?? 0;

		bool IEquatable<Field>.Equals(Field other) => Equals(other);

		public override bool Equals(object obj)
		{
			var other = obj as Field;
			if (other == null)
				return false;
			return ComparisonValue.Equals(other.ComparisonValue);
		}

		string IUrlParameter.GetString(IConnectionConfigurationValues settings)
		{
			var nestSettings = settings as IConnectionSettingsValues;
			if (nestSettings == null)
				throw new Exception("Tried to pass field name on querysting but it could not be resolved because no nest settings are available");
			var infer = new Inferrer(nestSettings);
			return infer.Field(this);
		}
	}
}
