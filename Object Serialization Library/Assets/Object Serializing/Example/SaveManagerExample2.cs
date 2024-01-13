using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerExample2 : MonoBehaviour
{
    private const string SAVE_PATH = "save2.json";
    private readonly JsonObjectSerializer<SecondSerializableObject> _jsonObjectSerializer = new();

    private void Awake()
    {
        //_jsonObjectSerializer.SetSerializePath(SAVE_PATH);
    }

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
