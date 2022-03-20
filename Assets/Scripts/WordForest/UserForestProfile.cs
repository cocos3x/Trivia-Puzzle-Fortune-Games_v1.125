using UnityEngine;

namespace WordForest
{
    public class UserForestProfile : EncodableModel
    {
        // Fields
        public int serverId;
        public int avatarId;
        public string portraitID;
        public string name;
        public string facebookId;
        public int level;
        public int acorns;
        public int shields;
        public int raidsSent;
        public int raidsReceived;
        public int attacksSent;
        public int attacksReceived;
        public WordForest.Map map;
        public bool isOffline;
        private bool isDummyAccount;
        private bool <autoCreated>k__BackingField;
        public System.Collections.Generic.List<WordForest.NewsArticle> news;
        
        // Properties
        public bool IsDummyAccount { get; set; }
        protected bool autoCreated { get; set; }
        
        // Methods
        public bool get_IsDummyAccount()
        {
            if(this.isDummyAccount == false)
            {
                    return (bool)((this.<autoCreated>k__BackingField) == true) ? 1 : 0;
            }
            
            return true;
        }
        public void set_IsDummyAccount(bool value)
        {
            this.isDummyAccount = value;
        }
        protected void set_autoCreated(bool value)
        {
            this.<autoCreated>k__BackingField = value;
        }
        protected bool get_autoCreated()
        {
            return (bool)this.<autoCreated>k__BackingField;
        }
        public override void Decode(System.Collections.Generic.Dictionary<string, object> dict, EncodableModel.TemplateModel sourceModel = 0)
        {
            this.Decode(jasonObject:  dict, sourceModel:  0);
            if((dict.ContainsKey(key:  "map")) != false)
            {
                    this.map = Newtonsoft.Json.JsonConvert.DeserializeObject<WordForest.Map>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  dict.Item["map"]));
            }
            
            if((dict.ContainsKey(key:  "news")) != false)
            {
                    this.news = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<WordForest.NewsArticle>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  dict.Item["news"]));
            }
            
            if((dict.ContainsKey(key:  "auto_created")) == false)
            {
                    return;
            }
            
            if((System.Boolean.TryParse(value:  dict.Item["auto_created"], result: out  false)) == false)
            {
                    return;
            }
            
            this.<autoCreated>k__BackingField = false;
        }
        public void Merge(WordForest.UserForestProfile model)
        {
            model.Merge(model:  model);
            this.map = model.map;
        }
        public static WordForest.UserForestProfile CreateDummyProfile(int baseLevel, bool flexibleBaseLevel = True, float minTreesNormalized = 0.4, float maxTreesNormalized = 0.99)
        {
            var val_17;
            WordForest.WFOGameEcon val_1 = WordForest.WFOGameEcon.Instance;
            .isDummyAccount = true;
            .serverId = -(UnityEngine.Random.Range(min:  1, max:  232));
            .avatarId = UnityEngine.Random.Range(min:  0, max:  25);
            .name = System.String.Format(format:  "Player{0}", arg0:  UnityEngine.Random.Range(min:  232, max:  16));
            .acorns = UnityEngine.Random.Range(min:  32, max:  64);
            float val_10 = UnityEngine.Random.Range(min:  0f, max:  100f);
            val_17 = 0;
            int val_11 = (val_10 > val_1.attackSuccessRate) ? 1 : 0;
            val_11 = ((val_10 == 0f) ? 1 : 0) | val_11;
            .shields = val_11;
            if(flexibleBaseLevel != false)
            {
                    val_17 = 0;
            }
            
            int val_14 = (UnityEngine.Random.Range(min:  0, max:  2)) + (UnityEngine.Mathf.Max(a:  baseLevel, b:  UnityEngine.Mathf.Min(a:  val_1.rewardWordChestUnlockLevel, b:  val_1.mysteryChestUnlockLevel)));
            .level = val_14;
            .map = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  val_14, growthLevel:  0, growthPercent:  UnityEngine.Random.Range(min:  minTreesNormalized, max:  maxTreesNormalized), dummyProfile:  true);
            return (WordForest.UserForestProfile)new WordForest.UserForestProfile();
        }
        public UserForestProfile()
        {
            this.name = "Player";
            this.level = 1;
            this.facebookId = "";
        }
    
    }

}
