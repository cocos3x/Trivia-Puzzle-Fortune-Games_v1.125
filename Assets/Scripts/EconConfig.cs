using UnityEngine;
public class EconConfig : ScriptableObject
{
    // Fields
    public int NonPurchaserVideoAdRewardCoins;
    public int OneTimePurchaserVideoAdRewardCoins;
    public int RepeatPurchaserVideoAdRewardCoins;
    public int VideoAdPlayerLevel;
    public int AdsControlPopup;
    public float DefaultNoAdsPackagePrice;
    public string NumberFormat;
    public string NumberFormatDecimal;
    public int DefaultPlayerCoins;
    public int HintCost;
    public int HintPickerCost;
    public int MegaHintCost;
    public int EmailPromptUnlockLevel;
    public int EmailPromptFrequency;
    public int ReviewPromptUnlockLevel;
    public int HintTutorialLevel;
    public int HintTutorialLevelV2;
    public int PickerHintTutorialLevel;
    public int PickerHintTutorialLevelV2;
    public int MegaHintTutorialLevel;
    public int ExtraReqIncrement;
    public int MaxExtraReqLevelsPerChapter;
    public int HintsPerChapterNonBuyer;
    public int HintsPerChapterOneTimeBuyer;
    public int HintsPerChapterRepeatBuyer;
    public int ExtraRequiredQuantityPerLevel;
    public int ExtraRequiredPostPurchaseLevel;
    public int TimerHours;
    public System.Collections.Generic.Dictionary<int, DailyBonusTier> DailyBonusCoinRewardTiers;
    public System.Collections.Generic.List<int> DailyBonusVideoRewards;
    public int FreeHintDailyBonusLevel;
    protected System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> giftRewardTypeChances;
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>> GiftRewardCoinRewardTiers;
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardCoinAmountChances;
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardFoodAmountChances;
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardDiceRollAmountChances;
    public System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> GiftRewardGoldenCurrencyAmountChances;
    public int WordCoinBonus;
    public int ChapterCompleteBonus;
    public int RateBonus;
    public int FacebookConnectBonus;
    public int VideoAdRewardCoins;
    public int VideoAdRewardBonusCollectCoins;
    public int EmailWelcome;
    public int EmailThankYou;
    public int RPNMonthly;
    public int RPNHoliday;
    public int IncentivizedEmailPrompt;
    public int InitalExtraWordsReq;
    public int ExtraWordsReqInc;
    public int MaxExtraWordsReq;
    public int RewardCoins;
    public int AdsControlButtonMaxLevel;
    public int NoAdsStartCoinAmount;
    public int AdsControlUnlockLevel;
    public bool WGWaterfall;
    public int WGWaterfallIntervalDays;
    public int WaterfallDisplayMinutes;
    public int WaterfallLevel;
    public bool AdvancedPlayerEnabled;
    public int AdvancedPlayerPopupDisplay;
    public int AdvancedPlayerLevelToSkip;
    public int DiscountSizePercent;
    public int DiscountChapterMinutes;
    public int DiscountChapterFrequency;
    public int DiscountDailyBonusMinutes;
    
    // Properties
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> GiftRewardTypeChances { get; }
    
    // Methods
    public virtual System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> get_GiftRewardTypeChances()
    {
        return (System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>>)this.giftRewardTypeChances;
    }
    public EconConfig()
    {
        var val_9;
        this.AdsControlPopup = 27;
        this.DefaultNoAdsPackagePrice = 6.244746E-41f;
        this.NonPurchaserVideoAdRewardCoins = ;
        this.OneTimePurchaserVideoAdRewardCoins = ;
        this.RepeatPurchaserVideoAdRewardCoins = 94489280537;
        this.VideoAdPlayerLevel = 22;
        this.NumberFormat = "#,##0";
        this.DefaultPlayerCoins = ;
        this.HintCost = ;
        this.HintPickerCost = 2791728742640;
        this.MegaHintCost = 650;
        this.EmailPromptUnlockLevel = ;
        this.EmailPromptFrequency = ;
        this.ReviewPromptUnlockLevel = 85899345953;
        this.HintTutorialLevel = 20;
        this.HintTutorialLevelV2 = ;
        this.PickerHintTutorialLevel = ;
        this.PickerHintTutorialLevelV2 = 180388626452;
        this.MegaHintTutorialLevel = 42;
        this.ExtraReqIncrement = ;
        this.MaxExtraReqLevelsPerChapter = ;
        this.HintsPerChapterNonBuyer = 21474836481;
        this.HintsPerChapterOneTimeBuyer = 5;
        this.HintsPerChapterRepeatBuyer = ;
        this.ExtraRequiredQuantityPerLevel = ;
        this.ExtraRequiredPostPurchaseLevel = 103079215225;
        this.TimerHours = 24;
        this.NumberFormatDecimal = "#,##0.00";
        this.DailyBonusCoinRewardTiers = new System.Collections.Generic.Dictionary<System.Int32, DailyBonusTier>();
        this.DailyBonusVideoRewards = new System.Collections.Generic.List<System.Int32>();
        this.FreeHintDailyBonusLevel = 13;
        System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>> val_3 = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTypeChance>>();
        val_3.Add(key:  0, value:  GiftRewardData.DailyBonusRewardTypeChances);
        val_3.Add(key:  2, value:  GiftRewardData.DailyBonusRewardTypeChances);
        val_3.Add(key:  1, value:  GiftRewardData.DailyBonusPickAnotherRewardChances);
        val_3.Add(key:  3, value:  GiftRewardData.ChapterRewardTypeChances);
        val_3.Add(key:  4, value:  GiftRewardData.DailyBonusRewardTypeChances);
        val_3.Add(key:  10, value:  GiftRewardData.DailyChallengeWeeklyRewardChances);
        val_3.Add(key:  11, value:  GiftRewardData.DailyChallengeMonthlyRewardChances);
        val_9 = null;
        val_9 = null;
        if((SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3.Add(key:  5, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 16 + 32);
        if((SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3.Add(key:  6, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 16 + 40);
        if((SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3.Add(key:  7, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 16 + 48);
        if((SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 24) <= 3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3.Add(key:  8, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 16 + 56);
        if((SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 24) <= 4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3.Add(key:  9, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardTypeChances + 16 + 64);
        this.giftRewardTypeChances = val_3;
        System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>> val_4 = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardTier>>();
        val_4.Add(key:  0, value:  GiftRewardData.DailyBonusCoinRewardTiersV2);
        val_4.Add(key:  2, value:  GiftRewardData.DailyBonusCoinRewardTiersV2);
        val_4.Add(key:  1, value:  GiftRewardData.DailyBonusCoinRewardTiersV2);
        val_4.Add(key:  3, value:  GiftRewardData.ChapterRewardCoinRewardTiers);
        val_4.Add(key:  10, value:  GiftRewardData.DailyChallengeCoinRewardTiers);
        val_4.Add(key:  11, value:  GiftRewardData.DailyChallengeCoinRewardTiers);
        val_4.Add(key:  5, value:  SnakesAndLaddersEvent.Econ.BoardGiftCoinRewardTiers);
        val_4.Add(key:  6, value:  SnakesAndLaddersEvent.Econ.BoardGiftCoinRewardTiers);
        val_4.Add(key:  7, value:  SnakesAndLaddersEvent.Econ.BoardGiftCoinRewardTiers);
        val_4.Add(key:  8, value:  SnakesAndLaddersEvent.Econ.BoardGiftCoinRewardTiers);
        val_4.Add(key:  9, value:  SnakesAndLaddersEvent.Econ.BoardGiftCoinRewardTiers);
        this.GiftRewardCoinRewardTiers = val_4;
        this.GiftRewardCoinAmountChances = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>();
        System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> val_6 = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>();
        val_6.Add(key:  0, value:  GiftRewardData.DailyBonusFoodAmountChances);
        val_6.Add(key:  2, value:  GiftRewardData.DailyBonusFoodAmountChances);
        val_6.Add(key:  1, value:  GiftRewardData.DailyBonusFoodAmountChances);
        val_6.Add(key:  3, value:  GiftRewardData.ChapterRewardFoodAmountChances);
        val_6.Add(key:  10, value:  GiftRewardData.DailyChallengeRewardFoodAmountChances);
        val_6.Add(key:  11, value:  GiftRewardData.DailyChallengeRewardFoodAmountChances);
        val_6.Add(key:  5, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardFoodAmountChances);
        val_6.Add(key:  6, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardFoodAmountChances);
        val_6.Add(key:  7, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardFoodAmountChances);
        val_6.Add(key:  8, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardFoodAmountChances);
        val_6.Add(key:  9, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardFoodAmountChances);
        this.GiftRewardFoodAmountChances = val_6;
        System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>> val_7 = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>();
        val_7.Add(key:  0, value:  SnakesAndLaddersEvent.Econ.DailyBonusDiceRollAmountChances);
        val_7.Add(key:  2, value:  SnakesAndLaddersEvent.Econ.DailyBonusDiceRollAmountChances);
        val_7.Add(key:  1, value:  SnakesAndLaddersEvent.Econ.DailyBonusDiceRollAmountChances);
        val_7.Add(key:  5, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardDiceRollAmountChances);
        val_7.Add(key:  6, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardDiceRollAmountChances);
        val_7.Add(key:  7, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardDiceRollAmountChances);
        val_7.Add(key:  8, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardDiceRollAmountChances);
        val_7.Add(key:  9, value:  SnakesAndLaddersEvent.Econ.BoardGiftRewardDiceRollAmountChances);
        this.GiftRewardDiceRollAmountChances = val_7;
        this.WordCoinBonus = ;
        this.ChapterCompleteBonus = ;
        this.RateBonus = 2147483648250;
        this.FacebookConnectBonus = 500;
        this.VideoAdRewardCoins = ;
        this.VideoAdRewardBonusCollectCoins = ;
        this.EmailWelcome = 1932735283440;
        this.EmailThankYou = 450;
        this.RPNMonthly = ;
        this.RPNHoliday = ;
        this.IncentivizedEmailPrompt = 42949673110;
        this.InitalExtraWordsReq = 10;
        this.GiftRewardGoldenCurrencyAmountChances = new System.Collections.Generic.Dictionary<GiftRewardSource, System.Collections.Generic.List<GiftRewardAmountChance>>();
        this.RewardCoins = ;
        this.AdsControlButtonMaxLevel = ;
        this.NoAdsStartCoinAmount = 111669150096;
        this.AdsControlUnlockLevel = 26;
        this.WGWaterfall = true;
        this.ExtraWordsReqInc = 2;
        this.MaxExtraWordsReq = 100;
        mem2[0] = 2.12199579131112E-313;
        this.WaterfallLevel = 21;
        mem2[0] = ;
        mem2[0] = 5;
    }

}
