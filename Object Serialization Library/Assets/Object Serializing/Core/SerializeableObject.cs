using System;
using System.Collections.Generic;
using UnityEngine;

public class SerializableObject : MonoBehaviour
{
    public string UniqueIdentifier => _uniqueIdentifier;
    [SerializeField] private string _uniqueIdentifier;
    
    [ContextMenu("Generate Unique Identifier")]
    private void GenerateUniqueIdentifier()
    {
        _uniqueIdentifier = Guid.NewGuid().ToString();
    }

    public object CaptureState()
    {
        Dictionary<string, object> state = new Dictionary<string, object>();
        
        foreach (ISerializableObject serializableObject in GetComponents<ISerializableObject>())
            state[serializableObject.GetType().ToString()] = serializableObject.SaveData();
        
        return state;
    }
    
    public void RestoreState(object state)
    {
        Dictionary<string, object> objectState = 
            Serialization.JCast<Dictionary<string, object>>(state);
        
        foreach (ISerializableObject serializableObject in GetComponents<ISerializableObject>())
        {
            string typeString = serializableObject.GetType().ToString();
            
            if (objectState.TryGetValue(typeString, out object value))
                serializableObject.LoadData(value);
        }
    }
}
