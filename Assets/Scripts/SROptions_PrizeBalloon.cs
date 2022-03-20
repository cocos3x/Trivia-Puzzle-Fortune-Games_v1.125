using UnityEngine;
public class SROptions_PrizeBalloon : SuperLuckySROptionsParent<SROptions_PrizeBalloon>, INotifyPropertyChanged
{
    // Properties
    public bool UseNetworkPurchaser { get; set; }
    public bool ForceToShowBalloon { get; set; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public bool get_UseNetworkPurchaser()
    {
        WGPrizeBalloonManager val_1 = MonoSingleton<WGPrizeBalloonManager>.Instance;
        return (bool)val_1.hack_setNonPurchaser;
    }
    public void set_UseNetworkPurchaser(bool value)
    {
        WGPrizeBalloonManager val_1 = MonoSingleton<WGPrizeBalloonManager>.Instance;
        val_1.hack_setNonPurchaser = value;
    }
    public bool get_ForceToShowBalloon()
    {
        WGPrizeBalloonManager val_1 = MonoSingleton<WGPrizeBalloonManager>.Instance;
        return (bool)val_1.hack_forceToShow;
    }
    public void set_ForceToShowBalloon(bool value)
    {
        WGPrizeBalloonManager val_1 = MonoSingleton<WGPrizeBalloonManager>.Instance;
        val_1.hack_forceToShow = value;
    }
    public void CheckEligibility()
    {
        SLCHUDWindow.SetupHUD(name:  "Prize Balloon Eligibility HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetPrizeBalloonInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_PrizeBalloon()
    {
    
    }

}
