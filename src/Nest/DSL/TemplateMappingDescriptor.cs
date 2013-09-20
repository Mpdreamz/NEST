﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Nest.Resolvers;
using Nest.Domain;

namespace Nest
{
	public class TemplateMappingDescriptor
	{
		private readonly IConnectionSettings _connectionSettings;

		internal string _Name { get; set; }
		internal TemplateMapping _TemplateMapping { get; set; }
    private readonly ElasticSerializer _serializer;

		public TemplateMappingDescriptor(IConnectionSettings connectionSettings)
		{
			this._TemplateMapping = new TemplateMapping();
			this._connectionSettings = connectionSettings;
      this._serializer = new ElasticSerializer(this._connectionSettings);
		}

		public TemplateMappingDescriptor Name(string name)
		{
			name.ThrowIfNull("name");
			this._Name = name;
			return this;
		}

		/// <summary>
		/// Initialize the descriptor using the values from for instance a previous Get Template Mapping call.
		/// </summary>
		public TemplateMappingDescriptor InitializeUsing(TemplateMapping templateMapping)
		{
			this._TemplateMapping = templateMapping;
			return this;
		}

		public TemplateMappingDescriptor Order(int order)
		{
			this._TemplateMapping.Order = order;
			return this;
		}

		public TemplateMappingDescriptor Template(string template)
		{
			template.ThrowIfNull("name");
			this._TemplateMapping.Template = template;
			return this;
		}

		public TemplateMappingDescriptor Settings(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> settingsSelector)
		{
			settingsSelector.ThrowIfNull("settingsDescriptor");
			this._TemplateMapping.Settings = settingsSelector(this._TemplateMapping.Settings ?? new FluentDictionary<string, object>());
			return this;

		}

		public TemplateMappingDescriptor AddMapping<T>(Func<RootObjectMappingDescriptor<T>, RootObjectMappingDescriptor<T>> mappingSelector)
			where T : class
		{
			mappingSelector.ThrowIfNull("mappingSelector");
			var rootObjectMappingDescriptor = mappingSelector(new RootObjectMappingDescriptor<T>(this._connectionSettings));
			rootObjectMappingDescriptor.ThrowIfNull("rootObjectMappingDescriptor");

			var typeName = rootObjectMappingDescriptor._TypeName.Resolve(this._connectionSettings);
			this._TemplateMapping.Mappings[typeName] = rootObjectMappingDescriptor._Mapping;
			return this;

		}
		public TemplateMappingDescriptor RemoveMapping<T>()
			where T : class
		{
			var typeName = new TypeNameMarker { Type = typeof(T) }.Resolve(this._connectionSettings);
			this._TemplateMapping.Mappings.Remove(typeName);
			return this;
		}
		public TemplateMappingDescriptor RemoveMapping(string typeName)
		{
			typeName.ThrowIfNull("typeName");
			this._TemplateMapping.Mappings.Remove(typeName);
			return this;
		}

		public TemplateMappingDescriptor AddWarmer<T>(Func<CreateWarmerDescriptor, CreateWarmerDescriptor> warmerSelector)
			where T : class
		{
			warmerSelector.ThrowIfNull("warmerSelector");
			var warmerDescriptor = warmerSelector(new CreateWarmerDescriptor());
			warmerDescriptor.ThrowIfNull("warmerDescriptor");
			warmerDescriptor._WarmerName.ThrowIfNull("warmer has no name");

      var query = this._serializer.Serialize(warmerDescriptor._SearchDescriptor);

			var warmer = new WarmerMapping { Name = warmerDescriptor._WarmerName, Types = warmerDescriptor._Types, Source = query };

			this._TemplateMapping.Warmers[warmerDescriptor._WarmerName] = warmer;
			return this;

		}
		public TemplateMappingDescriptor RemoveWarmer<T>()
			where T : class
		{
			var typeName = new TypeNameMarker { Type = typeof(T) }.Resolve(this._connectionSettings);
			this._TemplateMapping.Warmers.Remove(typeName);
			return this;
		}
		public TemplateMappingDescriptor RemoveWarmer(string typeName)
		{
			this._TemplateMapping.Warmers.Remove(typeName);
			return this;

		}


	}
}
