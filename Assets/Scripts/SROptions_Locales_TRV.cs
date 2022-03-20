using UnityEngine;
public class SROptions_TRV.SROptions_Locales_TRV : SuperLuckySROptionsParent<SROptions_TRV.SROptions_Locales_TRV>, INotifyPropertyChanged
{
    // Properties
    public string LocaleFromDevice { get; }
    public string LocaleFromEcon { get; }
    public string LangFromLoc { get; }
    public string SupportedLocaleDisplay { get; }
    
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
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_TRV>.Instance);
    }
    public string get_LocaleFromDevice()
    {
        return DeviceProperties.LocaleFromDevice;
    }
    public string get_LocaleFromEcon()
    {
        return MonoSingleton<TRVDataParser>.Instance.QAHACK_getCurrentCagetoryEconLocale;
    }
    public string get_LangFromLoc()
    {
        return (string)Localization.GAME_NAME + 80;
    }
    public void HackLocale()
    {
        SupportedLocales val_3 = 0;
        bool val_4 = System.Enum.TryParse<SupportedLocales>(value:  this.LocaleFromEcon.Replace(oldValue:  "-", newValue:  "_"), result: out  val_3);
        MonoSingleton<TRVDataParser>.Instance.QAHACK_setCurrentCategoryEcon(formattedLanguageAndLocale:  (0 == (System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).Length)) ? 0 : (val_3 + 1).ToString().Replace(oldValue:  "_", newValue:  "-"));
        SROptions_TRV.SROptions_Locales_TRV.NotifyPropertyChanged(propertyName:  "LocaleFromEcon");
    }
    public string get_SupportedLocaleDisplay()
    {
        return PrettyPrint.printJSON(obj:  System.Enum.GetNames(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())), types:  false, singleLineOutput:  false);
    }
    public SROptions_TRV.SROptions_Locales_TRV()
    {
    
    }

}
