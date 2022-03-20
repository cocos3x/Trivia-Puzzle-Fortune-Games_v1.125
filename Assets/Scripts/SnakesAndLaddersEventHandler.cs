using UnityEngine;
public class SnakesAndLaddersEventHandler : WGEventHandler
{
    // Fields
    public const string SNAKES_AND_LADDERS_EVENT_ID = "SnakesAndLadders";
    private static SnakesAndLaddersEventHandler <Instance>k__BackingField;
    private SnakesAndLaddersEvent.EventProgress eventProgress;
    private UnityEngine.GameObject diceRoll;
    private UnityEngine.GameObject eventButtonGO;
    private System.Action<bool, PurchaseModel> onPurchaseComplete;
    
    // Properties
    public static SnakesAndLaddersEventHandler Instance { get; set; }
    public static int CurrentDiceRollsOnEvent { get; }
    public bool IsDiceRollShownThisLevel { get; }
    public bool IsDiceRollCollectedThisLevel { get; }
    private UnityEngine.GameObject DiceRollPrefab { get; }
    private LineWord CurrentDiceRollWord { get; }
    private Cell CurrentDiceRollCell { get; }
    public override bool OverrideEventButton { get; }
    
    // Methods
    public static SnakesAndLaddersEventHandler get_Instance()
    {
        return (SnakesAndLaddersEventHandler)SnakesAndLaddersEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(SnakesAndLaddersEventHandler value)
    {
        SnakesAndLaddersEventHandler.<Instance>k__BackingField = value;
    }
    public static int get_CurrentDiceRollsOnEvent()
    {
        SnakesAndLaddersEventHandler val_3;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_3 = SnakesAndLaddersEventHandler.<Instance>k__BackingField;
            if(val_3 == null)
        {
                return (int)val_3;
        }
        
            if(((val_3 & 1) == 0) && (null != 0))
        {
                return (int)val_3;
        }
        
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public bool get_IsDiceRollShownThisLevel()
    {
        return (bool)(this.eventProgress.DiceRollProgress.LastLevel == App.Player) ? 1 : 0;
    }
    public bool get_IsDiceRollCollectedThisLevel()
    {
        return (bool)this.eventProgress.DiceRollProgress.IsCollected;
    }
    private UnityEngine.GameObject get_DiceRollPrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "dice_roll");
    }
    private LineWord get_CurrentDiceRollWord()
    {
        WordRegion val_1 = WordRegion.instance;
        SnakesAndLaddersEvent.MovingDiceRollProgress val_2 = this.eventProgress.DiceRollProgress;
        if(val_2 <= this.eventProgress.DiceRollProgress.LinewordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.eventProgress.DiceRollProgress.LinewordIndex) << 3);
        return 0;
    }
    private Cell get_CurrentDiceRollCell()
    {
        LineWord val_1 = this.CurrentDiceRollWord;
        SnakesAndLaddersEvent.MovingDiceRollProgress val_2 = this.eventProgress.DiceRollProgress;
        if(val_2 <= this.eventProgress.DiceRollProgress.CellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.eventProgress.DiceRollProgress.CellIndex) << 3);
        return 0;
    }
    public override void Init(GameEventV2 eventV2)
    {
        SnakesAndLaddersEventHandler.<Instance>k__BackingField = this;
        mem[1152921516707012784] = eventV2;
        this.RefreshEventData(data:  eventV2.eventData);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(eventV2 != null)
        {
                this.RefreshEventData(data:  eventV2.eventData);
            return;
        }
        
        throw new NullReferenceException();
    }
    public override bool IsEventEndedOffline()
    {
        System.TimeSpan val_1 = this.GetTimeLeft();
        return (bool)(val_1._ticks.TotalSeconds <= 0f) ? 1 : 0;
    }
    public override void OnWordRegionLoaded()
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        WGEventButton_Game val_4 = UnityEngine.Object.FindObjectOfType<WGEventButton_Game>();
        this.eventButtonGO = val_4.event_button.gameObject;
        this.ShowDiceRoll();
    }
    public override void OnValidWordSubmitted(string word)
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.IsReadyToCollectDiceRoll() == false)
        {
                return;
        }
        
        this.OnWordSubmitted(word:  word);
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.IsReadyToCollectDiceRoll() == false)
        {
                return;
        }
        
        LineWord val_5 = this.CurrentDiceRollWord;
        if((System.String.op_Inequality(a:  word, b:  val_5.answer)) == true)
        {
                return;
        }
        
        Cell val_7 = this.CurrentDiceRollCell;
        if((System.String.op_Inequality(a:  hintedCell.letter, b:  val_7.letter)) != false)
        {
                return;
        }
        
        this.ShiftDiceRoll();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        this.eventProgress.DiceRollProgress.IsMissed = false;
        this.eventProgress.DiceRollProgress.IsCollected = false;
        goto typeof(SnakesAndLaddersEvent.EventProgress).__il2cppRuntimeField_180;
    }
    public override int LastProgressTimestamp()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.LastProgressTimestamp;
        }
        
        throw new NullReferenceException();
    }
    public override void UpdateProgress()
    {
        this.eventProgress.LastProgressTimestamp = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool EventCompleted()
    {
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 504464731990392832})) != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28});
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28})) == false)
        {
                return false;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_5.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48});
    }
    public override string GetMainMenuButtonText()
    {
        goto typeof(SnakesAndLaddersEventHandler).__il2cppRuntimeField_350;
    }
    public override string GetGameButtonText()
    {
        return (string)this.eventProgress.DiceBalance.ToString();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "snakes_and_ladders_upper", defaultValue:  "SNAKES & LADDERS", useSingularKey:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
            
        }
        else
        {
                this.ShowBoardPopup();
        }
    
    }
    public override bool get_OverrideEventButton()
    {
        return true;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
            
        }
        else
        {
                this.ShowBoardPopup();
        }
    
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        PrefabsFromFolder val_6 = loader;
        if((this & 1) != 0)
        {
                return;
        }
        
        val_6 = val_6.LoadStrictlyTypeNamedPrefab<EventListItemContentSnakesAndLadders>(allowMultiple:  false);
        val_6.SetupDiceBalance(balance:  this.eventProgress.DiceBalance);
        float val_3 = this.GetCurrentBoard().GetPercentProgress();
        float val_6 = 100f;
        val_6 = val_3 * val_6;
        val_6.SetupSlider(sliderText:  System.String.Format(format:  "{0}%", arg0:  (int)(val_6 == Infinityf) ? (-(double)val_6) : ((double)val_6)), sliderValue:  val_3);
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        var val_4;
        decimal val_1 = purchase.DiceRolls;
        val_4 = null;
        val_4 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        if((purchase.id.Contains(value:  "starter_dice_pack")) != false)
        {
                this.OnPurchaseSuccess(purchase:  purchase);
        }
    
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "starter_dice_pack")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail(purchase:  purchase);
    }
    public override int GetMovingWordIndex()
    {
        if(this.eventProgress.DiceRollProgress.LastLevel != App.Player)
        {
                return this.GetMovingWordIndex();
        }
        
        if(this.eventProgress.DiceRollProgress.IsCollected == false)
        {
                return (int)this.eventProgress.DiceRollProgress.LinewordIndex;
        }
        
        return this.GetMovingWordIndex();
    }
    public SnakesAndLaddersEvent.BoardSpaceReward GetBoardSpaceReward()
    {
        var val_3;
        var val_4;
        var val_12;
        var val_13;
        var val_15;
        System.Collections.Generic.List<GiftRewardAmountChance> val_16;
        var val_17;
        RandomSet val_1 = new RandomSet();
        if((((mem[(RandomSet)[1152921516709653760]..ctor() + 303]) & 2) != 0) && ((mem[(RandomSet)[1152921516709653760]..ctor() + 224]) == 0))
        {
                val_12 = null;
        }
        
        List.Enumerator<T> val_2 = SnakesAndLaddersEvent.Econ.BoardSpaceRewardTypeChancesData.GetEnumerator();
        label_7:
        val_13 = public System.Boolean List.Enumerator<GiftRewardTypeChance>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.add(item:  val_3 + 16, weight:  (float)val_3 + 20);
        goto label_7;
        label_4:
        val_4.Dispose();
        object val_9 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_1.roll(unweighted:  false).ToString());
        val_13 = null;
        if(null == 5)
        {
            goto label_15;
        }
        
        if(null == 4)
        {
            goto label_16;
        }
        
        if(null != null)
        {
            goto label_17;
        }
        
        val_15 = null;
        val_15 = null;
        val_16 = 1152921505019043864;
        goto label_23;
        label_16:
        val_15 = null;
        val_15 = null;
        val_16 = 1152921505019043872;
        goto label_23;
        label_15:
        val_15 = null;
        val_15 = null;
        val_16 = 1152921505019043880;
        label_23:
        val_17 = GetRewardByAmountChance(rewards:  val_16);
        return (SnakesAndLaddersEvent.BoardSpaceReward)new SnakesAndLaddersEvent.BoardSpaceReward(type:  1152921504626761728, reward:  0);
        label_17:
        val_17 = 0;
        return (SnakesAndLaddersEvent.BoardSpaceReward)new SnakesAndLaddersEvent.BoardSpaceReward(type:  1152921504626761728, reward:  0);
    }
    public int GetDiceBalance()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.DiceBalance;
        }
        
        throw new NullReferenceException();
    }
    public SnakesAndLaddersEvent.DiceRollResult GetDiceRollResult()
    {
        int val_9;
        .result = new SnakesAndLaddersEvent.DiceRollResult();
        .Point = UnityEngine.Random.Range(min:  1, max:  7);
        (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard = this.GetCurrentBoard();
        (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.StartSpace = (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard.CurrentNumberSpace;
        (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.EndSpace = UnityEngine.Mathf.Min(a:  ((SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.Point) + ((SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard.CurrentNumberSpace), b:  (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard.Definition.MaxSpaceCount);
        SnakesAndLaddersEvent.BoardSpace val_8 = (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard.Definition.BoardSpaces.Find(match:  new System.Predicate<SnakesAndLaddersEvent.BoardSpace>(object:  new SnakesAndLaddersEventHandler.<>c__DisplayClass44_0(), method:  System.Boolean SnakesAndLaddersEventHandler.<>c__DisplayClass44_0::<GetDiceRollResult>b__0(SnakesAndLaddersEvent.BoardSpace x)));
        val_9 = val_8.NumberConnected;
        if(val_9 != 1)
        {
                if(((SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result) != null)
        {
            goto label_17;
        }
        
        }
        
        val_9 = (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.EndSpace;
        label_17:
        (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.FinalSpace = val_9;
        (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.CurrentBoard.CurrentNumberSpace = (SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result.FinalSpace;
        return (SnakesAndLaddersEvent.DiceRollResult)(SnakesAndLaddersEventHandler.<>c__DisplayClass44_0)[1152921516709991424].result;
    }
    public System.Collections.Generic.List<SnakesAndLaddersEvent.Board> GetAllBoards()
    {
        if(this.eventProgress != null)
        {
                return (System.Collections.Generic.List<SnakesAndLaddersEvent.Board>)this.eventProgress.Boards;
        }
        
        throw new NullReferenceException();
    }
    public SnakesAndLaddersEvent.Board GetCurrentBoard()
    {
        System.Collections.Generic.List<SnakesAndLaddersEvent.Board> val_3;
        var val_4;
        System.Predicate<SnakesAndLaddersEvent.Board> val_6;
        System.Collections.Generic.List<SnakesAndLaddersEvent.Board> val_7;
        val_3 = this;
        val_4 = null;
        val_4 = null;
        val_6 = SnakesAndLaddersEventHandler.<>c.<>9__46_0;
        if(val_6 == null)
        {
                System.Predicate<SnakesAndLaddersEvent.Board> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Predicate<SnakesAndLaddersEvent.Board>(object:  SnakesAndLaddersEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SnakesAndLaddersEventHandler.<>c::<GetCurrentBoard>b__46_0(SnakesAndLaddersEvent.Board x));
            SnakesAndLaddersEventHandler.<>c.<>9__46_0 = val_6;
        }
        
        if((this.eventProgress.Boards.Find(match:  val_1)) != null)
        {
                return (SnakesAndLaddersEvent.Board)val_7;
        }
        
        val_3 = this.eventProgress.Boards;
        if(this.eventProgress == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = this.eventProgress.Boards;
        return (SnakesAndLaddersEvent.Board)val_7;
    }
    public int GetCurrentBoardIndex()
    {
        return this.eventProgress.Boards.FindIndex(match:  new System.Predicate<SnakesAndLaddersEvent.Board>(object:  this, method:  System.Boolean SnakesAndLaddersEventHandler::<GetCurrentBoardIndex>b__47_0(SnakesAndLaddersEvent.Board x)));
    }
    public PurchaseModel GetStarterDicePack()
    {
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  "id_starter_dice_pack");
        .price = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  ""))).LocalPrice;
        .sale_price = val_1.getFloat(key:  "sale_price", defaultValue:  0f);
        .targetSalePrice = val_1.getFloat(key:  "sale_price", defaultValue:  1f);
        return (PurchaseModel)new PurchaseModel(json:  val_1);
    }
    public bool IsOutOfDice()
    {
        if(this.eventProgress != null)
        {
                return (bool)(this.eventProgress.DiceBalance == 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public void OnDiceRollUsed()
    {
        int val_1 = this.eventProgress.DiceBalance;
        val_1 = val_1 - 1;
        this.eventProgress.DiceBalance = val_1;
        int val_2 = this.eventProgress.DiceRolled;
        val_2 = val_2 + 1;
        this.eventProgress.DiceRolled = val_2;
        goto typeof(SnakesAndLaddersEventHandler).__il2cppRuntimeField_2B0;
    }
    public void RewardDiceRolls(int amount, string source)
    {
        amount = this.eventProgress.DiceBalance + amount;
        this.eventProgress.DiceBalance = UnityEngine.Mathf.Max(a:  0, b:  amount);
        if((System.String.IsNullOrEmpty(value:  source)) == true)
        {
                return;
        }
        
        App.Player.TrackNonCoinReward(source:  source, subSource:  0, rewardType:  "Dice Rolls", rewardAmount:  amount.ToString(), additionalParams:  0);
    }
    public void ResetBoardProgress()
    {
        this.eventProgress.ResetBoardProgress();
        goto typeof(SnakesAndLaddersEvent.EventProgress).__il2cppRuntimeField_180;
    }
    public bool IsStarterPackActive()
    {
        bool val_3;
        val_3 = this.eventProgress.StarterPackStatus.IsShown;
        if(val_3 != false)
        {
                if(this.eventProgress.StarterPackStatus.IsPurchased != false)
        {
                val_3 = 0;
        }
        else
        {
                bool val_1 = this.eventProgress.StarterPackStatus.IsOutOfTime();
            val_3 = val_1 ^ 1;
        }
        
        }
        
        val_1 = val_3;
        return (bool)val_1;
    }
    public System.TimeSpan GetStarterPackTimeLeft()
    {
        return this.eventProgress.StarterPackStatus.GetTimeLeft();
    }
    public void TryPurchase(PurchaseModel purchase)
    {
        bool val_1 = PurchaseProxy.Purchase(purchase:  purchase);
    }
    public void MarkStarterPackPurchased()
    {
        this.eventProgress.StarterPackStatus.IsPurchased = true;
        goto typeof(SnakesAndLaddersEvent.EventProgress).__il2cppRuntimeField_180;
    }
    public void ShowStarterDicePackPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGStarterDicePackPopup MetaGameBehavior::ShowUGUIMonolith<WGStarterDicePackPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public void AddPurchaseCompleteListener(System.Action<bool, PurchaseModel> purchaseCompleteAction)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.onPurchaseComplete, b:  purchaseCompleteAction);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.onPurchaseComplete = val_1;
        return;
        label_2:
    }
    public void SaveState()
    {
        if(this.eventProgress != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public bool IsEligibleToShowStarterPack()
    {
        if(this.eventProgress.StarterPackStatus.IsShown == true)
        {
                return false;
        }
        
        this.eventProgress.StarterPackStatus.IsShown = true;
        System.DateTime val_1 = DateTimeCheat.Now;
        this.eventProgress.StarterPackStatus.StartTime = val_1;
        if(this.eventProgress.StarterPackStatus.IsPurchased != false)
        {
                return false;
        }
        
        bool val_2 = this.eventProgress.StarterPackStatus.IsOutOfTime();
        val_2 = (~val_2) & 1;
        return false;
    }
    public void OnDiceRollEndingAnimationFinished()
    {
        this.DestroyDiceRoll();
        goto typeof(SnakesAndLaddersEventHandler).__il2cppRuntimeField_2B0;
    }
    public void ShowBoardPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSnakesAndLaddersBoardPopup>(showNext:  true);
    }
    public void ShowDicePacksPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStore_DicePacksPopup>(showNext:  true);
    }
    private void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        bool val_1 = System.String.op_Inequality(a:  0, b:  "SnakesAndLadders");
        if(val_1 != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + "ptcps_req");
            return;
        }
        
        val_1.ParseEcon(data:  data);
        SnakesAndLaddersEvent.EventProgress val_3 = new SnakesAndLaddersEvent.EventProgress();
        this.eventProgress = val_3;
        val_3.Initialize();
        if(this.IsEventNewCycle() != false)
        {
                SnakesAndLaddersEvent.EventProgress val_5 = new SnakesAndLaddersEvent.EventProgress();
            this.eventProgress = val_5;
            val_5.Initialize();
            this.eventProgress.Timestamp = SnakesAndLaddersEvent.EventProgress.__il2cppRuntimeField_name;
        }
    
    }
    private void ParseEcon(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_11;
        var val_12;
        var val_13;
        val_11 = data;
        if(val_11 == null)
        {
                return;
        }
        
        if((val_11.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_11 = val_11.Item["economy"];
        if((val_11.ContainsKey(key:  "default_dice")) != false)
        {
                val_12 = null;
            val_12 = null;
            bool val_5 = System.Int32.TryParse(s:  val_11.Item["default_dice"], result: out  void* val_5 = SnakesAndLaddersEvent.Econ.__il2cppRuntimeField_static_fields);
        }
        
        if((val_11.ContainsKey(key:  "mo_interval")) == false)
        {
                return;
        }
        
        val_13 = null;
        val_13 = null;
        bool val_9 = System.Int32.TryParse(s:  val_11.Item["mo_interval"], result: out  1152921505019043844);
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress.Timestamp != (X9 + 16)) ? 1 : 0;
    }
    private bool IsReadyToCollectDiceRoll()
    {
        var val_3;
        if((this.eventProgress.DiceRollProgress.LastLevel == App.Player) && (this.eventProgress.DiceRollProgress.LinewordIndex != 1))
        {
                var val_2 = (this.eventProgress.DiceRollProgress.IsCollected == false) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    private bool IsEligibleToSpawnNewDiceRoll()
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = this;
        if(this.eventProgress.DiceRollProgress.LinewordIndex != 1)
        {
                val_4 = App.Player;
            val_5 = null;
            val_5 = null;
            var val_3 = ((val_4 - this.eventProgress.DiceRollProgress.LastLevel) >= SnakesAndLaddersEvent.Econ.DiceRollLevelInterval) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 1;
        return (bool)val_6;
    }
    private void ShowDiceRoll()
    {
        SnakesAndLaddersEvent.MovingDiceRollProgress val_13;
        if(this.eventProgress.DiceRollProgress.IsCollected == true)
        {
                return;
        }
        
        if(this.eventProgress.DiceRollProgress.IsMissed != false)
        {
                return;
        }
        
        if(App.Player == this.eventProgress.DiceRollProgress.LastLevel)
        {
                if(this.eventProgress.DiceRollProgress.LinewordIndex != 1)
        {
            goto label_11;
        }
        
        }
        
        if(this.IsEligibleToSpawnNewDiceRoll() == false)
        {
                return;
        }
        
        this.eventProgress.DiceRollProgress.LastLevel = App.Player;
        RandomSet val_4 = new RandomSet();
        System.Collections.Generic.List<System.Int32> val_6 = WordRegion.instance.getAvailableLineIndices;
        var val_13 = 0;
        WordRegion val_7 = WordRegion.instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_4.add(item:  ((X24 + 16 + ((WordRegion.__il2cppRuntimeField_cctor_finished + 0) + 32) << 3) + 32 + 56 + 0) + 32, weight:  1f);
        val_13 = val_13 + 1;
        if(val_4.count() == 0)
        {
                return;
        }
        
        val_13 = this.eventProgress.DiceRollProgress;
        this.eventProgress.DiceRollProgress.LinewordIndex = val_4.roll(unweighted:  false);
        LineWord val_10 = this.CurrentDiceRollWord;
        int val_14 = 0;
        label_46:
        if(val_14 >= val_10.cells)
        {
            goto label_40;
        }
        
        LineWord val_11 = this.CurrentDiceRollWord;
        val_13 = val_11.cells;
        if(val_10.cells <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_14 = val_14 + 1;
        if(this.CurrentDiceRollWord != null)
        {
            goto label_46;
        }
        
        this.eventProgress.DiceRollProgress.CellIndex = val_14;
        label_40:
        label_11:
        this.SpawnDiceRoll();
    }
    private void OnWordSubmitted(string word)
    {
        LineWord val_1 = this.CurrentDiceRollWord;
        if((val_1.answer.Equals(value:  word)) != false)
        {
                this.CollectDiceRoll();
            return;
        }
        
        this.ShiftDiceRoll();
    }
    private void ShiftDiceRoll()
    {
        WordRegion val_1 = WordRegion.instance;
        return;
        label_14:
        LineWord val_2 = this.CurrentDiceRollWord;
        System.Collections.Generic.List<Cell> val_7 = val_2.cells;
        if( >= val_7)
        {
            goto label_9;
        }
        
        LineWord val_3 = this.CurrentDiceRollWord;
        if(val_7 <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + ( << 3);
        int val_4 =  + 1;
        if(W9 != 0)
        {
            goto label_14;
        }
        
        label_9:
        LineWord val_5 = this.CurrentDiceRollWord;
        if( < val_5.cells)
        {
                this.eventProgress.DiceRollProgress.CellIndex = ;
            this.DestroyDiceRoll();
            this.SpawnDiceRoll();
            return;
        }
        
        this.eventProgress.DiceRollProgress.IsMissed = true;
        this.DestroyDiceRoll();
    }
    private void DestroyDiceRoll()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.diceRoll)) == false)
        {
                return;
        }
        
        UnityEngine.Object.DestroyImmediate(obj:  this.diceRoll);
    }
    private void CollectDiceRoll()
    {
        if(this.diceRoll == 0)
        {
                return;
        }
        
        WordRegion val_2 = WordRegion.instance;
        mem2[0] = 1;
        this.eventProgress.DiceRollProgress.IsCollected = true;
        this.RewardDiceRolls(amount:  1, source:  "Snakes and Ladders Event");
        DiceRollTile val_3 = this.diceRoll.GetComponent<DiceRollTile>();
        val_3.eventButtonGO = this.eventButtonGO;
        this.diceRoll.GetComponent<DiceRollTile>().PlayEndingAnimation();
    }
    private void SpawnDiceRoll()
    {
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.DiceRollPrefab, parent:  this.CurrentDiceRollCell.transform);
        this.diceRoll = val_4;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_4.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.RectTransform val_8 = this.CurrentDiceRollCell.GetComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector2 val_10 = val_8.sizeDelta;
        UnityEngine.Vector2 val_11 = val_8.sizeDelta;
        UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  val_10.x, y:  val_11.y);
        this.diceRoll.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
    }
    private int GetRandomDiceRoll()
    {
        return UnityEngine.Random.Range(min:  1, max:  7);
    }
    private void OnPurchaseSuccess(PurchaseModel purchase)
    {
        this.onPurchaseComplete.Invoke(arg1:  true, arg2:  purchase);
    }
    private void OnPurchaseFail(PurchaseModel purchase)
    {
        this.onPurchaseComplete.Invoke(arg1:  false, arg2:  purchase);
    }
    private int GetRewardByAmountChance(System.Collections.Generic.List<GiftRewardAmountChance> rewards)
    {
        RandomSet val_1 = new RandomSet();
        List.Enumerator<T> val_2 = rewards.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.add(item:  11993091, weight:  1.401298E-45f);
        goto label_5;
        label_2:
        0.Dispose();
        return (int)val_1.roll(unweighted:  false);
    }
    public void Hack_ShowBoard(int boardIndex)
    {
        SnakesAndLaddersEvent.EventProgress val_2;
        var val_3;
        System.Collections.Generic.List<SnakesAndLaddersEvent.Board> val_4;
        var val_5;
        this.ResetBoardProgress();
        val_2 = this.eventProgress;
        val_3 = 4;
        label_18:
        val_4 = this.eventProgress.Boards;
        var val_1 = val_3 - 4;
        if(val_1 >= true)
        {
            goto typeof(SnakesAndLaddersEvent.EventProgress).__il2cppRuntimeField_180;
        }
        
        if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_1 >= boardIndex)
        {
            goto label_5;
        }
        
        if(this.eventProgress <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(0 != 0)
        {
            goto label_11;
        }
        
        label_5:
        val_5 = 0;
        label_11:
        mem2[-2305843009213693928] = val_5;
        val_4 = this.eventProgress.Boards;
        if(this.eventProgress <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        mem2[0] = (val_1 < boardIndex) ? 1 : 0;
        val_2 = this.eventProgress;
        val_3 = val_3 + 1;
        if(val_2 != null)
        {
            goto label_18;
        }
        
        throw new NullReferenceException();
    }
    public SnakesAndLaddersEventHandler()
    {
    
    }
    private bool <GetCurrentBoardIndex>b__47_0(SnakesAndLaddersEvent.Board x)
    {
        SnakesAndLaddersEvent.Board val_1 = this.GetCurrentBoard();
        return x.Definition.Equals(anotherBoard:  val_1.Definition);
    }

}
