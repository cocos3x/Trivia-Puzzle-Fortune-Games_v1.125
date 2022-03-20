using UnityEngine;

namespace AudienceNetwork
{
    internal class InterstitialAdContainer
    {
        // Fields
        private AudienceNetwork.InterstitialAd <interstitialAd>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onLoad>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onImpression>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onClick>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeErrorCallback <onError>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onDidClose>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onWillClose>k__BackingField;
        private AudienceNetwork.FBInterstitialAdBridgeCallback <onActivityDestroyed>k__BackingField;
        internal UnityEngine.AndroidJavaProxy listenerProxy;
        internal UnityEngine.AndroidJavaObject bridgedInterstitialAd;
        
        // Properties
        internal AudienceNetwork.InterstitialAd interstitialAd { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onLoad { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onImpression { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onClick { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeErrorCallback onError { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onDidClose { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onWillClose { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback onActivityDestroyed { get; set; }
        
        // Methods
        internal AudienceNetwork.InterstitialAd get_interstitialAd()
        {
            return (AudienceNetwork.InterstitialAd)this.<interstitialAd>k__BackingField;
        }
        internal void set_interstitialAd(AudienceNetwork.InterstitialAd value)
        {
            this.<interstitialAd>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onLoad()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onLoad>k__BackingField;
        }
        internal void set_onLoad(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onLoad>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onImpression()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onImpression>k__BackingField;
        }
        internal void set_onImpression(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onImpression>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onClick()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onClick>k__BackingField;
        }
        internal void set_onClick(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onClick>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeErrorCallback get_onError()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeErrorCallback)this.<onError>k__BackingField;
        }
        internal void set_onError(AudienceNetwork.FBInterstitialAdBridgeErrorCallback value)
        {
            this.<onError>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onDidClose()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onDidClose>k__BackingField;
        }
        internal void set_onDidClose(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onDidClose>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onWillClose()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onWillClose>k__BackingField;
        }
        internal void set_onWillClose(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onWillClose>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_onActivityDestroyed()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.<onActivityDestroyed>k__BackingField;
        }
        internal void set_onActivityDestroyed(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            this.<onActivityDestroyed>k__BackingField = value;
        }
        internal InterstitialAdContainer(AudienceNetwork.InterstitialAd interstitialAd)
        {
            this.<interstitialAd>k__BackingField = interstitialAd;
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[InterstitialAdContainer: interstitialAd={0}, onLoad={1}]", arg0:  this.<interstitialAd>k__BackingField, arg1:  this.<onLoad>k__BackingField);
        }
        public static bool op_Implicit(AudienceNetwork.InterstitialAdContainer obj)
        {
            return (bool)(obj != 0) ? 1 : 0;
        }
        internal UnityEngine.AndroidJavaObject LoadAdConfig(string bidPayload)
        {
            var val_6;
            var val_7;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaObject val_1 = this.bridgedInterstitialAd.Call<UnityEngine.AndroidJavaObject>(methodName:  "buildLoadAdConfig", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            object[] val_2 = new object[1];
            val_2[0] = this.listenerProxy;
            UnityEngine.AndroidJavaObject val_3 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "withAdListener", args:  val_2);
            if(bidPayload != null)
            {
                    object[] val_4 = new object[1];
                val_4[0] = bidPayload;
                UnityEngine.AndroidJavaObject val_5 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "withBid", args:  val_4);
            }
            
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
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
            this.bridgedInterstitialAd.Call(methodName:  "loadAd", args:  val_2);
        }
    
    }

}
