using UnityEngine;
public class IslandParadiseEventHandler.IslandParadiseProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_ISLANDPARADISE_PROG = "evt_islandparadise_prg";
    public int eventId;
    public int eventTimestamp;
    public int rewardProgressLevel;
    public int pointsCollected;
    public bool hasSeenPopup;
    
    // Methods
    public IslandParadiseEventHandler.IslandParadiseProgress()
    {
    
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_islandparadise_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        IslandParadiseProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<IslandParadiseProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
        this.rewardProgressLevel = val_3.rewardProgressLevel;
        this.pointsCollected = val_3.pointsCollected;
        this.hasSeenPopup = val_3.hasSeenPopup;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_islandparadise_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_islandparadise_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_islandparadise_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
