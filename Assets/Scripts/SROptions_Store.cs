using UnityEngine;
public class SROptions_Store : SuperLuckySROptionsParent<SROptions_Store>, INotifyPropertyChanged
{
    // Properties
    public bool WaterFallUseMinutes { get; set; }
    
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
    public bool get_WaterFallUseMinutes()
    {
        WGWaterfallSaleManager val_1 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        return (bool)val_1.qahack_useMinutes;
    }
    public void set_WaterFallUseMinutes(bool value)
    {
        WGWaterfallSaleManager val_1 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        val_1.qahack_useMinutes = value;
        SROptions_Store.NotifyPropertyChanged(propertyName:  "WaterFallUseMinutes");
    }
    public void WaterfallSaleHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Waterfall HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetWaterfallSaleInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ToggleNoAdsPackage()
    {
        float val_6;
        GameEcon val_1 = App.getGameEcon;
        val_6 = 2.99f;
        if(val_1.NoAdsPackagePriceToUse == val_6)
        {
                GameEcon val_2 = App.getGameEcon;
            val_6 = 9.99f;
        }
        else
        {
                if(val_1.NoAdsPackagePriceToUse == 9.99f)
        {
                GameEcon val_3 = App.getGameEcon;
            val_6 = 5.99f;
        }
        else
        {
                if(val_1.NoAdsPackagePriceToUse == 5.99f)
        {
                GameEcon val_4 = App.getGameEcon;
            val_6 = 7.99f;
        }
        else
        {
                if(val_1.NoAdsPackagePriceToUse != 7.99f)
        {
                return;
        }
        
            GameEcon val_5 = App.getGameEcon;
        }
        
        }
        
        }
        
        val_5.NoAdsPackagePriceToUse = val_6;
    }
    public SROptions_Store()
    {
    
    }

}
