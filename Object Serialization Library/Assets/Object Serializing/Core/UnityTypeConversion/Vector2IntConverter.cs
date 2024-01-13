using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Vector2IntConverter : JsonConverter<Vector2Int>
{
    public override void WriteJson(JsonWriter writer, Vector2Int value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "x", value.x },
            { "y", value.y }
        };
        obj.WriteTo(writer);
    }

    public override Vector2Int ReadJson(JsonReader reader, Type objectType, Vector2Int existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            int x = obj.GetValue("x").Value<int>();
            int y = obj.GetValue("y").Value<int>();

            return new Vector2Int(x, y);
        }

        return Vector2Int.zero;
    }
}