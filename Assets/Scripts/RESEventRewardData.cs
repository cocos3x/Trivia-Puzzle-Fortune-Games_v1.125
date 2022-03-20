using UnityEngine;
public class RESEventRewardData
{
    // Fields
    public RESEventRewardType rewardType;
    public int pointsReq;
    public decimal rewardQty;
    public System.Collections.Generic.Dictionary<string, object> metaData;
    
    // Methods
    public RESEventRewardData()
    {
    
    }
    public RESEventRewardData(RESEventRewardType rewType, decimal rewQty, int ptsReq, System.Collections.Generic.Dictionary<string, object> mData)
    {
        val_1 = new System.Object();
        this.rewardQty = rewQty;
        mem[1152921517102822384] = rewQty.lo;
        mem[1152921517102822388] = rewQty.mid;
        this.rewardType = rewType;
        this.pointsReq = ptsReq;
        this.metaData = val_1;
    }
    public RESEventRewardData(RESEventRewardData rData)
    {
        this.rewardType = rData.rewardType;
        this.rewardQty = rData.rewardQty;
        this.pointsReq = rData.pointsReq;
        this.metaData = rData.metaData;
    }

}
