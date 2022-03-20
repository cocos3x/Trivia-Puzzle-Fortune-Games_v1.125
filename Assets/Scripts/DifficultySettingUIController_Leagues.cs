using UnityEngine;
public class DifficultySettingUIController_Leagues : MonoSingleton<DifficultySettingUIController_Leagues>
{
    // Fields
    public const string UPDATE_DIFFICULTY_SETTING_ICON = "UpdateDifficultySettingIcon_Leagues";
    private UnityEngine.GameObject difficultySettingGroup;
    private UnityEngine.UI.Image difficultyMeter;
    private UnityEngine.Sprite normalDifficultySp;
    private UnityEngine.Sprite challengingDifficultySp;
    
    // Methods
    public override void InitMonoSingleton()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.difficultySettingGroup)) != false)
        {
                this.difficultySettingGroup.SetActive(value:  false);
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "UpdateDifficultySettingIcon_Leagues");
        this.UpdateDifficultySettingUI_Leagues();
    }
    private void UpdateDifficultySettingUI_Leagues()
    {
        GameEcon val_2 = App.getGameEcon;
        if(App.Player < val_2.difficultySettingPromptLevel)
        {
                return;
        }
        
        this.UpdateDifficultySettingIcon_Leagues();
        this.difficultySettingGroup.SetActive(value:  true);
    }
    private void UpdateDifficultySettingIcon_Leagues()
    {
        DifficultySettingManager val_1 = MonoSingleton<DifficultySettingManager>.Instance;
        var val_2 = ((val_1.<Setting>k__BackingField.Mode) == 0) ? 40 : 48;
        this.difficultyMeter.sprite = null;
    }
    public DifficultySettingUIController_Leagues()
    {
    
    }

}
