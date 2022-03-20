using UnityEngine;
public class LevelChallengeHandler : WGEventHandler
{
    // Fields
    public const string LEVEL_CHALLENGE_EVENT_ID = "LevelChallenge";
    private static LevelChallengeHandler _Instance;
    private const int ECON_DEFAULT_NUMWINNERS = 100;
    private const int ECON_DEFAULT_LEVELSREQUIRED = 100;
    private const int ECON_DEFAULT_REWARD = 225;
    private const int ECON_DEFAULT_REWARD_GOLDENCURRENCY = 50;
    private const int WINS_REMAINING_INIT = 97;
    private const string WINS_REMAINING_COUNTER_START_TIME = "";
    private const int WINS_REMAINING_COUNTER_INTERVAL_INIT = 0;
    private const int WINS_REMAINING_COUNTER_INTERVAL_IN_SECONDS_MIN = 90;
    private const int WINS_REMAINING_COUNTER_INTERVAL_IN_SECONDS_MAX = 240;
    private const int COMPLETED_LEVELS_INIT = 0;
    private const string LEVEL_CHALLENGE_EVENT_END_TIME_INIT = "";
    private const string NUM_WINNERS_KEY = "LevelChallenge_NumWinners";
    private const string REQUIRED_LEVELS_KEY = "LevelChallenge_RequiredLevels";
    private const string REWARD_KEY = "LevelChallenge_Reward";
    private const string REWARD_GOLDENCURRENCY_KEY = "LevelChallenge_Reward_GoldCurrency";
    private const string COMPLETED_LEVELS_KEY = "LevelChallenge_CompletedLevels";
    private const string LAST_PROGRESS_STAMP_KEY = "LevelChallenge_LastProgressTimestamp";
    private const string WINS_REMAINING_KEY = "LevelChallenge_WinsRemaining";
    private const string WINS_REMAINING_COUNTER_INTERVAL_KEY = "LevelChallenge_WinsRemainingCounterInterval";
    private const string WINS_REMAINING_COUNTER_INTERVAL_MIN_KEY = "LevelChallenge_WinsRemainingCounterIntervalMin";
    private const string WINS_REMAINING_COUNTER_INTERVAL_MAX_KEY = "LevelChallenge_WinsRemainingCounterIntervalMax";
    private const string WINS_REMAINING_COUNTER_START_TIME_KEY = "LevelChallenge_WinsRemainingCounterStartTime";
    private const string CHALLENGE_COMPLETED_KEY = "LevelChallenge_ChallengeCompleted";
    private const string LEVEL_CHALLENGE_POPUP_SHOWN_KEY = "LevelChallengePopupShown";
    private const string LEVEL_CHALLENGE_EVENT_TIME_STAMP_KEY = "LevelChallengeEventEndTime";
    private const string ECONOMY = "economy";
    private const string NUMWINNERS = "num_winners";
    private const string BUCKETS = "buckets";
    private const string LEVELSREQUIRED = "levels_required";
    private const string REWARD = "reward";
    private const string REWARD_GOLDENCURRENCY = "golden_currency_reward";
    private const string WINSREMAINING = "num_prizes_remaining";
    private const string CD_MIN = "cd_min";
    private const string CD_MAX = "cd_max";
    private const string MAIN_MENU_BUTTON_TEXT = "LEVEL CHALLENGE";
    private const string GAME_BUTTON_TEXT = "EVENT";
    private const int TRUE = 1;
    private const int FALSE = 0;
    
    // Properties
    public static LevelChallengeHandler Instance { get; }
    public static bool InGame { get; }
    public static int NumWinners { get; set; }
    public static int RequiredLevels { get; set; }
    public static int Reward { get; set; }
    public static int RewardGoldenCurrency { get; set; }
    public static int WinsRemaining { get; set; }
    public static int CompletedLevels { get; set; }
    private static string LevelChallengEventTimeStamp { get; set; }
    private static int WinsRemainingCounterInterval { get; set; }
    private static int WinsRemainingCounterIntervalMin { get; set; }
    private static int WinsRemainingCounterIntervalMax { get; set; }
    private static string WinsRemainingCounterStartTime { get; set; }
    private static int ChallengeCompleted { get; set; }
    private static int LevelChallengePopupShown { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    
    // Methods
    public static LevelChallengeHandler get_Instance()
    {
        return (LevelChallengeHandler)LevelChallengeHandler.FALSE;
    }
    public static bool get_InGame()
    {
        return SceneDictator.IsInGameScene();
    }
    public static int get_NumWinners()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_NumWinners", defaultValue:  100);
    }
    public static void set_NumWinners(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_NumWinners", value:  value);
    }
    public static int get_RequiredLevels()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_RequiredLevels", defaultValue:  100);
    }
    public static void set_RequiredLevels(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_RequiredLevels", value:  value);
    }
    public static int get_Reward()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_Reward", defaultValue:  225);
    }
    public static void set_Reward(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_Reward", value:  value);
    }
    public static int get_RewardGoldenCurrency()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_Reward_GoldCurrency", defaultValue:  50);
    }
    public static void set_RewardGoldenCurrency(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_Reward_GoldCurrency", value:  value);
    }
    public static int get_WinsRemaining()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_WinsRemaining", defaultValue:  97);
    }
    public static void set_WinsRemaining(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_WinsRemaining", value:  value);
    }
    public static int get_CompletedLevels()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_CompletedLevels", defaultValue:  0);
    }
    public static void set_CompletedLevels(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_CompletedLevels", value:  value);
    }
    private static string get_LevelChallengEventTimeStamp()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "LevelChallengeEventEndTime", defaultValue:  "");
    }
    private static void set_LevelChallengEventTimeStamp(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "LevelChallengeEventEndTime", value:  value);
    }
    private static int get_WinsRemainingCounterInterval()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_WinsRemainingCounterInterval", defaultValue:  0);
    }
    private static void set_WinsRemainingCounterInterval(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_WinsRemainingCounterInterval", value:  value);
    }
    private static int get_WinsRemainingCounterIntervalMin()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_WinsRemainingCounterIntervalMin", defaultValue:  90);
    }
    private static void set_WinsRemainingCounterIntervalMin(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_WinsRemainingCounterIntervalMin", value:  value);
    }
    private static int get_WinsRemainingCounterIntervalMax()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_WinsRemainingCounterIntervalMax", defaultValue:  240);
    }
    private static void set_WinsRemainingCounterIntervalMax(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_WinsRemainingCounterIntervalMax", value:  value);
    }
    private static string get_WinsRemainingCounterStartTime()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "LevelChallenge_WinsRemainingCounterStartTime", defaultValue:  "");
    }
    private static void set_WinsRemainingCounterStartTime(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "LevelChallenge_WinsRemainingCounterStartTime", value:  value);
    }
    private static int get_ChallengeCompleted()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_ChallengeCompleted", defaultValue:  0);
    }
    private static void set_ChallengeCompleted(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_ChallengeCompleted", value:  value);
    }
    private static int get_LevelChallengePopupShown()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallengePopupShown", defaultValue:  0);
    }
    private static void set_LevelChallengePopupShown(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallengePopupShown", value:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "LevelChallenge_LastProgressTimestamp", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "LevelChallenge_LastProgressTimestamp", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        LevelChallengeHandler.FALSE = this;
        this.RefreshLevelChallengeInfo(eventV2:  eventV2);
    }
    public override void OnGameSceneBegan()
    {
        var val_5;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(LevelChallengeHandler.GetWinsRemaining() == 0)
        {
                val_5 = 1;
            LevelChallengeHandler.ChallengeCompleted = 1;
        }
        
        if(LevelChallengeHandler.LevelChallengePopupShown == 0)
        {
                if((this & 1) == 0)
        {
            goto label_7;
        }
        
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        LevelChallengeHandler.ShowLevelChallengeCompletePopup();
        return;
        label_7:
        this.ShowLevelChallengePopup();
        LevelChallengeHandler.LevelChallengePopupShown = 1;
    }
    public override void OnMenuLoaded()
    {
        if(LevelChallengeHandler.GetWinsRemaining() != 0)
        {
                return;
        }
        
        LevelChallengeHandler.ChallengeCompleted = 1;
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "level_challenge_upper", defaultValue:  "LEVEL CHALLENGE", useSingularKey:  false);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "level_challenge_upper", defaultValue:  "LEVEL CHALLENGE", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return (string)LevelChallengeHandler.CompletedLevels.ToString() + "/"("/") + LevelChallengeHandler.RequiredLevels.ToString();
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 25;
        ShowLevelChallengePopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (26 + 1) : 26;
        ShowLevelChallengePopup();
    }
    public override bool IsChallengeCompleted()
    {
        return (bool)(LevelChallengeHandler.ChallengeCompleted == 1) ? 1 : 0;
    }
    public override bool IsEventEndedOffline()
    {
        System.DateTime val_1 = System.Convert.ToDateTime(value:  new System.DateTime() {dateData = 504464731990392832});
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        int val_3 = val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_2.dateData});
        val_3 = val_3 >> 31;
        LevelChallengeHandler.ChallengeCompleted = val_3;
        return (bool)(LevelChallengeHandler.ChallengeCompleted == 1) ? 1 : 0;
    }
    public override void OnEventEnded()
    {
        this.DeletePlayerPrefs();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.RefreshLevelChallengeInfo(eventV2:  eventV2);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        int val_1 = LevelChallengeHandler.CompletedLevels;
        val_1 = val_1 + 1;
        LevelChallengeHandler.CompletedLevels = val_1;
        if(LevelChallengeHandler.CompletedLevels >= LevelChallengeHandler.RequiredLevels)
        {
                return;
        }
        
        int val_4 = LevelChallengeHandler.GetWinsRemaining();
        if(val_4 < 1)
        {
                return;
        }
        
        val_4.ShowLevelChallengeProgressPopup();
    }
    public override int LastProgressTimestamp()
    {
        return LevelChallengeHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        LevelChallengeHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        var val_6;
        if(LevelChallengeHandler.CompletedLevels == LevelChallengeHandler.RequiredLevels)
        {
                if(LevelChallengeHandler.GetWinsRemaining() >= 1)
        {
                var val_5 = (LevelChallengeHandler.ChallengeCompleted == 0) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public override bool EventCompleted()
    {
        return (bool)(LevelChallengeHandler.ChallengeCompleted == 1) ? 1 : 0;
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        string val_5 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  LevelChallengeHandler.CompletedLevels.ToString(), arg1:  LevelChallengeHandler.RequiredLevels.ToString());
        EventListItemContentProgressbar val_8 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentProgressbar>(allowMultiple:  false);
        float val_9 = (float)LevelChallengeHandler.CompletedLevels;
        val_9 = val_9 / (float)LevelChallengeHandler.RequiredLevels;
    }
    public static void ShowLevelChallengeCompletePopup()
    {
        if(LevelChallengeHandler.CompletedLevels != LevelChallengeHandler.RequiredLevels)
        {
                return;
        }
        
        if(LevelChallengeHandler.GetWinsRemaining() < 1)
        {
                return;
        }
        
        WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLevelChallengeCompletePopup>(showNext:  false);
        LevelChallengeHandler.ChallengeCompleted = 1;
    }
    public static int GetWinsRemaining()
    {
        ulong val_26;
        var val_27;
        if((System.String.op_Equality(a:  LevelChallengeHandler.WinsRemainingCounterStartTime, b:  "")) != false)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            LevelChallengeHandler.WinsRemainingCounterStartTime = val_3.dateData.ToString();
        }
        
        if(LevelChallengeHandler.WinsRemainingCounterInterval == 0)
        {
                LevelChallengeHandler.WinsRemainingCounterInterval = UnityEngine.Random.Range(min:  LevelChallengeHandler.WinsRemainingCounterIntervalMin, max:  LevelChallengeHandler.WinsRemainingCounterIntervalMax);
        }
        
        System.DateTime val_10 = System.Convert.ToDateTime(value:  LevelChallengeHandler.WinsRemainingCounterStartTime);
        val_26 = val_10.dateData;
        val_26 = val_10.dateData;
        System.DateTime val_11 = DateTimeCheat.UtcNow;
        System.TimeSpan val_12 = val_11.dateData.Subtract(value:  new System.DateTime() {dateData = val_26});
        val_27;
        float val_25 = (float)val_12._ticks.TotalSeconds;
        if(val_25 <= 0f)
        {
                return (int)LevelChallengeHandler.WinsRemaining;
        }
        
        do
        {
            if(LevelChallengeHandler.WinsRemaining <= 0)
        {
                return (int)LevelChallengeHandler.WinsRemaining;
        }
        
            val_25 = val_25 - (float)LevelChallengeHandler.WinsRemainingCounterInterval;
            if(val_25 >= 0f)
        {
                int val_16 = LevelChallengeHandler.WinsRemaining;
            val_16 = val_16 - 1;
            LevelChallengeHandler.WinsRemaining = val_16;
            System.DateTime val_18 = val_10.dateData.AddSeconds(value:  (double)LevelChallengeHandler.WinsRemainingCounterInterval);
            LevelChallengeHandler.WinsRemainingCounterStartTime = val_18.dateData.ToString();
            val_26 = LevelChallengeHandler.WinsRemainingCounterIntervalMin;
            LevelChallengeHandler.WinsRemainingCounterInterval = UnityEngine.Random.Range(min:  val_26, max:  LevelChallengeHandler.WinsRemainingCounterIntervalMax);
            val_27 = 0;
            bool val_23 = PrefsSerializationManager.SavePlayerPrefs();
        }
        
        }
        while(val_25 > 0f);
        
        return (int)LevelChallengeHandler.WinsRemaining;
    }
    private bool IsLastCycleEnded()
    {
        return System.String.op_Inequality(a:  LevelChallengeHandler.LevelChallengEventTimeStamp, b:  X8 + 16.ToString());
    }
    private void RefreshLevelChallengeInfo(GameEventV2 eventV2)
    {
        mem[1152921516332967616] = eventV2;
        if(eventV2 == null)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  eventV2.type, b:  "LevelChallenge")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        if(this.IsLastCycleEnded() == false)
        {
                return;
        }
        
        this.InitLevelChallengeInfo(data:  LevelChallengeHandler.__il2cppRuntimeField_typeDefinition);
        LevelChallengeHandler.LevelChallengEventTimeStamp = this.ToString();
    }
    private void InitLevelChallengeInfo(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_25 = data;
        Player val_1 = App.Player;
        string val_26 = val_1.playerBucket;
        bool val_2 = val_25.ContainsKey(key:  "economy");
        val_25 = 1152921504685600768;
        val_26 = 0;
        if(val_26 == 0)
        {
                val_25 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? val_25.Item["economy"] : 0;
        }
        
        if((val_25.ContainsKey(key:  "num_winners")) != false)
        {
                object val_5 = val_25.Item["num_winners"];
            LevelChallengeHandler.NumWinners = 19914752;
        }
        
        bool val_6 = val_25.ContainsKey(key:  "buckets");
        val_27 = 0;
        if(val_27 == 0)
        {
                val_25 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? val_25.Item["buckets"] : 0;
        }
        
        bool val_8 = val_25.ContainsKey(key:  val_26);
        val_28 = 0;
        if(val_28 == 0)
        {
                val_26 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? val_25.Item[val_26] : 0;
        }
        
        val_26 = "levels_required";
        if((val_26.ContainsKey(key:  "levels_required")) != false)
        {
                object val_11 = val_26.Item["levels_required"];
            LevelChallengeHandler.RequiredLevels = 19914752;
        }
        
        val_26 = "reward";
        if((val_26.ContainsKey(key:  "reward")) != false)
        {
                object val_13 = val_26.Item["reward"];
            LevelChallengeHandler.Reward = 19914752;
        }
        
        val_26 = "golden_currency_reward";
        if((val_26.ContainsKey(key:  "golden_currency_reward")) != false)
        {
                object val_15 = val_26.Item["golden_currency_reward"];
            LevelChallengeHandler.RewardGoldenCurrency = 19914752;
        }
        
        if((val_26.ContainsKey(key:  "num_prizes_remaining")) != false)
        {
                val_26 = val_26.Item["num_prizes_remaining"];
            val_25 = UnityEngine.Random.Range(min:  -3, max:  3);
            LevelChallengeHandler.WinsRemaining = 1152921504626761728 + val_25;
        }
        
        val_26 = "cd_min";
        if((val_26.ContainsKey(key:  "cd_min")) != false)
        {
                object val_21 = val_26.Item["cd_min"];
            LevelChallengeHandler.WinsRemainingCounterIntervalMin = 19914752;
        }
        
        val_26 = "cd_max";
        if((val_26.ContainsKey(key:  "cd_max")) != false)
        {
                object val_23 = val_26.Item["cd_max"];
            LevelChallengeHandler.WinsRemainingCounterIntervalMax = 19914752;
        }
        
        bool val_24 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void ShowLevelChallengePopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLevelChallengePopup>(showNext:  false);
    }
    private void ShowLevelChallengeProgressPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGLevelChallengeProgressPopup MetaGameBehavior::ShowUGUIMonolith<WGLevelChallengeProgressPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    private void DeletePlayerPrefs()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_NumWinners")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_NumWinners");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_RequiredLevels")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_RequiredLevels");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_Reward")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_Reward");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_CompletedLevels")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_CompletedLevels");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_WinsRemaining")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_WinsRemaining");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_WinsRemainingCounterInterval")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_WinsRemainingCounterInterval");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_WinsRemainingCounterIntervalMin")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_WinsRemainingCounterIntervalMin");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_WinsRemainingCounterIntervalMax")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_WinsRemainingCounterIntervalMax");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_WinsRemainingCounterStartTime")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_WinsRemainingCounterStartTime");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_ChallengeCompleted")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_ChallengeCompleted");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallengePopupShown")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallengePopupShown");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallengeEventEndTime")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallengeEventEndTime");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "LevelChallenge_LastProgressTimestamp")) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "LevelChallenge_LastProgressTimestamp");
    }
    public LevelChallengeHandler()
    {
    
    }

}
