using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class SaveObjectExample : MonoBehaviour, ISerializableObject
{
    [SerializeField] private float _objectHealth;
    [SerializeField] private int _objectLevel;
    [SerializeField] private string _objectName;
    [SerializeField] private bool _objectIsAlive;
    [SerializeField] private Vector3 _objectPosition;
    [SerializeField] private Quaternion _objectRotation;
    [SerializeField] private Color _objectColor;
    [SerializeField] private Matrix4x4 _objectMatrix;
    [SerializeField] private ScriptableObjectExample _objectScriptableObject;
    [SerializeField] private ExampleClassObject _exampleClassObject;
    [SerializeField] private ExampleClassObject2 _exampleClassObject2;
    
    public object SaveData()
    {
        return new ExampleObjectData
        {
            ObjectHealth = _objectHealth,
            ObjectLevel = _objectLevel,
            ObjectName = _objectName,
            ObjectIsAlive = _objectIsAlive,
            ObjectPosition = _objectPosition,
            ObjectRotation = _objectRotation,
            ObjectColor = _objectColor,
            ObjectMatrix = _objectMatrix,
            ClassObject = _exampleClassObject,
            ClassObject2 = _exampleClassObject2,
            ObjectScriptableObject = _objectScriptableObject
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
        _objectPosition = exampleObjectData.ObjectPosition;
        _objectRotation = exampleObjectData.ObjectRotation;
        _objectColor = exampleObjectData.ObjectColor;
        _objectMatrix = exampleObjectData.ObjectMatrix;
        _exampleClassObject = exampleObjectData.ClassObject;
        _exampleClassObject2 = exampleObjectData.ClassObject2;
        _objectScriptableObject = exampleObjectData.ObjectScriptableObject;
    }
}

[Serializable]
public struct ExampleObjectData
{
    public float ObjectHealth;
    public int ObjectLevel;
    public string ObjectName;
    public bool ObjectIsAlive;
    public Vector3 ObjectPosition;
    public Quaternion ObjectRotation;
    public Color ObjectColor;
    public Matrix4x4 ObjectMatrix;
    public ExampleClassObject ClassObject;
    public ExampleClassObject2 ClassObject2;
    public ScriptableObjectExample ObjectScriptableObject;
}

[Serializable]
public class ExampleClassObject
{
    public Vector3 ObjectPosition;
    public Quaternion ObjectRotation;
    public Color ObjectColor;
    public ExampleClassObject2 _exampleClassObject2;
}

[Serializable]
public class ExampleClassObject2
{
    public Vector3 ObjectPosition;
    public Quaternion ObjectRotation;
    public Color ObjectColor;
    
    [JsonIgnore] public GameObject ObjectGameObject;
}