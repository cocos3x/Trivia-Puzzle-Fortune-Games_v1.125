using UnityEngine;

namespace AudienceNetwork
{
    internal static class AdLogger
    {
        // Fields
        private static AudienceNetwork.AdLogger.AdLogLevel logLevel;
        private static readonly string logPrefix;
        
        // Methods
        internal static void Log(string message)
        {
            var val_2 = null;
            if(AudienceNetwork.AdLogger.logLevel < 4)
            {
                    return;
            }
            
            UnityEngine.Debug.Log(message:  AudienceNetwork.AdLogger.logPrefix + "<log>: "("<log>: ") + message);
        }
        internal static void LogWarning(string message)
        {
            var val_2 = null;
            if(AudienceNetwork.AdLogger.logLevel < 3)
            {
                    return;
            }
            
            UnityEngine.Debug.LogWarning(message:  AudienceNetwork.AdLogger.logPrefix + "<warn>: "("<warn>: ") + message);
        }
        internal static void LogError(string message)
        {
            var val_2 = null;
            if(AudienceNetwork.AdLogger.logLevel < 2)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  AudienceNetwork.AdLogger.logPrefix + "<error>: "("<error>: ") + message);
        }
        private static string LevelAsString(AudienceNetwork.AdLogger.AdLogLevel logLevel)
        {
            var val_2;
            if((logLevel - 2) <= 4)
            {
                    val_2 = mem[39724656 + ((logLevel - 2)) << 3];
                val_2 = 39724656 + ((logLevel - 2)) << 3;
                return (string)val_2;
            }
            
            val_2 = "";
            return (string)val_2;
        }
        private static AdLogger()
        {
            AudienceNetwork.AdLogger.logLevel = 4;
            AudienceNetwork.AdLogger.logPrefix = "Audience Network Unity ";
        }
    
    }

}
