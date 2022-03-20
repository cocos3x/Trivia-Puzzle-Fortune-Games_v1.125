using UnityEngine;
public class App : MonoBehaviour
{
    // Fields
    protected static bool initialServerCallDone;
    protected static bool appStarted;
    protected static System.Collections.Generic.List<float> sceneLoadingTimes;
    protected static float sceneStartedLoading;
    public static System.Action onAppQuitAction;
    private static WordGames.GameNames game;
    public const string KNOBS = "knobs";
    public const string USERS = "users";
    public static readonly int SecondsToDimScreen;
    private static GameBehavior myBehavior;
    private static GameEcon myGameEcon;
    protected static System.Collections.Generic.List<AppComponent> components;
    private AppConfigs appConfigs;
    protected static AppConfigs config;
    private UnityEngine.Texture2D warningBackground;
    private UnityEngine.GUIStyle warningStyle;
    private float warningHeight;
    private static string iOSLoadingTime;
    public static bool created;
    private bool isFistSceneLoad;
    protected static UnityEngine.GameObject objectContainer;
    private static twelvegigs.storage.StorageManager storageManager;
    private static twelvegigs.net.JsonApiRequester networkManager;
    private static TrackerManager trackerManager;
    private static InAppPurchasesManager inAppPurchasesManager;
    private static DLCManager dlcManager;
    private static ThemesHandler themesHandler;
    private Player playerData;
    private static Player player;
    private static bool isQuitting;
    
    // Properties
    public static bool HasAppStarted { get; }
    public static WordGames.GameNames Game { get; set; }
    public static GameBehavior getBehavior { get; }
    public static GameEcon getGameEcon { get; }
    public virtual bool LogServer { get; }
    public virtual System.Collections.Generic.List<System.Type> GameComponents { get; }
    public virtual object[] GameComponentArguments { get; }
    public static AppConfigs Configuration { get; }
    public static string IOSLoadingTime { get; }
    public static twelvegigs.storage.StorageManager Storage { get; }
    public static twelvegigs.net.JsonApiRequester ApiRequester { get; }
    public static TrackerManager Tracker { get; }
    public static InAppPurchasesManager Purchases { get; }
    public static DLCManager DLC { get; }
    public static ThemesHandler ThemesHandler { get; }
    public static Player Player { get; }
    public static bool IsQuitting { get; }
    
    // Methods
    public static bool get_HasAppStarted()
    {
        null = null;
        return (bool)App.appStarted;
    }
    public static WordGames.GameNames get_Game()
    {
        null = null;
        return (GameNames)App.game;
    }
    public static void set_Game(WordGames.GameNames value)
    {
        null = null;
        App.game = value;
    }
    public static GameBehavior get_getBehavior()
    {
        var val_3;
        var val_5;
        GameBehavior val_7;
        val_3 = null;
        val_5 = 0;
        val_7 = App.myBehavior;
        if(val_7 != null)
        {
                val_7 = App.myBehavior;
            return val_7;
        }
        
        GameBehavior val_1 = null;
        val_7 = val_1;
        val_1 = new GameBehavior(name:  App.game);
        App.myBehavior = val_7;
        return val_7;
    }
    public static GameEcon get_getGameEcon()
    {
        var val_7;
        var val_9;
        GameEcon val_11;
        GameNames val_12;
        var val_13;
        val_7 = null;
        val_9 = 0;
        val_11 = App.myGameEcon;
        if(val_11 != null)
        {
                val_11 = App.myGameEcon;
            return val_11;
        }
        
        val_7 = null;
        val_12 = App.game;
        if(val_12 == 16)
        {
                BlockPuzzleMagic.BestBlocksGameEcon val_1 = null;
            val_11 = val_1;
            val_1 = new BlockPuzzleMagic.BestBlocksGameEcon();
        }
        else
        {
                val_7 = null;
            val_12 = App.game;
            if(val_12 == 17)
        {
                TRVEcon val_2 = null;
            val_11 = val_2;
            val_2 = new TRVEcon();
        }
        else
        {
                val_7 = null;
            val_12 = App.game;
            if(val_12 == 18)
        {
                WordForest.WFOGameEcon val_3 = null;
            val_11 = val_3;
            val_3 = new WordForest.WFOGameEcon();
        }
        else
        {
                val_12 = App.game;
            if(val_12 == 19)
        {
                FPHEcon val_4 = null;
            val_11 = val_4;
            val_4 = new FPHEcon();
        }
        else
        {
                GameEcon val_5 = null;
            val_11 = val_5;
            val_5 = new GameEcon();
        }
        
        }
        
        }
        
        }
        
        val_13 = null;
        val_13 = null;
        App.myGameEcon = val_11;
        return val_11;
    }
    public static T GetGameSpecificEcon<T>()
    {
        var val_3;
        GameEcon val_4;
        var val_5;
        var val_6;
        var val_7;
        val_3 = null;
        val_3 = null;
        val_4 = App.myGameEcon;
        if(val_4 == null)
        {
            goto label_3;
        }
        
        val_4 = App.myGameEcon;
        val_5 = null;
        if(X0 == true)
        {
            goto label_7;
        }
        
        label_3:
        val_3 = null;
        if(App.myGameEcon != null)
        {
                UnityEngine.Debug.LogError(message:  "type of " + App.myGameEcon.GetType());
        }
        
        val_6 = null;
        val_6 = null;
        App.myGameEcon = __RuntimeMethodHiddenParam + 48 + 8;
        label_7:
        val_6 = null;
        if(X0 != false)
        {
                if(X0 == true)
        {
                return (FPHEcon)val_7;
        }
        
        }
        
        val_7 = 0;
        return (FPHEcon)val_7;
    }
    public static AppComponent GetComponent(System.Type tipo)
    {
        var val_2;
        var val_3;
        System.Type val_10;
        var val_11;
        System.Collections.Generic.List<AppComponent> val_12;
        var val_13;
        var val_15;
        var val_16;
        var val_17;
        val_10 = tipo;
        val_11 = null;
        val_11 = null;
        val_12 = App.components;
        if(val_12 == null)
        {
            goto label_7;
        }
        
        val_11 = null;
        val_12 = App.components;
        if((App.components + 24) == 0)
        {
            goto label_7;
        }
        
        val_12 = App.components;
        List.Enumerator<T> val_1 = val_12.GetEnumerator();
        label_17:
        val_13 = public System.Boolean List.Enumerator<AppComponent>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_11;
        }
        
        val_15 = val_2;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Type.op_Equality(left:  val_15.GetType(), right:  val_10)) == true)
        {
            goto label_15;
        }
        
        val_13 = 0;
        System.Type val_7 = val_15.GetType();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7 & 1) == 0)
        {
            goto label_17;
        }
        
        label_15:
        val_3.Dispose();
        return (AppComponent)val_15;
        label_7:
        val_16 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_16 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_16 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_16 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184];
        val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184;
        label_36:
        D.LogClientError(developer:  "App :: Components are null", filter:  "default", context:  0, strings:  val_10);
        val_15 = 0;
        return (AppComponent)val_15;
        label_11:
        val_3.Dispose();
        string val_8 = "App :: Component "("App :: Component ") + val_10 + " not found.";
        val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        goto label_36;
    }
    public virtual bool get_LogServer()
    {
        return true;
    }
    public virtual System.Collections.Generic.List<System.Type> get_GameComponents()
    {
        return (System.Collections.Generic.List<System.Type>)new System.Collections.Generic.List<System.Type>();
    }
    public virtual object[] get_GameComponentArguments()
    {
        object[] val_1 = new object[0];
    }
    public static AppConfigs get_Configuration()
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        if(App.config == 0)
        {
                App val_2 = UnityEngine.Object.FindObjectOfType<App>();
            val_5 = null;
            val_5 = null;
            App.config = val_2.appConfigs;
        }
        else
        {
                val_5 = null;
        }
        
        val_5 = null;
        if(App.config == 0)
        {
                UnityEngine.Debug.LogError(message:  "Dashit?");
        }
        
        val_6 = null;
        val_6 = null;
        return (AppConfigs)App.config;
    }
    public static string get_IOSLoadingTime()
    {
        null = null;
        return (string)App.iOSLoadingTime;
    }
    protected void initMainModules()
    {
        UnityEngine.Object val_24;
        var val_25;
        var val_26;
        System.Action val_28;
        var val_29;
        var val_30;
        var val_31;
        UnityEngine.Object val_32;
        var val_33;
        val_24 = 0;
        if(App.Configuration == val_24)
        {
                val_24 = 0;
            UnityEngine.Debug.LogError(message:  "Couldn\'t initialize data, something is very wrong.");
        }
        
        val_25 = null;
        val_25 = null;
        if(App.networkManager == null)
        {
                AppConfigs val_3 = App.Configuration;
            val_26 = null;
            val_26 = null;
            val_28 = App.<>c.<>9__39_0;
            if(val_28 == null)
        {
                System.Action val_4 = null;
            val_24 = App.<>c.__il2cppRuntimeField_static_fields;
            val_28 = val_4;
            val_4 = new System.Action(object:  val_24, method:  System.Void App.<>c::<initMainModules>b__39_0());
            App.<>c.<>9__39_0 = val_28;
        }
        
            AppConfigs val_5 = App.Configuration;
            val_25 = null;
            App.networkManager = new twelvegigs.net.JsonApiRequester(ServerURL:  val_3.appConfig.ProductionServerURL, dequeueHandler:  val_4, logStuff:  false, adminServerURL:  val_5.appConfig.GetAdminURL(), throwExceptionsOnRequestFailures:  true);
        }
        
        val_25 = null;
        if(App.storageManager == null)
        {
                AppConfigs val_8 = App.Configuration;
            AppConfigs val_9 = App.Configuration;
            twelvegigs.storage.StorageManager val_11 = null;
            val_28 = val_11;
            val_11 = new twelvegigs.storage.StorageManager(resourcesPath:  System.String.Format(format:  "{0}/{1}", arg0:  val_8.appConfig.ResourcesDataPath, arg1:  val_9.appConfig.gamePathName));
            App.storageManager = val_28;
            val_11.initialize();
            val_25 = null;
        }
        
        val_25 = null;
        if(App.trackerManager == null)
        {
                val_25 = null;
            val_25 = null;
            App.trackerManager = TrackerManager.Instance;
        }
        
        val_25 = null;
        if(App.inAppPurchasesManager == null)
        {
                val_29 = null;
            val_29 = null;
            App.inAppPurchasesManager = InAppPurchasesManager.Instance;
        }
        
        if((DefaultHandler<PurchasesHandler>.Instance) == 0)
        {
                UnityEngine.Debug.LogError(message:  "PurchasesHandler.Instance was not instantiated for some odd reason.");
        }
        
        if((DefaultHandler<SubscriptionHandler>.Instance) == 0)
        {
                UnityEngine.Debug.LogError(message:  "SubscriptionHandler.Instance was not instantiated for some odd reason.");
        }
        
        val_30 = null;
        val_30 = null;
        if(App.dlcManager == 0)
        {
                val_31 = null;
            val_31 = null;
            App.dlcManager = this.gameObject.AddComponent<DLCManager>();
        }
        else
        {
                val_31 = null;
        }
        
        val_31 = null;
        val_32 = 0;
        if(App.themesHandler == val_32)
        {
                val_32 = public ThemesHandler UnityEngine.GameObject::AddComponent<ThemesHandler>();
            val_33 = null;
            val_33 = null;
            App.themesHandler = this.gameObject.AddComponent<ThemesHandler>();
        }
        
        UnityEngine.Application.targetFrameRate = 60;
        UnityEngine.Screen.sleepTimeout = -2;
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        bool val_12;
        var val_13;
        var val_14;
        var val_15;
        val_12 = pauseStatus;
        val_13 = null;
        val_13 = null;
        if(App.appStarted == false)
        {
                return;
        }
        
        if(val_12 != false)
        {
                Player val_1 = App.Player;
            System.DateTime val_2 = System.DateTime.UtcNow;
            val_1.properties.LastSeenDateString = val_2.dateData.ToString(format:  "yyyy-MM-dd HH:mm:ss");
            App.Player.SaveState();
        }
        else
        {
                DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        }
        
        App.pauseComponents(pauseStatus:  val_12);
        if(val_12 == true)
        {
                return;
        }
        
        if(App.Player != 0)
        {
                Player val_9 = App.Player;
            val_9.isNew = false;
        }
        
        AppConfigs val_10 = App.Configuration;
        val_12 = val_10.appConfig.Key(key:  "googlePlayKey");
        val_14 = null;
        val_14 = null;
        if(App.inAppPurchasesManager.initialized == true)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        App.inAppPurchasesManager.Init(key:  val_12);
    }
    public virtual void startApp()
    {
    
    }
    public virtual void initCustomBackend()
    {
    
    }
    public virtual void OnServerUpdatedData()
    {
    
    }
    private void Awake()
    {
        var val_7;
        var val_8;
        val_7 = null;
        val_7 = null;
        if(App.created != false)
        {
                val_8 = null;
            val_8 = null;
            if(this.gameObject == App.objectContainer)
        {
                return;
        }
        
            UnityEngine.Object.Destroy(obj:  this.gameObject);
            return;
        }
        
        this.Persist();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void App::SceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        UnityEngine.Application.add_quitting(value:  new System.Action(object:  0, method:  public static System.Void App::Quit_event()));
    }
    private void Start()
    {
        UnityEngine.Object val_4;
        UnityEngine.Debug.Log(message:  "startApp ");
        val_4 = 0;
        if(App.Player == val_4)
        {
                val_4 = 0;
            UnityEngine.Debug.Log(message:  "error creating Player");
        }
        
        this.initMainModules();
        this.awakeApp();
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    private void Persist()
    {
        var val_4;
        this.transform.parent = 0;
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        val_4 = null;
        val_4 = null;
        App.created = true;
        App.objectContainer = this.gameObject;
    }
    public void OnServerResponded(Notification notif)
    {
        goto typeof(App).__il2cppRuntimeField_1C0;
    }
    private void awakeApp()
    {
        System.Type val_4;
        var val_5;
        var val_13;
        var val_14;
        System.Object[] val_15;
        var val_16;
        val_13 = null;
        val_13 = null;
        if(App.components != null)
        {
                return;
        }
        
        val_14 = null;
        val_14 = null;
        App.components = new System.Collections.Generic.List<AppComponent>();
        System.Collections.Generic.List<AppComponent> val_2 = new System.Collections.Generic.List<AppComponent>();
        List.Enumerator<T> val_3 = this.GetEnumerator();
        label_15:
        if(val_5.MoveNext() == false)
        {
            goto label_7;
        }
        
        val_15 = this;
        object val_7 = System.Activator.CreateInstance(type:  val_4, args:  this);
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16 = val_7;
        if((val_16 & 1) == 0)
        {
            goto label_11;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  val_7);
        goto label_15;
        label_11:
        System.Threading.ThreadStart val_8 = new System.Threading.ThreadStart(object:  val_7, method:  public System.Void AppComponent::initAsynchronous());
        System.Threading.Thread val_9 = null;
        val_15 = val_8;
        val_9 = new System.Threading.Thread(start:  val_8);
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.Start();
        val_9.Join();
        goto label_15;
        label_7:
        val_5.Dispose();
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  val_5.LoadComponentsInMT(componentsInMT:  val_2));
    }
    private System.Collections.IEnumerator LoadComponentsInMT(System.Collections.Generic.List<AppComponent> componentsInMT)
    {
        .<>1__state = 0;
        .componentsInMT = componentsInMT;
        return (System.Collections.IEnumerator)new App.<LoadComponentsInMT>d__50();
    }
    public static void AddComponent(AppComponent component)
    {
        null = null;
        App.components.Add(item:  component);
    }
    public static void UpdateComponents()
    {
        null = null;
        List.Enumerator<T> val_1 = App.components.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_6;
        label_4:
        0.Dispose();
    }
    public static void InitialUpdateComponents()
    {
        null = null;
        List.Enumerator<T> val_1 = App.components.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_6;
        label_4:
        0.Dispose();
    }
    public static void startComponents()
    {
        null = null;
        List.Enumerator<T> val_1 = App.components.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_6;
        label_4:
        0.Dispose();
    }
    public static void pauseComponents(bool pauseStatus)
    {
        var val_4;
        var val_5;
        System.Collections.Generic.List<AppComponent> val_6;
        val_4 = pauseStatus;
        val_5 = null;
        val_5 = null;
        val_6 = App.components;
        if(val_6 == null)
        {
                return;
        }
        
        val_6 = App.components;
        List.Enumerator<T> val_1 = val_6.GetEnumerator();
        val_4 = val_4;
        label_9:
        if(0.MoveNext() == false)
        {
            goto label_7;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_9;
        label_7:
        0.Dispose();
    }
    private void SceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if(this.isFistSceneLoad != false)
        {
                this.isFistSceneLoad = false;
            return;
        }
        
        App.Player.SaveState();
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        App.RecordLoadingTime();
    }
    protected static void RecordLoadingTime()
    {
        System.Collections.Generic.List<T> val_4;
        var val_5;
        float val_6;
        var val_7;
        val_5 = null;
        val_5 = null;
        if(App.sceneLoadingTimes == null)
        {
                System.Collections.Generic.List<System.Single> val_1 = null;
            val_4 = val_1;
            val_1 = new System.Collections.Generic.List<System.Single>();
            val_5 = null;
            val_5 = null;
            App.sceneLoadingTimes = val_4;
        }
        
        val_5 = null;
        val_6 = App.sceneStartedLoading;
        if(val_6 == 0f)
        {
                return;
        }
        
        val_6 = App.sceneStartedLoading;
        float val_2 = UnityEngine.Time.time;
        if(val_6 >= 0)
        {
                return;
        }
        
        val_7 = null;
        val_7 = null;
        val_4 = App.sceneLoadingTimes;
        float val_3 = UnityEngine.Time.time;
        val_3 = val_3 - App.sceneStartedLoading;
        val_1.Add(item:  val_3);
        App.sceneStartedLoading = 0f;
    }
    public static System.Collections.Generic.List<float> GetLoadingTimes()
    {
        null = null;
        return (System.Collections.Generic.List<System.Single>)App.sceneLoadingTimes;
    }
    public static void StartSceneLoadingTimer()
    {
        var val_2 = null;
        App.sceneStartedLoading = UnityEngine.Time.time;
    }
    public static twelvegigs.storage.StorageManager get_Storage()
    {
        null = null;
        return (twelvegigs.storage.StorageManager)App.storageManager;
    }
    public static twelvegigs.net.JsonApiRequester get_ApiRequester()
    {
        null = null;
        return (twelvegigs.net.JsonApiRequester)App.networkManager;
    }
    public static TrackerManager get_Tracker()
    {
        null = null;
        return (TrackerManager)App.trackerManager;
    }
    public static InAppPurchasesManager get_Purchases()
    {
        null = null;
        return (InAppPurchasesManager)App.inAppPurchasesManager;
    }
    public static DLCManager get_DLC()
    {
        null = null;
        return (DLCManager)App.dlcManager;
    }
    public static ThemesHandler get_ThemesHandler()
    {
        var val_1;
        ThemesHandler val_3;
        val_1 = null;
        val_1 = null;
        val_3 = App.themesHandler;
        return (ThemesHandler);
    }
    public static Player get_Player()
    {
        var val_5;
        Player val_6;
        var val_7;
        val_5 = null;
        val_5 = null;
        val_6 = App.player;
        if(val_6 != 0)
        {
            goto label_5;
        }
        
        App val_2 = UnityEngine.Object.FindObjectOfType<App>();
        UnityEngine.ScriptableObject val_4 = UnityEngine.ScriptableObject.CreateInstance(type:  val_2.playerData.GetType());
        if(val_4 == null)
        {
            goto label_12;
        }
        
        val_2.playerData = val_4;
        val_4.Initialize();
        val_7 = null;
        val_6 = val_2.playerData;
        val_7 = null;
        App.player = val_6;
        goto label_15;
        label_5:
        val_7 = null;
        label_15:
        val_7 = null;
        return (Player)App.player;
        label_12:
        val_2.playerData = 0;
        throw new NullReferenceException();
    }
    public static void FlushConfigs()
    {
        bool val_1 = UnityEngine.Application.isEditor;
    }
    public static bool get_IsQuitting()
    {
        null = null;
        return (bool)App.isQuitting;
    }
    public static void Quit_event()
    {
        var val_1;
        System.Action val_2;
        TrackingComponent.TrackSession(sessionEnded:  true, quitButton:  false);
        val_1 = null;
        val_1 = null;
        App.isQuitting = true;
        val_2 = App.onAppQuitAction;
        if(val_2 == null)
        {
                return;
        }
        
        val_2 = App.onAppQuitAction;
        val_2.Invoke();
    }
    public static void Quit()
    {
        var val_1;
        TrackingComponent.TrackSession(sessionEnded:  true, quitButton:  true);
        val_1 = null;
        val_1 = null;
        App.isQuitting = true;
        UnityEngine.Application.Quit();
    }
    public App()
    {
        float val_2 = 0.06f;
        this.isFistSceneLoad = true;
        val_2 = (float)UnityEngine.Screen.height * val_2;
        this.warningHeight = val_2;
    }
    private static App()
    {
        App.USERS = 0;
        App.appStarted = false;
        App.onAppQuitAction = 0;
        App.SecondsToDimScreen = 25;
        App.config = 0;
        App.iOSLoadingTime = "0";
        App.created = false;
        App.player = 0;
        App.isQuitting = false;
    }

}
