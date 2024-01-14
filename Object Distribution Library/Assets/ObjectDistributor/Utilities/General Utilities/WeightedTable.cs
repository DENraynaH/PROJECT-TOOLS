using System;
using System.Collections.Generic;
using System.Linq;
using Raynah.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class WeightedObject<T>
{
    public WeightedObject(T objectType, float objectWeight)
    {
        Object = objectType;
        Weight = objectWeight;
    }
    
    [field:SerializeReference] public T Object { get; set; }
    [field:SerializeField] public float Weight { get; set; }
}

[Serializable]
public class WeightedTable<T>
{
    public int Count => _weightTable.Count;
    
    public List<WeightedObject<T>> _weightTable = new();
    
    public void Add(WeightedObject<T> weightedObject) => _weightTable.Add(weightedObject);
    public void Remove(WeightedObject<T> weightedObject) => _weightTable.Remove(weightedObject);
    
    public bool TryGet(out T objectType)
    {
        objectType = Get();
        return objectType != null;
    }
    
    public T Get()
    {
        if (_weightTable.IsEmpty())
            return default;
        
        float totalWeight = GetTotalWeight();
        float randomWeight = Random.Range(0, totalWeight);
        List<float> distributionTable = CreateDistributionTable();

        foreach (float distributedWeight in distributionTable)
        {
            if (randomWeight <= distributedWeight)
                return _weightTable[distributionTable.IndexOf(distributedWeight)].Object;
        }
        return default;
    }
    
    public void ForEach(Action<WeightedObject<T>> action)
    {
        foreach (WeightedObject<T> weightedObject in _weightTable)
            action?.Invoke(weightedObject);
    }
    
    public List<T> ToList()
    {
        List<T> objectList = new List<T>();
        
        foreach (WeightedObject<T> objectWeight in _weightTable)
            objectList.Add(objectWeight.Object);
        
        return objectList;
    }
    
    public T[] ToArray()
    {
        T[] objectArray = new T[_weightTable.Count];
        
        for (int i = 0; i < _weightTable.Count; i++)
            objectArray[i] = _weightTable[i].Object;
        
        return objectArray;
    }
    
    public void Clear()
    {
        _weightTable.Clear();
    }
    
    private List<float> CreateDistributionTable()
    {
        float currentWeight = 0;
        List<float> organisedWeightTable = new List<float>();
        
        foreach (WeightedObject<T> objectWeight in _weightTable)
        {
            currentWeight += objectWeight.Weight;
            organisedWeightTable.Add(currentWeight);
        }
        return organisedWeightTable;
    }
    
    private float GetTotalWeight()
    {
        float totalWeight = 0;
        
        foreach (WeightedObject<T> objectWeight in _weightTable)
            totalWeight += objectWeight.Weight;
        
        return totalWeight;
    }
}
