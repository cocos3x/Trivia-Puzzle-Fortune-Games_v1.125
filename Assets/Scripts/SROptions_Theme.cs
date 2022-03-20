using UnityEngine;
public class SROptions_Theme : SuperLuckySROptionsParent<SROptions_Theme>, INotifyPropertyChanged
{
    // Properties
    public string CurrentTheme { get; }
    
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
    public string get_CurrentTheme()
    {
        AppConfigs val_1 = App.Configuration;
        if(val_1.gameConfig.themesEnabled == false)
        {
                return "Themes not enabled for game.";
        }
        
        return App.ThemesHandler.CurrentThemeName;
    }
    public void Theme_skeumorphic()
    {
        AppConfigs val_1 = App.Configuration;
        if(val_1.gameConfig.themesEnabled == false)
        {
                return;
        }
        
        App.ThemesHandler.SwapTheme(swapTo:  1);
        SROptions_Theme.NotifyPropertyChanged(propertyName:  "CurrentTheme");
    }
    public void Theme_nut()
    {
        AppConfigs val_1 = App.Configuration;
        if(val_1.gameConfig.themesEnabled == false)
        {
                return;
        }
        
        App.ThemesHandler.SwapTheme(swapTo:  6);
        SROptions_Theme.NotifyPropertyChanged(propertyName:  "CurrentTheme");
    }
    public SROptions_Theme()
    {
    
    }

}
