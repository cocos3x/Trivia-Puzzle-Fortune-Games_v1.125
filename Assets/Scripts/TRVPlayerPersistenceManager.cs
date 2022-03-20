using UnityEngine;
public class TRVPlayerPersistenceManager
{
    // Fields
    private const string triviaPersistanceKey = "triviaCatProgress";
    private const string triviaAvailCategoriesKey = "trivialAvailCategories";
    private const string currentAnsReqIndexKey = "carqI";
    private const string currentAnsReqProgKey = "cqrP";
    private const string lastFreeLifeUsedKey = "lflu";
    private const string lastLevelRerollKey = "llrr";
    private const string currentOmmittedCategoriesKey = "coc";
    private const string earlyUnlockedCatsKey = "euc";
    private const string totalSeenQuestionsKey = "tots";
    private const string totalCorrectQuestionsKey = "totc";
    private const string streakKey = "trvStreak";
    private const string extraFreeLivesKey = "efl";
    private System.Collections.Generic.Dictionary<string, TRVSubCategoryProgress> catProgress;
    private TRVDataParser myParser;
    private System.Collections.Generic.List<string> availableCategories;
    private System.Collections.Generic.List<string> omittedCategories;
    private System.Collections.Generic.List<string> _earlyUnlockedCategories;
    private int lastRerollLevel;
    public int currentAnswerRequrementIndex;
    public int currentAnswerRequrementProgress;
    private System.DateTime lastFreeLifeUsed;
    private int totalSeenQuestions;
    private int totalCorrectQuestions;
    private int <currentStreak>k__BackingField;
    private int <extraFreeLives>k__BackingField;
    
    // Properties
    public System.Collections.Generic.List<string> getCurrentAvailableCategories { get; set; }
    public System.Collections.Generic.List<string> getOmittedCateogries { get; set; }
    public System.Collections.Generic.List<string> earlyUnlockedCategories { get; }
    public int getLastRerollLevel { get; set; }
    public System.DateTime freeLifeAvailableAt { get; }
    private int freeLifeCoolDownMinutes { get; }
    public int freeLifeCooldown { get; }
    public bool freeLifeAvailable { get; }
    public int TotalSeenQuestions { get; set; }
    public int TotalCorrectQuestions { get; set; }
    public int currentStreak { get; set; }
    public int extraFreeLives { get; set; }
    
    // Methods
    public System.Collections.Generic.List<string> get_getCurrentAvailableCategories()
    {
        return (System.Collections.Generic.List<System.String>)this.availableCategories;
    }
    public void set_getCurrentAvailableCategories(System.Collections.Generic.List<string> value)
    {
        this.availableCategories = value;
        this.SaveProgress();
    }
    public System.Collections.Generic.List<string> get_getOmittedCateogries()
    {
        return (System.Collections.Generic.List<System.String>)this.omittedCategories;
    }
    public void set_getOmittedCateogries(System.Collections.Generic.List<string> value)
    {
        this.omittedCategories = value;
        this.SaveProgress();
    }
    public System.Collections.Generic.List<string> get_earlyUnlockedCategories()
    {
        return (System.Collections.Generic.List<System.String>)this._earlyUnlockedCategories;
    }
    public int get_getLastRerollLevel()
    {
        return (int)this.lastRerollLevel;
    }
    public void set_getLastRerollLevel(int value)
    {
        this.lastRerollLevel = value;
        this.SaveProgress();
    }
    public System.DateTime get_freeLifeAvailableAt()
    {
        return this.lastFreeLifeUsed.AddMinutes(value:  (double)this.freeLifeCoolDownMinutes);
    }
    private int get_freeLifeCoolDownMinutes()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (int)val_1.extraLifeCoolDown;
    }
    public int get_freeLifeCooldown()
    {
        return this.freeLifeCoolDownMinutes;
    }
    public bool get_freeLifeAvailable()
    {
        if((this.<extraFreeLives>k__BackingField) > 0)
        {
                return true;
        }
        
        System.DateTime val_1 = ServerHandler.ServerTime;
        System.DateTime val_3 = this.lastFreeLifeUsed.AddMinutes(value:  (double)val_1.dateData.freeLifeCoolDownMinutes);
        return System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_3.dateData});
    }
    public int get_TotalSeenQuestions()
    {
        return (int)this.totalSeenQuestions;
    }
    public void set_TotalSeenQuestions(int value)
    {
        this.totalSeenQuestions = value;
    }
    public int get_TotalCorrectQuestions()
    {
        return (int)this.totalCorrectQuestions;
    }
    public void set_TotalCorrectQuestions(int value)
    {
        this.totalCorrectQuestions = value;
    }
    public int get_currentStreak()
    {
        return (int)this.<currentStreak>k__BackingField;
    }
    private void set_currentStreak(int value)
    {
        this.<currentStreak>k__BackingField = value;
    }
    public int get_extraFreeLives()
    {
        return (int)this.<extraFreeLives>k__BackingField;
    }
    public void set_extraFreeLives(int value)
    {
        this.<extraFreeLives>k__BackingField = value;
    }
    public TRVPlayerPersistenceManager(TRVDataParser parser)
    {
        this.omittedCategories = new System.Collections.Generic.List<System.String>();
        this.lastRerollLevel = 0;
        this.myParser = parser;
        this.catProgress = new System.Collections.Generic.Dictionary<System.String, TRVSubCategoryProgress>();
        this.LoadProgress();
    }
    public void LoadProgress()
    {
        string val_11;
        var val_12;
        string val_85;
        string val_86;
        var val_87;
        string val_88;
        var val_89;
        var val_91;
        var val_92;
        var val_93;
        var val_94;
        string val_95;
        int val_96;
        var val_97;
        val_85 = 1152921504874684416;
        bool val_2 = CPlayerPrefs.HasKey(key:  this.GetTriviaPersistanceKey());
        if(val_2 == false)
        {
            goto label_3;
        }
        
        val_86 = 0;
        object val_5 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  val_2.GetTriviaPersistanceKey(), defaultValue:  " "));
        if(val_5 == null)
        {
            goto label_8;
        }
        
        val_87 = val_5;
        val_88 = null;
        goto label_10;
        label_3:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = null;
        val_88 = 1152921510196879024;
        val_87 = val_6;
        val_86 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_87 != null)
        {
            goto label_10;
        }
        
        label_8:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = null;
        val_88 = 1152921510196879024;
        val_87 = val_7;
        val_86 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        label_10:
        if(this.myParser == null)
        {
                throw new NullReferenceException();
        }
        
        val_86 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_8 = this.myParser.getAllSubCategories;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = 1152921517239191840;
        val_86 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_9 = val_8.Keys;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_10 = val_9.GetEnumerator();
        val_89 = 1152921517324796416;
        label_30:
        val_88 = 1152921517239197984;
        if(val_12.MoveNext() == false)
        {
            goto label_14;
        }
        
        if(this.myParser == null)
        {
                throw new NullReferenceException();
        }
        
        val_85 = val_11;
        val_86 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_14 = this.myParser.getAllSubCategories;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = 1152921516945296096;
        System.Collections.Generic.List<System.String> val_15 = val_14.Item[val_85];
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_16 = val_15.GetEnumerator();
        val_88 = val_11;
        label_26:
        if(val_12.MoveNext() == false)
        {
            goto label_18;
        }
        
        val_85 = val_88;
        TRVSubCategoryProgress val_18 = new TRVSubCategoryProgress();
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.ContainsKey(key:  val_85)) != false)
        {
                val_88 = 1152921510214912464;
            object val_20 = val_7.Item[val_85];
            if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_21 = val_18.decode(data:  val_20);
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.catProgress.ContainsKey(key:  val_85)) == true)
        {
            goto label_26;
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        this.catProgress.Add(key:  val_85, value:  val_18);
        goto label_26;
        label_18:
        val_85 = 0;
        var val_23 = 0 + 1;
        mem2[0] = 222;
        val_88 = 1152921513251019952;
        val_12.Dispose();
        if(val_85 != 0)
        {
            goto label_27;
        }
        
        if((val_23 == 1) || ((-166811968 + ((0 + 1)) << 2) != 222))
        {
            goto label_30;
        }
        
        var val_86 = 0;
        val_86 = val_86 ^ (val_23 >> 31);
        var val_24 = val_23 + val_86;
        goto label_30;
        label_14:
        val_92 = 0 + 1;
        mem2[0] = 250;
        val_12.Dispose();
        if(val_92 != 1)
        {
                var val_25 = ((-166811968 + ((0 + 1)) << 2) == 250) ? 1 : 0;
            val_25 = ((val_92 >= 0) ? 1 : 0) & val_25;
            val_92 = val_92 - val_25;
        }
        
        System.Collections.Generic.List<System.String> val_27 = TRVPromoCategoriesHandler.GetSpecialCategoriesWithProgress();
        if(val_27 == null)
        {
            goto label_63;
        }
        
        List.Enumerator<T> val_28 = val_27.GetEnumerator();
        val_88 = val_11;
        label_62:
        if(val_12.MoveNext() == false)
        {
            goto label_54;
        }
        
        TRVSubCategoryProgress val_30 = null;
        val_86 = 0;
        val_30 = new TRVSubCategoryProgress();
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        val_86 = val_88;
        if((val_7.ContainsKey(key:  val_86)) != false)
        {
                val_88 = 1152921510214912464;
            val_86 = val_88;
            object val_32 = val_7.Item[val_86];
            if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
            val_86 = val_32;
            if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_33 = val_30.decode(data:  val_86);
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        val_86 = val_88;
        if((this.catProgress.ContainsKey(key:  val_86)) == true)
        {
            goto label_62;
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        this.catProgress.Add(key:  val_88, value:  val_30);
        goto label_62;
        label_54:
        val_92 = val_92 + 1;
        val_86 = public System.Void List.Enumerator<System.String>::Dispose();
        mem2[0] = 382;
        val_12.Dispose();
        if(val_92 != 1)
        {
                val_88 = ((val_92 >= 0) ? 1 : 0) & (((-166811968 + ((((0 + 1) - (val_92 >= 0x0 ? 1 : 0 & -166811968 + ((0 + 1)) << 2 == 0xFA ? 1 : 0)) + 1)) << 2) == 382) ? 1 : 0);
            val_92 = val_92 - val_88;
        }
        
        label_63:
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.ContainsKey(key:  "trivialAvailCategories")) != false)
        {
                val_86 = "trivialAvailCategories";
            val_88 = 1152921510214912464;
            object val_38 = val_7.Item[val_86];
            if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
            object val_39 = MiniJSON.Json.Deserialize(json:  val_38);
        }
        
        label_104:
        if(this.availableCategories != null)
        {
                if(this.availableCategories != null)
        {
            goto label_71;
        }
        
        }
        
        this.availableCategories = new System.Collections.Generic.List<System.String>();
        label_71:
        if((val_7.ContainsKey(key:  "carqI")) != false)
        {
                val_86 = "carqI";
            val_88 = 1152921510214912464;
            object val_42 = val_7.Item[val_86];
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_44 = System.Int32.TryParse(s:  val_42, result: out  this.currentAnswerRequrementIndex);
        }
        
        if((val_7.ContainsKey(key:  "cqrP")) != false)
        {
                val_86 = "cqrP";
            val_88 = 1152921510214912464;
            object val_46 = val_7.Item[val_86];
            if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_48 = System.Int32.TryParse(s:  val_46, result: out  this.currentAnswerRequrementProgress);
        }
        
        val_89 = val_92;
        if((val_7.ContainsKey(key:  "lflu")) != false)
        {
                val_86 = "lflu";
            val_88 = 1152921510214912464;
            object val_50 = val_7.Item[val_86];
            if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.DateTime.TryParse(s:  val_50, result: out  new System.DateTime() {dateData = this.lastFreeLifeUsed})) != true)
        {
                val_93 = null;
            val_93 = null;
            this.lastFreeLifeUsed = System.DateTime.MinValue;
        }
        
        }
        
        if((val_7.ContainsKey(key:  "llrr")) != false)
        {
                val_86 = "llrr";
            val_88 = 1152921510214912464;
            object val_53 = val_7.Item[val_86];
            if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Int32.TryParse(s:  val_53, result: out  this.lastRerollLevel)) != true)
        {
                mem2[0] = 0;
        }
        
        }
        
        System.Collections.Generic.List<System.String> val_56 = null;
        val_94 = 1152921509851217984;
        val_56 = new System.Collections.Generic.List<System.String>();
        this.omittedCategories = val_56;
        this._earlyUnlockedCategories = new System.Collections.Generic.List<System.String>();
        if((val_7.ContainsKey(key:  "euc")) == false)
        {
            goto label_131;
        }
        
        val_86 = "euc";
        val_88 = 1152921510214912464;
        object val_59 = val_7.Item[val_86];
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_60 = MiniJSON.Json.Deserialize(json:  val_59);
        if((val_60 == null) || (null < 1))
        {
            goto label_131;
        }
        
        List.Enumerator<T> val_61 = val_60.GetEnumerator();
        val_88 = val_11;
        val_94 = 1152921509851232320;
        label_96:
        if(val_12.MoveNext() == false)
        {
            goto label_92;
        }
        
        val_86 = val_88;
        if(val_86 == 0)
        {
            goto label_93;
        }
        
        val_88 = null;
        if(val_86 != val_88)
        {
            goto label_94;
        }
        
        label_93:
        if(this._earlyUnlockedCategories == null)
        {
                throw new NullReferenceException();
        }
        
        this._earlyUnlockedCategories.Add(item:  val_86);
        goto label_96;
        label_102:
        if(val_12.MoveNext() == false)
        {
            goto label_98;
        }
        
        val_95 = val_11;
        if(val_95 != 0)
        {
                val_88 = null;
            if(val_95 != val_88)
        {
            goto label_129;
        }
        
        }
        
        this.availableCategories.Add(item:  val_95);
        goto label_102;
        label_98:
        var val_66 =  + 1;
        mem2[0] = 511;
        val_12.Dispose();
        label_134:
        if(val_66 == 1)
        {
            goto label_104;
        }
        
        var val_67 = ((-166811968 + ((((((0 + 1) - (val_92 >= 0x0 ? 1 : 0 & -166811968 + ((0 + 1)) << 2 == 0xFA ? 1 : 0)) + 1) - (val_92 >= 0x0 ? 1 : 0 & -166811968 + ((((0 + 1) - (val_92 >= 0x0 ? 1 : 0 & -166811968 + ((0 + 1)) << 2 == 0) << 2) == 511) ? 1 : 0;
        val_67 = ((val_66 >= 0) ? 1 : 0) & val_67;
        val_66 = val_66 - val_67;
        goto label_104;
        label_92:
        var val_69 = val_89 + 1;
        mem2[0] = 867;
        val_12.Dispose();
        label_131:
        if((val_7.ContainsKey(key:  "tots")) != false)
        {
                val_86 = "tots";
            val_88 = 1152921510214912464;
            object val_71 = val_7.Item[val_86];
            if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_73 = System.Int32.TryParse(s:  val_71, result: out  this.totalSeenQuestions);
        }
        
        if((val_7.ContainsKey(key:  "totc")) != false)
        {
                val_86 = "totc";
            val_88 = 1152921510214912464;
            object val_75 = val_7.Item[val_86];
            if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_77 = System.Int32.TryParse(s:  val_75, result: out  this.totalCorrectQuestions);
        }
        
        if((val_7.ContainsKey(key:  "trvStreak")) != false)
        {
                val_86 = "trvStreak";
            val_88 = 1152921510214912464;
            int val_80 = 0;
            object val_79 = val_7.Item[val_86];
            if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_81 = System.Int32.TryParse(s:  val_79, result: out  val_80);
            val_96 = val_80;
        }
        else
        {
                val_96 = 0;
        }
        
        this.<currentStreak>k__BackingField = val_96;
        if((val_7.ContainsKey(key:  "efl")) != false)
        {
                val_86 = "efl";
            val_88 = 1152921510214912464;
            object val_83 = val_7.Item[val_86];
            if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_85 = System.Int32.TryParse(s:  val_83, result: out  0);
            this.<extraFreeLives>k__BackingField = 0;
        }
        
        this.SaveProgress();
        return;
        label_27:
        val_86 = 0;
        throw val_85;
        label_94:
        val_95 = val_88;
        label_129:
        val_91 = val_95;
        if(val_88 != 1)
        {
            goto label_149;
        }
        
        val_97 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, System.Collections.Generic.List<System.String>>::MoveNext();
        val_12.Dispose();
        if(as. 
           
           
          
        
        
        
         == 0)
        {
            goto label_134;
        }
        
        throw null;
        label_149:
    }
    public void SaveProgress()
    {
        string val_5;
        int val_6;
        string val_36;
        TRVDataParser val_37;
        string val_38;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = this.myParser.getAllSubCategories.Keys.GetEnumerator();
        var val_38 = 0;
        label_19:
        val_36 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, System.Collections.Generic.List<System.String>>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_37 = this.myParser;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_5;
        val_36 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_8 = val_37.getAllSubCategories;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_38;
        System.Collections.Generic.List<System.String> val_9 = val_8.Item[val_36];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = val_9.GetEnumerator();
        label_15:
        if(val_6.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        val_38 = val_5;
        if((this.catProgress.ContainsKey(key:  val_38)) != true)
        {
                if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
            this.catProgress.Add(key:  val_38, value:  new TRVSubCategoryProgress());
        }
        
        if(this.catProgress == null)
        {
                throw new NullReferenceException();
        }
        
        TRVSubCategoryProgress val_14 = this.catProgress.Item[val_38];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_38, value:  val_14.encode());
        goto label_15;
        label_8:
        val_38 = 0;
        var val_16 = val_38 + 1;
        mem2[0] = 168;
        val_6.Dispose();
        if(val_38 != 0)
        {
            goto label_24;
        }
        
        if((val_16 == 1) || ((-166404000 + ((0 + 1)) << 2) != 168))
        {
            goto label_19;
        }
        
        var val_37 = 0;
        val_37 = val_37 ^ (val_16 >> 31);
        var val_17 = val_16 + val_37;
        goto label_19;
        label_4:
        val_38 = val_38 + 1;
        mem2[0] = 196;
        val_6.Dispose();
        if(val_38 != 1)
        {
                var val_18 = ((-166404000 + ((0 + 1)) << 2) == 196) ? 1 : 0;
            val_18 = ((val_38 >= 0) ? 1 : 0) & val_18;
            val_18 = val_38 - val_18;
            val_18 = val_18 + 1;
        }
        
        System.Collections.Generic.List<System.String> val_20 = TRVPromoCategoriesHandler.GetSpecialCategoriesWithProgress();
        if(val_20 == null)
        {
            goto label_77;
        }
        
        List.Enumerator<T> val_21 = val_20.GetEnumerator();
        label_50:
        val_36 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_43;
        }
        
        val_37 = this.catProgress;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_5;
        if((val_37.ContainsKey(key:  val_36)) != true)
        {
                TRVSubCategoryProgress val_24 = null;
            val_36 = 0;
            val_24 = new TRVSubCategoryProgress();
            val_37 = this.catProgress;
            if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
            val_36 = val_5;
            val_37.Add(key:  val_36, value:  val_24);
        }
        
        val_37 = this.catProgress;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_5;
        TRVSubCategoryProgress val_25 = val_37.Item[val_36];
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_5, value:  val_25.encode());
        goto label_50;
        label_43:
        val_6.Dispose();
        label_77:
        val_6 = this.lastRerollLevel;
        val_1.Add(key:  "llrr", value:  val_6);
        val_1.Add(key:  "trivialAvailCategories", value:  MiniJSON.Json.Serialize(obj:  this.availableCategories));
        val_1.Add(key:  "lflu", value:  this.lastFreeLifeUsed.ToString());
        val_1.Add(key:  "euc", value:  MiniJSON.Json.Serialize(obj:  this._earlyUnlockedCategories));
        val_1.Add(key:  "efl", value:  this.<extraFreeLives>k__BackingField);
        val_1.Add(key:  "tots", value:  this.totalSeenQuestions);
        val_1.Add(key:  "totc", value:  this.totalCorrectQuestions);
        val_1.Add(key:  "trvStreak", value:  this.<currentStreak>k__BackingField);
        CPlayerPrefs.SetString(key:  val_1.GetTriviaPersistanceKey(), val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        System.DateTime val_32 = ServerHandler.ServerTime;
        System.DateTime val_33 = val_32.dateData.AddMinutes(value:  1);
        System.DateTime val_35 = this.lastFreeLifeUsed.AddMinutes(value:  (double)val_33.dateData.freeLifeCoolDownMinutes);
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_33.dateData}, t2:  new System.DateTime() {dateData = val_35.dateData})) == false)
        {
                return;
        }
        
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  25);
        return;
        label_24:
        val_37 = val_38;
        val_36 = 0;
        throw val_37;
    }
    public void AddFreeLife(bool addExtraLife = False)
    {
        var val_2;
        if((this.freeLifeAvailable != true) && (addExtraLife != true))
        {
                val_2 = null;
            val_2 = null;
            this.lastFreeLifeUsed = System.DateTime.MinValue;
            UpdateExtraLifeNotification(newUsedAt:  new System.DateTime() {dateData = System.DateTime.MinValue});
        }
        else
        {
                int val_2 = this.<extraFreeLives>k__BackingField;
            val_2 = val_2 + 1;
            this.<extraFreeLives>k__BackingField = val_2;
        }
        
        this.SaveProgress();
    }
    public void UseFreeLife(System.DateTime usedAtTime)
    {
        int val_1 = this.<extraFreeLives>k__BackingField;
        val_1 = val_1 - 1;
        if()
        {
                this.<extraFreeLives>k__BackingField = val_1;
        }
        else
        {
                this.lastFreeLifeUsed = usedAtTime;
            this.UpdateExtraLifeNotification(newUsedAt:  new System.DateTime() {dateData = usedAtTime.dateData});
        }
        
        this.SaveProgress();
    }
    public int TotalFreeLivesAvailable()
    {
        bool val_1 = this.freeLifeAvailable;
        val_1 = (this.<extraFreeLives>k__BackingField) + val_1;
        return (int)val_1;
    }
    public void UnlockCategoryEarly(string cat)
    {
        System.Collections.Generic.List<System.String> val_3 = this._earlyUnlockedCategories;
        if(val_3 == null)
        {
                System.Collections.Generic.List<System.String> val_1 = null;
            val_3 = val_1;
            val_1 = new System.Collections.Generic.List<System.String>();
            this._earlyUnlockedCategories = val_3;
        }
        
        if((val_1.Contains(item:  cat)) != false)
        {
                UnityEngine.Debug.LogError(message:  "Unlocking a cat early that is already unlocked");
            return;
        }
        
        this._earlyUnlockedCategories.Add(item:  cat);
        this.SaveProgress();
    }
    public TRVSubCategoryProgress GetSubCatProgress(string subCategory)
    {
        TRVSubCategoryProgress val_4;
        TRVSubCategoryProgress val_1 = null;
        val_4 = val_1;
        val_1 = new TRVSubCategoryProgress();
        if((this.catProgress.ContainsKey(key:  subCategory)) != false)
        {
                val_4 = this.catProgress.Item[subCategory];
            return val_4;
        }
        
        this.catProgress.Add(key:  subCategory, value:  val_1);
        return val_4;
    }
    public QuestionData GetQuestion(TRVSubCategoryData myData, string subCat, int desiredDifficulty, ref bool completedThisDifficulty)
    {
        int val_29;
        object val_30;
        System.Object[] val_31;
        var val_32;
        System.Object[] val_33;
        var val_34;
        val_29 = desiredDifficulty;
        val_30 = myData;
        bool val_29 = true;
        int val_2 = this.GetSubCatProgress(subCategory:  subCat).SeenQuestionsPerDifficulty(diff:  val_29);
        val_31 = 1152921517247365568;
        if((myData.questionData.ContainsKey(key:  val_29)) == false)
        {
            goto label_7;
        }
        
        System.Collections.Generic.List<QuestionData> val_4 = myData.questionData.Item[val_29];
        if(val_2 >= val_29)
        {
            goto label_7;
        }
        
        System.Collections.Generic.List<QuestionData> val_5 = myData.questionData.Item[val_29];
        if(val_29 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_29 = val_29 + (val_2 << 3);
        val_32 = mem[(true + (val_2) << 3) + 32];
        val_32 = (true + (val_2) << 3) + 32;
        TRVSubCategoryProgress val_6 = this.GetSubCatProgress(subCategory:  subCat);
        val_6.seenQuestions.set_Item(key:  (true + (val_2) << 3) + 32 + 32, value:  (val_6.seenQuestions.Item[(true + (val_2) << 3) + 32 + 32]) + 1);
        TRVSubCategoryProgress val_9 = this.GetSubCatProgress(subCategory:  subCat);
        val_31 = val_9.seenQuestions.Item[(true + (val_2) << 3) + 32 + 32];
        System.Collections.Generic.List<QuestionData> val_11 = myData.questionData.Item[val_29];
        if(val_31 == myData.questionData)
        {
                completedThisDifficulty = true;
        }
        
        val_33 = 0;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_14 = new object[3];
            val_14[0] = myData.subCategory;
            val_29 = 1152921504619999232;
            val_30 = (true + (val_2) << 3) + 32 + 32;
            val_14[1] = val_30;
            TRVSubCategoryProgress val_15 = this.GetSubCatProgress(subCategory:  subCat);
            val_14[2] = val_15.seenQuestions.Item[(true + (val_2) << 3) + 32 + 32];
            val_33 = val_14;
            UnityEngine.Debug.LogErrorFormat(format:  "Just iterated category {0} difficulty {1} seen questions to: {2}", args:  val_14);
        }
        
        int val_30 = this.totalSeenQuestions;
        val_30 = val_30 + 1;
        this.totalSeenQuestions = val_30;
        this.SaveProgress();
        goto label_37;
        label_7:
        if((myData.questionData.Keys.Count > val_29) && ((myData.questionData.ContainsKey(key:  val_29 + 1)) != false))
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_23 = new object[2];
            val_31 = val_23;
            val_31[0] = myData.subCategory;
            val_29 = val_29;
            val_31[1] = val_29;
            UnityEngine.Debug.LogErrorFormat(format:  "No Q\'s remain for {0} difficulty {1} getting higher difficulty.", args:  val_23);
        }
        
            val_34 = this;
            val_33 = val_30;
        }
        else
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_26 = new object[2];
            val_31 = myData.subCategory;
            val_26[0] = val_31;
            val_29 = val_29;
            val_26[1] = val_29;
            UnityEngine.Debug.LogErrorFormat(format:  "No Q\'s remain for {0} difficulty {1} or higher, had to reset!", args:  val_26);
        }
        
            this.ResetSubCat(subcat:  subCat);
            val_34 = this;
            val_33 = val_30;
        }
        
        val_32 = val_34;
        label_37:
        this.lastFreeLifeUsed = MonoSingleton<TRVDataParser>.Instance.GetQuestionImageFromID(subCategory:  this.myParser, questionID:  this.catProgress);
        return (QuestionData)val_32;
    }
    public void ResetSubCat(string subcat)
    {
        if((System.String.IsNullOrEmpty(value:  subcat)) == true)
        {
                return;
        }
        
        TRVSubCategoryProgress val_2 = this.GetSubCatProgress(subCategory:  subcat);
        if(val_2 == null)
        {
                return;
        }
        
        val_2.ResetCat();
        this.SaveProgress();
    }
    public int GetCrownsCollected()
    {
        var val_3;
        System.Func<TRVSubCategoryProgress, System.Int32> val_5;
        val_3 = null;
        val_3 = null;
        val_5 = TRVPlayerPersistenceManager.<>c.<>9__66_0;
        if(val_5 != null)
        {
                return System.Linq.Enumerable.Sum<TRVSubCategoryProgress>(source:  this.catProgress.Values, selector:  System.Func<TRVSubCategoryProgress, System.Int32> val_2 = null);
        }
        
        val_5 = val_2;
        val_2 = new System.Func<TRVSubCategoryProgress, System.Int32>(object:  TRVPlayerPersistenceManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVPlayerPersistenceManager.<>c::<GetCrownsCollected>b__66_0(TRVSubCategoryProgress x));
        TRVPlayerPersistenceManager.<>c.<>9__66_0 = val_5;
        return System.Linq.Enumerable.Sum<TRVSubCategoryProgress>(source:  this.catProgress.Values, selector:  val_2);
    }
    private void UpdateExtraLifeNotification(System.DateTime newUsedAt)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "notification_type", value:  "TRV_EXTRA_LIFE");
        System.DateTime val_3 = newUsedAt.dateData.AddMinutes(value:  (double)val_1.freeLifeCoolDownMinutes);
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  25, when:  new System.DateTime() {dateData = val_3.dateData}, optMessage:  "EXTRA LIFE AVAILABLE!", extraData:  val_1);
    }
    public void Hack_SendExtraLifeNotif()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_3 = val_1.dateData.AddMinutes(value:  (double)-val_1.dateData.freeLifeCoolDownMinutes);
        System.DateTime val_4 = val_3.dateData.AddSeconds(value:  5);
        val_4.dateData.UpdateExtraLifeNotification(newUsedAt:  new System.DateTime() {dateData = val_4.dateData});
    }
    private string GetTriviaPersistanceKey()
    {
        GameBehavior val_1 = App.getBehavior;
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        if((val_2.Equals(value:  "en")) == false)
        {
                return System.String.Format(format:  "{0}_{1}", arg0:  "triviaCatProgress", arg1:  val_2);
        }
        
        return "triviaCatProgress";
    }

}
