using UnityEngine;

namespace AudienceNetwork
{
    internal class AdSettingsBridge : IAdSettingsBridge
    {
        // Fields
        public static readonly AudienceNetwork.IAdSettingsBridge Instance;
        
        // Methods
        internal AdSettingsBridge()
        {
        
        }
        private static AdSettingsBridge()
        {
            AudienceNetwork.AdSettingsBridge.Instance = AudienceNetwork.AdSettingsBridge.CreateInstance();
        }
        private static AudienceNetwork.IAdSettingsBridge CreateInstance()
        {
            var val_4;
            if(UnityEngine.Application.platform != 0)
            {
                    AudienceNetwork.AdSettingsBridgeAndroid val_2 = null;
                val_4 = val_2;
                val_2 = new AudienceNetwork.AdSettingsBridgeAndroid();
                return (AudienceNetwork.IAdSettingsBridge)val_4;
            }
            
            AudienceNetwork.AdSettingsBridge val_3 = null;
            val_4 = val_3;
            val_3 = new AudienceNetwork.AdSettingsBridge();
            return (AudienceNetwork.IAdSettingsBridge)val_4;
        }
        public virtual void AddTestDevice(string deviceID)
        {
        
        }
        public virtual void SetUrlPrefix(string urlPrefix)
        {
        
        }
        public virtual void SetMixedAudience(bool mixedAudience)
        {
        
        }
        public virtual void SetDataProcessingOptions(string[] dataProcessingOptions)
        {
        
        }
        public virtual void SetDataProcessingOptions(string[] dataProcessingOptions, int country, int state)
        {
        
        }
        public virtual string GetBidderToken()
        {
            return (string)System.String.alignConst;
        }
    
    }

}
