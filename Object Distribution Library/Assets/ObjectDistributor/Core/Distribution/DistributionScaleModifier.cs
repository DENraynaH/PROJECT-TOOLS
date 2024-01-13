using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionScaleModifier", menuName = "Core/Distribution/DistributionScaleModifier")]
    public class DistributionScaleModifier : DistributionModifier
    {
        [SerializeField] private Vector3Boundaries _scaleBoundaries;
        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Scale Modifier");
            
            distributableObject.transform.localScale = _scaleBoundaries.GetRandom();
            return true;
        }
    }
}