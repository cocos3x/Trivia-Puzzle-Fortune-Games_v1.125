using UnityEngine;
public class SROptions_UIs : SuperLuckySROptionsParent<SROptions_UIs>, INotifyPropertyChanged
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
    public void KnobsInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Knobs Info HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetKnobsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void AdsInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Ads Info HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetAdsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PlayerTrackingStatsHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Player Tracking Stats HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetTrackingInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PlayerAddedCoinsTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Player Coins Trace", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetAddedCoinsTrace()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PlayerAddedNonCoinsTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Player Non Coin Trace", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetAddedNonCoinsTrace()));
    }
    public void QueuedWindowsTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Queued Windows", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::getQueuedWindowsString()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ClearQueuedWindowOps()
    {
        MonoSingleton<WGWindowManager>.Instance.ClearOps();
    }
    public void AdsEvents()
    {
        SLCHUDWindow.SetupHUD(name:  "Ads API Events", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetAdsEventsString()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PlayerAllInfoTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Player All Data HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::getPlayerAllInfoString()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void DebugEventsTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Debug Events", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::getDataInDBEvents()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void DebugAmpFeatureGlobals()
    {
        SLCHUDWindow.SetupHUD(name:  "Amp Feature Globals", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetAmpFeatureGlobals()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void LeaguesTraceHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Leagues Trace HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::getLeaguesTraceString()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void FeaturedOfferHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Featured Offer Logs", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetFeaturedOfferLog()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void MiscSLCDebug()
    {
        SLCHUDWindow.SetupHUD(name:  "Miscellaneous Logs", callbackfunc:  new System.Func<System.String>(object:  0, method:  public static System.String SLCDebug::GetLogs()));
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void MoreGamesHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "More Games Info", callbackfunc:  new System.Func<System.String>(object:  0, method:  public static System.String WGMoreGamesManager::GetDebugData()));
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void LetterBankHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Letter Bank Debug Info", callbackfunc:  new System.Func<System.String>(object:  0, method:  public static System.String LetterBankEventHandler::GetLog()));
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_UIs()
    {
    
    }

}
