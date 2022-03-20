using UnityEngine;
public class FPHPlayer : Player
{
    // Fields
    private const string PREFKEY_STN_LVL_PLAYED = "fph_stn_lvl_played";
    private const string PREFKEY_STN_LVL_SUCCESS = "fph_stn_lvl_success";
    private const string PREFKEY_TUTORIAL_COMPLETED = "fph_tuts";
    private EasySaver<FPHPlayer> mySaver;
    public int standardLevelsPlayed;
    public int standardLevelsCompleteSuccess;
    public int tutorialCompleted;
    
    // Properties
    public static FPHPlayer Instance { get; }
    public float SuccessPercentageStandardMode { get; }
    public string SuccessPercentageStandardModeString { get; }
    
    // Methods
    public static FPHPlayer get_Instance()
    {
        Player val_1 = App.Player;
        if(val_1 == null)
        {
                return (FPHPlayer)val_1;
        }
        
        return (FPHPlayer)val_1;
    }
    public float get_SuccessPercentageStandardMode()
    {
        float val_1 = (float)this.standardLevelsCompleteSuccess;
        val_1 = val_1 / (float)this.standardLevelsPlayed;
        val_1 = val_1 * 100f;
        return (float)val_1;
    }
    public string get_SuccessPercentageStandardModeString()
    {
        float val_2 = (float)this.standardLevelsCompleteSuccess;
        val_2 = val_2 / (float)this.standardLevelsPlayed;
        val_2 = val_2 * 100f;
        return (string)val_2.ToString(format:  "0.##");
    }
    public override void BuildReflectedLists()
    {
        this.mySaver = new EasySaver<FPHPlayer>(incInstance:  this);
    }
    public override void AddHardSaves(ref System.Collections.Generic.Dictionary<string, object> incDic)
    {
        this.mySaver.AddHardSavesToDictionary(refdic: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = incDic);
    }
    protected override void TrustServerData(System.Collections.IDictionary diff)
    {
        this.TrustServerData(diff:  diff);
    }
    protected override void LoadFromLocal()
    {
        this.LoadFromLocal();
        this.standardLevelsPlayed = UnityEngine.PlayerPrefs.GetInt(key:  "fph_stn_lvl_played", defaultValue:  this.standardLevelsPlayed);
        this.standardLevelsCompleteSuccess = UnityEngine.PlayerPrefs.GetInt(key:  "fph_stn_lvl_success", defaultValue:  this.standardLevelsCompleteSuccess);
        this.tutorialCompleted = UnityEngine.PlayerPrefs.GetInt(key:  "fph_tuts", defaultValue:  this.tutorialCompleted);
    }
    protected override void CreateNewPlayer(string id = " ")
    {
        this.CreateNewPlayer(id:  id);
        GameBehavior val_1 = App.getBehavior;
        mem[1152921515979616992] = val_1.<metaGameBehavior>k__BackingField;
        this.standardLevelsPlayed = 0;
        this.standardLevelsCompleteSuccess = 0;
        this.tutorialCompleted = 0;
    }
    public override void SoftSave()
    {
        this.mySaver.SoftSaveLite();
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected override void Save()
    {
        this.mySaver.SoftSaveFull();
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void TrackLevelCompleteSuccessRate(bool isSuccess)
    {
        int val_1 = this.standardLevelsPlayed;
        val_1 = val_1 + 1;
        this.standardLevelsPlayed = val_1;
        if(isSuccess == false)
        {
                return;
        }
        
        int val_2 = this.standardLevelsCompleteSuccess;
        val_2 = val_2 + 1;
        this.standardLevelsCompleteSuccess = val_2;
    }
    public FPHPlayer()
    {
    
    }

}
