using UnityEngine;
public class KeyToRichesEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "KeyToRiches";
    public const string PURCHASE_ID_BASE = "id_keyPack";
    public const string KEY_TO_RICHES_EVENT_REWARD = "Key to Riches Event Reward";
    public System.Action OnKeyBalanceChanged;
    private static KeyToRichesEventHandler _Instance;
    private KeyToRichesEventHandler.Econ econ;
    private KeyToRichesEventHandler.EventProgress eventProgress;
    private System.Collections.Generic.List<string> lettersToReward;
    private System.Collections.Generic.Dictionary<Alphabet2Manager.Rarity, int> lettersInfo;
    private KeyToRichesTile currentKey;
    private UnityEngine.GameObject eventButtonGO;
    private bool <HackShowKeyEveryLevel>k__BackingField;
    private bool showChestContent;
    
    // Properties
    public static KeyToRichesEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public bool KeyShowing { get; }
    public int KeyCount { get; set; }
    public int LevelsPerKey { get; }
    public bool IsKeyLevel { get; }
    public int KeyWordIndex { get; }
    public UnityEngine.GameObject EventButtonGO { get; }
    private UnityEngine.GameObject KeyTileObjectPrefab { get; }
    public int HackLevelsCounter { get; set; }
    public string KeyWord { get; }
    public int HackKeyCount { get; set; }
    public bool HackShowKeyEveryLevel { get; set; }
    public bool ShowChestContent { get; set; }
    
    // Methods
    public static KeyToRichesEventHandler get_Instance()
    {
        return (KeyToRichesEventHandler)KeyToRichesEventHandler._Instance;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public bool get_KeyShowing()
    {
        return UnityEngine.Object.op_Inequality(x:  this.currentKey, y:  0);
    }
    public int get_KeyCount()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.keyCount;
        }
        
        throw new NullReferenceException();
    }
    private void set_KeyCount(int value)
    {
        this.eventProgress.keyCount = value;
        if(this.OnKeyBalanceChanged == null)
        {
                return;
        }
        
        this.OnKeyBalanceChanged.Invoke();
    }
    public int get_LevelsPerKey()
    {
        if(this.econ == null)
        {
                return 0;
        }
        
        return (int)this.econ.levelsPerKey;
    }
    public bool get_IsKeyLevel()
    {
        if(this.eventProgress != null)
        {
                return (bool)(this.eventProgress.levelsCounter == 0) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public int get_KeyWordIndex()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.keyWordIndex;
        }
        
        throw new NullReferenceException();
    }
    public UnityEngine.GameObject get_EventButtonGO()
    {
        return (UnityEngine.GameObject)this.eventButtonGO;
    }
    private UnityEngine.GameObject get_KeyTileObjectPrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "Events", prefabName:  "KeyToRichesTile");
    }
    public override void OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        var val_6;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.KeyShowing == false)
        {
                return;
        }
        
        if((this.eventProgress.keyWordIndex & 2147483648) != 0)
        {
                return;
        }
        
        val_6 = WordRegion.instance;
        if(this.eventProgress.keyWordIndex >= (X9 + 24))
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  wordEntered)) == true)
        {
                return;
        }
        
        EventProgress val_6 = this.eventProgress;
        if(val_6 <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + ((this.eventProgress.keyWordIndex) << 3);
        if(((this.eventProgress + (this.eventProgress.keyWordIndex) << 3).keyWordIndex + 24.Equals(value:  wordEntered)) == false)
        {
                return;
        }
        
        mem2[0] = 1;
    }
    private void OnWordSubmitted(string wordCompleted)
    {
        WordRegion val_1 = WordRegion.instance;
        if(mem[41967640] <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_3 = mem[41967632];
        val_3 = val_3 + ((this.eventProgress.keyWordIndex) << 3);
        if(((mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 24.Equals(value:  wordCompleted)) != false)
        {
                this.CollectCurrentKey();
            return;
        }
        
        this.MoveOrRemoveKey();
    }
    public override void OnValidWordSubmitted(string word)
    {
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.KeyShowing == false)
        {
                return;
        }
        
        this.OnWordSubmitted(wordCompleted:  word);
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        string val_6 = word;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        if(this.KeyShowing == false)
        {
                return;
        }
        
        WordRegion val_3 = WordRegion.instance;
        if(mem[41967640] <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = mem[41967632];
        val_6 = val_6 + ((this.eventProgress.keyWordIndex) << 3);
        if((System.String.op_Inequality(a:  val_6 = word, b:  (mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 24)) == true)
        {
                return;
        }
        
        if(((mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 40 + 24) <= this.eventProgress.cellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = (mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 40 + 16;
        val_7 = val_7 + ((this.eventProgress.cellIndex) << 3);
        val_6 = mem[((mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 40 + 16 + (this.eventProgress.cellIndex) << 3) + 32];
        val_6 = ((mem[41967632] + (this.eventProgress.keyWordIndex) << 3) + 32 + 40 + 16 + (this.eventProgress.cellIndex) << 3) + 32;
        if(hintedCell != val_6)
        {
                return;
        }
        
        this.MoveOrRemoveKey();
    }
    public override void Init(GameEventV2 eventV2)
    {
        KeyToRichesEventHandler val_9 = this;
        mem[1152921516292223824] = eventV2;
        KeyToRichesEventHandler._Instance = val_9;
        this.LoadOrGenerateNewData();
        if(eventV2.eventData != null)
        {
                this.ParseEventData(eventData:  eventV2);
        }
        
        GameEcon val_2 = App.getGameEcon;
        if(App.Player < val_2.events_unlockLevel)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if((val_3.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_9 = ???;
        goto typeof(KeyToRichesEventHandler).__il2cppRuntimeField_210;
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        var val_5;
        decimal val_1 = purchase.Keys;
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        decimal val_3 = purchase.Keys;
        int val_5 = val_3.lo;
        val_5 = (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_5, mid = val_3.mid})) + this.eventProgress.keyCount;
        this.KeyCount = val_5;
        this.SaveData();
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<KeyToRichesPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<KeyToRichesPopup>(showNext:  false);
    }
    public override void OnMenuLoaded()
    {
        this.SaveData();
    }
    public override void OnGameSceneInit()
    {
        if(CategoryPacksManager.IsPlaying != false)
        {
                return;
        }
        
        if(this.eventProgress.keyCount >= 3)
        {
                WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<KeyToRichesPopup>(showNext:  false);
        }
        
        WGEventButton_Game val_4 = UnityEngine.Object.FindObjectOfType<WGEventButton_Game>();
        this.eventButtonGO = val_4.event_button.gameObject;
        this.TryPlaceKey();
    }
    public override bool EventCompleted()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "key_riches_upper", defaultValue:  "KEY TO RICHES", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return (string)Localization.Localize(key:  "key_riches_upper", defaultValue:  "KEY TO RICHES", useSingularKey:  false)(Localization.Localize(key:  "key_riches_upper", defaultValue:  "KEY TO RICHES", useSingularKey:  false)) + System.String.Format(format:  " {0}/3", arg0:  this.eventProgress.keyCount)(System.String.Format(format:  " {0}/3", arg0:  this.eventProgress.keyCount));
    }
    public override string GetGameButtonText()
    {
        return (string)System.String.Format(format:  "{0}/3", arg0:  this.eventProgress.keyCount);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_3 = (float)this.eventProgress.keyCount;
        val_3 = val_3 / 3f;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentKeyToRiches>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/3", arg0:  this.eventProgress.keyCount), sliderValue:  val_3);
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        if(this.eventProgress.levelsCounter != 0)
        {
                return;
        }
        
        1152921516293741120 = currentData;
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  1152921516293741120, key:  "Key Earned", newValue:  this.eventProgress.collected);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.CloseFtux();
        this.lettersToReward.Clear();
        this.lettersInfo.Clear();
        this.currentKey = 0;
        this.eventButtonGO = 0;
        if(CategoryPacksManager.IsPlaying != false)
        {
                return;
        }
        
        int val_2 = this.eventProgress.levelsCounter;
        val_2 = val_2 + levelsProgressed;
        this.eventProgress.levelsCounter = val_2;
        this.eventProgress.collected = false;
        this.eventProgress.skipped = false;
        this.eventProgress.keyWordIndex = 0;
        this.eventProgress.cellIndex = 0;
        this.SaveData();
    }
    public void PurchaseKeys(int keysToPurchase)
    {
        if((keysToPurchase - 1) > 2)
        {
                return;
        }
        
        bool val_4 = PurchaseProxy.Purchase(purchase:  new PurchaseModel(json:  this.GetPackageByKeyCount(keysToPurchase:  keysToPurchase)));
    }
    public twelvegigs.storage.JsonDictionary GetPackageByKeyCount(int keysToPurchase)
    {
        int val_4;
        var val_5;
        val_4 = keysToPurchase;
        if((val_4 - 1) > 2)
        {
                val_5 = 0;
            return (twelvegigs.storage.JsonDictionary)PackagesManager.GetPackageById(packageId:  val_4 = "id_keyPack" + val_4);
        }
        
        return (twelvegigs.storage.JsonDictionary)PackagesManager.GetPackageById(packageId:  val_4);
    }
    public string GetPackagePriceByKeyCount(int keysToPurchase)
    {
        int val_5;
        var val_6;
        val_5 = keysToPurchase;
        twelvegigs.storage.JsonDictionary val_1 = this.GetPackageByKeyCount(keysToPurchase:  val_5);
        if(val_1 != null)
        {
                val_5 = val_1;
            string val_2 = val_1.getString(key:  "regular_price", defaultValue:  "");
            val_6 = val_2;
            if((System.String.op_Equality(a:  val_2, b:  "")) == false)
        {
                return (string)val_6;
        }
        
            return "$" + val_5.getString(key:  "sale_price", defaultValue:  "")(val_5.getString(key:  "sale_price", defaultValue:  ""));
        }
        
        val_6 = "";
        return (string)val_6;
    }
    public System.Collections.Generic.List<KeyToRichesEventHandler.Reward> GenerateRewards(bool isPurchase = False)
    {
        int val_16;
        var val_17;
        var val_18;
        var val_19;
        val_17 = this;
        if(this.econ == null)
        {
            goto label_1;
        }
        
        this.lettersToReward.Clear();
        this.lettersInfo.Clear();
        if(isPurchase != true)
        {
                if(App.Player < 150)
        {
            goto label_8;
        }
        
        }
        
        val_18 = 3;
        goto label_9;
        label_1:
        val_19 = 0;
        return (System.Collections.Generic.List<Reward>)val_19;
        label_8:
        val_18 = 2;
        label_9:
        System.Collections.Generic.List<Reward> val_2 = null;
        val_19 = val_2;
        val_2 = new System.Collections.Generic.List<Reward>();
        Tier val_17 = 0;
        label_22:
        var val_16 = 0;
        label_20:
        val_16 = val_16 + 1;
        if(val_16 >= this.econ.tierQuantity.Item[val_17])
        {
            goto label_13;
        }
        
        System.Collections.Generic.List<Reward> val_5 = this.econ.tierRewards.Item[val_17];
        val_2.Add(item:  System.Linq.Enumerable.ElementAt<Reward>(source:  this.econ.tierRewards.Item[val_17], index:  UnityEngine.Random.Range(min:  0, max:  0)));
        if(this.econ != null)
        {
            goto label_20;
        }
        
        label_13:
        val_17 = val_17 + 1;
        if(val_17 < val_18)
        {
            goto label_22;
        }
        
        if(val_19 != null)
        {
            goto label_23;
        }
        
        label_30:
        int val_8 = UnityEngine.Random.Range(min:  0, max:  2);
        System.Collections.Generic.List<Reward> val_10 = this.econ.tierRewards.Item[val_8];
        Reward val_12 = System.Linq.Enumerable.ElementAt<Reward>(source:  this.econ.tierRewards.Item[val_8], index:  UnityEngine.Random.Range(min:  0, max:  val_8));
        val_2.Add(item:  val_12);
        label_23:
        if(val_12 <= 8)
        {
            goto label_30;
        }
        
        do
        {
            val_16 = UnityEngine.Random.Range(min:  0, max:  val_12);
            if(0 >= this.econ)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.econ <= val_16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2.set_Item(index:  0, value:  (typeof(Player).__il2cppRuntimeField_170 + (val_13) << 3) + 32);
            val_2.set_Item(index:  val_16, value:  (typeof(Player).__il2cppRuntimeField_170 + 0) + 32);
            val_17 = 0 + 1;
        }
        while(val_17 < val_16);
        
        return (System.Collections.Generic.List<Reward>)val_19;
    }
    public bool OpenChest(KeyToRichesEventHandler.Reward reward)
    {
        var val_3;
        if()
        {
                this.KeyCount = this.eventProgress.keyCount - 1;
            decimal val_2 = System.Decimal.op_Implicit(value:  reward.<count>k__BackingField);
            this.RewardPlayer(rewardType:  reward.<rewardType>k__BackingField, amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
            val_3 = 1;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public void RewardKeys(int amount)
    {
        amount = this.eventProgress.keyCount + amount;
        this.KeyCount = amount;
        this.SaveData();
    }
    public void OnRewardComplete()
    {
        this.CheckFtuxKey();
        this.RewardAlphabets();
        this.SaveData();
    }
    public void OnFlyToComplete()
    {
        if(this.eventProgress.keyCount < 3)
        {
                return;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<KeyToRichesPopup>(showNext:  false);
    }
    public System.Collections.Generic.List<string> RerollLetters()
    {
        var val_14;
        var val_15;
        System.Collections.Generic.List<System.String> val_16;
        if(this.lettersInfo == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.lettersInfo.Count == 0)
        {
            goto label_2;
        }
        
        if(this.lettersToReward == null)
        {
                throw new NullReferenceException();
        }
        
        this.lettersToReward.Clear();
        System.Array val_3 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_4 = val_3.GetEnumerator();
        label_28:
        var val_13 = 0;
        val_13 = val_13 + 1;
        if(val_4.MoveNext() == false)
        {
            goto label_14;
        }
        
        var val_14 = 0;
        val_14 = val_14 + 1;
        if(val_4.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.lettersInfo == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.lettersInfo.ContainsKey(key:  1152921504626761728)) == false)
        {
            goto label_28;
        }
        
        Alphabet2Manager val_10 = MonoSingleton<Alphabet2Manager>.Instance;
        if(this.lettersInfo == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.lettersToReward == null)
        {
                throw new NullReferenceException();
        }
        
        this.lettersToReward.AddRange(collection:  val_10.RollLettersForRarity(rarity:  1152921504626761728, count:  this.lettersInfo.Item[1152921504626761728]));
        goto label_28;
        label_14:
        val_14 = 0;
        if(X0 == false)
        {
            goto label_29;
        }
        
        var val_17 = X0;
        if((X0 + 294) == 0)
        {
            goto label_33;
        }
        
        var val_15 = X0 + 176;
        var val_16 = 0;
        val_15 = val_15 + 8;
        label_32:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_31;
        }
        
        val_16 = val_16 + 1;
        val_15 = val_15 + 16;
        if(val_16 < (X0 + 294))
        {
            goto label_32;
        }
        
        goto label_33;
        label_2:
        val_16 = 0;
        return val_16;
        label_31:
        val_17 = val_17 + (((X0 + 176 + 8)) << 4);
        val_15 = val_17 + 304;
        label_33:
        X0.Dispose();
        label_29:
        if(val_14 != 0)
        {
                throw X21;
        }
        
        val_16 = this.lettersToReward;
        return val_16;
    }
    public override int GetMovingWordIndex()
    {
        if(this.eventProgress != null)
        {
                if(this.eventProgress.levelsCounter == 0)
        {
                return (int)this.eventProgress.keyWordIndex;
        }
        
            return this.GetMovingWordIndex();
        }
        
        throw new NullReferenceException();
    }
    private void GenerateNewData()
    {
        this.eventProgress = new KeyToRichesEventHandler.EventProgress();
        .id = System.Void WFOMysteryChestDisplay.<>c__DisplayClass86_1::<DoOpenChestAnimationSequence>b__7();
        this.SaveData();
    }
    private void LoadOrGenerateNewData()
    {
        string val_1 = CPlayerPrefs.GetString(key:  "keyToRichesData", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) != true)
        {
                this.eventProgress = Newtonsoft.Json.JsonConvert.DeserializeObject<EventProgress>(value:  val_1);
            if(val_3.id == (public static System.Attribute[] System.Attribute::GetCustomAttributes(System.Reflection.Assembly element, System.Type attributeType, bool inherit)))
        {
                return;
        }
        
        }
        
        this.GenerateNewData();
    }
    private void SaveData()
    {
        CPlayerPrefs.SetString(key:  "keyToRichesData", val:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.eventProgress));
        CPlayerPrefs.Save();
    }
    private void CheckFtuxKey()
    {
        if(this.KeyShowing == false)
        {
                return;
        }
        
        if(this.eventProgress.keyFtuxShown != false)
        {
                this.currentKey.SetupAndShowFlyout(isFtux:  false);
            return;
        }
        
        this.currentKey.SetupAndShowFlyout(isFtux:  true);
        this.eventProgress.keyFtuxShown = true;
    }
    private void CheckFtuxEventButton()
    {
        UnityEngine.GameObject val_8;
        if(this.eventProgress.eventButtonFtuxShown == true)
        {
                return;
        }
        
        DynamicToolTip val_2 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_8 = this.eventButtonGO;
        if(val_8 != 0)
        {
                val_2.ShowToolTip(objToToolTip:  this.eventButtonGO, text:  Localization.Localize(key:  "key_riches_collect_tooltip", defaultValue:  "Collect 3 Keys to open Chests", useSingularKey:  false), topToolTip:  true, displayDuration:  4f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
            val_8 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<UGUIClickableMask>(showNext:  false);
            mem2[0] = new System.Action(object:  val_2, method:  public System.Void DynamicToolTip::Dismiss());
        }
        
        this.eventProgress.eventButtonFtuxShown = true;
    }
    private void CloseFtux()
    {
        MonoSingleton<WGWindowManager>.Instance.GetWindow<UGUIClickableMask>().Close();
    }
    private void TryPlaceKey()
    {
        UnityEngine.Transform val_37;
        var val_38;
        System.Predicate<LineWord> val_40;
        var val_41;
        System.Func<LineWord, System.Int32> val_43;
        var val_44;
        System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32> val_46;
        var val_47;
        System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32> val_49;
        if(this.eventProgress.collected == true)
        {
                return;
        }
        
        if(this.eventProgress.skipped != false)
        {
                return;
        }
        
        if((this.<HackShowKeyEveryLevel>k__BackingField) == false)
        {
            goto label_4;
        }
        
        label_75:
        this.eventProgress.levelsCounter = 0;
        bool val_2 = UnityEngine.Object.op_Equality(x:  this.currentKey, y:  0);
        if(((val_2 != false) && (this.eventProgress.keyWordIndex != 1)) && (this.eventProgress.cellIndex != 1))
        {
                WordRegion val_4 = WordRegion.instance;
            UnityEngine.GameObject val_37 = this.currentKey.keyGroup;
            if(val_37 <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_37 = val_37 + ((this.eventProgress.keyWordIndex) << 3);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_37 = (WordRegion.__il2cppRuntimeField_cctor_finished + 40 + 16 + (this.eventProgress.cellIndex) << 3) + 32.transform;
            this.currentKey = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_2.KeyTileObjectPrefab, parent:  val_37).GetComponent<KeyToRichesTile>();
        }
        else
        {
                WordRegion val_8 = WordRegion.instance;
            val_38 = null;
            val_38 = null;
            val_40 = KeyToRichesEventHandler.<>c.<>9__68_0;
            if(val_40 == null)
        {
                System.Predicate<LineWord> val_9 = null;
            val_40 = val_9;
            val_9 = new System.Predicate<LineWord>(object:  KeyToRichesEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean KeyToRichesEventHandler.<>c::<TryPlaceKey>b__68_0(LineWord x));
            KeyToRichesEventHandler.<>c.<>9__68_0 = val_40;
        }
        
            if((this.currentKey.Exists(match:  val_9)) == true)
        {
                return;
        }
        
            val_41 = null;
            val_41 = null;
            val_43 = KeyToRichesEventHandler.<>c.<>9__68_1;
            if(val_43 == null)
        {
                System.Func<LineWord, System.Int32> val_13 = null;
            val_43 = val_13;
            val_13 = new System.Func<LineWord, System.Int32>(object:  KeyToRichesEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 KeyToRichesEventHandler.<>c::<TryPlaceKey>b__68_1(LineWord w));
            KeyToRichesEventHandler.<>c.<>9__68_1 = val_43;
        }
        
            val_44 = null;
            val_44 = null;
            val_46 = KeyToRichesEventHandler.<>c.<>9__68_2;
            if(val_46 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32> val_15 = null;
            val_46 = val_15;
            val_15 = new System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32>(object:  KeyToRichesEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 KeyToRichesEventHandler.<>c::<TryPlaceKey>b__68_2(System.Linq.IGrouping<int, LineWord> gp));
            KeyToRichesEventHandler.<>c.<>9__68_2 = val_46;
        }
        
            if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.Linq.IGrouping<System.Int32, LineWord>>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .countOfMostFrequent = System.Linq.Enumerable.Count<LineWord>(source:  "Super Streak Level Complete!");
            val_47 = null;
            val_47 = null;
            val_49 = KeyToRichesEventHandler.<>c.<>9__68_4;
            if(val_49 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32> val_21 = null;
            val_49 = val_21;
            val_21 = new System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32>(object:  KeyToRichesEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 KeyToRichesEventHandler.<>c::<TryPlaceKey>b__68_4(System.Linq.IGrouping<int, LineWord> gp));
            KeyToRichesEventHandler.<>c.<>9__68_4 = val_49;
        }
        
            var val_38 = 1152921516108279904;
            int val_24 = System.Linq.Enumerable.Count<LineWord>(source:  System.Linq.Enumerable.ToList<LineWord>(source:  MoreLinq.MaxBy<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32>(source:  System.Linq.Enumerable.Where<System.Linq.IGrouping<System.Int32, LineWord>>(source:  System.Linq.Enumerable.ToList<System.Linq.IGrouping<System.Int32, LineWord>>(source:  System.Linq.Enumerable.OrderByDescending<System.Linq.IGrouping<System.Int32, LineWord>, System.Int32>(source:  System.Linq.Enumerable.GroupBy<LineWord, System.Int32>(source:  WordRegion.instance.getAvailableLineWords, keySelector:  val_13), keySelector:  val_15)), predicate:  new System.Func<System.Linq.IGrouping<System.Int32, LineWord>, System.Boolean>(object:  new KeyToRichesEventHandler.<>c__DisplayClass68_0(), method:  System.Boolean KeyToRichesEventHandler.<>c__DisplayClass68_0::<TryPlaceKey>b__3(System.Linq.IGrouping<int, LineWord> gp))), selector:  val_21)));
            int val_25 = val_24 - 1;
            var val_26 = (val_25 < 0) ? (val_24) : (val_25);
            if(val_38 <= (val_26 >> 1))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_38 = val_38 + ((val_26 >> 1) << 3);
            var val_28 = ((1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 24) - 1;
            var val_29 = (val_28 < 0) ? ((1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 24) : (val_28);
            int val_30 = val_29 >> 1;
            if(((1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 24) <= (val_29 >> 1))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_39 = (1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 16;
            val_39 = val_39 + (val_30 << 3);
            this.currentKey = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.KeyTileObjectPrefab, parent:  ((1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 16 + ((val_28 < 0x0 ? (1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32 + 40 + 24 : (( + 32.transform).GetComponent<KeyToRichesTile>();
            this.eventProgress.cellIndex = val_30;
            val_37 = this.eventProgress;
            this.eventProgress.keyWordIndex = WordRegion.instance.IndexOf(item:  (1152921516108279904 + ((val_25 < 0 ? val_24 : (val_24 - 1) >> 1)) << 3) + 32);
            this.SaveData();
        }
        
        this.CheckFtuxKey();
        return;
        label_4:
        if(this.eventProgress.levelsCounter == 0)
        {
            goto label_75;
        }
        
        if(this.eventProgress.levelsCounter < this.econ.levelsPerKey)
        {
                return;
        }
        
        goto label_75;
    }
    private void CollectCurrentKey()
    {
        this.KeyCount = this.eventProgress.keyCount + 1;
        this.currentKey.Collect();
        this.eventProgress.collected = true;
        this.CheckFtuxEventButton();
        this.SaveData();
    }
    private void MoveOrRemoveKey()
    {
        WordRegion val_1 = WordRegion.instance;
    }
    private void RewardPlayer(KeyToRichesEventHandler.RewardType rewardType, decimal amount)
    {
        if(rewardType > 5)
        {
                return;
        }
        
        var val_22 = 32554864 + (rewardType) << 2;
        val_22 = val_22 + 32554864;
        goto (32554864 + (rewardType) << 2 + 32554864);
    }
    private void RewardLetters(Alphabet2Manager.Rarity rarity, int count)
    {
        this.lettersToReward.AddRange(collection:  MonoSingleton<Alphabet2Manager>.Instance.RollLettersForRarity(rarity:  rarity, count:  count));
        if((this.lettersInfo.ContainsKey(key:  rarity)) != true)
        {
                this.lettersInfo.Add(key:  rarity, value:  0);
        }
        
        this.lettersInfo.set_Item(key:  rarity, value:  this.lettersInfo.Item[rarity] + count);
        Player val_6 = App.Player;
        val_6.TrackNonCoinReward(source:  "Key to Riches Event Reward", subSource:  0, rewardType:  val_6.GetAlphabetTypeString(rarity:  rarity), rewardAmount:  count.ToString(), additionalParams:  0);
    }
    private void RewardAlphabets()
    {
        if(this.lettersToReward == null)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupUIForKeyToRiches(rewardedTiles:  this.lettersToReward);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        Tier val_19;
        var val_74;
        object val_75;
        Reward val_76;
        string val_77;
        object val_78;
        var val_79;
        var val_80;
        Tier val_81;
        var val_82;
        var val_83;
        var val_84;
        var val_85;
        var val_86;
        var val_87;
        var val_88;
        var val_89;
        string val_90;
        var val_93;
        var val_94;
        var val_95;
        var val_98;
        var val_99;
        var val_100;
        var val_101;
        string val_102;
        var val_105;
        var val_106;
        var val_107;
        string val_108;
        var val_111;
        var val_112;
        var val_113;
        var val_116;
        val_74 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = eventData.Item["economy"];
        val_75 = "lvls_pk";
        if((val_2.ContainsKey(key:  "lvls_pk")) != false)
        {
                object val_4 = val_2.Item["lvls_pk"];
            mem2[0] = null;
        }
        
        if((val_2.ContainsKey(key:  "t_qty")) != false)
        {
                object val_6 = val_2.Item["t_qty"];
            val_75 = 0;
            val_76 = 1152921504619999232;
            val_77 = "t";
            var val_83 = 0;
            do
        {
            val_78 = val_83 + 2;
            if((ContainsKey(key:  "t" + val_78)) != false)
        {
                object val_11 = Item["t" + val_78];
            val_78 = val_83 + 1;
            mem[1152921516297729976] + 24.set_Item(key:  val_78, value:  19914752);
        }
        
            val_83 = val_83 + 1;
        }
        while(val_83 < 2);
        
        }
        
        val_74 = "t_rew";
        val_79 = 1152921510222861648;
        if((val_2.ContainsKey(key:  "t_rew")) == false)
        {
                return;
        }
        
        object val_13 = val_2.Item["t_rew"];
        val_80 = 0;
        var val_84 = 0;
        val_74 = 1152921504619999232;
        val_77 = "c";
        val_81 = 0;
        goto label_282;
        label_277:
        val_84 = val_84 + 0;
        var val_15 = val_84 + 304;
        label_279:
        if(val_81 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_39:
        var val_87 = 1179403647;
        if(mem[282584257676965] == 0)
        {
            goto label_27;
        }
        
        var val_85 = mem[282584257676847];
        var val_86 = 0;
        val_85 = val_85 + 8;
        label_29:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_28;
        }
        
        val_86 = val_86 + 1;
        val_85 = val_85 + 16;
        if(val_86 < mem[282584257676965])
        {
            goto label_29;
        }
        
        label_27:
        val_82 = "c";
        goto label_30;
        label_28:
        val_82 = "c";
        val_87 = val_87 + (((mem[282584257676847] + 8)) << 4);
        val_83 = val_87 + 304;
        label_30:
        if(val_81.MoveNext() == false)
        {
            goto label_31;
        }
        
        var val_91 = 1179403647;
        if(mem[282584257676965] == 0)
        {
            goto label_35;
        }
        
        var val_88 = mem[282584257676847];
        var val_89 = 0;
        val_88 = val_88 + 8;
        label_34:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_33;
        }
        
        val_89 = val_89 + 1;
        val_88 = val_88 + 16;
        if(val_89 < mem[282584257676965])
        {
            goto label_34;
        }
        
        goto label_35;
        label_33:
        var val_90 = val_88;
        val_90 = val_90 + 1;
        val_91 = val_91 + val_90;
        val_84 = val_91 + 304;
        label_35:
        if(val_81.Current == null)
        {
                throw new NullReferenceException();
        }
        
        KeyToRichesEventHandler.Reward val_18 = null;
        val_76 = val_18;
        val_18 = new KeyToRichesEventHandler.Reward(_type:  5, _count:  19914752);
        Add(item:  val_18);
        goto label_39;
        label_31:
        var val_92 = val_84;
        val_76 = 0;
        val_92 = val_92 + 1;
        mem2[0] = 953;
        if(X0 == false)
        {
            goto label_40;
        }
        
        var val_95 = X0;
        if((X0 + 294) == 0)
        {
            goto label_44;
        }
        
        var val_93 = X0 + 176;
        var val_94 = 0;
        val_93 = val_93 + 8;
        label_43:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_42;
        }
        
        val_94 = val_94 + 1;
        val_93 = val_93 + 16;
        if(val_94 < (X0 + 294))
        {
            goto label_43;
        }
        
        goto label_44;
        label_42:
        val_95 = val_95 + (((X0 + 176 + 8)) << 4);
        val_86 = val_95 + 304;
        label_44:
        X0.Dispose();
        label_40:
        var val_96 = val_92;
        if(val_76 != 0)
        {
                throw ???;
        }
        
        val_81 = val_19;
        if(val_96 == 1)
        {
            goto label_48;
        }
        
        var val_20 = ((-1194031104 + ((0 + 1)) << 2) == 953) ? 1 : 0;
        val_20 = ((val_96 >= 0) ? 1 : 0) & val_20;
        val_96 = val_96 - val_20;
        goto label_48;
        label_282:
        val_75 = val_81 + 1;
        if((ContainsKey(key:  "t" + val_75)) == false)
        {
            goto label_116;
        }
        
        object val_25 = Item["t" + val_75];
        val_19 = val_81;
        val_87 = 0;
        System.Collections.Generic.List<Reward> val_26 = new System.Collections.Generic.List<Reward>();
        if((ContainsKey(key:  "c")) == false)
        {
            goto label_121;
        }
        
        object val_28 = Item["c"];
        val_88 = null;
        var val_99 = X0;
        if((X0 + 294) == 0)
        {
            goto label_123;
        }
        
        var val_97 = X0 + 176;
        var val_98 = 0;
        val_97 = val_97 + 8;
        label_125:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_124;
        }
        
        val_98 = val_98 + 1;
        val_97 = val_97 + 16;
        if(val_98 < (X0 + 294))
        {
            goto label_125;
        }
        
        label_123:
        val_88 = null;
        goto label_126;
        label_121:
        val_90 = "g";
        goto label_127;
        label_124:
        val_99 = val_99 + (((X0 + 176 + 8)) << 4);
        val_89 = val_99 + 304;
        label_126:
        System.Collections.IEnumerator val_29 = X0.GetEnumerator();
        val_76 = val_29;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        label_141:
        var val_100 = 0;
        val_100 = val_100 + 1;
        if(val_76.MoveNext() == false)
        {
            goto label_133;
        }
        
        var val_101 = 0;
        val_101 = val_101 + 1;
        if(val_76.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  new KeyToRichesEventHandler.Reward(_type:  0, _count:  19914752));
        goto label_141;
        label_133:
        var val_102 = 0;
        val_85 = 0;
        val_102 = val_102 + 1;
        mem2[0] = 396;
        if(X0 == false)
        {
            goto label_142;
        }
        
        var val_105 = X0;
        val_76 = X0;
        if((X0 + 294) == 0)
        {
            goto label_146;
        }
        
        var val_103 = X0 + 176;
        var val_104 = 0;
        val_103 = val_103 + 8;
        label_145:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_144;
        }
        
        val_104 = val_104 + 1;
        val_103 = val_103 + 16;
        if(val_104 < (X0 + 294))
        {
            goto label_145;
        }
        
        goto label_146;
        label_144:
        val_105 = val_105 + (((X0 + 176 + 8)) << 4);
        val_93 = val_105 + 304;
        label_146:
        val_76.Dispose();
        label_142:
        var val_106 = val_102;
        if(val_85 != 0)
        {
                throw ???;
        }
        
        val_79 = 1152921510222861648;
        val_90 = "g";
        if(val_106 != 1)
        {
                var val_35 = ((-1194031104 + ((0 + 1)) << 2) == 396) ? 1 : 0;
            val_35 = ((val_106 >= 0) ? 1 : 0) & val_35;
            val_106 = val_106 - val_35;
        }
        
        val_77 = "c";
        label_127:
        if((ContainsKey(key:  val_90)) == false)
        {
            goto label_150;
        }
        
        object val_38 = Item["g"];
        val_94 = null;
        var val_109 = X0;
        if((X0 + 294) == 0)
        {
            goto label_152;
        }
        
        var val_107 = X0 + 176;
        var val_108 = 0;
        val_107 = val_107 + 8;
        label_154:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_153;
        }
        
        val_108 = val_108 + 1;
        val_107 = val_107 + 16;
        if(val_108 < (X0 + 294))
        {
            goto label_154;
        }
        
        label_152:
        val_94 = null;
        goto label_155;
        label_153:
        val_109 = val_109 + (((X0 + 176 + 8)) << 4);
        val_95 = val_109 + 304;
        label_155:
        System.Collections.IEnumerator val_39 = X0.GetEnumerator();
        val_76 = val_39;
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        label_169:
        var val_110 = 0;
        val_110 = val_110 + 1;
        if(val_76.MoveNext() == false)
        {
            goto label_161;
        }
        
        var val_111 = 0;
        val_111 = val_111 + 1;
        if(val_76.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  new KeyToRichesEventHandler.Reward(_type:  1, _count:  19914752));
        goto label_169;
        label_161:
        var val_112 = 0;
        val_85 = 0;
        val_112 = val_112 + 1;
        mem2[0] = 497;
        if(X0 == false)
        {
            goto label_170;
        }
        
        var val_115 = X0;
        val_76 = X0;
        if((X0 + 294) == 0)
        {
            goto label_174;
        }
        
        var val_113 = X0 + 176;
        var val_114 = 0;
        val_113 = val_113 + 8;
        label_173:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_172;
        }
        
        val_114 = val_114 + 1;
        val_113 = val_113 + 16;
        if(val_114 < (X0 + 294))
        {
            goto label_173;
        }
        
        goto label_174;
        label_172:
        val_115 = val_115 + (((X0 + 176 + 8)) << 4);
        val_98 = val_115 + 304;
        label_174:
        val_76.Dispose();
        label_170:
        var val_116 = val_112;
        if(val_85 != 0)
        {
                throw ???;
        }
        
        val_79 = 1152921510222861648;
        if(val_116 != 1)
        {
                var val_45 = ((-1194031104 + ((0 + 1)) << 2) == 497) ? 1 : 0;
            val_45 = ((val_116 >= 0) ? 1 : 0) & val_45;
            val_116 = val_116 - val_45;
        }
        
        val_77 = "c";
        label_150:
        if(((ContainsKey(key:  "a_t")) == false) || ((MonoSingleton<Alphabet2Manager>.Instance) == 0))
        {
            goto label_274;
        }
        
        object val_50 = Item["a_t"];
        val_99 = 1152921510222861648;
        if((val_50.ContainsKey(key:  val_77)) == false)
        {
            goto label_187;
        }
        
        object val_52 = val_50.Item["c"];
        val_100 = null;
        var val_119 = X0;
        if((X0 + 294) == 0)
        {
            goto label_189;
        }
        
        var val_117 = X0 + 176;
        var val_118 = 0;
        val_117 = val_117 + 8;
        label_191:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_190;
        }
        
        val_118 = val_118 + 1;
        val_117 = val_117 + 16;
        if(val_118 < (X0 + 294))
        {
            goto label_191;
        }
        
        label_189:
        val_100 = null;
        goto label_192;
        label_187:
        val_102 = "uc";
        goto label_194;
        label_190:
        val_119 = val_119 + (((X0 + 176 + 8)) << 4);
        val_101 = val_119 + 304;
        label_192:
        System.Collections.IEnumerator val_53 = X0.GetEnumerator();
        val_76 = val_53;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        label_208:
        var val_120 = 0;
        val_120 = val_120 + 1;
        if(val_76.MoveNext() == false)
        {
            goto label_200;
        }
        
        var val_121 = 0;
        val_121 = val_121 + 1;
        if(val_76.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  new KeyToRichesEventHandler.Reward(_type:  2, _count:  19914752));
        goto label_208;
        label_200:
        var val_122 = 0;
        val_85 = 0;
        val_122 = val_122 + 1;
        mem2[0] = 650;
        if(X0 == false)
        {
            goto label_209;
        }
        
        var val_125 = X0;
        val_76 = X0;
        if((X0 + 294) == 0)
        {
            goto label_213;
        }
        
        var val_123 = X0 + 176;
        var val_124 = 0;
        val_123 = val_123 + 8;
        label_212:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_211;
        }
        
        val_124 = val_124 + 1;
        val_123 = val_123 + 16;
        if(val_124 < (X0 + 294))
        {
            goto label_212;
        }
        
        goto label_213;
        label_211:
        val_125 = val_125 + (((X0 + 176 + 8)) << 4);
        val_105 = val_125 + 304;
        label_213:
        val_76.Dispose();
        label_209:
        var val_126 = val_122;
        if(val_85 != 0)
        {
                throw ???;
        }
        
        val_99 = 1152921510222861648;
        val_102 = "uc";
        if(val_126 != 1)
        {
                var val_59 = ((-1194031104 + ((0 + 1)) << 2) == 650) ? 1 : 0;
            val_59 = ((val_126 >= 0) ? 1 : 0) & val_59;
            val_126 = val_126 - val_59;
        }
        
        val_77 = "c";
        label_194:
        if((val_50.ContainsKey(key:  val_102)) == false)
        {
            goto label_217;
        }
        
        object val_62 = val_50.Item["uc"];
        val_106 = null;
        var val_129 = X0;
        if((X0 + 294) == 0)
        {
            goto label_219;
        }
        
        var val_127 = X0 + 176;
        var val_128 = 0;
        val_127 = val_127 + 8;
        label_221:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_220;
        }
        
        val_128 = val_128 + 1;
        val_127 = val_127 + 16;
        if(val_128 < (X0 + 294))
        {
            goto label_221;
        }
        
        label_219:
        val_106 = null;
        goto label_222;
        label_217:
        val_108 = "r";
        goto label_223;
        label_220:
        val_129 = val_129 + (((X0 + 176 + 8)) << 4);
        val_107 = val_129 + 304;
        label_222:
        System.Collections.IEnumerator val_63 = X0.GetEnumerator();
        val_76 = val_63;
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        label_237:
        var val_130 = 0;
        val_130 = val_130 + 1;
        if(val_76.MoveNext() == false)
        {
            goto label_229;
        }
        
        var val_131 = 0;
        val_131 = val_131 + 1;
        if(val_76.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  new KeyToRichesEventHandler.Reward(_type:  3, _count:  19914752));
        goto label_237;
        label_229:
        var val_132 = 0;
        val_85 = 0;
        val_132 = val_132 + 1;
        mem2[0] = 751;
        if(X0 == false)
        {
            goto label_238;
        }
        
        var val_135 = X0;
        val_76 = X0;
        if((X0 + 294) == 0)
        {
            goto label_242;
        }
        
        var val_133 = X0 + 176;
        var val_134 = 0;
        val_133 = val_133 + 8;
        label_241:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_240;
        }
        
        val_134 = val_134 + 1;
        val_133 = val_133 + 16;
        if(val_134 < (X0 + 294))
        {
            goto label_241;
        }
        
        goto label_242;
        label_240:
        val_135 = val_135 + (((X0 + 176 + 8)) << 4);
        val_111 = val_135 + 304;
        label_242:
        val_76.Dispose();
        label_238:
        var val_136 = val_132;
        if(val_85 != 0)
        {
                throw ???;
        }
        
        val_99 = 1152921510222861648;
        val_108 = "r";
        if(val_136 != 1)
        {
                var val_69 = ((-1194031104 + ((0 + 1)) << 2) == 751) ? 1 : 0;
            val_69 = ((val_136 >= 0) ? 1 : 0) & val_69;
            val_136 = val_136 - val_69;
        }
        
        val_77 = "c";
        label_223:
        if((val_50.ContainsKey(key:  val_108)) == false)
        {
            goto label_246;
        }
        
        object val_72 = val_50.Item["r"];
        val_112 = null;
        var val_139 = X0;
        if((X0 + 294) == 0)
        {
            goto label_248;
        }
        
        var val_137 = X0 + 176;
        var val_138 = 0;
        val_137 = val_137 + 8;
        label_250:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_249;
        }
        
        val_138 = val_138 + 1;
        val_137 = val_137 + 16;
        if(val_138 < (X0 + 294))
        {
            goto label_250;
        }
        
        label_248:
        val_112 = null;
        goto label_251;
        label_249:
        val_139 = val_139 + (((X0 + 176 + 8)) << 4);
        val_113 = val_139 + 304;
        label_251:
        System.Collections.IEnumerator val_73 = X0.GetEnumerator();
        val_76 = val_73;
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        label_265:
        var val_140 = 0;
        val_140 = val_140 + 1;
        if(val_76.MoveNext() == false)
        {
            goto label_257;
        }
        
        var val_141 = 0;
        val_141 = val_141 + 1;
        if(val_76.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_26.Add(item:  new KeyToRichesEventHandler.Reward(_type:  4, _count:  19914752));
        goto label_265;
        label_257:
        var val_142 = 0;
        val_85 = 0;
        val_142 = val_142 + 1;
        mem2[0] = 852;
        if(X0 == false)
        {
            goto label_266;
        }
        
        var val_145 = X0;
        val_76 = X0;
        if((X0 + 294) == 0)
        {
            goto label_270;
        }
        
        var val_143 = X0 + 176;
        var val_144 = 0;
        val_143 = val_143 + 8;
        label_269:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_268;
        }
        
        val_144 = val_144 + 1;
        val_143 = val_143 + 16;
        if(val_144 < (X0 + 294))
        {
            goto label_269;
        }
        
        goto label_270;
        label_268:
        val_145 = val_145 + (((X0 + 176 + 8)) << 4);
        val_116 = val_145 + 304;
        label_270:
        val_76.Dispose();
        label_266:
        var val_146 = val_142;
        if(val_85 != 0)
        {
                throw ???;
        }
        
        val_99 = 1152921510222861648;
        if(val_146 != 1)
        {
                var val_79 = ((-1194031104 + ((0 + 1)) << 2) == 852) ? 1 : 0;
            val_79 = ((val_146 >= 0) ? 1 : 0) & val_79;
            val_146 = val_146 - val_79;
        }
        
        val_77 = "c";
        label_246:
        if((val_50.ContainsKey(key:  "sr")) == false)
        {
            goto label_274;
        }
        
        object val_82 = val_50.Item["sr"];
        if((X0 + 294) == 0)
        {
            goto label_279;
        }
        
        var val_147 = X0 + 176;
        var val_148 = 0;
        val_147 = val_147 + 8;
        label_278:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_277;
        }
        
        val_148 = val_148 + 1;
        val_147 = val_147 + 16;
        if(val_148 < (X0 + 294))
        {
            goto label_278;
        }
        
        goto label_279;
        label_274:
        val_81 = val_19;
        label_48:
        mem[1152921516297729976] + 32.set_Item(key:  val_81, value:  val_26);
        label_116:
        val_78 = val_75;
        if(val_81 < 2)
        {
            goto label_282;
        }
    
    }
    private string GetAlphabetTypeString(Alphabet2Manager.Rarity rarity)
    {
        var val_1;
        if(rarity <= 3)
        {
                val_1 = mem[39724512 + (rarity) << 3];
            val_1 = 39724512 + (rarity) << 3;
            return (string)val_1;
        }
        
        val_1 = "";
        return (string)val_1;
    }
    public int get_HackLevelsCounter()
    {
        return (int)KeyToRichesEventHandler.EventProgress.__il2cppRuntimeField_namespaze;
    }
    public void set_HackLevelsCounter(int value)
    {
        typeof(KeyToRichesEventHandler.EventProgress).__il2cppRuntimeField_18 = value;
    }
    public string get_KeyWord()
    {
        var val_3;
        var val_4;
        val_3 = this;
        if(this.KeyShowing != false)
        {
                WordRegion val_2 = WordRegion.instance;
            EventProgress val_3 = this.eventProgress;
            if(val_3 <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + ((this.eventProgress.keyWordIndex) << 3);
            val_4 = ((this.eventProgress + (this.eventProgress.keyWordIndex) << 3).keyWordIndex) + 24;
            return (string)val_4;
        }
        
        val_4 = "";
        return (string)val_4;
    }
    public int get_HackKeyCount()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.keyCount;
        }
        
        throw new NullReferenceException();
    }
    public void set_HackKeyCount(int value)
    {
        this.KeyCount = value;
        this.SaveData();
    }
    public bool get_HackShowKeyEveryLevel()
    {
        return (bool)this.<HackShowKeyEveryLevel>k__BackingField;
    }
    public void set_HackShowKeyEveryLevel(bool value)
    {
        this.<HackShowKeyEveryLevel>k__BackingField = value;
    }
    public void LevelsCounterMinus10()
    {
        if(this.eventProgress != null)
        {
                int val_1 = this.eventProgress.levelsCounter;
            val_1 = val_1 - 10;
            val_1 = val_1 & (~(val_1 >> 31));
            this.eventProgress.levelsCounter = val_1;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void LevelsCounterPlus10()
    {
        if(this.eventProgress != null)
        {
                int val_1 = this.eventProgress.levelsCounter;
            val_1 = val_1 + 10;
            this.eventProgress.levelsCounter = val_1;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void GrantKeyWord()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        if(this.KeyShowing == false)
        {
                return;
        }
        
        WordRegion val_4 = WordRegion.instance;
        WordRegion val_5 = WordRegion.instance;
        EventProgress val_11 = this.eventProgress;
        if(val_11 <= this.eventProgress.keyWordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = val_11 + ((this.eventProgress.keyWordIndex) << 3);
        this = ???;
        goto typeof(WordRegion).__il2cppRuntimeField_1D0;
    }
    public bool get_ShowChestContent()
    {
        return (bool)this.showChestContent;
    }
    public void set_ShowChestContent(bool value)
    {
        this.showChestContent = value;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  MonoSingleton<WordGameEventsController>.Instance, aName:  "OnToggleKTRChestContent", aData:  new System.Collections.Hashtable());
    }
    public KeyToRichesEventHandler()
    {
        this.econ = new KeyToRichesEventHandler.Econ();
        this.eventProgress = new KeyToRichesEventHandler.EventProgress();
        this.lettersToReward = new System.Collections.Generic.List<System.String>();
        this.lettersInfo = new System.Collections.Generic.Dictionary<Rarity, System.Int32>();
    }

}
