using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionRotationModifier", menuName = "Distribution/DistributionRotationModifier")]
    public class DistributionRotationModifier : DistributionModifier
    {
        [SerializeField] private Vector3Boundaries _rotationBoundaries;
        [SerializeField] private AxisConstraint _axisConstraint;
        
        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Vector3 randomRotation = _rotationBoundaries.GetRandom();
            
            if (_axisConstraint.X)
                randomRotation.x = distributableObject.transform.localEulerAngles.x;
            
            if (_axisConstraint.Y)
                randomRotation.y = distributableObject.transform.localEulerAngles.y;
            
            if (_axisConstraint.Z)
                randomRotation.z = distributableObject.transform.localEulerAngles.z;
            
            distributableObject.transform.localEulerAngles = randomRotation;
            return true;
        }
    }
}