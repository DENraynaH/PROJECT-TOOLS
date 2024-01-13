using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LayerMaskConverter : JsonConverter<LayerMask>
{
    public override void WriteJson(JsonWriter writer, LayerMask value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "value", value.value }
        };
        obj.WriteTo(writer);
    }

    public override LayerMask ReadJson(JsonReader reader, Type objectType, LayerMask existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            int value = obj.GetValue("value").Value<int>();

            return new LayerMask { value = value };
        }

        return new LayerMask();
    }
}