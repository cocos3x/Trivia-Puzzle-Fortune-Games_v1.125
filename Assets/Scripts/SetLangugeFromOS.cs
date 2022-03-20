using UnityEngine;
public class SetLangugeFromOS : MonoBehaviour
{
    // Fields
    public bool disableLanguageSelection;
    public bool active;
    private Localization localization;
    private string previousLanguage;
    private static System.Collections.Generic.List<string> unlocalizedInWeb;
    
    // Methods
    private void Awake()
    {
        this.localization = this.gameObject.GetComponent<Localization>();
        if(this.disableLanguageSelection != false)
        {
                this.active = false;
        }
        
        if(this.SetupLanguage() != false)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        this.localization.setLocalizedCurrency(currencyKey:  val_4.<metaGameBehavior>k__BackingField);
    }
    private void SetLanguage(string useLanguage)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "Language", value:  useLanguage);
        this.localization.startingLanguage = useLanguage;
        this.localization.currentLanguage = useLanguage;
        AppConfigs val_1 = App.Configuration;
        Localization.SetGameName(gameName:  val_1.appConfig.gameName);
        GameBehavior val_2 = App.getBehavior;
        this.localization.setLocalizedCurrency(currencyKey:  val_2.<metaGameBehavior>k__BackingField);
    }
    private bool SetupLanguage()
    {
        var val_9 = 0;
        if((UnityEngine.PlayerPrefs.GetInt(key:  "settings_override_language", defaultValue:  0)) > 0)
        {
                return (bool)val_9;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.localization)) != true)
        {
                this.localization = this.gameObject.GetComponent<Localization>();
        }
        
        string val_5 = DeviceProperties.LocaleFromDevice;
        string val_6 = val_5.checkIfLanguageExists(deviceLanguage:  val_5);
        string val_7 = (val_6 == null) ? "en" : (val_6);
        if((val_7.Equals(value:  this.previousLanguage)) != false)
        {
                val_9 = 0;
            return (bool)val_9;
        }
        
        this.previousLanguage = val_7;
        this.SetLanguage(useLanguage:  val_7);
        val_9 = 1;
        return (bool)val_9;
    }
    private string checkIfLanguageExists(string deviceLanguage)
    {
        System.Func<TSource, System.Boolean> val_10;
        SetLangugeFromOS.<>c__DisplayClass8_0 val_1 = new SetLangugeFromOS.<>c__DisplayClass8_0();
        .deviceLanguage = deviceLanguage;
        GameBehavior val_2 = App.getBehavior;
        System.Func<System.String, System.Boolean> val_3 = null;
        val_10 = val_3;
        val_3 = new System.Func<System.String, System.Boolean>(object:  val_1, method:  System.Boolean SetLangugeFromOS.<>c__DisplayClass8_0::<checkIfLanguageExists>b__0(string x));
        string val_4 = System.Linq.Enumerable.FirstOrDefault<System.String>(source:  val_2.<metaGameBehavior>k__BackingField, predicate:  val_3);
        if(val_4 != null)
        {
                return (string)(val_8 == null) ? (val_10) : (val_8);
        }
        
        val_10 = val_4;
        if((System.Linq.Enumerable.FirstOrDefault<System.String>(source:  val_2.<metaGameBehavior>k__BackingField, predicate:  new System.Func<System.String, System.Boolean>(object:  val_1, method:  System.Boolean SetLangugeFromOS.<>c__DisplayClass8_0::<checkIfLanguageExists>b__1(string x)))) != null)
        {
                return (string)(val_8 == null) ? (val_10) : (val_8);
        }
        
        string val_8 = System.Linq.Enumerable.FirstOrDefault<System.String>(source:  val_2.<metaGameBehavior>k__BackingField, predicate:  new System.Func<System.String, System.Boolean>(object:  val_1, method:  System.Boolean SetLangugeFromOS.<>c__DisplayClass8_0::<checkIfLanguageExists>b__2(string x)));
        return (string)(val_8 == null) ? (val_10) : (val_8);
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
                return;
        }
        
        if(this.active == false)
        {
                return;
        }
        
        bool val_1 = this.SetupLanguage();
    }
    public SetLangugeFromOS()
    {
        this.disableLanguageSelection = true;
        this.active = true;
        this.previousLanguage = "";
    }
    private static SetLangugeFromOS()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "ja");
        val_1.Add(item:  "ko");
        val_1.Add(item:  "zh");
        val_1.Add(item:  "zh-HK");
        val_1.Add(item:  "zh-CN");
        val_1.Add(item:  "zh-TW");
        SetLangugeFromOS.unlocalizedInWeb = val_1;
    }

}
