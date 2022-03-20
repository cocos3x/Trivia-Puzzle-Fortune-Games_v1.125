using UnityEngine;

namespace com.adjust.sdk
{
    public static class AdjustEnvironmentExtension
    {
        // Methods
        public static string ToLowercaseString(com.adjust.sdk.AdjustEnvironment adjustEnvironment)
        {
            return (string)(adjustEnvironment == 0) ? "sandbox" : ((adjustEnvironment == 1) ? "production" : "unknown");
        }
    
    }

}
