using UnityEngine;
public class FOMOPackProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_FOMO_PROG = "evt_fomo_prg";
    public int eventId;
    public int ShowedLevel;
    public string LastShownAt;
    
    // Methods
    public FOMOPackProgress()
    {
        this.ShowedLevel = 0;
        this.LastShownAt = "";
        this = new System.Object();
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_fomo_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        FOMOPackProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<FOMOPackProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.ShowedLevel = val_3.ShowedLevel;
        this.LastShownAt = val_3.LastShownAt;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_fomo_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_fomo_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_fomo_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
