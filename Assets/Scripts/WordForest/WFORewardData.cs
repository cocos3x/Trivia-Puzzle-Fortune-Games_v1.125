using UnityEngine;

namespace WordForest
{
    public struct WFORewardData
    {
        // Fields
        public int id;
        public WordForest.WFORewardType rewardType;
        public decimal amount;
        public int transformToId;
        
        // Methods
        public WFORewardData(int rId, WordForest.WFORewardType rType, int rAmt, int rTid)
        {
            this = rId;
            this.rewardType = rType;
            decimal val_1 = System.Decimal.op_Implicit(value:  rAmt);
            this.amount = val_1;
            mem[1152921518144023552] = val_1.lo;
            mem[1152921518144023556] = val_1.mid;
            this.transformToId = rTid;
        }
        public WFORewardData(WordForest.WFORewardType rType, int rAmt)
        {
            this.rewardType = rType;
            decimal val_1 = System.Decimal.op_Implicit(value:  rAmt);
            this.amount = val_1;
            mem[1152921518144143744] = val_1.lo;
            mem[1152921518144143748] = val_1.mid;
            this = 0;
            this.transformToId = 0;
        }
    
    }

}
