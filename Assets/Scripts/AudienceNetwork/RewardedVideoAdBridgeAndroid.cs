using UnityEngine;

namespace AudienceNetwork
{
    internal class RewardedVideoAdBridgeAndroid : RewardedVideoAdBridge
    {
        // Fields
        private static System.Collections.Generic.Dictionary<int, AudienceNetwork.RewardedVideoAdContainer> rewardedVideoAds;
        private static int lastKey;
        
        // Methods
        private UnityEngine.AndroidJavaObject RewardedVideoAdForUniqueId(int uniqueId)
        {
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            if((AudienceNetwork.RewardedVideoAdBridgeAndroid.rewardedVideoAds.TryGetValue(key:  uniqueId, value: out  0)) != false)
            {
                    val_4 = 37794084;
                return (UnityEngine.AndroidJavaObject)val_4;
            }
            
            val_4 = 0;
            return (UnityEngine.AndroidJavaObject)val_4;
        }
        private AudienceNetwork.RewardedVideoAdContainer RewardedVideoAdContainerForUniqueId(int uniqueId)
        {
            var val_4;
            AudienceNetwork.RewardedVideoAdContainer val_1 = 0;
            val_4 = null;
            val_4 = null;
            return (AudienceNetwork.RewardedVideoAdContainer)((AudienceNetwork.RewardedVideoAdBridgeAndroid.rewardedVideoAds.TryGetValue(key:  uniqueId, value: out  val_1)) != true) ? (val_1) : 0;
        }
        private string GetStringForuniqueId(int uniqueId, string method)
        {
            var val_3;
            var val_5;
            UnityEngine.AndroidJavaObject val_1 = this.RewardedVideoAdForUniqueId(uniqueId:  uniqueId);
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
            UnityEngine.AndroidJavaObject val_1 = this.RewardedVideoAdForUniqueId(uniqueId:  uniqueId);
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
        public override int Create(string placementId, AudienceNetwork.RewardData rewardData, AudienceNetwork.RewardedVideoAd rewardedVideoAd)
        {
            var val_10;
            object val_11;
            int val_12;
            int val_13;
            UnityEngine.AndroidJavaObject val_14;
            var val_15;
            AudienceNetwork.Utility.AdUtility.Prepare();
            val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_11 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity").Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            object[] val_4 = new object[2];
            val_12 = val_4.Length;
            val_4[0] = val_11;
            if(placementId != null)
            {
                    val_12 = val_4.Length;
            }
            
            val_4[1] = placementId;
            UnityEngine.AndroidJavaObject val_5 = new UnityEngine.AndroidJavaObject(className:  "com.facebook.ads.RewardedVideoAd", args:  val_4);
            if(rewardData != null)
            {
                    object[] val_7 = new object[2];
                val_11 = val_7;
                val_13 = val_7.Length;
                val_11[0] = rewardData.<UserId>k__BackingField;
                if((rewardData.<Currency>k__BackingField) != null)
            {
                    val_13 = val_7.Length;
            }
            
                val_11[1] = rewardData.<Currency>k__BackingField;
                UnityEngine.AndroidJavaObject val_8 = null;
                val_14 = val_8;
                val_8 = new UnityEngine.AndroidJavaObject(className:  "com.facebook.ads.RewardData", args:  val_7);
            }
            else
            {
                    val_14 = 0;
            }
            
            .<rewardedVideoAd>k__BackingField = rewardedVideoAd;
            .listenerProxy = new AudienceNetwork.RewardedVideoAdBridgeListenerProxy(rewardedVideoAd:  rewardedVideoAd, bridgedRewardedVideoAd:  val_5);
            .bridgedRewardedVideoAd = val_5;
            .rewardData = val_14;
            val_15 = null;
            val_15 = null;
            AudienceNetwork.RewardedVideoAdBridgeAndroid.rewardedVideoAds.Add(key:  AudienceNetwork.RewardedVideoAdBridgeAndroid.lastKey, value:  new AudienceNetwork.RewardedVideoAdContainer());
            int val_10 = AudienceNetwork.RewardedVideoAdBridgeAndroid.lastKey;
            val_10 = val_10 + 1;
            AudienceNetwork.RewardedVideoAdBridgeAndroid.lastKey = val_10;
            return (int)AudienceNetwork.RewardedVideoAdBridgeAndroid.lastKey;
        }
        public override int Load(int uniqueId)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            AudienceNetwork.RewardedVideoAdContainer val_1 = this.RewardedVideoAdContainerForUniqueId(uniqueId:  uniqueId);
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
            AudienceNetwork.RewardedVideoAdContainer val_1 = this.RewardedVideoAdContainerForUniqueId(uniqueId:  uniqueId);
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
            UnityEngine.AndroidJavaObject val_1 = this.RewardedVideoAdForUniqueId(uniqueId:  val_3);
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
            RewardedVideoAdBridgeAndroid.<>c__DisplayClass10_0 val_1 = new RewardedVideoAdBridgeAndroid.<>c__DisplayClass10_0();
            .rewardedVideoAd = val_1.RewardedVideoAdContainerForUniqueId(uniqueId:  uniqueId).RewardedVideoAdForUniqueId(uniqueId:  uniqueId);
            val_2.<rewardedVideoAd>k__BackingField.ExecuteOnMainThread(action:  new System.Action(object:  val_1, method:  System.Void RewardedVideoAdBridgeAndroid.<>c__DisplayClass10_0::<Show>b__0()));
            return true;
        }
        public override void SetExtraHints(int uniqueId, AudienceNetwork.ExtraHints extraHints)
        {
            AudienceNetwork.Utility.AdUtility.Prepare();
            UnityEngine.AndroidJavaObject val_1 = this.RewardedVideoAdForUniqueId(uniqueId:  uniqueId);
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
            var val_3;
            var val_4;
            UnityEngine.AndroidJavaObject val_1 = this.RewardedVideoAdForUniqueId(uniqueId:  uniqueId);
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
            bool val_2 = AudienceNetwork.RewardedVideoAdBridgeAndroid.rewardedVideoAds.Remove(key:  uniqueId);
        }
        public override void OnLoad(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public override void OnImpression(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public override void OnClick(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public override void OnError(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback callback)
        {
        
        }
        public override void OnWillClose(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public override void OnDidClose(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public override void OnActivityDestroyed(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public RewardedVideoAdBridgeAndroid()
        {
            this = new System.Object();
        }
        private static RewardedVideoAdBridgeAndroid()
        {
            AudienceNetwork.RewardedVideoAdBridgeAndroid.rewardedVideoAds = new System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.RewardedVideoAdContainer>();
        }
    
    }

}
