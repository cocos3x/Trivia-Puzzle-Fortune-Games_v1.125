using UnityEngine;
public class LightningLevelsEventPrgress : LightingEventProgress
{
    // Fields
    private const string key_current_interval = "current_interval";
    private const string key_defined_interval = "defined_interval";
    public int CurrentInterval;
    public int DefinedInterval;
    
    // Properties
    protected override string pref_event_prg { get; }
    
    // Methods
    protected override string get_pref_event_prg()
    {
        return "ll_evt_prg";
    }
    public LightningLevelsEventPrgress()
    {
        mem[1152921516503001456] = 1;
        mem[1152921516503001460] = 0;
        mem[1152921516503001464] = 0;
        mem[1152921516503001468] = ;
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  this, defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
        if((val_3.ContainsKey(key:  "is_ftux")) != false)
        {
                mem[1152921516503150864] = System.Boolean.Parse(value:  val_3.Item["is_ftux"]);
        }
        
        if((val_3.ContainsKey(key:  "completed_levels")) != false)
        {
                mem[1152921516503150868] = System.Int32.Parse(s:  val_3.Item["completed_levels"]);
        }
        
        if((val_3.ContainsKey(key:  "rewarded")) != false)
        {
                mem[1152921516503150872] = System.Boolean.Parse(value:  val_3.Item["rewarded"]);
        }
        
        if((val_3.ContainsKey(key:  "last_prg_timestamp")) != false)
        {
                mem[1152921516503150876] = System.Int32.Parse(s:  val_3.Item["last_prg_timestamp"]);
        }
        
        if((val_3.ContainsKey(key:  "timestamp")) != false)
        {
                mem[1152921516503150880] = System.Int32.Parse(s:  val_3.Item["timestamp"]);
        }
        
        if((val_3.ContainsKey(key:  "current_interval")) != false)
        {
                this.CurrentInterval = System.Int32.Parse(s:  val_3.Item["current_interval"]);
        }
        
        if((val_3.ContainsKey(key:  "defined_interval")) == false)
        {
                return;
        }
        
        this.DefinedInterval = System.Int32.Parse(s:  val_3.Item["defined_interval"]);
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "is_ftux", value:  1152921510196879024);
        val_1.Add(key:  "completed_levels", value:  "is_ftux");
        val_1.Add(key:  "rewarded", value:  "completed_levels");
        val_1.Add(key:  "last_prg_timestamp", value:  "rewarded");
        val_1.Add(key:  "timestamp", value:  "last_prg_timestamp");
        val_1.Add(key:  "current_interval", value:  this.CurrentInterval);
        val_1.Add(key:  "defined_interval", value:  this.DefinedInterval);
        UnityEngine.PlayerPrefs.SetString(key:  this, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        this.DeleteKey(key:  this);
    }

}
