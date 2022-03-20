using UnityEngine;
private sealed class AdViewBridgeAndroid.<>c__DisplayClass13_0
{
    // Fields
    public UnityEngine.AndroidJavaObject adView;
    
    // Methods
    public AdViewBridgeAndroid.<>c__DisplayClass13_0()
    {
    
    }
    internal void <Release>b__0()
    {
        var val_3;
        var val_4;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.adView.Call(methodName:  "destroy", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        object[] val_2 = new object[1];
        val_2[0] = this.adView;
        this.adView.Call<UnityEngine.AndroidJavaObject>(methodName:  "getParent", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call(methodName:  "removeView", args:  val_2);
    }

}
