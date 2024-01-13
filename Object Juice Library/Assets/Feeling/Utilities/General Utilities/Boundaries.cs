using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Raynah.Core
{
    [Serializable]
    public struct Vector3Boundaries
    {
        [field:SerializeField] public Vector3 UpperBoundary { get; private set; }
        [field:SerializeField] public Vector3 LowerBoundary { get; private set; }

        public Vector3 GetRandom()
        {
            return new Vector3(
                Random.Range(LowerBoundary.x, UpperBoundary.x),
                Random.Range(LowerBoundary.y, UpperBoundary.y),
                Random.Range(LowerBoundary.z, UpperBoundary.z));
        }
    }
    
    [Serializable]
    public struct FloatBoundaries
    {
        [field:SerializeField] public float UpperBoundary { get; private set; }
        [field:SerializeField] public float LowerBoundary { get; private set; }
    
        public float GetRandom()
        {
            return (Random.Range(LowerBoundary, UpperBoundary));
        }
    }
}
