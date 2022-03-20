using UnityEngine;
public class Bootstrapper : MonoSingleton<Bootstrapper>
{
    // Fields
    private System.Action SceneLoadQueued;
    private System.Action unloadAfterAsyncLoad;
    private bool hasHandled;
    private bool canLoadScenes;
    private const string pref_saved_minigame = "slc_mini";
    private string currentMinigameString;
    private int _CurrentMinigame;
    private const string pref_saved_from_deeplink = "slc_mini_dplnk";
    private const string pref_deeplinked_minigame = "slc_mini_which_dplnk";
    private const string pref_deeplink_consumed = "slc_deeplink_consumed";
    public bool IsLoadingScene;
    
    // Properties
    public int CurrentMinigame { get; set; }
    public bool HasEnteredMainGame { get; set; }
    public int DeeplinkedWhichMinigame { get; set; }
    public bool DeeplinkConsumed { get; set; }
    
    // Methods
    public int get_CurrentMinigame()
    {
        int val_2 = this._CurrentMinigame;
        if(val_2 != 1)
        {
                return val_1;
        }
        
        val_2 = "slc_mini";
        int val_1 = UnityEngine.PlayerPrefs.GetInt(key:  val_2, defaultValue:  0);
        this._CurrentMinigame = val_1;
        return val_1;
    }
    public void set_CurrentMinigame(int value)
    {
        this._CurrentMinigame = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "slc_mini", value:  value);
    }
    public bool get_HasEnteredMainGame()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "slc_mini_dplnk", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public void set_HasEnteredMainGame(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "slc_mini_dplnk", value:  value);
    }
    public int get_DeeplinkedWhichMinigame()
    {
        return CPlayerPrefs.GetInt(key:  "slc_mini_which_dplnk", defaultValue:  0);
    }
    public void set_DeeplinkedWhichMinigame(int value)
    {
        CPlayerPrefs.SetInt(key:  "slc_mini_which_dplnk", val:  value);
    }
    public bool get_DeeplinkConsumed()
    {
        return UnityEngine.PlayerPrefs.HasKey(key:  "slc_deeplink_consumed");
    }
    public void set_DeeplinkConsumed(bool value)
    {
        if(value != false)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "slc_deeplink_consumed", value:  "consumed");
            return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "slc_deeplink_consumed");
    }
    public override void InitMonoSingleton()
    {
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        NotificationCenter val_2 = NotificationCenter.DefaultCenter;
        val_2.AddObserver(observer:  this, name:  "UnlockSceneLoading");
        if(val_2.HasEnteredMainGame == true)
        {
                return;
        }
        
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void Bootstrapper::SceneManager_sceneLoaded(SceneType sceneType)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_4.OnSceneLoaded = val_6;
        return;
        label_11:
    }
    private void SceneManager_sceneLoaded(SceneType sceneType)
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        val_1.<metaGameBehavior>k__BackingField.HasEnteredMainGame = true;
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void Bootstrapper::SceneManager_sceneLoaded(SceneType sceneType)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_3.OnSceneLoaded = val_5;
        return;
        label_12:
    }
    private void UnlockSceneLoading()
    {
        this.canLoadScenes = true;
        if(this.SceneLoadQueued != null)
        {
                this.SceneLoadQueued.Invoke();
        }
        
        this.SceneLoadQueued = 0;
    }
    public void HandleDeeplinkIntoMinigame(int minigame)
    {
        AppConfigs val_1 = App.Configuration;
        if(val_1.minigamesConfig.minigames == null)
        {
            goto label_6;
        }
        
        val_2.properties.InstalledFromMGDeeplink = true;
        App.Player.HasEnteredMainGame = false;
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        this.CurrentMinigame = minigame;
        this.DeeplinkedWhichMinigame = minigame;
        if(this.canLoadScenes == false)
        {
            goto label_13;
        }
        
        this.LoadScene(sceneToLoad:  3, redirectToGameplay:  false);
        this.hasHandled = true;
        return;
        label_6:
        this.HandleNoDeeplinkMinigame();
        return;
        label_13:
        this.SceneLoadQueued = new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkContinue());
    }
    public void HandleNoDeeplinkMinigame()
    {
        if(this.hasHandled == false)
        {
            goto label_1;
        }
        
        label_2:
        this.SceneLoadQueued = new System.Action(object:  this, method:  System.Void Bootstrapper::NoDeeplinkContinue());
        return;
        label_1:
        if(this.canLoadScenes == false)
        {
            goto label_2;
        }
        
        this.NoDeeplinkContinue();
    }
    public void HandleDeeplinkMainGame()
    {
        if(this.hasHandled == false)
        {
            goto label_1;
        }
        
        label_2:
        this.SceneLoadQueued = new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkMainGameContinue());
        return;
        label_1:
        if(this.canLoadScenes == false)
        {
            goto label_2;
        }
        
        this.DeeplinkMainGameContinue();
    }
    private void NoDeeplinkContinue()
    {
        SceneType val_3;
        int val_1 = this.CurrentMinigame;
        if(val_1 >= 1)
        {
                if(val_1.HasEnteredMainGame == false)
        {
            goto label_1;
        }
        
        }
        
        val_3 = 1;
        goto label_2;
        label_1:
        val_3 = 3;
        label_2:
        this.LoadScene(sceneToLoad:  val_3, redirectToGameplay:  false);
        this.hasHandled = true;
    }
    private void DeeplinkContinue()
    {
        this.LoadScene(sceneToLoad:  3, redirectToGameplay:  false);
        this.hasHandled = true;
    }
    private void DeeplinkMainGameContinue()
    {
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        val_11 = null;
        val_11 = null;
        if(App.game == 16)
        {
            goto label_43;
        }
        
        val_12 = null;
        val_12 = null;
        if(App.game == 17)
        {
            goto label_43;
        }
        
        val_13 = null;
        val_13 = null;
        if(App.game == 12)
        {
            goto label_43;
        }
        
        val_14 = null;
        val_14 = null;
        if(App.game == 19)
        {
            goto label_43;
        }
        
        val_15 = null;
        val_15 = null;
        if(App.game == 20)
        {
            goto label_43;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_35;
        }
        
        WordLevelGen val_2 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
        if(val_2.initialized == false)
        {
            goto label_39;
        }
        
        label_43:
        this.LoadScene(sceneToLoad:  2, redirectToGameplay:  false);
        this.hasHandled = true;
        return;
        label_35:
        WADataParser val_3 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(val_3.initialized == true)
        {
            goto label_43;
        }
        
        label_39:
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                WordLevelGen val_5 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnWordLevelGenInit, b:  new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkMainGameCallback()));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_59;
        }
        
        }
        
            val_5.OnWordLevelGenInit = val_7;
            return;
        }
        
        WADataParser val_8 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        System.Delegate val_10 = System.Delegate.Combine(a:  val_8.OnWADataParseInit, b:  new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkMainGameCallback()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_59;
        }
        
        }
        
        val_8.OnWADataParseInit = val_10;
        return;
        label_59:
    }
    private void DeeplinkMainGameCallback()
    {
        System.Action val_8;
        this.LoadScene(sceneToLoad:  2, redirectToGameplay:  false);
        this.hasHandled = true;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                WordLevelGen val_2 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            val_8 = val_2.OnWordLevelGenInit;
            System.Delegate val_4 = System.Delegate.Remove(source:  val_8, value:  new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkMainGameCallback()));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
            val_2.OnWordLevelGenInit = val_4;
            return;
        }
        
        WADataParser val_5 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        val_8 = val_5.OnWADataParseInit;
        System.Delegate val_7 = System.Delegate.Remove(source:  val_8, value:  new System.Action(object:  this, method:  System.Void Bootstrapper::DeeplinkMainGameCallback()));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        val_5.OnWADataParseInit = val_7;
        return;
        label_16:
    }
    public void HandlePlayMinigame(int minigame)
    {
        this.unloadAfterAsyncLoad = 0;
        this.CurrentMinigame = minigame;
        this.LoadScene(sceneToLoad:  3, redirectToGameplay:  false);
    }
    public void HandleLeaveMinigame(bool redirectToGameplay, string currentGame)
    {
        this.currentMinigameString = currentGame;
        this.LoadScene(sceneToLoad:  1, redirectToGameplay:  redirectToGameplay);
        if(this.unloadAfterAsyncLoad != null)
        {
                return;
        }
        
        this.unloadAfterAsyncLoad = new System.Action(object:  this, method:  System.Void Bootstrapper::UnloadMinigameScene());
    }
    private void UnloadMinigameScene()
    {
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.AsyncOperation val_2 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_1.<metaGameBehavior>k__BackingField);
        this.unloadAfterAsyncLoad = 0;
        this.currentMinigameString = "";
    }
    private void LoadScene(SceneType sceneToLoad, bool redirectToGameplay = False)
    {
        string val_17;
        string val_18;
        if(this.IsLoadingScene == true)
        {
                return;
        }
        
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        GameBehavior val_3 = App.getBehavior;
        val_17 = val_3.<metaGameBehavior>k__BackingField;
        if(sceneToLoad == 3)
        {
            goto label_8;
        }
        
        if(App.ThemesHandler != 0)
        {
                if((System.String.IsNullOrEmpty(value:  App.ThemesHandler.CurrentThemeName)) == false)
        {
            goto label_17;
        }
        
        }
        
        val_18 = "";
        goto label_18;
        label_17:
        val_18 = "_" + App.ThemesHandler.CurrentThemeName;
        label_18:
        val_17 = val_17 + val_18;
        label_8:
        UnityEngine.Coroutine val_16 = this.StartCoroutine(routine:  this.LoadSceneAsync(sceneName:  val_17, lastScene:  val_1.m_Handle.name, killManagers:  (sceneToLoad == 3) ? 1 : 0, redirectToGameplay:  redirectToGameplay));
    }
    private System.Collections.IEnumerator LoadSceneAsync(string sceneName, string lastScene, bool killManagers, bool redirectToGameplay)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .sceneName = sceneName;
        .lastScene = lastScene;
        .killManagers = killManagers;
        .redirectToGameplay = redirectToGameplay;
        return (System.Collections.IEnumerator)new Bootstrapper.<LoadSceneAsync>d__37();
    }
    public Bootstrapper()
    {
        this._CurrentMinigame = 0;
        this.currentMinigameString = "";
    }

}
