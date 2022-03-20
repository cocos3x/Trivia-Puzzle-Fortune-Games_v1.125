using UnityEngine;
public class PortraitCollectionEventHandler : WGEventHandler
{
    // Fields
    private static PortraitCollectionEventHandler _Instance;
    public const string EVENT_LAST_LEVEL = "last_level";
    private const string EARNED_SPIN_PIECE_KEY = "spin_earned_pc";
    public const string EVENT_ID = "PortraitCollection";
    public const string EVENT_TRACKING_ID = "Portrait Collection";
    private const string KEYS_KEY = "keys";
    private const string COLLECTION_KEY = "collection";
    private int <currentKeys>k__BackingField;
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private int <keyRequirement>k__BackingField;
    private int duplicatesPerReward;
    private string <currentCollection>k__BackingField;
    
    // Properties
    public static PortraitCollectionEventHandler Instance { get; }
    private int LastLevel { get; set; }
    public static bool EarnedKeyPiece { get; set; }
    public GameEventV2 getEvent { get; }
    public int currentKeys { get; set; }
    public int keyRequirement { get; set; }
    public string currentCollection { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    public bool PlayingChallenge { get; }
    
    // Methods
    public static PortraitCollectionEventHandler get_Instance()
    {
        return (PortraitCollectionEventHandler)PortraitCollectionEventHandler.COLLECTION_KEY;
    }
    private int get_LastLevel()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "last_level", defaultValue:  0);
    }
    private void set_LastLevel(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "last_level", value:  value);
        App.Player.SaveState();
    }
    public static bool get_EarnedKeyPiece()
    {
        return PlayerPrefsX.GetBool(name:  "spin_earned_pc", defaultValue:  false);
    }
    public static void set_EarnedKeyPiece(bool value)
    {
        bool val_2 = PlayerPrefsX.SetBool(name:  "spin_earned_pc", value:  value);
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public int get_currentKeys()
    {
        return (int)this.<currentKeys>k__BackingField;
    }
    private void set_currentKeys(int value)
    {
        this.<currentKeys>k__BackingField = value;
    }
    public int get_keyRequirement()
    {
        return (int)this.<keyRequirement>k__BackingField;
    }
    private void set_keyRequirement(int value)
    {
        this.<keyRequirement>k__BackingField = value;
    }
    public string get_currentCollection()
    {
        return (string)this.<currentCollection>k__BackingField;
    }
    private void set_currentCollection(string value)
    {
        this.<currentCollection>k__BackingField = value;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "specCat_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "specCat_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        UnityEngine.Debug.LogError(message:  "init?");
        mem[1152921516625313088] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        PortraitCollectionEventHandler.COLLECTION_KEY = this;
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
            return;
        }
        
        this.LoadPersistantData();
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "PortraitCollection")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "PortraitCollection"));
        if(val_3 == null)
        {
                return true;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        return true;
    }
    private void GenerateNewData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "keys", value:  this.<currentKeys>k__BackingField);
        CPlayerPrefs.SetString(key:  "PortraitCollection", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    private void LoadPersistantData()
    {
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "PortraitCollection"));
        if(val_2 != null)
        {
                this.myEventData = val_2;
            if((val_2.ContainsKey(key:  "keys")) != false)
        {
                if((System.Int32.TryParse(s:  this.myEventData.Item["keys"], result: out  0)) != false)
        {
                this.<currentKeys>k__BackingField = 0;
        }
        
        }
        
            if((this.myEventData.ContainsKey(key:  "collection")) == false)
        {
                return;
        }
        
            this.<currentCollection>k__BackingField = this.myEventData.Item["collection"];
            return;
        }
        
        this.myEventData = 0;
        throw new NullReferenceException();
    }
    public void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "keys", newValue:  this.<currentKeys>k__BackingField);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "collection", newValue:  this.<currentCollection>k__BackingField);
        CPlayerPrefs.SetString(key:  "PortraitCollection", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    public bool IsSolvingInProgress()
    {
        return (bool)(this.LastLevel == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_11;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        val_11 = 1152921510222861648;
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = eventData.Item["economy"];
        int val_6 = 0;
        if((val_3.ContainsKey(key:  "kpc")) != false)
        {
                if((System.Int32.TryParse(s:  val_3.Item["kpc"], result: out  val_6)) != false)
        {
                this.<keyRequirement>k__BackingField = 0;
        }
        
        }
        
        if((val_3.ContainsKey(key:  "dpr")) == false)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  val_3.Item["dpr"], result: out  val_6)) == false)
        {
                return;
        }
        
        this.duplicatesPerReward = 0;
    }
    public virtual void PlaceKey()
    {
        MonoSingleton<WGPortraitCollectionUIController>.Instance.OnWordRegionLoaded();
    }
    public bool get_PlayingChallenge()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return false;
        }
        
        if(CategoryPacksManager.IsPlaying == true)
        {
                return false;
        }
        
        if(PortraitCollectionEventHandler.COLLECTION_KEY == null)
        {
                return false;
        }
        
        if((PortraitCollectionEventHandler.COLLECTION_KEY & 1) == 0)
        {
                return SceneDictator.IsInGameScene();
        }
        
        return false;
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
    public void CollectKey()
    {
        int val_1 = this.<currentKeys>k__BackingField;
        val_1 = val_1 + 1;
        this.<currentKeys>k__BackingField = val_1;
        this.SaveData();
    }
    public override void OnWordRegionLoaded()
    {
        goto typeof(PortraitCollectionEventHandler).__il2cppRuntimeField_7E0;
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
                MonoSingleton<WGPortraitCollectionUIController>.Instance.DestroyKeyPiece();
            val_15 = this;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                if(this.PlayingChallenge == false)
        {
                return;
        }
        
            val_13 = 1152921504893161472;
            WGPortraitCollectionUIController val_4 = MonoSingleton<WGPortraitCollectionUIController>.Instance;
            if(val_4.keyPiece == 0)
        {
                return;
        }
        
            MonoSingleton<WGPortraitCollectionUIController>.Instance.OnWordSubmitted(submitWord:  val_14);
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
                MonoSingleton<WGPortraitCollectionUIController>.Instance.DestroyKeyPiece();
            val_27 = this;
            val_26 = ???;
            val_25 = ???;
            val_28 = ???;
            val_29 = ???;
            val_30 = ???;
        }
        else
        {
                if(this.PlayingChallenge == false)
        {
                return;
        }
        
            val_25 = 1152921504893161472;
            WGPortraitCollectionUIController val_4 = MonoSingleton<WGPortraitCollectionUIController>.Instance;
            if(val_4.keyPiece == 0)
        {
                return;
        }
        
            UnityEngine.Vector3 val_7 = val_26.transform.position;
            val_28 = val_7.x;
            val_29 = val_7.z;
            WGPortraitCollectionUIController val_8 = MonoSingleton<WGPortraitCollectionUIController>.Instance;
            UnityEngine.Vector3 val_10 = val_8.keyPiece.transform.position;
            val_30 = val_10.y;
            if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_28, y = val_7.y, z = val_29}, rhs:  new UnityEngine.Vector3() {x = val_10.x, y = val_30, z = val_10.z})) == false)
        {
                return;
        }
        
            MonoSingleton<WGPortraitCollectionUIController>.Instance.ShiftKeyPiece();
        }
    
    }
    public override int GetMovingWordIndex()
    {
        bool val_2 = UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGPortraitCollectionUIController>.Instance);
        if(val_2 == false)
        {
                return this.GetMovingWordIndex();
        }
        
        if(val_2.PlayingChallenge == false)
        {
                return this.GetMovingWordIndex();
        }
        
        return MonoSingleton<WGPortraitCollectionUIController>.Instance.GetKeyWordIndex;
    }
    public override int LastProgressTimestamp()
    {
        return PortraitCollectionEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        PortraitCollectionEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public PortraitCollectionEventHandler()
    {
    
    }

}
