using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionScaleModifier", menuName = "Distribution/DistributionScaleModifier")]
    public class DistributionScaleModifier : DistributionModifier
    {
        [SerializeField] private Vector3Boundaries _scaleBoundaries;
        [SerializeField] private AxisConstraint _axisConstraint;
        
        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Scale Modifier");
            
            Vector3 randomScale = _scaleBoundaries.GetRandom();
            
            if (_axisConstraint.X)
                randomScale.x = distributableObject.transform.localScale.x;
            
            if (_axisConstraint.Y)
                randomScale.y = distributableObject.transform.localScale.y;
            
            if (_axisConstraint.Z)
                randomScale.z = distributableObject.transform.localScale.z;
            
            distributableObject.transform.localScale = randomScale;
            return true;
        }
    }
}