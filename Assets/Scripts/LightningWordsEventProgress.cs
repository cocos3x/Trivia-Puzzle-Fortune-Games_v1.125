using UnityEngine;
public class LightningWordsEventProgress : LightningWordsProgress
{
    // Fields
    private const string pref_lw_timestamp = "lw_timestamp";
    private const string pref_lw_ftux = "lw_ftux";
    private const string pref_lw_missed_lvl = "lw_missed_lvl";
    private const string pref_lw_rewarded = "lw_rewarded";
    private const string pref_lw_last_progress = "lw_last_progress";
    public int timestamp;
    public int missedLevels;
    public bool isFTUX;
    public bool rewarded;
    public bool resetLevelProgress;
    public bool isLightningWordJustFound;
    public int lastProgressTimestamp;
    
    // Properties
    protected override string pref_lw_progress { get; }
    
    // Methods
    protected override string get_pref_lw_progress()
    {
        return "lw_event_progress";
    }
    public LightningWordsEventProgress()
    {
        val_1 = new System.Object();
        this.missedLevels = 0;
        mem[1152921517598955184] = 0;
        mem[1152921517598955203] = 0;
        mem[1152921517598955201] = 0;
        this.isFTUX = true;
        this.rewarded = false;
        this.resetLevelProgress = false;
        this.isLightningWordJustFound = false;
        this.lastProgressTimestamp = 0;
    }
    public override void Load()
    {
        this.timestamp = UnityEngine.PlayerPrefs.GetInt(key:  "lw_timestamp", defaultValue:  0);
        mem[1152921517599067680] = UnityEngine.PlayerPrefs.GetInt(key:  this, defaultValue:  0);
        this.missedLevels = UnityEngine.PlayerPrefs.GetInt(key:  "lw_missed_lvl", defaultValue:  0);
        this.isFTUX = ((UnityEngine.PlayerPrefs.GetInt(key:  "lw_ftux", defaultValue:  1)) == 1) ? 1 : 0;
        this.rewarded = ((UnityEngine.PlayerPrefs.GetInt(key:  "lw_rewarded", defaultValue:  0)) == 1) ? 1 : 0;
        this.lastProgressTimestamp = UnityEngine.PlayerPrefs.GetInt(key:  "lw_last_progress", defaultValue:  0);
    }
    public override void Save()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_timestamp", value:  this.timestamp);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_missed_lvl", value:  this.missedLevels);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_ftux", value:  this.isFTUX);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_rewarded", value:  this.rewarded);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_last_progress", value:  this.lastProgressTimestamp);
        this.Save();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_timestamp")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_timestamp");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_ftux")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_ftux");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_missed_lvl")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_missed_lvl");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_rewarded")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_rewarded");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_last_progress")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_last_progress");
        }
        
        this.Delete();
    }

}
