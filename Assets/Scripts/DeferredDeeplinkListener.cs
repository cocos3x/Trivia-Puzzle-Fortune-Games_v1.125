using UnityEngine;
private class AdjustAndroid.DeferredDeeplinkListener : AndroidJavaProxy
{
    // Fields
    private System.Action<string> callback;
    
    // Methods
    public AdjustAndroid.DeferredDeeplinkListener(System.Action<string> pCallback)
    {
        this.callback = pCallback;
    }
    public bool launchReceivedDeeplink(UnityEngine.AndroidJavaObject deeplink)
    {
        var val_2;
        var val_3;
        if(this.callback == null)
        {
                return (bool)com.adjust.sdk.AdjustAndroid.launchDeferredDeeplink;
        }
        
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        this.callback.Invoke(obj:  deeplink.Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184));
        return (bool)com.adjust.sdk.AdjustAndroid.launchDeferredDeeplink;
    }

}
