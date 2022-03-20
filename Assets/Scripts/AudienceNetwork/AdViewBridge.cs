using UnityEngine;

namespace AudienceNetwork
{
    internal class AdViewBridge : IAdViewBridge
    {
        // Fields
        public static readonly AudienceNetwork.IAdViewBridge Instance;
        
        // Methods
        internal AdViewBridge()
        {
        
        }
        private static AdViewBridge()
        {
            AudienceNetwork.AdViewBridge.Instance = AudienceNetwork.AdViewBridge.CreateInstance();
        }
        private static AudienceNetwork.IAdViewBridge CreateInstance()
        {
            var val_4;
            if(UnityEngine.Application.platform != 0)
            {
                    AudienceNetwork.AdViewBridgeAndroid val_2 = null;
                val_4 = val_2;
                val_2 = new AudienceNetwork.AdViewBridgeAndroid();
                return (AudienceNetwork.IAdViewBridge)val_4;
            }
            
            AudienceNetwork.AdViewBridge val_3 = null;
            val_4 = val_3;
            val_3 = new AudienceNetwork.AdViewBridge();
            return (AudienceNetwork.IAdViewBridge)val_4;
        }
        public virtual int Create(string placementId, AudienceNetwork.AdView AdView, AudienceNetwork.AdSize size)
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
        public virtual bool Show(int uniqueId, double x, double y, double width, double height)
        {
            return true;
        }
        public virtual void SetExtraHints(int uniqueId, AudienceNetwork.ExtraHints extraHints)
        {
        
        }
        public virtual void Release(int uniqueId)
        {
        
        }
        public virtual void OnLoad(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public virtual void OnImpression(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public virtual void OnClick(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
        public virtual void OnError(int uniqueId, AudienceNetwork.FBAdViewBridgeErrorCallback callback)
        {
        
        }
        public virtual void OnFinishedClick(int uniqueId, AudienceNetwork.FBAdViewBridgeCallback callback)
        {
        
        }
    
    }

}
