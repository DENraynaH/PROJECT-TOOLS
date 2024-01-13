using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Vector3IntConverter : JsonConverter<Vector3Int>
{
    public override void WriteJson(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "x", value.x },
            { "y", value.y },
            { "z", value.z }
        };
        obj.WriteTo(writer);
    }

    public override Vector3Int ReadJson(JsonReader reader, Type objectType, Vector3Int existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            int x = obj.GetValue("x").Value<int>();
            int y = obj.GetValue("y").Value<int>();
            int z = obj.GetValue("z").Value<int>();

            return new Vector3Int(x, y, z);
        }

        return Vector3Int.zero;
    }
}