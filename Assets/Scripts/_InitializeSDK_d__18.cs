using UnityEngine;
private sealed class ApplovinMaxPlugin.<InitializeSDK>d__18 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ApplovinMaxPlugin <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ApplovinMaxPlugin.<InitializeSDK>d__18(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        ApplovinMaxPlugin val_5;
        int val_6;
        var val_7;
        var val_8;
        val_5 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_6;
        }
        
        this.<>1__state = 0;
        val_6 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  5f);
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        val_5 = this.<>4__this;
        val_7 = null;
        val_7 = null;
        if(ApplovinMaxPlugin.initialized != true)
        {
                if(DeviceIdPlugin.IsEmulator() == false)
        {
            goto label_9;
        }
        
        }
        
        label_6:
        val_6 = 0;
        return (bool)val_6;
        label_9:
        MaxSdkCallbacks.add_OnSdkInitializedEvent(value:  new System.Action<SdkConfiguration>(object:  val_5, method:  System.Void ApplovinMaxPlugin::OnSDKInitialized(MaxSdkBase.SdkConfiguration obj)));
        AppConfigs val_4 = App.Configuration;
        MaxSdkAndroid.SetSdkKey(sdkKey:  val_4.appConfig.APPLOVIN_SDK_KEY);
        val_4.appConfig.APPLOVIN_SDK_KEY.SetupAdUnits();
        MaxSdkAndroid.InitializeSdk(adUnitIds:  0);
        val_8 = null;
        val_8 = null;
        ApplovinMaxPlugin.initialized = true;
        return (bool)val_6;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
