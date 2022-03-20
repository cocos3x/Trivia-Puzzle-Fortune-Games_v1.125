using UnityEngine;

namespace WordForest
{
    public struct WFOForestChestData
    {
        // Fields
        public int forestLevel;
        public decimal coins;
        public int acorns;
        public System.Collections.Generic.List<int> newRewardTypes;
        
        // Methods
        public WFOForestChestData(int _level, decimal _coins, int _acorns, System.Collections.Generic.List<int> _newRewardTypes)
        {
            this = _level;
            this.coins = _coins;
            mem[1152921518144508412] = _coins.lo;
            mem[1152921518144508416] = _coins.mid;
            this.acorns = _acorns;
            this.newRewardTypes = new System.Collections.Generic.List<System.Int32>(collection:  _newRewardTypes);
        }
    
    }

}
