using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionUniformScaleModifier", menuName = "Core/Distribution/DistributionUniformScaleModifier")]
    public class DistributionUniformScaleModifier : DistributionModifier
    {
        [SerializeField] private FloatBoundaries _scaleBoundaries;

        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Uniform Scale Modifier");
            
            distributableObject.transform.localScale = Vector3.one * _scaleBoundaries.GetRandom();
            return true;
        }
    }
}