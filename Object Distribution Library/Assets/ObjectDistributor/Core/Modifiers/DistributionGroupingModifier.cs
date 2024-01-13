using UnityEngine;

namespace Raynah.Core
{
    public class DistributionGroupingModifier : DistributionModifier
    {
        public override bool Modify(GameObject distributableObject, DistributionZone distributionZone)
        {
            Debug.Log("Running Grouping Modifier");
            
            throw new System.NotImplementedException();
        }
    }
}