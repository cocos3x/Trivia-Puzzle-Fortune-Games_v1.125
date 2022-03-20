using UnityEngine;
public class DifficultySettingManager : MonoSingleton<DifficultySettingManager>
{
    // Fields
    public bool DifficultyChangedOnLevelComplete;
    private DifficultySetting <Setting>k__BackingField;
    
    // Properties
    public static float GetCurrentPointMultiplier { get; }
    public DifficultySetting Setting { get; set; }
    public bool IsPlayingChallengingLevels { get; }
    
    // Methods
    public static float get_GetCurrentPointMultiplier()
    {
        if((MonoSingleton<DifficultySettingManager>.Instance) == 0)
        {
                return 0f;
        }
        
        var val_4 = (DifficultySettingManagerGameplay.IsPlayingDifficultLevel != true) ? 2f : 0f;
        return 0f;
    }
    public DifficultySetting get_Setting()
    {
        return (DifficultySetting)this.<Setting>k__BackingField;
    }
    private void set_Setting(DifficultySetting value)
    {
        this.<Setting>k__BackingField = value;
    }
    public bool get_IsPlayingChallengingLevels()
    {
        var val_10;
        GameBehavior val_1 = App.getBehavior;
        if(((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) != false) && ((this.<Setting>k__BackingField.Mode) == 1))
        {
                if(CategoryPacksManager.IsPlaying != false)
        {
                val_10 = 1;
            return (bool)val_10;
        }
        
            if((PlayingLevel.CurrentGameplayMode == 1) && ((this.<Setting>k__BackingField.StartingLevel) != 1))
        {
                if(App.Player >= (this.<Setting>k__BackingField.StartingLevel))
        {
            goto label_21;
        }
        
        }
        
        }
        
        val_10 = 0;
        return (bool)val_10;
        label_21:
        GameEcon val_8 = App.getGameEcon;
        var val_9 = (App.Player >= val_8.difficultySettingPromptLevel) ? 1 : 0;
        return (bool)val_10;
    }
    public override void InitMonoSingleton()
    {
        DifficultySetting val_1 = new DifficultySetting();
        this.<Setting>k__BackingField = val_1;
        val_1.LoadFromJSON();
    }
    public DifficultyMode GetMode()
    {
        if((this.<Setting>k__BackingField) != null)
        {
                return (DifficultyMode)this.<Setting>k__BackingField.Mode;
        }
        
        throw new NullReferenceException();
    }
    public void UpdateSetting(DifficultyMode mode)
    {
        this.<Setting>k__BackingField.Mode = mode;
        this.<Setting>k__BackingField.StartingLevel = App.Player + 1;
        this.<Setting>k__BackingField.SaveToJSON();
    }
    public void ShowOnPromptLevel()
    {
        if((this.<Setting>k__BackingField.FeatureStatus.Prompted) != false)
        {
                return;
        }
        
        this.<Setting>k__BackingField.FeatureStatus.Prompted = true;
        this.<Setting>k__BackingField.SaveToJSON();
        this.<Setting>k__BackingField.ShowDifficultySettingPopup();
    }
    public void ShowDifficultySettingPopup_Leagues()
    {
        SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false);
    }
    private void ShowDifficultySettingPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false);
    }
    public DifficultySettingManager()
    {
    
    }

}
