using UnityEngine;
public class SignInWithApplePlugin : MonoSingletonSelfGenerating<SignInWithApplePlugin>
{
    // Fields
    public const string DefaultPlayerName = "Player";
    private static bool _knobEnabled;
    private static System.Action<bool> OnSignInComplete;
    public const string OnApplePluginUpdate = "OnApplePluginUpdate";
    private bool initialized;
    private string appleUserId;
    private static float _ios_version;
    
    // Properties
    public static bool IsLoggedIn { get; }
    public static bool KnobEnabled { get; }
    
    // Methods
    public static void add_OnSignInComplete(System.Action<bool> value)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        do
        {
            if((System.Delegate.Combine(a:  SignInWithApplePlugin.OnSignInComplete, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
            val_3 = null;
            val_3 = null;
        }
        while(SignInWithApplePlugin.OnSignInComplete != 1152921504889438216);
        
        return;
        label_4:
    }
    public static void remove_OnSignInComplete(System.Action<bool> value)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        do
        {
            if((System.Delegate.Remove(source:  SignInWithApplePlugin.OnSignInComplete, value:  value)) != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
            val_3 = null;
            val_3 = null;
        }
        while(SignInWithApplePlugin.OnSignInComplete != 1152921504889438216);
        
        return;
        label_4:
    }
    public static bool get_IsLoggedIn()
    {
        var val_4;
        var val_5;
        var val_6;
        val_4 = null;
        val_4 = null;
        if((MonoSingletonSelfGenerating<T>._Instance) == 0)
        {
                val_5 = 0;
        }
        else
        {
                val_6 = null;
            val_6 = null;
            bool val_2 = System.String.IsNullOrEmpty(value:  MonoSingletonSelfGenerating<T>._Instance + 32);
            val_5 = val_2 ^ 1;
        }
        
        val_2 = val_5;
        return (bool)val_2;
    }
    public static bool get_KnobEnabled()
    {
        null = null;
        return (bool)SignInWithApplePlugin.OnApplePluginUpdate;
    }
    public static bool IsSupported()
    {
        return false;
    }
    public bool IsSignInAvailable()
    {
        return false;
    }
    private void Start()
    {
    
    }
    public void Init()
    {
        if(this.initialized == true)
        {
                return;
        }
        
        this.initialized = true;
        this.UpdateKnob();
    }
    public void OnServerResponded()
    {
        NotificationCenter val_1 = NotificationCenter.DefaultCenter;
        val_1.RemoveObserver(observer:  this, name:  "OnServerResponded");
        val_1.UpdateKnob();
    }
    public void UpdateCredentialStatus()
    {
    
    }
    public void LogIn()
    {
    
    }
    public void Logout()
    {
        Player val_1 = App.Player;
        val_1.email = System.String.alignConst;
        Player val_2 = App.Player;
        val_2.properties._profile_name = "Player";
        Player val_3 = App.Player;
        val_3.properties.appleUserId = System.String.alignConst;
        this.appleUserId = System.String.alignConst;
    }
    private static float iOSVersion()
    {
        return 0f;
    }
    private void UpdateKnob()
    {
        bool val_6;
        var val_7;
        var val_8;
        var val_9;
        val_6 = 1152921504884269056;
        val_7 = null;
        val_7 = null;
        if((getGameplayKnobs().Contains(key:  "asi")) == false)
        {
                return;
        }
        
        val_8 = null;
        val_8 = null;
        val_6 = getGameplayKnobs().getBool(key:  "asi");
        val_9 = null;
        val_9 = null;
        SignInWithApplePlugin.OnApplePluginUpdate = val_6;
    }
    public SignInWithApplePlugin()
    {
        this.appleUserId = System.String.alignConst;
    }
    private static SignInWithApplePlugin()
    {
        SignInWithApplePlugin.OnApplePluginUpdate = 1;
        SignInWithApplePlugin._ios_version = 0f;
    }

}
