using UnityEngine;
public class PiggyBankRaidProgress : EventProgression
{
    // Fields
    protected const string PREF_KEY_PIGGYBANKRAID_PROG = "piggybankraid_prg";
    public int eventId;
    public int eventTimestamp;
    public bool isMaxPiggyPurchased;
    public PiggyBankRaidPlayerProfile player;
    public int currentAssociatedLevel;
    public int currentLineWord;
    public int alternateLineWord;
    public int currentCell;
    public System.Collections.Generic.List<PiggyBankRaidNewsArticle> raidNewsList;
    
    // Methods
    public PiggyBankRaidProgress()
    {
        this.currentAssociatedLevel = 0;
        this.currentLineWord = 0;
        this.alternateLineWord = 0;
        this.currentCell = 0;
        this.player = new PiggyBankRaidPlayerProfile();
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "piggybankraid_prg", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        PiggyBankRaidProgress val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<PiggyBankRaidProgress>(value:  val_1);
        this.eventId = val_3.eventId;
        this.eventTimestamp = val_3.eventTimestamp;
        this.isMaxPiggyPurchased = val_3.isMaxPiggyPurchased;
        this.player = val_3.player;
        this.currentAssociatedLevel = val_3.currentAssociatedLevel;
        this.currentLineWord = val_3.currentLineWord;
        this.currentCell = val_3.currentCell;
        this.raidNewsList = val_3.raidNewsList;
    }
    public override void SaveToJSON()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "piggybankraid_prg", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "piggybankraid_prg")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "piggybankraid_prg");
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
