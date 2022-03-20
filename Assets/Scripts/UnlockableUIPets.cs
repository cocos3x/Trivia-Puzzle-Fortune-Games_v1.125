using UnityEngine;
public class UnlockableUIPets : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.GameObject upgradeIcon;
    
    // Properties
    protected override bool FeatureHidden { get; }
    protected override bool FeatureLocked { get; }
    
    // Methods
    protected override bool get_FeatureHidden()
    {
        return false;
    }
    protected override bool get_FeatureLocked()
    {
        bool val_1 = WADPetsManager.IsFeatureUnlocked();
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    protected override void OnClickLocked()
    {
    
    }
    protected override void OnClickUnlocked()
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 95;
        WADPetsScreenUI.ShowMainScreen();
    }
    protected override void UpdateButton()
    {
        if(this.upgradeIcon == 0)
        {
                return;
        }
        
        this.upgradeIcon.SetActive(value:  MonoSingleton<WADPetsManager>.Instance.IsAnyUpgradeAvailable());
    }
    public UnlockableUIPets()
    {
    
    }

}
