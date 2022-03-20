using UnityEngine;
public class BingoEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "WordBingo";
    public const string EVENT_TRACKING_ID = "Bingo";
    public const int CardSize = 5;
    public const int AvailableBalls = 75;
    public const int MAX_BALLS_PER_LVL = 1;
    private static BingoEventHandler <Instance>k__BackingField;
    public BingoEventHandler.BingoEcon econ;
    private System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> <combinations>k__BackingField;
    private BingoEventProgression <progression>k__BackingField;
    private bool <HackGuaranteeNumber>k__BackingField;
    private UnityEngine.GameObject bingoBallPrefab;
    private GenericMovingObject currentBingoBall;
    private string lastValidWord;
    private int previousWordIndex;
    private System.Collections.Generic.List<int> bingoCombination;
    
    // Properties
    public static BingoEventHandler Instance { get; set; }
    public static bool IsPlaying { get; }
    public System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> combinations { get; set; }
    public BingoEventProgression progression { get; set; }
    public bool HasCollectedBalls { get; }
    public bool HasMovingItem { get; }
    public bool HackGuaranteeNumber { get; set; }
    
    // Methods
    public static BingoEventHandler get_Instance()
    {
        return (BingoEventHandler)BingoEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(BingoEventHandler value)
    {
        BingoEventHandler.<Instance>k__BackingField = value;
    }
    public static bool get_IsPlaying()
    {
        var val_3;
        if((BingoEventHandler.<Instance>k__BackingField) != null)
        {
                if((BingoEventHandler.<Instance>k__BackingField.InExpireInterval()) == false)
        {
            goto label_2;
        }
        
        }
        
        val_3 = 0;
        goto label_3;
        label_2:
        BingoEventHandler val_2 = BingoEventHandler.<Instance>k__BackingField;
        val_3 = val_2 ^ 1;
        label_3:
        val_2 = val_3 & 1;
        return (bool)val_2;
    }
    public System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> get_combinations()
    {
        return (System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>>)this.<combinations>k__BackingField;
    }
    private void set_combinations(System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> value)
    {
        this.<combinations>k__BackingField = value;
    }
    public BingoEventProgression get_progression()
    {
        return (BingoEventProgression)this.<progression>k__BackingField;
    }
    private void set_progression(BingoEventProgression value)
    {
        this.<progression>k__BackingField = value;
    }
    public bool get_HasCollectedBalls()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return (bool)((this.<progression>k__BackingField.ballsCollected) > 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public bool get_HasMovingItem()
    {
        return UnityEngine.Object.op_Inequality(x:  this.currentBingoBall, y:  0);
    }
    public bool get_HackGuaranteeNumber()
    {
        return (bool)this.<HackGuaranteeNumber>k__BackingField;
    }
    public void set_HackGuaranteeNumber(bool value)
    {
        this.<HackGuaranteeNumber>k__BackingField = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        BingoEventHandler val_12;
        BingoEventProgression val_13;
        val_12 = this;
        mem[1152921516078203424] = eventV2;
        this.bingoBallPrefab = PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "BingoBallPrefab");
        BingoEventHandler.<Instance>k__BackingField = val_12;
        this.ParseEventData(eventData:  eventV2.eventData);
        this.<combinations>k__BackingField = this.GetBingoCombinations();
        BingoEventProgression val_3 = null;
        .keyWordIndex = -1;
        .cellIndex = -1;
        val_3 = new BingoEventProgression();
        this.<progression>k__BackingField = val_3;
        val_13 = this.<progression>k__BackingField;
        if(eventV2.id == (this.<progression>k__BackingField.currentEventId))
        {
                bool val_4 = this.IsEventExpired();
            if(val_4 == false)
        {
                return;
        }
        
            val_13 = this.<progression>k__BackingField;
        }
        
        this.<progression>k__BackingField.currentEventId = eventV2.id;
        this.<progression>k__BackingField.currentCard = val_4.GenerateCard();
        this.<progression>k__BackingField.balls = new System.Collections.Generic.List<System.Int32>();
        this.<progression>k__BackingField.bingoCalls = 0;
        this.<progression>k__BackingField.ballsCollected = 0;
        val_12 = ???;
        goto typeof(BingoEventProgression).__il2cppRuntimeField_180;
    }
    public override void OnWordRegionLoaded()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        this.lastValidWord = 0;
        this.previousWordIndex = 0;
        this.TryPlaceBall();
    }
    public override void OnValidWordSubmitted(string word)
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.HasMovingItem == false)
        {
                return;
        }
        
        this.lastValidWord = word;
        WordRegion val_3 = WordRegion.instance;
        if(((this.<progression>k__BackingField.keyWordIndex) & 2147483648) != 0)
        {
                return;
        }
        
        if((this.<progression>k__BackingField.keyWordIndex) >= (X9 + 24))
        {
                return;
        }
        
        if((WordRegion.instance & 1) != 0)
        {
                this.CollectBall();
            return;
        }
        
        this.MoveOrRemoveKey();
    }
    public override void OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        var val_6;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.HasMovingItem == false)
        {
                return;
        }
        
        if(((this.<progression>k__BackingField.keyWordIndex) & 2147483648) != 0)
        {
                return;
        }
        
        val_6 = WordRegion.instance;
        if((this.<progression>k__BackingField.keyWordIndex) >= (X9 + 24))
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        BingoEventProgression val_6 = this.<progression>k__BackingField;
        if(val_6 <= (this.<progression>k__BackingField.keyWordIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + ((this.<progression>k__BackingField.keyWordIndex) << 3);
        if(((this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 24.Equals(value:  wordEntered)) == false)
        {
                return;
        }
        
        mem2[0] = 1;
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        string val_9 = word;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.HasMovingItem == false)
        {
                return;
        }
        
        this.lastValidWord = val_9;
        WordRegion val_3 = WordRegion.instance;
        val_9 = this.<progression>k__BackingField.keyWordIndex;
        if((val_9 & 2147483648) != 0)
        {
                return;
        }
        
        if(val_9 >= mem[41971736])
        {
                return;
        }
        
        if(mem[41971736] <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_9 = mem[41971728];
        val_9 = val_9 + ((this.<progression>k__BackingField.keyWordIndex) << 3);
        UnityEngine.Vector3 val_5 = hintedCell.transform.position;
        val_9 = this.<progression>k__BackingField.cellIndex;
        if(((mem[41971728] + (this.<progression>k__BackingField.keyWordIndex) << 3) + 32 + 40 + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = (mem[41971728] + (this.<progression>k__BackingField.keyWordIndex) << 3) + 32 + 40 + 16;
        val_10 = val_10 + ((this.<progression>k__BackingField.cellIndex) << 3);
        UnityEngine.Vector3 val_7 = ((mem[41971728] + (this.<progression>k__BackingField.keyWordIndex) << 3) + 32 + 40 + 16 + (this.<progression>k__BackingField.cellIndex) << 3) + 32.transform.position;
        if((UnityEngine.Vector3.op_Inequality(lhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, rhs:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z})) != false)
        {
                return;
        }
        
        this.MoveOrRemoveKey();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.<progression>k__BackingField.keyWordIndex = 0;
        this.<progression>k__BackingField.cellIndex = 0;
        goto typeof(BingoEventProgression).__il2cppRuntimeField_180;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Bingo Ball Earned", value:  this.<progression>k__BackingField.currentLevelBalls);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41971712 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<BingoEventPopup>(showNext:  false);
        }
    
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41971712 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<BingoEventPopup>(showNext:  false);
        }
    
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_4;
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_3;
        }
        
        label_15:
        val_4 = 0;
        return true;
        label_3:
        if(layoutType != 1)
        {
            goto label_9;
        }
        
        if(context == 3)
        {
            goto label_6;
        }
        
        if(((context != 5) || ((this.<progression>k__BackingField) == null)) || ((this.<progression>k__BackingField.currentLevelBalls) >= 1))
        {
            goto label_9;
        }
        
        goto label_15;
        label_6:
        Player val_2 = App.Player;
        int val_4 = this.econ.ballLevelIntervall;
        val_4 = val_2 - ((val_2 / val_4) * val_4);
        if(val_4 > 0)
        {
            goto label_15;
        }
        
        label_9:
        val_4 = 1152921516079610721;
        return true;
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventProgressUI = eventProgressUI;
        .eventButton = eventButton;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new BingoEventHandler.<DoLevelCompleteEventProgressAnimation>d__43();
    }
    public override bool EventCompleted()
    {
        if(this.econ.purchasersOnly != false)
        {
                Player val_1 = App.Player;
            if(val_1.total_purchased <= 0f)
        {
                return true;
        }
        
            this.econ = this.econ;
        }
        
        if(this.econ.maxBingoCalls != 0)
        {
                if((this.<progression>k__BackingField.bingoCalls) >= this.econ.maxBingoCalls)
        {
                return true;
        }
        
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "bingo_upper", defaultValue:  "BINGO", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        if((this.<progression>k__BackingField.lastProgressTimestamp) == 0)
        {
                return Localization.Localize(key:  "bingo_upper", defaultValue:  "BINGO", useSingularKey:  false);
        }
        
        return this.<progression>k__BackingField.ballsCollected.ToString();
    }
    public override string GetGameButtonText()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return this.<progression>k__BackingField.currentLevelBalls.ToString();
        }
        
        throw new NullReferenceException();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentBingo val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentBingo>(allowMultiple:  false);
        GameEcon val_2 = App.getGameEcon;
        string val_3 = this.econ.basePrize.ToString(format:  val_2.numberFormatInt);
    }
    public override void OnEventEnded()
    {
        BingoEventHandler.<Instance>k__BackingField = 0;
        goto typeof(BingoEventProgression).__il2cppRuntimeField_190;
    }
    public override int GetMovingWordIndex()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return (int)this.<progression>k__BackingField.keyWordIndex;
        }
        
        throw new NullReferenceException();
    }
    public bool InExpireInterval()
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
    private bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48})) == false)
        {
                return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = System.DateTime.__il2cppRuntimeField_cctor_finished + 40});
        }
        
        return true;
    }
    public System.Collections.Generic.List<int> CallCollectedBalls()
    {
        System.Collections.Generic.IEnumerable<TSource> val_10;
        var val_11;
        var val_12;
        var val_13;
        System.Collections.Generic.List<System.Int32> val_1 = null;
        val_10 = val_1;
        val_1 = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.List<System.Int32> val_2 = null;
        val_11 = val_2;
        val_2 = new System.Collections.Generic.List<System.Int32>();
        if((this.<progression>k__BackingField.ballsCollected) < 1)
        {
                return (System.Collections.Generic.List<System.Int32>)val_11;
        }
        
        var val_12 = 1;
        do
        {
            val_1.Add(item:  1);
            val_12 = val_12 + 1;
        }
        while(val_12 != 76);
        
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  val_1, second:  this.<progression>k__BackingField.balls));
        val_10 = val_4;
        PluginExtension.Shuffle<System.Int32>(list:  val_4, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        if((this.<HackGuaranteeNumber>k__BackingField) != false)
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_11 = this.GuaranteeNumber(remainBalls:  val_10, n:  this.<progression>k__BackingField.ballsCollected);
            this.<progression>k__BackingField.ballsCollected = 0;
            return (System.Collections.Generic.List<System.Int32>)val_11;
        }
        
        }
        
        int val_8 = UnityEngine.Mathf.Min(a:  this.<progression>k__BackingField.ballsCollected, b:  W23);
        if(val_8 < 1)
        {
                return (System.Collections.Generic.List<System.Int32>)val_11;
        }
        
        val_12 = (long)val_8;
        val_13 = 8;
        do
        {
            var val_9 = val_13 - 8;
            if(val_9 >= 1152921504762277888)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.<progression>k__BackingField.balls.Add(item:  this.<progression>k__BackingField.cellIndex);
            if(val_9 >= (this.<progression>k__BackingField))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2.Add(item:  this.<progression>k__BackingField.cellIndex);
            int val_13 = this.<progression>k__BackingField.ballsCollected;
            val_13 = val_13 - 1;
            this.<progression>k__BackingField.ballsCollected = val_13;
            if(this.BingoCombinationCompleted() != null)
        {
                return (System.Collections.Generic.List<System.Int32>)val_11;
        }
        
            val_13 = val_13 + 1;
        }
        while((val_13 - 7) < val_12);
        
        return (System.Collections.Generic.List<System.Int32>)val_11;
    }
    public System.Collections.Generic.List<int> BingoCombinationCompleted()
    {
        int val_4;
        var val_5;
        System.Collections.Generic.List<System.Int32> val_20;
        System.Collections.Generic.List<System.Int32> val_21;
        var val_23;
        var val_25;
        var val_26;
        var val_27;
        var val_30;
        val_21 = this.bingoCombination;
        if(val_21 != null)
        {
                return (System.Collections.Generic.List<System.Int32>)val_21;
        }
        
        System.Collections.Generic.List<System.Int32> val_1 = null;
        val_20 = val_1;
        val_1 = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.HashSet<System.Int32> val_2 = new System.Collections.Generic.HashSet<System.Int32>();
        List.Enumerator<T> val_3 = this.<progression>k__BackingField.balls.GetEnumerator();
        val_23 = 1152921515442988336;
        label_6:
        if(val_5.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_7 = val_2.Add(item:  val_4);
        goto label_6;
        label_4:
        val_5.Dispose();
        List.Enumerator<T> val_8 = this.<combinations>k__BackingField.GetEnumerator();
        val_25 = 0;
        label_21:
        val_26 = public System.Boolean List.Enumerator<System.Collections.Generic.List<UnityEngine.Vector2Int>>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = val_4;
        val_26 = public System.Void System.Collections.Generic.List<System.Int32>::Clear();
        val_27 = val_20;
        val_1.Clear();
        if(val_23 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = val_23.GetEnumerator();
        var val_21 = 1;
        label_18:
        if(val_5.MoveNext() == false)
        {
            goto label_11;
        }
        
        if((this.<progression>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = val_4.x;
        if((this.<progression>k__BackingField.currentCard) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_23 >= null)
        {
                throw new IndexOutOfRangeException();
        }
        
        int val_19 = this.<progression>k__BackingField.currentEventId;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = (long)val_4.y + (val_19 * (long)val_23);
        int val_20 = this.<progression>k__BackingField.currentCard[val_19];
        var val_15 = (val_20 == 0) ? 1 : 0;
        val_15 = val_15 | (val_2.Contains(item:  val_20));
        val_21 = val_21 & val_15;
        if(val_20 == 0)
        {
            goto label_18;
        }
        
        val_1.Add(item:  val_20);
        goto label_18;
        label_11:
        val_23 = 0;
        val_25 = val_25 + 1;
        mem2[0] = 231;
        val_5.Dispose();
        if(val_23 != 0)
        {
            goto label_19;
        }
        
        if(val_25 != 1)
        {
                var val_16 = ((87 + ((val_25 + 1)) << 2) == 231) ? 1 : 0;
            val_16 = ((val_25 >= 0) ? 1 : 0) & val_16;
            val_25 = val_25 - val_16;
        }
        
        if((val_21 & 1) == 0)
        {
            goto label_21;
        }
        
        goto label_22;
        label_8:
        val_20 = 0;
        val_30 = 275;
        goto label_38;
        label_22:
        this.bingoCombination = val_20;
        val_30 = 277;
        label_38:
        val_25 = val_25 + 1;
        mem2[0] = 277;
        val_5.Dispose();
        if(val_25 != 1)
        {
                var val_18 = ((87 + ((((val_25 + 1) - (val_25 >= 0x0 ? 1 : 0 & 87 + ((val_25 + 1)) << 2 == 0xE7 ? 1 : 0)) + 1)) << 2) == 277) ? (val_20) : 0;
            return (System.Collections.Generic.List<System.Int32>)val_21;
        }
        
        val_21 = 0;
        return (System.Collections.Generic.List<System.Int32>)val_21;
        label_19:
        val_27 = val_23;
        val_26 = 0;
        throw val_27;
    }
    public int GetCurrentReward()
    {
        if(this.econ != null)
        {
                return (int)this.econ.basePrize;
        }
        
        throw new NullReferenceException();
    }
    public void CollectRewardAndNewCard()
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  this.econ.basePrize);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, source:  "Bingo Event", externalParams:  0, animated:  false);
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        this.<progression>k__BackingField.balls = val_2;
        this.<progression>k__BackingField.currentCard = val_2.GenerateCard();
        int val_4 = this.<progression>k__BackingField.bingoCalls;
        val_4 = val_4 + 1;
        this.<progression>k__BackingField.bingoCalls = val_4;
        this.bingoCombination = 0;
        goto typeof(BingoEventProgression).__il2cppRuntimeField_180;
    }
    public override bool IsRewardReadyToCollect()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return (bool)((this.<progression>k__BackingField.ballsCollected) > 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        if(CategoryPacksManager.IsPlaying != false)
        {
                return false;
        }
        
        dailyChallengeState = dailyChallengeState;
        return this.ShouldShowInDailyChallenge(dailyChallengeState:  dailyChallengeState);
    }
    public override int LastProgressTimestamp()
    {
        if((this.<progression>k__BackingField) != null)
        {
                return (int)this.<progression>k__BackingField.lastProgressTimestamp;
        }
        
        throw new NullReferenceException();
    }
    public override void UpdateProgress()
    {
        this.<progression>k__BackingField.lastProgressTimestamp = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public void HACKGrantBingo()
    {
        var val_5;
        var val_6;
        var val_13;
        int val_14;
        if((this & 1) != 0)
        {
                return;
        }
        
        int val_1 = UnityEngine.Random.Range(min:  0, max:  typeof(BingoEventHandler).__il2cppRuntimeField_4F8>>0&0xFFFFFFFF);
        if(null <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        BingoEventHandler val_2 = 1152921504908124160 + (val_1 << 3);
        System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
        List.Enumerator<T> val_4 = (1152921504908124160 + (val_1) << 3).econ.GetEnumerator();
        label_14:
        if(val_6.MoveNext() == false)
        {
            goto label_5;
        }
        
        if((this.<progression>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        int val_8 = val_5.x;
        if((this.<progression>k__BackingField.currentCard) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_8 >= null)
        {
                throw new IndexOutOfRangeException();
        }
        
        int val_12 = this.<progression>k__BackingField.currentEventId;
        if((this.<progression>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<progression>k__BackingField.balls) == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = (long)val_5.y + (val_12 * (long)val_8);
        int val_13 = this.<progression>k__BackingField.currentCard[val_12];
        val_13 = this.<progression>k__BackingField.balls;
        val_14 = val_13;
        var val_11 = (val_13 == 0) ? 1 : 0;
        val_11 = val_11 | (val_13.Contains(item:  val_14));
        if(val_11 == true)
        {
            goto label_14;
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  val_13);
        goto label_14;
        label_5:
        val_6.Dispose();
        this.<progression>k__BackingField.balls.AddRange(collection:  val_3);
        this.<progression>k__BackingField.ballsCollected = 1;
    }
    public void HACKGrantAllBalls()
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.<progression>k__BackingField.balls.AddRange(collection:  this.GetCollectedBalls(n:  75));
        this.<progression>k__BackingField.ballsCollected = 0;
    }
    public void HACKAddBall()
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        int val_1 = this.<progression>k__BackingField.ballsCollected;
        val_1 = val_1 + 1;
        this.<progression>k__BackingField.ballsCollected = val_1;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_20;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        val_20 = 1152921510222861648;
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = eventData.Item["economy"];
        if((val_3.ContainsKey(key:  "b_bp")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["b_bp"], result: out  this.econ.basePrize);
        }
        
        if((val_3.ContainsKey(key:  "b_c")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_3.Item["b_c"], result: out  this.econ.maxBingoCalls);
        }
        
        if((val_3.ContainsKey(key:  "bb_li")) != false)
        {
                bool val_15 = System.Int32.TryParse(s:  val_3.Item["bb_li"], result: out  this.econ.ballLevelIntervall);
        }
        
        if((val_3.ContainsKey(key:  "p_only")) == false)
        {
                return;
        }
        
        bool val_19 = System.Boolean.TryParse(value:  val_3.Item["p_only"], result: out  this.econ.purchasersOnly);
    }
    private System.Collections.Generic.List<int> GetCollectedBalls(int n)
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        var val_5 = 1;
        do
        {
            val_1.Add(item:  1);
            val_5 = val_5 + 1;
        }
        while(val_5 != 76);
        
        System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  val_1, second:  this.<progression>k__BackingField.balls));
        PluginExtension.Shuffle<System.Int32>(list:  val_3, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        return val_3.GetRange(index:  0, count:  UnityEngine.Mathf.Min(a:  n, b:  -1408634576));
    }
    private System.Collections.Generic.List<int> GuaranteeNumber(System.Collections.Generic.List<int> remainBalls, int n)
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        var val_10 = 0;
        do
        {
            var val_9 = 0;
            do
        {
            var val_2 = val_9 + 1;
            val_2 = val_10 + ((X10 + 16) * val_2);
            val_1.Add(item:  this.<progression>k__BackingField.currentCard[val_2]);
            val_9 = val_9 + 1;
        }
        while(val_9 < 4);
        
            val_10 = val_10 + 1;
        }
        while(val_10 <= 3);
        
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  val_1, second:  this.<progression>k__BackingField.balls));
        System.Collections.Generic.List<TSource> val_6 = System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  remainBalls, second:  val_1));
        PluginExtension.Shuffle<System.Int32>(list:  val_4, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        val_4.AddRange(collection:  val_6);
        return val_4.GetRange(index:  0, count:  UnityEngine.Mathf.Min(a:  n, b:  val_6));
    }
    private void TryPlaceBall()
    {
        var val_28;
        BingoEventHandler.<>c__DisplayClass68_0 val_1 = new BingoEventHandler.<>c__DisplayClass68_0();
        .<>4__this = this;
        if((this.<progression>k__BackingField.currentLevelBalls) > 0)
        {
                return;
        }
        
        Player val_2 = App.Player;
        int val_28 = this.econ.ballLevelIntervall;
        Player val_3 = val_2 / val_28;
        val_28 = val_2 - (val_3 * val_28);
        if(val_28 > 0)
        {
                return;
        }
        
        WordRegion val_4 = WordRegion.instance;
        .words = null;
        if((((this.<progression>k__BackingField.keyWordIndex) != 1) && ((this.<progression>k__BackingField.cellIndex) != 1)) && ((this.<progression>k__BackingField.keyWordIndex) < (X21 + 24)))
        {
                if((X21 + 24) <= (this.<progression>k__BackingField.keyWordIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_29 = X21 + 16;
            val_29 = val_29 + ((this.<progression>k__BackingField.keyWordIndex) << 3);
            if(((X21 + 16 + (this.<progression>k__BackingField.keyWordIndex) << 3) + 32 + 56) == 0)
        {
                BingoEventProgression val_30 = this.<progression>k__BackingField;
            if(val_3 <= ((long)this.<progression>k__BackingField.keyWordIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_30 = val_30 + (((long)(int)(this.<progression>k__BackingField.keyWordIndex)) << 3);
            if((this.<progression>k__BackingField.cellIndex) < ((this.<progression>k__BackingField + ((long)(int)(this.<progression>k__BackingField.keyWordIndex)) << 3).cellIndex + 40 + 24))
        {
                BingoEventProgression val_31 = this.<progression>k__BackingField;
            if(val_31 <= (this.<progression>k__BackingField.keyWordIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_31 = val_31 + ((this.<progression>k__BackingField.keyWordIndex) << 3);
            if(((this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 24) <= (this.<progression>k__BackingField.cellIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_32 = (this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 16;
            val_32 = val_32 + ((this.<progression>k__BackingField.cellIndex) << 3);
            this.currentBingoBall = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bingoBallPrefab, parent:  ((this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 16 + (this.<progression>k__BackingField.cellIndex) << 3) + 32.transform).GetComponent<GenericMovingObject>();
            MainController val_8 = MainController.instance;
            val_7.eventButton = val_8.eventButtonPanel.GetEventButton(eventId:  "WordBingo").gameObject;
            return;
        }
        
        }
        
        }
        
        var val_33 = 1152921515450617360;
        System.Collections.Generic.List<TSource> val_15 = System.Linq.Enumerable.ToList<System.Int32>(source:  WordRegion.instance.getAvailableLineIndices.FindAll(match:  new System.Predicate<System.Int32>(object:  val_1, method:  System.Boolean BingoEventHandler.<>c__DisplayClass68_0::<TryPlaceBall>b__0(int x))));
        if(as. 
           
           
          
        
        
        
         == 0)
        {
                return;
        }
        
        int val_16 = UnityEngine.Random.Range(min:  0, max:  -2041131504);
        if(val_33 <= val_16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_33 = val_33 + (val_16 << 2);
        this.<progression>k__BackingField.keyWordIndex = (1152921515450617360 + (val_16) << 2) + 32;
        BingoEventProgression val_34 = this.<progression>k__BackingField;
        if(val_34 <= (this.<progression>k__BackingField.keyWordIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_34 = val_34 + ((this.<progression>k__BackingField.keyWordIndex) << 3);
        .answer = 0;
        val_28 = null;
        val_28 = null;
        if((App.game == 4) && (this.lastValidWord != null))
        {
                WordRegion val_17 = WordRegion.instance;
            .answer = Find(match:  new System.Predicate<LineWord>(object:  val_1, method:  System.Boolean BingoEventHandler.<>c__DisplayClass68_0::<TryPlaceBall>b__1(LineWord x)));
        }
        
        this.<progression>k__BackingField.cellIndex = (this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40.FindIndex(startIndex:  0, match:  new System.Predicate<Cell>(object:  val_1, method:  System.Boolean BingoEventHandler.<>c__DisplayClass68_0::<TryPlaceBall>b__2(Cell x)));
        if((this.<progression>k__BackingField.cellIndex) == 1)
        {
                return;
        }
        
        if(((this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 24) <= (this.<progression>k__BackingField.cellIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_35 = (this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 16;
        val_35 = val_35 + ((this.<progression>k__BackingField.cellIndex) << 3);
        this.currentBingoBall = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bingoBallPrefab, parent:  ((this.<progression>k__BackingField + (this.<progression>k__BackingField.keyWordIndex) << 3).cellIndex + 40 + 16 + (this.<progression>k__BackingField.cellIndex) << 3) + 32.transform).GetComponent<GenericMovingObject>();
        MainController val_25 = MainController.instance;
        val_24.eventButton = val_25.eventButtonPanel.GetEventButton(eventId:  "WordBingo").gameObject;
        goto typeof(BingoEventProgression).__il2cppRuntimeField_180;
    }
    private void MoveOrRemoveKey()
    {
        WordRegion val_1 = WordRegion.instance;
    }
    private void CollectBall()
    {
        this.currentBingoBall.Collect();
        this.previousWordIndex = 0;
        this.<progression>k__BackingField.keyWordIndex = 0;
        this.<progression>k__BackingField.cellIndex = 0;
        int val_1 = this.<progression>k__BackingField.currentLevelBalls;
        val_1 = val_1 + 1;
        this.<progression>k__BackingField.currentLevelBalls = val_1;
        this.TryPlaceBall();
    }
    private int[,] GenerateCard()
    {
        var val_9 = 0;
        do
        {
            RandomSet val_1 = new RandomSet();
            var val_7 = 1;
            do
        {
            val_1.add(item:  1, weight:  1f);
            val_7 = val_7 + 1;
        }
        while(val_7 != 16);
        
            var val_8 = 0;
            do
        {
            val_8 = val_8 + 1;
            mem2[0] = (val_1.roll(unweighted:  false)) + (0 - val_9);
        }
        while(val_8 < 4);
        
            val_9 = val_9 + 1;
        }
        while(val_9 < 4);
        
        mem2[0] = 0;
        return (System.Int32[,])null;
    }
    private System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> GetBingoCombinations()
    {
        System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<UnityEngine.Vector2Int>>();
        var val_11 = 0;
        do
        {
            System.Collections.Generic.List<UnityEngine.Vector2Int> val_2 = new System.Collections.Generic.List<UnityEngine.Vector2Int>();
            do
        {
            UnityEngine.Vector2Int val_3 = new UnityEngine.Vector2Int(x:  0, y:  1);
            val_2.Add(item:  new UnityEngine.Vector2Int() {m_X = val_3.m_X, m_Y = val_3.m_X});
        }
        while(1 < 4);
        
            val_1.Add(item:  val_2);
            val_11 = val_11 + 1;
        }
        while(val_11 < 4);
        
        System.Collections.Generic.List<UnityEngine.Vector2Int> val_4 = new System.Collections.Generic.List<UnityEngine.Vector2Int>();
        do
        {
            int val_12 = 0;
            do
        {
            val_12 = val_12 + 1;
            UnityEngine.Vector2Int val_5 = new UnityEngine.Vector2Int(x:  val_12, y:  0);
            val_4.Add(item:  new UnityEngine.Vector2Int() {m_X = val_5.m_X, m_Y = val_5.m_X});
        }
        while(val_12 < 4);
        
            val_1.Add(item:  val_4);
            var val_6 = 0 + 1;
            System.Collections.Generic.List<UnityEngine.Vector2Int> val_7 = new System.Collections.Generic.List<UnityEngine.Vector2Int>();
        }
        while(0 <= 3);
        
        do
        {
            UnityEngine.Vector2Int val_8 = new UnityEngine.Vector2Int(x:  1, y:  1);
            val_7.Add(item:  new UnityEngine.Vector2Int() {m_X = val_8.m_X, m_Y = val_8.m_X});
        }
        while(1 < 4);
        
        val_1.Add(item:  val_7);
        System.Collections.Generic.List<UnityEngine.Vector2Int> val_9 = new System.Collections.Generic.List<UnityEngine.Vector2Int>();
        var val_13 = 4;
        do
        {
            UnityEngine.Vector2Int val_10 = new UnityEngine.Vector2Int(x:  1, y:  4);
            val_9.Add(item:  new UnityEngine.Vector2Int() {m_X = val_10.m_X, m_Y = val_10.m_X});
            val_13 = val_13 - 1;
        }
        while(1 < 4);
        
        val_1.Add(item:  val_9);
        return val_1;
    }
    public BingoEventHandler()
    {
        BingoEventHandler.BingoEcon val_1 = null;
        .ballLevelIntervall = 1;
        .maxBingoCalls = 24;
        .maxBallsPerLevel = 1;
        .basePrize = 100;
        val_1 = new BingoEventHandler.BingoEcon();
        this.econ = val_1;
        this.previousWordIndex = 0;
    }

}
