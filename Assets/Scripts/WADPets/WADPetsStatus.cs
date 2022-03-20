using UnityEngine;

namespace WADPets
{
    public class WADPetsStatus : EventProgression
    {
        // Fields
        private const string PREF_WADPETS_STATUS = "wadpets_status";
        private const string KEY_LAST_FED_TIME = "lastFed";
        public System.DateTime LastFedUtcTime;
        
        // Methods
        public override void LoadFromJSON()
        {
            string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wadpets_status", defaultValue:  "");
            if((System.String.IsNullOrEmpty(value:  val_1)) == true)
            {
                    return;
            }
            
            object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
            if((val_3.ContainsKey(key:  "lastFed")) == false)
            {
                    return;
            }
            
            System.DateTime val_6 = System.DateTime.UtcNow;
            System.DateTime val_7 = val_6.dateData.AddDays(value:  -1);
            System.DateTime val_8 = SLCDateTime.Parse(dateTime:  val_3.Item["lastFed"], defaultValue:  new System.DateTime() {dateData = val_7.dateData});
            this.LastFedUtcTime = val_8;
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "lastFed", value:  this.LastFedUtcTime.ToString());
            UnityEngine.PlayerPrefs.SetString(key:  "wadpets_status", value:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public WADPetsStatus()
        {
        
        }
    
    }

}
