using UnityEngine;
public class StarChampionshipEventProgress : TRVEventProgression
{
    // Fields
    private const string KEY_STARS = "stars";
    private const string KEY_REWARDED = "rewarded";
    public int Stars;
    public bool Rewarded;
    
    // Properties
    protected override string PREF_EVENT_PROG { get; }
    
    // Methods
    protected override string get_PREF_EVENT_PROG()
    {
        return "star_champ_evt_prg";
    }
    public override void LoadFromJSON()
    {
        string val_29;
        string val_30;
        if((UnityEngine.PlayerPrefs.HasKey(key:  this)) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this));
        val_29 = "eventID";
        val_30 = "eventID";
        if((val_3.ContainsKey(key:  val_30)) == false)
        {
            goto label_5;
        }
        
        val_29 = val_3.Item["eventID"];
        val_30 = (TRVStarChampionshipEventHandler.<Instance>k__BackingField + 16) + 56.ToString();
        if((System.String.op_Inequality(a:  val_29, b:  val_30)) == false)
        {
            goto label_10;
        }
        
        label_5:
        UnityEngine.PlayerPrefs.DeleteKey(key:  this);
        return;
        label_10:
        if((val_3.ContainsKey(key:  "timestamp")) != false)
        {
                bool val_12 = System.Int32.TryParse(s:  val_3.Item["timestamp"], result: out  1152921517392856032);
        }
        
        if((val_3.ContainsKey(key:  "last_prog_timestamp")) != false)
        {
                bool val_16 = System.Int32.TryParse(s:  val_3.Item["last_prog_timestamp"], result: out  1152921517392856036);
        }
        
        if((val_3.ContainsKey(key:  "stars")) != false)
        {
                bool val_20 = System.Int32.TryParse(s:  val_3.Item["stars"], result: out  this.Stars);
        }
        
        if((val_3.ContainsKey(key:  "rewarded")) != false)
        {
                bool val_24 = System.Boolean.TryParse(value:  val_3.Item["rewarded"], result: out  this.Rewarded);
        }
        
        if((val_3.ContainsKey(key:  "isEventShown")) == false)
        {
                return;
        }
        
        bool val_28 = System.Boolean.TryParse(value:  val_3.Item["isEventShown"], result: out  1152921517392856040);
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "timestamp", value:  1152921510196879024);
        val_1.Add(key:  "last_prog_timestamp", value:  "timestamp");
        val_1.Add(key:  "stars", value:  this.Stars);
        val_1.Add(key:  "rewarded", value:  this.Rewarded);
        val_1.Add(key:  "isEventShown", value:  "rewarded");
        val_1.Add(key:  "eventID", value:  TRVStarChampionshipEventHandler.<Instance>k__BackingField + 16 + 56);
        UnityEngine.PlayerPrefs.SetString(key:  this, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  this)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  this);
    }
    public StarChampionshipEventProgress()
    {
    
    }

}
