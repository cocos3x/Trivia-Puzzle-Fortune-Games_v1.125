using UnityEngine;
public class WGDailyChallengeManager : MonoSingleton<WGDailyChallengeManager>
{
    // Fields
    private const float data_request_cooldown = 1;
    public const string DAILY_CHALLENGE_DATA_UPDATE = "OnDailyChallengeDataUpdate";
    public const int REQUIRED_STARS = 3;
    public const int DAILY_CHALLENGE_UNLOCK_LEVEL = 6;
    private readonly double EPSILON;
    private bool isRequesting;
    private bool dcRevamp;
    private int lastKnownCheatSeconds;
    private System.DateTime lastRequestSuccessTime;
    private System.Action<bool> currentRequestCallback;
    private System.Collections.Generic.List<ZooTile> monthZooTileCollection;
    private DailyChallenge_MonthHistory monthHistory;
    private DailyChallengeProgress todaysProgress;
    private DailyChallenge_WeekHistory weekHistory;
    private System.DateTime lastWeekRewardCollected;
    private System.DateTime lastMonthRewardCollected;
    public System.Action<int> OnStarsEarned;
    public System.Action OnZooTileEarned;
    public System.Action OnMissedPoint;
    public System.Action OnWeeklyMonthlyRewardCollected;
    private DailyChallengeStatus <Status>k__BackingField;
    private DailyChallengeEconomy <Econ>k__BackingField;
    public bool PlayingMorning;
    public bool PlayingEvening;
    private System.DateTime _LastPlayedDailyChallenge;
    private bool <IsDataReady>k__BackingField;
    private int <RecentStarGained>k__BackingField;
    private bool <HackDateTime>k__BackingField;
    private DailyChallengeGameLevel missedChallengeLevel;
    private static System.DateTime lastServerCall;
    private static int secondsUntilNextRequest;
    private bool isRunningDelayedRequest;
    private System.Collections.Generic.List<string> answers;
    private System.Collections.Generic.List<string> extraWords;
    private System.Collections.Generic.List<int> actualWordsCount;
    
    // Properties
    public int Version { get; }
    public DailyChallengeStatus Status { get; set; }
    public DailyChallengeEconomy Econ { get; set; }
    public DailyChallengeProgress TodaysProgress { get; set; }
    public DailyChallenge_MonthHistory MonthHistory { get; set; }
    public DailyChallenge_WeekHistory WeekHistory { get; set; }
    public System.Collections.Generic.List<ZooTile> ZooTileCollection { get; }
    public DailyChallengeGameLevel CurrentLevel { get; set; }
    public bool PlayingChallenge { get; set; }
    public System.DateTime LastPlayedDailyChallenge { get; set; }
    public bool IsDataReady { get; set; }
    public int RecentStarGained { get; set; }
    public bool HackDateTime { get; set; }
    public bool FeatureAvailable { get; }
    
    // Methods
    public int get_Version()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_340;
    }
    public DailyChallengeStatus get_Status()
    {
        return (DailyChallengeStatus)this.<Status>k__BackingField;
    }
    private void set_Status(DailyChallengeStatus value)
    {
        this.<Status>k__BackingField = value;
    }
    public DailyChallengeEconomy get_Econ()
    {
        return (DailyChallengeEconomy)this.<Econ>k__BackingField;
    }
    private void set_Econ(DailyChallengeEconomy value)
    {
        this.<Econ>k__BackingField = value;
    }
    public DailyChallengeProgress get_TodaysProgress()
    {
        return (DailyChallengeProgress)this.todaysProgress;
    }
    private void set_TodaysProgress(DailyChallengeProgress value)
    {
        this.todaysProgress = value;
    }
    public DailyChallenge_MonthHistory get_MonthHistory()
    {
        return (DailyChallenge_MonthHistory)this.monthHistory;
    }
    private void set_MonthHistory(DailyChallenge_MonthHistory value)
    {
        this.monthHistory = value;
    }
    public DailyChallenge_WeekHistory get_WeekHistory()
    {
        return (DailyChallenge_WeekHistory)this.weekHistory;
    }
    private void set_WeekHistory(DailyChallenge_WeekHistory value)
    {
        this.weekHistory = value;
    }
    public System.Collections.Generic.List<ZooTile> get_ZooTileCollection()
    {
        System.Collections.Generic.IEnumerable<TSource> val_7;
        var val_8;
        var val_9;
        System.Predicate<ZooTile> val_11;
        var val_12;
        System.Func<ZooTile, System.String> val_14;
        System.Collections.Generic.List<ZooTile> val_1 = null;
        val_7 = val_1;
        val_1 = new System.Collections.Generic.List<ZooTile>(collection:  this.monthZooTileCollection);
        val_8 = null;
        val_8 = null;
        val_9 = null;
        val_9 = null;
        val_11 = WGDailyChallengeManager.<>c.<>9__40_0;
        if(val_11 == null)
        {
                System.Predicate<ZooTile> val_2 = null;
            val_11 = val_2;
            val_2 = new System.Predicate<ZooTile>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeManager.<>c::<get_ZooTileCollection>b__40_0(ZooTile x));
            WGDailyChallengeManager.<>c.<>9__40_0 = val_11;
        }
        
        val_1.AddRange(collection:  ZooTilePool.LifetimeZooTiles.FindAll(match:  val_2));
        if(1152921517786711040 < 1)
        {
                return (System.Collections.Generic.List<ZooTile>)val_7;
        }
        
        val_12 = null;
        val_12 = null;
        val_14 = WGDailyChallengeManager.<>c.<>9__40_1;
        if(val_14 == null)
        {
                System.Func<ZooTile, System.String> val_4 = null;
            val_14 = val_4;
            val_4 = new System.Func<ZooTile, System.String>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.String WGDailyChallengeManager.<>c::<get_ZooTileCollection>b__40_1(ZooTile x));
            WGDailyChallengeManager.<>c.<>9__40_1 = val_14;
        }
        
        val_7 = System.Linq.Enumerable.ToList<ZooTile>(source:  System.Linq.Enumerable.OrderBy<ZooTile, System.String>(source:  val_1, keySelector:  val_4));
        return (System.Collections.Generic.List<ZooTile>)val_7;
    }
    public DailyChallengeGameLevel get_CurrentLevel()
    {
        DailyChallengeGameLevel val_1;
        if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                val_1 = this.todaysProgress.currentLevel;
            return (DailyChallengeGameLevel)mem[this.missedChallengeLevel];
        }
        
        val_1 = this.missedChallengeLevel;
        return (DailyChallengeGameLevel)mem[this.missedChallengeLevel];
    }
    public void set_CurrentLevel(DailyChallengeGameLevel value)
    {
        DailyChallengeGameLevel val_1;
        if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                val_1 = this.todaysProgress.currentLevel;
        }
        else
        {
                val_1 = this.missedChallengeLevel;
        }
        
        mem2[0] = value;
    }
    public bool get_PlayingChallenge()
    {
        if(this.PlayingMorning == false)
        {
                return (bool)(this.PlayingEvening == true) ? 1 : 0;
        }
        
        return true;
    }
    public void set_PlayingChallenge(bool value)
    {
        this.PlayingMorning = false;
        this.PlayingEvening = false;
        if(value == false)
        {
                return;
        }
        
        this.PlayingMorning = this.<Status>k__BackingField.playingDayMorning;
        bool val_2 = this.<Status>k__BackingField.playingDayMorning;
        val_2 = val_2 ^ 1;
        this.PlayingEvening = val_2;
        System.DateTime val_1 = DateTimeCheat.Now;
        this.LastPlayedDailyChallenge = new System.DateTime() {dateData = val_1.dateData};
    }
    public System.DateTime get_LastPlayedDailyChallenge()
    {
        var val_6;
        var val_7;
        val_6 = null;
        val_6 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this._LastPlayedDailyChallenge}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return (System.DateTime)this._LastPlayedDailyChallenge;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "last_dc_play_time")) == false)
        {
                return (System.DateTime)this._LastPlayedDailyChallenge;
        }
        
        val_7 = null;
        val_7 = null;
        System.DateTime val_5 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "last_dc_play_time", defaultValue:  System.DateTime.MinValue.ToString()));
        this._LastPlayedDailyChallenge = val_5;
        return (System.DateTime)this._LastPlayedDailyChallenge;
    }
    public void set_LastPlayedDailyChallenge(System.DateTime value)
    {
        this._LastPlayedDailyChallenge = value;
        UnityEngine.PlayerPrefs.SetString(key:  "last_dc_play_time", value:  this._LastPlayedDailyChallenge.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public bool get_IsDataReady()
    {
        return (bool)this.<IsDataReady>k__BackingField;
    }
    private void set_IsDataReady(bool value)
    {
        this.<IsDataReady>k__BackingField = value;
    }
    public int get_RecentStarGained()
    {
        return (int)this.<RecentStarGained>k__BackingField;
    }
    private void set_RecentStarGained(int value)
    {
        this.<RecentStarGained>k__BackingField = value;
    }
    public bool get_HackDateTime()
    {
        return (bool)this.<HackDateTime>k__BackingField;
    }
    public void set_HackDateTime(bool value)
    {
        this.<HackDateTime>k__BackingField = value;
    }
    public bool get_FeatureAvailable()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) > 5) ? 1 : 0;
    }
    public bool CurrentLanguageSupported()
    {
        GameBehavior val_1 = App.getBehavior;
        bool val_3 = System.String.op_Inequality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
        val_3 = (~val_3) & 1;
        return (bool)val_3;
    }
    public override void InitMonoSingleton()
    {
        Player val_1 = App.Player;
        SLCDebug.Log(logMessage:  "WGDailyChallengeManager.InitMonoSingleton :: player id: "("WGDailyChallengeManager.InitMonoSingleton :: player id: ") + val_1.id, colorHash:  "#FFFFFF", isError:  false);
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        System.Delegate val_5 = System.Delegate.Combine(a:  GoldenApplesManager.OnAppleAwarded, b:  new System.Action<System.Int32>(object:  this, method:  System.Void WGDailyChallengeManager::OnAppleAwarded(int appleAwarded)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        GoldenApplesManager.OnAppleAwarded = val_5;
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void WGDailyChallengeManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        this.monthHistory = new DailyChallenge_MonthHistory();
        this.weekHistory = new DailyChallenge_WeekHistory();
        this.<Status>k__BackingField = new DailyChallengeStatus(isMorning:  WGDailyChallengeManagerHelper.MorningChallengeAvailableNow());
        this.todaysProgress = new DailyChallengeProgress();
        this.RequestChallengeData(firstTimeNewIdRequest:  false);
        return;
        label_10:
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode sceneMode)
    {
        this.RequestDataInLobby();
    }
    private void RequestDataInLobby()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        this.<IsDataReady>k__BackingField = false;
        this.isRequesting = false;
        this.RequestChallengeData(firstTimeNewIdRequest:  false);
    }
    private void OnServerResponded()
    {
        this.RequestChallengeData(firstTimeNewIdRequest:  false);
    }
    public void OnSceneChanged(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next)
    {
        this.TrackChallengeProgress();
        this.SavePersistentProgress();
        UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  public System.Void WGDailyChallengeManager::OnSceneChanged(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next)));
    }
    private void SavePersistentProgress()
    {
        if((this.<Status>k__BackingField.playingPersistentLevel) == false)
        {
                return;
        }
        
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        DailyChallengeGameLevel val_2 = this.CurrentLevel;
        this.<Status>k__BackingField.lastPlayedLevel = new DailyChallengeLastPlayedLevel(day:  this.<Status>k__BackingField.playingDay, isMorning:  ((this.<Status>k__BackingField.playingDayMorning) == true) ? 1 : 0, levelId:  val_1.gameLevel.word, stars:  val_2.stars, progress:  this.GetProgressPercentage(), done:  false, isPersistentLevel:  true);
        this = ???;
        goto typeof(DailyChallengeStatus).__il2cppRuntimeField_180;
    }
    private void PauseTimer()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        val_1.sessionLoseFocusStartTime = UnityEngine.Mathf.RoundToInt(f:  UnityEngine.Time.time);
    }
    private void ResumeTimer()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        int val_6 = val_4.sessionLoseFocusStartTime;
        val_6 = ((UnityEngine.Mathf.RoundToInt(f:  UnityEngine.Time.time)) + val_1.sessionLoseFocusTime) - val_6;
        val_1.sessionLoseFocusTime = val_6;
    }
    private int GetTimeSpent()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        DailyChallengeGameLevel val_9 = this.CurrentLevel;
        int val_12 = val_9.sessionLoseFocusTime;
        int val_10 = (UnityEngine.Mathf.RoundToInt(f:  UnityEngine.Time.time)) + val_1.timeSpent;
        val_10 = val_10 - val_4.challengeStartTime;
        val_10 = val_10 + (UnityEngine.Mathf.Max(a:  0, b:  DateTimeCheat.Seconds - val_6.timerBeginCheatSeconds));
        val_12 = val_10 - val_12;
        val_1.timeSpent = val_12;
        DailyChallengeGameLevel val_11 = this.CurrentLevel;
        return (int)val_11.timeSpent;
    }
    private void TrackChallengeProgress()
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_16;
        var val_17;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_16 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.DateTime val_2 = DateTimeCheat.Now;
        val_1.Add(key:  "date", value:  val_2.dateData.ToString());
        val_1.Add(key:  "word", value:  this.GetLevelForTracking());
        val_1.Add(key:  "# of Letters", value:  val_4.m_stringLength);
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        val_1.Add(key:  "Hints Used", value:  val_5.regularHintsUsed);
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        val_1.Add(key:  "Hints Used Picker", value:  val_6.pickerHintsUsed);
        DailyChallengeGameLevel val_7 = this.CurrentLevel;
        val_1.Add(key:  "Retry", value:  val_7.isRetryLevel);
        val_1.Add(key:  "Challenge Complete", value:  null);
        if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                DailyChallengeGameLevel val_8 = this.CurrentLevel;
            val_1.Add(key:  "Challenge Resumed", value:  val_8.challengeResumed);
            val_16 = val_16;
        }
        
        DailyChallengeGameLevel val_9 = this.CurrentLevel;
        DailyChallengeGameLevel val_10 = this.CurrentLevel;
        System.Collections.Generic.List<System.String> val_16 = val_10.found;
        val_16 = val_9.gameLevel.actualWordCount - val_16;
        val_1.Add(key:  "Remaining Words", value:  val_16);
        val_1.Add(key:  "Time Spent", value:  this.GetTimeSpent());
        DailyChallengeGameLevel val_12 = this.CurrentLevel;
        val_1.Add(key:  "Stars Starting", value:  val_12.sessionStarsStarting);
        DailyChallengeGameLevel val_13 = this.CurrentLevel;
        val_1.Add(key:  "Stars Ending", value:  val_13.stars);
        DailyChallengeGameLevel val_14 = this.CurrentLevel;
        val_1.Add(key:  "Stars Saved", value:  val_14.starsSaved);
        MonoSingleton<WordGameEventsController>.Instance.AppendDailyChallengeCompleteData(curData: ref  val_1);
        val_17 = null;
        val_17 = null;
        App.trackerManager.track(eventName:  "Daily Challenges", data:  val_1);
    }
    public void ResetLastRequestSuccessTime()
    {
        null = null;
        this.lastRequestSuccessTime = System.DateTime.MinValue;
    }
    private void RequestChallengeData(bool firstTimeNewIdRequest = False)
    {
        ulong val_11;
        if(this.FeatureAvailable == false)
        {
                return;
        }
        
        if(firstTimeNewIdRequest != true)
        {
                System.DateTime val_2 = DateTimeCheat.Now;
            val_11 = val_2.dateData;
            System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_11}, d2:  new System.DateTime() {dateData = this.lastRequestSuccessTime});
            if(val_3._ticks.TotalSeconds < 0)
        {
                if(this.lastKnownCheatSeconds == DateTimeCheat.Seconds)
        {
                return;
        }
        
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnDailyChallengeDataUpdate");
            return;
        }
        
        }
        
        if(this.isRunningDelayedRequest != true)
        {
                Player val_7 = App.Player;
            if((System.String.op_Equality(a:  val_7.id, b:  " ")) != false)
        {
                UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.RequestValidIdDelayed());
            return;
        }
        
        }
        
        this.DoRequest();
    }
    private void DoRequest()
    {
        var val_10;
        var val_11;
        if(this.isRequesting == false)
        {
            goto label_1;
        }
        
        label_8:
        this.FireRequestCallback(status:  false);
        return;
        label_1:
        val_10 = null;
        val_10 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
            goto label_8;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        val_1.Add(key:  "period", value:  (WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true) ? "m" : "e");
        val_1.Add(key:  "version", value:  val_1.Version);
        val_1.Add(key:  "timezone", value:  DeviceIdPlugin.GetTimeZone());
        if((this.<HackDateTime>k__BackingField) != false)
        {
                System.DateTime val_7 = DateTimeCheat.Now;
            val_1.Add(key:  "hack_time", value:  val_7.dateData.ToString());
        }
        
        this.isRequesting = true;
        val_11 = null;
        val_11 = null;
        App.networkManager.DoGet(path:  "/api/word/daily_challenges/1", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGDailyChallengeManager::OnDailyChallengeRequest(string apiCall, System.Collections.Generic.Dictionary<string, object> response)), destroy:  false, immediate:  false, getParams:  val_1, timeout:  20);
    }
    public void RequestServerUpdate(System.Action<bool> callback)
    {
        this.currentRequestCallback = callback;
        this.DoRequest();
    }
    public void UnregisterRequestCallback(System.Action<bool> callback)
    {
        if((System.Delegate.op_Equality(d1:  this.currentRequestCallback, d2:  callback)) == false)
        {
                return;
        }
        
        this.currentRequestCallback = 0;
    }
    public string GetMonthTileName()
    {
        int val_33;
        var val_34;
        var val_35;
        string val_36;
        var val_37;
        string val_38;
        var val_39;
        var val_40;
        var val_41;
        val_33 = this;
        val_34 = null;
        val_34 = null;
        System.Collections.Generic.List<TSource> val_2 = System.Linq.Enumerable.ToList<ZooTile>(source:  System.Linq.Enumerable.Except<ZooTile>(first:  ZooTilePool.MonthlyZooTiles, second:  this.monthZooTileCollection));
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<ZooTile>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
            goto label_4;
        }
        
        val_35 = "";
        val_36 = UnityEngine.PlayerPrefs.GetString(key:  "dc_month_tile_last_saved_time", defaultValue:  "");
        System.DateTime val_4 = DateTimeCheat.Now;
        System.DateTime val_6 = DateTimeCheat.Now;
        System.DateTime val_8 = new System.DateTime(year:  val_4.dateData.Year, month:  val_6.dateData.Month, day:  1);
        if((System.String.IsNullOrEmpty(value:  val_36)) == false)
        {
            goto label_7;
        }
        
        val_37 = 0;
        goto label_8;
        label_4:
        val_38 = "";
        return val_38;
        label_7:
        System.DateTime val_10 = val_8.dateData.AddMonths(months:  0);
        System.DateTime val_11 = SLCDateTime.Parse(dateTime:  val_36, defaultValue:  new System.DateTime() {dateData = val_10.dateData});
        val_37 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_11.dateData}, t2:  new System.DateTime() {dateData = val_8.dateData});
        label_8:
        val_38 = UnityEngine.PlayerPrefs.GetString(key:  "dc_month_tile", defaultValue:  "");
        if(val_37 == 0)
        {
                if((System.String.IsNullOrEmpty(value:  val_36)) == false)
        {
                return val_38;
        }
        
        }
        
        System.DateTime val_15 = new System.DateTime(year:  227, month:  10, day:  1);
        System.DateTime val_16 = DateTimeCheat.Now;
        val_36 = val_16.dateData.Year;
        System.DateTime val_19 = DateTimeCheat.Now;
        val_39 = null;
        int val_22 = val_36 - val_15.dateData.Year;
        val_22 = val_19.dateData.Month + (val_22 * 12);
        val_35 = val_22 + (~val_15.dateData.Month);
        if(<0)
        {
            goto label_16;
        }
        
        val_39 = null;
        var val_33 = ZooTilePool.MonthlyZooTiles + 24;
        val_33 = val_33 - 1;
        if(val_35 <= val_33)
        {
            goto label_20;
        }
        
        label_16:
        val_35 = 0;
        label_20:
        val_40 = val_35;
        goto label_21;
        label_40:
        val_36 = this.monthZooTileCollection;
        if((ZooTilePool.MonthlyZooTiles + 24) <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_34 = ZooTilePool.MonthlyZooTiles + 16;
        val_34 = val_34 + 0;
        if((val_36.Contains(item:  (ZooTilePool.MonthlyZooTiles + 16 + 0) + 32)) == true)
        {
            goto label_27;
        }
        
        val_41 = null;
        val_41 = null;
        val_36 = ZooTilePool.MonthlyZooTiles;
        if((ZooTilePool.MonthlyZooTiles + 24) <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_35 = ZooTilePool.MonthlyZooTiles + 16;
        val_35 = val_35 + 0;
        if((System.String.op_Equality(a:  val_38, b:  (ZooTilePool.MonthlyZooTiles + 16 + 0) + 32 + 16)) == false)
        {
            goto label_33;
        }
        
        label_27:
        val_39 = null;
        val_39 = null;
        var val_36 = ZooTilePool.MonthlyZooTiles + 24;
        val_36 = val_36 - 1;
        label_21:
        val_39 = null;
        if(((val_40 == val_36) ? 0 : (val_40 + 1)) < (ZooTilePool.MonthlyZooTiles + 24))
        {
            goto label_40;
        }
        
        goto label_41;
        label_33:
        val_39 = null;
        label_41:
        val_39 = null;
        if((ZooTilePool.MonthlyZooTiles + 24) <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_37 = ZooTilePool.MonthlyZooTiles + 16;
        val_37 = val_37 + 0;
        val_38 = mem[(ZooTilePool.MonthlyZooTiles + 16 + 0) + 32 + 16];
        val_38 = (ZooTilePool.MonthlyZooTiles + 16 + 0) + 32 + 16;
        UnityEngine.PlayerPrefs.SetString(key:  "dc_month_tile", value:  val_38);
        System.DateTime val_26 = DateTimeCheat.Now;
        val_33 = val_26.dateData.Year;
        System.DateTime val_28 = DateTimeCheat.Now;
        System.DateTime val_30 = new System.DateTime(year:  val_33, month:  val_28.dateData.Month, day:  1);
        UnityEngine.PlayerPrefs.SetString(key:  "dc_month_tile_last_saved_time", value:  val_30.dateData.ToString());
        bool val_32 = PrefsSerializationManager.SavePlayerPrefs();
        return val_38;
    }
    public ZooTile GetNextLifetimeTile()
    {
        var val_2;
        var val_3;
        System.Func<ZooTile, System.Boolean> val_5;
        val_2 = null;
        val_2 = null;
        val_3 = null;
        val_3 = null;
        val_5 = WGDailyChallengeManager.<>c.<>9__87_0;
        if(val_5 != null)
        {
                return System.Linq.Enumerable.FirstOrDefault<ZooTile>(source:  ZooTilePool.LifetimeZooTiles, predicate:  System.Func<ZooTile, System.Boolean> val_1 = null);
        }
        
        val_5 = val_1;
        val_1 = new System.Func<ZooTile, System.Boolean>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeManager.<>c::<GetNextLifetimeTile>b__87_0(ZooTile x));
        WGDailyChallengeManager.<>c.<>9__87_0 = val_5;
        return System.Linq.Enumerable.FirstOrDefault<ZooTile>(source:  ZooTilePool.LifetimeZooTiles, predicate:  val_1);
    }
    private void OnApplicationPause(bool paused)
    {
        paused = (~paused) & 1;
        this.HandleApplicationBackToFocus(isInFocus:  paused);
    }
    private void OnApplicationFocus(bool focus)
    {
        this.HandleApplicationBackToFocus(isInFocus:  focus);
    }
    private void OnLocalize()
    {
        if(this.PlayingMorning != true)
        {
                if(this.PlayingEvening == false)
        {
                return;
        }
        
        }
        
        this.HandleLevelCompletion();
        this.Play();
    }
    private void HandleApplicationBackToFocus(bool isInFocus)
    {
        if(this.PlayingMorning != true)
        {
                if(this.PlayingEvening == false)
        {
                return;
        }
        
        }
        
        if(isInFocus != false)
        {
                this.ResumeTimer();
            this.RequestDataInLobby();
            return;
        }
        
        this.PauseTimer();
    }
    private void OnApplicationQuit()
    {
        if(this.PlayingMorning != true)
        {
                if(this.PlayingEvening == false)
        {
                return;
        }
        
        }
        
        int val_1 = this.GetTimeSpent();
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private System.Collections.IEnumerator RequestValidIdDelayed()
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeManager.<RequestValidIdDelayed>d__94(<>1__state:  0);
    }
    private void OnDailyChallengeRequest(string apiCall, System.Collections.Generic.Dictionary<string, object> response)
    {
        string val_8 = apiCall;
        this.CheckAndHandleRollover();
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_8 = val_8 + "\n" + PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  response, types:  false, singleLineOutput:  false));
            UnityEngine.Debug.Log(message:  val_8);
        }
        
        if(response != null)
        {
                object val_5 = response.Item["success"];
            if(null != null)
        {
                this.UpdateDataFromServer(response:  response);
            return;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "Daily Challenge Request Failed: "("Daily Challenge Request Failed: ") + MiniJSON.Json.Serialize(obj:  response)(MiniJSON.Json.Serialize(obj:  response)));
        this.isRequesting = false;
        this.FireRequestCallback(status:  false);
    }
    private void UpdateDataFromServer(System.Collections.Generic.Dictionary<string, object> response)
    {
        string val_19 = "economy";
        if((response.ContainsKey(key:  "economy")) != false)
        {
                object val_2 = response.Item["economy"];
            if(val_2 != null)
        {
                val_19 = val_2;
        }
        
        }
        
        if((this.<Econ>k__BackingField) != null)
        {
                this.monthHistory = this.ParseMonthProgress(data:  response);
            if(this.dcRevamp != false)
        {
                DailyChallenge_WeekHistory val_4 = this.ParseWeekProgress(data:  response);
            this.weekHistory = val_4;
        }
        
            this.monthZooTileCollection = val_4.ParseMonthZooTileCollection(data:  response);
            if((System.String.IsNullOrEmpty(value:  this.monthHistory.tile)) != false)
        {
                this.monthHistory.tile = this.GetMonthTileName();
        }
        
            val_19 = 1152921504880381952;
            System.DateTime val_8 = DateTimeCheat.Now;
            if((this.monthHistory.progress.ContainsKey(key:  val_8.dateData.Day.ToString())) != false)
        {
                System.DateTime val_12 = DateTimeCheat.Now;
            DailyChallenge_DayProgress val_15 = this.monthHistory.progress.Item[val_12.dateData.Day.ToString()];
            mem2[0] = val_15.stars_m;
            mem2[0] = val_15.stars_e;
        }
        
            System.DateTime val_16 = DateTimeCheat.Now;
            this.lastRequestSuccessTime = val_16;
            this.lastKnownCheatSeconds = DateTimeCheat.Seconds;
            this.<IsDataReady>k__BackingField = true;
            this.FireRequestCallback(status:  true);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "WGDailyChallengeManager: Econ is null and we did not get an economy json in the response. Aborting UpdateDataFromServer", context:  this);
    }
    private void CheckChallengeRollover()
    {
        this.<Status>k__BackingField.lastPlayedLevel.isPersistentLevel = true;
        if((this.<Status>k__BackingField.playingPersistentLevel) == false)
        {
                return;
        }
        
        if((((this.<Status>k__BackingField.playingPersistentLevel) == true) ? 1 : 0) == (((this.<Status>k__BackingField.playingDayMorning) == true) ? 1 : 0))
        {
                return;
        }
        
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        val_3.hasStartedPreviously = false;
        PlayingLevel.CompleteLevel(mode:  2, parameters:  0);
    }
    public void Play()
    {
        this.CheckChallengeRollover();
        this.GetLevel(mode:  ((this.<Status>k__BackingField.playingPersistentLevel) == false) ? (2 + 1) : 2);
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        if(val_3.hasStartedPreviously != false)
        {
                DailyChallengeGameLevel val_4 = this.CurrentLevel;
            val_4.challengeResumed = true;
        }
        else
        {
                this.ResetProgress();
            DailyChallengeGameLevel val_6 = this.CurrentLevel;
            DailyChallengeGameLevel val_7 = this.CurrentLevel;
            DailyChallengeLastPlayedLevel val_10 = new DailyChallengeLastPlayedLevel(day:  this.<Status>k__BackingField.playingDay, isMorning:  WGDailyChallengeManagerHelper.MorningChallengeAvailableNow(), levelId:  val_6.gameLevel.word, stars:  val_7.stars, progress:  this.GetProgressPercentage(), done:  false, isPersistentLevel:  this.<Status>k__BackingField.playingPersistentLevel);
            this.<Status>k__BackingField.lastPlayedLevel = val_10;
        }
        
        this.ResetSessionTracking();
        this.PlayingChallenge = true;
        GameBehavior val_11 = App.getBehavior;
        WGWindowManager val_13 = MonoSingleton<WGWindowManager>.Instance.IsWindowInQueue<LevelCompletePopup>();
        .levelComplete = val_13;
        if(val_13 == 0)
        {
                return;
        }
        
        (WGDailyChallengeManager.<>c__DisplayClass101_0)[1152921517792576608].levelComplete.gameObject.SetActive(value:  true);
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  MonoSingleton<WGWindowManager>.Instance, callback:  new System.Action(object:  new WGDailyChallengeManager.<>c__DisplayClass101_0(), method:  System.Void WGDailyChallengeManager.<>c__DisplayClass101_0::<Play>b__0()), count:  1);
    }
    private void ResetProgress()
    {
        MonoSingleton<WordGameEventsController>.Instance.ResetDCProgress();
        this.CurrentLevel.ResetPointer();
        ExtraWord.ClearEventExtraWordProgress(gameTypeId:  "dailychallenge");
    }
    private void GetLevel(GameplayMode mode)
    {
        bool val_22;
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
            goto label_9;
        }
        
        DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        if(val_3._TutorialActive == false)
        {
            goto label_9;
        }
        
        this.CurrentLevel = MonoSingleton<DailyChallengeTutorialManager>.Instance.GetDailyChallengeGameLevel();
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        val_6.gameLevel = this.GenerateOrLoadLevel(levelName:  "", tries:  0, mode:  mode);
        DailyChallengeGameLevel val_8 = this.CurrentLevel;
        val_22 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        this.<Status>k__BackingField = new DailyChallengeStatus(isMorning:  val_22);
        .playingDayMorning = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        this.<Status>k__BackingField.playingDay = 0;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
        label_9:
        this.CurrentLevel = new DailyChallengeGameLevel();
        DailyChallengeGameLevel val_15 = this.CurrentLevel;
        val_15.persistent = (mode == 2) ? 1 : 0;
        if(mode == 2)
        {
                if((this.<Status>k__BackingField.lastPlayedLevel.done) != false)
        {
                this.CurrentLevel = new DailyChallengeGameLevel();
        }
        else
        {
                DailyChallengeGameLevel val_18 = this.CurrentLevel;
        }
        
        }
        
        val_22 = this.CurrentLevel;
        val_19.gameLevel = this.GenerateOrLoadLevel(levelName:  "dc_retry", tries:  0, mode:  mode);
        DailyChallengeGameLevel val_21 = this.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    private void ResetSessionTracking()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        val_1.challengeStartTime = UnityEngine.Mathf.RoundToInt(f:  UnityEngine.Time.time);
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        val_4.timerBeginCheatSeconds = DateTimeCheat.Seconds;
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        val_6.sessionLoseFocusTime = 0;
        DailyChallengeGameLevel val_7 = this.CurrentLevel;
        val_7.sessionLoseFocusStartTime = 0;
        DailyChallengeGameLevel val_8 = this.CurrentLevel;
        DailyChallengeGameLevel val_9 = this.CurrentLevel;
        val_8.sessionStarsStarting = val_9.stars;
    }
    private bool IsChallengeDifferent()
    {
        DailyChallengeLastPlayedLevel val_3 = this.<Status>k__BackingField.lastPlayedLevel;
        bool val_2 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow();
        val_3 = ((val_3 != 0) ? 1 : 0) ^ val_2;
        val_2 = val_3;
        return (bool)val_2;
    }
    private void HandleChallengeSwitch()
    {
        SLCDebug.Log(logMessage:  "WGDailyChallengeManager.HandleChallengeSwitch()", colorHash:  "#FFFFFF", isError:  false);
        PlayingLevel.CompleteLevel(mode:  2, parameters:  0);
        this.<Status>k__BackingField.lastPlayedLevel = new DailyChallengeLastPlayedLevel(isMorning:  false);
    }
    private void FireRequestCallback(bool status)
    {
        if(this.currentRequestCallback != null)
        {
                status = status;
            this.currentRequestCallback.Invoke(obj:  status);
        }
        
        this.currentRequestCallback = 0;
    }
    public void HandleStarProgress()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        int val_5 = val_1.stars;
        val_5 = val_5 + 1;
        val_1.stars = val_5;
        DailyChallengeGameLevel val_2 = this.CurrentLevel;
        int val_6 = val_2.progressDefinitionsIndex;
        val_6 = val_6 + 1;
        val_2.progressDefinitionsIndex = val_6;
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        if(this.OnStarsEarned == null)
        {
                return;
        }
        
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        this.OnStarsEarned.Invoke(obj:  val_4.stars);
    }
    public float GetProgressPercentage()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        if(val_1.gameLevel.actualWordCount == 0)
        {
                return 0f;
        }
        
        DailyChallengeGameLevel val_2 = this.CurrentLevel;
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        float val_4 = (float)val_3.gameLevel.actualWordCount;
        val_4 = (float)val_2.points / val_4;
        return 0f;
    }
    public float GetNextProgressTarget()
    {
        object val_3;
        object val_4;
        var val_11;
        var val_12;
        System.Collections.Generic.List<System.Object> val_1 = new System.Collections.Generic.List<System.Object>();
        List.Enumerator<T> val_2 = this.<Econ>k__BackingField.ChallengeDefinition.StarThresholds.GetEnumerator();
        label_6:
        val_11 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_3);
        goto label_6;
        label_4:
        val_4.Dispose();
        val_4 = 100;
        val_1.Add(item:  val_4);
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        DailyChallengeGameLevel val_7 = this.CurrentLevel;
        val_6.progressDefinitionsIndex = UnityEngine.Mathf.Min(a:  W24 - 1, b:  val_7.progressDefinitionsIndex);
        DailyChallengeGameLevel val_10 = this.CurrentLevel;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_12 = mem[(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + (val_10.progressDefinitionsIndex) << 3) + 32];
        val_12 = (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + (val_10.progressDefinitionsIndex) << 3) + 32;
        val_11 = null;
        float val_11 = (float)val_12;
        val_11 = val_11 / 100f;
        return (float)val_11;
    }
    public void OnChallengeCompleted()
    {
        DailyChallengeStatus val_11;
        var val_12;
        UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  public System.Void WGDailyChallengeManager::OnSceneChanged(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next)));
        this.TrackChallengeComplete();
        if((UnityEngine.PlayerPrefs.HasKey(key:  "DailyChallengeFinished")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "DailyChallengeFinished");
        }
        
        val_11 = this.<Status>k__BackingField;
        if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                val_11 = this.<Status>k__BackingField;
            val_12 = WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() ^ (((this.<Status>k__BackingField.playingDayMorning) == false) ? 1 : 0);
        }
        else
        {
                val_12 = 0;
        }
        
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        this.<Status>k__BackingField.lastPlayedLevel = new DailyChallengeLastPlayedLevel(day:  this.<Status>k__BackingField.playingDay, isMorning:  ((this.<Status>k__BackingField.playingDayMorning) == true) ? 1 : 0, levelId:  val_5.gameLevel.word, stars:  val_6.stars, progress:  this.GetProgressPercentage(), done:  true, isPersistentLevel:  val_12 & 1);
        this.UpdateMonthHistory();
        this.HandleLevelCompletion();
        this.ShowLevelComplete();
    }
    private void HandleLevelCompletion()
    {
        UnityEngine.Object val_6;
        bool val_7;
        val_6 = 0;
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) != val_6)
        {
                DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
            val_7 = val_3._TutorialActive;
        }
        else
        {
                val_7 = 0;
        }
        
        val_7 = val_7 | (this.<Status>k__BackingField.playingPersistentLevel);
        if(val_7 != false)
        {
                DailyChallengeGameLevel val_4 = this.CurrentLevel;
            val_4.hasStartedPreviously = false;
            val_6 = 0;
            PlayingLevel.CompleteLevel(mode:  2, parameters:  val_6);
        }
        
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_190;
    }
    private void UpdateMonthHistory()
    {
        System.Collections.Generic.Dictionary<System.String, DailyChallenge_DayProgress> val_35;
        int val_36;
        DailyChallenge_DayProgress val_37;
        DailyChallengeSimplifiedLevel val_38;
        DailyChallengeSimplifiedLevel val_40;
        var val_41;
        var val_42;
        var val_43;
        bool val_2 = this.monthHistory.progress.ContainsKey(key:  this.<Status>k__BackingField.playingDay.ToString());
        if(val_2 == false)
        {
            goto label_4;
        }
        
        val_35 = this.monthHistory.progress;
        DailyChallenge_DayProgress val_4 = val_35.Item[this.<Status>k__BackingField.playingDay.ToString()];
        if(this.PlayingMorning == false)
        {
            goto label_9;
        }
        
        val_36 = val_4.stars_m;
        goto label_11;
        label_4:
        val_36 = 0;
        goto label_11;
        label_9:
        val_36 = val_4.stars_e;
        label_11:
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        if(val_5.stars <= val_36)
        {
                return;
        }
        
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        int val_35 = val_6.stars;
        Player val_7 = App.Player;
        int val_36 = val_7.dcStars;
        val_35 = val_35 - val_36;
        val_36 = val_36 + val_35;
        val_7.dcStars = val_36;
        int val_37 = this.monthHistory.stars;
        val_37 = val_37 + val_35;
        this.monthHistory.stars = val_37;
        if(this.dcRevamp != false)
        {
                if(this.PlayingCurrentWeek() != false)
        {
                int val_38 = this.weekHistory.stars;
            val_38 = val_38 + val_35;
            this.weekHistory.stars = val_38;
        }
        
        }
        
        this.<RecentStarGained>k__BackingField = val_35;
        if(val_2 != false)
        {
                val_37 = this.monthHistory.progress.Item[this.<Status>k__BackingField.playingDay.ToString()];
        }
        else
        {
                DailyChallenge_DayProgress val_11 = null;
            val_37 = val_11;
            val_11 = new DailyChallenge_DayProgress();
        }
        
        DailyChallengeGameLevel val_12 = this.CurrentLevel;
        if(this.PlayingMorning != false)
        {
                .stars_m = val_12.stars;
        }
        else
        {
                .stars_e = val_12.stars;
        }
        
        string val_13 = this.<Status>k__BackingField.playingDay.ToString();
        if(val_2 != false)
        {
                this.monthHistory.progress.set_Item(key:  val_13, value:  val_11);
        }
        else
        {
                this.monthHistory.progress.Add(key:  val_13, value:  val_11);
        }
        
        if((this.dcRevamp != false) && (this.PlayingCurrentWeek() != false))
        {
                System.DateTime val_15 = DateTimeCheat.Today;
            System.DateTime val_17 = DateTimeCheat.Today;
            int val_39 = this.<Status>k__BackingField.playingDay;
            val_39 = (val_15.dateData.DayOfWeek - val_17.dateData.Day) + val_39;
            string val_20 = val_39.ToString();
            if((this.weekHistory.progress.ContainsKey(key:  val_20)) != false)
        {
                this.weekHistory.progress.set_Item(key:  val_20, value:  val_11);
        }
        else
        {
                this.weekHistory.progress.Add(key:  val_20, value:  val_11);
        }
        
        }
        
        if(this.IsPlayingTodaysLevel() == false)
        {
            goto label_47;
        }
        
        if(this.PlayingMorning == false)
        {
            goto label_49;
        }
        
        this.todaysProgress.morningChallenge.done = true;
        val_38 = this.todaysProgress.morningChallenge;
        int[] val_23 = new int[3];
        val_40 = this.todaysProgress.morningChallenge;
        if(val_40 != null)
        {
            goto label_53;
        }
        
        label_49:
        this.todaysProgress.eveningChallenge.done = true;
        val_38 = this.todaysProgress.eveningChallenge;
        int[] val_24 = new int[3];
        val_40 = this.todaysProgress.eveningChallenge;
        label_53:
        val_24[0] = val_40;
        val_24[0] = val_36;
        DailyChallengeGameLevel val_25 = this.CurrentLevel;
        val_24[1] = val_25.stars;
        mem2[0] = UnityEngine.Mathf.Max(values:  val_24);
        label_47:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_27 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        DailyChallengeGameLevel val_28 = this.CurrentLevel;
        val_27.Add(key:  "stars", value:  val_28.stars);
        val_27.Add(key:  "day", value:  this.<Status>k__BackingField.playingDay);
        val_36 = 1152921504988475392;
        val_41 = null;
        val_41 = null;
        val_35 = ZooTilePool.MonthlyZooTiles;
        ZooTile val_30 = val_35.Find(match:  new System.Predicate<ZooTile>(object:  this, method:  System.Boolean WGDailyChallengeManager::<UpdateMonthHistory>b__113_0(ZooTile x)));
        if(val_30 != null)
        {
                val_35 = val_30;
            if((this.monthZooTileCollection.Contains(item:  val_35)) != true)
        {
                val_42 = null;
            val_42 = null;
            System.Func<ZooTile, System.Boolean> val_32 = null;
            val_36 = val_32;
            val_32 = new System.Func<ZooTile, System.Boolean>(object:  this, method:  System.Boolean WGDailyChallengeManager::<UpdateMonthHistory>b__113_1(ZooTile x));
            ZooTile val_34 = System.Linq.Enumerable.First<ZooTile>(source:  System.Linq.Enumerable.Where<ZooTile>(source:  ZooTilePool.MonthlyZooTiles, predicate:  val_32));
            if(this.monthHistory.stars >= val_34.requiredStars)
        {
                val_43 = null;
            val_43 = null;
            WGDailyChallengeV2Popup.newZooTile = val_35;
            this.monthZooTileCollection.Add(item:  val_35);
            val_27.Add(key:  "current_month_tile", value:  val_30.name);
            if(this.OnZooTileEarned != null)
        {
                this.OnZooTileEarned.Invoke();
        }
        
        }
        
        }
        
        }
        
        this.UpdateToSever(parameters:  val_27);
    }
    public bool IsMorningChallengePerfectCompletion()
    {
        return (bool)(this.todaysProgress.morningChallenge == 3) ? 1 : 0;
    }
    public bool IsEveningChallengePerfectCompletion()
    {
        return (bool)(this.todaysProgress.eveningChallenge == 3) ? 1 : 0;
    }
    public bool PlayingCurrentWeek()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_3 = new System.DateTime(year:  val_1.dateData.Year, month:  this.<Status>k__BackingField.playingMonth, day:  this.<Status>k__BackingField.playingDay);
        System.DateTime val_4 = DateTimeCheat.Today;
        System.DateTime val_5 = DateTimeCheat.Today;
        System.DateTime val_7 = val_4.dateData.AddDays(value:  (double)-val_5.dateData.DayOfWeek);
        return (bool)System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = val_7.dateData});
    }
    private void UpdateToSever(System.Collections.Generic.Dictionary<string, object> parameters)
    {
        object val_11;
        var val_12;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "version", value:  val_1.Version);
        Player val_3 = App.Player;
        val_1.Add(key:  "user_id", value:  val_3.id);
        val_1.Add(key:  "timezone", value:  DeviceIdPlugin.GetTimeZone());
        val_11 = mem[this.PlayingMorning == false ? "e" : "m"];
        val_11 = (this.PlayingMorning == false) ? "e" : "m";
        val_1.Add(key:  "period", value:  val_11);
        if((this.<HackDateTime>k__BackingField) != false)
        {
                System.DateTime val_6 = DateTimeCheat.Now;
            val_11 = val_6.dateData.ToString();
            val_1.Add(key:  "hack_time", value:  val_11);
        }
        
        Dictionary.Enumerator<TKey, TValue> val_8 = parameters.GetEnumerator();
        label_12:
        if(0.MoveNext() == false)
        {
            goto label_11;
        }
        
        val_1.Add(key:  0, value:  0);
        goto label_12;
        label_11:
        0.Dispose();
        val_12 = null;
        val_12 = null;
        App.networkManager.DoPut(path:  "/api/word/daily_challenges/1", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGDailyChallengeManager::OnPutResponse(string method, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    private bool IsToday(int day)
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        return (bool)(val_1.dateData.Day == day) ? 1 : 0;
    }
    private void OnPutResponse(string method, System.Collections.Generic.Dictionary<string, object> response)
    {
        if((response != null) && ((response.ContainsKey(key:  "success")) != false))
        {
                if(response.Item["success"] != null)
        {
                this.UpdateDataFromServer(response:  response);
            return;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "Failed to update progress on server.");
    }
    private DailyChallenge_MonthHistory ParseMonthProgress(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_6;
        string val_7;
        string val_42;
        string val_43;
        string val_44;
        DailyChallenge_DayProgress val_45;
        val_42 = data;
        int val_15 = 0;
        int val_23 = 0;
        DailyChallenge_MonthHistory val_1 = null;
        val_44 = 0;
        val_1 = new DailyChallenge_MonthHistory();
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = "month_data";
        if((val_42.ContainsKey(key:  val_44)) == false)
        {
            goto label_57;
        }
        
        val_44 = "month_data";
        object val_3 = val_42.Item[val_44];
        if(val_3 == null)
        {
            goto label_57;
        }
        
        val_42 = val_3;
        Dictionary.Enumerator<TKey, TValue> val_4 = val_42.GetEnumerator();
        label_55:
        val_44 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Type.op_Equality(left:  val_7.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_55;
        }
        
        DailyChallenge_DayProgress val_12 = null;
        val_44 = 0;
        val_12 = new DailyChallenge_DayProgress();
        if((val_7.ContainsKey(key:  "m")) != false)
        {
                val_44 = "m";
            object val_14 = val_7.Item[val_44];
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_14, result: out  val_15)) != false)
        {
                if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            .stars_m = 0;
            val_43 = val_7;
            int val_17 = System.Int32.Parse(s:  val_43);
            val_44 = val_17;
            if((val_17.IsToday(day:  val_44)) != false)
        {
                if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
            this.todaysProgress.morningChallenge.done = true;
            val_43 = this.todaysProgress;
            if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
            DailyChallengeGameLevel val_19 = this.CurrentLevel;
            if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_19.hasStartedPreviously != true)
        {
                if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = this.<Status>k__BackingField.playingDay;
            if((val_19.IsToday(day:  val_44)) != false)
        {
                if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                if((this.<Status>k__BackingField.lastPlayedLevel) == null)
        {
                throw new NullReferenceException();
        }
        
            this.<Status>k__BackingField.lastPlayedLevel.done = true;
            if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<Status>k__BackingField.lastPlayedLevel) == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = 1;
            if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<Status>k__BackingField.lastPlayedLevel) == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = val_15;
            val_43 = this.<Status>k__BackingField;
            if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        val_44 = "e";
        if((val_7.ContainsKey(key:  val_44)) != false)
        {
                val_44 = "e";
            object val_22 = val_7.Item[val_44];
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_22, result: out  val_23)) != false)
        {
                if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            .stars_e = 0;
            val_43 = val_7;
            int val_25 = System.Int32.Parse(s:  val_43);
            val_44 = val_25;
            if((val_25.IsToday(day:  val_44)) != false)
        {
                if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.todaysProgress.eveningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
            this.todaysProgress.eveningChallenge.done = true;
            val_43 = this.todaysProgress;
            if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
            DailyChallengeGameLevel val_27 = this.CurrentLevel;
            if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_27.hasStartedPreviously != true)
        {
                if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = this.<Status>k__BackingField.playingDay;
            if((val_27.IsToday(day:  val_44)) != false)
        {
                if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                if((this.<Status>k__BackingField.lastPlayedLevel) == null)
        {
                throw new NullReferenceException();
        }
        
            this.<Status>k__BackingField.lastPlayedLevel.done = true;
            if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<Status>k__BackingField.lastPlayedLevel) == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = 0;
            if((this.<Status>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            mem2[0] = val_23;
            val_43 = this.<Status>k__BackingField;
            if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (DailyChallenge_MonthHistory)[1152921517796204720].progress;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43.Add(key:  val_7, value:  val_12);
        goto label_55;
        label_6:
        val_44 = public System.Void Dictionary.Enumerator<System.String, System.Object>::Dispose();
        val_6.Dispose();
        val_45 = 1152921510214912464;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .stars = 0;
        val_44 = "last_monthly_collected";
        if((val_42.ContainsKey(key:  val_44)) != false)
        {
                val_44 = "last_monthly_collected";
            object val_30 = val_42.Item[val_44];
            if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
            val_42 = val_30;
            val_44 = this.lastMonthRewardCollected;
            bool val_31 = System.DateTime.TryParse(s:  val_42, result: out  new System.DateTime() {dateData = val_44});
        }
        
        label_57:
        val_43 = 0;
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
                return val_1;
        }
        
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                return val_1;
        }
        
        System.DateTime val_33 = DateTimeCheat.Now;
        val_44 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_33.dateData.Day.ToString();
        val_43 = (DailyChallenge_MonthHistory)[1152921517796204720].progress;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_42;
        if((val_43.ContainsKey(key:  val_44)) != true)
        {
                DailyChallenge_DayProgress val_37 = null;
            val_44 = 0;
            val_45 = val_37;
            val_37 = new DailyChallenge_DayProgress();
            if((DailyChallenge_MonthHistory)[1152921517796204720].progress == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = val_42;
            (DailyChallenge_MonthHistory)[1152921517796204720].progress.Add(key:  val_44, value:  val_37);
        }
        
        val_43 = (DailyChallenge_MonthHistory)[1152921517796204720].progress;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_42;
        if(val_43.Item[val_44] == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_38.stars_m == this.todaysProgress.morningChallenge)
        {
                return val_1;
        }
        
        val_43 = (DailyChallenge_MonthHistory)[1152921517796204720].progress;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45 = (DailyChallenge_MonthHistory)[1152921517796204720].stars;
        val_44 = val_42;
        if(val_43.Item[val_44] == null)
        {
                throw new NullReferenceException();
        }
        
        int val_41 = val_39.stars_m;
        val_41 = val_45 - val_41;
        .stars = val_41;
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (DailyChallenge_MonthHistory)[1152921517796204720].progress;
        val_41 = this.todaysProgress.morningChallenge + val_41;
        .stars = val_41;
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_42;
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43.Item[val_44] == null)
        {
                throw new NullReferenceException();
        }
        
        val_40.stars_m = this.todaysProgress.morningChallenge;
        return val_1;
    }
    private DailyChallenge_WeekHistory ParseWeekProgress(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_6;
        string val_7;
        string val_34;
        System.Collections.Generic.Dictionary<System.String, DailyChallenge_DayProgress> val_35;
        string val_36;
        DailyChallenge_DayProgress val_37;
        val_34 = data;
        DailyChallenge_WeekHistory val_1 = null;
        val_36 = 0;
        val_1 = new DailyChallenge_WeekHistory();
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = "week_data";
        if((val_34.ContainsKey(key:  val_36)) == false)
        {
            goto label_25;
        }
        
        val_36 = "week_data";
        object val_3 = val_34.Item[val_36];
        if(val_3 == null)
        {
            goto label_25;
        }
        
        val_34 = val_3;
        Dictionary.Enumerator<TKey, TValue> val_4 = val_34.GetEnumerator();
        label_23:
        val_36 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Type.op_Equality(left:  val_7.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_23;
        }
        
        DailyChallenge_DayProgress val_12 = null;
        val_36 = 0;
        val_12 = new DailyChallenge_DayProgress();
        if((val_7.ContainsKey(key:  "m")) != false)
        {
                val_36 = "m";
            object val_14 = val_7.Item[val_36];
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_14, result: out  0)) != false)
        {
                if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            .stars_m = 0;
        }
        
        }
        
        if((val_7.ContainsKey(key:  "e")) != false)
        {
                val_36 = "e";
            object val_18 = val_7.Item[val_36];
            if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_18, result: out  0)) != false)
        {
                if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            .stars_e = 0;
        }
        
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        (DailyChallenge_WeekHistory)[1152921517796648704].progress.Add(key:  val_7, value:  val_12);
        goto label_23;
        label_6:
        val_36 = public System.Void Dictionary.Enumerator<System.String, System.Object>::Dispose();
        val_6.Dispose();
        val_37 = 1152921510214912464;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .stars = 0;
        val_36 = "last_weekly_collected";
        if((val_34.ContainsKey(key:  val_36)) != false)
        {
                val_36 = "last_weekly_collected";
            object val_22 = val_34.Item[val_36];
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = val_22;
            val_36 = this.lastWeekRewardCollected;
            bool val_23 = System.DateTime.TryParse(s:  val_34, result: out  new System.DateTime() {dateData = val_36});
        }
        
        label_25:
        val_35 = 0;
        if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() == false)
        {
                return val_1;
        }
        
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                return val_1;
        }
        
        System.DateTime val_25 = DateTimeCheat.Today;
        val_36 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = val_25.dateData.DayOfWeek.ToString();
        val_35 = (DailyChallenge_WeekHistory)[1152921517796648704].progress;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_34;
        if((val_35.ContainsKey(key:  val_36)) != true)
        {
                DailyChallenge_DayProgress val_29 = null;
            val_36 = 0;
            val_37 = val_29;
            val_29 = new DailyChallenge_DayProgress();
            if((DailyChallenge_WeekHistory)[1152921517796648704].progress == null)
        {
                throw new NullReferenceException();
        }
        
            val_36 = val_34;
            (DailyChallenge_WeekHistory)[1152921517796648704].progress.Add(key:  val_36, value:  val_29);
        }
        
        val_35 = (DailyChallenge_WeekHistory)[1152921517796648704].progress;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_34;
        if(val_35.Item[val_36] == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_30.stars_m == this.todaysProgress.morningChallenge)
        {
                return val_1;
        }
        
        val_35 = (DailyChallenge_WeekHistory)[1152921517796648704].progress;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = (DailyChallenge_WeekHistory)[1152921517796648704].stars;
        val_36 = val_34;
        if(val_35.Item[val_36] == null)
        {
                throw new NullReferenceException();
        }
        
        int val_33 = val_31.stars_m;
        val_33 = val_37 - val_33;
        .stars = val_33;
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = (DailyChallenge_WeekHistory)[1152921517796648704].progress;
        val_33 = this.todaysProgress.morningChallenge + val_33;
        .stars = val_33;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_34;
        if(this.todaysProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.todaysProgress.morningChallenge == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35.Item[val_36] == null)
        {
                throw new NullReferenceException();
        }
        
        val_32.stars_m = this.todaysProgress.morningChallenge;
        return val_1;
    }
    private System.Collections.Generic.List<ZooTile> ParseMonthZooTileCollection(System.Collections.Generic.Dictionary<string, object> data)
    {
        object val_7;
        var val_8;
        string val_15;
        var val_16;
        var val_17;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = data;
        System.Collections.Generic.List<ZooTile> val_1 = null;
        val_15 = public System.Void System.Collections.Generic.List<ZooTile>::.ctor();
        val_1 = new System.Collections.Generic.List<ZooTile>();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_13.ContainsKey(key:  "zoo_tile_data")) == false)
        {
                return val_1;
        }
        
        val_15 = "zoo_tile_data";
        object val_3 = val_13.Item[val_15];
        if(val_3 == null)
        {
                return val_1;
        }
        
        val_13 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        val_16 = "collection";
        if((val_13.ContainsKey(key:  "collection")) == false)
        {
                return val_1;
        }
        
        val_15 = "collection";
        object val_5 = val_13.Item[val_15];
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_6 = val_5.GetEnumerator();
        val_16 = 1152921510211410768;
        label_17:
        if(val_8.MoveNext() == false)
        {
            goto label_11;
        }
        
        WGDailyChallengeManager.<>c__DisplayClass122_0 val_10 = null;
        val_15 = 0;
        val_10 = new WGDailyChallengeManager.<>c__DisplayClass122_0();
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        .tile = val_7;
        val_17 = null;
        val_17 = null;
        System.Predicate<ZooTile> val_11 = null;
        val_15 = val_10;
        val_11 = new System.Predicate<ZooTile>(object:  val_10, method:  System.Boolean WGDailyChallengeManager.<>c__DisplayClass122_0::<ParseMonthZooTileCollection>b__0(ZooTile x));
        if(ZooTilePool.MonthlyZooTiles == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  ZooTilePool.MonthlyZooTiles.Find(match:  val_11));
        goto label_17;
        label_11:
        val_8.Dispose();
        return val_1;
    }
    private void CheckAndHandleRollover()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        if(this.IsDayRollover() != false)
        {
                this.HandleDayRollover();
            return;
        }
        
        if(this.IsChallengeDifferent() == false)
        {
                return;
        }
        
        this.HandleChallengeSwitch();
    }
    private bool IsDayRollover()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        return (bool)((val_1.dateData.ToOADate() ?? (this.<Status>k__BackingField.oa_date)) > this.EPSILON) ? 1 : 0;
    }
    public void HandleDayRollover()
    {
        PlayingLevel.CompleteLevel(mode:  2, parameters:  0);
        System.DateTime val_1 = DateTimeCheat.Today;
        this.<Status>k__BackingField.oa_date = val_1.dateData.ToOADate();
        this.<Status>k__BackingField.lastPlayedLevel = new DailyChallengeLastPlayedLevel(isMorning:  WGDailyChallengeManagerHelper.MorningChallengeAvailableNow());
        this.todaysProgress = new DailyChallengeProgress();
    }
    public void OnPointsGained(string word)
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        int val_4 = val_1.points;
        val_4 = val_4 + 1;
        val_1.points = val_4;
        if(word != null)
        {
                DailyChallengeGameLevel val_2 = this.CurrentLevel;
            val_2.found.Add(item:  word);
        }
        
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    public bool IsWeekRewardAvailable()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = DateTimeCheat.Today;
        System.DateTime val_4 = val_1.dateData.AddDays(value:  (double)-val_2.dateData.DayOfWeek);
        return (bool)System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = this.lastWeekRewardCollected});
    }
    public bool IsMonthRewardAvailable()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = DateTimeCheat.Today;
        System.DateTime val_4 = val_1.dateData.AddDays(value:  (double)-val_2.dateData.Day);
        return (bool)System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = this.lastMonthRewardCollected});
    }
    public bool IsPlayingPersistentLevel()
    {
        if((this.<Status>k__BackingField) != null)
        {
                return (bool)this.<Status>k__BackingField.playingPersistentLevel;
        }
        
        throw new NullReferenceException();
    }
    public bool IsPlayingTodaysLevel()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        return (bool)((this.<Status>k__BackingField.playingDay) == val_1.dateData.Day) ? 1 : 0;
    }
    public bool CurrentChallengeComplete()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        return (bool)val_1.gameLevel.completed;
    }
    public void ShowLevelComplete()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDailyChallengeLevelComplete>(showNext:  false);
    }
    public DailyChallengeLastPlayedLevel GetLastPlayedLevel()
    {
        if((this.<Status>k__BackingField) != null)
        {
                return (DailyChallengeLastPlayedLevel)this.<Status>k__BackingField.lastPlayedLevel;
        }
        
        throw new NullReferenceException();
    }
    public bool IsPlayingValid()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        return (bool)((this.<Status>k__BackingField.playingMonth) == val_1.dateData.Month) ? 1 : 0;
    }
    private void OnAppleAwarded(int appleAwarded)
    {
        if(this.PlayingMorning != true)
        {
                if(this.PlayingEvening == false)
        {
                return;
        }
        
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WGDailyChallengeLevelComplete>().isActiveAndEnabled) != false)
        {
                return;
        }
        
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        int val_10 = val_4.leaguePointsEarned;
        val_10 = val_10 + appleAwarded;
        val_4.leaguePointsEarned = val_10;
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        DailyChallengeGameLevel val_7 = this.CurrentLevel;
        val_5.largestWordStreak = UnityEngine.Mathf.Max(a:  WordStreak.LargestStreak, b:  val_7.largestWordStreak);
        DailyChallengeGameLevel val_9 = this.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    private void RunLevelGenerationPrep()
    {
        var val_13;
        float val_14;
        var val_23;
        System.Func<StarTier, System.Int32, __f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>> val_25;
        var val_26;
        System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Boolean> val_28;
        var val_29;
        System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Int32> val_31;
        var val_32;
        var val_33;
        System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>, System.Single> val_35;
        val_23 = null;
        val_23 = null;
        val_25 = WGDailyChallengeManager.<>c.<>9__136_0;
        if(val_25 == null)
        {
                System.Func<StarTier, System.Int32, __f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>> val_2 = null;
            val_25 = val_2;
            val_2 = new System.Func<StarTier, System.Int32, __f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  __f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32> WGDailyChallengeManager.<>c::<RunLevelGenerationPrep>b__136_0(StarTier value, int index));
            WGDailyChallengeManager.<>c.<>9__136_0 = val_25;
        }
        
        val_26 = null;
        val_26 = null;
        val_28 = WGDailyChallengeManager.<>c.<>9__136_1;
        if(val_28 == null)
        {
                System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Boolean> val_4 = null;
            val_28 = val_4;
            val_4 = new System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Boolean>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeManager.<>c::<RunLevelGenerationPrep>b__136_1(<>f__AnonymousType0<StarTier, int> pair));
            WGDailyChallengeManager.<>c.<>9__136_1 = val_28;
        }
        
        val_29 = null;
        val_29 = null;
        val_31 = WGDailyChallengeManager.<>c.<>9__136_2;
        if(val_31 == null)
        {
                System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Int32> val_6 = null;
            val_31 = val_6;
            val_6 = new System.Func<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Int32>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGDailyChallengeManager.<>c::<RunLevelGenerationPrep>b__136_2(<>f__AnonymousType0<StarTier, int> pair));
            WGDailyChallengeManager.<>c.<>9__136_2 = val_31;
        }
        
        System.Collections.Generic.IEnumerable<TResult> val_7 = System.Linq.Enumerable.Select<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>, System.Int32>(source:  System.Linq.Enumerable.Where<__f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>>(source:  System.Linq.Enumerable.Select<StarTier, __f__AnonymousType0__value_j__TPar, _index_j__TPar_<StarTier, System.Int32>>(source:  this.<Econ>k__BackingField.StarTiers.Tiers, selector:  val_2), predicate:  val_4), selector:  val_6);
        if((System.Linq.Enumerable.Any<System.Int32>(source:  val_7)) != false)
        {
                val_32 = System.Linq.Enumerable.First<System.Int32>(source:  val_7);
        }
        else
        {
                val_32 = 44393391;
        }
        
        if(1152921517798743840 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_23 = mem[399540552];
        DailyChallengeGameLevel val_10 = this.CurrentLevel;
        if(val_23 <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_23 = val_23 + 355147128;
        val_10.tier = (mem[399540552] + 355147128) + 32;
        System.Collections.Generic.Dictionary<System.Int32, System.Single> val_11 = new System.Collections.Generic.Dictionary<System.Int32, System.Single>();
        Dictionary.Enumerator<TKey, TValue> val_12 = mem[399540552] + 24.GetEnumerator();
        float val_24 = 0f;
        label_29:
        if(val_13.MoveNext() == false)
        {
            goto label_27;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_24 + val_14;
        val_11.Add(key:  val_14, value:  val_24);
        goto label_29;
        label_27:
        val_13.Dispose();
        val_33 = null;
        val_33 = null;
        val_35 = WGDailyChallengeManager.<>c.<>9__136_3;
        if(val_35 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>, System.Single> val_16 = null;
            val_35 = val_16;
            val_16 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>, System.Single>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Single WGDailyChallengeManager.<>c::<RunLevelGenerationPrep>b__136_3(System.Collections.Generic.KeyValuePair<int, float> x));
            WGDailyChallengeManager.<>c.<>9__136_3 = val_35;
        }
        
        System.Linq.IOrderedEnumerable<TSource> val_17 = System.Linq.Enumerable.OrderBy<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>, System.Single>(source:  val_11, keySelector:  val_16);
        float val_18 = UnityEngine.Random.Range(min:  0f, max:  100f);
        val_18 = val_18 / 100f;
        .rand = val_18;
        System.Collections.Generic.KeyValuePair<System.Int32, System.Single> val_20 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>>(source:  val_11, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Single>, System.Boolean>(object:  new WGDailyChallengeManager.<>c__DisplayClass136_0(), method:  System.Boolean WGDailyChallengeManager.<>c__DisplayClass136_0::<RunLevelGenerationPrep>b__4(System.Collections.Generic.KeyValuePair<int, float> x)));
        this.<Econ>k__BackingField.ChallengeDefinition.LettersLength = val_11;
        System.Collections.Generic.List<System.Int32> val_21 = this.<Econ>k__BackingField.ChallengeDefinition.LettersWordCount.Item[307172832];
        if((this.<Econ>k__BackingField) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<Econ>k__BackingField.ChallengeDefinition.MaxRequiredWordsAmount = this.<Econ>k__BackingField;
        System.Collections.Generic.List<System.Int32> val_22 = this.<Econ>k__BackingField.ChallengeDefinition.LettersWordCount.Item[307172832];
        if((this.<Econ>k__BackingField) == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredWordsAmount = this.<Econ>k__BackingField.ChallengeDefinition;
    }
    private GameLevel GenerateOrLoadLevel(string levelName, int tries = 0, GameplayMode mode = 2)
    {
        GameLevel val_15;
        var val_16;
        int val_15 = tries;
        goto label_0;
        label_42:
        mem[1152921517799218032] = ???;
        .levelWordLength = this.<Econ>k__BackingField.ChallengeDefinition.LettersLength;
        mem[1152921517799218036] = this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredLength;
        mem[1152921517799218040] = this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredLength;
        mem[1152921517799218054] = 0;
        mem[1152921517799218052] = true;
        mem[1152921517799218044] = this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredLength;
        val_15 = MonoSingletonSelfGenerating<WADataParser>.Instance.GetDynamicDailyChallengeLevel(param:  new DynamicLevelBuildParams());
        if(val_3.actualWordCount >= (this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredWordsAmount))
        {
            goto label_16;
        }
        
        if(val_15 <= 19)
        {
            goto label_17;
        }
        
        goto label_20;
        label_16:
        if((val_15 > 19) || (val_3.actualWordCount <= (this.<Econ>k__BackingField.ChallengeDefinition.MaxRequiredWordsAmount)))
        {
            goto label_20;
        }
        
        label_17:
        val_15 = val_15 + 1;
        label_0:
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
            goto label_26;
        }
        
        DailyChallengeTutorialManager val_6 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        if(val_6._TutorialActive == true)
        {
            goto label_30;
        }
        
        label_26:
        GameLevel val_7 = PlayingLevel.GetCurrentDailyChallengeLevel();
        if((val_7 != null) && (mode != 3))
        {
                val_15 = val_7;
            if(val_7.completed == false)
        {
                return val_15;
        }
        
        }
        
        this.RunLevelGenerationPrep();
        int val_9 = UnityEngine.Random.Range(min:  this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredWordsAmount, max:  (this.<Econ>k__BackingField.ChallengeDefinition.MaxRequiredWordsAmount) + 1);
        GameBehavior val_10 = App.getBehavior;
        if(((val_10.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_42;
        }
        
        val_15 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.GetDynamicDailyChallengeLevel(wordLength:  this.<Econ>k__BackingField.ChallengeDefinition.LettersLength, wordCount:  val_9, maxWordCount:  val_9);
        label_20:
        val_15.levelName = levelName;
        val_16 = null;
        goto label_51;
        label_30:
        val_15 = MonoSingleton<DailyChallengeTutorialManager>.Instance.GetGameLevel();
        val_16 = null;
        label_51:
        PlayingLevel.SetLevel(currentMode:  mode, level:  val_15, parameters:  0, skipSaving:  false);
        return val_15;
    }
    public int GetGoldenAppleReward()
    {
        int val_4;
        int val_5;
        val_4 = this;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                WordForest.WFOManagerGameplay val_2 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
            val_5 = val_2.<lastCompletedAcornsTotal>k__BackingField;
            return (int)null;
        }
        
        DailyChallengeDefinition val_4 = this.<Econ>k__BackingField.ChallengeDefinition;
        DailyChallengeGameLevel val_3 = this.CurrentLevel;
        val_4 = val_3.stars;
        if(val_4 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + ((val_3.stars) << 3);
        return (int)null;
    }
    public int GetMatchingDayDistance()
    {
        var val_20;
        var val_21;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32> val_23;
        var val_24;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Boolean> val_26;
        var val_27;
        var val_29;
        .todayOnCalendar = this.<Status>k__BackingField.todayOnCalendar;
        val_20 = 1152921504614567936;
        val_21 = null;
        val_21 = null;
        val_23 = WGDailyChallengeManager.<>c.<>9__139_1;
        if(val_23 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32> val_4 = null;
            val_23 = val_4;
            val_4 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGDailyChallengeManager.<>c::<GetMatchingDayDistance>b__139_1(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x));
            WGDailyChallengeManager.<>c.<>9__139_1 = val_23;
        }
        
        System.Collections.Generic.List<TSource> val_6 = System.Linq.Enumerable.ToList<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  System.Linq.Enumerable.OrderBy<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32>(source:  System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  this.monthHistory.progress, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Boolean>(object:  new WGDailyChallengeManager.<>c__DisplayClass139_0(), method:  System.Boolean WGDailyChallengeManager.<>c__DisplayClass139_0::<GetMatchingDayDistance>b__0(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x))), keySelector:  val_4));
        .i = 1;
        if(((WGDailyChallengeManager.<>c__DisplayClass139_0)[1152921517799703136].todayOnCalendar) >= 2)
        {
                do
        {
            if((System.Linq.Enumerable.Any<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  val_6, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Boolean>(object:  new WGDailyChallengeManager.<>c__DisplayClass139_1(), method:  System.Boolean WGDailyChallengeManager.<>c__DisplayClass139_1::<GetMatchingDayDistance>b__4(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x)))) != true)
        {
                System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress> val_12 = new System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>(key:  .i.ToString(), value:  new DailyChallenge_DayProgress());
            val_6.Add(item:  new System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>() {Value = val_12.Value});
            val_20 = val_20;
        }
        
            int val_20 = .i;
            val_20 = val_20 + 1;
            mem[1152921517799740016] = val_20;
        }
        while(val_20 < ((WGDailyChallengeManager.<>c__DisplayClass139_0)[1152921517799703136].todayOnCalendar));
        
        }
        
        val_24 = null;
        val_24 = null;
        val_26 = WGDailyChallengeManager.<>c.<>9__139_2;
        if(val_26 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Boolean> val_13 = null;
            val_26 = val_13;
            val_13 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Boolean>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeManager.<>c::<GetMatchingDayDistance>b__139_2(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x));
            WGDailyChallengeManager.<>c.<>9__139_2 = val_26;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_14 = System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  val_6, predicate:  val_13);
        System.Collections.Generic.List<TSource> val_15 = System.Linq.Enumerable.ToList<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  val_14);
        if((public static System.Collections.Generic.IEnumerable<TSource> System.Linq.Enumerable::Where<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)) != 0)
        {
                val_27 = null;
            val_27 = null;
            val_26 = WGDailyChallengeManager.<>c.<>9__139_3;
            if(val_26 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32> val_16 = null;
            val_26 = val_16;
            val_16 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGDailyChallengeManager.<>c::<GetMatchingDayDistance>b__139_3(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x));
            WGDailyChallengeManager.<>c.<>9__139_3 = val_26;
        }
        
            System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress> val_18 = System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>>(source:  System.Linq.Enumerable.OrderByDescending<System.Collections.Generic.KeyValuePair<System.String, DailyChallenge_DayProgress>, System.Int32>(source:  val_14, keySelector:  val_16));
            val_29 = (System.Int32.Parse(s:  val_18.Value)) - ((WGDailyChallengeManager.<>c__DisplayClass139_0)[1152921517799703136].todayOnCalendar);
            return (int)val_29;
        }
        
        val_29 = 0;
        return (int)val_29;
    }
    public System.Collections.Generic.List<ZooTile> GetLifetimeMonthlyZootiles()
    {
        var val_3 = null;
        return System.Linq.Enumerable.ToList<ZooTile>(source:  System.Linq.Enumerable.Except<ZooTile>(first:  this.ZooTileCollection, second:  ZooTilePool.LifetimeZooTiles));
    }
    public bool IsTooltipReadyToShow()
    {
        var val_6;
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
            goto label_5;
        }
        
        DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        if(val_3._TutorialActive == true)
        {
            goto label_15;
        }
        
        label_5:
        if((SceneDictator.IsInGameScene() != false) && ((this.<Status>k__BackingField.lastPlayedLevel.day) == (this.<Status>k__BackingField.todayOnCalendar)))
        {
                var val_5 = ((this.<Status>k__BackingField.lastPlayedLevel.done) == true) ? 1 : 0;
            return (bool)val_6;
        }
        
        label_15:
        val_6 = 0;
        return (bool)val_6;
    }
    public decimal GetRetryCost()
    {
        var val_1 = ((this.<Status>k__BackingField.playingPersistentLevel) == false) ? 20 : 16;
        return System.Decimal.op_Implicit(value:  363683840);
    }
    public void CollectWeeklyReward()
    {
        if(this.IsWeekRewardAvailable() != false)
        {
                GameBehavior val_2 = App.getBehavior;
            val_2.<metaGameBehavior>k__BackingField.Setup(rewardSource:  10);
            System.Delegate val_5 = System.Delegate.Combine(a:  X21, b:  new System.Action(object:  this, method:  System.Void WGDailyChallengeManager::OnWeeklyRewardCollected()));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            mem2[0] = val_5;
            return;
        }
        
        SLCDebug.Log(logMessage:  "Error: trying to collect Daily Challenge Weekly Reward before it\'s ready. Aborting.", colorHash:  "#FFFFFF", isError:  true);
        return;
        label_8:
    }
    public void CollectMonthlyReward()
    {
        if(this.IsMonthRewardAvailable() != false)
        {
                GameBehavior val_2 = App.getBehavior;
            val_2.<metaGameBehavior>k__BackingField.Setup(rewardSource:  11);
            System.Delegate val_5 = System.Delegate.Combine(a:  X21, b:  new System.Action(object:  this, method:  System.Void WGDailyChallengeManager::OnMonthlyRewardCollected()));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            mem2[0] = val_5;
            return;
        }
        
        SLCDebug.Log(logMessage:  "Error: trying to collect Daily Challenge Monthly Reward before it\'s ready. Aborting.", colorHash:  "#FFFFFF", isError:  true);
        return;
        label_8:
    }
    private void OnWeeklyRewardCollected()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        this.lastWeekRewardCollected = val_1;
        if(this.OnWeeklyMonthlyRewardCollected != null)
        {
                this.OnWeeklyMonthlyRewardCollected.Invoke();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "last_weekly_collected", value:  this.lastWeekRewardCollected.ToString());
        this.UpdateToSever(parameters:  val_2);
    }
    private void OnMonthlyRewardCollected()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        this.lastMonthRewardCollected = val_1;
        if(this.OnWeeklyMonthlyRewardCollected != null)
        {
                this.OnWeeklyMonthlyRewardCollected.Invoke();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "last_monthly_collected", value:  this.lastMonthRewardCollected.ToString());
        this.UpdateToSever(parameters:  val_2);
    }
    private void TrackChallengeComplete()
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_34;
        var val_35;
        var val_36;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_34 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.DateTime val_3 = DateTimeCheat.Now;
        val_2.Add(key:  "date", value:  val_3.dateData.ToString());
        val_2.Add(key:  "word", value:  this.GetLevelForTracking());
        val_2.Add(key:  "# of Letters", value:  val_1.m_stringLength);
        DailyChallengeGameLevel val_5 = this.CurrentLevel;
        val_2.Add(key:  "Hints Used", value:  val_5.regularHintsUsed);
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        val_2.Add(key:  "Hints Used Picker", value:  val_6.pickerHintsUsed);
        DailyChallengeGameLevel val_7 = this.CurrentLevel;
        val_2.Add(key:  "Stars Earned", value:  val_7.stars);
        DailyChallengeGameLevel val_8 = this.CurrentLevel;
        val_2.Add(key:  "Retry", value:  val_8.isRetryLevel);
        val_2.Add(key:  "Challenge Complete", value:  true);
        if((this.<Status>k__BackingField.playingPersistentLevel) != false)
        {
                DailyChallengeGameLevel val_9 = this.CurrentLevel;
            val_2.Add(key:  "Challenge Resumed", value:  val_9.challengeResumed);
            val_34 = val_34;
        }
        
        DailyChallengeGameLevel val_10 = this.CurrentLevel;
        DailyChallengeGameLevel val_11 = this.CurrentLevel;
        System.Collections.Generic.List<System.String> val_34 = val_11.found;
        val_34 = val_10.gameLevel.actualWordCount - val_34;
        val_2.Add(key:  "Remaining Words", value:  val_34);
        val_2.Add(key:  "Time Spent", value:  this.GetTimeSpent());
        DailyChallengeGameLevel val_13 = this.CurrentLevel;
        val_2.Add(key:  "Stars Starting", value:  val_13.sessionStarsStarting);
        GameBehavior val_14 = App.getBehavior;
        if(((val_14.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                DailyChallengeGameLevel val_15 = this.CurrentLevel;
            WordForest.WFOManagerGameplay val_16 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
            val_15.largestWordStreak = val_16.<lastCompletedWordStreak>k__BackingField;
        }
        
        DailyChallengeGameLevel val_17 = this.CurrentLevel;
        val_2.Add(key:  "Largest Word Streak", value:  val_17.largestWordStreak);
        GameBehavior val_18 = App.getBehavior;
        if(((val_18.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                DailyChallengeGameLevel val_19 = this.CurrentLevel;
            WordForest.WFOManagerGameplay val_20 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
            val_19.leaguePointsEarned = val_20.<lastCompletedAcornsTotal>k__BackingField;
        }
        
        DailyChallengeGameLevel val_21 = this.CurrentLevel;
        val_2.Add(key:  "League Points Earned", value:  val_21.leaguePointsEarned);
        DailyChallengeGameLevel val_22 = this.CurrentLevel;
        val_2.Add(key:  "Stars Saved", value:  val_22.starsSaved);
        MonoSingleton<WordGameEventsController>.Instance.AppendDailyChallengeCompleteData(curData: ref  val_2);
        val_35 = null;
        val_35 = null;
        App.trackerManager.track(eventName:  "Daily Challenges", data:  val_2);
        val_36 = 1152921504975269888;
        if(WordStreak.ApplesFromStreak >= 1)
        {
                val_36 = App.Player;
            val_36.TrackNonCoinReward(source:  "Gameplay", subSource:  "streak_" + WordStreak.LargestStreak, rewardType:  "Golden Currency", rewardAmount:  WordStreak.ApplesFromStreak.ToString(), additionalParams:  0);
        }
        
        if(ExtraWord.ApplesFromExtra < 1)
        {
                return;
        }
        
        val_36 = App.Player;
        val_36.TrackNonCoinReward(source:  "extra_word", subSource:  0, rewardType:  "Golden Currency", rewardAmount:  ExtraWord.ApplesFromExtra.ToString(), additionalParams:  0);
    }
    public string GetStageForTracking()
    {
        return (string)(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != true) ? "m" : "e";
    }
    public string GetLevelForTracking()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        return val_1.gameLevel.word.Replace(oldValue:  "|", newValue:  "");
    }
    public void OnStarsSaved()
    {
        DailyChallengeGameLevel val_1 = this.CurrentLevel;
        int val_3 = val_1.starsSaved;
        val_3 = val_3 + 1;
        val_1.starsSaved = val_3;
        DailyChallengeGameLevel val_2 = this.CurrentLevel;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    public string Hack_GetTileInfo()
    {
        var val_15;
        var val_16;
        System.Func<ZooTile, System.String> val_18;
        var val_19;
        System.Func<ZooTile, System.String> val_21;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_2 = val_1.AppendFormat(format:  "Current month tile: <color=#F2240D>{0}</color>\n\n", arg0:  this.monthHistory.tile);
        val_15 = null;
        val_15 = null;
        val_16 = null;
        val_16 = null;
        val_18 = WGDailyChallengeManager.<>c.<>9__151_0;
        if(val_18 == null)
        {
                System.Func<ZooTile, System.String> val_4 = null;
            val_18 = val_4;
            val_4 = new System.Func<ZooTile, System.String>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.String WGDailyChallengeManager.<>c::<Hack_GetTileInfo>b__151_0(ZooTile x));
            WGDailyChallengeManager.<>c.<>9__151_0 = val_18;
        }
        
        System.Text.StringBuilder val_8 = val_1.AppendFormat(format:  "Available month tiles (pool): <color=#D5CF01>{0}</color>\n\n", arg0:  MiniJSON.Json.Serialize(obj:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<ZooTile, System.String>(source:  System.Linq.Enumerable.Except<ZooTile>(first:  ZooTilePool.MonthlyZooTiles, second:  this.monthZooTileCollection), selector:  val_4))));
        val_19 = null;
        val_19 = null;
        val_21 = WGDailyChallengeManager.<>c.<>9__151_1;
        if(val_21 == null)
        {
                System.Func<ZooTile, System.String> val_10 = null;
            val_21 = val_10;
            val_10 = new System.Func<ZooTile, System.String>(object:  WGDailyChallengeManager.<>c.__il2cppRuntimeField_static_fields, method:  System.String WGDailyChallengeManager.<>c::<Hack_GetTileInfo>b__151_1(ZooTile x));
            WGDailyChallengeManager.<>c.<>9__151_1 = val_21;
        }
        
        System.Text.StringBuilder val_14 = val_1.AppendFormat(format:  "All Tile Collection: <color=#77BB66>{0}</color>\n\n", arg0:  MiniJSON.Json.Serialize(obj:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<ZooTile, System.String>(source:  this.ZooTileCollection, selector:  val_10))));
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    public string Hack_GetLevelInfo()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        DailyChallengeGameLevel val_2 = this.CurrentLevel;
        System.Text.StringBuilder val_3 = val_1.AppendFormat(format:  "Word: <color=#F2240D>{0}</color>\n", arg0:  val_2.gameLevel.word);
        DailyChallengeGameLevel val_4 = this.CurrentLevel;
        System.Text.StringBuilder val_5 = val_1.AppendFormat(format:  "Answers: <color=#D5CF01>{0}</color>\n", arg0:  val_4.gameLevel.answers);
        DailyChallengeGameLevel val_6 = this.CurrentLevel;
        System.Text.StringBuilder val_7 = val_1.AppendFormat(format:  "Extra: <color=#77BB66>{0}</color>\n", arg0:  val_6.gameLevel.extraWords);
        System.Text.StringBuilder val_8 = val_1.Append(value:  '
        ');
        DailyChallengeGameLevel val_9 = this.CurrentLevel;
        if(val_9.tier != null)
        {
                DailyChallengeGameLevel val_10 = this.CurrentLevel;
            System.Text.StringBuilder val_12 = val_1.AppendFormat(format:  "Star tier: <color=#F2240D>{0}</color>\n", arg0:  val_10.tier.ToJSON());
        }
        
        System.Text.StringBuilder val_13 = val_1.AppendFormat(format:  "Word length: <color=#D5CF01>{0}</color>\n", arg0:  this.<Econ>k__BackingField.ChallengeDefinition.LettersLength);
        System.Text.StringBuilder val_14 = val_1.AppendFormat(format:  "Min words: <color=#77BB66>{0}</color>\n", arg0:  this.<Econ>k__BackingField.ChallengeDefinition.MinRequiredWordsAmount);
        System.Text.StringBuilder val_15 = val_1.AppendFormat(format:  "Max words: <color=#77FF66>{0}</color>\n", arg0:  this.<Econ>k__BackingField.ChallengeDefinition.MaxRequiredWordsAmount);
        return (string)val_1;
    }
    public void Hack_ResetMonthTileOnServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "reset_month_tile", value:  true);
        this.UpdateToSever(parameters:  val_1);
    }
    public void Hack_FillStars(int days)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        int val_3 = val_2.dcStars;
        val_3 = val_3 + (days * 6);
        val_2.dcStars = val_3;
        val_1.Add(key:  "fill_stars", value:  days);
        this.UpdateToSever(parameters:  val_1);
    }
    public void Hack_ResetDailyChallenge()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "reset_progress", value:  true);
        this.UpdateToSever(parameters:  val_1);
        this.Hack_ResetLastPlayedTime();
    }
    public void Hack_MonthTileCollection()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "hack_collection", value:  true);
        this.UpdateToSever(parameters:  val_1);
    }
    public void Hack_CompleteMonthStars()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        int val_8 = 6;
        val_8 = val_2.dcStars + ((System.DateTime.DaysInMonth(year:  val_3.dateData.Year, month:  val_5.dateData.Month)) * val_8);
        val_2.dcStars = val_8;
        val_1.Add(key:  "hack_month_stars", value:  true);
        this.UpdateToSever(parameters:  val_1);
    }
    public void Hack_CompleteWeekStars()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        int val_3 = val_2.dcStars;
        val_3 = val_3 + 42;
        val_2.dcStars = val_3;
        val_1.Add(key:  "hack_week_stars", value:  true);
        this.UpdateToSever(parameters:  val_1);
    }
    public void Hack_ResetLastPlayedTime()
    {
        var val_2;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "last_dc_play_time")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "last_dc_play_time");
        }
        
        val_2 = null;
        val_2 = null;
        this._LastPlayedDailyChallenge = System.DateTime.MinValue;
    }
    public WGDailyChallengeManager()
    {
        var val_11;
        GameBehavior val_1 = App.getBehavior;
        this.dcRevamp = (val_1.<metaGameBehavior>k__BackingField) & 1;
        this.monthZooTileCollection = new System.Collections.Generic.List<ZooTile>();
        this.monthHistory = new DailyChallenge_MonthHistory();
        this.todaysProgress = new DailyChallengeProgress();
        this.weekHistory = new DailyChallenge_WeekHistory();
        val_11 = null;
        val_11 = null;
        this._LastPlayedDailyChallenge = System.DateTime.MinValue;
        this.missedChallengeLevel = new DailyChallengeGameLevel();
        this.answers = new System.Collections.Generic.List<System.String>();
        this.extraWords = new System.Collections.Generic.List<System.String>();
        this.actualWordsCount = new System.Collections.Generic.List<System.Int32>();
    }
    private static WGDailyChallengeManager()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        WGDailyChallengeManager.lastServerCall = val_1.dateData;
        WGDailyChallengeManager.secondsUntilNextRequest = 30;
    }
    private bool <UpdateMonthHistory>b__113_0(ZooTile x)
    {
        return System.String.op_Equality(a:  x.name, b:  this.monthHistory.tile);
    }
    private bool <UpdateMonthHistory>b__113_1(ZooTile x)
    {
        return System.String.op_Equality(a:  x.name, b:  this.monthHistory.tile);
    }

}
