using UnityEngine;
public class BestBlocksPlayer : Player
{
    // Fields
    private const string PREFKEY_PLAYER_LIVES = "bbl_plives";
    private const string PREFKEY_PLAYER_LIVES_SERVER = "experience";
    private const string PREFKEY_LAST_LIFE_TOPUP_TIME = "bbl_life_topuptime";
    private const string PREFKEY_ZEN_SCORE_BEST = "bbl_zen_scr_best";
    private const string PREFKEY_ZEN_SCORE_CURRENT = "bbl_zen_scr_curr";
    private const string PREFKEY_ZEN_SCORE_LIFETIME = "bbl_zen_scr_lftm";
    private const string PREFKEY_ZEN_PIECES_PLACED_CURRENT = "bbl_zen_pipl_curr";
    private const string PREFKEY_POWERUPUSAGE_LIFETIME = "bbl_pwrup_ul";
    private const string PREFKEY_POWERUPUSAGE_CHAPTER = "bbl_pwrup_uc";
    private const string PREFKEY_POWERUPUSAGE_LEVEL = "bbl_pwrup_ulvl";
    private const string PREFKEY_POWERUPUSAGE_LEVEL_FREE = "bbl_pwrup_ulvlfree";
    private const string PREFKEY_CONSECUTIVE_FAILS = "bbl_consecutivefails";
    private const string PREFKEY_PIECEROTATION_LIFETIME = "bbl_prot_ul";
    private const string PREFKEY_PIECEROTATION_CURRENT = "bbl_prot_cur";
    private const string PREFKEY_PIECEROTATION_PROMPT = "bbl_prot_prmt";
    private const string PREFKEY_JELLYLEVEL_INCREMENTS = "bbl_jellylvl_incre";
    private const string PREFKEY_STONELEVEL_INCREMENTS = "bbl_stonelvl_incre";
    private const string PREFKEY_GOALREQUIREMENT_INCREMENTS = "bbl_goalreq_incre";
    private const string PREFKEY_GOALQUANTITY_INCREMENTS = "bbl_goalqty_incre";
    private const string PREFKEY_TUTORIAL_COMPLETED = "bbl_10ksu";
    private const string PREFKEY_TUTORIAL_COMPLETED_SERVER = "keys";
    private EasySaver<BestBlocksPlayer> mySaver;
    public int tutorialCompleted;
    public int livesBalance;
    public int zenModeScoreBest;
    public int zenModeScoreCurrent;
    public int zenModeScoreLifetime;
    public int zenModePiecesPlacedCurrent;
    public System.DateTime lastLifeTopupTime;
    public int lifetimePowerupUsed;
    public int chapterPowerupUsed;
    public System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, int> levelPowerupUsed;
    public int levelPowerupFreeUsed;
    public int lifetimeRotationsUsed;
    public System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, int> currentRotationsUsed;
    public System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, bool> rotationPrompted;
    public int consecutiveGameFails;
    public int levelGenJellyLevelsIncrementCount;
    public int levelGenStoneLevelsIncrementCount;
    public System.Collections.Generic.Dictionary<BlockPuzzleMagic.Goal.GoalType, int> goalRequirementIncrement;
    public System.Collections.Generic.List<int> computedGoalQuantity;
    
    // Properties
    public static BestBlocksPlayer Instance { get; }
    public string lastLifeTopupTimeJson { get; }
    public string levelPowerupUsedJson { get; }
    public string currentRotationsUsedJson { get; }
    public string rotationPromptedJson { get; }
    public string goalRequirementIncrementJson { get; }
    public string computedGoalQuantityJson { get; }
    public System.TimeSpan LivesMaxTimeLeft { get; }
    
    // Methods
    public static BestBlocksPlayer get_Instance()
    {
        Player val_1 = App.Player;
        if(val_1 == null)
        {
                return (BestBlocksPlayer)val_1;
        }
        
        return (BestBlocksPlayer)val_1;
    }
    public string get_lastLifeTopupTimeJson()
    {
        return (string)Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.lastLifeTopupTime);
    }
    public string get_levelPowerupUsedJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.levelPowerupUsed);
    }
    public string get_currentRotationsUsedJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.currentRotationsUsed);
    }
    public string get_rotationPromptedJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.rotationPrompted);
    }
    public string get_goalRequirementIncrementJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.goalRequirementIncrement);
    }
    public string get_computedGoalQuantityJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.computedGoalQuantity);
    }
    public override void BuildReflectedLists()
    {
        this.mySaver = new EasySaver<BestBlocksPlayer>(incInstance:  this);
        if(this.goalRequirementIncrement != null)
        {
                if(this.goalRequirementIncrement.Count > 0)
        {
            goto label_2;
        }
        
        }
        
        System.Collections.Generic.Dictionary<GoalType, System.Int32> val_3 = new System.Collections.Generic.Dictionary<GoalType, System.Int32>();
        val_3.Add(key:  1, value:  0);
        val_3.Add(key:  2, value:  0);
        val_3.Add(key:  3, value:  0);
        this.goalRequirementIncrement = val_3;
        label_2:
        if(this.computedGoalQuantity != null)
        {
                if(this.computedGoalQuantity > 0)
        {
                return;
        }
        
        }
        
        BlockPuzzleMagic.BestBlocksGameEcon val_4 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        this.computedGoalQuantity = new System.Collections.Generic.List<System.Int32>(collection:  val_4.goalQuantityArray);
    }
    public override void AddHardSaves(ref System.Collections.Generic.Dictionary<string, object> incDic)
    {
        this.mySaver.AddHardSavesToDictionary(refdic: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = incDic);
    }
    protected override void TrustServerData(System.Collections.IDictionary diff)
    {
        var val_8;
        var val_9;
        var val_11;
        object val_12;
        var val_14;
        var val_11 = 0;
        val_11 = val_11 + 1;
        val_8 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  "experience")) != false)
        {
                var val_12 = 0;
            val_12 = val_12 + 1;
            val_9 = 0;
            val_11 = public System.Object System.Collections.IDictionary::get_Item(object key);
            this.livesBalance = System.Int32.Parse(s:  diff.Item["experience"]);
        }
        
        val_12 = "keys";
        var val_13 = 0;
        val_13 = val_13 + 1;
        val_11 = 4;
        val_14 = public System.Boolean System.Collections.IDictionary::Contains(object key);
        if((diff.Contains(key:  val_12)) != false)
        {
                val_12 = "keys";
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_14 = 0;
            this.tutorialCompleted = System.Int32.Parse(s:  diff.Item[val_12], style:  511);
        }
        
        this.TrustServerData(diff:  diff);
    }
    protected override void LoadFromLocal()
    {
        this.LoadFromLocal();
        this.livesBalance = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_plives", defaultValue:  0);
        this.lifetimePowerupUsed = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_pwrup_ul", defaultValue:  0);
        this.chapterPowerupUsed = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_pwrup_uc", defaultValue:  0);
        string val_4 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_pwrup_ulvl");
        if((System.String.IsNullOrEmpty(value:  val_4)) != true)
        {
                System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.Int32> val_6 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.Int32>>(value:  val_4);
            this.levelPowerupUsed = val_6;
            if(val_6 == null)
        {
                this.levelPowerupUsed = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.Int32>();
        }
        
        }
        
        this.lifetimeRotationsUsed = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_prot_ul", defaultValue:  0);
        string val_9 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_prot_cur", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_9)) != true)
        {
                System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Int32> val_11 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Int32>>(value:  val_9);
            this.currentRotationsUsed = val_11;
            if(val_11 == null)
        {
                this.currentRotationsUsed = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Int32>();
        }
        
        }
        
        string val_13 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_prot_prmt", defaultValue:  0);
        if((System.String.IsNullOrEmpty(value:  val_13)) != true)
        {
                System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Boolean> val_15 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Boolean>>(value:  val_13);
            this.rotationPrompted = val_15;
            if(val_15 == null)
        {
                this.rotationPrompted = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Boolean>();
        }
        
        }
        
        this.consecutiveGameFails = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_consecutivefails", defaultValue:  0);
        this.levelGenJellyLevelsIncrementCount = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_jellylvl_incre", defaultValue:  0);
        this.levelGenStoneLevelsIncrementCount = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_stonelvl_incre", defaultValue:  0);
        this.goalRequirementIncrement = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<GoalType, System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "bbl_goalreq_incre", defaultValue:  System.String.alignConst));
        this.computedGoalQuantity = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "bbl_goalqty_incre", defaultValue:  System.String.alignConst));
        string val_24 = UnityEngine.PlayerPrefs.GetString(key:  "bbl_life_topuptime");
        if((System.String.IsNullOrEmpty(value:  val_24)) != true)
        {
                System.DateTime val_26 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.DateTime>(value:  val_24);
            this.lastLifeTopupTime = val_26;
        }
        
        this.tutorialCompleted = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_10ksu", defaultValue:  this.tutorialCompleted);
        this.zenModeScoreBest = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_zen_scr_best", defaultValue:  0);
        this.zenModeScoreCurrent = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_zen_scr_curr", defaultValue:  0);
        this.zenModeScoreLifetime = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_zen_scr_lftm", defaultValue:  0);
        this.zenModePiecesPlacedCurrent = UnityEngine.PlayerPrefs.GetInt(key:  "bbl_zen_pipl_curr", defaultValue:  0);
        bool val_32 = this.RefreshPlayerLives();
    }
    protected override void CreateNewPlayer(string id = " ")
    {
        this.CreateNewPlayer(id:  id);
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        this.livesBalance = val_1.maxPlayerLives;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        this.lastLifeTopupTime = val_2;
        this.tutorialCompleted = 0;
    }
    public bool IsFTUXGameLevels()
    {
        return BlockPuzzleMagic.BBLFtuxData.IsEligibleForCuratedFtuxLevels(playerLevel:  App.Player);
    }
    public bool GetFtuxStatus(BlockPuzzleMagic.FtuxId ftuxId)
    {
        if(ftuxId == 0)
        {
                return false;
        }
        
        var val_2 = 1;
        val_2 = val_2 << ftuxId;
        return (bool)(this.tutorialCompleted != val_2) ? 1 : 0;
    }
    public void SetFtuxStatus(BlockPuzzleMagic.FtuxId ftuxId, bool completed)
    {
        if(ftuxId == 0)
        {
                return;
        }
        
        int val_4 = this.tutorialCompleted;
        var val_3 = 1;
        val_3 = val_3 << ftuxId;
        val_4 = val_4 | val_3;
        this.tutorialCompleted = (completed != true) ? (val_4) : (val_4 & (~val_3));
    }
    public bool IsLivesMaxed()
    {
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        return (bool)(this.livesBalance >= val_1.maxPlayerLives) ? 1 : 0;
    }
    public System.TimeSpan get_LivesMaxTimeLeft()
    {
        ulong val_9;
        var val_11;
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        System.DateTime val_4 = this.lastLifeTopupTime.ToLocalTime();
        float val_9 = val_1.lifeRechargeTimeMins;
        val_9 = val_9 * ((float)UnityEngine.Mathf.Clamp(value:  val_1.maxPlayerLives - this.livesBalance, min:  1, max:  val_1.maxPlayerLives));
        System.DateTime val_5 = val_4.dateData.AddMinutes(value:  (double)val_9);
        val_9 = val_5.dateData;
        System.DateTime val_6 = System.DateTime.Now;
        System.TimeSpan val_7 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_9}, d2:  new System.DateTime() {dateData = val_6.dateData});
        if(val_7._ticks.TotalSeconds > 0f)
        {
                return (System.TimeSpan)System.TimeSpan.__il2cppRuntimeField_static_fields;
        }
        
        val_9 = 1152921504622821376;
        val_11 = null;
        val_11 = null;
        return (System.TimeSpan)System.TimeSpan.__il2cppRuntimeField_static_fields;
    }
    public bool RefreshPlayerLives()
    {
        float val_10;
        var val_11;
        if(this.IsLivesMaxed() == true)
        {
            goto label_1;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = this.lastLifeTopupTime});
        val_10 = val_3._ticks.TotalMinutes;
        BlockPuzzleMagic.BestBlocksGameEcon val_5 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        if(val_10 >= (double)val_5.lifeRechargeTimeMins)
        {
            goto label_9;
        }
        
        label_1:
        val_11 = 0;
        return (bool)val_11;
        label_9:
        val_10 = val_3._ticks.TotalMinutes;
        BlockPuzzleMagic.BestBlocksGameEcon val_7 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        float val_10 = (float)val_10;
        val_10 = val_10 / val_7.lifeRechargeTimeMins;
        int val_9 = this.CreditLife(amount:  UnityEngine.Mathf.FloorToInt(f:  val_10), source:  0);
        val_11 = 1;
        this.lastLifeTopupTime = val_2;
        return (bool)val_11;
    }
    public int DebitLife(int amount = 1)
    {
        if(this.IsLivesMaxed() != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            this.lastLifeTopupTime = val_2;
        }
        
        this.SendLivesFullNotification(timeFromNow:  new System.Nullable<System.TimeSpan>() {HasValue = false});
        return (int)this.CreditLife(amount:  -amount, source:  0);
    }
    public void SendLivesFullNotification(System.Nullable<System.TimeSpan> timeFromNow)
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  21);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "notification_type", value:  "livesfull");
        if((X2 & 255) == 0)
        {
                System.TimeSpan val_2 = timeFromNow.HasValue.Value;
        }
        else
        {
                System.TimeSpan val_3 = this.LivesMaxTimeLeft;
        }
        
        System.DateTime val_4 = System.DateTime.UtcNow;
        System.DateTime val_5 = val_4.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3._ticks});
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  21, when:  new System.DateTime() {dateData = val_5.dateData}, interval:  0, optTitle:  0, optMessage:  "Lives are full! Time to keep playing!", extraData:  val_1, priority:  0, useTimeModifier:  true);
    }
    public int CreditLife(int amount = 1, string source)
    {
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        this.livesBalance = UnityEngine.Mathf.Clamp(value:  this.livesBalance + amount, min:  0, max:  val_1.maxPlayerLives);
        if((System.String.IsNullOrEmpty(value:  source)) != true)
        {
                App.Player.TrackNonCoinReward(source:  source, subSource:  0, rewardType:  0, rewardAmount:  0, additionalParams:  0);
        }
        
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        return (int)this.livesBalance;
    }
    public int GetPowerupAmountUsedThisLevel(BlockPuzzleMagic.PowerUpType powerupType)
    {
        if((this.levelPowerupUsed.ContainsKey(key:  powerupType)) == false)
        {
                return 0;
        }
        
        return this.levelPowerupUsed.Item[powerupType];
    }
    public bool IsFreePowerupAvailable(BlockPuzzleMagic.PowerUpType powerupType)
    {
        return false;
    }
    public void IncrementCurrentRotationsUsed(BlockPuzzleMagic.GameMode mode, int stepAmt)
    {
        EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Int32>(dic:  this.currentRotationsUsed, key:  mode, newValue:  (EnumerableExtentions.GetOrDefault<BlockPuzzleMagic.GameMode, System.Int32>(dic:  this.currentRotationsUsed, key:  mode, defaultValue:  0)) + stepAmt);
        int val_3 = this.lifetimeRotationsUsed;
        val_3 = val_3 + 1;
        this.lifetimeRotationsUsed = val_3;
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
    public BestBlocksPlayer()
    {
        null = null;
        this.lastLifeTopupTime = System.DateTime.MinValue;
        this.levelPowerupUsed = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.Int32>();
        this.currentRotationsUsed = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Int32>();
        this.rotationPrompted = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Boolean>();
        this.goalRequirementIncrement = new System.Collections.Generic.Dictionary<GoalType, System.Int32>();
        this.computedGoalQuantity = new System.Collections.Generic.List<System.Int32>();
    }

}
