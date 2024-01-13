using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ColorConverter : JsonConverter<Color>
{
    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "r", value.r },
            { "g", value.g },
            { "b", value.b },
            { "a", value.a }
        };
        obj.WriteTo(writer);
    }

    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            float r = obj.GetValue("r").Value<float>();
            float g = obj.GetValue("g").Value<float>();
            float b = obj.GetValue("b").Value<float>();
            float a = obj.GetValue("a").Value<float>();

            return new Color(r, g, b, a);
        }

        return Color.white;
    }
}