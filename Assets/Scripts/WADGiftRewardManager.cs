using UnityEngine;
public class WADGiftRewardManager : WGGiftRewardManager<WADGiftRewardManager>
{
    // Methods
    public System.Collections.Generic.List<GiftReward> MakeRewards(GiftRewardType rewardType, int rewardAmount)
    {
        GiftReward val_15;
        GiftRewardType val_16;
        var val_17;
        System.Predicate<GiftReward> val_19;
        var val_20;
        System.Collections.Generic.List<GiftReward> val_2 = new System.Collections.Generic.List<GiftReward>();
        GiftReward val_3 = null;
        val_15 = val_3;
        val_3 = new GiftReward();
        .reward = val_15;
        .Type = rewardType;
        if(rewardType > 5)
        {
                return val_2;
        }
        
        var val_15 = 32498276 + (rewardType) << 2;
        val_15 = val_15 + 32498276;
        goto (32498276 + (rewardType) << 2 + 32498276);
        label_37:
        GameBehavior val_5 = App.getBehavior;
        if(((val_5.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_15;
        }
        
        .reward = new GiftReward();
        .Type = ;
        (WADGiftRewardManager.<>c__DisplayClass0_0)[1152921517704114752].reward.SubType_PetCard = MonoSingleton<WADPetsManager>.Instance.GetRandomPet();
        val_17 = null;
        val_17 = null;
        val_19 = WADGiftRewardManager.<>c.<>9__0_0;
        if(val_19 == null)
        {
                System.Predicate<GiftReward> val_9 = null;
            val_19 = val_9;
            val_9 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<MakeRewards>b__0_0(GiftReward x));
            WADGiftRewardManager.<>c.<>9__0_0 = val_19;
        }
        
        System.Collections.Generic.List<T> val_10 = val_2.FindAll(match:  val_9);
        if((val_10 == null) || (1152921517704018592 < 1))
        {
            goto label_30;
        }
        
        val_15 = (WADGiftRewardManager.<>c__DisplayClass0_0)[1152921517704114752].<>9__1;
        if(val_15 == null)
        {
                System.Predicate<GiftReward> val_11 = null;
            val_15 = val_11;
            val_11 = new System.Predicate<GiftReward>(object:  new WADGiftRewardManager.<>c__DisplayClass0_0(), method:  System.Boolean WADGiftRewardManager.<>c__DisplayClass0_0::<MakeRewards>b__1(GiftReward x));
            .<>9__1 = val_15;
        }
        
        if((val_10.Find(match:  val_11)) == null)
        {
            goto label_30;
        }
        
        decimal val_13 = System.Decimal.op_Increment(d:  new System.Decimal() {flags = val_12.Amount, hi = val_12.Amount, lo = 212423232, mid = 268435459});
        val_12.Amount = val_13;
        mem2[0] = val_13.lo;
        mem[4] = val_13.mid;
        val_16 = 3;
        goto label_33;
        label_30:
        val_20 = null;
        val_20 = null;
        (WADGiftRewardManager.<>c__DisplayClass0_0)[1152921517704114752].reward.Amount = System.Decimal.One;
        val_2.Add(item:  (WADGiftRewardManager.<>c__DisplayClass0_0)[1152921517704114752].reward);
        label_33:
         =  + 1;
        if( < rewardAmount)
        {
            goto label_37;
        }
        
        return val_2;
        label_15:
        UnityEngine.Debug.LogError(message:  "Attempting to reward Pets collectible card but game does not support Pets!");
        return val_2;
    }
    public System.Collections.Generic.List<GiftReward> GetRewards(GiftRewardSource rewardSource)
    {
        var val_9;
        GiftRewardSource val_10;
        int val_45;
        MetaGameBehavior val_46;
        var val_47;
        var val_48;
        System.Predicate<GiftRewardTypeChance> val_50;
        var val_51;
        var val_52;
        GiftReward val_54;
        var val_60;
        GiftReward val_63;
        val_45 = this;
        System.Collections.Generic.List<GiftReward> val_1 = new System.Collections.Generic.List<GiftReward>();
        if(rewardSource == 2)
        {
            goto label_1;
        }
        
        System.Collections.Generic.List<GiftRewardTypeChance> val_2 = val_1.GetRewardTypeChances(rewardSource:  rewardSource);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_46 = val_3.<metaGameBehavior>k__BackingField;
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_46 & 1) == 0)
        {
                val_47 = 1152921504984109056;
            val_48 = null;
            val_48 = null;
            val_50 = WADGiftRewardManager.<>c.<>9__1_0;
            if(val_50 == null)
        {
                System.Predicate<GiftRewardTypeChance> val_4 = null;
            val_50 = val_4;
            val_51 = public System.Void System.Predicate<GiftRewardTypeChance>::.ctor(object object, IntPtr method);
            val_4 = new System.Predicate<GiftRewardTypeChance>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<GetRewards>b__1_0(GiftRewardTypeChance x));
            WADGiftRewardManager.<>c.<>9__1_0 = val_50;
        }
        
            if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            val_46 = val_2;
            int val_5 = val_46.RemoveAll(match:  val_4);
        }
        
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
            goto label_14;
        }
        
        if(val_2 != null)
        {
            goto label_15;
        }
        
        throw new NullReferenceException();
        label_14:
        val_47 = 1152921504984109056;
        val_52 = null;
        val_52 = null;
        val_50 = WADGiftRewardManager.<>c.<>9__1_1;
        if(val_50 == null)
        {
                System.Predicate<GiftRewardTypeChance> val_6 = null;
            val_50 = val_6;
            val_51 = public System.Void System.Predicate<GiftRewardTypeChance>::.ctor(object object, IntPtr method);
            val_6 = new System.Predicate<GiftRewardTypeChance>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<GetRewards>b__1_1(GiftRewardTypeChance x));
            WADGiftRewardManager.<>c.<>9__1_1 = val_50;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_7 = val_2.RemoveAll(match:  val_6);
        label_15:
        if((public System.Int32 System.Collections.Generic.List<GiftRewardTypeChance>::RemoveAll(System.Predicate<T> match)) == 0)
        {
            goto label_23;
        }
        
        List.Enumerator<T> val_8 = val_2.GetEnumerator();
        label_85:
        if(val_10.MoveNext() == false)
        {
            goto label_24;
        }
        
        val_46 = 0;
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((UnityEngine.Random.Range(min:  0, max:  100)) >= (val_9 + 20))
        {
            goto label_85;
        }
        
        GiftReward val_14 = null;
        val_54 = val_14;
        val_14 = new GiftReward();
        if((new WADGiftRewardManager.<>c__DisplayClass1_0()) == null)
        {
                throw new NullReferenceException();
        }
        
        .reward = val_54;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        .Type = val_9 + 16;
        if((val_9 + 16) > 5)
        {
            goto label_29;
        }
        
        var val_44 = 32498300 + (val_9 + 16) << 2;
        val_44 = val_44 + 32498300;
        goto (32498300 + (val_9 + 16) << 2 + 32498300);
        label_29:
        if(((WADGiftRewardManager.<>c__DisplayClass1_0)[1152921517704499552].reward) == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = null;
        val_60 = null;
        val_46 = (WADGiftRewardManager.<>c__DisplayClass1_0)[1152921517704499552].reward.Amount;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_46, hi = val_46}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == true)
        {
            goto label_85;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  (WADGiftRewardManager.<>c__DisplayClass1_0)[1152921517704499552].reward);
        goto label_85;
        label_24:
        val_10.Dispose();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Void List.Enumerator<GiftRewardTypeChance>::Dispose()) != 0)
        {
                return val_1;
        }
        
        object[] val_36 = new object[1];
        val_10 = rewardSource;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36[0] = val_10;
        UnityEngine.Debug.LogErrorFormat(format:  "Zero rewards supported for {0}. Returning ftux coins.", args:  val_36);
        GiftReward val_37 = null;
        val_63 = val_37;
        val_37 = new GiftReward();
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        .Type = 0;
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_45 = val_38.dbFtuxCr;
        decimal val_39 = System.Decimal.op_Implicit(value:  val_45);
        .Amount = val_39;
        mem[1152921517704602016] = val_39.lo;
        mem[1152921517704602020] = val_39.mid;
        goto label_104;
        label_23:
        object[] val_40 = new object[1];
        val_10 = rewardSource;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40[0] = val_10;
        UnityEngine.Debug.LogErrorFormat(format:  "Gift Reward Type Chances doesn\'t contain {0}. Returning ftux coins.", args:  val_40);
        label_1:
        GiftReward val_41 = null;
        val_63 = val_41;
        val_41 = new GiftReward();
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        .Type = 0;
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        val_45 = val_42.dbFtuxCr;
        val_46 = val_45;
        decimal val_43 = System.Decimal.op_Implicit(value:  val_46);
        .Amount = val_43;
        mem[1152921517704618416] = val_43.lo;
        mem[1152921517704618420] = val_43.mid;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        label_104:
        val_1.Add(item:  val_41);
        return val_1;
    }
    public void CollectRewards(System.Collections.Generic.List<GiftReward> rewards, GiftRewardSource rewardSource)
    {
        var val_9;
        var val_10;
        var val_36;
        var val_37;
        System.Predicate<GiftReward> val_39;
        System.Func<GiftReward, System.Decimal> val_40;
        var val_41;
        var val_43;
        System.Predicate<GiftReward> val_45;
        var val_46;
        int val_47;
        int val_48;
        var val_49;
        System.Predicate<GiftReward> val_51;
        var val_52;
        System.Func<GiftReward, System.Int32> val_54;
        var val_55;
        System.Predicate<GiftReward> val_57;
        var val_58;
        System.Func<GiftReward, System.Decimal> val_60;
        var val_61;
        System.Predicate<GiftReward> val_63;
        var val_64;
        System.Func<GiftReward, System.Int32> val_66;
        var val_67;
        System.Predicate<GiftReward> val_69;
        var val_70;
        val_36 = rewards;
        string val_1 = this.GetRewardSourceTracking(rewardSource:  rewardSource);
        val_37 = null;
        val_37 = null;
        val_39 = WADGiftRewardManager.<>c.<>9__2_0;
        if(val_39 == null)
        {
                System.Predicate<GiftReward> val_2 = null;
            val_39 = val_2;
            val_2 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_0(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_0 = val_39;
        }
        
        val_41 = null;
        val_41 = null;
        val_40 = WADGiftRewardManager.<>c.<>9__2_1;
        if(val_40 == null)
        {
                System.Func<GiftReward, System.Decimal> val_4 = null;
            val_40 = val_4;
            val_4 = new System.Func<GiftReward, System.Decimal>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal WADGiftRewardManager.<>c::<CollectRewards>b__2_1(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_1 = val_40;
        }
        
        decimal val_5 = System.Linq.Enumerable.Sum<GiftReward>(source:  val_36.FindAll(match:  val_2), selector:  val_4);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, source:  val_1, externalParams:  0, animated:  false);
        val_43 = null;
        val_43 = null;
        val_45 = WADGiftRewardManager.<>c.<>9__2_2;
        if(val_45 == null)
        {
                System.Predicate<GiftReward> val_6 = null;
            val_45 = val_6;
            val_6 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_2(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_2 = val_45;
        }
        
        List.Enumerator<T> val_8 = val_36.FindAll(match:  val_6).GetEnumerator();
        val_46 = 1152921504893161472;
        label_27:
        val_47 = public System.Boolean List.Enumerator<GiftReward>::MoveNext();
        if(val_10.MoveNext() == false)
        {
            goto label_20;
        }
        
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_48 = val_9 + 40;
        val_47 = val_9 + 40 + 8;
        int val_13 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_48, hi = val_48, lo = val_47, mid = val_47});
        if((MonoSingleton<WADPetsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.RewardPetCards(amount:  val_13, pet:  val_9 + 32, source:  0, subsource:  0, additionalParam:  0);
        goto label_27;
        label_20:
        val_10.Dispose();
        if(1152921516320044144 >= 1)
        {
                val_40 = App.Player;
            val_40.TrackNonCoinReward(source:  val_1, subSource:  0, rewardType:  "Cards", rewardAmount:  App.__il2cppRuntimeField_cctor_finished.ToString(), additionalParams:  0);
        }
        
        val_49 = null;
        val_49 = null;
        val_51 = WADGiftRewardManager.<>c.<>9__2_3;
        if(val_51 == null)
        {
                System.Predicate<GiftReward> val_16 = null;
            val_51 = val_16;
            val_16 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_3(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_3 = val_51;
        }
        
        val_52 = null;
        val_40 = App.Player;
        val_52 = null;
        val_54 = WADGiftRewardManager.<>c.<>9__2_4;
        if(val_54 == null)
        {
                System.Func<GiftReward, System.Int32> val_19 = null;
            val_54 = val_19;
            val_19 = new System.Func<GiftReward, System.Int32>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADGiftRewardManager.<>c::<CollectRewards>b__2_4(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_4 = val_54;
        }
        
        val_40.AddPetsFood(amount:  System.Linq.Enumerable.Sum<GiftReward>(source:  val_36.FindAll(match:  val_16), selector:  val_19), source:  val_1, subSource:  0, FoodSpentParams:  0, additionalParam:  0);
        val_55 = null;
        val_55 = null;
        val_57 = WADGiftRewardManager.<>c.<>9__2_5;
        if(val_57 == null)
        {
                System.Predicate<GiftReward> val_21 = null;
            val_57 = val_21;
            val_21 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_5(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_5 = val_57;
        }
        
        val_58 = null;
        val_58 = null;
        val_60 = WADGiftRewardManager.<>c.<>9__2_6;
        if(val_60 == null)
        {
                System.Func<GiftReward, System.Decimal> val_23 = null;
            val_60 = val_23;
            val_23 = new System.Func<GiftReward, System.Decimal>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal WADGiftRewardManager.<>c::<CollectRewards>b__2_6(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_6 = val_60;
        }
        
        decimal val_24 = System.Linq.Enumerable.Sum<GiftReward>(source:  val_36.FindAll(match:  val_21), selector:  val_23);
        val_40 = val_24.lo;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_40, mid = val_24.mid}, source:  System.String.Format(format:  "{0} Pet Coins", arg0:  val_1), externalParams:  0, animated:  false);
        val_61 = null;
        val_61 = null;
        val_63 = WADGiftRewardManager.<>c.<>9__2_7;
        if(val_63 == null)
        {
                System.Predicate<GiftReward> val_26 = null;
            val_63 = val_26;
            val_26 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_7(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_7 = val_63;
        }
        
        val_64 = null;
        val_40 = SnakesAndLaddersEventHandler.<Instance>k__BackingField;
        val_64 = null;
        val_66 = WADGiftRewardManager.<>c.<>9__2_8;
        if(val_66 == null)
        {
                System.Func<GiftReward, System.Int32> val_28 = null;
            val_66 = val_28;
            val_28 = new System.Func<GiftReward, System.Int32>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADGiftRewardManager.<>c::<CollectRewards>b__2_8(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_8 = val_66;
        }
        
        val_40.RewardDiceRolls(amount:  System.Linq.Enumerable.Sum<GiftReward>(source:  val_36.FindAll(match:  val_26), selector:  val_28), source:  val_1);
        val_67 = null;
        val_67 = null;
        val_69 = WADGiftRewardManager.<>c.<>9__2_9;
        if(val_69 == null)
        {
                System.Predicate<GiftReward> val_30 = null;
            val_69 = val_30;
            val_30 = new System.Predicate<GiftReward>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADGiftRewardManager.<>c::<CollectRewards>b__2_9(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_9 = val_69;
        }
        
        GoldenApplesManager val_32 = MonoSingleton<GoldenApplesManager>.Instance;
        val_70 = null;
        val_70 = null;
        val_40 = WADGiftRewardManager.<>c.<>9__2_10;
        if(val_40 == null)
        {
                System.Func<GiftReward, System.Int32> val_33 = null;
            val_40 = val_33;
            val_33 = new System.Func<GiftReward, System.Int32>(object:  WADGiftRewardManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADGiftRewardManager.<>c::<CollectRewards>b__2_10(GiftReward x));
            WADGiftRewardManager.<>c.<>9__2_10 = val_40;
        }
        
        int val_34 = System.Linq.Enumerable.Sum<GiftReward>(source:  val_36.FindAll(match:  val_30), selector:  val_33);
        if(rewardSource > 2)
        {
                return;
        }
        
        MonoSingleton<WGDailyBonusManager>.Instance.HandleCollected();
    }
    private System.Collections.Generic.List<GiftRewardTypeChance> GetRewardTypeChances(GiftRewardSource rewardSource)
    {
        if((App.getGameEcon.ContainsKey(key:  rewardSource)) == false)
        {
                return (System.Collections.Generic.List<GiftRewardTypeChance>)new System.Collections.Generic.List<GiftRewardTypeChance>();
        }
        
        return App.getGameEcon.Item[rewardSource];
    }
    private decimal GetCoinReward(GiftRewardSource rewardSource)
    {
        var val_20;
        var val_21;
        decimal val_22;
        var val_23;
        var val_24;
        float val_25;
        if((App.getGameEcon.ContainsKey(key:  rewardSource)) == false)
        {
            goto label_5;
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_4 = App.getGameEcon.Item[rewardSource];
        if(1152921517705191328 < 1)
        {
            goto label_11;
        }
        
        if(1152921517705191328 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        decimal val_6 = System.Decimal.op_Implicit(value:  System.Convert.ToInt32(value:  public SingleRange System.Collections.Generic.List<SingleRange>::get_Item(int index).__il2cppRuntimeField_20));
        Player val_7 = App.Player;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, d2:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits})) == false)
        {
            goto label_21;
        }
        
        val_20 = 0 + 1;
        var val_9 = 0 + 2;
        goto label_39;
        label_5:
        if((App.getGameEcon.ContainsKey(key:  rewardSource)) == false)
        {
            goto label_28;
        }
        
        System.Collections.Generic.List<GiftRewardAmountChance> val_13 = App.getGameEcon.Item[rewardSource];
        val_21 = val_13.GetRewardByAmountChance(rewards:  val_13);
        val_22 = val_21;
        goto label_35;
        label_28:
        val_21 = 1152921504617017344;
        val_23 = null;
        val_23 = null;
        val_22 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid};
        label_11:
        val_20 = 0;
        goto label_39;
        label_21:
        val_20 = 0;
        label_39:
        var val_16 = (val_20 == 1) ? ((App.__il2cppRuntimeField_cctor_finished - 1)) : (val_20);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        int val_17 = UnityEngine.Random.Range(min:  0, max:  (App.__il2cppRuntimeField_cctor_finished + (val_20 == 0x1 ? (App.__il2cppRuntimeField_cctor_finished - 1) : val_20) << 3) + 32 + 40 + 24);
        if(rewardSource == 3)
        {
                GameEcon val_18 = App.getGameEcon;
            val_25 = val_18.ChapterClearedRewardMulitplier;
        }
        else
        {
                val_25 = 1f;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_21 = System.Convert.ToInt32(value:  (((App.__il2cppRuntimeField_cctor_finished + (val_20 == 0x1 ? (App.__il2cppRuntimeField_cctor_finished - 1) : val_20) << 3) + 32 + 40 + ((long)(int)(val_20 == 0x1 ? (App.__il2cppRuntimeField_cctor_fin + 32);
        float val_21 = (float)val_21;
        val_21 = val_25 * val_21;
        val_21 = (val_21 == Infinityf) ? (-(double)val_21) : ((double)val_21);
        val_22 = (int)val_21;
        label_35:
        val_24 = 0;
        decimal val_20 = System.Decimal.op_Implicit(value:  val_22);
        return new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid};
    }
    private int GetPetFoodReward(GiftRewardSource rewardSource)
    {
        System.Collections.Generic.List<GiftRewardAmountChance> val_2 = App.getGameEcon.Item[rewardSource];
        return val_2.GetRewardByAmountChance(rewards:  val_2);
    }
    private int GetPetCoinReward()
    {
        float val_1 = WADPetsManager.GetLevelCurveModifier(ability:  5);
        val_1 = (val_1 == Infinityf) ? (-(double)val_1) : ((double)val_1);
        return (int)(int)val_1;
    }
    private int GetDiceRollReward(GiftRewardSource rewardSource)
    {
        System.Collections.Generic.List<GiftRewardAmountChance> val_2 = App.getGameEcon.Item[rewardSource];
        return val_2.GetRewardByAmountChance(rewards:  val_2);
    }
    private int GetGoldenCurrencyReward(GiftRewardSource rewardSource)
    {
        System.Collections.Generic.List<GiftRewardAmountChance> val_2 = App.getGameEcon.Item[rewardSource];
        return val_2.GetRewardByAmountChance(rewards:  val_2);
    }
    private int GetRewardByAmountChance(System.Collections.Generic.List<GiftRewardAmountChance> rewards)
    {
        RandomSet val_1 = new RandomSet();
        List.Enumerator<T> val_2 = rewards.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.add(item:  11993091, weight:  1.401298E-45f);
        goto label_5;
        label_2:
        0.Dispose();
        return (int)val_1.roll(unweighted:  false);
    }
    private string GetRewardSourceTracking(GiftRewardSource rewardSource)
    {
        if(rewardSource <= 12)
        {
                var val_3 = 32498324;
            val_3 = (32498324 + (rewardSource) << 2) + val_3;
        }
        else
        {
                var val_2 = (CategoryPacksManager.IsPlaying != true) ? "Category Chapter Complete" : "unknown source gift reward";
            return (string);
        }
    
    }
    private string PrintRewards(System.Collections.Generic.List<GiftReward> giftRewards)
    {
        var val_2;
        object val_3;
        object val_7;
        var val_8;
        int val_9;
        int val_10;
        val_7 = "";
        List.Enumerator<T> val_1 = giftRewards.GetEnumerator();
        goto label_2;
        label_22:
        object[] val_4 = new object[5];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        if(val_4.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[0] = val_7;
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_2 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_2 + 32 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_2 + 32 + 16 + 16) != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_9 = val_4.Length;
        val_4[1] = val_2 + 32 + 16 + 16;
        val_8 = ": ";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_9 = val_4.Length;
        if(val_9 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[2] = ": ";
        val_3 = val_2 + 40;
        if(val_3 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_10 = val_4.Length;
        if(val_10 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[3] = val_3;
        val_8 = "\n";
        val_10 = val_4.Length;
        if(val_10 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[4] = "\n";
        val_7 = +val_4;
        label_2:
        if(val_3.MoveNext() == true)
        {
            goto label_22;
        }
        
        val_3.Dispose();
        return (string)val_7;
    }
    public WADGiftRewardManager()
    {
    
    }

}
