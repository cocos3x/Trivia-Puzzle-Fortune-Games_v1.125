using UnityEngine;
public class UnlockableUIStoreButton : WGUnlockableUIElement
{
    // Properties
    protected override bool FeatureHidden { get; }
    
    // Methods
    protected override bool get_FeatureHidden()
    {
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_2 = App.getGameEcon;
        bool val_3 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  val_2.storeButtonDisplayLevel);
        val_3 = (~val_3) & 1;
        return (bool)val_3;
    }
    protected override void SetNewState(WGUnlockableUIElement.UiLockedState newState)
    {
        this.gameObject.SetActive(value:  (newState != 1) ? 1 : 0);
    }
    public UnlockableUIStoreButton()
    {
    
    }

}
