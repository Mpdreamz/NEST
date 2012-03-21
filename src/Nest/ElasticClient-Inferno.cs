﻿using System;
using Fasterflect;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Nest.Resolvers;

namespace Nest
{

	public partial class ElasticClient
	{
		private Regex _bulkReplace = new Regex(@",\n|^\[", RegexOptions.Compiled | RegexOptions.Multiline);

		private Func<T, string> CreateIdSelector<T>() where T : class
		{
			Func<T, string> idSelector = null;
			var type = typeof(T);
			var idProperty = type.GetProperty("Id");
			if (idProperty != null)
			{
				if (idProperty.PropertyType == typeof(int))
					idSelector = (@object) => ((int)@object.TryGetPropertyValue("Id")).ToString();
				else if (idProperty.PropertyType == typeof(int?))
					idSelector = (@object) =>
					{
						int? val = (int?)@object.TryGetPropertyValue("Id");
						return (val.HasValue) ? val.Value.ToString() : string.Empty;
					};
				else if (idProperty.PropertyType == typeof(string))
					idSelector = (@object) => (string)@object.TryGetPropertyValue("Id");
				else
					idSelector = (@object) => (string)Convert.ChangeType(@object.TryGetPropertyValue("Id"), typeof(string), CultureInfo.InvariantCulture);
			}
			return idSelector;
		}

		private string CreatePathFor<T>(T @object) where T : class
		{
			var index = this.Settings.DefaultIndex;
			if (string.IsNullOrEmpty(index))
				throw new NullReferenceException("Cannot infer default index for current connection.");
			return this.CreatePathFor<T>(@object, index);

		}
		private string CreatePathFor<T>(T @object, string index) where T : class
		{
			//var type = typeof(T);
			var typeName = this.InferTypeName<T>();
			return this.CreatePathFor<T>(@object, index, typeName);
			
		}
		private string CreatePathFor<T>(T @object, string index, string type) where T : class
		{
			@object.ThrowIfNull("object");
			index.ThrowIfNull("index");
			type.ThrowIfNull("type");

			var path = this.CreatePath(index, type);

			var id = this.GetIdFor<T>(@object);
			if (!string.IsNullOrEmpty(id))
				path = this.CreatePath(index, type, id);

			return path;

		}
		private string CreatePathFor<T>(T @object, string index, string type, string id) where T : class
		{
			@object.ThrowIfNull("object");
			index.ThrowIfNull("index");
			type.ThrowIfNull("type");

			return this.CreatePath(index, type, id);
		}

		private string GetIdFor<T>(T @object)
		{
			var type = typeof(T);
			var idProperty = type.GetProperty("Id");
			string idString = null;

			if (idProperty != null)
			{
				object value = idProperty.GetValue(@object, null);

				if (value != null)
				{
					idString = value.ToString();
				}
			}

			return idString;
		}

		public static string GetTypeNameFor(Type type)
		{
			if (!type.IsClass && !type.IsInterface)
				throw new ArgumentException("Type is not a class or interface", "type");
			return GetTypeNameForType(type);
		}

		public static string GetTypeNameFor<T>() where T : class
		{
			return GetTypeNameForType(typeof(T));
		}

		private static string GetTypeNameForType(Type type)
		{
			var typeName = type.Name;
			var att = PropertyNameResolver.GetElasticPropertyFor(type);
			if (att != null && !att.Name.IsNullOrEmpty())
				typeName = att.Name;
			else
				typeName = Inflector.MakePlural(type.Name).ToLower();

			return typeName;
		}

		private string InferTypeName<T>() where T : class
		{
			var type = typeof(T);
			var typeName = type.Name;
			var att = PropertyNameResolver.GetElasticPropertyFor<T>();
			if (att != null && !att.Name.IsNullOrEmpty())
				typeName = att.Name;
			else
			{ 
				if (this.Settings.TypeNameInferrer != null)
					typeName = this.Settings.TypeNameInferrer(typeName);
				if (this.Settings.TypeNameInferrer == null || string.IsNullOrEmpty(typeName))
					typeName = Inflector.MakePlural(type.Name).ToLower();
			}
			return typeName;
		}
		private string CreatePath(string index)
		{
			return "{0}/".F(index);
		}
		private string CreatePath(string index, string type)
		{
			return "{0}/{1}/".F(index, type);
		}
		private string CreatePath(string index, string type, string id)
		{
			return "{0}/{1}/{2}".F(index, type, id);
		}

		private string GenerateBulkIndexCommand<T>(IEnumerable<T> objects) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, "index");
		}
		private string GenerateBulkIndexCommand<T>(IEnumerable<BulkParameters<T>> objects) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, "index");
		}
		private string GenerateBulkIndexCommand<T>(IEnumerable<T> objects, string index) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, "index");
		}
		private string GenerateBulkIndexCommand<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, "index");
		}
		private string GenerateBulkIndexCommand<T>(IEnumerable<T> @objects, string index, string typeName) where T : class 
		{
			return this.GenerateBulkCommand<T>(@objects, index, typeName, "index");
		}
		private string GenerateBulkIndexCommand<T>(IEnumerable<BulkParameters<T>> @objects, string index, string typeName) where T : class 
		{
			return this.GenerateBulkCommand<T>(@objects, index, typeName, "index");
		}

		private string GenerateBulkDeleteCommand<T>(IEnumerable<T> objects) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, "delete");
		}
		private string GenerateBulkDeleteCommand<T>(IEnumerable<BulkParameters<T>> objects) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, "delete");
		}
		private string GenerateBulkDeleteCommand<T>(IEnumerable<T> objects, string index) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, "delete");
		}
		private string GenerateBulkDeleteCommand<T>(IEnumerable<BulkParameters<T>> objects, string index) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, "delete");
		}
		private string GenerateBulkDeleteCommand<T>(IEnumerable<T> @objects, string index, string typeName) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, typeName, "delete");
		}
		private string GenerateBulkDeleteCommand<T>(IEnumerable<BulkParameters<T>> @objects, string index, string typeName) where T : class
		{
			return this.GenerateBulkCommand<T>(@objects, index, typeName, "delete");
		}

		private string GenerateBulkCommand<T>(IEnumerable<T> objects, string command) where T : class
		{
			objects.ThrowIfNull("objects");

			var index = this.Settings.DefaultIndex;
			if (string.IsNullOrEmpty(index))
				throw new NullReferenceException("Cannot infer default index for current connection.");

			return this.GenerateBulkCommand<T>(objects, index, command);
		}
		private string GenerateBulkCommand<T>(IEnumerable<BulkParameters<T>> objects, string command) where T : class
		{
			objects.ThrowIfNull("objects");

			var index = this.Settings.DefaultIndex;
			if (string.IsNullOrEmpty(index))
				throw new NullReferenceException("Cannot infer default index for current connection.");

			return this.GenerateBulkCommand<T>(objects, index, command);
		}
		private string GenerateBulkCommand<T>(IEnumerable<T> objects, string index, string command) where T : class
		{
			objects.ThrowIfNull("objects");
			index.ThrowIfNullOrEmpty("index");

			var type = typeof(T);
			var typeName = this.InferTypeName<T>();

			return this.GenerateBulkCommand<T>(objects, index, typeName, command);
		}
		private string GenerateBulkCommand<T>(IEnumerable<BulkParameters<T>> objects, string index, string command) where T : class
		{
			objects.ThrowIfNull("objects");
			index.ThrowIfNullOrEmpty("index");

			var type = typeof(T);
			var typeName = this.InferTypeName<T>();

			return this.GenerateBulkCommand<T>(objects, index, typeName, command);
		}


		private string GenerateBulkCommand<T>(IEnumerable<T> @objects, string index, string typeName, string command) where T : class
		{
			if (!@objects.Any())
				return null;

			var idSelector = this.CreateIdSelector<T>();

			var sb = new StringBuilder();
			var action = "{{ \"{0}\" : {{ \"_index\" : \"{1}\", \"_type\" : \"{2}\"".F(command, index, typeName);

			foreach (var @object in objects)
			{
				var objectAction = action;
				if (idSelector != null)
					objectAction += ", \"_id\" : \"{0}\" ".F(idSelector(@object));

				objectAction += "} }\n";

				sb.Append(objectAction);
				if (command == "index")
				{
					string jsonCommand = JsonConvert.SerializeObject(@object, Formatting.None, SerializationSettings);
					sb.Append(jsonCommand + "\n");
				}
			}
			var json = sb.ToString();
			return json;


			
		}
		private string GenerateBulkCommand<T>(IEnumerable<BulkParameters<T>> @objects, string index, string typeName, string command) where T : class
		{
			if (!@objects.Any())
				return null;

			var idSelector = this.CreateIdSelector<T>();

			var sb = new StringBuilder();
			var action = "{{ \"{0}\" : {{ \"_index\" : \"{1}\", \"_type\" : \"{2}\"".F(command, index, typeName);

			foreach (var @object in objects)
			{
				if (@object.Document == null)
					continue;

				var objectAction = action;
				if (idSelector != null)
					objectAction += ", \"_id\" : \"{0}\" ".F(idSelector(@object.Document));

				if (!@object.Version.IsNullOrEmpty())
					objectAction += ", \"version\" : \"{0}\" ".F(@object.Version);
				if (!@object.Parent.IsNullOrEmpty())
					objectAction += ", \"parent\" : \"{0}\" ".F(@object.Parent);
				if (@object.VersionType != VersionType.Internal)
					objectAction += ", \"version_type\" : \"{0}\" ".F(@object.VersionType.ToString().ToLower());
				if (!@object.Routing.IsNullOrEmpty())
					objectAction += ", \"routing\" : \"{0}\" ".F(@object.Routing);
				objectAction += "} }\n";

				sb.Append(objectAction);
				if (command == "index")
				{
					string jsonCommand = JsonConvert.SerializeObject(@object.Document, Formatting.None, SerializationSettings);
					sb.Append(jsonCommand + "\n");
				}
			}
			var json = sb.ToString();
			return json;
		}
	
		private string AppendSimpleParametersToPath(string path, ISimpleUrlParameters urlParameters)
		{
			if (urlParameters == null)
				return path;

			var parameters = new List<string>();

			if (urlParameters.Replication != Replication.Sync) //sync == default
				parameters.Add("replication=" + urlParameters.Replication.ToString().ToLower());

			
			if (urlParameters.Refresh) //false == default
				parameters.Add("refresh=true");

			path += "?" + string.Join("&", parameters.ToArray());
			return path;
		}
		private string AppendDeleteByQueryParametersToPath(string path, DeleteByQueryParameters urlParameters)
		{
			if (urlParameters == null)
				return path;

			var parameters = new List<string>();

			if (urlParameters.Replication != Replication.Sync) //sync == default
				parameters.Add("replication=" + urlParameters.Replication.ToString().ToLower());

			if (urlParameters.Consistency != Consistency.Quorum) //quorum == default
				parameters.Add("consistency=" + urlParameters.Replication.ToString().ToLower());

			if (!urlParameters.Routing.IsNullOrEmpty()) 
				parameters.Add("routing=" + urlParameters.Routing);

			path += "?" + string.Join("&", parameters.ToArray());
			return path;
		}
		private string AppendParametersToPath(string path, IUrlParameters urlParameters)
		{
			if (urlParameters == null)
				return path;

			var parameters = new List<string>();

			if (!urlParameters.Version.IsNullOrEmpty())
				parameters.Add("version=" + urlParameters.Version);
			if (!urlParameters.Routing.IsNullOrEmpty())
				parameters.Add("routing=" + urlParameters.Routing);
			if (!urlParameters.Parent.IsNullOrEmpty())
				parameters.Add("parent=" + urlParameters.Parent);

			if (urlParameters.Replication != Replication.Sync) //sync == default
				parameters.Add("replication=" + urlParameters.Replication.ToString().ToLower());

			if (urlParameters.Consistency != Consistency.Quorum) //quorum == default
				parameters.Add("consistency=" + urlParameters.Consistency.ToString().ToLower());

			if (urlParameters.Refresh) //false == default
				parameters.Add("refresh=true");

			if (urlParameters is IndexParameters)
				this.AppendIndexParameters(parameters, (IndexParameters)urlParameters);

			path += "?" + string.Join("&", parameters.ToArray());
			return path;
		}

		private List<string> AppendIndexParameters(List<string> parameters, IndexParameters indexParameters)
		{
			if (indexParameters == null)
				return parameters;

			if (!indexParameters.Timeout.IsNullOrEmpty())
				parameters.Add("timeout=" + indexParameters.Timeout);

			if (indexParameters.VersionType != VersionType.Internal) //internal == default
				parameters.Add("version_type=" + indexParameters.VersionType.ToString().ToLower());

			return parameters;
		}

		private string GetPathForDynamic(SearchDescriptor<dynamic> descriptor)
		{
			var indices = this.Settings.DefaultIndex;
			if (descriptor._Indices.HasAny())
				indices = string.Join(",", descriptor._Indices);
			else if (descriptor._Indices != null || descriptor._AllIndices) //if set to empty array asume all
				indices = "_all";

			string types = (descriptor._Types.HasAny()) ? string.Join(",", descriptor._Types) : null;

			return this.PathJoin(indices, types, descriptor._Routing);
		}
		private string GetPathForTyped<T>(SearchDescriptor<T> descriptor) where T : class
		{
			var indices = this.Settings.DefaultIndex;
			if (descriptor._Indices.HasAny())
				indices = string.Join(",", descriptor._Indices);
			else if (descriptor._Indices != null || descriptor._AllIndices) //if set to empty array asume all
				indices = "_all";

			var types = this.InferTypeName<T>();
			if (descriptor._Types.HasAny())
				types = string.Join(",", descriptor._Types);
			else if (descriptor._Types != null || descriptor._AllTypes) //if set to empty array assume all
				types = null;

			return this.PathJoin(indices, types, descriptor._Routing);
		}
		private string GetPathForDynamic(QueryPathDescriptor<dynamic> descriptor)
		{
			var indices = this.Settings.DefaultIndex;
			if (descriptor._Indices.HasAny())
				indices = string.Join(",", descriptor._Indices);
			else if (descriptor._Indices != null || descriptor._AllIndices) //if set to empty array asume all
				indices = "_all";

			string types = (descriptor._Types.HasAny()) ? string.Join(",", descriptor._Types) : null;

			return this.PathJoin(indices, types, descriptor._Routing, "_query");
		}
		private string GetPathForTyped<T>(QueryPathDescriptor<T> descriptor) where T : class
		{
			var indices = this.Settings.DefaultIndex;
			if (descriptor._Indices.HasAny())
				indices = string.Join(",", descriptor._Indices);
			else if (descriptor._Indices != null || descriptor._AllIndices) //if set to empty array asume all
				indices = "_all";

			var types = this.InferTypeName<T>();
			if (descriptor._Types.HasAny())
				types = string.Join(",", descriptor._Types);
			else if (descriptor._Types != null || descriptor._AllTypes) //if set to empty array assume all
				types = null;

			return this.PathJoin(indices, types, descriptor._Routing, "_query");
		}
		private string PathJoin(string indices, string types, string routing, string extension = "_search")
		{
			string path = string.Concat(!string.IsNullOrEmpty(types) ?
											 this.CreatePath(indices, types) :
											 this.CreatePath(indices), extension);
			if (!String.IsNullOrEmpty(routing))
			{
				path = "{0}?routing={1}".F(path, routing);
			}
			return path;
		}

	}
}
