using UnityEngine;
public class FPHDataParser : MonoSingleton<FPHDataParser>
{
    // Fields
    private string currentLevelListLanguage;
    private System.Collections.Generic.List<FPHLevelObject> standardLevelList;
    private string QAHACK_currentHackedLocale;
    
    // Properties
    private string PERSISTANT_LEVEL_DATA_KEY { get; }
    public string PathToGameResources { get; }
    public int InitialLevelOffset { get; set; }
    private int QuizLevelOffest { get; set; }
    public string QAHACK_getCurrentCagetoryEconLocale { get; }
    
    // Methods
    private string get_PERSISTANT_LEVEL_DATA_KEY()
    {
        string val_4;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<FPHDataParser>.Instance)) != false)
        {
                FPHDataParser val_3 = MonoSingleton<FPHDataParser>.Instance;
            val_4 = val_3.currentLevelListLanguage;
            return "FPHGPS" + val_4;
        }
        
        val_4 = "en";
        return "FPHGPS" + val_4;
    }
    public string get_PathToGameResources()
    {
        return "game/"("game/") + WordApp.GamePathName + "/"("/");
    }
    public int get_InitialLevelOffset()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "fph_initial_lvl_offset", defaultValue:  0);
    }
    public void set_InitialLevelOffset(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "fph_initial_lvl_offset", value:  value);
    }
    private int get_QuizLevelOffest()
    {
        return CPlayerPrefs.GetInt(key:  "qlo", defaultValue:  0);
    }
    private void set_QuizLevelOffest(int value)
    {
        CPlayerPrefs.SetInt(key:  "qlo", val:  value);
    }
    private void OnLocalize()
    {
        GameBehavior val_1 = App.getBehavior;
        if((this.currentLevelListLanguage.StartsWith(value:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) == true)
        {
                return;
        }
        
        this.currentLevelListLanguage = this.GetFormattedLangaugeAndLocale();
        this.standardLevelList = this.LoadStandardLevelData();
    }
    private string GetFormattedLangaugeAndLocale()
    {
        object val_16;
        string val_17;
        object val_18;
        var val_19;
        if((System.String.IsNullOrEmpty(value:  this.QAHACK_currentHackedLocale)) == false)
        {
            goto label_1;
        }
        
        if(Localization.GAME_NAME == 0)
        {
            goto label_5;
        }
        
        goto label_8;
        label_1:
        val_17 = this.QAHACK_currentHackedLocale;
        return (string)val_19;
        label_5:
        val_16 = "en";
        label_8:
        string val_3 = DeviceProperties.LocaleFromDevice;
        if((val_3.Contains(value:  "-")) != false)
        {
                char[] val_5 = new char[1];
            val_5[0] = '-';
        }
        else
        {
                val_18 = "US";
        }
        
        val_17 = System.String.Format(format:  "{0}-{1}", arg0:  val_16, arg1:  val_18).ToLower();
        if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_17.Replace(oldValue:  "-", newValue:  "_"))) == true)
        {
                return (string)val_19;
        }
        
        object[] val_12 = new object[1];
        val_12[0] = val_17;
        UnityEngine.Debug.LogErrorFormat(format:  "{0} Not A Supported Language/Locale!", args:  val_12);
        if((val_17.StartsWith(value:  "de")) != false)
        {
                val_19 = "de-de";
            return (string)val_19;
        }
        
        if((val_17.StartsWith(value:  "fr")) != false)
        {
                val_19 = "fr-fr";
            return (string)val_19;
        }
        
        if((val_17.StartsWith(value:  "es")) != false)
        {
                val_19 = "es-419";
            return (string)val_19;
        }
        
        val_19 = "en-us";
        return (string)val_19;
    }
    private string ParseLanguageFromLocale(string currentLocale)
    {
        char[] val_1 = new char[1];
        val_1[0] = '-';
        return (string)currentLocale.Split(separator:  val_1)[0];
    }
    public string get_QAHACK_getCurrentCagetoryEconLocale()
    {
        return (string)((System.String.IsNullOrEmpty(value:  this.currentLevelListLanguage)) != true) ? "not set" : (this.currentLevelListLanguage);
    }
    public void QAHACK_setCurrentCategoryEcon(string formattedLanguageAndLocale)
    {
        this.standardLevelList = 0;
        this.QAHACK_currentHackedLocale = formattedLanguageAndLocale;
        object[] val_1 = new object[1];
        val_1[0] = this.QAHACK_currentHackedLocale;
        UnityEngine.Debug.LogErrorFormat(format:  "Attempting to Parse Category Econ For: {0}", args:  val_1);
        this.currentLevelListLanguage = this.GetFormattedLangaugeAndLocale();
        this.standardLevelList = this.LoadStandardLevelData();
    }
    public override void InitMonoSingleton()
    {
        string val_4;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        if(Localization.GAME_NAME != 0)
        {
                if(this != null)
        {
            goto label_10;
        }
        
        }
        
        val_4 = "en";
        label_10:
        this.currentLevelListLanguage = val_4;
        this.standardLevelList = this.LoadStandardLevelData();
    }
    private System.Collections.Generic.List<FPHLevelObject> ParseRawText(UnityEngine.TextAsset levelData)
    {
        string val_8;
        var val_9;
        FPHLevelObject val_10;
        val_8 = levelData;
        val_9 = 0;
        if((System.String.IsNullOrEmpty(value:  val_8.text)) == true)
        {
                return (System.Collections.Generic.List<FPHLevelObject>)val_9;
        }
        
        val_8 = val_8.text;
        System.String[] val_4 = System.Text.RegularExpressions.Regex.Split(input:  val_8, pattern:  "\n|\r|\r\n");
        if(val_4 != null)
        {
                val_8 = val_4;
            if(val_4.Length != 0)
        {
                System.Collections.Generic.List<FPHLevelObject> val_5 = null;
            val_9 = val_5;
            val_5 = new System.Collections.Generic.List<FPHLevelObject>();
            int val_10 = val_4.Length;
            if(val_10 < 2)
        {
                return (System.Collections.Generic.List<FPHLevelObject>)val_9;
        }
        
            val_10 = val_10 & 4294967295;
            do
        {
            val_10 = 1;
            if((System.String.IsNullOrEmpty(value:  val_8[1])) != true)
        {
                FPHLevelObject val_7 = null;
            val_10 = val_7;
            val_7 = new FPHLevelObject(unparsedString:  val_8[1]);
            val_5.Add(item:  val_7);
        }
        
            var val_9 = 5 + 1;
        }
        while((5 - 3) < (val_4.Length << ));
        
            return (System.Collections.Generic.List<FPHLevelObject>)val_9;
        }
        
        }
        
        val_9 = 0;
        return (System.Collections.Generic.List<FPHLevelObject>)val_9;
    }
    private System.Collections.Generic.List<FPHLevelObject> LoadStandardLevelData()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.currentLevelListLanguage);
        string val_3 = val_1.ParseLanguageFromLocale(currentLocale:  (val_1 != true) ? "en-us" : (this.currentLevelListLanguage));
        string val_5 = System.String.Format(format:  "{0}{1}_{2}", arg0:  val_3.PathToGameResources, arg1:  "Levels/Standard/FPHLevels", arg2:  val_3);
        object[] val_6 = new object[1];
        val_6[0] = val_5;
        UnityEngine.Debug.LogErrorFormat(format:  "will load FPH Level Data from: {0}", args:  val_6);
        UnityEngine.TextAsset val_7 = LoadAssetFromFolder(path:  val_5);
        bool val_8 = UnityEngine.Object.op_Equality(x:  val_7, y:  0);
        if(val_8 == false)
        {
                return val_8.ParseRawText(levelData:  val_7);
        }
        
        return 0;
    }
    public System.Collections.Generic.List<FPHLevelObject> LoadQOTDLevelData()
    {
        string val_2 = this.PathToGameResources + "Levels/Standard/FPHLevelsQOTD"("Levels/Standard/FPHLevelsQOTD");
        UnityEngine.TextAsset val_3 = val_2.LoadAssetFromFolder(path:  val_2);
        bool val_4 = UnityEngine.Object.op_Equality(x:  val_3, y:  0);
        if(val_4 == false)
        {
                return val_4.ParseRawText(levelData:  val_3);
        }
        
        return 0;
    }
    private FPHLevelObject GetLevelObject(out int index)
    {
        Player val_1 = App.Player;
        Player val_5 = val_1;
        System.Collections.Generic.List<FPHLevelObject> val_6 = this.standardLevelList;
        Player val_3 = val_5 + val_1.InitialLevelOffset;
        val_3 = val_3 - 1;
        val_5 = val_3 - ((val_3 / val_6) * val_6);
        index = val_5;
        if(val_6 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (val_5 << 3);
        return 0;
    }
    private FPHLevelObject GetSpecificLevelObject(int index)
    {
        bool val_1 = true;
        if(val_1 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (index << 3);
        return (FPHLevelObject)(true + (index) << 3) + 32;
    }
    public bool CanResumeGame()
    {
        string val_11;
        var val_12;
        FPHGameplayState val_1 = new FPHGameplayState();
        val_11 = val_1.PERSISTANT_LEVEL_DATA_KEY;
        bool val_3 = CPlayerPrefs.HasKey(key:  val_11);
        if(val_3 == false)
        {
            goto label_3;
        }
        
        val_11 = val_3.PERSISTANT_LEVEL_DATA_KEY;
        bool val_6 = System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  val_11));
        if(val_6 == false)
        {
            goto label_6;
        }
        
        label_3:
        val_12 = 0;
        return (bool)FPHGameplayState.Deserialize(dataString:  CPlayerPrefs.GetString(key:  val_11 = val_6.PERSISTANT_LEVEL_DATA_KEY), stateToLoad: ref  val_1);
        label_6:
        return (bool)FPHGameplayState.Deserialize(dataString:  CPlayerPrefs.GetString(key:  val_11), stateToLoad: ref  val_1);
    }
    public void SetupLevel(ref FPHGameplayState state)
    {
        FPHGameplayState val_30;
        var val_31;
        var val_32;
        string val_33;
        var val_34;
        var val_35;
        char val_36;
        val_30 = 1152921515935531904;
        val_31 = 1152921504874684416;
        val_32 = 0;
        bool val_2 = CPlayerPrefs.HasKey(key:  this.PERSISTANT_LEVEL_DATA_KEY);
        if(val_2 != false)
        {
                val_32 = 0;
            bool val_5 = System.String.IsNullOrEmpty(value:  CPlayerPrefs.GetString(key:  val_2.PERSISTANT_LEVEL_DATA_KEY));
            if(val_5 != true)
        {
                if((FPHGameplayState.Deserialize(dataString:  CPlayerPrefs.GetString(key:  val_5.PERSISTANT_LEVEL_DATA_KEY), stateToLoad: ref  FPHGameplayState val_8 = state)) != false)
        {
                <levelData>k__BackingField = this.GetSpecificLevelObject(index:  state.<levelIndex>k__BackingField);
            val_33 = mem[state + 128];
            val_33 = state.phraseSlotCorrectValue;
            val_34 = "";
            if((val_33.Equals(value:  state.<levelData>k__BackingField.<phrase>k__BackingField.Replace(oldValue:  " ", newValue:  ""))) == true)
        {
                return;
        }
        
            object[] val_13 = new object[2];
            val_13[0] = state.phraseSlotCorrectValue;
            val_13[1] = state.<levelData>k__BackingField.<phrase>k__BackingField.Replace(oldValue:  " ", newValue:  "");
            UnityEngine.Debug.LogErrorFormat(format:  "Mismach Loading Saved Level: {0} didn\'t match level data: {1}", args:  val_13);
            FPHGameplayState val_15 = new FPHGameplayState();
            state = val_15;
        }
        
            val_32 = 0;
            CPlayerPrefs.DeleteKey(key:  val_15.PERSISTANT_LEVEL_DATA_KEY);
        }
        
        }
        
        mem[1152921515935572892] = App.Player;
        int val_18 = 0;
        mem[1152921515935572816] = this.GetLevelObject(index: out  val_18);
        val_31 = 1152921515935452352;
        mem[1152921515935572824] = val_18;
        FPHEcon val_20 = App.GetGameSpecificEcon<FPHEcon>();
        mem[1152921515935572852] = val_20.defaultTokens;
        System.Collections.Generic.List<FPHLetterSlotState> val_21 = new System.Collections.Generic.List<FPHLetterSlotState>();
        mem[1152921515935572912] = val_21;
        val_33 = state;
        val_34 = 1152921515935462592;
        var val_30 = 0;
        label_60:
        if(val_30 >= (val_19 + 32 + 16))
        {
            goto label_43;
        }
        
        if(((val_19 + 32.Chars[0]) & 65535) != ' ')
        {
                if((FPHKeyboard.IsLetter(value:  val_19 + 32.Chars[0])) != false)
        {
                val_21.Add(item:  0);
            val_35 = public System.Void System.Collections.Generic.List<System.Char>::Add(System.Char item);
            val_36 = 32;
        }
        else
        {
                val_21.Add(item:  1);
            val_35 = public System.Void System.Collections.Generic.List<System.Char>::Add(System.Char item);
            val_36 = val_19 + 32.Chars[0];
        }
        
            mem[1152921515935572920].Add(item:  val_36);
        }
        
        val_33 = state;
        val_30 = val_30 + 1;
        if(val_33 != null)
        {
            goto label_60;
        }
        
        throw new NullReferenceException();
        label_43:
        mem[1152921515935572928] = mem[1152921515935572920].Replace(oldValue:  " ", newValue:  "");
        val_30 = state;
        mem[1152921515935572944] = App.GetGameSpecificEcon<FPHEcon>().GetChestType();
    }
    public void UpdateSavedLevel(FPHGameplayState state)
    {
        string val_1 = this.PERSISTANT_LEVEL_DATA_KEY;
        if(state != null)
        {
                CPlayerPrefs.SetString(key:  val_1, val:  MiniJSON.Json.Serialize(obj:  state.Serialize()));
            CPlayerPrefs.Save();
            return;
        }
        
        CPlayerPrefs.DeleteKey(key:  val_1);
    }
    private UnityEngine.TextAsset[] LoadAssetsFromFolder(string path)
    {
        return UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  path);
    }
    private UnityEngine.TextAsset LoadAssetFromFolder(string path)
    {
        return UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  path);
    }
    public FPHDataParser()
    {
        this.currentLevelListLanguage = "";
        this.standardLevelList = new System.Collections.Generic.List<FPHLevelObject>();
        this.QAHACK_currentHackedLocale = "";
    }

}
