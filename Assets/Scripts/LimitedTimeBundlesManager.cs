using UnityEngine;
public class LimitedTimeBundlesManager : MonoSingleton<LimitedTimeBundlesManager>
{
    // Fields
    private const string pref_purchases = "ltb_purchases";
    private const string pref_popup_shown = "ltb_popup_lvl";
    public const string DICE_BUNDLE = "id_bundles6";
    public const string CAP = "sb_pc";
    public const string DISPLAY_EXTRA = "xtra";
    public const string TOTAL_VALUE = "total";
    private static string _LastBundlePurchase;
    private static int Interval;
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> _BundlesPackages;
    private static System.Collections.Generic.List<string> _BundlePackagesKeys;
    public static System.Collections.Generic.Dictionary<string, string> BundleLocKeys;
    public static System.Collections.Generic.Dictionary<string, string> BundleTitles;
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>> _BundlePurchaseCountsPerTimeFrame;
    private static System.Collections.Generic.List<LimitedTimeframe> LimitedTimeframes;
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<LimitedTimeframe>> BundleTimeframes;
    public LimitedTimeBundlesPackDisplayManager CurrentPackDisplay;
    private LimitedTimeBundlesHeader _prefab_limited_time_bundle_header;
    private LimitedTimeBundlePackDisplay _prefab_limited_time_bundle;
    private GameStoreCategory gameStoreCategory;
    private bool isLevelCompleteListenerAdded;
    private LimitedTimeBundlesStatus status;
    public System.Action OnStoreRefreshPackItems;
    
    // Properties
    public static string MEDIUM { get; }
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> BundlesPackages { get; }
    public static System.Collections.Generic.List<string> BundlePackagesKeys { get; }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>> BundlePurchaseCountsPerTimeFrame { get; }
    public LimitedTimeBundlesHeader prefab_limited_time_bundle_header { get; }
    public LimitedTimeBundlePackDisplay prefab_limited_time_bundle { get; }
    public LimitedTimeBundlesStatus Status { get; }
    
    // Methods
    public static string get_MEDIUM()
    {
        null = null;
        return (string)(App.game == 17) ? "trivia_star_bundle1" : "id_bundles5";
    }
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> get_BundlesPackages()
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_3;
        var val_4;
        var val_5;
        val_4 = null;
        val_4 = null;
        if(LimitedTimeBundlesManager._BundlesPackages == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = null;
            val_3 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>();
            val_5 = null;
            val_5 = null;
            LimitedTimeBundlesManager._BundlesPackages = val_3;
            LimitedTimeBundlesManager.PopulateBundlesPackages(key:  "id_bundles6", bundlesPackagesRef: ref  LimitedTimeBundlesManager._BundlesPackages);
            LimitedTimeBundlesManager.PopulateBundlesPackages(key:  LimitedTimeBundlesManager.MEDIUM, bundlesPackagesRef: ref  LimitedTimeBundlesManager._BundlesPackages);
            val_4 = null;
        }
        
        val_4 = null;
        return LimitedTimeBundlesManager._BundlesPackages;
    }
    private static void PopulateBundlesPackages(string key, ref System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> bundlesPackagesRef)
    {
        .key = key;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = PackagesManager.getDef.Find(match:  new System.Predicate<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LimitedTimeBundlesManager.<>c__DisplayClass13_0(), method:  System.Boolean LimitedTimeBundlesManager.<>c__DisplayClass13_0::<PopulateBundlesPackages>b__0(System.Collections.Generic.Dictionary<string, object> p)));
        if(val_4 == null)
        {
                return;
        }
        
        bundlesPackagesRef.Add(key:  (LimitedTimeBundlesManager.<>c__DisplayClass13_0)[1152921516517772784].key, value:  val_4);
    }
    public static System.Collections.Generic.List<string> get_BundlePackagesKeys()
    {
        var val_4 = null;
        if(LimitedTimeBundlesManager._BundlePackagesKeys == null)
        {
                val_4 = null;
            LimitedTimeBundlesManager._BundlePackagesKeys = System.Linq.Enumerable.ToList<System.String>(source:  LimitedTimeBundlesManager.BundlesPackages.Keys);
        }
        
        val_4 = null;
        return (System.Collections.Generic.List<System.String>)LimitedTimeBundlesManager._BundlePackagesKeys;
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>> get_BundlePurchaseCountsPerTimeFrame()
    {
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Int32>> val_3;
        var val_4 = null;
        if(LimitedTimeBundlesManager._BundlePurchaseCountsPerTimeFrame == null)
        {
                val_4 = null;
            val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Int32>>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "ltb_purchases", defaultValue:  "{}"));
            val_4 = null;
            LimitedTimeBundlesManager._BundlePurchaseCountsPerTimeFrame = val_3;
        }
        
        val_4 = null;
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Int32>>)LimitedTimeBundlesManager._BundlePurchaseCountsPerTimeFrame;
    }
    public LimitedTimeBundlesHeader get_prefab_limited_time_bundle_header()
    {
        LimitedTimeBundlesHeader val_3;
        if(this._prefab_limited_time_bundle_header == 0)
        {
                this._prefab_limited_time_bundle_header = PrefabLoader.LoadPrefab<LimitedTimeBundlesHeader>(featureName:  "Store");
            return val_3;
        }
        
        val_3 = this._prefab_limited_time_bundle_header;
        return val_3;
    }
    public LimitedTimeBundlePackDisplay get_prefab_limited_time_bundle()
    {
        LimitedTimeBundlePackDisplay val_3;
        if(this._prefab_limited_time_bundle == 0)
        {
                this._prefab_limited_time_bundle = PrefabLoader.LoadPrefab<LimitedTimeBundlePackDisplay>(featureName:  "Store");
            return val_3;
        }
        
        val_3 = this._prefab_limited_time_bundle;
        return val_3;
    }
    public LimitedTimeBundlesStatus get_Status()
    {
        LimitedTimeBundlesStatus val_2 = this.status;
        if(val_2 != null)
        {
                return val_2;
        }
        
        this.status = new LimitedTimeBundlesStatus();
        val_2 = this.status;
        return val_2;
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void LimitedTimeBundlesManager::Instance_OnSceneLoaded(SceneType obj)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Remove(source:  val_4.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void LimitedTimeBundlesManager::Instance_OnSceneUnloaded(SceneType obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_4.OnSceneUnloaded = val_6;
        return;
        label_8:
    }
    public override void InitMonoSingleton()
    {
        var val_11;
        var val_12;
        var val_13;
        this.InitMonoSingleton();
        val_11 = null;
        val_11 = null;
        LimitedTimeBundlesManager.Interval = App.getGameEcon;
        val_12 = null;
        val_12 = null;
        System.Delegate val_3 = System.Delegate.Combine(a:  GameStoreUI.OnCreatePackItems, b:  new System.Action(object:  this, method:  System.Void LimitedTimeBundlesManager::OnStoreCreatePackItems()));
        if(val_3 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        GameStoreUI.OnCreatePackItems = val_3;
        System.Delegate val_5 = System.Delegate.Combine(a:  GameStoreUI.OnRefreshDisplay, b:  new System.Action(object:  this, method:  System.Void LimitedTimeBundlesManager::OnStoreRefreshDisplay()));
        if(val_5 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_5;
        val_13 = null;
        val_13 = null;
        System.Delegate val_7 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void LimitedTimeBundlesManager::OnPurchaseCompleted(PurchaseModel purchased)));
        if(val_7 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_7;
        SceneDictator val_8 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_10 = System.Delegate.Combine(a:  val_8.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void LimitedTimeBundlesManager::Instance_OnSceneLoaded(SceneType obj)));
        if(val_10 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_8.OnSceneLoaded = val_10;
    }
    public static void DigestBundleKnobs(System.Collections.Generic.Dictionary<string, object> knobs)
    {
        var val_27;
        LimitedTimeframe val_28;
        string val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        val_27 = knobs;
        val_28 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        GameEcon val_3 = App.getGameEcon;
        int val_17 = val_3.ltb_unlockLevel;
        if((val_27.ContainsKey(key:  "lvls")) != false)
        {
                val_29 = 1152921504925962240;
            val_30 = null;
            val_30 = null;
            bool val_7 = System.Int32.TryParse(s:  val_27.Item["lvls"], result: out  1152921504925966344);
        }
        
        if((val_27.ContainsKey(key:  "m_bc")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_27.Item["m_bc"], result: out  10);
            LimitedTimeBundlesManager.BundlesPackages.Item[LimitedTimeBundlesManager.MEDIUM].set_Item(key:  "sb_pc", value:  10);
        }
        
        if((val_27.ContainsKey(key:  "ul")) != false)
        {
                bool val_18 = System.Int32.TryParse(s:  val_27.Item["ul"], result: out  val_17);
        }
        
        GameEcon val_19 = App.getGameEcon;
        val_28 = "sch";
        val_19.ltb_unlockLevel = val_17;
        if((val_27.ContainsKey(key:  "sch")) == false)
        {
                return;
        }
        
        System.Collections.Generic.List<LimitedTimeframe> val_21 = new System.Collections.Generic.List<LimitedTimeframe>();
        val_31 = null;
        val_31 = null;
        LimitedTimeBundlesManager.LimitedTimeframes = val_21;
        val_27 = val_27.Item["sch"];
        if(null < 1)
        {
                return;
        }
        
        var val_28 = 4;
        do
        {
            if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_32 = mem[System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 32];
            val_32 = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 32;
            val_33 = 0;
            val_34 = null;
            val_34 = null;
            val_29 = Item["du"];
            LimitedTimeframe val_26 = null;
            val_28 = val_26;
            val_26 = new LimitedTimeframe(date:  Item["d"], duration:  val_29);
            val_21.Add(item:  val_26);
            val_28 = val_28 + 1;
        }
        while((val_28 - 3) < null);
    
    }
    public static void DigestBundleKnobsV2(System.Collections.Generic.Dictionary<string, object> knobs)
    {
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<LimitedTimeframe>> val_29;
        string val_30;
        var val_31;
        var val_32;
        var val_34;
        var val_35;
        val_29 = knobs;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        val_30 = 1152921510222861648;
        if((val_29.ContainsKey(key:  "b_pul")) != false)
        {
                GameEcon val_4 = App.getGameEcon;
            bool val_6 = System.Int32.TryParse(s:  val_29.Item["b_pul"], result: out  val_4.LimitedTimeBundlesEcon.BundlePopupUnlockLevel);
        }
        
        if((val_29.ContainsKey(key:  "b_pil")) != false)
        {
                GameEcon val_9 = App.getGameEcon;
            bool val_11 = System.Int32.TryParse(s:  val_29.Item["b_pil"], result: out  val_9.LimitedTimeBundlesEcon.BundlePopupInterval);
        }
        
        val_31 = "sb_pc";
        if((val_29.ContainsKey(key:  "sb_pc")) != false)
        {
                GameEcon val_14 = App.getGameEcon;
            bool val_16 = System.Int32.TryParse(s:  val_29.Item["sb_pc"], result: out  val_14.LimitedTimeBundlesEcon.StarterBundlePurchaseCap);
            GameEcon val_20 = App.getGameEcon;
            LimitedTimeBundlesManager.BundlesPackages.Item[LimitedTimeBundlesManager.MEDIUM].set_Item(key:  "sb_pc", value:  val_20.LimitedTimeBundlesEcon.StarterBundlePurchaseCap);
        }
        
        if((val_29.ContainsKey(key:  "sch")) == false)
        {
                return;
        }
        
        System.Collections.Generic.List<LimitedTimeframe> val_22 = new System.Collections.Generic.List<LimitedTimeframe>();
        val_32 = null;
        val_32 = null;
        LimitedTimeBundlesManager.LimitedTimeframes = val_22;
        object val_23 = val_29.Item["sch"];
        if(null >= 1)
        {
                val_31 = 1152921504926654464;
            var val_30 = 4;
            val_30 = 0;
            if(val_30 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_30 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_30 = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["d"];
            val_34 = null;
            val_34 = null;
            val_22.Add(item:  new LimitedTimeframe(date:  val_30, duration:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["du"]));
            var val_27 = val_30 - 3;
            val_30 = val_30 + 1;
        }
        
        val_35 = null;
        val_35 = null;
        val_29 = LimitedTimeBundlesManager.BundleTimeframes;
        System.Collections.Generic.List<LimitedTimeframe> val_29 = EnumerableExtentions.GetOrDefault<System.String, System.Collections.Generic.List<LimitedTimeframe>>(dic:  val_29, key:  LimitedTimeBundlesManager.MEDIUM, defaultValue:  val_22);
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> GetAllBundles()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>)new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(dictionary:  LimitedTimeBundlesManager.BundlesPackages);
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> GetAvailableBundles()
    {
        System.Collections.Generic.List<LimitedTimeframe> val_18;
        var val_19;
        System.Collections.Generic.IDictionary<TKey, TValue> val_32;
        var val_33;
        var val_34;
        var val_36;
        System.Collections.Generic.List<LimitedTimeframe> val_37;
        val_32 = LimitedTimeBundlesManager.BundlesPackages;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(dictionary:  val_32);
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_7;
        }
        
        val_33 = 1152921504934535168;
        System.DateTime val_4 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeEnd();
        System.DateTime val_5 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeStart();
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = val_5.dateData});
        double val_7 = val_6._ticks.TotalDays;
        val_7 = (val_7 == Infinity) ? (-val_7) : (val_7);
        System.DateTime val_8 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeStart();
        System.DateTime val_9 = val_8.dateData.ToLocalTime();
        LimitedTimeframe val_12 = null;
        val_32 = val_12;
        val_12 = new LimitedTimeframe(date:  val_9.dateData.ToString(), duration:  (int)val_7.ToString());
        System.Collections.Generic.List<LimitedTimeframe> val_13 = new System.Collections.Generic.List<LimitedTimeframe>();
        val_13.Add(item:  val_12);
        if((val_13.GetValidLimitedTimeframe(limitedTimeframes:  val_13)) != null)
        {
            goto label_17;
        }
        
        label_7:
        bool val_15 = val_2.Remove(key:  "id_bundles6");
        label_17:
        val_34 = null;
        val_34 = null;
        Dictionary.Enumerator<TKey, TValue> val_16 = LimitedTimeBundlesManager.BundleTimeframes.GetEnumerator();
        val_36 = 1152921516519673328;
        label_25:
        bool val_20 = val_19.MoveNext();
        if(val_20 == false)
        {
            goto label_22;
        }
        
        val_37 = val_18;
        if((val_20.GetValidLimitedTimeframe(limitedTimeframes:  val_37)) != null)
        {
            goto label_25;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_22 = val_2.Remove(key:  val_18);
        goto label_25;
        label_22:
        val_19.Dispose();
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_23 = this.GetCurrentBundlePurchaseCounts();
        if(val_23 == null)
        {
                return val_2;
        }
        
        if(val_23.Count < 1)
        {
                return val_2;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_25 = val_23.GetEnumerator();
        val_32 = 1152921515493400064;
        val_36 = 1152921516519683568;
        val_33 = "sb_pc";
        label_34:
        val_37 = public System.Boolean Dictionary.Enumerator<System.String, System.Int32>::MoveNext();
        if(val_19.MoveNext() == false)
        {
            goto label_28;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_2.ContainsKey(key:  val_18)) == false)
        {
            goto label_34;
        }
        
        val_37 = val_18;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_28 = val_2.Item[val_37];
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = "sb_pc";
        object val_29 = val_28.Item[val_37];
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.Parse(s:  val_29)) > val_18)
        {
            goto label_34;
        }
        
        bool val_31 = val_2.Remove(key:  val_18);
        goto label_34;
        label_28:
        val_19.Dispose();
        return val_2;
    }
    public bool HaveBundlesToShow()
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_1.<metaGameBehavior>k__BackingField.GetCurrentLimitedTimeframe()) == null)
        {
                return (bool)val_6;
        }
        
            var val_5 = (this.GetAvailableBundles().Count > 0) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public bool ShouldShowBundlesPopup()
    {
        var val_22;
        var val_23;
        val_22 = this;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        GameEcon val_3 = App.getGameEcon;
        if(App.Player <= val_3.LimitedTimeBundlesEcon.BundlePopupUnlockLevel)
        {
            goto label_31;
        }
        
        System.Collections.Generic.List<System.String> val_4 = LimitedTimeBundlesManager.BundlePackagesKeys;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((this.GetCurrentCountOfBundlePurchase(bundleId:  LimitedTimeBundlesManager.__il2cppRuntimeField_cctor_finished + 32)) > 0)
        {
            goto label_31;
        }
        
        LimitedTimeBundlesStatus val_6 = this.Status;
        GameEcon val_7 = App.getGameEcon;
        if((val_6.TimesPopupShown >= val_7.LimitedTimeBundlesEcon.BundlePopupMaxCapToShow) || (this.HaveBundlesToShow() == false))
        {
            goto label_31;
        }
        
        GameEcon val_10 = App.getGameEcon;
        int val_22 = val_10.LimitedTimeBundlesEcon.BundlePopupUnlockLevel;
        val_22 = val_22 + 1;
        if(App.Player != val_22)
        {
            goto label_29;
        }
        
        val_23 = 1;
        return (bool)val_23;
        label_5:
        if(this.HaveBundlesToShow() == false)
        {
            goto label_31;
        }
        
        GameBehavior val_12 = App.getBehavior;
        LimitedTimeBundlesStatus val_13 = this.Status;
        label_46:
        val_22 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_8B0;
        label_31:
        val_23 = 0;
        return (bool)val_23;
        label_29:
        GameBehavior val_19 = App.getBehavior;
        LimitedTimeBundlesStatus val_20 = this.Status;
        GameEcon val_21 = App.getGameEcon;
        goto label_46;
    }
    public int GetCurrentCountOfBundlePurchase(string bundleId)
    {
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_1 = this.GetCurrentBundlePurchaseCounts();
        if(val_1 == null)
        {
                return 0;
        }
        
        if(val_1.Count < 1)
        {
                return 0;
        }
        
        if((val_1.ContainsKey(key:  bundleId)) == false)
        {
                return 0;
        }
        
        return val_1.Item[bundleId];
    }
    public System.Collections.Generic.List<string> RerollLettersForLastBundlePurchase()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if((System.String.IsNullOrEmpty(value:  LimitedTimeBundlesManager._LastBundlePurchase)) != false)
        {
                UnityEngine.Debug.LogError(message:  "Couldn\'t re-roll letters for last bundle purchase. Last bundle purchase string is null or empty.");
            return 0;
        }
        
        val_3 = null;
        val_3 = null;
        return RollLetters(bundleID:  LimitedTimeBundlesManager._LastBundlePurchase);
    }
    private void Instance_OnSceneLoaded(SceneType obj)
    {
        if(obj != 2)
        {
                return;
        }
        
        if(MainController.instance == 0)
        {
                return;
        }
        
        MainController val_3 = MainController.instance;
        val_3.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void LimitedTimeBundlesManager::OnLevelComplete()));
        this.isLevelCompleteListenerAdded = true;
    }
    private void Instance_OnSceneUnloaded(SceneType obj)
    {
        if(this.isLevelCompleteListenerAdded == false)
        {
                return;
        }
        
        MainController val_1 = MainController.instance;
        val_1.onLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void LimitedTimeBundlesManager::OnLevelComplete()));
        this.isLevelCompleteListenerAdded = false;
    }
    public void OnLevelComplete()
    {
        LimitedTimeBundlesStatus val_1 = this.Status;
        int val_2 = val_1.LevelsSincePopupShown;
        val_2 = val_2 + 1;
        val_1.LevelsSincePopupShown = val_2;
    }
    private System.Collections.Generic.Dictionary<string, int> GetCurrentBundlePurchaseCounts()
    {
        string val_7;
        var val_8;
        LimitedTimeframe val_1 = this.GetCurrentLimitedTimeframe();
        if(val_1 == null)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Int32>)val_8;
        }
        
        val_7 = val_1.GetCurrentLimitedTimeframe();
        if((LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame.ContainsKey(key:  val_7)) != false)
        {
                System.Collections.Generic.Dictionary<System.String, System.Int32> val_6 = LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame.Item[val_7];
            return (System.Collections.Generic.Dictionary<System.String, System.Int32>)val_8;
        }
        
        val_8 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Int32>)val_8;
    }
    private void AddBundlePurchaseCountForTimeFrame(string bundleId)
    {
        LimitedTimeframe val_1 = this.GetCurrentLimitedTimeframe();
        if(val_1 == null)
        {
            goto label_1;
        }
        
        LimitedTimeframe val_2 = val_1.GetCurrentLimitedTimeframe();
        if((LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame.ContainsKey(key:  val_2)) == false)
        {
            goto label_6;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_6 = LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame.Item[val_2];
        if((val_6.ContainsKey(key:  bundleId)) == false)
        {
            goto label_11;
        }
        
        val_6.set_Item(key:  bundleId, value:  val_6.Item[bundleId] + 1);
        goto label_19;
        label_1:
        UnityEngine.Debug.LogError(message:  "Can\'t Add Bundle Purchase Count For Timeframe because Timeframe is null.");
        return;
        label_6:
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_11 = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        val_11.Add(key:  bundleId, value:  1);
        LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame.Add(key:  val_2, value:  val_11);
        goto label_19;
        label_11:
        val_6.Add(key:  bundleId, value:  1);
        label_19:
        UnityEngine.PlayerPrefs.SetString(key:  "ltb_purchases", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  LimitedTimeBundlesManager.BundlePurchaseCountsPerTimeFrame));
        bool val_14 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private LimitedTimeframe GetCurrentLimitedTimeframe()
    {
        var val_14;
        string val_15;
        var val_16;
        System.Func<LimitedTimeframe, System.Boolean> val_18;
        var val_19;
        val_14 = null;
        val_14 = null;
        System.Collections.Generic.List<LimitedTimeframe> val_1 = new System.Collections.Generic.List<LimitedTimeframe>(collection:  LimitedTimeBundlesManager.LimitedTimeframes);
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_7;
        }
        
        System.DateTime val_3 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeEnd();
        System.DateTime val_4 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeStart();
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = val_4.dateData});
        double val_6 = val_5._ticks.TotalDays;
        val_6 = (val_6 == Infinity) ? (-val_6) : (val_6);
        System.DateTime val_7 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetTimeStart();
        System.DateTime val_8 = val_7.dateData.ToLocalTime();
        val_15 = val_8.dateData.ToString();
        val_1.Add(item:  new LimitedTimeframe(date:  val_15, duration:  (int)val_6.ToString()));
        goto label_17;
        label_7:
        if(val_1 == null)
        {
            goto label_19;
        }
        
        label_17:
        if(null >= 1)
        {
                val_16 = null;
            val_16 = null;
            val_18 = LimitedTimeBundlesManager.<>c.<>9__52_0;
            if(val_18 == null)
        {
                System.Func<LimitedTimeframe, System.Boolean> val_12 = null;
            val_18 = val_12;
            val_12 = new System.Func<LimitedTimeframe, System.Boolean>(object:  LimitedTimeBundlesManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LimitedTimeBundlesManager.<>c::<GetCurrentLimitedTimeframe>b__52_0(LimitedTimeframe d));
            LimitedTimeBundlesManager.<>c.<>9__52_0 = val_18;
        }
        
            LimitedTimeframe val_13 = System.Linq.Enumerable.FirstOrDefault<LimitedTimeframe>(source:  val_1, predicate:  val_12);
            return (LimitedTimeframe)val_19;
        }
        
        label_19:
        val_19 = 0;
        return (LimitedTimeframe)val_19;
    }
    private LimitedTimeframe GetValidLimitedTimeframe(System.Collections.Generic.List<LimitedTimeframe> limitedTimeframes)
    {
        var val_3;
        System.Func<LimitedTimeframe, System.Boolean> val_5;
        var val_6;
        if((limitedTimeframes != null) && (true >= 1))
        {
                val_3 = null;
            val_3 = null;
            val_5 = LimitedTimeBundlesManager.<>c.<>9__53_0;
            if(val_5 == null)
        {
                System.Func<LimitedTimeframe, System.Boolean> val_1 = null;
            val_5 = val_1;
            val_1 = new System.Func<LimitedTimeframe, System.Boolean>(object:  LimitedTimeBundlesManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LimitedTimeBundlesManager.<>c::<GetValidLimitedTimeframe>b__53_0(LimitedTimeframe d));
            LimitedTimeBundlesManager.<>c.<>9__53_0 = val_5;
        }
        
            LimitedTimeframe val_2 = System.Linq.Enumerable.FirstOrDefault<LimitedTimeframe>(source:  limitedTimeframes, predicate:  val_1);
            return (LimitedTimeframe)val_6;
        }
        
        val_6 = 0;
        return (LimitedTimeframe)val_6;
    }
    public System.DateTime GetCurrentOfferEndTime()
    {
        LimitedTimeframe val_1 = this.GetCurrentLimitedTimeframe();
        return val_1.startDate.AddDays(value:  (double)val_1.durationDays);
    }
    public int GetHighestExtraDisplay()
    {
        var val_8;
        string val_9;
        var val_10;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = this.GetAvailableBundles();
        if((val_1.ContainsKey(key:  LimitedTimeBundlesManager.MEDIUM)) == false)
        {
            goto label_4;
        }
        
        val_8 = 1152921516518955056;
        val_9 = LimitedTimeBundlesManager.MEDIUM;
        goto label_7;
        label_4:
        if((val_1.ContainsKey(key:  "id_bundles6")) == false)
        {
            goto label_8;
        }
        
        val_9 = "id_bundles6";
        val_8 = 1152921516518955056;
        label_7:
        object val_7 = val_1.Item[val_9].Item["xtra"];
        return (int)val_10;
        label_8:
        val_10 = 0;
        return (int)val_10;
    }
    private void OnStoreCreatePackItems()
    {
        if(this.HaveBundlesToShow() == false)
        {
                return;
        }
        
        if(this.gameStoreCategory == 0)
        {
                this.gameStoreCategory = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  "bundles", showTitle:  false, siblingIndex:  0);
        }
        
        string val_9 = this.GetHighestExtraDisplay().ToString();
        System.DateTime val_10 = val_9.GetCurrentOfferEndTime();
        UnityEngine.Object.Instantiate<LimitedTimeBundlesHeader>(original:  this.prefab_limited_time_bundle_header, parent:  this.gameStoreCategory.XfmPackageContents).Setup(freeAmount:  val_9, endTime:  new System.DateTime() {dateData = val_10.dateData});
        this = this.gameStoreCategory.gameObject.AddComponent<LimitedTimeBundlesPackDisplayManager>();
        this.CreatePackItems(packItemContainer:  this.gameStoreCategory.XfmPackageContents, popupContainer:  0);
    }
    private void OnStoreRefreshDisplay()
    {
        if(this.CurrentPackDisplay == 0)
        {
                return;
        }
        
        this.CurrentPackDisplay.RefreshPackItems();
    }
    private void OnPurchaseCompleted(PurchaseModel purchased)
    {
        PurchaseModel val_10;
        var val_11;
        val_10 = purchased;
        .purchased = val_10;
        if((purchased.id.Contains(value:  "bundle")) == false)
        {
                return;
        }
        
        val_10 = this.CurrentPackDisplay;
        if(val_10 == 0)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = PackagesManager.getDef.Find(match:  new System.Predicate<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LimitedTimeBundlesManager.<>c__DisplayClass58_0(), method:  System.Boolean LimitedTimeBundlesManager.<>c__DisplayClass58_0::<OnPurchaseCompleted>b__0(System.Collections.Generic.Dictionary<string, object> p)));
        if(val_6 != null)
        {
                val_11 = null;
            val_11 = null;
            LimitedTimeBundlesManager._LastBundlePurchase = (LimitedTimeBundlesManager.<>c__DisplayClass58_0)[1152921516522353664].purchased.id;
            this.CurrentPackDisplay.PrepareBundlePurchaseSuccess(alphabetLettersPurchased:  RollLetters(bundleID:  (LimitedTimeBundlesManager.<>c__DisplayClass58_0)[1152921516522353664].purchased.id));
            object val_8 = val_6.Item["id"];
            val_8.AddBundlePurchaseCountForTimeFrame(bundleId:  val_8);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Could not find bundle for id " + (LimitedTimeBundlesManager.<>c__DisplayClass58_0)[1152921516522353664].purchased.id((LimitedTimeBundlesManager.<>c__DisplayClass58_0)[1152921516522353664].purchased.id) + " but it seems to be a bundle.");
    }
    private System.Collections.Generic.List<string> RollLetters(string bundleID)
    {
        System.Predicate<T> val_35;
        var val_36;
        string val_37;
        .bundleID = bundleID;
        System.Predicate<System.Collections.Generic.Dictionary<System.String, System.Object>> val_3 = null;
        val_35 = val_3;
        val_3 = new System.Predicate<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new LimitedTimeBundlesManager.<>c__DisplayClass59_0(), method:  System.Boolean LimitedTimeBundlesManager.<>c__DisplayClass59_0::<RollLetters>b__0(System.Collections.Generic.Dictionary<string, object> p));
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = PackagesManager.getDef.Find(match:  val_3);
        if(val_4 != null)
        {
                System.Collections.Generic.List<System.String> val_5 = null;
            val_36 = val_5;
            val_5 = new System.Collections.Generic.List<System.String>();
            if((val_4.ContainsKey(key:  0.ToString())) != false)
        {
                val_37 = 0.ToString();
            val_5.AddRange(collection:  MonoSingleton<Alphabet2Manager>.Instance.RollLettersForRarity(rarity:  0, count:  System.Int32.Parse(s:  val_4.Item[val_37])));
        }
        
            if((val_4.ContainsKey(key:  1.ToString())) != false)
        {
                val_37 = 1.ToString();
            val_5.AddRange(collection:  MonoSingleton<Alphabet2Manager>.Instance.RollLettersForRarity(rarity:  1, count:  System.Int32.Parse(s:  val_4.Item[val_37])));
        }
        
            if((val_4.ContainsKey(key:  2.ToString())) != false)
        {
                val_37 = 2.ToString();
            val_5.AddRange(collection:  MonoSingleton<Alphabet2Manager>.Instance.RollLettersForRarity(rarity:  2, count:  System.Int32.Parse(s:  val_4.Item[val_37])));
        }
        
            val_35 = 3;
            if((val_4.ContainsKey(key:  3.ToString())) == false)
        {
                return (System.Collections.Generic.List<System.String>)val_36;
        }
        
            val_35 = MonoSingleton<Alphabet2Manager>.Instance;
            val_37 = 3.ToString();
            val_5.AddRange(collection:  val_35.RollLettersForRarity(rarity:  3, count:  System.Int32.Parse(s:  val_4.Item[val_37])));
            return (System.Collections.Generic.List<System.String>)val_36;
        }
        
        UnityEngine.Debug.LogError(message:  "Could not find bundle for id " + (LimitedTimeBundlesManager.<>c__DisplayClass59_0)[1152921516522675584].bundleID((LimitedTimeBundlesManager.<>c__DisplayClass59_0)[1152921516522675584].bundleID) + " but it seems to be a bundle.");
        val_36 = 0;
        return (System.Collections.Generic.List<System.String>)val_36;
    }
    public LimitedTimeBundlesManager()
    {
    
    }
    private static LimitedTimeBundlesManager()
    {
        LimitedTimeBundlesManager._LastBundlePurchase = "";
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_1.Add(key:  "id_bundles5", value:  "starter_collector_bundle_upper");
        val_1.Add(key:  "id_bundles6", value:  "snl_bundle");
        val_1.Add(key:  "trivia_star_bundle1", value:  "starter_collector_bundle_upper");
        LimitedTimeBundlesManager.BundleLocKeys = val_1;
        System.Collections.Generic.Dictionary<System.String, System.String> val_2 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_2.Add(key:  "id_bundles5", value:  "STARTER BUNDLE");
        val_2.Add(key:  "id_bundles6", value:  "Snakes & Ladders Bundle");
        val_2.Add(key:  "trivia_star_bundle1", value:  "STARTER BUNDLE");
        LimitedTimeBundlesManager.BundleTitles = val_2;
        LimitedTimeBundlesManager.LimitedTimeframes = new System.Collections.Generic.List<LimitedTimeframe>();
        LimitedTimeBundlesManager.BundleTimeframes = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<LimitedTimeframe>>();
    }

}
