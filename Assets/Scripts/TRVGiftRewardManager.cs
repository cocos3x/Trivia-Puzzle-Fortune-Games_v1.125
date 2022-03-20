using UnityEngine;
public class TRVGiftRewardManager : WGGiftRewardManager<TRVGiftRewardManager>
{
    // Methods
    public System.Collections.Generic.List<GiftReward> GetRewards(GiftRewardSource rewardsSource, out bool expertLeveledUp, int cardsGranted = 0)
    {
        int val_14;
        System.Collections.Generic.List<GiftReward> val_1 = new System.Collections.Generic.List<GiftReward>();
        expertLeveledUp = false;
        if((rewardsSource == 0) || (rewardsSource == 3))
        {
            goto label_2;
        }
        
        if(rewardsSource != 2)
        {
            goto label_3;
        }
        
        mem[1152921517166918832] = 0;
        GameEcon val_3 = App.getGameEcon;
        val_14 = val_3.dbFtuxCr;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_14);
        mem[1152921517166918856] = val_4.flags;
        mem[1152921517166918860] = val_4.hi;
        mem[1152921517166918864] = val_4.lo;
        mem[1152921517166918868] = val_4.mid;
        val_1.Add(item:  new TRVDailyBonusRewardContainer());
        return val_1;
        label_2:
        TRVDailyBonusRewardContainer val_5 = new TRVDailyBonusRewardContainer();
        decimal val_7 = System.Decimal.op_Implicit(value:  val_5.GetCoinReward());
        mem[1152921517166927048] = val_7.flags;
        mem[1152921517166927052] = val_7.hi;
        mem[1152921517166927056] = val_7.lo;
        mem[1152921517166927060] = val_7.mid;
        val_1.Add(item:  val_5);
        label_3:
        List.Enumerator<T> val_11 = MonoSingleton<TRVExpertsController>.Instance.DetermineExpertCards(source:  rewardsSource, expertNowReadyToUpgrade: out  true, cardsToPull:  cardsGranted).GetEnumerator();
        val_14 = 1152921517137356832;
        label_23:
        if(0.MoveNext() == false)
        {
            goto label_20;
        }
        
        TRVDailyBonusRewardContainer val_13 = new TRVDailyBonusRewardContainer();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921517166939312] = 3;
        .expertRewards = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_13);
        goto label_23;
        label_20:
        0.Dispose();
        return val_1;
    }
    public void CollectRewards(System.Collections.Generic.List<TRVDailyBonusRewardContainer> rewards, GiftRewardSource rewardSource)
    {
        var val_10;
        System.Predicate<TRVDailyBonusRewardContainer> val_12;
        var val_13;
        var val_14;
        System.Func<TRVDailyBonusRewardContainer, System.Decimal> val_16;
        var val_17;
        System.Predicate<TRVDailyBonusRewardContainer> val_19;
        val_10 = null;
        val_10 = null;
        val_12 = TRVGiftRewardManager.<>c.<>9__1_0;
        if(val_12 == null)
        {
                System.Predicate<TRVDailyBonusRewardContainer> val_2 = null;
            val_12 = val_2;
            val_2 = new System.Predicate<TRVDailyBonusRewardContainer>(object:  TRVGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVGiftRewardManager.<>c::<CollectRewards>b__1_0(TRVDailyBonusRewardContainer x));
            TRVGiftRewardManager.<>c.<>9__1_0 = val_12;
        }
        
        val_14 = null;
        val_13 = App.Player;
        val_14 = null;
        val_16 = TRVGiftRewardManager.<>c.<>9__1_1;
        if(val_16 == null)
        {
                System.Func<TRVDailyBonusRewardContainer, System.Decimal> val_5 = null;
            val_16 = val_5;
            val_5 = new System.Func<TRVDailyBonusRewardContainer, System.Decimal>(object:  TRVGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal TRVGiftRewardManager.<>c::<CollectRewards>b__1_1(TRVDailyBonusRewardContainer x));
            TRVGiftRewardManager.<>c.<>9__1_1 = val_16;
        }
        
        decimal val_6 = System.Linq.Enumerable.Sum<TRVDailyBonusRewardContainer>(source:  rewards.FindAll(match:  val_2), selector:  val_5);
        val_13.AddCredits(amount:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, source:  this.GetRewardSourceTracking(rewardSource:  rewardSource), subSource:  0, externalParams:  0, doTrack:  true);
        val_17 = null;
        val_17 = null;
        val_19 = TRVGiftRewardManager.<>c.<>9__1_2;
        if(val_19 == null)
        {
                System.Predicate<TRVDailyBonusRewardContainer> val_7 = null;
            val_19 = val_7;
            val_7 = new System.Predicate<TRVDailyBonusRewardContainer>(object:  TRVGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVGiftRewardManager.<>c::<CollectRewards>b__1_2(TRVDailyBonusRewardContainer x));
            TRVGiftRewardManager.<>c.<>9__1_2 = val_19;
        }
        
        System.Collections.Generic.List<T> val_8 = rewards.FindAll(match:  val_7);
        if(rewardSource > 2)
        {
                return;
        }
        
        MonoSingleton<WGDailyBonusManager>.Instance.HandleCollected();
    }
    private int GetCoinReward()
    {
        var val_10;
        var val_11;
        System.Collections.Generic.List<GiftRewardTier> val_2 = App.GetGameSpecificEcon<TRVEcon>().DailyBonusTiersV2;
        if(1152921517052171200 < 1)
        {
            goto label_5;
        }
        
        val_10 = 0;
        if(1152921517052171200 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        decimal val_4 = System.Decimal.op_Implicit(value:  System.Convert.ToInt32(value:  System.Object Dictionary.Enumerator<System.Char, System.Object>::System.Collections.IEnumerator.get_Current().__il2cppRuntimeField_20));
        Player val_5 = App.Player;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits})) == false)
        {
            goto label_15;
        }
        
        val_11 = val_10 + 1;
        var val_7 = val_10 + 2;
        val_10 = val_11;
        goto label_18;
        label_5:
        val_11 = 0;
        goto label_18;
        label_15:
        val_11 = val_10;
        label_18:
        var val_9 = (val_11 == 1) ? ((App.__il2cppRuntimeField_cctor_finished - 1)) : (val_11);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        int val_10 = UnityEngine.Random.Range(min:  0, max:  (App.__il2cppRuntimeField_cctor_finished + (val_11 == 0x1 ? (App.__il2cppRuntimeField_cctor_finished - 1) : val_11) << 3) + 32 + 40 + 24);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return System.Convert.ToInt32(value:  (((App.__il2cppRuntimeField_cctor_finished + (val_11 == 0x1 ? (App.__il2cppRuntimeField_cctor_finished - 1) : val_11) << 3) + 32 + 40 + ((long)(int)(val_11 == 0x1 ? (App.__il2cppRuntimeField_cctor_fin + 32);
    }
    private string GetRewardSourceTracking(GiftRewardSource rewardSource)
    {
        if(rewardSource <= 12)
        {
                var val_3 = 32556292;
            val_3 = (32556292 + (rewardSource) << 2) + val_3;
        }
        else
        {
                var val_2 = (CategoryPacksManager.IsPlaying != true) ? "Category Chapter Complete" : "unknown source gift reward";
            return "Snakes and Ladders";
        }
    
    }
    public TRVGiftRewardManager()
    {
    
    }

}
