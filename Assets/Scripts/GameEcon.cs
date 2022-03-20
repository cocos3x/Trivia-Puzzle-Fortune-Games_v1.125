using UnityEngine;
public class GameEcon
{
    // Fields
    public string numberFormatInt;
    public static string numberFormatDecimal;
    private string _titleFormat;
    private bool _formatSet;
    private decimal _base099CreditPackSize;
    private decimal _base199CreditPackSize;
    private decimal _base299CreditPackSize;
    private decimal _base499CreditPackSize;
    private decimal _base999CreditPackSize;
    private decimal _base1999CreditPackSize;
    private decimal _base4999CreditPackSize;
    private decimal _base099GemPackSize;
    public decimal InitialPlayerCoins;
    public int InitialPlayerGems;
    public int InitialPlayerGoldenCurrency;
    private decimal _HintCost;
    private decimal _HintPickerCost;
    private decimal _HintMEGACost;
    public float ChapterClearedRewardMulitplier;
    private decimal InitialChapterClearedReward;
    public int InitialExtraWordsReq;
    public int ExtraWordsIncrement;
    public int ExtraWordsMaxReq;
    public decimal ExtraWordsReward;
    public decimal videoAdReward;
    public decimal nonPurchaserVidReward;
    public decimal oneTimePurchaserVidReward;
    public decimal repeatPurchaserVidReward;
    public decimal videoAdRewardBonusCollect;
    public int NoAdsStarterPackCoinAmount;
    public float NoAdsPackagePriceToUse;
    public float fallbackNoAdsPackagePriceToUse;
    public decimal fbConnectBonus;
    public int dailyBonusHours;
    public System.Collections.Generic.Dictionary<int, DailyBonusTier> dailyBonusTiers;
    public System.Collections.Generic.List<int> dailyBonusVideoRewards;
    public LimitedTimeBundlesEcon LimitedTimeBundlesEcon;
    public int subscriptionPromoPostDailyBonusLevel;
    public decimal ratingReward;
    public decimal wordCoinBonus;
    public decimal emailCollectReward;
    public int emailCollectTimeoutDays;
    public int freeHintPopupLevel;
    public int freeHintPostDailyBonus;
    public int adsControlPopupLevel;
    public int adsControlButtonLevel_max;
    public int adsControlMaxViews;
    public int emailCollectPopupLevel;
    public int extraReqBeginningChapter;
    public int extraReqDefaultLevelsPerChapter;
    public int extraReqIncrement;
    public int extraReqMaxLevelsPerChapter;
    public int extraReqHintsPerCh_BuyNone;
    public int extraReqHintsPerCh_BuyFirst;
    public int extraReqHintsPerCh_BuyRepeat;
    public int extraReqQuantityPerLevel;
    public int extraReqPostPurchaseLvl;
    public int extraReqPostPurchaseMin;
    public int extraReqPostPurchaseMax;
    public int remLevelWordMax;
    public int remWordRemovalPercentage;
    public int hintTutorialLevel;
    public int hintTutorialLevelV2;
    public int hintPickerTutorialLevel;
    public int hintPickerTutorialLevelV2;
    public int hintMEGATutorialLevel;
    public int FInviterLevelComplete;
    public int FInviterCoinsReward;
    public int FInviterFTUX;
    public int FInviter_BR_I;
    public int FInviter_BR_R;
    public int FInviter_SI_I;
    public int FInviter_SI_R;
    public int FInviter_GO_I;
    public int FInviter_GO_R;
    public bool FInviterEnabled;
    public int RecLevel;
    public int RecInterval;
    public int RecLimit;
    public int RecDelay;
    public int difficultySettingPromptLevel;
    public int difficultySettingHintDiscount;
    public int levelGenStartLevel;
    public float plvDesiredNumReqWordsBase;
    public float plvDesiredNumReqWordsIncrement;
    public float plvDesiredNumReqWordsMax;
    public int plvMaxExtraWords;
    public float[] plvReqWordDeviations;
    public int[] plvExtraWordCounts;
    public int[] plvNumWordLengths;
    public float plvDesiredWordLengthBase;
    public float plvDesiredWordLengthIncrement;
    public int plvLettersArrayIncrement;
    public float plvWordLengthMax;
    public int plvNumLettersMax;
    public float plvGivenLettersBase;
    public float plvGivenLettersDecrement;
    public float plvGivenLettersMin;
    public float[] plvWordLengthDeviations;
    public int[] plvLettersArray;
    public int plvHintsPerCh_BuyNone;
    public int plvHintsPerCh_BuyFirst;
    public int plvHintsPerCh_BuyRepeat;
    public float wsaDefaultGridSize;
    public float wsaDefaultGridSizeIncrement;
    public float wsaMaximumGridSize;
    public int wsaMysteryWordIncrement;
    public int wsaMaxMysteryWordQuantity;
    public int ChapterHintThresholdNonBuyer;
    public int ChapterHintThresholdFirstTimeBuyer;
    public int ChapterHintThresholdRepeatBuyer;
    public bool coinStorePack1Override;
    public int scsStandardEntryCost;
    public int scsVideosPerLuckyCash;
    public int scsMinimumCashOutBankBalance;
    private int hintDiscountSizePercent;
    public int hintDiscountChapterMinutes;
    public int hintDiscountDailyBonusMinutes;
    public int hintDiscountChapterFreq;
    public float extraChapterEventMultiplier;
    public int alphabetOneMoreCost;
    public System.Collections.Generic.List<object> alphabetRewards;
    public int starUnlockLevel;
    public System.Collections.Generic.Dictionary<string, object> goalsHashes;
    public int starRowDif;
    public int starStreakDif;
    public int mysteryGiftUnlockLevel;
    public int mysteryGiftFlyoutLevelInterval;
    public int mysteryGiftReward;
    public int finalForcedLetterLayoutLevel;
    public int storyPopupLevel;
    public System.Collections.Generic.List<int> WADHardLevels;
    public int hintPickerUnlockLevel;
    public int hintPickerUnlockLevelV2;
    public int shuffleHintFtuxLevel;
    public int leaguesUnlockLevel;
    public bool ftuxTutorialEnabled;
    public int maxLevelEasyLetters;
    public int postLevelRewardedVideo_Level;
    public int postLevelRewardedVideo_minLevels;
    public int postLevelRewardedVideo_maxLevels;
    public float postLevelRewardedVideo_freq;
    public float postLevelCollectionTile_freq;
    public float postLevelAdsControl_freq;
    public int postLevelAdsControl_duration;
    public int postLevelAdsControl_minLvl;
    public int notificationPromptUnlockLevel;
    public int notificationUnlockInterval;
    public int notificationUnlockAppearances;
    public bool offersEnabled;
    public bool surveysEnabled;
    public decimal ab_completeCollectionReward;
    public int ab_minLevelsPerTile;
    public int ab_maxLevelsPerTile;
    public int ab_postLevelTileFreq_Modulo;
    public int ab_unlockLevel;
    public decimal ab_redrawCoinCost;
    public int[] bonusGameWheelAwardCoins;
    public int[] bonusGameWheelAwardGoldenCurrency;
    public bool starterPackEnabled;
    public int starterPackLevel;
    public System.TimeSpan starterPackTimeSpan;
    public System.TimeSpan starterPackWaterfalDelay;
    public int FOMOPackUnlockedLevel;
    public decimal FOMOMaxBalance;
    public int FOMOLevelInterval;
    public System.TimeSpan FOMOPackTimeSpan;
    private int _challengeWordsunlockLevel;
    private int _challengeWordsLevelCooldown;
    private int _challengeWordsWordChance;
    public int events_unlockLevel;
    public int freeHintFinalLevel;
    public int freeHintInitialTooltip;
    public int freeHintEndingTooltip;
    public int spHintsPerLevel;
    public float spHintConstant;
    public int spHintStartLevel;
    public int spHintEndLevel;
    public float WIQ_BaseIQ;
    public float WIQ_MaxNEWWORDIQCompensation;
    public float WIQ_LevelClearIQCompensation_a;
    public float WIQ_LevelClearIQCompensation_b;
    public float WIQ_BaseNewWordPoint;
    public float WIQ_LetterPoint;
    public float WIQ_NEWWORDMultiplier;
    public float WIQ_BaseClearPoints_min;
    public float WIQ_BaseClearPoints_max;
    public float WIQ_HighestComplexity;
    public float WIQ_MaxAdditionalClearPoints;
    public float[] WIQ_Milestones;
    public int categoryUnlockLevel;
    public string categoryShowLevelsDisplay;
    public decimal categoryChapterReward;
    public bool categoryShowButtonLocked;
    public int categoryCompletionGoal;
    public int categoryCompletionCountIncrease;
    public int categoryCompletionGoalMax;
    public int categoryMaxRequiredWords;
    public int watchAdForSpinUnlockSpins;
    public int watchAdForCoinUnlockLevel;
    public int nonPurchaserCap;
    public int lowPurchaserCap;
    public int highPurchaserCap;
    public int repeatPurchaserCap;
    public int dbFtuxLevel;
    public int dbFtuxCr;
    public int hintMeterFreeHints;
    public int storeButtonDisplayLevel;
    public int friendInvButtonDisplayLevel;
    public int alphButtonDisplayLevel;
    public int iqButtonDisplayLevel;
    public int dcButtonDisplayLevel;
    public int leaguesButtonDisplayLevel;
    public int libraryButtonDisplayLevel;
    public int categoriesButtonDisplayLevel;
    public int eventButtonDisplayLevel;
    public bool levelSkipEnabled;
    public float lifetime099SpendLimit;
    public int goldenAppleFtuxLevel;
    public int definitionFtuxLevel;
    public int newUserTaskUnlock;
    public bool gm_enabled;
    public float gm_defaultMultiplier;
    public float gm_defaultMultiplierCost;
    public float gm_multiplierIncrement;
    public float gm_costIncrementCoefficient;
    public float gm_maxGoldenMultiplier;
    public int caf_unlockLevel;
    public int caf_frequencyShown;
    public decimal caf_reward_coins;
    public PrizeBalloon.Econ prize_balloon_econ;
    protected twelvegigs.storage.JsonDictionary knobsConfigjs;
    private twelvegigs.storage.JsonDictionary otherKnobsConfigjs;
    private System.Collections.Generic.Dictionary<string, object> minigameUnlockLevels;
    public int ltb_unlockLevel;
    public bool ss_enabled;
    public int ss_min_offer;
    public int ss_cost_multiplier;
    public bool jumbledWords;
    private System.Collections.Generic.List<BonusRewardsContainer> _bonusRewardDefaultData;
    
    // Properties
    public string titleFormat { get; }
    public decimal base099CreditPackSize { get; }
    public decimal base199CreditPackSize { get; }
    public decimal base299CreditPackSize { get; }
    public decimal base499CreditPackSize { get; }
    public decimal base999CreditPackSize { get; }
    public decimal base1999CreditPackSize { get; }
    public decimal base4999CreditPackSize { get; }
    public decimal base099GemPackSize { get; }
    public int ExtraWordsTarget { get; }
    public decimal HintCost { get; }
    public decimal HintCostUnaltered { get; }
    public decimal HintCostDiscounted { get; }
    public decimal HintPickerCost { get; }
    public decimal HintPickerCostUnaltered { get; }
    public decimal HintPickerCostDiscounted { get; }
    public decimal HintMEGACost { get; }
    public decimal HintMEGACostUnaltered { get; }
    public decimal HintMEGACostDiscounted { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> GiftRewardTypeChances { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>> GiftRewardCoinRewardTiers { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardCoinAmountChances { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardFoodAmountChances { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardDiceRollAmountChances { get; }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardGoldenCurrencyAmountChances { get; }
    public decimal hintDiscountAmount { get; }
    public int maxBonusGameWheelAwardCoins { get; }
    public int maxBonusGameWheelAwardGoldenCurrency { get; }
    public int ChallengeWordsUnlockLevel { get; }
    public int ChallengeWordsLevelCooldown { get; }
    public int ChallengeWordsWordChance { get; }
    public virtual int ltb_interval { get; }
    public virtual float MiniReturnGameGiftOfflineHours { get; }
    public virtual int bonusRewardPointsPerDollarSpent { get; }
    public virtual System.Collections.Generic.List<BonusRewardsContainer> bonusRewardTiers { get; }
    
    // Methods
    public string get_titleFormat()
    {
        string val_2;
        if(this._formatSet != false)
        {
                val_2 = this._titleFormat;
            return (string)val_2;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_2 = val_1.<metaGameBehavior>k__BackingField;
        this._titleFormat = val_2;
        this._formatSet = true;
        return (string)val_2;
    }
    public decimal get_base099CreditPackSize()
    {
        var val_7;
        var val_8;
        var val_9;
        string val_11;
        var val_12;
        val_8 = null;
        val_8 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base099CreditPackSize, hi = this._base099CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_9 = 0;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  0).Equals(obj:  0.99f)) == true)
        {
            goto label_7;
        }
        
        val_9 = 1;
        label_4:
        val_7 = PackagesManager.GetPackages(packageType:  "credits");
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_9 < val_7.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_11 = "credits";
        val_12 = val_9;
        decimal val_7 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_11, packageIndex:  1);
        this._base099CreditPackSize = val_7;
        mem[1152921517501950284] = val_7.lo;
        mem[1152921517501950288] = val_7.mid;
        return new System.Decimal() {flags = val_11, hi = val_11, lo = X21, mid = X21};
        label_3:
        val_11 = this._base099CreditPackSize;
        return new System.Decimal() {flags = val_11, hi = val_11, lo = X21, mid = X21};
    }
    public decimal get_base199CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base199CreditPackSize, hi = this._base199CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 0;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  0)) > 1.99f)
        {
            goto label_7;
        }
        
        val_8 = 1;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base199CreditPackSize = val_6;
        mem[1152921517502070524] = val_6.lo;
        mem[1152921517502070528] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base199CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base299CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base299CreditPackSize, hi = this._base299CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 1;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  1)) > 2.99f)
        {
            goto label_7;
        }
        
        val_8 = 2;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base299CreditPackSize = val_6;
        mem[1152921517502190764] = val_6.lo;
        mem[1152921517502190768] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base299CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base499CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base499CreditPackSize, hi = this._base499CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 1;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  1)) > 4.99f)
        {
            goto label_7;
        }
        
        val_8 = 2;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base499CreditPackSize = val_6;
        mem[1152921517502311004] = val_6.lo;
        mem[1152921517502311008] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base499CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base999CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base999CreditPackSize, hi = this._base999CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 1;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  1)) > 9.99f)
        {
            goto label_7;
        }
        
        val_8 = 2;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base999CreditPackSize = val_6;
        mem[1152921517502431244] = val_6.lo;
        mem[1152921517502431248] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base999CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base1999CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base1999CreditPackSize, hi = this._base1999CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 1;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  1)) > 19.99f)
        {
            goto label_7;
        }
        
        val_8 = 2;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base1999CreditPackSize = val_6;
        mem[1152921517502551484] = val_6.lo;
        mem[1152921517502551488] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base1999CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base4999CreditPackSize()
    {
        var val_6;
        var val_7;
        var val_8;
        string val_10;
        int val_11;
        val_7 = null;
        val_7 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base4999CreditPackSize, hi = this._base4999CreditPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_8 = 1;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "credits", index:  1)) > 49.99f)
        {
            goto label_7;
        }
        
        val_8 = 2;
        label_4:
        val_6 = PackagesManager.GetPackages(packageType:  "credits");
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8 < val_6.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_10 = "credits";
        val_11 = val_8 - 1;
        decimal val_6 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_10, packageIndex:  val_11);
        this._base4999CreditPackSize = val_6;
        mem[1152921517502671724] = val_6.lo;
        mem[1152921517502671728] = val_6.mid;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
        label_3:
        val_10 = this._base4999CreditPackSize;
        return new System.Decimal() {flags = val_10, hi = val_10, lo = X21, mid = X21};
    }
    public decimal get_base099GemPackSize()
    {
        var val_7;
        var val_8;
        var val_9;
        string val_11;
        var val_12;
        val_8 = null;
        val_8 = null;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = this._base099GemPackSize, hi = this._base099GemPackSize, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_3;
        }
        
        val_9 = 0;
        goto label_4;
        label_15:
        if((PackagesManager.GetPriceByIndex(packageType:  "gems", index:  0).Equals(obj:  0.99f)) == true)
        {
            goto label_7;
        }
        
        val_9 = 1;
        label_4:
        val_7 = PackagesManager.GetPackages(packageType:  "gems");
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_9 < val_7.Count)
        {
            goto label_15;
        }
        
        label_7:
        val_11 = "gems";
        val_12 = val_9;
        decimal val_7 = PackagesManager.GetCreditsAmountByIndex(packageType:  val_11, packageIndex:  1);
        this._base099GemPackSize = val_7;
        mem[1152921517502791964] = val_7.lo;
        mem[1152921517502791968] = val_7.mid;
        return new System.Decimal() {flags = val_11, hi = val_11, lo = X21, mid = X21};
        label_3:
        val_11 = this._base099GemPackSize;
        return new System.Decimal() {flags = val_11, hi = val_11, lo = X21, mid = X21};
    }
    public int get_ExtraWordsTarget()
    {
        if(Prefs.extraTarget != 0)
        {
                return Prefs.extraTarget;
        }
        
        Prefs.extraTarget = this.InitialExtraWordsReq;
        return Prefs.extraTarget;
    }
    public decimal get_HintCost()
    {
        return new System.Decimal() {flags = this._HintCost, hi = this._HintCost};
    }
    public decimal get_HintCostUnaltered()
    {
        return new System.Decimal() {flags = this._HintCost, hi = this._HintCost};
    }
    public decimal get_HintCostDiscounted()
    {
        decimal val_1 = this.hintDiscountAmount;
        return System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this._HintCost, hi = this._HintCost, lo = 11495056, mid = 268435459});
    }
    public decimal get_HintPickerCost()
    {
        return new System.Decimal() {flags = this._HintPickerCost, hi = this._HintPickerCost};
    }
    public decimal get_HintPickerCostUnaltered()
    {
        return new System.Decimal() {flags = this._HintPickerCost, hi = this._HintPickerCost};
    }
    public decimal get_HintPickerCostDiscounted()
    {
        decimal val_1 = this.hintDiscountAmount;
        return System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this._HintPickerCost, hi = this._HintPickerCost, lo = 11831056, mid = 268435459});
    }
    public decimal get_HintMEGACost()
    {
        return new System.Decimal() {flags = this._HintMEGACost, hi = this._HintMEGACost};
    }
    public decimal get_HintMEGACostUnaltered()
    {
        return new System.Decimal() {flags = this._HintMEGACost, hi = this._HintMEGACost};
    }
    public decimal get_HintMEGACostDiscounted()
    {
        decimal val_1 = this.hintDiscountAmount;
        return System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this._HintMEGACost, hi = this._HintMEGACost, lo = 12167056, mid = 268435459});
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> get_GiftRewardTypeChances()
    {
        AppConfigs val_1 = App.Configuration;
        goto typeof(EconConfig).__il2cppRuntimeField_170;
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>> get_GiftRewardCoinRewardTiers()
    {
        AppConfigs val_1 = App.Configuration;
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>>)val_1.econConfig.GiftRewardCoinRewardTiers;
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> get_GiftRewardCoinAmountChances()
    {
        AppConfigs val_1 = App.Configuration;
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>)val_1.econConfig.GiftRewardCoinAmountChances;
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> get_GiftRewardFoodAmountChances()
    {
        AppConfigs val_1 = App.Configuration;
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>)val_1.econConfig.GiftRewardFoodAmountChances;
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> get_GiftRewardDiceRollAmountChances()
    {
        AppConfigs val_1 = App.Configuration;
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>)val_1.econConfig.GiftRewardDiceRollAmountChances;
    }
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> get_GiftRewardGoldenCurrencyAmountChances()
    {
        AppConfigs val_1 = App.Configuration;
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>)val_1.econConfig.GiftRewardGoldenCurrencyAmountChances;
    }
    public decimal get_hintDiscountAmount()
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  this.hintDiscountSizePercent);
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    public int get_maxBonusGameWheelAwardCoins()
    {
        return (int)this.bonusGameWheelAwardCoins[((-4294967296) + ((this.bonusGameWheelAwardCoins.Length) << 32)) >> 30];
    }
    public int get_maxBonusGameWheelAwardGoldenCurrency()
    {
        return (int)this.bonusGameWheelAwardGoldenCurrency[((-4294967296) + ((this.bonusGameWheelAwardGoldenCurrency.Length) << 32)) >> 30];
    }
    public int get_ChallengeWordsUnlockLevel()
    {
        return (int)this._challengeWordsunlockLevel;
    }
    public int get_ChallengeWordsLevelCooldown()
    {
        return (int)this._challengeWordsLevelCooldown;
    }
    public int get_ChallengeWordsWordChance()
    {
        return (int)this._challengeWordsWordChance;
    }
    public virtual int get_ltb_interval()
    {
        return 8;
    }
    public virtual float get_MiniReturnGameGiftOfflineHours()
    {
        return 3f;
    }
    public virtual ReturnGameGiftReward GetReturnReward(int level, float leftHours)
    {
        return 0;
    }
    public virtual int get_bonusRewardPointsPerDollarSpent()
    {
        return 50;
    }
    public virtual System.Collections.Generic.List<BonusRewardsContainer> get_bonusRewardTiers()
    {
        return (System.Collections.Generic.List<BonusRewardsContainer>)this._bonusRewardDefaultData;
    }
    public static bool IsEnabledAndLevelMet(int playerLevel, int knobValue)
    {
        if(knobValue == 1)
        {
                return false;
        }
        
        return (bool)(playerLevel >= knobValue) ? 1 : 0;
    }
    public static bool IsEnabledAndLevelNotExeeded(int playerLevel, int knobValue)
    {
        if(knobValue == 1)
        {
                return true;
        }
        
        return (bool)(playerLevel <= knobValue) ? 1 : 0;
    }
    public System.Collections.Generic.Dictionary<string, object> GetGameplayKnobs()
    {
        var val_2 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>);
    }
    public System.Collections.Generic.Dictionary<string, object> GetMinigamesUnlockKnobs()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.minigameUnlockLevels;
    }
    public virtual void ReadFromKnobs()
    {
        string val_502;
        var val_503;
        twelvegigs.storage.KnobsModel val_983;
        var val_984;
        var val_985;
        var val_986;
        var val_987;
        var val_988;
        decimal val_990;
        var val_991;
        var val_992;
        var val_993;
        var val_994;
        var val_995;
        var val_996;
        var val_997;
        var val_998;
        var val_999;
        var val_1000;
        var val_1001;
        var val_1002;
        var val_1003;
        var val_1004;
        var val_1005;
        var val_1006;
        var val_1007;
        var val_1008;
        var val_1009;
        var val_1010;
        val_983 = null;
        val_983 = null;
        if(App.storageManager == null)
        {
                throw new NullReferenceException();
        }
        
        val_983 = mem[App.storageManager + 24];
        val_983 = App.storageManager.knobsModel;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        twelvegigs.storage.JsonDictionary val_1 = getWordGameplayKnobs();
        if(val_1 != null)
        {
                this.knobsConfigjs = val_1;
        }
        else
        {
                val_983 = this.knobsConfigjs;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_984 = 1152921504685600768;
        val_985 = 0;
        if(App.game != 15)
        {
            goto label_19;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "scratch_gameplay", defaultValue:  "{}"));
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_986 = 1152921510222861648;
        if((val_4.ContainsKey(key:  "sec")) != false)
        {
                object val_6 = val_4.Item["sec"];
            if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_8 = System.Int32.TryParse(s:  val_6, result: out  this.scsStandardEntryCost);
        }
        
        if((val_4.ContainsKey(key:  "vp_lc")) != false)
        {
                object val_10 = val_4.Item["vp_lc"];
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_12 = System.Int32.TryParse(s:  val_10, result: out  this.scsVideosPerLuckyCash);
        }
        
        if((val_4.ContainsKey(key:  "minco_bb")) == false)
        {
                return;
        }
        
        object val_14 = val_4.Item["minco_bb"];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        label_974:
        bool val_16 = System.Int32.TryParse(s:  val_14, result: out  this.scsMinimumCashOutBankBalance);
        return;
        label_19:
        Dictionary.KeyCollection<TKey, TValue> val_17 = Keys;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_17.Count <= 1)
        {
            goto label_32;
        }
        
        if((ContainsKey(key:  "initial_coins")) != false)
        {
                object val_20 = Item["initial_coins"];
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_21 = System.Decimal.TryParse(s:  val_20, result: out  new System.Decimal() {flags = this.InitialPlayerCoins, hi = this.InitialPlayerCoins, lo = this.InitialPlayerCoins, mid = this.InitialPlayerCoins});
        }
        
        if((ContainsKey(key:  "initial_gems")) != false)
        {
                object val_23 = Item["initial_gems"];
            if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_25 = System.Int32.TryParse(s:  val_23, result: out  this.InitialPlayerGems);
        }
        
        if((ContainsKey(key:  "hint_cost")) != false)
        {
                object val_27 = Item["hint_cost"];
            if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_28 = System.Decimal.TryParse(s:  val_27, result: out  new System.Decimal() {flags = this._HintCost, hi = this._HintCost, lo = this._HintCost, mid = this._HintCost});
        }
        
        if((ContainsKey(key:  "hp_c")) != false)
        {
                object val_30 = Item["hp_c"];
            if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_31 = System.Decimal.TryParse(s:  val_30, result: out  new System.Decimal() {flags = this._HintPickerCost, hi = this._HintPickerCost, lo = this._HintPickerCost, mid = this._HintPickerCost});
        }
        
        if((ContainsKey(key:  "mh_c")) != false)
        {
                object val_33 = Item["mh_c"];
            if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_34 = System.Decimal.TryParse(s:  val_33, result: out  new System.Decimal() {flags = this._HintMEGACost, hi = this._HintMEGACost, lo = this._HintMEGACost, mid = this._HintMEGACost});
        }
        
        if((ContainsKey(key:  "ccr_v2")) != false)
        {
                object val_36 = Item["ccr_v2"];
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_37 = System.Decimal.TryParse(s:  val_36, result: out  new System.Decimal() {flags = this.InitialChapterClearedReward, hi = this.InitialChapterClearedReward, lo = this.InitialChapterClearedReward, mid = this.InitialChapterClearedReward});
        }
        
        if((ContainsKey(key:  "ecrem")) != false)
        {
                object val_39 = Item["ecrem"];
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_41 = System.Single.TryParse(s:  val_39, result: out  this.extraChapterEventMultiplier);
        }
        
        if((ContainsKey(key:  "starred_word_reward")) != false)
        {
                object val_43 = Item["starred_word_reward"];
            if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_44 = System.Decimal.TryParse(s:  val_43, result: out  new System.Decimal() {flags = this.wordCoinBonus, hi = this.wordCoinBonus, lo = this.wordCoinBonus, mid = this.wordCoinBonus});
        }
        
        if((ContainsKey(key:  "initial_extra_words_required")) != false)
        {
                object val_46 = Item["initial_extra_words_required"];
            if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_48 = System.Int32.TryParse(s:  val_46, result: out  this.InitialExtraWordsReq);
        }
        
        if((ContainsKey(key:  "extra_words_increment")) != false)
        {
                object val_50 = Item["extra_words_increment"];
            if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_52 = System.Int32.TryParse(s:  val_50, result: out  this.ExtraWordsIncrement);
        }
        
        if((ContainsKey(key:  "extra_words_max_required")) != false)
        {
                object val_54 = Item["extra_words_max_required"];
            if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_56 = System.Int32.TryParse(s:  val_54, result: out  this.ExtraWordsMaxReq);
        }
        
        if((ContainsKey(key:  "dly_bn_v2")) == false)
        {
            goto label_110;
        }
        
        object val_58 = Item["dly_bn_v2"];
        if(val_58 == null)
        {
            goto label_110;
        }
        
        if(((val_58.ContainsKey(key:  "cbt")) == false) || (val_58.Item["cbt"] == null))
        {
            goto label_102;
        }
        
        System.Collections.Generic.List<GiftRewardTier> val_61 = new System.Collections.Generic.List<GiftRewardTier>();
        if(1152921515939697216 < 1)
        {
            goto label_75;
        }
        
        do
        {
            DailyBonusTier val_62 = new DailyBonusTier();
            if(0 >= 1152921504972980224)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
            val_62.Decode(jasonObject:  null, sourceModel:  0);
            if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            val_983 = val_65.dailyBonusTiers;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_983.ContainsKey(key:  0)) != true)
        {
                if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            val_983 = val_67.dailyBonusTiers;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            val_983.Add(key:  0, value:  val_62);
        }
        
            GiftRewardTier val_68 = new GiftRewardTier();
            if(0 >= 1152921515939720768)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
            val_983 = val_68;
            val_68.Decode(jasonObject:  null, sourceModel:  0);
            if(val_61 == null)
        {
                throw new NullReferenceException();
        }
        
            val_61.Add(item:  val_68);
        }
        while(1 < null);
        
        goto label_97;
        label_32:
        UnityEngine.Debug.LogWarning(message:  "App.getGameEcon.ReadFromKnobs: Knobs Not Found! This should never be the case!");
        return;
        label_75:
        if(val_61 == null)
        {
            goto label_102;
        }
        
        label_97:
        if(1152921515939697216 >= 1)
        {
                val_983 = this;
            if(this == null)
        {
                throw new NullReferenceException();
        }
        
            this.set_Item(key:  0, value:  val_61);
            val_983 = this;
            if(this == null)
        {
                throw new NullReferenceException();
        }
        
            this.set_Item(key:  2, value:  val_61);
            val_983 = this;
            if(this == null)
        {
                throw new NullReferenceException();
        }
        
            this.set_Item(key:  1, value:  val_61);
        }
        
        label_102:
        val_987 = 1152921504685600768;
        if(((val_58.ContainsKey(key:  "rv")) != false) && (val_58.Item["rv"] != null))
        {
                this.dailyBonusVideoRewards = new System.Collections.Generic.List<System.Int32>();
            if(1152921510062986752 >= 1)
        {
                if(0 >= 1152921510062986752)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_983 = "java.lang.Short";
            if(this.dailyBonusVideoRewards == null)
        {
                throw new NullReferenceException();
        }
        
            this.dailyBonusVideoRewards.Add(item:  System.Convert.ToInt32(value:  val_983));
        }
        
        }
        
        label_110:
        val_988 = 1152921510222861648;
        if((ContainsKey(key:  "rating_reward")) != false)
        {
                object val_76 = Item["rating_reward"];
            if(val_76 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_77 = System.Decimal.TryParse(s:  val_76, result: out  new System.Decimal() {flags = this.ratingReward, hi = this.ratingReward, lo = this.ratingReward, mid = this.ratingReward});
        }
        
        if((ContainsKey(key:  "video_ad_reward")) != false)
        {
                object val_79 = Item["video_ad_reward"];
            if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_80 = System.Decimal.TryParse(s:  val_79, result: out  new System.Decimal() {flags = this.videoAdReward, hi = this.videoAdReward, lo = this.videoAdReward, mid = this.videoAdReward});
        }
        
        object val_81 = AdSegmentation.GetSegementedConfig(key:  "va_rew", knobs:  null, addSegment:  true);
        if(val_81 != null)
        {
                if((val_81.ContainsKey(key:  "np")) != false)
        {
                object val_83 = val_81.Item["np"];
            if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_84 = System.Decimal.TryParse(s:  val_83, result: out  new System.Decimal() {flags = this.nonPurchaserVidReward, hi = this.nonPurchaserVidReward, lo = this.nonPurchaserVidReward, mid = this.nonPurchaserVidReward});
        }
        
            if((val_81.ContainsKey(key:  "otp")) != false)
        {
                object val_86 = val_81.Item["otp"];
            if(val_86 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_87 = System.Decimal.TryParse(s:  val_86, result: out  new System.Decimal() {flags = this.oneTimePurchaserVidReward, hi = this.oneTimePurchaserVidReward, lo = this.oneTimePurchaserVidReward, mid = this.oneTimePurchaserVidReward});
        }
        
            if((val_81.ContainsKey(key:  "rp")) != false)
        {
                object val_89 = val_81.Item["rp"];
            if(val_89 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_90 = System.Decimal.TryParse(s:  val_89, result: out  new System.Decimal() {flags = this.repeatPurchaserVidReward, hi = this.repeatPurchaserVidReward, lo = this.repeatPurchaserVidReward, mid = this.repeatPurchaserVidReward});
        }
        
        }
        
        if((ContainsKey(key:  "d_s")) != false)
        {
                object val_92 = Item["d_s"];
            if(val_92 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_92.ContainsKey(key:  "pl")) != false)
        {
                object val_94 = val_92.Item["pl"];
            if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_96 = System.Int32.TryParse(s:  val_94, result: out  this.difficultySettingPromptLevel);
        }
        
            if((val_92.ContainsKey(key:  "cd_hd")) != false)
        {
                object val_98 = val_92.Item["cd_hd"];
            if(val_98 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_100 = System.Int32.TryParse(s:  val_98, result: out  this.difficultySettingHintDiscount);
        }
        
        }
        
        if((ContainsKey(key:  "p_b")) != false)
        {
                object val_102 = Item["p_b"];
            if(val_102 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_102.ContainsKey(key:  "en")) != false)
        {
                object val_104 = val_102.Item["en"];
            if(val_104 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_106 = System.Boolean.TryParse(value:  val_104, result: out  this.prize_balloon_econ.FeatureEnabled);
        }
        
            if((val_102.ContainsKey(key:  "mcb")) != false)
        {
                object val_108 = val_102.Item["mcb"];
            if(val_108 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_110 = System.Int32.TryParse(s:  val_108, result: out  this.prize_balloon_econ.TriggerCoinBalance);
        }
        
            if((val_102.ContainsKey(key:  "lpd")) != false)
        {
                object val_112 = val_102.Item["lpd"];
            if(val_112 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_114 = System.Int32.TryParse(s:  val_112, result: out  this.prize_balloon_econ.LapsedPayerDays);
        }
        
            if((val_102.ContainsKey(key:  "mlc")) != false)
        {
                object val_116 = val_102.Item["mlc"];
            if(val_116 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_118 = System.Int32.TryParse(s:  val_116, result: out  this.prize_balloon_econ.MinLevelsToCompletePerSession);
        }
        
            if((val_102.ContainsKey(key:  "ost")) != false)
        {
                object val_120 = val_102.Item["ost"];
            if(val_120 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_122 = System.Int32.TryParse(s:  val_120, result: out  this.prize_balloon_econ.BalloonOnScreenInSec);
        }
        
            if((val_102.ContainsKey(key:  "lvl")) != false)
        {
                object val_124 = val_102.Item["lvl"];
            if(val_124 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_126 = System.Int32.TryParse(s:  val_124, result: out  this.prize_balloon_econ.UnlockLevel);
        }
        
            if((val_102.ContainsKey(key:  "dl")) != false)
        {
                object val_128 = val_102.Item["dl"];
            if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.prize_balloon_econ == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_130 = System.Int32.TryParse(s:  val_128, result: out  this.prize_balloon_econ.DailyLimit);
        }
        
        }
        
        if((ContainsKey(key:  "v_ad_rw_b")) != false)
        {
                object val_132 = Item["v_ad_rw_b"];
            if(val_132 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_133 = System.Decimal.TryParse(s:  val_132, result: out  new System.Decimal() {flags = this.videoAdRewardBonusCollect, hi = this.videoAdRewardBonusCollect, lo = this.videoAdRewardBonusCollect, mid = this.videoAdRewardBonusCollect});
        }
        
        if((ContainsKey(key:  "ios_na_am")) != false)
        {
                object val_135 = Item["ios_na_am"];
            if(val_135 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_137 = System.Int32.TryParse(s:  val_135, result: out  this.NoAdsStarterPackCoinAmount);
        }
        
        if((ContainsKey(key:  "android_na_am")) != false)
        {
                object val_139 = Item["android_na_am"];
            if(val_139 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_141 = System.Int32.TryParse(s:  val_139, result: out  this.NoAdsStarterPackCoinAmount);
        }
        
        if((ContainsKey(key:  "raf_p")) != false)
        {
                object val_143 = Item["raf_p"];
            if(val_143 == null)
        {
                throw new NullReferenceException();
        }
        
            this.NoAdsPackagePriceToUse = System.Single.Parse(s:  val_143, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        if((ContainsKey(key:  "facebook_connect_bonus")) != false)
        {
                object val_147 = Item["facebook_connect_bonus"];
            if(val_147 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_148 = System.Decimal.TryParse(s:  val_147, result: out  new System.Decimal() {flags = this.fbConnectBonus, hi = this.fbConnectBonus, lo = this.fbConnectBonus, mid = this.fbConnectBonus});
        }
        
        if((ContainsKey(key:  "extra_words_reward")) != false)
        {
                object val_150 = Item["extra_words_reward"];
            if(val_150 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_151 = System.Decimal.TryParse(s:  val_150, result: out  new System.Decimal() {flags = this.ExtraWordsReward, hi = this.ExtraWordsReward, lo = this.ExtraWordsReward, mid = this.ExtraWordsReward});
        }
        
        if((ContainsKey(key:  "email_collect_reward")) != false)
        {
                object val_153 = Item["email_collect_reward"];
            if(val_153 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_154 = System.Decimal.TryParse(s:  val_153, result: out  new System.Decimal() {flags = this.emailCollectReward, hi = this.emailCollectReward, lo = this.emailCollectReward, mid = this.emailCollectReward});
        }
        
        if((ContainsKey(key:  "email_collect_days")) != false)
        {
                object val_156 = Item["email_collect_days"];
            if(val_156 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_158 = System.Int32.TryParse(s:  val_156, result: out  this.emailCollectTimeoutDays);
        }
        
        if((ContainsKey(key:  "gt_pu")) != false)
        {
                object val_160 = Item["gt_pu"];
            if(val_160 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_162 = System.Int32.TryParse(s:  val_160, result: out  this.subscriptionPromoPostDailyBonusLevel);
        }
        
        object val_163 = AdSegmentation.GetSegementedConfig(key:  "fh_l", knobs:  null, addSegment:  true);
        if(val_163 != null)
        {
                bool val_165 = System.Int32.TryParse(s:  val_163, result: out  this.freeHintPopupLevel);
        }
        
        object val_166 = AdSegmentation.GetSegementedConfig(key:  "fh_db_l", knobs:  null, addSegment:  true);
        if(val_166 != null)
        {
                bool val_168 = System.Int32.TryParse(s:  val_166, result: out  this.freeHintPostDailyBonus);
        }
        
        object val_169 = AdSegmentation.GetSegementedConfig(key:  "ac_l", knobs:  null, addSegment:  true);
        if(val_169 != null)
        {
                bool val_171 = System.Int32.TryParse(s:  val_169, result: out  this.adsControlPopupLevel);
        }
        
        object val_172 = AdSegmentation.GetSegementedConfig(key:  "acsp_mv", knobs:  null, addSegment:  true);
        if(val_172 != null)
        {
                bool val_174 = System.Int32.TryParse(s:  val_172, result: out  this.adsControlMaxViews);
        }
        
        if((ContainsKey(key:  "acb_mx")) != false)
        {
                object val_176 = Item["acb_mx"];
            if(val_176 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_178 = System.Int32.TryParse(s:  val_176, result: out  this.adsControlButtonLevel_max);
        }
        
        if((ContainsKey(key:  "ec_l")) != false)
        {
                object val_180 = Item["ec_l"];
            if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_182 = System.Int32.TryParse(s:  val_180, result: out  this.emailCollectPopupLevel);
        }
        
        if((ContainsKey(key:  "fr_in")) != false)
        {
                object val_184 = Item["fr_in"];
            if(val_184 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_184.ContainsKey(key:  "enable")) != false)
        {
                object val_186 = val_184.Item["enable"];
            if(val_186 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_188 = System.Boolean.TryParse(value:  val_186, result: out  this.FInviterEnabled);
        }
        
            if((val_184.ContainsKey(key:  "FI L C")) != false)
        {
                object val_190 = val_184.Item["FI L C"];
            if(val_190 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_192 = System.Int32.TryParse(s:  val_190, result: out  this.FInviterLevelComplete);
        }
        
            if((val_184.ContainsKey(key:  "FI C R")) != false)
        {
                object val_194 = val_184.Item["FI C R"];
            if(val_194 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_196 = System.Int32.TryParse(s:  val_194, result: out  this.FInviterCoinsReward);
        }
        
            if((val_184.ContainsKey(key:  "FI FTUX")) != false)
        {
                object val_198 = val_184.Item["FI FTUX"];
            if(val_198 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_200 = System.Int32.TryParse(s:  val_198, result: out  this.FInviterFTUX);
        }
        
            if((val_184.ContainsKey(key:  "FI BR I")) != false)
        {
                object val_202 = val_184.Item["FI BR I"];
            if(val_202 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_204 = System.Int32.TryParse(s:  val_202, result: out  this.FInviter_BR_I);
        }
        
            if((val_184.ContainsKey(key:  "FI BR R")) != false)
        {
                object val_206 = val_184.Item["FI BR R"];
            if(val_206 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_208 = System.Int32.TryParse(s:  val_206, result: out  this.FInviter_BR_R);
        }
        
            if((val_184.ContainsKey(key:  "FI SI I")) != false)
        {
                object val_210 = val_184.Item["FI SI I"];
            if(val_210 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_212 = System.Int32.TryParse(s:  val_210, result: out  this.FInviter_SI_I);
        }
        
            if((val_184.ContainsKey(key:  "FI SI R")) != false)
        {
                object val_214 = val_184.Item["FI SI R"];
            if(val_214 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_216 = System.Int32.TryParse(s:  val_214, result: out  this.FInviter_SI_R);
        }
        
            if((val_184.ContainsKey(key:  "FI GO I")) != false)
        {
                object val_218 = val_184.Item["FI GO I"];
            if(val_218 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_220 = System.Int32.TryParse(s:  val_218, result: out  this.FInviter_GO_I);
        }
        
            if((val_184.ContainsKey(key:  "FI GO R")) != false)
        {
                object val_222 = val_184.Item["FI GO R"];
            if(val_222 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_224 = System.Int32.TryParse(s:  val_222, result: out  this.FInviter_GO_R);
        }
        
            if((val_184.ContainsKey(key:  "Rcmd Lvl")) != false)
        {
                object val_226 = val_184.Item["Rcmd Lvl"];
            if(val_226 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_228 = System.Int32.TryParse(s:  val_226, result: out  this.RecLevel);
        }
        
            if((val_184.ContainsKey(key:  "RF Itv")) != false)
        {
                object val_230 = val_184.Item["RF Itv"];
            if(val_230 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_232 = System.Int32.TryParse(s:  val_230, result: out  this.RecInterval);
        }
        
            if((val_184.ContainsKey(key:  "RF Lmt")) != false)
        {
                object val_234 = val_184.Item["RF Lmt"];
            if(val_234 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_236 = System.Int32.TryParse(s:  val_234, result: out  this.RecLimit);
        }
        
            if((val_184.ContainsKey(key:  "RF Dl")) != false)
        {
                object val_238 = val_184.Item["RF Dl"];
            if(val_238 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_240 = System.Int32.TryParse(s:  val_238, result: out  this.RecDelay);
        }
        
        }
        
        if((ContainsKey(key:  "hint_tutorial_level")) != false)
        {
                object val_242 = Item["hint_tutorial_level"];
            if(val_242 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_244 = System.Int32.TryParse(s:  val_242, result: out  this.hintTutorialLevel);
            this.hintTutorialLevelV2 = this.hintTutorialLevel;
        }
        
        if((ContainsKey(key:  "erw_v2")) != false)
        {
                object val_246 = Item["erw_v2"];
            if(val_246 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_246.ContainsKey(key:  "bc")) != false)
        {
                object val_248 = val_246.Item["bc"];
            if(val_248 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_250 = System.Int32.TryParse(s:  val_248, result: out  this.extraReqBeginningChapter);
        }
        
            if((val_246.ContainsKey(key:  "def")) != false)
        {
                object val_252 = val_246.Item["def"];
            if(val_252 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_254 = System.Int32.TryParse(s:  val_252, result: out  this.extraReqDefaultLevelsPerChapter);
        }
        
            if((val_246.ContainsKey(key:  "inc")) != false)
        {
                object val_256 = val_246.Item["inc"];
            if(val_256 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_258 = System.Int32.TryParse(s:  val_256, result: out  this.extraReqIncrement);
        }
        
            if((val_246.ContainsKey(key:  "max")) != false)
        {
                object val_260 = val_246.Item["max"];
            if(val_260 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_262 = System.Int32.TryParse(s:  val_260, result: out  this.extraReqMaxLevelsPerChapter);
        }
        
            if((val_246.ContainsKey(key:  "hpc")) != false)
        {
                object val_264 = val_246.Item["hpc"];
            if(val_264 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_264.ContainsKey(key:  "nb")) != false)
        {
                object val_266 = val_264.Item["nb"];
            if(val_266 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_268 = System.Int32.TryParse(s:  val_266, result: out  this.extraReqHintsPerCh_BuyNone);
        }
        
            if((val_264.ContainsKey(key:  "1tb")) != false)
        {
                object val_270 = val_264.Item["1tb"];
            if(val_270 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_272 = System.Int32.TryParse(s:  val_270, result: out  this.extraReqHintsPerCh_BuyFirst);
        }
        
            if((val_264.ContainsKey(key:  "rb")) != false)
        {
                object val_274 = val_264.Item["rb"];
            if(val_274 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_276 = System.Int32.TryParse(s:  val_274, result: out  this.extraReqHintsPerCh_BuyRepeat);
        }
        
        }
        
            if((val_246.ContainsKey(key:  "qpl")) != false)
        {
                object val_278 = val_246.Item["qpl"];
            if(val_278 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_280 = System.Int32.TryParse(s:  val_278, result: out  this.extraReqQuantityPerLevel);
        }
        
            if((val_246.ContainsKey(key:  "pp_lvl")) != false)
        {
                object val_282 = val_246.Item["pp_lvl"];
            if(val_282 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_284 = System.Int32.TryParse(s:  val_282, result: out  this.extraReqPostPurchaseLvl);
        }
        
        }
        
        if((ContainsKey(key:  "hp_t_l")) != false)
        {
                object val_286 = Item["hp_t_l"];
            if(val_286 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_288 = System.Int32.TryParse(s:  val_286, result: out  this.hintPickerTutorialLevel);
            this.hintPickerTutorialLevelV2 = this.hintPickerTutorialLevel;
        }
        
        if((ContainsKey(key:  "hp_u_l")) != false)
        {
                object val_290 = Item["hp_u_l"];
            if(val_290 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_292 = System.Int32.TryParse(s:  val_290, result: out  this.hintPickerUnlockLevel);
            this.hintPickerUnlockLevelV2 = this.hintPickerUnlockLevel;
        }
        
        if((ContainsKey(key:  "mh_t_l")) != false)
        {
                object val_294 = Item["mh_t_l"];
            if(val_294 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_296 = System.Int32.TryParse(s:  val_294, result: out  this.hintMEGATutorialLevel);
        }
        
        if((ContainsKey(key:  "hd_s")) != false)
        {
                object val_298 = Item["hd_s"];
            if(val_298 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_300 = System.Int32.TryParse(s:  val_298, result: out  this.hintDiscountSizePercent);
        }
        
        if((ContainsKey(key:  "cc_rf")) != false)
        {
                object val_302 = Item["cc_rf"];
            if(val_302 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_304 = System.Int32.TryParse(s:  val_302, result: out  this.hintDiscountChapterFreq);
        }
        
        if((ContainsKey(key:  "cc_r")) != false)
        {
                object val_306 = Item["cc_r"];
            if(val_306 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_308 = System.Int32.TryParse(s:  val_306, result: out  this.hintDiscountChapterMinutes);
        }
        
        if((ContainsKey(key:  "dr_d4")) != false)
        {
                object val_310 = Item["dr_d4"];
            if(val_310 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_312 = System.Int32.TryParse(s:  val_310, result: out  this.hintDiscountDailyBonusMinutes);
        }
        
        if((ContainsKey(key:  "ac_om")) != false)
        {
                object val_314 = Item["ac_om"];
            if(val_314 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_316 = System.Int32.TryParse(s:  val_314, result: out  this.alphabetOneMoreCost);
        }
        
        if((ContainsKey(key:  "ac_rwt")) != false)
        {
                this.alphabetRewards = ;
        }
        
        if((ContainsKey(key:  "m_g_v2")) != false)
        {
                object val_321 = Item["m_g_v2"];
            if(val_321 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_321.ContainsKey(key:  "u_l")) != false)
        {
                object val_323 = val_321.Item["u_l"];
            if(val_323 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_325 = System.Int32.TryParse(s:  val_323, result: out  this.mysteryGiftUnlockLevel);
        }
        
            if((val_321.ContainsKey(key:  "f_l_i")) != false)
        {
                object val_327 = val_321.Item["f_l_i"];
            if(val_327 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_329 = System.Int32.TryParse(s:  val_327, result: out  this.mysteryGiftFlyoutLevelInterval);
        }
        
            if((val_321.ContainsKey(key:  "r")) != false)
        {
                object val_331 = val_321.Item["r"];
            if(val_331 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_333 = System.Int32.TryParse(s:  val_331, result: out  this.mysteryGiftReward);
        }
        
        }
        
        if((ContainsKey(key:  "dl_str")) != false)
        {
                object val_335 = Item["dl_str"];
            if(val_335 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_337 = System.Int32.TryParse(s:  val_335, result: out  this.levelGenStartLevel);
        }
        
        if((ContainsKey(key:  "l_u_l")) != false)
        {
                object val_339 = Item["l_u_l"];
            if(val_339 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_341 = System.Int32.TryParse(s:  val_339, result: out  this.leaguesUnlockLevel);
        }
        
        if((ContainsKey(key:  "ags")) != false)
        {
                this.goalsHashes = ;
        }
        
        val_990 = "level_generation";
        if((ContainsKey(key:  "level_generation")) != false)
        {
                object val_346 = Item["level_generation"];
            if(val_346 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_346.ContainsKey(key:  "plv_dnrwb")) != false)
        {
                object val_348 = val_346.Item["plv_dnrwb"];
            if(val_348 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_350 = System.Single.TryParse(s:  val_348, result: out  this.plvDesiredNumReqWordsBase);
        }
        
            if((val_346.ContainsKey(key:  "plv_dnrwi")) != false)
        {
                object val_352 = val_346.Item["plv_dnrwi"];
            if(val_352 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_354 = System.Single.TryParse(s:  val_352, result: out  this.plvDesiredNumReqWordsIncrement);
        }
        
            if((val_346.ContainsKey(key:  "plv_dnrwm")) != false)
        {
                object val_356 = val_346.Item["plv_dnrwm"];
            if(val_356 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_358 = System.Single.TryParse(s:  val_356, result: out  this.plvDesiredNumReqWordsMax);
        }
        
            if((val_346.ContainsKey(key:  "plv_mxew")) != false)
        {
                object val_360 = val_346.Item["plv_mxew"];
            if(val_360 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_362 = System.Int32.TryParse(s:  val_360, result: out  this.plvMaxExtraWords);
        }
        
            if((val_346.ContainsKey(key:  "plv_ch_nb")) != false)
        {
                object val_364 = val_346.Item["plv_ch_nb"];
            if(val_364 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_366 = System.Int32.TryParse(s:  val_364, result: out  this.plvHintsPerCh_BuyNone);
        }
        
            if((val_346.ContainsKey(key:  "plv_ch_ftb")) != false)
        {
                object val_368 = val_346.Item["plv_ch_ftb"];
            if(val_368 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_370 = System.Int32.TryParse(s:  val_368, result: out  this.plvHintsPerCh_BuyFirst);
        }
        
            if((val_346.ContainsKey(key:  "plv_ch_rb")) != false)
        {
                object val_372 = val_346.Item["plv_ch_rb"];
            if(val_372 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_374 = System.Int32.TryParse(s:  val_372, result: out  this.plvHintsPerCh_BuyRepeat);
        }
        
            if((val_346.ContainsKey(key:  "plv_rwd")) != false)
        {
                object val_376 = val_346.Item["plv_rwd"];
            if(val_376 == null)
        {
                throw new NullReferenceException();
        }
        
            if((MiniJSON.Json.Deserialize(json:  val_376)) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                if(null <= 0)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.plvReqWordDeviations == null)
        {
                throw new NullReferenceException();
        }
        
            if(0 >= this.plvReqWordDeviations.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
            this.plvReqWordDeviations[0] = 13073.37f;
        }
        
        }
        
            if((val_346.ContainsKey(key:  "plv_ewc")) != false)
        {
                object val_379 = val_346.Item["plv_ewc"];
            if(val_379 == null)
        {
                throw new NullReferenceException();
        }
        
            if((MiniJSON.Json.Deserialize(json:  val_379)) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                if(null <= 0)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.plvExtraWordCounts == null)
        {
                throw new NullReferenceException();
        }
        
            if(0 >= this.plvExtraWordCounts.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
            this.plvExtraWordCounts[0] = 1179403647;
        }
        
        }
        
            val_988 = 1152921510222861648;
            val_987 = 1152921504685600768;
            if((val_346.ContainsKey(key:  "plv_nwl")) != false)
        {
                object val_382 = val_346.Item["plv_nwl"];
            if(val_382 == null)
        {
                throw new NullReferenceException();
        }
        
            if((MiniJSON.Json.Deserialize(json:  val_382)) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                if(null <= 0)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.plvNumWordLengths == null)
        {
                throw new NullReferenceException();
        }
        
            if(0 >= this.plvNumWordLengths.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
            this.plvNumWordLengths[0] = 1179403647;
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "level_generation")) != false)
        {
                val_990 = 1152921510214912464;
            object val_385 = Item["level_generation"];
            if(val_385 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_385.ContainsKey(key:  "plv_dwlb")) != false)
        {
                object val_387 = val_385.Item["plv_dwlb"];
            if(val_387 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_389 = System.Single.TryParse(s:  val_387, result: out  this.plvDesiredWordLengthBase);
        }
        
            if((val_385.ContainsKey(key:  "plv_dwli")) != false)
        {
                object val_391 = val_385.Item["plv_dwli"];
            if(val_391 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_393 = System.Single.TryParse(s:  val_391, result: out  this.plvDesiredWordLengthIncrement);
        }
        
            if((val_385.ContainsKey(key:  "plv_lai")) != false)
        {
                object val_395 = val_385.Item["plv_lai"];
            if(val_395 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_397 = System.Int32.TryParse(s:  val_395, result: out  this.plvLettersArrayIncrement);
        }
        
            if((val_385.ContainsKey(key:  "plv_wlm")) != false)
        {
                object val_399 = val_385.Item["plv_wlm"];
            if(val_399 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_401 = System.Single.TryParse(s:  val_399, result: out  this.plvWordLengthMax);
        }
        
            if((val_385.ContainsKey(key:  "plv_nlm")) != false)
        {
                object val_403 = val_385.Item["plv_nlm"];
            if(val_403 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_405 = System.Int32.TryParse(s:  val_403, result: out  this.plvNumLettersMax);
        }
        
            if((val_385.ContainsKey(key:  "plv_glb")) != false)
        {
                object val_407 = val_385.Item["plv_glb"];
            if(val_407 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_409 = System.Single.TryParse(s:  val_407, result: out  this.plvGivenLettersBase);
        }
        
            if((val_385.ContainsKey(key:  "plv_gld")) != false)
        {
                object val_411 = val_385.Item["plv_gld"];
            if(val_411 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_413 = System.Single.TryParse(s:  val_411, result: out  this.plvGivenLettersDecrement);
        }
        
            if((val_385.ContainsKey(key:  "plv_glm")) != false)
        {
                object val_415 = val_385.Item["plv_glm"];
            if(val_415 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_417 = System.Single.TryParse(s:  val_415, result: out  this.plvGivenLettersMin);
        }
        
            if((val_385.ContainsKey(key:  "plv_wld")) != false)
        {
                object val_419 = val_385.Item["plv_wld"];
            if(val_419 == null)
        {
                throw new NullReferenceException();
        }
        
            if((MiniJSON.Json.Deserialize(json:  val_419)) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                if(null <= 0)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.plvWordLengthDeviations == null)
        {
                throw new NullReferenceException();
        }
        
            if(0 >= this.plvWordLengthDeviations.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
            this.plvWordLengthDeviations[0] = 13073.37f;
        }
        
        }
        
            if((val_385.ContainsKey(key:  "plv_la")) != false)
        {
                object val_422 = val_385.Item["plv_la"];
            if(val_422 == null)
        {
                throw new NullReferenceException();
        }
        
            if((MiniJSON.Json.Deserialize(json:  val_422)) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                if(null <= 0)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.plvLettersArray == null)
        {
                throw new NullReferenceException();
        }
        
            val_991 = null;
            this.plvLettersArray[0] = 1179403647;
        }
        
        }
        
            val_987 = 1152921504685600768;
            if((val_385.ContainsKey(key:  "plv_ch_nb")) != false)
        {
                object val_425 = val_385.Item["plv_ch_nb"];
            if(val_425 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_427 = System.Int32.TryParse(s:  val_425, result: out  this.plvHintsPerCh_BuyNone);
        }
        
            if((val_385.ContainsKey(key:  "plv_ch_ftb")) != false)
        {
                object val_429 = val_385.Item["plv_ch_ftb"];
            if(val_429 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_431 = System.Int32.TryParse(s:  val_429, result: out  this.plvHintsPerCh_BuyFirst);
        }
        
            if((val_385.ContainsKey(key:  "plv_ch_rb")) != false)
        {
                object val_433 = val_385.Item["plv_ch_rb"];
            if(val_433 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_435 = System.Int32.TryParse(s:  val_433, result: out  this.plvHintsPerCh_BuyRepeat);
        }
        
        }
        
        if((ContainsKey(key:  "r_lwm")) != false)
        {
                object val_437 = Item["r_lwm"];
            if(val_437 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_439 = System.Int32.TryParse(s:  val_437, result: out  this.remLevelWordMax);
        }
        
        if((ContainsKey(key:  "r_wrp")) != false)
        {
                object val_441 = Item["r_wrp"];
            if(val_441 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_443 = System.Int32.TryParse(s:  val_441, result: out  this.remWordRemovalPercentage);
        }
        
        if((ContainsKey(key:  "cso_p1")) != false)
        {
                object val_445 = Item["cso_p1"];
            if(val_445 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_447 = System.Boolean.TryParse(value:  val_445, result: out  this.coinStorePack1Override);
        }
        
        object val_448 = AdSegmentation.GetSegementedConfig(key:  "plop", knobs:  null, addSegment:  true);
        if(val_448 != null)
        {
                if((val_448.ContainsKey(key:  "ow")) != false)
        {
                val_990 = 1152921510214912464;
            object val_450 = val_448.Item["ow"];
            if(val_450 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_450.ContainsKey(key:  "rv")) != false)
        {
                object val_452 = val_450.Item["rv"];
            if(val_452 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_454 = System.Single.TryParse(s:  val_452, result: out  this.postLevelRewardedVideo_freq);
        }
        
            if((val_450.ContainsKey(key:  "ct")) != false)
        {
                object val_456 = val_450.Item["ct"];
            if(val_456 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_458 = System.Single.TryParse(s:  val_456, result: out  this.postLevelCollectionTile_freq);
        }
        
            if((val_450.ContainsKey(key:  "ac")) != false)
        {
                object val_460 = val_450.Item["ac"];
            if(val_460 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_462 = System.Single.TryParse(s:  val_460, result: out  this.postLevelAdsControl_freq);
        }
        
        }
        
            if((val_448.ContainsKey(key:  "ac")) != false)
        {
                object val_464 = val_448.Item["ac"];
            if(val_464 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_464.ContainsKey(key:  "dur")) != false)
        {
                object val_466 = val_464.Item["dur"];
            if(val_466 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_468 = System.Int32.TryParse(s:  val_466, result: out  this.postLevelAdsControl_duration);
        }
        
            val_990 = "lvl";
            if((val_464.ContainsKey(key:  "lvl")) != false)
        {
                object val_470 = val_464.Item["lvl"];
            if(val_470 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_472 = System.Int32.TryParse(s:  val_470, result: out  this.postLevelAdsControl_minLvl);
        }
        
        }
        
        }
        
        object val_473 = AdSegmentation.GetSegementedConfig(key:  "pl_l", knobs:  null, addSegment:  true);
        if(val_473 != null)
        {
                bool val_475 = System.Int32.TryParse(s:  val_473, result: out  this.postLevelRewardedVideo_Level);
        }
        
        object val_476 = AdSegmentation.GetSegementedConfig(key:  "pl_mn", knobs:  null, addSegment:  true);
        if(val_476 != null)
        {
                bool val_478 = System.Int32.TryParse(s:  val_476, result: out  this.postLevelRewardedVideo_minLevels);
        }
        
        object val_479 = AdSegmentation.GetSegementedConfig(key:  "pl_mx", knobs:  null, addSegment:  true);
        if(val_479 != null)
        {
                bool val_481 = System.Int32.TryParse(s:  val_479, result: out  this.postLevelRewardedVideo_maxLevels);
        }
        
        if((ContainsKey(key:  "5_star_review_delay")) != false)
        {
                object val_483 = Item["5_star_review_delay"];
            if(val_483 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_485 = System.Int32.TryParse(s:  val_483, result: out  1152921504973676548);
        }
        
        if((ContainsKey(key:  "str_unlck")) != false)
        {
                object val_487 = Item["str_unlck"];
            if(val_487 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_489 = System.Int32.TryParse(s:  val_487, result: out  this.starUnlockLevel);
        }
        
        if((ContainsKey(key:  "fflll")) != false)
        {
                object val_491 = Item["fflll"];
            if(val_491 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_493 = System.Int32.TryParse(s:  val_491, result: out  this.finalForcedLetterLayoutLevel);
        }
        
        if((ContainsKey(key:  "spl")) != false)
        {
                object val_495 = Item["spl"];
            if(val_495 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_497 = System.Int32.TryParse(s:  val_495, result: out  this.storyPopupLevel);
        }
        
        if((ContainsKey(key:  "h_d_l")) == false)
        {
            goto label_980;
        }
        
        if(this.WADHardLevels == null)
        {
                throw new NullReferenceException();
        }
        
        val_983 = this.WADHardLevels;
        val_983.Clear();
        if(Item["h_d_l"] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_501 = GetEnumerator();
        val_990 = 1152921510479955696;
        label_467:
        if(val_503.MoveNext() == false)
        {
            goto label_464;
        }
        
        val_983 = val_502;
        if(val_983 == 0)
        {
                throw new NullReferenceException();
        }
        
        this.WADHardLevels.Add(item:  System.Int32.Parse(s:  val_983, style:  511));
        goto label_467;
        label_464:
        val_503.Dispose();
        label_980:
        if((ContainsKey(key:  "nf_un_lvl")) != false)
        {
                object val_507 = Item["nf_un_lvl"];
            if(val_507 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_509 = System.Int32.TryParse(s:  val_507, result: out  this.notificationPromptUnlockLevel);
        }
        
        if((ContainsKey(key:  "nf_un_intvl")) != false)
        {
                object val_511 = Item["nf_un_intvl"];
            if(val_511 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_513 = System.Int32.TryParse(s:  val_511, result: out  this.notificationUnlockInterval);
        }
        
        if((ContainsKey(key:  "nf_un_aprn")) != false)
        {
                object val_515 = Item["nf_un_aprn"];
            if(val_515 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_517 = System.Int32.TryParse(s:  val_515, result: out  this.notificationUnlockAppearances);
        }
        
        if((ContainsKey(key:  "mg_ulk_lvls")) != false)
        {
                object val_519 = Item["mg_ulk_lvls"];
            if(val_519 != null)
        {
                if(val_519.Count >= 1)
        {
                this.minigameUnlockLevels = val_519;
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "ack")) != false)
        {
                object val_522 = Item["ack"];
            if(val_522 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_522.ContainsKey(key:  "cc_rew")) != false)
        {
                object val_524 = val_522.Item["cc_rew"];
            if(val_524 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.ab_completeCollectionReward;
            bool val_525 = System.Decimal.TryParse(s:  val_524, result: out  new System.Decimal() {flags = val_990, hi = val_990, lo = val_990, mid = val_990});
        }
        
            if((val_522.ContainsKey(key:  "lpt_min")) != false)
        {
                object val_527 = val_522.Item["lpt_min"];
            if(val_527 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_529 = System.Int32.TryParse(s:  val_527, result: out  this.ab_minLevelsPerTile);
        }
        
            if((val_522.ContainsKey(key:  "lpt_max")) != false)
        {
                object val_531 = val_522.Item["lpt_max"];
            if(val_531 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_533 = System.Int32.TryParse(s:  val_531, result: out  this.ab_maxLevelsPerTile);
        }
        
            if((val_522.ContainsKey(key:  "t_r_frq")) != false)
        {
                object val_535 = val_522.Item["t_r_frq"];
            if(val_535 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_537 = System.Int32.TryParse(s:  val_535, result: out  this.ab_postLevelTileFreq_Modulo);
        }
        
            if((val_522.ContainsKey(key:  "lvl")) != false)
        {
                object val_539 = val_522.Item["lvl"];
            if(val_539 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_541 = System.Int32.TryParse(s:  val_539, result: out  this.ab_unlockLevel);
        }
        
            if((val_522.ContainsKey(key:  "rd_cst")) != false)
        {
                object val_543 = val_522.Item["rd_cst"];
            if(val_543 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_544 = System.Decimal.TryParse(s:  val_543, result: out  new System.Decimal() {flags = this.ab_redrawCoinCost, hi = this.ab_redrawCoinCost, lo = this.ab_redrawCoinCost, mid = this.ab_redrawCoinCost});
        }
        
        }
        
        if((ContainsKey(key:  "bgw")) != false)
        {
                val_990 = 1152921510214912464;
            object val_546 = Item["bgw"];
            if(val_546 == null)
        {
                throw new NullReferenceException();
        }
        
            if(((val_546.ContainsKey(key:  "c")) != false) && (val_546.Item["c"] != null))
        {
                this.bonusGameWheelAwardCoins = new int[-1710462256];
            if(1152921505059750640 >= 1)
        {
                do
        {
            if(1152921505059750640 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_983 = null;
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            if(this.bonusGameWheelAwardCoins == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_552 = System.Int32.TryParse(s:  ToString(), result: out  this.bonusGameWheelAwardCoins[32]);
        }
        while(1 < this.bonusGameWheelAwardCoins);
        
        }
        
        }
        
            if(((val_546.ContainsKey(key:  "gc")) != false) && (val_546.Item["gc"] != null))
        {
                this.bonusGameWheelAwardGoldenCurrency = new int[-242073040];
            if(1152921505059750640 >= 1)
        {
                do
        {
            if(1152921505059750640 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_983 = null;
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            if(this.bonusGameWheelAwardGoldenCurrency == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_558 = System.Int32.TryParse(s:  ToString(), result: out  this.bonusGameWheelAwardGoldenCurrency[32]);
            val_990 = 36;
        }
        while(1 < this.bonusGameWheelAwardGoldenCurrency);
        
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "s_p")) != false)
        {
                object val_560 = Item["s_p"];
            if(val_560 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_560.ContainsKey(key:  "en")) != false)
        {
                object val_562 = val_560.Item["en"];
            if(val_562 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.starterPackEnabled;
            bool val_564 = System.Boolean.TryParse(value:  val_562, result: out  val_990);
        }
        
            if((val_560.ContainsKey(key:  "lvl")) != false)
        {
                object val_566 = val_560.Item["lvl"];
            if(val_566 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_568 = System.Int32.TryParse(s:  val_566, result: out  this.starterPackLevel);
        }
        
            int val_571 = 0;
            if((val_560.ContainsKey(key:  "t")) != false)
        {
                object val_570 = val_560.Item["t"];
            if(val_570 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_570, result: out  val_571)) != false)
        {
                System.TimeSpan val_573;
            val_503 = 0;
            val_573 = new System.TimeSpan(hours:  0, minutes:  0, seconds:  0);
            this.starterPackTimeSpan = val_573._ticks;
        }
        
        }
        
            if((val_560.ContainsKey(key:  "wd")) != false)
        {
                object val_575 = val_560.Item["wd"];
            if(val_575 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_575, result: out  val_571)) != false)
        {
                System.TimeSpan val_577;
            val_503 = 0;
            val_577 = new System.TimeSpan(days:  0, hours:  0, minutes:  0, seconds:  0);
            this.starterPackWaterfalDelay = val_577._ticks;
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "f_p")) != false)
        {
                object val_579 = Item["f_p"];
            if(val_579 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_579.ContainsKey(key:  "lvl")) != false)
        {
                object val_581 = val_579.Item["lvl"];
            if(val_581 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_583 = System.Int32.TryParse(s:  val_581, result: out  this.FOMOPackUnlockedLevel);
        }
        
            if((val_579.ContainsKey(key:  "max_bal")) != false)
        {
                object val_585 = val_579.Item["max_bal"];
            if(val_585 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.FOMOMaxBalance;
            bool val_586 = System.Decimal.TryParse(s:  val_585, result: out  new System.Decimal() {flags = val_990, hi = val_990, lo = val_990, mid = val_990});
        }
        
            if((val_579.ContainsKey(key:  "lvl_intvl")) != false)
        {
                object val_588 = val_579.Item["lvl_intvl"];
            if(val_588 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_590 = System.Int32.TryParse(s:  val_588, result: out  this.FOMOLevelInterval);
        }
        
            if((val_579.ContainsKey(key:  "t")) != false)
        {
                object val_592 = val_579.Item["t"];
            if(val_592 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_592, result: out  0)) != false)
        {
                System.TimeSpan val_595;
            val_503 = 0;
            val_595 = new System.TimeSpan(hours:  0, minutes:  0, seconds:  0);
            this.FOMOPackTimeSpan = val_595._ticks;
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "c_w")) != false)
        {
                object val_597 = Item["c_w"];
            if(val_597 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_597.ContainsKey(key:  "ul")) != false)
        {
                object val_599 = val_597.Item["ul"];
            if(val_599 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_601 = System.Int32.TryParse(s:  val_599, result: out  this._challengeWordsunlockLevel);
        }
        
            if((val_597.ContainsKey(key:  "lc")) != false)
        {
                object val_603 = val_597.Item["lc"];
            if(val_603 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_605 = System.Int32.TryParse(s:  val_603, result: out  this._challengeWordsLevelCooldown);
        }
        
            val_990 = "ch";
            if((val_597.ContainsKey(key:  "ch")) != false)
        {
                object val_607 = val_597.Item["ch"];
            if(val_607 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_609 = System.Int32.TryParse(s:  val_607, result: out  this._challengeWordsWordChance);
        }
        
        }
        
        if((ContainsKey(key:  "lws")) != false)
        {
                object val_611 = Item["lws"];
            if(val_611 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_613 = System.Boolean.TryParse(value:  val_611, result: out  this.levelSkipEnabled);
        }
        
        if((ContainsKey(key:  "eul")) != false)
        {
                object val_615 = Item["eul"];
            if(val_615 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_617 = System.Int32.TryParse(s:  val_615, result: out  this.events_unlockLevel);
        }
        
        if((ContainsKey(key:  "fht")) != false)
        {
                val_990 = 1152921510214912464;
            object val_619 = Item["fht"];
            if(val_619 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_619.ContainsKey(key:  "fl")) != false)
        {
                object val_621 = val_619.Item["fl"];
            if(val_621 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_623 = System.Int32.TryParse(s:  val_621, result: out  this.freeHintFinalLevel);
        }
        
            if((val_619.ContainsKey(key:  "st")) != false)
        {
                object val_625 = val_619.Item["st"];
            if(val_625 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_627 = System.Int32.TryParse(s:  val_625, result: out  this.freeHintInitialTooltip);
        }
        
            if((val_619.ContainsKey(key:  "et")) != false)
        {
                object val_629 = val_619.Item["et"];
            if(val_629 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_631 = System.Int32.TryParse(s:  val_629, result: out  this.freeHintEndingTooltip);
        }
        
        }
        
        if((ContainsKey(key:  "s_h")) != false)
        {
                val_990 = 1152921510214912464;
            object val_633 = Item["s_h"];
            if(val_633 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_633.ContainsKey(key:  "hpl")) != false)
        {
                object val_635 = val_633.Item["hpl"];
            if(val_635 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_637 = System.Int32.TryParse(s:  val_635, result: out  this.spHintsPerLevel);
        }
        
            if((val_633.ContainsKey(key:  "sl")) != false)
        {
                object val_639 = val_633.Item["sl"];
            if(val_639 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_641 = System.Int32.TryParse(s:  val_639, result: out  this.spHintStartLevel);
        }
        
            if((val_633.ContainsKey(key:  "el")) != false)
        {
                object val_643 = val_633.Item["el"];
            if(val_643 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_645 = System.Int32.TryParse(s:  val_643, result: out  this.spHintEndLevel);
        }
        
            if((val_633.ContainsKey(key:  "hc")) != false)
        {
                object val_647 = val_633.Item["hc"];
            if(val_647 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_649 = System.Single.TryParse(s:  val_647, result: out  this.spHintConstant);
        }
        
        }
        
        if((ContainsKey(key:  "hm_ft")) != false)
        {
                object val_651 = Item["hm_ft"];
            if(val_651 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_653 = System.Int32.TryParse(s:  val_651, result: out  this.hintMeterFreeHints);
        }
        
        if((ContainsKey(key:  "eul")) != false)
        {
                object val_655 = Item["eul"];
            if(val_655 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_657 = System.Int32.TryParse(s:  val_655, result: out  this.events_unlockLevel);
        }
        
        if((ContainsKey(key:  "db_ftux")) != false)
        {
                object val_659 = Item["db_ftux"];
            if(val_659 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_659.ContainsKey(key:  "lvl")) != false)
        {
                object val_661 = val_659.Item["lvl"];
            if(val_661 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_663 = System.Int32.TryParse(s:  val_661, result: out  this.dbFtuxLevel);
        }
        
            val_990 = "cr";
            if((val_659.ContainsKey(key:  "cr")) != false)
        {
                object val_665 = val_659.Item["cr"];
            if(val_665 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_667 = System.Int32.TryParse(s:  val_665, result: out  this.dbFtuxCr);
        }
        
        }
        
        if((ContainsKey(key:  "wiq")) != false)
        {
                object val_669 = Item["wiq"];
            if(val_669 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_669.ContainsKey(key:  "b_iq")) != false)
        {
                object val_671 = val_669.Item["b_iq"];
            if(val_671 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_BaseIQ = System.Single.Parse(s:  val_671, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            if((val_669.ContainsKey(key:  "nw")) != false)
        {
                object val_675 = val_669.Item["nw"];
            if(val_675 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_675.ContainsKey(key:  "bp")) != false)
        {
                object val_677 = val_675.Item["bp"];
            if(val_677 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_BaseNewWordPoint = System.Single.Parse(s:  val_677, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            if((val_675.ContainsKey(key:  "lp")) != false)
        {
                object val_681 = val_675.Item["lp"];
            if(val_681 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_LetterPoint = System.Single.Parse(s:  val_681, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            val_990 = "mult";
            if((val_675.ContainsKey(key:  "mult")) != false)
        {
                object val_685 = val_675.Item["mult"];
            if(val_685 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_NEWWORDMultiplier = System.Single.Parse(s:  val_685, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        }
        
            if((val_669.ContainsKey(key:  "lc")) != false)
        {
                object val_689 = val_669.Item["lc"];
            if(val_689 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_689.ContainsKey(key:  "min_bcp")) != false)
        {
                object val_691 = val_689.Item["min_bcp"];
            if(val_691 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_BaseClearPoints_min = System.Single.Parse(s:  val_691, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            if((val_689.ContainsKey(key:  "max_bcp")) != false)
        {
                object val_695 = val_689.Item["max_bcp"];
            if(val_695 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_BaseClearPoints_max = System.Single.Parse(s:  val_695, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            if((val_689.ContainsKey(key:  "h_c")) != false)
        {
                object val_699 = val_689.Item["h_c"];
            if(val_699 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_HighestComplexity = System.Single.Parse(s:  val_699, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
            val_990 = "max_acp";
            if((val_689.ContainsKey(key:  "max_acp")) != false)
        {
                object val_703 = val_689.Item["max_acp"];
            if(val_703 == null)
        {
                throw new NullReferenceException();
        }
        
            this.WIQ_MaxAdditionalClearPoints = System.Single.Parse(s:  val_703, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        }
        
            if((val_669.ContainsKey(key:  "m_t")) != false)
        {
                object val_707 = val_669.Item["m_t"];
            val_990 = 0;
            System.Collections.Generic.List<System.Single> val_709 = new System.Collections.Generic.List<System.Single>();
            if(this.WIQ_Milestones == null)
        {
                throw new NullReferenceException();
        }
        
            var val_710 = (0 >= this.WIQ_Milestones.Length) ? 1 : 0;
            val_710 = val_710 | ((0 < this.WIQ_Milestones.Length) ? 1 : 0);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_983 = mem[((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_707 : 0 + 16 + 0) + 32];
            val_983 = ((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_707 : 0 + 16 + 0) + 32;
            val_983 = val_983;
            float val_713 = System.Single.Parse(s:  val_983, provider:  System.Globalization.CultureInfo.InvariantCulture);
            if(val_713 > (-1f))
        {
                if(val_709 == null)
        {
                throw new NullReferenceException();
        }
        
            val_983 = val_709;
            val_709.Add(item:  val_713);
        }
        
            if(val_709 == null)
        {
                throw new NullReferenceException();
        }
        
            val_987 = 1152921504685600768;
            this.WIQ_Milestones = val_709.ToArray();
        }
        
        }
        
        if((ContainsKey(key:  "h_s")) != false)
        {
                object val_716 = Item["h_s"];
            if(val_716 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_716.ContainsKey(key:  "store")) != false)
        {
                object val_718 = val_716.Item["store"];
            if(val_718 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_720 = System.Int32.TryParse(s:  val_718, result: out  this.storeButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "fr_in")) != false)
        {
                object val_722 = val_716.Item["fr_in"];
            if(val_722 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_724 = System.Int32.TryParse(s:  val_722, result: out  this.friendInvButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "alph")) != false)
        {
                object val_726 = val_716.Item["alph"];
            if(val_726 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_728 = System.Int32.TryParse(s:  val_726, result: out  this.alphButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "iq")) != false)
        {
                object val_730 = val_716.Item["iq"];
            if(val_730 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_732 = System.Int32.TryParse(s:  val_730, result: out  this.iqButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "d_c")) != false)
        {
                object val_734 = val_716.Item["d_c"];
            if(val_734 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_736 = System.Int32.TryParse(s:  val_734, result: out  this.dcButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "leag")) != false)
        {
                object val_738 = val_716.Item["leag"];
            if(val_738 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_740 = System.Int32.TryParse(s:  val_738, result: out  this.leaguesButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "lib")) != false)
        {
                object val_742 = val_716.Item["lib"];
            if(val_742 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_744 = System.Int32.TryParse(s:  val_742, result: out  this.libraryButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "cat")) != false)
        {
                object val_746 = val_716.Item["cat"];
            if(val_746 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_748 = System.Int32.TryParse(s:  val_746, result: out  this.categoriesButtonDisplayLevel);
        }
        
            if((val_716.ContainsKey(key:  "cat_sbl")) != false)
        {
                object val_750 = val_716.Item["cat_sbl"];
            if(val_750 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.categoryShowButtonLocked;
            bool val_752 = System.Boolean.TryParse(value:  val_750, result: out  val_990);
        }
        
            if((val_716.ContainsKey(key:  "event")) != false)
        {
                object val_754 = val_716.Item["event"];
            if(val_754 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_756 = System.Int32.TryParse(s:  val_754, result: out  this.eventButtonDisplayLevel);
        }
        
        }
        
        if((ContainsKey(key:  "tl")) != false)
        {
                val_990 = 1152921510214912464;
            object val_758 = Item["tl"];
            if(val_758 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_758.ContainsKey(key:  "ccb")) != false)
        {
                object val_760 = val_758.Item["ccb"];
            if(val_760 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_762 = System.Int32.TryParse(s:  val_760, result: out  1152921504898863140);
        }
        
            if((val_758.ContainsKey(key:  "rf_hrs")) != false)
        {
                object val_764 = val_758.Item["rf_hrs"];
            if(val_764 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_766 = System.Int32.TryParse(s:  val_764, result: out  1152921504898863136);
        }
        
            if((val_758.ContainsKey(key:  "bp")) != false)
        {
                object val_768 = val_758.Item["bp"];
            if(val_768 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_768.ContainsKey(key:  "c")) != false)
        {
                object val_770 = val_768.Item["c"];
            if(val_770 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_770, result: out  100)) != false)
        {
                val_983 = TheLibraryLogic.BookEcon;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_983.Item[0] == null)
        {
                throw new NullReferenceException();
        }
        
            val_773.GoldenAppleCost = 100;
        }
        
        }
        
            if((val_768.ContainsKey(key:  "u")) != false)
        {
                object val_775 = val_768.Item["u"];
            if(val_775 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_775, result: out  350)) != false)
        {
                val_983 = TheLibraryLogic.BookEcon;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_983.Item[1] == null)
        {
                throw new NullReferenceException();
        }
        
            val_778.GoldenAppleCost = 350;
        }
        
        }
        
            if((val_768.ContainsKey(key:  "r")) != false)
        {
                object val_780 = val_768.Item["r"];
            if(val_780 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_780, result: out  1500)) != false)
        {
                val_983 = TheLibraryLogic.BookEcon;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_983.Item[2] == null)
        {
                throw new NullReferenceException();
        }
        
            val_783.GoldenAppleCost = 1500;
        }
        
        }
        
            if((val_768.ContainsKey(key:  "s")) != false)
        {
                object val_785 = val_768.Item["s"];
            if(val_785 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_785, result: out  5500)) != false)
        {
                val_992 = null;
            val_992 = null;
            val_983 = TheLibraryLogic.BookEcon;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_983.Item[3] == null)
        {
                throw new NullReferenceException();
        }
        
            val_788.GoldenAppleCost = 5500;
        }
        
        }
        
        }
        
            if((val_758.ContainsKey(key:  "lvl_p_ch")) != false)
        {
                object val_790 = val_758.Item["lvl_p_ch"];
            if(val_790 == null)
        {
                throw new NullReferenceException();
        }
        
            val_993 = null;
            val_993 = null;
            bool val_792 = System.Int32.TryParse(s:  val_790, result: out  1152921504898543628);
        }
        
            if((val_758.ContainsKey(key:  "ch_p_bk")) != false)
        {
                object val_794 = val_758.Item["ch_p_bk"];
            if(val_794 == null)
        {
                throw new NullReferenceException();
        }
        
            val_994 = null;
            val_994 = null;
            bool val_796 = System.Int32.TryParse(s:  val_794, result: out  1152921504898543624);
        }
        
            if((val_758.ContainsKey(key:  "b_s")) != false)
        {
                object val_798 = val_758.Item["b_s"];
            if((val_798 != null) && (null >= 1))
        {
                val_995 = null;
            val_995 = null;
            BookList.BookOptionsSkus = val_798;
        }
        
        }
        
            if((val_758.ContainsKey(key:  "bpk")) != false)
        {
                object val_800 = val_758.Item["bpk"];
            if(val_800 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_800.ContainsKey(key:  "5bp_gc")) != false)
        {
                object val_802 = val_800.Item["5bp_gc"];
            if(val_802 == null)
        {
                throw new NullReferenceException();
        }
        
            val_996 = null;
            val_996 = null;
            bool val_804 = System.Int32.TryParse(s:  val_802, result: out  1152921504898863152);
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "cs")) != false)
        {
                object val_806 = Item["cs"];
            if(val_806 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_806.ContainsKey(key:  "fo")) != false)
        {
                object val_808 = val_806.Item["fo"];
            if(val_808 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_808.ContainsKey(key:  "min_p")) != false)
        {
                object val_810 = val_808.Item["min_p"];
            if(val_810 == null)
        {
                throw new NullReferenceException();
        }
        
            val_997 = null;
            val_997 = null;
            bool val_811 = System.Int32.TryParse(s:  val_810, result: out  void* val_811 = FeaturedOfferManager.__il2cppRuntimeField_static_fields);
        }
        
            if((val_808.ContainsKey(key:  "p_pct")) != false)
        {
                object val_813 = val_808.Item["p_pct"];
            if(val_813 == null)
        {
                throw new NullReferenceException();
        }
        
            val_998 = null;
            val_998 = null;
            bool val_815 = System.Int32.TryParse(s:  val_813, result: out  1152921504921546760);
        }
        
            if((val_808.ContainsKey(key:  "bc_pct")) != false)
        {
                object val_817 = val_808.Item["bc_pct"];
            if(val_817 == null)
        {
                throw new NullReferenceException();
        }
        
            val_999 = null;
            val_999 = null;
            bool val_819 = System.Int32.TryParse(s:  val_817, result: out  1152921504921546764);
        }
        
            val_990 = "pp_del";
            if((val_808.ContainsKey(key:  "pp_del")) != false)
        {
                object val_821 = val_808.Item["pp_del"];
            if(val_821 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = 1152921504921542656;
            val_1000 = null;
            val_1000 = null;
            bool val_823 = System.Int32.TryParse(s:  val_821, result: out  1152921504921546756);
        }
        
        }
        
            if((val_806.ContainsKey(key:  "99_lsl")) != false)
        {
                object val_825 = val_806.Item["99_lsl"];
            if(val_825 == null)
        {
                throw new NullReferenceException();
        }
        
            this.lifetime099SpendLimit = System.Single.Parse(s:  val_825, provider:  System.Globalization.CultureInfo.InvariantCulture);
        }
        
        }
        
        if((ContainsKey(key:  "ft_e")) != false)
        {
                object val_829 = Item["ft_e"];
            if(val_829 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_831 = System.Boolean.TryParse(value:  val_829, result: out  this.ftuxTutorialEnabled);
        }
        
        if((ContainsKey(key:  "cat")) != false)
        {
                object val_833 = Item["cat"];
            if(val_833 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_833.ContainsKey(key:  "en")) != false)
        {
                object val_835 = val_833.Item["en"];
            if(val_835 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_837 = System.Boolean.TryParse(value:  val_835, result: out  true);
            val_990 = 1152921504910999552;
            val_1001 = null;
            val_1001 = null;
            CategoryPacksManager.featureEnabled = true;
        }
        
            if((val_833.ContainsKey(key:  "lvl")) != false)
        {
                object val_839 = val_833.Item["lvl"];
            if(val_839 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_841 = System.Int32.TryParse(s:  val_839, result: out  this.categoryUnlockLevel);
        }
        
            if((val_833.ContainsKey(key:  "sld")) != false)
        {
                object val_843 = val_833.Item["sld"];
            if(val_843 == null)
        {
                throw new NullReferenceException();
        }
        
            this.categoryShowLevelsDisplay = val_843;
        }
        
            if((val_833.ContainsKey(key:  "g")) != false)
        {
                object val_845 = val_833.Item["g"];
            if(val_845 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_847 = System.Int32.TryParse(s:  val_845, result: out  this.categoryCompletionGoal);
        }
        
            if((val_833.ContainsKey(key:  "gi")) != false)
        {
                object val_849 = val_833.Item["gi"];
            if(val_849 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_851 = System.Int32.TryParse(s:  val_849, result: out  this.categoryCompletionCountIncrease);
        }
        
            if((val_833.ContainsKey(key:  "gm")) != false)
        {
                object val_853 = val_833.Item["gm"];
            if(val_853 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_855 = System.Int32.TryParse(s:  val_853, result: out  this.categoryCompletionGoalMax);
        }
        
            if((val_833.ContainsKey(key:  "lmw")) != false)
        {
                object val_857 = val_833.Item["lmw"];
            if(val_857 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_859 = System.Int32.TryParse(s:  val_857, result: out  this.categoryMaxRequiredWords);
        }
        
            if((val_833.ContainsKey(key:  "cr")) != false)
        {
                object val_861 = val_833.Item["cr"];
            if(val_861 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.categoryChapterReward;
            bool val_862 = System.Decimal.TryParse(s:  val_861, result: out  new System.Decimal() {flags = val_990, hi = val_990, lo = val_990, mid = val_990});
        }
        
            if((val_833.ContainsKey(key:  "ltc")) != false)
        {
                if(val_833.Item["ltc"] == null)
        {
                throw new NullReferenceException();
        }
        
            if(null >= 1)
        {
                var val_981 = 0;
            do
        {
            GameEcon.<>c__DisplayClass315_0 val_865 = new GameEcon.<>c__DisplayClass315_0();
            if(val_981 >= null)
        {
                val_983 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_990 = 0;
            if(val_865 == null)
        {
                throw new NullReferenceException();
        }
        
            .currPackId = 0;
            val_983 = null;
            val_983 = null;
            if((ContainsKey(key:  "id")) != false)
        {
                object val_868 = Item["id"];
            if(val_868 == null)
        {
                throw new NullReferenceException();
        }
        
            if(((System.Int32.TryParse(s:  val_868, result: out  1152921517509885328)) != false) && ((ContainsKey(key:  "start_date")) != false))
        {
                object val_872 = Item["start_date"];
            if(val_872 == null)
        {
                throw new NullReferenceException();
        }
        
            if(((System.DateTime.TryParse(s:  val_872, provider:  System.Globalization.CultureInfo.InvariantCulture, styles:  0, result: out  new System.DateTime() {dateData = System.DateTime.MinValue})) != false) && ((ContainsKey(key:  "duration")) != false))
        {
                object val_876 = Item["duration"];
            if(val_876 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Single.TryParse(s:  val_876, result: out  float val_877 = 2.327484E-38f)) != false)
        {
                val_1002 = null;
            val_1002 = null;
            val_990 = CategoryPackData.packList;
            if(val_990 == null)
        {
                throw new NullReferenceException();
        }
        
            CategoryPackInfo val_880 = val_990.Find(match:  new System.Predicate<CategoryPackInfo>(object:  val_865, method:  System.Boolean GameEcon.<>c__DisplayClass315_0::<ReadFromKnobs>b__0(CategoryPackInfo obj)));
            if(val_880 != null)
        {
                val_880.SetTimeLimited(startDate:  new System.DateTime() {dateData = System.DateTime.MinValue}, availDuration:  0f);
        }
        
        }
        
        }
        
        }
        
        }
        
            val_981 = val_981 + 1;
        }
        while(val_981 < 1152921516130046848);
        
        }
        
        }
        
        }
        
        val_1003 = 1152921510222861648;
        if((ContainsKey(key:  "pets")) != false)
        {
                object val_882 = Item["pets"];
            if(val_882 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = "f_dur_v2";
            if((val_882.ContainsKey(key:  "f_dur_v2")) != false)
        {
                object val_884 = val_882.Item["f_dur_v2"];
            if(val_884 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_886 = System.Int32.TryParse(s:  val_884, result: out  0);
            if(0 >= 1)
        {
                val_1005 = null;
            val_1005 = null;
            WADPets.WADPetsEcon.FedDurationHours = 0;
        }
        
        }
        
        }
        
        if((ContainsKey(key:  "lt_sb")) != false)
        {
                object val_888 = Item["lt_sb"];
            val_1006 = 0;
            LimitedTimeBundlesManager.DigestBundleKnobs(knobs:  null);
        }
        
        if((ContainsKey(key:  "lt_sb_v2")) != false)
        {
                object val_891 = Item["lt_sb_v2"];
            val_1007 = 0;
            LimitedTimeBundlesManager.DigestBundleKnobsV2(knobs:  null);
        }
        
        if((ContainsKey(key:  "wd_fl")) != false)
        {
                object val_894 = Item["wd_fl"];
            if(val_894 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_896 = System.Int32.TryParse(s:  val_894, result: out  this.definitionFtuxLevel);
        }
        
        if((ContainsKey(key:  "gcp_ftux")) != false)
        {
                object val_898 = Item["gcp_ftux"];
            if(val_898 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_900 = System.Int32.TryParse(s:  val_898, result: out  this.goldenAppleFtuxLevel);
        }
        
        if((ContainsKey(key:  "mo_ga")) != false)
        {
                object val_902 = Item["mo_ga"];
            val_1008 = 0;
            WGMoreGamesManager.DigestMoreGamesKnobs(knobs:  null);
        }
        
        if((ContainsKey(key:  "nutul")) != false)
        {
                object val_905 = Item["nutul"];
            if(val_905 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_907 = System.Int32.TryParse(s:  val_905, result: out  this.newUserTaskUnlock);
        }
        
        val_983 = null;
        val_983 = null;
        if(App.storageManager == null)
        {
                throw new NullReferenceException();
        }
        
        val_983 = mem[App.storageManager + 24];
        val_983 = App.storageManager.knobsModel;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        twelvegigs.storage.JsonDictionary val_908 = getGameplayKnobs();
        if(val_908 != null)
        {
                this.otherKnobsConfigjs = val_908;
        }
        else
        {
                val_983 = this.otherKnobsConfigjs;
            if(val_983 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.otherKnobsConfigjs.dataSource == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.otherKnobsConfigjs.dataSource.ContainsKey(key:  "c_m")) != false)
        {
                object val_910 = this.otherKnobsConfigjs.dataSource.Item["c_m"];
            if(val_910 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_910.ContainsKey(key:  "c_s")) != false)
        {
                if(val_910.Item["c_s"] == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = 1152921504619999232;
            val_991 = null;
            if(null >= 1)
        {
                object val_913 = val_910.Item["c_s"];
            if(val_913 == null)
        {
                throw new NullReferenceException();
        }
        
            val_991 = null;
            val_983 = val_913;
            decimal val_914 = System.Decimal.op_Implicit(value:  19914752);
            val_1004 = 1152921505022394368;
            val_990 = val_914.lo;
            val_1009 = null;
            val_1009 = null;
            SLC.Social.Leagues.LeaguesEconomy.MultiplierCostScale = val_914.flags;
            SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_3C = val_914.hi;
            SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_40 = val_990;
            SLC.Social.Leagues.LeaguesEconomy.CostToCreate.__il2cppRuntimeField_44 = val_914.mid;
        }
        
        }
        
            if((val_910.ContainsKey(key:  "m_io")) != false)
        {
                object val_916 = val_910.Item["m_io"];
            val_1010 = 0;
            SLC.Social.Leagues.LeaguesEconomy.UpdateMultiplierOptions(response:  null);
        }
        
        }
        
        if((ContainsKey(key:  "r_w_j")) == false)
        {
            goto label_926;
        }
        
        object val_919 = Item["r_w_j"];
        if(val_919 == null)
        {
                throw new NullReferenceException();
        }
        
        val_990 = "enabled";
        if((val_919.ContainsKey(key:  "enabled")) == true)
        {
            goto label_921;
        }
        
        val_990 = "en";
        if((val_919.ContainsKey(key:  "en")) == false)
        {
            goto label_922;
        }
        
        label_921:
        object val_922 = val_919.Item[val_990];
        if(val_922 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_924 = System.Boolean.TryParse(value:  val_922, result: out  this.jumbledWords);
        goto label_926;
        label_922:
        this.jumbledWords = false;
        label_926:
        if((ContainsKey(key:  "go_mu")) != false)
        {
                object val_926 = Item["go_mu"];
            if(val_926 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_926.ContainsKey(key:  "en")) != false)
        {
                object val_928 = val_926.Item["en"];
            if(val_928 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = this.gm_enabled;
            bool val_930 = System.Boolean.TryParse(value:  val_928, result: out  val_990);
        }
        
            if((val_926.ContainsKey(key:  "mult_def")) != false)
        {
                object val_932 = val_926.Item["mult_def"];
            if(val_932 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_934 = System.Single.TryParse(s:  val_932, result: out  this.gm_defaultMultiplier);
        }
        
            if((val_926.ContainsKey(key:  "init_cost")) != false)
        {
                object val_936 = val_926.Item["init_cost"];
            if(val_936 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_938 = System.Single.TryParse(s:  val_936, result: out  this.gm_defaultMultiplierCost);
        }
        
            if((val_926.ContainsKey(key:  "mult_inc")) != false)
        {
                object val_940 = val_926.Item["mult_inc"];
            if(val_940 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_942 = System.Single.TryParse(s:  val_940, result: out  this.gm_multiplierIncrement);
        }
        
            if((val_926.ContainsKey(key:  "gr_pow_co")) != false)
        {
                object val_944 = val_926.Item["gr_pow_co"];
            if(val_944 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_946 = System.Single.TryParse(s:  val_944, result: out  this.gm_costIncrementCoefficient);
        }
        
            if((val_926.ContainsKey(key:  "mult_max")) != false)
        {
                object val_948 = val_926.Item["mult_max"];
            if(val_948 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_950 = System.Single.TryParse(s:  val_948, result: out  this.gm_maxGoldenMultiplier);
        }
        
        }
        
        if((ContainsKey(key:  "el_ll")) != false)
        {
                object val_952 = Item["el_ll"];
            if(val_952 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_954 = System.Int32.TryParse(s:  val_952, result: out  this.maxLevelEasyLetters);
        }
        
        if((ContainsKey(key:  "caf")) != false)
        {
                object val_956 = Item["caf"];
            if(val_956 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_956.ContainsKey(key:  "lvl")) != false)
        {
                object val_958 = val_956.Item["lvl"];
            if(val_958 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_960 = System.Int32.TryParse(s:  val_958, result: out  this.caf_unlockLevel);
        }
        
            if((val_956.ContainsKey(key:  "f_s")) != false)
        {
                object val_962 = val_956.Item["f_s"];
            if(val_962 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_964 = System.Int32.TryParse(s:  val_962, result: out  this.caf_frequencyShown);
        }
        
            object val_965 = val_956.Item["rew"];
            if(val_965 == null)
        {
                throw new NullReferenceException();
        }
        
            val_990 = "c";
            if((val_965.ContainsKey(key:  "c")) != false)
        {
                object val_967 = val_965.Item["c"];
            if(val_967 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_968 = System.Decimal.TryParse(s:  val_967, result: out  new System.Decimal() {flags = this.caf_reward_coins, hi = this.caf_reward_coins, lo = this.caf_reward_coins, mid = this.caf_reward_coins});
        }
        
        }
        
        val_986 = "s_s";
        if((ContainsKey(key:  "s_s")) == false)
        {
                return;
        }
        
        val_990 = 1152921510214912464;
        object val_970 = Item["s_s"];
        if(val_970 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_970.ContainsKey(key:  "en")) != false)
        {
                object val_972 = val_970.Item["en"];
            if(val_972 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_974 = System.Boolean.TryParse(value:  val_972, result: out  this.ss_enabled);
        }
        
        if((val_970.ContainsKey(key:  "mo")) != false)
        {
                object val_976 = val_970.Item["mo"];
            if(val_976 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_978 = System.Int32.TryParse(s:  val_976, result: out  this.ss_min_offer);
        }
        
        val_986 = "cm";
        if((val_970.ContainsKey(key:  "cm")) == false)
        {
                return;
        }
        
        if(val_970.Item["cm"] == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_974;
    }
    public GameEcon()
    {
        AppConfigs val_1 = App.Configuration;
        this.numberFormatInt = val_1.econConfig.NumberFormat;
        this._titleFormat = "";
        AppConfigs val_2 = App.Configuration;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_2.econConfig.DefaultPlayerCoins);
        this.InitialPlayerCoins = val_3;
        mem[1152921517510671420] = val_3.lo;
        mem[1152921517510671424] = val_3.mid;
        this.InitialPlayerGems = 14;
        AppConfigs val_4 = App.Configuration;
        decimal val_5 = System.Decimal.op_Implicit(value:  val_4.econConfig.HintCost);
        this._HintCost = val_5;
        mem[1152921517510671444] = val_5.lo;
        mem[1152921517510671448] = val_5.mid;
        AppConfigs val_6 = App.Configuration;
        decimal val_7 = System.Decimal.op_Implicit(value:  val_6.econConfig.HintPickerCost);
        this._HintPickerCost = val_7;
        mem[1152921517510671460] = val_7.lo;
        mem[1152921517510671464] = val_7.mid;
        AppConfigs val_8 = App.Configuration;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8.econConfig.MegaHintCost);
        this._HintMEGACost = val_9;
        mem[1152921517510671476] = val_9.lo;
        mem[1152921517510671480] = val_9.mid;
        this.ChapterClearedRewardMulitplier = 1f;
        AppConfigs val_10 = App.Configuration;
        decimal val_11 = System.Decimal.op_Implicit(value:  val_10.econConfig.ChapterCompleteBonus);
        this.InitialChapterClearedReward = val_11;
        mem[1152921517510671496] = val_11.lo;
        mem[1152921517510671500] = val_11.mid;
        AppConfigs val_12 = App.Configuration;
        this.InitialExtraWordsReq = val_12.econConfig.InitalExtraWordsReq;
        AppConfigs val_13 = App.Configuration;
        this.ExtraWordsIncrement = val_13.econConfig.ExtraWordsReqInc;
        AppConfigs val_14 = App.Configuration;
        this.ExtraWordsMaxReq = val_14.econConfig.MaxExtraWordsReq;
        AppConfigs val_15 = App.Configuration;
        decimal val_16 = System.Decimal.op_Implicit(value:  val_15.econConfig.RewardCoins);
        mem2[0] = val_16.flags;
        mem[4] = val_16.hi;
        mem[1152921517510671524] = val_16.lo;
        mem[1152921517510671528] = val_16.mid;
        AppConfigs val_17 = App.Configuration;
        decimal val_18 = System.Decimal.op_Implicit(value:  val_17.econConfig.VideoAdRewardCoins);
        mem2[0] = val_18.flags;
        mem[4] = val_18.hi;
        mem[1152921517510671540] = val_18.lo;
        mem[1152921517510671544] = val_18.mid;
        AppConfigs val_19 = App.Configuration;
        decimal val_20 = System.Decimal.op_Implicit(value:  val_19.econConfig.NonPurchaserVideoAdRewardCoins);
        mem2[0] = val_20.flags;
        mem[4] = val_20.hi;
        mem[1152921517510671556] = val_20.lo;
        mem[1152921517510671560] = val_20.mid;
        AppConfigs val_21 = App.Configuration;
        decimal val_22 = System.Decimal.op_Implicit(value:  val_21.econConfig.OneTimePurchaserVideoAdRewardCoins);
        mem2[0] = val_22.flags;
        mem[4] = val_22.hi;
        mem[1152921517510671572] = val_22.lo;
        mem[1152921517510671576] = val_22.mid;
        AppConfigs val_23 = App.Configuration;
        decimal val_24 = System.Decimal.op_Implicit(value:  val_23.econConfig.RepeatPurchaserVideoAdRewardCoins);
        mem2[0] = val_24.flags;
        mem[4] = val_24.hi;
        mem[1152921517510671588] = val_24.lo;
        mem[1152921517510671592] = val_24.mid;
        AppConfigs val_25 = App.Configuration;
        decimal val_26 = System.Decimal.op_Implicit(value:  val_25.econConfig.VideoAdRewardBonusCollectCoins);
        mem2[0] = val_26.flags;
        mem[4] = val_26.hi;
        mem[1152921517510671604] = val_26.lo;
        mem[1152921517510671608] = val_26.mid;
        AppConfigs val_27 = App.Configuration;
        this.NoAdsStarterPackCoinAmount = val_27.econConfig.NoAdsStartCoinAmount;
        AppConfigs val_28 = App.Configuration;
        this.NoAdsPackagePriceToUse = val_28.econConfig.DefaultNoAdsPackagePrice;
        AppConfigs val_29 = App.Configuration;
        this.fallbackNoAdsPackagePriceToUse = val_29.econConfig.DefaultNoAdsPackagePrice;
        AppConfigs val_30 = App.Configuration;
        decimal val_31 = System.Decimal.op_Implicit(value:  val_30.econConfig.FacebookConnectBonus);
        this.fbConnectBonus = val_31;
        mem[1152921517510671632] = val_31.lo;
        mem[1152921517510671636] = val_31.mid;
        AppConfigs val_32 = App.Configuration;
        this.dailyBonusHours = val_32.econConfig.TimerHours;
        AppConfigs val_33 = App.Configuration;
        this.dailyBonusTiers = val_33.econConfig.DailyBonusCoinRewardTiers;
        AppConfigs val_34 = App.Configuration;
        this.dailyBonusVideoRewards = val_34.econConfig.DailyBonusVideoRewards;
        this.LimitedTimeBundlesEcon = new LimitedTimeBundlesEcon();
        this.subscriptionPromoPostDailyBonusLevel = 0;
        AppConfigs val_36 = App.Configuration;
        decimal val_37 = System.Decimal.op_Implicit(value:  val_36.econConfig.RateBonus);
        mem2[0] = val_37.flags;
        mem[4] = val_37.hi;
        mem[1152921517510671684] = val_37.lo;
        mem[1152921517510671688] = val_37.mid;
        AppConfigs val_38 = App.Configuration;
        decimal val_39 = System.Decimal.op_Implicit(value:  val_38.econConfig.WordCoinBonus);
        mem2[0] = val_39.flags;
        mem[4] = val_39.hi;
        mem[1152921517510671700] = val_39.lo;
        mem[1152921517510671704] = val_39.mid;
        AppConfigs val_40 = App.Configuration;
        decimal val_41 = System.Decimal.op_Implicit(value:  val_40.econConfig.IncentivizedEmailPrompt);
        mem2[0] = val_41.flags;
        mem[4] = val_41.hi;
        mem[1152921517510671716] = val_41.lo;
        mem[1152921517510671720] = val_41.mid;
        AppConfigs val_42 = App.Configuration;
        this.emailCollectTimeoutDays = val_42.econConfig.EmailPromptFrequency;
        AppConfigs val_43 = App.Configuration;
        this.freeHintPopupLevel = val_43.econConfig.VideoAdPlayerLevel;
        AppConfigs val_44 = App.Configuration;
        this.freeHintPostDailyBonus = val_44.econConfig.FreeHintDailyBonusLevel;
        AppConfigs val_45 = App.Configuration;
        this.adsControlPopupLevel = val_45.econConfig.AdsControlPopup;
        AppConfigs val_46 = App.Configuration;
        this.adsControlMaxViews = 5;
        this.adsControlButtonLevel_max = val_46.econConfig.AdsControlButtonMaxLevel;
        AppConfigs val_47 = App.Configuration;
        this.emailCollectPopupLevel = val_47.econConfig.EmailPromptUnlockLevel;
        this.extraReqBeginningChapter = 10;
        this.extraReqDefaultLevelsPerChapter = 1;
        AppConfigs val_48 = App.Configuration;
        this.extraReqIncrement = val_48.econConfig.ExtraReqIncrement;
        AppConfigs val_49 = App.Configuration;
        this.extraReqMaxLevelsPerChapter = val_49.econConfig.MaxExtraReqLevelsPerChapter;
        AppConfigs val_50 = App.Configuration;
        this.extraReqHintsPerCh_BuyNone = val_50.econConfig.HintsPerChapterNonBuyer;
        AppConfigs val_51 = App.Configuration;
        this.extraReqHintsPerCh_BuyFirst = val_51.econConfig.HintsPerChapterOneTimeBuyer;
        AppConfigs val_52 = App.Configuration;
        this.extraReqHintsPerCh_BuyRepeat = val_52.econConfig.HintsPerChapterRepeatBuyer;
        AppConfigs val_53 = App.Configuration;
        this.extraReqQuantityPerLevel = val_53.econConfig.ExtraRequiredQuantityPerLevel;
        AppConfigs val_54 = App.Configuration;
        this.extraReqPostPurchaseLvl = val_54.econConfig.ExtraRequiredPostPurchaseLevel;
        mem2[0] = ;
        AppConfigs val_55 = App.Configuration;
        this.hintTutorialLevel = val_55.econConfig.HintTutorialLevel;
        AppConfigs val_56 = App.Configuration;
        this.hintTutorialLevelV2 = val_56.econConfig.HintTutorialLevelV2;
        AppConfigs val_57 = App.Configuration;
        this.hintPickerTutorialLevel = val_57.econConfig.PickerHintTutorialLevel;
        AppConfigs val_58 = App.Configuration;
        this.hintPickerTutorialLevelV2 = val_58.econConfig.PickerHintTutorialLevelV2;
        AppConfigs val_59 = App.Configuration;
        this.FInviter_GO_R = 1300;
        this.FInviterEnabled = true;
        this.FInviterLevelComplete = ;
        this.FInviterCoinsReward = ;
        this.FInviterFTUX = 21474836522;
        this.FInviter_BR_I = 5;
        this.FInviter_BR_R = ;
        this.FInviter_SI_I = ;
        this.FInviter_SI_R = 214748365400;
        this.FInviter_GO_I = 50;
        this.hintMEGATutorialLevel = val_59.econConfig.MegaHintTutorialLevel;
        mem2[0] = ;
        this.difficultySettingPromptLevel = 105;
        mem2[0] = 4.24399158193549E-311;
        mem2[0] = 1.19209318347191E-07;
        mem2[0] = 1096810496;
        this.plvReqWordDeviations = new float[20] {2.690493E-43f, 5.766483E-41f, 2.322652E-41f, 4.618399E-41f, 2.67648E-43f, 2.322652E-41f, 2.67648E-43f, 4.618399E-41f, 4.600463E-41f, 5.748547E-41f, 2.304716E-41f, 5.748547E-41f, 8.82818E-44f, 1.156912E-41f, 8.044434E-41f, 6.89649E-41f, 2.304716E-41f, 6.89649E-41f, 5.829402E-42f, 3.452799E-41f};
        this.plvExtraWordCounts = new int[20] {6, 5, 4, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0};
        this.plvNumWordLengths = new int[20] {3, 3, 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        this.plvLettersArrayIncrement = 2;
        this.plvWordLengthMax = 7f;
        this.plvNumLettersMax = 18;
        this.plvDesiredWordLengthBase = 5f;
        this.plvDesiredWordLengthIncrement = 0.1f;
        mem2[0] = 3.43322836382498E-06;
        this.plvGivenLettersMin = 1f;
        this.plvWordLengthDeviations = new float[20] {4.61854E-41f, -4.294963E+08f, -4.294962E+08f, -6.352689E-23f, 4.172329E-08f, -4.284436E+08f, -6.35277E-23f, -4.284477E+08f, 2.67648E-43f, 0f, -4.294922E+08f, -6.33201E-23f, 4.600603E-41f, 8.82818E-44f, -4.284477E+08f, -6.332091E-23f, -4.294921E+08f, 2.720076E+23f, 6.89649E-41f, 8.96831E-44f};
        this.plvHintsPerCh_BuyNone = 2;
        this.plvHintsPerCh_BuyFirst = 5;
        this.plvLettersArray = new int[20] {15, 14, 14, 13, 13, 13, 13, 12, 12, 12, 12, 12, 12, 11, 11, 11, 11, 10, 10, 10};
        this.plvHintsPerCh_BuyRepeat = 10;
        mem2[0] = 1.19209318472091E-07;
        this.wsaMaximumGridSize = 12f;
        mem2[0] = ;
        this.ChapterHintThresholdRepeatBuyer = 10;
        AppConfigs val_65 = App.Configuration;
        this.hintDiscountSizePercent = val_65.econConfig.DiscountSizePercent;
        AppConfigs val_66 = App.Configuration;
        this.hintDiscountChapterMinutes = val_66.econConfig.DiscountChapterMinutes;
        AppConfigs val_67 = App.Configuration;
        this.hintDiscountDailyBonusMinutes = val_67.econConfig.DiscountDailyBonusMinutes;
        AppConfigs val_68 = App.Configuration;
        this.hintDiscountChapterFreq = val_68.econConfig.DiscountChapterFrequency;
        mem2[0] = 1073741824;
        this.alphabetRewards = new System.Collections.Generic.List<System.Object>();
        this.starUnlockLevel = 6;
        this.starRowDif = 2;
        mem2[0] = ;
        this.storyPopupLevel = 0;
        this.WADHardLevels = new System.Collections.Generic.List<System.Int32>();
        mem2[0] = ;
        this.ftuxTutorialEnabled = true;
        mem2[0] = ;
        mem2[0] = 3.4332283505023E-06;
        this.postLevelAdsControl_freq = 0.1f;
        mem2[0] = ;
        this.notificationUnlockAppearances = 4;
        this.offersEnabled = true;
        this.surveysEnabled = true;
        decimal val_71 = new System.Decimal(value:  232);
        this.ab_completeCollectionReward = val_71.flags;
        mem[1152921517510672216] = val_71.lo;
        this.ab_minLevelsPerTile = ;
        this.ab_maxLevelsPerTile = ;
        this.ab_postLevelTileFreq_Modulo = 429496729604;
        this.ab_unlockLevel = 100;
        decimal val_72 = new System.Decimal(value:  60);
        this.ab_redrawCoinCost = val_72.flags;
        this.bonusGameWheelAwardCoins = new int[4] {25, 50, 75, 100};
        this.bonusGameWheelAwardGoldenCurrency = new int[4] {100, 250, 500, 1000};
        this.starterPackEnabled = true;
        this.starterPackLevel = 24;
        System.TimeSpan val_75 = new System.TimeSpan(hours:  24, minutes:  0, seconds:  0);
        this.starterPackTimeSpan = val_75._ticks;
        System.TimeSpan val_76 = new System.TimeSpan(hours:  24, minutes:  0, seconds:  0);
        this.FOMOPackUnlockedLevel = 75;
        this.starterPackWaterfalDelay = val_76._ticks;
        decimal val_77 = new System.Decimal(value:  244);
        mem2[0] = val_77.flags;
        this.FOMOLevelInterval = 2;
        System.TimeSpan val_78 = new System.TimeSpan(hours:  1, minutes:  0, seconds:  0);
        this.FOMOPackTimeSpan = val_78._ticks;
        mem2[0] = ;
        mem2[0] = ;
        this.spHintConstant = 2.2f;
        mem2[0] = 2.54639494940536E-312;
        mem2[0] = 10995116121;
        this.WIQ_LevelClearIQCompensation_b = ;
        this.WIQ_BaseNewWordPoint = ;
        this.WIQ_LetterPoint = 0.05f;
        this.WIQ_NEWWORDMultiplier = 0.005f;
        this.WIQ_LevelClearIQCompensation_a = 0.034f;
        this.WIQ_BaseClearPoints_min = ;
        this.WIQ_BaseClearPoints_max = ;
        this.WIQ_HighestComplexity = 0.87f;
        this.WIQ_MaxAdditionalClearPoints = 0.025f;
        this.WIQ_Milestones = new float[10] {0f, 7.255643E-41f, 7.542629E-41f, 7.901362E-41f, 8.113518E-43f, 1.157332E-41f, 2.592262E-41f, 4.385924E-41f, 6.287206E-41f, 8.977699E-41f};
        this.categoryUnlockLevel = 150;
        this.categoryShowLevelsDisplay = "100";
        decimal val_80 = new System.Decimal(value:  30);
        mem2[0] = val_80.flags;
        mem2[0] = 2.1219957919534E-314;
        this.categoryCompletionGoalMax = 10;
        mem2[0] = ;
        mem2[0] = ;
        this.libraryButtonDisplayLevel = 6;
        this.categoriesButtonDisplayLevel = 110;
        this.lifetime099SpendLimit = 19.99f;
        this.dbFtuxCr = 50;
        this.hintMeterFreeHints = 1;
        mem2[0] = 6.36598737586021E-314;
        this.newUserTaskUnlock = 3;
        mem2[0] = ;
        decimal val_81;
        this.gm_maxGoldenMultiplier = 100f;
        this.caf_unlockLevel = 5;
        this.caf_frequencyShown = 0;
        val_81 = new System.Decimal(value:  50);
        mem2[0] = val_81.flags;
        this.prize_balloon_econ = new PrizeBalloon.Econ();
        this.knobsConfigjs = new twelvegigs.storage.JsonDictionary();
        this.otherKnobsConfigjs = new twelvegigs.storage.JsonDictionary();
        this.ltb_unlockLevel = 6;
        this.ss_min_offer = 3;
        this.ss_cost_multiplier = 10;
        System.Collections.Generic.List<BonusRewardsContainer> val_85 = new System.Collections.Generic.List<BonusRewardsContainer>();
        val_85.Add(item:  new BonusRewardsContainer(lvl:  0, ptrq:  0, bonusGC:  0, bonusGems:  0, bonusCoins:  0));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  1, ptrq:  200, bonusGC:  10, bonusGems:  5, bonusCoins:  5));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  2, ptrq:  244, bonusGC:  20, bonusGems:  10, bonusCoins:  5));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  3, ptrq:  188, bonusGC:  30, bonusGems:  10, bonusCoins:  10));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  4, ptrq:  176, bonusGC:  40, bonusGems:  15, bonusCoins:  10));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  5, ptrq:  108, bonusGC:  50, bonusGems:  15, bonusCoins:  20));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  6, ptrq:  28, bonusGC:  60, bonusGems:  25, bonusCoins:  25));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  7, ptrq:  136, bonusGC:  70, bonusGems:  30, bonusCoins:  30));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  8, ptrq:  164, bonusGC:  80, bonusGems:  35, bonusCoins:  35));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  9, ptrq:  44, bonusGC:  90, bonusGems:  40, bonusCoins:  40));
        val_85.Add(item:  new BonusRewardsContainer(lvl:  10, ptrq:  208, bonusGC:  100, bonusGems:  50, bonusCoins:  50));
        this._bonusRewardDefaultData = val_85;
    }
    private static GameEcon()
    {
        AppConfigs val_1 = App.Configuration;
        GameEcon.numberFormatDecimal = val_1.econConfig.NumberFormatDecimal;
    }

}
