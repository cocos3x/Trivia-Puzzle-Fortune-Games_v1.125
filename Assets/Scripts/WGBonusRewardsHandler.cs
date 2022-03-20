using UnityEngine;
public class WGBonusRewardsHandler : DefaultHandler<WGBonusRewardsHandler>
{
    // Fields
    private decimal lastPointsCalculated;
    private BonusRewardsContainer myContainer;
    
    // Properties
    private int currentRewardPoints { get; set; }
    
    // Methods
    private int get_currentRewardPoints()
    {
        Player val_1 = App.Player;
        return (int)val_1._bonusRewardPoints;
    }
    private void set_currentRewardPoints(int value)
    {
        Player val_1 = App.Player;
        val_1._bonusRewardPoints = value;
    }
    protected override void AwakeLogic()
    {
        var val_5;
        this.AwakeLogic();
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        System.Delegate val_3 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGBonusRewardsHandler::ProcessPurchase(ref PurchaseModel purchaseInfo)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_3;
        BonusRewardsContainer val_4 = this.GetCurrentRewards();
        return;
        label_9:
    }
    private void OnDestroy()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, value:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGBonusRewardsHandler::ProcessPurchase(ref PurchaseModel purchaseInfo)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_2;
        return;
        label_4:
    }
    private void ProcessPurchase(ref PurchaseModel purchaseInfo)
    {
        var val_26;
        string val_27;
        int val_28;
        int val_29;
        var val_30;
        string val_31;
        int val_32;
        int val_33;
        var val_34;
        var val_35;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        int val_2 = val_1.<metaGameBehavior>k__BackingField.GetPointsForPurchase(pack:  purchaseInfo);
        BonusRewardsContainer val_3 = this.GetCurrentRewards();
        decimal val_4 = purchaseInfo.Credits;
        val_26 = null;
        val_26 = null;
        val_28 = 0;
        val_29 = 0;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_6 = purchaseInfo.Credits;
            float val_26 = 0.01f;
            val_26 = ((float)val_3.<bonusCoinsEarnedPercent>k__BackingField) * val_26;
            val_26 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid})) * val_26;
            decimal val_9 = System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_26));
            val_29 = val_9.flags;
            val_28 = val_9.lo;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_27 = "BonusRewardCredits";
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_29, hi = val_9.hi, lo = val_28, mid = val_9.mid}, source:  val_27, subSource:  0, externalParams:  0, doTrack:  false);
        }
        
        }
        
        decimal val_12 = purchaseInfo.Gems;
        val_30 = null;
        val_30 = null;
        val_32 = 0;
        val_33 = 0;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_14 = purchaseInfo.Gems;
            float val_27 = 0.01f;
            val_27 = ((float)val_3.<bonusGemsEarnedPercent>k__BackingField) * val_27;
            val_27 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid})) * val_27;
            decimal val_17 = System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_27));
            val_33 = val_17.flags;
            val_32 = val_17.lo;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_17.flags, hi = val_17.hi, lo = val_17.lo, mid = val_17.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                val_31 = 0;
            App.Player.AddGems(amount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_33, hi = val_17.hi, lo = val_32, mid = val_17.mid}), source:  "BonusRewardGems", subsource:  val_31);
        }
        
        }
        
        val_34 = null;
        val_34 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_29, hi = val_9.hi, lo = val_28, mid = val_9.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
            goto label_38;
        }
        
        val_35 = null;
        val_35 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_33, hi = val_17.hi, lo = val_32, mid = val_17.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_41;
        }
        
        label_38:
        vipAddedCredits = val_9;
        mem2[0] = val_28;
        mem[4] = val_9.mid;
        vipAddedGems = val_17;
        mem2[0] = val_32;
        mem[4] = val_17.mid;
        label_41:
        vipApplied = true;
        BonusRewardsContainer val_23 = this.GetCurrentRewards();
        vipLevel = val_23.<level>k__BackingField;
        vipContribution = val_2;
        Player val_24 = App.Player;
        int val_28 = val_24._bonusRewardPoints;
        val_28 = val_28 + val_2;
        val_24._bonusRewardPoints = val_28;
        BonusRewardsContainer val_25 = this.GetCurrentRewards();
    }
    public BonusRewardsContainer GetCurrentRewards()
    {
        decimal val_10;
        BonusRewardsContainer val_11;
        val_10 = this.lastPointsCalculated;
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  val_1._bonusRewardPoints);
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_10, hi = val_10, lo = 41967616}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid})) != false)
        {
                val_11 = this.myContainer;
            if(val_11 != null)
        {
                return val_11;
        }
        
        }
        
        GameEcon val_4 = App.getGameEcon;
        var val_10 = val_4.currentRewardPoints;
        List.Enumerator<T> val_6 = val_4.GetEnumerator();
        val_10 = 1152921517449991536;
        goto label_12;
        label_15:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_10 < 1)
        {
            goto label_14;
        }
        
        this.myContainer = 0;
        val_10 = val_10 - 1;
        label_12:
        if(0.MoveNext() == true)
        {
            goto label_15;
        }
        
        label_14:
        0.Dispose();
        Player val_8 = App.Player;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8._bonusRewardPoints);
        val_11 = this.myContainer;
        this.lastPointsCalculated = val_9;
        mem[1152921517450025808] = val_9.lo;
        mem[1152921517450025812] = val_9.mid;
        return val_11;
    }
    public BonusRewardsContainer GetNextRewards()
    {
        var val_5;
        BonusRewardsContainer val_1 = this.GetCurrentRewards();
        List.Enumerator<T> val_3 = App.getGameEcon.GetEnumerator();
        label_8:
        if(0.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_5 = 0;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(11993091 <= (val_1.<level>k__BackingField))
        {
            goto label_8;
        }
        
        goto label_9;
        label_6:
        val_5 = 0;
        label_9:
        0.Dispose();
        return (BonusRewardsContainer)val_5;
    }
    public int GetProgressThroughCurrentTier()
    {
        var val_5;
        GameEcon val_1 = App.getGameEcon;
        val_5 = val_1.currentRewardPoints;
        List.Enumerator<T> val_3 = val_1.GetEnumerator();
        goto label_5;
        label_8:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_5 = 1;
        val_5 = val_5 - val_5;
        if()
        {
            goto label_7;
        }
        
        val_5 = val_5;
        label_5:
        if(0.MoveNext() == true)
        {
            goto label_8;
        }
        
        label_7:
        0.Dispose();
        return (int)val_5;
    }
    public bool MaxPointsGained()
    {
        var val_6;
        System.Func<BonusRewardsContainer, System.Int32> val_8;
        val_6 = null;
        val_6 = null;
        val_8 = WGBonusRewardsHandler.<>c.<>9__11_0;
        if(val_8 == null)
        {
                System.Func<BonusRewardsContainer, System.Int32> val_2 = null;
            val_8 = val_2;
            val_2 = new System.Func<BonusRewardsContainer, System.Int32>(object:  WGBonusRewardsHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGBonusRewardsHandler.<>c::<MaxPointsGained>b__11_0(BonusRewardsContainer x));
            WGBonusRewardsHandler.<>c.<>9__11_0 = val_8;
        }
        
        BonusRewardsContainer val_3 = MoreLinq.MaxBy<BonusRewardsContainer, System.Int32>(source:  App.getGameEcon, selector:  val_2);
        BonusRewardsContainer val_4 = this.GetCurrentRewards();
        return (bool)((val_4.<level>k__BackingField) == (val_3.<level>k__BackingField)) ? 1 : 0;
    }
    public int GetPointsForPurchase(PurchaseModel pack)
    {
        GameEcon val_2 = App.getGameEcon;
        val_2 = val_2 * (UnityEngine.Mathf.CeilToInt(f:  pack.sale_price));
        return (int)val_2;
    }
    public decimal GetBonusCoins(PurchaseModel pack)
    {
        decimal val_1 = pack.Credits;
        BonusRewardsContainer val_3 = this.GetCurrentRewards();
        float val_5 = 0.01f;
        val_5 = ((float)val_3.<bonusCoinsEarnedPercent>k__BackingField) * val_5;
        val_5 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid})) * val_5;
        return System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_5));
    }
    public decimal GetBonusGems(PurchaseModel pack)
    {
        decimal val_1 = pack.Gems;
        BonusRewardsContainer val_3 = this.GetCurrentRewards();
        float val_5 = 0.01f;
        val_5 = ((float)val_3.<bonusGemsEarnedPercent>k__BackingField) * val_5;
        val_5 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid})) * val_5;
        return System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_5));
    }
    public decimal GetBonusStars(int starsBeingRewarded)
    {
        BonusRewardsContainer val_1 = this.GetCurrentRewards();
        float val_3 = 0.01f;
        val_3 = ((float)val_1.<bonusGoldenCurrencyEarnedPercent>k__BackingField) * val_3;
        val_3 = val_3 * (float)starsBeingRewarded;
        return System.Decimal.op_Implicit(value:  UnityEngine.Mathf.CeilToInt(f:  val_3));
    }
    public WGBonusRewardsHandler()
    {
        null = null;
        this.lastPointsCalculated = System.Decimal.MinusOne;
    }

}
