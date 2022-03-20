using UnityEngine;
public class FPHPortraitCollectionController : MonoSingleton<FPHPortraitCollectionController>
{
    // Fields
    private const string COLLECTION_ACTIVE_DATA = "collectionActive";
    private const string COLLECTION_INACTIVE_DATA = "collectionInActive";
    private FPHPortraitProgress progress;
    private System.Collections.Generic.Dictionary<string, int> inactiveCollectionProgress;
    
    // Properties
    public FPHPortraitProgress currentProgress { get; set; }
    private PortraitCollectionEcon myEcon { get; }
    
    // Methods
    public FPHPortraitProgress get_currentProgress()
    {
        return (FPHPortraitProgress)this.progress;
    }
    public void set_currentProgress(FPHPortraitProgress value)
    {
        this.progress = value;
    }
    private PortraitCollectionEcon get_myEcon()
    {
        WGPortraitDataController val_1 = MonoSingleton<WGPortraitDataController>.Instance;
        return (PortraitCollectionEcon)val_1.getEcon;
    }
    private void Start()
    {
        this.LoadPartialCollectionProgress();
        this.LoadProgress();
        System.Delegate val_2 = System.Delegate.Combine(a:  GoldenApplesManager.OnAppleAwarded, b:  new System.Action<System.Int32>(object:  this, method:  public System.Void FPHPortraitCollectionController::OnStarsGained(int stars)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        GoldenApplesManager.OnAppleAwarded = val_2;
        UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void FPHPortraitCollectionController::OnSceneChanged(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.Scene otherScene)));
        return;
        label_2:
    }
    private void OnSceneChanged(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.Scene otherScene)
    {
        this.CheckAndUpdateCollection();
    }
    private void LoadPartialCollectionProgress()
    {
        string val_1 = CPlayerPrefs.GetString(key:  "collectionInActive");
        if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
                if(this.inactiveCollectionProgress != null)
        {
                return;
        }
        
        }
        else
        {
                System.Collections.Generic.Dictionary<System.String, System.Int32> val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Int32>>(value:  val_1);
            this.inactiveCollectionProgress = val_3;
            if(val_3 != null)
        {
                return;
        }
        
        }
        
        this.inactiveCollectionProgress = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
    }
    private void LoadProgress()
    {
        string val_1 = CPlayerPrefs.GetString(key:  "collectionActive");
        if((System.String.IsNullOrEmpty(value:  val_1)) != true)
        {
                this.progress = Newtonsoft.Json.JsonConvert.DeserializeObject<FPHPortraitProgress>(value:  val_1);
        }
        
        if(this.IsEnabled() == false)
        {
                return;
        }
        
        if(this.progress != null)
        {
                this.CheckAndUpdateCollection();
            return;
        }
        
        this.SetupNewCollectionProgress();
    }
    private void CheckAndUpdateCollection()
    {
        if(this.progress != null)
        {
                System.DateTime val_1 = DateTimeCheat.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.progress.collectionStartTime});
            FPHEcon val_4 = App.GetGameSpecificEcon<FPHEcon>();
            if(val_2._ticks.TotalHours > (double)val_4.PortraitCollectionDurationHours)
        {
                this.progress = 0;
        }
        
        }
        
        if(this.IsEnabled() == false)
        {
                return;
        }
        
        if(this.progress != null)
        {
                System.DateTime val_6 = DateTimeCheat.UtcNow;
            System.TimeSpan val_7 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_6.dateData}, d2:  new System.DateTime() {dateData = this.progress.collectionStartTime});
            FPHEcon val_9 = App.GetGameSpecificEcon<FPHEcon>();
            if(val_7._ticks.TotalHours <= (double)val_9.PortraitCollectionDurationHours)
        {
                return;
        }
        
        }
        
        this.SetupNewCollectionProgress();
    }
    private void SaveProgress()
    {
        if(this.progress == null)
        {
                return;
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.Int32>(dic:  this.inactiveCollectionProgress, key:  this.progress.chosenCollection, newValue:  this.progress.starsCollected);
        CPlayerPrefs.SetString(key:  "collectionInActive", val:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.inactiveCollectionProgress));
        CPlayerPrefs.SetString(key:  "collectionActive", val:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.progress));
        CPlayerPrefs.Save();
    }
    private void SetupNewCollectionProgress()
    {
        System.Func<TSource, System.Boolean> val_16;
        var val_17;
        System.Collections.Generic.IEnumerable<T> val_18;
        System.Collections.Generic.List<System.String> val_3 = MonoSingleton<WGPortraitDataController>.Instance.GetFullyUnlockedCollections();
        .completedCollections = val_3;
        PortraitCollectionEcon val_4 = val_3.myEcon;
        if(W21 == val_4.MyCollections)
        {
                return;
        }
        
        System.Collections.Generic.List<CollectionEcon> val_5 = new System.Collections.Generic.List<CollectionEcon>();
        PortraitCollectionEcon val_7 = val_5.myEcon.myEcon;
        if(W23 == W24)
        {
                val_17 = 1152921516610870736;
            val_18 = val_7.MyCollections;
        }
        else
        {
                System.Func<CollectionEcon, System.Boolean> val_8 = null;
            val_16 = val_8;
            val_8 = new System.Func<CollectionEcon, System.Boolean>(object:  new FPHPortraitCollectionController.<>c__DisplayClass15_0(), method:  System.Boolean FPHPortraitCollectionController.<>c__DisplayClass15_0::<SetupNewCollectionProgress>b__0(CollectionEcon x));
            val_17 = 1152921516610870736;
            val_18 = System.Linq.Enumerable.Where<CollectionEcon>(source:  val_7.MyCollections, predicate:  val_8);
        }
        
        val_5.AddRange(collection:  val_18);
        int val_10 = UnityEngine.Random.Range(min:  0, max:  val_18);
        if(val_17 <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_17 = val_17 + (val_10 << 3);
        FPHPortraitProgress val_11 = new FPHPortraitProgress();
        System.DateTime val_13 = DateTimeCheat.UtcNow;
        .collectionStartTime = val_13;
        .chosenCollection = (val_17 + (val_10) << 3) + 32 + 16;
        if(this.inactiveCollectionProgress != null)
        {
                if((this.inactiveCollectionProgress.ContainsKey(key:  (val_17 + (val_10) << 3) + 32 + 16)) != false)
        {
                .starsCollected = this.inactiveCollectionProgress.Item[(FPHPortraitProgress)[1152921516611016848].chosenCollection];
        }
        
        }
        
        this.progress = new FPHPortraitProgress();
        this.SaveProgress();
    }
    public bool IsEnabled()
    {
        var val_7;
        Player val_1 = App.Player;
        FPHEcon val_2 = App.GetGameSpecificEcon<FPHEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1, knobValue:  val_2.portriatCollectionUnlockLevel)) != false)
        {
                PortraitCollectionEcon val_6 = MonoSingleton<WGPortraitDataController>.Instance.GetFullyUnlockedCollections().myEcon;
            if(val_1 == val_6.MyCollections)
        {
                if(this.progress == null)
        {
            goto label_15;
        }
        
        }
        
            val_7 = 1;
            return (bool)val_7;
        }
        
        label_15:
        val_7 = 0;
        return (bool)val_7;
    }
    public bool isEventActive()
    {
        this.CheckAndUpdateCollection();
        return (bool)(this.progress != 0) ? 1 : 0;
    }
    public int GetCollectionNextUnlockCost()
    {
        if(this.progress == null)
        {
                return 2147483647;
        }
        
        return this.GetCollectionNextUnlockCost(collection:  this.progress.chosenCollection);
    }
    public int GetCollectionNextUnlockCost(string collection)
    {
        System.Collections.Generic.List<System.String> val_2 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  collection);
        FPHEcon val_3 = App.GetGameSpecificEcon<FPHEcon>();
        if(collection >= val_3.starsPerPortrait.Length)
        {
            goto label_9;
        }
        
        FPHEcon val_4 = App.GetGameSpecificEcon<FPHEcon>();
        label_21:
        return (int)val_4.starsPerPortrait[collection];
        label_9:
        FPHEcon val_5 = App.GetGameSpecificEcon<FPHEcon>();
        FPHEcon val_6 = App.GetGameSpecificEcon<FPHEcon>();
        if((val_6.starsPerPortrait.Length - 1) < val_5.starsPerPortrait.Length)
        {
            goto label_21;
        }
        
        throw new IndexOutOfRangeException();
    }
    public int GetCollectionPreviousUnlockCost(string collection)
    {
        int val_5;
        System.Collections.Generic.List<System.String> val_2 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  collection);
        if(collection != null)
        {
                FPHEcon val_3 = App.GetGameSpecificEcon<FPHEcon>();
            val_5 = val_3.starsPerPortrait[collection - 1];
            return (int)val_5;
        }
        
        UnityEngine.Debug.LogError(message:  "trying to get the unlock cost of a portrait when we\'ve not unlocked any");
        val_5 = 0;
        return (int)val_5;
    }
    public int GetCollectionCurrentProgress(string collection)
    {
        if(this.inactiveCollectionProgress == null)
        {
                return 0;
        }
        
        if((this.inactiveCollectionProgress.ContainsKey(key:  collection)) == false)
        {
                return 0;
        }
        
        return this.inactiveCollectionProgress.Item[collection];
    }
    public string GetNextUnlockedPortrait(string collection)
    {
        .collection = collection;
        System.Collections.Generic.List<System.String> val_3 = MonoSingleton<WGPortraitDataController>.Instance.GetUnlockedPortraitsByCollection(collection:  (FPHPortraitCollectionController.<>c__DisplayClass22_0)[1152921516612503536].collection);
        if(W22 > val_4.starsPerPortrait.Length)
        {
                return (string)System.String.__il2cppRuntimeField_static_fields;
        }
        
        PortraitCollectionEcon val_5 = App.GetGameSpecificEcon<FPHEcon>().myEcon;
        if(((System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  val_5.MyCollections, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  new FPHPortraitCollectionController.<>c__DisplayClass22_0(), method:  System.Boolean FPHPortraitCollectionController.<>c__DisplayClass22_0::<GetNextUnlockedPortrait>b__0(CollectionEcon x)))) == null) || (W22 >= val_7.progressPortraits.Length))
        {
                return (string)System.String.__il2cppRuntimeField_static_fields;
        }
        
        return (string)System.String.__il2cppRuntimeField_static_fields;
    }
    public string GetNextUnlockedPortrait()
    {
        if(this.progress == null)
        {
                return (string)System.String.alignConst;
        }
        
        return this.GetNextUnlockedPortrait(collection:  this.progress.chosenCollection);
    }
    public string GetCollectionRewardPotrait(string collection)
    {
        int val_6;
        FPHPortraitCollectionController.<>c__DisplayClass24_0 val_1 = new FPHPortraitCollectionController.<>c__DisplayClass24_0();
        .collection = collection;
        PortraitCollectionEcon val_2 = val_1.myEcon;
        if((System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  val_2.MyCollections, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  val_1, method:  System.Boolean FPHPortraitCollectionController.<>c__DisplayClass24_0::<GetCollectionRewardPotrait>b__0(CollectionEcon x)))) != null)
        {
                string val_5 = System.Linq.Enumerable.Last<System.String>(source:  val_4.progressPortraits);
            return (string)val_6;
        }
        
        val_6 = System.String.alignConst;
        return (string)val_6;
    }
    public UnityEngine.Sprite GetCollectionBanner(string collection)
    {
        UnityEngine.Sprite val_5;
        FPHPortraitCollectionController.<>c__DisplayClass25_0 val_1 = new FPHPortraitCollectionController.<>c__DisplayClass25_0();
        .collection = collection;
        PortraitCollectionEcon val_2 = val_1.myEcon;
        if((System.Linq.Enumerable.FirstOrDefault<CollectionEcon>(source:  val_2.MyCollections, predicate:  new System.Func<CollectionEcon, System.Boolean>(object:  val_1, method:  System.Boolean FPHPortraitCollectionController.<>c__DisplayClass25_0::<GetCollectionBanner>b__0(CollectionEcon x)))) == null)
        {
                return val_5;
        }
        
        val_5 = val_4.banner;
        return val_5;
    }
    public void OnStarsGained(int stars)
    {
        var val_9;
        FPHPortraitProgress val_10;
        if(this.IsEnabled() == false)
        {
                return;
        }
        
        val_9 = this;
        this.CheckAndUpdateCollection();
        val_10 = this.progress;
        if(val_10 == null)
        {
                return;
        }
        
        if(this.progress.collectionCompleted != false)
        {
                return;
        }
        
        if(this.progress.hasStartedInstance != true)
        {
                this.progress.hasStartedInstance = true;
            val_10 = this.progress;
        }
        
        int val_9 = this.progress.starsCollected;
        val_9 = val_9 + stars;
        this.progress.starsCollected = val_9;
        int val_2 = this.GetCollectionNextUnlockCost(collection:  this.progress.chosenCollection);
        if(this.progress.starsCollected >= val_2)
        {
                this.progress.starsCollected = this.progress.starsCollected - (val_2.GetCollectionNextUnlockCost(collection:  this.progress.chosenCollection));
            this.progress.showUnlockedPortrait = true;
            MonoSingleton<WGPortraitDataController>.Instance.UnlockNextPortraitInCollection(collection:  this.progress.chosenCollection);
            bool val_7 = MonoSingleton<WGPortraitDataController>.Instance.IsCollectionFullyUnlocked(collection:  this.progress.chosenCollection);
            if(val_7 != false)
        {
                this.progress.collectionCompleted = true;
        }
        
        }
        
        int val_8 = val_7.GetCollectionNextUnlockCost(collection:  this.progress.chosenCollection);
        this.SaveProgress();
    }
    public System.TimeSpan GetTimeRemaining()
    {
        FPHPortraitProgress val_6;
        long val_7;
        this.CheckAndUpdateCollection();
        val_6 = this.progress;
        if(val_6 != null)
        {
                FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
            System.DateTime val_2 = this.progress.collectionStartTime.AddHours(value:  (double)val_1.PortraitCollectionDurationHours);
            val_6 = val_2.dateData;
            System.DateTime val_3 = DateTimeCheat.UtcNow;
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_6}, d2:  new System.DateTime() {dateData = val_3.dateData});
            return (System.TimeSpan)val_7;
        }
        
        System.TimeSpan val_5 = new System.TimeSpan(days:  0, hours:  0, minutes:  0, seconds:  0, milliseconds:  0);
        val_7 = val_5._ticks;
        return (System.TimeSpan)val_7;
    }
    public void OnProgressSeen()
    {
        if(this.progress != null)
        {
                this.progress.showUnlockedPortrait = false;
            this.SaveProgress();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void OnEventStartSeen()
    {
        if(this.progress != null)
        {
                this.progress.hasStartedInstance = true;
            this.SaveProgress();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnDestroy()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  GoldenApplesManager.OnAppleAwarded, value:  new System.Action<System.Int32>(object:  this, method:  public System.Void FPHPortraitCollectionController::OnStarsGained(int stars)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        GoldenApplesManager.OnAppleAwarded = val_2;
        UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void FPHPortraitCollectionController::OnSceneChanged(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.Scene otherScene)));
        return;
        label_2:
    }
    public FPHPortraitCollectionController()
    {
    
    }

}
