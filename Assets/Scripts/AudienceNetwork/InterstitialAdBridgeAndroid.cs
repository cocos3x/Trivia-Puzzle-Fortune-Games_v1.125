using UnityEngine;

namespace AudienceNetwork
{
    internal class InterstitialAdBridgeAndroid : InterstitialAdBridge
    {
        // Fields
        private static System.Collections.Generic.Dictionary<int, AudienceNetwork.InterstitialAdContainer> interstitialAds;
        private static int lastKey;
        
        // Methods
        private UnityEngine.AndroidJavaObject InterstitialAdForuniqueId(int uniqueId)
        {
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            if((AudienceNetwork.InterstitialAdBridgeAndroid.interstitialAds.TryGetValue(key:  uniqueId, value: out  0)) != false)
            {
                    val_4 = 0;
                return (UnityEngine.AndroidJavaObject)val_4;
            }
            
            val_4 = 0;
            return (UnityEngine.AndroidJavaObject)val_4;
        }
        private AudienceNetwork.InterstitialAdContainer InterstitialAdContainerForuniqueId(int uniqueId)
        {
            var val_4;
            AudienceNetwork.InterstitialAdContainer val_1 = 0;
            val_4 = null;
            val_4 = null;
            return (AudienceNetwork.InterstitialAdContainer)((AudienceNetwork.InterstitialAdBridgeAndroid.interstitialAds.TryGetValue(key:  uniqueId, value: out  val_1)) != true) ? (val_1) : 0;
        }
        private string GetStringForuniqueId(int uniqueId, string method)
        {
            var val_3;
            var val_5;
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return (string)val_1.Call<System.String>(methodName:  method, args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            }
            
            val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
            val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            return (string)val_1.Call<System.String>(methodName:  method, args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        private string GetImageURLForuniqueId(int uniqueId, string method)
        {
            var val_4;
            string val_5;
            var val_7;
            var val_8;
            val_5 = method;
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return (string)val_5.Call<System.String>(methodName:  "getUrl", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            }
            
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
            val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            UnityEngine.AndroidJavaObject val_2 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  val_5, args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(val_2 == null)
            {
                    return (string)val_5.Call<System.String>(methodName:  "getUrl", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            }
            
            val_4 = public static T[] System.Array::Empty<System.Object>();
            val_5 = val_2;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            return (string)val_5.Call<System.String>(methodName:  "getUrl", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public override int Create(string placementId, AudienceNetwork.InterstitialAd interstitialAd)
        {
            var val_8;
            int val_9;
            var val_10;
            AudienceNetwork.Utility.AdUtility.Prepare();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_4 = new object[2];
            val_9 = val_4.Length;
            val_4[0] = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(placementId != null)
            {
                    val_9 = val_4.Length;
            }
            
            val_4[1] = placementId;
            UnityEngine.AndroidJavaObject val_5 = new UnityEngine.AndroidJavaObject(className:  "com.facebook.ads.InterstitialAd", args:  val_4);
            .<interstitialAd>k__BackingField = interstitialAd;
            .listenerProxy = new AudienceNetwork.InterstitialAdBridgeListenerProxy(interstitialAd:  interstitialAd, bridgedInterstitialAd:  val_5);
            .bridgedInterstitialAd = val_5;
            val_10 = null;
            val_10 = null;
            AudienceNetwork.InterstitialAdBridgeAndroid.interstitialAds.Add(key:  AudienceNetwork.InterstitialAdBridgeAndroid.lastKey, value:  new AudienceNetwork.InterstitialAdContainer());
            int val_8 = AudienceNetwork.InterstitialAdBridgeAndroid.lastKey;
            val_8 = val_8 + 1;
            AudienceNetwork.InterstitialAdBridgeAndroid.lastKey = val_8;
            return (int)AudienceNetwork.InterstitialAdBridgeAndroid.lastKey;
        }
        public override int Load(int uniqueId)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            AudienceNetwork.InterstitialAdContainer val_1 = this.InterstitialAdContainerForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return (int)uniqueId;
            }
            
            val_1.Load(bidPayload:  0);
            return (int)uniqueId;
        }
        public override int Load(int uniqueId, string bidPayload)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            AudienceNetwork.InterstitialAdContainer val_1 = this.InterstitialAdContainerForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return (int)uniqueId;
            }
            
            val_1.Load(bidPayload:  bidPayload);
            return (int)uniqueId;
        }
        public override bool IsValid(int uniqueId)
        {
            int val_3;
            var val_4;
            var val_5;
            val_3 = uniqueId;
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  val_3);
            if(val_1 != null)
            {
                    val_3 = val_1;
                val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_5 = (val_3.Call<System.Boolean>(methodName:  "isAdInvalidated", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184)) ^ 1;
                return (bool)val_5 & 1;
            }
            
            val_5 = 0;
            return (bool)val_5 & 1;
        }
        public override bool Show(int uniqueId)
        {
            var val_2;
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return (bool)val_1;
            }
            
            val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_2 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_2 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            return val_1.Call<System.Boolean>(methodName:  "show", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public override void Release(int uniqueId)
        {
            var val_3;
            var val_4;
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  uniqueId);
            if(val_1 != null)
            {
                    val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
                val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
                val_1.Call(methodName:  "destroy", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            }
            
            val_4 = null;
            val_4 = null;
            bool val_2 = AudienceNetwork.InterstitialAdBridgeAndroid.interstitialAds.Remove(key:  uniqueId);
        }
        public override void SetExtraHints(int uniqueId, AudienceNetwork.ExtraHints extraHints)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            UnityEngine.AndroidJavaObject val_1 = this.InterstitialAdForuniqueId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return;
            }
            
            object[] val_2 = new object[1];
            val_2[0] = extraHints.GetAndroidObject();
            val_1.Call(methodName:  "setExtraHints", args:  val_2);
        }
        public override void OnLoad(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public override void OnImpression(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public override void OnClick(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public override void OnError(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeErrorCallback callback)
        {
        
        }
        public override void OnWillClose(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public override void OnDidClose(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public override void OnActivityDestroyed(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public InterstitialAdBridgeAndroid()
        {
            this = new System.Object();
        }
        private static InterstitialAdBridgeAndroid()
        {
            AudienceNetwork.InterstitialAdBridgeAndroid.interstitialAds = new System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.InterstitialAdContainer>();
        }
    
    }

}
