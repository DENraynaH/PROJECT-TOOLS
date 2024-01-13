using Raynah.Utilities;
using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionGroundedModifier", menuName = "Core/Distribution/DistributionGroundedModifier")]
    public class DistributionSurfaceModifier : DistributionModifier
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _jumpDistance;
        [SerializeField] private float _searchDistance;

        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Grounded Modifier");
            
            Vector3 objectPosition = distributableObject.transform.position;
            Vector3 raycastPosition = objectPosition.Add(y: _jumpDistance);
            
            distributableObject.transform.position = Physics.Raycast
            (raycastPosition, Vector3.down, 
                out RaycastHit raycastHit, _searchDistance,
                _groundLayer) ? raycastHit.point : objectPosition;
            
            return true;
        }
    }
}