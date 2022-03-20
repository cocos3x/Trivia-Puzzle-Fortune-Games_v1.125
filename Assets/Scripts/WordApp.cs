using UnityEngine;
public class WordApp : App
{
    // Fields
    public const string NATIVE_CALLBACKS = "NativeCallbacks";
    public const string ON_DEFERRED_READY = "OnDeferredReady";
    public const string ON_SERVER_DATA_SYNC = "OnServerSync";
    public static System.Action DeferredServerDataReady;
    public static UnityEngine.Events.UnityEvent DeferredGameUIReadyEvent;
    private static bool deferredEventHasFired;
    public const string CACHED_LEVEL_GEN_VERSION_KEY = "c_lgv";
    public const string LEVEL_GEN_VERSION_KEY = "lgv";
    public const int MIN_LEVEL_GEN_VERSION = 1;
    public const int MAX_LEVEL_GEN_VERSION = 2;
    public const int DEFAULT_LEVEL_GEN_VERSION = 2;
    public static int CurrentlyLoadedLevelGenVersion;
    
    // Properties
    public static bool DeferredEventHasFired { get; }
    public static string GamePathName { get; }
    public override System.Collections.Generic.List<System.Type> GameComponents { get; }
    public override object[] GameComponentArguments { get; }
    public static int LevelGenVersionToUse { get; }
    
    // Methods
    public static bool get_DeferredEventHasFired()
    {
        null = null;
        return (bool)WordApp.deferredEventHasFired;
    }
    public static string get_GamePathName()
    {
        return WordApp.GetGamePathName();
    }
    public static AppConfigs getConfig()
    {
        return App.Configuration;
    }
    public override System.Collections.Generic.List<System.Type> get_GameComponents()
    {
        System.Collections.Generic.List<System.Type> val_1 = new System.Collections.Generic.List<System.Type>();
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(item:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        return val_1;
    }
    public override object[] get_GameComponentArguments()
    {
        int val_3;
        object[] val_1 = new object[2];
        AppConfigs val_2 = App.Configuration;
        val_3 = val_1.Length;
        val_1[0] = val_2.appConfig.gameName;
        val_3 = val_1.Length;
        val_1[1] = "NativeCallbacks";
        return (System.Object[])val_1;
    }
    public override void OnServerUpdatedData()
    {
        var val_2;
        var val_4;
        this.UpdateData();
        val_2 = null;
        val_4 = 0;
        if(App.USERS != null)
        {
                App.UpdateComponents();
            return;
        }
        
        App.USERS = 1;
        App.InitialUpdateComponents();
    }
    private void UpdateData()
    {
        NotificationCenter val_1 = NotificationCenter.DefaultCenter;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.PostNotification(aSender:  0, aName:  "OnServerSync");
        GameEcon val_2 = App.getGameEcon;
        WordApp.CheckLevelGenMode();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  null.SendDeferredServerDataReadyCallback());
    }
    private System.Collections.IEnumerator SendDeferredServerDataReadyCallback()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new WordApp.<SendDeferredServerDataReadyCallback>d__17();
    }
    public override void startApp()
    {
        var val_7;
        var val_8;
        val_7 = null;
        val_7 = null;
        WordGames.currentGame = App.game;
        AppConfigs val_1 = App.Configuration;
        Localization.SetGameName(gameName:  val_1.appConfig.gameName);
        if(App.appStarted != false)
        {
                return;
        }
        
        val_8 = 1152921504884273153;
        App.appStarted = true;
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.StartCoroutine(routine:  App.getGameEcon.SendDeferredAppStartNotification()).PingForDeeplink());
        Logger.Init();
        UnityEngine.Screen.sleepTimeout = 0;
    }
    private System.Collections.IEnumerator PingForDeeplink()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new WordApp.<PingForDeeplink>d__19();
    }
    private System.Collections.IEnumerator SendDeferredAppStartNotification()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new WordApp.<SendDeferredAppStartNotification>d__20();
    }
    public override void initCustomBackend()
    {
        this.initCustomBackend();
    }
    private static string GetGamePathName()
    {
        AppConfigs val_1 = App.Configuration;
        return (string)val_1.appConfig.gamePathName;
    }
    public static WordGames.GameNames GetGameEnum(string game)
    {
        string val_10;
        var val_11;
        object val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        val_10 = game;
        System.Array val_2 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = val_2.GetEnumerator();
        label_19:
        var val_11 = 0;
        val_11 = val_11 + 1;
        if(val_11.MoveNext() == false)
        {
            goto label_11;
        }
        
        var val_12 = 0;
        val_12 = val_12 + 1;
        if(val_11.Current == null)
        {
                throw new NullReferenceException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  null.ToString(), b:  val_10)) == false)
        {
            goto label_19;
        }
        
        val_14 = null;
        val_15 = 89;
        val_16 = 0;
        val_10 = 0;
        goto label_20;
        label_11:
        val_15 = 87;
        val_16 = 0;
        val_10 = 0;
        val_14 = 0;
        label_20:
        if(X0 == false)
        {
            goto label_21;
        }
        
        var val_15 = X0;
        val_11 = X0;
        if((X0 + 294) == 0)
        {
            goto label_25;
        }
        
        var val_13 = X0 + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_24:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_23;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (X0 + 294))
        {
            goto label_24;
        }
        
        goto label_25;
        label_23:
        val_15 = val_15 + (((X0 + 176 + 8)) << 4);
        val_17 = val_15 + 304;
        label_25:
        val_11.Dispose();
        label_21:
        if(val_10 != 0)
        {
                throw val_10;
        }
        
        if(val_16 != 1)
        {
                var val_10 = (87 == 89) ? (val_14) : (0 + 1);
            return (GameNames)val_18;
        }
        
        val_18 = 1;
        return (GameNames)val_18;
    }
    public static int get_LevelGenVersionToUse()
    {
        var val_7;
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) != false)
        {
                val_7 = 1;
            return (int)val_7;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "c_lgv")) != false)
        {
                int val_5 = UnityEngine.PlayerPrefs.GetInt(key:  "c_lgv");
            val_7 = 2;
            if(val_5 > 2)
        {
                return (int)val_7;
        }
        
            var val_6 = (val_5 < 1) ? (val_7) : (val_5);
            return (int)val_7;
        }
        
        val_7 = 2;
        return (int)val_7;
    }
    private static void CheckLevelGenMode()
    {
        System.Collections.IDictionary val_14;
        var val_15;
        var val_16;
        var val_17;
        int val_18;
        var val_19;
        int val_21;
        var val_22;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_14 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_15 = null;
        val_15 = null;
        if(getWordGameplayKnobs() != null)
        {
                val_14 = val_2.dataSource;
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if((val_1.ContainsKey(key:  "lgv")) != false)
        {
                bool val_6 = System.Int32.TryParse(s:  val_1.Item["lgv"], result: out  2);
        }
        
        GameBehavior val_7 = App.getBehavior;
        if((System.String.op_Inequality(a:  val_7.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) != false)
        {
                val_16 = 1;
        }
        else
        {
                val_16 = val_16;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "c_lgv", value:  1);
        GameBehavior val_10 = App.getBehavior;
        if(((val_10.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "c_lgv", value:  1);
        }
        
        val_17 = null;
        val_17 = null;
        val_18 = WordApp.CurrentlyLoadedLevelGenVersion;
        if(val_18 == 1)
        {
                return;
        }
        
        val_17 = null;
        val_18 = WordApp.CurrentlyLoadedLevelGenVersion;
        var val_15 = 2;
        val_15 = (1 < 3) ? ((1 < 1) ? (val_15) : 1) : (val_15);
        if(val_18 == val_15)
        {
                return;
        }
        
        if(1 == 1)
        {
                MonoSingletonSelfGenerating<WADataParser>.Instance.CallEmptyMethod();
            val_19 = null;
            val_19 = null;
            val_21 = 1;
        }
        else
        {
                if(1 != 2)
        {
                if((1 - 1) < 2)
        {
                return;
        }
        
        }
        
            MonoSingletonSelfGenerating<WordLevelGen>.Instance.CallEmptyMethod();
            val_22 = null;
            val_22 = null;
            val_21 = 2;
        }
        
        WordApp.CurrentlyLoadedLevelGenVersion = val_21;
    }
    public static int SanitizeLevelGenVersion(int input)
    {
        if(input > 2)
        {
                return 2;
        }
        
        return (int)(input < 1) ? 2 : input;
    }
    public static void LanguageChanged()
    {
        WordApp.CheckLevelGenMode();
    }
    public WordApp()
    {
    
    }
    private static WordApp()
    {
        WordApp.DEFAULT_LEVEL_GEN_VERSION = 0;
        WordApp.DEFAULT_LEVEL_GEN_VERSION.__il2cppRuntimeField_3 = 0;
        WordApp.DeferredGameUIReadyEvent = new UnityEngine.Events.UnityEvent();
        WordApp.deferredEventHasFired = false;
        WordApp.CurrentlyLoadedLevelGenVersion = 0;
    }

}
