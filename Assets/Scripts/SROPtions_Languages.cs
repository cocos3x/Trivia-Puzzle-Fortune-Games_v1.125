using UnityEngine;
public class SROPtions_Languages : SuperLuckySROptionsParent<SROPtions_Languages>, INotifyPropertyChanged
{
    // Properties
    public string Language { get; }
    
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
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_General>.Instance);
    }
    public string get_Language()
    {
        return Localization.Localize(key:  "Keys", defaultValue:  "", useSingularKey:  false);
    }
    public void en()
    {
        SROPtions_Languages.LanguageClicked(sender:  "en");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void hi()
    {
        SROPtions_Languages.LanguageClicked(sender:  "hi");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void eses()
    {
        SROPtions_Languages.LanguageClicked(sender:  "es-es");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void fr()
    {
        SROPtions_Languages.LanguageClicked(sender:  "fr");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void id()
    {
        SROPtions_Languages.LanguageClicked(sender:  "id");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void tr()
    {
        SROPtions_Languages.LanguageClicked(sender:  "tr");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void tl()
    {
        SROPtions_Languages.LanguageClicked(sender:  "tl");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void ptbr()
    {
        SROPtions_Languages.LanguageClicked(sender:  "pt-br");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void de()
    {
        SROPtions_Languages.LanguageClicked(sender:  "de");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void es()
    {
        SROPtions_Languages.LanguageClicked(sender:  "es");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void ko()
    {
        SROPtions_Languages.LanguageClicked(sender:  "ko");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void pl()
    {
        SROPtions_Languages.LanguageClicked(sender:  "pl");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void pt()
    {
        SROPtions_Languages.LanguageClicked(sender:  "pt");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void zhTW()
    {
        SROPtions_Languages.LanguageClicked(sender:  "zh-TW");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void nl()
    {
        SROPtions_Languages.LanguageClicked(sender:  "nl");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void ru()
    {
        SROPtions_Languages.LanguageClicked(sender:  "ru");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void ms()
    {
        SROPtions_Languages.LanguageClicked(sender:  "ms");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void it()
    {
        SROPtions_Languages.LanguageClicked(sender:  "it");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void ja()
    {
        SROPtions_Languages.LanguageClicked(sender:  "ja");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void th()
    {
        SROPtions_Languages.LanguageClicked(sender:  "th");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public void zhCN()
    {
        SROPtions_Languages.LanguageClicked(sender:  "zh-CN");
        SROPtions_Languages.NotifyPropertyChanged(propertyName:  "Language");
    }
    public static void LanguageClicked(string sender)
    {
        if(Localization.GAME_NAME == 0)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "Language", value:  sender);
        Localization.GAME_NAME.__unknownFiledOffset_38 = sender;
        Localization.GAME_NAME.currentLanguage = sender;
        GameBehavior val_2 = App.getBehavior;
        Localization.GAME_NAME.setLocalizedCurrency(currencyKey:  val_2.<metaGameBehavior>k__BackingField);
    }
    public static SROPtions_Languages.Languages LanguageStringToEnum(string lang)
    {
        var val_4;
        if((System.String.IsNullOrEmpty(value:  lang)) != false)
        {
                val_4 = 0;
            return (Languages)null;
        }
        
        object val_3 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  lang, ignoreCase:  true);
        return (Languages)null;
    }
    public SROPtions_Languages()
    {
    
    }

}
