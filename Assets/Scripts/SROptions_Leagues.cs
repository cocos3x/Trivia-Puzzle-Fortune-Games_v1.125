using UnityEngine;
public class SROptions_Leagues : SuperLuckySROptionsParent<SROptions_Leagues>, INotifyPropertyChanged
{
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
        var val_8;
        var val_11;
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_8 = 13;
        val_11 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_11 = 12;
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
    }
    public void QueuedWindowsTraceHUD()
    {
        if((MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance) == 0)
        {
                return;
        }
        
        SLCHUDWindow.SetupHUD(name:  "Queued Windows", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance, method:  public System.String SLCWindowManager<SLC.Social.Leagues.LeaguesWindowManager>::DebugQueuedWindows()));
    }
    public SROptions_Leagues()
    {
    
    }

}
