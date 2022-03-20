using UnityEngine;

namespace WADPets
{
    public class LifetimeTracking : EventProgression
    {
        // Fields
        private const string PREF_LIFETIME_TRACKING = "wadpet_lifetime_tracking";
        private const string KEY_FOOD = "food";
        public int Food;
        
        // Methods
        public LifetimeTracking()
        {
            this.Food = 10;
        }
        public override void LoadFromJSON()
        {
            string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wadpet_lifetime_tracking", defaultValue:  "");
            if((System.String.IsNullOrEmpty(value:  val_1)) == true)
            {
                    return;
            }
            
            object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
            if((val_3.ContainsKey(key:  "food")) == false)
            {
                    return;
            }
            
            this.Food = System.Int32.Parse(s:  val_3.Item["food"]);
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "food", value:  this.Food);
            UnityEngine.PlayerPrefs.SetString(key:  "wadpet_lifetime_tracking", value:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        }
    
    }

}
