using System.Collections.Generic;
using Raynah.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Raynah.Core
{
    public class RuntimeObjectDistributor : ObjectDistributor
    {
        public List<DistributableObject> DistributedObjects => _distributedObjects;
        [FoldoutGroup("Debug")] [SerializeField] private List<DistributableObject> _distributedObjects = new();
        
        protected override void OnDistribute(GameObject distributedObject)
        {
            DistributableObject distributableObject = distributedObject.GetOrAddComponent<DistributableObject>();
            _distributedObjects.Add(distributableObject);
        }
    }
}