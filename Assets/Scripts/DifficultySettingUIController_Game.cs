using UnityEngine;
public class DifficultySettingUIController_Game : MonoSingleton<DifficultySettingUIController_Game>
{
    // Fields
    private UnityEngine.GameObject tooltip;
    
    // Methods
    public void ShowTooltip()
    {
        if(this.tooltip != null)
        {
                this.tooltip.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    public DifficultySettingUIController_Game()
    {
    
    }

}
