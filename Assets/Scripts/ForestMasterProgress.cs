using UnityEngine;
public class ForestMasterProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_FORMAS_PROG = "evt_formas_prg";
    public int eventId;
    public int eventTimestamp;
    public bool hasSeenPopup;
    
    // Methods
    public ForestMasterProgress()
    {
    
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_formas_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        ForestMasterProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<ForestMasterProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
        this.hasSeenPopup = val_3.hasSeenPopup;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_formas_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_formas_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_formas_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
