using UnityEngine;

namespace AudienceNetwork
{
    internal class AdViewContainer
    {
        // Fields
        private AudienceNetwork.AdView <adView>k__BackingField;
        private AudienceNetwork.FBAdViewBridgeCallback <onLoad>k__BackingField;
        private AudienceNetwork.FBAdViewBridgeCallback <onImpression>k__BackingField;
        private AudienceNetwork.FBAdViewBridgeCallback <onClick>k__BackingField;
        private AudienceNetwork.FBAdViewBridgeErrorCallback <onError>k__BackingField;
        private AudienceNetwork.FBAdViewBridgeCallback <onFinishedClick>k__BackingField;
        internal UnityEngine.AndroidJavaProxy listenerProxy;
        internal UnityEngine.AndroidJavaObject bridgedAdView;
        
        // Properties
        internal AudienceNetwork.AdView adView { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback onLoad { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback onImpression { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback onClick { get; set; }
        internal AudienceNetwork.FBAdViewBridgeErrorCallback onError { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback onFinishedClick { get; set; }
        
        // Methods
        internal AudienceNetwork.AdView get_adView()
        {
            return (AudienceNetwork.AdView)this.<adView>k__BackingField;
        }
        internal void set_adView(AudienceNetwork.AdView value)
        {
            this.<adView>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_onLoad()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.<onLoad>k__BackingField;
        }
        internal void set_onLoad(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            this.<onLoad>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_onImpression()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.<onImpression>k__BackingField;
        }
        internal void set_onImpression(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            this.<onImpression>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_onClick()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.<onClick>k__BackingField;
        }
        internal void set_onClick(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            this.<onClick>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeErrorCallback get_onError()
        {
            return (AudienceNetwork.FBAdViewBridgeErrorCallback)this.<onError>k__BackingField;
        }
        internal void set_onError(AudienceNetwork.FBAdViewBridgeErrorCallback value)
        {
            this.<onError>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_onFinishedClick()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.<onFinishedClick>k__BackingField;
        }
        internal void set_onFinishedClick(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            this.<onFinishedClick>k__BackingField = value;
        }
        internal AdViewContainer(AudienceNetwork.AdView adView)
        {
            this.<adView>k__BackingField = adView;
        }
        public override string ToString()
        {
            return System.String.Format(format:  "[AdViewContainer: adView={0}, onLoad={1}]", arg0:  this.<adView>k__BackingField, arg1:  this.<onLoad>k__BackingField);
        }
        public static bool op_Implicit(AudienceNetwork.AdViewContainer obj)
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
            UnityEngine.AndroidJavaObject val_1 = this.bridgedAdView.Call<UnityEngine.AndroidJavaObject>(methodName:  "buildLoadAdConfig", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
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
            this.bridgedAdView.Call(methodName:  "loadAd", args:  val_2);
        }
    
    }

}
