using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class QuaternionConverter : JsonConverter<Quaternion>
{
    public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
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

    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            float x = obj.GetValue("x").Value<float>();
            float y = obj.GetValue("y").Value<float>();
            float z = obj.GetValue("z").Value<float>();
            float w = obj.GetValue("w").Value<float>();

            return new Quaternion(x, y, z, w);
        }

        return Quaternion.identity;
    }
}