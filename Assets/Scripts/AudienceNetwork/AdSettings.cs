using UnityEngine;

namespace AudienceNetwork
{
    public static class AdSettings
    {
        // Methods
        public static void AddTestDevice(string deviceID)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdSettingsBridge.Instance.AddTestDevice(deviceID:  deviceID);
        }
        public static void SetUrlPrefix(string urlPrefix)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdSettingsBridge.Instance.SetUrlPrefix(urlPrefix:  urlPrefix);
        }
        public static void SetMixedAudience(bool mixedAudience)
        {
            var val_3 = null;
            var val_3 = 0;
            val_3 = val_3 + 1;
            AudienceNetwork.AdSettingsBridge.Instance.SetMixedAudience(mixedAudience:  mixedAudience);
        }
        public static void SetDataProcessingOptions(string[] dataProcessingOptions)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdSettingsBridge.Instance.SetDataProcessingOptions(dataProcessingOptions:  dataProcessingOptions);
        }
        public static void SetDataProcessingOptions(string[] dataProcessingOptions, int country, int state)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdSettingsBridge.Instance.SetDataProcessingOptions(dataProcessingOptions:  dataProcessingOptions, country:  country, state:  state);
        }
        public static string GetBidderToken()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.AdSettingsBridge.Instance.GetBidderToken();
        }
    
    }

}
