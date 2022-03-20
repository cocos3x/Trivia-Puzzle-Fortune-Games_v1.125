using UnityEngine;

namespace WordForest
{
    public class RaidAttackDataController : MonoBehaviour
    {
        // Fields
        private System.Collections.Generic.Dictionary<int, WordForest.UserForestProfile> serverProfiles;
        private System.Collections.Generic.Dictionary<int, WordForest.UserForestProfile> dummyProfiles;
        private System.Collections.Generic.List<int> cachedOpponentPoolRaid;
        private System.Collections.Generic.List<int> cachedOpponentPoolAttack;
        private System.Collections.Generic.List<WordForest.NewsArticle> newsArticles;
        private System.Nullable<System.DateTime> lastProcessedNewsTimestamp;
        public int shieldsInitialCount;
        private WordForest.UserForestProfile <QA_myself>k__BackingField;
        
        // Properties
        public System.Collections.Generic.List<WordForest.NewsArticle> NewsArticles { get; set; }
        public System.DateTime LastProcessedNewsTimestamp { get; set; }
        public WordForest.UserForestProfile QA_myself { get; set; }
        public string QA_RaidPoolIds { get; }
        public string QA_AttackPoolIds { get; }
        
        // Methods
        public System.Collections.Generic.List<WordForest.NewsArticle> get_NewsArticles()
        {
            if(this.newsArticles != null)
            {
                    return val_2;
            }
            
            System.Collections.Generic.List<WordForest.NewsArticle> val_2 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<WordForest.NewsArticle>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "wfo_news_list", defaultValue:  "[]"));
            this.newsArticles = val_2;
            return val_2;
        }
        public void set_NewsArticles(System.Collections.Generic.List<WordForest.NewsArticle> value)
        {
            this.newsArticles = value;
            UnityEngine.PlayerPrefs.SetString(key:  "wfo_news_list", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  value));
        }
        public System.DateTime get_LastProcessedNewsTimestamp()
        {
            var val_8;
            var val_9;
            if(true == 0)
            {
                    string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wfo_news_lastproc_ts", defaultValue:  0);
                if((System.String.IsNullOrEmpty(value:  val_1)) != false)
            {
                
            }
            else
            {
                    System.DateTime val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.DateTime>(value:  val_1);
                System.Nullable<System.DateTime> val_4 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = val_3.dateData});
                val_8 = 0;
                this.lastProcessedNewsTimestamp = val_4.HasValue;
                mem[1152921518071082328] = val_8;
            }
            
                if(val_8 == 255)
            {
                    val_9 = null;
                val_9 = null;
                System.Nullable<System.DateTime> val_5 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = System.DateTime.MinValue});
                this.lastProcessedNewsTimestamp = val_5.HasValue;
            }
            
            }
            
            System.DateTime val_6 = this.lastProcessedNewsTimestamp.Value;
            return (System.DateTime)val_6.dateData;
        }
        public void set_LastProcessedNewsTimestamp(System.DateTime value)
        {
            System.Nullable<System.DateTime> val_1 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = value.dateData});
            this.lastProcessedNewsTimestamp = val_1.HasValue;
            UnityEngine.PlayerPrefs.SetString(key:  "wfo_news_lastproc_ts", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  value));
        }
        public void AddOrUpdateServerProfileToCache(WordForest.UserForestProfile profile)
        {
            if((this.serverProfiles.ContainsKey(key:  profile.serverId)) != false)
            {
                    this.serverProfiles.Item[profile.serverId].Merge(model:  profile);
                return;
            }
            
            this.serverProfiles.Add(key:  profile.serverId, value:  profile);
        }
        public void AddOrUpdateDummyProfileToCache(WordForest.UserForestProfile profile)
        {
            if((this.dummyProfiles.ContainsKey(key:  profile.serverId)) != false)
            {
                    this.dummyProfiles.Item[profile.serverId].Merge(model:  profile);
                return;
            }
            
            this.dummyProfiles.Add(key:  profile.serverId, value:  profile);
        }
        public void CacheRaidOpponents(System.Collections.Generic.List<WordForest.UserForestProfile> profiles, bool isDummies = False)
        {
            if(profiles == null)
            {
                    return;
            }
            
            if(true < 1)
            {
                    return;
            }
            
            if(isDummies != true)
            {
                    this.cachedOpponentPoolRaid.Clear();
                if(1152921515441984688 < 1)
            {
                    return;
            }
            
            }
            
            var val_2 = 4;
            do
            {
                if(1152921515441984688 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(isDummies != false)
            {
                    this.AddOrUpdateDummyProfileToCache(profile:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info");
            }
            else
            {
                    this.AddOrUpdateServerProfileToCache(profile:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info");
            }
            
                if(1152921515441984688 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                this.cachedOpponentPoolRaid.Add(item:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info".__il2cppRuntimeField_10>>0&0xFFFFFFFF);
                val_2 = val_2 + 1;
            }
            while((val_2 - 4) < ("PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info"));
        
        }
        public void CacheAttackOpponents(System.Collections.Generic.List<WordForest.UserForestProfile> profiles, bool isDummies = False)
        {
            if(profiles == null)
            {
                    return;
            }
            
            if(true < 1)
            {
                    return;
            }
            
            if(isDummies != true)
            {
                    this.cachedOpponentPoolAttack.Clear();
                if(1152921515441984688 < 1)
            {
                    return;
            }
            
            }
            
            var val_2 = 4;
            do
            {
                if(1152921515441984688 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(isDummies != false)
            {
                    this.AddOrUpdateDummyProfileToCache(profile:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info");
            }
            else
            {
                    this.AddOrUpdateServerProfileToCache(profile:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info");
            }
            
                if(1152921515441984688 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                this.cachedOpponentPoolAttack.Add(item:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info".__il2cppRuntimeField_10>>0&0xFFFFFFFF);
                val_2 = val_2 + 1;
            }
            while((val_2 - 4) < ("PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info"));
        
        }
        public WordForest.UserForestProfile GetRandomRaidOpponent()
        {
            var val_6;
            bool val_7;
            System.Collections.Generic.List<System.Int32> val_8;
            var val_9;
            val_6 = this;
            System.Collections.Generic.List<WordForest.UserForestProfile> val_1 = null;
            val_7 = 1152921518071874640;
            val_1 = new System.Collections.Generic.List<WordForest.UserForestProfile>();
            val_8 = this.cachedOpponentPoolRaid;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_6 = 0;
            label_8:
            val_7 = 44190408;
            if(val_6 >= val_7)
            {
                goto label_2;
            }
            
            if(val_6 >= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = 44190408;
            WordForest.UserForestProfile val_2 = this.GetUserProfile(serverId:  301330432);
            if(val_2 != null)
            {
                    val_7 = val_2.isDummyAccount;
                if(val_7 != true)
            {
                    val_7 = val_2.<autoCreated>k__BackingField;
                if(val_7 != true)
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_1.Add(item:  val_2);
            }
            
            }
            
            }
            
            val_8 = this.cachedOpponentPoolRaid;
            val_6 = val_6 + 1;
            if(val_8 != null)
            {
                goto label_8;
            }
            
            throw new NullReferenceException();
            label_2:
            if(val_2 >= 1)
            {
                    int val_3 = UnityEngine.Random.Range(min:  0, max:  val_2);
                val_6 = val_3;
                if(val_7 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_7 = val_7 + (val_6 << 3);
                val_9 = mem[(val_2.<autoCreated>k__BackingField + (val_3) << 3) + 32];
                val_9 = (val_2.<autoCreated>k__BackingField + (val_3) << 3) + 32;
                return (WordForest.UserForestProfile)this.GetUserProfile(serverId:  (val_2.<autoCreated>k__BackingField + (val_4) << 2) + 32);
            }
            
            int val_4 = UnityEngine.Random.Range(min:  0, max:  val_7);
            if(val_7 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = val_7 + (val_4 << 2);
            return (WordForest.UserForestProfile)this.GetUserProfile(serverId:  (val_2.<autoCreated>k__BackingField + (val_4) << 2) + 32);
        }
        public WordForest.UserForestProfile GetRandomAttackOpponent()
        {
            var val_6;
            bool val_7;
            System.Collections.Generic.List<System.Int32> val_8;
            var val_9;
            val_6 = this;
            System.Collections.Generic.List<WordForest.UserForestProfile> val_1 = null;
            val_7 = 1152921518071874640;
            val_1 = new System.Collections.Generic.List<WordForest.UserForestProfile>();
            val_8 = this.cachedOpponentPoolAttack;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_6 = 0;
            label_8:
            val_7 = 44190408;
            if(val_6 >= val_7)
            {
                goto label_2;
            }
            
            if(val_6 >= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = 44190408;
            WordForest.UserForestProfile val_2 = this.GetUserProfile(serverId:  301330432);
            if(val_2 != null)
            {
                    val_7 = val_2.isDummyAccount;
                if(val_7 != true)
            {
                    val_7 = val_2.<autoCreated>k__BackingField;
                if(val_7 != true)
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_1.Add(item:  val_2);
            }
            
            }
            
            }
            
            val_8 = this.cachedOpponentPoolAttack;
            val_6 = val_6 + 1;
            if(val_8 != null)
            {
                goto label_8;
            }
            
            throw new NullReferenceException();
            label_2:
            if(val_2 >= 1)
            {
                    int val_3 = UnityEngine.Random.Range(min:  0, max:  val_2);
                val_6 = val_3;
                if(val_7 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_7 = val_7 + (val_6 << 3);
                val_9 = mem[(val_2.<autoCreated>k__BackingField + (val_3) << 3) + 32];
                val_9 = (val_2.<autoCreated>k__BackingField + (val_3) << 3) + 32;
                return (WordForest.UserForestProfile)this.GetUserProfile(serverId:  (val_2.<autoCreated>k__BackingField + (val_4) << 2) + 32);
            }
            
            int val_4 = UnityEngine.Random.Range(min:  0, max:  val_7);
            if(val_7 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_7 = val_7 + (val_4 << 2);
            return (WordForest.UserForestProfile)this.GetUserProfile(serverId:  (val_2.<autoCreated>k__BackingField + (val_4) << 2) + 32);
        }
        public WordForest.UserForestProfile GetUserProfile(int serverId)
        {
            if((this.serverProfiles.ContainsKey(key:  serverId)) != false)
            {
                    if(this.serverProfiles != null)
            {
                goto label_3;
            }
            
            }
            
            if((this.dummyProfiles.ContainsKey(key:  serverId)) == false)
            {
                    return 0;
            }
            
            label_3:
            WordForest.UserForestProfile val_3 = this.dummyProfiles.Item[serverId];
            return val_3.ProcessProfileForMissingData(profile:  val_3);
        }
        private WordForest.UserForestProfile ProcessProfileForMissingData(WordForest.UserForestProfile profile)
        {
            WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
            if(profile.serverId == val_1.forestServerId)
            {
                    return (WordForest.UserForestProfile)profile;
            }
            
            if(profile.map != null)
            {
                    if(profile.map.GetForestData() != null)
            {
                    System.Collections.Generic.List<WordForest.MapItem> val_3 = profile.map.GetForestData();
                if(val_1.forestServerId > 0)
            {
                    return (WordForest.UserForestProfile)profile;
            }
            
            }
            
            }
            
            profile.map = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  profile.level, growthLevel:  0, growthPercent:  UnityEngine.Random.Range(min:  0.3f, max:  1f), dummyProfile:  false);
            return (WordForest.UserForestProfile)profile;
        }
        public void ProcessNewsArticles(System.Collections.Generic.List<WordForest.NewsArticle> news)
        {
            var val_22;
            var val_23;
            System.Comparison<WordForest.NewsArticle> val_25;
            int val_26;
            var val_27;
            var val_28;
            var val_29;
            if(news == null)
            {
                    return;
            }
            
            if(true < 1)
            {
                    return;
            }
            
            this.NewsArticles = news;
            val_23 = null;
            val_23 = null;
            val_25 = RaidAttackDataController.<>c.<>9__21_0;
            if(val_25 == null)
            {
                    string val_2 = "GBK";
                val_25 = val_2;
                val_2 = new System.Comparison<WordForest.NewsArticle>(object:  RaidAttackDataController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 RaidAttackDataController.<>c::<ProcessNewsArticles>b__21_0(WordForest.NewsArticle a, WordForest.NewsArticle b));
                RaidAttackDataController.<>c.<>9__21_0 = val_25;
            }
            
            this.NewsArticles.Sort(comparison:  val_25);
            val_26 = this.shieldsInitialCount;
            System.Collections.Generic.List<WordForest.NewsArticle> val_3 = this.NewsArticles;
            System.Collections.Generic.List<WordForest.NewsArticle> val_4 = this.NewsArticles;
            val_22 = 1152921515419383392;
            var val_21 = 1318;
            label_56:
            if((44172279 & 2147483648) != 0)
            {
                goto label_11;
            }
            
            if(val_21 <= 44172279)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_21 = val_21 + 353378232;
            System.DateTime val_5 = this.LastProcessedNewsTimestamp;
            if((System.DateTime.Compare(t1:  new System.DateTime() {dateData = (1318 + 353378232) + 32 + 32}, t2:  new System.DateTime() {dateData = val_5.dateData})) >= 1)
            {
                    System.Collections.Generic.List<WordForest.NewsArticle> val_7 = this.NewsArticles;
                if(null <= 44172279)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((System.String.IsNullOrEmpty(value:  0x1000000015A73000.__il2cppRuntimeField_FD8 + 16 + 32)) != false)
            {
                    val_27 = 1;
            }
            else
            {
                    val_27 = 0x1000000015A73000.__il2cppRuntimeField_FD8 + 16 + 32.Contains(value:  "dummy");
            }
            
                if((0x1000000015A73000.__il2cppRuntimeField_FD8 + 24.Contains(value:  "attack")) != false)
            {
                    bool val_11 = 0x1000000015A73000.__il2cppRuntimeField_FD8 + 24.Contains(value:  "tried");
                if(val_11 != false)
            {
                    val_26 = UnityEngine.Mathf.Max(a:  val_26 - 1, b:  0);
            }
            
                System.Collections.Generic.Dictionary<System.String, System.Object> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                if(val_27 != true)
            {
                    val_14.Add(key:  "Attacker ID", value:  0x1000000015A73000.__il2cppRuntimeField_FD8 + 16 + 40);
            }
            
                val_14.Add(key:  "Shield Used", value:  val_11);
                val_14.Add(key:  "Shields Remaining", value:  val_26);
                val_28 = null;
                val_28 = null;
                App.trackerManager.track(eventName:  "Attacked", data:  val_14);
                WordForest.RaidAttackManager val_16 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                val_16.notifyController.Notify(note:  3, data:  0);
            }
            else
            {
                    if((0x1000000015A73000.__il2cppRuntimeField_FD8 + 24.Contains(value:  "stole")) != false)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                if(val_27 != true)
            {
                    val_18.Add(key:  "Raider ID", value:  0x1000000015A73000.__il2cppRuntimeField_FD8 + 16 + 40);
            }
            
                val_29 = null;
                val_29 = null;
                App.trackerManager.track(eventName:  "Raided", data:  val_18);
            }
            
            }
            
            }
            
            if(this.NewsArticles != null)
            {
                goto label_56;
            }
            
            label_11:
            if(val_21 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.LastProcessedNewsTimestamp = new System.DateTime() {dateData = mem[106679016291106848]};
            WordForest.RaidAttackManager val_20 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            val_20.notifyController.Notify(note:  5, data:  0);
        }
        public WordForest.UserForestProfile get_QA_myself()
        {
            return (WordForest.UserForestProfile)this.<QA_myself>k__BackingField;
        }
        public void set_QA_myself(WordForest.UserForestProfile value)
        {
            this.<QA_myself>k__BackingField = value;
        }
        public string get_QA_RaidPoolIds()
        {
            System.Collections.Generic.List<System.Int32> val_5;
            string val_6;
            int val_7;
            int val_8;
            var val_9;
            val_5 = this.cachedOpponentPoolRaid;
            var val_6 = 0;
            label_23:
            if(val_6 >= "")
            {
                    return "";
            }
            
            if(val_6 >= 44273376)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((this.GetUserProfile(serverId:  -1702363664)) == null)
            {
                goto label_4;
            }
            
            object[] val_2 = new object[4];
            val_5 = val_2;
            if(val_1.isDummyAccount == false)
            {
                goto label_5;
            }
            
            val_6 = "<color=#{0}>{1}: lvl{2}</color>{3}";
            goto label_6;
            label_5:
            val_6 = "<color=#{0}>{1}: lvl{2}</color>{3}";
            if((val_1.<autoCreated>k__BackingField) == false)
            {
                goto label_7;
            }
            
            label_6:
            label_25:
            val_7 = val_2.Length;
            val_5[0] = "EE0000";
            if(val_1.name != null)
            {
                    val_7 = val_2.Length;
            }
            
            val_5[1] = val_1.name;
            val_8 = val_2.Length;
            val_5[2] = val_1.level;
            System.Collections.Generic.List<System.Int32> val_5 = this.cachedOpponentPoolRaid;
            val_5 = val_5 - 1;
            val_9 = "\n";
            if(System.String.__il2cppRuntimeField_static_fields != 0)
            {
                    val_8 = val_2.Length;
            }
            
            val_5[3] = System.String.__il2cppRuntimeField_static_fields;
            string val_4 = "" + System.String.Format(format:  val_6, args:  val_2)(System.String.Format(format:  val_6, args:  val_2));
            label_4:
            val_6 = val_6 + 1;
            if(this.cachedOpponentPoolRaid != null)
            {
                goto label_23;
            }
            
            label_7:
            if(val_5 != null)
            {
                goto label_25;
            }
            
            throw new NullReferenceException();
        }
        public string get_QA_AttackPoolIds()
        {
            System.Collections.Generic.List<System.Int32> val_5;
            string val_6;
            int val_7;
            int val_8;
            var val_9;
            val_5 = this.cachedOpponentPoolAttack;
            var val_6 = 0;
            label_23:
            if(val_6 >= "")
            {
                    return "";
            }
            
            if(val_6 >= 44273376)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((this.GetUserProfile(serverId:  -1702363664)) == null)
            {
                goto label_4;
            }
            
            object[] val_2 = new object[4];
            val_5 = val_2;
            if(val_1.isDummyAccount == false)
            {
                goto label_5;
            }
            
            val_6 = "<color=#{0}>{1}: lvl{2}</color>{3}";
            goto label_6;
            label_5:
            val_6 = "<color=#{0}>{1}: lvl{2}</color>{3}";
            if((val_1.<autoCreated>k__BackingField) == false)
            {
                goto label_7;
            }
            
            label_6:
            label_25:
            val_7 = val_2.Length;
            val_5[0] = "EE0000";
            if(val_1.name != null)
            {
                    val_7 = val_2.Length;
            }
            
            val_5[1] = val_1.name;
            val_8 = val_2.Length;
            val_5[2] = val_1.level;
            System.Collections.Generic.List<System.Int32> val_5 = this.cachedOpponentPoolAttack;
            val_5 = val_5 - 1;
            val_9 = "\n";
            if(System.String.__il2cppRuntimeField_static_fields != 0)
            {
                    val_8 = val_2.Length;
            }
            
            val_5[3] = System.String.__il2cppRuntimeField_static_fields;
            string val_4 = "" + System.String.Format(format:  val_6, args:  val_2)(System.String.Format(format:  val_6, args:  val_2));
            label_4:
            val_6 = val_6 + 1;
            if(this.cachedOpponentPoolAttack != null)
            {
                goto label_23;
            }
            
            label_7:
            if(val_5 != null)
            {
                goto label_25;
            }
            
            throw new NullReferenceException();
        }
        public RaidAttackDataController()
        {
            this.serverProfiles = new System.Collections.Generic.Dictionary<System.Int32, WordForest.UserForestProfile>();
            this.dummyProfiles = new System.Collections.Generic.Dictionary<System.Int32, WordForest.UserForestProfile>();
            this.cachedOpponentPoolRaid = new System.Collections.Generic.List<System.Int32>();
            this.cachedOpponentPoolAttack = new System.Collections.Generic.List<System.Int32>();
        }
    
    }

}
