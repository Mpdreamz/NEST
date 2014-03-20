using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elasticsearch.Net.Serialization;
using Nest.Resolvers;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	public class NestSerializer : INestSerializer
	{
		private readonly IConnectionSettingsValues _settings;
		private readonly JsonSerializerSettings _serializationSettings;

		public NestSerializer(IConnectionSettingsValues settings)
		{
			this._settings = settings;
			this._serializationSettings = this.CreateSettings();
		}

		///// <summary>
		///// Returns a response of type R based on the connection status by trying parsing status.Result into R
		///// </summary>
		///// <returns></returns>
		//public virtual R ToParsedResponse<R>(
		//	ElasticsearchResponse<R> status, 
		//	bool notFoundIsAValidResponse = false,
		//	JsonConverter piggyBackJsonConverter = null
		//	) where R : BaseResponse
		//{
		//	var jsonSettings =piggyBackJsonConverter != null
		//		? this.CreateSettings(piggyBackJsonConverter)
		//		: this._serializationSettings;
			
		//	var isValid =
		//		(notFoundIsAValidResponse)
		//			? (status.Error == null
		//			   || status.Error.HttpStatusCode == System.Net.HttpStatusCode.NotFound)
		//			: (status.Error == null);

		//	R r;
		//	if (!isValid)
		//		r = (R)typeof (R).CreateInstance();
		//	else
		//		r = JsonConvert.DeserializeObject<R>(status.Result, jsonSettings);

		//	var baseResponse = r as BaseResponse;
		//	if (baseResponse == null)
		//		return null;
		//	baseResponse.IsValid = isValid;
		//	baseResponse.ConnectionStatus = status;
		//	return r;
		//}
	
		public virtual byte[] Serialize(object data, SerializationFormatting formatting = SerializationFormatting.Indented)
		{
			var format = formatting == SerializationFormatting.None ? Formatting.None : Formatting.Indented;
			var serialized = JsonConvert.SerializeObject(data, format, this._serializationSettings);
			return serialized.Utf8Bytes();
		}

		/// <summary>
		/// Deserialize an object 
		/// </summary>
		public virtual T Deserialize<T>(IElasticsearchResponse response, Stream stream, object deserializationState = null) 
		{
			var settings = this._serializationSettings;
			var customConverter = deserializationState as Func<IElasticsearchResponse, Stream, T>;
			if (customConverter != null)
			{
				var t = customConverter(response, stream);
				return t;
			}

			var state = deserializationState as JsonConverter;
			if (state != null)
				settings = this.CreateSettings(state);

			return _Deserialize<T>(response, stream, settings);
		}

		/// <summary>
		/// Deserialize to type T bypassing checks for custom deserialization state and or BaseResponse return types.
		/// </summary>
		public T DeserializeInternal<T>(Stream stream)
		{
			var serializer = JsonSerializer.Create(this._serializationSettings);
			var jsonTextReader = new JsonTextReader(new StreamReader(stream));
			var t = (T) serializer.Deserialize(jsonTextReader, typeof (T));
			return t;
			
		}

		protected internal  T _Deserialize<T>(IElasticsearchResponse response, Stream stream, JsonSerializerSettings settings = null)
		{
			settings = settings ?? _serializationSettings;
			var serializer = JsonSerializer.Create(settings);
			var jsonTextReader = new JsonTextReader(new StreamReader(stream));
			var t = (T) serializer.Deserialize(jsonTextReader, typeof (T));
			var r = t as BaseResponse;
			if (r != null)
			{
				r.ConnectionStatus = response;
			}
			return t;
		}

		public virtual Task<T> DeserializeAsync<T>(IElasticsearchResponse response, Stream stream, object deserializationState = null)
		{
			//TODO sadly json .net async does not read the stream async so 
			//figure out wheter reading the stream async on our own might be beneficial 
			//over memory possible memory usage
			var tcs = new TaskCompletionSource<T>();
			var r = this.Deserialize<T>(response, stream, deserializationState);
			tcs.SetResult(r);
			return tcs.Task;
		}
		
		internal JsonSerializerSettings CreateSettings(JsonConverter piggyBackJsonConverter = null)
		{
			var piggyBackState = new JsonConverterPiggyBackState { ActualJsonConverter = piggyBackJsonConverter };
			var settings = new JsonSerializerSettings()
			{
				ContractResolver = new ElasticContractResolver(this._settings) { PiggyBackState = piggyBackState },
				DefaultValueHandling = DefaultValueHandling.Include,
				NullValueHandling = NullValueHandling.Ignore
			};

			if (_settings.ModifyJsonSerializerSettings != null)
				_settings.ModifyJsonSerializerSettings(settings);

			return settings;
		}

		public string SerializeBulkDescriptor(BulkDescriptor bulkDescriptor)
		{
			bulkDescriptor.ThrowIfNull("bulkDescriptor");
			bulkDescriptor._Operations.ThrowIfEmpty("Bulk descriptor does not define any operations");
			var sb = new StringBuilder();
			var inferrer = new ElasticInferrer(this._settings);

			foreach (var operation in bulkDescriptor._Operations)
			{
				var command = operation._Operation;
				var index = operation._Index
				            ?? inferrer.IndexName(bulkDescriptor._Index)
				            ?? inferrer.IndexName(operation._ClrType);
				var typeName = operation._Type
				               ?? inferrer.TypeName(bulkDescriptor._Type)
				               ?? inferrer.TypeName(operation._ClrType);

				var id = operation.GetIdForObject(inferrer);
				operation._Index = index;
				operation._Type = typeName;
				operation._Id = id;

				var opJson = this.Serialize(operation, SerializationFormatting.None).Utf8String();

				var action = "{{ \"{0}\" :  {1} }}\n".F(command, opJson);
				sb.Append(action);

				if (command == "index" || command == "create")
				{
					var jsonCommand = this.Serialize(operation._Object, SerializationFormatting.None).Utf8String();
					sb.Append(jsonCommand + "\n");
				}
				else if (command == "update")
				{
					var jsonCommand = this.Serialize(operation.GetBody(), SerializationFormatting.None).Utf8String();
					sb.Append(jsonCommand + "\n");
				}
			}
			var json = sb.ToString();
			return json;
		}
	
		/// <summary>
		/// _msearch needs a specialized json format in the body
		/// </summary>
		public string SerializeMultiSearch(MultiSearchDescriptor multiSearchDescriptor)
		{
			var sb = new StringBuilder();
			var inferrer = new ElasticInferrer(this._settings);
			foreach (var operation in multiSearchDescriptor._Operations.Values)
			{
				var indices = inferrer.IndexNames(operation._Indices);
				if (operation._AllIndices.GetValueOrDefault(false))
					indices = "_all";

				var index = indices 
				            ?? inferrer.IndexName(multiSearchDescriptor._Index)
				            ?? inferrer.IndexName(operation._ClrType);

				var types = inferrer.TypeNames(operation._Types);
				var typeName = types
				               ?? inferrer.TypeName(multiSearchDescriptor._Type)
				               ?? inferrer.TypeName(operation._ClrType);
				if (operation._AllTypes.GetValueOrDefault(false))
					typeName = null; //force empty typename so we'll query all types.

				var op = new
				{
					index = index,
					type = typeName,
					search_type = this.GetSearchType(operation, multiSearchDescriptor),
					preference = operation._Preference,
					routing = operation._Routing
				};
				var opJson = this.Serialize(op, SerializationFormatting.None).Utf8String();

				var action = "{0}\n".F(opJson);
				sb.Append(action);
				var searchJson = this.Serialize(operation, SerializationFormatting.None).Utf8String();
				sb.Append(searchJson + "\n");

			}
			var json = sb.ToString();
			return json;
		}

		
		protected string GetSearchType(SearchDescriptorBase descriptor, MultiSearchDescriptor multiSearchDescriptor)
		{
			if (descriptor._SearchType != null)
			{
				switch (descriptor._SearchType.Value)
				{
					case SearchTypeOptions.Count:
						return "count";
					case SearchTypeOptions.DfsQueryThenFetch:
						return "dfs_query_then_fetch";
					case SearchTypeOptions.DfsQueryAndFetch:
						return "dfs_query_and_fetch";
					case SearchTypeOptions.QueryThenFetch:
						return "query_then_fetch";
					case SearchTypeOptions.QueryAndFetch:
						return "query_and_fetch";
					case SearchTypeOptions.Scan:
						return "scan";
				}
			}
			return multiSearchDescriptor._QueryString.ContainsKey("search_type")
				? multiSearchDescriptor._QueryString._QueryStringDictionary["search_type"] as string
				: null;
		}

	}
}