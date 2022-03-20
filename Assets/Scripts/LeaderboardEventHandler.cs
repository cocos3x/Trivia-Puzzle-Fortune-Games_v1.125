using UnityEngine;
public class LeaderboardEventHandler : WGEventHandler
{
    // Fields
    public const string LEADERBOARD_EVENT_ID = "Leaderboard";
    public const string SHOW_RANK_UP_FLYOUT = "ShowRankupFlyout";
    public LeaderboardEventPlayerInfo_Self playerInfo;
    public System.Collections.Generic.List<LeaderboardPlayerInfo> rankedPlayerInfo;
    public System.Collections.Generic.List<LeaderboardTier> leaderboardTiers;
    private const string ECONOMY = "economy";
    private const string ECON = "value";
    private const string MIN = "min";
    private const string MAX = "max";
    private const string REW = "rew";
    private const string LEADERBOARD = "leaderboard";
    private const string NAME = "name";
    private const string STATS = "stats";
    private const string AVATAR = "avatar";
    private const string RANK = "rank";
    private const string MEMBERSHIP = "membership";
    private const string FBID = "fbid";
    private const string USEFB = "use_fb";
    private const string INDEX = "index";
    private const string APPLES = "apples";
    private const string FINAL_REWARD = "final_reward";
    private const string FINAL_RANK = "final_rank";
    private const string REWARDED = "rewarded";
    private const string pref_shown_leaderboard_first_entry = "lbd_first_entry";
    private const string pref_pulled_leaderboard_latest_info = "lbd_pulled_latest_info";
    private const string LAST_PROGRESS_STAMP_KEY = "lbd_LastProgressTimestamp";
    private const string pref_server_timestamp_key = "lbd_timestamp";
    private static LeaderboardEventHandler instance;
    private bool dataInitialized;
    private static int savedProgress;
    private static System.DateTime lastServerUpdate;
    private static int secondsToLastUpdate;
    
    // Properties
    public static LeaderboardEventHandler Instance { get; }
    private bool pulledLastestLeaderboardInfo { get; set; }
    private bool shownLeaderboardOnFirstEntering { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    private int eventTimestamp { get; set; }
    public override bool SupportsGoldenApples { get; }
    public bool IsInLeaderboard { get; }
    
    // Methods
    public static LeaderboardEventHandler get_Instance()
    {
        null = null;
        return (LeaderboardEventHandler)LeaderboardEventHandler.instance;
    }
    private bool get_pulledLastestLeaderboardInfo()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "lbd_pulled_latest_info", defaultValue:  0)) == 1) ? 1 : 0;
    }
    private void set_pulledLastestLeaderboardInfo(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lbd_pulled_latest_info", value:  value);
    }
    private bool get_shownLeaderboardOnFirstEntering()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "lbd_first_entry", defaultValue:  0)) == 1) ? 1 : 0;
    }
    private void set_shownLeaderboardOnFirstEntering(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "lbd_first_entry", value:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "lbd_LastProgressTimestamp", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "lbd_LastProgressTimestamp", value:  value);
    }
    private int get_eventTimestamp()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "lbd_timestamp", defaultValue:  0);
    }
    private void set_eventTimestamp(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "lbd_timestamp", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        var val_2;
        mem[1152921517578387856] = eventV2;
        int val_1 = this.eventTimestamp;
        if(eventV2.serverTimestamp != val_1)
        {
                val_1.eventTimestamp = eventV2.serverTimestamp;
            this.ClearEventData();
        }
        
        val_2 = null;
        val_2 = null;
        LeaderboardEventHandler.instance = this;
        this.ParseEventData(eventData:  eventV2.eventData);
        this.dataInitialized = true;
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(true == 0)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  0, b:  "Leaderboard")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        if(this.dataInitialized == true)
        {
                return;
        }
        
        this.ParseEventData(eventData:  eventV2.eventData);
        this.dataInitialized = true;
        bool val_4 = this.InExpireSession();
        if(val_4 == false)
        {
                return;
        }
        
        if(val_4.rewarded == true)
        {
                return;
        }
        
        GameBehavior val_6 = App.getBehavior;
        if((val_6.<metaGameBehavior>k__BackingField) == 1)
        {
                return;
        }
        
        val_6.<metaGameBehavior>k__BackingField.ShowLeaderboardCompletePopup();
    }
    public override void OnEventEnded()
    {
        this.ClearEventData();
    }
    public override bool EventCompleted()
    {
        if(this.playerInfo != null)
        {
                return this.playerInfo.rewarded;
        }
        
        throw new NullReferenceException();
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override string GetEventDisplayName()
    {
        null = null;
        if(App.game != 17)
        {
                return Localization.Localize(key:  "leaderboard_upper", defaultValue:  "LEADERBOARD", useSingularKey:  false);
        }
        
        return "LEADERBOARDS";
    }
    public override void OnMenuLoaded()
    {
        bool val_1 = this.InExpireSession();
        if(val_1 == false)
        {
                return;
        }
        
        bool val_2 = val_1.rewarded;
        if(val_2 != false)
        {
                return;
        }
        
        val_2.ShowLeaderboardCompletePopup();
    }
    public override void OnGameSceneBegan()
    {
        var val_11;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        }
        
        if(this.HandlingExpireSession() == true)
        {
                return;
        }
        
        bool val_5 = this.InExpireSession();
        if(val_5 == false)
        {
            goto label_11;
        }
        
        bool val_6 = val_5.rewarded;
        if(val_6 == false)
        {
            goto label_13;
        }
        
        label_11:
        bool val_7 = val_6.shownLeaderboardOnFirstEntering;
        if(val_7 == true)
        {
            goto label_25;
        }
        
        val_7.shownLeaderboardOnFirstEntering = true;
        val_11 = null;
        val_11 = null;
        if(App.game != 17)
        {
            goto label_20;
        }
        
        GameBehavior val_8 = App.getBehavior;
        goto label_25;
        label_13:
        val_6.ShowLeaderboardCompletePopup();
        return;
        label_20:
        this.ShowLeaderboardPopup();
        label_25:
        if(this.playerInfo.notifyRankup == false)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ShowRankupFlyout");
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_3;
        bool val_1 = this.InExpireSession();
        if(val_1 == false)
        {
            goto label_1;
        }
        
        bool val_2 = val_1.rewarded;
        if(val_2 == false)
        {
            goto label_3;
        }
        
        label_1:
        if(connected != false)
        {
                this.ShowLeaderboardPopup();
            val_3 = null;
            val_3 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 43;
            return;
        }
        
        val_2.ShowInternetRequiredPopup();
        return;
        label_3:
        val_2.ShowLeaderboardCompletePopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_3;
        bool val_1 = this.InExpireSession();
        if(val_1 == false)
        {
            goto label_1;
        }
        
        bool val_2 = val_1.rewarded;
        if(val_2 == false)
        {
            goto label_3;
        }
        
        label_1:
        if(connected != false)
        {
                this.ShowLeaderboardPopup();
            val_3 = null;
            val_3 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 44;
            return;
        }
        
        val_2.ShowInternetRequiredPopup();
        return;
        label_3:
        val_2.ShowLeaderboardCompletePopup();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        LeaderboardEventPlayerInfo_Self val_9;
        string val_10;
        System.Char[] val_11;
        string val_12;
        val_9 = this;
        string val_1 = this.GetCurrentRankText();
        val_10 = val_1;
        if((val_1.Contains(value:  "+")) != false)
        {
                char[] val_3 = new char[1];
            val_11 = val_3;
            val_11[0] = '+';
            val_10 = val_10.TrimEnd(trimChars:  val_3);
            val_12 = 0;
            val_9 = this.playerInfo;
        }
        else
        {
                val_11 = 0;
            val_12 = Ordinal.AddOrdinal(num:  this.playerInfo);
        }
        
        decimal val_6 = System.Decimal.op_Implicit(value:  null);
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentLeaderboard>(allowMultiple:  false).SetupLeaderboardPlayerInfo(rank:  val_10, suffix:  val_12, apples:  NumberAbbreviation.GetNumber(num:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}));
    }
    public override void OnAppleAwarded(int appleAwarded)
    {
        if(this.InExpireSession() != false)
        {
                return;
        }
        
        this.UpdateProgressionToServer(progress:  appleAwarded, rewarded:  false);
    }
    public override int LastProgressTimestamp()
    {
        return LeaderboardEventHandler.LastProgressTimestampPref;
    }
    public override bool IsExcludedFromGameSceneButtonOrdering()
    {
        return true;
    }
    public override void UpdateProgress()
    {
        LeaderboardEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override string GetMainMenuButtonText()
    {
        object val_8;
        System.Object[] val_9;
        var val_10;
        object val_12;
        var val_13;
        string val_14;
        int val_15;
        val_8 = this;
        val_10 = null;
        val_10 = null;
        if(App.game == 17)
        {
                string val_1 = Localization.Localize(key:  "leaderboards_upper", defaultValue:  "LEADERBOARDS", useSingularKey:  false);
            return (string)System.String.Format(format:  "{0} {1}<size={2}>{3}</size>", args:  object[] val_4 = new object[4]);
        }
        
        if(this.IsInLeaderboard != false)
        {
                val_12 = Ordinal.AddOrdinal(num:  this.playerInfo);
            val_13 = 40;
        }
        else
        {
                val_13 = 45;
            val_12 = "+";
        }
        
        val_9 = val_4;
        val_14 = "LEADERBOARD";
        val_9[0] = Localization.Localize(key:  "leaderboard_upper", defaultValue:  val_14, useSingularKey:  false);
        val_9[1] = this.playerInfo.ToString();
        val_8 = 45;
        val_15 = val_4.Length;
        val_9[2] = val_8;
        val_15 = val_4.Length;
        val_9[3] = val_12;
        return (string)System.String.Format(format:  "{0} {1}<size={2}>{3}</size>", args:  val_4);
    }
    public override string GetGameButtonText()
    {
        LeaderboardEventPlayerInfo_Self val_5;
        object val_6;
        var val_7;
        val_5 = this;
        if(this.IsInLeaderboard != false)
        {
                val_6 = Ordinal.AddOrdinal(num:  this.playerInfo);
            val_7 = 36;
            return (string)System.String.Format(format:  "{0}<size={1}>{2}</size>", arg0:  mem[this.playerInfo].ToString(), arg1:  54, arg2:  val_6 = "+");
        }
        
        val_5 = this.playerInfo;
        val_7 = 54;
        return (string)System.String.Format(format:  "{0}<size={1}>{2}</size>", arg0:  mem[this.playerInfo].ToString(), arg1:  54, arg2:  val_6);
    }
    public override void OnFacebookPluginUpdate()
    {
        goto typeof(LeaderboardEventHandler).__il2cppRuntimeField_3F0;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_75;
        var val_76;
        var val_77;
        var val_78;
        var val_79;
        val_75 = eventData;
        this.ResetEventDataBeforeParsing();
        if((val_75.ContainsKey(key:  "economy")) == false)
        {
            goto label_28;
        }
        
        val_75 = val_75.Item["economy"];
        if((val_75.ContainsKey(key:  "value")) == false)
        {
            goto label_28;
        }
        
        val_75 = val_75.Item["value"];
        if(null < 1)
        {
            goto label_28;
        }
        
        val_76 = "max";
        val_77 = 1152921510222861648;
        var val_75 = 0;
        label_23:
        if(val_75 >= 1152921504976707584)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((((ContainsKey(key:  "min")) == false) || ((ContainsKey(key:  "max")) == false)) || ((ContainsKey(key:  "rew")) == false))
        {
            goto label_17;
        }
        
        bool val_12 = System.Int32.TryParse(s:  Item["min"], result: out  (LeaderboardTier)[1152921517580958480].upperLevel);
        bool val_15 = System.Int32.TryParse(s:  Item["max"], result: out  (LeaderboardTier)[1152921517580958480].lowerLevel);
        bool val_18 = System.Int32.TryParse(s:  Item["rew"], result: out  (LeaderboardTier)[1152921517580958480].reward);
        this.leaderboardTiers.Add(item:  new LeaderboardTier());
        val_75 = val_75 + 1;
        if(val_75 < 1152921517580760304)
        {
            goto label_23;
        }
        
        goto label_28;
        label_17:
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "something wrong with the econ values setup!");
        }
        
        label_28:
        val_78 = 1152921510222861648;
        if((val_75.ContainsKey(key:  "leaderboard")) != false)
        {
                val_77 = 1152921510214912464;
            val_75 = val_75.Item["leaderboard"];
            if(null >= 1)
        {
                do
        {
            LeaderboardPlayerInfo val_23 = new LeaderboardPlayerInfo();
            if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.ContainsKey(key:  "stats")) != false)
        {
                bool val_27 = System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["stats"], result: out  val_23);
        }
        
            val_79 = public System.Boolean System.Collections.Generic.Dictionary<System.String, System.Object>::ContainsKey(System.String key);
            if((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.ContainsKey(key:  "rank")) != false)
        {
                bool val_31 = System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["rank"], result: out  val_23);
        }
        
            string val_32 = SLC.Social.SocialManager.ProfileName;
            if((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.ContainsKey(key:  "membership")) != false)
        {
                object val_34 = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["membership"];
            if((val_34.ContainsKey(key:  "name")) != false)
        {
                object val_36 = val_34.Item["name"];
        }
        
            if((val_34.ContainsKey(key:  "avatar")) != false)
        {
                bool val_40 = System.Int32.TryParse(s:  val_34.Item["avatar"], result: out  val_23);
        }
        
            if((val_34.ContainsKey(key:  "portrait_id")) != false)
        {
                object val_42 = val_34.Item["portrait_id"];
        }
        
            if((val_34.ContainsKey(key:  "use_fb")) != false)
        {
                bool val_45 = false;
            bool val_46 = System.Boolean.TryParse(value:  val_34.Item["use_fb"], result: out  val_45);
            val_77 = val_77;
            val_78 = 1152921510222861648;
            if(val_45 != 0)
        {
                if((val_34.ContainsKey(key:  "fbid")) != false)
        {
                object val_48 = val_34.Item["fbid"];
        }
        
        }
        
        }
        
        }
        
            this.rankedPlayerInfo.Add(item:  val_23);
            val_76 = 0 + 1;
        }
        while(val_76 < 1152921517580815168);
        
        }
        
        }
        
        if((val_75.ContainsKey(key:  "apples")) != false)
        {
                bool val_52 = System.Int32.TryParse(s:  val_75.Item["apples"], result: out  this.playerInfo);
        }
        
        if((val_75.ContainsKey(key:  "rank")) != false)
        {
                LeaderboardEventPlayerInfo_Self val_55 = this.playerInfo;
            bool val_56 = System.Int32.TryParse(s:  val_75.Item["rank"], result: out  val_55);
            val_75 = this.playerInfo;
            if(val_75 > val_55)
        {
                this.playerInfo.notifyRankup = true;
        }
        
        }
        
        if((val_75.ContainsKey(key:  "index")) != false)
        {
                int val_59 = this.playerInfo.rankIndex;
            bool val_60 = System.Int32.TryParse(s:  val_75.Item["index"], result: out  val_59);
            this.playerInfo.rankIndex = val_59;
        }
        
        if((val_75.ContainsKey(key:  "final_reward")) != false)
        {
                int val_63 = this.playerInfo.reward;
            bool val_64 = System.Int32.TryParse(s:  val_75.Item["final_reward"], result: out  val_63);
            this.playerInfo.reward = val_63;
        }
        
        if((val_75.ContainsKey(key:  "final_rank")) != false)
        {
                bool val_68 = System.Int32.TryParse(s:  val_75.Item["final_rank"], result: out  this.playerInfo);
        }
        
        bool val_69 = val_75.ContainsKey(key:  "rewarded");
        if(val_69 == false)
        {
                return;
        }
        
        bool val_73 = val_69.rewarded;
        System.Boolean.TryParse(value:  val_75.Item["rewarded"], result: out  val_73).rewarded = val_73;
    }
    private void ResetEventDataBeforeParsing()
    {
        LeaderboardEventPlayerInfo_Self val_1 = null;
        .rankIndex = 1;
        val_1 = new LeaderboardEventPlayerInfo_Self();
        this.playerInfo = val_1;
        this.rankedPlayerInfo = new System.Collections.Generic.List<LeaderboardPlayerInfo>();
        this.leaderboardTiers = new System.Collections.Generic.List<LeaderboardTier>();
    }
    private void DeletePlayerPref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    private bool InExpireSession()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40})) == false)
        {
                return false;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48});
    }
    private bool HandlingExpireSession()
    {
        var val_4;
        bool val_1 = this.playerInfo.rewarded;
        if(val_1 != false)
        {
                val_4 = 1;
            return (bool)val_4;
        }
        
        if(val_1.pulledLastestLeaderboardInfo != true)
        {
                bool val_3 = this.InExpireSession();
            if(val_3 != false)
        {
                val_4 = 1;
            val_3.pulledLastestLeaderboardInfo = true;
            return (bool)val_4;
        }
        
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    private void ShowLeaderboardPopup()
    {
        this.CheckPlayerRankInLeaderboard();
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaderboardPopup>(showNext:  false);
    }
    private void ShowLeaderboardCompletePopup()
    {
        if((MonoSingleton<WGWindowManager>.Instance) == 0)
        {
                return;
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaderboardCompletePopup>(showNext:  false);
    }
    private void ShowInternetRequiredPopup()
    {
        int val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ClearEventData()
    {
        var val_3;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lbd_pulled_latest_info")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lbd_pulled_latest_info");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lbd_first_entry")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lbd_first_entry");
        }
        
        this.playerInfo.ClearData();
        val_3 = null;
        val_3 = null;
        LeaderboardEventHandler.instance = 0;
    }
    private void CheckPlayerRankInLeaderboard()
    {
        System.Collections.Generic.List<LeaderboardPlayerInfo> val_7 = this.rankedPlayerInfo;
        if(W23 == 0)
        {
                return;
        }
        
        int val_1 = W23 - 1;
        val_7 = val_7 + (val_1 << 3);
        if(this.playerInfo != 41967616)
        {
                return;
        }
        
        if(this.playerInfo.rankIndex <= W23)
        {
                return;
        }
        
        string val_2 = SLC.Social.SocialManager.ProfileName;
        if(FacebookPlugin.IsLoggedIn != false)
        {
                Player val_4 = App.Player;
        }
        else
        {
                int val_5 = SLC.Social.SocialManager.AvatarID;
            string val_6 = SLC.Social.SocialManager.PortraitID;
        }
        
        this.playerInfo.rankIndex = ;
        this.rankedPlayerInfo.set_Item(index:  val_1, value:  41967616);
    }
    public void UpdateProgressionToServer(int progress, bool rewarded = False)
    {
        var val_7;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
        var val_9;
        var val_10;
        val_7 = null;
        val_7 = null;
        int val_7 = LeaderboardEventHandler.savedProgress;
        val_7 = val_7 + progress;
        LeaderboardEventHandler.savedProgress = val_7;
        val_8 = 1152921504616751104;
        System.DateTime val_1 = System.DateTime.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = LeaderboardEventHandler.lastServerUpdate});
        if(val_2._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        System.DateTime val_4 = System.DateTime.UtcNow;
        val_9 = null;
        val_9 = null;
        LeaderboardEventHandler.lastServerUpdate = val_4.dateData;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
        val_8 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "apples", value:  LeaderboardEventHandler.savedProgress);
        if(rewarded != false)
        {
                val_5.Add(key:  "rewarded", value:  true);
        }
        
        this.dataInitialized = false;
        val_10 = null;
        val_10 = null;
        LeaderboardEventHandler.savedProgress = 0;
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_5);
    }
    public string GetRemainingTime()
    {
        var val_20;
        string val_21;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
        val_20 = null;
        val_20 = null;
        object[] val_3 = new object[4];
        int val_4 = val_2._ticks.Days;
        if(App.game == 17)
        {
                val_3[0] = UnityEngine.Mathf.Max(a:  val_4, b:  0);
            val_3[1] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
            val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
            val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0);
            val_21 = "{0:0}d {1:00}h {2:00}m {3:00}s";
            return (string)System.String.Format(format:  val_21 = "{0:0}:{1:00}:{2:00}:{3:00}", args:  val_3);
        }
        
        val_3[0] = UnityEngine.Mathf.Max(a:  val_4, b:  0);
        val_3[1] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
        val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
        val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0);
        return (string)System.String.Format(format:  val_21, args:  val_3);
    }
    public string GetCurrentRankText()
    {
        System.Collections.Generic.List<LeaderboardTier> val_6;
        var val_7;
        System.Predicate<LeaderboardTier> val_9;
        System.Predicate<T> val_10;
        val_6 = this;
        val_7 = null;
        val_7 = null;
        val_9 = LeaderboardEventHandler.<>c.<>9__77_0;
        if(val_9 == null)
        {
                System.Predicate<LeaderboardTier> val_1 = null;
            val_9 = val_1;
            val_1 = new System.Predicate<LeaderboardTier>(object:  LeaderboardEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaderboardEventHandler.<>c::<GetCurrentRankText>b__77_0(LeaderboardTier x));
            LeaderboardEventHandler.<>c.<>9__77_0 = val_9;
        }
        
        val_10 = val_9;
        int val_2 = this.leaderboardTiers.FindIndex(match:  val_1);
        if(val_2 == 1)
        {
            goto label_7;
        }
        
        val_9 = this.playerInfo;
        if(null <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        LeaderboardEventPlayerInfo_Self val_3 = 1152921504977027072 + (val_2 << 3);
        var val_6 = mem[(1152921504977027072 + (val_2) << 3) + 32] + 16;
        if(val_9 >= val_6)
        {
            goto label_12;
        }
        
        label_7:
        string val_4 = this.playerInfo.ToString();
        return (string)(mem[(1152921504977027072 + (val_2) << 3) + 32] + 16 + ((long)(int)(val_2)) << 3) + 32 + 16((mem[(1152921504977027072 + (val_2) << 3) + 32] + 16 + ((long)(int)(val_2)) << 3) + 32 + 16) + "+"("+");
        label_12:
        val_6 = this.leaderboardTiers;
        if(val_6 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (((long)(int)(val_2)) << 3);
        return (string)(mem[(1152921504977027072 + (val_2) << 3) + 32] + 16 + ((long)(int)(val_2)) << 3) + 32 + 16((mem[(1152921504977027072 + (val_2) << 3) + 32] + 16 + ((long)(int)(val_2)) << 3) + 32 + 16) + "+"("+");
    }
    public bool get_IsInLeaderboard()
    {
        var val_4;
        var val_5;
        System.Predicate<LeaderboardTier> val_7;
        var val_8;
        val_4 = this;
        val_5 = null;
        val_5 = null;
        val_7 = LeaderboardEventHandler.<>c.<>9__79_0;
        if(val_7 == null)
        {
                System.Predicate<LeaderboardTier> val_1 = null;
            val_7 = val_1;
            val_1 = new System.Predicate<LeaderboardTier>(object:  LeaderboardEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaderboardEventHandler.<>c::<get_IsInLeaderboard>b__79_0(LeaderboardTier x));
            LeaderboardEventHandler.<>c.<>9__79_0 = val_7;
        }
        
        int val_2 = this.leaderboardTiers.FindIndex(match:  val_1);
        if(val_2 == 1)
        {
            goto label_7;
        }
        
        val_7 = this.leaderboardTiers;
        val_4 = this.playerInfo;
        if(null <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        LeaderboardEventPlayerInfo_Self val_3 = 1152921504977027072 + (val_2 << 3);
        if(val_4 >= (mem[(1152921504977027072 + (val_2) << 3) + 32] + 16))
        {
            goto label_12;
        }
        
        label_7:
        val_8 = 1;
        return (bool)val_8;
        label_12:
        val_8 = 0;
        return (bool)val_8;
    }
    public bool EventRewardsGems()
    {
        null = null;
        return (bool)(App.game == 17) ? 1 : 0;
    }
    public int GetCurrentReward()
    {
        System.Collections.Generic.List<LeaderboardTier> val_1;
        var val_2;
        val_1 = this;
        var val_1 = 0;
        label_13:
        if(val_1 >= this.leaderboardTiers)
        {
            goto label_2;
        }
        
        if(null <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + 1;
        if(this.leaderboardTiers != null)
        {
            goto label_13;
        }
        
        label_2:
        val_2 = 0;
        return (int);
    }
    public SLC.Social.Profile GetPlayerProfile()
    {
        if(this.playerInfo < 101)
        {
                if((this.rankedPlayerInfo != null) && (null >= 1))
        {
                if(this.playerInfo.rankIndex <= null)
        {
            goto label_6;
        }
        
        }
        
            UnityEngine.Debug.LogWarning(message:  "Leaderboard Info Not Found");
            return (SLC.Social.Profile)new SLC.Social.Profile();
        }
        
        if(FacebookPlugin.IsLoggedIn != false)
        {
                .UseFacebook = true;
            Player val_3 = App.Player;
            .FacebookId = val_3.properties.online_fb_id;
            return (SLC.Social.Profile)new SLC.Social.Profile();
        }
        
        .AvatarId = SLC.Social.SocialManager.AvatarID;
        label_32:
        .Portrait_ID = SLC.Social.SocialManager.PortraitID;
        return (SLC.Social.Profile)new SLC.Social.Profile();
        label_6:
        int val_6 = this.playerInfo.rankIndex - 1;
        if(null <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        LeaderboardEventPlayerInfo_Self val_7 = 1152921504977027072 + (val_6 << 3);
        if(FacebookPlugin.IsLoggedIn != false)
        {
                if((System.String.IsNullOrEmpty(value:  mem[(1152921504977027072 + ((this.playerInfo.rankIndex - 1)) << 3) + 32])) == true)
        {
                return (SLC.Social.Profile)new SLC.Social.Profile();
        }
        
            .FacebookId = mem[(1152921504977027072 + ((this.playerInfo.rankIndex - 1)) << 3) + 32];
            .UseFacebook = true;
            return (SLC.Social.Profile)new SLC.Social.Profile();
        }
        
        if((mem[(1152921504977027072 + ((this.playerInfo.rankIndex - 1)) << 3) + 32]) == 1)
        {
                return (SLC.Social.Profile)new SLC.Social.Profile();
        }
        
        .AvatarId = mem[(1152921504977027072 + ((this.playerInfo.rankIndex - 1)) << 3) + 32];
        goto label_32;
    }
    public LeaderboardEventHandler()
    {
        LeaderboardEventPlayerInfo_Self val_1 = null;
        .rankIndex = 1;
        val_1 = new LeaderboardEventPlayerInfo_Self();
        this.playerInfo = val_1;
        this.rankedPlayerInfo = new System.Collections.Generic.List<LeaderboardPlayerInfo>();
        this.leaderboardTiers = new System.Collections.Generic.List<LeaderboardTier>();
    }
    private static LeaderboardEventHandler()
    {
        LeaderboardEventHandler.savedProgress = 0;
        System.DateTime val_1 = System.DateTime.Now;
        LeaderboardEventHandler.lastServerUpdate = val_1.dateData;
        LeaderboardEventHandler.secondsToLastUpdate = 20;
    }

}
