using UnityEngine;
public class TRVQotdStatus : EventProgression
{
    // Fields
    private const string PREF_TRV_QOTD_STATUS = "trv_qotd_status";
    private const string KEY_LAST_FINISHED_TIME = "last_finished_time";
    private const string KEY_LAST_LPN_SETUP_TIME = "last_lpn_setup_time";
    private bool playing;
    public System.DateTime LastFinishedTime;
    
    // Properties
    public bool IsPlaying { get; set; }
    
    // Methods
    public bool get_IsPlaying()
    {
        return (bool)this.playing;
    }
    public void set_IsPlaying(bool value)
    {
        this.playing = value;
    }
    public override void LoadFromJSON()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "trv_qotd_status")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "trv_qotd_status"));
        if((val_3.ContainsKey(key:  "last_finished_time")) == false)
        {
                return;
        }
        
        bool val_6 = System.DateTime.TryParse(s:  val_3.Item["last_finished_time"], result: out  new System.DateTime() {dateData = this.LastFinishedTime});
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "last_finished_time", value:  this.LastFinishedTime.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "trv_qotd_status", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public TRVQotdStatus()
    {
    
    }

}
