using UnityEngine;

namespace AudienceNetwork
{
    internal class RewardedVideoAdBridge : IRewardedVideoAdBridge
    {
        // Fields
        public static readonly AudienceNetwork.IRewardedVideoAdBridge Instance;
        
        // Methods
        internal RewardedVideoAdBridge()
        {
        
        }
        private static RewardedVideoAdBridge()
        {
            AudienceNetwork.RewardedVideoAdBridge.Instance = AudienceNetwork.RewardedVideoAdBridge.CreateInstance();
        }
        private static AudienceNetwork.IRewardedVideoAdBridge CreateInstance()
        {
            var val_4;
            if(UnityEngine.Application.platform != 0)
            {
                    AudienceNetwork.RewardedVideoAdBridgeAndroid val_2 = null;
                val_4 = val_2;
                val_2 = new AudienceNetwork.RewardedVideoAdBridgeAndroid();
                return (AudienceNetwork.IRewardedVideoAdBridge)val_4;
            }
            
            AudienceNetwork.RewardedVideoAdBridge val_3 = null;
            val_4 = val_3;
            val_3 = new AudienceNetwork.RewardedVideoAdBridge();
            return (AudienceNetwork.IRewardedVideoAdBridge)val_4;
        }
        public virtual int Create(string placementId, AudienceNetwork.RewardData rewardData, AudienceNetwork.RewardedVideoAd RewardedVideoAd)
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
        public virtual void OnLoad(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnImpression(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnClick(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnError(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback callback)
        {
        
        }
        public virtual void OnWillClose(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnDidClose(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnComplete(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnDidSucceed(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnDidFail(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
        public virtual void OnActivityDestroyed(int uniqueId, AudienceNetwork.FBRewardedVideoAdBridgeCallback callback)
        {
        
        }
    
    }

}
