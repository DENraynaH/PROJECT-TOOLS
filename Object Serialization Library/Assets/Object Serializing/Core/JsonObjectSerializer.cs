using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonObjectSerializer
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
    
    private void CaptureState(Dictionary<string, object> objectState)
    {
        SerializableObject[] serializableObjects = Object.FindObjectsOfType<SerializableObject>();
        foreach (SerializableObject serializableObject in serializableObjects)
            objectState[serializableObject.UniqueIdentifier] = serializableObject.CaptureState();
    }

    private void RestoreState(Dictionary<string, object> objectState)
    {
        SerializableObject[] serializableObjects = Object.FindObjectsOfType<SerializableObject>();
        foreach (SerializableObject serializableObject in serializableObjects)
        {
            if (objectState.TryGetValue(serializableObject.UniqueIdentifier, out object componentState))
                serializableObject.RestoreState(componentState);
        }
    }
}
