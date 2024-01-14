using Raynah.Utilities;
using UnityEngine;

namespace Raynah.Core
{
    [CreateAssetMenu(fileName = "DistributionGroundedModifier", menuName = "Distribution/DistributionSurfaceModifier")]
    public class DistributionSurfaceModifier : DistributionModifier
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _jumpDistance;
        [SerializeField] private float _searchDistance;
        [SerializeField] private bool _cancelOnFail;

        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Grounded Modifier");
            
            Vector3 objectPosition = distributableObject.transform.position;
            Vector3 raycastPosition = objectPosition.Add(y: _jumpDistance);

            Ray ray = new Ray(raycastPosition, Vector3.down);
            bool isGrounded = Physics.Raycast(ray, out RaycastHit raycastHit, _searchDistance, _groundLayer);
            
            if (isGrounded)
                distributableObject.transform.position = raycastHit.point;
            else
            {
                if (_cancelOnFail)
                    return false;
                
                distributableObject.transform.position = objectPosition;
            }

            return true;
        }
    }
}