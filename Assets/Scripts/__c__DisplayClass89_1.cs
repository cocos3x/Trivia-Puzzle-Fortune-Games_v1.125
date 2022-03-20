using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass89_1
{
    // Fields
    public WordForest.WFOWordChestItemIcon itemIcon;
    public WordForest.WFORewardData rewardData;
    public WordForest.WFOMysteryChestDisplay.<>c__DisplayClass89_0 CS$<>8__locals1;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass89_1()
    {
    
    }
    internal void <CreateMiniSeqSegmentShowItemOuttro>b__1()
    {
        UnityEngine.Object val_12;
        int val_14;
        WordForest.WFOMysteryChestDisplay val_15;
        val_12 = this.itemIcon.gameObject;
        UnityEngine.Object.Destroy(obj:  val_12);
        if((null <= 6) && ((0 & 98) == 0))
        {
                val_14 = this.CS$<>8__locals1.<>4__this.statViewCurrentValueAcorns;
            this.CS$<>8__locals1.<>4__this.statViewCurrentValueAcorns = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = X21, hi = X21, lo = val_12, mid = val_12})) + val_14;
            val_12 = this.CS$<>8__locals1.<>4__this.acornStatViewObj;
            decimal val_4 = System.Decimal.op_Implicit(value:  this.CS$<>8__locals1.<>4__this.statViewCurrentValueAcorns);
            mem2[0] = val_4.flags;
            mem[4] = val_4.hi;
            mem2[0] = val_4.lo;
            mem[4] = val_4.mid;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this.CS$<>8__locals1.<>4__this, aName:  "OnAcornLevelBalanceUpdated");
        }
        
        if("OnAcornLevelBalanceUpdated" == 2)
        {
                val_14 = mem[this.CS$<>8__locals1.<>4__this.statViewCurrentValueCoins];
            val_14 = this.CS$<>8__locals1.<>4__this.statViewCurrentValueCoins.flags;
            decimal val_6 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_14, hi = val_14, lo = this.CS$<>8__locals1.<>4__this.statViewCurrentValueCoins.lo, mid = this.CS$<>8__locals1.<>4__this.statViewCurrentValueCoins.lo}, d2:  new System.Decimal() {flags = this.CS$<>8__locals1.<>4__this, hi = this.CS$<>8__locals1.<>4__this, lo = val_12, mid = val_12});
            mem2[0] = val_6.flags;
            mem[4] = val_6.hi;
            lo = val_6.lo;
            mem[4] = val_6.mid;
            mem2[0] = this.CS$<>8__locals1.<>4__this.statViewCurrentValueCoins.flags;
            mem2[0] = 1;
            val_12 = NotificationCenter.DefaultCenter;
            val_15 = this.CS$<>8__locals1.<>4__this;
            val_12.PostNotification(aSender:  val_15, aName:  "CoinsStatViewUpdate", aData:  CurrencyStatView.GetAnimHT(shouldAnimate:  true));
            mem2[0] = 0;
        }
        
        if((this.CS$<>8__locals1.<>4__this.coinStatViewAnimObj) != 4)
        {
                return;
        }
        
        this.CS$<>8__locals1.<>4__this.statViewCurrentValueShields = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_15, hi = val_15, lo = val_12, mid = val_12})) + (this.CS$<>8__locals1.<>4__this.statViewCurrentValueShields);
        this.CS$<>8__locals1.<>4__this.shieldStatViewObj.artificalTargetBalance = this.CS$<>8__locals1.<>4__this.statViewCurrentValueShields;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this.CS$<>8__locals1.<>4__this, aName:  "OnShieldBalanceUpdated");
    }

}
