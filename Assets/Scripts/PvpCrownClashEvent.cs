using UnityEngine;
public class PvpCrownClashEvent : WGEventHandler
{
    // Fields
    private static PvpCrownClashEvent _Instance;
    public const string CROWN_CLASH_EVENT_ID = "CrownClashPvP";
    public const string EVENT_TRACKING_ID = "ApplePicking";
    private const string crownClashPvpPrimaryData = "ccPvpData";
    public const string crownClashLastCrownKey = "lastPvpCrownClashCrown";
    private const string crownClashCrownsCollectedThisLevel = "pvpCrownsCollectedThisLevel";
    private const string LAST_PROGRESS_STAMP_KEY = "pvpCrowns_LastProgressTimestamp";
    private System.Collections.Generic.Dictionary<string, object> thisEventData;
    private bool promptEvent;
    private bool hasShownNoInternetThisSession;
    private int _membershipCrowns;
    private int lastKnownCrowns;
    private bool hasInit;
    private bool hasInitLevel;
    private int aiMinScore;
    private int aiMaxScore;
    private System.Collections.Generic.Dictionary<string, object> eventCoinRewards;
    private System.Collections.Generic.Dictionary<string, object> eventAppleRewards;
    
    // Properties
    public static PvpCrownClashEvent Instance { get; }
    public int membershipCrowns { get; }
    public GameEventV2 myData { get; }
    public int crownsCollectedThisLevel { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    public System.Collections.Generic.Dictionary<string, object> getCoinRewards { get; }
    public System.Collections.Generic.Dictionary<string, object> getAppleRewards { get; }
    public int opponentPlayerSprite { get; }
    public int playerSprite { get; }
    public string playerPortrait { get; }
    public string opponentName { get; }
    public string playerName { get; }
    public object rewardData { get; }
    public override bool SupportsGoldenApples { get; }
    
    // Methods
    public static PvpCrownClashEvent get_Instance()
    {
        return (PvpCrownClashEvent)PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY;
    }
    public int get_membershipCrowns()
    {
        return (int)this._membershipCrowns;
    }
    public GameEventV2 get_myData()
    {
        return (GameEventV2)this;
    }
    public int get_crownsCollectedThisLevel()
    {
        return CPlayerPrefs.GetInt(key:  "pvpCrownsCollectedThisLevel", defaultValue:  0);
    }
    public void set_crownsCollectedThisLevel(int value)
    {
        CPlayerPrefs.SetInt(key:  "pvpCrownsCollectedThisLevel", val:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "pvpCrowns_LastProgressTimestamp", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pvpCrowns_LastProgressTimestamp", value:  value);
    }
    public System.Collections.Generic.Dictionary<string, object> get_getCoinRewards()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.eventCoinRewards;
    }
    public System.Collections.Generic.Dictionary<string, object> get_getAppleRewards()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.eventAppleRewards;
    }
    public int get_opponentPlayerSprite()
    {
        var val_5;
        int val_3 = 0;
        if((this.thisEventData.ContainsKey(key:  "oppAvatar")) != false)
        {
                bool val_4 = System.Int32.TryParse(s:  this.thisEventData.Item["oppAvatar"], result: out  val_3);
            val_5 = val_3;
            return (int)val_5;
        }
        
        val_5 = 0;
        return (int)val_5;
    }
    public int get_playerSprite()
    {
        return SLC.Social.SocialManager.AvatarID;
    }
    public string get_playerPortrait()
    {
        return SLC.Social.SocialManager.PortraitID;
    }
    public string get_opponentName()
    {
        if((this.thisEventData.ContainsKey(key:  "name")) == false)
        {
                return "null";
        }
        
        object val_2 = this.thisEventData.Item["name"];
        this = ???;
        goto typeof(System.Object).__il2cppRuntimeField_160;
    }
    public string get_playerName()
    {
        return SLC.Social.SocialManager.ProfileName;
    }
    public void SetFtuxSeen()
    {
        if((this.thisEventData.ContainsKey(key:  "ftuxShown")) == true)
        {
                return;
        }
        
        this.thisEventData.Add(key:  "ftuxShown", value:  true);
        this.SavePlayerData();
    }
    public void SetWindowSeen()
    {
        if((this.thisEventData.ContainsKey(key:  "eventPrompted")) == true)
        {
                return;
        }
        
        this = this.thisEventData;
        this.Add(key:  "eventPrompted", value:  true);
    }
    public object get_rewardData()
    {
        if(this.canCollectReward() == false)
        {
                return 0;
        }
        
        if((this.thisEventData.ContainsKey(key:  "reward")) == false)
        {
                return 0;
        }
        
        return this.thisEventData.Item["reward"];
    }
    public override void Init(GameEventV2 eventV2)
    {
        PvpCrownClashEvent val_7 = this;
        if(this.hasInit == true)
        {
                return;
        }
        
        mem[1152921516170150880] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        this.CheckData(gameEvent:  eventV2);
        PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY = val_7;
        this.hasInit = true;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        this.hasInitLevel = true;
        val_7 = ???;
        goto typeof(PvpCrownClashEvent).__il2cppRuntimeField_560;
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "apple_picking_upper", defaultValue:  "APPLE PICKING", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_8;
        string val_1 = this._membershipCrowns.ToString();
        int val_2 = this.getOpponentCrowns();
        int val_7 = this._membershipCrowns;
        if((val_2 != 0) && (val_7 != 0))
        {
                val_7 = val_7 + val_2;
            val_8 = (float)val_7 / (float)val_7;
        }
        else
        {
                if((val_7 | val_2) != 0)
        {
                var val_4 = (val_7 < 1) ? 0f : 1f;
        }
        else
        {
                val_8 = 0.5f;
        }
        
        }
        
        float val_5 = UnityEngine.Mathf.Clamp(value:  val_8, min:  0.1f, max:  0.9f);
        EventListItemContentCCPvP val_6 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentCCPvP>(allowMultiple:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        mem2[0] = 1152921516170509152;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PvPCrownClashPopup>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_3;
        mem2[0] = 1152921516170509152;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PvPCrownClashPopup>(showNext:  false).SetUpWindow(fromGameButton:  false);
        val_3 = null;
        val_3 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 42;
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "apple_picking_upper", defaultValue:  "APPLE PICKING", useSingularKey:  false);
    }
    public override void OnMenuLoaded()
    {
        if(this.hasInit == false)
        {
                return;
        }
        
        this.SavePlayerData();
        this.CheckCalculateReward();
    }
    public override void OnGameSceneInit()
    {
        if(this.hasInit == false)
        {
                return;
        }
        
        this.CheckCalculateReward();
        this.hasInitLevel = true;
        if(this.thisEventData == null)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        if((this.thisEventData.ContainsKey(key:  "eventPrompted")) != false)
        {
                return;
        }
        
        mem2[0] = 1152921516170509152;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PvPCrownClashPopup>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public override bool IsEventEndedOffline()
    {
        return this.IsEventEndedOffline();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if(this.hasInit == false)
        {
                return;
        }
        
        this.SavePlayerData();
    }
    public override void OnEventEnded()
    {
        this.ResetData();
    }
    public override bool EventCompleted()
    {
        Player val_1 = App.Player;
        if(val_1.isHacker != false)
        {
                return true;
        }
        
        if((val_1.isHacker + 82) != 0)
        {
                if((this & 1) == 0)
        {
                return true;
        }
        
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48})) == true)
        {
                return true;
        }
        
        return this.thisEventData.ContainsKey(key:  "rewarded");
    }
    public override bool IsRewardReadyToCollect()
    {
        if(this.hasInit == false)
        {
                return false;
        }
        
        if(this.thisEventData == null)
        {
                return false;
        }
        
        this.CheckCalculateReward();
        return this.thisEventData.ContainsKey(key:  "reward");
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        this.crownsCollectedThisLevel = 0;
    }
    public override string GetHackPanelEventData()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_3 = val_1.AppendLine(value:  PrettyPrint.printJSON(obj:  this.thisEventData, types:  false, singleLineOutput:  false));
        System.Text.StringBuilder val_4 = val_1.AppendLine(value:  PrettyPrint.__il2cppRuntimeField_cctor_finished + 96);
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.OnDataUpdated(eventV2:  eventV2);
        this.CheckCalculateReward();
    }
    public override void OnWindowsStateChange(bool anyActiveWindows)
    {
        this.OnWindowsStateChange(anyActiveWindows:  anyActiveWindows);
        this.CheckCalculateReward();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "apple_picking_upper", defaultValue:  "APPLE PICKING", useSingularKey:  false);
    }
    public override int LastProgressTimestamp()
    {
        return PvpCrownClashEvent.LastProgressTimestampPref;
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override void OnAppleAwarded(int appleAwarded)
    {
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        this.CollectApples(apples:  appleAwarded);
        this = ???;
        goto typeof(PvpCrownClashEvent).__il2cppRuntimeField_2B0;
    }
    public override void UpdateProgress()
    {
        PvpCrownClashEvent.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public bool CanEngageWithEvent()
    {
        Player val_1 = App.Player;
        if(val_1.isHacker == true)
        {
                return false;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40})) == true)
        {
                return false;
        }
        
        this.CheckCalculateReward();
        return false;
    }
    private void ResetData()
    {
        if((CPlayerPrefs.HasKey(key:  "lastPvpCrownClashCrown")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "lastPvpCrownClashCrown");
        }
        
        if((CPlayerPrefs.HasKey(key:  "pvpCrownsCollectedThisLevel")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "pvpCrownsCollectedThisLevel");
        }
        
        if((CPlayerPrefs.HasKey(key:  "ccPvpData")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "ccPvpData");
        }
        
        if(this.thisEventData != null)
        {
                this.thisEventData.Clear();
        }
        
        this.hasInit = false;
        CPlayerPrefs.Save();
    }
    private void CheckData(GameEventV2 gameEvent)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10;
        var val_11;
        val_10 = 1152921504874684416;
        if((CPlayerPrefs.HasKey(key:  "ccPvpData")) == false)
        {
            goto label_16;
        }
        
        val_10 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "ccPvpData"));
        if((val_10.ContainsKey(key:  "id")) == false)
        {
            goto label_9;
        }
        
        object val_5 = val_10.Item["id"];
        if(gameEvent != null)
        {
            goto label_12;
        }
        
        goto label_16;
        label_9:
        val_11 = 0;
        label_12:
        if(gameEvent.id == val_11)
        {
                this.thisEventData = val_10;
            if((val_10.ContainsKey(key:  "playerCrowns")) == false)
        {
                return;
        }
        
            bool val_9 = System.Int32.TryParse(s:  this.thisEventData.Item["playerCrowns"], result: out  this._membershipCrowns);
            return;
        }
        
        this.ResetData();
        label_16:
        this.GenerateNewEventData();
    }
    private void GenerateNewEventData()
    {
        var val_36;
        var val_37;
        int val_38;
        System.Collections.Generic.List<T> val_39;
        var val_40;
        var val_41;
        float val_42;
        int val_43;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_36 = 1152921515419383392;
        val_1.Add(key:  "name", value:  SLC.Social.SocialManager.GetRandomProfileName());
        val_37 = 1152921504619999232;
        val_1.Add(key:  "oppAvatar", value:  SLC.Social.SocialManager.GetRandomAvatarID());
        int val_4 = UnityEngine.Random.Range(min:  this.aiMinScore, max:  this.aiMaxScore);
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = "nw_t_l"}, d2:  new System.DateTime() {dateData = "Myself HUD"});
        val_38 = System.Math.Max(val1:  1, val2:  val_5._ticks.Days);
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_8 = null;
        val_39 = val_8;
        val_8 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.List<System.Int32> val_9 = new System.Collections.Generic.List<System.Int32>();
        val_40 = 1152921510479955696;
        val_9.Add(item:  3);
        val_9.Add(item:  4);
        val_9.Add(item:  5);
        val_9.Add(item:  6);
        if()
        {
                float val_37 = 0.85f;
            float val_36 = 1.15f;
            val_40 = 1152921516173237664;
            int val_11 = val_4 / val_38;
            val_41 = 0;
            var val_44 = 0;
            do
        {
            if(val_11 != 0)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_36 = (val_41 != 1) ? ((float)val_11 * val_36) : ((float)val_11);
            val_37 = (val_41 != 1) ? ((float)val_11) : ((float)val_11 * val_37);
            val_42 = UnityEngine.Random.Range(min:  val_37, max:  val_36);
            int val_16 = UnityEngine.Mathf.FloorToInt(f:  val_42);
            object val_18 = (val_44 == (val_38 - 1)) ? (val_4) : (val_16);
            if(mem[1152921516173349528] >= 1)
        {
                int val_19 = UnityEngine.Random.Range(min:  0, max:  mem[1152921516173349528]);
            if(mem[1152921516173349528] <= val_19)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_38 = mem[1152921516173349520];
            val_38 = val_38 + (val_19 << 2);
            val_43 = mem[(mem[1152921516173349520] + (val_19) << 2) + 32];
            val_43 = (mem[1152921516173349520] + (val_19) << 2) + 32;
            bool val_20 = val_9.Remove(item:  val_43);
        }
        else
        {
                val_43 = UnityEngine.Random.Range(min:  3, max:  7);
        }
        
            System.Collections.Generic.List<System.Int32> val_23 = new System.Collections.Generic.List<System.Int32>(collection:  new int[12]);
            if(mem[1152921516173349528] >= 1)
        {
                var val_40 = val_18;
            float val_39 = 0.7f;
            var val_41 = 0;
            int val_25 = val_40 / val_43;
            do
        {
            val_36 = (0 != 1) ? ((float)val_25) : ((float)val_25 * 1.3f);
            val_39 = (0 != 1) ? ((float)val_25 * val_39) : ((float)val_25);
            val_42 = UnityEngine.Random.Range(min:  val_39, max:  val_36);
            int val_29 = UnityEngine.Mathf.FloorToInt(f:  val_42);
            int val_30 = ((val_43 - 1) == val_41) ? (val_40) : (val_29);
            val_40 = val_40 - val_30;
            var val_31 = (val_29 > val_25) ? 1 : 0;
            val_23.set_Item(index:  0, value:  val_30);
            val_41 = val_41 + 1;
        }
        while(val_41 < val_43);
        
        }
        
            PluginExtension.Shuffle<System.Int32>(list:  val_23, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            int val_42 = val_4;
            val_37 = 1152921504619999232;
            val_42 = val_42 - val_18;
            var val_43 = 2;
            do
        {
            if(val_43 < 1152921515450622480)
        {
                val_23.Insert(index:  2, item:  0);
        }
        else
        {
                val_23.Add(item:  0);
        }
        
            val_43 = val_43 + 2;
        }
        while(val_43 != 26);
        
            val_36 = 1152921515419383392;
            val_14.Add(key:  "crn", value:  val_18);
            val_14.Add(key:  "frg", value:  val_23);
            val_39 = val_39;
            val_41 = (val_16 > val_11) ? 1 : 0;
            val_8.Add(item:  val_14);
            val_38 = val_38;
        }
        
            val_44 = val_44 + 1;
        }
        while(val_44 < val_38);
        
        }
        
        PluginExtension.Shuffle<System.Collections.Generic.Dictionary<System.String, System.Object>>(list:  val_8, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        val_1.Add(key:  "dayData", value:  MiniJSON.Json.Serialize(obj:  val_8));
        val_1.Add(key:  "playerCrowns", value:  0);
        val_1.Add(key:  "id", value:  mem[1152921516173301136] + 56);
        System.DateTime val_33 = DateTimeCheat.UtcNow;
        val_1.Add(key:  "startTime", value:  val_33.dateData.ToString());
        mem[1152921516173301152] = val_1;
        val_1.Add(key:  "finalScore", value:  this.getOpponentCrowns(basedOnTime:  new System.DateTime() {dateData = mem[1152921516173301136] + 40}));
        this.SavePlayerData();
    }
    private void SavePlayerData()
    {
        if(this.thisEventData == null)
        {
                return;
        }
        
        if(this.thisEventData.Keys.Count == 0)
        {
                return;
        }
        
        if((this.thisEventData.ContainsKey(key:  "playerCrowns")) != false)
        {
                this.thisEventData.set_Item(key:  "playerCrowns", value:  this._membershipCrowns);
        }
        else
        {
                this.thisEventData.Add(key:  "playerCrowns", value:  this._membershipCrowns);
        }
        
        this = MiniJSON.Json.Serialize(obj:  this.thisEventData);
        CPlayerPrefs.SetString(key:  "ccPvpData", val:  this);
        CPlayerPrefs.Save();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_20;
        var val_21;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  PrettyPrint.printJSON(obj:  eventData, types:  false, singleLineOutput:  false));
        }
        
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
            goto label_10;
        }
        
        object val_5 = eventData.Item["economy"];
        if((val_5.ContainsKey(key:  "ai_min")) != false)
        {
                if((System.Int32.TryParse(s:  val_5.Item["ai_min"], result: out  this.aiMinScore)) != true)
        {
                UnityEngine.Debug.LogError(message:  "unable to parse ai min score");
        }
        
        }
        
        if((val_5.ContainsKey(key:  "ai_max")) != false)
        {
                if((System.Int32.TryParse(s:  val_5.Item["ai_max"], result: out  this.aiMaxScore)) != true)
        {
                UnityEngine.Debug.LogError(message:  "unable to parse ai max score");
        }
        
        }
        
        if((val_5.ContainsKey(key:  "coins")) == false)
        {
            goto label_24;
        }
        
        object val_15 = val_5.Item["coins"];
        val_20 = 0;
        goto label_27;
        label_10:
        UnityEngine.Debug.LogError(message:  "no Crown Clash pvp econ values found");
        return;
        label_27:
        this.eventCoinRewards = ;
        label_24:
        if((val_5.ContainsKey(key:  "golden")) == false)
        {
                return;
        }
        
        object val_18 = val_5.Item["golden"];
        val_21 = 0;
        this.eventAppleRewards = ;
    }
    private void CollectApples(int apples)
    {
        var val_11;
        var val_12;
        var val_13;
        val_11 = this;
        val_12 = 1152921504886665216;
        val_13 = null;
        val_13 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
                return;
        }
        
        int val_1 = this._membershipCrowns + apples;
        this._membershipCrowns = val_1;
        int val_2 = System.Math.Min(val1:  val_1, val2:  999999);
        this._membershipCrowns = val_2;
        int val_3 = val_2.crownsCollectedThisLevel;
        val_3.crownsCollectedThisLevel = val_3 + apples;
        val_11 = ???;
        val_12 = ???;
        goto typeof(PvpCrownClashEvent).__il2cppRuntimeField_2B0;
    }
    public int getOpponentCrowns()
    {
        var val_3;
        int val_4;
        val_3 = null;
        val_3 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                System.DateTime val_1 = DateTimeCheat.UtcNow;
            val_4 = this;
            this.lastKnownCrowns = this.getOpponentCrowns(basedOnTime:  new System.DateTime() {dateData = val_1.dateData});
            return val_4;
        }
        
        val_4 = this.lastKnownCrowns;
        return val_4;
    }
    private int getOpponentCrowns(System.DateTime basedOnTime)
    {
        var val_12;
        var val_13;
        ulong val_35;
        var val_36;
        var val_37;
        string val_38;
        var val_39;
        var val_40;
        float val_41;
        var val_42;
        if((this.thisEventData.ContainsKey(key:  "dayData")) == false)
        {
            goto label_28;
        }
        
        val_35 = "startTime";
        if((this.thisEventData.ContainsKey(key:  "startTime")) == false)
        {
            goto label_28;
        }
        
        System.DateTime val_4 = System.DateTime.UtcNow;
        System.DateTime val_5 = SLCDateTime.Parse(dateTime:  this.thisEventData.Item["startTime"], defaultValue:  new System.DateTime() {dateData = val_4.dateData});
        val_35 = val_5.dateData;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime() {dateData = 16140901064495857664});
        System.TimeSpan val_7 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = basedOnTime.dateData}, d2:  new System.DateTime() {dateData = 16140901064495857664});
        val_36 = 1152921504687730688;
        System.Collections.Generic.List<System.Object> val_10 = new System.Collections.Generic.List<System.Object>();
        List.Enumerator<T> val_11 = MiniJSON.Json.Deserialize(json:  this.thisEventData.Item["dayData"]).GetEnumerator();
        val_37 = "frg";
        label_23:
        val_38 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_13.MoveNext() == false)
        {
            goto label_15;
        }
        
        val_39 = val_12;
        if(val_39 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = "frg";
        object val_15 = val_39.Item[val_38];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40 = 0;
        val_10.AddRange(collection:  null);
        goto label_23;
        label_15:
        val_13.Dispose();
        System.TimeSpan val_16 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 16140901064495857664});
        val_41 = System.Single.Parse(s:  val_16._ticks.TotalHours.ToString());
        int val_20 = UnityEngine.Mathf.FloorToInt(f:  val_41);
        if(val_20 < 1)
        {
            goto label_28;
        }
        
        val_41 = 60f;
        var val_36 = 0;
        val_42 = 0;
        val_37 = (long)val_20;
        label_43:
        if(val_36 >= 32555008)
        {
                return (int)val_42;
        }
        
        System.DateTime val_21 = 0.AddHours(value:  0);
        System.TimeSpan val_22 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_21.dateData}, d2:  new System.DateTime() {dateData = val_35});
        ulong val_34 = val_21.dateData;
        System.TimeSpan val_23 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_34}, d2:  new System.DateTime() {dateData = basedOnTime.dateData});
        if(val_22._ticks.TotalHours < 0)
        {
            goto label_42;
        }
        
        if(val_36 >= val_34)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_34 = val_34 + 0;
        int val_25 = System.Int32.Parse(s:  (val_21.dateData + 0) + 32);
        if(val_25 == 0)
        {
            goto label_42;
        }
        
        val_36 = val_21.dateData.Day;
        if(val_36 != basedOnTime.dateData.Day)
        {
            goto label_38;
        }
        
        val_36 = val_21.dateData.Hour;
        if(val_36 != basedOnTime.dateData.Hour)
        {
            goto label_38;
        }
        
        float val_35 = (float)val_25;
        val_35 = ((float)val_7._ticks.Minutes / val_41) * val_35;
        val_42 = (UnityEngine.Mathf.FloorToInt(f:  val_35)) + val_42;
        goto label_42;
        label_38:
        if(val_23._ticks.TotalHours <= 0f)
        {
                val_42 = val_25 + val_42;
        }
        
        label_42:
        val_36 = val_36 + 1;
        if(val_36 < val_37)
        {
            goto label_43;
        }
        
        return (int)val_42;
        label_28:
        val_42 = 0;
        return (int)val_42;
    }
    public bool canCollectReward()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
        double val_3 = val_2._ticks.TotalSeconds;
        if((this.thisEventData.ContainsKey(key:  "rewarded")) == true)
        {
            goto label_15;
        }
        
        val_8 = this.thisEventData;
        if(val_8.Count == 0)
        {
            goto label_17;
        }
        
        if((CPlayerPrefs.HasKey(key:  "ccPvpData")) == false)
        {
            goto label_15;
        }
        
        val_8 = this.thisEventData;
        bool val_7 = val_8.ContainsKey(key:  "reward");
        goto label_17;
        label_15:
        val_8 = 0;
        label_17:
        val_8 = val_8 & 1;
        return (bool)val_8;
    }
    public void CheckCalculateReward()
    {
        var val_23;
        ulong val_24;
        string val_25;
        var val_26;
        object val_27;
        string val_28;
        val_23 = this;
        if(this.thisEventData == null)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        val_24 = val_1.dateData;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 41971712}, d2:  new System.DateTime() {dateData = val_24});
        double val_3 = val_2._ticks.TotalSeconds;
        if((this.thisEventData.ContainsKey(key:  "rewarded")) == true)
        {
                return;
        }
        
        if(this.thisEventData.Count == 0)
        {
                return;
        }
        
        if((CPlayerPrefs.HasKey(key:  "ccPvpData")) == false)
        {
                return;
        }
        
        if((this.thisEventData.ContainsKey(key:  "reward")) == true)
        {
                return;
        }
        
        int val_9 = System.Int32.Parse(s:  this.thisEventData.Item["finalScore"]);
        if(this._membershipCrowns < val_9)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_10 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_24 = 1152921515419383392;
            val_10.Add(key:  "coins", value:  0);
            val_10.Add(key:  "golden", value:  0);
            val_25 = "reward";
            val_26 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_27 = val_10;
        }
        else
        {
                var val_23 = val_9;
            System.Collections.Generic.List<TSource> val_12 = System.Linq.Enumerable.ToList<System.String>(source:  PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY + 64.Keys);
            val_28 = "0";
            if(1152921510375394352 >= 1)
        {
                var val_24 = 0;
            val_23 = val_23 + this._membershipCrowns;
            do
        {
            if(1152921510375394352 <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_23 >= (System.Int32.Parse(s:  ToString())))
        {
                if(null <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_28 = mem[.SyncRoot + 32];
        }
        
            val_24 = val_24 + 1;
        }
        while(val_24 < null);
        
        }
        
            System.Collections.Generic.Dictionary<System.String, System.Object> val_15 = null;
            val_24 = val_15;
            val_15 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_15.Add(key:  "coins", value:  this.eventCoinRewards.Item[val_28]);
            val_15.Add(key:  "golden", value:  this.eventAppleRewards.Item[val_28]);
            val_25 = "reward";
            val_26 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            val_27 = val_24;
        }
        
        this.thisEventData.Add(key:  val_25, value:  val_15);
        val_23 = 1152921504893161472;
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<PvPCrownClashPopup>()) != false)
        {
                UnityEngine.Object.FindObjectOfType<PvPCrownClashPopup>().DisplayCrownClashResult();
            return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PvPCrownClashPopup>(showNext:  false).SetUpWindow(fromGameButton:  false);
    }
    public void CollectReward()
    {
        object val_1 = PvpCrownClashEvent.LAST_PROGRESS_STAMP_KEY.rewardData;
        int val_3 = System.Int32.Parse(s:  val_1.Item["coins"]);
        this.thisEventData.Add(key:  "rewarded", value:  true);
        this.SavePlayerData();
        if(val_3 >= 1)
        {
                decimal val_7 = System.Decimal.op_Implicit(value:  val_3);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  "ApplePicking", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
        if((System.Int32.Parse(s:  val_1.Item["golden"])) < 1)
        {
                return;
        }
        
        GoldenApplesManager val_8 = MonoSingleton<GoldenApplesManager>.Instance;
    }
    public void AddHackedCrowns(int crowns)
    {
        int val_2 = crowns;
        val_2 = this._membershipCrowns + val_2;
        this._membershipCrowns = val_2;
        this._membershipCrowns = System.Math.Min(val1:  val_2, val2:  999999);
        this.SavePlayerData();
    }
    public PvpCrownClashEvent()
    {
        this.aiMinScore = 375;
        this.aiMaxScore = 500;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "0", value:  10);
        val_1.Add(key:  "100", value:  25);
        val_1.Add(key:  "250", value:  50);
        val_1.Add(key:  "500", value:  100);
        val_1.Add(key:  "750", value:  250);
        val_1.Add(key:  "1000", value:  500);
        this.eventCoinRewards = val_1;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "0", value:  3);
        val_2.Add(key:  "100", value:  5);
        val_2.Add(key:  "250", value:  10);
        val_2.Add(key:  "500", value:  25);
        val_2.Add(key:  "750", value:  70);
        val_2.Add(key:  "1000", value:  140);
        this.eventAppleRewards = val_2;
    }

}
