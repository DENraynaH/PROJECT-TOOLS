using System.Collections.Generic;
using System.Linq;
using Raynah.Utilities;

namespace Raynah.Core
{
    public interface IDistributionStrategy
    {
        DistributionZone[] GetDistributeZones();
    }

    public class DistributionStrategyBase
    {
        protected readonly WeightedTable<DistributionZone> _distributionZones;

        protected DistributionStrategyBase(WeightedTable<DistributionZone> distributionZones)
        {
            _distributionZones = distributionZones;
        }
    }
    
    public class RandomAreaAdjustedDistributionStrategy : DistributionStrategyBase, IDistributionStrategy
    {
        public RandomAreaAdjustedDistributionStrategy(WeightedTable<DistributionZone> distributionZones)
            : base(distributionZones)
        {
            distributionZones.ForEach(distributionZone =>
            {
                float area = distributionZone.Object.GetArea();
                distributionZone.Weight += area;
            });
        }
        
        public DistributionZone[] GetDistributeZones()
        {
            return new DistributionZone[] { _distributionZones.Get() };
        }
    }
    
    public class RandomAreaIgnoredDistributionStrategy : DistributionStrategyBase, IDistributionStrategy
    {
        public RandomAreaIgnoredDistributionStrategy(WeightedTable<DistributionZone> distributionZones) 
            : base(distributionZones) { }
        
        public DistributionZone[] GetDistributeZones()
        {
            return new DistributionZone[] { _distributionZones.Get() };
        }
    }
    
    public class GlobalDistributionStrategy : DistributionStrategyBase, IDistributionStrategy
    {
        private readonly DistributionZone[] _availableDistributionZones;

        public GlobalDistributionStrategy(WeightedTable<DistributionZone> distributionZones)
            : base(distributionZones)
        {
            _availableDistributionZones = _distributionZones.ToArray();
        }
        
        public DistributionZone[] GetDistributeZones()
        {
            return _availableDistributionZones;
        }
    }
    
    public class LinearDistributionStrategy : DistributionStrategyBase, IDistributionStrategy
    {
        private List<DistributionZone> _availableDistributionZones = new List<DistributionZone>();
        
        public LinearDistributionStrategy(WeightedTable<DistributionZone> distributionZones) 
            : base(distributionZones) { }
        
        public DistributionZone[] GetDistributeZones()
        {
            if (_availableDistributionZones.IsEmpty())
                _availableDistributionZones = _distributionZones.ToList();

            DistributionZone[] distributionZonesToDistribute = { _availableDistributionZones[0] };
            _availableDistributionZones.RemoveAt(0);
            
            return distributionZonesToDistribute;
        }
    }
}