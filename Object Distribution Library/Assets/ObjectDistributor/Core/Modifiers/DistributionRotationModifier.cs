using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionRotationModifier", menuName = "Core/Distribution/DistributionRotationModifier")]
    public class DistributionRotationModifier : DistributionModifier
    {
        [SerializeField] private Vector3Boundaries _rotationBoundaries;
        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Rotation Modifier");
            
            distributableObject.transform.localEulerAngles = _rotationBoundaries.GetRandom();
            return true;
        }
    }
}