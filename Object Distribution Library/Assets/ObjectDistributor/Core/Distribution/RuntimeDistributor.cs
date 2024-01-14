using System.Collections;
using System.Collections.Generic;
using Raynah.Utilities;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Timer = Raynah.Utilities.Timer;

namespace Raynah.Core
{
    public class RuntimeDistributor : MonoBehaviour
    {
        [SerializeField] private RuntimeObjectDistributor _objectDistributor;
        [SerializeField] private int _distributionQuantity;
        [SerializeField] private float _distributionInterval;
        [SerializeField] private float _distributionMaximum;
        
        private Timer _distributionTimer;
        private bool _isEnabled;
        
        private void Awake()
        {
            _objectDistributor = GetComponent<RuntimeObjectDistributor>();
            Timers.LoopingAction(_distributionInterval, Distribute).Start();
        }

        private void Distribute()
        {
            bool canDistribute = CanDistribute();
            if (canDistribute)
                _objectDistributor.Distribute(_distributionQuantity);
        }
        
        private bool CanDistribute() => 
            _isEnabled && _objectDistributor.DistributedObjects.Count < _distributionMaximum;
        
        [Button] public void StartDistributing() => _isEnabled = true;
        [Button] public void StopDistributing() => _isEnabled = false;
    }
}
