using UnityEngine;
public class LetterBankTierRewardInfo
{
    // Fields
    public int tier;
    public LetterBankRewardChances coin_chances;
    public LetterBankRewardChances card_chances;
    public LetterBankRewardChances food_chances;
    public bool successfullyParsed;
    
    // Methods
    public LetterBankTierRewardInfo(System.Collections.Generic.Dictionary<string, object> chances)
    {
        var val_12;
        var val_13;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_64;
        LetterBankRewardChances val_65;
        System.Collections.Generic.List<System.Int32> val_66;
        string val_67;
        var val_68;
        int val_69;
        LetterBankRewardChances val_70;
        LetterBankRewardChances val_71;
        LetterBankRewardChances val_72;
        val_64 = chances;
        this.coin_chances = new LetterBankRewardChances();
        this.card_chances = new LetterBankRewardChances();
        LetterBankRewardChances val_3 = null;
        val_65 = val_3;
        val_3 = new LetterBankRewardChances();
        val_66 = this;
        val_67 = 0;
        this.food_chances = val_65;
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_64.ContainsKey(key:  "c_ch")) != false)
        {
                val_67 = "c_ch";
            object val_5 = val_64.Item[val_67];
            if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.coin_chances == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_7 = System.Int32.TryParse(s:  val_5, result: out  this.coin_chances.percent_chance);
        }
        
        if((val_64.ContainsKey(key:  "c_amt_ch")) == false)
        {
            goto label_149;
        }
        
        val_67 = "c_amt_ch";
        if(val_64.Item[val_67] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_11 = GetEnumerator();
        val_68 = "amt";
        val_69 = 0;
        label_29:
        val_67 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_13.MoveNext() == false)
        {
            goto label_11;
        }
        
        int val_21 = val_69;
        int val_17 = val_69;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.ContainsKey(key:  "amt")) != false)
        {
                val_67 = "amt";
            object val_16 = val_12.Item[val_67];
            if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_18 = System.Int32.TryParse(s:  val_16, result: out  val_17);
        }
        
        val_67 = "ch";
        val_66 = val_12;
        if((val_66.ContainsKey(key:  val_67)) != false)
        {
                val_67 = "ch";
            object val_20 = val_12.Item[val_67];
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_22 = System.Int32.TryParse(s:  val_20, result: out  val_21);
        }
        
        if((val_17 < 1) || (val_21 < 1))
        {
            goto label_29;
        }
        
        val_70 = this.coin_chances;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.coin_chances.reward_amounts == null)
        {
                System.Collections.Generic.List<System.Int32> val_23 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_23 = new System.Collections.Generic.List<System.Int32>();
            this.coin_chances.reward_amounts = val_23;
            val_70 = this.coin_chances;
            if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.coin_chances.reward_amounts_chances == null)
        {
                System.Collections.Generic.List<System.Int32> val_24 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_24 = new System.Collections.Generic.List<System.Int32>();
            this.coin_chances.reward_amounts_chances = val_24;
            val_70 = this.coin_chances;
            if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_66 = this.coin_chances.reward_amounts;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_67 = val_17;
        val_66.Add(item:  0);
        if(this.coin_chances == null)
        {
                throw new NullReferenceException();
        }
        
        val_66 = this.coin_chances.reward_amounts_chances;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.Add(item:  0);
        goto label_29;
        label_11:
        val_13.Dispose();
        val_64 = val_64;
        label_149:
        if((val_64.ContainsKey(key:  "crd_ch")) != false)
        {
                val_67 = "crd_ch";
            object val_26 = val_64.Item[val_67];
            if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.card_chances == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_28 = System.Int32.TryParse(s:  val_26, result: out  this.card_chances.percent_chance);
        }
        
        if((val_64.ContainsKey(key:  "crd_amt_ch")) == false)
        {
            goto label_146;
        }
        
        val_67 = "crd_amt_ch";
        if(val_64.Item[val_67] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_32 = GetEnumerator();
        val_68 = "amt";
        val_69 = 0;
        label_57:
        val_67 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_13.MoveNext() == false)
        {
            goto label_39;
        }
        
        int val_40 = val_69;
        int val_36 = val_69;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.ContainsKey(key:  "amt")) != false)
        {
                val_67 = "amt";
            object val_35 = val_12.Item[val_67];
            if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_37 = System.Int32.TryParse(s:  val_35, result: out  val_36);
        }
        
        val_67 = "ch";
        val_66 = val_12;
        if((val_66.ContainsKey(key:  val_67)) != false)
        {
                val_67 = "ch";
            object val_39 = val_12.Item[val_67];
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_41 = System.Int32.TryParse(s:  val_39, result: out  val_40);
        }
        
        if((val_36 < 1) || (val_40 < 1))
        {
            goto label_57;
        }
        
        val_71 = this.card_chances;
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.card_chances.reward_amounts == null)
        {
                System.Collections.Generic.List<System.Int32> val_42 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_42 = new System.Collections.Generic.List<System.Int32>();
            this.card_chances.reward_amounts = val_42;
            val_71 = this.card_chances;
            if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.card_chances.reward_amounts_chances == null)
        {
                System.Collections.Generic.List<System.Int32> val_43 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_43 = new System.Collections.Generic.List<System.Int32>();
            this.card_chances.reward_amounts_chances = val_43;
            val_71 = this.card_chances;
            if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_66 = this.card_chances.reward_amounts;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_67 = val_36;
        val_66.Add(item:  0);
        if(this.card_chances == null)
        {
                throw new NullReferenceException();
        }
        
        val_66 = this.card_chances.reward_amounts_chances;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.Add(item:  0);
        goto label_57;
        label_39:
        val_13.Dispose();
        val_64 = val_64;
        label_146:
        if((val_64.ContainsKey(key:  "fd_ch")) != false)
        {
                val_67 = "fd_ch";
            object val_45 = val_64.Item[val_67];
            if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.food_chances == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_47 = System.Int32.TryParse(s:  val_45, result: out  this.food_chances.percent_chance);
        }
        
        if((val_64.ContainsKey(key:  "fd_amt_ch")) == false)
        {
            goto label_144;
        }
        
        val_67 = "fd_amt_ch";
        val_65 = 1152921510214912464;
        if(val_64.Item[val_67] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_51 = GetEnumerator();
        val_69 = 1152921504685600768;
        val_68 = "ch";
        label_85:
        val_67 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_13.MoveNext() == false)
        {
            goto label_67;
        }
        
        int val_59 = 0;
        int val_55 = 0;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.ContainsKey(key:  "amt")) != false)
        {
                val_67 = "amt";
            object val_54 = val_12.Item[val_67];
            if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_56 = System.Int32.TryParse(s:  val_54, result: out  val_55);
        }
        
        val_67 = "ch";
        val_66 = val_12;
        if((val_66.ContainsKey(key:  val_67)) != false)
        {
                val_67 = "ch";
            object val_58 = val_12.Item[val_67];
            if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_60 = System.Int32.TryParse(s:  val_58, result: out  val_59);
        }
        
        if((val_55 < 1) || (val_59 < 1))
        {
            goto label_85;
        }
        
        val_72 = this.food_chances;
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.food_chances.reward_amounts == null)
        {
                System.Collections.Generic.List<System.Int32> val_61 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_61 = new System.Collections.Generic.List<System.Int32>();
            this.food_chances.reward_amounts = val_61;
            val_72 = this.food_chances;
            if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.food_chances.reward_amounts_chances == null)
        {
                System.Collections.Generic.List<System.Int32> val_62 = null;
            val_67 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_62 = new System.Collections.Generic.List<System.Int32>();
            this.food_chances.reward_amounts_chances = val_62;
            val_72 = this.food_chances;
        }
        
        val_66 = this.food_chances.reward_amounts;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_67 = val_55;
        val_66.Add(item:  0);
        if(this.food_chances == null)
        {
                throw new NullReferenceException();
        }
        
        val_66 = this.food_chances.reward_amounts_chances;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.Add(item:  0);
        goto label_85;
        label_67:
        val_13.Dispose();
        label_144:
        this.successfullyParsed = true;
    }
    public System.Collections.Generic.List<GiftReward> RollRewards()
    {
        LetterBankRewardChances val_17;
        LetterBankRewardChances val_18;
        LetterBankRewardChances val_19;
        var val_20;
        LetterBankRewardChances val_21;
        LetterBankRewardChances val_22;
        LetterBankRewardChances val_23;
        LetterBankRewardChances val_24;
        System.Collections.Generic.List<GiftReward> val_1 = new System.Collections.Generic.List<GiftReward>();
        if((UnityEngine.Random.Range(min:  0, max:  100)) < this.coin_chances.percent_chance)
        {
                RandomSet val_3 = new RandomSet();
            .replacement = false;
            val_17 = this.coin_chances;
            if(W9 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_17 = this.coin_chances;
        }
        
            if(W9 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.add(item:  this.coin_chances.reward_amounts_chances, weight:  (float)this.coin_chances.reward_amounts_chances);
            val_18 = this.coin_chances;
            if(W9 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_18 = this.coin_chances;
        }
        
            if(W9 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.add(item:  this.coin_chances.reward_amounts, weight:  (float)(float)this.coin_chances.reward_amounts_chances);
            val_19 = this.coin_chances;
            if(W9 <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_19 = this.coin_chances;
        }
        
            if(W9 <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.add(item:  this.coin_chances.reward_amounts, weight:  (float)(float)(float)this.coin_chances.reward_amounts_chances);
            val_20 = WGGiftRewardManager<WADGiftRewardManager>.Instance.MakeRewards(rewardType:  0, rewardAmount:  val_3.roll(unweighted:  false));
            if((public static WADGiftRewardManager WGGiftRewardManager<WADGiftRewardManager>::get_Instance()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1.Add(item:  public System.Void System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo>::Add(TRVTriviaPursuitCategoryDisplayInfo item));
        }
        
        if((UnityEngine.Random.Range(min:  0, max:  100)) < this.card_chances.percent_chance)
        {
                RandomSet val_8 = new RandomSet();
            .replacement = false;
            val_21 = this.card_chances;
            if((public System.Void System.Collections.Generic.List<GiftReward>::Add(GiftReward item)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_21 = this.card_chances;
        }
        
            if((public System.Void System.Collections.Generic.List<GiftReward>::Add(GiftReward item)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8.add(item:  this.card_chances.reward_amounts_chances, weight:  (float)this.card_chances.reward_amounts_chances);
            val_22 = this.card_chances;
            if(1152921516090981088 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_22 = this.card_chances;
        }
        
            if(1152921516090981088 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8.add(item:  this.card_chances.reward_amounts, weight:  (float)(float)this.card_chances.reward_amounts_chances);
            val_20 = WGGiftRewardManager<WADGiftRewardManager>.Instance.MakeRewards(rewardType:  3, rewardAmount:  val_8.roll(unweighted:  false));
            if((public static WADGiftRewardManager WGGiftRewardManager<WADGiftRewardManager>::get_Instance()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1.Add(item:  public System.Void System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo>::Add(TRVTriviaPursuitCategoryDisplayInfo item));
        }
        
        if((UnityEngine.Random.Range(min:  0, max:  100)) >= this.food_chances.percent_chance)
        {
                return val_1;
        }
        
        RandomSet val_13 = null;
        val_20 = val_13;
        val_13 = new RandomSet();
        .replacement = false;
        val_23 = this.food_chances;
        if((public System.Void System.Collections.Generic.List<GiftReward>::Add(GiftReward item)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_23 = this.food_chances;
        }
        
        if((public System.Void System.Collections.Generic.List<GiftReward>::Add(GiftReward item)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_13.add(item:  this.food_chances.reward_amounts_chances, weight:  (float)this.food_chances.reward_amounts_chances);
        val_24 = this.food_chances;
        if(1152921516090981088 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_24 = this.food_chances;
        }
        
        if(1152921516090981088 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_13.add(item:  -1178583392, weight:  (float)(float)this.food_chances.reward_amounts_chances);
        System.Collections.Generic.List<GiftReward> val_16 = WGGiftRewardManager<WADGiftRewardManager>.Instance.MakeRewards(rewardType:  1, rewardAmount:  val_13.roll(unweighted:  false));
        if((public static WADGiftRewardManager WGGiftRewardManager<WADGiftRewardManager>::get_Instance()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1.Add(item:  public System.Void System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo>::Add(TRVTriviaPursuitCategoryDisplayInfo item));
        return val_1;
    }

}
