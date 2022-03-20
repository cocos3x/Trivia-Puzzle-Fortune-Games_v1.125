using UnityEngine;
public class SROptions_FPH : SuperLuckySROptionsParent<SROptions_FPH>, INotifyPropertyChanged
{
    // Fields
    private bool isDebugBannerShown;
    
    // Properties
    public bool DisplayCardValue { get; set; }
    public bool Show { get; set; }
    
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
    public bool get_DisplayCardValue()
    {
        return CPlayerPrefs.GetBool(key:  "DisplayCardValue", defaultValue:  false);
    }
    public void set_DisplayCardValue(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "DisplayCardValue", value:  value);
    }
    public void CompleteLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_190;
    }
    public void CompleteChapter()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_1A0;
    }
    public void RestartLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_1B0;
    }
    public void General()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_General>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void PlayerCheats()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Player>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DateTime()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DateTime>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Store()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Store>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Ads()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Ads>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DailyBonus()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DailyBonus>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DisplayLevelInfo()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetGameLevelInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ShowEventHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_GameEvents>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void GenericUIs()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_UIs>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public bool get_Show()
    {
        return (bool)this.isDebugBannerShown;
    }
    public void set_Show(bool value)
    {
        this.isDebugBannerShown = value;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ToggleDebugBanner");
    }
    public void Locales()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Locales_FPH>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public SROptions_FPH()
    {
        this.isDebugBannerShown = true;
    }

}
