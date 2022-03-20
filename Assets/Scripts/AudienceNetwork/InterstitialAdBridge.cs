using UnityEngine;

namespace AudienceNetwork
{
    internal class InterstitialAdBridge : IInterstitialAdBridge
    {
        // Fields
        public static readonly AudienceNetwork.IInterstitialAdBridge Instance;
        
        // Methods
        internal InterstitialAdBridge()
        {
        
        }
        private static InterstitialAdBridge()
        {
            AudienceNetwork.InterstitialAdBridge.Instance = AudienceNetwork.InterstitialAdBridge.CreateInstance();
        }
        private static AudienceNetwork.IInterstitialAdBridge CreateInstance()
        {
            var val_4;
            if(UnityEngine.Application.platform != 0)
            {
                    AudienceNetwork.InterstitialAdBridgeAndroid val_2 = null;
                val_4 = val_2;
                val_2 = new AudienceNetwork.InterstitialAdBridgeAndroid();
                return (AudienceNetwork.IInterstitialAdBridge)val_4;
            }
            
            AudienceNetwork.InterstitialAdBridge val_3 = null;
            val_4 = val_3;
            val_3 = new AudienceNetwork.InterstitialAdBridge();
            return (AudienceNetwork.IInterstitialAdBridge)val_4;
        }
        public virtual int Create(string placementId, AudienceNetwork.InterstitialAd InterstitialAd)
        {
            return 123;
        }
        public virtual int Load(int uniqueId)
        {
            return 123;
        }
        public virtual int Load(int uniqueId, string bidPayload)
        {
            return 123;
        }
        public virtual bool IsValid(int uniqueId)
        {
            return true;
        }
        public virtual bool Show(int uniqueId)
        {
            return true;
        }
        public virtual void SetExtraHints(int uniqueId, AudienceNetwork.ExtraHints extraHints)
        {
        
        }
        public virtual void Release(int uniqueId)
        {
        
        }
        public virtual void OnLoad(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public virtual void OnImpression(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public virtual void OnClick(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public virtual void OnError(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeErrorCallback callback)
        {
        
        }
        public virtual void OnWillClose(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public virtual void OnDidClose(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
        public virtual void OnActivityDestroyed(int uniqueId, AudienceNetwork.FBInterstitialAdBridgeCallback callback)
        {
        
        }
    
    }

}
