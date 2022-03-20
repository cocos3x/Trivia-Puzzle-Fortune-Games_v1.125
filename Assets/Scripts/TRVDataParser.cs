using UnityEngine;
public class TRVDataParser : MonoSingleton<TRVDataParser>
{
    // Fields
    public static string hackedAdjustCampaign;
    public static System.Collections.Generic.List<string> categoryNames;
    public static System.Collections.Generic.List<string> excludedCateogries;
    private static System.Collections.Generic.List<FeatureCategorySelectFunction> featureCategorySelectFunctions;
    private TRVSubCategoryDictionary currentCategories;
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> cachedSubCategories;
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> <getFinishedSubCategories>k__BackingField;
    private int lastUpdatedSubCategoryLevel;
    private bool <ForceUpdateSubCategories>k__BackingField;
    private System.Collections.Generic.List<string> hackCategories;
    private bool hasInit;
    private TRVPlayerPersistenceManager <playerPersistance>k__BackingField;
    private TRVSubCategoryData <currentSubCategoryData>k__BackingField;
    private TRVEcon.TRVCategoryEcon currentCategoryEcon;
    private static string desiredLocale;
    private string QAHACK_currentHackedLocale;
    private TRVSubCategoryData lastRetrievedSubCatData;
    
    // Properties
    private int ftuxLevelLimit { get; }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> getAllSubCategories { get; }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> getFinishedSubCategories { get; set; }
    public bool ForceUpdateSubCategories { get; set; }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> getAvailableSubCategories { get; }
    public System.Collections.Generic.List<string> HackCategories { get; }
    public TRVPlayerPersistenceManager playerPersistance { get; set; }
    public TRVSubCategoryData currentSubCategoryData { get; set; }
    public System.Collections.Generic.Dictionary<int, int[]> getQuizDifficultyOrders { get; }
    private int[] initialQuizLengthArray { get; }
    private int[] quizLengthArray { get; }
    public System.Collections.Generic.Dictionary<string, int> CategoryUnlockLevels { get; }
    public static string CurrentDesiredLocale { get; }
    public string QAHACK_getCurrentCagetoryEconLocale { get; }
    private static string currentPlatform { get; }
    public static string PathToGameResources { get; }
    
    // Methods
    public static void AddCategorySelectFunction(FeatureCategorySelectFunction newfunction)
    {
        var val_6;
        var val_7;
        System.Predicate<FeatureCategorySelectFunction> val_9;
        var val_11;
        var val_12;
        System.Func<FeatureCategorySelectFunction, System.Int32> val_14;
        var val_15;
        val_6 = null;
        val_6 = null;
        TRVDataParser.featureCategorySelectFunctions.Add(item:  newfunction);
        val_7 = null;
        val_7 = null;
        val_9 = TRVDataParser.<>c.<>9__4_0;
        if(val_9 == null)
        {
                System.Predicate<FeatureCategorySelectFunction> val_1 = null;
            val_9 = val_1;
            val_1 = new System.Predicate<FeatureCategorySelectFunction>(object:  TRVDataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVDataParser.<>c::<AddCategorySelectFunction>b__4_0(FeatureCategorySelectFunction p));
            TRVDataParser.<>c.<>9__4_0 = val_9;
        }
        
        int val_2 = TRVDataParser.featureCategorySelectFunctions.RemoveAll(match:  val_1);
        val_11 = null;
        val_11 = null;
        val_12 = null;
        val_12 = null;
        val_14 = TRVDataParser.<>c.<>9__4_1;
        if(val_14 == null)
        {
                System.Func<FeatureCategorySelectFunction, System.Int32> val_3 = null;
            val_14 = val_3;
            val_3 = new System.Func<FeatureCategorySelectFunction, System.Int32>(object:  TRVDataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVDataParser.<>c::<AddCategorySelectFunction>b__4_1(FeatureCategorySelectFunction p));
            TRVDataParser.<>c.<>9__4_1 = val_14;
        }
        
        val_15 = null;
        val_15 = null;
        TRVDataParser.featureCategorySelectFunctions = System.Linq.Enumerable.ToList<FeatureCategorySelectFunction>(source:  System.Linq.Enumerable.OrderBy<FeatureCategorySelectFunction, System.Int32>(source:  TRVDataParser.featureCategorySelectFunctions, keySelector:  val_3));
    }
    private int get_ftuxLevelLimit()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.veryEasyLevelLimit;
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> get_getAllSubCategories()
    {
        return this.currentCategories.GetSubCategories(currentLocale:  this.GetFormattedLangaugeAndLocale());
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> get_getFinishedSubCategories()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)this.<getFinishedSubCategories>k__BackingField;
    }
    private void set_getFinishedSubCategories(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> value)
    {
        this.<getFinishedSubCategories>k__BackingField = value;
    }
    public bool get_ForceUpdateSubCategories()
    {
        return (bool)this.<ForceUpdateSubCategories>k__BackingField;
    }
    public void set_ForceUpdateSubCategories(bool value)
    {
        this.<ForceUpdateSubCategories>k__BackingField = value;
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> get_getAvailableSubCategories()
    {
        string val_4;
        var val_5;
        var val_23;
        var val_24;
        System.Collections.Generic.IEnumerable<T> val_25;
        System.Collections.Generic.Dictionary<TKey, TValue> val_26;
        string val_27;
        Player val_1 = App.Player;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == this.lastUpdatedSubCategoryLevel)
        {
                if((this.<ForceUpdateSubCategories>k__BackingField) == false)
        {
            goto label_5;
        }
        
        }
        
        label_40:
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        val_23 = null;
        val_23 = null;
        if(TRVDataParser.categoryNames == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_3 = TRVDataParser.categoryNames.GetEnumerator();
        var val_23 = 0;
        label_25:
        if(val_5.MoveNext() == false)
        {
            goto label_9;
        }
        
        val_24 = null;
        val_24 = null;
        if(TRVDataParser.excludedCateogries == null)
        {
                throw new NullReferenceException();
        }
        
        if((TRVDataParser.excludedCateogries.Contains(item:  val_4)) == true)
        {
            goto label_25;
        }
        
        System.Collections.Generic.List<System.String> val_8 = null;
        val_25 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_8 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_9 = this.getAllSubCategories;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_11 = val_9.Item[val_4].GetEnumerator();
        label_21:
        if(val_5.MoveNext() == false)
        {
            goto label_16;
        }
        
        if((this.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = val_4;
        if((this.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  val_27)) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_13.isFinished == true)
        {
            goto label_21;
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Add(item:  val_27);
        goto label_21;
        label_16:
        val_27 = 0;
        val_23 = val_23 + 1;
        mem2[0] = 179;
        val_5.Dispose();
        if(val_27 != 0)
        {
            goto label_22;
        }
        
        if(val_23 != 1)
        {
                var val_14 = ((1152921517236792208 + ((0 + 1)) << 2) == 179) ? 1 : 0;
            val_14 = ((val_23 >= 0) ? 1 : 0) & val_14;
            val_23 = val_23 - val_14;
        }
        
        System.Collections.Generic.List<System.String> val_19 = null;
        val_25 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Where<System.String>(source:  val_8, predicate:  new System.Func<System.String, System.Boolean>(object:  this, method:  System.Boolean TRVDataParser::<get_getAvailableSubCategories>b__21_0(string x))));
        val_19 = new System.Collections.Generic.List<System.String>(collection:  val_25);
        val_26 = val_2;
        if(val_26 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(key:  val_4, value:  val_19);
        goto label_25;
        label_9:
        var val_20 = val_23 + 1;
        mem2[0] = 242;
        val_5.Dispose();
        this.cachedSubCategories = val_2;
        Player val_21 = App.Player;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        this.lastUpdatedSubCategoryLevel = val_21;
        this.<ForceUpdateSubCategories>k__BackingField = false;
        return val_2;
        label_5:
        if(this.cachedSubCategories == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.cachedSubCategories.Count < 1)
        {
            goto label_40;
        }
        
        return val_2;
        label_22:
        val_26 = X23;
        val_25 = 0;
        throw val_26;
    }
    public bool IsValidSubCategory(string cat)
    {
        string val_4;
        var val_5;
        string val_19;
        var val_20;
        System.Object[] val_21;
        System.Object[] val_24;
        string val_25;
        var val_26;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_1 = this.CategoryUnlockLevels;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.ContainsKey(key:  cat)) == false)
        {
            goto label_2;
        }
        
        val_19 = 1152921504957325312;
        val_20 = null;
        val_20 = null;
        if(TRVDataParser.categoryNames == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_3 = TRVDataParser.categoryNames.GetEnumerator();
        var val_21 = 0;
        label_27:
        if(val_5.MoveNext() == false)
        {
            goto label_6;
        }
        
        val_19 = val_4;
        if((System.String.op_Equality(a:  val_19, b:  "QOTD")) == true)
        {
            goto label_27;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_8 = this.getAllSubCategories;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8.ContainsKey(key:  val_19)) == true)
        {
            goto label_9;
        }
        
        object[] val_10 = new object[1];
        val_21 = val_10;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_19 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_10.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_21[0] = val_19;
        UnityEngine.Debug.LogErrorFormat(format:  "getAllSubCategories does not contain: {0}", args:  val_10);
        goto label_27;
        label_9:
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_11 = this.getAllSubCategories;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_13 = val_11.Item[val_19].GetEnumerator();
        label_20:
        if(val_5.MoveNext() == false)
        {
            goto label_19;
        }
        
        if((System.String.op_Equality(a:  cat, b:  val_4)) == false)
        {
            goto label_20;
        }
        
        val_21 = val_21 + 1;
        val_19 = 0;
        mem2[0] = 223;
        goto label_30;
        label_19:
        val_21 = val_21 + 1;
        val_19 = 0;
        mem2[0] = 173;
        label_30:
        val_5.Dispose();
        if(val_19 != 0)
        {
                throw val_19;
        }
        
        if(val_21 == 1)
        {
            goto label_27;
        }
        
        if((-254753904 + ((0 + 1)) << 2) == 173)
        {
            goto label_24;
        }
        
        if((-254753904 + ((0 + 1)) << 2) != 223)
        {
            goto label_27;
        }
        
        goto label_26;
        label_24:
        var val_20 = 0;
        val_20 = val_20 ^ (val_21 >> 31);
        var val_16 = val_21 + val_20;
        goto label_27;
        label_2:
        object[] val_17 = new object[1];
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_17;
        val_24[0] = cat;
        val_25 = "InValid SubCategory: Unlock Econ Not Contain {0}";
        goto label_37;
        label_6:
        val_19 = -254753904;
        val_21 = val_21 + 1;
        mem2[0] = 201;
        val_5.Dispose();
        val_26 = 1;
        if(val_21 != 1)
        {
                if((val_19 + ((0 + 1)) << 2) == 223)
        {
                return (bool)val_26 & 1;
        }
        
        }
        
        object[] val_18 = new object[1];
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_18;
        val_24[0] = cat;
        val_25 = "InValid SubCategory: getAllSubCategories Not Contain {0}";
        label_37:
        UnityEngine.Debug.LogErrorFormat(format:  val_25, args:  val_18);
        val_26 = 0;
        return (bool)val_26 & 1;
        label_26:
        val_5.Dispose();
        return (bool)val_26 & 1;
    }
    public System.Collections.Generic.List<string> get_HackCategories()
    {
        System.Collections.Generic.List<System.String> val_2 = this.hackCategories;
        if(val_2 != null)
        {
                return val_2;
        }
        
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        this.hackCategories = val_1;
        var val_2 = 0;
        label_4:
        val_1.Add(item:  "");
        val_2 = val_2 + 1;
        if(val_2 > 1)
        {
            goto label_3;
        }
        
        if(this.hackCategories != null)
        {
            goto label_4;
        }
        
        throw new NullReferenceException();
        label_3:
        val_2 = this.hackCategories;
        return val_2;
    }
    public TRVPlayerPersistenceManager get_playerPersistance()
    {
        return (TRVPlayerPersistenceManager)this.<playerPersistance>k__BackingField;
    }
    private void set_playerPersistance(TRVPlayerPersistenceManager value)
    {
        this.<playerPersistance>k__BackingField = value;
    }
    public TRVSubCategoryData get_currentSubCategoryData()
    {
        return (TRVSubCategoryData)this.<currentSubCategoryData>k__BackingField;
    }
    private void set_currentSubCategoryData(TRVSubCategoryData value)
    {
        this.<currentSubCategoryData>k__BackingField = value;
    }
    public System.Collections.Generic.Dictionary<int, int[]> get_getQuizDifficultyOrders()
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_5;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        if(App.Player > val_2.ftux2LevelLimit)
        {
                TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
            val_5 = val_3.quizDifficultyOrders;
            return (System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>)val_4.FTUX2quizDifficultyOrders.SyncRoot;
        }
        
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        val_5 = val_4.FTUX2quizDifficultyOrders;
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>)val_4.FTUX2quizDifficultyOrders.SyncRoot;
    }
    private int[] get_initialQuizLengthArray()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (System.Int32[])val_1.initialQuizLength;
    }
    private int[] get_quizLengthArray()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (System.Int32[])val_1.quizLengthArray;
    }
    public override void InitMonoSingleton()
    {
        this.Init();
    }
    private void Init()
    {
        if(this.hasInit == true)
        {
                return;
        }
        
        this.LoadInitialCategoryData();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        this.hasInit = true;
    }
    private void Start()
    {
        this.<playerPersistance>k__BackingField = new TRVPlayerPersistenceManager(parser:  this);
    }
    private void OnLocalize()
    {
        GameBehavior val_1 = App.getBehavior;
        if((this.currentCategories.language.Equals(value:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                return;
        }
        
        this.<ForceUpdateSubCategories>k__BackingField = true;
        this.<playerPersistance>k__BackingField.LoadProgress();
    }
    private void LoadInitialCategoryData()
    {
        this.currentCategories = new TRVSubCategoryDictionary(currentLocale:  this.GetFormattedLangaugeAndLocale());
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> LoadCategoryInfo(string currentLanguage)
    {
        string val_3;
        var val_4;
        var val_15;
        UnityEngine.Object val_16;
        int val_17;
        int val_18;
        UnityEngine.Object val_19;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        val_15 = null;
        val_15 = null;
        List.Enumerator<T> val_2 = TRVDataParser.categoryNames.GetEnumerator();
        label_45:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        string[] val_6 = new string[8];
        string val_7 = TRVDataParser.PathToGameResources;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_7 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_17 = val_6.Length;
        if(val_17 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[0] = val_7;
        val_16 = "Levels/";
        val_17 = val_6.Length;
        if(val_17 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[1] = "Levels/";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_18 = val_6.Length;
        if(val_18 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[2] = "android";
        val_16 = "/";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_18 = val_6.Length;
        if(val_18 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[3] = "/";
        if(currentLanguage != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_18 = val_6.Length;
        }
        
        val_6[4] = currentLanguage;
        val_16 = "/";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_18 = val_6.Length;
        if(val_18 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[5] = "/";
        if(val_3 != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_18 = val_6.Length;
        }
        
        if(val_18 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[6] = val_3;
        val_16 = "/";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_18 = val_6.Length;
        if(val_18 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[7] = "/";
        T[] val_9 = UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  +val_6);
        if((val_9 == null) || (val_9.Length == 0))
        {
            goto label_45;
        }
        
        System.Collections.Generic.List<System.String> val_10 = null;
        val_19 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_10 = new System.Collections.Generic.List<System.String>();
        int val_15 = val_9.Length;
        if(val_15 >= 1)
        {
                var val_16 = 0;
            val_15 = val_15 & 4294967295;
            do
        {
            if(val_16 >= val_15)
        {
                throw new IndexOutOfRangeException();
        }
        
            val_16 = 1152921506201531664;
            val_19 = 0;
            if(val_16 != val_19)
        {
                if(null == null)
        {
                throw new NullReferenceException();
        }
        
            val_19 = 0;
            if((System.String.IsNullOrEmpty(value:  1152921506201531664.name)) != true)
        {
                val_19 = 1152921506201531664.name;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            val_16 = val_10;
            val_10.Add(item:  val_19);
        }
        
        }
        
            val_16 = val_16 + 1;
        }
        while(val_16 < (val_9.Length << ));
        
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_3, value:  val_10);
        goto label_45;
        label_4:
        val_4.Dispose();
        return val_1;
    }
    public TRVSubCategoryData LoadSubCategoryData(string subcategory, string primaryCategory = "")
    {
        string val_5;
        var val_6;
        string val_19;
        string val_20;
        string val_21;
        int val_23;
        int val_24;
        var val_25;
        val_19 = primaryCategory;
        val_20 = subcategory;
        if((System.String.op_Equality(a:  val_19, b:  "")) == false)
        {
            goto label_53;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = this.getAllSubCategories.Keys.GetEnumerator();
        label_7:
        if(val_6.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_21 = val_5;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_8 = this.getAllSubCategories;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_9 = val_8.Item[val_21];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_9.Contains(item:  val_20)) == false)
        {
            goto label_7;
        }
        
        goto label_8;
        label_4:
        val_21 = val_19;
        label_8:
        val_6.Dispose();
        val_19 = val_21;
        label_53:
        string[] val_11 = new string[9];
        val_23 = val_11.Length;
        val_11[0] = TRVDataParser.PathToGameResources;
        val_23 = val_11.Length;
        val_11[1] = "Levels/";
        val_24 = val_11.Length;
        val_11[2] = "android";
        val_24 = val_11.Length;
        val_11[3] = "/";
        if(this.currentCategories.language != null)
        {
                val_24 = val_11.Length;
        }
        
        val_11[4] = this.currentCategories.language;
        val_24 = val_11.Length;
        val_11[5] = "/";
        if(val_19 != null)
        {
                val_24 = val_11.Length;
        }
        
        val_11[6] = val_19;
        val_24 = val_11.Length;
        val_11[7] = "/";
        if(val_20 != null)
        {
                val_24 = val_11.Length;
        }
        
        val_11[8] = val_20;
        UnityEngine.TextAsset val_14 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  +val_11);
        if(val_14 == 0)
        {
                val_20 = "couldn\'t find data for " + val_19 + " " + val_20;
            UnityEngine.Debug.LogError(message:  val_20);
            val_25 = 0;
            return (TRVSubCategoryData)val_25;
        }
        
        TRVSubCategoryData val_17 = null;
        val_25 = val_17;
        val_17 = new TRVSubCategoryData(unparsedData:  val_14, subCategoryName:  val_20);
        return (TRVSubCategoryData)val_25;
    }
    public System.Collections.Generic.Dictionary<string, int> get_CategoryUnlockLevels()
    {
        var val_10;
        System.Collections.Generic.Dictionary<System.String, System.Int32> val_11;
        var val_12;
        val_10 = this;
        if(this.currentCategoryEcon != null)
        {
                if(this.currentCategoryEcon.categoryUnlockLevels.Count != 0)
        {
                if((this.currentCategoryEcon.locale.Equals(value:  this.GetFormattedLangaugeAndLocale())) == true)
        {
            goto label_6;
        }
        
        }
        
        }
        
        object[] val_4 = new object[1];
        val_4[0] = this.GetFormattedLangaugeAndLocale();
        UnityEngine.Debug.LogErrorFormat(format:  "Attempting to Parse Category Econ For: {0}", args:  val_4);
        this.LoadCategoryEconData(desiredLocale:  this.GetFormattedLangaugeAndLocale());
        label_6:
        if(this.currentCategoryEcon != null)
        {
                if(this.currentCategoryEcon.categoryUnlockLevels.Count != 0)
        {
                val_11 = this.currentCategoryEcon.categoryUnlockLevels;
            return (System.Collections.Generic.Dictionary<System.String, System.Int32>)val_11;
        }
        
        }
        
        object[] val_8 = new object[1];
        val_8[0] = this.GetFormattedLangaugeAndLocale();
        UnityEngine.Debug.LogErrorFormat(format:  "Could Not Parse Category Econ For: {0}", args:  val_8);
        val_10 = 1152921504957857792;
        val_12 = null;
        val_12 = null;
        val_11 = 1152921504957861904;
        return (System.Collections.Generic.Dictionary<System.String, System.Int32>)val_11;
    }
    private void LoadCategoryEconData(string desiredLocale)
    {
        int val_9;
        int val_10;
        string[] val_1 = new string[5];
        val_9 = val_1.Length;
        val_1[0] = TRVDataParser.PathToGameResources;
        val_9 = val_1.Length;
        val_1[1] = "Levels/";
        val_10 = val_1.Length;
        val_1[2] = "android";
        val_10 = val_1.Length;
        val_1[3] = "/CategoryEcons/";
        if(desiredLocale != null)
        {
                val_10 = val_1.Length;
        }
        
        val_1[4] = desiredLocale;
        UnityEngine.TextAsset val_4 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  +val_1);
        if(val_4 == 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  val_4.text)) == true)
        {
                return;
        }
        
        this.currentCategoryEcon = new TRVEcon.TRVCategoryEcon(categoryEconData:  val_4, localeName:  desiredLocale);
    }
    public static string get_CurrentDesiredLocale()
    {
        null = null;
        return (string)TRVDataParser.desiredLocale;
    }
    private string GetFormattedLangaugeAndLocale()
    {
        object val_15;
        string val_16;
        object val_17;
        var val_18;
        if((System.String.IsNullOrEmpty(value:  this.QAHACK_currentHackedLocale)) == false)
        {
            goto label_1;
        }
        
        if(Localization.GAME_NAME == 0)
        {
            goto label_5;
        }
        
        goto label_8;
        label_1:
        val_16 = this.QAHACK_currentHackedLocale;
        return val_16;
        label_5:
        val_15 = "en";
        label_8:
        string val_3 = DeviceProperties.LocaleFromDevice;
        if((val_3.Contains(value:  "-")) != false)
        {
                char[] val_5 = new char[1];
            val_5[0] = '-';
        }
        else
        {
                val_17 = "US";
        }
        
        val_16 = System.String.Format(format:  "{0}-{1}", arg0:  val_15, arg1:  val_17).ToLower();
        if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_16.Replace(oldValue:  "-", newValue:  "_"))) != true)
        {
                object[] val_12 = new object[1];
            val_12[0] = val_16;
            UnityEngine.Debug.LogErrorFormat(format:  "{0} Not A Supported Language/Locale!", args:  val_12);
            val_16 = mem[val_13 != true ? "es-419" : "en-us"];
            val_16 = ((val_16.StartsWith(value:  "es")) != true) ? "es-419" : "en-us";
        }
        
        val_18 = null;
        val_18 = null;
        TRVDataParser.desiredLocale = val_16;
        return val_16;
    }
    public string get_QAHACK_getCurrentCagetoryEconLocale()
    {
        return (string)(this.currentCategoryEcon == 0) ? "not set" : this.currentCategoryEcon.locale;
    }
    public void QAHACK_setCurrentCategoryEcon(string formattedLanguageAndLocale)
    {
        this.currentCategoryEcon = 0;
        this.QAHACK_currentHackedLocale = formattedLanguageAndLocale;
        object[] val_1 = new object[1];
        val_1[0] = this.QAHACK_currentHackedLocale;
        UnityEngine.Debug.LogErrorFormat(format:  "Attempting to Parse Category Econ For: {0}", args:  val_1);
        this.LoadCategoryEconData(desiredLocale:  this.QAHACK_currentHackedLocale);
    }
    private static string get_currentPlatform()
    {
        return "android";
    }
    public static string get_PathToGameResources()
    {
        return "game/"("game/") + WordApp.GamePathName + "/"("/");
    }
    public int GetQuizLength()
    {
        var val_5;
        System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Boolean> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = TRVDataParser.<>c.<>9__65_0;
        if(val_7 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Boolean> val_3 = null;
            val_7 = val_3;
            val_3 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Boolean>(object:  TRVDataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVDataParser.<>c::<GetQuizLength>b__65_0(System.Collections.Generic.KeyValuePair<int, int> x));
            TRVDataParser.<>c.<>9__65_0 = val_7;
        }
        
        System.Collections.Generic.KeyValuePair<System.Int32, System.Int32> val_4 = System.Linq.Enumerable.Last<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>>(source:  App.GetGameSpecificEcon<TRVEcon>().quizLength, predicate:  val_3);
        val_4.Value = val_4.Value >> 32;
        return (int)val_4.Value;
    }
    public QuestionData GetQuestionFromID(string category, string subCategory, string questionID)
    {
        TRVSubCategoryData val_9;
        var val_10;
        System.Func<System.Collections.Generic.List<QuestionData>, System.Collections.Generic.IEnumerable<QuestionData>> val_12;
        .questionID = questionID;
        if(this.lastRetrievedSubCatData != null)
        {
                if((System.String.op_Inequality(a:  this.lastRetrievedSubCatData.subCategory, b:  subCategory)) == false)
        {
            goto label_3;
        }
        
        }
        
        TRVSubCategoryData val_3 = this.LoadSubCategoryData(subcategory:  subCategory, primaryCategory:  "");
        this.lastRetrievedSubCatData = val_3;
        if(val_3 == null)
        {
                label_3:
            val_9 = this.lastRetrievedSubCatData;
        }
        
        val_10 = null;
        val_10 = null;
        val_12 = TRVDataParser.<>c.<>9__67_0;
        if(val_12 != null)
        {
                return System.Linq.Enumerable.FirstOrDefault<QuestionData>(source:  System.Linq.Enumerable.ToList<QuestionData>(source:  System.Linq.Enumerable.SelectMany<System.Collections.Generic.List<QuestionData>, QuestionData>(source:  this.lastRetrievedSubCatData.questionData.Values, selector:  System.Func<System.Collections.Generic.List<QuestionData>, System.Collections.Generic.IEnumerable<QuestionData>> val_5 = null)), predicate:  new System.Func<QuestionData, System.Boolean>(object:  new TRVDataParser.<>c__DisplayClass67_0(), method:  System.Boolean TRVDataParser.<>c__DisplayClass67_0::<GetQuestionFromID>b__1(QuestionData p)));
        }
        
        val_12 = val_5;
        val_5 = new System.Func<System.Collections.Generic.List<QuestionData>, System.Collections.Generic.IEnumerable<QuestionData>>(object:  TRVDataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.IEnumerable<QuestionData> TRVDataParser.<>c::<GetQuestionFromID>b__67_0(System.Collections.Generic.List<QuestionData> x));
        TRVDataParser.<>c.<>9__67_0 = val_12;
        return System.Linq.Enumerable.FirstOrDefault<QuestionData>(source:  System.Linq.Enumerable.ToList<QuestionData>(source:  System.Linq.Enumerable.SelectMany<System.Collections.Generic.List<QuestionData>, QuestionData>(source:  this.lastRetrievedSubCatData.questionData.Values, selector:  val_5)), predicate:  new System.Func<QuestionData, System.Boolean>(object:  new TRVDataParser.<>c__DisplayClass67_0(), method:  System.Boolean TRVDataParser.<>c__DisplayClass67_0::<GetQuestionFromID>b__1(QuestionData p)));
    }
    public UnityEngine.Sprite GetQuestionImageFromID(string subCategory, string questionID)
    {
        string val_12;
        string val_13;
        UnityEngine.Object val_14;
        val_12 = questionID;
        val_13 = subCategory;
        val_14 = MonoSingleton<TRVSpecialCategoriesManager>.Instance.GetQuestionImageFromID(subCategory:  val_13, questionID:  val_12);
        if(val_14 != 0)
        {
                return (UnityEngine.Sprite)val_14;
        }
        
        val_14 = 0;
        if((val_12.StartsWith(value:  "FTUXPIC")) == false)
        {
                return (UnityEngine.Sprite)val_14;
        }
        
        val_13 = MonoSingleton<TRVUtils>.Instance.GetEnglishIconNameForCategory(cat:  val_13);
        val_14 = UnityEngine.Resources.Load<UnityEngine.Sprite>(path:  System.String.Format(format:  "game/Trivia/UI/GameplayImages/{0}/{1}", arg0:  val_13, arg1:  val_12));
        if(val_14 != 0)
        {
                return (UnityEngine.Sprite)val_14;
        }
        
        object[] val_10 = new object[1];
        val_12 = System.String.Format(format:  "Trivia/UI/GameplayImages/{0}/{1}", arg0:  val_13, arg1:  val_12);
        val_10[0] = val_12;
        UnityEngine.Debug.LogErrorFormat(format:  "Could not find image: {0}", args:  val_10);
        return (UnityEngine.Sprite)val_14;
    }
    public ChestType GetChestType()
    {
        var val_11;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_11 = 0;
            return (ChestType)val_11;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) == 2)
        {
                val_11 = 1;
            return (ChestType)val_11;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if((val_3.<metaGameBehavior>k__BackingField) == 3)
        {
                val_11 = 2;
            return (ChestType)val_11;
        }
        
        RandomSet val_4 = new RandomSet();
        TRVEcon val_5 = App.GetGameSpecificEcon<TRVEcon>();
        val_4.add(item:  0, weight:  (float)val_5.chestWeights.Item[0]);
        TRVEcon val_7 = App.GetGameSpecificEcon<TRVEcon>();
        val_4.add(item:  1, weight:  (float)val_7.chestWeights.Item[1]);
        TRVEcon val_9 = App.GetGameSpecificEcon<TRVEcon>();
        val_4.add(item:  2, weight:  (float)val_9.chestWeights.Item[2]);
        return val_4.roll(unweighted:  false);
    }
    public System.Collections.Generic.List<string> GetNewCategories(System.Collections.Generic.List<string> currentlySelectedCategories)
    {
        string val_9;
        var val_10;
        System.Collections.Generic.List<T> val_26;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_27;
        var val_28;
        var val_29;
        var val_30;
        System.Collections.Generic.List<System.String> val_32;
        System.Collections.Generic.List<System.String> val_1 = null;
        val_26 = val_1;
        val_1 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>().FilterForAvailableCats(currentlySelectedCategories:  currentlySelectedCategories);
        if(val_3 == null)
        {
            goto label_1;
        }
        
        val_27 = val_3;
        int val_4 = val_3.Count;
        if(val_4 > 2)
        {
            goto label_2;
        }
        
        label_1:
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_5 = val_4.FilterForAvailableCats(currentlySelectedCategories:  0);
        val_27 = val_5;
        if(val_5 == null)
        {
            goto label_10;
        }
        
        label_2:
        val_28 = 1152921517236775296;
        if(val_27.Count < 1)
        {
            goto label_4;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_8 = val_27.Keys.GetEnumerator();
        val_26 = 1152921517239197984;
        val_29 = 1152921516945296096;
        val_30 = 0;
        goto label_6;
        label_8:
        if(val_27.Item[val_9] == null)
        {
                throw new NullReferenceException();
        }
        
        val_30 = val_9 + val_30;
        label_6:
        if(val_10.MoveNext() == true)
        {
            goto label_8;
        }
        
        val_10.Dispose();
        goto label_39;
        label_4:
        val_30 = 0;
        label_39:
        if(val_30 >= 3)
        {
                if(val_27.Count > 2)
        {
            goto label_11;
        }
        
        }
        
        label_10:
        this.<ForceUpdateSubCategories>k__BackingField = true;
        val_26 = this.getAvailableSubCategories;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_15 = null;
        val_27 = val_15;
        val_15 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>(dictionary:  val_26);
        label_11:
        System.Collections.Generic.List<System.String> val_17 = val_15.RollSelectedCateogries(availableCatData:  val_15);
        this.InsertFeatureCategories(selectedCategories: ref  val_17);
        val_32 = val_17;
        if((val_16 + 24) > 2)
        {
            goto label_36;
        }
        
        val_32.Clear();
        val_28 = 1152921504758390784;
        UnityEngine.Debug.LogError(message:  "somehow selected less than 3 categories, doing unweighted fallback calculation");
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_19 = val_15.Keys.GetEnumerator();
        string val_25 = val_9;
        val_29 = 1152921516945296096;
        label_22:
        if(val_10.MoveNext() == false)
        {
            goto label_18;
        }
        
        System.Collections.Generic.List<System.String> val_21 = val_15.Item[val_25];
        val_26 = val_21;
        if((val_21 == null) || (val_25 == 0))
        {
            goto label_20;
        }
        
        int val_22 = UnityEngine.Random.Range(min:  0, max:  val_25);
        if(val_25 <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_25 = val_25 + (val_22 << 3);
        val_32.Add(item:  (val_9 + (val_22) << 3) + 32);
        goto label_22;
        label_20:
        val_27 = "Broken cat detected with key of " + val_25;
        UnityEngine.Debug.LogError(message:  val_27);
        val_10.Dispose();
        val_32 = 0;
        return val_32;
        label_18:
        val_10.Dispose();
        label_36:
        TRVDataParser val_24 = MonoSingleton<TRVDataParser>.Instance;
        val_24.<playerPersistance>k__BackingField.getCurrentAvailableCategories = val_32;
        return val_32;
    }
    private void InsertFeatureCategories(ref System.Collections.Generic.List<string> selectedCategories)
    {
        System.Collections.Generic.List<System.String> val_15;
        var val_16;
        System.Collections.Generic.List<FeatureCategorySelectFunction> val_17;
        val_15 = 1152921517241790272;
        bool val_2 = System.String.IsNullOrEmpty(value:  this.GetAdjustCampaign());
        if(val_2 != false)
        {
                if((System.String.IsNullOrEmpty(value:  val_2.GetAdjustCampaign())) == true)
        {
            goto label_2;
        }
        
        }
        
        bool val_5 = CPlayerPrefs.GetBool(key:  "adjustCatSeen", defaultValue:  false);
        if(val_5 != false)
        {
                label_2:
            val_16 = null;
            val_16 = null;
            val_17 = TRVDataParser.featureCategorySelectFunctions;
            if(val_17 == null)
        {
                return;
        }
        
            val_16 = null;
            val_17 = TRVDataParser.featureCategorySelectFunctions;
            if((TRVDataParser.featureCategorySelectFunctions + 24) <= 0)
        {
                return;
        }
        
            val_16 = null;
            val_17 = TRVDataParser.featureCategorySelectFunctions;
            if((TRVDataParser.featureCategorySelectFunctions + 24) <= 0)
        {
                return;
        }
        
            val_17 = TRVDataParser.featureCategorySelectFunctions;
            if((TRVDataParser.featureCategorySelectFunctions + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            selectedCategories = TRVDataParser.featureCategorySelectFunctions + 16 + 32 + 24.Invoke(arg:  selectedCategories);
            return;
        }
        
        bool val_9 = selectedCategories.Contains(item:  this.TranslateAdjustCampaignToCategory(campaign:  val_5.GetAdjustCampaign()));
        if(val_9 != true)
        {
                if((System.String.IsNullOrEmpty(value:  this.TranslateAdjustCampaignToCategory(campaign:  val_9.GetAdjustCampaign()))) != true)
        {
                selectedCategories.RemoveAt(index:  0);
            val_15 = selectedCategories;
            val_15.Add(item:  this.TranslateAdjustCampaignToCategory(campaign:  selectedCategories.GetAdjustCampaign()));
        }
        
        }
        
        CPlayerPrefs.SetBool(key:  "adjustCatSeen", value:  true);
    }
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> FilterForAvailableCats(System.Collections.Generic.List<string> currentlySelectedCategories)
    {
        string val_6;
        var val_7;
        System.Collections.Generic.IEnumerable<T> val_33;
        int val_34;
        var val_38;
        var val_39;
        var val_41;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_5 = MonoSingleton<TRVDataParser>.Instance.getAvailableSubCategories.Keys.GetEnumerator();
        label_39:
        if(val_7.MoveNext() == false)
        {
            goto label_6;
        }
        
        TRVDataParser val_9 = MonoSingleton<TRVDataParser>.Instance;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_10 = val_9.getAvailableSubCategories;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_33 = val_10.Item[val_6];
        System.Collections.Generic.List<System.String> val_12 = new System.Collections.Generic.List<System.String>(collection:  val_33);
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = System.String.alignConst;
        if((val_12.Contains(item:  val_34)) != false)
        {
                val_34 = System.String.alignConst;
            bool val_14 = val_12.Remove(item:  val_34);
        }
        
        if(currentlySelectedCategories == 0)
        {
            goto label_31;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_15.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_33 = val_15.<playerPersistance>k__BackingField.omittedCategories;
        Player val_16 = App.Player;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_33 == null) || (val_16 != (val_17.<playerPersistance>k__BackingField.lastRerollLevel))) || ((val_17.<playerPersistance>k__BackingField.lastRerollLevel) < 1))
        {
            goto label_25;
        }
        
        List.Enumerator<T> val_18 = val_33.GetEnumerator();
        label_28:
        if(val_7.MoveNext() == false)
        {
            goto label_26;
        }
        
        if((val_12.Contains(item:  val_6)) == false)
        {
            goto label_28;
        }
        
        bool val_21 = val_12.Remove(item:  val_6);
        goto label_28;
        label_26:
        var val_32 = 0;
        val_33 = 0;
        val_32 = val_32 + 1;
        mem2[0] = 237;
        val_7.Dispose();
        if(val_33 != 0)
        {
                throw val_33;
        }
        
        var val_34 = val_32;
        if(val_34 == 1)
        {
            goto label_30;
        }
        
        if((-249767840 + ((0 + 1)) << 2) != 237)
        {
            goto label_31;
        }
        
        var val_33 = 0;
        val_33 = val_33 ^ (val_34 >> 31);
        val_34 = val_34 + val_33;
        if(val_1 != null)
        {
            goto label_32;
        }
        
        throw new NullReferenceException();
        label_30:
        label_31:
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_33 = val_22.<playerPersistance>k__BackingField;
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        val_33.getOmittedCateogries = new System.Collections.Generic.List<System.String>();
        label_25:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        label_32:
        val_1.Add(key:  val_6, value:  val_12);
        goto label_39;
        label_6:
        val_38 = 1;
        val_7.Dispose();
        if(val_38 == 1)
        {
            goto label_44;
        }
        
        var val_24 = (274 == 274) ? 1 : 0;
        val_24 = ((val_38 >= 0) ? 1 : 0) & val_24;
        val_24 = val_38 - val_24;
        val_24 = val_24 + 1;
        val_39 = (long)val_24;
        if(val_1 != null)
        {
            goto label_45;
        }
        
        goto label_48;
        label_44:
        val_39 = 0;
        if(val_1 == null)
        {
            goto label_48;
        }
        
        label_45:
        if(val_1.Count <= 2)
        {
            goto label_48;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_28 = val_1.Keys.GetEnumerator();
        val_38 = 0;
        goto label_50;
        label_52:
        if(val_1.Item[val_6] == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = 44427872;
        label_50:
        if(val_7.MoveNext() == true)
        {
            goto label_52;
        }
        
        val_7.Dispose();
        var val_31 = (val_38 > 2) ? (val_1) : 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)val_41;
        label_48:
        UnityEngine.Debug.LogError(message:  "didn\'t get at least 3 valid primary categories");
        val_41 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)val_41;
    }
    private System.Collections.Generic.List<string> RollSelectedCateogries(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> availableCatData)
    {
        int val_34;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        var val_35 = 0;
        label_58:
        if(App.Player <= TRVMainController.getRerollFTUXLEVEL)
        {
            goto label_6;
        }
        
        RandomSet val_4 = new RandomSet();
        System.Collections.Generic.List<System.String> val_6 = availableCatData.Item[2.ToString()];
        if(16926284 >= 1)
        {
                TRVEcon val_7 = App.GetGameSpecificEcon<TRVEcon>();
            val_4.add(item:  2, weight:  (float)val_7.primaryCategoryOdds.Item[2]);
        }
        
        System.Collections.Generic.List<System.String> val_10 = availableCatData.Item[1.ToString()];
        if(38161477 >= 1)
        {
                TRVEcon val_11 = App.GetGameSpecificEcon<TRVEcon>();
            val_4.add(item:  1, weight:  (float)val_11.primaryCategoryOdds.Item[1]);
        }
        
        System.Collections.Generic.List<System.String> val_14 = availableCatData.Item[0.ToString()];
        if(1179403647 < 1)
        {
            goto label_26;
        }
        
        TRVEcon val_15 = App.GetGameSpecificEcon<TRVEcon>();
        val_4.add(item:  0, weight:  (float)val_15.primaryCategoryOdds.Item[0]);
        goto label_32;
        label_6:
        System.Collections.Generic.List<System.Int32> val_17 = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.List<System.String> val_19 = availableCatData.Item[2.ToString()];
        if(16926284 >= 1)
        {
                val_17.Add(item:  2);
        }
        
        System.Collections.Generic.List<System.String> val_21 = availableCatData.Item[1.ToString()];
        if(38161477 >= 1)
        {
                val_17.Add(item:  1);
        }
        
        string val_22 = 0.ToString();
        var val_34 = 1179403647;
        System.Collections.Generic.List<System.String> val_23 = availableCatData.Item[val_22];
        if(val_34 >= 1)
        {
                val_17.Add(item:  0);
        }
        
        int val_24 = UnityEngine.Random.Range(min:  0, max:  val_22);
        if(1179403647 <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_34 = val_34 + (val_24 << 2);
        val_34 = mem[(1179403647 + (val_24) << 2) + 32];
        val_34 = (1179403647 + (val_24) << 2) + 32;
        goto label_49;
        label_26:
        label_32:
        val_34 = val_4.roll(unweighted:  false);
        label_49:
        System.Collections.Generic.List<System.String> val_27 = availableCatData.Item[val_34.ToString()];
        if((val_27.Contains(item:  System.String.alignConst)) != false)
        {
                bool val_29 = val_27.Remove(item:  System.String.alignConst);
        }
        
        int val_30 = UnityEngine.Random.Range(min:  0, max:  System.String.alignConst);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        bool val_33 = availableCatData.Item[val_34.ToString()].Remove(item:  (System.String.__il2cppRuntimeField_static_fields + (val_30) << 3) + 32);
        val_1.Add(item:  (System.String.__il2cppRuntimeField_static_fields + (val_30) << 3) + 32);
        val_35 = val_35 + 1;
        if(val_35 < 2)
        {
            goto label_58;
        }
        
        return val_1;
    }
    private string GetAdjustCampaign()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_4;
        }
        
        val_4 = 1152921504957325312;
        val_5 = null;
        val_5 = null;
        if((System.String.IsNullOrEmpty(value:  TRVDataParser.hackedAdjustCampaign)) == false)
        {
            goto label_7;
        }
        
        label_4:
        val_4 = 1152921504887410688;
        val_6 = null;
        val_6 = null;
        val_7 = 1152921504887414816;
        return (string)TRVDataParser.__il2cppRuntimeField_static_fields;
        label_7:
        val_8 = null;
        val_8 = null;
        return (string)TRVDataParser.__il2cppRuntimeField_static_fields;
    }
    private string GetAdjustAdGroup()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_4;
        }
        
        val_4 = 1152921504957325312;
        val_5 = null;
        val_5 = null;
        if((System.String.IsNullOrEmpty(value:  TRVDataParser.hackedAdjustCampaign)) == false)
        {
            goto label_7;
        }
        
        label_4:
        val_4 = 1152921504887410688;
        val_6 = null;
        val_6 = null;
        val_7 = 1152921504887414808;
        return (string)TRVDataParser.__il2cppRuntimeField_static_fields;
        label_7:
        val_8 = null;
        val_8 = null;
        return (string)TRVDataParser.__il2cppRuntimeField_static_fields;
    }
    private string TranslateAdjustCampaignToCategory(string campaign)
    {
        string val_9;
        var val_10;
        val_9 = campaign;
        if((System.String.IsNullOrEmpty(value:  val_9)) == true)
        {
            goto label_1;
        }
        
        bool val_3 = val_9.ToLower().Contains(value:  "popmusic_test");
        if(val_3 == true)
        {
            goto label_4;
        }
        
        label_1:
        string val_4 = val_3.GetAdjustAdGroup();
        if(((System.String.IsNullOrEmpty(value:  val_4)) == true) || ((val_4.Contains(value:  "popmusic_test")) == false))
        {
            goto label_7;
        }
        
        label_4:
        val_10 = "Pop Music";
        return (string)System.String.__il2cppRuntimeField_static_fields;
        label_7:
        if((System.String.IsNullOrEmpty(value:  val_9)) == true)
        {
                return (string)System.String.__il2cppRuntimeField_static_fields;
        }
        
        val_9 = "no category found for campaign of " + val_9;
        UnityEngine.Debug.LogWarning(message:  val_9);
        return (string)System.String.__il2cppRuntimeField_static_fields;
    }
    public string NextAvailableCategory()
    {
        return (string)System.String.alignConst;
    }
    public void UnlockCategoryEarly(string euCat)
    {
        this.<ForceUpdateSubCategories>k__BackingField = true;
        if((this.<playerPersistance>k__BackingField) != null)
        {
                this.<playerPersistance>k__BackingField.UnlockCategoryEarly(cat:  euCat);
            return;
        }
        
        throw new NullReferenceException();
    }
    public TRVDataParser()
    {
        this.cachedSubCategories = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        this.lastUpdatedSubCategoryLevel = 0;
        this.QAHACK_currentHackedLocale = "";
    }
    private static TRVDataParser()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "General");
        val_1.Add(item:  "Entertainment");
        val_1.Add(item:  "Sports");
        val_1.Add(item:  "QOTD");
        val_1.Add(item:  "SpecialCategories");
        TRVDataParser.categoryNames = val_1;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  "QOTD");
        val_2.Add(item:  "SpecialCategories");
        TRVDataParser.excludedCateogries = val_2;
        TRVDataParser.featureCategorySelectFunctions = new System.Collections.Generic.List<FeatureCategorySelectFunction>();
        TRVDataParser.desiredLocale = "";
    }
    private bool <get_getAvailableSubCategories>b__21_0(string x)
    {
        var val_6;
        if((this.CategoryUnlockLevels.ContainsKey(key:  x)) == false)
        {
            goto label_2;
        }
        
        if(App.Player >= this.CategoryUnlockLevels.Item[x])
        {
            goto label_7;
        }
        
        return this.<playerPersistance>k__BackingField._earlyUnlockedCategories.Contains(item:  x);
        label_2:
        val_6 = 0;
        return (bool)val_6;
        label_7:
        val_6 = 1;
        return (bool)val_6;
    }

}
