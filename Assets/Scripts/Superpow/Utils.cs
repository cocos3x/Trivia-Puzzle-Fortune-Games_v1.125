using UnityEngine;

namespace Superpow
{
    public class Utils
    {
        // Methods
        public static int GetNumLevels(int world, int chapter)
        {
            return 0;
        }
        public static int GetNumChapters(int world, bool forceResources = False)
        {
            return 0;
        }
        public static int GetNumWorlds(bool forceResources = False)
        {
            return 1;
        }
        public static void SaveAllLevelsForCurrentGame(System.Collections.Generic.List<object> responseObject)
        {
            GameBehavior val_1 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_1E0;
        }
        public static void SaveLevelsFromChaptersCurrentGame(System.Collections.Generic.List<object> chapters, string language = "")
        {
            GameBehavior val_1 = App.getBehavior;
            string val_2 = Superpow.Utils.ConvertLangugaeServerToClient(serverLanguage:  language);
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_1E0;
        }
        public static string ConvertLangugaeServerToClient(string serverLanguage)
        {
            var val_4;
            if((System.String.op_Equality(a:  serverLanguage, b:  "es_la")) == false)
            {
                    return (string)((System.String.op_Equality(a:  serverLanguage, b:  "en_us")) != true) ? "en" : serverLanguage;
            }
            
            val_4 = "es";
            return (string)((System.String.op_Equality(a:  serverLanguage, b:  "en_us")) != true) ? "en" : serverLanguage;
        }
        public Utils()
        {
        
        }
    
    }

}
