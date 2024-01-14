#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using Raynah.Core;
using Raynah.Utilities;
using UnityEditor;
using UnityEngine;

namespace Raynah
{
    [ExecuteInEditMode]
    public class DistributionAreaModifierDrawer : MonoBehaviour
    {
        [SerializeField] DistributionAreaModifier _distributionAreaModifier;
        [SerializeField] private float _drawDuration = 10.0f;
        
        private float _castOffsetDistance;
        private Vector3 _castOffsetDirection;
        private Vector3 _castSize;
        private GameObject _distributedObject;
        private bool _successfulDistribution;
        private int _collidedObjects;
        //private bool _drawDebugger;

        private Timer _drawTimer;

        private void OnEnable()
        {
            _distributionAreaModifier.OnModify += InitDrawer;
        }
        
        private void OnDisable()
        {
            _distributionAreaModifier.OnModify -= InitDrawer;
        }

        private void InitDrawer(DistributionAreaModifierData distributionAreaModifierData)
        {
            _castOffsetDistance = distributionAreaModifierData.CastOffsetDistance;
            _castOffsetDirection = distributionAreaModifierData.CastOffsetDirection;
            _castSize = distributionAreaModifierData.CastSize;
            _distributedObject = distributionAreaModifierData.TargetObject;
            _collidedObjects = distributionAreaModifierData.CollidedObjects;
            _successfulDistribution = distributionAreaModifierData.SuccessfulDistribution;
            
            //_drawDebugger = true; 
            
            //TODO
            /*Timer System needs to include some form of object
            pooling for timers, to avoid loads of garbage. */
            
            //TODO
            /* Timer System may also not support editor timers,
            only useable in runtime. */
            
            //TODO SUPPORT DRAWING TEMPORARY GIZMOS, EVEN WHEN THE OBJECT DOESN'T SPAWN
            /*_drawTimer.Cancel();
            _drawTimer = Timers.TimedAction
                    (_showDebuggerDuration, () => _drawDebugger = false).Start();*/
        }

        private void OnDrawGizmos()
        {
            if (_distributedObject == null)
                return;
            
            /*if (!_drawDebugger)
                return;*/
            
            Vector3 objectPosition = _distributedObject.transform.position;
            Vector3 castDirection = (_distributedObject.transform.forward + _castOffsetDirection).normalized;
            
            Handles.color = _successfulDistribution ? Color.green : Color.red;
            Handles.DrawWireCube(objectPosition + castDirection * _castOffsetDistance, _castSize);
            Handles.Label(objectPosition, $"Collided Objects: {_collidedObjects}");
        }
    }
    
    public struct DistributionAreaModifierData
    {
        public DistributionAreaModifierData(float castOffsetDistance, Vector3 castOffsetDirection, 
            Vector3 castSize, GameObject targetObject, int collidedObjects, bool successfulDistribution)
        {
            CastOffsetDistance = castOffsetDistance;
            CastOffsetDirection = castOffsetDirection;
            CastSize = castSize;
            TargetObject = targetObject;
            CollidedObjects = collidedObjects;
            SuccessfulDistribution = successfulDistribution;
        }
        
        public float CastOffsetDistance { get; set; }
        public Vector3 CastOffsetDirection { get; set; }
        public Vector3 CastSize { get; set; }
        public GameObject TargetObject { get; set; }
        public int CollidedObjects { get; set; }
        public bool SuccessfulDistribution { get; set; }
    }
}
#endif
