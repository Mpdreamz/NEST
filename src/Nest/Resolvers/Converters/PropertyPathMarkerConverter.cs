﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace Nest.Resolvers.Converters
{

    public class FieldMappingOuterClassConverter : JsonConverter
    {
        private readonly FieldMappingOuterClass _infer;
        public FieldMappingOuterClassConverter(FieldMappingOuterClass a)
        {
            _infer = a;
        }
        public FieldMappingOuterClassConverter()
        {

        }

        public override bool CanRead { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return true; //only to be used with attribute or contract registration.
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var marker = value as FieldMappingOuterClass;
            if (marker == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(this._infer.field_mapping);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

    }
    public class PropertyPathMarkerConverter : JsonConverter
    {
        private readonly ElasticInferrer _infer;
        public PropertyPathMarkerConverter(IConnectionSettingsValues connectionSettings)
        {
            _infer = new ElasticInferrer(connectionSettings);
        }

        public override bool CanRead { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return true; //only to be used with attribute or contract registration.
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var marker = value as PropertyPathMarker;
            if (marker == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(this._infer.PropertyPath(marker));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

    }
    public class PropertyNameMarkerConverter : JsonConverter
    {
        private readonly ElasticInferrer _infer;
        public PropertyNameMarkerConverter(IConnectionSettingsValues connectionSettings)
        {
            _infer = new ElasticInferrer(connectionSettings);
        }

        public override bool CanRead { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return true; //only to be used with attribute or contract registration.
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var marker = value as PropertyNameMarker;
            if (marker == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(this._infer.PropertyName(marker));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

    }
}

