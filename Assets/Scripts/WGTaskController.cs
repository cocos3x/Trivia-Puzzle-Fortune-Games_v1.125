using UnityEngine;
public class WGTaskController : MonoSingleton<WGTaskController>
{
    // Fields
    private System.Collections.Generic.Dictionary<string, int> unlockableFeatures;
    private int highestLevelRequiredTask;
    private System.Collections.Generic.List<string> seenTasks;
    private bool hasInit;
    
    // Properties
    private int unlockLevel { get; }
    public bool isRelevent { get; }
    
    // Methods
    private int get_unlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.newUserTaskUnlock;
    }
    public bool get_isRelevent()
    {
        var val_8;
        var val_9;
        var val_10;
        val_8 = this;
        if(this.hasInit != true)
        {
                val_9 = val_8;
            this.Init();
        }
        
        if(((this.unlockLevel & 2147483648) == 0) && (PlayingLevel.CurrentGameplayMode == 1))
        {
                Player val_3 = App.Player;
            if(val_3 >= val_3.unlockLevel)
        {
                if(App.Player < this.highestLevelRequiredTask)
        {
                var val_7 = (val_8 != this.unlockableFeatures.Count) ? 1 : 0;
            return (bool)val_10;
        }
        
        }
        
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    private void Start()
    {
        this.Init();
    }
    private void Init()
    {
        System.Collections.Generic.List<System.String> val_6;
        var val_7;
        if(this.hasInit == true)
        {
                return;
        }
        
        if((CPlayerPrefs.HasKey(key:  "seenTasks")) == false)
        {
            goto label_4;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "seenTasks", defaultValue:  "[]"));
        val_6 = 0;
        goto label_9;
        label_4:
        val_7 = this;
        val_6 = this.seenTasks;
        if(val_6 != null)
        {
            goto label_10;
        }
        
        goto label_12;
        label_9:
        val_7 = this;
        this.seenTasks = ;
        label_10:
        label_12:
        this.seenTasks = new System.Collections.Generic.List<System.String>();
        this.PopulateEventUnlocks();
        this.hasInit = true;
    }
    public string getNextUnlockableEvent()
    {
        System.Collections.Generic.IEnumerable<TSource> val_6;
        int val_7;
        var val_8;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_10;
        var val_12;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_14;
        val_6 = this;
        val_7 = System.String.alignConst;
        if(this.isRelevent == false)
        {
                return (string)val_7;
        }
        
        val_8 = null;
        val_8 = null;
        val_10 = WGTaskController.<>c.<>9__10_0;
        if(val_10 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_2 = null;
            val_10 = val_2;
            val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(object:  WGTaskController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGTaskController.<>c::<getNextUnlockableEvent>b__10_0(System.Collections.Generic.KeyValuePair<string, int> x));
            WGTaskController.<>c.<>9__10_0 = val_10;
        }
        
        val_12 = null;
        val_6 = System.Linq.Enumerable.OrderBy<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(source:  this.unlockableFeatures, keySelector:  val_2);
        val_12 = null;
        val_14 = WGTaskController.<>c.<>9__10_1;
        if(val_14 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean> val_4 = null;
            val_14 = val_4;
            val_4 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Boolean>(object:  WGTaskController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGTaskController.<>c::<getNextUnlockableEvent>b__10_1(System.Collections.Generic.KeyValuePair<string, int> x));
            WGTaskController.<>c.<>9__10_1 = val_14;
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_5 = System.Linq.Enumerable.FirstOrDefault<System.Collections.Generic.KeyValuePair<System.String, System.Int32>>(source:  val_6, predicate:  val_4);
        val_7 = val_5.Value;
        return (string)val_7;
    }
    public int getNextUnlockLevel()
    {
        string val_7;
        var val_8;
        goto label_0;
        label_12:
        this.PopulateEventUnlocks();
        val_7 = this.getNextUnlockableEvent();
        if((this.unlockableFeatures.ContainsKey(key:  val_7)) == false)
        {
            goto label_2;
        }
        
        val_8 = this.unlockableFeatures.Item[val_7];
        if(App.Player != val_8)
        {
                return (int)val_8;
        }
        
        this.seenTasks.Add(item:  val_7);
        val_7 = MiniJSON.Json.Serialize(obj:  this.seenTasks);
        CPlayerPrefs.SetString(key:  "seenTasks", val:  val_7);
        CPlayerPrefs.Save();
        label_0:
        if(this.isRelevent == true)
        {
            goto label_12;
        }
        
        label_2:
        val_8 = 0;
        return (int)val_8;
    }
    private void PopulateEventUnlocks()
    {
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_31;
        var val_32;
        var val_33;
        this.unlockableFeatures = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        val_31 = 1152921504765632512;
        if((MonoSingleton<WGDailyBonusManager>.Instance) != 0)
        {
                GameBehavior val_4 = App.getBehavior;
            if(((val_4.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                GameEcon val_5 = App.getGameEcon;
            this.unlockableFeatures.Add(key:  "Daily Bonus", value:  val_5.dbFtuxLevel);
        }
        
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                GameBehavior val_8 = App.getBehavior;
            if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                GameEcon val_9 = App.getGameEcon;
            this.unlockableFeatures.Add(key:  "Events", value:  val_9.events_unlockLevel);
        }
        
        }
        
        GameBehavior val_10 = App.getBehavior;
        if(((val_10.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                GameBehavior val_11 = App.getBehavior;
            this.unlockableFeatures.Add(key:  "Picker Hint", value:  val_11.<metaGameBehavior>k__BackingField);
        }
        
        val_32 = 1152921504893267968;
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                if((MonoSingletonSelfGenerating<WGChallengeController>.Instance.featureEnabled) != false)
        {
                WGChallengeController val_16 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
            this.unlockableFeatures.Add(key:  "Goals", value:  val_16._unlockLevel);
        }
        
        }
        
        if((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) != 0)
        {
                GameEcon val_19 = App.getGameEcon;
            this.unlockableFeatures.Add(key:  "Leagues", value:  val_19.leaguesUnlockLevel);
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance) != 0)
        {
                GameEcon val_22 = App.getGameEcon;
            if(val_22.ab_unlockLevel >= 1)
        {
                GameEcon val_23 = App.getGameEcon;
            this.unlockableFeatures.Add(key:  "Alphabet", value:  val_23.ab_unlockLevel);
        }
        
        }
        
        GameBehavior val_24 = App.getBehavior;
        if(((val_24.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((MonoSingleton<CategoryPacksManager>.Instance) != 0)
        {
                GameEcon val_27 = App.getGameEcon;
            this.unlockableFeatures.Add(key:  "Categories", value:  val_27.categoryUnlockLevel);
        }
        
        }
        
        if(this.unlockableFeatures.Count < 1)
        {
                return;
        }
        
        val_32 = 1152921504927133696;
        val_33 = null;
        val_33 = null;
        val_31 = WGTaskController.<>c.<>9__12_0;
        if(val_31 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32> val_29 = null;
            val_31 = val_29;
            val_29 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(object:  WGTaskController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WGTaskController.<>c::<PopulateEventUnlocks>b__12_0(System.Collections.Generic.KeyValuePair<string, int> x));
            WGTaskController.<>c.<>9__12_0 = val_31;
        }
        
        System.Collections.Generic.KeyValuePair<System.String, System.Int32> val_30 = MoreLinq.MaxBy<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>(source:  this.unlockableFeatures, selector:  val_29);
        this.highestLevelRequiredTask = val_31;
    }
    public WGTaskController()
    {
    
    }

}
