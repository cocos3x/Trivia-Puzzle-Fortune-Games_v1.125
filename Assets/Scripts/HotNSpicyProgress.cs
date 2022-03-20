using UnityEngine;
public class HotNSpicyProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_HOTNSPICY_PROG = "evt_hotnspicy_prg";
    public int eventId;
    public int eventTimestamp;
    public int playerTierAtEventStart;
    public int rewardProgressLevel;
    public int pointsCollected;
    public RESEventRewardData currentRewardData;
    public int totalPointsCollected;
    public int totalSpinResourceSpent;
    public float prevAvgPointPerSpin;
    public bool hasSeenPopup;
    
    // Properties
    public float AveragePointPerSpin { get; }
    
    // Methods
    public float get_AveragePointPerSpin()
    {
        float val_1 = (float)this.totalPointsCollected;
        val_1 = val_1 / (float)this.totalSpinResourceSpent;
        return (float)val_1;
    }
    public HotNSpicyProgress()
    {
        this.playerTierAtEventStart = 0;
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_hotnspicy_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        HotNSpicyProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<HotNSpicyProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
        this.playerTierAtEventStart = val_3.playerTierAtEventStart;
        this.rewardProgressLevel = val_3.rewardProgressLevel;
        this.pointsCollected = val_3.pointsCollected;
        this.currentRewardData = val_3.currentRewardData;
        this.totalPointsCollected = val_3.totalPointsCollected;
        this.totalSpinResourceSpent = val_3.totalSpinResourceSpent;
        this.prevAvgPointPerSpin = val_3.prevAvgPointPerSpin;
        this.hasSeenPopup = val_3.hasSeenPopup;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_hotnspicy_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_hotnspicy_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_hotnspicy_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
