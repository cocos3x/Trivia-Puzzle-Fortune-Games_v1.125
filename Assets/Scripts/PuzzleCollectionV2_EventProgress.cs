using UnityEngine;
public class PuzzleCollectionV2_EventProgress
{
    // Fields
    private const string pref_pc_last_lvl = "pc_last_lvl";
    private const string pref_pc_lvl_lapsed = "pc_lvl_lapsed";
    private const string pref_pc_lvl_itvl = "pc_lvl_itvl";
    private const string pref_pc_last_mode = "pc_last_mode";
    private const string pref_pc_last_mode_subid = "pc_last_mode_subid";
    public int lastLevel;
    public int levelsLapsed;
    public int levelInterval;
    public GameplayMode lastMode;
    public string lastModeSecondaryId;
    
    // Methods
    public void Load()
    {
        this.lastLevel = UnityEngine.PlayerPrefs.GetInt(key:  "pc_last_lvl", defaultValue:  0);
        this.levelsLapsed = UnityEngine.PlayerPrefs.GetInt(key:  "pc_lvl_lapsed", defaultValue:  0);
        this.levelInterval = UnityEngine.PlayerPrefs.GetInt(key:  "pc_lvl_itvl", defaultValue:  0);
        this.lastMode = UnityEngine.PlayerPrefs.GetInt(key:  "pc_last_mode", defaultValue:  1);
        this.lastModeSecondaryId = UnityEngine.PlayerPrefs.GetString(key:  "pc_last_mode_subid", defaultValue:  0);
    }
    public void Save()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pc_last_lvl", value:  this.lastLevel);
        UnityEngine.PlayerPrefs.SetInt(key:  "pc_lvl_lapsed", value:  this.levelsLapsed);
        UnityEngine.PlayerPrefs.SetInt(key:  "pc_lvl_itvl", value:  this.levelInterval);
        UnityEngine.PlayerPrefs.SetInt(key:  "pc_last_mode", value:  this.lastMode);
        UnityEngine.PlayerPrefs.SetString(key:  "pc_last_mode_subid", value:  this.lastModeSecondaryId);
    }
    public void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pc_last_lvl")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pc_last_lvl");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pc_lvl_lapsed")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pc_lvl_lapsed");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pc_lvl_itvl")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pc_lvl_itvl");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pc_last_mode")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "pc_last_mode");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "pc_last_mode_subid")) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "pc_last_mode_subid");
    }
    protected void DeletePlayerPref(string key)
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  key)) == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  key);
    }
    public PuzzleCollectionV2_EventProgress()
    {
        this.levelsLapsed = 0;
        this.lastMode = 1;
    }

}
