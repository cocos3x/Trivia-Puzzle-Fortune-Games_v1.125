using UnityEngine;
public class FPHEcon : GameEcon
{
    // Fields
    private int levelEntryFee;
    public int levelsPerChapter;
    private int baseLevelCompletionReward;
    public decimal startingCoins;
    public int startingGems;
    public int rewardedVideoGemReward;
    public int keyboardTutorialRewardMultiplier;
    public int solveReminderUnlockLevel;
    private System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<int>> chestRewardMultis;
    private System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<int>> chestRewardBucketA;
    private System.Collections.Generic.Dictionary<FPHChestType, int> chestWeights;
    private int defaultTokens;
    public int consonantCost;
    private int vowelCost;
    private int powerupHintUnlockLevel;
    private int powerupHintFtuxLevel;
    private int powerupHintFreeUsageLevelLimit;
    private int powerupHintCost;
    private int powerupRemoveUnlockLevel;
    private int powerupRemoveFtuxLevel;
    private int powerupRemoveFreeUsageLevelLimit;
    private int powerupRemoveCost;
    private int powerupRemoveQty;
    public System.Collections.Generic.List<char> vowels;
    public int portriatCollectionUnlockLevel;
    public int PortraitCollectionDurationHours;
    public int[] starsPerPortrait;
    public static System.Collections.Generic.List<GiftRewardTypeChance> ChapterRewardTypeChances;
    public static System.Collections.Generic.List<GiftRewardTypeChance> DailyBonusRewardTypeChances;
    public static System.Collections.Generic.List<GiftRewardTier> DailyBonusCoinRewardTiers;
    public static System.Collections.Generic.List<GiftRewardTier> DailyBonusFTUXCoinRewardTiers;
    public static System.Collections.Generic.List<GiftRewardTier> DailyBonusPickAnotherCoinRewardTiers;
    public static System.Collections.Generic.List<GiftRewardTier> ChapterRewardCoinRewardTiers;
    public int qotdUnlockLevel;
    public FPHQOTDPhrase QotdNormalReward;
    public FPHQOTDPhrase QotdBonusReward;
    public int multiplierChestUnlockLevel;
    
    // Properties
    public int LevelEntryFee { get; }
    public int BaseLevelCompletionReward { get; }
    public System.Collections.Generic.Dictionary<FPHChestType, int> ChestWeights { get; }
    public int DefaultTokens { get; }
    public int VowelCost { get; }
    public int PowerupHintUnlockLevel { get; }
    public int PowerupHintFtuxLevel { get; }
    public int PowerupHintFreeUsageLevelLimit { get; }
    public int PowerupHintCost { get; }
    public int PowerupRemoveUnlockLevel { get; }
    public int PowerupRemoveFtuxLevel { get; }
    public int PowerupRemoveFreeUsageLevelLimit { get; }
    public int PowerupRemoveCost { get; }
    public int PowerupRemoveQty { get; }
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> GiftRewardTypeChances { get; }
    
    // Methods
    public int get_LevelEntryFee()
    {
        return (int)this.levelEntryFee;
    }
    public int get_BaseLevelCompletionReward()
    {
        return (int)this.baseLevelCompletionReward;
    }
    public System.Collections.Generic.Dictionary<FPHChestType, int> get_ChestWeights()
    {
        return (System.Collections.Generic.Dictionary<FPHChestType, System.Int32>)this.chestWeights;
    }
    public FPHChestType GetChestType()
    {
        var val_8;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_8 = 0;
            return (FPHChestType)val_8;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 2)
        {
                val_8 = 1;
            return (FPHChestType)val_8;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if((val_3.<metaGameBehavior>k__BackingField) == 3)
        {
                val_8 = 2;
            return (FPHChestType)val_8;
        }
        
        RandomSet val_4 = new RandomSet();
        val_4.add(item:  0, weight:  (float)this.chestWeights.Item[0]);
        val_4.add(item:  1, weight:  (float)this.chestWeights.Item[1]);
        val_4.add(item:  2, weight:  (float)this.chestWeights.Item[2]);
        return val_4.roll(unweighted:  false);
    }
    public int get_DefaultTokens()
    {
        return (int)this.defaultTokens;
    }
    public int get_VowelCost()
    {
        return (int)this.vowelCost;
    }
    public int get_PowerupHintUnlockLevel()
    {
        return (int)this.powerupHintUnlockLevel;
    }
    public int get_PowerupHintFtuxLevel()
    {
        return (int)this.powerupHintFtuxLevel;
    }
    public int get_PowerupHintFreeUsageLevelLimit()
    {
        return (int)this.powerupHintFreeUsageLevelLimit;
    }
    public int get_PowerupHintCost()
    {
        return (int)this.powerupHintCost;
    }
    public int get_PowerupRemoveUnlockLevel()
    {
        return (int)this.powerupRemoveUnlockLevel;
    }
    public int get_PowerupRemoveFtuxLevel()
    {
        return (int)this.powerupRemoveFtuxLevel;
    }
    public int get_PowerupRemoveFreeUsageLevelLimit()
    {
        return (int)this.powerupRemoveFreeUsageLevelLimit;
    }
    public int get_PowerupRemoveCost()
    {
        return (int)this.powerupRemoveCost;
    }
    public int get_PowerupRemoveQty()
    {
        return (int)this.powerupRemoveQty;
    }
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> get_GiftRewardTypeChances()
    {
        System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> val_1 = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>>();
        val_1.Add(key:  0, value:  FPHEcon.DailyBonusRewardTypeChances);
        val_1.Add(key:  2, value:  FPHEcon.DailyBonusRewardTypeChances);
        val_1.Add(key:  1, value:  FPHEcon.DailyBonusRewardTypeChances);
        val_1.Add(key:  3, value:  FPHEcon.ChapterRewardTypeChances);
        return val_1;
    }
    public FPHEcon()
    {
        decimal val_1;
        this.baseLevelCompletionReward = 150;
        this.levelEntryFee = 500;
        this.levelsPerChapter = 10;
        val_1 = new System.Decimal(value:  184);
        mem2[0] = val_1.flags;
        mem2[0] = ;
        System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<System.Int32>> val_2 = new System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<System.Int32>>();
        System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
        val_3.Add(item:  1);
        val_3.Add(item:  2);
        val_3.Add(item:  3);
        val_2.Add(key:  0, value:  val_3);
        System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
        val_4.Add(item:  2);
        val_4.Add(item:  3);
        val_4.Add(item:  4);
        val_2.Add(key:  1, value:  val_4);
        System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>();
        val_5.Add(item:  3);
        val_5.Add(item:  5);
        val_5.Add(item:  7);
        val_2.Add(key:  2, value:  val_5);
        System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
        val_6.Add(item:  4);
        val_6.Add(item:  7);
        val_6.Add(item:  10);
        val_2.Add(key:  3, value:  val_6);
        this.chestRewardMultis = val_2;
        System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<System.Int32>> val_7 = new System.Collections.Generic.Dictionary<FPHChestType, System.Collections.Generic.List<System.Int32>>();
        System.Collections.Generic.List<System.Int32> val_8 = new System.Collections.Generic.List<System.Int32>();
        val_8.Add(item:  1);
        val_8.Add(item:  2);
        val_8.Add(item:  3);
        val_7.Add(key:  0, value:  val_8);
        System.Collections.Generic.List<System.Int32> val_9 = new System.Collections.Generic.List<System.Int32>();
        val_9.Add(item:  2);
        val_9.Add(item:  3);
        val_9.Add(item:  4);
        val_7.Add(key:  1, value:  val_9);
        System.Collections.Generic.List<System.Int32> val_10 = new System.Collections.Generic.List<System.Int32>();
        val_10.Add(item:  3);
        val_10.Add(item:  5);
        val_10.Add(item:  7);
        val_7.Add(key:  2, value:  val_10);
        System.Collections.Generic.List<System.Int32> val_11 = new System.Collections.Generic.List<System.Int32>();
        val_11.Add(item:  4);
        val_11.Add(item:  7);
        val_11.Add(item:  10);
        val_7.Add(key:  3, value:  val_11);
        this.chestRewardBucketA = val_7;
        System.Collections.Generic.Dictionary<FPHChestType, System.Int32> val_12 = new System.Collections.Generic.Dictionary<FPHChestType, System.Int32>();
        val_12.Add(key:  0, value:  60);
        val_12.Add(key:  1, value:  30);
        val_12.Add(key:  2, value:  10);
        this.chestWeights = val_12;
        this.defaultTokens = ;
        this.consonantCost = ;
        this.vowelCost = 8589934607;
        this.powerupHintUnlockLevel = 2;
        this.powerupHintFtuxLevel = ;
        this.powerupHintFreeUsageLevelLimit = ;
        this.powerupHintCost = 12884901918;
        this.powerupRemoveUnlockLevel = 3;
        this.powerupRemoveFtuxLevel = ;
        this.powerupRemoveFreeUsageLevelLimit = ;
        this.powerupRemoveCost = 25769803791;
        this.powerupRemoveQty = 6;
        System.Collections.Generic.List<System.Char> val_13 = new System.Collections.Generic.List<System.Char>();
        val_13.Add(item:  'A');
        val_13.Add(item:  'E');
        val_13.Add(item:  'I');
        val_13.Add(item:  'O');
        val_13.Add(item:  'U');
        this.vowels = val_13;
        this.portriatCollectionUnlockLevel = 6;
        this.PortraitCollectionDurationHours = 48;
        this.starsPerPortrait = new int[12] {1000, 2000, 3000, 4000, 5000, 6000, 7000, 15000, 25000, 35000, 50000, 100000};
        this.qotdUnlockLevel = 6;
        this.QotdNormalReward = new FPHQOTDPhrase(rewardType:  0, rewardAmount:  100, tokens:  150);
        this.QotdBonusReward = new FPHQOTDPhrase(rewardType:  1, rewardAmount:  10, tokens:  80);
        this.multiplierChestUnlockLevel = 20;
        mem[1152921515939356532] = 0;
        mem[1152921515939356888] = 700;
        this.set_Item(key:  0, value:  FPHEcon.DailyBonusCoinRewardTiers);
        this.set_Item(key:  2, value:  FPHEcon.DailyBonusFTUXCoinRewardTiers);
        this.set_Item(key:  1, value:  FPHEcon.DailyBonusPickAnotherCoinRewardTiers);
        this.set_Item(key:  3, value:  FPHEcon.ChapterRewardCoinRewardTiers);
    }
    public System.Collections.Generic.List<int> GetChestRewardMultiplier(FPHChestType type)
    {
        Player val_1 = App.Player;
        if((System.String.op_Equality(a:  val_1.playerBucket.ToLower(), b:  "a")) != false)
        {
                if(this.chestRewardBucketA != null)
        {
                return (System.Collections.Generic.List<System.Int32>)new System.Collections.Generic.List<System.Int32>(collection:  this.chestRewardMultis.Item[type]);
        }
        
            throw new NullReferenceException();
        }
        
        return (System.Collections.Generic.List<System.Int32>)new System.Collections.Generic.List<System.Int32>(collection:  this.chestRewardMultis.Item[type]);
    }
    public override void ReadFromKnobs()
    {
        GiftRewardTier val_122;
        var val_123;
        var val_124;
        GiftRewardTier val_125;
        var val_126;
        System.Collections.Generic.List<T> val_127;
        int val_128;
        string val_129;
        var val_130;
        this.ReadFromKnobs();
        if((16824064.ContainsKey(key:  "dly_bn_v2")) == false)
        {
            goto label_42;
        }
        
        object val_2 = 16824064.Item["dly_bn_v2"];
        if(val_2 == null)
        {
            goto label_42;
        }
        
        if(((val_2.ContainsKey(key:  "cbt")) == false) || (val_2.Item["cbt"] == null))
        {
            goto label_37;
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_5 = null;
        val_122 = public System.Void System.Collections.Generic.List<GiftRewardTier>::.ctor();
        val_5 = new System.Collections.Generic.List<GiftRewardTier>();
        if(1152921515939697216 < 1)
        {
            goto label_13;
        }
        
        var val_121 = 0;
        do
        {
            DailyBonusTier val_6 = new DailyBonusTier();
            if(val_121 >= 1152921504972980224)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_123 = 0;
            val_124 = public System.Void EncodableModel::Decode(System.Collections.Generic.Dictionary<string, object> jasonObject, EncodableModel.TemplateModel sourceModel);
            val_6.Decode(jasonObject:  null, sourceModel:  0);
            GameEcon val_9 = App.getGameEcon;
            if((val_9.dailyBonusTiers.ContainsKey(key:  0)) != true)
        {
                GameEcon val_11 = App.getGameEcon;
            val_124 = public System.Void System.Collections.Generic.Dictionary<System.Int32, DailyBonusTier>::Add(System.Int32 key, DailyBonusTier value);
            val_11.dailyBonusTiers.Add(key:  0, value:  val_6);
        }
        
            GiftRewardTier val_12 = null;
            val_125 = val_12;
            val_12 = new GiftRewardTier();
            if(val_121 >= 1152921504973459456)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_126 = 0;
            val_12.Decode(jasonObject:  null, sourceModel:  0);
            val_122 = val_125;
            val_5.Add(item:  val_12);
            val_121 = val_121 + 1;
        }
        while(val_121 < 1152921515939725984);
        
        goto label_35;
        label_13:
        if(val_5 == null)
        {
            goto label_37;
        }
        
        label_35:
        if(1152921515939697216 >= 1)
        {
                this.set_Item(key:  0, value:  val_5);
        }
        
        label_37:
        if((val_2.ContainsKey(key:  "rv")) != false)
        {
                object val_15 = val_2.Item["rv"];
            if(val_15 != null)
        {
                System.Collections.Generic.List<System.Int32> val_16 = null;
            val_127 = val_16;
            val_128 = public System.Void System.Collections.Generic.List<System.Int32>::.ctor();
            val_16 = new System.Collections.Generic.List<System.Int32>();
            mem[1152921515939929464] = val_127;
            if(1152921510062986752 >= 1)
        {
                val_125 = 1152921504616697856;
            var val_122 = 0;
            if(val_122 >= 1152921510062986752)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_128 = System.Convert.ToInt32(value:  "java.lang.Short");
            val_16.Add(item:  val_128);
            val_122 = val_122 + 1;
        }
        
            System.Collections.Generic.List<GiftRewardTier> val_18 = new System.Collections.Generic.List<GiftRewardTier>();
            val_18.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_15));
            this.set_Item(key:  1, value:  val_18);
        }
        
        }
        
        label_42:
        if((16824064.ContainsKey(key:  "fph_gp")) != false)
        {
                object val_21 = 16824064.Item["fph_gp"];
            if((val_21.ContainsKey(key:  "itb")) != false)
        {
                bool val_25 = System.Int32.TryParse(s:  val_21.Item["itb"], result: out  this.defaultTokens);
        }
        
            if((val_21.ContainsKey(key:  "lef")) != false)
        {
                bool val_29 = System.Int32.TryParse(s:  val_21.Item["lef"], result: out  this.levelEntryFee);
        }
        
            if((val_21.ContainsKey(key:  "v_c")) != false)
        {
                bool val_33 = System.Int32.TryParse(s:  val_21.Item["v_c"], result: out  this.vowelCost);
        }
        
            if((val_21.ContainsKey(key:  "c_c")) != false)
        {
                bool val_37 = System.Int32.TryParse(s:  val_21.Item["c_c"], result: out  this.consonantCost);
        }
        
            if((val_21.ContainsKey(key:  "b_lcr")) != false)
        {
                bool val_41 = System.Int32.TryParse(s:  val_21.Item["b_lcr"], result: out  this.baseLevelCompletionReward);
        }
        
        }
        
        if((16824064.ContainsKey(key:  "fph_p_ups")) != false)
        {
                object val_43 = 16824064.Item["fph_p_ups"];
            if((val_43.ContainsKey(key:  "hint")) != false)
        {
                object val_45 = val_43.Item["hint"];
            if((val_45.ContainsKey(key:  "c")) != false)
        {
                bool val_49 = System.Int32.TryParse(s:  val_45.Item["c"], result: out  this.powerupHintCost);
        }
        
            if((val_45.ContainsKey(key:  "ul")) != false)
        {
                bool val_53 = System.Int32.TryParse(s:  val_45.Item["ul"], result: out  this.powerupHintUnlockLevel);
        }
        
            if((val_45.ContainsKey(key:  "ftux")) != false)
        {
                bool val_57 = System.Int32.TryParse(s:  val_45.Item["ftux"], result: out  this.powerupHintFtuxLevel);
        }
        
        }
        
            if((val_43.ContainsKey(key:  "r_lett")) != false)
        {
                object val_59 = val_43.Item["r_lett"];
            if((val_59.ContainsKey(key:  "c")) != false)
        {
                bool val_63 = System.Int32.TryParse(s:  val_59.Item["c"], result: out  this.powerupRemoveCost);
        }
        
            if((val_59.ContainsKey(key:  "ul")) != false)
        {
                bool val_67 = System.Int32.TryParse(s:  val_59.Item["ul"], result: out  this.powerupRemoveUnlockLevel);
        }
        
            if((val_59.ContainsKey(key:  "ftux")) != false)
        {
                bool val_71 = System.Int32.TryParse(s:  val_59.Item["ftux"], result: out  this.powerupRemoveFtuxLevel);
        }
        
        }
        
        }
        
        val_129 = "va_rew_gems";
        if((16824064.ContainsKey(key:  val_129)) != false)
        {
                val_129 = this.rewardedVideoGemReward;
            bool val_74 = System.Int32.TryParse(s:  16824064.Item["va_rew_gems"], result: out  val_129);
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_75 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_76 = new System.Collections.Generic.List<System.Object>();
        GameEcon val_77 = App.getGameEcon;
        val_76.Add(item:  val_77.dbFtuxCr);
        val_75.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_76));
        val_130 = 1152921515939330608;
        this.set_Item(key:  2, value:  val_75);
        this.set_Item(key:  3, value:  FPHEcon.ChapterRewardCoinRewardTiers);
        if((16824064.ContainsKey(key:  "fph_lul")) != false)
        {
                bool val_82 = System.Int32.TryParse(s:  16824064.Item["fph_lul"], result: out  1152921515939929956);
        }
        
        if((16824064.ContainsKey(key:  "da_ph")) != false)
        {
                val_130 = 1152921510214912464;
            object val_84 = 16824064.Item["da_ph"];
            if((val_84.ContainsKey(key:  "ul")) != false)
        {
                int val_87 = 6;
            if((System.Int32.TryParse(s:  val_84.Item["ul"], result: out  val_87)) != false)
        {
                this.qotdUnlockLevel = 6;
        }
        
            if((val_84.ContainsKey(key:  "ph1")) != false)
        {
                object val_90 = val_84.Item["ph1"];
            if((val_90.ContainsKey(key:  "rew_c")) != false)
        {
                if((System.Int32.TryParse(s:  val_90.Item["rew_c"], result: out  val_87)) != false)
        {
                this.QotdNormalReward.rewardAmount = 6;
        }
        
        }
        
            if((val_90.ContainsKey(key:  "tok")) != false)
        {
                if((System.Int32.TryParse(s:  val_90.Item["tok"], result: out  val_87)) != false)
        {
                this.QotdNormalReward.tokensAmount = 6;
        }
        
        }
        
        }
        
            if((val_84.ContainsKey(key:  "ph2")) != false)
        {
                object val_98 = val_84.Item["ph2"];
            if((val_98.ContainsKey(key:  "rew_g")) != false)
        {
                if((System.Int32.TryParse(s:  val_98.Item["rew_g"], result: out  val_87)) != false)
        {
                this.QotdBonusReward.rewardAmount = 6;
        }
        
        }
        
            if((val_98.ContainsKey(key:  "tok")) != false)
        {
                if((System.Int32.TryParse(s:  val_98.Item["tok"], result: out  val_87)) != false)
        {
                this.QotdBonusReward.tokensAmount = 6;
        }
        
        }
        
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "po_col")) != false)
        {
                object val_106 = 16824064.Item["po_col"];
            val_130 = "ul";
            if((val_106.ContainsKey(key:  "ul")) != false)
        {
                if((System.Int32.TryParse(s:  val_106.Item["ul"], result: out  6)) != false)
        {
                this.portriatCollectionUnlockLevel = 6;
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "fph_cm")) != false)
        {
                object val_112 = 16824064.Item["fph_cm"];
            val_130 = "ul";
            if((val_112.ContainsKey(key:  "ul")) != false)
        {
                if((System.Int32.TryParse(s:  val_112.Item["ul"], result: out  20)) != false)
        {
                this.multiplierChestUnlockLevel = 20;
        }
        
        }
        
        }
        
        if((16824064.ContainsKey(key:  "sr_ul")) == false)
        {
                return;
        }
        
        bool val_120 = System.Int32.TryParse(s:  16824064.Item["sr_ul"], result: out  0);
        this.solveReminderUnlockLevel = 0;
    }
    private static FPHEcon()
    {
        System.Collections.Generic.List<GiftRewardTypeChance> val_1 = new System.Collections.Generic.List<GiftRewardTypeChance>();
        val_1.Add(item:  new GiftRewardTypeChance(rewardType:  0, chance:  100));
        FPHEcon.ChapterRewardTypeChances = val_1;
        System.Collections.Generic.List<GiftRewardTypeChance> val_3 = new System.Collections.Generic.List<GiftRewardTypeChance>();
        val_3.Add(item:  new GiftRewardTypeChance(rewardType:  0, chance:  100));
        FPHEcon.DailyBonusRewardTypeChances = val_3;
        System.Collections.Generic.List<GiftRewardTier> val_5 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_6 = new System.Collections.Generic.List<System.Object>();
        val_6.Add(item:  500);
        val_6.Add(item:  600);
        val_6.Add(item:  700);
        val_5.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_6));
        System.Collections.Generic.List<System.Object> val_8 = new System.Collections.Generic.List<System.Object>();
        val_8.Add(item:  400);
        val_8.Add(item:  500);
        val_8.Add(item:  600);
        val_5.Add(item:  new GiftRewardTier(threshold:  "500", rewards:  val_8));
        System.Collections.Generic.List<System.Object> val_10 = new System.Collections.Generic.List<System.Object>();
        val_10.Add(item:  300);
        val_10.Add(item:  400);
        val_10.Add(item:  500);
        val_5.Add(item:  new GiftRewardTier(threshold:  "1000", rewards:  val_10));
        System.Collections.Generic.List<System.Object> val_12 = new System.Collections.Generic.List<System.Object>();
        val_12.Add(item:  200);
        val_12.Add(item:  300);
        val_12.Add(item:  400);
        val_5.Add(item:  new GiftRewardTier(threshold:  "1500", rewards:  val_12));
        System.Collections.Generic.List<System.Object> val_14 = new System.Collections.Generic.List<System.Object>();
        val_14.Add(item:  100);
        val_14.Add(item:  200);
        val_14.Add(item:  300);
        val_5.Add(item:  new GiftRewardTier(threshold:  "2000", rewards:  val_14));
        FPHEcon.DailyBonusCoinRewardTiers = val_5;
        System.Collections.Generic.List<GiftRewardTier> val_16 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_17 = new System.Collections.Generic.List<System.Object>();
        val_17.Add(item:  700);
        val_16.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_17));
        FPHEcon.DailyBonusFTUXCoinRewardTiers = val_16;
        System.Collections.Generic.List<GiftRewardTier> val_19 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_20 = new System.Collections.Generic.List<System.Object>();
        val_20.Add(item:  10);
        val_20.Add(item:  15);
        val_20.Add(item:  20);
        val_19.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_20));
        FPHEcon.DailyBonusPickAnotherCoinRewardTiers = val_19;
        System.Collections.Generic.List<GiftRewardTier> val_22 = new System.Collections.Generic.List<GiftRewardTier>();
        System.Collections.Generic.List<System.Object> val_23 = new System.Collections.Generic.List<System.Object>();
        val_23.Add(item:  500);
        val_23.Add(item:  600);
        val_23.Add(item:  700);
        val_22.Add(item:  new GiftRewardTier(threshold:  "0", rewards:  val_23));
        System.Collections.Generic.List<System.Object> val_25 = new System.Collections.Generic.List<System.Object>();
        val_25.Add(item:  400);
        val_25.Add(item:  500);
        val_25.Add(item:  600);
        val_22.Add(item:  new GiftRewardTier(threshold:  "500", rewards:  val_25));
        System.Collections.Generic.List<System.Object> val_27 = new System.Collections.Generic.List<System.Object>();
        val_27.Add(item:  300);
        val_27.Add(item:  400);
        val_27.Add(item:  500);
        val_22.Add(item:  new GiftRewardTier(threshold:  "1000", rewards:  val_27));
        System.Collections.Generic.List<System.Object> val_29 = new System.Collections.Generic.List<System.Object>();
        val_29.Add(item:  200);
        val_29.Add(item:  300);
        val_29.Add(item:  400);
        val_22.Add(item:  new GiftRewardTier(threshold:  "1500", rewards:  val_29));
        System.Collections.Generic.List<System.Object> val_31 = new System.Collections.Generic.List<System.Object>();
        val_31.Add(item:  100);
        val_31.Add(item:  200);
        val_31.Add(item:  300);
        val_22.Add(item:  new GiftRewardTier(threshold:  "2000", rewards:  val_31));
        FPHEcon.ChapterRewardCoinRewardTiers = val_22;
    }

}
