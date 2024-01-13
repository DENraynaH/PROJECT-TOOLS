using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Raynah.Core
{
    public abstract class DistributionZone
    {
        public Vector3 OffsetPosition { get => _offsetPosition; set => _offsetPosition = value; }
        [SerializeField] protected Vector3 _offsetPosition;
        
        public abstract Vector3 GetPosition(Vector3 distributorPosition);
        public abstract float GetArea();
    }
    
    public class PointDistributionZone : DistributionZone
    {
        public override Vector3 GetPosition(Vector3 distributorPosition)
        {
            return distributorPosition + _offsetPosition;
        }

        public override float GetArea()
        {
            return 1.0f;
        }
    }
    
    public class BoxDistributionZone : DistributionZone
    {
        public Vector3 BoxBoundaries => _boxBoundaries;
        [SerializeField] private Vector3 _boxBoundaries;
        
        public override Vector3 GetPosition(Vector3 distributorPosition)
        {
            Vector3 boxPosition = _offsetPosition + distributorPosition;
            
            return new Vector3
                ((boxPosition.x) + Random.Range(-_boxBoundaries.x / 2, _boxBoundaries.x / 2),
                (boxPosition.y) + Random.Range(-_boxBoundaries.y / 2, _boxBoundaries.y / 2),
                (boxPosition.z) + Random.Range(-_boxBoundaries.z / 2, _boxBoundaries.z / 2));
        }

        public override float GetArea()
        {
            return _boxBoundaries.x * _boxBoundaries.y * _boxBoundaries.z;
        }
    }
    
    public class SphereDistributionZone : DistributionZone
    {
        public float SphereRadius => _sphereRadius;
        [SerializeField] private float _sphereRadius;
        
        public override Vector3 GetPosition(Vector3 distributorPosition)
        {
            return distributorPosition + _offsetPosition + 
                   Random.insideUnitSphere * _sphereRadius;
        }

        public override float GetArea()
        {
            return (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(_sphereRadius, 3);
        }
    }
    
    public class LineDistributionZone : DistributionZone
    {
        public Vector3 LineDirection => _lineDirection;
        public float LineLength => _lineLength;
        [SerializeField] private Vector3 _lineDirection;
        [SerializeField] private float _lineLength;
        
        public override Vector3 GetPosition(Vector3 distributorPosition)
        {
            return distributorPosition + _offsetPosition + 
                   (_lineDirection * Random.Range(0, _lineLength));
        }

        public override float GetArea()
        {
            return _lineLength;
        }
    }

    public class SplineDistributionZone : DistributionZone
    {
        public override Vector3 GetPosition(Vector3 distributorPosition)
        {
            throw new System.NotImplementedException();
        }

        public override float GetArea()
        {
            throw new System.NotImplementedException();
        }
    }
}