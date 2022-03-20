using UnityEngine;
public class FPHQotdStatus : EventProgression
{
    // Fields
    private const string PREF_TRV_QOTD_STATUS = "trv_qotd_status";
    private const string KEY_LAST_FINISHED_TIME = "last_finished_time";
    private const string KEY_LAST_LPN_SETUP_TIME = "last_lpn_setup_time";
    private const string LEVEL_DATA = "level_data";
    private const string KEY_PROGRESS = "qotd_prog";
    public bool IsPlaying;
    public System.DateTime LastPlayedTime;
    public System.DateTime LastLPNSetupTime;
    public int qotdProgress;
    public string savedLevelData;
    
    // Methods
    public override void LoadFromJSON()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "trv_qotd_status")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "trv_qotd_status"));
        if(val_3 == null)
        {
                return;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "last_finished_time", value:  this.LastPlayedTime.ToString());
        val_1.Add(key:  "last_lpn_setup_time", value:  this.LastLPNSetupTime.ToString());
        val_1.Add(key:  "level_data", value:  this.savedLevelData);
        val_1.Add(key:  "qotd_prog", value:  this.qotdProgress);
        UnityEngine.PlayerPrefs.SetString(key:  "trv_qotd_status", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public FPHQotdStatus()
    {
    
    }

}
