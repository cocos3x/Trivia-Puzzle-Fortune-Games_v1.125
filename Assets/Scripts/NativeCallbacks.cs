using UnityEngine;
public class NativeCallbacks : MonoSingleton<NativeCallbacks>
{
    // Fields
    private static bool created;
    private static bool tokenReceived;
    private static int remoteCount;
    private static UnityEngine.GameObject objectContainer;
    private static bool sentLowMemoryWarning;
    
    // Methods
    public override void InitMonoSingleton()
    {
        null = null;
        NativeCallbacks.created = true;
        UnityEngine.Object.DontDestroyOnLoad(target:  this.gameObject);
        NativeCallbacks.objectContainer = this.gameObject;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NativeCallbacks::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        LoadingDialogPlugin.RemoveView();
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void NativeCallbacks::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
    }
    private void Update()
    {
        null = null;
        if(NativeCallbacks.tokenReceived != false)
        {
                return;
        }
        
        updateDeviceToken();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        null = null;
        if(NativeCallbacks.objectContainer != this.gameObject)
        {
                UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        
        this.CancelInvoke();
    }
    private void OnDeferredReady()
    {
        FacebookPlugin.SendAccessToken();
    }
    private int tapMultiplier(int taps)
    {
        return (int)taps;
    }
    private void OnAdxReferral(string referral)
    {
        var val_3;
        if((System.String.op_Inequality(a:  UnityEngine.PlayerPrefs.GetString(key:  "adxReferral", defaultValue:  "none"), b:  "none")) != false)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        App.trackerManager.superProperty(propertyName:  "Referral", propertyValue:  referral);
        UnityEngine.PlayerPrefs.SetString(key:  "adxReferral", value:  referral);
    }
    public void OnAppRated(string message)
    {
    
    }
    private void OnFacebookRequestAppUserId(string message)
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  message);
        UnityEngine.PlayerPrefs.SetString(key:  "facebook_app_user_id", value:  ((System.String.op_Equality(a:  message, b:  "fail")) != true) ? "sent" : message);
    }
    private static void setVideoWatcher()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "reward_watcher")) != false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "reward_watcher", value:  1);
    }
    public static void OnLowMemory(string usageRatio)
    {
    
    }
    private void updateMetaData(string message)
    {
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.UpdateMetadata();
    }
    private void handleRemoteNotification(string issueId)
    {
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.handleRemoteNotification(issueId:  issueId);
    }
    private void updateDeviceToken()
    {
        var val_4 = null;
        NativeCallbacks.tokenReceived = MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.UpdateDeviceToken();
    }
    private void ReceivedLowMemWarning(string fromNative)
    {
        string val_2;
        var val_3;
        var val_4;
        val_2 = fromNative;
        val_3 = null;
        val_3 = null;
        if(NativeCallbacks.sentLowMemoryWarning == true)
        {
                return;
        }
        
        val_2 = "NativeCallbacks. Low Memory Warning on iOS. " + val_2;
        UnityEngine.Debug.LogError(message:  val_2);
        val_4 = null;
        val_4 = null;
        NativeCallbacks.sentLowMemoryWarning = true;
    }
    private void IOSDidRegisterForNotifications(string message)
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnPushNotificationsChangedV22");
    }
    public NativeCallbacks()
    {
    
    }
    private static NativeCallbacks()
    {
    
    }

}
