using UnityEngine;
public class WGTimelineTracker : MonoBehaviour
{
    // Fields
    protected const string timelineKey = "level_gen_timeline";
    protected const string startStampKey = "level_gen_start_stamp";
    protected const string versionKey = "level_gen_version";
    protected bool enabled;
    private System.DateTime <startStamp>k__BackingField;
    protected System.DateTime previousEventAt;
    protected System.Collections.Generic.List<TimelineEvent> timeline;
    protected string levelWord;
    protected string levelWords;
    protected string currentLanguage;
    protected string deviceId;
    protected MainController.GameModeForTracking currentGameMode;
    protected twelvegigs.net.JsonApiRequester apiRequester;
    private string levelGenerationUrl;
    private string railsGameName;
    private static WGTimelineTracker _instance;
    
    // Properties
    public static bool IsLoaded { get; }
    public System.DateTime startStamp { get; set; }
    protected virtual int LevelGenerationVersion { get; }
    public string LevelGenerationUrl { get; }
    public string RailsGameName { get; }
    public static WGTimelineTracker Instance { get; }
    
    // Methods
    public static bool get_IsLoaded()
    {
        return false;
    }
    public System.DateTime get_startStamp()
    {
        return (System.DateTime)this.<startStamp>k__BackingField;
    }
    protected void set_startStamp(System.DateTime value)
    {
        this.<startStamp>k__BackingField = value;
    }
    protected virtual int get_LevelGenerationVersion()
    {
        return 2;
    }
    private void Start()
    {
        AppConfigs val_1 = App.Configuration;
        this.enabled = val_1.appConfig.uploadLevelGenerationStatistics;
        this.apiRequester = new twelvegigs.net.JsonApiRequester(ServerURL:  this.LevelGenerationUrl, dequeueHandler:  new System.Action(object:  this, method:  System.Void WGTimelineTracker::<Start>b__20_0()), logStuff:  false, adminServerURL:  0, throwExceptionsOnRequestFailures:  false);
        this.deviceId = DeviceIdPlugin.GetDeviceId();
        this.LoadData();
    }
    public virtual void LevelStarted(string levelword, string levelWords, MainController.GameModeForTracking gameMode, string levelLanguage)
    {
        System.DateTime val_1 = System.DateTime.Now;
        this.<startStamp>k__BackingField = val_1;
        this.levelWord = levelword;
        this.levelWords = levelWords;
        this.currentGameMode = gameMode;
        this.currentLanguage = levelLanguage;
    }
    public virtual void WordSpelled(string word)
    {
        bool val_2 = this.levelWord.Equals(value:  word);
    }
    public virtual void ExtraWordSpelled(string word)
    {
    
    }
    public virtual void LevelCompleted()
    {
    
    }
    public virtual void HintUsed()
    {
    
    }
    protected virtual void SetDropoff()
    {
    
    }
    protected virtual void AddEvent(TimelineEvent te)
    {
        if(this.enabled == false)
        {
                return;
        }
        
        this.timeline.Add(item:  new TimelineEvent() {type = te.type, gameMode = te.type, word = te.word, levelWord = te.word, levelWords = te.levelWords, language = te.levelWords, stamp = te.stamp, isLevelWord = ???});
        System.DateTime val_1 = System.DateTime.Now;
        this.previousEventAt = val_1;
        this.Flush();
    }
    protected virtual TimelineEvent CreateEvent(TimelineEvent.Type t, string w, bool isLevelWord = False)
    {
        double val_9;
        TimelineEvent val_0;
        System.DateTime val_2 = System.DateTime.Now;
        System.TimeSpan val_3 = val_2.dateData.Subtract(value:  new System.DateTime() {dateData = this.<startStamp>k__BackingField});
        double val_4 = val_3._ticks.TotalMilliseconds;
        val_4 = (val_4 == Infinity) ? (-val_4) : (val_4);
        val_9 = 0;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.previousEventAt}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                System.DateTime val_6 = System.DateTime.Now;
            System.TimeSpan val_7 = val_6.dateData.Subtract(value:  new System.DateTime() {dateData = this.previousEventAt});
            double val_8 = val_7._ticks.TotalMilliseconds;
            val_8 = (val_8 == Infinity) ? (-val_8) : (val_8);
            val_9 = (double)(int)val_8;
        }
        
        val_0.type = t;
        mem[1152921517994291284] = this.currentGameMode;
        val_0.gameMode = w;
        val_0.word = this.levelWord;
        val_0.levelWords = this.currentLanguage;
        val_0.language = (double)(int)val_4;
        val_0.stamp = val_9;
        val_0.delta = isLevelWord;
        mem[1152921517994291343] = 0;
        mem[1152921517994291341] = 0;
        mem[1152921517994291337] = 0;
        return val_0;
    }
    protected bool ShouldFlush()
    {
        return (bool)(this.timeline > 0) ? 1 : 0;
    }
    protected void Flush()
    {
        if(this.ShouldFlush() == false)
        {
                return;
        }
        
        label_4:
        if(true <= 0)
        {
            goto label_3;
        }
        
        this.timeline.RemoveAt(index:  0);
        if(this.timeline != null)
        {
            goto label_4;
        }
        
        throw new NullReferenceException();
        label_3:
        this.SaveData();
    }
    protected virtual void Track(TimelineEvent te)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "l_index", value:  App.Player);
        val_1.Add(key:  "l_word", value:  te.word);
        val_1.Add(key:  "l_words", value:  te.levelWord);
        val_1.Add(key:  "t_seconds", value:  te.language);
        val_1.Add(key:  "is_level_word", value:  (te.delta != 0) ? 1 : 0);
        if(te.stamp != 0f)
        {
                val_1.set_Item(key:  "seconds", value:  te.stamp);
        }
        
        if((System.String.IsNullOrEmpty(value:  te.gameMode)) != true)
        {
                val_1.set_Item(key:  "word", value:  te.gameMode);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "version", value:  this);
        val_5.Add(key:  "game", value:  this.RailsGameName);
        val_5.Add(key:  "date", value:  ServerHandler.UnixServerTime);
        val_5.Add(key:  "user", value:  this.deviceId);
        val_5.Add(key:  "game_mode", value:  268435459);
        te.type = null;
        val_5.Add(key:  "type", value:  te.type.ToString());
        val_5.Add(key:  "lang", value:  te.levelWords);
        val_5.Add(key:  "event_data", value:  val_1);
        this.apiRequester.DoPut(path:  System.String.alignConst, postBody:  val_5, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false);
    }
    private void LoadData()
    {
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        val_13 = 0;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "level_gen_version")) != false)
        {
                val_13 = 0;
            val_14 = UnityEngine.PlayerPrefs.GetInt(key:  "level_gen_version");
        }
        else
        {
                val_14 = 0;
        }
        
        if(val_14 == this)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "level_gen_start_stamp")) != false)
        {
                val_15 = null;
            val_15 = null;
            System.DateTime val_5 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "level_gen_start_stamp"), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            this.<startStamp>k__BackingField = val_5;
        }
        
            if((UnityEngine.PlayerPrefs.HasKey(key:  "level_gen_timeline")) != false)
        {
                this.timeline = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<TimelineEvent>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "level_gen_timeline"));
        }
        
            val_16 = null;
            val_16 = null;
            if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.<startStamp>k__BackingField}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == true)
        {
                return;
        }
        
            System.DateTime val_10 = System.DateTime.Now;
            System.TimeSpan val_11 = val_10.dateData.Subtract(value:  new System.DateTime() {dateData = this.<startStamp>k__BackingField});
            if(val_11._ticks.TotalDays <= 1)
        {
                return;
        }
        
            return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "level_gen_start_stamp");
        UnityEngine.PlayerPrefs.DeleteKey(key:  "level_gen_timeline");
    }
    public void SaveData()
    {
        var val_4;
        System.DateTime val_5;
        if(true >= 1)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "level_gen_timeline", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.timeline));
        }
        
        val_4 = null;
        val_4 = null;
        val_5 = System.DateTime.MinValue;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.<startStamp>k__BackingField}, d2:  new System.DateTime() {dateData = val_5})) != false)
        {
                val_5 = this.<startStamp>k__BackingField.ToString();
            UnityEngine.PlayerPrefs.SetString(key:  "level_gen_start_stamp", value:  val_5);
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "level_gen_version", value:  503357808);
    }
    public string get_LevelGenerationUrl()
    {
        string val_2;
        if((System.String.IsNullOrEmpty(value:  this.levelGenerationUrl)) != false)
        {
                val_2 = "https://level-gen.12gigs.com";
            this.levelGenerationUrl = val_2;
            return val_2;
        }
        
        val_2 = this.levelGenerationUrl;
        return val_2;
    }
    private string GetLevelGenerationUrl()
    {
        return "https://level-gen.12gigs.com";
    }
    public string get_RailsGameName()
    {
        string val_3;
        bool val_1 = System.String.IsNullOrEmpty(value:  this.railsGameName);
        if(val_1 != false)
        {
                this.railsGameName = val_1.GetGameRailsName();
            return val_3;
        }
        
        val_3 = this.railsGameName;
        return val_3;
    }
    private string GetGameRailsName()
    {
        AppConfigs val_1 = App.Configuration;
        return val_1.appConfig.ProductionServerURL.Replace(oldValue:  "-", newValue:  "_").Replace(oldValue:  "https://", newValue:  "").Replace(oldValue:  "_api.12gigs.com", newValue:  "");
    }
    public static WGTimelineTracker get_Instance()
    {
        return (WGTimelineTracker)WGTimelineTracker._instance;
    }
    private void Awake()
    {
        if(WGTimelineTracker._instance != 0)
        {
                UnityEngine.Object.Destroy(obj:  this);
            return;
        }
        
        WGTimelineTracker._instance = this;
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
    }
    public WGTimelineTracker()
    {
        this.timeline = new System.Collections.Generic.List<TimelineEvent>();
        this.levelWord = System.String.alignConst;
        this.levelWords = System.String.alignConst;
        this.currentLanguage = System.String.alignConst;
        this.deviceId = System.String.alignConst;
    }
    private void <Start>b__20_0()
    {
        if(this.apiRequester != null)
        {
                this.apiRequester.Dequeue();
            return;
        }
        
        throw new NullReferenceException();
    }

}
