using UnityEngine;
public class FPHMetaGameBehavior : MetaGameBehavior
{
    // Fields
    private static bool hasShownBenefitsWindowThisSession;
    
    // Properties
    public override System.Collections.Generic.Dictionary<string, System.Type> DefaultEventTypes { get; }
    public override System.Collections.Generic.Dictionary<string, System.Type> EventHandlerTypeLookup { get; }
    public override int PlayerLevel { get; set; }
    public override bool supportsEvents { get; }
    public override bool supportsCategoryLevelPacks { get; }
    public override string NotifImgUrlDailyBonus { get; }
    public override string NotifImgUrlPostAd { get; }
    public override bool supportAdsControlV2 { get; }
    public override bool supportsAdaptiveRewardedVideoReward { get; }
    public override bool supportsMiniSettingsPopupSoundButtons { get; }
    public override bool supportsGOTDPopup { get; }
    public override bool supportsDailyLoginRewardPopup { get; }
    public override bool supportsEmailCollectPopup { get; }
    public override bool supportsWordIQ { get; }
    public override bool supportsRecommendPopup { get; }
    public override bool supportsFBConnect { get; }
    public override bool supportsChallenges { get; }
    public override bool supportsSubscriptions { get; }
    public override bool supportsRecaptureNotifications { get; }
    public override bool supportsLeaguesUnlockingAnimation { get; }
    public override bool supportsLeaguesLowPointJoinLock { get; }
    public override bool supportsPortraitCollection { get; }
    public override bool alwaysForceReviewTracking { get; }
    public override bool supportsLocalization { get; }
    public override bool playMusicInLeaugues { get; }
    public override bool leaguesRewardsCoins { get; }
    public override bool leaguesContributeCostCoins { get; }
    public override bool leaguesMultiplierCostCoins { get; }
    public override bool supportsFBShare { get; }
    public override bool supportsSilverTicketDisplay { get; }
    public override bool canShowGoldenTicketStoreItem { get; }
    public override bool subscriptionGrantsGems { get; }
    public override decimal PlayerInitialCoins { get; }
    public override int PlayerInitialGems { get; }
    public override int RewardedVideoGemReward { get; }
    public override bool PiggyBankUsesGems { get; }
    private int timesShownThisSession { get; set; }
    public override string BannerPlacement { get; }
    
    // Methods
    public override System.Collections.Generic.Dictionary<string, System.Type> get_DefaultEventTypes()
    {
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Type>();
        val_1.Add(key:  "BigQuiz", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "PiggyBank", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        return val_1;
    }
    public override System.Collections.Generic.Dictionary<string, System.Type> get_EventHandlerTypeLookup()
    {
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Type>();
        val_1.Add(key:  "ProgressiveIapSale", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        return val_1;
    }
    public override System.Type getDefinitions<T>()
    {
        return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
    }
    public override int get_PlayerLevel()
    {
        Player val_1 = App.Player;
        goto typeof(Player).__il2cppRuntimeField_170;
    }
    public override void set_PlayerLevel(int value)
    {
        this.PlayerLevel = value;
    }
    public override string GetUrlSharePrefix()
    {
        return "https://{0}/";
    }
    public override SceneType getActiveSceneType()
    {
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string val_2 = val_1.m_Handle.name;
        return (SceneType)this;
    }
    public override bool get_supportsEvents()
    {
        return true;
    }
    public override bool get_supportsCategoryLevelPacks()
    {
        return false;
    }
    public override UnityEngine.GameObject OpenPauseMenu()
    {
        GameBehavior val_1 = App.getBehavior;
        return val_1.<metaGameBehavior>k__BackingField.gameObject;
    }
    public override System.Collections.Generic.List<PurchaseModel> FilterStoreCreditPacksPerGame(System.Collections.Generic.List<PurchaseModel> unfiltered)
    {
        var val_2;
        System.Predicate<PurchaseModel> val_4;
        val_2 = null;
        val_2 = null;
        val_4 = FPHMetaGameBehavior.<>c.<>9__15_0;
        if(val_4 != null)
        {
                return unfiltered.FindAll(match:  System.Predicate<PurchaseModel> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<PurchaseModel>(object:  FPHMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FPHMetaGameBehavior.<>c::<FilterStoreCreditPacksPerGame>b__15_0(PurchaseModel p));
        FPHMetaGameBehavior.<>c.<>9__15_0 = val_4;
        return unfiltered.FindAll(match:  val_1);
    }
    public override string get_NotifImgUrlDailyBonus()
    {
        return "https://12gcontent.s3-us-west-1.amazonaws.com/TRV_RPNS/TRV_PushNotifications_Generic-NoBanner.png";
    }
    public override string get_NotifImgUrlPostAd()
    {
        return "https://12gcontent.s3-us-west-1.amazonaws.com/TRV_RPNS/TRV_PushNotifications_Generic-NoBanner.png";
    }
    public override bool get_supportAdsControlV2()
    {
        return true;
    }
    public override bool get_supportsAdaptiveRewardedVideoReward()
    {
        return false;
    }
    public override bool get_supportsMiniSettingsPopupSoundButtons()
    {
        return false;
    }
    public override bool get_supportsGOTDPopup()
    {
        return false;
    }
    public override bool get_supportsDailyLoginRewardPopup()
    {
        return true;
    }
    public override bool get_supportsEmailCollectPopup()
    {
        return false;
    }
    public override bool get_supportsWordIQ()
    {
        return false;
    }
    public override bool get_supportsRecommendPopup()
    {
        return false;
    }
    public override bool get_supportsFBConnect()
    {
        return false;
    }
    public override bool get_supportsChallenges()
    {
        return false;
    }
    public override bool get_supportsSubscriptions()
    {
        return false;
    }
    public override bool get_supportsRecaptureNotifications()
    {
        return false;
    }
    public override bool get_supportsLeaguesUnlockingAnimation()
    {
        return true;
    }
    public override bool get_supportsLeaguesLowPointJoinLock()
    {
        return true;
    }
    public override bool get_supportsPortraitCollection()
    {
        return true;
    }
    public override bool LTB_V2()
    {
        return false;
    }
    public override bool get_alwaysForceReviewTracking()
    {
        return true;
    }
    public override bool get_supportsLocalization()
    {
        return true;
    }
    public override System.Collections.Generic.List<string> GetSupportedLanguageNames()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "en");
        val_1.Add(item:  "es");
        val_1.Add(item:  "de");
        val_1.Add(item:  "fr");
        return val_1;
    }
    public override bool get_playMusicInLeaugues()
    {
        return false;
    }
    public override bool get_leaguesRewardsCoins()
    {
        return false;
    }
    public override bool get_leaguesContributeCostCoins()
    {
        return false;
    }
    public override bool get_leaguesMultiplierCostCoins()
    {
        return false;
    }
    public override System.Collections.Generic.List<string[]> LeagueHints()
    {
        int val_3;
        System.Collections.Generic.List<System.String[]> val_1 = new System.Collections.Generic.List<System.String[]>();
        string[] val_2 = new string[2];
        val_3 = val_2.Length;
        val_2[0] = "fph_league_loading_hint";
        val_3 = val_2.Length;
        val_2[1] = "Earn stars each level from your remaining tokens!";
        val_1.Add(item:  val_2);
        return val_1;
    }
    public override bool get_supportsFBShare()
    {
        return false;
    }
    public override bool GemsUnlocked()
    {
        return true;
    }
    public override bool AdsAllowedByScene()
    {
        return (bool)(this == 2) ? 1 : 0;
    }
    public override bool get_supportsSilverTicketDisplay()
    {
        return false;
    }
    public override bool get_canShowGoldenTicketStoreItem()
    {
        return false;
    }
    public override UnityEngine.GameObject OnLeaguesEntryButtonClicked()
    {
        FeatureAccessPoints val_12;
        var val_14;
        var val_15;
        var val_16;
        System.Action val_18;
        var val_19;
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_3;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_8;
        }
        
        var val_5 = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (14 + 1) : 14;
        goto label_13;
        label_3:
        val_12 = 13;
        goto label_13;
        label_8:
        val_12 = 14;
        label_13:
        val_14 = null;
        val_14 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = val_12;
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
        {
                return MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  false).gameObject;
        }
        
        val_15 = null;
        val_15 = null;
        val_16 = null;
        val_16 = null;
        val_18 = FPHMetaGameBehavior.<>c.<>9__73_0;
        if(val_18 == null)
        {
                System.Action val_8 = null;
            val_18 = val_8;
            val_8 = new System.Action(object:  FPHMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHMetaGameBehavior.<>c::<OnLeaguesEntryButtonClicked>b__73_0());
            FPHMetaGameBehavior.<>c.<>9__73_0 = val_18;
        }
        
        val_19 = null;
        val_12 = System.Delegate.Combine(a:  SLC.Social.Leagues.LeaguesUIManager.DoOnStart, b:  val_8);
        val_19 = null;
        if(val_12 != null)
        {
                if(null != null)
        {
            goto label_33;
        }
        
        }
        
        SLC.Social.Leagues.LeaguesUIManager.DoOnStart = val_12;
        return MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  false).gameObject;
        label_33:
    }
    public override string LeaguesBenefitsDescription()
    {
        return System.String.Format(format:  "Collect Stars to raise your{0}club\'s seasonal rank.", arg0:  System.Environment.NewLine);
    }
    public override bool CanShowLeaguesJoinLeagueButton(SLC.Social.Leagues.Guild CurrentGuild)
    {
        return (bool)(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == 0) ? 1 : 0;
    }
    public override string GetGoldenAppleNameForGame()
    {
        return "Stars";
    }
    public override string GetGoldenAppleNameForGameUpper()
    {
        return "STARS";
    }
    public override string GetSpecialCurrencyLocalizationKey()
    {
        return "stars_meta";
    }
    public override System.Collections.Generic.Dictionary<string, object> FilterSubscriptionDictionary(System.Collections.Generic.Dictionary<string, object> dic)
    {
        if(((dic.ContainsKey(key:  "id")) != false) && ((System.String.op_Equality(a:  dic.Item["id"], b:  "id_golden_ticket_subscription")) != false))
        {
                if((dic.ContainsKey(key:  "sale_price")) != false)
        {
                dic.set_Item(key:  "sale_price", value:  16.99f);
        }
        
            EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  dic, key:  "initial", newValue:  0.99f);
        }
        
        if((dic.ContainsKey(key:  "id")) == false)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)dic;
        }
        
        if((System.String.op_Equality(a:  dic.Item["id"], b:  "id_silver_ticket_subscription")) == false)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)dic;
        }
        
        "id" = "sale_price";
        if((dic.ContainsKey(key:  "sale_price")) != false)
        {
                dic.set_Item(key:  "sale_price", value:  3.99f);
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  dic, key:  "initial", newValue:  0f);
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)dic;
    }
    public override void DoStoreCloseVideoLogic(bool purchased, bool ooc)
    {
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_33;
        var val_35;
        var val_37;
        MetaGameBehavior val_38;
        var val_39;
        var val_41;
        var val_43;
        var val_44;
        var val_45;
        val_28 = ooc;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_12;
        }
        
        Player val_2 = App.Player;
        FPHEcon val_3 = App.GetGameSpecificEcon<FPHEcon>();
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3.levelEntryFee);
        val_29 = 0;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) == false)
        {
            goto label_12;
        }
        
        val_30 = 1152921504891564032;
        val_31 = MonoSingleton<AdsUIController>.Instance;
        goto label_85;
        label_12:
        GameBehavior val_7 = App.getBehavior;
        if(((val_7.<metaGameBehavior>k__BackingField) != 2) || (FPHGameplayController.Instance == 0))
        {
            goto label_43;
        }
        
        FPHGameplayController val_10 = FPHGameplayController.Instance;
        if(val_10.currentGame == null)
        {
            goto label_43;
        }
        
        FPHGameplayController val_11 = FPHGameplayController.Instance;
        if(val_11.currentGame.hasCollectedChest == false)
        {
            goto label_43;
        }
        
        Player val_12 = App.Player;
        FPHEcon val_13 = App.GetGameSpecificEcon<FPHEcon>();
        decimal val_14 = System.Decimal.op_Implicit(value:  val_13.levelEntryFee);
        val_29 = 0;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_12._credits, hi = val_12._credits, lo = 1152921504901894144}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid})) == false)
        {
            goto label_43;
        }
        
        val_31 = MonoSingleton<AdsUIController>.Instance;
        val_33 = null;
        val_33 = null;
        val_35 = 1;
        goto label_52;
        label_43:
        GameBehavior val_17 = App.getBehavior;
        val_30 = 1152921504891564032;
        if((val_17.<metaGameBehavior>k__BackingField) != 4)
        {
            goto label_57;
        }
        
        val_37 = null;
        val_37 = null;
        if(PurchaseProxy.currentPurchasePoint != 124)
        {
            goto label_63;
        }
        
        GameBehavior val_18 = App.getBehavior;
        val_38 = val_18.<metaGameBehavior>k__BackingField;
        val_39 = val_38;
        val_41 = "OOG";
        goto label_81;
        label_57:
        val_43 = null;
        val_43 = null;
        if(PurchaseProxy.currentPurchasePoint != 126)
        {
            goto label_75;
        }
        
        GameBehavior val_20 = App.getBehavior;
        val_38 = val_20.<metaGameBehavior>k__BackingField;
        val_39 = val_38;
        val_41 = "OOG";
        goto label_81;
        label_63:
        val_31 = MonoSingleton<AdsUIController>.Instance;
        label_85:
        val_44 = null;
        val_35 = 0;
        label_52:
        val_31.TryShowPromptVideo(entryPoint:  PurchaseProxy.__il2cppRuntimeField_static_fields, showAsFlyout:  false);
        return;
        label_75:
        val_45 = null;
        val_45 = null;
        val_39 = null;
        if(PurchaseProxy.currentPurchasePoint != 127)
        {
            goto label_95;
        }
        
        GameBehavior val_23 = App.getBehavior;
        val_38 = val_23.<metaGameBehavior>k__BackingField;
        val_39 = val_38;
        val_41 = "OOG";
        label_81:
        label_106:
        val_28 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
        label_95:
        GameBehavior val_25 = App.getBehavior;
        var val_27 = (val_28 != 1) ? 5 : 35;
        goto label_106;
    }
    public override bool get_subscriptionGrantsGems()
    {
        return true;
    }
    public override decimal get_PlayerInitialCoins()
    {
        FPHEcon val_2 = (App.GetGameSpecificEcon<FPHEcon>()) + 1452;
        return new System.Decimal() {flags = val_1.startingCoins.flags, hi = val_1.startingCoins.flags, lo = 294834176, mid = 268435456};
    }
    public override int get_PlayerInitialGems()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.startingGems;
    }
    public override int get_RewardedVideoGemReward()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        return (int)val_1.rewardedVideoGemReward;
    }
    public override void OnClickHome()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                FPHGameplayController val_2 = FPHGameplayController.Instance;
            FPHGameplayController val_3 = FPHGameplayController.Instance;
            GameBehavior val_4 = App.getBehavior;
            WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
            val_5.music.FadeOutMusic();
            return;
        }
        
        this.OnClickHome();
    }
    public override bool get_PiggyBankUsesGems()
    {
        return true;
    }
    public override bool CanAccessLimitedTimeBundles()
    {
        return false;
    }
    private int get_timesShownThisSession()
    {
        return CPlayerPrefs.GetInt(key:  "ltbtotal", defaultValue:  0);
    }
    private void set_timesShownThisSession(int value)
    {
        CPlayerPrefs.SetInt(key:  "ltbtotal", val:  value);
        CPlayerPrefs.Save();
    }
    public override void AppendPurchaseTracking(ref System.Collections.Generic.Dictionary<string, object> tracking, PurchaseModel pm)
    {
        UnityEngine.Object val_9;
        int val_10;
        var val_11;
        var val_12;
        FPHQotdStatus val_13;
        val_9 = pm;
        Player val_1 = App.Player;
        tracking.Add(key:  "Current Gems", value:  val_1._gems);
        Player val_2 = App.Player;
        tracking.Add(key:  "Current Stars", value:  val_2._stars);
        decimal val_3 = val_9.GoldenCurrency;
        val_10 = val_3.lo;
        val_11 = null;
        val_11 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_10, mid = val_3.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_5 = val_9.GoldenCurrency;
            tracking.Add(key:  "Star Amount", value:  val_5);
        }
        
        if(this != 2)
        {
            goto label_20;
        }
        
        val_9 = 1152921504901894144;
        val_12 = null;
        val_12 = null;
        if(FPHGameplayController.currentGameplayMode != 1)
        {
            goto label_20;
        }
        
        val_10 = 1152921515980489520;
        val_9 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        if(val_9 == 0)
        {
            goto label_20;
        }
        
        FPHPhraseOfTheDayController val_8 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        val_13 = val_8.<Status>k__BackingField;
        if(val_13 == null)
        {
            goto label_25;
        }
        
        val_13 = val_8.<Status>k__BackingField.IsPlaying;
        goto label_25;
        label_20:
        val_13 = false;
        label_25:
        tracking.Add(key:  "Daily Phrases", value:  val_13);
    }
    public override void SetToCreditsStatViewPos(UnityEngine.RectTransform rectTransform)
    {
        MonoExtensions.SetUIAnchor(rect:  rectTransform, anchor:  1);
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  267.75f, y:  -67f);
        rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public override void SetToGemsStatViewPos(UnityEngine.RectTransform rectTransform)
    {
        MonoExtensions.SetUIAnchor(rect:  rectTransform, anchor:  1);
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  593.5f, y:  -67f);
        rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public override void SetToGoldenStatViewPos(UnityEngine.RectTransform rectTransform)
    {
        MonoExtensions.SetUIAnchor(rect:  rectTransform, anchor:  1);
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  924.25f, y:  -67f);
        rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public override void AppendUserProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> userProperties)
    {
        userProperties.Add(key:  "Correct Answer Percentage", value:  FPHPlayer.Instance.SuccessPercentageStandardModeString);
    }
    public override bool ArePopupsAllowedForSceneType(SceneType type)
    {
        var val_2;
        var val_3;
        val_2 = type;
        if(val_2 == 2)
        {
                val_2 = 1152921504901894144;
            val_3 = null;
            val_3 = null;
            return (bool)(val_2 == 1) ? 1 : 0;
        }
        
        return (bool)(val_2 == 1) ? 1 : 0;
    }
    public override string GetLevelForTracking()
    {
        if(FPHGameplayController.Instance == 0)
        {
                Player val_3 = App.Player;
            return (string)val_4.currentGame.trackingLevel.ToString();
        }
        
        FPHGameplayController val_4 = FPHGameplayController.Instance;
        return (string)val_4.currentGame.trackingLevel.ToString();
    }
    public override void ShowAdditionalSceneChangePopups(SceneType scene)
    {
        MetaGameBehavior val_12;
        var val_13;
        var val_14;
        val_12 = scene;
        if((MonoSingleton<FPHPhraseOfTheDayController>.Instance) != 0)
        {
                MonoSingleton<FPHPhraseOfTheDayController>.Instance.CheckLPN();
        }
        
        if(val_12 != 1)
        {
                return;
        }
        
        val_13 = null;
        val_13 = null;
        if(FPHMetaGameBehavior.hasShownBenefitsWindowThisSession == true)
        {
                return;
        }
        
        val_12 = 1152921505022660608;
        if(SLC.Social.Leagues.LeaguesManager.IsAvailable() == false)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
        {
                return;
        }
        
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyProfile.hasJoinedClub == true)
        {
                return;
        }
        
        GameBehavior val_10 = App.getBehavior;
        val_12 = val_10.<metaGameBehavior>k__BackingField;
        val_14 = null;
        val_14 = null;
        FPHMetaGameBehavior.hasShownBenefitsWindowThisSession = true;
    }
    public override void TrackAdditionalNonCoinAwardParams(System.Collections.Generic.Dictionary<string, object> data)
    {
    
    }
    public override string get_BannerPlacement()
    {
        return "TOP";
    }
    public FPHMetaGameBehavior()
    {
    
    }
    private static FPHMetaGameBehavior()
    {
    
    }

}
