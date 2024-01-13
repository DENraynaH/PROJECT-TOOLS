using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerExample : MonoBehaviour
{
    private readonly JsonObjectSerializer<SerializableObject> _jsonObjectSerializer = new();
    
    [ContextMenu("Save")]
    public void Save()
    {
        _jsonObjectSerializer.SaveObjects();
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        _jsonObjectSerializer.LoadObjects();
    }
}

