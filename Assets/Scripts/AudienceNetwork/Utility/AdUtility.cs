using UnityEngine;

namespace AudienceNetwork.Utility
{
    public static class AdUtility
    {
        // Methods
        internal static double Width()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.Utility.AdUtilityBridge.Instance.Width();
        }
        internal static double Height()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.Utility.AdUtilityBridge.Instance.Height();
        }
        internal static double Convert(double deviceSize)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.Utility.AdUtilityBridge.Instance.Convert(deviceSize:  deviceSize);
        }
        internal static void Prepare()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.Utility.AdUtilityBridge.Instance.Prepare();
        }
        internal static bool IsLandscape()
        {
            var val_5;
            if(UnityEngine.Screen.orientation != 3)
            {
                    if(UnityEngine.Screen.orientation != 3)
            {
                    return (bool)(UnityEngine.Screen.orientation == 4) ? 1 : 0;
            }
            
            }
            
            val_5 = 1;
            return (bool)(UnityEngine.Screen.orientation == 4) ? 1 : 0;
        }
    
    }

}
