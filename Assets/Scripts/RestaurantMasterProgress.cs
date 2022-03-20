using UnityEngine;
public class RestaurantMasterProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_RESMAS_PROG = "evt_resmas_prg";
    public int eventId;
    public int eventTimestamp;
    
    // Methods
    public RestaurantMasterProgress()
    {
    
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_resmas_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        RestaurantMasterProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<RestaurantMasterProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_resmas_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_resmas_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_resmas_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
