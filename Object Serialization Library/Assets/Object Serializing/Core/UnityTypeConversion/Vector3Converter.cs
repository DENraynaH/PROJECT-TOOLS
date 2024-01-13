using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Vector3Converter : JsonConverter<Vector3>
{
    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "x", value.x },
            { "y", value.y },
            { "z", value.z }
        };
        obj.WriteTo(writer);
    }

    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            float x = obj.GetValue("x").Value<float>();
            float y = obj.GetValue("y").Value<float>();
            float z = obj.GetValue("z").Value<float>();

            return new Vector3(x, y, z);
        }

        return Vector3.zero;
    }
}