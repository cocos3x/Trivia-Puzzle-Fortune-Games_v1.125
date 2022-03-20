using UnityEngine;
public class OnTheTrailEventProgress : EventProgression
{
    // Fields
    private const string PREF_EVENT_PROG = "ott_evt_prg";
    private const string KEY_IS_WAGON_BROKEN = "is_wagon_broken";
    private const string KEY_DAYS_REWARDED = "days_rewarded";
    private const string KEY_SAVED_DAY_PROGRESS = "saved_day_progress";
    private const string KEY_TIMESTAMP = "timestamp";
    private const string KEY_LAST_PROG_TIMESTAMP = "last_prog_timestamp";
    private const string KEY_IS_FTUX_SEEN = "is_ftux_seen";
    private const string KEY_IS_INITIALIZED = "is_initialized";
    public bool IsWagonBroken;
    public System.Collections.Generic.List<bool> DaysRewarded;
    public OnTheTrailDayProgress SavedDayProgress;
    public OnTheTrailDayProgress WagonBrokenDayProgress;
    public int Timestamp;
    public int LastProgressTimestamp;
    public bool IsFtuxSeen;
    public bool IsInitialized;
    public bool IsEventCompleted;
    
    // Methods
    public OnTheTrailEventProgress()
    {
        this.IsWagonBroken = false;
        this.DaysRewarded = new System.Collections.Generic.List<System.Boolean>(collection:  new bool[5]);
        this.SavedDayProgress = new OnTheTrailDayProgress();
        this.IsEventCompleted = false;
        this.IsFtuxSeen = false;
        this.IsInitialized = false;
        this.WagonBrokenDayProgress = new OnTheTrailDayProgress();
        this.Timestamp = 0;
        this.LastProgressTimestamp = 0;
    }
    public override void LoadFromJSON()
    {
        bool val_14;
        var val_15;
        var val_36;
        bool val_37;
        var val_38;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "ott_evt_prg", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
        if((val_3.ContainsKey(key:  "is_wagon_broken")) != false)
        {
                this.IsWagonBroken = System.Boolean.Parse(value:  val_3.Item["is_wagon_broken"]);
        }
        
        if((val_3.ContainsKey(key:  "days_rewarded")) == false)
        {
            goto label_42;
        }
        
        object val_10 = MiniJSON.Json.Deserialize(json:  val_3.Item["days_rewarded"]);
        this.DaysRewarded = new System.Collections.Generic.List<System.Boolean>();
        List.Enumerator<T> val_13 = GetEnumerator();
        label_20:
        val_36 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_15.MoveNext() == false)
        {
            goto label_16;
        }
        
        if(this.DaysRewarded == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = val_14;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_36 = null;
        this.DaysRewarded.Add(item:  val_37);
        goto label_20;
        label_16:
        val_15.Dispose();
        label_42:
        if((val_3.ContainsKey(key:  "timestamp")) != false)
        {
                this.Timestamp = System.Int32.Parse(s:  val_3.Item["timestamp"]);
        }
        
        if((val_3.ContainsKey(key:  "last_prog_timestamp")) != false)
        {
                this.LastProgressTimestamp = System.Int32.Parse(s:  val_3.Item["last_prog_timestamp"]);
        }
        
        if((val_3.ContainsKey(key:  "saved_day_progress")) != false)
        {
                object val_25 = MiniJSON.Json.Deserialize(json:  val_3.Item["saved_day_progress"]);
            val_38 = 0;
            this.SavedDayProgress.FromJSON(json:  null);
        }
        
        if((val_3.ContainsKey(key:  "is_ftux_seen")) != false)
        {
                this.IsFtuxSeen = System.Boolean.Parse(value:  val_3.Item["is_ftux_seen"]);
        }
        
        if((val_3.ContainsKey(key:  "is_initialized")) == false)
        {
                return;
        }
        
        this.IsInitialized = System.Boolean.Parse(value:  val_3.Item["is_initialized"]);
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "is_wagon_broken", value:  this.IsWagonBroken);
        val_1.Add(key:  "days_rewarded", value:  MiniJSON.Json.Serialize(obj:  this.DaysRewarded));
        val_1.Add(key:  "saved_day_progress", value:  MiniJSON.Json.Serialize(obj:  this.SavedDayProgress.ToJSON()));
        val_1.Add(key:  "timestamp", value:  this.Timestamp);
        val_1.Add(key:  "last_prog_timestamp", value:  this.LastProgressTimestamp);
        val_1.Add(key:  "is_ftux_seen", value:  this.IsFtuxSeen);
        val_1.Add(key:  "is_initialized", value:  this.IsInitialized);
        UnityEngine.PlayerPrefs.SetString(key:  "ott_evt_prg", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_6 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        this.DeleteKey(key:  "ott_evt_prg");
    }

}
