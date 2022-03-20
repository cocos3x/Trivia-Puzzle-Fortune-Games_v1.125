using UnityEngine;
public class SROptions_GameEvents : SuperLuckySROptionsParent<SROptions_GameEvents>, INotifyPropertyChanged
{
    // Fields
    private WGEventHandler activeEvent;
    private System.TimeSpan eventSpan;
    private float calcTime;
    private string lastCachedInfo;
    
    // Properties
    public string CurrentEventType { get; }
    public string CurrentSingleEvent { get; }
    public string Level { get; }
    public string KeyToRichesKeyWord { get; }
    public int KeyToRichesKeyCount { get; set; }
    public bool KeyToRichesShowKeyEveryLevel { get; set; }
    public bool KeyToRichesShowChestContent { get; set; }
    public int KeyToRichesLevelsCounter { get; set; }
    public string ShowPiggyRaidPool { get; }
    public bool ShowPiggyRaidTileEveryLevel { get; set; }
    public bool MakeNextAddPiggyAmountExact { get; set; }
    public string DiceRolls { get; }
    public string YouBetchaConsecutiveDismissial { get; }
    public string lbMultiplier { get; }
    public bool FreeSpins { get; set; }
    private string EventExpireCountdown { get; }
    
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
    public string get_CurrentEventType()
    {
        WGEventHandler val_2 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  0);
        if(val_2 == null)
        {
                return "none";
        }
        
        return val_2.EventType;
    }
    public string get_CurrentSingleEvent()
    {
        return MonoSingleton<WordGameEventsController>.Instance.QAHACK_CurrentSingleEventTypeKey;
    }
    public void ToggleHackedSingleEvent()
    {
        MonoSingleton<WordGameEventsController>.Instance.QAHACK_ToggleSingleEvent();
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "CurrentSingleEvent");
    }
    public void CurrentEventInfoHud()
    {
        var val_4;
        System.Func<System.String> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = SROptions_GameEvents.<>c.<>9__7_0;
        if(val_6 == null)
        {
                System.Func<System.String> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<System.String>(object:  SROptions_GameEvents.<>c.__il2cppRuntimeField_static_fields, method:  System.String SROptions_GameEvents.<>c::<CurrentEventInfoHud>b__7_0());
            SROptions_GameEvents.<>c.<>9__7_0 = val_6;
        }
        
        SLCHUDWindow.SetupHUD(name:  "Current Events HUD", callbackfunc:  val_1);
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_Level()
    {
        return MonoSingleton<WordGameEventsController>.Instance.DebugGetLevel();
    }
    public void PlayerLevelUp1()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  1);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelUp10()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  5);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelUp100()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  100);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown1()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  0);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown10()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  -5);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown100()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  99);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void CompletePuzzle()
    {
        if((MonoSingleton<PuzzleCollectionUIController>.Instance) == 0)
        {
                return;
        }
        
        PuzzleCollectionHandler.CurrentPuzzleProgress = System.Linq.Enumerable.ToArray<System.Int32>(source:  System.Linq.Enumerable.Repeat<System.Int32>(element:  1, count:  16));
        PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.HackPuzzleSolution();
    }
    public void CheckPuzzlePoolHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Puzzle Pool HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetPuzzlePoolInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void AddCrowns5000()
    {
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY != null)
        {
                ClubClashEvent.LAST_PROGRESS_STAMP_KEY.AddHackedCrowns(crowns:  136);
        }
        
        if(PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.AddHackedCrowns(crowns:  136);
    }
    public void AddCrowns50k()
    {
        if(ClubClashEvent.LAST_PROGRESS_STAMP_KEY != null)
        {
                ClubClashEvent.LAST_PROGRESS_STAMP_KEY.AddHackedCrowns(crowns:  80);
        }
        
        if(PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.AddHackedCrowns(crowns:  80);
    }
    public void AddOneGoldenApple()
    {
        this.AddGoldenApples(amount:  1);
    }
    public void SubtractOneGoldenApple()
    {
        this.AddGoldenApples(amount:  0);
    }
    public void AddTenGoldenApples()
    {
        this.AddGoldenApples(amount:  10);
    }
    public void SubtractTenGoldenApples()
    {
        this.AddGoldenApples(amount:  9);
    }
    private void AddGoldenApples(int amount)
    {
        null = null;
        LeaderboardEventHandler.instance.UpdateProgressionToServer(progress:  amount, rewarded:  false);
    }
    public void PiggyBankInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Piggy Bank Info HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetPiggyBankInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ReInitPiggyBank()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackReInit();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankEvent()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackResetProgress();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankAlmostReady()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackSetBundleAlmostReady();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankReady()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackSetBundleReady();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankPromptCooldown()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackResetPromptCooldown();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankExpire1Minute()
    {
        if(PiggyBankHandler.iapHigh != null)
        {
                PiggyBankHandler.iapHigh.HackSetExpire1Minute();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankFeatureCooldown()
    {
        PiggyBankHandler.HackResetFeatureCooldown();
    }
    public void ResetLastPurchaseCooldown()
    {
        PiggyBankHandler.HackIgnoreLastPurchaseDate();
    }
    public void PiggyBankV2InfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Piggy Bank Info HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetPiggyBankV2Info()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ReInitPiggyBankV2()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackReInit();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankV2Event()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackResetProgress();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankV2AlmostFull()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackSetBankAlmostFull();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankV2Ready()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackSetBundleReady();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankV2PromptCooldown()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackResetPromptCooldown();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void SetPiggyBankV2Expire1Minute()
    {
        if(PiggyBankV2Handler.minDowngradeTier != 0)
        {
                PiggyBankV2Handler.minDowngradeTier.HackSetExpire1Minute();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank needs to be initialized to use this hack");
    }
    public void ResetPiggyBankV2FeatureCooldown()
    {
        PiggyBankV2Handler.HackResetFeatureCooldown();
    }
    public void ResetLastPurchaseCooldownV2()
    {
        PiggyBankV2Handler.HackIgnoreLastPurchaseDate();
    }
    public void SetWordHuntWords()
    {
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                return;
        }
        
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.SetRequiredWordsAsCurrentExtraWords();
    }
    public void CollectWordHuntWord()
    {
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                return;
        }
        
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.HackCollectSmallestWord();
    }
    public void ResetLightningWordsEventProgress()
    {
        if(LightningWordsHandler.DEFAULT_REWARD_VALUE == 0)
        {
                return;
        }
        
        LightningWordsHandler.DEFAULT_REWARD_VALUE.Hack_ResetLightningWordsEventProgress();
    }
    public string get_KeyToRichesKeyWord()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return "";
        }
        
        return KeyToRichesEventHandler._Instance.KeyWord;
    }
    public void KeyToRichesGrantKeyWord()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.GrantKeyWord();
    }
    public int get_KeyToRichesKeyCount()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return 0;
        }
        
        return KeyToRichesEventHandler._Instance.HackKeyCount;
    }
    public void set_KeyToRichesKeyCount(int value)
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.HackKeyCount = value;
    }
    public bool get_KeyToRichesShowKeyEveryLevel()
    {
        var val_2;
        if(KeyToRichesEventHandler._Instance != null)
        {
                var val_1 = ((KeyToRichesEventHandler._Instance.<HackShowKeyEveryLevel>k__BackingField) == true) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public void set_KeyToRichesShowKeyEveryLevel(bool value)
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.<HackShowKeyEveryLevel>k__BackingField = value;
    }
    public bool get_KeyToRichesShowChestContent()
    {
        var val_2;
        if(KeyToRichesEventHandler._Instance != null)
        {
                var val_1 = (KeyToRichesEventHandler._Instance.showChestContent == true) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public void set_KeyToRichesShowChestContent(bool value)
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        value = value;
        KeyToRichesEventHandler._Instance.ShowChestContent = value;
    }
    public int get_KeyToRichesLevelsCounter()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return 0;
        }
        
        return KeyToRichesEventHandler._Instance.HackLevelsCounter;
    }
    public void set_KeyToRichesLevelsCounter(int value)
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.HackLevelsCounter = value;
    }
    public void KeyToRichesLevelMinus10()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.LevelsCounterMinus10();
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  KeyToRichesEventHandler._Instance);
    }
    public void KeyToRichesComplete10Levels()
    {
        if(KeyToRichesEventHandler._Instance == null)
        {
                return;
        }
        
        KeyToRichesEventHandler._Instance.LevelsCounterPlus10();
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "KeyToRichesLevelsCounter");
    }
    public void GrantBingo()
    {
        if((BingoEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        BingoEventHandler.<Instance>k__BackingField.HACKGrantBingo();
        MonoSingleton<WordGameEventsController>.Instance.OnEventHandlerProgress();
    }
    public void GrantAddBalls()
    {
        if((BingoEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        BingoEventHandler.<Instance>k__BackingField.HACKAddBall();
        MonoSingleton<WordGameEventsController>.Instance.OnEventHandlerProgress();
    }
    public void GrantAllBalls()
    {
        if((BingoEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        BingoEventHandler.<Instance>k__BackingField.HACKGrantAllBalls();
    }
    public string get_ShowPiggyRaidPool()
    {
        var val_1;
        var val_2;
        val_1 = null;
        val_1 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
                return (string)System.String.alignConst;
        }
        
        val_2 = null;
        val_2 = null;
        return PiggyBankRaidEventHandler.<Instance>k__BackingField.QA_RaidPoolIds;
    }
    public bool get_ShowPiggyRaidTileEveryLevel()
    {
        var val_2;
        var val_3;
        var val_4;
        val_2 = null;
        val_2 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) != null)
        {
                val_3 = null;
            val_3 = null;
            var val_1 = ((PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_LevelBufferHack>k__BackingField) == true) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public void set_ShowPiggyRaidTileEveryLevel(bool value)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_LevelBufferHack>k__BackingField = value;
    }
    public void SetPiggyBankAlmostFull()
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        val_5 = null;
        val_5 = null;
        decimal val_2 = Item[PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankLevel];
        val_6 = null;
        val_6 = null;
        decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins = new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    public bool get_MakeNextAddPiggyAmountExact()
    {
        var val_2;
        var val_3;
        var val_4;
        val_2 = null;
        val_2 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) != null)
        {
                val_3 = null;
            val_3 = null;
            var val_1 = ((PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_NextPiggyCreditFillExactlyMax>k__BackingField) == true) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public void set_MakeNextAddPiggyAmountExact(bool value)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField.<QA_NextPiggyCreditFillExactlyMax>k__BackingField = value;
    }
    public void ShowMyselfHUD()
    {
        var val_33;
        var val_34;
        var val_35;
        int val_36;
        val_33 = 1152921504928411648;
        val_34 = null;
        val_34 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        val_35 = null;
        val_35 = null;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        SLC.Social.Profile val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyProfile;
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  "Profile Name: "("Profile Name: ") + val_3.Name);
        System.Text.StringBuilder val_8 = val_1.AppendLine(value:  "Piggy Bank Level: "("Piggy Bank Level: ") + PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankLevel(PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankLevel));
        object[] val_9 = new object[4];
        val_9[0] = "Piggy Bank Coins: ";
        decimal val_10 = PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankCoins;
        val_36 = val_9.Length;
        val_9[1] = val_10;
        val_36 = val_9.Length;
        val_9[2] = "/";
        decimal val_12 = Item[PiggyBankRaidEventHandler.<Instance>k__BackingField.PiggyBankLevel];
        val_9[3] = val_12;
        System.Text.StringBuilder val_14 = val_1.AppendLine(value:  +val_9);
        System.Text.StringBuilder val_16 = val_1.AppendLine(value:  "Min. Raidable Coins: "("Min. Raidable Coins: ") + PiggyBankRaidEcon.__il2cppRuntimeField_this_arg);
        System.Text.StringBuilder val_21 = val_1.AppendLine(value:  "Is Event Completed: "("Is Event Completed: ") + PiggyBankRaidEventHandler.<Instance>k__BackingField.IsEventCompleted().ToString()(PiggyBankRaidEventHandler.<Instance>k__BackingField.IsEventCompleted().ToString()));
        System.Text.StringBuilder val_22 = val_1.AppendLine();
        System.Text.StringBuilder val_25 = val_1.AppendLine(value:  "<b>Last Server Payload:</b>\n"("<b>Last Server Payload:</b>\n") + PrettyPrint.printJSON(obj:  PiggyBankRaidEventHandler.<Instance>k__BackingField.debugLastPayLoad, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  PiggyBankRaidEventHandler.<Instance>k__BackingField.debugLastPayLoad, types:  false, singleLineOutput:  false)));
        System.Text.StringBuilder val_26 = val_1.AppendLine();
        System.Text.StringBuilder val_27 = val_1.AppendLine(value:  "<b>Coin Log:</b>");
        System.Text.StringBuilder val_29 = val_1.AppendLine(value:  PiggyBankRaidEventHandler.<Instance>k__BackingField.GetCoinLog());
        SLCHUDWindow.SetupHUD(name:  "Myself HUD", callbackfunc:  new System.Func<System.String>(object:  val_1, method:  typeof(System.Text.StringBuilder).__il2cppRuntimeField_168));
        val_33 = SRDebug.Instance;
        var val_33 = 0;
        val_33 = val_33 + 1;
        val_33.HideDebugPanel();
    }
    public string get_DiceRolls()
    {
        var val_3;
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) != null)
        {
                string val_2 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetDiceBalance().ToString();
            return (string)val_3;
        }
        
        val_3 = "0";
        return (string)val_3;
    }
    public void DiceRollsUp1()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  1, source:  0);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "DiceRolls");
    }
    public void DiceRollsUp10()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  10, source:  0);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "DiceRolls");
    }
    public void DiceRollsDown1()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  0, source:  0);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "DiceRolls");
    }
    public void DiceRollsDown10()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.RewardDiceRolls(amount:  9, source:  0);
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "DiceRolls");
    }
    public void SetBoard1()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.Hack_ShowBoard(boardIndex:  0);
    }
    public void SetBoard2()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.Hack_ShowBoard(boardIndex:  1);
    }
    public void SetBoard3()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.Hack_ShowBoard(boardIndex:  2);
    }
    public void SetBoard4()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.Hack_ShowBoard(boardIndex:  3);
    }
    public void SetBoard5()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEventHandler.<Instance>k__BackingField.Hack_ShowBoard(boardIndex:  4);
    }
    public void SetBoardProgress80Percent()
    {
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SnakesAndLaddersEvent.Board val_1 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetCurrentBoard();
        float val_2 = (float)val_1.Definition.MaxSpaceCount;
        val_2 = val_2 * 0.8f;
        val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
        val_1.CurrentNumberSpace = (int)val_2;
    }
    public void SeasonEventResetProgress()
    {
        if((SeasonPassEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        SeasonPassEventHandler.<Instance>k__BackingField.Hack_ResetProgress();
    }
    public string get_YouBetchaConsecutiveDismissial()
    {
        object val_4;
        var val_5;
        if(TRVYouBetchaEventHandler.EVENT_TRACKING_ID != null)
        {
                Player val_4 = TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 56;
            val_4 = App.Player - val_4;
            val_4 = val_4;
            string val_3 = System.String.Format(format:  "Levels Since Last Bet {0},Levels To No Longer Show {1}", arg0:  val_4, arg1:  TRVYouBetchaEventHandler.EVENT_TRACKING_ID + 52.ToString());
            return (string)val_5;
        }
        
        val_5 = "Event Not Active";
        return (string)val_5;
    }
    public void ResetYouBetcha()
    {
        if(TRVYouBetchaEventHandler.EVENT_TRACKING_ID == null)
        {
                return;
        }
        
        TRVYouBetchaEventHandler.EVENT_TRACKING_ID.ResetEventProgress();
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "You Betcha");
    }
    public string get_lbMultiplier()
    {
        null = null;
        return System.String.Format(format:  "{0}x", arg0:  ToString());
    }
    public void lbSet2x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 2;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet3x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 3;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet4x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 4;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet5x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 5;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet10x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 10;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet25x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 25;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void lbSet50x()
    {
        null = null;
        LetterBankEventHandler.hack_multiplier = 50;
        SROptions_GameEvents.NotifyPropertyChanged(propertyName:  "Letter Bank");
    }
    public void None()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 0;
    }
    public void Attack()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 1;
    }
    public void AttackSuccess()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 2;
    }
    public void AttackFailed()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 3;
    }
    public void Raid()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 4;
    }
    public void Shield()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 5;
    }
    public void Spins()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 6;
    }
    public void Bag3()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 7;
    }
    public void Bag2()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 8;
    }
    public void Bag1()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 9;
    }
    public bool get_FreeSpins()
    {
        var val_2;
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY != null)
        {
                var val_1 = ((SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 40) != 0) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public void set_FreeSpins(bool value)
    {
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY == null)
        {
                return;
        }
        
        SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.__unknownFiledOffset_28 = value;
    }
    private string get_EventExpireCountdown()
    {
        object val_15;
        var val_16;
        val_15 = this;
        WGEventHandler val_2 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  0);
        this.activeEvent = val_2;
        if(val_2 != null)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2}, d2:  new System.DateTime() {dateData = val_3.dateData});
            this.eventSpan = val_4;
            object[] val_5 = new object[4];
            val_5[0] = this.eventSpan.Days.ToString();
            val_5[1] = this.eventSpan.Hours.ToString();
            val_5[2] = this.eventSpan.Minutes.ToString();
            val_15 = this.eventSpan.Seconds.ToString();
            val_5[3] = val_15;
            string val_14 = System.String.Format(format:  "{00}d:{01}h:{02}m:{03}s", args:  val_5);
            return (string)val_16;
        }
        
        val_16 = "n/a";
        return (string)val_16;
    }
    public string GetCurrentEventInfo()
    {
        object val_10;
        string val_11;
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.calcTime + val_1;
        this.calcTime = val_1;
        if(val_1 < 0)
        {
                if((System.String.IsNullOrEmpty(value:  this.lastCachedInfo)) == false)
        {
            goto label_2;
        }
        
        }
        
        this.lastCachedInfo = "";
        System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_6 = val_3.Append(value:  System.String.Format(format:  "<color=#20FD3B>Expire Countdown: {0}</color>\n", arg0:  this.EventExpireCountdown));
        if(this.activeEvent != null)
        {
                val_10 = this.activeEvent.EventType;
        }
        else
        {
                val_10 = "null";
        }
        
        System.Text.StringBuilder val_9 = val_3.Append(value:  System.String.Format(format:  "Event Info: {0}", arg0:  val_10));
        val_11 = val_3;
        this.lastCachedInfo = val_11;
        this.calcTime = 0f;
        return val_11;
        label_2:
        val_11 = this.lastCachedInfo;
        return val_11;
    }
    public SROptions_GameEvents()
    {
        this.lastCachedInfo = "";
    }

}
