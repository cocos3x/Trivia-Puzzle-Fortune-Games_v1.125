using UnityEngine;
public class GameEventsManager : MonoSingleton<GameEventsManager>
{
    // Fields
    private bool initialized;
    private string prefkey;
    private string timeCheatStampKey;
    private const string ApiUrl = "/api/game_events";
    public const string Notification_OnGameEventDataReceived = "OnGameEventDataReceived";
    public const string Notification_OnGameEventPutResponse = "OnGameEventDataPutResponse";
    public const string Notification_OnGameEventDownloaded = "OnGameEventDataDownloaded";
    public const string Notificaiton_OnResetHack = "OnResetHack";
    public const string Notification_OnAlmostCompleteHack = "OnAlmostCompleteHack";
    public const string Notification_OnAddEventCurrency = "OnAddEventCurrency";
    private bool <cheating>k__BackingField;
    private System.TimeSpan _serverOffsetTime;
    private float timeToUpdate;
    private static string lastEventsResponse;
    private System.Collections.Generic.List<GameEventV2> eventList;
    private bool isAsynching;
    private static System.DateTime lastServerUpdate;
    private static int secondsToLastUpdate;
    private bool synching;
    
    // Properties
    private string VersionString { get; }
    public bool cheating { get; set; }
    public bool isAvailable { get; }
    public System.DateTime ServerTime { get; }
    public System.Collections.Generic.List<GameEventV2> getGameEvents { get; }
    
    // Methods
    private string get_VersionString()
    {
        return "9";
    }
    public bool get_cheating()
    {
        return (bool)this.<cheating>k__BackingField;
    }
    protected void set_cheating(bool value)
    {
        this.<cheating>k__BackingField = value;
    }
    public bool get_isAvailable()
    {
        if(this.initialized == false)
        {
                return false;
        }
        
        return (bool)((this.<cheating>k__BackingField) == false) ? 1 : 0;
    }
    public System.DateTime get_ServerTime()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        return System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = this._serverOffsetTime});
    }
    public static string GetLastEventsResponseDebug()
    {
        null = null;
        return (string)GameEventsManager.lastEventsResponse;
    }
    public System.Collections.Generic.List<GameEventV2> get_getGameEvents()
    {
        return (System.Collections.Generic.List<GameEventV2>)this.eventList;
    }
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void GameEventsManager::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        this.<cheating>k__BackingField = false;
        this.DoAsync();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        return;
        label_5:
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void GameEventsManager::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    private void OnApplicationPaused(bool paused)
    {
        if(paused != false)
        {
                return;
        }
        
        this.storeData();
    }
    private void DoAsync()
    {
        if(this.isAsynching == true)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<AsyncExecution>.Instance.Async(callback:  new System.Action(object:  this, method:  System.Void GameEventsManager::init()), when:  2.4f);
        this.isAsynching = true;
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        if((sceneType - 1) > 1)
        {
                return;
        }
        
        if(this.synching == true)
        {
                return;
        }
        
        if(this.initialized == false)
        {
                return;
        }
        
        if((this.<cheating>k__BackingField) != false)
        {
                return;
        }
        
        this.RequestServerEvents();
    }
    private void OnLocalize()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        val_3 = null;
        val_3 = null;
        GameEventsManager.lastServerUpdate = System.DateTime.MinValue;
        this.eventList = new System.Collections.Generic.List<GameEventV2>();
        if(this.initialized == false)
        {
                return;
        }
        
        if((this.<cheating>k__BackingField) != false)
        {
                return;
        }
        
        this.RequestServerEvents();
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.timeToUpdate - val_1;
        this.timeToUpdate = val_1;
        if(val_1 > 0f)
        {
                return;
        }
        
        this.eventList = this.PurgeExpiredList(_eventList:  this.eventList);
        this.timeToUpdate = 1f;
    }
    private System.Collections.Generic.List<GameEventV2> PurgeExpiredList(System.Collections.Generic.List<GameEventV2> _eventList)
    {
        ulong val_6;
        var val_7;
        System.Collections.Generic.List<GameEventV2> val_1 = new System.Collections.Generic.List<GameEventV2>();
        List.Enumerator<T> val_2 = _eventList.GetEnumerator();
        label_8:
        val_6 = public System.Boolean List.Enumerator<GameEventV2>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        val_6 = val_4.dateData;
        val_7 = 0 + 48;
        if(((val_7.CompareTo(value:  new System.DateTime() {dateData = val_6})) & 2147483648) != 0)
        {
            goto label_8;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  0);
        goto label_8;
        label_2:
        0.Dispose();
        return val_1;
    }
    private void init()
    {
        var val_5;
        var val_6;
        System.Collections.IDictionary val_11;
        GameEventV2 val_12;
        var val_13;
        if(this.initialized == true)
        {
                return;
        }
        
        this.<cheating>k__BackingField = false;
        if((UnityEngine.PlayerPrefs.HasKey(key:  this.prefkey)) == false)
        {
            goto label_34;
        }
        
        List.Enumerator<T> val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this.prefkey)).GetEnumerator();
        label_12:
        if(val_6.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_12 = val_5;
        if(val_12 == 0)
        {
            goto label_7;
        }
        
        val_11 = X0;
        if(X0 == true)
        {
            goto label_8;
        }
        
        throw new NullReferenceException();
        label_7:
        val_11 = 0;
        label_8:
        GameEventV2 val_8 = null;
        val_12 = val_8;
        val_8 = new GameEventV2();
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Deserialize(data:  val_11);
        if(this.eventList == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventList.Add(item:  val_8);
        goto label_12;
        label_6:
        val_11 = 0;
        val_6.Dispose();
        if(val_11 != 0)
        {
                throw val_11;
        }
        
        this.eventList = val_6.PurgeExpiredList(_eventList:  this.eventList);
        label_34:
        this.synching = true;
        this.initialized = true;
        this.RequestServerEvents();
        this.isAsynching = false;
        return;
        label_35:
        val_13 = val_11;
        if(0 != 1)
        {
            goto label_30;
        }
        
        if((null & 1) == 0)
        {
            goto label_31;
        }
        
        UnityEngine.Debug.LogWarning(message:  "Unable to parse game event data, requestin from server.");
        goto label_34;
        label_31:
        mem[8] = 1179403647;
        goto label_35;
        label_30:
    }
    public void CheckAndRequestServerEvents()
    {
        if(this.synching != false)
        {
                return;
        }
        
        if(this.initialized == false)
        {
                return;
        }
        
        if((this.<cheating>k__BackingField) == true)
        {
                return;
        }
        
        this.RequestServerEvents();
    }
    private void RequestServerEvents()
    {
        ulong val_11;
        var val_12;
        var val_13;
        var val_14;
        System.DateTime val_1 = System.DateTime.UtcNow;
        val_11 = val_1.dateData;
        val_12 = null;
        val_12 = null;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_11}, d2:  new System.DateTime() {dateData = GameEventsManager.lastServerUpdate});
        if(val_2._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        System.DateTime val_4 = System.DateTime.UtcNow;
        val_13 = null;
        val_13 = null;
        GameEventsManager.lastServerUpdate = val_4.dateData;
        val_14 = null;
        val_14 = null;
        val_11 = App.networkManager;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "p", value:  "a");
        val_6.Add(key:  "v", value:  val_6.VersionString);
        val_6.Add(key:  "client_version", value:  DeviceIdPlugin.GetClientVersion());
        Player val_9 = App.Player;
        val_6.Add(key:  "bucket", value:  val_9.playerBucket);
        Player val_10 = App.Player;
        val_6.Add(key:  "user_id", value:  val_10.id);
        val_11.DoGet(path:  "/api/game_events", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void GameEventsManager::requestResponse(string method, System.Collections.Generic.Dictionary<string, object> data)), destroy:  false, immediate:  false, getParams:  val_6, timeout:  20);
    }
    private void requestResponse(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_14;
        var val_15;
        string val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        ulong val_21;
        System.Collections.IList val_22;
        val_14 = null;
        val_14 = null;
        if(Logger.GameEvents != false)
        {
                UnityEngine.Debug.Log(message:  "2jhtw34 GameEventsManager.requestResponse()");
        }
        
        val_15 = 1152921504917016576;
        val_16 = PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false);
        val_17 = null;
        val_17 = null;
        GameEventsManager.lastEventsResponse = val_16;
        val_18 = null;
        val_18 = null;
        if(Logger.GameEvents != false)
        {
                val_19 = null;
            val_19 = null;
            val_16 = "LATEST EVENTS RESPONSE : "("LATEST EVENTS RESPONSE : ") + GameEventsManager.lastEventsResponse;
            UnityEngine.Debug.LogWarning(message:  val_16);
        }
        
        this.synching = false;
        if(data == null)
        {
                return;
        }
        
        val_20 = 1152921510222861648;
        if((data.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        object val_4 = data.Item["success"];
        if(null == null)
        {
                return;
        }
        
        val_15 = "game_events";
        if((data.ContainsKey(key:  "game_events")) == false)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "srv_time")) != false)
        {
                decimal val_8 = System.Decimal.Parse(s:  data.Item["srv_time"]);
            System.DateTime val_9 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid});
            val_21 = val_9.dateData;
            System.DateTime val_10 = System.DateTime.UtcNow;
            System.TimeSpan val_11 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_21}, d2:  new System.DateTime() {dateData = val_10.dateData});
            this._serverOffsetTime = val_11;
        }
        
        if(data.Item["game_events"] == null)
        {
            goto label_29;
        }
        
        val_20 = null;
        val_22 = X0;
        if(X0 == true)
        {
            goto label_30;
        }
        
        return;
        label_29:
        val_22 = 0;
        label_30:
        this.loadDescs(descs:  val_22);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventDataReceived");
    }
    public void GetCustomData(int eventId, string urlSubPath, System.Collections.Generic.Dictionary<string, object> data, System.Action<System.Collections.Generic.Dictionary<string, object>> onResponse)
    {
        var val_7;
        .onResponse = onResponse;
        if((System.String.IsNullOrEmpty(value:  urlSubPath)) != false)
        {
                string val_3 = System.String.Format(format:  "{0}/{1}", arg0:  "/api/game_events", arg1:  eventId);
        }
        
        val_7 = null;
        val_7 = null;
        App.networkManager.DoGet(path:  System.String.Format(format:  "{0}/{1}/{2}", arg0:  "/api/game_events", arg1:  eventId, arg2:  urlSubPath), onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new GameEventsManager.<>c__DisplayClass43_0(), method:  System.Void GameEventsManager.<>c__DisplayClass43_0::<GetCustomData>b__0(string method, System.Collections.Generic.Dictionary<string, object> responseData)), destroy:  false, immediate:  false, getParams:  data, timeout:  20);
    }
    public void PostCustomData(int eventId, string urlSubPath, System.Collections.Generic.Dictionary<string, object> data, System.Action<System.Collections.Generic.Dictionary<string, object>> onResponse)
    {
        var val_7;
        .onResponse = onResponse;
        if((System.String.IsNullOrEmpty(value:  urlSubPath)) != false)
        {
                string val_3 = System.String.Format(format:  "{0}/{1}", arg0:  "/api/game_events", arg1:  eventId);
        }
        
        val_7 = null;
        val_7 = null;
        App.networkManager.DoPost(path:  System.String.Format(format:  "{0}/{1}/{2}", arg0:  "/api/game_events", arg1:  eventId, arg2:  urlSubPath), postBody:  data, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new GameEventsManager.<>c__DisplayClass44_0(), method:  System.Void GameEventsManager.<>c__DisplayClass44_0::<PostCustomData>b__0(string method, System.Collections.Generic.Dictionary<string, object> responseData)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    public void PutUpdate(int eventID, System.Collections.Generic.Dictionary<string, object> data)
    {
        this.syncEvent(eventId:  eventID, data:  data, POST:  false);
    }
    private void syncEvent(int eventId, System.Collections.Generic.Dictionary<string, object> data, bool POST = False)
    {
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_7;
        var val_8;
        twelvegigs.net.JsonApiRequester val_9;
        var val_10;
        data.Add(key:  "p", value:  "a");
        data.Add(key:  "v", value:  data.VersionString);
        data.Add(key:  "client_version", value:  DeviceIdPlugin.GetClientVersion());
        val_7 = 1152921504884269056;
        Player val_3 = App.Player;
        data.Add(key:  "user_id", value:  val_3.id);
        if(POST != false)
        {
                val_8 = null;
            val_8 = null;
            val_9 = App.networkManager;
            val_9.DoPost(path:  "/api/game_events", postBody:  data, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void GameEventsManager::putResponse(string method, System.Collections.Generic.Dictionary<string, object> data)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
            return;
        }
        
        val_10 = null;
        val_10 = null;
        val_9 = System.String.Format(format:  "{0}/{1}", arg0:  "/api/game_events", arg1:  eventId);
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_6 = null;
        val_7 = val_6;
        val_6 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void GameEventsManager::putResponse(string method, System.Collections.Generic.Dictionary<string, object> data));
        App.networkManager.DoPut(path:  val_9, postBody:  data, onCompleteFunction:  val_6, timeout:  20, destroy:  false, immediate:  false);
    }
    private void putResponse(string method, System.Collections.Generic.Dictionary<string, object> data)
    {
        object val_8;
        var val_9;
        val_8 = 1152921504884002816;
        val_9 = null;
        val_9 = null;
        if(Logger.GameEvents != false)
        {
                val_8 = "EVENT PUT RESPONSE : "("EVENT PUT RESPONSE : ") + PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  data, types:  false, singleLineOutput:  false));
            UnityEngine.Debug.LogWarning(message:  val_8);
        }
        
        this.synching = false;
        if(data == null)
        {
                return;
        }
        
        val_8 = 1152921510222861648;
        if((data.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        object val_4 = data.Item["success"];
        if(null == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "id")) != false)
        {
                this.updateDesc(desc:  data);
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnGameEventDataPutResponse", aData:  new System.Collections.Hashtable(d:  data));
    }
    private void storeData()
    {
        string val_8;
        object val_9;
        var val_10;
        val_8 = this;
        if(this.initialized == false)
        {
                return;
        }
        
        if((this.<cheating>k__BackingField) == true)
        {
                return;
        }
        
        System.Collections.Generic.List<System.Object> val_1 = new System.Collections.Generic.List<System.Object>();
        List.Enumerator<T> val_2 = this.eventList.GetEnumerator();
        label_7:
        val_9 = public System.Boolean List.Enumerator<GameEventV2>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_10 = 0;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_9 = val_10.Serialize();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_9);
        goto label_7;
        label_4:
        0.Dispose();
        UnityEngine.PlayerPrefs.SetString(key:  this.prefkey, value:  MiniJSON.Json.Serialize(obj:  val_1));
        val_8 = this.timeCheatStampKey;
        System.DateTime val_6 = DateTimeCheat.UtcNow;
        UnityEngine.PlayerPrefs.SetString(key:  val_8, value:  val_6.dateData.ToString());
    }
    private void loadDescs(System.Collections.IList descs)
    {
        var val_5;
        var val_7;
        System.Collections.IDictionary val_10;
        var val_11;
        val_5 = this;
        if(descs == null)
        {
                throw new NullReferenceException();
        }
        
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = descs.GetEnumerator();
        label_19:
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_7.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        if(val_7.Current == null)
        {
            goto label_16;
        }
        
        val_10 = X0;
        if(val_10 == true)
        {
            goto label_17;
        }
        
        throw new NullReferenceException();
        label_16:
        val_10 = 0;
        label_17:
        this.updateDesc(desc:  val_10);
        goto label_19;
        label_11:
        val_5 = 0;
        if(X0 == false)
        {
            goto label_20;
        }
        
        var val_12 = X0;
        val_7 = X0;
        if((X0 + 294) == 0)
        {
            goto label_24;
        }
        
        var val_10 = X0 + 176;
        var val_11 = 0;
        val_10 = val_10 + 8;
        label_23:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_22;
        }
        
        val_11 = val_11 + 1;
        val_10 = val_10 + 16;
        if(val_11 < (X0 + 294))
        {
            goto label_23;
        }
        
        goto label_24;
        label_22:
        val_12 = val_12 + (((X0 + 176 + 8)) << 4);
        val_11 = val_12 + 304;
        label_24:
        val_7.Dispose();
        label_20:
        if(val_5 != 0)
        {
                throw val_5;
        }
    
    }
    private void updateDesc(System.Collections.IDictionary desc)
    {
        System.Collections.IDictionary val_6;
        System.Collections.Generic.List<GameEventV2> val_7;
        GameEventV2 val_1 = new GameEventV2();
        val_6 = desc;
        val_1.init(desc:  val_6);
        val_7 = this.eventList;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = val_7.GetEnumerator();
        label_5:
        val_6 = public System.Boolean List.Enumerator<GameEventV2>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(4194311 != (GameEventV2)[1152921516264972560].id)
        {
            goto label_5;
        }
        
        0.Dispose();
        0.update(data:  desc);
        return;
        label_3:
        val_6 = public System.Void List.Enumerator<GameEventV2>::Dispose();
        0.Dispose();
        val_7 = this.eventList;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.Add(item:  val_1);
    }
    public GameEventsManager()
    {
        this.prefkey = "GameEventsDataV2";
        this.timeCheatStampKey = "GameEventsTimeCheat";
        System.TimeSpan val_1 = new System.TimeSpan(hours:  0, minutes:  0, seconds:  0);
        this.timeToUpdate = 1f;
        this._serverOffsetTime = val_1._ticks;
        this.eventList = new System.Collections.Generic.List<GameEventV2>();
    }
    private static GameEventsManager()
    {
        var val_1;
        GameEventsManager.lastEventsResponse = "no response ever";
        val_1 = null;
        val_1 = null;
        GameEventsManager.lastServerUpdate = System.DateTime.MinValue;
        GameEventsManager.secondsToLastUpdate = 20;
    }

}
