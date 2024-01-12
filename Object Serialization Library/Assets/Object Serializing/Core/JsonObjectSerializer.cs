using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonObjectSerializer<T> where T : SerializableObject
{
    private readonly IDataSerializer _dataSerializer = new JsonDataSerializer();
    
    public void SaveObjects()
    {
        Dictionary<string, object> objectState = new Dictionary<string, object>();
        CaptureState(objectState);
        _dataSerializer.SaveFile(objectState);
    }
    
    public void LoadObjects()
    {
        bool successfulOperation = _dataSerializer.LoadFile(out Dictionary<string, object> objectState);
        
        if (successfulOperation)
            RestoreState(objectState);
    }
    
    public void SetSerializePath(string serializePath)
    {
        _dataSerializer.SerializePath = $"{Application.persistentDataPath}/{serializePath}";
    }
    
    private void CaptureState(Dictionary<string, object> objectState)
    {
        T[] serializableObjects = Object.FindObjectsOfType<T>();
        foreach (T serializableObject in serializableObjects)
            objectState[serializableObject.UniqueIdentifier] = serializableObject.CaptureState();
    }

    private void RestoreState(Dictionary<string, object> objectState)
    {
        T[] serializableObjects = Object.FindObjectsOfType<T>();
        foreach (T serializableObject in serializableObjects)
        {
            if (objectState.TryGetValue(serializableObject.UniqueIdentifier, out object componentState))
                serializableObject.RestoreState(componentState);
        }
    }
}
