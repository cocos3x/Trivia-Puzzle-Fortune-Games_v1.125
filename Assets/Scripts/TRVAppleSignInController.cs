using UnityEngine;
public class TRVAppleSignInController : MonoBehaviour
{
    // Fields
    private UGUINetworkedButton appleSignInButton;
    
    // Methods
    private void Awake()
    {
        var val_10;
        System.Delegate val_2 = System.Delegate.Combine(a:  this.appleSignInButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVAppleSignInController::OnClickAppleSignin(bool connected)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.appleSignInButton.OnConnectionClick = val_2;
        RestoreProgressManager.add_OnServerError(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVAppleSignInController::ShowInternetError(bool isWebException)));
        UnityEngine.GameObject val_4 = this.appleSignInButton.gameObject;
        if(SignInWithApplePlugin.IsSupported() == false)
        {
            goto label_7;
        }
        
        val_10 = FacebookPlugin.IsLoggedIn ^ 1;
        if(val_4 != null)
        {
            goto label_10;
        }
        
        label_7:
        val_10 = 0;
        label_10:
        val_4.SetActive(value:  val_10 & 1);
        if(SignInWithApplePlugin.IsSupported() == false)
        {
                return;
        }
        
        if(SignInWithApplePlugin.IsLoggedIn == false)
        {
                return;
        }
        
        this.SetButtonSignedIn();
        return;
        label_3:
    }
    private void OnEnable()
    {
        null = null;
        if(App.networkManager.Reachable() == false)
        {
                return;
        }
        
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    private void OnClickAppleSignin(bool connected)
    {
        if(connected != false)
        {
                SignInWithApplePlugin.add_OnSignInComplete(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVAppleSignInController::OnAppleSignin(bool success)));
            MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.LogIn();
            return;
        }
        
        this.ShowInternetError(isWebException:  false);
    }
    private void OnAppleSignin(bool success)
    {
        SignInWithApplePlugin.remove_OnSignInComplete(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVAppleSignInController::OnAppleSignin(bool success)));
        if(success != false)
        {
                Player val_2 = App.Player;
            if((System.String.IsNullOrEmpty(value:  val_2.properties.appleUserId)) != true)
        {
                Player val_5 = App.Player;
            MonoSingleton<RestoreProgressManager>.Instance.OnAppleLogin(appleUserId:  val_5.properties.appleUserId);
        }
        
        }
        
        this.SetButtonSignedIn();
        if((this.gameObject.GetComponent<WGSettingsMiniPopup>()) == 0)
        {
                return;
        }
        
        this.gameObject.GetComponent<WGSettingsMiniPopup>().SetFacebookButtons();
    }
    private void SetButtonSignedIn()
    {
        if(this.appleSignInButton != null)
        {
                this.appleSignInButton.interactable = false;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void ShowInternetError(bool isWebException)
    {
        var val_6;
        System.Func<System.Boolean> val_8;
        System.Func<System.Boolean>[] val_3 = new System.Func<System.Boolean>[1];
        val_6 = null;
        val_6 = null;
        val_8 = TRVAppleSignInController.<>c.<>9__6_0;
        if(val_8 == null)
        {
                System.Func<System.Boolean> val_4 = null;
            val_8 = val_4;
            val_4 = new System.Func<System.Boolean>(object:  TRVAppleSignInController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVAppleSignInController.<>c::<ShowInternetError>b__6_0());
            TRVAppleSignInController.<>c.<>9__6_0 = val_8;
        }
        
        val_3[0] = val_8;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupInternetRequired(buttonCallbacks:  val_3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDestroy()
    {
        RestoreProgressManager.remove_OnServerError(value:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVAppleSignInController::ShowInternetError(bool isWebException)));
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVAppleSignInController()
    {
    
    }

}
