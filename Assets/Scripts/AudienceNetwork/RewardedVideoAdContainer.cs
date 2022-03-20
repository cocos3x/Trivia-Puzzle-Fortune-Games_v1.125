using UnityEngine;

namespace AudienceNetwork
{
    internal class RewardedVideoAdContainer
    {
        // Fields
        private AudienceNetwork.RewardedVideoAd <rewardedVideoAd>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onLoad>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onImpression>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onClick>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback <onError>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onDidClose>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onWillClose>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onComplete>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onDidSucceed>k__BackingField;
        private AudienceNetwork.FBRewardedVideoAdBridgeCallback <onDidFail>k__BackingField;
        internal UnityEngine.AndroidJavaProxy listenerProxy;
        internal UnityEngine.AndroidJavaObject bridgedRewardedVideoAd;
        internal UnityEngine.AndroidJavaObject rewardData;
        
        // Properties
        internal AudienceNetwork.RewardedVideoAd rewardedVideoAd { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onLoad { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onImpression { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onClick { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback onError { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onDidClose { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onWillClose { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onComplete { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onDidSucceed { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback onDidFail { get; set; }
        
        // Methods
        internal AudienceNetwork.RewardedVideoAd get_rewardedVideoAd()
        {
            return (AudienceNetwork.RewardedVideoAd)this.<rewardedVideoAd>k__BackingField;
        }
        internal void set_rewardedVideoAd(AudienceNetwork.RewardedVideoAd value)
        {
            this.<rewardedVideoAd>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onLoad()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onLoad>k__BackingField;
        }
        internal void set_onLoad(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onLoad>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onImpression()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onImpression>k__BackingField;
        }
        internal void set_onImpression(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onImpression>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onClick()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onClick>k__BackingField;
        }
        internal void set_onClick(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onClick>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback get_onError()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback)this.<onError>k__BackingField;
        }
        internal void set_onError(AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback value)
        {
            this.<onError>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onDidClose()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onDidClose>k__BackingField;
        }
        internal void set_onDidClose(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onDidClose>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onWillClose()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onWillClose>k__BackingField;
        }
        internal void set_onWillClose(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onWillClose>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onComplete()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onComplete>k__BackingField;
        }
        internal void set_onComplete(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onComplete>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onDidSucceed()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onDidSucceed>k__BackingField;
        }
        internal void set_onDidSucceed(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onDidSucceed>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_onDidFail()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.<onDidFail>k__BackingField;
        }
        internal void set_onDidFail(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            this.<onDidFail>k__BackingField = value;
        }
        internal RewardedVideoAdContainer(AudienceNetwork.RewardedVideoAd rewardedVideoAd)
        {
            this.<rewardedVideoAd>k__BackingField = rewardedVideoAd;
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[RewardedVideoAdContainer: rewardedVideoAd={0}, onLoad={1}]", arg0:  this.<rewardedVideoAd>k__BackingField, arg1:  this.<onLoad>k__BackingField);
        }
        public static bool op_Implicit(AudienceNetwork.RewardedVideoAdContainer obj)
        {
            return (bool)(obj != 0) ? 1 : 0;
        }
        internal UnityEngine.AndroidJavaObject LoadAdConfig(string bidPayload)
        {
            var val_8;
            var val_9;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaObject val_1 = this.bridgedRewardedVideoAd.Call<UnityEngine.AndroidJavaObject>(methodName:  "buildLoadAdConfig", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            object[] val_2 = new object[1];
            val_2[0] = this.listenerProxy;
            UnityEngine.AndroidJavaObject val_3 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "withAdListener", args:  val_2);
            if(this.rewardData != null)
            {
                    object[] val_4 = new object[1];
                val_4[0] = this.rewardData;
                UnityEngine.AndroidJavaObject val_5 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "withRewardData", args:  val_4);
            }
            
            if(bidPayload != null)
            {
                    object[] val_6 = new object[1];
                val_6[0] = bidPayload;
                UnityEngine.AndroidJavaObject val_7 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "withBid", args:  val_6);
            }
            
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            return val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "build", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public void Load()
        {
            this.Load(bidPayload:  0);
        }
        public void Load(string bidPayload)
        {
            object[] val_2 = new object[1];
            val_2[0] = this.LoadAdConfig(bidPayload:  bidPayload);
            this.bridgedRewardedVideoAd.Call(methodName:  "loadAd", args:  val_2);
        }
    
    }

}
