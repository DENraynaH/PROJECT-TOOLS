using System;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ScriptableObjectConverter : JsonConverter<ScriptableObject>
{
    public override void WriteJson(JsonWriter writer, ScriptableObject value, JsonSerializer serializer)
    {
        var obj = new JObject();
        var fields = value.GetType().GetFields();
        foreach (var field in fields)
        {
            obj.Add(field.Name, JToken.FromObject(field.GetValue(value), serializer));
        }
        obj.WriteTo(writer);
    }

    public override ScriptableObject ReadJson(JsonReader reader, Type objectType, ScriptableObject existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            ScriptableObject scriptableObject = ScriptableObject.CreateInstance(objectType);
            JObject obj = JObject.Load(reader);
            FieldInfo[] fields = objectType.GetFields();
            foreach (var field in fields)
            {
                var fieldName = field.Name;
                if (obj.TryGetValue(fieldName, out var fieldValue))
                {
                    var value = fieldValue.ToObject(field.FieldType, serializer);
                    field.SetValue(scriptableObject, value);
                }
            }

            return scriptableObject;
        }
        return null;
    }
}