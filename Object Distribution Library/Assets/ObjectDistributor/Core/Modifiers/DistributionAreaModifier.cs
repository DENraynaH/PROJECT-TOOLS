using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionAreaModifier", menuName = "Distribution/DistributionAreaModifier")]
    public class DistributionAreaModifier : DistributionModifier
    {
        [SerializeField] private LayerMask _castLayers;
        [SerializeField] private int _minimumCollisions;
        [SerializeField] private float _castOffsetDistance;
        [SerializeField] private Vector3 _castOffsetDirection;
        [SerializeField] private Vector3 _castSize;
        
        private Collider[] _collidedObjects;
        public event Action<DistributionAreaModifierData> OnModify;
        
        private void OnEnable()
        {
            _collidedObjects = new Collider[_minimumCollisions + 1];
        }

        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            bool successfulDistribution = false;
            
            Vector3 objectPosition = distributableObject.transform.position;
            Vector3 castDirection = (distributableObject.transform.forward + _castOffsetDirection).normalized;
            
            int collidedObjects = Physics.OverlapBoxNonAlloc
            (objectPosition + (castDirection * _castOffsetDistance), 
                (_castSize / 2), _collidedObjects, Quaternion.identity, _castLayers);

            /*int objectCount = ContainsObjectCount(distributableObject);
            Debug.Log(objectCount);
            collidedObjects -= objectCount;*/
            
            if (collidedObjects <= _minimumCollisions)
                successfulDistribution = true;
            
            OnModify?.Invoke(new DistributionAreaModifierData(_castOffsetDistance, _castOffsetDirection, 
                _castSize, distributableObject, collidedObjects, successfulDistribution));
            
            return successfulDistribution;
        }
        
        private int ContainsObjectCount(GameObject collideObject)
        {
            int count = 0;
            foreach (Collider collider in _collidedObjects)
            {
                if (collider != null)
                {
                    if (collider.gameObject == collideObject) 
                        count++;
                }
            }
            return count;
        }
    }
}