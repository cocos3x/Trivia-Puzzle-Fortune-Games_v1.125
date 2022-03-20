using UnityEngine;
public class PiggyBankRaidEventHandler : WGEventHandler
{
    // Fields
    public const string PIGGY_BANK_RAID_EVENT_ID = "PiggyBankRaid";
    public const string EVENT_TRACKING_ID = "Piggy Bank Raid";
    public static bool isEventPopupQueued;
    public System.Action<bool, System.Decimal> OnPurchaseAttempt;
    public TrackerPurchasePoints currPurchasePoint;
    private PiggyBankRaidEcon econ;
    private PiggyBankRaidProgress progressData;
    private UnityEngine.GameObject currentTileObj;
    private System.Collections.Generic.List<PiggyBankRaidPlayerProfile> cachedOpponentPool;
    private PiggyBankRaidPlayerProfile currentOpponent;
    private System.Nullable<System.DateTime> lastProcessedNewsTimestamp;
    private DG.Tweening.Tweener collectTween;
    private static PiggyBankRaidEventHandler <Instance>k__BackingField;
    public System.Collections.Generic.Dictionary<string, object> debugLastPayLoad;
    private System.Collections.Generic.List<string> debugCoinChangeLog;
    private bool <QA_LevelBufferHack>k__BackingField;
    private bool <QA_NextPiggyCreditFillExactlyMax>k__BackingField;
    
    // Properties
    public PiggyBankRaidEcon Econ { get; }
    public PiggyBankRaidProgress ProgressData { get; }
    public PiggyBankRaidPlayerProfile CurrentOpponent { get; }
    public static PiggyBankRaidEventHandler Instance { get; set; }
    public decimal PiggyBankCoins { get; set; }
    public int PiggyBankLevel { get; set; }
    private UnityEngine.GameObject TilePrefab { get; }
    public bool IsTileCurrentlyInPlay { get; }
    public string QA_RaidPoolIds { get; }
    public bool QA_LevelBufferHack { get; set; }
    public bool QA_NextPiggyCreditFillExactlyMax { get; set; }
    
    // Methods
    public PiggyBankRaidEcon get_Econ()
    {
        return (PiggyBankRaidEcon)this.econ;
    }
    public PiggyBankRaidProgress get_ProgressData()
    {
        return (PiggyBankRaidProgress)this.progressData;
    }
    public PiggyBankRaidPlayerProfile get_CurrentOpponent()
    {
        return (PiggyBankRaidPlayerProfile)this.currentOpponent;
    }
    public static PiggyBankRaidEventHandler get_Instance()
    {
        null = null;
        return (PiggyBankRaidEventHandler)PiggyBankRaidEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(PiggyBankRaidEventHandler value)
    {
        null = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField = value;
    }
    public decimal get_PiggyBankCoins()
    {
        return new System.Decimal() {flags = this.progressData.player.coins, hi = this.progressData.player.coins};
    }
    public void set_PiggyBankCoins(decimal value)
    {
        this.progressData.player.coins = value;
        mem2[0] = value.lo;
        mem[4] = value.mid;
        goto typeof(PiggyBankRaidProgress).__il2cppRuntimeField_180;
    }
    public int get_PiggyBankLevel()
    {
        return UnityEngine.Mathf.Clamp(value:  this.progressData.player.bankLevel, min:  1, max:  5);
    }
    protected void set_PiggyBankLevel(int value)
    {
        this.progressData.player.bankLevel = value;
    }
    private UnityEngine.GameObject get_TilePrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "PiggyBankRaidTile");
    }
    public bool get_IsTileCurrentlyInPlay()
    {
        int val_5;
        var val_6;
        val_5 = this;
        if((WordRegion.instance != 0) && (this.progressData.currentAssociatedLevel == PlayingLevel.GetCurrentPlayerLevelNumber()))
        {
                val_5 = this.progressData.currentLineWord;
            if((((val_5 & 2147483648) == 0) && (val_5 < (this.progressData.currentAssociatedLevel + 24))) && ((this.progressData.currentCell & 2147483648) == 0))
        {
                if((this.progressData.currentAssociatedLevel + 24) <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_5 = this.progressData.currentAssociatedLevel + 16;
            val_5 = val_5 + ((this.progressData.currentLineWord) << 3);
            var val_4 = (this.progressData.currentCell < ((this.progressData.currentAssociatedLevel + 16 + (this.progressData.currentLineWord) << 3) + 32 + 40 + 24)) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public override void Init(GameEventV2 eventV2)
    {
        var val_1;
        mem[1152921516574942064] = eventV2;
        val_1 = null;
        val_1 = null;
        PiggyBankRaidEventHandler.<Instance>k__BackingField = this;
        this.SetupEvent();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "PiggyBankRaid")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "piggy_raid_upper", defaultValue:  "PIGGY BANK RAID", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "piggy_raid_upper", defaultValue:  "PIGGY BANK RAID", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "raid_upper", defaultValue:  "RAID", useSingularKey:  false);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public override bool EventCompleted()
    {
        if(this.progressData != null)
        {
                return (bool)this.progressData.isMaxPiggyPurchased;
        }
        
        throw new NullReferenceException();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        decimal val_1 = this.PiggyBankCoins;
        decimal val_3 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        decimal val_4 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        float val_5 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        decimal val_6 = this.PiggyBankCoins;
        GameEcon val_7 = App.getGameEcon;
        decimal val_10 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        string val_11 = System.String.Format(format:  "{0}/{1}", arg0:  val_6.flags.ToString(format:  val_7.numberFormatInt), arg1:  val_10);
        EventListItemContentPiggyBankRaid val_12 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentPiggyBankRaid>(allowMultiple:  false);
    }
    public override void OnProcessPurchase(ref PurchaseModel purchase)
    {
        this.OnProcessPurchase(purchase: ref  PurchaseModel val_1 = purchase);
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "id_piggybank_raid")) == false)
        {
                return;
        }
        
        if(this.OnPurchaseAttempt == null)
        {
                return;
        }
        
        decimal val_2 = purchase.Credits;
        this.OnPurchaseAttempt.Invoke(arg1:  false, arg2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        PiggyBankRaidProgress val_3;
        if((purchase.id.Contains(value:  "id_piggybank_raid")) == false)
        {
                return;
        }
        
        mem2[0] = 0;
        this.progressData.player.coins = 0m;
        int val_3 = this.progressData.player.bankLevel;
        val_3 = val_3 + 1;
        this.progressData.player.bankLevel = val_3;
        val_3 = this.progressData;
        if(this.progressData.player.bankLevel >= 6)
        {
                this.progressData.isMaxPiggyPurchased = true;
            val_3 = this.progressData;
        }
        
        this.UpdateProgressToServer();
        if(this.OnPurchaseAttempt == null)
        {
                return;
        }
        
        decimal val_2 = purchase.Credits;
        this.OnPurchaseAttempt.Invoke(arg1:  true, arg2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
    }
    public override void OnEventEnded()
    {
        this.progressData = new PiggyBankRaidProgress();
    }
    public override void OnMenuLoaded()
    {
        null = null;
        if(PiggyBankRaidEventHandler.isEventPopupQueued == false)
        {
                return;
        }
        
        PiggyBankRaidEventHandler.HandleDeeplinkShowRaid();
    }
    public override void OnGameSceneBegan()
    {
        null = null;
        if(PiggyBankRaidEventHandler.isEventPopupQueued == false)
        {
                return;
        }
        
        PiggyBankRaidEventHandler.HandleDeeplinkShowRaid();
    }
    public static void HandleDeeplinkShowRaid()
    {
        UnityEngine.Object val_5;
        var val_6;
        bool val_7;
        val_6 = null;
        val_6 = null;
        if((PiggyBankRaidEventHandler.<Instance>k__BackingField) == null)
        {
            goto label_6;
        }
        
        val_5 = MonoSingleton<WGWindowManager>.Instance;
        if(val_5 != 0)
        {
            goto label_11;
        }
        
        val_6 = null;
        label_6:
        val_6 = null;
        val_7 = 1;
        goto label_14;
        label_11:
        GameBehavior val_3 = App.getBehavior;
        val_5 = val_3.<metaGameBehavior>k__BackingField;
        val_6 = null;
        val_6 = null;
        val_7 = false;
        label_14:
        PiggyBankRaidEventHandler.isEventPopupQueued = val_7;
    }
    public override void OnWordRegionLoaded()
    {
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        if(this.IsCurrentEventInCycle() == false)
        {
                return;
        }
        
        if(this.progressData.isMaxPiggyPurchased == true)
        {
                return;
        }
        
        if(PlayingLevel.CurrentGameplayMode != 1)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(CategoryPacksManager.IsPlaying != false)
        {
                return;
        }
        
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void PiggyBankRaidEventHandler::OnWordRegionWordFound(string wordCompleted)));
        this.LoadGameData();
    }
    public void DiscardOverflowAmount()
    {
        decimal val_1 = this.PiggyBankCoins;
        decimal val_3 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) == false)
        {
                return;
        }
        
        decimal val_6 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        this.PiggyBankCoins = new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid};
        this.UpdateProgressToServer();
    }
    public override void OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        var val_5 = this;
        if(this.IsTileCurrentlyInPlay == false)
        {
                return;
        }
        
        WordRegion val_2 = WordRegion.instance;
        if((this.progressData.currentLineWord & 2147483648) != 0)
        {
                return;
        }
        
        if(this.progressData.currentLineWord >= (X9 + 24))
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        PiggyBankRaidProgress val_5 = this.progressData;
        if(val_5 <= this.progressData.currentLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.progressData.currentLineWord) << 3);
        if(((this.progressData + (this.progressData.currentLineWord) << 3).player.avatarId.Equals(value:  wordEntered)) == false)
        {
                return;
        }
        
        mem2[0] = 1;
    }
    private void OnWordRegionWordFound(string wordCompleted)
    {
        var val_6;
        if(this.IsTileCurrentlyInPlay == false)
        {
                return;
        }
        
        if((this.progressData.currentLineWord & 2147483648) != 0)
        {
                return;
        }
        
        val_6 = WordRegion.instance;
        if(this.progressData.currentLineWord >= (X23 + 24))
        {
                return;
        }
        
        if((X23 + 24) <= this.progressData.currentLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = X23 + 16;
        val_5 = val_5 + ((this.progressData.currentLineWord) << 3);
        if(((X23 + 16 + (this.progressData.currentLineWord) << 3) + 32 + 24.Equals(value:  wordCompleted)) == true)
        {
            goto label_12;
        }
        
        PiggyBankRaidProgress val_6 = this.progressData;
        if(this.progressData.alternateLineWord == 1)
        {
            goto label_19;
        }
        
        if(val_6 <= this.progressData.alternateLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + ((this.progressData.alternateLineWord) << 3);
        if(((this.progressData + (this.progressData.alternateLineWord) << 3).player.avatarId.Equals(value:  wordCompleted)) == false)
        {
            goto label_19;
        }
        
        label_12:
        this.CollectTileObject();
        return;
        label_19:
        this.ShiftTileObject();
    }
    public override void OnSubmitWordWithHints(string word)
    {
        var val_5;
        if(this.IsTileCurrentlyInPlay == false)
        {
                return;
        }
        
        val_5 = WordRegion.instance;
        if((X22 + 24) <= this.progressData.currentLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = X22 + 16;
        val_5 = val_5 + ((this.progressData.currentLineWord) << 3);
        if(((X22 + 16 + (this.progressData.currentLineWord) << 3) + 32 + 24.Equals(value:  word)) != true)
        {
                PiggyBankRaidProgress val_6 = this.progressData;
            if(this.progressData.alternateLineWord == 1)
        {
                return;
        }
        
            if(val_6 <= this.progressData.alternateLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_6 = val_6 + ((this.progressData.alternateLineWord) << 3);
            if(((this.progressData + (this.progressData.alternateLineWord) << 3).player.avatarId.Equals(value:  word)) == false)
        {
                return;
        }
        
        }
        
        this.CollectTileObject();
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        UnityEngine.Object val_4;
        if(this.IsTileCurrentlyInPlay == false)
        {
                return;
        }
        
        WordRegion val_2 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        bool val_4 = static_value_02807010;
        val_4 = val_4 + ((this.progressData.currentLineWord) << 3);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        var val_5 = (static_value_02807010 + (this.progressData.currentLineWord) << 3) + 32 + 40 + 16;
        val_5 = val_5 + ((this.progressData.currentCell) << 3);
        val_4 = mem[((static_value_02807010 + (this.progressData.currentLineWord) << 3) + 32 + 40 + 16 + (this.progressData.currentCell) << 3) + 32];
        val_4 = ((static_value_02807010 + (this.progressData.currentLineWord) << 3) + 32 + 40 + 16 + (this.progressData.currentCell) << 3) + 32;
        if(hintedCell != val_4)
        {
                return;
        }
        
        this.ShiftTileObject();
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.currPurchasePoint = 101;
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public PiggyBankRaidPopup MetaGameBehavior::ShowUGUIMonolith<PiggyBankRaidPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void OnGameButtonPressed(bool connected)
    {
        this.currPurchasePoint = 102;
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public PiggyBankRaidPopup MetaGameBehavior::ShowUGUIMonolith<PiggyBankRaidPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override int GetMovingWordIndex()
    {
        if(this.IsTileCurrentlyInPlay == false)
        {
                return this.GetMovingWordIndex();
        }
        
        return (int)this.progressData.currentLineWord;
    }
    public PurchaseModel GetPiggyPurchaseModel()
    {
        int val_2 = UnityEngine.Mathf.Clamp(value:  this.PiggyBankLevel, min:  1, max:  5);
        return (PurchaseModel)new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  System.String.Format(format:  "id_piggybank_raid_{0}", arg0:  this.PiggyBankLevel)));
    }
    public void DoPurchasePiggyBank()
    {
        TrackerPurchasePoints val_10;
        var val_11;
        val_10 = this;
        if(this.PiggyBankLevel < 1)
        {
                return;
        }
        
        if(this.PiggyBankLevel > 5)
        {
                return;
        }
        
        if(this.IsPiggyBankFull() == false)
        {
                return;
        }
        
        if(this.progressData.isMaxPiggyPurchased == true)
        {
                return;
        }
        
        PurchaseModel val_7 = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  System.String.Format(format:  "id_piggybank_raid_{0}", arg0:  this.PiggyBankLevel)));
        decimal val_8 = this.PiggyBankCoins;
        val_7.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
        val_10 = this.currPurchasePoint;
        val_11 = null;
        val_11 = null;
        PurchaseProxy.currentPurchasePoint = val_10;
        bool val_9 = PurchaseProxy.Purchase(purchase:  val_7);
    }
    public PiggyBankRaidPlayerProfile CreateRandomDummyOpponent()
    {
        int val_2 = this.PiggyBankLevel + 1;
        RandomSet val_3 = new RandomSet();
        if(val_2 >= 1)
        {
                int val_16 = 1;
            do
        {
            if((this.econ.fakeOpponentBankLevelWeights.ContainsKey(key:  1)) != false)
        {
                val_3.add(item:  1, weight:  (float)this.econ.fakeOpponentBankLevelWeights.Item[1]);
        }
        
            val_16 = val_16 + 1;
        }
        while(val_16 <= val_2);
        
        }
        
        int val_6 = val_3.roll(unweighted:  false);
        decimal val_8 = this.econ.bankMaxCoins.Item[val_6];
        val_8.lo = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid})) + 1;
        decimal val_11 = System.Decimal.op_Implicit(value:  UnityEngine.Random.Range(min:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.econ.minimumRaidableCoins, hi = this.econ.minimumRaidableCoins, lo = val_16, mid = val_16}), max:  val_8.lo));
        decimal val_12 = this.GenerateRandomRaidableCoins(coinUpperLimit:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
        .isDummyAccount = true;
        .userId = "dummyId";
        .avatarId = SLC.Social.SocialManager.GetRandomAvatarID();
        .name = SLC.Social.SocialManager.GetRandomProfileName();
        .bankLevel = val_6;
        .coins = val_12;
        mem[1152921516578634084] = val_12.lo;
        mem[1152921516578634088] = val_12.mid;
        return (PiggyBankRaidPlayerProfile)new PiggyBankRaidPlayerProfile();
    }
    public decimal GetPiggyBankOverflowAmount()
    {
        decimal val_6;
        var val_7;
        var val_8;
        decimal val_2 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        decimal val_3 = this.PiggyBankCoins;
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        val_6 = val_4.flags;
        val_7 = val_4.lo;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
                return new System.Decimal() {flags = val_6, hi = val_6, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10};
        }
        
        val_8 = null;
        val_8 = null;
        val_6 = System.Decimal.Zero;
        return new System.Decimal() {flags = val_6, hi = val_6, lo = System.Decimal.Powers10.__il2cppRuntimeField_10, mid = System.Decimal.Powers10.__il2cppRuntimeField_10};
    }
    public bool IsPiggyBankFull()
    {
        decimal val_1 = this.PiggyBankCoins;
        decimal val_3 = this.econ.bankMaxCoins.Item[this.PiggyBankLevel];
        return System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
    }
    public decimal GenerateRandomRaidableCoins(decimal coinUpperLimit)
    {
        decimal val_1 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = coinUpperLimit.flags, hi = coinUpperLimit.hi, lo = coinUpperLimit.lo, mid = coinUpperLimit.mid}, d2:  new System.Decimal() {flags = this.econ.minimumRaidableCoins, hi = this.econ.minimumRaidableCoins, lo = 41971712});
        decimal val_2 = System.Decimal.op_Implicit(value:  20);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        int val_4 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        val_4 = (val_4 + (val_4 << 2)) << 2;
        decimal val_6 = System.Decimal.op_Implicit(value:  val_4);
        return System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.econ.minimumRaidableCoins, hi = this.econ.minimumRaidableCoins, lo = val_1.flags, mid = val_1.hi}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
    }
    public System.Collections.Generic.List<System.Decimal> GeneratePickerOptionsFromCoins(decimal coins)
    {
        int val_13;
        decimal val_14;
        System.Collections.Generic.IList<T> val_15;
        var val_16;
        val_13 = coins.lo;
        val_14 = this.econ.minimumRaidableCoins;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = coins.flags, hi = coins.hi, lo = val_13, mid = coins.mid}, d2:  new System.Decimal() {flags = val_14, hi = val_14, lo = 41971712})) != false)
        {
                val_13 = "Cannot generate raid picker options from amount less than minimum raidable: "("Cannot generate raid picker options from amount less than minimum raidable: ") + coins;
            UnityEngine.Debug.LogError(message:  val_13);
            val_15 = 0;
            return (System.Collections.Generic.List<System.Decimal>)val_15;
        }
        
        System.Collections.Generic.List<System.Decimal> val_3 = null;
        val_15 = val_3;
        val_3 = new System.Collections.Generic.List<System.Decimal>();
        val_16 = null;
        val_16 = null;
        val_3.Add(item:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        if(this.econ == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        decimal val_4 = System.Decimal.op_Explicit(value:  this.econ.bankPriceTier);
        decimal val_5 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = coins.flags, hi = coins.hi, lo = val_13, mid = coins.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        decimal val_6 = System.Math.Round(d:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, mode:  1);
        val_3.Add(item:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        val_14 = this.econ.raidOptionMultiplier;
        if(this.econ <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        decimal val_7 = System.Decimal.op_Explicit(value:  this.econ.bankPriceTier);
        decimal val_8 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = coins.flags, hi = coins.hi, lo = val_13, mid = coins.mid}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        decimal val_9 = System.Math.Round(d:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, mode:  1);
        val_3.Add(item:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
        if(this.econ <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        decimal val_10 = System.Decimal.op_Explicit(value:  this.econ.raidOptionMultiplier);
        decimal val_11 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = coins.flags, hi = coins.hi, lo = val_13, mid = coins.mid}, d2:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
        decimal val_12 = System.Math.Round(d:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, mode:  1);
        val_3.Add(item:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid});
        PluginExtension.Shuffle<System.Decimal>(list:  val_3, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        return (System.Collections.Generic.List<System.Decimal>)val_15;
    }
    public void UpdateProgressToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "level", value:  this.PiggyBankLevel);
        decimal val_3 = this.PiggyBankCoins;
        val_1.Add(key:  "coins", value:  val_3);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    public System.Collections.Generic.List<PiggyBankRaidNewsArticle> GetRaidNews()
    {
        if(this.progressData != null)
        {
                return (System.Collections.Generic.List<PiggyBankRaidNewsArticle>)this.progressData.raidNewsList;
        }
        
        throw new NullReferenceException();
    }
    private bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48})) == false)
        {
                return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = System.DateTime.__il2cppRuntimeField_cctor_finished + 40});
        }
        
        return true;
    }
    private bool IsCurrentEventInCycle()
    {
        return (bool)(this.progressData.eventId == (X9 + 56)) ? 1 : 0;
    }
    public bool IsEventCompleted()
    {
        if(this.progressData != null)
        {
                return (bool)this.progressData.isMaxPiggyPurchased;
        }
        
        throw new NullReferenceException();
    }
    private void ParsePlayerProgressFromServer(System.Collections.Generic.Dictionary<string, object> eventDataDict)
    {
        var val_33;
        var val_34;
        string val_35;
        var val_36;
        int val_37;
        int val_38;
        int val_39;
        val_34 = this;
        if(eventDataDict == null)
        {
                return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                this.debugLastPayLoad = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_35 = 1152921510222861648;
            if((eventDataDict.ContainsKey(key:  "coins")) != false)
        {
                this.debugLastPayLoad.Add(key:  "coins", value:  eventDataDict.Item["coins"]);
        }
        
            if((eventDataDict.ContainsKey(key:  "progress")) != false)
        {
                this.debugLastPayLoad.Add(key:  "progress", value:  eventDataDict.Item["progress"]);
        }
        
        }
        
        if((eventDataDict.ContainsKey(key:  "coins")) != false)
        {
                val_35 = eventDataDict.Item["coins"];
            if((System.Decimal.TryParse(s:  val_35, result: out  new System.Decimal())) != false)
        {
                decimal val_11 = System.Math.Min(val1:  new System.Decimal() {flags = this.progressData.player.coins, hi = this.progressData.player.coins, lo = X25, mid = X25}, val2:  new System.Decimal());
            this.progressData.player.coins = val_11;
            mem2[0] = val_11.lo;
            mem[4] = val_11.mid;
            val_35 = this.progressData.player.coins;
            val_36 = null;
            val_36 = null;
            if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_35, hi = val_35}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                mem2[0] = 0;
            this.progressData.player.coins = 0m;
        }
        
            if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_35 = 0;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = this.progressData.player.coins, hi = this.progressData.player.coins, lo = X22, mid = X22}, d2:  new System.Decimal())) != false)
        {
                object[] val_16 = new object[7];
            val_35 = val_16;
            val_35[0] = "Value \'";
            val_37 = val_16.Length;
            val_35[1] = 0;
            val_37 = val_16.Length;
            val_35[2] = "\' from server, final coins: ";
            val_38 = val_16.Length;
            val_35[3] = this.progressData.player.coins;
            val_38 = val_16.Length;
            val_35[4] = " (Was: ";
            val_39 = val_16.Length;
            val_35[5] = this.progressData.player.coins;
            val_39 = val_16.Length;
            val_35[6] = ")";
            this.AddToCoinLog(logStr:  +val_16);
        }
        
        }
        
        }
        
        }
        
        val_33 = "progress";
        if((eventDataDict.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        object val_19 = eventDataDict.Item["progress"];
        if((val_19.ContainsKey(key:  "news")) != false)
        {
                this.ProcessRaidNews(news:  Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<PiggyBankRaidNewsArticle>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_19.Item["news"])));
        }
        
        val_33 = "level";
        if((val_19.ContainsKey(key:  "level")) != false)
        {
                if(((System.Int32.TryParse(s:  val_19.Item["level"], result: out  0)) != false) && (0 > this.progressData.player.bankLevel))
        {
                this.progressData.player.bankLevel = 0;
        }
        
        }
        
        val_34 = "cooldown_level";
        if((val_19.ContainsKey(key:  "cooldown_level")) == false)
        {
                return;
        }
        
        bool val_31 = System.Int32.TryParse(s:  val_19.Item["cooldown_level"], result: out  0);
    }
    private void SetupEvent()
    {
        if(true != 0)
        {
                this.econ = new PiggyBankRaidEcon(eventDataDict:  147633);
        }
        
        if(this.IsEventExpired() != true)
        {
                if(this.IsCurrentEventInCycle() == true)
        {
            goto label_4;
        }
        
        }
        
        this.progressData = new PiggyBankRaidProgress();
        this.ClearTileObject();
        label_4:
        if(this.IsEventExpired() != false)
        {
                return;
        }
        
        this.ParsePlayerProgressFromServer(eventDataDict:  System.Void System.Collections.Generic.Stack<System.Object>::ThrowForEmptyStack());
        this.progressData.eventId = public System.Void Mono.Security.X509.X509ExtensionCollection::Remove(Mono.Security.X509.X509Extension extension);
        goto typeof(PiggyBankRaidProgress).__il2cppRuntimeField_180;
    }
    private void LoadGameData()
    {
        int val_10;
        var val_11;
        PiggyBankRaidProgress val_19;
        PiggyBankRaidProgress val_20;
        int val_21;
        int val_22;
        var val_23;
        System.Predicate<LineWord> val_25;
        object val_26;
        val_19 = this;
        if(this.IsCurrentEventInCycle() == false)
        {
                return;
        }
        
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.progressData.isMaxPiggyPurchased == true)
        {
                return;
        }
        
        WordRegion val_2 = WordRegion.instance;
        val_19 = 0;
        val_20 = this.progressData;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_18 = this.progressData.currentAssociatedLevel;
        val_21 = PlayingLevel.GetCurrentPlayerLevelNumber();
        if(val_18 == 1)
        {
            goto label_9;
        }
        
        if((this.<QA_LevelBufferHack>k__BackingField) != false)
        {
                val_22 = 1;
        }
        else
        {
                if(this.econ == null)
        {
                throw new NullReferenceException();
        }
        
            val_22 = this.econ.levelBuffer;
        }
        
        val_18 = val_21 - val_18;
        if(val_18 < val_22)
        {
            goto label_13;
        }
        
        label_9:
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = null;
        val_23 = null;
        val_25 = PiggyBankRaidEventHandler.<>c.<>9__70_0;
        if(val_25 == null)
        {
                System.Predicate<LineWord> val_4 = null;
            val_26 = PiggyBankRaidEventHandler.<>c.__il2cppRuntimeField_static_fields;
            val_25 = val_4;
            val_4 = new System.Predicate<LineWord>(object:  val_26, method:  System.Boolean PiggyBankRaidEventHandler.<>c::<LoadGameData>b__70_0(LineWord x));
            PiggyBankRaidEventHandler.<>c.<>9__70_0 = val_25;
        }
        
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X22.Exists(match:  val_4)) == true)
        {
                return;
        }
        
        val_26 = 0;
        if(val_2.getAvailableLineIndices == null)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Boolean System.Collections.Generic.List<LineWord>::Exists(System.Predicate<T> match)) == 0)
        {
                return;
        }
        
        RandomSet val_7 = new RandomSet();
        val_26 = 0;
        System.Collections.Generic.List<System.Int32> val_8 = val_2.getAvailableLineIndices;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_9 = val_8.GetEnumerator();
        label_27:
        if(val_11.MoveNext() == false)
        {
            goto label_25;
        }
        
        val_7.add(item:  val_10, weight:  1f);
        goto label_27;
        label_25:
        val_26 = public System.Void List.Enumerator<System.Int32>::Dispose();
        val_11.Dispose();
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.currentAssociatedLevel = val_21;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = this.progressData;
        val_19 = val_7;
        val_26 = 0;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.currentLineWord = val_7.roll(unweighted:  false);
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.currentCell = 0;
        val_19 = this.progressData;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = this.progressData;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        label_13:
        if(this.progressData.currentAssociatedLevel == val_21)
        {
                val_21 = this.progressData.currentLineWord;
            if((val_21 & 2147483648) == 0)
        {
                if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_21 < this.progressData.isMaxPiggyPurchased) && ((this.progressData.currentCell & 2147483648) == 0))
        {
                if(this.progressData.isMaxPiggyPurchased <= val_21)
        {
                val_19 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            int val_19 = this.progressData.eventId;
            val_19 = val_19 + ((this.progressData.currentLineWord) << 3);
            if(((this.progressData.eventId + (this.progressData.currentLineWord) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            if(((this.progressData.eventId + (this.progressData.currentLineWord) << 3) + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
            if(this.progressData.currentCell < ((this.progressData.eventId + (this.progressData.currentLineWord) << 3) + 32 + 40 + 24))
        {
                PiggyBankRaidProgress val_20 = this.progressData;
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            val_21 = this.TilePrefab;
            if(val_20 <= this.progressData.currentLineWord)
        {
                val_19 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_20 = val_20 + ((this.progressData.currentLineWord) << 3);
            if(((this.progressData + (this.progressData.currentLineWord) << 3).player) == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
            if(((this.progressData + (this.progressData.currentLineWord) << 3).player.bankLevel) == 0)
        {
                throw new NullReferenceException();
        }
        
            if(((this.progressData + (this.progressData.currentLineWord) << 3).player.bankLevel + 24) <= this.progressData.currentCell)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_21 = (this.progressData + (this.progressData.currentLineWord) << 3).player.bankLevel + 16;
            val_21 = val_21 + ((this.progressData.currentCell) << 3);
            val_19 = mem[((this.progressData + (this.progressData.currentLineWord) << 3).player.bankLevel + 16 + (this.progressData.currentCell) << 3) + 32];
            val_19 = ((this.progressData + (this.progressData.currentLineWord) << 3).player.bankLevel + 16 + (this.progressData.currentCell) << 3) + 32;
            if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_26 = val_19.transform;
            this.currentTileObj = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_21, parent:  val_26);
        }
        
        }
        
        }
        
        }
        
        this.RetrieveRaidPool();
        val_19 = this;
        if(this.progressData == null)
        {
                throw new NullReferenceException();
        }
        
        this.progressData.alternateLineWord = this.FindAlternateLineWord();
    }
    private void CollectTileObject()
    {
        if(this.IsTileCurrentlyInPlay == false)
        {
                return;
        }
        
        if(this.currentTileObj == 0)
        {
                return;
        }
        
        WordRegion.instance.AddLevelCompleteBlocker(blocker:  1);
        MonoSingleton<ScreenOverlay>.Instance.ToggleDarkener(state:  true, animated:  true, duration:  0.1f);
        this.currentTileObj.transform.SetParent(p:  MonoSingleton<ScreenOverlay>.Instance.transform);
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  30f);
        this.collectTween = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.currentTileObj.transform, duration:  1.2f, strength:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, vibrato:  50, randomness:  90f, fadeOut:  true), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankRaidEventHandler::<CollectTileObject>b__71_0()));
    }
    private void ShiftTileObject()
    {
        System.Collections.Generic.List<Cell> val_10;
        System.Predicate<T> val_11;
        .<>4__this = this;
        WordRegion val_2 = WordRegion.instance;
        if(this.collectTween != null)
        {
                return;
        }
        
        if((X21 + 24) <= this.progressData.currentLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = X21 + 16;
        val_10 = val_10 + ((this.progressData.currentLineWord) << 3);
        .lineWordObj = (X21 + 16 + (this.progressData.currentLineWord) << 3) + 32;
        val_10 = mem[(X21 + 16 + (this.progressData.currentLineWord) << 3) + 32 + 40];
        val_10 = (X21 + 16 + (this.progressData.currentLineWord) << 3) + 32 + 40;
        System.Predicate<Cell> val_3 = new System.Predicate<Cell>(object:  new PiggyBankRaidEventHandler.<>c__DisplayClass72_0(), method:  System.Boolean PiggyBankRaidEventHandler.<>c__DisplayClass72_0::<ShiftTileObject>b__0(Cell x));
        val_11 = val_3;
        this.progressData.currentCell = val_10.FindIndex(match:  val_3);
        if((this.progressData.currentCell & 2147483648) == 0)
        {
                PiggyBankRaidProgress val_11 = this.progressData;
            val_10 = (PiggyBankRaidEventHandler.<>c__DisplayClass72_0)[1152921516581091712].lineWordObj.cells;
            if(val_11 <= this.progressData.currentCell)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + ((this.progressData.currentCell) << 3);
            this.currentTileObj.transform.SetParent(p:  (this.progressData + (this.progressData.currentCell) << 3).player.transform);
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.zero;
            val_11 = 0;
            this.currentTileObj.transform.localPosition = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        }
        else
        {
                this.ClearTileObject();
        }
        
        this.progressData.alternateLineWord = this.FindAlternateLineWord();
        goto typeof(PiggyBankRaidProgress).__il2cppRuntimeField_180;
    }
    private void ClearTileObject()
    {
        this.progressData.currentCell = 0;
        this.progressData.currentLineWord = -1;
        this.progressData.alternateLineWord = -1;
        UnityEngine.Object.Destroy(obj:  this.currentTileObj);
        this.currentTileObj = 0;
    }
    private int FindAlternateLineWord()
    {
        var val_4;
        var val_6;
        val_4 = null;
        val_4 = null;
        if((App.game != 4) || (this.IsTileCurrentlyInPlay == false))
        {
            goto label_19;
        }
        
        WordRegion val_2 = WordRegion.instance;
        if(mem[41963544] <= this.progressData.currentLineWord)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = mem[41963536];
        val_4 = val_4 + ((this.progressData.currentLineWord) << 3);
        if(((mem[41963536] + (this.progressData.currentLineWord) << 3) + 32 + 40 + 24) <= this.progressData.currentCell)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = (mem[41963536] + (this.progressData.currentLineWord) << 3) + 32 + 40 + 16;
        val_6 = 0;
        val_5 = val_5 + ((this.progressData.currentCell) << 3);
        label_26:
        var val_6 = X24 + 24;
        if(val_6 >= val_6)
        {
            goto label_19;
        }
        
        if(val_6 != this.progressData.currentLineWord)
        {
                val_6 = val_6 & 4294967295;
            if(val_6 >= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_7 = X24 + 16;
            val_7 = val_7 + 0;
            if(((X24 + 16 + 0) + 32 + 40.Contains(item:  ((mem[41963536] + (this.progressData.currentLineWord) << 3) + 32 + 40 + 16 + (this.progressData.currentCell) << 3) + 32)) == true)
        {
                return (int)val_6;
        }
        
        }
        
        val_6 = val_6 + 1;
        if(X24 != 0)
        {
            goto label_26;
        }
        
        throw new NullReferenceException();
        label_19:
        val_6 = 0;
        return (int)val_6;
    }
    private void OnRaidPickerPopupClose()
    {
        WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  1);
    }
    public System.DateTime GetLastProcessedNewsTimestamp()
    {
        var val_8;
        var val_9;
        if(true == 0)
        {
                string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wad_news_lastproc_ts", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
            
        }
        else
        {
                System.DateTime val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.DateTime>(value:  val_1);
            System.Nullable<System.DateTime> val_4 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = val_3.dateData});
            val_8 = 0;
            this.lastProcessedNewsTimestamp = val_4.HasValue;
            mem[1152921516581645136] = val_8;
        }
        
            if(val_8 == 255)
        {
                val_9 = null;
            val_9 = null;
            System.Nullable<System.DateTime> val_5 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = System.DateTime.MinValue});
            this.lastProcessedNewsTimestamp = val_5.HasValue;
        }
        
        }
        
        System.DateTime val_6 = this.lastProcessedNewsTimestamp.Value;
        return (System.DateTime)val_6.dateData;
    }
    public void SetLastProcessedNewsTimestamp(System.DateTime date)
    {
        System.Nullable<System.DateTime> val_1 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = date.dateData});
        this.lastProcessedNewsTimestamp = val_1.HasValue;
        mem[1152921516581769424] = 0;
        UnityEngine.PlayerPrefs.SetString(key:  "wad_news_lastproc_ts", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1.HasValue));
    }
    private void ProcessRaidNews(System.Collections.Generic.List<PiggyBankRaidNewsArticle> news)
    {
        System.Comparison<PiggyBankRaidNewsArticle> val_9;
        ulong val_10;
        var val_11;
        var val_14;
        var val_15;
        PiggyBankRaidProgress val_16;
        var val_17;
        if(news == null)
        {
                return;
        }
        
        if(true < 1)
        {
                return;
        }
        
        val_10 = 1152921504928464896;
        val_11 = null;
        val_11 = null;
        val_9 = PiggyBankRaidEventHandler.<>c.<>9__78_0;
        if(val_9 == null)
        {
                System.Comparison<PiggyBankRaidNewsArticle> val_1 = null;
            val_9 = val_1;
            val_1 = new System.Comparison<PiggyBankRaidNewsArticle>(object:  PiggyBankRaidEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 PiggyBankRaidEventHandler.<>c::<ProcessRaidNews>b__78_0(PiggyBankRaidNewsArticle a, PiggyBankRaidNewsArticle b));
            PiggyBankRaidEventHandler.<>c.<>9__78_0 = val_9;
        }
        
        news.Sort(comparison:  val_1);
        System.DateTime val_2 = this.GetLastProcessedNewsTimestamp();
        val_14 = 44449503;
        if(true >= 0)
        {
                val_9 = val_2.dateData;
            if(1152921516581875760 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_10 = mem[mem[400045560] + 56];
            val_10 = mem[400045560] + 56;
            if((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_10}, t2:  new System.DateTime() {dateData = val_9})) >= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = mem[(System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32];
            val_10 = (System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32;
            if((System.String.IsNullOrEmpty(value:  (System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32 + 24)) != false)
        {
                val_15 = 1;
        }
        else
        {
                val_15 = (System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32 + 24.Contains(value:  "dummy");
        }
        
            val_16 = this.progressData;
            if(this.progressData.raidNewsList == null)
        {
                this.progressData.raidNewsList = new System.Collections.Generic.List<PiggyBankRaidNewsArticle>();
            val_16 = this.progressData;
        }
        
            this.progressData.raidNewsList.Add(item:  val_10);
            if(val_15 != true)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_7.Add(key:  "Amount", value:  (System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32 + 36);
            val_7.Add(key:  "Current Piggy Bank", value:  this.progressData.player.coins);
            val_7.Add(key:  "Raider ID", value:  (System.DateTime.__il2cppRuntimeField_cctor_finished + 355596024) + 32 + 24);
            val_17 = null;
            val_17 = null;
            App.trackerManager.track(eventName:  "Raided", data:  val_7);
        }
        
        }
        
            val_14 = 44449502;
        }
        
        if("Raided" == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.SetLastProcessedNewsTimestamp(date:  new System.DateTime() {dateData = public System.Boolean System.Nullable<System.Runtime.Serialization.StreamingContext>::get_HasValue().__il2cppRuntimeField_38});
    }
    private string GetPlatformId()
    {
        return "a";
    }
    private void RetrieveRaidPool()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "bucket", value:  val_2.playerBucket);
        Player val_3 = App.Player;
        val_1.Add(key:  "user_id", value:  val_3.id);
        val_1.Add(key:  "p", value:  "a");
        decimal val_4 = this.PiggyBankCoins;
        val_1.Add(key:  "coins", value:  val_4);
        this.cachedOpponentPool.Clear();
        this.cachedOpponentPool.Add(item:  this.CreateRandomDummyOpponent());
        MonoSingleton<GameEventsManager>.Instance.GetCustomData(eventId:  -1940626368, urlSubPath:  "raid_pool", data:  val_1, onResponse:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void PiggyBankRaidEventHandler::<RetrieveRaidPool>b__80_0(System.Collections.Generic.Dictionary<string, object> resp)));
    }
    public void SendRaidResultToServer(decimal amountStolen)
    {
        object val_7;
        var val_8;
        if(((this.currentOpponent != null) && (this.currentOpponent.isDummyAccount != true)) && ((this.currentOpponent.<autoCreated>k__BackingField) != true))
        {
                if((System.String.IsNullOrEmpty(value:  this.currentOpponent.userId)) == false)
        {
            goto label_4;
        }
        
        }
        
        val_7 = 1152921504884002816;
        val_8 = null;
        val_8 = null;
        if(Logger.GameEvents == false)
        {
                return;
        }
        
        val_7 = "[RaidEvent] Raid result of " + amountStolen + " coins not sent as opponent isn\'t real/valid."(" coins not sent as opponent isn\'t real/valid.");
        Logger.Warn(message:  val_7);
        return;
        label_4:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_4 = App.Player;
        val_3.Add(key:  "bucket", value:  val_4.playerBucket);
        Player val_5 = App.Player;
        val_3.Add(key:  "user_id", value:  val_5.id);
        val_3.Add(key:  "p", value:  "a");
        val_3.Add(key:  "receiver_id", value:  this.currentOpponent.userId);
        val_3.Add(key:  "coins", value:  amountStolen);
        MonoSingleton<GameEventsManager>.Instance.PostCustomData(eventId:  -1940626368, urlSubPath:  "raid", data:  val_3, onResponse:  0);
    }
    public void AddToCoinLog(string logStr)
    {
        System.Collections.Generic.List<System.String> val_13;
        int val_14;
        int val_15;
        System.Collections.Generic.List<System.String> val_16;
        if(this.debugCoinChangeLog == null)
        {
                string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbr_db_coinlog", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
                System.Collections.Generic.List<System.String> val_3 = null;
            val_13 = val_3;
            val_3 = new System.Collections.Generic.List<System.String>();
        }
        else
        {
                val_13 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  val_1);
        }
        
            this.debugCoinChangeLog = val_13;
            if(val_13 == null)
        {
                this.debugCoinChangeLog = new System.Collections.Generic.List<System.String>();
        }
        
        }
        
        System.DateTime val_6 = System.DateTime.Now;
        string[] val_7 = new string[6];
        val_7[0] = "[";
        val_14 = val_7.Length;
        val_7[1] = val_6.dateData.ToShortDateString();
        val_14 = val_7.Length;
        val_7[2] = " ";
        val_15 = val_7.Length;
        val_7[3] = val_6.dateData.ToShortTimeString();
        val_15 = val_7.Length;
        val_7[4] = "] ";
        if(logStr != null)
        {
                val_15 = val_7.Length;
        }
        
        val_7[5] = logStr;
        this.debugCoinChangeLog.Add(item:  +val_7);
        val_16 = this.debugCoinChangeLog;
        if(this.debugCoinChangeLog >= 26)
        {
                val_16.RemoveAt(index:  0);
            val_16 = this.debugCoinChangeLog;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "pbr_db_coinlog", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_16));
    }
    public string GetCoinLog()
    {
        System.Collections.Generic.List<System.String> val_11;
        var val_12;
        if(this.debugCoinChangeLog == null)
        {
                string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbr_db_coinlog", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
                System.Collections.Generic.List<System.String> val_3 = null;
            val_11 = val_3;
            val_3 = new System.Collections.Generic.List<System.String>();
        }
        else
        {
                System.Collections.Generic.List<System.String> val_4 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  val_1);
            val_11 = val_4;
        }
        
            this.debugCoinChangeLog = val_11;
            if(val_11 == null)
        {
                val_4 = new System.Collections.Generic.List<System.String>();
            this.debugCoinChangeLog = val_4;
        }
        
        }
        
        System.Text.StringBuilder val_5 = new System.Text.StringBuilder();
        List.Enumerator<T> val_6 = this.debugCoinChangeLog.GetEnumerator();
        label_10:
        val_12 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_8 = val_5.AppendLine(value:  0);
        goto label_10;
        label_8:
        0.Dispose();
        return (string)val_5;
    }
    public string get_QA_RaidPoolIds()
    {
        int val_5;
        int val_6;
        var val_7;
        var val_6 = 0;
        label_22:
        if(val_6 >= "")
        {
                return "";
        }
        
        if(val_6 >= 44273376)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(as. 
           
           
          
        
        
        
         == 0)
        {
            goto label_4;
        }
        
        object[] val_1 = new object[4];
        label_24:
        label_25:
        val_5 = val_1.Length;
        val_1[0] = "EE0000";
        val_5 = val_1.Length;
        val_1[1] = null;
        val_6 = val_1.Length;
        val_1[2] = public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current().__il2cppRuntimeField_28;
        System.Collections.Generic.List<PiggyBankRaidPlayerProfile> val_5 = this.cachedOpponentPool;
        val_5 = val_5 - 1;
        val_7 = "\n";
        if(System.String.__il2cppRuntimeField_static_fields != 0)
        {
                val_6 = val_1.Length;
        }
        
        val_1[3] = System.String.__il2cppRuntimeField_static_fields;
        string val_3 = "" + System.String.Format(format:  "<color=#{0}>{1}: piggy lvl {2}</color>{3}", args:  val_1)(System.String.Format(format:  "<color=#{0}>{1}: piggy lvl {2}</color>{3}", args:  val_1));
        label_4:
        val_6 = val_6 + 1;
        if(this.cachedOpponentPool != null)
        {
            goto label_22;
        }
        
        if((System.String.IsNullOrEmpty(value:  public CreatorPropertyContext List.Enumerator<CreatorPropertyContext>::get_Current().__il2cppRuntimeField_10)) == true)
        {
            goto label_24;
        }
        
        goto label_25;
    }
    public bool get_QA_LevelBufferHack()
    {
        return (bool)this.<QA_LevelBufferHack>k__BackingField;
    }
    public void set_QA_LevelBufferHack(bool value)
    {
        this.<QA_LevelBufferHack>k__BackingField = value;
    }
    public bool get_QA_NextPiggyCreditFillExactlyMax()
    {
        return (bool)this.<QA_NextPiggyCreditFillExactlyMax>k__BackingField;
    }
    public void set_QA_NextPiggyCreditFillExactlyMax(bool value)
    {
        this.<QA_NextPiggyCreditFillExactlyMax>k__BackingField = value;
    }
    public PiggyBankRaidEventHandler()
    {
        this.econ = new PiggyBankRaidEcon();
        this.progressData = new PiggyBankRaidProgress();
        this.cachedOpponentPool = new System.Collections.Generic.List<PiggyBankRaidPlayerProfile>();
        this.debugLastPayLoad = new System.Collections.Generic.Dictionary<System.String, System.Object>();
    }
    private static PiggyBankRaidEventHandler()
    {
    
    }
    private void <CollectTileObject>b__71_0()
    {
        MonoSingleton<ScreenOverlay>.Instance.ToggleDarkener(state:  false, animated:  false, duration:  0.4f);
        this.ClearTileObject();
        int val_2 = UnityEngine.Random.Range(min:  0, max:  typeof(PiggyBankRaidProgress).__il2cppRuntimeField_188>>0&0xFFFFFFFF);
        if(null <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        PiggyBankRaidProgress val_3 = 1152921504928251904 + (val_2 << 3);
        this.currentOpponent = (1152921504928251904 + (val_2) << 3).player;
        GameBehavior val_4 = App.getBehavior;
        val_4.<metaGameBehavior>k__BackingField.Initialize(opponent:  this.currentOpponent, onClose:  new System.Action(object:  this, method:  System.Void PiggyBankRaidEventHandler::OnRaidPickerPopupClose()));
        this.collectTween = 0;
    }
    private void <RetrieveRaidPool>b__80_0(System.Collections.Generic.Dictionary<string, object> resp)
    {
        var val_5;
        var val_10;
        var val_11;
        System.Collections.Generic.List<PiggyBankRaidPlayerProfile> val_12;
        val_10 = "pool";
        if((resp.ContainsKey(key:  "pool")) == false)
        {
                return;
        }
        
        this.cachedOpponentPool.Clear();
        List.Enumerator<T> val_3 = resp.Item["pool"].GetEnumerator();
        val_10 = 1152921510211410768;
        label_13:
        val_11 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_7;
        }
        
        PiggyBankRaidPlayerProfile val_7 = new PiggyBankRaidPlayerProfile();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = 0;
        val_12 = this.cachedOpponentPool;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(item:  val_7);
        goto label_13;
        label_7:
        val_5.Dispose();
    }

}
