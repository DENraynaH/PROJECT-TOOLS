using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace Raynah.Core
{
    public abstract class DistributionModifier : ScriptableObject
    { 
        public abstract bool Modify(GameObject distributableObject, DistributionZone distributionZone);
    }
}
