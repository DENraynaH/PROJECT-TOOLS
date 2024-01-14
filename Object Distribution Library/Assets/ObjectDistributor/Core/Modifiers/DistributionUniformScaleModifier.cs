using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionUniformScaleModifier", menuName = "Distribution/DistributionUniformScaleModifier")]
    public class DistributionUniformScaleModifier : DistributionModifier
    {
        [SerializeField] private FloatBoundaries _scaleBoundaries;
        [SerializeField] private AxisConstraint _axisConstraint;

        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Uniform Scale Modifier");
            
            float randomScale = _scaleBoundaries.GetRandom();
            Vector3 initialScale = distributableObject.transform.localScale;
            Vector3 uniformScale = Vector3.one * randomScale;
            
            if (_axisConstraint.X)
                uniformScale.x = initialScale.x;
            
            if (_axisConstraint.Y)
                uniformScale.y = initialScale.y;
            
            if (_axisConstraint.Z)
                uniformScale.z = initialScale.z;
            
            distributableObject.transform.localScale = uniformScale;
            return true;
        }
    }
}