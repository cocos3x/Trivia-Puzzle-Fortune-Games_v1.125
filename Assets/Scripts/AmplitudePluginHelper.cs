using UnityEngine;
public class AmplitudePluginHelper
{
    // Fields
    private static AmplitudePluginHelper.FeatureAccessPoints lastFeatureAccessPoint;
    
    // Properties
    public static AmplitudePluginHelper.FeatureAccessPoints LastFeatureAccessPoint { get; set; }
    
    // Methods
    public static AmplitudePluginHelper.FeatureAccessPoints get_LastFeatureAccessPoint()
    {
        null = null;
        return (FeatureAccessPoints)AmplitudePluginHelper.lastFeatureAccessPoint;
    }
    public static void set_LastFeatureAccessPoint(AmplitudePluginHelper.FeatureAccessPoints value)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = value;
    }
    public static void InjectMetaData(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        if(data == null)
        {
            goto label_3;
        }
        
        if(App.Player != 0)
        {
            goto label_6;
        }
        
        UnityEngine.Debug.LogError(message:  "trying to get tracking data with no Player");
        return;
        label_3:
        UnityEngine.Debug.LogError(message:  "Trying to inject tracking data on null data");
        return;
        label_6:
        if((data.ContainsKey(key:  "level")) != true)
        {
                data.Add(key:  "level", value:  Player.GetLevelForTracking());
        }
        
        if((data.ContainsKey(key:  "coins")) == true)
        {
                return;
        }
        
        data.Add(key:  "coins", value:  val_1._credits.ToString());
    }
    public static void InjectRegularGlobals(string eventName, System.Collections.Generic.Dictionary<string, object> globals)
    {
        MetaGameBehavior val_72;
        string val_73;
        var val_74;
        var val_75;
        string val_76;
        Player val_1 = App.Player;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if(globals == null)
        {
                throw new NullReferenceException();
        }
        
        globals.Add(key:  "google_ad_id", value:  DeviceIdPlugin.GetGoogleAdId());
        globals.Add(key:  "fbauid", value:  UnityEngine.PlayerPrefs.GetString(key:  "facebook_app_user_id", defaultValue:  ""));
        globals.Add(key:  "alt_payer", value:  ((UnityEngine.PlayerPrefs.GetInt(key:  "altPayer", defaultValue:  0)) == 1) ? 1 : 0);
        globals.Add(key:  "unity_crashed", value:  ((UnityEngine.PlayerPrefs.GetInt(key:  "unity_crashed", defaultValue:  0)) == 1) ? 1 : 0);
        val_73 = "recommender";
        globals.Add(key:  val_73, value:  WGInviteManager.InviteSent);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_72 = val_12.<metaGameBehavior>k__BackingField;
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Current Language";
        globals.Add(key:  val_73, value:  val_72.GetCurrentLanguage());
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_14.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "imported_user";
        globals.Add(key:  val_73, value:  val_14.properties.imported);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_15.properties == null)
        {
                throw new NullReferenceException();
        }
        
        globals.Add(key:  "imported_old_support_id", value:  val_15.properties.oldSupportId);
        if((System.String.IsNullOrEmpty(value:  AdSegmentation.Segment)) != true)
        {
                globals.Add(key:  "Adjust Segment", value:  AdSegmentation.Segment);
        }
        
        val_73 = 0;
        if((MonoSingleton<WGAudioController>.Instance) != val_73)
        {
                WGAudioController val_21 = MonoSingleton<WGAudioController>.Instance;
            if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
            val_73 = "Music On";
            globals.Add(key:  val_73, value:  val_21.IsSoundEnabled());
            WGAudioController val_24 = MonoSingleton<WGAudioController>.Instance;
            if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
            globals.Add(key:  "Sound On", value:  val_24.IsMusicEnabled());
        }
        
        val_74 = null;
        val_74 = null;
        val_73 = "Notifications On";
        val_72 = globals;
        val_72.Add(key:  val_73, value:  twelvegigs.plugins.LocalNotificationsPlugin.notification_status);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1.email != null)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            globals.Add(key:  "user_email", value:  val_27.email);
        }
        
        globals.Add(key:  "ads_clicked", value:  val_1.num_ad_clicks);
        globals.Add(key:  "purchaser", value:  (val_1.total_purchased > 0f) ? 1 : 0.ToString());
        globals.Add(key:  "Network Purchaser", value:  val_1.NetworkPurchaser.ToString());
        globals.Add(key:  "repeat_purchaser", value:  (val_1.num_purchase > 1) ? 1 : 0);
        globals.Add(key:  "super_whale", value:  (val_1.total_purchased > 250f) ? 1 : 0);
        globals.Add(key:  "ad_whale", value:  (val_1.num_ad_clicks > 29) ? 1 : 0.ToString());
        val_73 = "is_emulator";
        globals.Add(key:  val_73, value:  DeviceIdPlugin.IsEmulator());
        val_72 = val_2.<metaGameBehavior>k__BackingField;
        if(val_72 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_75 = mem[val_2.<metaGameBehavior>k__BackingField + 1288];
        val_75 = val_2.<metaGameBehavior>k__BackingField + 1288;
        if((val_72 & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_39.properties == null)
        {
                throw new NullReferenceException();
        }
        
            object val_72 = ~(System.String.IsNullOrEmpty(value:  val_39.properties.offline_fb_id));
            val_72 = val_72 & 1;
            val_76 = "connected_to_fb";
            globals.Add(key:  val_76, value:  val_72);
        }
        
        globals.Add(key:  "Level", value:  val_1);
        val_73 = "coin_balance";
        val_72 = globals;
        val_72.Add(key:  val_73, value:  val_1._credits.ToString());
        if(val_1.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Last Seen";
        globals.Add(key:  val_73, value:  val_1.properties.LastSeenDateString);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Hacker";
        globals.Add(key:  val_73, value:  val_42.isHacker);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Hacker Type";
        globals.Add(key:  val_73, value:  val_43.hackerType);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_44.properties == null)
        {
                throw new NullReferenceException();
        }
        
        globals.Add(key:  "Hacker Local Purchases", value:  val_44.properties.<PurchaseHackUser>k__BackingField);
        val_73 = "Hacker Local Time";
        globals.Add(key:  val_73, value:  DeviceProperties.timeTraveler);
        CompanyDevices val_47 = CompanyDevices.Instance;
        if(val_47 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "low_end_device";
        globals.Add(key:  val_73, value:  val_47.isLowEndDevice());
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lapsing Purchaser";
        globals.Add(key:  val_73, value:  val_50.IsLapsingPurchaser);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lapsing Non-purchaser";
        globals.Add(key:  val_73, value:  val_51.IsLapsingNonPurchaser);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "total_transactions";
        globals.Add(key:  val_73, value:  val_52.num_purchase);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "total_purchase";
        globals.Add(key:  val_73, value:  val_53.total_purchased);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_54.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_55.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_56.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_57.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_58.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_59.properties == null)
        {
                throw new NullReferenceException();
        }
        
        int val_73 = val_59.properties.MGHintsCount;
        int val_60 = val_55.properties.LifetimeDCHints + val_54.properties.LifetimeHints;
        val_60 = val_60 + val_56.properties.LifetimeHintPickers;
        val_60 = val_60 + val_57.properties.LifetimeMegaHints;
        val_60 = val_60 + val_58.properties.LifetimeCheckHints;
        val_73 = val_60 + val_73;
        val_73 = "Lifetime Hint Usage";
        globals.Add(key:  val_73, value:  val_73);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_61.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lifetime Original Hints";
        globals.Add(key:  val_73, value:  val_61.properties.LifetimeHints);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_62.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lifetime Free Hints";
        globals.Add(key:  val_73, value:  val_62.properties.LifetimeFreeHints);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_63.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lifetime Struggle Hints";
        val_72 = globals;
        val_72.Add(key:  val_73, value:  val_63.properties.LifetimeStruggleHints);
        if((val_3.<gameplayBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_64.properties == null)
        {
                throw new NullReferenceException();
        }
        
            globals.Add(key:  "Lifetime Picker Hints", value:  val_64.properties.LifetimeHintPickers);
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_65.properties == null)
        {
                throw new NullReferenceException();
        }
        
            globals.Add(key:  "Lifetime Mega Hints", value:  val_65.properties.LifetimeMegaHints);
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            val_73 = "Lifetime Checks Used";
            globals.Add(key:  val_73, value:  val_66.properties.LifetimeCheckHints);
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Gems";
        globals.Add(key:  val_73, value:  val_67._gems);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_68.properties == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = "Lifetime Prize Balloon Tapped";
        globals.Add(key:  val_73, value:  val_68.properties.prizeBalloonTapped);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_69.properties == null)
        {
                throw new NullReferenceException();
        }
        
        globals.Add(key:  "Lifetime Prize Balloon Appearance", value:  val_69.properties.prizeBalloonAppeared);
        string val_70 = DeeplinkPlugin.GetMoreGamesReferal();
        if((System.String.IsNullOrEmpty(value:  val_70)) == false)
        {
                return;
        }
        
        globals.Add(key:  "Install Params", value:  val_70);
    }
    public static void InjectFeatureGlobals(string eventName, System.Collections.Generic.Dictionary<string, object> globals)
    {
        var val_105;
        var val_148;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_149;
        MetaGameBehavior val_150;
        var val_151;
        var val_152;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_153;
        var val_154;
        var val_155;
        var val_156;
        var val_157;
        var val_158;
        var val_159;
        var val_160;
        var val_161;
        UnityEngine.Object val_162;
        SubScriptionType val_163;
        bool val_164;
        bool val_165;
        object val_166;
        var val_167;
        float val_168;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_169;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_19 = globals;
        val_148 = 1152921504884269056;
        val_149 = App.Player;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_150 = val_2.<metaGameBehavior>k__BackingField;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_150 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_150 & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Lifetime DC Stars", value:  val_4.dcStars);
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_5.properties == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Lifetime Challenge Hints", value:  val_5.properties.LifetimeDCHints);
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_6.properties == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Daily Challenge Tutorial Status", value:  val_6.properties.DailyChallengeTutorialStatus);
        }
        
        if((val_3.<gameplayBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_8.properties == null)
        {
                throw new NullReferenceException();
        }
        
            if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Extra Required Words Levels", value:  UnityEngine.Mathf.Min(a:  val_7.extraReqDefaultLevelsPerChapter + (val_9.extraReqIncrement * val_8.properties.ChaptersPlayedWithoutHints), b:  val_10.extraReqMaxLevelsPerChapter));
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_13.properties == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Skip Tutorial", value:  val_13.properties.SkippedTutorial);
        }
        
        if(((val_3.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_14.properties == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Skip Advanced Used", value:  val_14.properties.AdvancedSkipLevel);
        }
        
        if((val_150 & 1) != 0)
        {
                WordGameEventsController.InjectEventsTrackingData(data:  val_19, onlyTrackEnabledEvents:  false);
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Lifetime Puzzles Completed", value:  PuzzleCollectionHandler.LifetimePuzzlesCompleted);
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "+Pass Active", value:  SeasonPassEventHandler.IsPlusPassActive);
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Dice Rolls", value:  SnakesAndLaddersEventHandler.CurrentDiceRollsOnEvent);
        }
        
        SLC.Social.Leagues.LeaguesTracker.InjectLeaguesPlayerGlobals(globals: ref  val_19);
        val_151 = 1152921504619999232;
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Number Friends Invited", value:  WGInviteManager.invitesSend);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Was Invited", value:  WGInviteManager.isInvited);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Total Number of Valid Invites", value:  WGInviteManager.TotalValidInvites);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Friend Code Redeemed Manually", value:  WGInviteManager.CodeManuallyEntered);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Definitions Viewed", value:  val_26.properties.LifetimeDefinitionsViewed);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_27.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Extra Words", value:  val_27.properties.GoalExtraWords);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_28.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Use Hints", value:  val_28.properties.GoalUseHints);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_29.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Golden Currency", value:  val_29.properties.GoalGoldenCurrency);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_30.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Daily Challenge", value:  val_30.properties.GoalDailyChallenge);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_31.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Twitter Post", value:  val_31.properties.GoalTwitterPosts);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_32.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Goal Friend Inviter", value:  val_32.properties.GoalFriendInvites);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_33.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Story Mode Vote", value:  val_33.properties.story_mode_vote);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_34.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Alphabet Collections Completed", value:  val_34.properties.ab_totalCollectionsComplete);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Alphabet Redraw Used", value:  val_35.properties.ab_lifeftime_redraws);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Levels Removed", value:  val_36.levelsRemoved);
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                WGDailyChallengeManager val_39 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
            val_151 = 1152921504619999232;
            if(val_39.GetLifetimeMonthlyZootiles() == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Daily Challenge Monthly Tiles Earned", value:  0);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_41.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime VIP Purchases", value:  val_41.properties.LifetimeVipPartyPurchases);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_42.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Largest Word Streak", value:  val_42.properties.LifetimeLargestStreak);
        if(PiggyBankHandler.iapHigh != null)
        {
                object val_146 = PiggyBankHandler.iapHigh + 240;
            val_146 = val_146 ^ 1;
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Has Piggy Bank", value:  val_146);
        if(AttackMadnessEventHandler.IsEventActive != false)
        {
                if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "EA Attack Madness", value:  (AttackMadnessEventHandler.<Instance>k__BackingField) & 1);
            if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if(null == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Current Attack Madness Reward Tier", value:  typeof(AttackMadnessProgress).__il2cppRuntimeField_1C);
        }
        
        if(RaidMadnessEventHandler.IsEventActive != false)
        {
                if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Current Raid Madness Reward Tier", value:  RaidMadnessEventHandler.<Instance>k__BackingField.ProgressLevel);
        }
        
        if(IslandParadiseEventHandler._Instance != null)
        {
                if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Current Island Paradise Reward Tier", value:  IslandParadiseEventHandler._Instance.ProgressLevel + 1);
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "EA Island Paradise Symbol", value:  IslandParadiseEventHandler.IsEventActive);
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_19.ContainsKey(key:  "Access Point")) != true)
        {
                val_152 = null;
            val_152 = null;
            if(AmplitudePluginHelper.lastFeatureAccessPoint != 0)
        {
                object[] val_52 = new object[2];
            if(val_52 == null)
        {
                throw new NullReferenceException();
        }
        
            if(eventName != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
            if(val_52.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
            val_52[0] = eventName;
            val_154 = null;
            val_154 = null;
            if(AmplitudePluginHelper.lastFeatureAccessPoint == 0)
        {
                throw new NullReferenceException();
        }
        
            string val_53 = AmplitudePluginHelper.lastFeatureAccessPoint.ToString();
            AmplitudePluginHelper.lastFeatureAccessPoint = ;
            if(val_53 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
            if(val_52.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
            val_52[1] = val_53;
            UnityEngine.Debug.LogWarningFormat(format:  "{0} is using up Access Point: {1}", args:  val_52);
            val_152 = null;
        }
        
            val_155 = null;
            val_148 = val_148;
            val_155 = null;
            val_148 = val_148;
            if(AmplitudePluginHelper.lastFeatureAccessPoint == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Access Point", value:  AmplitudePluginHelper.lastFeatureAccessPoint.ToString());
            val_156 = null;
            val_156 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 0;
        }
        
        val_157 = 1152921504619999232;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_55.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "User IQ", value:  val_55.properties.PlayerIQ);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Books Purchased", value:  TheLibraryLogic.LifetimeBooksPurchased);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Books Earned", value:  TheLibraryLogic.LifetimeBooksEarned);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Library Score", value:  TheLibraryLogic.LibraryScore);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Library Collections Completed", value:  TheLibraryLogic.CountCompletedCollections());
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Book Packs Purchased", value:  TheLibraryLogic.LifetimeBookPacksPurchased);
        if((DefaultHandler<SubscriptionHandler>.Instance) == 0)
        {
            goto label_171;
        }
        
        SubscriptionHandler val_63 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_63.IsActive(subPackage:  0)) == false)
        {
            goto label_175;
        }
        
        SubscriptionHandler val_65 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_65.getCurrentModel(subPackage:  0)) == null)
        {
                throw new NullReferenceException();
        }
        
        val_158 = (val_66.<trial>k__BackingField) ^ 1;
        goto label_180;
        label_171:
        val_159 = 0;
        val_160 = 0;
        goto label_181;
        label_175:
        val_158 = 0;
        label_180:
        SubscriptionHandler val_68 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_68.IsActive(subPackage:  1)) != false)
        {
                SubscriptionHandler val_70 = DefaultHandler<SubscriptionHandler>.Instance;
            if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
            val_157 = 1152921504619999232;
            if((val_70.getCurrentModel(subPackage:  1)) == null)
        {
                throw new NullReferenceException();
        }
        
            val_161 = (val_71.<trial>k__BackingField) ^ 1;
        }
        else
        {
                val_157 = 1152921504619999232;
            val_161 = 0;
        }
        
        label_181:
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Golden Ticket Sub Active", value:  (val_158 != 0) ? 1 : 0);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_73.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Golden Ticket Sub Purchases", value:  val_73.properties.numSubscriptionsPurchased);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Silver Ticket Sub Active", value:  (val_161 != 0) ? 1 : 0);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_74.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Silver Ticket Sub Purchases", value:  val_74.properties.numSubscriptionsPurchased_Silver);
        val_162 = 0;
        if((DefaultHandler<SubscriptionHandler>.Instance) == val_162)
        {
            goto label_242;
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_77.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_77.properties.numTrialSubs == 0)
        {
            goto label_210;
        }
        
        SubscriptionHandler val_78 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_78.IsActive(subPackage:  0)) == false)
        {
            goto label_219;
        }
        
        SubscriptionHandler val_80 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_80 == null)
        {
                throw new NullReferenceException();
        }
        
        val_163 = 0;
        if((val_80.getCurrentModel(subPackage:  val_163)) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_81.<trial>k__BackingField) == false)
        {
            goto label_219;
        }
        
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_153.Add(key:  "Golden Ticket Trial", value:  "Active");
        goto label_223;
        label_219:
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_153.Add(key:  "Golden Ticket Trial", value:  "Completed");
        goto label_223;
        label_210:
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_153.Add(key:  "Golden Ticket Trial", value:  "Pending");
        label_223:
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_82.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_82.properties.numTrialSubs_Silver == 0)
        {
            goto label_229;
        }
        
        SubscriptionHandler val_83 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_83.IsActive(subPackage:  1)) == false)
        {
            goto label_238;
        }
        
        SubscriptionHandler val_85 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_85 == null)
        {
                throw new NullReferenceException();
        }
        
        val_163 = 1;
        if((val_85.getCurrentModel(subPackage:  val_163)) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_86.<trial>k__BackingField) == false)
        {
            goto label_238;
        }
        
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_162 = "Silver Ticket Trial";
        val_153.Add(key:  val_162, value:  "Active");
        goto label_242;
        label_238:
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_162 = "Silver Ticket Trial";
        val_153.Add(key:  val_162, value:  "Completed");
        goto label_242;
        label_229:
        val_153 = val_19;
        if(val_153 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_162 = "Silver Ticket Trial";
        val_153.Add(key:  val_162, value:  "Pending");
        label_242:
        if(val_149 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_149 > WGFTUXManager.FTUX_LEVEL_LIMIT)
        {
                if(val_1.properties == null)
        {
                throw new NullReferenceException();
        }
        
            val_164 = val_1.properties.FTUXWasBlockedByKnob;
        }
        else
        {
                val_164 = false;
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "FTUX Was Disabled", value:  val_164);
        if((val_150 & 1) != 0)
        {
                if((MonoSingleton<CategoryPacksManager>.Instance) != 0)
        {
                if((MonoSingleton<CategoryPacksManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Total Categories Complete", value:  val_90.totalCompletedPacks);
            if((MonoSingleton<CategoryPacksManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_19.Add(key:  "Total Categories Purchased", value:  val_91.totalPurchasedPacks);
        }
        
        }
        
        val_149 = val_19;
        if((MonoSingleton<LimitedTimeBundlesManager>.Instance) != 0)
        {
                LimitedTimeBundlesManager val_94 = MonoSingleton<LimitedTimeBundlesManager>.Instance;
            if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
            val_165 = val_94.HaveBundlesToShow();
        }
        else
        {
                val_165 = false;
        }
        
        if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_149.Add(key:  "EA Limited Time Bundle Sale", value:  val_165);
        val_149 = val_19;
        if((MonoSingleton<DifficultySettingManager>.Instance) == 0)
        {
            goto label_275;
        }
        
        if((MonoSingleton<DifficultySettingManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_98.<Setting>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_98.<Setting>k__BackingField.Mode) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_166 = val_98.<Setting>k__BackingField.Mode.ToString();
        mem2[0] = val_98.<Setting>k__BackingField.Mode;
        if(val_149 != 0)
        {
            goto label_281;
        }
        
        throw new NullReferenceException();
        label_275:
        val_166 = "Not supported in this game";
        if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_281:
        val_149.Add(key:  "Difficulty Setting", value:  val_166);
        val_149 = MonoSingleton<WADPetsManager>.Instance;
        if(val_149 == 0)
        {
            goto label_292;
        }
        
        if((MonoSingleton<WADPetsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_102.<IsDataInitialized>k__BackingField) == false)
        {
            goto label_292;
        }
        
        System.Collections.Generic.List<WADPets.WADPet> val_103 = WADPetsManager.GetAllPetsCollection();
        if(val_103 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_104 = val_103.GetEnumerator();
        val_157 = 1152921505018241024;
        label_299:
        if(val_165.MoveNext() == false)
        {
            goto label_294;
        }
        
        val_149 = val_105;
        if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
        WADPets.PetStatus val_109 = val_149.GetStatus();
        if(val_109 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  System.String.Format(format:  "Pet {0} Status", arg0:  val_149.GetPrettyName()), value:  val_109.ToString());
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  System.String.Format(format:  "Pet {0} Cards", arg0:  val_149.GetPrettyName()), value:  val_105 + 32);
        goto label_299;
        label_294:
        val_149 = 0;
        val_165.Dispose();
        val_150 = val_150;
        val_148 = 1152921504884269056;
        if(val_149 != 0)
        {
            goto label_300;
        }
        
        if((MonoSingleton<WADPetsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_113.<LifetimeTrackingInfo>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Lifetime Food", value:  val_113.<LifetimeTrackingInfo>k__BackingField.Food);
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "Card Balance", value:  WADPetsManager.GetCardsBalance());
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Add(key:  "food_balance", value:  val_115._food);
        label_292:
        val_149 = val_19;
        if(GoldenMultiplierManager.IsAvaialable != false)
        {
                GoldenMultiplierManager val_117 = MonoSingleton<GoldenMultiplierManager>.Instance;
            if(val_117 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Golden Multiplier", value:  val_117.GetCurrentBaseMultiplier);
            val_149 = val_19;
            GoldenMultiplierManager val_119 = MonoSingleton<GoldenMultiplierManager>.Instance;
            if(val_119 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Total Multiplier", value:  val_119.GetCurrentGoldenMultiplier);
        }
        else
        {
                if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Golden Multiplier", value:  null);
            val_149 = val_19;
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Total Multiplier", value:  null);
        }
        
        val_149 = MonoSingleton<TRVQuestionOfTheDayManager>.Instance;
        if(val_149 != 0)
        {
                val_149 = val_19;
            TRVQuestionOfTheDayManager val_123 = MonoSingleton<TRVQuestionOfTheDayManager>.Instance;
            if(val_123 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "EA Question of the Day", value:  val_123.IsPlaying());
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_126.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((((val_126.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<TournamentsManager>.Instance) == 0))
        {
            goto label_343;
        }
        
        if((MonoSingleton<TournamentsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_129.currentTournamentInfo == null)
        {
            goto label_343;
        }
        
        if((MonoSingleton<TournamentsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_130.currentTournamentInfo == null)
        {
                throw new NullReferenceException();
        }
        
        int val_147 = val_130.currentTournamentInfo.myRank;
        val_147 = val_147 + 1;
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_163 = "Current Tournament Rank";
        val_19.Add(key:  val_163, value:  val_147);
        val_167 = null;
        val_167 = null;
        if((MonoSingleton<TournamentsManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_131.currentTournamentInfo == null)
        {
                throw new NullReferenceException();
        }
        
        if(TournamentsEconomy.TierNames == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_131.currentTournamentInfo.tierIndex >= TournamentsEconomy.TierNames.Length)
        {
            goto label_354;
        }
        
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.String[] val_132 = TournamentsEconomy.TierNames + ((val_131.currentTournamentInfo.tierIndex) << 3);
        val_19.Add(key:  "Current Tournament Tier", value:  (TournamentsEconomy.TierNames + (val_131.currentTournamentInfo.tierIndex) << 3) + 32);
        label_343:
        val_149 = MonoSingleton<TRVDataParser>.Instance;
        if(val_149 != 0)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_135.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_149 = val_135.<playerPersistance>k__BackingField.totalSeenQuestions;
            if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_136.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_149 > 0)
        {
                float val_149 = 100f;
            float val_148 = (float)val_136.<playerPersistance>k__BackingField.totalCorrectQuestions;
            val_148 = val_148 / (float)val_149;
            val_149 = val_148 * val_149;
            val_168 = (float)UnityEngine.Mathf.RoundToInt(f:  val_149);
        }
        else
        {
                val_168 = 0f;
        }
        
            val_149 = val_19;
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Correct Answer Percentage", value:  val_168);
        }
        
        val_169 = 1152921504893267968;
        val_149 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        if(val_149 != 0)
        {
                val_149 = val_19;
            AdsManager val_140 = MonoSingletonSelfGenerating<AdsManager>.Instance;
            if(val_140 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_149 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_149.Add(key:  "Ad Cap Reached", value:  val_140.rewardVideoCapReached);
        }
        
        if((val_150 & 1) == 0)
        {
                return;
        }
        
        val_169 = val_19;
        if(val_169 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_169.Add(key:  "Required Words Jumble", value:  WordRegion.EnabledNonAlphabeticalWords());
        return;
        label_300:
        val_153 = val_149;
        throw val_153;
        label_354:
        val_163 = 0;
        throw new IndexOutOfRangeException();
    }
    public static void InjectMetaBehaviorProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> globals, ref System.Collections.Generic.Dictionary<string, object> data)
    {
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WordGameEventsController>.Instance.AppendAmplitudeUserProperties(globals: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = globals);
    }
    public AmplitudePluginHelper()
    {
    
    }
    private static AmplitudePluginHelper()
    {
    
    }

}
