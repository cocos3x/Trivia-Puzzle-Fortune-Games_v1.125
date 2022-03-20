using UnityEngine;

namespace AudienceNetwork
{
    internal class AdSettingsBridgeAndroid : AdSettingsBridge
    {
        // Methods
        public override void AddTestDevice(string deviceID)
        {
            object[] val_2 = new object[1];
            val_2[0] = deviceID;
            this.GetAdSettingsObject().CallStatic(methodName:  "addTestDevice", args:  val_2);
        }
        public override void SetUrlPrefix(string urlPrefix)
        {
            object[] val_2 = new object[1];
            val_2[0] = urlPrefix;
            this.GetAdSettingsObject().CallStatic(methodName:  "setUrlPrefix", args:  val_2);
        }
        public override void SetMixedAudience(bool mixedAudience)
        {
            object[] val_3 = new object[1];
            val_3[0] = mixedAudience;
            this.GetAdSettingsObject().CallStatic(methodName:  "setMixedAudience", args:  val_3);
        }
        public override void SetDataProcessingOptions(string[] dataProcessingOptions)
        {
            object[] val_2 = new object[1];
            val_2[0] = dataProcessingOptions;
            this.GetAdSettingsObject().CallStatic(methodName:  "setDataProcessingOptions", args:  val_2);
        }
        public override void SetDataProcessingOptions(string[] dataProcessingOptions, int country, int state)
        {
            object[] val_2 = new object[3];
            val_2[0] = dataProcessingOptions;
            val_2[1] = country;
            val_2[2] = state;
            this.GetAdSettingsObject().CallStatic(methodName:  "setDataProcessingOptions", args:  val_2);
        }
        public override string GetBidderToken()
        {
            var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_5 = new object[1];
            val_5[0] = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.BidderTokenProvider").CallStatic<System.String>(methodName:  "getBidderToken", args:  val_5);
        }
        private UnityEngine.AndroidJavaClass GetAdSettingsObject()
        {
            return (UnityEngine.AndroidJavaClass)new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AdSettings");
        }
        public AdSettingsBridgeAndroid()
        {
            this = new System.Object();
        }
    
    }

}
