using UnityEngine;

namespace WADPets
{
    public class LevelTracking : EventProgression
    {
        // Fields
        private const string PREF_PET_LEVEL_TRACKING = "wadpet_level";
        private const string KEY_HAS_BONUS_ALPHABET_TILE = "has_bonus_alphabet_tile";
        private const string KEY_GAINED_ALPHABET_TILE = "gained_alphabet_tile";
        private const string KEY_HAS_ALPHABET_TILE_IN_LEVEL = "has_alphabet_tile_in_level";
        public bool HasBonusAlphabetTile;
        public bool GainedBonusAlphabetTile;
        public bool HasAlphabetTileInLevel;
        
        // Methods
        public void ResetLevelCompleteEvent()
        {
            this.HasBonusAlphabetTile = false;
            this.GainedBonusAlphabetTile = false;
            this.HasAlphabetTileInLevel = false;
            goto typeof(WADPets.LevelTracking).__il2cppRuntimeField_180;
        }
        public override void LoadFromJSON()
        {
            string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wadpet_level", defaultValue:  "");
            if((System.String.IsNullOrEmpty(value:  val_1)) == true)
            {
                    return;
            }
            
            object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
            if((val_3.ContainsKey(key:  "has_bonus_alphabet_tile")) != false)
            {
                    this.HasBonusAlphabetTile = System.Boolean.Parse(value:  val_3.Item["has_bonus_alphabet_tile"]);
            }
            
            if((val_3.ContainsKey(key:  "gained_alphabet_tile")) != false)
            {
                    this.GainedBonusAlphabetTile = System.Boolean.Parse(value:  val_3.Item["gained_alphabet_tile"]);
            }
            
            if((val_3.ContainsKey(key:  "has_alphabet_tile_in_level")) == false)
            {
                    return;
            }
            
            this.HasAlphabetTileInLevel = System.Boolean.Parse(value:  val_3.Item["has_alphabet_tile_in_level"]);
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "has_bonus_alphabet_tile", value:  this.HasBonusAlphabetTile);
            val_1.Add(key:  "gained_alphabet_tile", value:  this.GainedBonusAlphabetTile);
            val_1.Add(key:  "has_alphabet_tile_in_level", value:  this.HasAlphabetTileInLevel);
            UnityEngine.PlayerPrefs.SetString(key:  "wadpet_level", value:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public override void Delete()
        {
            UnityEngine.PlayerPrefs.DeleteKey(key:  "wadpet_level");
        }
        public LevelTracking()
        {
        
        }
    
    }

}
