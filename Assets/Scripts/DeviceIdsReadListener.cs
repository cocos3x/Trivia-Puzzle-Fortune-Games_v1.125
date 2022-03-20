using UnityEngine;
private class AdjustAndroid.DeviceIdsReadListener : AndroidJavaProxy
{
    // Fields
    private System.Action<string> onPlayAdIdReadCallback;
    
    // Methods
    public AdjustAndroid.DeviceIdsReadListener(System.Action<string> pCallback)
    {
        this.onPlayAdIdReadCallback = pCallback;
    }
    public void onGoogleAdIdRead(string playAdId)
    {
        if(this.onPlayAdIdReadCallback == null)
        {
                return;
        }
        
        this.onPlayAdIdReadCallback.Invoke(obj:  playAdId);
    }
    public void onGoogleAdIdRead(UnityEngine.AndroidJavaObject ajoAdId)
    {
        var val_2;
        var val_3;
        string val_4;
        if(ajoAdId != null)
        {
                val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
            val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            val_4 = ajoAdId.Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_4 = 0;
        }
        
        this.onGoogleAdIdRead(playAdId:  val_4);
    }

}
