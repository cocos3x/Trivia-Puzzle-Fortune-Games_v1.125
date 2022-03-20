using UnityEngine;
public class UnlockableUIForest : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.GameObject badgeGrow;
    private UnityEngine.UI.Text LabelGrow;
    
    // Properties
    protected override int UnlockLevel { get; }
    
    // Methods
    protected override int get_UnlockLevel()
    {
        WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
        return (int)val_1.wordForestUnlockLevel;
    }
    protected override void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
        if(newState == 3)
        {
                int val_2 = MonoSingleton<WordForest.WFOForestManager>.Instance.AffordableGrowthStages;
            this.badgeGrow.SetActive(value:  (val_2 > 0) ? 1 : 0);
            this = this.LabelGrow;
            string val_4 = val_2.ToString();
            return;
        }
        
        this.badgeGrow.SetActive(value:  false);
    }
    public UnlockableUIForest()
    {
    
    }

}
