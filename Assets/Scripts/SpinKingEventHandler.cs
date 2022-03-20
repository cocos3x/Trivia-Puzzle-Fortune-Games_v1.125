using UnityEngine;
public class SpinKingEventHandler : WGEventHandler
{
    // Fields
    public const string SPINKING_EVENT_ID = "SpinKing";
    public const string SHOW_RANK_UP_FLYOUT = "ShowRankupFlyout";
    public const string SPIN_KING_EVENT_LAST_LEVEL = "spin_king_last_level";
    private static SpinKingEventHandler <Instance>k__BackingField;
    private const string LAST_POPUP_SHOW_LEVEL_KEY = "last_popup_show_level";
    private const string EARNED_SPIN_PIECE_KEY = "spin_earned_pc";
    private const string LAST_PROGRESS_STAMP_KEY = "spin_last_progress";
    public bool isGotSpinInLevel;
    private int span;
    public bool QAHACK_FreeSpins;
    private SpinKingEventHandler.SpinKingEcon <econ>k__BackingField;
    private int _bankedSpins;
    
    // Properties
    public static SpinKingEventHandler Instance { get; set; }
    public static bool EarnedSpinPiece { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    public SpinKingEventHandler.SpinKingEcon econ { get; set; }
    public int BankedSpins { get; }
    public bool PlayingChallenge { get; }
    public bool isBankedSpinsMax { get; }
    public bool isSpinsMax { get; }
    public bool isActive { get; }
    private int LastLevel { get; set; }
    private int lastPopupShowLevel { get; set; }
    
    // Methods
    public static SpinKingEventHandler get_Instance()
    {
        return (SpinKingEventHandler)SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY;
    }
    private static void set_Instance(SpinKingEventHandler value)
    {
        SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY = value;
    }
    public static bool get_EarnedSpinPiece()
    {
        return PlayerPrefsX.GetBool(name:  "spin_earned_pc", defaultValue:  false);
    }
    public static void set_EarnedSpinPiece(bool value)
    {
        bool val_2 = PlayerPrefsX.SetBool(name:  "spin_earned_pc", value:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "spin_last_progress", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "spin_last_progress", value:  value);
    }
    public SpinKingEventHandler.SpinKingEcon get_econ()
    {
        return (SpinKingEcon)this.<econ>k__BackingField;
    }
    private void set_econ(SpinKingEventHandler.SpinKingEcon value)
    {
        this.<econ>k__BackingField = value;
    }
    public int get_BankedSpins()
    {
        return (int)this._bankedSpins;
    }
    public bool get_PlayingChallenge()
    {
        string val_6;
        if(((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) && (CategoryPacksManager.IsPlaying != true))
        {
                val_6 = SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY;
            if(val_6 == null)
        {
                return (bool)val_6;
        }
        
            if(((val_6 & 1) == 0) && (SceneDictator.IsInGameScene() != false))
        {
                int val_6 = this.span;
            val_6 = this._bankedSpins + val_6;
            if(val_6 < (this.<econ>k__BackingField.EventMaxSpins))
        {
                var val_5 = (this._bankedSpins < (this.<econ>k__BackingField.MaxBankedSpins)) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public bool get_isBankedSpinsMax()
    {
        if((this.<econ>k__BackingField) != null)
        {
                return (bool)(this._bankedSpins >= (this.<econ>k__BackingField.MaxBankedSpins)) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public bool get_isSpinsMax()
    {
        if((this.<econ>k__BackingField) != null)
        {
                int val_2 = this.span;
            val_2 = this._bankedSpins + val_2;
            return (bool)(val_2 >= (this.<econ>k__BackingField.EventMaxSpins)) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public bool get_isActive()
    {
        var val_2;
        if(this.IsEventExpired() != false)
        {
                val_2 = 0;
            return true;
        }
        
        val_2 = 1152921517649382801;
        return true;
    }
    private int get_LastLevel()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "spin_king_last_level", defaultValue:  0);
    }
    private void set_LastLevel(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "spin_king_last_level", value:  value);
        App.Player.SaveState();
    }
    private int get_lastPopupShowLevel()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "last_popup_show_level")) != false)
        {
                return UnityEngine.PlayerPrefs.GetInt(key:  "last_popup_show_level");
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "last_popup_show_level", value:  (App.Player - 10) - (this.<econ>k__BackingField.LevelsShowPopup));
        Player val_5 = App.Player;
        val_5 = (val_5 - 10) - (this.<econ>k__BackingField.LevelsShowPopup);
        return (int)val_5;
    }
    private void set_lastPopupShowLevel(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "last_popup_show_level", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517650000384] = eventV2;
        SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY = this;
        SpinKingEventHandler.SpinKingEcon val_1 = null;
        .InitialBaseSpins = ;
        .MaxBankedSpins = ;
        .EventMaxSpins = 21474836730;
        .LevelsShowPopup = 5;
        val_1 = new SpinKingEventHandler.SpinKingEcon();
        this.<econ>k__BackingField = val_1;
        this.ParseEventData(eventData:  eventV2.eventData);
        SpinKingOutCome val_2 = SpinKingSlotMachine.CreateSpinOutCome();
    }
    public override void OnWordRegionLoaded()
    {
        val_1.hasLevelFinishedLoading = true;
        MonoSingleton<SpinKingEventUIController>.Instance.UpdateSpinCollectionUI();
        this.isGotSpinInLevel = false;
    }
    public override string GetGameButtonText()
    {
        return this._bankedSpins.ToString();
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "spin_king_upper", defaultValue:  "SPIN KING", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        object val_7;
        PrefabsFromFolder val_8 = loader;
        if((this & 1) != 0)
        {
                return;
        }
        
        val_8 = val_8.LoadStrictlyTypeNamedPrefab<EventListItemContentSpinKing>(allowMultiple:  false);
        val_7 = this._bankedSpins;
        val_8.SetupCollectedSpins(amount:  System.String.Format(format:  "{0}/{1}", arg0:  this._bankedSpins, arg1:  this.<econ>k__BackingField.MaxBankedSpins), isMax:  (this._bankedSpins >= (this.<econ>k__BackingField.MaxBankedSpins)) ? 1 : 0);
        float val_7 = (float)this._bankedSpins;
        float val_4 = val_7 / ((float)this.<econ>k__BackingField.MaxBankedSpins);
        val_7 = val_4 * 100f;
        val_8.SetupSlider(sliderText:  System.String.Format(format:  "{0}%", arg0:  (int)(val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7)), sliderValue:  val_4);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "spin_king_upper", defaultValue:  "SPIN KING", useSingularKey:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
            
        }
        else
        {
                this.ShowSlotPopup().SetPlayFromLevelComplete(level_complete:  false);
        }
    
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
            
        }
        else
        {
                this.ShowSlotPopup().SetPlayFromLevelComplete(level_complete:  false);
        }
    
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public override bool EventCompleted()
    {
        if((this.<econ>k__BackingField) != null)
        {
                return (bool)(this.span >= (this.<econ>k__BackingField.EventMaxSpins)) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(SpinKingEventHandler).__il2cppRuntimeField_4F0;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if(this._bankedSpins != (this.<econ>k__BackingField.MaxBankedSpins))
        {
                return;
        }
        
        int val_2 = this.lastPopupShowLevel;
        int val_5 = this.<econ>k__BackingField.LevelsShowPopup;
        val_5 = val_5 + val_2;
        if(App.Player < val_5)
        {
                return;
        }
        
        val_2.ShowSlotPopup().SetPlayFromLevelComplete(level_complete:  true);
        Player val_4 = App.Player;
        val_4.lastPopupShowLevel = val_4;
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
    public override int GetMovingWordIndex()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SpinKingEventUIController>.Instance)) == false)
        {
                return this.GetMovingWordIndex();
        }
        
        if(this.PlayingChallenge == false)
        {
                return this.GetMovingWordIndex();
        }
        
        return MonoSingleton<SpinKingEventUIController>.Instance.spinWordIndex;
    }
    public override void OnValidWordSubmitted(string word)
    {
        var val_13;
        string val_14;
        var val_15;
        val_14 = word;
        val_15 = this;
        if(this.IsEventExpired() != false)
        {
                MonoSingleton<SpinKingEventUIController>.Instance.DestroySpinPiece();
            val_15 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                if(val_15.PlayingChallenge == false)
        {
                return;
        }
        
            val_13 = 1152921504893161472;
            SpinKingEventUIController val_4 = MonoSingleton<SpinKingEventUIController>.Instance;
            if(val_4.spinPiece == 0)
        {
                return;
        }
        
            MonoSingleton<SpinKingEventUIController>.Instance.OnWordSubmitted(submitWord:  val_14);
        }
    
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        var val_25;
        var val_26;
        var val_27;
        double val_28;
        double val_29;
        double val_30;
        val_26 = hintedCell;
        val_27 = this;
        if(this.IsEventExpired() != false)
        {
                MonoSingleton<SpinKingEventUIController>.Instance.DestroySpinPiece();
            val_27 = ???;
            val_26 = ???;
            val_25 = ???;
            val_28 = ???;
            val_29 = ???;
            val_30 = ???;
        }
        else
        {
                if(val_27.PlayingChallenge == false)
        {
                return;
        }
        
            val_25 = 1152921504893161472;
            SpinKingEventUIController val_4 = MonoSingleton<SpinKingEventUIController>.Instance;
            if(val_4.spinPiece == 0)
        {
                return;
        }
        
            UnityEngine.Vector3 val_7 = val_26.transform.position;
            val_28 = val_7.x;
            val_29 = val_7.z;
            SpinKingEventUIController val_8 = MonoSingleton<SpinKingEventUIController>.Instance;
            UnityEngine.Vector3 val_10 = val_8.spinPiece.transform.position;
            val_30 = val_10.y;
            if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_28, y = val_7.y, z = val_29}, rhs:  new UnityEngine.Vector3() {x = val_10.x, y = val_30, z = val_10.z})) == false)
        {
                return;
        }
        
            MonoSingleton<SpinKingEventUIController>.Instance.ShiftSpinPiece();
        }
    
    }
    public override int LastProgressTimestamp()
    {
        return SpinKingEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        SpinKingEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public System.TimeSpan GetRemainingTime()
    {
        var val_4;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = 163547}, t2:  new System.DateTime() {dateData = val_1.dateData})) != false)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            return Subtract(value:  new System.DateTime() {dateData = val_3.dateData});
        }
        
        val_4 = null;
        val_4 = null;
        return (System.TimeSpan)System.TimeSpan.Zero;
    }
    public void HandleSpinPieceCollected()
    {
        int val_1 = this._bankedSpins;
        this.isGotSpinInLevel = true;
        val_1 = val_1 + 1;
        this._bankedSpins = val_1;
        if(val_1 > (this.<econ>k__BackingField.MaxBankedSpins))
        {
                this._bankedSpins = this.<econ>k__BackingField.MaxBankedSpins;
        }
        
        this.SendSpinsAmountToServer();
        goto typeof(SpinKingEventHandler).__il2cppRuntimeField_2B0;
    }
    public float GetPercentProgress()
    {
        if((this.<econ>k__BackingField) != null)
        {
                float val_1 = (float)this._bankedSpins;
            val_1 = val_1 / ((float)this.<econ>k__BackingField.MaxBankedSpins);
            return (float)val_1;
        }
        
        throw new NullReferenceException();
    }
    public WGSpinKingSlotPopup ShowSlotPopup()
    {
        return MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSpinKingSlotPopup>(showNext:  true);
    }
    public void Spin()
    {
        int val_2 = this._bankedSpins;
        val_2 = val_2 - 1;
        if()
        {
                return;
        }
        
        this._bankedSpins = val_2;
        this.span = this.span + 1;
        this.SendSpinsAmountToServer();
        goto typeof(SpinKingEventHandler).__il2cppRuntimeField_2B0;
    }
    public bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48})) == false)
        {
                return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = System.DateTime.__il2cppRuntimeField_cctor_finished + 40});
        }
        
        return true;
    }
    public bool IsSolvingInProgress()
    {
        return (bool)(this.LastLevel == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0;
    }
    public void SaveEventProgress()
    {
        if(PlayingLevel.CurrentGameplayMode == 4)
        {
                CategoryPacksManager val_2 = MonoSingleton<CategoryPacksManager>.Instance;
            string val_3 = val_2.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
        }
        
        int val_4 = PlayingLevel.GetCurrentPlayerLevelNumber();
        val_4.LastLevel = val_4;
    }
    public void SpinPieceAnimationComplete()
    {
        goto typeof(SpinKingEventHandler).__il2cppRuntimeField_2B0;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_26;
        var val_27;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        if((eventData.ContainsKey(key:  "economy")) != false)
        {
                val_27 = 1152921510214912464;
            object val_3 = eventData.Item["economy"];
            if((val_3.ContainsKey(key:  "ibs")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["ibs"], result: out  this.<econ>k__BackingField.InitialBaseSpins);
        }
        
            if((val_3.ContainsKey(key:  "mbs")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_3.Item["mbs"], result: out  this.<econ>k__BackingField.MaxBankedSpins);
        }
        
            if((val_3.ContainsKey(key:  "ems")) != false)
        {
                bool val_15 = System.Int32.TryParse(s:  val_3.Item["ems"], result: out  this.<econ>k__BackingField.EventMaxSpins);
        }
        
        }
        
        val_26 = "progress";
        if((eventData.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        val_26 = 1152921510214912464;
        object val_17 = eventData.Item["progress"];
        if((val_17.ContainsKey(key:  "spins")) != false)
        {
                bool val_21 = System.Int32.TryParse(s:  val_17.Item["spins"], result: out  this._bankedSpins);
            val_27 = "span";
            if((val_17.ContainsKey(key:  "span")) == false)
        {
                return;
        }
        
            bool val_25 = System.Int32.TryParse(s:  val_17.Item["span"], result: out  this.span);
            return;
        }
        
        this.span = 0;
        this._bankedSpins = this.<econ>k__BackingField.InitialBaseSpins;
        this.SendSpinsAmountToServer();
    }
    private void DeletePlayerPref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    private string GetPlatformId()
    {
        return "a";
    }
    public void SendSpinsAmountToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "bucket", value:  val_2.playerBucket);
        val_1.Add(key:  "spins", value:  this._bankedSpins);
        val_1.Add(key:  "span", value:  this.span);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    public SpinKingEventHandler()
    {
    
    }

}
