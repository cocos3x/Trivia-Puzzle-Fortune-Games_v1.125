using UnityEngine;

namespace WADPets
{
    [Serializable]
    public class WADPet : EventProgression
    {
        // Fields
        private const string PREF_PET = "wadpet";
        private const string KEY_LEVEL = "level";
        private const string KEY_UNLOCKED = "unlocked";
        private const string KEY_CARDS = "cards";
        private const string KEY_FTUX_SHOWN = "ftux_shown";
        public WADPets.WADPetInfo Info;
        public int LevelIndex;
        public bool IsUnlocked;
        public int Cards;
        public bool IsFtuxShown;
        public float CachedValueModifier;
        
        // Methods
        public WADPet(WADPets.WADPetInfo info)
        {
            this.Info = info;
            this.LevelIndex = 0;
            this.IsUnlocked = false;
            this.Cards = 0;
            this.CachedValueModifier = 0f;
            this.IsFtuxShown = false;
        }
        public bool IsActive()
        {
            var val_5;
            if(this.IsUnlocked != false)
            {
                    System.TimeSpan val_2 = MonoSingleton<WADPetsManager>.Instance.GetTimeCountdownToNextFeed();
                var val_4 = (val_2._ticks.TotalSeconds > 0f) ? 1 : 0;
                return (bool)val_5;
            }
            
            val_5 = 0;
            return (bool)val_5;
        }
        public WADPets.PetStatus GetStatus()
        {
            if(this.IsUnlocked == false)
            {
                    return 0;
            }
            
            return (WADPets.PetStatus)((this.IsActive() & true) != 0) ? (1 + 1) : 1;
        }
        public void Upgrade(int hackLevel = -1)
        {
            var val_11;
            int val_12 = hackLevel;
            if(val_12 != 1)
            {
                    if(this != null)
            {
                goto label_2;
            }
            
            }
            
            val_11 = WADPetsManager.GetUpgradeRequirement(levelIndex:  this.LevelIndex);
            this.Cards = this.Cards - val_1.Cards;
            this.Tracking_CardsSpent(amount:  val_1.Cards, prevCardsBalance:  WADPetsManager.GetCardsBalance(), isUpgrade:  (this.LevelIndex > 0) ? 1 : 0);
            if(val_1.Coins >= 1)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                val_5.Add(key:  "Pet Upgraded", value:  this.GetPrettyName());
                val_11 = App.Player;
                decimal val_8 = System.Decimal.op_Implicit(value:  -val_1.Coins);
                val_11.AddCredits(amount:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, source:  "Pet Upgraded", subSource:  0, externalParams:  val_5, doTrack:  true);
                NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate");
            }
            
            val_12 = this.LevelIndex + 1;
            label_2:
            this.LevelIndex = val_12;
            this.IsUnlocked = true;
        }
        public string GetPrettyName()
        {
            string val_1 = this.Info.Name.ToString();
            mem2[0] = this.Info.Name;
            return (string)System.String.Format(format:  "{0}{1}", arg0:  val_1.ToUpper().Chars[0], arg1:  val_1.ToLower().Substring(startIndex:  1));
        }
        public override void LoadFromJSON()
        {
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  this.GetPetPlayerprefKey(), defaultValue:  "");
            if((System.String.IsNullOrEmpty(value:  val_2)) == true)
            {
                    return;
            }
            
            object val_4 = MiniJSON.Json.Deserialize(json:  val_2);
            if((val_4.ContainsKey(key:  "level")) != false)
            {
                    object val_7 = val_4.Item["level"];
                if((val_4.ContainsKey(key:  "cards")) != false)
            {
                    bool val_9 = System.Int32.TryParse(s:  val_7, result: out  this.LevelIndex);
            }
            else
            {
                    bool val_11 = System.Int32.TryParse(s:  val_7, result: out  0);
                this.LevelIndex = 1;
            }
            
            }
            
            if((val_4.ContainsKey(key:  "unlocked")) != false)
            {
                    bool val_15 = System.Boolean.TryParse(value:  val_4.Item["unlocked"], result: out  this.IsUnlocked);
            }
            
            if((val_4.ContainsKey(key:  "cards")) != false)
            {
                    bool val_19 = System.Int32.TryParse(s:  val_4.Item["cards"], result: out  this.Cards);
            }
            
            if((val_4.ContainsKey(key:  "ftux_shown")) == false)
            {
                    return;
            }
            
            this = this.IsFtuxShown;
            bool val_23 = System.Boolean.TryParse(value:  val_4.Item["ftux_shown"], result: out  this);
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "level", value:  this.LevelIndex);
            val_1.Add(key:  "unlocked", value:  this.IsUnlocked);
            val_1.Add(key:  "cards", value:  this.Cards);
            val_1.Add(key:  "ftux_shown", value:  this.IsFtuxShown);
            UnityEngine.PlayerPrefs.SetString(key:  this.GetPetPlayerprefKey(), value:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public override void Delete()
        {
            this.DeleteKey(key:  this.GetPetPlayerprefKey());
        }
        private void SpendCards(int amount, int prevCardsBalance, bool isUpgrade)
        {
            int val_2 = this.Cards;
            val_2 = val_2 - amount;
            this.Cards = val_2;
            this.Tracking_CardsSpent(amount:  amount, prevCardsBalance:  prevCardsBalance, isUpgrade:  isUpgrade);
        }
        private void Tracking_CardsSpent(int amount, int prevCardsBalance, bool isUpgrade)
        {
            var val_5;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "Cards Spent", value:  amount);
            val_1.Add(key:  "Current Card Balance", value:  WADPetsManager.GetCardsBalance());
            val_1.Add(key:  "Previous Card Balance", value:  prevCardsBalance);
            val_1.Add(key:  "Pet", value:  this.GetPrettyName());
            val_1.Add(key:  "Pet Level", value:  this.LevelIndex);
            object val_5 = ~isUpgrade;
            val_5 = val_5 & 1;
            val_1.Add(key:  "Pet Unlocked", value:  val_5);
            val_1.Add(key:  "Pet Upgraded", value:  isUpgrade);
            val_5 = null;
            val_5 = null;
            App.trackerManager.track(eventName:  Events.CARDS_SPENT, data:  val_1);
        }
        private string GetPetPlayerprefKey()
        {
            return (string)System.String.Format(format:  "{0}_{1}", arg0:  "wadpet", arg1:  this.Info.Name);
        }
    
    }

}
