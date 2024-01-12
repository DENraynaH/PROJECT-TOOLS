using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonDataSerializer : IDataSerializer
{
    public string SerializePath
    {
        get => $"{Application.persistentDataPath}/saveData.json";
        set => SerializePath = value;
    }

    public bool SaveFile(object state)
    {
        try
        {
            string serializedState = JsonConvert.SerializeObject(state, Formatting.Indented);
            bool doesFileExist = File.Exists(SerializePath);
        
            if (doesFileExist)
                File.Delete(SerializePath);
        
            using FileStream fileStream = File.Create(SerializePath);
            fileStream.Close();
        
            File.WriteAllText(SerializePath, serializedState);
            return true;

        }
        catch (Exception exception)
        {
            Debug.LogError($"Serialization Attempt Failed {exception.Message}, {exception.StackTrace}");
            throw;
        }
    }

    public bool LoadFile<T>(out T loadedState)
    {
        loadedState = default;
            
        if (!File.Exists(SerializePath))
            return false;

        try
        {
            string serializedState = File.ReadAllText(SerializePath);
            loadedState = JsonConvert.DeserializeObject<T>(serializedState);
            return loadedState != null;
        }
        catch (Exception e)
        {
            Debug.LogError($"Deserialization Attempt Failed {e.Message}, {e.StackTrace}");
            return false;
        }
    }
}

public static class Serialization
{
    public static T JCast<T>(object castObject)
    {
        return JObject.FromObject(castObject).ToObject<T>();
    }
}