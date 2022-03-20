using UnityEngine;

namespace AudienceNetwork
{
    public static class AudienceNetworkAds
    {
        // Fields
        private static bool isInitialized;
        
        // Methods
        internal static void Initialize()
        {
            var val_7;
            var val_8;
            if(AudienceNetwork.AudienceNetworkAds.IsInitialized() == true)
            {
                    return;
            }
            
            UnityEngine.PlayerPrefs.SetString(key:  "an_isUnitySDK", value:  "6.4.0");
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaClass val_5 = null;
            val_7 = val_5;
            val_5 = new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AudienceNetworkAds");
            object[] val_6 = new object[1];
            val_6[0] = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_5.CallStatic(methodName:  "initialize", args:  val_6);
            AudienceNetwork.AudienceNetworkAds.isInitialized = true;
        }
        internal static bool IsInitialized()
        {
            var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_5 = new object[1];
            val_5[0] = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AudienceNetworkAds").CallStatic<System.Boolean>(methodName:  "isInitialized", args:  val_5);
        }
    
    }

}
