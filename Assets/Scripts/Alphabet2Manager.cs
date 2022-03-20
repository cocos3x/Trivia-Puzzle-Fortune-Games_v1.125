using UnityEngine;
public class Alphabet2Manager : MonoSingleton<Alphabet2Manager>
{
    // Fields
    private static System.Collections.Generic.List<string> supportLangs;
    private int tilesPerCollectionBox;
    private float uncommonThreshold;
    private float rareThreshold;
    private float superThreshold;
    private decimal commonReward;
    private decimal uncommonReward;
    private decimal rareReward;
    private decimal superReward;
    private string currentVideoRewardLetter;
    private bool QAHACK_alwaysPostLevelTile;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> AlphabetCollections;
    private System.Collections.Generic.Dictionary<string, float> AlphabetLetterData;
    private UnityEngine.GameObject currentAlphabetTileObject;
    private bool isLevelCompleteListenerAdded;
    public System.Action OnAlphabetTileCollected;
    public System.Action OnAlphabetCollectionCompleted;
    public System.Action OnPetAlphabetTileSpawned;
    public System.Action OnTileClickAction;
    
    // Properties
    public static bool IsAvailable { get; }
    private decimal completeCollectionReward { get; }
    private int minLevelsPerTile { get; }
    private int maxLevelsPerTile { get; }
    private int postLevelTileFreq_Modulo { get; }
    private int unlockLevel { get; }
    private decimal redrawCoinCost { get; }
    private int currentCollectionIndex { get; set; }
    private int totalCollectionsComplete { get; set; }
    private decimal currentCollectionRewardBonus { get; set; }
    private System.Collections.Generic.List<string> currentCollectionBox { get; set; }
    private System.Collections.Generic.List<string> currentCollectionProgress { get; set; }
    private int nextLevelWithTile { get; set; }
    private string currentLanguage { get; set; }
    private bool inFTUX { get; }
    private int lifetimeRedraws { get; set; }
    private string currentCollectionLetter { get; set; }
    private int currentLineWord { get; set; }
    private int currentCell { get; set; }
    private int lastLevelWithTile { get; set; }
    private string lastTileType { get; set; }
    private bool collectedLastLevel { get; set; }
    private string lastLevelWithTileRarity { get; set; }
    private int levelsLapsedSinceTileSpawned { get; set; }
    private GameplayMode lastGameModeWithTile { get; set; }
    private string lastGameModeSecondayId { get; set; }
    private UnityEngine.GameObject AlphabetTileObjectPrefab { get; }
    private UnityEngine.GameObject AlphabetTileTooltipPrefab { get; }
    public int TilesPerCollectionBox { get; }
    public bool isAvailable { get; }
    public bool hasDataLoaded { get; }
    public bool canAddGameplayTile { get; }
    public string GetCurrentCollectionLetter { get; }
    public System.Collections.Generic.List<string> GetCurrentCollection { get; }
    public System.Collections.Generic.List<string> GetCurrentCollectionProgress { get; }
    public System.Collections.Generic.List<string> GetCurrentCollectionBox { get; }
    public decimal GetCurrentRewardAmount { get; }
    public UnityEngine.GameObject CurrentAlphabetTileObject { get; set; }
    public string GetCurrentVideoRewardLetter { get; }
    public bool QAHACK_AlwaysPostLevelTile { get; set; }
    public int GetAbWordIndex { get; }
    public decimal GetRedrawCost { get; }
    public int LifetimeRedrawsUsed { get; set; }
    public bool IsCurrentLevelWithTile { get; }
    
    // Methods
    public static bool get_IsAvailable()
    {
        System.Collections.Generic.List<System.String> val_8;
        var val_9;
        val_8 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        val_9 = null;
        val_9 = null;
        val_8 = Alphabet2Manager.supportLangs;
        GameBehavior val_2 = App.getBehavior;
        if((val_8.Contains(item:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) == false)
        {
                return false;
        }
        
        val_8 = MonoSingleton<Alphabet2Manager>.Instance;
        if(val_8 != 0)
        {
                return MonoSingleton<Alphabet2Manager>.Instance.isAvailable;
        }
        
        return false;
    }
    private static void onTileClicked()
    {
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionPopup>(showNext:  true).SetupWithInfo();
    }
    private decimal get_completeCollectionReward()
    {
        GameEcon val_1 = App.getGameEcon;
        return new System.Decimal() {flags = val_1.ab_completeCollectionReward, hi = val_1.ab_completeCollectionReward};
    }
    private int get_minLevelsPerTile()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ab_minLevelsPerTile;
    }
    private int get_maxLevelsPerTile()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ab_maxLevelsPerTile;
    }
    private int get_postLevelTileFreq_Modulo()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ab_postLevelTileFreq_Modulo;
    }
    private int get_unlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.ab_unlockLevel;
    }
    private decimal get_redrawCoinCost()
    {
        GameEcon val_1 = App.getGameEcon;
        return new System.Decimal() {flags = val_1.ab_redrawCoinCost, hi = val_1.ab_redrawCoinCost};
    }
    private int get_currentCollectionIndex()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.ab_currentCollectionIndex;
    }
    private void set_currentCollectionIndex(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_currentCollectionIndex = value;
    }
    private int get_totalCollectionsComplete()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.ab_totalCollectionsComplete;
    }
    private void set_totalCollectionsComplete(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_totalCollectionsComplete = value;
    }
    private decimal get_currentCollectionRewardBonus()
    {
        Player val_1 = App.Player;
        return new System.Decimal() {flags = val_1.properties.ab_currentCollectionBonus, hi = val_1.properties.ab_currentCollectionBonus};
    }
    private void set_currentCollectionRewardBonus(decimal value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_currentCollectionBonus = value;
        mem2[0] = value.lo;
        mem[4] = value.mid;
    }
    private System.Collections.Generic.List<string> get_currentCollectionBox()
    {
        Player val_1 = App.Player;
        return (System.Collections.Generic.List<System.String>)val_1.properties.ab_currentCollectionBox;
    }
    private void set_currentCollectionBox(System.Collections.Generic.List<string> value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_currentCollectionBox = value;
    }
    private System.Collections.Generic.List<string> get_currentCollectionProgress()
    {
        Player val_1 = App.Player;
        return (System.Collections.Generic.List<System.String>)val_1.properties.ab_currentCollectionProgress;
    }
    private void set_currentCollectionProgress(System.Collections.Generic.List<string> value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_currentCollectionProgress = value;
    }
    private int get_nextLevelWithTile()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.ab_nextLevel;
    }
    private void set_nextLevelWithTile(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_nextLevel = value;
    }
    private string get_currentLanguage()
    {
        Player val_1 = App.Player;
        return (string)val_1.properties.ab_currentLanguage;
    }
    private void set_currentLanguage(string value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_currentLanguage = value;
    }
    private bool get_inFTUX()
    {
        var val_5;
        int val_1 = this.nextLevelWithTile;
        if(val_1 != 0)
        {
                val_5 = 0;
            return (bool)(val_1.nextLevelWithTile <= (val_3.<metaGameBehavior>k__BackingField)) ? 1 : 0;
        }
        
        GameBehavior val_3 = App.getBehavior;
        return (bool)(val_1.nextLevelWithTile <= (val_3.<metaGameBehavior>k__BackingField)) ? 1 : 0;
    }
    private int get_lifetimeRedraws()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.ab_lifeftime_redraws;
    }
    private void set_lifetimeRedraws(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.ab_lifeftime_redraws = value;
    }
    private string get_currentCollectionLetter()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "ab_curr_coll_ltr", defaultValue:  "");
    }
    private void set_currentCollectionLetter(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "ab_curr_coll_ltr", value:  value);
    }
    private int get_currentLineWord()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ab_curr_lineword", defaultValue:  0);
    }
    private void set_currentLineWord(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ab_curr_lineword", value:  value);
    }
    private int get_currentCell()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ab_curr_cell", defaultValue:  0);
    }
    private void set_currentCell(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ab_curr_cell", value:  value);
    }
    private int get_lastLevelWithTile()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ab_last_lvl", defaultValue:  0);
    }
    private void set_lastLevelWithTile(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ab_last_lvl", value:  value);
    }
    private string get_lastTileType()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "ab_last_type", defaultValue:  "regular");
    }
    private void set_lastTileType(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "ab_last_type", value:  value);
    }
    private bool get_collectedLastLevel()
    {
        return (bool)System.Boolean.Parse(value:  UnityEngine.PlayerPrefs.GetString(key:  "ab_collected_last", defaultValue:  0.ToString()));
    }
    private void set_collectedLastLevel(bool value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "ab_collected_last", value:  value.ToString());
    }
    private string get_lastLevelWithTileRarity()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "ab_last_rarity", defaultValue:  "");
    }
    private void set_lastLevelWithTileRarity(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "ab_last_rarity", value:  value);
    }
    private int get_levelsLapsedSinceTileSpawned()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ab_lvls_lapsed", defaultValue:  0);
    }
    private void set_levelsLapsedSinceTileSpawned(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ab_lvls_lapsed", value:  value);
    }
    private GameplayMode get_lastGameModeWithTile()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ab_last_gmode", defaultValue:  1);
    }
    private void set_lastGameModeWithTile(GameplayMode value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ab_last_gmode", value:  value);
    }
    private string get_lastGameModeSecondayId()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "ab_last_gsubmode", defaultValue:  0);
    }
    private void set_lastGameModeSecondayId(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "ab_last_gsubmode", value:  value);
    }
    private UnityEngine.GameObject get_AlphabetTileObjectPrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "AlphabetTile", prefabName:  "alphabetTile");
    }
    private UnityEngine.GameObject get_AlphabetTileTooltipPrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "AlphabetTile", prefabName:  "alphabetTooltip");
    }
    public int get_TilesPerCollectionBox()
    {
        return (int)this.tilesPerCollectionBox;
    }
    public bool get_isAvailable()
    {
        GameBehavior val_1 = App.getBehavior;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  val_1.<metaGameBehavior>k__BackingField.unlockLevel);
    }
    public bool get_hasDataLoaded()
    {
        var val_4;
        if(this.AlphabetCollections.Count >= 1)
        {
                var val_3 = (this.AlphabetLetterData.Count > 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public bool get_canAddGameplayTile()
    {
        bool val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    public string get_GetCurrentCollectionLetter()
    {
        return this.currentCollectionLetter;
    }
    public System.Collections.Generic.List<string> get_GetCurrentCollection()
    {
        return this.AlphabetCollections.Item[this.currentCollectionIndex];
    }
    public System.Collections.Generic.List<string> get_GetCurrentCollectionProgress()
    {
        return this.currentCollectionProgress;
    }
    public System.Collections.Generic.List<string> get_GetCurrentCollectionBox()
    {
        return this.currentCollectionBox;
    }
    public decimal get_GetCurrentRewardAmount()
    {
        decimal val_1 = this.completeCollectionReward;
        decimal val_2 = val_1.flags.currentCollectionRewardBonus;
        return System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
    }
    public UnityEngine.GameObject get_CurrentAlphabetTileObject()
    {
        return (UnityEngine.GameObject)this.currentAlphabetTileObject;
    }
    public void set_CurrentAlphabetTileObject(UnityEngine.GameObject value)
    {
        this.currentAlphabetTileObject = value;
    }
    public string get_GetCurrentVideoRewardLetter()
    {
        string val_3;
        if((System.String.IsNullOrEmpty(value:  this.currentVideoRewardLetter)) != false)
        {
                this.currentVideoRewardLetter = this.PickNextCollectionLetter();
            return val_3;
        }
        
        val_3 = this.currentVideoRewardLetter;
        return val_3;
    }
    public bool get_QAHACK_AlwaysPostLevelTile()
    {
        return (bool)this.QAHACK_alwaysPostLevelTile;
    }
    public void set_QAHACK_AlwaysPostLevelTile(bool value)
    {
        this.QAHACK_alwaysPostLevelTile = value;
    }
    public int get_GetAbWordIndex()
    {
        bool val_2 = System.String.IsNullOrEmpty(value:  this.currentCollectionLetter);
        if(val_2 == false)
        {
                return val_2.currentLineWord;
        }
        
        return 0;
    }
    public decimal get_GetRedrawCost()
    {
        return this.redrawCoinCost;
    }
    public int get_LifetimeRedrawsUsed()
    {
        return this.lifetimeRedraws;
    }
    public void set_LifetimeRedrawsUsed(int value)
    {
        this.lifetimeRedraws = value;
    }
    public bool get_IsCurrentLevelWithTile()
    {
        var val_5;
        bool val_1 = this.IsCurrentModeEqualsModeWithTile();
        if(val_1 != false)
        {
                var val_4 = (val_1.lastLevelWithTile == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    public bool IsCurrentModeEqualsModeWithTile()
    {
        var val_9;
        GameplayMode val_1 = PlayingLevel.CurrentGameplayMode;
        if(val_1 != val_1.lastGameModeWithTile)
        {
            goto label_3;
        }
        
        GameplayMode val_3 = PlayingLevel.CurrentGameplayMode;
        if(val_3 != 4)
        {
            goto label_6;
        }
        
        val_9 = 0;
        if((System.Int32.TryParse(s:  val_3.lastGameModeSecondayId, result: out  0)) == false)
        {
                return (bool)val_9;
        }
        
        CategoryPacksManager val_7 = MonoSingleton<CategoryPacksManager>.Instance;
        var val_8 = ((val_7.<CurrentCategoryPackInfo>k__BackingField.packId) == 0) ? 1 : 0;
        return (bool)val_9;
        label_3:
        val_9 = 0;
        return (bool)val_9;
        label_6:
        val_9 = 1;
        return (bool)val_9;
    }
    public System.Collections.Generic.Dictionary<string, object> GetLevelTracking()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "level", value:  val_1.lastLevelWithTile);
        val_1.Add(key:  "rarity", value:  val_1.lastLevelWithTileRarity);
        val_1.Add(key:  "collected", value:  val_1.collectedLastLevel);
        return val_1;
    }
    public System.Collections.Generic.List<string> RollLettersForRarity(Alphabet2Manager.Rarity rarity, int count)
    {
        System.Func<TSource, System.Boolean> val_9;
        System.Collections.Generic.IEnumerable<TSource> val_10;
        var val_11;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.String> val_13;
        .<>4__this = this;
        .rarity = rarity;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.Boolean> val_3 = null;
        val_9 = val_3;
        val_3 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.Boolean>(object:  new Alphabet2Manager.<>c__DisplayClass132_0(), method:  System.Boolean Alphabet2Manager.<>c__DisplayClass132_0::<RollLettersForRarity>b__0(System.Collections.Generic.KeyValuePair<string, float> kvp));
        val_10 = System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.String, System.Single>>(source:  this.AlphabetLetterData, predicate:  val_3);
        val_11 = null;
        val_11 = null;
        val_13 = Alphabet2Manager.<>c.<>9__132_1;
        if(val_13 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.String> val_5 = null;
            val_13 = val_5;
            val_5 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.String>(object:  Alphabet2Manager.<>c.__il2cppRuntimeField_static_fields, method:  System.String Alphabet2Manager.<>c::<RollLettersForRarity>b__132_1(System.Collections.Generic.KeyValuePair<string, float> kvp));
            Alphabet2Manager.<>c.<>9__132_1 = val_13;
        }
        
        var val_9 = 1152921510375394352;
        if(count < 1)
        {
                return val_2;
        }
        
        val_10 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.Single>, System.String>(source:  val_10, selector:  val_5));
        do
        {
            int val_8 = UnityEngine.Random.Range(min:  0, max:  1473580080);
            if(val_9 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_8 << 3);
            val_2.Add(item:  (1152921510375394352 + (val_8) << 3) + 32);
            val_9 = 0 + 1;
        }
        while(val_9 < count);
        
        return val_2;
    }
    public Alphabet2Manager.Rarity GetCurrentRarity()
    {
        System.Object[] val_8;
        var val_9;
        val_8 = this;
        bool val_2 = this.AlphabetLetterData.ContainsKey(key:  this.currentCollectionLetter);
        if(val_2 == false)
        {
            goto label_2;
        }
        
        float val_4 = this.AlphabetLetterData.Item[val_2.currentCollectionLetter];
        if(this.uncommonThreshold < 0)
        {
            goto label_4;
        }
        
        if(this.rareThreshold >= 0)
        {
            goto label_5;
        }
        
        val_9 = 1;
        return (Rarity)val_9;
        label_2:
        object[] val_5 = new object[1];
        val_8 = val_5;
        val_8[0] = val_5.currentCollectionLetter;
        UnityEngine.Debug.LogErrorFormat(format:  "AplhabetLetterData doesn\'t contain: {0}", args:  val_5);
        label_4:
        val_9 = 0;
        return (Rarity)val_9;
        label_5:
        var val_7 = (this.superThreshold < 0) ? 2 : 3;
        return (Rarity)val_9;
    }
    public Alphabet2Manager.Rarity GetRarity(string letter)
    {
        var val_5;
        if((this.AlphabetLetterData.ContainsKey(key:  letter)) == false)
        {
            goto label_2;
        }
        
        float val_2 = this.AlphabetLetterData.Item[letter];
        if(this.uncommonThreshold < 0)
        {
            goto label_4;
        }
        
        if(this.rareThreshold >= 0)
        {
            goto label_5;
        }
        
        val_5 = 1;
        return (Rarity)val_5;
        label_2:
        object[] val_3 = new object[1];
        val_3[0] = letter;
        UnityEngine.Debug.LogErrorFormat(format:  "AplhabetLetterData doesn\'t contain: {0}", args:  val_3);
        label_4:
        val_5 = 0;
        return (Rarity)val_5;
        label_5:
        var val_4 = (this.superThreshold < 0) ? 2 : 3;
        return (Rarity)val_5;
    }
    public decimal GetRewardForLetter(string letter)
    {
        return this.GetRewardByRarity(rarity:  this.GetRarity(letter:  letter));
    }
    public bool ShouldShowPostLevelAd()
    {
        var val_7;
        int val_1 = this.nextLevelWithTile;
        if(val_1 == 0)
        {
                return (bool)(val_5 == 0) ? 1 : 0;
        }
        
        if(this.QAHACK_alwaysPostLevelTile != false)
        {
                val_7 = 1;
            return (bool)(val_5 == 0) ? 1 : 0;
        }
        
        int val_3 = UnityEngine.Random.Range(min:  0, max:  val_1.postLevelTileFreq_Modulo);
        int val_4 = val_3.postLevelTileFreq_Modulo;
        int val_5 = val_3 / val_4;
        val_5 = val_3 - (val_5 * val_4);
        return (bool)(val_5 == 0) ? 1 : 0;
    }
    public bool IsCurrentCollectionComplete()
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_7;
        var val_8;
        System.Predicate<System.String> val_10;
        var val_11;
        val_7 = this.AlphabetCollections;
        if(41971712 != 1152921516018472640)
        {
            goto label_4;
        }
        
        val_7 = val_7.Item[this.currentCollectionProgress.currentCollectionIndex].currentCollectionProgress;
        val_8 = null;
        val_8 = null;
        val_10 = Alphabet2Manager.<>c.<>9__137_0;
        if(val_10 == null)
        {
                System.Predicate<System.String> val_5 = null;
            val_10 = val_5;
            val_5 = new System.Predicate<System.String>(object:  Alphabet2Manager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Alphabet2Manager.<>c::<IsCurrentCollectionComplete>b__137_0(string x));
            Alphabet2Manager.<>c.<>9__137_0 = val_10;
        }
        
        if((val_7.Exists(match:  val_5)) == false)
        {
            goto label_11;
        }
        
        label_4:
        val_11 = 0;
        return (bool)val_11;
        label_11:
        val_11 = 1;
        return (bool)val_11;
    }
    public bool ShouldShowFTUX()
    {
        return false;
    }
    public void ClearAndFillCollectionBox(int tileCount)
    {
        this.FillCollectionBoxRandomly(lettersToCollect:  tileCount);
    }
    public bool IsCollectionBoxFull()
    {
        System.Collections.Generic.List<System.String> val_1 = this.currentCollectionBox;
        return (bool)(true >= this.tilesPerCollectionBox) ? 1 : 0;
    }
    public void CollectFTUXBox()
    {
        int val_1 = this.nextLevelWithTile;
        if(val_1 != 0)
        {
                return;
        }
        
        val_1.nextLevelWithTile = 1;
    }
    public bool HasCollectedWordAtIndex(string word, int letterIndex)
    {
        Alphabet2Manager.<>c__DisplayClass142_0 val_1 = new Alphabet2Manager.<>c__DisplayClass142_0();
        .word = word;
        .letterIndex = letterIndex;
        return val_1.currentCollectionProgress.Exists(match:  new System.Predicate<System.String>(object:  val_1, method:  System.Boolean Alphabet2Manager.<>c__DisplayClass142_0::<HasCollectedWordAtIndex>b__0(string x)));
    }
    public void CollectTileFromBox(string word, int letterIndex)
    {
        int val_27;
        string val_28;
        string val_29;
        string val_30;
        string val_31;
        var val_32;
        string val_33;
        string val_34;
        val_27 = letterIndex;
        Alphabet2Manager.<>c__DisplayClass143_0 val_1 = new Alphabet2Manager.<>c__DisplayClass143_0();
        .word = word;
        string val_4 = val_1.currentCollectionProgress.Find(match:  new System.Predicate<System.String>(object:  val_1, method:  System.Boolean Alphabet2Manager.<>c__DisplayClass143_0::<CollectTileFromBox>b__0(string x)));
        val_28 = (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word;
        if((System.String.IsNullOrEmpty(value:  val_4)) == false)
        {
            goto label_3;
        }
        
        val_29 = val_28 + 0.CreateString(c:  '0', count:  (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.m_stringLength)(0.CreateString(c:  '0', count:  (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.m_stringLength));
        val_30 = "";
        if(val_7.m_stringLength >= 1)
        {
                do
        {
            int val_27 = (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.m_stringLength;
            val_27 = val_27 + val_27;
            if(0 == val_27)
        {
                val_31 = "1";
        }
        else
        {
                val_31 = val_29.Chars[0].ToString();
        }
        
            string val_10 = val_30 + val_31;
            val_28 = 0 + 1;
            val_30 = val_10;
        }
        while(val_28 < val_7.m_stringLength);
        
        }
        
        System.Collections.Generic.List<System.String> val_11 = val_10.currentCollectionProgress;
        val_32 = 1152921509851232320;
        val_33 = val_30;
        goto label_12;
        label_3:
        bool val_14 = System.Linq.Enumerable.ToArray<System.Char>(source:  System.Linq.Enumerable.Skip<System.Char>(source:  val_4, count:  (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.m_stringLength))[val_27 << 1][32].Equals(obj:  '0');
        if(val_14 == false)
        {
            goto label_16;
        }
        
        val_29 = "";
        if(val_4.m_stringLength >= 1)
        {
                do
        {
            int val_28 = (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.m_stringLength;
            val_28 = val_28 + val_27;
            if(0 == val_28)
        {
                val_34 = "1";
        }
        else
        {
                val_34 = val_4.Chars[0].ToString();
        }
        
            string val_17 = val_29 + val_34;
            val_28 = 0 + 1;
            val_29 = val_17;
        }
        while(val_28 < val_4.m_stringLength);
        
        }
        
        val_32 = 1152921509851232320;
        val_33 = val_29;
        label_12:
        val_17.currentCollectionProgress.Remove(item:  val_4).currentCollectionProgress.Add(item:  val_33);
        return;
        label_16:
        decimal val_21 = val_14.currentCollectionRewardBonus;
        decimal val_25 = this.GetRewardByRarity(rarity:  this.GetRarity(letter:  (Alphabet2Manager.<>c__DisplayClass143_0)[1152921516022086368].word.Chars[val_27].ToString()));
        val_27 = val_25.flags;
        val_29 = val_25.lo;
        decimal val_26 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_21.lo, mid = val_21.mid}, d2:  new System.Decimal() {flags = val_27, hi = val_25.hi, lo = val_29, mid = val_25.mid});
        val_26.flags.currentCollectionRewardBonus = new System.Decimal() {flags = val_26.flags, hi = val_26.hi, lo = val_26.lo, mid = val_26.mid};
    }
    public void CompleteCurrentCollection()
    {
        var val_15;
        var val_16;
        System.Collections.Generic.List<System.String> val_1 = this.currentCollectionBox;
        val_1.Clear();
        val_1.currentCollectionProgress.Clear();
        val_15 = null;
        val_15 = null;
        currentCollectionRewardBonus = new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        GameBehavior val_4 = App.getBehavior;
        val_16 = currentLanguage;
        if((val_16.Equals(value:  val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != true)
        {
                val_16 = this;
            this.ParseAlphabetData();
        }
        
        this.currentCollectionLetter = "";
        this.currentLineWord = 0;
        this.currentCell = 0;
        int val_8 = this.AlphabetCollections.Count;
        int val_9 = this.currentCollectionIndex + 1;
        val_8.currentCollectionIndex = val_9 - ((val_9 / val_8) * val_8);
        int val_12 = val_8.totalCollectionsComplete;
        val_12.totalCollectionsComplete = val_12 + 1;
        App.Player.SaveState();
    }
    public void CollectCurrentVideoRewardTile()
    {
        var val_5;
        this.currentCollectionLetter = this.currentVideoRewardLetter;
        this.currentVideoRewardLetter = "";
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Alphabet Tile Rarity", value:  this.GetCurrentRarity().ToString());
        val_5 = null;
        val_5 = null;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0}, source:  "Video_Ad_Alphabet_Tile", subSource:  0, externalParams:  val_1, doTrack:  true);
        this.CollectCurrentLetter();
    }
    public UnityEngine.Transform GetLetterTransform()
    {
        var val_4;
        int val_2 = WordRegion.instance.currentLineWord;
        if((X20 + 24) <= val_2)
        {
                val_4 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_4 = X20 + 16;
        val_4 = val_4 + (val_2 << 3);
        int val_3 = this.currentCell;
        if(((X20 + 16 + (val_2) << 3) + 32 + 40 + 24) <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = (X20 + 16 + (val_2) << 3) + 32 + 40 + 16;
        val_5 = val_5 + (val_3 << 3);
        return ((X20 + 16 + (val_2) << 3) + 32 + 40 + 16 + (val_3) << 3) + 32.transform;
    }
    public System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> GetRandomSeededPositionsForCollection(System.Collections.Generic.List<string> collectionBox)
    {
        var val_2;
        var val_3;
        System.Collections.Generic.IEnumerable<TSource> val_22;
        object val_23;
        int val_24;
        var val_28;
        var val_30;
        var val_31;
        val_22 = collectionBox;
        val_23 = this;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_1 = val_22.GetEnumerator();
        val_24 = 0;
        goto label_2;
        label_4:
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_24 - val_2.Chars[0];
        label_2:
        if(val_3.MoveNext() == true)
        {
            goto label_4;
        }
        
        val_3.Dispose();
        UnityEngine.Random.InitState(seed:  val_24);
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, System.Int32>> val_6 = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>();
        System.Linq.IOrderedEnumerable<TSource> val_8 = System.Linq.Enumerable.OrderBy<System.String, System.Int32>(source:  val_22, keySelector:  new System.Func<System.String, System.Int32>(object:  this, method:  System.Int32 Alphabet2Manager::<GetRandomSeededPositionsForCollection>b__147_0(string x)));
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_25 = 0;
        val_25 = val_25 + 1;
        val_22 = val_8.GetEnumerator();
        label_32:
        var val_26 = 0;
        val_26 = val_26 + 1;
        if(val_22.MoveNext() == false)
        {
            goto label_15;
        }
        
        Alphabet2Manager.<>c__DisplayClass147_0 val_13 = new Alphabet2Manager.<>c__DisplayClass147_0();
        var val_27 = 0;
        val_27 = val_27 + 1;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        .item = val_22.Current;
        System.Collections.Generic.List<System.String> val_16 = this.GetCurrentCollection;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_28 = 1152921516022751936;
        if((val_16.FindAll(match:  new System.Predicate<System.String>(object:  val_13, method:  System.Boolean Alphabet2Manager.<>c__DisplayClass147_0::<GetRandomSeededPositionsForCollection>b__1(string x)))) == null)
        {
                throw new NullReferenceException();
        }
        
        int val_19 = UnityEngine.Random.Range(min:  0, max:  -1468896832);
        if(val_28 <= val_19)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_28 = val_28 + (val_19 << 3);
        System.Collections.Generic.List<System.Int32> val_20 = new System.Collections.Generic.List<System.Int32>();
        if(((1152921516022751936 + (val_19) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((1152921516022751936 + (val_19) << 3) + 32 + 16) >= 1)
        {
                val_28 = 0;
            do
        {
            int val_21 = (1152921516022751936 + (val_19) << 3) + 32.IndexOf(value:  (Alphabet2Manager.<>c__DisplayClass147_0)[1152921516022843824].item, startIndex:  0);
            if((val_21 & 2147483648) == 0)
        {
                if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            val_20.Add(item:  val_21);
            val_28 = val_21;
        }
        
            var val_29 = (1152921516022751936 + (val_19) << 3) + 32 + 16;
            val_28 = val_28 + 1;
        }
        while(val_28 < val_29);
        
        }
        
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_22 = UnityEngine.Random.Range(min:  0, max:  val_21);
        if(val_29 <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_29 = val_29 + (val_22 << 2);
        val_3 = 0;
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_23 = new System.Collections.Generic.KeyValuePair<System.String, System.Int32>(key:  (1152921516022751936 + (val_19) << 3) + 32, value:  ((1152921516022751936 + (val_19) << 3) + 32 + 16 + (val_22) << 2) + 32);
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.Add(item:  new System.Collections.Generic.KeyValuePair<System.String, System.Int32>() {Value = val_23.Value});
        goto label_32;
        label_15:
        val_23 = 0;
        if(val_22 != null)
        {
                var val_30 = 0;
            val_30 = val_30 + 1;
            val_22.Dispose();
        }
        
        if(val_23 == 0)
        {
                return val_6;
        }
        
        val_30 = val_23;
        val_31 = 0;
        throw val_30;
    }
    public void QAHACK_GetTile()
    {
        int val_2 = WordRegion.instance.currentLineWord;
        if((X21 + 24) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_3 = X21 + 16;
        val_3 = val_3 + (val_2 << 3);
        this.onWordRegionWordFound(wordCompleted:  (X21 + 16 + (val_2) << 3) + 32 + 24);
    }
    public void QAHACK_AddTile()
    {
        this.nextLevelWithTile = 0;
        this.onWordRegionLoaded();
    }
    public void QAHACK_FillBoxAndCollect()
    {
        this.FillCollectionBoxAndShow();
    }
    public void QAHACK_CompleteCurrentCollection()
    {
        List.Enumerator<T> val_3 = this.AlphabetCollections.Item[this.currentCollectionIndex].GetEnumerator();
        goto label_5;
        label_7:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(11993091 >= 1)
        {
                var val_5 = 0;
            do
        {
            this.CollectTileFromBox(word:  0, letterIndex:  0);
            val_5 = val_5 + 1;
        }
        while(val_5 < 11993091);
        
        }
        
        label_5:
        if(0.MoveNext() == true)
        {
            goto label_7;
        }
        
        0.Dispose();
    }
    public void QAHACK_SampleTileCollection()
    {
        var val_5;
        System.Collections.Generic.List<System.String> val_1 = this.currentCollectionBox;
        val_1.Clear();
        val_1.currentCollectionProgress.Clear();
        val_5 = null;
        val_5 = null;
        currentCollectionRewardBonus = new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0};
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.QAHACK_SampleLoop());
    }
    private System.Collections.IEnumerator QAHACK_SampleLoop()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Alphabet2Manager.<QAHACK_SampleLoop>d__153();
    }
    private void Start()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void Alphabet2Manager::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void Alphabet2Manager::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance) == 0)
        {
                return;
        }
        
        this.ParseAlphabetData();
        return;
        label_8:
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void Alphabet2Manager::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Remove(source:  val_4.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void Alphabet2Manager::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnLocalize");
        return;
        label_8:
    }
    private void OnLocalize()
    {
        GameBehavior val_2 = App.getBehavior;
        if((this.currentLanguage.Equals(value:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) == true)
        {
                return;
        }
        
        GameBehavior val_5 = App.getBehavior;
        if(((val_5.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance) == 0)
        {
                return;
        }
        
        this.ParseAlphabetData();
    }
    private void ParseAlphabetData()
    {
        object val_42;
        var val_43;
        var val_44;
        var val_45;
        val_42 = this;
        val_43 = null;
        val_43 = null;
        val_44 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        bool val_3 = Alphabet2Manager.supportLangs.Contains(item:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        if(val_3 != false)
        {
                if((public System.Boolean System.Collections.Generic.List<System.String>::Contains(System.String item)) == 0)
        {
                System.Collections.Generic.List<System.String> val_5 = val_3.currentCollectionBox.currentCollectionProgress;
            if((public System.Boolean System.Collections.Generic.List<System.String>::Contains(System.String item)) == 0)
        {
                GameBehavior val_6 = App.getBehavior;
            string val_7 = val_6.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
            val_7.currentLanguage = val_7;
        }
        
        }
        
            bool val_9 = System.String.IsNullOrEmpty(value:  val_7.currentLanguage);
            if(val_9 != false)
        {
                val_9.currentLanguage = "en";
        }
        
            UnityEngine.Debug.LogWarning(message:  "Alphabet -- getting collection data for: "("Alphabet -- getting collection data for: ") + val_9.currentLanguage);
            this.AlphabetCollections.Clear();
            this.AlphabetLetterData.Clear();
            string val_12 = WordApp.GamePathName;
            this.AlphabetCollections = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>>(value:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "data/umbrella/"("data/umbrella/") + val_12 + "/alphabet_collection_"("/alphabet_collection_") + val_12.currentLanguage).text);
            string val_18 = WordApp.GamePathName;
            char[] val_23 = new char[1];
            val_23[0] = '
        ';
            if(val_24.Length >= 1)
        {
                do
        {
            char[] val_25 = new char[1];
            val_25[0] = '	';
            System.String[] val_26 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "data/umbrella/"("data/umbrella/") + val_18 + "/alphabet_rarity_"("/alphabet_rarity_") + val_18.currentLanguage).text.Split(separator:  val_23)[0].Split(separator:  val_25);
            val_45 = this.AlphabetLetterData;
            val_45.Add(key:  val_26[0].ToUpper(), value:  System.Single.Parse(s:  val_26[1], provider:  System.Globalization.CultureInfo.InvariantCulture));
        }
        while(1 < val_24.Length);
        
        }
        
            val_44 = 1152921516018110016;
            if(val_45.currentCollectionIndex < this.AlphabetCollections.Count)
        {
                return;
        }
        
            int val_32 = this.AlphabetCollections.Count;
            if(val_32 < 1)
        {
                return;
        }
        
            int val_33 = val_32.currentCollectionIndex;
            System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_45 = this.AlphabetCollections;
            int val_34 = val_45.Count;
            val_45 = val_33 / val_34;
            val_34.currentCollectionIndex = val_33 - (val_45 * val_34);
            val_42 = "Alphabet -- too few Collections, setting index to: "("Alphabet -- too few Collections, setting index to: ") + val_34.currentCollectionIndex.ToString();
            UnityEngine.Debug.LogWarning(message:  val_42);
            return;
        }
        
        object[] val_39 = new object[1];
        val_42 = val_39;
        GameBehavior val_40 = App.getBehavior;
        val_42[0] = val_40.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        UnityEngine.Debug.LogErrorFormat(format:  "ParseAlphabetData for unsupported lang: {0}", args:  val_39);
    }
    private void Instance_OnSceneLoaded(SceneType obj)
    {
        if(obj != 2)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        if(this.isAvailable == false)
        {
                return;
        }
        
        bool val_4 = this.hasDataLoaded;
        if(val_4 == false)
        {
                return;
        }
        
        if(val_4.canAddGameplayTile == false)
        {
                return;
        }
        
        WordRegion.instance.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  this, method:  System.Void Alphabet2Manager::onWordRegionLoaded()));
        WordRegion.instance.addOnPreprocessPlayerTurnAction(callback:  new System.Action<System.Boolean, System.String, LineWord, Cell>(object:  this, method:  System.Void Alphabet2Manager::OnPreprocessPlayerTurnAction(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)));
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void Alphabet2Manager::onWordRegionWordFound(string wordCompleted)));
        WordRegion.instance.addOnHintUsedAtLocation(callback:  new System.Action<UnityEngine.Vector3>(object:  this, method:  System.Void Alphabet2Manager::onWordRegionHintUsed(UnityEngine.Vector3 location)));
        MainController val_14 = MainController.instance;
        val_14.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void Alphabet2Manager::OnLevelComplete()));
        this.isLevelCompleteListenerAdded = true;
    }
    private void Instance_OnSceneUnloaded(SceneType obj)
    {
        if(this.isLevelCompleteListenerAdded == false)
        {
                return;
        }
        
        if(MainController.instance != 0)
        {
                MainController val_3 = MainController.instance;
            val_3.onLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void Alphabet2Manager::OnLevelComplete()));
        }
        
        this.isLevelCompleteListenerAdded = false;
    }
    private void FillCollectionBoxRandomly(int lettersToCollect)
    {
        var val_4;
        System.Collections.Generic.List<System.String> val_1 = this.currentCollectionBox;
        val_1.Clear();
        if(lettersToCollect < 1)
        {
                return;
        }
        
        var val_4 = 0;
        do
        {
            val_4 = val_1.currentCollectionBox;
            val_4.Add(item:  this.PickNextCollectionLetter());
            val_4 = val_4 + 1;
        }
        while(val_4 < lettersToCollect);
    
    }
    private void FillCollectionBoxAndShow()
    {
        this.FillCollectionBoxRandomly(lettersToCollect:  this.tilesPerCollectionBox);
        GameBehavior val_1 = App.getBehavior;
        mem2[0] = 0;
    }
    private bool IsAlphabetTileReady()
    {
        int val_1 = this.nextLevelWithTile;
        int val_7 = val_1;
        int val_2 = val_1.lastLevelWithTile;
        val_7 = val_7 - val_2;
        int val_3 = val_2.minLevelsPerTile;
        int val_5 = UnityEngine.Mathf.Clamp(value:  val_7, min:  val_3, max:  val_3.maxLevelsPerTile);
        int val_6 = val_5.levelsLapsedSinceTileSpawned;
        if(val_6 >= val_5)
        {
                return true;
        }
        
        return val_6.inFTUX;
    }
    private bool IsPetAlphabetTileReady()
    {
        UnityEngine.Object val_10;
        var val_11;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                float val_3 = (WADPetsManager.GetLevelCurveModifier(ability:  3)) * 100f;
            val_11 = 0;
            if(val_3 <= ((float)UnityEngine.Random.Range(min:  0, max:  100)))
        {
                return (bool)val_11;
        }
        
            val_10 = MonoSingleton<WADPetsManager>.Instance;
            if(val_10 != 0)
        {
                MonoSingleton<WADPetsManager>.Instance.Tracking_HasAlphabetTile();
            if((val_3.Equals(obj:  0f)) != true)
        {
                MonoSingleton<WADPetsManager>.Instance.Tracking_HasBonusAlphabetTile();
        }
        
        }
        
            val_11 = 1;
            return (bool)val_11;
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    private void OnLevelComplete()
    {
        int val_1 = this.levelsLapsedSinceTileSpawned;
        val_1.levelsLapsedSinceTileSpawned = val_1 + 1;
    }
    private void onWordRegionLoaded()
    {
        int val_33;
        var val_34;
        var val_73;
        var val_74;
        string val_75;
        UnityEngine.GameObject val_76;
        var val_77;
        UnityEngine.Transform val_78;
        var val_79;
        var val_80;
        System.Predicate<LineWord> val_82;
        System.Action val_84;
        var val_86;
        string val_87;
        val_73 = this;
        val_75 = 0;
        bool val_2 = System.String.IsNullOrEmpty(value:  this.currentCollectionLetter);
        if(val_2 == true)
        {
            goto label_2;
        }
        
        val_74 = val_73;
        bool val_3 = this.IsCurrentLevelWithTile;
        if(val_3 == false)
        {
            goto label_2;
        }
        
        int val_4 = val_3.currentLineWord;
        WordRegion val_5 = WordRegion.instance;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        WordRegion val_7 = WordRegion.instance;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_8 = val_7.currentLineWord;
        if(X23 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_8;
        if((X23 + 24) <= val_8)
        {
                val_76 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_71 = X23 + 16;
        val_71 = val_71 + (val_78 << 3);
        if(((X23 + 16 + (val_8) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((X23 + 16 + (val_8) << 3) + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_5.currentCell >= ((X23 + 16 + (val_8) << 3) + 32 + 40 + 24))
        {
            goto label_15;
        }
        
        WordRegion val_10 = WordRegion.instance;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_11 = val_10.currentLineWord;
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Void System.Globalization.JapaneseCalendar::.ctor()) <= val_11)
        {
                val_76 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_72 = System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index);
        val_72 = val_72 + (val_11 << 3);
        if(((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        int val_12 = this.currentCell;
        if(((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32 + 40 + 24) <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_73 = (System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32 + 40 + 16;
        val_73 = val_73 + (val_12 << 3);
        val_76 = mem[((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index)  + 32];
        val_76 = ((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index)  + 32;
        if(val_76 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_76.transform;
        UnityEngine.GameObject val_14 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.AlphabetTileObjectPrefab, parent:  val_78);
        this.currentAlphabetTileObject = val_14;
        val_75 = "pet";
        if((System.String.op_Equality(a:  val_14.lastTileType, b:  val_75)) == false)
        {
            goto label_27;
        }
        
        val_75 = 0;
        WADPets.WADPet val_17 = WADPetsManager.GetPetByAbility(ability:  3);
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = 0;
        val_79 = val_17.IsActive();
        goto label_29;
        label_2:
        bool val_19 = val_2.IsAlphabetTileReady();
        if(val_19 != true)
        {
                if(val_19.IsPetAlphabetTileReady() == false)
        {
                return;
        }
        
        }
        
        if(WordRegion.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = null;
        val_80 = null;
        val_82 = Alphabet2Manager.<>c.<>9__165_0;
        if(val_82 == null)
        {
                System.Predicate<LineWord> val_22 = null;
            val_75 = Alphabet2Manager.<>c.__il2cppRuntimeField_static_fields;
            val_82 = val_22;
            val_22 = new System.Predicate<LineWord>(object:  val_75, method:  System.Boolean Alphabet2Manager.<>c::<onWordRegionLoaded>b__165_0(LineWord x));
            Alphabet2Manager.<>c.<>9__165_0 = val_82;
        }
        
        if(X21 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X21.Exists(match:  val_22)) == true)
        {
                return;
        }
        
        string val_24 = this.PickNextCollectionLetter();
        val_24.currentCollectionLetter = val_24;
        val_75 = 0;
        if((System.String.IsNullOrEmpty(value:  val_24.currentCollectionLetter)) == true)
        {
                return;
        }
        
        WordRegion val_27 = WordRegion.instance;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = 0;
        if(val_27.getAvailableLineIndices == null)
        {
                throw new NullReferenceException();
        }
        
        RandomSet val_29 = null;
        val_75 = 0;
        val_29 = new RandomSet();
        WordRegion val_30 = WordRegion.instance;
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = 0;
        System.Collections.Generic.List<System.Int32> val_31 = val_30.getAvailableLineIndices;
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_32 = val_31.GetEnumerator();
        label_54:
        if(val_34.MoveNext() == false)
        {
            goto label_52;
        }
        
        val_29.add(item:  val_33, weight:  1f);
        goto label_54;
        label_15:
        val_75 = "";
        val_5.currentCollectionLetter = val_75;
        goto label_95;
        label_52:
        val_75 = public System.Void List.Enumerator<System.Int32>::Dispose();
        val_34.Dispose();
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_36 = val_29.roll(unweighted:  false);
        val_36.currentLineWord = val_36;
        val_75 = 0;
        val_36.currentCell = 0;
        val_78 = val_36.AlphabetTileObjectPrefab;
        WordRegion val_38 = WordRegion.instance;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_39 = val_38.currentLineWord;
        if((Alphabet2Manager.<>c.__il2cppRuntimeField_static_fields) == null)
        {
                throw new NullReferenceException();
        }
        
        if((Alphabet2Manager.<>c.<>9 + 24) <= val_39)
        {
                val_76 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_74 = Alphabet2Manager.<>c.<>9 + 16;
        val_74 = val_74 + (val_39 << 3);
        if(((Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_77 = mem[(Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40];
        val_77 = (Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40;
        int val_40 = this.currentCell;
        if(val_77 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40 + 24) <= val_40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_75 = (Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40 + 16;
        val_75 = val_75 + (val_40 << 3);
        val_76 = mem[((Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40 + 16 + (val_40) << 3) + 32];
        val_76 = ((Alphabet2Manager.<>c.<>9 + 16 + (val_39) << 3) + 32 + 40 + 16 + (val_40) << 3) + 32;
        if(val_76 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_41 = val_76.transform;
        val_75 = val_41;
        UnityEngine.GameObject val_42 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_78, parent:  val_75);
        this.currentAlphabetTileObject = val_42;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = mem[val_19 != true ? "regular" : "pet"];
        val_75 = (val_19 != true) ? "regular" : "pet";
        val_42.lastTileType = val_75;
        val_76 = this.currentAlphabetTileObject;
        if(val_76 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = public AlphabetTile UnityEngine.GameObject::GetComponent<AlphabetTile>();
        AlphabetTile val_44 = val_76.GetComponent<AlphabetTile>();
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = (~val_19) & 1;
        val_44.Init(showPet:  val_75);
        if(val_19 != true)
        {
                val_84 = this.OnPetAlphabetTileSpawned;
            if(val_84 != null)
        {
                val_75 = 0;
            val_84.Invoke();
            this.OnPetAlphabetTileSpawned = 0;
        }
        
        }
        
        if(val_84.inFTUX != false)
        {
                if(val_19 != false)
        {
                WordRegion val_46 = WordRegion.instance;
            if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            int val_47 = val_46.currentLineWord;
            if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            WordRegion val_48 = WordRegion.instance;
            if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
            int val_49 = val_48.currentLineWord;
            if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
            val_76 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_78 = this.currentCell;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_76 = mem[(((WordRegion.__il2cppRuntimeField_cctor_finished + (val_47) << 3) + (val_49) << 3) + 32 + 40 + 16 + (val_51) << 3) + 32];
            val_76 = (((WordRegion.__il2cppRuntimeField_cctor_finished + (val_47) << 3) + (val_49) << 3) + 32 + 40 + 16 + (val_51) << 3) + 32;
            UnityEngine.Coroutine val_54 = this.StartCoroutine(routine:  this.ShowTooltip(word:  (WordRegion.__il2cppRuntimeField_cctor_finished + (val_47) << 3) + 32, letterTransform:  val_76.transform));
        }
        
            this.FillCollectionBoxRandomly(lettersToCollect:  this.tilesPerCollectionBox - 1);
        }
        
        int val_56 = PlayingLevel.GetCurrentPlayerLevelNumber();
        val_56.lastLevelWithTile = val_56;
        val_56.collectedLastLevel = false;
        Rarity val_58 = this.GetRarity(letter:  val_56.currentCollectionLetter);
        if(val_58 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_58.lastLevelWithTileRarity = val_58.ToString();
        val_58.levelsLapsedSinceTileSpawned = 0;
        GameplayMode val_60 = PlayingLevel.CurrentGameplayMode;
        val_60.lastGameModeWithTile = val_60;
        val_86 = 0;
        if(val_60.lastGameModeWithTile == 4)
        {
                if((MonoSingleton<CategoryPacksManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_62.<CurrentCategoryPackInfo>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            string val_63 = val_62.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
            val_87 = val_63;
        }
        
        val_63.lastGameModeSecondayId = val_87;
        int val_64 = val_63.lastLevelWithTile;
        val_73 = val_64;
        int val_65 = val_64.minLevelsPerTile;
        int val_68 = UnityEngine.Random.Range(min:  val_65, max:  val_65.maxLevelsPerTile + 1);
        val_75 = val_68 + val_73;
        val_68.nextLevelWithTile = val_75;
        goto label_95;
        label_27:
        val_79 = 0;
        label_29:
        val_76 = this.currentAlphabetTileObject;
        if(val_76 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = public AlphabetTile UnityEngine.GameObject::GetComponent<AlphabetTile>();
        AlphabetTile val_69 = val_76.GetComponent<AlphabetTile>();
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75 = val_79 & 1;
        val_69.Init(showPet:  val_75);
        label_95:
        Player val_70 = App.Player;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        val_70.SaveState();
    }
    private System.Collections.IEnumerator ShowTooltip(LineWord word, UnityEngine.Transform letterTransform)
    {
        .<>1__state = 0;
        .word = word;
        .<>4__this = this;
        .letterTransform = letterTransform;
        return (System.Collections.IEnumerator)new Alphabet2Manager.<ShowTooltip>d__166();
    }
    private string PickNextCollectionLetter()
    {
        System.Collections.Generic.KeyValuePair<System.String, System.Single> val_4;
        var val_6;
        int val_17;
        System.Collections.Generic.Dictionary<System.String, System.Single> val_18;
        var val_19;
        System.Collections.Generic.List<T> val_20;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        RandomSet val_2 = null;
        val_17 = 0;
        val_2 = new RandomSet();
        val_18 = this.AlphabetLetterData;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_3 = val_18.GetEnumerator();
        goto label_6;
        label_11:
        Alphabet2Manager.<>c__DisplayClass167_0 val_7 = null;
        val_17 = 0;
        val_7 = new Alphabet2Manager.<>c__DisplayClass167_0();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .keyValuePair = val_4;
        val_17 = val_7.currentCollectionIndex;
        if(this.AlphabetCollections == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_9 = this.AlphabetCollections.Item[val_17];
        System.Predicate<System.String> val_10 = null;
        val_17 = val_7;
        val_10 = new System.Predicate<System.String>(object:  val_7, method:  System.Boolean Alphabet2Manager.<>c__DisplayClass167_0::<PickNextCollectionLetter>b__0(string x));
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_10;
        if((val_9.Exists(match:  val_10)) != false)
        {
                val_18 = 0;
            if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_2.add(item:  0, weight:  (float)UnityEngine.Mathf.RoundToInt(f:  S9 * 100f));
            val_1.Add(item:  (Alphabet2Manager.<>c__DisplayClass167_0)[1152921516026549280].keyValuePair);
        }
        
        label_6:
        if(val_6.MoveNext() == true)
        {
            goto label_11;
        }
        
        val_17 = public System.Void Dictionary.Enumerator<System.String, System.Single>::Dispose();
        val_6.Dispose();
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = "";
        if(mem[1152921516026537016] != 0)
        {
                val_18 = val_2;
            if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
            int val_15 = val_2.roll(unweighted:  false);
            val_20 = val_1;
            if(mem[1152921516026537016] <= val_15)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_20 = val_1;
        }
        
            var val_16 = mem[1152921516026537008];
            val_16 = val_16 + (val_15 << 3);
            val_19 = mem[(mem[1152921516026537008] + (val_15) << 3) + 32];
            val_19 = (mem[1152921516026537008] + (val_15) << 3) + 32;
            val_2.clear();
            return (string)val_19;
        }
        
        UnityEngine.Debug.LogWarning(message:  "No matching letters...");
        return (string)val_19;
    }
    private void OnPreprocessPlayerTurnAction(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        var val_10;
        if((System.String.IsNullOrEmpty(value:  this.currentCollectionLetter)) == true)
        {
                return;
        }
        
        if(this.IsCurrentLevelWithTile == false)
        {
                return;
        }
        
        int val_5 = WordRegion.instance.currentLineWord;
        if((val_5 & 2147483648) != 0)
        {
                return;
        }
        
        int val_6 = val_5.currentLineWord;
        bool val_7 = System.String.IsNullOrEmpty(value:  wordEntered);
        if(val_7 == true)
        {
                return;
        }
        
        int val_8 = val_7.currentLineWord;
        val_10 = val_8;
        if((X22 + 24) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = X22 + 16;
        val_10 = val_10 + (val_10 << 3);
        if(((X22 + 16 + (val_8) << 3) + 32 + 24.Equals(value:  wordEntered)) == false)
        {
                return;
        }
        
        mem2[0] = 1;
    }
    private void onWordRegionWordFound(string wordCompleted)
    {
        var val_10;
        if((System.String.IsNullOrEmpty(value:  this.currentCollectionLetter)) == true)
        {
                return;
        }
        
        bool val_3 = this.IsCurrentLevelWithTile;
        if(val_3 == false)
        {
                return;
        }
        
        int val_4 = val_3.currentLineWord;
        if((val_4 & 2147483648) != 0)
        {
                return;
        }
        
        val_10 = val_4.currentLineWord;
        WordRegion val_6 = WordRegion.instance;
        int val_8 = WordRegion.instance.currentLineWord;
        if((public System.Void System.Globalization.JapaneseCalendar::.ctor()) <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index);
        val_10 = val_10 + (val_8 << 3);
        if(((System.Void Dictionary.ValueCollection<System.Int32Enum, System.Collections.Generic.KeyValuePair<System.Object, System.Object>>::System.Collections.ICollection.CopyTo(System.Array array, int index) + + 32 + 24.Equals(value:  wordCompleted)) != false)
        {
                this.CollectCurrentLetter();
            return;
        }
        
        this.ShiftCurrentLetter();
    }
    private void onWordRegionHintUsed(UnityEngine.Vector3 location)
    {
        var val_12;
        System.Predicate<Cell> val_14;
        if((System.String.IsNullOrEmpty(value:  this.currentCollectionLetter)) == true)
        {
                return;
        }
        
        if(this.IsCurrentLevelWithTile == false)
        {
                return;
        }
        
        if(this.currentAlphabetTileObject == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_6 = this.currentAlphabetTileObject.transform.position;
        if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, rhs:  new UnityEngine.Vector3() {x = location.x, y = location.y, z = location.z})) == false)
        {
                return;
        }
        
        int val_9 = WordRegion.instance.currentLineWord;
        if((X21 + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_12 = X21 + 16;
        val_12 = val_12 + (val_9 << 3);
        val_12 = null;
        val_12 = null;
        val_14 = Alphabet2Manager.<>c.<>9__170_0;
        if(val_14 == null)
        {
                System.Predicate<Cell> val_10 = null;
            val_14 = val_10;
            val_10 = new System.Predicate<Cell>(object:  Alphabet2Manager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Alphabet2Manager.<>c::<onWordRegionHintUsed>b__170_0(Cell x));
            Alphabet2Manager.<>c.<>9__170_0 = val_14;
        }
        
        if(((X21 + 16 + (val_9) << 3) + 32 + 40.Exists(match:  val_10)) != false)
        {
                this.ShiftCurrentLetter();
            return;
        }
        
        this.CollectCurrentLetter();
    }
    private void CollectCurrentLetter()
    {
        System.Collections.Generic.List<System.String> val_1 = this.currentCollectionBox;
        val_1.Add(item:  val_1.currentCollectionLetter);
        if((this.IsCollectionBoxFull() != false) && (this.OnAlphabetCollectionCompleted != null))
        {
                this.OnAlphabetCollectionCompleted.Invoke();
        }
        
        if(this.OnAlphabetTileCollected != null)
        {
                this.OnAlphabetTileCollected.Invoke();
        }
        
        GameBehavior val_4 = App.getBehavior;
        int val_6 = PlayingLevel.GetCurrentPlayerLevelNumber();
        val_6.lastLevelWithTile = val_6;
        val_6.collectedLastLevel = true;
        Rarity val_8 = this.GetRarity(letter:  val_6.currentCollectionLetter);
        val_8.lastLevelWithTileRarity = val_8.ToString();
        val_8.lastTileType = "regular";
        val_8.currentCollectionLetter = "";
        App.Player.SaveState();
    }
    private void ShiftCurrentLetter()
    {
        object val_17 = this;
        WordRegion val_1 = WordRegion.instance;
    }
    private Alphabet2Manager.Rarity GetRarity(float rarityValue)
    {
        if(this.uncommonThreshold < 0)
        {
                return 0;
        }
        
        if(this.rareThreshold >= 0)
        {
                return (Rarity)(this.superThreshold < 0) ? 2 : 3;
        }
        
        return 1;
    }
    private decimal GetRewardByRarity(Alphabet2Manager.Rarity rarity)
    {
        var val_1;
        decimal val_2;
        var val_3;
        var val_4;
        val_1 = this;
        if(rarity <= 3)
        {
                var val_1 = 32560352 + (rarity) << 2;
            val_1 = val_1 + 32560352;
        }
        else
        {
                val_1 = 1152921504617017344;
            val_4 = null;
            val_4 = null;
            val_2 = 1152921504617021448;
            val_3 = 1152921504617021456;
            return new System.Decimal() {flags = -1699697600, hi = 268435458, lo = -1464142880, mid = 268435458};
        }
    
    }
    public Alphabet2Manager()
    {
        var val_7;
        this.tilesPerCollectionBox = 5;
        this.superThreshold = 0.5f;
        this.uncommonThreshold = 6f;
        this.rareThreshold = 2.2f;
        val_7 = null;
        val_7 = null;
        this.commonReward = System.Decimal.One;
        decimal val_1 = new System.Decimal(value:  3);
        this.uncommonReward = val_1.flags;
        decimal val_2 = new System.Decimal(value:  5);
        decimal val_3;
        this.rareReward = val_2.flags;
        val_3 = new System.Decimal(value:  15);
        this.superReward = val_3.flags;
        this.currentVideoRewardLetter = "";
        this.AlphabetCollections = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
        this.AlphabetLetterData = new System.Collections.Generic.Dictionary<System.String, System.Single>();
        this.OnTileClickAction = new System.Action(object:  0, method:  static System.Void Alphabet2Manager::onTileClicked());
    }
    private static Alphabet2Manager()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "en");
        val_1.Add(item:  "es");
        Alphabet2Manager.supportLangs = val_1;
    }
    private int <GetRandomSeededPositionsForCollection>b__147_0(string x)
    {
        return this.GetRarity(letter:  x);
    }
    private bool <ShiftCurrentLetter>b__172_0(Cell x)
    {
        Cell val_6;
        var val_7;
        val_6 = x;
        if(x.isShown != false)
        {
                val_7 = 0;
            return (bool)(val_6 > val_3.currentCell) ? 1 : 0;
        }
        
        int val_2 = WordRegion.instance.currentLineWord;
        if((X21 + 24) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = X21 + 16;
        val_6 = val_6 + (val_2 << 3);
        int val_3 = (X21 + 16 + (val_2) << 3) + 32 + 40.IndexOf(item:  val_6);
        val_6 = val_3;
        return (bool)(val_6 > val_3.currentCell) ? 1 : 0;
    }

}
