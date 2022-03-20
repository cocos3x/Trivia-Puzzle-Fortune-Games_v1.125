using UnityEngine;
public class WGLeaguesLoadingPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text hintText;
    public bool isFlyout;
    private static bool loadingLeagues;
    public System.Action onLeaguesExitAction;
    
    // Properties
    public static bool LoadingLeagues { get; }
    private System.Collections.Generic.List<string[]> hints { get; }
    
    // Methods
    public static bool get_LoadingLeagues()
    {
        null = null;
        return (bool)WGLeaguesLoadingPopup.loadingLeagues;
    }
    private System.Collections.Generic.List<string[]> get_hints()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_910;
    }
    private void Start()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGLeaguesLoadingPopup::OnSceneUnloaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneUnloaded = val_3;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnNetworkConnectivityResponse");
        return;
        label_5:
    }
    private void OnSceneUnloaded(SceneType sceneType)
    {
        if(sceneType != 4)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnEnable()
    {
        var val_10 = 1152921515528589184;
        CameraManagerUGUI val_1 = MonoSingletonSelfGenerating<CameraManagerUGUI>.Instance;
        val_1.TakeCameraStateSnapshot();
        System.Collections.Generic.List<System.String[]> val_3 = val_1.hints.hints;
        int val_4 = UnityEngine.Random.Range(min:  0, max:  0);
        if(val_10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (val_4 << 3);
        string val_5 = Localization.Localize(key:  (1152921515528589184 + (val_4) << 3) + 32 + 32, defaultValue:  (1152921515528589184 + (val_4) << 3) + 32 + 32 + 8, useSingularKey:  false);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  11.ToString());
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.DelayLoadLeagues());
    }
    private System.Collections.IEnumerator DelayLoadLeagues()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLeaguesLoadingPopup.<DelayLoadLeagues>d__11();
    }
    private System.Collections.IEnumerator OnDataUpdate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLeaguesLoadingPopup.<OnDataUpdate>d__12();
    }
    private void OnNetworkConnectivityResponse()
    {
        null = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                return;
        }
        
        this.OnError_Null_Response();
    }
    private void OnError_Null_Response()
    {
        int val_11;
        var val_12;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  9.ToString());
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_11 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "return_home_upper", defaultValue:  "RETURN HOME", useSingularKey:  false);
        val_11 = val_9.Length;
        val_9[1] = "";
        val_12 = null;
        val_12 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "connection_lost_upper", defaultValue:  "CONNECTION LOST", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "league_requires_connection", defaultValue:  "Leagues Requires a Network Connection", useSingularKey:  false), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private System.Collections.IEnumerator WaitLoadLeagues()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLeaguesLoadingPopup.<WaitLoadLeagues>d__15();
    }
    private void OnDisable()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void WGLeaguesLoadingPopup::OnSceneUnloaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneUnloaded = val_3;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnNetworkConnectivityResponse");
        if(this.isFlyout == false)
        {
            goto label_9;
        }
        
        if(this.onLeaguesExitAction == null)
        {
            goto label_13;
        }
        
        UnityEngine.Debug.LogError(message:  "WGLeaguesLoadingPopup warning - unexpectedly triggering onLeaguesExitAction on a flyout that is getting disabled/destroyed.");
        label_9:
        if(this.onLeaguesExitAction != null)
        {
                this.onLeaguesExitAction.Invoke();
        }
        
        label_13:
        this.onLeaguesExitAction = 0;
        return;
        label_5:
    }
    public WGLeaguesLoadingPopup()
    {
    
    }
    private static WGLeaguesLoadingPopup()
    {
    
    }

}
