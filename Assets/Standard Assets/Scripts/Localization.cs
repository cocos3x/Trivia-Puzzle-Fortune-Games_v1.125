using UnityEngine;
public class Localization : MonoBehaviour
{
    // Fields
    public const string ON_LOCALIZE = "OnLocalize";
    private static Localization mInstance;
    private const string CURRENCY = "#currency";
    private const string CURRENCYS = "#currency_s";
    private const string CURRENCYL = "#currency_l";
    private const string CURRENCYU = "#currency_u";
    private const string GAME_NAME = "#game-name";
    private string <Currency>k__BackingField;
    private string <CurrencySingular>k__BackingField;
    private string <CurrencyLowerCase>k__BackingField;
    private string <CurrencyUpperCase>k__BackingField;
    private static string <GameName>k__BackingField;
    public string startingLanguage;
    private UnityEngine.TextAsset[] languages;
    private System.Collections.Generic.Dictionary<string, string> mDictionary;
    private string mLanguage;
    
    // Properties
    private string Currency { get; set; }
    private string CurrencySingular { get; set; }
    private string CurrencyLowerCase { get; set; }
    private string CurrencyUpperCase { get; set; }
    private static string GameName { get; set; }
    public static Localization instance { get; }
    public string currentLanguage { get; set; }
    
    // Methods
    private string get_Currency()
    {
        return (string)this.<Currency>k__BackingField;
    }
    private void set_Currency(string value)
    {
        this.<Currency>k__BackingField = value;
    }
    private string get_CurrencySingular()
    {
        return (string)this.<CurrencySingular>k__BackingField;
    }
    private void set_CurrencySingular(string value)
    {
        this.<CurrencySingular>k__BackingField = value;
    }
    private string get_CurrencyLowerCase()
    {
        return (string)this.<CurrencyLowerCase>k__BackingField;
    }
    private void set_CurrencyLowerCase(string value)
    {
        this.<CurrencyLowerCase>k__BackingField = value;
    }
    private string get_CurrencyUpperCase()
    {
        return (string)this.<CurrencyUpperCase>k__BackingField;
    }
    private void set_CurrencyUpperCase(string value)
    {
        this.<CurrencyUpperCase>k__BackingField = value;
    }
    private static string get_GameName()
    {
        return (string)Localization.<GameName>k__BackingField;
    }
    private static void set_GameName(string value)
    {
        Localization.<GameName>k__BackingField = value;
    }
    public static Localization get_instance()
    {
        return (Localization)Localization.GAME_NAME;
    }
    public string get_currentLanguage()
    {
        return (string)this.mLanguage;
    }
    public void set_currentLanguage(string value)
    {
        UnityEngine.TextAsset val_8;
        var val_9;
        string val_8 = value;
        if((System.String.op_Inequality(a:  this.mLanguage, b:  val_8)) == false)
        {
                return;
        }
        
        this.startingLanguage = val_8;
        if((System.String.IsNullOrEmpty(value:  val_8)) == true)
        {
            goto label_15;
        }
        
        if(this.languages == null)
        {
            goto label_6;
        }
        
        UnityEngine.TextAsset val_3 = this.FindLanguageAsset(name:  val_8);
        if(val_3 == 0)
        {
            goto label_6;
        }
        
        val_8 = val_3;
        goto label_7;
        label_6:
        UnityEngine.Object val_6 = UnityEngine.Resources.Load(path:  val_8, systemTypeInstance:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_9 = 0;
        if( == 0)
        {
            goto label_15;
        }
        
        val_8 = ;
        label_7:
        this.Load(asset:  val_8);
        return;
        label_15:
        this.mDictionary.Clear();
        UnityEngine.PlayerPrefs.DeleteKey(key:  "Language");
    }
    private void Awake()
    {
        if(Localization.GAME_NAME == 0)
        {
                Localization.GAME_NAME = this;
            UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
            this.currentLanguage = UnityEngine.PlayerPrefs.GetString(key:  "Language", defaultValue:  this.startingLanguage);
            if((System.String.IsNullOrEmpty(value:  this.mLanguage)) == false)
        {
                return;
        }
        
            if(this.languages == null)
        {
                return;
        }
        
            if(this.languages.Length == 0)
        {
                return;
        }
        
            this.currentLanguage = this.languages[0].name;
            return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void OnEnable()
    {
        if(Localization.GAME_NAME != 0)
        {
                return;
        }
        
        Localization.GAME_NAME = this;
    }
    private void OnDestroy()
    {
        if(Localization.GAME_NAME != this)
        {
                return;
        }
        
        Localization.GAME_NAME = 0;
    }
    private UnityEngine.TextAsset FindLanguageAsset(string name)
    {
        UnityEngine.TextAsset val_4;
        if(this.languages.Length < 1)
        {
            goto label_9;
        }
        
        var val_4 = 0;
        label_10:
        val_4 = this.languages[val_4];
        if(val_4 != 0)
        {
                if((System.String.op_Equality(a:  val_4.name, b:  name)) == true)
        {
                return (UnityEngine.TextAsset)val_4;
        }
        
        }
        
        val_4 = val_4 + 1;
        if(val_4 >= (long)this.languages.Length)
        {
            goto label_9;
        }
        
        if(this.languages != null)
        {
            goto label_10;
        }
        
        throw new NullReferenceException();
        label_9:
        val_4 = 0;
        return (UnityEngine.TextAsset)val_4;
    }
    private void Load(UnityEngine.TextAsset asset)
    {
        this.mLanguage = asset.name;
        this.mDictionary = new ByteReader(asset:  asset).ReadDictionary();
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        if(UnityEngine.Application.isEditor != false)
        {
                if((UnityEngine.StackTraceUtility.ExtractStackTrace().Contains(value:  "UGUILocalizeComponentEditor")) != false)
        {
                return;
        }
        
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "Language", value:  this.mLanguage);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnLocalize", aData:  0);
    }
    public string GetForLanguage(string language, string key, string defaultValue = "", bool useSingularKey = False)
    {
        UnityEngine.TextAsset val_1 = this.FindLanguageAsset(name:  language);
        if(val_1 == 0)
        {
                return this.Get(key:  key, defaultValue:  defaultValue, useSingularKey:  useSingularKey);
        }
        
        this.Load(asset:  val_1);
        return this.Get(key:  key, defaultValue:  defaultValue, useSingularKey:  useSingularKey);
    }
    public string Get(string key, string defaultValue = "", bool useSingularKey = False)
    {
        string val_18;
        var val_19;
        var val_20;
        val_18 = key;
        val_19 = this;
        string val_2 = 0;
        if((this.mDictionary.TryGetValue(key:  val_18 + " Mobile", value: out  val_2)) != false)
        {
                val_20 = val_2;
            return (string)val_20;
        }
        
        if(useSingularKey != false)
        {
                string val_4 = val_18 + "_singular";
        }
        
        if((this.mDictionary.TryGetValue(key:  val_4, value: out  val_2)) == false)
        {
            goto label_6;
        }
        
        val_20 = val_2;
        if(val_20 != 0)
        {
            goto label_7;
        }
        
        label_6:
        var val_7 = ((System.String.op_Inequality(a:  defaultValue, b:  "")) != true) ? defaultValue : (val_4);
        label_7:
        if((val_7.Contains(value:  "#currency_s")) != false)
        {
                val_20 = val_7.Replace(oldValue:  "#currency_s", newValue:  this.<CurrencySingular>k__BackingField);
        }
        
        if((val_20.Contains(value:  "#currency_l")) != false)
        {
                val_20 = val_20.Replace(oldValue:  "#currency_l", newValue:  this.<CurrencyLowerCase>k__BackingField);
        }
        
        if((val_20.Contains(value:  "#currency_u")) != false)
        {
                val_20 = val_20.Replace(oldValue:  "#currency_u", newValue:  this.<CurrencyUpperCase>k__BackingField);
        }
        
        val_18 = "#currency";
        if((val_20.Contains(value:  "#currency")) != false)
        {
                val_20 = val_20.Replace(oldValue:  "#currency", newValue:  this.<Currency>k__BackingField);
        }
        
        val_19 = "#game-name";
        if((val_20.Contains(value:  "#game-name")) == false)
        {
                return (string)val_20;
        }
        
        val_20 = val_20.Replace(oldValue:  "#game-name", newValue:  Localization.<GameName>k__BackingField);
        return (string)val_20;
    }
    public void setLocalizedCurrency(string currencyKey)
    {
        this.<Currency>k__BackingField = this.Get(key:  currencyKey, defaultValue:  currencyKey, useSingularKey:  false);
        this.<CurrencySingular>k__BackingField = this.Get(key:  currencyKey + "_singular", defaultValue:  this.<Currency>k__BackingField, useSingularKey:  false);
        this.<CurrencyLowerCase>k__BackingField = this.<Currency>k__BackingField.ToLower();
        this.<CurrencyUpperCase>k__BackingField = this.<Currency>k__BackingField.ToUpper();
    }
    public static void SetGameName(string gameName)
    {
        Localization.<GameName>k__BackingField = gameName;
    }
    public static string Localize(string key, string defaultValue = "", bool useSingularKey = False)
    {
        if(Localization.GAME_NAME == 0)
        {
                return (string)((System.String.IsNullOrEmpty(value:  defaultValue)) != true) ? key : defaultValue;
        }
        
        return Localization.GAME_NAME.Get(key:  key, defaultValue:  defaultValue, useSingularKey:  useSingularKey);
    }
    public static System.Collections.Generic.List<string> GetLanguageNames()
    {
        var val_4;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        if(Localization.GAME_NAME == 0)
        {
                val_2.Add(item:  "en");
            return val_2;
        }
        
        val_4 = 0;
        goto label_7;
        label_15:
        var val_4 = 18093;
        val_4 = val_4 + 0;
        val_2.Add(item:  (18093 + 0) + 32.name);
        val_4 = 1;
        label_7:
        if(val_4 < (Localization.GAME_NAME + 64 + 24))
        {
            goto label_15;
        }
        
        return val_2;
    }
    public Localization()
    {
        this.startingLanguage = "English";
        this.mDictionary = new System.Collections.Generic.Dictionary<System.String, System.String>();
    }

}
