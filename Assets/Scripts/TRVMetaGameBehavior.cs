using UnityEngine;
public class TRVMetaGameBehavior : MetaGameBehavior
{
    // Properties
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
    public override bool supportsBonusRewards { get; }
    public override bool supportsTournaments { get; }
    public override bool playMusicInLeaugues { get; }
    public override bool leaguesRewardsCoins { get; }
    public override bool supportsFBShare { get; }
    public override bool supportsSilverTicketDisplay { get; }
    public override bool canShowGoldenTicketStoreItem { get; }
    public override decimal FOMOCurrency { get; }
    public override string FOMOCurrencyType { get; }
    public override bool subscriptionGrantsGems { get; }
    public override decimal PlayerInitialCoins { get; }
    public override int PlayerInitialGems { get; }
    public override int RewardedVideoGemReward { get; }
    public override bool PiggyBankUsesGems { get; }
    private int timesShownThisSession { get; set; }
    public override float WindowManagerBackgroundAlpha { get; }
    public override bool CanShowUnPauseInterstitial { get; }
    public override bool canShowGameSceneEventUpdates { get; }
    public override bool supportsLocalization { get; }
    
    // Methods
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
        return (SceneType)this.GetSceneTypeFromSceneName(sceneName:  val_1.m_Handle.name);
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
        val_4 = TRVMetaGameBehavior.<>c.<>9__11_0;
        if(val_4 != null)
        {
                return unfiltered.FindAll(match:  System.Predicate<PurchaseModel> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<PurchaseModel>(object:  TRVMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVMetaGameBehavior.<>c::<FilterStoreCreditPacksPerGame>b__11_0(PurchaseModel p));
        TRVMetaGameBehavior.<>c.<>9__11_0 = val_4;
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
        return true;
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
    public override bool get_supportsBonusRewards()
    {
        return true;
    }
    public override bool get_supportsTournaments()
    {
        return true;
    }
    public override bool get_playMusicInLeaugues()
    {
        return false;
    }
    public override bool get_leaguesRewardsCoins()
    {
        return false;
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
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == false)
        {
                return this.canShowGoldenTicketStoreItem;
        }
        
        return false;
    }
    public override decimal get_FOMOCurrency()
    {
        Player val_1 = App.Player;
        return System.Decimal.op_Implicit(value:  val_1._gems);
    }
    public override string get_FOMOCurrencyType()
    {
        return "gems";
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
        val_18 = TRVMetaGameBehavior.<>c.<>9__64_0;
        if(val_18 == null)
        {
                System.Action val_8 = null;
            val_18 = val_8;
            val_8 = new System.Action(object:  TRVMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVMetaGameBehavior.<>c::<OnLeaguesEntryButtonClicked>b__64_0());
            TRVMetaGameBehavior.<>c.<>9__64_0 = val_18;
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
    public override System.Collections.Generic.List<string[]> LeagueHints()
    {
        int val_3;
        System.Collections.Generic.List<System.String[]> val_1 = new System.Collections.Generic.List<System.String[]>();
        string[] val_2 = new string[2];
        val_3 = val_2.Length;
        val_2[0] = "trv_league_loading_hint";
        val_3 = val_2.Length;
        val_2[1] = "Earn League Points by answering questions correctly!";
        val_1.Add(item:  val_2);
        return val_1;
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
        decimal val_43;
        var val_44;
        var val_45;
        var val_46;
        var val_47;
        var val_48;
        var val_49;
        int val_50;
        var val_51;
        var val_52;
        var val_53;
        MetaGameBehavior val_54;
        var val_56;
        var val_57;
        var val_58;
        var val_59;
        val_44 = ooc;
        val_46 = null;
        val_46 = null;
        if(PurchaseProxy.currentPurchasePoint != 1)
        {
                val_47 = null;
            val_47 = null;
            if(PurchaseProxy.currentPurchasePoint != 86)
        {
                val_48 = null;
            val_48 = null;
            if(PurchaseProxy.currentPurchasePoint == 87)
        {
            
        }
        else
        {
                val_49 = null;
            val_49 = null;
            var val_1 = (PurchaseProxy.currentPurchasePoint == 2) ? 1 : 0;
        }
        
        }
        
        }
        
        bool val_2 = purchased | val_44;
        if((PurchaseProxy.currentPurchasePoint != 2) && ((FOMOPackEventHandler.<Instance>k__BackingField) != null))
        {
                bool val_3 = FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  false);
        }
        
        GameBehavior val_4 = App.getBehavior;
        if((val_4.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_32;
        }
        
        Player val_5 = App.Player;
        val_43 = val_5._credits;
        val_50 = App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost;
        decimal val_8 = System.Decimal.op_Implicit(value:  val_50);
        val_51 = 0;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_43, hi = val_43, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid})) == true)
        {
            goto label_65;
        }
        
        label_32:
        GameBehavior val_10 = App.getBehavior;
        if((val_10.<metaGameBehavior>k__BackingField) != 2)
        {
            goto label_58;
        }
        
        val_50 = 1152921515943153616;
        val_43 = MonoSingleton<TRVMainController>.Instance;
        if(val_43 == 0)
        {
            goto label_58;
        }
        
        TRVMainController val_13 = MonoSingleton<TRVMainController>.Instance;
        if(val_13.currentGame == null)
        {
            goto label_58;
        }
        
        TRVMainController val_14 = MonoSingleton<TRVMainController>.Instance;
        if(val_14.currentGame.quizCompleted == false)
        {
            goto label_58;
        }
        
        Player val_15 = App.Player;
        val_43 = val_15._credits;
        val_50 = App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost;
        decimal val_18 = System.Decimal.op_Implicit(value:  val_50);
        val_51 = 0;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_43, hi = val_43, lo = 1152921504893161472}, d2:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid})) == true)
        {
            goto label_65;
        }
        
        label_58:
        GameBehavior val_20 = App.getBehavior;
        if((val_20.<metaGameBehavior>k__BackingField) != 4)
        {
            goto label_70;
        }
        
        label_65:
        val_52 = null;
        val_52 = null;
        MonoSingleton<AdsUIController>.Instance.TryShowPromptVideo(entryPoint:  PurchaseProxy.currentPurchasePoint, showAsFlyout:  false);
        return;
        label_70:
        val_53 = null;
        val_53 = null;
        if(PurchaseProxy.currentPurchasePoint != 114)
        {
            goto label_84;
        }
        
        if((MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed) == false)
        {
                return;
        }
        
        GameBehavior val_24 = App.getBehavior;
        val_54 = val_24.<metaGameBehavior>k__BackingField;
        val_56 = "OOC";
        goto label_94;
        label_84:
        val_57 = null;
        val_57 = null;
        if(PurchaseProxy.currentPurchasePoint != 98)
        {
            goto label_100;
        }
        
        val_43 = 32;
        if(purchased == true)
        {
            goto label_128;
        }
        
        label_127:
        if((val_44 != false) && ((FOMOPackEventHandler.<Instance>k__BackingField) != null))
        {
                bool val_26 = FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  false);
        }
        
        label_128:
        if((MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed) == false)
        {
                return;
        }
        
        GameBehavior val_29 = App.getBehavior;
        val_54 = val_29.<metaGameBehavior>k__BackingField;
        val_56 = "OOG";
        label_94:
        val_44 = ???;
        val_43 = ???;
        val_50 = ???;
        val_45 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
        label_100:
        val_58 = null;
        val_58 = null;
        if(PurchaseProxy.currentPurchasePoint != 99)
        {
            goto label_119;
        }
        
        if(purchased == false)
        {
            goto label_127;
        }
        
        goto label_128;
        label_119:
        val_59 = null;
        val_59 = null;
        var val_42 = (PurchaseProxy.currentPurchasePoint == 104) ? 37 : (((val_44 & true) != 0) ? (34 + 1) : 34);
        if(purchased == false)
        {
            goto label_127;
        }
        
        goto label_128;
    }
    public override bool get_subscriptionGrantsGems()
    {
        return true;
    }
    public override decimal get_PlayerInitialCoins()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return new System.Decimal() {flags = val_1.startingCoins, hi = val_1.startingCoins};
    }
    public override int get_PlayerInitialGems()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.startingGems;
    }
    public override int get_RewardedVideoGemReward()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.rewardedVideoGemReward;
    }
    public override void OnClickHome()
    {
        int val_14;
        var val_15;
        System.Func<System.Boolean> val_17;
        var val_18;
        System.Func<System.Boolean> val_20;
        var val_21;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) == 1) || ((MonoSingleton<TRVMainController>.Instance.IsPlayingChallenge) == false))
        {
            goto label_9;
        }
        
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        val_5[1] = true;
        string[] val_6 = new string[2];
        val_14 = val_6.Length;
        val_6[0] = "HOME";
        val_14 = val_6.Length;
        val_6[1] = "CANCEL";
        System.Func<System.Boolean>[] val_7 = new System.Func<System.Boolean>[2];
        val_15 = null;
        val_15 = null;
        val_17 = TRVMetaGameBehavior.<>c.<>9__79_0;
        if(val_17 == null)
        {
                System.Func<System.Boolean> val_8 = null;
            val_17 = val_8;
            val_8 = new System.Func<System.Boolean>(object:  TRVMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVMetaGameBehavior.<>c::<OnClickHome>b__79_0());
            TRVMetaGameBehavior.<>c.<>9__79_0 = val_17;
        }
        
        val_7[0] = val_17;
        val_18 = null;
        val_18 = null;
        val_20 = TRVMetaGameBehavior.<>c.<>9__79_1;
        if(val_20 != null)
        {
            goto label_31;
        }
        
        System.Func<System.Boolean> val_9 = null;
        val_20 = val_9;
        val_9 = new System.Func<System.Boolean>(object:  TRVMetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVMetaGameBehavior.<>c::<OnClickHome>b__79_1());
        TRVMetaGameBehavior.<>c.<>9__79_1 = val_20;
        if(val_20 == null)
        {
            goto label_34;
        }
        
        label_31:
        label_34:
        val_7[1] = val_20;
        val_21 = null;
        val_21 = null;
        this.SetupMessage(titleTxt:  "Are You Sure?", messageTxt:  "Returning home will abandon the challenge.", shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_7, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        return;
        label_9:
        GameBehavior val_10 = App.getBehavior;
        if((val_10.<metaGameBehavior>k__BackingField) == 2)
        {
                if((MonoSingleton<TRVMainController>.Instance) != 0)
        {
                MonoSingleton<TRVMainController>.Instance.AbortQuiz();
        }
        
        }
        
        this.OnClickHome();
    }
    public override bool get_PiggyBankUsesGems()
    {
        return true;
    }
    public override bool CanAccessLimitedTimeBundles()
    {
        return true;
    }
    public override bool LTB_V2()
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
    public override bool ShouldShowLTBPopup(int levelSincePopup, int Interval)
    {
        UnityEngine.Object val_18;
        var val_19;
        var val_20;
        TRVQuizProgress val_21;
        var val_22;
        var val_23;
        val_18 = this;
        if((App.Player <= (public static TRVEcon App::GetGameSpecificEcon<TRVEcon>())) || ((App.GetGameSpecificEcon<TRVEcon>().timesShownThisSession) > 7))
        {
            goto label_14;
        }
        
        val_19 = 1152921504893161472;
        if((MonoSingleton<LimitedTimeBundlesManager>.Instance) == 0)
        {
            goto label_14;
        }
        
        val_20 = null;
        val_20 = null;
        if(LimitedTimeBundlesManager.BundleLocKeys == null)
        {
            goto label_14;
        }
        
        val_19 = LimitedTimeBundlesManager.BundlePackagesKeys;
        if(null == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_8 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetCurrentCountOfBundlePurchase(bundleId:  LimitedTimeBundlesManager.__il2cppRuntimeField_byval_arg);
        if((val_8 != 0) || (val_18 != 2))
        {
            goto label_37;
        }
        
        val_18 = App.Player;
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_18 != 1152921517052171201)
        {
            goto label_37;
        }
        
        val_19 = 1152921504893161472;
        val_18 = MonoSingleton<TRVMainController>.Instance;
        if(val_18 == 0)
        {
            goto label_37;
        }
        
        TRVMainController val_13 = MonoSingleton<TRVMainController>.Instance;
        if(val_13.currentGame == null)
        {
            goto label_37;
        }
        
        TRVMainController val_14 = MonoSingleton<TRVMainController>.Instance;
        val_21 = val_14.currentGame;
        if(val_21.successfullyCompletedQuiz == true)
        {
            goto label_42;
        }
        
        label_37:
        val_22 = 0;
        if(levelSincePopup < Interval)
        {
                return (bool)val_23;
        }
        
        if(val_8 != 0)
        {
                return (bool)val_23;
        }
        
        label_42:
        int val_16 = this.timesShownThisSession;
        val_16.timesShownThisSession = val_16 + 1;
        val_23 = 1;
        return (bool)val_23;
        label_14:
        val_23 = 0;
        return (bool)val_23;
    }
    public override void AppendPurchaseTracking(ref System.Collections.Generic.Dictionary<string, object> tracking, PurchaseModel pm)
    {
        bool val_11;
        var val_12;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance) != 0)
        {
                val_11 = MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying();
        }
        else
        {
                val_11 = false;
        }
        
        tracking.Add(key:  "Question of the Day", value:  val_11);
        Player val_5 = App.Player;
        tracking.Add(key:  "Current Gems", value:  val_5._gems);
        Player val_6 = App.Player;
        tracking.Add(key:  "Current Stars", value:  val_6._stars);
        decimal val_7 = pm.GoldenCurrency;
        val_12 = null;
        val_12 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
                return;
        }
        
        decimal val_9 = pm.GoldenCurrency;
        tracking.Add(key:  "Star Amount", value:  val_9);
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
    public override void ShowDailyBonusPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyBonusPopup>(showNext:  true);
    }
    public override void AppendUserProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> userProperties)
    {
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_11;
        var val_12;
        object val_13;
        var val_14;
        if((MonoSingleton<TRVExpertsController>.Instance) != 0)
        {
                TRVExpertsController val_3 = MonoSingleton<TRVExpertsController>.Instance;
            if(val_3.myExperts != null)
        {
                TRVExpertsController val_4 = MonoSingleton<TRVExpertsController>.Instance;
            val_11 = val_4.myExperts;
            int val_5 = val_11.Count;
        }
        else
        {
                val_11 = 0;
        }
        
            userProperties.Add(key:  "Lifetime Experts Unlocked ", value:  val_11);
        }
        
        if((DefaultHandler<WGBonusRewardsHandler>.Instance) != 0)
        {
                BonusRewardsContainer val_9 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetCurrentRewards();
            userProperties.Add(key:  "Bonus Level", value:  val_9.<level>k__BackingField);
        }
        
        val_12 = null;
        val_12 = null;
        if((System.String.IsNullOrEmpty(value:  AdjustPlugin.<Attribution_adgroup>k__BackingField)) == false)
        {
            goto label_31;
        }
        
        val_13 = "none";
        if(userProperties != null)
        {
            goto label_32;
        }
        
        label_31:
        val_14 = null;
        val_14 = null;
        val_13 = 1152921504887414808;
        label_32:
        userProperties.Add(key:  "Adjust Adset Name", value:  val_13);
    }
    public override bool ArePopupsAllowedForSceneType(SceneType type)
    {
        return (bool)(type == 1) ? 1 : 0;
    }
    public override string GetSpecialCurrencyLocalizationKey()
    {
        return "stars_meta";
    }
    public override void OnLevelAwarded()
    {
    
    }
    public override float get_WindowManagerBackgroundAlpha()
    {
        return 0.6f;
    }
    public override void ShowGameSpecificPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(App.Player != val_3.moreCategoriesShowLevel)
        {
                return;
        }
        
        if((CPlayerPrefs.GetBool(key:  "moreCatShown", defaultValue:  false)) != false)
        {
                return;
        }
        
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVMoreCategoriesPopup>(showNext:  false);
    }
    public override bool get_CanShowUnPauseInterstitial()
    {
        UnityEngine.Object val_7;
        var val_8;
        val_7 = MonoSingleton<TRVGameplayUI>.Instance;
        if(val_7 != 0)
        {
                TRVGameplayUI val_3 = MonoSingleton<TRVGameplayUI>.Instance;
            val_7 = val_3.timer;
            if(val_7 != 0)
        {
                TRVGameplayUI val_5 = MonoSingleton<TRVGameplayUI>.Instance;
            if(val_5.timer.playingGame != false)
        {
                val_8 = 0;
            return (bool)val_8;
        }
        
        }
        
        }
        
        val_8 = 1;
        return (bool)val_8;
    }
    public override bool get_canShowGameSceneEventUpdates()
    {
        null = null;
        return (bool)(TRVMainController.noAnswerSelectedCharacter == null) ? 1 : 0;
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
        return val_1;
    }
    public TRVMetaGameBehavior()
    {
    
    }

}
