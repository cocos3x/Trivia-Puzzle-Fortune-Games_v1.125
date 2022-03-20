using UnityEngine;

namespace SLC.Minigames
{
    public static class MinigamesKnobsManager
    {
        // Fields
        public static System.Action<twelvegigs.storage.JsonDictionary> OnKnobsRecieved;
        private const string defaultKnobData = "{\"meta\": {\"versions\": {\"knobs\": 0000 } }, \"data\": {\"knobs\": {} } }";
        private static string rawKnobs;
        private static bool requestingEconData;
        
        // Methods
        private static string RetrieveRawKnobs()
        {
            string val_3;
            var val_4;
            SLC.Minigames.MinigamesKnobsManager.RequestEconData();
            if((System.String.IsNullOrEmpty(value:  SLC.Minigames.MinigamesKnobsManager.rawKnobs)) != false)
            {
                    val_4 = null;
                val_3 = UnityEngine.PlayerPrefs.GetString(key:  "mg_knbs", defaultValue:  "{\"meta\": {\"versions\": {\"knobs\": 0000 } }, \"data\": {\"knobs\": {} } }");
                val_4 = null;
                SLC.Minigames.MinigamesKnobsManager.rawKnobs = val_3;
            }
            else
            {
                    val_4 = null;
            }
            
            val_4 = null;
            return (string)SLC.Minigames.MinigamesKnobsManager.rawKnobs;
        }
        private static void RequestEconData()
        {
            var val_4;
            var val_5;
            var val_6;
            val_4 = null;
            val_4 = null;
            if(SLC.Minigames.MinigamesKnobsManager.requestingEconData != false)
            {
                    return;
            }
            
            val_5 = 1152921505028255760;
            SLC.Minigames.MinigamesKnobsManager.requestingEconData = true;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "p", value:  "a");
            Player val_2 = App.Player;
            val_1.Add(key:  "bucket", value:  val_2.playerBucket);
            val_6 = null;
            val_6 = null;
            App.networkManager.DoGet(path:  "/api/mini/knobs", onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  0, method:  static System.Void SLC.Minigames.MinigamesKnobsManager::OnEconDataRequestComplete(string apiCall, System.Collections.Generic.Dictionary<string, object> response)), destroy:  false, immediate:  false, getParams:  val_1, timeout:  20);
        }
        private static void OnEconDataRequestComplete(string apiCall, System.Collections.Generic.Dictionary<string, object> response)
        {
            var val_10;
            var val_12;
            if(((response != null) && ((response.ContainsKey(key:  "success")) != false)) && ((System.Boolean.Parse(value:  response.Item["success"])) != false))
            {
                    val_10 = null;
                val_10 = null;
                SLC.Minigames.MinigamesKnobsManager.rawKnobs = MiniJSON.Json.Serialize(obj:  response);
                UnityEngine.PlayerPrefs.SetString(key:  "mg_knbs", value:  SLC.Minigames.MinigamesKnobsManager.rawKnobs);
                bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
                if(SLC.Minigames.MinigamesKnobsManager.defaultKnobData != null)
            {
                    object val_6 = MiniJSON.Json.Deserialize(json:  SLC.Minigames.MinigamesKnobsManager.rawKnobs);
                new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                SLC.Minigames.MinigamesKnobsManager.defaultKnobData.Invoke(obj:  new twelvegigs.storage.JsonDictionary().getJsonDictionary(key:  "data").getJsonDictionary(key:  "knobs"));
            }
            
            }
            
            val_12 = null;
            val_12 = null;
            SLC.Minigames.MinigamesKnobsManager.requestingEconData = false;
        }
        public static twelvegigs.storage.JsonDictionary GetKnobs()
        {
            object val_2 = MiniJSON.Json.Deserialize(json:  SLC.Minigames.MinigamesKnobsManager.RetrieveRawKnobs());
            new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
            return new twelvegigs.storage.JsonDictionary().getJsonDictionary(key:  "data").getJsonDictionary(key:  "knobs");
        }
        private static MinigamesKnobsManager()
        {
        
        }
    
    }

}
