using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveObjectExample : MonoBehaviour, ISerializableObject
{
    [SerializeField] private float _objectHealth;
    [SerializeField] private int _objectLevel;
    [SerializeField] private string _objectName;
    [SerializeField] private bool _objectIsAlive;
    
    public object SaveData()
    {
        return new ExampleObjectData
        {
            ObjectHealth = _objectHealth,
            ObjectLevel = _objectLevel,
            ObjectName = _objectName,
            ObjectIsAlive = _objectIsAlive
        };
    }

    public void LoadData(object state)
    {
        ExampleObjectData exampleObjectData = 
            Serialization.JCast<ExampleObjectData>(state);
        
        _objectHealth = exampleObjectData.ObjectHealth;
        _objectLevel = exampleObjectData.ObjectLevel;
        _objectName = exampleObjectData.ObjectName;
        _objectIsAlive = exampleObjectData.ObjectIsAlive;
    }
}

public struct ExampleObjectData
{
    public float ObjectHealth;
    public int ObjectLevel;
    public string ObjectName;
    public bool ObjectIsAlive;
}