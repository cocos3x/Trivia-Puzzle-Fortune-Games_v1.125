using UnityEngine;

namespace AudienceNetwork
{
    internal class AdViewBridgeAndroid : AdViewBridge
    {
        // Fields
        private static System.Collections.Generic.Dictionary<int, AudienceNetwork.AdViewContainer> adViews;
        private static int lastKey;
        
        // Methods
        private UnityEngine.AndroidJavaObject AdViewForAdViewId(int uniqueId)
        {
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            if((AudienceNetwork.AdViewBridgeAndroid.adViews.TryGetValue(key:  uniqueId, value: out  0)) != false)
            {
                    val_4 = 0;
                return (UnityEngine.AndroidJavaObject)val_4;
            }
            
            val_4 = 0;
            return (UnityEngine.AndroidJavaObject)val_4;
        }
        private AudienceNetwork.AdViewContainer AdViewContainerForAdViewId(int uniqueId)
        {
            var val_4;
            AudienceNetwork.AdViewContainer val_1 = 0;
            val_4 = null;
            val_4 = null;
            return (AudienceNetwork.AdViewContainer)((AudienceNetwork.AdViewBridgeAndroid.adViews.TryGetValue(key:  uniqueId, value: out  val_1)) != true) ? (val_1) : 0;
        }
        private string GetStringForAdViewId(int uniqueId, string method)
        {
            var val_3;
            var val_5;
            UnityEngine.AndroidJavaObject val_1 = this.AdViewForAdViewId(uniqueId:  uniqueId);
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
        private string GetImageURLForAdViewId(int uniqueId, string method)
        {
            var val_4;
            string val_5;
            var val_7;
            var val_8;
            val_5 = method;
            UnityEngine.AndroidJavaObject val_1 = this.AdViewForAdViewId(uniqueId:  uniqueId);
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
        private UnityEngine.AndroidJavaObject JavaAdSizeFromAdSize(AudienceNetwork.AdSize size)
        {
            var val_3;
            string val_4;
            if(size != 2)
            {
                    if(size != 1)
            {
                    val_3 = 0;
                if(size != 0)
            {
                    return (UnityEngine.AndroidJavaObject)new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AdSize").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  val_4 = "RECTANGLE_HEIGHT_250");
            }
            
                val_4 = "BANNER_HEIGHT_50";
                return (UnityEngine.AndroidJavaObject)new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AdSize").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  val_4);
            }
            
                val_4 = "BANNER_HEIGHT_90";
                return (UnityEngine.AndroidJavaObject)new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AdSize").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  val_4);
            }
            
            return (UnityEngine.AndroidJavaObject)new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.AdSize").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  val_4);
        }
        public override int Create(string placementId, AudienceNetwork.AdView adView, AudienceNetwork.AdSize size)
        {
            var val_9;
            int val_10;
            var val_11;
            AudienceNetwork.Utility.AdUtility.Prepare();
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            object[] val_4 = new object[3];
            val_10 = val_4.Length;
            val_4[0] = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(placementId != null)
            {
                    val_10 = val_4.Length;
            }
            
            val_4[1] = placementId;
            val_4[2] = X0.JavaAdSizeFromAdSize(size:  size);
            UnityEngine.AndroidJavaObject val_6 = new UnityEngine.AndroidJavaObject(className:  "com.facebook.ads.AdView", args:  val_4);
            .<adView>k__BackingField = adView;
            .listenerProxy = new AudienceNetwork.AdViewBridgeListenerProxy(adView:  adView, bridgedAdView:  val_6);
            .bridgedAdView = val_6;
            val_11 = null;
            val_11 = null;
            AudienceNetwork.AdViewBridgeAndroid.adViews.Add(key:  AudienceNetwork.AdViewBridgeAndroid.lastKey, value:  new AudienceNetwork.AdViewContainer());
            int val_9 = AudienceNetwork.AdViewBridgeAndroid.lastKey;
            val_9 = val_9 + 1;
            AudienceNetwork.AdViewBridgeAndroid.lastKey = val_9;
            return (int)AudienceNetwork.AdViewBridgeAndroid.lastKey;
        }
        public override int Load(int uniqueId)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            AudienceNetwork.AdViewContainer val_1 = this.AdViewContainerForAdViewId(uniqueId:  uniqueId);
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
            AudienceNetwork.AdViewContainer val_1 = this.AdViewContainerForAdViewId(uniqueId:  uniqueId);
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
            UnityEngine.AndroidJavaObject val_1 = this.AdViewForAdViewId(uniqueId:  val_3);
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
        public override bool Show(int uniqueId, double x, double y, double width, double height)
        {
            var val_7;
            AdViewBridgeAndroid.<>c__DisplayClass11_0 val_1 = new AdViewBridgeAndroid.<>c__DisplayClass11_0();
            .width = width;
            .height = height;
            .x = x;
            .y = y;
            UnityEngine.AndroidJavaObject val_2 = val_1.AdViewForAdViewId(uniqueId:  uniqueId);
            .adView = val_2;
            if(val_2 == null)
            {
                    return (bool)val_7;
            }
            
            UnityEngine.AndroidJavaObject val_4 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
            .activity = val_4;
            object[] val_5 = new object[1];
            val_5[0] = new UnityEngine.AndroidJavaRunnable(object:  val_1, method:  System.Void AdViewBridgeAndroid.<>c__DisplayClass11_0::<Show>b__0());
            val_4.Call(methodName:  "runOnUiThread", args:  val_5);
            val_7 = 1;
            return (bool)val_7;
        }
        public override void SetExtraHints(int uniqueId, AudienceNetwork.ExtraHints extraHints)
        {
            UnityEngine.AndroidJavaObject val_1 = this.AdViewForAdViewId(uniqueId:  uniqueId);
            if(val_1 == null)
            {
                    return;
            }
            
            object[] val_2 = new object[1];
            val_2[0] = extraHints.GetAndroidObject();
            val_1.Call(methodName:  "setExtraHints", args:  val_2);
        }
        public override void Release(int uniqueId)
        {
            var val_8;
            UnityEngine.AndroidJavaObject val_3 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
            .adView = val_3.AdViewForAdViewId(uniqueId:  uniqueId);
            val_8 = null;
            val_8 = null;
            bool val_5 = AudienceNetwork.AdViewBridgeAndroid.adViews.Remove(key:  uniqueId);
            if(((AdViewBridgeAndroid.<>c__DisplayClass13_0)[1152921520224891856].adView) == null)
            {
                    return;
            }
            
            object[] val_6 = new object[1];
            val_6[0] = new UnityEngine.AndroidJavaRunnable(object:  new AdViewBridgeAndroid.<>c__DisplayClass13_0(), method:  System.Void AdViewBridgeAndroid.<>c__DisplayClass13_0::<Release>b__0());
            val_3.Call(methodName:  "runOnUiThread", args:  val_6);
        }
        public override void OnLoad(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public override void OnImpression(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public override void OnClick(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public override void OnError(int uniqueId, AudienceNetwork.FBAdViewBridgeErrorCallback callback)
        {
        
        }
        public override void OnFinishedClick(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public AdViewBridgeAndroid()
        {
            this = new System.Object();
        }
        private static AdViewBridgeAndroid()
        {
            AudienceNetwork.AdViewBridgeAndroid.adViews = new System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.AdViewContainer>();
        }
    
    }

}
