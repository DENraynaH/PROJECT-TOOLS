using System;
using System.Collections.Generic;
using Raynah.Utilities;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Raynah.Core
{
    public class ObjectDistributor : MonoBehaviour
    {
        public List<DistributionZone> DistributionZones => _distributionZones.ToList();
        public List<DistributableObject> DistributedObjects => _distributedObjects;
        
        [FoldoutGroup("Settings")] [SerializeField] private DistributionType _distributionType;
        [FoldoutGroup("Settings")] [SerializeField] private int _maxDistributionAttempt = 50;
        [FoldoutGroup("Settings")] [SerializeField] private WeightedTable<GameObject> _distributableObjects = new();
        [FoldoutGroup("Settings")] [SerializeField] private WeightedTable<DistributionZone> _distributionZones = new();
        [FoldoutGroup("Settings")] [SerializeField] private List<DistributionModifier> _distributionModifiers = new();
        [FoldoutGroup("Debug")] [SerializeField] private List<DistributableObject> _distributedObjects = new();
        
        private IDistributionStrategy _distributionStrategy;
        
        public void Distribute(int distributionCount)
        {
            for (int i = 0; i < distributionCount; i++)
                Distribute();
        }
        
        [Button] public void Distribute()
        {
            bool isDistributionTableSetup = IsSetup();
            
            if (!isDistributionTableSetup)
                return;
            
            _distributionStrategy ??= GetDistributionStrategy();
            
            DistributionZone[] distributionZones = 
                _distributionStrategy.GetDistributeZones();

            foreach (DistributionZone distributionZone in distributionZones)
                DistributeObject(distributionZone);
        }
        
        private void DistributeObject(DistributionZone distributionZone)
        {
            int distributionAttempt = 0;
            bool isDistributed = false;
            GameObject distributedObject = null;
            
            distributedObject = Instantiate(
                _distributableObjects.Get(),
                distributionZone.GetPosition(transform.position), Quaternion.identity);

            while (distributionAttempt++ < _maxDistributionAttempt && isDistributed == false)
            {
                distributedObject.transform.position = distributionZone.GetPosition(transform.position);
                isDistributed = ApplyModifiers(distributedObject, distributionZone);
            }

            if (isDistributed)
            {
                DistributableObject distributableObject = distributedObject.GetOrAddComponent<DistributableObject>();
                _distributedObjects.Add(distributableObject);   
            }
            else
                Destroy(distributedObject);
        }
        
        private bool ApplyModifiers(GameObject distributableObject, DistributionZone distributionZone)
        {
            foreach (DistributionModifier modifier in _distributionModifiers)
            {
                bool successfulModifier = modifier.Modify(distributableObject, distributionZone);
                if (!successfulModifier)
                    return false;
            }
            return true;
        }
        
        private IDistributionStrategy GetDistributionStrategy()
        {
            switch (_distributionType)
            {
                case DistributionType.RandomAreaAdjusted:
                    return new RandomAreaAdjustedDistributionStrategy(_distributionZones);
                case DistributionType.RandomAreaIgnored:
                    return new RandomAreaIgnoredDistributionStrategy(_distributionZones);
                case DistributionType.Global:
                    return new GlobalDistributionStrategy(_distributionZones);
                case DistributionType.Linear:
                    return new LinearDistributionStrategy(_distributionZones);
            }
            return null;
        }
        
        private bool IsSetup()
        {
            return _distributableObjects != null && _distributionZones != null &&
                   _distributableObjects.Count > 0 && _distributionZones.Count > 0;
        }
    }
}
 