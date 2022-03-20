using UnityEngine;
public class TRVEcon : GameEcon
{
    // Fields
    private static bool overridenInitialValues;
    public float quizDuration;
    public int extraLifeCost;
    public int extraLifeCoolDown;
    public int categoryRerollCost;
    public int veryEasyLevelLimit;
    public int ftux2LevelLimit;
    public int levelsPerChapter;
    public int chapterReward;
    private int _quizEntryCost;
    public float quizRewardConstant;
    public bool doubleChapterRewardEnabled;
    public int playLastCategoryCost;
    public int rewardedVideoGemReward;
    public int hintReminderUnlockLevel;
    public bool hintReminderEnabled;
    public int hintReminderLevelInterval;
    public int hintReminderMaxViews;
    public int videosForExtraLife;
    public int askExpertGemCost;
    public int expertCooldownHours;
    public int earlyCategoryUnlockCost;
    public int earlyCategoryUnlockLevel;
    public int variableEntryUnlock;
    public int maxStreak;
    public bool variableLevelCompleteRewardEnabled;
    public int multiplierRedrawUnlockLevel;
    public int expertsUnlockLevel;
    public int maxExtraLives;
    public bool bonusRewardedLivesEnabled;
    public int moreCategoriesShowLevel;
    public int[] variableEntryCost;
    public int[] variableMultipliers;
    private System.Collections.Generic.List<BonusRewardsContainer> trvBonusRewardDefaultData;
    public System.Collections.Generic.Dictionary<TRVExpertRarites, int> expertOdds;
    private System.Collections.Generic.List<GiftRewardTier> returnList;
    private static System.Collections.Generic.List<GiftRewardTier> TRVDailyBonusCoinRewardTiersV2;
    public TRVQotdEcon qotdEcon;
    public decimal startingCoins;
    public int startingGems;
    public int lowGemThreshold;
    private System.Collections.Generic.List<GiftRewardTypeChance> TRVDailyBonusRewardChances;
    public System.Collections.Generic.Dictionary<TRVCategoryID, int> primaryCategoryOdds;
    public System.Collections.Generic.Dictionary<ChestType, System.Collections.Generic.List<int>> chestRewardMultis;
    public System.Collections.Generic.Dictionary<ChestType, int> chestWeights;
    public System.Collections.Generic.Dictionary<int, int[]> quizDifficultyOrders;
    public System.Collections.Generic.Dictionary<int, int[]> FTUX2quizDifficultyOrders;
    public int[] initialQuizLength;
    public int[] quizLengthArray;
    private System.Collections.Generic.Dictionary<int, int> quizLengthBucketA;
    private System.Collections.Generic.Dictionary<int, int> quizLengthBucketB;
    public static System.Collections.Generic.Dictionary<string, int> DefaultCategoryUnlockLevels;
    public System.Collections.Generic.Dictionary<TRVPowerupType, PowerupEcon> PowerupData;
    public System.Collections.Generic.Dictionary<int, TRVCategoryRankInfo> TRVCategoryRankEcon;
    public TriviaMastersEcon TriviaMastersEventEcon;
    public TriviaPursuitEcon TriviaPursuitEventEcon;
    public System.Collections.Generic.List<StarChampionshipTier> StarChampionshipEventEcon;
    
    // Properties
    public int defaultQuizEntryCost { get; }
    public int dynamicQuizEntryCost { get; }
    public override System.Collections.Generic.List<BonusRewardsContainer> bonusRewardTiers { get; }
    public System.Collections.Generic.List<GiftRewardTier> DailyBonusTiersV2 { get; }
    public override int ltb_interval { get; }
    public System.Collections.Generic.List<GiftRewardTypeChance> DailyBonusRewardChances { get; }
    public System.Collections.Generic.Dictionary<int, int> quizLength { get; }
    
    // Methods
    public int get_defaultQuizEntryCost()
    {
        return (int)this._quizEntryCost;
    }
    public int get_dynamicQuizEntryCost()
    {
        int val_6;
        var val_7;
        if(((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  this.variableEntryUnlock)) != false) && ((TRVMainController.currentMultiplier & 2147483648) == 0))
        {
                if(TRVMainController.currentMultiplier < this.variableEntryCost.Length)
        {
                val_6 = this.variableEntryCost[TRVMainController.currentMultiplier];
            val_7 = null;
            return UnityEngine.Mathf.Max(a:  100, b:  val_6 = this._quizEntryCost);
        }
        
        }
        
        val_7 = null;
        return UnityEngine.Mathf.Max(a:  100, b:  val_6);
    }
    public override System.Collections.Generic.List<BonusRewardsContainer> get_bonusRewardTiers()
    {
        return (System.Collections.Generic.List<BonusRewardsContainer>)this.trvBonusRewardDefaultData;
    }
    public System.Collections.Generic.List<GiftRewardTier> get_DailyBonusTiersV2()
    {
        System.Collections.Generic.List<GiftRewardTier> val_12 = this.returnList;
        if(val_12 != null)
        {
                if(true != 0)
        {
                return val_12;
        }
        
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_1 = null;
        val_12 = val_1;
        val_1 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
        val_2.Add(item:  100);
        val_2.Add(item:  120);
        val_2.Add(item:  150);
        val_1.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_2));
        System.Collections.Generic.List<System.Object> val_4 = new System.Collections.Generic.List<System.Object>();
        val_4.Add(item:  80);
        val_4.Add(item:  100);
        val_4.Add(item:  120);
        val_1.Add(item:  new GiftRewardTier(threshold:  "100", rewards:  val_4));
        System.Collections.Generic.List<System.Object> val_6 = new System.Collections.Generic.List<System.Object>();
        val_6.Add(item:  60);
        val_6.Add(item:  80);
        val_6.Add(item:  100);
        val_1.Add(item:  new GiftRewardTier(threshold:  "250", rewards:  val_6));
        System.Collections.Generic.List<System.Object> val_8 = new System.Collections.Generic.List<System.Object>();
        val_8.Add(item:  40);
        val_8.Add(item:  60);
        val_8.Add(item:  80);
        val_1.Add(item:  new GiftRewardTier(threshold:  "500", rewards:  val_8));
        System.Collections.Generic.List<System.Object> val_10 = new System.Collections.Generic.List<System.Object>();
        val_10.Add(item:  20);
        val_10.Add(item:  40);
        val_10.Add(item:  60);
        val_1.Add(item:  new GiftRewardTier(threshold:  "1000", rewards:  val_10));
        this.returnList = val_12;
        return val_12;
    }
    public override int get_ltb_interval()
    {
        return 4;
    }
    public System.Collections.Generic.List<GiftRewardTypeChance> get_DailyBonusRewardChances()
    {
        return (System.Collections.Generic.List<GiftRewardTypeChance>)this.TRVDailyBonusRewardChances;
    }
    public System.Collections.Generic.Dictionary<int, int> get_quizLength()
    {
        Player val_1 = App.Player;
        var val_4 = ((System.String.op_Equality(a:  val_1.playerBucket.ToLower(), b:  "a")) != true) ? 1688 : 1696;
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)null;
    }
    public override void ReadFromKnobs()
    {
        var val_110;
        var val_111;
        System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32> val_180;
        var val_181;
        TRVQotdEcon val_182;
        TRVQotdEcon val_183;
        var val_184;
        var val_185;
        var val_186;
        var val_187;
        var val_188;
        var val_189;
        var val_190;
        val_180 = this;
        this.ReadFromKnobs();
        if(true == 0)
        {
                throw new NullReferenceException();
        }
        
        if(16824064 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_181 = 1152921504685600768;
        Dictionary.KeyCollection<TKey, TValue> val_1 = 16824064.Keys;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1.Count <= 1)
        {
            goto label_6;
        }
        
        if((16824064.ContainsKey(key:  "vell")) != false)
        {
                object val_4 = 16824064.Item["vell"];
            if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_6 = System.Int32.TryParse(s:  val_4, result: out  this.veryEasyLevelLimit);
        }
        
        if((16824064.ContainsKey(key:  "elrt")) != false)
        {
                object val_8 = 16824064.Item["elrt"];
            if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_10 = System.Int32.TryParse(s:  val_8, result: out  this.extraLifeCoolDown);
        }
        
        if((16824064.ContainsKey(key:  "2x_ccr")) != false)
        {
                object val_12 = 16824064.Item["2x_ccr"];
            if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_14 = System.Boolean.TryParse(value:  val_12, result: out  this.doubleChapterRewardEnabled);
        }
        
        if((16824064.ContainsKey(key:  "qotd")) == false)
        {
            goto label_42;
        }
        
        object val_16 = 16824064.Item["qotd"];
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_16.ContainsKey(key:  "lvl")) != false)
        {
                object val_18 = val_16.Item["lvl"];
            if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.qotdEcon == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_20 = System.Int32.TryParse(s:  val_18, result: out  this.qotdEcon.unlockLevel);
        }
        
        if((val_16.ContainsKey(key:  "rew")) == false)
        {
            goto label_32;
        }
        
        object val_22 = val_16.Item["rew"];
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_22.ContainsKey(key:  "c")) == false)
        {
            goto label_26;
        }
        
        int val_25 = 0;
        object val_24 = val_22.Item["c"];
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_26 = System.Int32.TryParse(s:  val_24, result: out  val_25);
        val_182 = this.qotdEcon;
        val_183 = val_25;
        goto label_28;
        label_6:
        UnityEngine.Debug.LogWarning(message:  "App.getGameEcon.ReadFromKnobs: Knobs Not Found! This should never be the case!");
        return;
        label_26:
        val_183 = "g";
        if((val_22.ContainsKey(key:  "g")) == false)
        {
            goto label_32;
        }
        
        int val_29 = 0;
        object val_28 = val_22.Item["g"];
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_30 = System.Int32.TryParse(s:  val_28, result: out  val_29);
        val_182 = this.qotdEcon;
        val_183 = val_29;
        TRVReward val_31 = null;
        label_28:
        val_184 = 0;
        val_31 = new TRVReward(rewardType:  1, rewardAmount:  0);
        if(val_182 == null)
        {
                throw new NullReferenceException();
        }
        
        this.qotdEcon.normalReward = val_31;
        label_32:
        if((val_16.ContainsKey(key:  "b_rew")) == false)
        {
            goto label_42;
        }
        
        object val_33 = val_16.Item["b_rew"];
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_33.ContainsKey(key:  "c")) == false)
        {
            goto label_39;
        }
        
        object val_35 = val_33.Item["c"];
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_37 = System.Int32.TryParse(s:  val_35, result: out  0);
        val_183 = this.qotdEcon;
        goto label_41;
        label_39:
        if((val_33.ContainsKey(key:  "g")) == false)
        {
            goto label_42;
        }
        
        object val_39 = val_33.Item["g"];
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_41 = System.Int32.TryParse(s:  val_39, result: out  0);
        val_183 = this.qotdEcon;
        TRVReward val_42 = null;
        label_41:
        val_184 = 0;
        val_42 = new TRVReward(rewardType:  1, rewardAmount:  0);
        if(val_183 == null)
        {
                throw new NullReferenceException();
        }
        
        this.qotdEcon.bonusReward = val_42;
        label_42:
        if((16824064.ContainsKey(key:  "qcpc")) != false)
        {
                object val_44 = 16824064.Item["qcpc"];
            if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
            float val_46 = System.Single.Parse(s:  val_44, provider:  System.Globalization.CultureInfo.InvariantCulture);
            this.quizRewardConstant = val_46;
            if(val_46 < 0)
        {
                this.quizRewardConstant = 0.5f;
            UnityEngine.Debug.LogError(message:  "getting quiz prize reward constant less than 0.1, defaulting to 0.5 as a failsafe");
        }
        
        }
        
        if((16824064.ContainsKey(key:  "tcw")) != false)
        {
                object val_48 = 16824064.Item["tcw"];
            if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
            int val_51 = 0;
            if((val_48.ContainsKey(key:  "gk")) != false)
        {
                object val_50 = val_48.Item["gk"];
            if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_50, result: out  val_51)) != false)
        {
                val_180 = this.primaryCategoryOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32>::set_Item(TRVCategoryID key, System.Int32 value);
            val_180.set_Item(key:  0, value:  0);
        }
        
        }
        
            if((val_48.ContainsKey(key:  "s")) != false)
        {
                object val_54 = val_48.Item["s"];
            if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_54, result: out  val_51)) != false)
        {
                val_180 = this.primaryCategoryOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32>::set_Item(TRVCategoryID key, System.Int32 value);
            val_180.set_Item(key:  2, value:  0);
        }
        
        }
        
            val_183 = "e";
            if((val_48.ContainsKey(key:  "e")) != false)
        {
                object val_57 = val_48.Item["e"];
            if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_57, result: out  val_51)) != false)
        {
                val_180 = this.primaryCategoryOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32>::set_Item(TRVCategoryID key, System.Int32 value);
            val_180.set_Item(key:  1, value:  0);
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "lc_c")) != false)
        {
                object val_60 = 16824064.Item["lc_c"];
            if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_62 = System.Int32.TryParse(s:  val_60, result: out  this.playLastCategoryCost);
        }
        
        if((16824064.ContainsKey(key:  "e_c")) == false)
        {
            goto label_98;
        }
        
        object val_64 = 16824064.Item["e_c"];
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        val_185 = val_64;
        int val_67 = 0;
        if((val_185.ContainsKey(key:  "gc")) != false)
        {
                object val_66 = val_185.Item["gc"];
            if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_66, result: out  val_67)) != false)
        {
                this.askExpertGemCost = 0;
        }
        
        }
        
        if((val_185.ContainsKey(key:  "cd_h")) != false)
        {
                object val_70 = val_185.Item["cd_h"];
            if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_70, result: out  val_67)) != false)
        {
                this.expertCooldownHours = 0;
        }
        
        }
        
        val_183 = "crw";
        if((val_185.ContainsKey(key:  "crw")) == false)
        {
            goto label_98;
        }
        
        object val_73 = val_185.Item["crw"];
        if(val_73 == null)
        {
            goto label_84;
        }
        
        val_185 = val_73;
        if(null <= 3)
        {
            goto label_84;
        }
        
        if((System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, result: out  val_67)) != false)
        {
                val_180 = this.expertOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>::set_Item(TRVExpertRarites key, System.Int32 value);
            val_180.set_Item(key:  1, value:  0);
        }
        
        if(1152921517249692448 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_180 = public static System.String[] System.IO.Directory::GetDirectories(string path);
        if((public static System.String[] System.IO.Directory::GetDirectories(string path)) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_180, result: out  val_67)) != false)
        {
                val_180 = this.expertOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>::set_Item(TRVExpertRarites key, System.Int32 value);
            val_180.set_Item(key:  2, value:  0);
        }
        
        if(1152921517249692448 <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_180 = null;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  ToString(), result: out  val_67)) != false)
        {
                val_180 = this.expertOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>::set_Item(TRVExpertRarites key, System.Int32 value);
            val_180.set_Item(key:  3, value:  0);
        }
        
        if(1152921517249692448 <= 3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_180 = null;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  ToString(), result: out  val_67)) != false)
        {
                val_180 = this.expertOdds;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_184 = public System.Void System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>::set_Item(TRVExpertRarites key, System.Int32 value);
            val_180.set_Item(key:  4, value:  0);
        }
        
        label_98:
        if((16824064.ContainsKey(key:  "gem_lbt")) != false)
        {
                object val_81 = 16824064.Item["gem_lbt"];
            if(val_81 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_83 = System.Int32.TryParse(s:  val_81, result: out  this.lowGemThreshold);
        }
        
        if((16824064.ContainsKey(key:  "dly_bn_v2")) == false)
        {
            goto label_123;
        }
        
        object val_85 = 16824064.Item["dly_bn_v2"];
        if(val_85 == null)
        {
            goto label_123;
        }
        
        val_183 = "cbt";
        if(((val_85.ContainsKey(key:  "cbt")) == false) || (val_85.Item["cbt"] == null))
        {
            goto label_123;
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_88 = new System.Collections.Generic.List<GiftRewardTier>();
        if(1152921515939697216 < 1)
        {
            goto label_110;
        }
        
        val_182 = 1152921504973459456;
        var val_179 = 0;
        do
        {
            GiftRewardTier val_89 = null;
            val_183 = val_89;
            val_89 = new GiftRewardTier();
            if(val_179 >= 1152921515939697216)
        {
                val_180 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_183 == null)
        {
                throw new NullReferenceException();
        }
        
            val_186 = 0;
            val_180 = val_183;
            val_89.Decode(jasonObject:  null, sourceModel:  0);
            if(val_88 == null)
        {
                throw new NullReferenceException();
        }
        
            val_88.Add(item:  val_89);
            val_179 = val_179 + 1;
        }
        while(val_179 < null);
        
        goto label_118;
        label_84:
        UnityEngine.Debug.LogError(message:  "not getting prob data correctly");
        return;
        label_110:
        if(val_88 == null)
        {
            goto label_123;
        }
        
        label_118:
        if(1152921515939697216 >= 1)
        {
                val_187 = null;
            val_187 = null;
            val_180 = TRVEcon.TRVDailyBonusCoinRewardTiersV2;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_180.Clear();
            val_180 = TRVEcon.TRVDailyBonusCoinRewardTiersV2;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_180.AddRange(collection:  val_88);
        }
        
        label_123:
        if((16824064.ContainsKey(key:  "cat_eu")) != false)
        {
                object val_92 = 16824064.Item["cat_eu"];
            if(val_92 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_92.ContainsKey(key:  "lvl")) != false)
        {
                object val_94 = val_92.Item["lvl"];
            if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_96 = System.Int32.TryParse(s:  val_94, result: out  this.earlyCategoryUnlockLevel);
        }
        
            val_183 = "cost";
            if((val_92.ContainsKey(key:  "cost")) != false)
        {
                object val_98 = val_92.Item["cost"];
            if(val_98 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_100 = System.Int32.TryParse(s:  val_98, result: out  this.earlyCategoryUnlockCost);
        }
        
        }
        
        if((16824064.ContainsKey(key:  "vpc")) == false)
        {
            goto label_164;
        }
        
        object val_102 = 16824064.Item["vpc"];
        if(val_102 == null)
        {
            goto label_164;
        }
        
        if((val_102.ContainsKey(key:  "lvl")) != false)
        {
                object val_104 = val_102.Item["lvl"];
            if(val_104 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_104, result: out  10)) != false)
        {
                this.variableEntryUnlock = 10;
        }
        
        }
        
        if((val_102.ContainsKey(key:  "qsc")) == false)
        {
            goto label_152;
        }
        
        object val_108 = val_102.Item["qsc"];
        if((val_108 == null) || (null != 4))
        {
            goto label_152;
        }
        
        List.Enumerator<T> val_109 = val_108.GetEnumerator();
        val_183 = 1152921510211410768;
        val_182 = 1152921504619999232;
        val_188 = 1;
        goto label_148;
        label_151:
        val_180 = val_110;
        val_188 = val_188 & ((val_180 > 0) ? 1 : 0);
        label_148:
        if(val_111.MoveNext() == true)
        {
            goto label_151;
        }
        
        val_111.Dispose();
        if((val_188 & 1) != 0)
        {
                val_183 = new int[4];
            if(1152921505059750640 >= 1)
        {
                var val_180 = 0;
            do
        {
            if(1152921505059750640 <= val_180)
        {
                val_180 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_183 == null)
        {
                throw new NullReferenceException();
        }
        
            val_180 = null;
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = mem[TRVGameplayUI.<checkLevelFlyout>d__28];
            val_180 = val_180 + 1;
        }
        while(val_180 < (mem[TRVGameplayUI.<checkLevelFlyout>d__28]));
        
        }
        
            this.variableEntryCost = val_183;
        }
        
        label_152:
        if((val_102.ContainsKey(key:  "vpl_cr")) != false)
        {
                object val_116 = val_102.Item["vpl_cr"];
            if(val_116 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Boolean.TryParse(value:  val_116, result: out  false)) != false)
        {
                this.variableLevelCompleteRewardEnabled = false;
        }
        
        }
        
        label_164:
        if((16824064.ContainsKey(key:  "strk_max")) != false)
        {
                object val_120 = 16824064.Item["strk_max"];
            if(val_120 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_120, result: out  20)) != false)
        {
                this.maxStreak = 20;
        }
        
        }
        
        if((16824064.ContainsKey(key:  "h_r")) != false)
        {
                object val_124 = 16824064.Item["h_r"];
            if(val_124 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_124.ContainsKey(key:  "lvl")) != false)
        {
                object val_126 = val_124.Item["lvl"];
            if(val_126 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_126, result: out  10)) != false)
        {
                this.hintReminderUnlockLevel = 10;
        }
        
        }
        
            if((val_124.ContainsKey(key:  "nh_lvls")) != false)
        {
                object val_130 = val_124.Item["nh_lvls"];
            if(val_130 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_130, result: out  5)) != false)
        {
                this.hintReminderLevelInterval = 5;
        }
        
        }
        
            val_183 = "mv";
            if((val_124.ContainsKey(key:  "mv")) != false)
        {
                object val_134 = val_124.Item["mv"];
            if(val_134 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_134, result: out  3)) != false)
        {
                this.hintReminderMaxViews = 3;
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "mcr_ul")) != false)
        {
                object val_138 = 16824064.Item["mcr_ul"];
            if(val_138 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_138, result: out  8)) != false)
        {
                this.multiplierRedrawUnlockLevel = 8;
        }
        
        }
        
        if((16824064.ContainsKey(key:  "rv_el")) != false)
        {
                val_183 = 1152921510214912464;
            object val_142 = 16824064.Item["rv_el"];
            if(val_142 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_142.ContainsKey(key:  "en")) != false)
        {
                object val_144 = val_142.Item["en"];
            if(val_144 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Boolean.TryParse(value:  val_144, result: out  false)) != false)
        {
                this.bonusRewardedLivesEnabled = false;
        }
        
        }
        
            if((val_142.ContainsKey(key:  "max_el")) != false)
        {
                object val_148 = val_142.Item["max_el"];
            if(val_148 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_148, result: out  2)) != false)
        {
                this.maxExtraLives = UnityEngine.Mathf.Max(a:  2, b:  1);
        }
        
        }
        
            if((val_142.ContainsKey(key:  "num_vid")) != false)
        {
                object val_153 = val_142.Item["num_vid"];
            if(val_153 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_153, result: out  2)) != false)
        {
                this.videosForExtraLife = 2;
        }
        
        }
        
            if((val_142.ContainsKey(key:  "s_l")) != false)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_157.isNew != false)
        {
                val_181 = 1152921504957857792;
            val_189 = null;
            val_189 = null;
            if(TRVEcon.overridenInitialValues != true)
        {
                Player val_158 = App.Player;
            if(val_158 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_158 == 1)
        {
                val_182 = 1152921515677607024;
            if((MonoSingleton<TRVDataParser>.Instance) != 0)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_161.<playerPersistance>k__BackingField) != null)
        {
                object val_162 = val_142.Item["s_l"];
            if(val_162 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_162, result: out  0)) != false)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_165.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_165.<playerPersistance>k__BackingField.<extraFreeLives>k__BackingField = -1;
            if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            val_180 = val_166.<playerPersistance>k__BackingField;
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            val_180.SaveProgress();
            val_190 = null;
            val_190 = null;
            TRVEcon.overridenInitialValues = true;
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "mc_pu")) != false)
        {
                object val_168 = 16824064.Item["mc_pu"];
            if(val_168 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_168, result: out  0)) != false)
        {
                this.moreCategoriesShowLevel = 0;
        }
        
        }
        
        if((16824064.ContainsKey(key:  "elc")) != false)
        {
                object val_172 = 16824064.Item["elc"];
            if(val_172 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_172, result: out  50)) != false)
        {
                this.extraLifeCost = 50;
        }
        
        }
        
        val_185 = "va_rew_gems";
        if((16824064.ContainsKey(key:  "va_rew_gems")) == false)
        {
                return;
        }
        
        object val_176 = AdSegmentation.GetSegementedConfig(key:  "va_rew_gems", knobs:  16824064, addSegment:  false);
        if(val_176 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_178 = System.Int32.TryParse(s:  val_176, result: out  this.rewardedVideoGemReward);
    }
    public TRVEcon()
    {
        this.quizDuration = 30f;
        mem2[0] = ;
        mem2[0] = ;
        this.quizRewardConstant = 0.5f;
        this.doubleChapterRewardEnabled = true;
        mem2[0] = 3.18299368793011E-313;
        this.hintReminderUnlockLevel = 10;
        this.hintReminderEnabled = true;
        this.hintReminderLevelInterval = 5;
        mem2[0] = ;
        mem2[0] = ;
        mem2[0] = 1.06099789587789E-313;
        this.maxExtraLives = 3;
        this.moreCategoriesShowLevel = 2;
        this.variableEntryCost = new int[4] {100, 200, 300, 400};
        this.variableMultipliers = new int[4] {1, 2, 5, 10};
        System.Collections.Generic.List<BonusRewardsContainer> val_3 = new System.Collections.Generic.List<BonusRewardsContainer>();
        val_3.Add(item:  new BonusRewardsContainer(lvl:  0, ptrq:  0, bonusGC:  0, bonusGems:  0, bonusCoins:  0));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  1, ptrq:  200, bonusGC:  10, bonusGems:  5, bonusCoins:  5));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  2, ptrq:  244, bonusGC:  20, bonusGems:  10, bonusCoins:  5));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  3, ptrq:  188, bonusGC:  30, bonusGems:  10, bonusCoins:  10));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  4, ptrq:  176, bonusGC:  40, bonusGems:  15, bonusCoins:  10));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  5, ptrq:  108, bonusGC:  50, bonusGems:  15, bonusCoins:  20));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  6, ptrq:  28, bonusGC:  60, bonusGems:  25, bonusCoins:  25));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  7, ptrq:  136, bonusGC:  70, bonusGems:  30, bonusCoins:  30));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  8, ptrq:  164, bonusGC:  80, bonusGems:  35, bonusCoins:  35));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  9, ptrq:  44, bonusGC:  90, bonusGems:  40, bonusCoins:  40));
        val_3.Add(item:  new BonusRewardsContainer(lvl:  10, ptrq:  208, bonusGC:  100, bonusGems:  50, bonusCoins:  50));
        this.trvBonusRewardDefaultData = val_3;
        System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32> val_15 = new System.Collections.Generic.Dictionary<TRVExpertRarites, System.Int32>();
        val_15.Add(key:  1, value:  40);
        val_15.Add(key:  2, value:  30);
        val_15.Add(key:  3, value:  20);
        val_15.Add(key:  4, value:  10);
        this.expertOdds = val_15;
        decimal val_17;
        this.qotdEcon = new TRVQotdEcon();
        val_17 = new System.Decimal(value:  196);
        this.startingCoins = val_17.flags;
        this.startingGems = 500;
        this.lowGemThreshold = 100;
        System.Collections.Generic.List<GiftRewardTypeChance> val_18 = new System.Collections.Generic.List<GiftRewardTypeChance>();
        val_18.Add(item:  new GiftRewardTypeChance(rewardType:  0, chance:  100));
        val_18.Add(item:  new GiftRewardTypeChance(rewardType:  3, chance:  100));
        val_18.Add(item:  new GiftRewardTypeChance(rewardType:  3, chance:  80));
        val_18.Add(item:  new GiftRewardTypeChance(rewardType:  3, chance:  20));
        this.TRVDailyBonusRewardChances = val_18;
        System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32> val_23 = new System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32>();
        val_23.Add(key:  2, value:  20);
        val_23.Add(key:  1, value:  40);
        val_23.Add(key:  0, value:  40);
        this.primaryCategoryOdds = val_23;
        System.Collections.Generic.Dictionary<ChestType, System.Collections.Generic.List<System.Int32>> val_24 = new System.Collections.Generic.Dictionary<ChestType, System.Collections.Generic.List<System.Int32>>();
        System.Collections.Generic.List<System.Int32> val_25 = new System.Collections.Generic.List<System.Int32>();
        val_25.Add(item:  2);
        val_25.Add(item:  2);
        val_25.Add(item:  4);
        val_24.Add(key:  0, value:  val_25);
        System.Collections.Generic.List<System.Int32> val_26 = new System.Collections.Generic.List<System.Int32>();
        val_26.Add(item:  2);
        val_26.Add(item:  2);
        val_26.Add(item:  3);
        val_26.Add(item:  3);
        val_26.Add(item:  4);
        val_26.Add(item:  5);
        val_24.Add(key:  1, value:  val_26);
        System.Collections.Generic.List<System.Int32> val_27 = new System.Collections.Generic.List<System.Int32>();
        val_27.Add(item:  2);
        val_27.Add(item:  2);
        val_27.Add(item:  3);
        val_27.Add(item:  3);
        val_27.Add(item:  4);
        val_27.Add(item:  4);
        val_27.Add(item:  5);
        val_27.Add(item:  6);
        val_27.Add(item:  7);
        val_24.Add(key:  2, value:  val_27);
        this.chestRewardMultis = val_24;
        System.Collections.Generic.Dictionary<ChestType, System.Int32> val_28 = new System.Collections.Generic.Dictionary<ChestType, System.Int32>();
        val_28.Add(key:  0, value:  60);
        val_28.Add(key:  1, value:  30);
        val_28.Add(key:  2, value:  10);
        this.chestWeights = val_28;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_29 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>();
        val_29.Add(key:  3, value:  new int[3]);
        val_29.Add(key:  4, value:  new int[4]);
        int[] val_32 = new int[5];
        val_32[2] = 1;
        val_29.Add(key:  5, value:  val_32);
        int[] val_33 = new int[6];
        val_33[2] = 1;
        val_33[2] = 1;
        val_29.Add(key:  6, value:  val_33);
        int[] val_34 = new int[7];
        val_34[2] = 1;
        val_34[3] = 1;
        val_29.Add(key:  7, value:  val_34);
        this.quizDifficultyOrders = val_29;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_35 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>();
        val_35.Add(key:  3, value:  new int[3]);
        val_35.Add(key:  4, value:  new int[4]);
        int[] val_38 = new int[5];
        val_38[2] = 1;
        val_35.Add(key:  5, value:  val_38);
        int[] val_39 = new int[6];
        val_39[2] = 1;
        val_39[2] = 1;
        val_35.Add(key:  6, value:  val_39);
        int[] val_40 = new int[7];
        val_40[2] = 1;
        val_40[3] = 1;
        val_35.Add(key:  7, value:  val_40);
        this.FTUX2quizDifficultyOrders = val_35;
        this.initialQuizLength = new int[23] {3, 3, 4, 4, 5, 3, 4, 3, 4, 5, 6, 3, 5, 4, 4, 6, 3, 4, 5, 5, 4, 3, 7};
        this.quizLengthArray = new int[14] {3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7};
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_43 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_43.Add(key:  0, value:  3);
        val_43.Add(key:  0, value:  4);
        val_43.Add(key:  51, value:  5);
        val_43.Add(key:  201, value:  6);
        val_43.Add(key:  245, value:  7);
        this.quizLengthBucketA = val_43;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_44 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_44.Add(key:  0, value:  3);
        val_44.Add(key:  0, value:  4);
        val_44.Add(key:  21, value:  5);
        val_44.Add(key:  100, value:  6);
        val_44.Add(key:  245, value:  7);
        this.quizLengthBucketB = val_44;
        System.Collections.Generic.Dictionary<TRVPowerupType, PowerupEcon> val_45 = new System.Collections.Generic.Dictionary<TRVPowerupType, PowerupEcon>();
        val_45.Add(key:  0, value:  new PowerupEcon(unlockLevel:  3, ftuxLevel:  3, freeLevelLimit:  5, reminderTimeRemaining:  12, cost:  30));
        val_45.Add(key:  1, value:  new PowerupEcon(unlockLevel:  7, ftuxLevel:  7, freeLevelLimit:  10, reminderTimeRemaining:  13, cost:  30));
        val_45.Add(key:  2, value:  new PowerupEcon(unlockLevel:  5, ftuxLevel:  5, freeLevelLimit:  7, reminderTimeRemaining:  19, cost:  30));
        this.PowerupData = val_45;
        System.Collections.Generic.Dictionary<System.Int32, TRVCategoryRankInfo> val_49 = new System.Collections.Generic.Dictionary<System.Int32, TRVCategoryRankInfo>();
        val_49.Add(key:  1, value:  new TRVCategoryRankInfo(goal:  7, reward:  10));
        val_49.Add(key:  2, value:  new TRVCategoryRankInfo(goal:  15, reward:  15));
        val_49.Add(key:  3, value:  new TRVCategoryRankInfo(goal:  20, reward:  20));
        val_49.Add(key:  4, value:  new TRVCategoryRankInfo(goal:  25, reward:  25));
        val_49.Add(key:  5, value:  new TRVCategoryRankInfo(goal:  30, reward:  30));
        val_49.Add(key:  6, value:  new TRVCategoryRankInfo(goal:  40, reward:  40));
        val_49.Add(key:  7, value:  new TRVCategoryRankInfo(goal:  50, reward:  50));
        val_49.Add(key:  8, value:  new TRVCategoryRankInfo(goal:  75, reward:  75));
        val_49.Add(key:  9, value:  new TRVCategoryRankInfo(goal:  100, reward:  100));
        this.TRVCategoryRankEcon = val_49;
        System.Collections.Generic.List<StarChampionshipTier> val_59 = new System.Collections.Generic.List<StarChampionshipTier>();
        val_59.Add(item:  new StarChampionshipTier(tierIndex:  0, goal:  0, reward:  0, isTopTier:  false));
        val_59.Add(item:  new StarChampionshipTier(tierIndex:  1, goal:  208, reward:  10, isTopTier:  false));
        val_59.Add(item:  new StarChampionshipTier(tierIndex:  2, goal:  112, reward:  30, isTopTier:  false));
        val_59.Add(item:  new StarChampionshipTier(tierIndex:  3, goal:  200, reward:  50, isTopTier:  false));
        val_59.Add(item:  new StarChampionshipTier(tierIndex:  4, goal:  168, reward:  75, isTopTier:  true));
        this.StarChampionshipEventEcon = val_59;
    }
    private static TRVEcon()
    {
        TRVEcon.overridenInitialValues = false;
        System.Collections.Generic.List<GiftRewardTier> val_1 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
        val_2.Add(item:  100);
        val_2.Add(item:  120);
        val_2.Add(item:  150);
        val_1.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_2));
        System.Collections.Generic.List<System.Object> val_4 = new System.Collections.Generic.List<System.Object>();
        val_4.Add(item:  80);
        val_4.Add(item:  100);
        val_4.Add(item:  120);
        val_1.Add(item:  new GiftRewardTier(threshold:  "100", rewards:  val_4));
        System.Collections.Generic.List<System.Object> val_6 = new System.Collections.Generic.List<System.Object>();
        val_6.Add(item:  60);
        val_6.Add(item:  80);
        val_6.Add(item:  100);
        val_1.Add(item:  new GiftRewardTier(threshold:  "250", rewards:  val_6));
        System.Collections.Generic.List<System.Object> val_8 = new System.Collections.Generic.List<System.Object>();
        val_8.Add(item:  40);
        val_8.Add(item:  60);
        val_8.Add(item:  80);
        val_1.Add(item:  new GiftRewardTier(threshold:  "500", rewards:  val_8));
        System.Collections.Generic.List<System.Object> val_10 = new System.Collections.Generic.List<System.Object>();
        val_10.Add(item:  20);
        val_10.Add(item:  40);
        val_10.Add(item:  60);
        val_1.Add(item:  new GiftRewardTier(threshold:  "1000", rewards:  val_10));
        TRVEcon.TRVDailyBonusCoinRewardTiersV2 = val_1;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_12 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        val_12.Add(key:  "Animals", value:  0);
        val_12.Add(key:  "Food", value:  0);
        val_12.Add(key:  "Brands", value:  2);
        val_12.Add(key:  "Birds", value:  5);
        val_12.Add(key:  "World Geography", value:  12);
        val_12.Add(key:  "Capital Cities", value:  19);
        val_12.Add(key:  "Biology", value:  26);
        val_12.Add(key:  "Travel", value:  33);
        val_12.Add(key:  "Pets", value:  40);
        val_12.Add(key:  "Landmarks", value:  47);
        val_12.Add(key:  "World History", value:  54);
        val_12.Add(key:  "Literature", value:  61);
        val_12.Add(key:  "Poetry", value:  68);
        val_12.Add(key:  "Technology", value:  75);
        val_12.Add(key:  "Mythology", value:  82);
        val_12.Add(key:  "Science", value:  89);
        val_12.Add(key:  "Art", value:  96);
        val_12.Add(key:  "Oceans", value:  103);
        val_12.Add(key:  "Chemistry", value:  110);
        val_12.Add(key:  "U.S. History", value:  117);
        val_12.Add(key:  "Earth", value:  125);
        val_12.Add(key:  "U.S. Geography", value:  131);
        val_12.Add(key:  "Wine", value:  145);
        val_12.Add(key:  "Basketball", value:  14);
        val_12.Add(key:  "Baseball", value:  11);
        val_12.Add(key:  "Football", value:  3);
        val_12.Add(key:  "Auto Racing", value:  9);
        val_12.Add(key:  "Hockey", value:  18);
        val_12.Add(key:  "Golf", value:  27);
        val_12.Add(key:  "Tennis", value:  36);
        val_12.Add(key:  "Olympics", value:  42);
        val_12.Add(key:  "Soccer", value:  45);
        val_12.Add(key:  "Boxing", value:  65);
        val_12.Add(key:  "Cricket", value:  74);
        val_12.Add(key:  "College Sports", value:  83);
        val_12.Add(key:  "Animated Movies", value:  0);
        val_12.Add(key:  "Pop Culture", value:  0);
        val_12.Add(key:  "Disney", value:  1);
        val_12.Add(key:  "Celebrities", value:  7);
        val_12.Add(key:  "Pop Music", value:  16);
        val_12.Add(key:  "Movies 90s", value:  25);
        val_12.Add(key:  "TV 10s", value:  34);
        val_12.Add(key:  "Music 10s", value:  43);
        val_12.Add(key:  "Movies 10s", value:  52);
        val_12.Add(key:  "Reality TV", value:  62);
        val_12.Add(key:  "Plays & Musicals", value:  70);
        val_12.Add(key:  "Country Music", value:  79);
        val_12.Add(key:  "TV 90s", value:  88);
        val_12.Add(key:  "Sitcoms", value:  97);
        val_12.Add(key:  "Awards", value:  106);
        val_12.Add(key:  "Rock Music", value:  115);
        val_12.Add(key:  "Video Games", value:  124);
        val_12.Add(key:  "Music R&B", value:  133);
        val_12.Add(key:  "Music 00s", value:  142);
        val_12.Add(key:  "Music 90s", value:  151);
        val_12.Add(key:  "Movies 00s", value:  160);
        val_12.Add(key:  "Hip Hop", value:  169);
        val_12.Add(key:  "Action Movies", value:  178);
        val_12.Add(key:  "TV 00s", value:  187);
        val_12.Add(key:  "Foreign Films", value:  196);
        TRVEcon.DefaultCategoryUnlockLevels = val_12;
    }

}
