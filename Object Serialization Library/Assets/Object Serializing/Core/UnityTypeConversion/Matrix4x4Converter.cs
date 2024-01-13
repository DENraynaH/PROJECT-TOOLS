using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Matrix4x4Converter : JsonConverter<Matrix4x4>
{
    public override void WriteJson(JsonWriter writer, Matrix4x4 value, JsonSerializer serializer)
    {
        JObject obj = new JObject
        {
            { "m00", value.m00 },
            { "m01", value.m01 },
            { "m02", value.m02 },
            { "m03", value.m03 },
            { "m10", value.m10 },
            { "m11", value.m11 },
            { "m12", value.m12 },
            { "m13", value.m13 },
            { "m20", value.m20 },
            { "m21", value.m21 },
            { "m22", value.m22 },
            { "m23", value.m23 },
            { "m30", value.m30 },
            { "m31", value.m31 },
            { "m32", value.m32 },
            { "m33", value.m33 }
        };
        obj.WriteTo(writer);
    }

    public override Matrix4x4 ReadJson(JsonReader reader, Type objectType, Matrix4x4 existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);

            float m00 = obj.GetValue("m00").Value<float>();
            float m01 = obj.GetValue("m01").Value<float>();
            float m02 = obj.GetValue("m02").Value<float>();
            float m03 = obj.GetValue("m03").Value<float>();
            float m10 = obj.GetValue("m10").Value<float>();
            float m11 = obj.GetValue("m11").Value<float>();
            float m12 = obj.GetValue("m12").Value<float>();
            float m13 = obj.GetValue("m13").Value<float>();
            float m20 = obj.GetValue("m20").Value<float>();
            float m21 = obj.GetValue("m21").Value<float>();
            float m22 = obj.GetValue("m22").Value<float>();
            float m23 = obj.GetValue("m23").Value<float>();
            float m30 = obj.GetValue("m30").Value<float>();
            float m31 = obj.GetValue("m31").Value<float>();
            float m32 = obj.GetValue("m32").Value<float>();
            float m33 = obj.GetValue("m33").Value<float>();

            return new Matrix4x4(
                new Vector4(m00, m01, m02, m03),
                new Vector4(m10, m11, m12, m13),
                new Vector4(m20, m21, m22, m23),
                new Vector4(m30, m31, m32, m33));

        }
        return Matrix4x4.identity;
    }
}