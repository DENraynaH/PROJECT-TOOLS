using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Vector4Converter : JsonConverter<Vector4>
{
    public override void WriteJson(JsonWriter writer, Vector4 value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "x", value.x },
            { "y", value.y },
            { "z", value.z },
            { "w", value.w }
        };
        obj.WriteTo(writer);
    }

    public override Vector4 ReadJson(JsonReader reader, Type objectType, Vector4 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            float x = obj.GetValue("x").Value<float>();
            float y = obj.GetValue("y").Value<float>();
            float z = obj.GetValue("z").Value<float>();
            float w = obj.GetValue("w").Value<float>();

            return new Vector4(x, y, z, w);
        }

        return Vector4.zero;
    }
}