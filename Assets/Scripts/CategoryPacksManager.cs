using UnityEngine;
public class CategoryPacksManager : MonoSingleton<CategoryPacksManager>
{
    // Fields
    public const int TOTAL_CHAPTERS_PER_PACK = 5;
    public const int DEFAULT_LEVELS_PER_PACK = 100;
    private const int DEFAULT_PACK_LEVEL_WHEN_UNOWNED = -1;
    public const string EVENT_CHAPTER_COMPLETE = "Category Chapter Complete";
    public const string EVENT_PACK_COMPLETE = "Category Pack Complete";
    public const string EVENT_PROPERTY_CATEGORY_PACK = "Category Level Pack";
    private const string PREFKEY_PACKLVLSEQ = "catpak_paklvlseq";
    private const string PREFKEY_DISCOVEREDPACKS = "catpak_discovered";
    private const string PREFKEY_PACK_LVL_PROGRESS = "catpak_lvlprog_{0}";
    private const string PREFKEY_PACK_LVL_PROGRESS_EXTRAWORDS = "catpak_lvlprog_ew_{0}";
    private static bool featureEnabled;
    private static bool isPlaying;
    public static System.Collections.Generic.List<CategoryCompletionReward> RewardBundleEcon;
    private CategoryPackData packData;
    private System.Collections.Generic.Dictionary<int, CategoryPackWordBank> wordBankDict;
    private bool categoryLevelQueued;
    public System.Action<bool, int> OnPackPurchaseComplete;
    public System.Action OnNetworkFailed;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<int>> packLevelWordIndexSequence;
    private int packsDiscovered;
    private CategoryPackInfo <CurrentCategoryPackInfo>k__BackingField;
    private bool <IsChapterCompleted>k__BackingField;
    private int totalCompletedPacks;
    private int totalPurchasedPacks;
    private bool hasNewlyDiscoveredPacks;
    private int <PackNewlyPurchased>k__BackingField;
    private System.Action<bool> onPingResponse;
    
    // Properties
    private System.Collections.Generic.Dictionary<int, int> packLevelProgress { get; }
    public int RewardTargetPacks { get; set; }
    public int RewardCurrentPacks { get; set; }
    public static bool FeatureAvailable { get; set; }
    public static bool IsPlaying { get; }
    public CategoryPackInfo CurrentCategoryPackInfo { get; set; }
    public CategoryPackWordBank CurrentCategoryPackWordBank { get; }
    public bool IsChapterCompleted { get; set; }
    public bool IsCurrentLevelLastWithinChapter { get; }
    public int TotalCompletedPacks { get; }
    public int TotalPurchasedPacks { get; }
    public bool HasNewlyDiscoveredPacks { get; }
    public int PackNewlyPurchased { get; set; }
    public int PackNewlyCompleted { get; set; }
    public bool IsPackNewlyCompleted { get; }
    public CategoryPackData PackData { get; }
    public string LevelProgressPrefKey { get; }
    public string LevelExtraRequiredWordsProgressPrefKey { get; }
    
    // Methods
    private System.Collections.Generic.Dictionary<int, int> get_packLevelProgress()
    {
        Player val_1 = App.Player;
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)val_1.properties.cpPackProgress;
    }
    public int get_RewardTargetPacks()
    {
        Player val_1 = App.Player;
        return val_1.properties.CategoryRewardTargetPacks;
    }
    public void set_RewardTargetPacks(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.cpRewardTargetPacks = value;
    }
    public int get_RewardCurrentPacks()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.cpRewardCurrentPacks;
    }
    public void set_RewardCurrentPacks(int value)
    {
        Player val_1 = App.Player;
        val_1.properties.cpRewardCurrentPacks = value;
    }
    public static bool get_FeatureAvailable()
    {
        null = null;
        if(CategoryPacksManager.featureEnabled == false)
        {
                return false;
        }
        
        GameBehavior val_1 = App.getBehavior;
        return System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public static void set_FeatureAvailable(bool value)
    {
        null = null;
        CategoryPacksManager.featureEnabled = value;
    }
    public static bool get_IsPlaying()
    {
        var val_6;
        var val_7;
        val_6 = null;
        if(CategoryPacksManager.FeatureAvailable == false)
        {
                return false;
        }
        
        val_7 = null;
        val_7 = null;
        if(CategoryPacksManager.isPlaying == false)
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_550;
    }
    public CategoryPackInfo get_CurrentCategoryPackInfo()
    {
        return (CategoryPackInfo)this.<CurrentCategoryPackInfo>k__BackingField;
    }
    private void set_CurrentCategoryPackInfo(CategoryPackInfo value)
    {
        this.<CurrentCategoryPackInfo>k__BackingField = value;
    }
    public CategoryPackWordBank get_CurrentCategoryPackWordBank()
    {
        if((this.<CurrentCategoryPackInfo>k__BackingField) == null)
        {
                return 0;
        }
        
        return this.GetWordBank(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId);
    }
    public bool get_IsChapterCompleted()
    {
        return (bool)this.<IsChapterCompleted>k__BackingField;
    }
    private void set_IsChapterCompleted(bool value)
    {
        this.<IsChapterCompleted>k__BackingField = value;
    }
    public bool get_IsCurrentLevelLastWithinChapter()
    {
        if((this.<CurrentCategoryPackInfo>k__BackingField) == null)
        {
                return false;
        }
        
        int val_2 = (this.GetPackProgress(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId)) + 1;
        var val_3 = X10 >> 63;
        val_3 = (X10 >> 35) + val_3;
        return (bool)(0 > val_3) ? 1 : 0;
    }
    public int get_TotalCompletedPacks()
    {
        return (int)this.totalCompletedPacks;
    }
    public int get_TotalPurchasedPacks()
    {
        return (int)this.totalPurchasedPacks;
    }
    public bool get_HasNewlyDiscoveredPacks()
    {
        return (bool)this.hasNewlyDiscoveredPacks;
    }
    public int get_PackNewlyPurchased()
    {
        return (int)this.<PackNewlyPurchased>k__BackingField;
    }
    private void set_PackNewlyPurchased(int value)
    {
        this.<PackNewlyPurchased>k__BackingField = value;
    }
    public int get_PackNewlyCompleted()
    {
        return CPlayerPrefs.GetInt(key:  "cpcr", defaultValue:  0);
    }
    public void set_PackNewlyCompleted(int value)
    {
        CPlayerPrefs.SetInt(key:  "cpcr", val:  value);
    }
    public bool get_IsPackNewlyCompleted()
    {
        int val_1 = this.PackNewlyCompleted;
        val_1 = (val_1 >> 31) ^ 1;
        return (bool)val_1;
    }
    public CategoryPackData get_PackData()
    {
        return (CategoryPackData)this.packData;
    }
    public string get_LevelProgressPrefKey()
    {
        object val_2;
        if((this.<CurrentCategoryPackInfo>k__BackingField) != null)
        {
                val_2 = this.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
            return System.String.Format(format:  "catpak_lvlprog_{0}", arg0:  val_2 = "XX");
        }
        
        return System.String.Format(format:  "catpak_lvlprog_{0}", arg0:  val_2);
    }
    public string get_LevelExtraRequiredWordsProgressPrefKey()
    {
        object val_2;
        if((this.<CurrentCategoryPackInfo>k__BackingField) != null)
        {
                val_2 = this.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
            return System.String.Format(format:  "catpak_lvlprog_ew_{0}", arg0:  val_2 = "XX");
        }
        
        return System.String.Format(format:  "catpak_lvlprog_ew_{0}", arg0:  val_2);
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        var val_4 = null;
        if(mode == 1)
        {
                return;
        }
        
        if(CategoryPacksManager.IsPlaying == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        string val_3 = scene.m_Handle.name;
        if((val_2.<metaGameBehavior>k__BackingField) == 2)
        {
                this.<IsChapterCompleted>k__BackingField = false;
        }
        else
        {
                this.ExitMode();
        }
        
        this.RefreshHasNewlyDiscoveredPacks();
        this.categoryLevelQueued = false;
    }
    private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
    {
        GameBehavior val_1 = App.getBehavior;
        string val_2 = scene.m_Handle.name;
        if(((val_1.<metaGameBehavior>k__BackingField) == 2) && (this.categoryLevelQueued != true))
        {
                this.ExitMode();
        }
        
        this.RefreshHasNewlyDiscoveredPacks();
    }
    public void OnLevelComplete()
    {
        var val_13;
        int val_14;
        val_13 = null;
        if(CategoryPacksManager.IsPlaying == false)
        {
                return;
        }
        
        int val_6 = UnityEngine.Mathf.Min(a:  (this.GetPackProgress(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId)) + 1, b:  this.GetWordBank(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId).Size);
        EnumerableExtentions.SetOrAdd<System.Int32, System.Int32>(dic:  val_6.packLevelProgress, key:  this.<CurrentCategoryPackInfo>k__BackingField.packId, newValue:  val_6);
        this.RefreshTotalCompletedPacks();
        var val_9 = X10 >> 35;
        val_9 = val_9 + (X10 >> 63);
        this.<IsChapterCompleted>k__BackingField = (0 > val_9) ? 1 : 0;
        bool val_11 = this.IsPackCompleted(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId);
        if(val_11 != false)
        {
                val_14 = this.<CurrentCategoryPackInfo>k__BackingField.packId;
        }
        else
        {
                val_14 = 0;
        }
        
        val_11.PackNewlyCompleted = 0;
        this.categoryLevelQueued = true;
        App.Player.SaveState();
    }
    public override void InitMonoSingleton()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void CategoryPacksManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        UnityEngine.SceneManagement.SceneManager.add_sceneUnloaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void CategoryPacksManager::OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)));
    }
    private void Start()
    {
        this.Initialize();
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void CategoryPacksManager::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        UnityEngine.SceneManagement.SceneManager.remove_sceneUnloaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void CategoryPacksManager::OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)));
    }
    public void OpenAndPlayPack(int packId)
    {
        var val_4;
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_1.PlayingChallenge = false;
        this.<CurrentCategoryPackInfo>k__BackingField = val_1.GetPackInfo(packId:  packId);
        this.categoryLevelQueued = true;
        val_4 = null;
        val_4 = null;
        CategoryPacksManager.isPlaying = true;
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void PurchasePack(int packToPurchase)
    {
        var val_6;
        decimal val_1 = this.GetPackUnlockCost(packId:  packToPurchase);
        Player val_2 = App.Player;
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid})) != false)
        {
                this.<PackNewlyPurchased>k__BackingField = packToPurchase;
            bool val_4 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, source:  "Category Level Pack", externalParams:  0, animated:  false);
            this.SetPackOwned(packId:  packToPurchase);
            App.Player.SaveState();
            val_6 = 1;
        }
        else
        {
                val_6 = 0;
            this.<PackNewlyPurchased>k__BackingField = 0;
        }
        
        if(this.OnPackPurchaseComplete == null)
        {
                return;
        }
        
        this.OnPackPurchaseComplete.Invoke(arg1:  false, arg2:  packToPurchase);
    }
    public bool IsPackNewlyDiscovered(int packId)
    {
        var val_7;
        if((this.IsPackOwned(packId:  packId)) != false)
        {
                if((MonoExtensions.IsBitSet(value:  this.packsDiscovered, bit:  packId)) != true)
        {
                this.SetPackDiscovered(packId:  packId);
        }
        
        }
        
        if((this.GetPackInfo(packId:  packId).IsAvailable) != false)
        {
                val_7 = (MonoExtensions.IsBitSet(value:  this.packsDiscovered, bit:  packId)) ^ 1;
            return (bool)val_7 & 1;
        }
        
        val_7 = 0;
        return (bool)val_7 & 1;
    }
    public void SetPackDiscovered(int packId)
    {
        int val_1 = MonoExtensions.SetBit(value:  this.packsDiscovered, bit:  packId);
        this.packsDiscovered = val_1;
        UnityEngine.PlayerPrefs.SetInt(key:  "catpak_discovered", value:  val_1);
    }
    public bool IsPackOwned(int packId)
    {
        var val_6;
        bool val_2 = this.packLevelProgress.ContainsKey(key:  packId);
        if(val_2 != false)
        {
                val_6 = (val_2.packLevelProgress.Item[packId] >> 31) ^ 1;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    private void SetPackOwned(int packId)
    {
        bool val_2 = this.packLevelProgress.ContainsKey(key:  packId);
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_3 = val_2.packLevelProgress;
        if(val_2 == false)
        {
            goto label_3;
        }
        
        int val_4 = val_3.Item[packId];
        if((val_4 & 2147483648) == 0)
        {
            goto label_6;
        }
        
        val_4.packLevelProgress.set_Item(key:  packId, value:  0);
        goto label_6;
        label_3:
        val_3.Add(key:  packId, value:  0);
        label_6:
        this.RefreshTotalPurchasedPacks();
    }
    public bool IsPackCompleted(int packId = -1)
    {
        int val_6;
        var val_7;
        val_6 = packId;
        if(packId == 1)
        {
                if((this.<CurrentCategoryPackInfo>k__BackingField) != null)
        {
                val_6 = this.<CurrentCategoryPackInfo>k__BackingField.packId;
        }
        else
        {
                val_6 = 0;
        }
        
        }
        
        if((this.IsPackOwned(packId:  0)) != false)
        {
                var val_5 = ((this.GetPackProgress(packId:  0)) >= (this.GetWordBank(packId:  0).Size)) ? 1 : 0;
            return (bool)val_7;
        }
        
        val_7 = 0;
        return (bool)val_7;
    }
    public decimal GetPackUnlockCost(int packId)
    {
        decimal val_3;
        int val_4;
        if((this.GetPackInfo(packId:  packId)) != null)
        {
                val_3 = val_1.cost;
            return new System.Decimal() {flags = val_3, hi = val_3, lo = val_4, mid = val_4};
        }
        
        decimal val_2 = new System.Decimal(value:  208);
        val_3 = val_2.flags;
        val_4 = val_2.lo;
        return new System.Decimal() {flags = val_3, hi = val_3, lo = val_4, mid = val_4};
    }
    public CategoryPackInfo GetPackInfo(int packId)
    {
        var val_3;
        .packId = packId;
        val_3 = null;
        val_3 = null;
        return CategoryPackData.packList.Find(match:  new System.Predicate<CategoryPackInfo>(object:  new CategoryPacksManager.<>c__DisplayClass83_0(), method:  System.Boolean CategoryPacksManager.<>c__DisplayClass83_0::<GetPackInfo>b__0(CategoryPackInfo x)));
    }
    public CategoryPackWordBank GetWordBank(int packId)
    {
        var val_3;
        if((this.wordBankDict.ContainsKey(key:  packId)) != false)
        {
                CategoryPackWordBank val_2 = this.wordBankDict.Item[packId];
            return (CategoryPackWordBank)val_3;
        }
        
        val_3 = 0;
        return (CategoryPackWordBank)val_3;
    }
    public CategoryColor GetColor(CategoryColorCode colorCode)
    {
        .colorCode = colorCode;
        return this.packData.colorList.Find(match:  new System.Predicate<CategoryColor>(object:  new CategoryPacksManager.<>c__DisplayClass85_0(), method:  System.Boolean CategoryPacksManager.<>c__DisplayClass85_0::<GetColor>b__0(CategoryColor x)));
    }
    public int GetPackProgress(int packId)
    {
        bool val_2 = this.packLevelProgress.ContainsKey(key:  packId);
        if(val_2 == false)
        {
                return 0;
        }
        
        return val_2.packLevelProgress.Item[packId];
    }
    public int CalculateChapterFromLevel(int playerLevel, bool ignoreRangeLimitClamp = False)
    {
        if(ignoreRangeLimitClamp == false)
        {
                return UnityEngine.Mathf.Clamp(value:  0, min:  0, max:  4);
        }
        
        return 0;
    }
    public int CalculateLevelFromChapter(int chapterId)
    {
        return UnityEngine.Mathf.Max(a:  (chapterId + (chapterId << 2)) << 2, b:  0);
    }
    public int GetCurrentChapterForPack(int packId = -1)
    {
        int val_1 = this.GetPackProgress(packId:  this.<CurrentCategoryPackInfo>k__BackingField.packId);
        return val_1.CalculateChapterFromLevel(playerLevel:  val_1, ignoreRangeLimitClamp:  false);
    }
    public string GetWordFromPack(int packId)
    {
        int val_13;
        var val_14;
        var val_15;
        val_13 = packId;
        val_14 = this;
        if((this.IsPackCompleted(packId:  val_13)) == true)
        {
            goto label_19;
        }
        
        CategoryPackWordBank val_2 = this.GetWordBank(packId:  val_13);
        if(val_2 == null)
        {
                return (string)val_15;
        }
        
        if(((this.packLevelWordIndexSequence.ContainsKey(key:  val_13)) == false) || (this.packLevelWordIndexSequence.Item[val_13] == null))
        {
            goto label_6;
        }
        
        System.Collections.Generic.List<System.Int32> val_5 = this.packLevelWordIndexSequence.Item[val_13];
        if(1152921516130948608 >= val_2.Size)
        {
            goto label_9;
        }
        
        label_6:
        System.Collections.Generic.List<System.Int32> val_7 = new System.Collections.Generic.List<System.Int32>();
        if(val_2.Size >= 1)
        {
                var val_13 = 0;
            do
        {
            val_7.Add(item:  0);
            val_13 = val_13 + 1;
        }
        while(val_13 < val_2.Size);
        
        }
        
        PluginExtension.Shuffle<System.Int32>(list:  val_7, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        EnumerableExtentions.SetOrAdd<System.Int32, System.Collections.Generic.List<System.Int32>>(dic:  this.packLevelWordIndexSequence, key:  val_13, newValue:  val_7);
        UnityEngine.PlayerPrefs.SetString(key:  "catpak_paklvlseq", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.packLevelWordIndexSequence));
        label_9:
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_14 = this.packLevelWordIndexSequence;
        val_14 = this.GetPackProgress(packId:  val_13);
        System.Collections.Generic.List<System.Int32> val_12 = val_14.Item[val_13];
        if(val_14 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_14 = val_14 + (val_14 << 2);
        if(val_12 < val_14)
        {
                if(val_14 <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_14 = val_14 + ((val_12) << 3);
            return (string)val_15;
        }
        
        label_19:
        val_15 = 0;
        return (string)val_15;
    }
    public CategoryCompletionReward ResolveNewlyCompletedPack()
    {
        int val_13;
        var val_14;
        var val_15;
        int val_1 = this.PackNewlyCompleted;
        if((val_1 & 2147483648) != 0)
        {
            goto label_1;
        }
        
        int val_2 = val_1.RewardCurrentPacks;
        val_2.RewardCurrentPacks = val_2 + 1;
        val_13 = 0;
        val_2.PackNewlyCompleted = 0;
        int val_4 = val_2.RewardCurrentPacks;
        int val_5 = val_4.RewardTargetPacks;
        if(val_4 >= val_5)
        {
            goto label_2;
        }
        
        val_14 = 0;
        goto label_3;
        label_1:
        val_14 = 0;
        return (CategoryCompletionReward)val_14;
        label_2:
        val_5.RewardCurrentPacks = 0;
        GameEcon val_7 = App.getGameEcon;
        GameEcon val_8 = App.getGameEcon;
        int val_10 = UnityEngine.Mathf.Min(a:  val_7.categoryCompletionCountIncrease + val_5.RewardTargetPacks, b:  val_8.categoryCompletionGoalMax);
        val_10.RewardTargetPacks = val_10;
        val_15 = null;
        val_15 = null;
        val_13 = mem[CategoryPacksManager.RewardBundleEcon + 24];
        val_13 = CategoryPacksManager.RewardBundleEcon + 24;
        int val_11 = UnityEngine.Random.Range(min:  0, max:  val_13);
        if((CategoryPacksManager.RewardBundleEcon + 24) <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_13 = CategoryPacksManager.RewardBundleEcon + 16;
        val_13 = val_13 + (val_11 << 3);
        val_14 = mem[(CategoryPacksManager.RewardBundleEcon + 16 + (val_11) << 3) + 32];
        val_14 = (CategoryPacksManager.RewardBundleEcon + 16 + (val_11) << 3) + 32;
        label_3:
        Player val_12 = App.Player;
        return (CategoryCompletionReward)val_14;
    }
    public void CreditGoalReward(CategoryCompletionReward chosenReward)
    {
        int val_3;
        var val_4;
        var val_11;
        Dictionary.Enumerator<TKey, TValue> val_1 = chosenReward.rewards.GetEnumerator();
        label_22:
        val_11 = public System.Boolean Dictionary.Enumerator<GameEventRewardType, System.Decimal>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_3;
        }
        
        var val_11 = val_3;
        val_11 = val_11 - 1;
        if(val_11 > 3)
        {
            goto label_22;
        }
        
        var val_12 = 32560740 + ((val_3 - 1)) << 2;
        val_12 = val_12 + 32560740;
        goto (32560740 + ((val_3 - 1)) << 2 + 32560740);
        label_3:
        val_4.Dispose();
    }
    public void HACKSetPackLastLevelOfChapterProgress()
    {
        int val_1 = this.GetCurrentChapterForPack(packId:  0);
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_2 = val_1.packLevelProgress;
        EnumerableExtentions.SetOrAdd<System.Int32, System.Int32>(dic:  val_2, key:  this.<CurrentCategoryPackInfo>k__BackingField.packId, newValue:  (val_2.CalculateLevelFromChapter(chapterId:  val_1 + 1)) - 1);
        this.RefreshTotalCompletedPacks();
    }
    private void Initialize()
    {
        this.LoadDataIntoMemoryFromResources();
        this.LoadLocalPlayerPrefs();
        this.RefreshTotalCompletedPacks();
        this.RefreshTotalPurchasedPacks();
        this.RefreshHasNewlyDiscoveredPacks();
    }
    private void ExitMode()
    {
        null = null;
        CategoryPacksManager.isPlaying = false;
        this.<CurrentCategoryPackInfo>k__BackingField = 0;
    }
    private void RefreshTotalCompletedPacks()
    {
        var val_3;
        int val_4;
        int val_8;
        Dictionary.Enumerator<TKey, TValue> val_2 = this.packLevelProgress.GetEnumerator();
        val_8 = 0;
        goto label_2;
        label_3:
        val_8 = val_8 + (this.IsPackCompleted(packId:  val_4));
        label_2:
        if(val_3.MoveNext() == true)
        {
            goto label_3;
        }
        
        val_3.Dispose();
        this.totalCompletedPacks = val_8;
    }
    private void RefreshTotalPurchasedPacks()
    {
        var val_3;
        int val_4;
        int val_8;
        Dictionary.Enumerator<TKey, TValue> val_2 = this.packLevelProgress.GetEnumerator();
        val_8 = 0;
        goto label_2;
        label_3:
        val_8 = val_8 + (val_2.getEnumeratorRetType.IsPackOwned(packId:  val_4));
        label_2:
        if(val_3.MoveNext() == true)
        {
            goto label_3;
        }
        
        val_3.Dispose();
        this.totalPurchasedPacks = val_8;
    }
    private void RefreshHasNewlyDiscoveredPacks()
    {
        var val_2;
        System.Collections.Generic.List<CategoryPackInfo> val_3;
        bool val_4;
        var val_3 = 0;
        label_10:
        val_2 = null;
        val_2 = null;
        val_3 = CategoryPackData.packList;
        if(val_3 >= (CategoryPackData.packList + 24))
        {
            goto label_4;
        }
        
        val_3 = CategoryPackData.packList;
        if((CategoryPackData.packList + 24) <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_2 = CategoryPackData.packList + 16;
        val_2 = val_2 + 0;
        val_3 = val_3 + 1;
        if((this.IsPackNewlyDiscovered(packId:  (CategoryPackData.packList + 16 + 0) + 32 + 16)) == false)
        {
            goto label_10;
        }
        
        val_4 = 1;
        goto label_11;
        label_4:
        val_4 = false;
        label_11:
        this.hasNewlyDiscoveredPacks = val_4;
    }
    private void LoadDataIntoMemoryFromResources()
    {
        string val_29;
        System.Collections.Generic.Dictionary<System.Int32, CategoryPackWordBank> val_30;
        int val_31;
        var val_32;
        System.Collections.Generic.Dictionary<System.Int32, CategoryPackWordBank> val_33;
        var val_34;
        CategoryPackWordBank val_35;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                string val_3 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.PathToGameResources;
        }
        
        string val_6 = MonoSingletonSelfGenerating<WADataParser>.Instance.PathToGameResources(MonoSingletonSelfGenerating<WADataParser>.Instance.PathToGameResources) + "CategoryPacks/"("CategoryPacks/");
        val_29 = "categories_packwords";
        UnityEngine.TextAsset[] val_7 = val_6.LoadAssetsFromFolder(path:  val_6);
        val_30 = this.wordBankDict;
        if(val_30 == null)
        {
                System.Collections.Generic.Dictionary<System.Int32, CategoryPackWordBank> val_8 = null;
            val_30 = val_8;
            val_8 = new System.Collections.Generic.Dictionary<System.Int32, CategoryPackWordBank>();
            this.wordBankDict = val_30;
        }
        
        val_8.Clear();
        if(val_7 == null)
        {
                return;
        }
        
        val_31 = val_7.Length;
        if(val_31 == 0)
        {
                return;
        }
        
        if(val_31 < 1)
        {
            goto label_17;
        }
        
        val_32 = 0;
        label_22:
        if((1152921507192016768.name.Contains(value:  val_29)) == true)
        {
            goto label_21;
        }
        
        val_31 = val_7.Length;
        val_32 = val_32 + 1;
        if(val_32 < val_31)
        {
            goto label_22;
        }
        
        label_17:
        val_32 = 0;
        goto label_23;
        label_21:
        val_31 = val_7.Length;
        label_23:
        char[] val_13 = new char[1];
        val_13[0] = '
        ';
        System.String[] val_14 = val_7[val_32].text.Replace(oldValue:  "\r", newValue:  "").Split(separator:  val_13);
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_15 = null;
        val_29 = val_15;
        val_15 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        char[] val_16 = new char[1];
        val_16[0] = ',';
        int val_33 = val_17.Length;
        if(val_33 >= 2)
        {
                val_34 = 1152921516132348128;
            val_33 = val_33 & 4294967295;
            do
        {
            if((System.Int32.TryParse(s:  val_14[0].Split(separator:  val_16)[1], result: out  0)) != false)
        {
                val_33 = this.wordBankDict;
            CategoryPackWordBank val_20 = null;
            val_35 = val_20;
            val_20 = new CategoryPackWordBank();
            EnumerableExtentions.SetOrAdd<System.Int32, CategoryPackWordBank>(dic:  val_33, key:  0, newValue:  val_20);
            EnumerableExtentions.SetOrAdd<System.Int32, System.Int32>(dic:  val_15, key:  5 - 4, newValue:  0);
        }
        
            var val_23 = 5 + 1;
        }
        while((5 - 3) < (val_17.Length << ));
        
        }
        
        if((val_14 + 24) <= 2)
        {
                return;
        }
        
        do
        {
            System.String[] val_24 = val_14 + 16;
            char[] val_25 = new char[1];
            val_25[0] = ',';
            if(val_26.Length >= 2)
        {
                do
        {
            val_35 = (val_14 + 16) + 32.Split(separator:  val_25)[1].Trim().ToUpper();
            CategoryPackWordBank val_30 = this.wordBankDict.Item[val_15.Item[1]];
            val_30.allWordsList.Add(item:  val_35);
            val_33 = 1 + 1;
        }
        while(val_33 < val_26.Length);
        
        }
        
            val_34 = 2 + 1;
        }
        while(val_34 < (val_14 + 24));
    
    }
    private void LoadLocalPlayerPrefs()
    {
        this.packsDiscovered = UnityEngine.PlayerPrefs.GetInt(key:  "catpak_discovered", defaultValue:  0);
        this.packLevelWordIndexSequence = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "catpak_paklvlseq", defaultValue:  "{}"));
    }
    private UnityEngine.TextAsset[] LoadAssetsFromFolder(string path)
    {
        return UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  path);
    }
    private void WaitUntilNetwork(System.Action<bool> onResponse)
    {
        this.onPingResponse = onResponse;
        NetworkConnectivityPinger val_1 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPingDone, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void CategoryPacksManager::OnNetworkReponse(bool networkAvailable)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPingDone = val_3;
        MonoSingleton<NetworkConnectivityPinger>.Instance.PingGoogle();
        return;
        label_5:
    }
    private void OnNetworkReponse(bool networkAvailable)
    {
        NetworkConnectivityPinger val_1 = MonoSingleton<NetworkConnectivityPinger>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnPingDone, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void CategoryPacksManager::OnNetworkReponse(bool networkAvailable)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPingDone = val_3;
        this.onPingResponse.Invoke(obj:  networkAvailable);
        this.onPingResponse = 0;
        if(networkAvailable == true)
        {
                return;
        }
        
        if(this.OnNetworkFailed == null)
        {
                return;
        }
        
        this.OnNetworkFailed.Invoke();
        return;
        label_5:
    }
    public CategoryPacksManager()
    {
        this.packLevelWordIndexSequence = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>();
    }
    private static CategoryPacksManager()
    {
        var val_16;
        CategoryPacksManager.featureEnabled = true;
        CategoryPacksManager.isPlaying = false;
        System.Collections.Generic.List<CategoryCompletionReward> val_1 = new System.Collections.Generic.List<CategoryCompletionReward>();
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal> val_2 = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal>();
        decimal val_3 = new System.Decimal(value:  250);
        val_2.Add(key:  1, value:  new System.Decimal() {flags = val_3.flags, hi = val_3.flags, lo = val_3.lo, mid = val_3.lo});
        val_1.Add(item:  new CategoryCompletionReward(id:  "Bundle1", allRewards:  val_2));
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal> val_5 = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal>();
        decimal val_6 = new System.Decimal(value:  75);
        val_5.Add(key:  2, value:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        val_1.Add(item:  new CategoryCompletionReward(id:  "Bundle2", allRewards:  val_5));
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal> val_8 = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal>();
        decimal val_9 = new System.Decimal(value:  150);
        val_8.Add(key:  1, value:  new System.Decimal() {flags = val_9.flags, hi = val_9.flags, lo = val_9.lo, mid = val_9.lo});
        decimal val_10 = new System.Decimal(value:  50);
        val_8.Add(key:  2, value:  new System.Decimal() {flags = val_10.flags, hi = val_10.flags, lo = val_10.lo, mid = val_10.lo});
        val_1.Add(item:  new CategoryCompletionReward(id:  "Bundle3", allRewards:  val_8));
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal> val_12 = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal>();
        val_16 = null;
        val_16 = null;
        val_12.Add(key:  3, value:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        val_1.Add(item:  new CategoryCompletionReward(id:  "Bundle4", allRewards:  val_12));
        System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal> val_14 = new System.Collections.Generic.Dictionary<GameEventRewardType, System.Decimal>();
        val_14.Add(key:  4, value:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0});
        val_1.Add(item:  new CategoryCompletionReward(id:  "Bundle5", allRewards:  val_14));
        CategoryPacksManager.RewardBundleEcon = val_1;
    }

}
