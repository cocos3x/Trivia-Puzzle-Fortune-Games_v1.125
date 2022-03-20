using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BestBlocksGameEcon : GameEcon
    {
        // Fields
        private BlockPuzzleMagic.BestBlocksEconConfig bestBlocksEconConfig;
        private decimal chapterClearedReward;
        private int normalGridsPerChapter;
        private int stoneLevelsPerChapter;
        private static int levelsPerChapter;
        private static int proceduralCrateOnlyChapters;
        private static int proceduralCrateStoneOnlyChapters;
        private float stoneLevelIncrement;
        private int goalRequirementIncrement;
        private int powerupUsageThresholdNonPurchaser;
        private int powerupUsageThresholdOneTimePurchaser;
        private int powerupUsageThresholdPurchaser;
        private int powerupTrashTutorialLevel;
        private int powerupFillTutorialLevel;
        private int powerupBombTutorialLevel;
        private int powerupEarthquakeUnlockLevel;
        private System.Collections.Generic.Dictionary<BlockPuzzleMagic.Goal.GoalType, System.Collections.Generic.List<int>> goalRequirements;
        private System.Collections.Generic.List<int> goalQuantityArray;
        private int maxGoalQuantity;
        private int goalQuantityIncrement;
        private int maxPlayerLives;
        private float lifeRechargeTimeMins;
        private decimal maxLivesCost;
        private decimal powerupCostTrash;
        private decimal powerupCostBomb;
        private decimal powerupCostFill;
        private decimal powerupCostEarthquake;
        private int ftuxEasyModeLevels;
        private int failedAttemptsBeforeEasyMode;
        private int lifePenaltyGameOver;
        private float bombBlockAPChance;
        private float rainbowBlockAPChance;
        public const string LN_SCRBONUS_LNCOUNT = "ln";
        public const string LN_SCRBONUS_BONUS = "bn";
        private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> zenLineClearScoreBonus;
        private int zenBaseScorePerBlock;
        private int ftuxPieceListEndLevel;
        private int ftux2PieceListEndLevel;
        private System.Collections.Generic.List<int> allowedShapeIdsFtux1;
        private System.Collections.Generic.List<int> allowedShapeIdsChallengeMode;
        private System.Collections.Generic.List<int> allowedShapesIdsFtux2;
        private System.Collections.Generic.List<int> allowedShapeIdsZenMode;
        private int starThreshold1;
        private int starThreshold2;
        
        // Properties
        public static BlockPuzzleMagic.BestBlocksGameEcon Instance { get; }
        public BlockPuzzleMagic.GridLayoutDefinitions gridLayoutDefinitions { get; }
        public decimal ChapterClearedReward { get; }
        public int NormalGridsPerChapter { get; }
        public int StoneLevelsPerChapter { get; }
        public static int LevelsPerChapter { get; }
        public static int ProceduralCrateOnlyChapters { get; }
        public static int ProceduralCrateStoneOnlyChapters { get; }
        public float StoneLevelIncrement { get; }
        public int GoalRequirementIncrement { get; }
        public int PowerupTrashTutorialLevel { get; }
        public int PowerupFillTutorialLevel { get; }
        public int PowerupBombTutorialLevel { get; }
        public int PowerupEarthquakeUnlockLevel { get; }
        public System.Collections.Generic.Dictionary<BlockPuzzleMagic.Goal.GoalType, System.Collections.Generic.List<int>> GoalRequirements { get; }
        public System.Collections.Generic.List<int> GoalQuantityArray { get; }
        public int MaxGoalQuantity { get; }
        public int GoalQuantityIncrement { get; }
        public int MaxPlayerLives { get; }
        public float LifeRechargeTimeMins { get; }
        public decimal MaxLivesCost { get; }
        public decimal PowerupCostTrash { get; }
        public decimal PowerupCostBomb { get; }
        public decimal PowerupCostFill { get; }
        public decimal PowerupCostEarthquake { get; }
        public int FTUXEasyModeLevels { get; }
        public int FailedAttemptsBeforeEasyMode { get; }
        public int LifePenaltyGameOver { get; }
        public float BombBlockAPChance { get; }
        public float RainbowBlockAPChance { get; }
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> ZenLineClearScoreBonus { get; }
        public int ZenBaseScorePerBlock { get; }
        public int FtuxPieceListEndLevel { get; }
        public int Ftux2PieceListEndLevel { get; }
        public int StarThreshold1 { get; }
        public int StarThreshold2 { get; }
        
        // Methods
        public static BlockPuzzleMagic.BestBlocksGameEcon get_Instance()
        {
            GameEcon val_1 = App.getGameEcon;
            if(val_1 == null)
            {
                    return (BlockPuzzleMagic.BestBlocksGameEcon)val_1;
            }
            
            return (BlockPuzzleMagic.BestBlocksGameEcon)val_1;
        }
        public BlockPuzzleMagic.GridLayoutDefinitions get_gridLayoutDefinitions()
        {
            EconConfig val_3;
            if(this.bestBlocksEconConfig == 0)
            {
                    AppConfigs val_2 = App.Configuration;
                val_3 = val_2.econConfig;
                this.bestBlocksEconConfig = val_3;
                if(val_3 != null)
            {
                    return (BlockPuzzleMagic.GridLayoutDefinitions)this.bestBlocksEconConfig.gridLayoutDefinitions;
            }
            
            }
            
            val_3 = this.bestBlocksEconConfig;
            return (BlockPuzzleMagic.GridLayoutDefinitions)this.bestBlocksEconConfig.gridLayoutDefinitions;
        }
        public decimal get_ChapterClearedReward()
        {
            return new System.Decimal() {flags = this.chapterClearedReward, hi = this.chapterClearedReward};
        }
        public int get_NormalGridsPerChapter()
        {
            return (int)this.normalGridsPerChapter;
        }
        public int get_StoneLevelsPerChapter()
        {
            return (int)this.stoneLevelsPerChapter;
        }
        public static int get_LevelsPerChapter()
        {
            null = null;
            return (int)BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS;
        }
        public static int get_ProceduralCrateOnlyChapters()
        {
            null = null;
            return (int)BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateOnlyChapters;
        }
        public static int get_ProceduralCrateStoneOnlyChapters()
        {
            null = null;
            return (int)BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateStoneOnlyChapters;
        }
        public float get_StoneLevelIncrement()
        {
            return (float)this.stoneLevelIncrement;
        }
        public int get_GoalRequirementIncrement()
        {
            return (int)this.goalRequirementIncrement;
        }
        public int GetPowerupUsageThresholdForPlayer()
        {
            int val_3;
            Player val_1 = App.Player;
            if(val_1.num_purchase <= 0)
            {
                goto label_4;
            }
            
            Player val_2 = App.Player;
            if(val_2.num_purchase != 1)
            {
                goto label_8;
            }
            
            val_3 = this.powerupUsageThresholdOneTimePurchaser;
            return val_3;
            label_4:
            val_3 = this.powerupUsageThresholdNonPurchaser;
            return val_3;
            label_8:
            val_3 = this.powerupUsageThresholdPurchaser;
            return val_3;
        }
        public int get_PowerupTrashTutorialLevel()
        {
            return (int)this.powerupTrashTutorialLevel;
        }
        public int get_PowerupFillTutorialLevel()
        {
            return (int)this.powerupFillTutorialLevel;
        }
        public int get_PowerupBombTutorialLevel()
        {
            return (int)this.powerupBombTutorialLevel;
        }
        public int get_PowerupEarthquakeUnlockLevel()
        {
            return (int)this.powerupEarthquakeUnlockLevel;
        }
        public int GetPowerupTutorialLevel(BlockPuzzleMagic.PowerUpType powerupType)
        {
            if(powerupType > 3)
            {
                    return 0;
            }
            
            var val_1 = 32563304 + (powerupType) << 2;
            val_1 = val_1 + 32563304;
            goto (32563304 + (powerupType) << 2 + 32563304);
        }
        public System.Collections.Generic.Dictionary<BlockPuzzleMagic.Goal.GoalType, System.Collections.Generic.List<int>> get_GoalRequirements()
        {
            return (System.Collections.Generic.Dictionary<GoalType, System.Collections.Generic.List<System.Int32>>)this.goalRequirements;
        }
        public System.Collections.Generic.List<int> get_GoalQuantityArray()
        {
            return (System.Collections.Generic.List<System.Int32>)this.goalQuantityArray;
        }
        public int get_MaxGoalQuantity()
        {
            return (int)this.maxGoalQuantity;
        }
        public int get_GoalQuantityIncrement()
        {
            return (int)this.goalQuantityIncrement;
        }
        public int get_MaxPlayerLives()
        {
            return (int)this.maxPlayerLives;
        }
        public float get_LifeRechargeTimeMins()
        {
            return (float)this.lifeRechargeTimeMins;
        }
        public decimal get_MaxLivesCost()
        {
            return new System.Decimal() {flags = this.maxLivesCost, hi = this.maxLivesCost};
        }
        public decimal get_PowerupCostTrash()
        {
            return new System.Decimal() {flags = this.powerupCostTrash, hi = this.powerupCostTrash};
        }
        public decimal get_PowerupCostBomb()
        {
            return new System.Decimal() {flags = this.powerupCostBomb, hi = this.powerupCostBomb};
        }
        public decimal get_PowerupCostFill()
        {
            return new System.Decimal() {flags = this.powerupCostFill, hi = this.powerupCostFill};
        }
        public decimal get_PowerupCostEarthquake()
        {
            return new System.Decimal() {flags = this.powerupCostEarthquake, hi = this.powerupCostEarthquake};
        }
        public decimal GetPowerupCost(BlockPuzzleMagic.PowerUpType _type)
        {
            decimal val_2;
            int val_3;
            if(_type <= 3)
            {
                    var val_2 = 32563320 + (_type) << 2;
                val_2 = val_2 + 32563320;
            }
            else
            {
                    decimal val_1 = new System.Decimal(value:  2147483647);
                val_2 = val_1.flags;
                val_3 = val_1.lo;
                return new System.Decimal() {};
            }
        
        }
        public int get_FTUXEasyModeLevels()
        {
            return (int)this.ftuxEasyModeLevels;
        }
        public int get_FailedAttemptsBeforeEasyMode()
        {
            return (int)this.failedAttemptsBeforeEasyMode;
        }
        public bool IsEasyMode()
        {
            var val_7;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
            {
                    BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                if((val_3.currentLevel != null) && (val_3.currentLevel.gameMode == 2))
            {
                    GameBehavior val_4 = App.getBehavior;
                if((val_4.<metaGameBehavior>k__BackingField) <= this.ftuxEasyModeLevels)
            {
                    return (bool)val_7;
            }
            
                Player val_5 = App.Player;
                var val_6 = (((Player.__il2cppRuntimeField_typeHierarchy + (typeof(MetaGameBehavior).__il2cppRuntimeField_2F8 + 296) << 3) + -8) >= this.failedAttemptsBeforeEasyMode) ? 1 : 0;
                return (bool)val_7;
            }
            
            }
            
            val_7 = 0;
            return (bool)val_7;
        }
        public int get_LifePenaltyGameOver()
        {
            return (int)this.lifePenaltyGameOver;
        }
        public float get_BombBlockAPChance()
        {
            return (float)this.bombBlockAPChance;
        }
        public float get_RainbowBlockAPChance()
        {
            return (float)this.rainbowBlockAPChance;
        }
        public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> get_ZenLineClearScoreBonus()
        {
            return (System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Int32>>)this.zenLineClearScoreBonus;
        }
        public int get_ZenBaseScorePerBlock()
        {
            return (int)this.zenBaseScorePerBlock;
        }
        public int get_FtuxPieceListEndLevel()
        {
            return (int)this.ftuxPieceListEndLevel;
        }
        public int get_Ftux2PieceListEndLevel()
        {
            return (int)this.ftux2PieceListEndLevel;
        }
        public System.Collections.Generic.List<int> GetAllowedShapeIdsForMode(BlockPuzzleMagic.GameMode gameMode)
        {
            System.Collections.Generic.List<System.Int32> val_3;
            if(gameMode == 2)
            {
                goto label_1;
            }
            
            if(gameMode != 1)
            {
                goto label_14;
            }
            
            val_3 = this.allowedShapeIdsZenMode;
            return (System.Collections.Generic.List<System.Int32>)this.allowedShapeIdsChallengeMode.SyncRoot;
            label_1:
            GameBehavior val_1 = App.getBehavior;
            if((val_1.<metaGameBehavior>k__BackingField) < this.ftuxPieceListEndLevel)
            {
                    val_3 = this.allowedShapeIdsFtux1;
                return (System.Collections.Generic.List<System.Int32>)this.allowedShapeIdsChallengeMode.SyncRoot;
            }
            
            GameBehavior val_2 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) < this.ftux2PieceListEndLevel)
            {
                    val_3 = this.allowedShapesIdsFtux2;
                return (System.Collections.Generic.List<System.Int32>)this.allowedShapeIdsChallengeMode.SyncRoot;
            }
            
            label_14:
            val_3 = this.allowedShapeIdsChallengeMode;
            return (System.Collections.Generic.List<System.Int32>)this.allowedShapeIdsChallengeMode.SyncRoot;
        }
        public int get_StarThreshold1()
        {
            return (int)this.starThreshold1;
        }
        public int get_StarThreshold2()
        {
            return (int)this.starThreshold2;
        }
        public override void ReadFromKnobs()
        {
            System.Collections.IDictionary val_134;
            var val_135;
            decimal val_136;
            var val_137;
            this.ReadFromKnobs();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_134 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_135 = null;
            val_135 = null;
            if(getWordGameplayKnobs() != null)
            {
                    val_134 = val_2.dataSource;
            }
            
            if((val_1.ContainsKey(key:  "bbl_lgen")) != false)
            {
                    object val_4 = val_1.Item["bbl_lgen"];
                if((val_4.ContainsKey(key:  "9x9_lpc")) != false)
            {
                    bool val_8 = System.Int32.TryParse(s:  val_4.Item["9x9_lpc"], result: out  this.normalGridsPerChapter);
            }
            
                if((val_4.ContainsKey(key:  "st1")) != false)
            {
                    bool val_12 = System.Int32.TryParse(s:  val_4.Item["st1"], result: out  this.starThreshold1);
            }
            
                val_136 = "st2";
                if((val_4.ContainsKey(key:  "st2")) != false)
            {
                    bool val_16 = System.Int32.TryParse(s:  val_4.Item["st2"], result: out  this.starThreshold2);
            }
            
            }
            
            if((val_1.ContainsKey(key:  "pw_up_c")) != false)
            {
                    object val_18 = val_1.Item["pw_up_c"];
                if((val_18.ContainsKey(key:  "nc")) != false)
            {
                    val_136 = this.powerupCostTrash;
                bool val_21 = System.Decimal.TryParse(s:  val_18.Item["nc"], result: out  new System.Decimal() {flags = val_136, hi = val_136, lo = val_136, mid = val_136});
            }
            
                if((val_18.ContainsKey(key:  "brk")) != false)
            {
                    val_136 = this.powerupCostBomb;
                bool val_24 = System.Decimal.TryParse(s:  val_18.Item["brk"], result: out  new System.Decimal() {flags = val_136, hi = val_136, lo = val_136, mid = val_136});
            }
            
                if((val_18.ContainsKey(key:  "fill")) != false)
            {
                    bool val_27 = System.Decimal.TryParse(s:  val_18.Item["fill"], result: out  new System.Decimal() {flags = this.powerupCostFill, hi = this.powerupCostFill, lo = this.powerupCostFill, mid = this.powerupCostFill});
            }
            
            }
            
            if((val_1.ContainsKey(key:  "ccr_v2")) != false)
            {
                    bool val_30 = System.Decimal.TryParse(s:  val_1.Item["ccr_v2"], result: out  new System.Decimal() {flags = this.chapterClearedReward, hi = this.chapterClearedReward, lo = this.chapterClearedReward, mid = this.chapterClearedReward});
            }
            
            if((val_1.ContainsKey(key:  "goal_rq")) != false)
            {
                    object val_32 = val_1.Item["goal_rq"];
                if((val_32.ContainsKey(key:  "inc")) != false)
            {
                    bool val_36 = System.Int32.TryParse(s:  val_32.Item["inc"], result: out  this.goalRequirementIncrement);
            }
            
                val_136 = "req";
                if((val_32.ContainsKey(key:  "req")) != false)
            {
                    this.goalRequirements = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<GoalType, System.Collections.Generic.List<System.Int32>>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_32.Item["req"]));
            }
            
            }
            
            if((val_1.ContainsKey(key:  "per_ch")) != false)
            {
                    object val_42 = val_1.Item["per_ch"];
                val_136 = "stone";
                if((val_42.ContainsKey(key:  "stone")) != false)
            {
                    object val_44 = val_42.Item["stone"];
                if((val_44.ContainsKey(key:  "lvls")) != false)
            {
                    bool val_48 = System.Int32.TryParse(s:  val_44.Item["lvls"], result: out  this.stoneLevelsPerChapter);
            }
            
                val_136 = "inc";
                if((val_44.ContainsKey(key:  "inc")) != false)
            {
                    bool val_52 = System.Single.TryParse(s:  val_44.Item["inc"], result: out  this.stoneLevelIncrement);
            }
            
            }
            
            }
            
            if((val_1.ContainsKey(key:  "goal_q")) != false)
            {
                    object val_54 = val_1.Item["goal_q"];
                if((val_54.ContainsKey(key:  "inc")) != false)
            {
                    bool val_58 = System.Int32.TryParse(s:  val_54.Item["inc"], result: out  this.goalQuantityIncrement);
            }
            
                if((val_54.ContainsKey(key:  "max")) != false)
            {
                    bool val_62 = System.Int32.TryParse(s:  val_54.Item["max"], result: out  this.maxGoalQuantity);
            }
            
                val_136 = "array";
                if((val_54.ContainsKey(key:  "array")) != false)
            {
                    this.goalQuantityArray = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_54.Item["array"]));
            }
            
            }
            
            if((val_1.ContainsKey(key:  "pw_us_thr")) != false)
            {
                    object val_68 = val_1.Item["pw_us_thr"];
                if((val_68.ContainsKey(key:  "nobuy")) != false)
            {
                    bool val_72 = System.Int32.TryParse(s:  val_68.Item["nobuy"], result: out  this.powerupUsageThresholdNonPurchaser);
            }
            
                if((val_68.ContainsKey(key:  "onebuy")) != false)
            {
                    bool val_76 = System.Int32.TryParse(s:  val_68.Item["onebuy"], result: out  this.powerupUsageThresholdOneTimePurchaser);
            }
            
                val_136 = "manybuy";
                if((val_68.ContainsKey(key:  "manybuy")) != false)
            {
                    bool val_80 = System.Int32.TryParse(s:  val_68.Item["manybuy"], result: out  this.powerupUsageThresholdPurchaser);
            }
            
            }
            
            if((val_1.ContainsKey(key:  "ftux_ezlvls")) != false)
            {
                    bool val_84 = System.Int32.TryParse(s:  val_1.Item["ftux_ezlvls"], result: out  this.ftuxEasyModeLevels);
            }
            
            if((val_1.ContainsKey(key:  "ez_failsw")) != false)
            {
                    bool val_88 = System.Int32.TryParse(s:  val_1.Item["ez_failsw"], result: out  this.failedAttemptsBeforeEasyMode);
            }
            
            if((val_1.ContainsKey(key:  "mx_l")) != false)
            {
                    bool val_92 = System.Int32.TryParse(s:  val_1.Item["mx_l"], result: out  this.maxPlayerLives);
            }
            
            if((val_1.ContainsKey(key:  "mx_l_c")) != false)
            {
                    bool val_95 = System.Decimal.TryParse(s:  val_1.Item["mx_l_c"], result: out  new System.Decimal() {flags = this.maxLivesCost, hi = this.maxLivesCost, lo = this.maxLivesCost, mid = this.maxLivesCost});
            }
            
            if((val_1.ContainsKey(key:  "l_rc_t")) != false)
            {
                    bool val_99 = System.Single.TryParse(s:  val_1.Item["l_rc_t"], result: out  this.lifeRechargeTimeMins);
            }
            
            if((val_1.ContainsKey(key:  "nw_t_l")) != false)
            {
                    bool val_103 = System.Int32.TryParse(s:  val_1.Item["nw_t_l"], result: out  this.powerupTrashTutorialLevel);
            }
            
            if((val_1.ContainsKey(key:  "f_t_l")) != false)
            {
                    bool val_107 = System.Int32.TryParse(s:  val_1.Item["f_t_l"], result: out  this.powerupFillTutorialLevel);
            }
            
            if((val_1.ContainsKey(key:  "b_t_l")) != false)
            {
                    bool val_111 = System.Int32.TryParse(s:  val_1.Item["b_t_l"], result: out  this.powerupBombTutorialLevel);
            }
            
            if((val_1.ContainsKey(key:  "eq_u_l")) != false)
            {
                    bool val_115 = System.Int32.TryParse(s:  val_1.Item["eq_u_l"], result: out  this.powerupEarthquakeUnlockLevel);
            }
            
            if((val_1.ContainsKey(key:  "bomb_ap")) != false)
            {
                    bool val_119 = System.Single.TryParse(s:  val_1.Item["bomb_ap"], result: out  this.bombBlockAPChance);
            }
            
            if((val_1.ContainsKey(key:  "rnbw_ap")) != false)
            {
                    bool val_123 = System.Single.TryParse(s:  val_1.Item["rnbw_ap"], result: out  this.rainbowBlockAPChance);
            }
            
            val_137 = "ftux_pl";
            if((val_1.ContainsKey(key:  "ftux_pl")) == false)
            {
                    return;
            }
            
            val_137 = 1152921510214912464;
            object val_125 = val_1.Item["ftux_pl"];
            if((val_125.ContainsKey(key:  "el1")) != false)
            {
                    bool val_129 = System.Int32.TryParse(s:  val_125.Item["el1"], result: out  this.ftuxPieceListEndLevel);
            }
            
            if((val_125.ContainsKey(key:  "el2")) == false)
            {
                    return;
            }
            
            bool val_133 = System.Int32.TryParse(s:  val_125.Item["el2"], result: out  this.ftux2PieceListEndLevel);
        }
        public BestBlocksGameEcon()
        {
            decimal val_1 = new System.Decimal(value:  20);
            this.chapterClearedReward = val_1.flags;
            this.stoneLevelIncrement = 0.25f;
            this.normalGridsPerChapter = 3;
            this.stoneLevelsPerChapter = 5;
            this.powerupFillTutorialLevel = 6;
            this.powerupBombTutorialLevel = 15;
            this.powerupEarthquakeUnlockLevel = 30;
            this.powerupUsageThresholdNonPurchaser = ;
            this.powerupUsageThresholdOneTimePurchaser = ;
            this.powerupUsageThresholdPurchaser = 42949672970;
            this.powerupTrashTutorialLevel = 10;
            System.Collections.Generic.Dictionary<GoalType, System.Collections.Generic.List<System.Int32>> val_2 = new System.Collections.Generic.Dictionary<GoalType, System.Collections.Generic.List<System.Int32>>();
            System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
            val_3.Add(item:  10);
            val_3.Add(item:  10);
            val_3.Add(item:  10);
            val_3.Add(item:  10);
            val_2.Add(key:  1, value:  val_3);
            System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
            val_4.Add(item:  10);
            val_4.Add(item:  10);
            val_4.Add(item:  10);
            val_4.Add(item:  10);
            val_2.Add(key:  2, value:  val_4);
            System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>();
            val_5.Add(item:  25);
            val_5.Add(item:  20);
            val_5.Add(item:  15);
            val_5.Add(item:  15);
            val_2.Add(key:  3, value:  val_5);
            val_2.Add(key:  4, value:  0);
            val_2.Add(key:  5, value:  0);
            this.goalRequirements = val_2;
            System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
            val_6.Add(item:  2);
            val_6.Add(item:  2);
            val_6.Add(item:  2);
            val_6.Add(item:  3);
            val_6.Add(item:  3);
            val_6.Add(item:  3);
            val_6.Add(item:  3);
            val_6.Add(item:  4);
            val_6.Add(item:  4);
            val_6.Add(item:  4);
            this.goalQuantityArray = val_6;
            this.maxPlayerLives = 5;
            this.lifeRechargeTimeMins = 15f;
            this.maxGoalQuantity = 4;
            this.goalQuantityIncrement = 1;
            decimal val_7 = new System.Decimal(value:  195);
            this.maxLivesCost = val_7.flags;
            decimal val_8 = new System.Decimal(value:  60);
            this.powerupCostTrash = val_8.flags;
            decimal val_9 = new System.Decimal(value:  60);
            this.powerupCostBomb = val_9.flags;
            decimal val_10 = new System.Decimal(value:  60);
            decimal val_11;
            this.powerupCostFill = val_10.flags;
            val_11 = new System.Decimal(value:  90);
            this.ftuxEasyModeLevels = 7;
            this.powerupCostEarthquake = val_11.flags;
            mem2[0] = 2.12199579244747E-314;
            mem2[0] = 1056964608;
            System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Int32>> val_12 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Int32>>();
            System.Collections.Generic.Dictionary<System.String, System.Int32> val_13 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
            val_13.Add(key:  "ln", value:  3);
            val_13.Add(key:  "bn", value:  35);
            val_12.Add(item:  val_13);
            System.Collections.Generic.Dictionary<System.String, System.Int32> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
            val_14.Add(key:  "ln", value:  4);
            val_14.Add(key:  "bn", value:  88);
            val_12.Add(item:  val_14);
            System.Collections.Generic.Dictionary<System.String, System.Int32> val_15 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
            val_15.Add(key:  "ln", value:  5);
            val_15.Add(key:  "bn", value:  105);
            val_12.Add(item:  val_15);
            System.Collections.Generic.Dictionary<System.String, System.Int32> val_16 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
            val_16.Add(key:  "ln", value:  6);
            val_16.Add(key:  "bn", value:  120);
            val_12.Add(item:  val_16);
            this.zenLineClearScoreBonus = val_12;
            this.ftux2PieceListEndLevel = 40;
            this.zenBaseScorePerBlock = 1;
            this.ftuxPieceListEndLevel = 6;
            System.Collections.Generic.List<System.Int32> val_17 = new System.Collections.Generic.List<System.Int32>();
            val_17.Add(item:  1);
            val_17.Add(item:  2);
            val_17.Add(item:  5);
            val_17.Add(item:  6);
            val_17.Add(item:  9);
            val_17.Add(item:  10);
            val_17.Add(item:  11);
            val_17.Add(item:  12);
            val_17.Add(item:  13);
            this.allowedShapeIdsFtux1 = val_17;
            System.Collections.Generic.List<System.Int32> val_18 = new System.Collections.Generic.List<System.Int32>();
            val_18.Add(item:  1);
            val_18.Add(item:  2);
            val_18.Add(item:  3);
            val_18.Add(item:  5);
            val_18.Add(item:  6);
            val_18.Add(item:  7);
            val_18.Add(item:  9);
            val_18.Add(item:  10);
            val_18.Add(item:  11);
            val_18.Add(item:  12);
            val_18.Add(item:  13);
            val_18.Add(item:  14);
            val_18.Add(item:  15);
            val_18.Add(item:  16);
            val_18.Add(item:  17);
            val_18.Add(item:  23);
            val_18.Add(item:  24);
            val_18.Add(item:  25);
            val_18.Add(item:  26);
            val_18.Add(item:  27);
            val_18.Add(item:  28);
            val_18.Add(item:  29);
            val_18.Add(item:  30);
            this.allowedShapeIdsChallengeMode = val_18;
            System.Collections.Generic.List<System.Int32> val_19 = new System.Collections.Generic.List<System.Int32>();
            val_19.Add(item:  1);
            val_19.Add(item:  2);
            val_19.Add(item:  3);
            val_19.Add(item:  5);
            val_19.Add(item:  6);
            val_19.Add(item:  7);
            val_19.Add(item:  9);
            val_19.Add(item:  10);
            val_19.Add(item:  11);
            val_19.Add(item:  12);
            val_19.Add(item:  13);
            val_19.Add(item:  14);
            val_19.Add(item:  15);
            val_19.Add(item:  16);
            val_19.Add(item:  17);
            this.allowedShapesIdsFtux2 = val_19;
            System.Collections.Generic.List<System.Int32> val_20 = new System.Collections.Generic.List<System.Int32>();
            val_20.Add(item:  0);
            val_20.Add(item:  1);
            val_20.Add(item:  2);
            val_20.Add(item:  3);
            val_20.Add(item:  4);
            val_20.Add(item:  5);
            val_20.Add(item:  6);
            val_20.Add(item:  7);
            val_20.Add(item:  8);
            val_20.Add(item:  9);
            val_20.Add(item:  10);
            val_20.Add(item:  11);
            val_20.Add(item:  12);
            val_20.Add(item:  13);
            val_20.Add(item:  18);
            val_20.Add(item:  19);
            val_20.Add(item:  20);
            val_20.Add(item:  21);
            val_20.Add(item:  22);
            this.allowedShapeIdsZenMode = val_20;
            this.starThreshold1 = 15;
            this.starThreshold2 = 27;
        }
        private static BestBlocksGameEcon()
        {
            BlockPuzzleMagic.BestBlocksGameEcon.LN_SCRBONUS_BONUS = 7;
            BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateOnlyChapters = 2;
            BlockPuzzleMagic.BestBlocksGameEcon.proceduralCrateStoneOnlyChapters = 2;
        }
    
    }

}
