using UnityEngine;

namespace WordForest
{
    public class WFOPlayer : Player
    {
        // Fields
        private const string PREFKEY_STARS_BAL_TEMP = "wfo_acnbal_tmp";
        private const string PREFKEY_STARS_BAL_TEMP_WGS = "wfo_acnbal_tmp_wgs";
        private const string PREFKEY_STARS_BAL_TEMP_WMC = "wfo_acnbal_tmp_wmc";
        private const string PREFKEY_STARS_BAL_TEMP_WFC = "wfo_acnbal_tmp_wfc";
        private const string PREFKEY_STARS_BAL_TEMP_WRA = "wfo_acnbal_tmp_wra";
        private const string PREFKEY_STARS_BAL_TEMP_DAILY_CHALLENGE = "wfo_acnbal_tmp_dc";
        private const string PREFKEY_SHIELDS = "wfo_shields";
        private const string PREFKEY_TUTORIAL_COMPLETED = "wfo_tuts";
        private const string PREFKEY_WORDCHEST_CURRTYPE = "wfo_wrdcht_type";
        private const string PREFKEY_WORDCHEST_CURRREQ = "wfo_wrdcht_req";
        private const string PREFKEY_WORDCHEST_CURRCOMP = "wfo_wrdcht_comp";
        private const string PREFKEY_CHESTREWARDS = "wfo_cht_rews";
        private const string PREFKEY_CURR_FOREST = "wfo_curr_forest";
        private const string PREFKEY_CURR_CHEST = "wfo_curr_chest";
        private const string PREFKEY_CURR_GROWTH = "wfo_curr_growth";
        private const string PREKEY_FOREST_SERVER_ID = "wfo_frst_serv_id";
        private const string PREFKEY_LAST_SERVER_ACORNS = "wfo_lst_serv_acorns";
        private const string PREFKEY_LAST_SERVER_SHIELDS = "wfo_lst_serv_shields";
        private const string PREFKEY_FOREST_MAPDATA = "wfo_frst_mapdata";
        private const string PREFKEY_RAIDS_SENT = "wfo_raids_sent";
        private const string PREFKEY_RAIDS_RECEIVED = "wfo_raids_rec";
        private const string PREFKEY_ATTACKS_SENT = "wfo_attacks_sent";
        private const string PREFKEY_ATTACKS_RECEIVED = "wfo_attacks_rec";
        private const string PREFKEY_FOREST_VERSION = "wfo_forest_ver";
        private const int CURRENT_FOREST_VERSION = 1;
        public int ForestVersion;
        private EasySaver<WordForest.WFOPlayer> mySaver;
        private int starsLevelBalanceNormal;
        public int playingStarsFromGameplay;
        public int playingStarsFromMC;
        public int playingStarsFromFC;
        public int playingStarsFromRaid;
        private int starsLevelBalanceDailyChallenge;
        public int shields;
        public int tutorialCompleted;
        private int currentWordChestType;
        public int currentWordChestWordRequired;
        public int currentWordChestWordCompleted;
        public int currentForestID;
        public int forestServerId;
        public int currentChestID;
        private int currentForestGrowth;
        public WordForest.Map forestMapData;
        private int lastKnownServerAcorns;
        private int lastKnownServerShields;
        public int raidsSent;
        public int raidsReceived;
        public int attacksSent;
        public int attacksReceived;
        
        // Properties
        public static WordForest.WFOPlayer Instance { get; }
        public bool UpgradePlayer { get; }
        public int starsLevelBalance { get; set; }
        public int acorns { get; set; }
        public WordForest.WFOWordChestType CurrentWordChestType { get; set; }
        public string forestMapDataJson { get; }
        public int LastKnownServerAcorns { get; set; }
        public int LastKnownServerShields { get; set; }
        
        // Methods
        public static WordForest.WFOPlayer get_Instance()
        {
            Player val_1 = App.Player;
            if(val_1 == null)
            {
                    return (WordForest.WFOPlayer)val_1;
            }
            
            return (WordForest.WFOPlayer)val_1;
        }
        public bool get_UpgradePlayer()
        {
            return (bool)(this.ForestVersion < 1) ? 1 : 0;
        }
        public int get_starsLevelBalance()
        {
            var val_3 = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? 412 : 392;
            return (int)null;
        }
        public void set_starsLevelBalance(int value)
        {
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
            {
                    this.starsLevelBalanceDailyChallenge = value;
                return;
            }
            
            this.starsLevelBalanceNormal = value;
        }
        public int get_acorns()
        {
            return (int)this;
        }
        public void set_acorns(int value)
        {
            this.stars = value;
        }
        public WordForest.WFOWordChestType get_CurrentWordChestType()
        {
            return (WordForest.WFOWordChestType)this.currentWordChestType;
        }
        public void set_CurrentWordChestType(WordForest.WFOWordChestType value)
        {
            this.currentWordChestType = value;
        }
        public string get_forestMapDataJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.forestMapData);
        }
        public int get_LastKnownServerAcorns()
        {
            return (int)this.lastKnownServerAcorns;
        }
        public void set_LastKnownServerAcorns(int value)
        {
            this.lastKnownServerAcorns = value;
        }
        public int get_LastKnownServerShields()
        {
            return (int)this.lastKnownServerShields;
        }
        public void set_LastKnownServerShields(int value)
        {
            this.lastKnownServerShields = value;
        }
        public override void BuildReflectedLists()
        {
            this.mySaver = new EasySaver<WordForest.WFOPlayer>(incInstance:  this);
        }
        public override void AddHardSaves(ref System.Collections.Generic.Dictionary<string, object> incDic)
        {
            this.mySaver.AddHardSavesToDictionary(refdic: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = incDic);
        }
        protected override void TrustServerData(System.Collections.IDictionary diff)
        {
            this.TrustServerData(diff:  diff);
        }
        protected override void LoadFromLocal()
        {
            this.LoadFromLocal();
            this.starsLevelBalanceNormal = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp", defaultValue:  0);
            this.starsLevelBalanceDailyChallenge = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp_dc", defaultValue:  0);
            this.shields = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_shields");
            this.tutorialCompleted = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_tuts", defaultValue:  this.tutorialCompleted);
            this.currentWordChestType = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_wrdcht_type", defaultValue:  0);
            this.currentWordChestWordRequired = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_wrdcht_req", defaultValue:  0);
            this.currentWordChestWordCompleted = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_wrdcht_comp", defaultValue:  0);
            this.currentForestID = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_curr_forest", defaultValue:  1);
            this.currentForestGrowth = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_curr_growth", defaultValue:  0);
            this.currentChestID = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_curr_chest", defaultValue:  1);
            string val_11 = UnityEngine.PlayerPrefs.GetString(key:  "wfo_frst_mapdata", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_11)) != true)
            {
                    this.forestMapData = Newtonsoft.Json.JsonConvert.DeserializeObject<WordForest.Map>(value:  val_11);
            }
            
            this.lastKnownServerAcorns = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_lst_serv_acorns", defaultValue:  0);
            this.lastKnownServerShields = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_lst_serv_shields", defaultValue:  0);
            this.raidsSent = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_raids_sent", defaultValue:  0);
            this.raidsReceived = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_raids_rec", defaultValue:  0);
            this.attacksSent = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_attacks_sent", defaultValue:  0);
            this.attacksReceived = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_attacks_rec", defaultValue:  0);
            this.forestServerId = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_frst_serv_id", defaultValue:  0);
            this.ForestVersion = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_forest_ver", defaultValue:  0);
            this.playingStarsFromGameplay = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp_wgs", defaultValue:  0);
            this.playingStarsFromMC = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp_wmc", defaultValue:  0);
            this.playingStarsFromFC = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp_wfc", defaultValue:  0);
            this.playingStarsFromRaid = UnityEngine.PlayerPrefs.GetInt(key:  "wfo_acnbal_tmp_wra", defaultValue:  0);
            this.LocalDataIntegrityCheck();
        }
        protected override void CreateNewPlayer(string id = " ")
        {
            this.CreateNewPlayer(id:  id);
            GameBehavior val_1 = App.getBehavior;
            mem[1152921518179305328] = val_1.<metaGameBehavior>k__BackingField;
            this.starsLevelBalanceNormal = 0;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = 4.94065645841247E-324;
            this.currentChestID = 1;
            this.forestMapData = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  1, growthLevel:  0, growthPercent:  0f, dummyProfile:  false);
            this.ForestVersion = 1;
            mem2[0] = 0;
            mem2[0] = 0;
        }
        public override void SoftSave()
        {
            this.mySaver.SoftSaveLite();
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        protected override void Save()
        {
            this.mySaver.SoftSaveFull();
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        private void LocalDataIntegrityCheck()
        {
            if(this.forestMapData != null)
            {
                    return;
            }
            
            if((this.currentForestID <= 0) && (this.currentForestGrowth < 1))
            {
                    this.forestMapData = WordForest.WFOGameEconHelper.CreateMap(forestLevel:  1, growthLevel:  0, growthPercent:  0f, dummyProfile:  false);
                return;
            }
            
            int val_5 = this.currentForestID;
            this.forestMapData = WordForest.WFOGameEconHelper.MapDataV1ToV2Migration(oldForestId:  this.currentForestID, oldForestGrowth:  this.currentForestGrowth);
            val_5 = val_5 + 1;
            this.currentForestID = val_5;
            this.currentChestID = val_5;
            if(CompanyDevices.Instance.CompanyDevice() == false)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "[Data] Old forest data detected. Doing data migration.");
        }
        public WFOPlayer()
        {
        
        }
    
    }

}
