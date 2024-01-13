using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raynah
{
    public class EditorDistributor : MonoBehaviour
    {
        enum DistributionType
        {
            Random,
            Weighted,
            Three,
            Four,
            Five,
            Easy
        }
        
        private DistributionType _distributionType;

        public void Tester()
        {
            switch (_distributionType)
            {
                case DistributionType.Random:
                    break;
                case DistributionType.Weighted:
                    break;
                case DistributionType.Three:
                    break;
                case DistributionType.Four:
                    break;
                case DistributionType.Five:
                    break;
                case DistributionType.Easy:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
