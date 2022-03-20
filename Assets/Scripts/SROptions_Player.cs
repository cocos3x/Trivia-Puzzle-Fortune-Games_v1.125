using UnityEngine;
public class SROptions_Player : SuperLuckySROptionsParent<SROptions_Player>, INotifyPropertyChanged
{
    // Properties
    public string SupportID { get; }
    public string Credits { get; }
    public string Gems { get; }
    public string Bucket { get; }
    public string Level { get; }
    public string SetLevel { get; set; }
    public string Chapter { get; }
    public string IsHacker { get; }
    public string HackerType { get; }
    public string IsTimeTraveler { get; }
    public string IsPurchaseHackUser { get; }
    public string Apples { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    private bool CreditsHackAvailable()
    {
        return true;
    }
    public string get_SupportID()
    {
        Player val_1 = App.Player;
        return (string)val_1.support;
    }
    public string get_Credits()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        return (string)val_1._credits.ToString(format:  val_2.numberFormatInt);
    }
    public void CreditsMinus1Hint()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_2._HintCost, hi = val_2._HintCost, lo = X22, mid = X22});
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public void CreditsMinus50()
    {
        Player val_1 = App.Player;
        decimal val_2 = new System.Decimal(value:  2);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Truncate(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public void CreditsInitial()
    {
        GameEcon val_2 = App.getGameEcon;
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_2.InitialPlayerCoins, hi = val_2.InitialPlayerCoins});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public void CreditsPlus50()
    {
        Player val_1 = App.Player;
        decimal val_2 = new System.Decimal(lo:  15, mid:  0, hi:  0, isNegative:  false, scale:  1);
        decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        decimal val_4 = System.Math.Truncate(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public void CreditsPlus1Hint()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        decimal val_3 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_2._HintCost, hi = val_2._HintCost, lo = X22, mid = X22});
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public void CreditsPlus10Hint()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        decimal val_3 = new System.Decimal(value:  10);
        decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2._HintCost, hi = val_2._HintCost, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.flags, lo = val_3.lo, mid = val_3.lo});
        decimal val_5 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = X20, mid = X20}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        App.Player.SetCredits(amount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Credits");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
    }
    public string get_Gems()
    {
        Player val_1 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        return (string)val_1._gems.ToString(format:  val_2.numberFormatInt);
    }
    public void GemPlus10()
    {
        App.Player.AddGems(amount:  10, source:  "Not Tracked", subsource:  0);
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Gems");
    }
    public void GemPlus100()
    {
        App.Player.AddGems(amount:  100, source:  "Not Tracked", subsource:  0);
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Gems");
    }
    public void GemPlus10000()
    {
        App.Player.AddGems(amount:  16, source:  "Not Tracked", subsource:  0);
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Gems");
    }
    public void GemMinus100()
    {
        int val_6;
        Player val_1 = App.Player;
        if(val_1._gems > 99)
        {
                val_6 = 99;
        }
        else
        {
                Player val_2 = App.Player;
            val_6 = -val_2._gems;
        }
        
        App.Player.AddGems(amount:  val_6, source:  "Not Tracked", subsource:  0);
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Gems");
    }
    public void GemMinus1000()
    {
        Player val_1 = App.Player;
        if(val_1._gems <= 999)
        {
                Player val_2 = App.Player;
        }
        
        App.Player.AddGems(amount:  999, source:  "Not Tracked", subsource:  0);
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdatePlayerStats");
        CurrencyController.HandleBalanceChanged(type:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Gems");
    }
    public string get_Bucket()
    {
        Player val_1 = App.Player;
        return (string)val_1.playerBucket;
    }
    public void SetBucketA()
    {
        var val_12;
        var val_13;
        Player val_1 = App.Player;
        val_1.playerBucket = "A";
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Bucket");
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_12 = 1152921516930561296;
        }
        else
        {
                val_12 = 1152921516930562320;
        }
        
        if((MonoSingletonSelfGenerating<WADataParser>.InstanceExists) == false)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                MonoSingletonSelfGenerating<WordLevelGen>.Instance.ReInitialize();
        }
        else
        {
                MonoSingletonSelfGenerating<WADataParser>.Instance.ReInitialize();
        }
        
        val_13 = null;
        if(SceneDictator.IsInGameScene() == false)
        {
                return;
        }
        
        GameBehavior val_8 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void SetBucketB()
    {
        var val_12;
        var val_13;
        Player val_1 = App.Player;
        val_1.playerBucket = "B";
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Bucket");
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_12 = 1152921516930561296;
        }
        else
        {
                val_12 = 1152921516930562320;
        }
        
        if((MonoSingletonSelfGenerating<WADataParser>.InstanceExists) == false)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                MonoSingletonSelfGenerating<WordLevelGen>.Instance.ReInitialize();
        }
        else
        {
                MonoSingletonSelfGenerating<WADataParser>.Instance.ReInitialize();
        }
        
        val_13 = null;
        if(SceneDictator.IsInGameScene() == false)
        {
                return;
        }
        
        GameBehavior val_8 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public string get_Level()
    {
        GameBehavior val_1 = App.getBehavior;
        return (string)val_1.<metaGameBehavior>k__BackingField.ToString();
    }
    public void PlayerLevelUp1()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) + 1);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  1);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void PlayerLevelUp10()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) + 10);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  10);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void PlayerLevelUp100()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) + 100);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  100);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void PlayerLevelDown1()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) - 1);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  0);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void PlayerLevelDown10()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) - 10);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  9);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void GrantAllExtraWords()
    {
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.CompleteChallenge(id:  0);
            return;
        }
        
        Prefs.extraProgress = App.getGameEcon.ExtraWordsTarget;
    }
    public void PlayerLevelDown100()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  (val_1.<metaGameBehavior>k__BackingField) - 100);
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  99);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Chapter");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public void set_SetLevel(string value)
    {
        string val_7 = value;
        GameBehavior val_1 = App.getBehavior;
        MetaGameBehavior val_2 = val_1.<metaGameBehavior>k__BackingField;
        if((System.Int32.TryParse(s:  val_7 = value, result: out  val_2)) == false)
        {
                return;
        }
        
        val_7 = val_2;
        GameBehavior val_4 = App.getBehavior;
        if(val_7 == (val_4.<metaGameBehavior>k__BackingField))
        {
                return;
        }
        
        val_4.<metaGameBehavior>k__BackingField.SetPlayerLevel(level:  val_2);
        DebugMessageDisplay.DisplayMessage(msgTxt:  "Set Player Level to " + val_2, displayTime:  3f);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Level");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public string get_SetLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        return (string)val_1.<metaGameBehavior>k__BackingField.ToString();
    }
    public string get_Chapter()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_170;
    }
    public void ResetPlayer()
    {
        this.ResetDailyChallenge();
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.PlayerPrefs.DeleteAll();
        System.IO.DirectoryInfo val_4 = new System.IO.DirectoryInfo(path:  UnityEngine.Application.persistentDataPath + "/config_files"("/config_files"));
        if((val_4 & 1) != 0)
        {
                val_4.Delete(recursive:  true);
        }
        
        System.IO.DirectoryInfo val_7 = new System.IO.DirectoryInfo(path:  UnityEngine.Application.persistentDataPath + "/scrapbooks"("/scrapbooks"));
        if((val_7 & 1) != 0)
        {
                val_7.Delete(recursive:  true);
        }
        
        App.Player.HardReset();
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  true);
        MonoSingleton<SRDebugger_Instantiator>.Instance.StartExitApp(waitSeconds:  3);
    }
    private void ResetDailyChallenge()
    {
        UnityEngine.Object val_5;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_5 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_5 == 0)
        {
                return;
        }
        
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_ResetDailyChallenge();
    }
    private void SetPlayerLevel(int level)
    {
        var val_1 = (level > 1) ? level : (0 + 1);
        GameBehavior val_2 = App.getBehavior;
        GameBehavior val_3 = App.getBehavior;
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnLevelUp");
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnDeferredReady");
    }
    public string get_IsHacker()
    {
        Player val_1 = App.Player;
        return (string)val_1.isHacker.ToString();
    }
    public string get_HackerType()
    {
        Player val_1 = App.Player;
        return (string)val_1.hackerType;
    }
    public string get_IsTimeTraveler()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        System.DateTime val_2 = ServerHandler.ServerTime;
        System.TimeSpan val_3 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
        System.TimeSpan val_4 = val_3._ticks.Duration();
        return (string)(val_4._ticks.TotalHours > 12) ? 1 : 0.ToString();
    }
    public string get_IsPurchaseHackUser()
    {
        Player val_1 = App.Player;
        return (string)val_1.properties.<PurchaseHackUser>k__BackingField.ToString();
    }
    public string get_Apples()
    {
        Player val_1 = App.Player;
        return (string)val_1._stars.ToString();
    }
    public void Credit10Apples()
    {
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  10, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_6 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  10, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  10);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public void Credit100Apples()
    {
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  100, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_6 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  100, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  100);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public void Credit1000Apples()
    {
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  232, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_6 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  232, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  232);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public void Credit10000Apples()
    {
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  16, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_6 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  16, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  16);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public void DoubleApples()
    {
        Player val_1 = App.Player;
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  val_1._stars, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_7 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  val_1._stars, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  val_1._stars);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public void HalfApples()
    {
        Player val_1 = App.Player;
        var val_15 = 1;
        val_15 = val_15 - val_1._stars;
        int val_2 = ((-val_1._stars) < 0) ? (val_15) : (-val_1._stars);
        val_2 = val_2 >> 1;
        if((MonoSingleton<TRVStarsManager>.Instance) != 0)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  val_2, source:  "HACKS", subSource:  0, additionalParam:  0);
        }
        
        if((MonoSingleton<GoldenApplesManager>.Instance) != 0)
        {
                GoldenApplesManager val_8 = MonoSingleton<GoldenApplesManager>.Instance;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsChanged");
        SLC.Social.Leagues.LeaguesManager.ContributePointsFromWinnings(goldenCurrencyWinnings:  val_2, machineName:  "HACKS", applyLTO:  true, bypassCaching:  false);
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnSecondaryCurrencyGained(numGained:  val_2);
        }
        
        App.Player.SaveState();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        CurrencyController.HandleBalanceChanged(type:  2);
        SROptions_Player.NotifyPropertyChanged(propertyName:  "Stars/Apples");
    }
    public SROptions_Player()
    {
    
    }

}
