﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Newtonsoft.Json;
using Shared.Extensions;
using Elasticsearch.Net;
using Nest.Resolvers;

namespace Nest
{
	public partial class UpdateDescriptor<T,K> : DocumentPathDescriptorBase<UpdateDescriptor<T, K>, T, UpdateRequestParameters> 
		, IPathInfo<UpdateRequestParameters> 
		where T : class 
		where K : class
	{



		[JsonProperty(PropertyName = "script")]
		internal string _Script { get; set; }

		[JsonProperty(PropertyName = "params")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		internal Dictionary<string, object> _Params { get; set; }

		[JsonProperty(PropertyName = "upsert")]
		internal object _Upsert { get; set; }

		[JsonProperty(PropertyName = "doc_as_upsert")]
		internal bool? _DocAsUpsert { get; set; }

		[JsonProperty(PropertyName = "doc")]
		internal K _Document { get; set; }

		
		public UpdateDescriptor<T, K> Script(string script)
		{
			script.ThrowIfNull("script");
			this._Script = script;
			return this;
		}

		public UpdateDescriptor<T, K> Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramDictionary)
		{
			paramDictionary.ThrowIfNull("paramDictionary");
			this._Params = paramDictionary(new FluentDictionary<string, object>());
			return this;
		}

		/// <summary>
		/// The full document to be created if an existing document does not exist for a partial merge.
		/// </summary>
		public UpdateDescriptor<T, K> Upsert(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> upsertValues)
		{
			upsertValues.ThrowIfNull("upsertValues");
			this._Upsert = upsertValues(new FluentDictionary<string, object>());
			return this;
		}

		/// <summary>
		/// The full document to be created if an existing document does not exist for a partial merge.
		/// </summary>
		public UpdateDescriptor<T, K> Upsert(T upsertObject)
		{
			upsertObject.ThrowIfNull("upsertObject");
			this._Upsert = upsertObject;
			return this;
		}

		/// <summary>
		/// The partial update document to be merged on to the existing object.
		/// </summary>
		public UpdateDescriptor<T, K> Document(K @object)
		{
			this._Document = @object;
			return this;
		}

		public UpdateDescriptor<T, K> DocAsUpsert(bool docAsUpsert = true)
		{
			this._DocAsUpsert = docAsUpsert;
			return this;
		}

		ElasticsearchPathInfo<UpdateRequestParameters> IPathInfo<UpdateRequestParameters>.ToPathInfo(IConnectionSettingsValues settings)
		{
			if (this._Document != null && this._Id == null)
				this._Id = new ElasticInferrer(settings).Id(this._Document);

			var pathInfo = base.ToPathInfo(settings, this._QueryString);
			pathInfo.RequestParameters = this._QueryString;
			pathInfo.HttpMethod = PathInfoHttpMethod.POST;
			
			return pathInfo;
		}
	}
}
