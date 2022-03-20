using UnityEngine;

namespace WordForest
{
    public class WFOGameEcon : GameEcon
    {
        // Fields
        public const string ECON_JSON_KNOBS = "wfo_econ_json_knobs";
        public int InitialPlayerGoldenCurrency;
        private int wordForestUnlockLevel;
        private int wordForestPopupLevel;
        private int rewardWordChestUnlockLevel;
        private int mysteryChestUnlockLevel;
        private int wordStreakUnlockLevel;
        private int wordStreakTutorialLevel;
        private int rewardFuseCount;
        private System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> wordChestWeight;
        private System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> wordChestRequiredWords;
        private System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> wordChestRewardAmount;
        private System.Collections.Generic.Dictionary<int, int> initialPlayerChestRewardInventory;
        private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<WordForest.WFORewardData>> mysteryRewards;
        private System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> raidEligibleAcornsMinMax;
        private System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> attackRewardAcorns;
        private System.Collections.Generic.List<WordForest.WFOForestData> forests;
        private System.Collections.Generic.Dictionary<WordForest.FtuxId, float> ftuxForestGrowthPercent;
        private System.Collections.Generic.Dictionary<WordForest.FtuxId, int> ftuxForestInitDestroyedTrees;
        private System.Collections.Generic.List<WordForest.WFOForestChestData> forestChests;
        public int mysteryGiftReward;
        public int offensiveActionsPerDay;
        public int daysOfOffensiveActionsPostSession;
        public float attackSuccessRate;
        public int maxUnblockAttacksReceived;
        public int maxRaidsReceived;
        
        // Properties
        public static WordForest.WFOGameEcon Instance { get; }
        public int MaxShields { get; }
        public int WordForestUnlockLevel { get; }
        public int WordForestPopupLevel { get; }
        public int RewardWordChestUnlockLevel { get; }
        public int MysteryChestUnlockLevel { get; }
        public int WordStreakUnlockLevel { get; }
        public int WordStreakTutorialLevel { get; }
        public int RewardFuseCount { get; }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> WordChestWeight { get; }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> WordChestRequiredWords { get; }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> WordChestRewardAmount { get; }
        public System.Collections.Generic.Dictionary<int, int> InitialPlayerChestRewardInventory { get; }
        public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<WordForest.WFORewardData>> MysteryRewards { get; }
        public System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> RaidEligibleAcornsMinMax { get; }
        public System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> AttackRewardAcorns { get; }
        public System.Collections.Generic.List<WordForest.WFOForestData> Forests { get; }
        public System.Collections.Generic.Dictionary<WordForest.FtuxId, float> FtuxForestGrowthPercent { get; }
        public System.Collections.Generic.Dictionary<WordForest.FtuxId, int> FtuxForestInitDestroyedTrees { get; }
        public System.Collections.Generic.List<WordForest.WFOForestChestData> ForestChests { get; }
        
        // Methods
        public static WordForest.WFOGameEcon get_Instance()
        {
            GameEcon val_1 = App.getGameEcon;
            if(val_1 == null)
            {
                    return (WordForest.WFOGameEcon)val_1;
            }
            
            return (WordForest.WFOGameEcon)val_1;
        }
        public int get_MaxShields()
        {
            return 3;
        }
        public int get_WordForestUnlockLevel()
        {
            return (int)this.wordForestUnlockLevel;
        }
        public int get_WordForestPopupLevel()
        {
            return (int)this.wordForestPopupLevel;
        }
        public int get_RewardWordChestUnlockLevel()
        {
            return (int)this.rewardWordChestUnlockLevel;
        }
        public int get_MysteryChestUnlockLevel()
        {
            return (int)this.mysteryChestUnlockLevel;
        }
        public int get_WordStreakUnlockLevel()
        {
            return (int)this.wordStreakUnlockLevel;
        }
        public int get_WordStreakTutorialLevel()
        {
            return (int)this.wordStreakTutorialLevel;
        }
        public int get_RewardFuseCount()
        {
            return (int)this.rewardFuseCount;
        }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> get_WordChestWeight()
        {
            return (System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>)this.wordChestWeight;
        }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> get_WordChestRequiredWords()
        {
            return (System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>)this.wordChestRequiredWords;
        }
        public System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, int> get_WordChestRewardAmount()
        {
            return (System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>)this.wordChestRewardAmount;
        }
        public System.Collections.Generic.Dictionary<int, int> get_InitialPlayerChestRewardInventory()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)this.initialPlayerChestRewardInventory;
        }
        public System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<WordForest.WFORewardData>> get_MysteryRewards()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<WordForest.WFORewardData>>)this.mysteryRewards;
        }
        public System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> get_RaidEligibleAcornsMinMax()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>)this.raidEligibleAcornsMinMax;
        }
        public System.Collections.Generic.Dictionary<int, UnityEngine.Vector2Int> get_AttackRewardAcorns()
        {
            return (System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>)this.attackRewardAcorns;
        }
        public System.Collections.Generic.List<WordForest.WFOForestData> get_Forests()
        {
            return (System.Collections.Generic.List<WordForest.WFOForestData>)this.forests;
        }
        public System.Collections.Generic.Dictionary<WordForest.FtuxId, float> get_FtuxForestGrowthPercent()
        {
            return (System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Single>)this.ftuxForestGrowthPercent;
        }
        public System.Collections.Generic.Dictionary<WordForest.FtuxId, int> get_FtuxForestInitDestroyedTrees()
        {
            return (System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Int32>)this.ftuxForestInitDestroyedTrees;
        }
        public System.Collections.Generic.List<WordForest.WFOForestChestData> get_ForestChests()
        {
            return (System.Collections.Generic.List<WordForest.WFOForestChestData>)this.forestChests;
        }
        public override void ReadFromKnobs()
        {
            System.Collections.IDictionary val_17;
            var val_18;
            this.ReadFromKnobs();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_17 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_18 = null;
            val_18 = null;
            if(getWordGameplayKnobs() != null)
            {
                    val_17 = val_2.dataSource;
            }
            
            if((val_17.ContainsKey(key:  "raa")) != false)
            {
                    object val_4 = val_17.Item["raa"];
                if((val_4.ContainsKey(key:  "asr")) != false)
            {
                    bool val_8 = System.Single.TryParse(s:  val_4.Item["asr"], result: out  this.attackSuccessRate);
            }
            
            }
            
            if((val_17.ContainsKey(key:  "gyf_pl")) != false)
            {
                    bool val_12 = System.Int32.TryParse(s:  val_17.Item["gyf_pl"], result: out  this.wordForestPopupLevel);
            }
            
            if((UnityEngine.PlayerPrefs.HasKey(key:  "wfo_econ_json_knobs")) == false)
            {
                    return;
            }
            
            string val_14 = UnityEngine.PlayerPrefs.GetString(key:  "wfo_econ_json_knobs", defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_14)) == true)
            {
                    return;
            }
            
            if((MiniJSON.Json.Deserialize(json:  val_14)) == null)
            {
                    return;
            }
        
        }
        public void CacheServerJsonKnobs(System.Collections.Generic.Dictionary<string, object> jsonDict)
        {
            UnityEngine.PlayerPrefs.SetString(key:  "wfo_econ_json_knobs", value:  MiniJSON.Json.Serialize(obj:  jsonDict));
            bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public void ParseServerJsonKnobs(System.Collections.Generic.Dictionary<string, object> jsonDict)
        {
            if((jsonDict.ContainsKey(key:  "mystery_chest_forest_level_unlock")) != false)
            {
                    bool val_4 = System.Int32.TryParse(s:  jsonDict.Item["mystery_chest_forest_level_unlock"], result: out  this.mysteryChestUnlockLevel);
            }
            
            if((jsonDict.ContainsKey(key:  "word_streak_forest_level_unlock")) != false)
            {
                    bool val_8 = System.Int32.TryParse(s:  jsonDict.Item["word_streak_forest_level_unlock"], result: out  this.wordStreakUnlockLevel);
            }
            
            if((jsonDict.ContainsKey(key:  "reward_chest_forest_level_unlock")) == false)
            {
                    return;
            }
            
            bool val_12 = System.Int32.TryParse(s:  jsonDict.Item["reward_chest_forest_level_unlock"], result: out  this.rewardWordChestUnlockLevel);
        }
        public WFOGameEcon()
        {
            mem2[0] = ;
            mem2[0] = ;
            System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32> val_1 = new System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>();
            val_1.Add(key:  1, value:  50);
            val_1.Add(key:  2, value:  30);
            val_1.Add(key:  3, value:  20);
            this.wordChestWeight = val_1;
            System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32> val_2 = new System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>();
            val_2.Add(key:  1, value:  15);
            val_2.Add(key:  2, value:  20);
            val_2.Add(key:  3, value:  25);
            this.wordChestRequiredWords = val_2;
            System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32> val_3 = new System.Collections.Generic.Dictionary<WordForest.WFOWordChestType, System.Int32>();
            val_3.Add(key:  1, value:  3);
            val_3.Add(key:  2, value:  5);
            val_3.Add(key:  3, value:  7);
            this.wordChestRewardAmount = val_3;
            System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_4 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
            val_4.Add(key:  0, value:  4);
            val_4.Add(key:  1, value:  4);
            val_4.Add(key:  2, value:  4);
            val_4.Add(key:  3, value:  4);
            val_4.Add(key:  4, value:  3);
            val_4.Add(key:  5, value:  3);
            val_4.Add(key:  6, value:  3);
            val_4.Add(key:  7, value:  2);
            val_4.Add(key:  8, value:  2);
            val_4.Add(key:  9, value:  2);
            val_4.Add(key:  10, value:  1);
            val_4.Add(key:  11, value:  1);
            val_4.Add(key:  24, value:  1);
            val_4.Add(key:  25, value:  1);
            val_4.Add(key:  27, value:  1);
            this.initialPlayerChestRewardInventory = val_4;
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<WordForest.WFORewardData>> val_5 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<WordForest.WFORewardData>>();
            val_5.Add(key:  1, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  3, acornMedium:  6, acornLarge:  15, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  2, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  3, acornMedium:  6, acornLarge:  15, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  3, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  5, acornMedium:  10, acornLarge:  25, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  4, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  7, acornMedium:  14, acornLarge:  35, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  5, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  9, acornMedium:  18, acornLarge:  45, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  6, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  11, acornMedium:  22, acornLarge:  55, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  7, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  13, acornMedium:  26, acornLarge:  65, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  8, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  15, acornMedium:  30, acornLarge:  75, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  9, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  17, acornMedium:  34, acornLarge:  85, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  10, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  19, acornMedium:  38, acornLarge:  95, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  11, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  21, acornMedium:  42, acornLarge:  105, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  12, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  23, acornMedium:  46, acornLarge:  115, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  13, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  25, acornMedium:  50, acornLarge:  125, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  14, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  27, acornMedium:  54, acornLarge:  135, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  15, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  29, acornMedium:  58, acornLarge:  145, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  16, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  31, acornMedium:  62, acornLarge:  155, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  17, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  33, acornMedium:  66, acornLarge:  165, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  18, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  35, acornMedium:  70, acornLarge:  175, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  19, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  37, acornMedium:  74, acornLarge:  185, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  20, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  39, acornMedium:  78, acornLarge:  195, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  21, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  41, acornMedium:  82, acornLarge:  205, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  22, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  43, acornMedium:  86, acornLarge:  215, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  23, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  45, acornMedium:  90, acornLarge:  225, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  24, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  47, acornMedium:  94, acornLarge:  235, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  25, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  49, acornMedium:  98, acornLarge:  245, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  26, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  51, acornMedium:  102, acornLarge:  255, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  27, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  53, acornMedium:  106, acornLarge:  9, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  28, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  55, acornMedium:  110, acornLarge:  19, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  29, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  57, acornMedium:  114, acornLarge:  29, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  30, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  59, acornMedium:  118, acornLarge:  39, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  31, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  61, acornMedium:  122, acornLarge:  49, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  32, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  63, acornMedium:  126, acornLarge:  59, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  33, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  65, acornMedium:  130, acornLarge:  69, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  34, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  67, acornMedium:  134, acornLarge:  79, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  35, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  69, acornMedium:  138, acornLarge:  89, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  36, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  71, acornMedium:  142, acornLarge:  99, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  37, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  73, acornMedium:  146, acornLarge:  109, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  38, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  75, acornMedium:  150, acornLarge:  119, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  39, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  77, acornMedium:  154, acornLarge:  129, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  40, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  79, acornMedium:  158, acornLarge:  139, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  41, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  81, acornMedium:  162, acornLarge:  149, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  42, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  83, acornMedium:  166, acornLarge:  159, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  43, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  85, acornMedium:  170, acornLarge:  169, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  44, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  87, acornMedium:  174, acornLarge:  179, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  45, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  89, acornMedium:  178, acornLarge:  189, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  46, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  91, acornMedium:  182, acornLarge:  199, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  47, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  93, acornMedium:  186, acornLarge:  209, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  48, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  95, acornMedium:  190, acornLarge:  219, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  49, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  97, acornMedium:  194, acornLarge:  229, coinSmall:  1, coinMedium:  2));
            val_5.Add(key:  50, value:  WordForest.WFOGameEconHelper.GetMysteryRewards(acornSmall:  99, acornMedium:  198, acornLarge:  239, coinSmall:  1, coinMedium:  2));
            this.mysteryRewards = val_5;
            System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int> val_56 = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>();
            UnityEngine.Vector2Int val_57 = new UnityEngine.Vector2Int(x:  18, y:  54);
            val_56.Add(key:  1, value:  new UnityEngine.Vector2Int() {m_X = val_57.m_X, m_Y = val_57.m_X});
            UnityEngine.Vector2Int val_58 = new UnityEngine.Vector2Int(x:  18, y:  54);
            val_56.Add(key:  2, value:  new UnityEngine.Vector2Int() {m_X = val_58.m_X, m_Y = val_58.m_X});
            UnityEngine.Vector2Int val_59 = new UnityEngine.Vector2Int(x:  30, y:  90);
            val_56.Add(key:  3, value:  new UnityEngine.Vector2Int() {m_X = val_59.m_X, m_Y = val_59.m_X});
            UnityEngine.Vector2Int val_60 = new UnityEngine.Vector2Int(x:  42, y:  126);
            val_56.Add(key:  4, value:  new UnityEngine.Vector2Int() {m_X = val_60.m_X, m_Y = val_60.m_X});
            UnityEngine.Vector2Int val_61 = new UnityEngine.Vector2Int(x:  54, y:  162);
            val_56.Add(key:  5, value:  new UnityEngine.Vector2Int() {m_X = val_61.m_X, m_Y = val_61.m_X});
            UnityEngine.Vector2Int val_62 = new UnityEngine.Vector2Int(x:  66, y:  198);
            val_56.Add(key:  6, value:  new UnityEngine.Vector2Int() {m_X = val_62.m_X, m_Y = val_62.m_X});
            UnityEngine.Vector2Int val_63 = new UnityEngine.Vector2Int(x:  78, y:  234);
            val_56.Add(key:  7, value:  new UnityEngine.Vector2Int() {m_X = val_63.m_X, m_Y = val_63.m_X});
            UnityEngine.Vector2Int val_64 = new UnityEngine.Vector2Int(x:  90, y:  14);
            val_56.Add(key:  8, value:  new UnityEngine.Vector2Int() {m_X = val_64.m_X, m_Y = val_64.m_X});
            UnityEngine.Vector2Int val_65 = new UnityEngine.Vector2Int(x:  102, y:  50);
            val_56.Add(key:  9, value:  new UnityEngine.Vector2Int() {m_X = val_65.m_X, m_Y = val_65.m_X});
            UnityEngine.Vector2Int val_66 = new UnityEngine.Vector2Int(x:  114, y:  86);
            val_56.Add(key:  10, value:  new UnityEngine.Vector2Int() {m_X = val_66.m_X, m_Y = val_66.m_X});
            UnityEngine.Vector2Int val_67 = new UnityEngine.Vector2Int(x:  126, y:  122);
            val_56.Add(key:  11, value:  new UnityEngine.Vector2Int() {m_X = val_67.m_X, m_Y = val_67.m_X});
            UnityEngine.Vector2Int val_68 = new UnityEngine.Vector2Int(x:  138, y:  158);
            val_56.Add(key:  12, value:  new UnityEngine.Vector2Int() {m_X = val_68.m_X, m_Y = val_68.m_X});
            UnityEngine.Vector2Int val_69 = new UnityEngine.Vector2Int(x:  150, y:  194);
            val_56.Add(key:  13, value:  new UnityEngine.Vector2Int() {m_X = val_69.m_X, m_Y = val_69.m_X});
            UnityEngine.Vector2Int val_70 = new UnityEngine.Vector2Int(x:  162, y:  230);
            val_56.Add(key:  14, value:  new UnityEngine.Vector2Int() {m_X = val_70.m_X, m_Y = val_70.m_X});
            UnityEngine.Vector2Int val_71 = new UnityEngine.Vector2Int(x:  174, y:  10);
            val_56.Add(key:  15, value:  new UnityEngine.Vector2Int() {m_X = val_71.m_X, m_Y = val_71.m_X});
            UnityEngine.Vector2Int val_72 = new UnityEngine.Vector2Int(x:  186, y:  46);
            val_56.Add(key:  16, value:  new UnityEngine.Vector2Int() {m_X = val_72.m_X, m_Y = val_72.m_X});
            UnityEngine.Vector2Int val_73 = new UnityEngine.Vector2Int(x:  198, y:  82);
            val_56.Add(key:  17, value:  new UnityEngine.Vector2Int() {m_X = val_73.m_X, m_Y = val_73.m_X});
            UnityEngine.Vector2Int val_74 = new UnityEngine.Vector2Int(x:  210, y:  118);
            val_56.Add(key:  18, value:  new UnityEngine.Vector2Int() {m_X = val_74.m_X, m_Y = val_74.m_X});
            UnityEngine.Vector2Int val_75 = new UnityEngine.Vector2Int(x:  222, y:  154);
            val_56.Add(key:  19, value:  new UnityEngine.Vector2Int() {m_X = val_75.m_X, m_Y = val_75.m_X});
            UnityEngine.Vector2Int val_76 = new UnityEngine.Vector2Int(x:  234, y:  190);
            val_56.Add(key:  20, value:  new UnityEngine.Vector2Int() {m_X = val_76.m_X, m_Y = val_76.m_X});
            UnityEngine.Vector2Int val_77 = new UnityEngine.Vector2Int(x:  246, y:  226);
            val_56.Add(key:  21, value:  new UnityEngine.Vector2Int() {m_X = val_77.m_X, m_Y = val_77.m_X});
            UnityEngine.Vector2Int val_78 = new UnityEngine.Vector2Int(x:  2, y:  6);
            val_56.Add(key:  22, value:  new UnityEngine.Vector2Int() {m_X = val_78.m_X, m_Y = val_78.m_X});
            UnityEngine.Vector2Int val_79 = new UnityEngine.Vector2Int(x:  14, y:  42);
            val_56.Add(key:  23, value:  new UnityEngine.Vector2Int() {m_X = val_79.m_X, m_Y = val_79.m_X});
            UnityEngine.Vector2Int val_80 = new UnityEngine.Vector2Int(x:  26, y:  78);
            val_56.Add(key:  24, value:  new UnityEngine.Vector2Int() {m_X = val_80.m_X, m_Y = val_80.m_X});
            UnityEngine.Vector2Int val_81 = new UnityEngine.Vector2Int(x:  38, y:  114);
            val_56.Add(key:  25, value:  new UnityEngine.Vector2Int() {m_X = val_81.m_X, m_Y = val_81.m_X});
            UnityEngine.Vector2Int val_82 = new UnityEngine.Vector2Int(x:  50, y:  150);
            val_56.Add(key:  26, value:  new UnityEngine.Vector2Int() {m_X = val_82.m_X, m_Y = val_82.m_X});
            UnityEngine.Vector2Int val_83 = new UnityEngine.Vector2Int(x:  62, y:  186);
            val_56.Add(key:  27, value:  new UnityEngine.Vector2Int() {m_X = val_83.m_X, m_Y = val_83.m_X});
            UnityEngine.Vector2Int val_84 = new UnityEngine.Vector2Int(x:  74, y:  222);
            val_56.Add(key:  28, value:  new UnityEngine.Vector2Int() {m_X = val_84.m_X, m_Y = val_84.m_X});
            UnityEngine.Vector2Int val_85 = new UnityEngine.Vector2Int(x:  86, y:  2);
            val_56.Add(key:  29, value:  new UnityEngine.Vector2Int() {m_X = val_85.m_X, m_Y = val_85.m_X});
            UnityEngine.Vector2Int val_86 = new UnityEngine.Vector2Int(x:  98, y:  38);
            val_56.Add(key:  30, value:  new UnityEngine.Vector2Int() {m_X = val_86.m_X, m_Y = val_86.m_X});
            UnityEngine.Vector2Int val_87 = new UnityEngine.Vector2Int(x:  110, y:  74);
            val_56.Add(key:  31, value:  new UnityEngine.Vector2Int() {m_X = val_87.m_X, m_Y = val_87.m_X});
            UnityEngine.Vector2Int val_88 = new UnityEngine.Vector2Int(x:  122, y:  110);
            val_56.Add(key:  32, value:  new UnityEngine.Vector2Int() {m_X = val_88.m_X, m_Y = val_88.m_X});
            UnityEngine.Vector2Int val_89 = new UnityEngine.Vector2Int(x:  134, y:  146);
            val_56.Add(key:  33, value:  new UnityEngine.Vector2Int() {m_X = val_89.m_X, m_Y = val_89.m_X});
            UnityEngine.Vector2Int val_90 = new UnityEngine.Vector2Int(x:  146, y:  182);
            val_56.Add(key:  34, value:  new UnityEngine.Vector2Int() {m_X = val_90.m_X, m_Y = val_90.m_X});
            UnityEngine.Vector2Int val_91 = new UnityEngine.Vector2Int(x:  158, y:  218);
            val_56.Add(key:  35, value:  new UnityEngine.Vector2Int() {m_X = val_91.m_X, m_Y = val_91.m_X});
            UnityEngine.Vector2Int val_92 = new UnityEngine.Vector2Int(x:  170, y:  254);
            val_56.Add(key:  36, value:  new UnityEngine.Vector2Int() {m_X = val_92.m_X, m_Y = val_92.m_X});
            UnityEngine.Vector2Int val_93 = new UnityEngine.Vector2Int(x:  182, y:  34);
            val_56.Add(key:  37, value:  new UnityEngine.Vector2Int() {m_X = val_93.m_X, m_Y = val_93.m_X});
            UnityEngine.Vector2Int val_94 = new UnityEngine.Vector2Int(x:  194, y:  70);
            val_56.Add(key:  38, value:  new UnityEngine.Vector2Int() {m_X = val_94.m_X, m_Y = val_94.m_X});
            UnityEngine.Vector2Int val_95 = new UnityEngine.Vector2Int(x:  206, y:  106);
            val_56.Add(key:  39, value:  new UnityEngine.Vector2Int() {m_X = val_95.m_X, m_Y = val_95.m_X});
            UnityEngine.Vector2Int val_96 = new UnityEngine.Vector2Int(x:  218, y:  142);
            val_56.Add(key:  40, value:  new UnityEngine.Vector2Int() {m_X = val_96.m_X, m_Y = val_96.m_X});
            UnityEngine.Vector2Int val_97 = new UnityEngine.Vector2Int(x:  230, y:  178);
            val_56.Add(key:  41, value:  new UnityEngine.Vector2Int() {m_X = val_97.m_X, m_Y = val_97.m_X});
            UnityEngine.Vector2Int val_98 = new UnityEngine.Vector2Int(x:  242, y:  214);
            val_56.Add(key:  42, value:  new UnityEngine.Vector2Int() {m_X = val_98.m_X, m_Y = val_98.m_X});
            UnityEngine.Vector2Int val_99 = new UnityEngine.Vector2Int(x:  510, y:  250);
            val_56.Add(key:  43, value:  new UnityEngine.Vector2Int() {m_X = val_99.m_X, m_Y = val_99.m_X});
            UnityEngine.Vector2Int val_100 = new UnityEngine.Vector2Int(x:  10, y:  30);
            val_56.Add(key:  44, value:  new UnityEngine.Vector2Int() {m_X = val_100.m_X, m_Y = val_100.m_X});
            UnityEngine.Vector2Int val_101 = new UnityEngine.Vector2Int(x:  22, y:  66);
            val_56.Add(key:  45, value:  new UnityEngine.Vector2Int() {m_X = val_101.m_X, m_Y = val_101.m_X});
            UnityEngine.Vector2Int val_102 = new UnityEngine.Vector2Int(x:  34, y:  102);
            val_56.Add(key:  46, value:  new UnityEngine.Vector2Int() {m_X = val_102.m_X, m_Y = val_102.m_X});
            UnityEngine.Vector2Int val_103 = new UnityEngine.Vector2Int(x:  46, y:  138);
            val_56.Add(key:  47, value:  new UnityEngine.Vector2Int() {m_X = val_103.m_X, m_Y = val_103.m_X});
            UnityEngine.Vector2Int val_104 = new UnityEngine.Vector2Int(x:  58, y:  174);
            val_56.Add(key:  48, value:  new UnityEngine.Vector2Int() {m_X = val_104.m_X, m_Y = val_104.m_X});
            UnityEngine.Vector2Int val_105 = new UnityEngine.Vector2Int(x:  70, y:  210);
            val_56.Add(key:  49, value:  new UnityEngine.Vector2Int() {m_X = val_105.m_X, m_Y = val_105.m_X});
            UnityEngine.Vector2Int val_106 = new UnityEngine.Vector2Int(x:  82, y:  246);
            val_56.Add(key:  50, value:  new UnityEngine.Vector2Int() {m_X = val_106.m_X, m_Y = val_106.m_X});
            this.raidEligibleAcornsMinMax = val_56;
            System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int> val_107 = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>();
            UnityEngine.Vector2Int val_108 = new UnityEngine.Vector2Int(x:  9, y:  30);
            val_107.Add(key:  1, value:  new UnityEngine.Vector2Int() {m_X = val_108.m_X, m_Y = val_108.m_X});
            UnityEngine.Vector2Int val_109 = new UnityEngine.Vector2Int(x:  9, y:  30);
            val_107.Add(key:  2, value:  new UnityEngine.Vector2Int() {m_X = val_109.m_X, m_Y = val_109.m_X});
            UnityEngine.Vector2Int val_110 = new UnityEngine.Vector2Int(x:  15, y:  50);
            val_107.Add(key:  3, value:  new UnityEngine.Vector2Int() {m_X = val_110.m_X, m_Y = val_110.m_X});
            UnityEngine.Vector2Int val_111 = new UnityEngine.Vector2Int(x:  21, y:  70);
            val_107.Add(key:  4, value:  new UnityEngine.Vector2Int() {m_X = val_111.m_X, m_Y = val_111.m_X});
            UnityEngine.Vector2Int val_112 = new UnityEngine.Vector2Int(x:  27, y:  90);
            val_107.Add(key:  5, value:  new UnityEngine.Vector2Int() {m_X = val_112.m_X, m_Y = val_112.m_X});
            UnityEngine.Vector2Int val_113 = new UnityEngine.Vector2Int(x:  33, y:  110);
            val_107.Add(key:  6, value:  new UnityEngine.Vector2Int() {m_X = val_113.m_X, m_Y = val_113.m_X});
            UnityEngine.Vector2Int val_114 = new UnityEngine.Vector2Int(x:  39, y:  130);
            val_107.Add(key:  7, value:  new UnityEngine.Vector2Int() {m_X = val_114.m_X, m_Y = val_114.m_X});
            UnityEngine.Vector2Int val_115 = new UnityEngine.Vector2Int(x:  45, y:  150);
            val_107.Add(key:  8, value:  new UnityEngine.Vector2Int() {m_X = val_115.m_X, m_Y = val_115.m_X});
            UnityEngine.Vector2Int val_116 = new UnityEngine.Vector2Int(x:  51, y:  170);
            val_107.Add(key:  9, value:  new UnityEngine.Vector2Int() {m_X = val_116.m_X, m_Y = val_116.m_X});
            UnityEngine.Vector2Int val_117 = new UnityEngine.Vector2Int(x:  57, y:  190);
            val_107.Add(key:  10, value:  new UnityEngine.Vector2Int() {m_X = val_117.m_X, m_Y = val_117.m_X});
            UnityEngine.Vector2Int val_118 = new UnityEngine.Vector2Int(x:  63, y:  210);
            val_107.Add(key:  11, value:  new UnityEngine.Vector2Int() {m_X = val_118.m_X, m_Y = val_118.m_X});
            UnityEngine.Vector2Int val_119 = new UnityEngine.Vector2Int(x:  69, y:  230);
            val_107.Add(key:  12, value:  new UnityEngine.Vector2Int() {m_X = val_119.m_X, m_Y = val_119.m_X});
            UnityEngine.Vector2Int val_120 = new UnityEngine.Vector2Int(x:  75, y:  250);
            val_107.Add(key:  13, value:  new UnityEngine.Vector2Int() {m_X = val_120.m_X, m_Y = val_120.m_X});
            UnityEngine.Vector2Int val_121 = new UnityEngine.Vector2Int(x:  81, y:  14);
            val_107.Add(key:  14, value:  new UnityEngine.Vector2Int() {m_X = val_121.m_X, m_Y = val_121.m_X});
            UnityEngine.Vector2Int val_122 = new UnityEngine.Vector2Int(x:  87, y:  34);
            val_107.Add(key:  15, value:  new UnityEngine.Vector2Int() {m_X = val_122.m_X, m_Y = val_122.m_X});
            UnityEngine.Vector2Int val_123 = new UnityEngine.Vector2Int(x:  93, y:  54);
            val_107.Add(key:  16, value:  new UnityEngine.Vector2Int() {m_X = val_123.m_X, m_Y = val_123.m_X});
            UnityEngine.Vector2Int val_124 = new UnityEngine.Vector2Int(x:  99, y:  74);
            val_107.Add(key:  17, value:  new UnityEngine.Vector2Int() {m_X = val_124.m_X, m_Y = val_124.m_X});
            UnityEngine.Vector2Int val_125 = new UnityEngine.Vector2Int(x:  105, y:  94);
            val_107.Add(key:  18, value:  new UnityEngine.Vector2Int() {m_X = val_125.m_X, m_Y = val_125.m_X});
            UnityEngine.Vector2Int val_126 = new UnityEngine.Vector2Int(x:  111, y:  114);
            val_107.Add(key:  19, value:  new UnityEngine.Vector2Int() {m_X = val_126.m_X, m_Y = val_126.m_X});
            UnityEngine.Vector2Int val_127 = new UnityEngine.Vector2Int(x:  117, y:  134);
            val_107.Add(key:  20, value:  new UnityEngine.Vector2Int() {m_X = val_127.m_X, m_Y = val_127.m_X});
            UnityEngine.Vector2Int val_128 = new UnityEngine.Vector2Int(x:  123, y:  154);
            val_107.Add(key:  21, value:  new UnityEngine.Vector2Int() {m_X = val_128.m_X, m_Y = val_128.m_X});
            UnityEngine.Vector2Int val_129 = new UnityEngine.Vector2Int(x:  129, y:  174);
            val_107.Add(key:  22, value:  new UnityEngine.Vector2Int() {m_X = val_129.m_X, m_Y = val_129.m_X});
            UnityEngine.Vector2Int val_130 = new UnityEngine.Vector2Int(x:  135, y:  194);
            val_107.Add(key:  23, value:  new UnityEngine.Vector2Int() {m_X = val_130.m_X, m_Y = val_130.m_X});
            UnityEngine.Vector2Int val_131 = new UnityEngine.Vector2Int(x:  141, y:  214);
            val_107.Add(key:  24, value:  new UnityEngine.Vector2Int() {m_X = val_131.m_X, m_Y = val_131.m_X});
            UnityEngine.Vector2Int val_132 = new UnityEngine.Vector2Int(x:  147, y:  234);
            val_107.Add(key:  25, value:  new UnityEngine.Vector2Int() {m_X = val_132.m_X, m_Y = val_132.m_X});
            UnityEngine.Vector2Int val_133 = new UnityEngine.Vector2Int(x:  153, y:  510);
            val_107.Add(key:  26, value:  new UnityEngine.Vector2Int() {m_X = val_133.m_X, m_Y = val_133.m_X});
            UnityEngine.Vector2Int val_134 = new UnityEngine.Vector2Int(x:  159, y:  18);
            val_107.Add(key:  27, value:  new UnityEngine.Vector2Int() {m_X = val_134.m_X, m_Y = val_134.m_X});
            UnityEngine.Vector2Int val_135 = new UnityEngine.Vector2Int(x:  165, y:  38);
            val_107.Add(key:  28, value:  new UnityEngine.Vector2Int() {m_X = val_135.m_X, m_Y = val_135.m_X});
            UnityEngine.Vector2Int val_136 = new UnityEngine.Vector2Int(x:  171, y:  58);
            val_107.Add(key:  29, value:  new UnityEngine.Vector2Int() {m_X = val_136.m_X, m_Y = val_136.m_X});
            UnityEngine.Vector2Int val_137 = new UnityEngine.Vector2Int(x:  177, y:  78);
            val_107.Add(key:  30, value:  new UnityEngine.Vector2Int() {m_X = val_137.m_X, m_Y = val_137.m_X});
            UnityEngine.Vector2Int val_138 = new UnityEngine.Vector2Int(x:  183, y:  98);
            val_107.Add(key:  31, value:  new UnityEngine.Vector2Int() {m_X = val_138.m_X, m_Y = val_138.m_X});
            UnityEngine.Vector2Int val_139 = new UnityEngine.Vector2Int(x:  189, y:  118);
            val_107.Add(key:  32, value:  new UnityEngine.Vector2Int() {m_X = val_139.m_X, m_Y = val_139.m_X});
            UnityEngine.Vector2Int val_140 = new UnityEngine.Vector2Int(x:  195, y:  138);
            val_107.Add(key:  33, value:  new UnityEngine.Vector2Int() {m_X = val_140.m_X, m_Y = val_140.m_X});
            UnityEngine.Vector2Int val_141 = new UnityEngine.Vector2Int(x:  201, y:  158);
            val_107.Add(key:  34, value:  new UnityEngine.Vector2Int() {m_X = val_141.m_X, m_Y = val_141.m_X});
            UnityEngine.Vector2Int val_142 = new UnityEngine.Vector2Int(x:  207, y:  178);
            val_107.Add(key:  35, value:  new UnityEngine.Vector2Int() {m_X = val_142.m_X, m_Y = val_142.m_X});
            UnityEngine.Vector2Int val_143 = new UnityEngine.Vector2Int(x:  213, y:  198);
            val_107.Add(key:  36, value:  new UnityEngine.Vector2Int() {m_X = val_143.m_X, m_Y = val_143.m_X});
            UnityEngine.Vector2Int val_144 = new UnityEngine.Vector2Int(x:  219, y:  218);
            val_107.Add(key:  37, value:  new UnityEngine.Vector2Int() {m_X = val_144.m_X, m_Y = val_144.m_X});
            UnityEngine.Vector2Int val_145 = new UnityEngine.Vector2Int(x:  225, y:  238);
            val_107.Add(key:  38, value:  new UnityEngine.Vector2Int() {m_X = val_145.m_X, m_Y = val_145.m_X});
            UnityEngine.Vector2Int val_146 = new UnityEngine.Vector2Int(x:  231, y:  2);
            val_107.Add(key:  39, value:  new UnityEngine.Vector2Int() {m_X = val_146.m_X, m_Y = val_146.m_X});
            UnityEngine.Vector2Int val_147 = new UnityEngine.Vector2Int(x:  237, y:  22);
            val_107.Add(key:  40, value:  new UnityEngine.Vector2Int() {m_X = val_147.m_X, m_Y = val_147.m_X});
            UnityEngine.Vector2Int val_148 = new UnityEngine.Vector2Int(x:  243, y:  42);
            val_107.Add(key:  41, value:  new UnityEngine.Vector2Int() {m_X = val_148.m_X, m_Y = val_148.m_X});
            UnityEngine.Vector2Int val_149 = new UnityEngine.Vector2Int(x:  249, y:  62);
            val_107.Add(key:  42, value:  new UnityEngine.Vector2Int() {m_X = val_149.m_X, m_Y = val_149.m_X});
            UnityEngine.Vector2Int val_150 = new UnityEngine.Vector2Int(x:  255, y:  82);
            val_107.Add(key:  43, value:  new UnityEngine.Vector2Int() {m_X = val_150.m_X, m_Y = val_150.m_X});
            UnityEngine.Vector2Int val_151 = new UnityEngine.Vector2Int(x:  5, y:  102);
            val_107.Add(key:  44, value:  new UnityEngine.Vector2Int() {m_X = val_151.m_X, m_Y = val_151.m_X});
            UnityEngine.Vector2Int val_152 = new UnityEngine.Vector2Int(x:  11, y:  122);
            val_107.Add(key:  45, value:  new UnityEngine.Vector2Int() {m_X = val_152.m_X, m_Y = val_152.m_X});
            UnityEngine.Vector2Int val_153 = new UnityEngine.Vector2Int(x:  17, y:  142);
            val_107.Add(key:  46, value:  new UnityEngine.Vector2Int() {m_X = val_153.m_X, m_Y = val_153.m_X});
            UnityEngine.Vector2Int val_154 = new UnityEngine.Vector2Int(x:  23, y:  162);
            val_107.Add(key:  47, value:  new UnityEngine.Vector2Int() {m_X = val_154.m_X, m_Y = val_154.m_X});
            UnityEngine.Vector2Int val_155 = new UnityEngine.Vector2Int(x:  29, y:  182);
            val_107.Add(key:  48, value:  new UnityEngine.Vector2Int() {m_X = val_155.m_X, m_Y = val_155.m_X});
            UnityEngine.Vector2Int val_156 = new UnityEngine.Vector2Int(x:  35, y:  202);
            val_107.Add(key:  49, value:  new UnityEngine.Vector2Int() {m_X = val_156.m_X, m_Y = val_156.m_X});
            UnityEngine.Vector2Int val_157 = new UnityEngine.Vector2Int(x:  41, y:  222);
            val_107.Add(key:  50, value:  new UnityEngine.Vector2Int() {m_X = val_157.m_X, m_Y = val_157.m_X});
            this.attackRewardAcorns = val_107;
            System.Collections.Generic.List<WordForest.WFOForestData> val_158 = new System.Collections.Generic.List<WordForest.WFOForestData>();
            val_158.Add(item:  new WordForest.WFOForestData() {level = 1, forestName = "Summer Lake", initialCost = 1, costIncrease = 1, stages = 10, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 2, forestName = "Southwestern Desert", initialCost = 240, costIncrease = 10, stages = 15, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 3, forestName = "Snowy Mountain", initialCost = 540, costIncrease = 15, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 4, forestName = "Amazon Rainforest", initialCost = 1030, costIncrease = 20, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 5, forestName = "Autumn Woods", initialCost = 1720, costIncrease = 25, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 6, forestName = "Tropical Island", initialCost = 2640, costIncrease = 30, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 7, forestName = "Aussie Outback", initialCost = 3790, costIncrease = 35, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 8, forestName = "Exotic Jungle", initialCost = 5200, costIncrease = 40, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 9, forestName = "Bamboo Forest", initialCost = 6880, costIncrease = 45, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 10, forestName = "Alaskan Wilderness", initialCost = 8850, costIncrease = 50, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 11, forestName = "Caribbean Dream", initialCost = 11110, costIncrease = 55, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 12, forestName = "Highland Glen", initialCost = 13670, costIncrease = 60, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 13, forestName = "Serengeti Safari", initialCost = 16560, costIncrease = 65, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 14, forestName = "Bayou Backcountry", initialCost = 19770, costIncrease = 70, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 15, forestName = "Royal Gardens", initialCost = 23320, costIncrease = 75, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 16, forestName = "Patagonian Trek", initialCost = 27220, costIncrease = 80, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 17, forestName = "Everglade Escape", initialCost = 31470, costIncrease = 85, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 18, forestName = "Rustic Vineyard", initialCost = 36090, costIncrease = 90, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 19, forestName = "Bison Plains", initialCost = 41080, costIncrease = 95, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 20, forestName = "African Wilds", initialCost = 46460, costIncrease = 100, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 21, forestName = "Country Orchard", initialCost = 52220, costIncrease = 105, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 22, forestName = "Viking Valley", initialCost = 58380, costIncrease = 110, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 23, forestName = "Mediterranean Cove", initialCost = 64950, costIncrease = 115, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 24, forestName = "Medieval Times", initialCost = 71930, costIncrease = 120, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 25, forestName = "Arabian Oasis", initialCost = 79330, costIncrease = 125, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 26, forestName = "Rocky Ridge", initialCost = 87150, costIncrease = 130, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 27, forestName = "Rabbit Hollow", initialCost = 95410, costIncrease = 135, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 28, forestName = "Nile Kingdom", initialCost = 104110, costIncrease = 140, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 29, forestName = "Mayan Discovery", initialCost = 113250, costIncrease = 145, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 30, forestName = "Celtic Isle", initialCost = 122840, costIncrease = 150, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 31, forestName = "Mount Olympus", initialCost = 132900, costIncrease = 155, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 32, forestName = "Gold Rush Gorge", initialCost = 143410, costIncrease = 160, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 33, forestName = "Enchanted Forest", initialCost = 154400, costIncrease = 165, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 34, forestName = "Dutch Meadows", initialCost = 165870, costIncrease = 170, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 35, forestName = "Winter Wonderland", initialCost = 177810, costIncrease = 175, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 36, forestName = "Hawaiian Retreat", initialCost = 190250, costIncrease = 180, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 37, forestName = "Central Park", initialCost = 203170, costIncrease = 185, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 38, forestName = "Haunted Hollow", initialCost = 216600, costIncrease = 190, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 39, forestName = "Andes Adventure", initialCost = 230530, costIncrease = 195, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 40, forestName = "Candy Creek", initialCost = 244970, costIncrease = 200, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 41, forestName = "Dino Dunes", initialCost = 259920, costIncrease = 205, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 42, forestName = "Pirates Bay", initialCost = 275390, costIncrease = 210, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 43, forestName = "Himalayan Heights", initialCost = 291390, costIncrease = 215, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 44, forestName = "Sakura Spring", initialCost = 307920, costIncrease = 220, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 45, forestName = "Mythical Woods", initialCost = 324980, costIncrease = 225, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 46, forestName = "Land of Siam", initialCost = 342580, costIncrease = 230, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 47, forestName = "Toyland Trail", initialCost = 360720, costIncrease = 235, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 48, forestName = "Madagascar Coast", initialCost = 379410, costIncrease = 240, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 49, forestName = "Prehistoric Valley", initialCost = 398660, costIncrease = 245, stages = 20, bgType = ???});
            val_158.Add(item:  new WordForest.WFOForestData() {level = 50, forestName = "Carnival Wonders", initialCost = 418460, costIncrease = 250, stages = 20, bgType = ???});
            this.forests = val_158;
            System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Single> val_159 = new System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Single>();
            val_159.Add(key:  10, value:  0.74f);
            val_159.Add(key:  11, value:  0.94f);
            val_159.Add(key:  9, value:  0.9f);
            this.ftuxForestGrowthPercent = val_159;
            System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Int32> val_160 = new System.Collections.Generic.Dictionary<WordForest.FtuxId, System.Int32>();
            val_160.Add(key:  10, value:  1);
            val_160.Add(key:  11, value:  3);
            val_160.Add(key:  9, value:  4);
            this.ftuxForestInitDestroyedTrees = val_160;
            System.Collections.Generic.List<WordForest.WFOForestChestData> val_161 = new System.Collections.Generic.List<WordForest.WFOForestChestData>();
            decimal val_162 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_163 = new System.Collections.Generic.List<System.Int32>();
            val_163.Add(item:  11);
            val_163.Add(item:  24);
            val_163.Add(item:  3);
            val_163.Add(item:  8);
            WordForest.WFOForestChestData val_164 = new WordForest.WFOForestChestData(_level:  1, _coins:  new System.Decimal() {flags = val_162.flags, hi = val_162.flags, lo = val_162.lo, mid = val_162.lo}, _acorns:  120, _newRewardTypes:  val_163);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_164.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_164.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_165 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_166 = new System.Collections.Generic.List<System.Int32>();
            val_166.Add(item:  11);
            val_166.Add(item:  24);
            val_166.Add(item:  3);
            val_166.Add(item:  8);
            WordForest.WFOForestChestData val_167 = new WordForest.WFOForestChestData(_level:  2, _coins:  new System.Decimal() {flags = val_165.flags, hi = val_165.flags, lo = val_165.lo, mid = val_165.lo}, _acorns:  120, _newRewardTypes:  val_166);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_167.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_167.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_168 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_169 = new System.Collections.Generic.List<System.Int32>();
            val_169.Add(item:  1);
            val_169.Add(item:  6);
            val_169.Add(item:  12);
            val_169.Add(item:  4);
            WordForest.WFOForestChestData val_170 = new WordForest.WFOForestChestData(_level:  3, _coins:  new System.Decimal() {flags = val_168.flags, hi = val_168.flags, lo = val_168.lo, mid = val_168.lo}, _acorns:  14, _newRewardTypes:  val_169);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_170.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_170.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_171 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_172 = new System.Collections.Generic.List<System.Int32>();
            val_172.Add(item:  18);
            val_172.Add(item:  5);
            val_172.Add(item:  12);
            val_172.Add(item:  1);
            WordForest.WFOForestChestData val_173 = new WordForest.WFOForestChestData(_level:  4, _coins:  new System.Decimal() {flags = val_171.flags, hi = val_171.flags, lo = val_171.lo, mid = val_171.lo}, _acorns:  510, _newRewardTypes:  val_172);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_173.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_173.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_174 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_175 = new System.Collections.Generic.List<System.Int32>();
            val_175.Add(item:  3);
            val_175.Add(item:  11);
            val_175.Add(item:  1);
            val_175.Add(item:  16);
            WordForest.WFOForestChestData val_176 = new WordForest.WFOForestChestData(_level:  5, _coins:  new System.Decimal() {flags = val_174.flags, hi = val_174.flags, lo = val_174.lo, mid = val_174.lo}, _acorns:  92, _newRewardTypes:  val_175);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_176.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_176.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_177 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_178 = new System.Collections.Generic.List<System.Int32>();
            val_178.Add(item:  4);
            val_178.Add(item:  15);
            val_178.Add(item:  11);
            val_178.Add(item:  8);
            WordForest.WFOForestChestData val_179 = new WordForest.WFOForestChestData(_level:  6, _coins:  new System.Decimal() {flags = val_177.flags, hi = val_177.flags, lo = val_177.lo, mid = val_177.lo}, _acorns:  40, _newRewardTypes:  val_178);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_179.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_179.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_180 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_181 = new System.Collections.Generic.List<System.Int32>();
            val_181.Add(item:  20);
            val_181.Add(item:  23);
            val_181.Add(item:  7);
            val_181.Add(item:  18);
            WordForest.WFOForestChestData val_182 = new WordForest.WFOForestChestData(_level:  7, _coins:  new System.Decimal() {flags = val_180.flags, hi = val_180.flags, lo = val_180.lo, mid = val_180.lo}, _acorns:  98, _newRewardTypes:  val_181);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_182.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_182.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_183 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_184 = new System.Collections.Generic.List<System.Int32>();
            val_184.Add(item:  4);
            val_184.Add(item:  1);
            val_184.Add(item:  5);
            val_184.Add(item:  7);
            WordForest.WFOForestChestData val_185 = new WordForest.WFOForestChestData(_level:  8, _coins:  new System.Decimal() {flags = val_183.flags, hi = val_183.flags, lo = val_183.lo, mid = val_183.lo}, _acorns:  40, _newRewardTypes:  val_184);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_185.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_185.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_186 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_187 = new System.Collections.Generic.List<System.Int32>();
            val_187.Add(item:  8);
            val_187.Add(item:  10);
            val_187.Add(item:  3);
            val_187.Add(item:  15);
            WordForest.WFOForestChestData val_188 = new WordForest.WFOForestChestData(_level:  9, _coins:  new System.Decimal() {flags = val_186.flags, hi = val_186.flags, lo = val_186.lo, mid = val_186.lo}, _acorns:  112, _newRewardTypes:  val_187);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_188.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_188.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_189 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_190 = new System.Collections.Generic.List<System.Int32>();
            val_190.Add(item:  1);
            val_190.Add(item:  18);
            val_190.Add(item:  30);
            val_190.Add(item:  9);
            WordForest.WFOForestChestData val_191 = new WordForest.WFOForestChestData(_level:  10, _coins:  new System.Decimal() {flags = val_189.flags, hi = val_189.flags, lo = val_189.lo, mid = val_189.lo}, _acorns:  68, _newRewardTypes:  val_190);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_191.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_191.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_192 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_193 = new System.Collections.Generic.List<System.Int32>();
            val_193.Add(item:  16);
            val_193.Add(item:  20);
            val_193.Add(item:  1);
            val_193.Add(item:  17);
            WordForest.WFOForestChestData val_194 = new WordForest.WFOForestChestData(_level:  11, _coins:  new System.Decimal() {flags = val_192.flags, hi = val_192.flags, lo = val_192.lo, mid = val_192.lo}, _acorns:  174, _newRewardTypes:  val_193);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_194.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_194.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_195 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_196 = new System.Collections.Generic.List<System.Int32>();
            val_196.Add(item:  27);
            val_196.Add(item:  22);
            val_196.Add(item:  2);
            val_196.Add(item:  8);
            WordForest.WFOForestChestData val_197 = new WordForest.WFOForestChestData(_level:  12, _coins:  new System.Decimal() {flags = val_195.flags, hi = val_195.flags, lo = val_195.lo, mid = val_195.lo}, _acorns:  174, _newRewardTypes:  val_196);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_197.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_197.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_198 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_199 = new System.Collections.Generic.List<System.Int32>();
            val_199.Add(item:  13);
            val_199.Add(item:  8);
            val_199.Add(item:  4);
            val_199.Add(item:  25);
            WordForest.WFOForestChestData val_200 = new WordForest.WFOForestChestData(_level:  13, _coins:  new System.Decimal() {flags = val_198.flags, hi = val_198.flags, lo = val_198.lo, mid = val_198.lo}, _acorns:  88, _newRewardTypes:  val_199);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_200.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_200.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_201 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_202 = new System.Collections.Generic.List<System.Int32>();
            val_202.Add(item:  13);
            val_202.Add(item:  29);
            val_202.Add(item:  7);
            val_202.Add(item:  10);
            WordForest.WFOForestChestData val_203 = new WordForest.WFOForestChestData(_level:  14, _coins:  new System.Decimal() {flags = val_201.flags, hi = val_201.flags, lo = val_201.lo, mid = val_201.lo}, _acorns:  72, _newRewardTypes:  val_202);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_203.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_203.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_204 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_205 = new System.Collections.Generic.List<System.Int32>();
            val_205.Add(item:  11);
            val_205.Add(item:  13);
            val_205.Add(item:  10);
            val_205.Add(item:  14);
            WordForest.WFOForestChestData val_206 = new WordForest.WFOForestChestData(_level:  15, _coins:  new System.Decimal() {flags = val_204.flags, hi = val_204.flags, lo = val_204.lo, mid = val_204.lo}, _acorns:  80, _newRewardTypes:  val_205);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_206.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_206.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_207 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_208 = new System.Collections.Generic.List<System.Int32>();
            val_208.Add(item:  11);
            val_208.Add(item:  0);
            val_208.Add(item:  4);
            val_208.Add(item:  20);
            WordForest.WFOForestChestData val_209 = new WordForest.WFOForestChestData(_level:  16, _coins:  new System.Decimal() {flags = val_207.flags, hi = val_207.flags, lo = val_207.lo, mid = val_207.lo}, _acorns:  32, _newRewardTypes:  val_208);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_209.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_209.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_210 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_211 = new System.Collections.Generic.List<System.Int32>();
            val_211.Add(item:  3);
            val_211.Add(item:  14);
            val_211.Add(item:  8);
            val_211.Add(item:  27);
            WordForest.WFOForestChestData val_212 = new WordForest.WFOForestChestData(_level:  17, _coins:  new System.Decimal() {flags = val_210.flags, hi = val_210.flags, lo = val_210.lo, mid = val_210.lo}, _acorns:  84, _newRewardTypes:  val_211);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_212.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_212.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_213 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_214 = new System.Collections.Generic.List<System.Int32>();
            val_214.Add(item:  8);
            val_214.Add(item:  14);
            val_214.Add(item:  3);
            val_214.Add(item:  10);
            WordForest.WFOForestChestData val_215 = new WordForest.WFOForestChestData(_level:  18, _coins:  new System.Decimal() {flags = val_213.flags, hi = val_213.flags, lo = val_213.lo, mid = val_213.lo}, _acorns:  80, _newRewardTypes:  val_214);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_215.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_215.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_216 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_217 = new System.Collections.Generic.List<System.Int32>();
            val_217.Add(item:  21);
            val_217.Add(item:  10);
            val_217.Add(item:  17);
            val_217.Add(item:  13);
            WordForest.WFOForestChestData val_218 = new WordForest.WFOForestChestData(_level:  19, _coins:  new System.Decimal() {flags = val_216.flags, hi = val_216.flags, lo = val_216.lo, mid = val_216.lo}, _acorns:  20, _newRewardTypes:  val_217);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_218.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_218.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_219 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_220 = new System.Collections.Generic.List<System.Int32>();
            val_220.Add(item:  28);
            val_220.Add(item:  26);
            val_220.Add(item:  9);
            val_220.Add(item:  3);
            WordForest.WFOForestChestData val_221 = new WordForest.WFOForestChestData(_level:  20, _coins:  new System.Decimal() {flags = val_219.flags, hi = val_219.flags, lo = val_219.lo, mid = val_219.lo}, _acorns:  160, _newRewardTypes:  val_220);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_221.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_221.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_222 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_223 = new System.Collections.Generic.List<System.Int32>();
            val_223.Add(item:  15);
            val_223.Add(item:  9);
            val_223.Add(item:  14);
            val_223.Add(item:  11);
            WordForest.WFOForestChestData val_224 = new WordForest.WFOForestChestData(_level:  21, _coins:  new System.Decimal() {flags = val_222.flags, hi = val_222.flags, lo = val_222.lo, mid = val_222.lo}, _acorns:  244, _newRewardTypes:  val_223);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_224.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_224.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_225 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_226 = new System.Collections.Generic.List<System.Int32>();
            val_226.Add(item:  15);
            val_226.Add(item:  11);
            val_226.Add(item:  1);
            val_226.Add(item:  9);
            WordForest.WFOForestChestData val_227 = new WordForest.WFOForestChestData(_level:  22, _coins:  new System.Decimal() {flags = val_225.flags, hi = val_225.flags, lo = val_225.lo, mid = val_225.lo}, _acorns:  172, _newRewardTypes:  val_226);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_227.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_227.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_228 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_229 = new System.Collections.Generic.List<System.Int32>();
            val_229.Add(item:  9);
            val_229.Add(item:  14);
            val_229.Add(item:  14);
            val_229.Add(item:  18);
            WordForest.WFOForestChestData val_230 = new WordForest.WFOForestChestData(_level:  23, _coins:  new System.Decimal() {flags = val_228.flags, hi = val_228.flags, lo = val_228.lo, mid = val_228.lo}, _acorns:  144, _newRewardTypes:  val_229);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_230.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_230.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_231 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_232 = new System.Collections.Generic.List<System.Int32>();
            val_232.Add(item:  3);
            val_232.Add(item:  11);
            val_232.Add(item:  11);
            val_232.Add(item:  12);
            WordForest.WFOForestChestData val_233 = new WordForest.WFOForestChestData(_level:  24, _coins:  new System.Decimal() {flags = val_231.flags, hi = val_231.flags, lo = val_231.lo, mid = val_231.lo}, _acorns:  60, _newRewardTypes:  val_232);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_233.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_233.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_234 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_235 = new System.Collections.Generic.List<System.Int32>();
            val_235.Add(item:  0);
            val_235.Add(item:  29);
            val_235.Add(item:  14);
            val_235.Add(item:  8);
            WordForest.WFOForestChestData val_236 = new WordForest.WFOForestChestData(_level:  25, _coins:  new System.Decimal() {flags = val_234.flags, hi = val_234.flags, lo = val_234.lo, mid = val_234.lo}, _acorns:  176, _newRewardTypes:  val_235);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_236.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_236.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_237 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_238 = new System.Collections.Generic.List<System.Int32>();
            val_238.Add(item:  5);
            val_238.Add(item:  17);
            val_238.Add(item:  6);
            val_238.Add(item:  26);
            WordForest.WFOForestChestData val_239 = new WordForest.WFOForestChestData(_level:  26, _coins:  new System.Decimal() {flags = val_237.flags, hi = val_237.flags, lo = val_237.lo, mid = val_237.lo}, _acorns:  236, _newRewardTypes:  val_238);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_239.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_239.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_240 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_241 = new System.Collections.Generic.List<System.Int32>();
            val_241.Add(item:  4);
            val_241.Add(item:  13);
            val_241.Add(item:  10);
            val_241.Add(item:  7);
            WordForest.WFOForestChestData val_242 = new WordForest.WFOForestChestData(_level:  27, _coins:  new System.Decimal() {flags = val_240.flags, hi = val_240.flags, lo = val_240.lo, mid = val_240.lo}, _acorns:  84, _newRewardTypes:  val_241);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_242.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_242.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_243 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_244 = new System.Collections.Generic.List<System.Int32>();
            val_244.Add(item:  25);
            val_244.Add(item:  8);
            val_244.Add(item:  28);
            val_244.Add(item:  17);
            WordForest.WFOForestChestData val_245 = new WordForest.WFOForestChestData(_level:  28, _coins:  new System.Decimal() {flags = val_243.flags, hi = val_243.flags, lo = val_243.lo, mid = val_243.lo}, _acorns:  32, _newRewardTypes:  val_244);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_245.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_245.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_246 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_247 = new System.Collections.Generic.List<System.Int32>();
            val_247.Add(item:  9);
            val_247.Add(item:  8);
            val_247.Add(item:  19);
            val_247.Add(item:  17);
            WordForest.WFOForestChestData val_248 = new WordForest.WFOForestChestData(_level:  29, _coins:  new System.Decimal() {flags = val_246.flags, hi = val_246.flags, lo = val_246.lo, mid = val_246.lo}, _acorns:  24, _newRewardTypes:  val_247);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_248.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_248.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_249 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_250 = new System.Collections.Generic.List<System.Int32>();
            val_250.Add(item:  4);
            val_250.Add(item:  1);
            val_250.Add(item:  16);
            val_250.Add(item:  8);
            WordForest.WFOForestChestData val_251 = new WordForest.WFOForestChestData(_level:  30, _coins:  new System.Decimal() {flags = val_249.flags, hi = val_249.flags, lo = val_249.lo, mid = val_249.lo}, _acorns:  216, _newRewardTypes:  val_250);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_251.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_251.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_252 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_253 = new System.Collections.Generic.List<System.Int32>();
            val_253.Add(item:  9);
            val_253.Add(item:  24);
            val_253.Add(item:  0);
            val_253.Add(item:  3);
            WordForest.WFOForestChestData val_254 = new WordForest.WFOForestChestData(_level:  31, _coins:  new System.Decimal() {flags = val_252.flags, hi = val_252.flags, lo = val_252.lo, mid = val_252.lo}, _acorns:  66400, _newRewardTypes:  val_253);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_254.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_254.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_255 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_256 = new System.Collections.Generic.List<System.Int32>();
            val_256.Add(item:  1);
            val_256.Add(item:  18);
            val_256.Add(item:  12);
            val_256.Add(item:  5);
            WordForest.WFOForestChestData val_257 = new WordForest.WFOForestChestData(_level:  32, _coins:  new System.Decimal() {flags = val_255.flags, hi = val_255.flags, lo = val_255.lo, mid = val_255.lo}, _acorns:  71700, _newRewardTypes:  val_256);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_257.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_257.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_258 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_259 = new System.Collections.Generic.List<System.Int32>();
            val_259.Add(item:  15);
            val_259.Add(item:  15);
            val_259.Add(item:  0);
            val_259.Add(item:  5);
            WordForest.WFOForestChestData val_260 = new WordForest.WFOForestChestData(_level:  33, _coins:  new System.Decimal() {flags = val_258.flags, hi = val_258.flags, lo = val_258.lo, mid = val_258.lo}, _acorns:  77200, _newRewardTypes:  val_259);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_260.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_260.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_261 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_262 = new System.Collections.Generic.List<System.Int32>();
            val_262.Add(item:  6);
            val_262.Add(item:  12);
            val_262.Add(item:  1);
            val_262.Add(item:  8);
            WordForest.WFOForestChestData val_263 = new WordForest.WFOForestChestData(_level:  34, _coins:  new System.Decimal() {flags = val_261.flags, hi = val_261.flags, lo = val_261.lo, mid = val_261.lo}, _acorns:  82900, _newRewardTypes:  val_262);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_263.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_263.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_264 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_265 = new System.Collections.Generic.List<System.Int32>();
            val_265.Add(item:  7);
            val_265.Add(item:  8);
            val_265.Add(item:  12);
            val_265.Add(item:  6);
            WordForest.WFOForestChestData val_266 = new WordForest.WFOForestChestData(_level:  35, _coins:  new System.Decimal() {flags = val_264.flags, hi = val_264.flags, lo = val_264.lo, mid = val_264.lo}, _acorns:  88900, _newRewardTypes:  val_265);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_266.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_266.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_267 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_268 = new System.Collections.Generic.List<System.Int32>();
            val_268.Add(item:  4);
            val_268.Add(item:  14);
            val_268.Add(item:  6);
            val_268.Add(item:  8);
            WordForest.WFOForestChestData val_269 = new WordForest.WFOForestChestData(_level:  36, _coins:  new System.Decimal() {flags = val_267.flags, hi = val_267.flags, lo = val_267.lo, mid = val_267.lo}, _acorns:  95100, _newRewardTypes:  val_268);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_269.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_269.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_270 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_271 = new System.Collections.Generic.List<System.Int32>();
            val_271.Add(item:  8);
            val_271.Add(item:  28);
            val_271.Add(item:  9);
            val_271.Add(item:  9);
            WordForest.WFOForestChestData val_272 = new WordForest.WFOForestChestData(_level:  37, _coins:  new System.Decimal() {flags = val_270.flags, hi = val_270.flags, lo = val_270.lo, mid = val_270.lo}, _acorns:  101500, _newRewardTypes:  val_271);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_272.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_272.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_273 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_274 = new System.Collections.Generic.List<System.Int32>();
            val_274.Add(item:  9);
            val_274.Add(item:  5);
            val_274.Add(item:  14);
            val_274.Add(item:  2);
            WordForest.WFOForestChestData val_275 = new WordForest.WFOForestChestData(_level:  38, _coins:  new System.Decimal() {flags = val_273.flags, hi = val_273.flags, lo = val_273.lo, mid = val_273.lo}, _acorns:  108300, _newRewardTypes:  val_274);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_275.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_275.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_276 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_277 = new System.Collections.Generic.List<System.Int32>();
            val_277.Add(item:  5);
            val_277.Add(item:  5);
            val_277.Add(item:  3);
            val_277.Add(item:  15);
            WordForest.WFOForestChestData val_278 = new WordForest.WFOForestChestData(_level:  39, _coins:  new System.Decimal() {flags = val_276.flags, hi = val_276.flags, lo = val_276.lo, mid = val_276.lo}, _acorns:  115200, _newRewardTypes:  val_277);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_278.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_278.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_279 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_280 = new System.Collections.Generic.List<System.Int32>();
            val_280.Add(item:  6);
            val_280.Add(item:  24);
            val_280.Add(item:  27);
            val_280.Add(item:  16);
            WordForest.WFOForestChestData val_281 = new WordForest.WFOForestChestData(_level:  40, _coins:  new System.Decimal() {flags = val_279.flags, hi = val_279.flags, lo = val_279.lo, mid = val_279.lo}, _acorns:  122400, _newRewardTypes:  val_280);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_281.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_281.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_282 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_283 = new System.Collections.Generic.List<System.Int32>();
            val_283.Add(item:  0);
            val_283.Add(item:  9);
            val_283.Add(item:  11);
            val_283.Add(item:  16);
            WordForest.WFOForestChestData val_284 = new WordForest.WFOForestChestData(_level:  41, _coins:  new System.Decimal() {flags = val_282.flags, hi = val_282.flags, lo = val_282.lo, mid = val_282.lo}, _acorns:  129900, _newRewardTypes:  val_283);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_284.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_284.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_285 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_286 = new System.Collections.Generic.List<System.Int32>();
            val_286.Add(item:  6);
            val_286.Add(item:  18);
            val_286.Add(item:  2);
            val_286.Add(item:  4);
            WordForest.WFOForestChestData val_287 = new WordForest.WFOForestChestData(_level:  42, _coins:  new System.Decimal() {flags = val_285.flags, hi = val_285.flags, lo = val_285.lo, mid = val_285.lo}, _acorns:  137600, _newRewardTypes:  val_286);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_287.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_287.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_288 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_289 = new System.Collections.Generic.List<System.Int32>();
            val_289.Add(item:  9);
            val_289.Add(item:  6);
            val_289.Add(item:  5);
            val_289.Add(item:  11);
            WordForest.WFOForestChestData val_290 = new WordForest.WFOForestChestData(_level:  43, _coins:  new System.Decimal() {flags = val_288.flags, hi = val_288.flags, lo = val_288.lo, mid = val_288.lo}, _acorns:  145600, _newRewardTypes:  val_289);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_290.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_290.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_291 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_292 = new System.Collections.Generic.List<System.Int32>();
            val_292.Add(item:  7);
            val_292.Add(item:  4);
            val_292.Add(item:  16);
            val_292.Add(item:  14);
            WordForest.WFOForestChestData val_293 = new WordForest.WFOForestChestData(_level:  44, _coins:  new System.Decimal() {flags = val_291.flags, hi = val_291.flags, lo = val_291.lo, mid = val_291.lo}, _acorns:  153900, _newRewardTypes:  val_292);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_293.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_293.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_294 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_295 = new System.Collections.Generic.List<System.Int32>();
            val_295.Add(item:  18);
            val_295.Add(item:  4);
            val_295.Add(item:  6);
            val_295.Add(item:  9);
            WordForest.WFOForestChestData val_296 = new WordForest.WFOForestChestData(_level:  45, _coins:  new System.Decimal() {flags = val_294.flags, hi = val_294.flags, lo = val_294.lo, mid = val_294.lo}, _acorns:  162400, _newRewardTypes:  val_295);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_296.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_296.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_297 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_298 = new System.Collections.Generic.List<System.Int32>();
            val_298.Add(item:  7);
            val_298.Add(item:  17);
            val_298.Add(item:  10);
            val_298.Add(item:  7);
            WordForest.WFOForestChestData val_299 = new WordForest.WFOForestChestData(_level:  46, _coins:  new System.Decimal() {flags = val_297.flags, hi = val_297.flags, lo = val_297.lo, mid = val_297.lo}, _acorns:  171200, _newRewardTypes:  val_298);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_299.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_299.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_300 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_301 = new System.Collections.Generic.List<System.Int32>();
            val_301.Add(item:  0);
            val_301.Add(item:  17);
            val_301.Add(item:  10);
            val_301.Add(item:  5);
            WordForest.WFOForestChestData val_302 = new WordForest.WFOForestChestData(_level:  47, _coins:  new System.Decimal() {flags = val_300.flags, hi = val_300.flags, lo = val_300.lo, mid = val_300.lo}, _acorns:  180300, _newRewardTypes:  val_301);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_302.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_302.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_303 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_304 = new System.Collections.Generic.List<System.Int32>();
            val_304.Add(item:  8);
            val_304.Add(item:  12);
            val_304.Add(item:  2);
            val_304.Add(item:  14);
            WordForest.WFOForestChestData val_305 = new WordForest.WFOForestChestData(_level:  48, _coins:  new System.Decimal() {flags = val_303.flags, hi = val_303.flags, lo = val_303.lo, mid = val_303.lo}, _acorns:  189700, _newRewardTypes:  val_304);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_305.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_305.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_306 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_307 = new System.Collections.Generic.List<System.Int32>();
            val_307.Add(item:  1);
            val_307.Add(item:  15);
            val_307.Add(item:  3);
            val_307.Add(item:  13);
            WordForest.WFOForestChestData val_308 = new WordForest.WFOForestChestData(_level:  49, _coins:  new System.Decimal() {flags = val_306.flags, hi = val_306.flags, lo = val_306.lo, mid = val_306.lo}, _acorns:  199300, _newRewardTypes:  val_307);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_308.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_308.coins.mid}, acorns = 250, newRewardTypes = 20});
            decimal val_309 = new System.Decimal(value:  25);
            System.Collections.Generic.List<System.Int32> val_310 = new System.Collections.Generic.List<System.Int32>();
            val_310.Add(item:  6);
            val_310.Add(item:  16);
            val_310.Add(item:  4);
            val_310.Add(item:  5);
            WordForest.WFOForestChestData val_311 = new WordForest.WFOForestChestData(_level:  50, _coins:  new System.Decimal() {flags = val_309.flags, hi = val_309.flags, lo = val_309.lo, mid = val_309.lo}, _acorns:  209200, _newRewardTypes:  val_310);
            val_161.Add(item:  new WordForest.WFOForestChestData() {forestLevel = val_311.forestLevel, coins = new System.Decimal() {hi = 651456576, lo = 268435459, mid = val_311.coins.mid}, acorns = 250, newRewardTypes = 20});
            this.forestChests = val_161;
            this.daysOfOffensiveActionsPostSession = 2;
            this.attackSuccessRate = 50f;
            this.maxUnblockAttacksReceived = 3;
            this.maxRaidsReceived = 0;
            this.mysteryGiftReward = 100;
            this.offensiveActionsPerDay = 6;
        }
    
    }

}
