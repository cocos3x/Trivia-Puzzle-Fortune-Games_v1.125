using UnityEngine;
public class LightningWordsLevelProgress : LightningWordsProgress
{
    // Fields
    private const string pref_lw_word = "lw_lvl_wd";
    private const string pref_lw_word_idx = "lw_lvl_wd_idx";
    private const string pref_lw_time_left = "lw_lvl_time_left";
    private const string pref_lw_paused = "lw_lvl_psd";
    private const string pref_lw_first_wd_time_left = "lw_lvl_first_wd_time_left";
    private const string pref_lw_is_coin_spent = "lw_lvl_coin_spent";
    private const string pref_lw_mode = "lw_lvl_mode";
    private const string pref_lw_mode_sub = "lw_lvl_mode_sub";
    public string currentLightningWord;
    public int currentLightningWordIndex;
    public System.DateTime lightningEndTime;
    public int lightningRemainingTime;
    public GameplayMode currentMode;
    public string currentModeSecondaryId;
    public bool paused;
    public int firstLightningWordTimeRemaining;
    public bool isCoinSpent;
    
    // Properties
    protected override string pref_lw_progress { get; }
    
    // Methods
    protected override string get_pref_lw_progress()
    {
        return "lw_lvl_progress";
    }
    public LightningWordsLevelProgress()
    {
        this = new System.Object();
        mem[1152921517597959920] = 0;
        this.currentLightningWordIndex = 0;
        this.lightningRemainingTime = 0;
        this.paused = false;
        this.firstLightningWordTimeRemaining = 0;
        this.isCoinSpent = false;
        this.currentLightningWord = "";
        this.currentModeSecondaryId = 0;
    }
    public override void Load()
    {
        mem[1152921517598080960] = UnityEngine.PlayerPrefs.GetInt(key:  this, defaultValue:  0);
        this.currentLightningWord = UnityEngine.PlayerPrefs.GetString(key:  "lw_lvl_wd", defaultValue:  "");
        this.currentLightningWordIndex = UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_wd_idx", defaultValue:  0);
        this.lightningRemainingTime = UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_time_left", defaultValue:  0);
        this.paused = ((UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_psd", defaultValue:  0)) == 1) ? 1 : 0;
        this.firstLightningWordTimeRemaining = UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_first_wd_time_left", defaultValue:  0);
        this.isCoinSpent = ((UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_coin_spent", defaultValue:  0)) == 1) ? 1 : 0;
        this.currentMode = UnityEngine.PlayerPrefs.GetInt(key:  "lw_lvl_mode", defaultValue:  1);
        this.currentModeSecondaryId = UnityEngine.PlayerPrefs.GetString(key:  "lw_lvl_mode_sub", defaultValue:  0);
    }
    public bool IsCurrentLightningWordExisted()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.currentLightningWord);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public bool IsCurrentModeEqualsModeWithTile()
    {
        var val_7;
        if(PlayingLevel.CurrentGameplayMode != this.currentMode)
        {
            goto label_3;
        }
        
        if(PlayingLevel.CurrentGameplayMode != 4)
        {
            goto label_6;
        }
        
        val_7 = 0;
        if((System.Int32.TryParse(s:  this.currentModeSecondaryId, result: out  0)) == false)
        {
                return (bool)val_7;
        }
        
        CategoryPacksManager val_5 = MonoSingleton<CategoryPacksManager>.Instance;
        var val_6 = ((val_5.<CurrentCategoryPackInfo>k__BackingField.packId) == 0) ? 1 : 0;
        return (bool)val_7;
        label_3:
        val_7 = 0;
        return (bool)val_7;
        label_6:
        val_7 = 1;
        return (bool)val_7;
    }
    public void ReleaseCurrentLightningWord()
    {
        this.currentLightningWordIndex = 0;
        this.currentLightningWord = "";
        goto typeof(LightningWordsLevelProgress).__il2cppRuntimeField_190;
    }
    public override void Save()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "lw_lvl_wd", value:  this.currentLightningWord);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_wd_idx", value:  this.currentLightningWordIndex);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_time_left", value:  this.lightningRemainingTime);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_psd", value:  this.paused);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_first_wd_time_left", value:  this.firstLightningWordTimeRemaining);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_coin_spent", value:  this.isCoinSpent);
        UnityEngine.PlayerPrefs.SetInt(key:  "lw_lvl_mode", value:  this.currentMode);
        UnityEngine.PlayerPrefs.SetString(key:  "lw_lvl_mode_sub", value:  this.currentModeSecondaryId);
        this.Save();
    }
    public override void Delete()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_wd")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_wd");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_wd_idx")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_wd_idx");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_time_left")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_time_left");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_psd")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_psd");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_first_wd_time_left")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_first_wd_time_left");
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "lw_lvl_coin_spent")) != false)
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "lw_lvl_coin_spent");
        }
        
        this.Delete();
    }

}
