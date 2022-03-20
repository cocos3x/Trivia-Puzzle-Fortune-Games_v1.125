using UnityEngine;
public class WGRestoreProgressionPopup : MonoBehaviour
{
    // Fields
    private WGPreviousProgressionPopup progressionPopup;
    private WGEmailLoginPopup emailLoginPopup;
    private UnityEngine.GameObject initLoginGroup;
    private UGUINetworkedButton appleSignInButton;
    private UGUINetworkedButton emailLogInButton;
    private UnityEngine.UI.Text versionText;
    private UnityEngine.UI.Text supportIDText;
    private UnityEngine.GameObject loggedGroup;
    private UnityEngine.UI.Button logoutButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Text loggedText;
    private UnityEngine.UI.Text l_versionText;
    private UnityEngine.UI.Text l_supportIDText;
    private UnityEngine.GameObject confirmLogoutGroup;
    private UnityEngine.UI.Button confirmLogoutButton;
    private UnityEngine.UI.Button cancelLogoutButton;
    private UnityEngine.GameObject loadingGroup;
    private UnityEngine.UI.Text titleLoading;
    private UnityEngine.UI.Text textLoading;
    private UnityEngine.GameObject reminderGroup;
    private UnityEngine.UI.Button signInButton;
    private System.Collections.Generic.List<UnityEngine.GameObject> loginGroups;
    private WGRestoreProgressionPopup.State currentState;
    private bool <showReminder>k__BackingField;
    
    // Properties
    public bool showReminder { get; set; }
    
    // Methods
    public bool get_showReminder()
    {
        return (bool)this.<showReminder>k__BackingField;
    }
    public void set_showReminder(bool value)
    {
        this.<showReminder>k__BackingField = value;
    }
    private void Awake()
    {
        System.Collections.Generic.List<UnityEngine.GameObject> val_1 = new System.Collections.Generic.List<UnityEngine.GameObject>();
        val_1.Add(item:  this.loadingGroup);
        val_1.Add(item:  this.initLoginGroup);
        val_1.Add(item:  this.loggedGroup);
        val_1.Add(item:  this.confirmLogoutGroup);
        val_1.Add(item:  this.emailLoginPopup.gameObject);
        val_1.Add(item:  this.progressionPopup.gameObject);
        val_1.Add(item:  this.reminderGroup);
        this.loginGroups = val_1;
        System.Delegate val_5 = System.Delegate.Combine(a:  this.appleSignInButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickAppleSignin(bool connected)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.appleSignInButton.OnConnectionClick = val_5;
        System.Delegate val_7 = System.Delegate.Combine(a:  this.emailLogInButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickEmailLogin(bool connected)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.emailLogInButton.OnConnectionClick = val_7;
        this.logoutButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickLogout()));
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickClose()));
        this.confirmLogoutButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickConfirmLogout()));
        this.cancelLogoutButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickCancelLogout()));
        this.progressionPopup.add_OnClickButton(value:  new System.Action<Result>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnClickProgressionPopup(WGPreviousProgressionPopup.Result result)));
        this.emailLoginPopup.add_OnLoginAction(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnLoginAction(bool waitRequest)));
        this.signInButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGRestoreProgressionPopup::<Awake>b__28_0()));
        RestoreProgressManager.add_OnServerError(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::ShowInternetError(bool isWebException)));
        RestoreProgressManager.add_OnImportResponded(value:  new System.Action<ServerResponse>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnServerResponded(RestoreProgressManager.ServerResponse response)));
        this.appleSignInButton.gameObject.SetActive(value:  SignInWithApplePlugin.IsSupported());
        return;
        label_9:
    }
    private void OnEnable()
    {
        var val_8;
        State val_9;
        string val_1 = DeviceIdPlugin.GetClientVersion();
        Player val_2 = App.Player;
        val_8 = null;
        val_8 = null;
        if(App.networkManager.Reachable() != false)
        {
                DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        }
        
        if(RestoreProgressManager.HasPreviousProgression != false)
        {
                val_9 = 3;
        }
        else
        {
                if((this.<showReminder>k__BackingField) != false)
        {
                val_9 = 6;
        }
        else
        {
                if((MonoSingleton<RestoreProgressManager>.Instance.IsLoggedIn) == false)
        {
            goto label_26;
        }
        
            val_9 = 4;
        }
        
        }
        
        label_26:
        this.UpdateState(state:  val_9);
    }
    private void OnDestroy()
    {
        RestoreProgressManager.remove_OnServerError(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::ShowInternetError(bool isWebException)));
        RestoreProgressManager.remove_OnImportResponded(value:  new System.Action<ServerResponse>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnServerResponded(RestoreProgressManager.ServerResponse response)));
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickAppleSignin(bool connected)
    {
        if(connected != false)
        {
                SignInWithApplePlugin.add_OnSignInComplete(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnAppleSignin(bool success)));
            MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.LogIn();
            return;
        }
        
        this.ShowInternetError(isWebException:  true);
    }
    private void OnAppleSignin(bool success)
    {
        SignInWithApplePlugin.remove_OnSignInComplete(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGRestoreProgressionPopup::OnAppleSignin(bool success)));
        if(success == false)
        {
            goto label_3;
        }
        
        Player val_2 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_2.properties.appleUserId)) == false)
        {
            goto label_8;
        }
        
        label_3:
        this.UpdateState(state:  0);
        return;
        label_8:
        this.ShowLoadingView();
        Player val_5 = App.Player;
        MonoSingleton<RestoreProgressManager>.Instance.OnAppleLogin(appleUserId:  val_5.properties.appleUserId);
    }
    private void OnClickLogout()
    {
        this.UpdateState(state:  5);
    }
    private void OnClickEmailLogin(bool connected)
    {
        if(connected != false)
        {
                this.UpdateState(state:  1);
            return;
        }
        
        this.ShowInternetError(isWebException:  true);
    }
    private void OnClickConfirmLogout()
    {
        this.ShowLoadingView();
        MonoSingleton<RestoreProgressManager>.Instance.LogoutRequest();
    }
    private void OnClickCancelLogout()
    {
        this.UpdateState(state:  4);
    }
    private void OnClickClose()
    {
    
    }
    private void OnLoginAction(bool waitRequest)
    {
        if(waitRequest != false)
        {
                this.ShowLoadingView();
            return;
        }
        
        this.UpdateState(state:  0);
    }
    private void OnClickProgressionPopup(WGPreviousProgressionPopup.Result result)
    {
        var val_4;
        this.ShowLoadingView();
        if(result != 2)
        {
                if(result != 1)
        {
                if(result != 0)
        {
                return;
        }
        
            RestoreProgressManager val_1 = MonoSingleton<RestoreProgressManager>.Instance;
            val_4 = 1;
        }
        else
        {
                val_4 = 0;
        }
        
            MonoSingleton<RestoreProgressManager>.Instance.ConfirmImport(importProgression:  false);
            return;
        }
        
        MonoSingleton<RestoreProgressManager>.Instance.LogoutRequest();
    }
    private void OnServerResponded(RestoreProgressManager.ServerResponse response)
    {
        if(response > 4)
        {
                return;
        }
        
        var val_1 = 32496764 + (response) << 2;
        val_1 = val_1 + 32496764;
        goto (32496764 + (response) << 2 + 32496764);
    }
    private void UpdateState(WGRestoreProgressionPopup.State state)
    {
        var val_2;
        var val_3;
        List.Enumerator<T> val_1 = this.loginGroups.GetEnumerator();
        label_4:
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_2.SetActive(value:  false);
        goto label_4;
        label_2:
        val_3.Dispose();
        this.currentState = state;
        if(state > 6)
        {
                return;
        }
        
        var val_11 = 32496736 + (state) << 2;
        val_11 = val_11 + 32496736;
        goto (32496736 + (state) << 2 + 32496736);
    }
    private void ShowLoadingView()
    {
        var val_2;
        var val_3;
        UnityEngine.UI.Text val_10;
        string val_11;
        string val_12;
        List.Enumerator<T> val_1 = this.loginGroups.GetEnumerator();
        label_4:
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_2.SetActive(value:  false);
        goto label_4;
        label_2:
        val_3.Dispose();
        this.loadingGroup.SetActive(value:  true);
        if((this.currentState - 2) < 2)
        {
                string val_6 = Localization.Localize(key:  "updating_progress_upper", defaultValue:  "UPDATING PROGRESS", useSingularKey:  false);
            val_10 = this.textLoading;
            val_11 = "updating_loading_text";
            val_12 = "Please wait while we update your progress. It may take a while.";
        }
        else
        {
                if(this.currentState == 5)
        {
                string val_7 = Localization.Localize(key:  "logout_upper", defaultValue:  "LOGOUT", useSingularKey:  false);
            val_10 = this.textLoading;
            val_11 = "logout_loading_text";
            val_12 = "Please wait while we update your saved progress. It may take a while.";
        }
        else
        {
                string val_8 = Localization.Localize(key:  "checking_progress_upper", defaultValue:  "CHECKING PROGRESS", useSingularKey:  false);
            val_10 = this.textLoading;
            val_11 = "loading_text";
            val_12 = "Please wait while we check your saved progress. It may take a while.";
        }
        
        }
        
        string val_9 = Localization.Localize(key:  val_11, defaultValue:  val_12, useSingularKey:  false);
    }
    private void ShowInternetError(bool isWebException)
    {
        var val_6;
        System.Func<System.Boolean> val_8;
        if(this.currentState != 2)
        {
                if(this.currentState != 3)
        {
            goto label_3;
        }
        
        }
        
        if(isWebException != true)
        {
                this.UpdateState(state:  this.currentState);
            if(this.currentState != 2)
        {
                return;
        }
        
            this.emailLoginPopup.ShowAlertMessage(errorCode:  true);
            return;
        }
        
        label_3:
        System.Func<System.Boolean>[] val_3 = new System.Func<System.Boolean>[1];
        val_6 = null;
        val_6 = null;
        val_8 = WGRestoreProgressionPopup.<>c.<>9__44_0;
        if(val_8 == null)
        {
                System.Func<System.Boolean> val_4 = null;
            val_8 = val_4;
            val_4 = new System.Func<System.Boolean>(object:  WGRestoreProgressionPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGRestoreProgressionPopup.<>c::<ShowInternetError>b__44_0());
            WGRestoreProgressionPopup.<>c.<>9__44_0 = val_8;
        }
        
        val_3[0] = val_8;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupInternetRequired(buttonCallbacks:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGRestoreProgressionPopup()
    {
    
    }
    private void <Awake>b__28_0()
    {
        this.UpdateState(state:  0);
    }

}
