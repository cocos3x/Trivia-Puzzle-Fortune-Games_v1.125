using UnityEngine;
public class RaidMadnessProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_RAIDMAD_PROG = "evt_raidmad_prg";
    public int eventId;
    public int eventTimestamp;
    public int playerTierAtEventStart;
    public int rewardProgressLevel;
    public int pointsCollected;
    public RESEventRewardData currentRewardData;
    public System.Collections.Generic.Dictionary<GameplayMode, int> pointsCollectedDuringGameLevel;
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
    public RaidMadnessProgress()
    {
        this.playerTierAtEventStart = 1;
        this.pointsCollectedDuringGameLevel = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
        this.pointsCollectedDuringGameLevel = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "evt_raidmad_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        RaidMadnessProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<RaidMadnessProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
        this.playerTierAtEventStart = val_3.playerTierAtEventStart;
        this.rewardProgressLevel = val_3.rewardProgressLevel;
        this.pointsCollected = val_3.pointsCollected;
        this.currentRewardData = val_3.currentRewardData;
        this.pointsCollectedDuringGameLevel = val_3.pointsCollectedDuringGameLevel;
        if(val_3.pointsCollectedDuringGameLevel == null)
        {
                this.pointsCollectedDuringGameLevel = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
        }
        
        this.totalPointsCollected = val_3.totalPointsCollected;
        this.totalSpinResourceSpent = val_3.totalSpinResourceSpent;
        this.prevAvgPointPerSpin = val_3.prevAvgPointPerSpin;
        this.hasSeenPopup = val_3.hasSeenPopup;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "evt_raidmad_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "evt_raidmad_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "evt_raidmad_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
