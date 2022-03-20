using UnityEngine;
public class TRVMainController : MonoSingleton<TRVMainController>
{
    // Fields
    private static TRVMainController.TRVMainControllerEntry _entryType;
    private const int REROLL_FTUX_LEVEL = 10;
    public static bool QAHACK_HURRY;
    public static bool QAHACK_CORRECT;
    private const string rerollUsedKey = "rerollUsed";
    private const string lastLowGemKey = "lastLowGem";
    public const string noAnswerSelectedCharacter = "!";
    private TRVQuizProgress currentGame;
    private int numCategoriesSelection;
    public System.Action OnQuizBegin;
    public System.Action<TRVQuizProgress> OnQuestionBegin;
    public System.Action<bool, TRVQuizProgress> OnQuizComplete;
    public System.Func<TRVQuizProgress> GetNewQuizFromFeature;
    public System.Func<QuestionData> GetExternalFeatureQuestion;
    public System.Func<bool> ShowLevelComplete;
    public System.Func<bool> ShowLevelFailed;
    public System.Func<bool> PlayingChallenge;
    public System.Action<bool> OnQuestionAnswered;
    private bool <rerolled>k__BackingField;
    
    // Properties
    public static TRVMainController.TRVMainControllerEntry entryType { get; set; }
    public static int currentMultiplier { get; set; }
    public static int getRerollFTUXLEVEL { get; }
    public TRVQuizProgress getCurrentGame { get; }
    public int getQuizLength { get; }
    public System.DateTime freeLifeAvailableAt { get; }
    public bool freeLifeAvailable { get; }
    public bool IsPlayingChallenge { get; }
    public bool rerolled { get; set; }
    private bool spentGemsLastQuiz { get; set; }
    public bool eventEntryType { get; }
    
    // Methods
    public static TRVMainController.TRVMainControllerEntry get_entryType()
    {
        null = null;
        return (TRVMainControllerEntry)TRVMainController.noAnswerSelectedCharacter;
    }
    public static void set_entryType(TRVMainController.TRVMainControllerEntry value)
    {
        null = null;
        TRVMainController.noAnswerSelectedCharacter = value;
    }
    public static int get_currentMultiplier()
    {
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_2.variableEntryUnlock)) == false)
        {
                return 0;
        }
        
        return CPlayerPrefs.GetInt(key:  "curMulti", defaultValue:  0);
    }
    public static void set_currentMultiplier(int value)
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        CPlayerPrefs.SetInt(key:  "curMulti", val:  UnityEngine.Mathf.Min(a:  value, b:  val_1.variableMultipliers.Length));
    }
    public static int get_getRerollFTUXLEVEL()
    {
        return 10;
    }
    public TRVQuizProgress get_getCurrentGame()
    {
        return (TRVQuizProgress)this.currentGame;
    }
    public int get_getQuizLength()
    {
        if(this.currentGame != null)
        {
                return (int)this.currentGame.quizLength;
        }
        
        throw new NullReferenceException();
    }
    public System.DateTime get_freeLifeAvailableAt()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        return val_1.<playerPersistance>k__BackingField.freeLifeAvailableAt;
    }
    public bool get_freeLifeAvailable()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        return val_1.<playerPersistance>k__BackingField.freeLifeAvailable;
    }
    public bool get_IsPlayingChallenge()
    {
        System.Func<System.Boolean> val_3;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != false)
        {
                val_3 = 1;
            return (bool)val_3;
        }
        
        val_3 = this.PlayingChallenge;
        if(val_3 == null)
        {
                return (bool)val_3;
        }
        
        return val_3.Invoke();
    }
    public bool get_rerolled()
    {
        return (bool)this.<rerolled>k__BackingField;
    }
    public void set_rerolled(bool value)
    {
        this.<rerolled>k__BackingField = value;
    }
    private bool get_spentGemsLastQuiz()
    {
        return CPlayerPrefs.GetBool(key:  "showlg", defaultValue:  false);
    }
    private void set_spentGemsLastQuiz(bool value)
    {
        value = value;
        CPlayerPrefs.SetBool(key:  "showlg", value:  value);
    }
    public bool get_eventEntryType()
    {
        null = null;
        return (bool)(TRVMainController.noAnswerSelectedCharacter == 2) ? 1 : 0;
    }
    private void Start()
    {
        null = null;
        if(TRVMainController.noAnswerSelectedCharacter <= 3)
        {
                var val_1 = 32497824 + (TRVMainController.noAnswerSelectedCharacter) << 2;
            val_1 = val_1 + 32497824;
        }
        else
        {
                this.Init(currentlySelectedCategores:  0, fromReroll:  false);
        }
    
    }
    public void Init(System.Collections.Generic.List<string> currentlySelectedCategores, bool fromReroll = False)
    {
        string val_32;
        var val_33;
        System.Collections.Generic.IEnumerable<T> val_50;
        var val_51;
        System.Collections.Generic.List<System.String> val_52;
        TRVPlayerPersistenceManager val_53;
        int val_54;
        MetaGameBehavior val_55;
        var val_56;
        var val_57;
        System.Collections.Generic.IEnumerable<TSource> val_58;
        var val_59;
        System.Func<TRVCategorySelectionInfo, System.Boolean> val_61;
        val_50 = currentlySelectedCategores;
        if(fromReroll != true)
        {
                this.CheckLowGems();
        }
        
        if(val_50 == null)
        {
            goto label_2;
        }
        
        label_53:
        val_51 = null;
        val_51 = null;
        if(TRVMainController.noAnswerSelectedCharacter == null)
        {
                val_52 = 0;
            MonoSingleton<WGWindowManager>.Instance.ShowAvailablePopups(fromMinimize:  false, entry:  "");
        }
        
        if(val_50 == null)
        {
            goto label_159;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_2.<playerPersistance>k__BackingField;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        val_53.getCurrentAvailableCategories = val_52;
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_3.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_54 = val_3.<playerPersistance>k__BackingField.lastRerollLevel;
        Player val_4 = App.Player;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_54 != val_4)
        {
            goto label_22;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_5.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_5.<playerPersistance>k__BackingField.omittedCategories;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = val_50;
        val_53.AddRange(collection:  val_52);
        goto label_28;
        label_2:
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_6.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_6.<playerPersistance>k__BackingField.availableCategories) == null)
        {
            goto label_33;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.<playerPersistance>k__BackingField.availableCategories) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.<playerPersistance>k__BackingField.availableCategories) != null)
        {
            goto label_53;
        }
        
        label_33:
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_8.<playerPersistance>k__BackingField.omittedCategories) == null)
        {
            goto label_44;
        }
        
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_9.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_9.<playerPersistance>k__BackingField.omittedCategories) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_9.<playerPersistance>k__BackingField.omittedCategories) != null)
        {
            goto label_53;
        }
        
        label_44:
        CPlayerPrefs.SetBool(key:  "rerollUsed", value:  false);
        goto label_53;
        label_22:
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_10.<playerPersistance>k__BackingField;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = val_50;
        val_53.getOmittedCateogries = val_52;
        label_28:
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        Player val_12 = App.Player;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_11.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.<playerPersistance>k__BackingField.getLastRerollLevel = val_12;
        val_52 = 1;
        CPlayerPrefs.SetBool(key:  "rerollUsed", value:  true);
        label_159:
        val_55 = 1152921504893161472;
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_13.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_13.<playerPersistance>k__BackingField.availableCategories) != null)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_14.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_14.<playerPersistance>k__BackingField.availableCategories) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_14.<playerPersistance>k__BackingField.availableCategories) != null)
        {
                TRVDataParser val_15 = MonoSingleton<TRVDataParser>.Instance;
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_15.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            bool val_16 = val_15.CheckDataIsOld(currentlySelectedCategories:  val_15.<playerPersistance>k__BackingField.availableCategories);
            if(val_16 == false)
        {
            goto label_147;
        }
        
        }
        
        }
        
        val_52 = val_50;
        val_16.GetNewCategories(currentlySelectedCategories:  val_52);
        val_56 = 1;
        label_147:
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID != null)
        {
                val_52 = 0;
            if((val_56 | (System.String.IsNullOrEmpty(value:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32))) != false)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_19.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_52 = 0;
            TRVCrazyCategoriesEventHandler.RollBonusCategory(chosenCategories:  val_19.<playerPersistance>k__BackingField.availableCategories);
        }
        
        }
        
        CompanyDevices val_20 = CompanyDevices.Instance;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        if(val_20.CompanyDevice() != false)
        {
                val_57 = 1152921516945301216;
            var val_49 = 0;
            do
        {
            TRVDataParser val_22 = MonoSingleton<TRVDataParser>.Instance;
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            val_52 = 0;
            System.Collections.Generic.List<System.String> val_23 = val_22.HackCategories;
            if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
            val_54 = val_23;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_52 = 0;
            if((System.String.IsNullOrEmpty(value:  (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32)) != true)
        {
                if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_25.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
            val_54 = val_25.<playerPersistance>k__BackingField.availableCategories;
            TRVDataParser val_26 = MonoSingleton<TRVDataParser>.Instance;
            if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
            val_52 = 0;
            if(val_26.HackCategories == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_49 >= (val_25.<playerPersistance>k__BackingField))
        {
                val_53 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
            val_54.set_Item(index:  0, value:  TRVPlayerPersistenceManager.__il2cppRuntimeField_byval_arg);
        }
        
            val_49 = val_49 + 1;
        }
        while(val_49 < 2);
        
        }
        
        this.currentGame = 0;
        if(this.GetNewQuizFromFeature != null)
        {
                TRVQuizProgress val_28 = this.GetNewQuizFromFeature.Invoke();
            this.currentGame = val_28;
            if(val_28 != null)
        {
                this.SetupAndAnimateNewQuiz();
            this.TrackLevelStart();
            if(this.OnQuizBegin == null)
        {
                return;
        }
        
            this.OnQuizBegin.Invoke();
            return;
        }
        
        }
        
        System.Collections.Generic.List<TRVCategorySelectionInfo> val_29 = null;
        val_52 = public System.Void System.Collections.Generic.List<TRVCategorySelectionInfo>::.ctor();
        val_29 = new System.Collections.Generic.List<TRVCategorySelectionInfo>();
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_30.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_30.<playerPersistance>k__BackingField.availableCategories;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_31 = val_53.GetEnumerator();
        val_56 = 1152921504956899328;
        val_50 = 1152921517297816416;
        label_121:
        if(val_33.MoveNext() == false)
        {
            goto label_118;
        }
        
        TRVCategorySelectionInfo val_35 = null;
        val_52 = 0;
        val_35 = new TRVCategorySelectionInfo();
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        .categoryName = val_32;
        System.Collections.Generic.List<WGEventHandler> val_36 = null;
        val_52 = public System.Void System.Collections.Generic.List<WGEventHandler>::.ctor();
        val_36 = new System.Collections.Generic.List<WGEventHandler>();
        .associatedEvents = val_36;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.Add(item:  val_35);
        goto label_121;
        label_118:
        val_52 = public System.Void List.Enumerator<System.String>::Dispose();
        val_33.Dispose();
        WordGameEventsController val_37 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_54 = 1152921504960946176;
        val_58 = val_37.GetEventsRegisteredCategories(categories:  val_29);
        val_59 = null;
        val_59 = null;
        val_61 = TRVMainController.<>c.<>9__47_0;
        if(val_61 == null)
        {
                System.Func<TRVCategorySelectionInfo, System.Boolean> val_39 = null;
            val_61 = val_39;
            val_39 = new System.Func<TRVCategorySelectionInfo, System.Boolean>(object:  TRVMainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVMainController.<>c::<Init>b__47_0(TRVCategorySelectionInfo x));
            TRVMainController.<>c.<>9__47_0 = val_61;
        }
        
        val_52 = val_61;
        if((System.Linq.Enumerable.Any<TRVCategorySelectionInfo>(source:  val_58, predicate:  val_39)) == false)
        {
            goto label_164;
        }
        
        UnityEngine.Debug.LogError(message:  "GETTING AN EMPTY NAME FOR A CATOGORY THAT USED TO RESULT IN A CRASH. OVERRIDING WITH NEW CATEGORIES, CHECK ACTIVE EVENTS WHEN THIS OCCURS");
        GetNewCategories(currentlySelectedCategories:  val_50);
        System.Collections.Generic.List<TRVCategorySelectionInfo> val_41 = null;
        val_58 = val_41;
        val_52 = public System.Void System.Collections.Generic.List<TRVCategorySelectionInfo>::.ctor();
        val_41 = new System.Collections.Generic.List<TRVCategorySelectionInfo>();
        if((MonoSingleton<TRVDataParser>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_42.<playerPersistance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_42.<playerPersistance>k__BackingField.availableCategories;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_43 = val_53.GetEnumerator();
        label_141:
        if(val_33.MoveNext() == false)
        {
            goto label_138;
        }
        
        TRVCategorySelectionInfo val_45 = null;
        val_52 = 0;
        val_45 = new TRVCategorySelectionInfo();
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        .categoryName = val_32;
        System.Collections.Generic.List<WGEventHandler> val_46 = null;
        val_52 = public System.Void System.Collections.Generic.List<WGEventHandler>::.ctor();
        val_46 = new System.Collections.Generic.List<WGEventHandler>();
        .associatedEvents = val_46;
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.Add(item:  val_45);
        goto label_141;
        label_138:
        val_52 = public System.Void List.Enumerator<System.String>::Dispose();
        val_33.Dispose();
        label_164:
        val_57 = val_56;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_55 = val_47.<metaGameBehavior>k__BackingField;
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = val_55;
        val_52 = 0;
        if(val_53 == null)
        {
                throw new NullReferenceException();
        }
        
        val_53.Init(selectedCategorys:  val_41, animate:  true, canReroll:  true);
    }
    public void InitQOTD()
    {
        this.CheckLowGems();
        this.OnCategorySelected(selectedSubCat:  MonoSingleton<TRVQuestionOfTheDayManager>.Instance.GetRandomSubCategory(), selectedPrimaryCat:  "QOTD");
    }
    public void InitSpecialCategories()
    {
        this.CheckLowGems();
        this.OnCategorySelected(selectedSubCat:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.GetEventSubCategory(), selectedPrimaryCat:  TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID.GetEventPrimaryCategory());
    }
    private void InitPromoCategories()
    {
        this.CheckLowGems();
        this.OnCategorySelected(selectedSubCat:  MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetCurrentlyShownSubCategory(), selectedPrimaryCat:  MonoSingleton<TRVPromoCategoriesHandler>.Instance.GetPrimaryCategory());
    }
    public void InitSpecialCategories(TRVCategorySelectionInfo categorySelectionInfo, string primaryCategoryName)
    {
        this.CheckLowGems();
        this.OnCategorySelected(selectedSubCat:  categorySelectionInfo, selectedPrimaryCat:  primaryCategoryName);
    }
    private void GetNewCategories(System.Collections.Generic.List<string> currentlySelectedCategories)
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        val_1.<playerPersistance>k__BackingField.getCurrentAvailableCategories = MonoSingleton<TRVDataParser>.Instance.GetNewCategories(currentlySelectedCategories:  currentlySelectedCategories);
    }
    private void CheckLowGems()
    {
        int val_19;
        var val_20;
        if((MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed) == false)
        {
                return;
        }
        
        bool val_4 = MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached;
        if(val_4 == true)
        {
                return;
        }
        
        if(val_4.spentGemsLastQuiz == false)
        {
                return;
        }
        
        Player val_6 = App.Player;
        val_19 = val_6._gems;
        TRVEcon val_7 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_19 >= val_7.lowGemThreshold)
        {
                return;
        }
        
        val_20 = null;
        val_20 = null;
        val_19 = System.DateTime.MinValue.ToString();
        if((System.DateTime.TryParse(s:  CPlayerPrefs.GetString(key:  "lastLowGem", defaultValue:  val_19), result: out  new System.DateTime())) == false)
        {
                return;
        }
        
        System.DateTime val_11 = 0.Date;
        val_19 = val_11.dateData;
        System.DateTime val_12 = DateTimeCheat.UtcNow;
        System.DateTime val_13 = val_12.dateData.Date;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = val_19}, d2:  new System.DateTime() {dateData = val_13.dateData})) == false)
        {
                return;
        }
        
        GameBehavior val_15 = App.getBehavior;
        val_15.<metaGameBehavior>k__BackingField.InitAsLowGems(lowGems:  true);
        System.DateTime val_17 = DateTimeCheat.UtcNow;
        val_19 = val_17.dateData.ToString();
        CPlayerPrefs.SetString(key:  "lastLowGem", val:  val_19);
        spentGemsLastQuiz = false;
    }
    public void CheckShouldShowLowGems()
    {
        if(this.currentGame == null)
        {
                return;
        }
        
        if((this.currentGame.removeTwoHintUsed != true) && (this.currentGame.rerollQuestionUsed != true))
        {
                int val_1 = this.currentGame.extraLivesUsedThisQuiz;
            if(val_1 <= 0)
        {
                if((this.<rerolled>k__BackingField) == false)
        {
            goto label_5;
        }
        
        }
        
        }
        
        label_5:
        val_1.spentGemsLastQuiz = true;
    }
    private bool CheckCanReroll()
    {
        return true;
    }
    private bool CheckDataIsOld(System.Collections.Generic.List<string> currentlySelectedCategories)
    {
        string val_2;
        var val_3;
        var val_25;
        var val_27;
        var val_28;
        string val_29;
        var val_30;
        System.Collections.Generic.List<System.String> val_31;
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        val_25 = currentlySelectedCategories;
        List.Enumerator<T> val_1 = val_25.GetEnumerator();
        val_27 = 0;
        label_36:
        val_28 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_29 = val_2;
        val_30 = null;
        val_30 = null;
        val_31 = TRVDataParser.categoryNames;
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_31.GetEnumerator();
        label_21:
        if(val_3.MoveNext() == false)
        {
            goto label_6;
        }
        
        TRVDataParser val_7 = MonoSingleton<TRVDataParser>.Instance;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_7.getAvailableSubCategories == null)
        {
            goto label_15;
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
        
        if((val_10.ContainsKey(key:  val_2)) == false)
        {
            goto label_15;
        }
        
        TRVDataParser val_12 = MonoSingleton<TRVDataParser>.Instance;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_13 = val_12.getAvailableSubCategories;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_14 = val_13.Item[val_2];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_14.Contains(item:  val_29)) == false)
        {
            goto label_21;
        }
        
        val_32 = val_27 + 1;
        val_33 = 0;
        mem2[0] = 163;
        val_34 = 1;
        goto label_69;
        label_15:
        if((MonoSingleton<TRVPromoCategoriesHandler>.Instance) == 0)
        {
            goto label_27;
        }
        
        TRVPromoCategoriesHandler val_18 = MonoSingleton<TRVPromoCategoriesHandler>.Instance;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = (~(val_18.IsActivePromo(subCategoryName:  val_29))) & 1;
        goto label_31;
        label_6:
        val_32 = val_27 + 1;
        val_36 = 163;
        goto label_32;
        label_27:
        val_35 = 1;
        label_31:
        var val_20 = (val_35 != 0) ? 1 : 0;
        val_32 = val_27 + 1;
        val_36 = 201;
        label_32:
        val_33 = 0;
        val_34 = 0;
        mem2[0] = 201;
        label_69:
        val_3.Dispose();
        if(val_33 != 0)
        {
            goto label_43;
        }
        
        if(val_32 == 1)
        {
            goto label_34;
        }
        
        if((1152921517299413392 + ((val_27 + 1)) << 2) == 201)
        {
            goto label_35;
        }
        
        var val_21 = ((1152921517299413392 + ((val_27 + 1)) << 2) == 163) ? 1 : 0;
        val_21 = ((val_32 >= 0) ? 1 : 0) & val_21;
        val_27 = val_32 - val_21;
        label_34:
        if(val_34 != 0)
        {
            goto label_36;
        }
        
        goto label_37;
        label_2:
        val_37 = val_20;
        val_38 = 199;
        goto label_70;
        label_37:
        val_37 = 1;
        val_38 = 201;
        label_70:
        val_39 = val_27 + 1;
        mem2[0] = 201;
        goto label_71;
        label_35:
        val_37 = val_20;
        label_71:
        val_3.Dispose();
        if(val_32 != 1)
        {
                val_40 = val_37 & (((1152921517299413392 + ((val_27 + 1)) << 2) == 201) ? 1 : 0);
            return (bool)val_40;
        }
        
        val_40 = 0;
        return (bool)val_40;
        label_43:
        val_31 = val_33;
        val_28 = 0;
        throw val_31;
    }
    public bool RetrieveLevelDataFromFeature()
    {
        var val_2;
        if(this.GetNewQuizFromFeature != null)
        {
                if(this.GetNewQuizFromFeature.Invoke() != null)
        {
                val_2 = 1;
            return (bool)val_2;
        }
        
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public void OnCategorySelected(TRVCategorySelectionInfo selectedSubCat, string selectedPrimaryCat = "")
    {
        var val_26;
        TRVQuizProgress val_27;
        string val_28;
        this.currentGame = 0;
        if((this.eventEntryType == false) || ((MonoSingleton<WordGameEventsController>.Instance) == 0))
        {
            goto label_6;
        }
        
        TRVQuizProgress val_7 = MonoSingleton<WordGameEventsController>.Instance.GetEventQuiz(data:  MonoSingleton<TRVDataParser>.Instance.LoadSubCategoryData(subcategory:  selectedSubCat.categoryName, primaryCategory:  selectedPrimaryCat));
        goto label_14;
        label_6:
        val_26 = null;
        val_26 = null;
        if(TRVMainController.noAnswerSelectedCharacter == 3)
        {
            goto label_20;
        }
        
        bool val_9 = MonoSingleton<TRVPromoCategoriesHandler>.Instance.IsActivePromo(subCategoryName:  selectedSubCat.categoryName);
        if(val_9 == false)
        {
            goto label_25;
        }
        
        label_20:
        TRVQuizProgress val_11 = MonoSingleton<TRVPromoCategoriesHandler>.Instance.LoadQuiz(subCategory:  selectedSubCat.categoryName, primaryCategory:  selectedPrimaryCat);
        label_14:
        val_27 = val_11;
        this.currentGame = val_11;
        if(val_27 != null)
        {
            goto label_34;
        }
        
        label_36:
        TRVQuizProgress val_14 = null;
        val_27 = val_14;
        val_14 = new TRVQuizProgress(quizCategoryData:  MonoSingleton<TRVDataParser>.Instance.LoadSubCategoryData(subcategory:  selectedSubCat.categoryName, primaryCategory:  selectedPrimaryCat));
        this.currentGame = val_27;
        if(val_27 != null)
        {
            goto label_34;
        }
        
        label_25:
        val_27 = this.currentGame;
        if(val_27 == null)
        {
            goto label_36;
        }
        
        label_34:
        this.currentGame.quizCategory = selectedSubCat.categoryName;
        if(W9 <= 0)
        {
            goto label_38;
        }
        
        string val_15 = val_9.EventType;
        if(this.currentGame != null)
        {
            goto label_41;
        }
        
        label_38:
        val_28 = "";
        label_41:
        this.currentGame.associatedEventID = val_28;
        TRVDataParser val_16 = MonoSingleton<TRVDataParser>.Instance;
        val_16.<playerPersistance>k__BackingField.getCurrentAvailableCategories = new System.Collections.Generic.List<System.String>();
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != true)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnGameSceneBegan();
        }
        
        if((CPlayerPrefs.GetBool(key:  "rerollUsed", defaultValue:  false)) != false)
        {
                this.<rerolled>k__BackingField = true;
            CPlayerPrefs.SetBool(key:  "rerollUsed", value:  false);
        }
        
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != false)
        {
                this.CheckQOTDQuestionSet();
            this.StartNextQuestion();
        }
        else
        {
                MonoSingleton<WordGameEventsController>.Instance.OnEventCategorySelected(category:  selectedSubCat);
            this.SetupAndAnimateNewQuiz();
        }
        
        this.TrackLevelStart();
        if(this.OnQuizBegin == null)
        {
                return;
        }
        
        this.OnQuizBegin.Invoke();
    }
    public void SetupAndAnimateNewQuiz()
    {
        this.currentGame.currentGameplayState = new TRVGameplayState();
        bool val_2 = this.SetupQuestionFromLevelData(progress:  this.currentGame);
        GameBehavior val_3 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVQuestionComplete MetaGameBehavior::ShowUGUIMonolith<TRVQuestionComplete>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public void StartNextQuestion()
    {
        var val_8;
        UnityEngine.Object val_9;
        this.currentGame.currentGameplayState = new TRVGameplayState();
        bool val_2 = this.SetupQuestionFromLevelData(progress:  this.currentGame);
        val_8 = null;
        val_8 = null;
        if(TRVMainController.noAnswerSelectedCharacter != null)
        {
                val_9 = 0;
        }
        else
        {
                val_9 = MonoSingleton<WordGameEventsController>.Instance.OnTRVQuestionStart(progress:  this.currentGame);
        }
        
        if(val_9 != 0)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void TRVMainController::<StartNextQuestion>b__60_0());
            return;
        }
        
        MonoSingleton<TRVGameplayUI>.Instance.StartGameplay(incData:  this.currentGame);
    }
    public void StartNextQOTDQuestion()
    {
        this.CheckQOTDQuestionSet();
        this.StartNextQuestion();
    }
    public void StartQuiz()
    {
        var val_3;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        this.currentGame.currentGameplayState.quizStartTime = val_1;
        MonoSingleton<TRVGameplayUI>.Instance.UpdateGameState(incData:  this.currentGame);
        if(this.OnQuestionBegin != null)
        {
                this.OnQuestionBegin.Invoke(obj:  this.currentGame);
        }
        
        val_3 = null;
        val_3 = null;
        if(TRVMainController.QAHACK_CORRECT == false)
        {
                return;
        }
        
        this.OnAnswerClicked(selectedAnswer:  this.currentGame.currentQuestionData.<answer>k__BackingField);
    }
    private bool SetupQuestionFromLevelData(TRVQuizProgress progress)
    {
        var val_10;
        QuestionData val_11;
        string val_13;
        System.Collections.Generic.List<TRVQuestionHistory> val_11 = this.currentGame.previousQuestions;
        if()
        {
                val_11 = val_11 + ((W9 - 1) << 3);
            val_10 = 28525.extraLifeUsed;
        }
        else
        {
                val_10 = 0;
        }
        
        if(this.GetExternalFeatureQuestion == null)
        {
            goto label_7;
        }
        
        QuestionData val_3 = this.GetExternalFeatureQuestion.Invoke();
        if(val_3 == null)
        {
            goto label_7;
        }
        
        val_11 = val_3;
        if((val_10 & 1) == 0)
        {
                int val_12 = this.currentGame.quizProgressIndex;
            val_12 = val_12 + 1;
            this.currentGame.quizProgressIndex = val_12;
        }
        
        val_3.imageSp = MonoSingleton<TRVDataParser>.Instance.GetQuestionImageFromID(subCategory:  val_3.<category>k__BackingField, questionID:  val_3.<questionID>k__BackingField);
        progress.currentGameplayState = new TRVGameplayState();
        progress.currentQuestionData = val_11;
        (TRVGameplayState)[1152921517300924624].activeButtons.AddRange(collection:  val_3.<incorrectAnswers>k__BackingField);
        val_13 = val_3.<answer>k__BackingField;
        goto label_18;
        label_7:
        this.currentGame.AdvanceQuiz(extraLifeQuestion:  val_10 & 1);
        val_11 = this.currentGame.currentQuestionData;
        this.currentGame.currentQuestionData.imageSp = MonoSingleton<TRVDataParser>.Instance.GetQuestionImageFromID(subCategory:  progress.quizCategory, questionID:  this.currentGame.currentQuestionData.<questionID>k__BackingField);
        progress.currentQuestionData = this.currentGame.currentQuestionData;
        progress.currentGameplayState.activeButtons.AddRange(collection:  this.currentGame.currentQuestionData.<incorrectAnswers>k__BackingField);
        val_13 = progress.currentQuestionData.<answer>k__BackingField;
        label_18:
        progress.currentGameplayState.activeButtons.Add(item:  val_13);
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        progress.currentGameplayState.quizDuration = val_10.quizDuration;
        return true;
    }
    private void CheckQOTDQuestionSet()
    {
        var val_12;
        System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>, System.Int32> val_14;
        TRVCategorySelectionInfo val_2 = MonoSingleton<TRVQuestionOfTheDayManager>.Instance.GetRandomSubCategory();
        TRVDataParser val_3 = MonoSingleton<TRVDataParser>.Instance;
        val_12 = null;
        val_12 = null;
        val_14 = TRVMainController.<>c.<>9__64_0;
        if(val_14 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>, System.Int32> val_6 = null;
            val_14 = val_6;
            val_6 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>, System.Int32>(object:  TRVMainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVMainController.<>c::<CheckQOTDQuestionSet>b__64_0(System.Collections.Generic.KeyValuePair<int, System.Collections.Generic.List<QuestionData>> x));
            TRVMainController.<>c.<>9__64_0 = val_14;
        }
        
        if((val_3.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  val_2.categoryName).totalQuestionsSeen) != (System.Linq.Enumerable.Sum<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>>(source:  this.currentGame.<myData>k__BackingField.questionData, selector:  val_6)))
        {
                return;
        }
        
        TRVDataParser val_8 = MonoSingleton<TRVDataParser>.Instance;
        TRVSubCategoryProgress val_9 = val_8.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  val_2.categoryName);
        val_9.seenQuestions = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        TRVDataParser val_11 = MonoSingleton<TRVDataParser>.Instance;
        val_11.<playerPersistance>k__BackingField.SaveProgress();
    }
    public void OnAnswerClicked(string selectedAnswer)
    {
        QuestionData val_42;
        System.DateTime val_43;
        var val_44;
        TRVQuizProgress val_45;
        var val_46;
        val_42 = 1152921504616751104;
        val_43 = this.currentGame.currentGameplayState.quizStartTime;
        val_44 = null;
        val_44 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_43}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == true)
        {
                return;
        }
        
        if(this.currentGame.currentGameplayState.hasSelectedAnswer == true)
        {
                return;
        }
        
        this.currentGame.currentGameplayState.activeButtons.Clear();
        this.currentGame.currentGameplayState.selectedAnswer = selectedAnswer;
        if((MonoSingleton<WGFlyoutManager>.Instance.ShowingWindow<TRVAskExpertPopup>()) != true)
        {
                if((MonoSingleton<WGFlyoutManager>.Instance.ShowingWindow<TRVExpertAdvicePopup>()) == false)
        {
            goto label_21;
        }
        
        }
        
        MonoSingleton<WGFlyoutManager>.Instance.CloseCurrentWindow();
        label_21:
        bool val_8 = System.String.op_Equality(a:  selectedAnswer, b:  this.currentGame.currentQuestionData.<answer>k__BackingField);
        if(val_8 != false)
        {
                System.DateTime val_9 = DateTimeCheat.UtcNow;
            System.TimeSpan val_10 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_9.dateData}, d2:  new System.DateTime() {dateData = this.currentGame.currentGameplayState.quizStartTime});
            float val_41 = (float)val_10._ticks.TotalSeconds;
            val_41 = this.currentGame.currentGameplayState.quizDuration - (UnityEngine.Mathf.Max(a:  0f, b:  val_41));
            this.currentGame.currentGameplayState.pointsEarned = UnityEngine.Mathf.CeilToInt(f:  UnityEngine.Mathf.Min(a:  this.currentGame.currentGameplayState.quizDuration, b:  val_41));
            if((TRVCategoryRankController.CanRankUpCategory(subCategory:  this.currentGame.quizCategory)) != false)
        {
                TRVDataParser val_16 = MonoSingleton<TRVDataParser>.Instance;
            TRVSubCategoryProgress val_17 = val_16.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  this.currentGame.quizCategory);
            .categoryName = this.currentGame.quizCategory;
            .rank = val_17.rank;
            .lastRankProgress = TRVCategoryRankController.GetCategoryProcess(subcategoryProgress:  val_17);
            TRVCategoryRankController.ProcessCategoryRank(categoryName:  this.currentGame.quizCategory, subcategoryProgress:  val_17);
            .currentRankProgress = TRVCategoryRankController.GetCategoryProcess(subcategoryProgress:  val_17);
            this.currentGame.categoryRankProgress = new TRVCategoryRankProgress();
        }
        
            WGAudioController val_21 = MonoSingleton<WGAudioController>.Instance;
            val_21.sound.PlayGameSpecificSound(id:  "TRVQuestionCorrect", clipIndex:  0);
            TRVDataParser val_22 = MonoSingleton<TRVDataParser>.Instance;
            int val_42 = val_22.<playerPersistance>k__BackingField.totalCorrectQuestions;
            val_42 = val_42 + 1;
            val_22.<playerPersistance>k__BackingField.totalCorrectQuestions = val_42;
        }
        else
        {
                if((System.String.op_Inequality(a:  selectedAnswer, b:  "!")) != false)
        {
                WGAudioController val_24 = MonoSingleton<WGAudioController>.Instance;
            val_24.sound.PlayGameSpecificSound(id:  "TRVQuestionIncorrect", clipIndex:  0);
        }
        
        }
        
        if(WGTimelineTracker._instance != 0)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_26 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_26.Add(key:  "id", value:  this.currentGame.currentQuestionData.<questionID>k__BackingField);
            val_26.Add(key:  "category", value:  this.currentGame.quizCategory);
            val_26.Add(key:  "difficulty", value:  this.currentGame.currentQuestionData.<difficulty>k__BackingField);
            val_26.Add(key:  "question", value:  this.currentGame.currentQuestionData.<question>k__BackingField);
            val_26.Add(key:  "answer", value:  this.currentGame.currentQuestionData.<answer>k__BackingField);
            val_26.Add(key:  "user_answer", value:  selectedAnswer);
            var val_27 = (((WGTimelineTracker.__il2cppRuntimeField_typeHierarchy + (TRVTimelineTracker.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? WGTimelineTracker._instance : 0;
        }
        
        MonoSingleton<TRVGameplayUI>.Instance.UpdateGameState(incData:  this.currentGame);
        val_45 = this.currentGame;
        if(((this.currentGame + (((WGTimelineTracker.__il2cppRuntimeField_typeHierarchy + (TRVTimelineTracker.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 - 1)) << 3).currentGameplayState.extraLifeUsed) != false)
        {
                TRVQuizProgress val_43 = this.currentGame;
            if(val_43 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_43 = val_43 + ((val_43 - 1) << 3);
            val_46 = (~((this.currentGame + ((this.currentGame - 1)) << 3).currentGameplayState.answeredCorrectly)) & 1;
        }
        else
        {
                val_46 = 0;
        }
        
        val_45 = this.currentGame;
        var val_32 = (val_46 != 0) ? 1 : 0;
        val_42 = this.currentGame.currentQuestionData;
        int val_44 = (TRVQuestionHistory)[1152921517301823296].extraLivesUsed;
        bool val_34 = val_8;
        val_44 = val_44 + val_32;
        .extraLivesUsed = val_44;
        if(val_32 != 0)
        {
                object[] val_35 = new object[1];
            val_42 = val_34;
            val_35[0] = val_42;
            UnityEngine.Debug.LogErrorFormat(format:  "This WAS an extra life question and was answered: {0}", args:  val_35);
            if(val_34 != false)
        {
                TRVDataParser val_36 = MonoSingleton<TRVDataParser>.Instance;
            int val_45 = val_36.<playerPersistance>k__BackingField.totalCorrectQuestions;
            val_45 = val_45 - 1;
            val_36.<playerPersistance>k__BackingField.totalCorrectQuestions = val_45;
        }
        
            TRVDataParser val_37 = MonoSingleton<TRVDataParser>.Instance;
            int val_46 = val_37.<playerPersistance>k__BackingField.totalSeenQuestions;
            val_46 = val_46 - 1;
            val_37.<playerPersistance>k__BackingField.totalSeenQuestions = val_46;
        }
        
        this.currentGame.previousQuestions.Add(item:  new TRVQuestionHistory(prevState:  this.currentGame.currentGameplayState, qd:  val_42));
        TRVQuizProgress val_47 = this.currentGame;
        val_43 = this.currentGame.previousQuestions;
        if(val_47 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_47 = val_47 + ((val_47 - 1) << 3);
        mem2[0] = 0;
        UnityEngine.Coroutine val_40 = this.StartCoroutine(routine:  this.displayAnswerResult(correct:  val_34));
        if(this.OnQuestionAnswered == null)
        {
                return;
        }
        
        this.OnQuestionAnswered.Invoke(obj:  val_34);
    }
    private System.Collections.IEnumerator displayAnswerResult(bool correct)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .correct = correct;
        return (System.Collections.IEnumerator)new TRVMainController.<displayAnswerResult>d__66();
    }
    public bool PurchaseExtraLife(bool updateGems = True, bool addExtraLife = False)
    {
        bool val_10;
        var val_11;
        var val_12;
        string val_13;
        val_10 = addExtraLife;
        Player val_1 = App.Player;
        val_11 = 1152921517052171200;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1._gems < val_2.extraLifeCost)
        {
                val_12 = 0;
            return (bool)val_12;
        }
        
        if((System.String.IsNullOrEmpty(value:  this.currentGame.associatedEventID)) != false)
        {
                val_13 = "Extra Life";
        }
        else
        {
                val_13 = this.currentGame.associatedEventID;
        }
        
        val_11 = App.Player;
        TRVEcon val_5 = App.GetGameSpecificEcon<TRVEcon>();
        val_11.AddGems(amount:  -val_5.extraLifeCost, source:  mem[this.currentGame.associatedEventID], subsource:  0);
        TRVDataParser val_6 = MonoSingleton<TRVDataParser>.Instance;
        val_6.<playerPersistance>k__BackingField.AddFreeLife(addExtraLife:  val_10);
        TRVQuizProgress val_10 = this.currentGame;
        val_10 = this.currentGame.previousQuestions;
        if(val_10 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + ((val_10 - 1) << 3);
        val_12 = 1;
        mem2[0] = val_12;
        if(updateGems == false)
        {
                return (bool)val_12;
        }
        
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        val_12 = 1;
        return (bool)val_12;
    }
    public void OnExtraLifeClicked()
    {
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_1.<playerPersistance>k__BackingField.UseFreeLife(usedAtTime:  new System.DateTime() {dateData = val_2.dateData});
        TRVQuizProgress val_5 = this.currentGame;
        if(val_5 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((val_5 - 1) << 3);
        mem2[0] = (DateTimeCheat.__il2cppRuntimeField_12F + 1);
    }
    public void RerollCategory(System.Action onRerollSuccess, System.Action onRerollFailed)
    {
        var val_11;
        var val_12;
        var val_13;
        val_11 = onRerollSuccess;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) > 9)
        {
            goto label_5;
        }
        
        if(val_11 != null)
        {
            goto label_6;
        }
        
        return;
        label_5:
        Player val_2 = App.Player;
        val_12 = 1152921517052171200;
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_2._gems >= val_3.categoryRerollCost)
        {
            goto label_12;
        }
        
        val_13 = null;
        val_13 = null;
        PurchaseProxy.currentPurchasePoint = 92;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        GameBehavior val_5 = App.getBehavior;
        val_11 = val_5.<metaGameBehavior>k__BackingField;
        val_11.Init(outOfCredits:  true, onCloseAction:  new System.Action(object:  this, method:  System.Void TRVMainController::<RerollCategory>b__69_0()));
        if(onRerollFailed == null)
        {
                return;
        }
        
        goto label_24;
        label_12:
        TRVEcon val_9 = App.GetGameSpecificEcon<TRVEcon>();
        App.Player.AddGems(amount:  -val_9.categoryRerollCost, source:  "Category Reroll", subsource:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        if(val_11 == null)
        {
                return;
        }
        
        label_6:
        label_24:
        val_11.Invoke();
    }
    public void RerollQuestion(int cost, float remainingTime)
    {
        string val_12;
        if(cost >= 1)
        {
                if((System.String.IsNullOrEmpty(value:  this.currentGame.associatedEventID)) != false)
        {
                val_12 = "Reroll Question";
        }
        else
        {
                val_12 = this.currentGame.associatedEventID;
        }
        
            App.Player.AddGems(amount:  -cost, source:  mem[this.currentGame.associatedEventID], subsource:  0);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        }
        
        MonoSingleton<TRVGameplayUI>.Instance.HideTimer();
        MonoSingleton<TRVGameplayUI>.Instance.StopTimer();
        MonoSingleton<TRVGameplayUI>.Instance.FadeOutPowerups();
        MonoSingleton<TRVGameplayUI>.Instance.HideQuestionButtons();
        this.currentGame.currentGameplayState = new TRVGameplayState();
        bool val_9 = this.SetupQuestionFromLevelData(progress:  this.currentGame);
        this.currentGame.rerollQuestionUsed = true;
        this.currentGame.currentGameplayState.rerollQuestionPowerupUsed = true;
        if(cost <= 0)
        {
                this.currentGame.currentGameplayState.freererollQuestionPowerupUsed = true;
        }
        
        System.DateTime val_10 = DateTimeCheat.UtcNow;
        this.currentGame.currentGameplayState.quizStartTime = val_10;
        float val_12 = 1f;
        val_12 = remainingTime + val_12;
        this.currentGame.currentGameplayState.quizDuration = val_12;
        MonoSingleton<TRVGameplayUI>.Instance.StartGameplay(incData:  this.currentGame);
        this.TrackLevelStart();
    }
    public void ProcessQuizComplete(bool success)
    {
        var val_24;
        var val_25;
        var val_26;
        this.CheckShouldShowLowGems();
        bool val_1 = this.IsPlayingChallenge;
        if(success == false)
        {
            goto label_1;
        }
        
        if(val_1 == true)
        {
            goto label_48;
        }
        
        if((this.currentGame & 1) != 0)
        {
                Player val_3 = App.Player + 1;
        }
        
        TRVDataParser val_4 = MonoSingleton<TRVDataParser>.Instance;
        TRVSubCategoryProgress val_5 = val_4.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  this.currentGame.quizCategory);
        int val_24 = val_5.quizzesComplete;
        val_24 = val_24 + 1;
        val_5.quizzesComplete = val_24;
        if(this.currentGame.incorrecctAnswers == 0)
        {
                int val_25 = val_5.crownsCollected;
            val_25 = val_25 + 1;
            val_5.crownsCollected = val_25;
        }
        
        MonoSingleton<TRVUtils>.Instance.Init(forceUpdate:  true);
        GameBehavior val_8 = App.getBehavior;
        if((val_8.<metaGameBehavior>k__BackingField) < 10)
        {
            goto label_23;
        }
        
        GameBehavior val_9 = App.getBehavior;
        if(0 != 0)
        {
            goto label_28;
        }
        
        label_23:
        val_24 = null;
        val_24 = null;
        val_25 = null;
        val_25 = null;
        GameBehavior val_10 = App.getBehavior;
        App.trackerManager.track(eventName:  Events.LEVEL_REACHED + "_" + val_10.<metaGameBehavior>k__BackingField.ToString()(val_10.<metaGameBehavior>k__BackingField.ToString()), data:  this.TrackLevelEnd(levelToTrack:  this.currentGame, abortedQuiz:  false));
        label_28:
        if((MonoSingleton<LimitedTimeBundlesManager>.Instance) == 0)
        {
            goto label_48;
        }
        
        MonoSingleton<LimitedTimeBundlesManager>.Instance.OnLevelComplete();
        goto label_48;
        label_1:
        if(val_1 != true)
        {
                TRVDataParser val_17 = MonoSingleton<TRVDataParser>.Instance;
            TRVSubCategoryProgress val_18 = val_17.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  this.currentGame.quizCategory);
            int val_26 = val_18.quizzesComplete;
            val_26 = val_26 + 1;
            val_18.quizzesComplete = val_26;
            this.RewardMultiPicked(multi:  1);
        }
        
        label_48:
        if(this.OnQuizComplete != null)
        {
                if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != true)
        {
                this.OnQuizComplete.Invoke(arg1:  success, arg2:  this.currentGame);
        }
        
        }
        
        TRVDataParser val_22 = MonoSingleton<TRVDataParser>.Instance;
        val_22.<playerPersistance>k__BackingField.SaveProgress();
        this.currentGame.quizCompleted = true;
        val_26 = null;
        val_26 = null;
        App.trackerManager.track(eventName:  "TRV Level Complete", data:  this.TrackLevelEnd(levelToTrack:  this.currentGame, abortedQuiz:  false));
    }
    public void RemoveTwo(int cost, float remainingTime)
    {
        string val_19;
        var val_20;
        var val_21;
        if(cost >= 1)
        {
                val_19 = "50/50 Powerup";
            if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != false)
        {
                val_19 = "Question of the Day";
        }
        else
        {
                if((System.String.IsNullOrEmpty(value:  this.currentGame.associatedEventID)) != true)
        {
                val_19 = this.currentGame.associatedEventID;
        }
        
        }
        
            App.Player.AddGems(amount:  -cost, source:  val_19, subsource:  0);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        }
        
        System.Collections.Generic.List<System.String> val_6 = new System.Collections.Generic.List<System.String>();
        val_6.AddRange(collection:  this.currentGame.currentGameplayState.activeButtons);
        QuestionData val_19 = this.currentGame.currentQuestionData;
        bool val_7 = val_6.Remove(item:  this.currentGame.currentQuestionData.<answer>k__BackingField);
        int val_8 = UnityEngine.Random.Range(min:  0, max:  this.currentGame.currentQuestionData.<answer>k__BackingField);
        if(val_19 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = val_19 + (val_8 << 3);
        bool val_9 = val_6.Remove(item:  (this.currentGame.currentQuestionData + (val_8) << 3).<difficulty>k__BackingField);
        TRVGameplayState val_20 = this.currentGame.currentGameplayState;
        bool val_10 = this.currentGame.currentGameplayState.activeButtons.Remove(item:  (this.currentGame.currentQuestionData + (val_8) << 3).<difficulty>k__BackingField);
        int val_11 = UnityEngine.Random.Range(min:  0, max:  (this.currentGame.currentQuestionData + (val_8) << 3).<difficulty>k__BackingField);
        if(val_20 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_20 + (val_11 << 3);
        bool val_12 = val_6.Remove(item:  (this.currentGame.currentGameplayState + (val_11) << 3).selectedAnswer);
        bool val_13 = this.currentGame.currentGameplayState.activeButtons.Remove(item:  (this.currentGame.currentGameplayState + (val_11) << 3).selectedAnswer);
        int val_21 = this.currentGame.currentGameplayState.hintsUsed;
        val_21 = val_21 + 1;
        this.currentGame.currentGameplayState.hintsUsed = val_21;
        if(cost <= 0)
        {
                int val_22 = this.currentGame.currentGameplayState.freehintsUsed;
            val_22 = val_22 + 1;
            this.currentGame.currentGameplayState.freehintsUsed = val_22;
        }
        
        this.currentGame.removeTwoHintUsed = true;
        Player val_14 = App.Player;
        int val_23 = val_14.properties.LifetimeHints;
        val_23 = val_23 + 1;
        val_14.properties.LifetimeHints = val_23;
        System.DateTime val_15 = DateTimeCheat.UtcNow;
        this.currentGame.currentGameplayState.quizStartTime = val_15;
        float val_24 = 1f;
        val_24 = remainingTime + val_24;
        this.currentGame.currentGameplayState.quizDuration = val_24;
        MonoSingleton<TRVGameplayUI>.Instance.UpdateGameState(incData:  this.currentGame);
        val_20 = null;
        val_20 = null;
        App.trackerManager.track(eventName:  Events.HINT_USED);
        val_21 = null;
        val_21 = null;
        Player val_17 = App.Player;
        App.trackerManager.track(eventName:  System.String.Format(format:  "{0}_{1}", arg0:  Events.HINT_USED, arg1:  val_17.properties.LifetimeHints));
    }
    public void ConcludeQuestionComplete()
    {
        MetaGameBehavior val_19;
        int val_20;
        TRVQuizProgress val_21;
        val_19 = this;
        if(this.currentGame.previousQuestions == null)
        {
            goto label_3;
        }
        
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        val_20 = val_1.currentGame.quizLength;
        System.Collections.Generic.List<TRVQuestionHistory> val_2 = this.currentGame.countedAnswerData;
        val_21 = this.currentGame;
        if(this.currentGame.quizCompleted == false)
        {
            goto label_12;
        }
        
        val_21 = this.currentGame;
        if(val_21.countedAnswers >= this.currentGame.correctAnswerRequirement)
        {
            goto label_14;
        }
        
        label_12:
        if(((this.currentGame.correctAnswerRequirement - this.currentGame.countedAnswers) <= (val_20 - W22)) || (this.currentGame.quizCompleted == true))
        {
            goto label_16;
        }
        
        val_20 = val_21 - 1;
        if(val_21 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_21 = val_21 + (val_20 << 3);
        if(((this.currentGame + ((this.currentGame - 1)) << 3).currentGameplayState.extraLifeUsed) == false)
        {
            goto label_20;
        }
        
        label_16:
        bool val_8 = this.IsOutOfQuestions();
        if(val_8 == false)
        {
            goto label_21;
        }
        
        val_8.ShowOutOfQuestionsPopup(showFlyout:  false);
        goto label_22;
        label_3:
        MonoSingleton<TRVGameplayUI>.Instance.StartGameplay(incData:  this.currentGame);
        WGAudioController val_10 = MonoSingleton<WGAudioController>.Instance;
        val_10.music.Play(type:  1, trackIndex:  0);
        return;
        label_14:
        if(this.ShowLevelComplete == null)
        {
            goto label_32;
        }
        
        if(this.ShowLevelComplete.Invoke() == true)
        {
                return;
        }
        
        goto label_32;
        label_21:
        this.StartNextQuestion();
        return;
        label_20:
        if(this.ShowLevelFailed != null)
        {
                if(this.ShowLevelFailed.Invoke() != false)
        {
                return;
        }
        
        }
        
        this.ProcessQuizComplete(success:  false);
        label_32:
        TRVDataParser val_13 = MonoSingleton<TRVDataParser>.Instance;
        val_13.<playerPersistance>k__BackingField.getCurrentAvailableCategories = new System.Collections.Generic.List<System.String>();
        GameBehavior val_15 = App.getBehavior;
        val_19 = val_15.<metaGameBehavior>k__BackingField;
        label_22:
        WGAudioController val_17 = MonoSingleton<WGAudioController>.Instance;
        val_17.music.FadeOutMusic();
    }
    public void AbortChallenge()
    {
        if(this.ShowLevelFailed == null)
        {
                return;
        }
        
        bool val_1 = this.ShowLevelFailed.Invoke();
    }
    public void AbortQuiz()
    {
        var val_3;
        this.CheckShouldShowLowGems();
        if(this.currentGame == null)
        {
                return;
        }
        
        if(this.currentGame.quizCompleted != false)
        {
                return;
        }
        
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.FadeOutMusic();
        val_3 = null;
        val_3 = null;
        App.trackerManager.track(eventName:  "TRV Level Complete", data:  this.TrackLevelEnd(levelToTrack:  this.currentGame, abortedQuiz:  true));
    }
    public bool IsOutOfQuestions()
    {
        UnityEngine.Object val_12;
        var val_13;
        bool val_15;
        TRVDataParser val_1 = MonoSingleton<TRVDataParser>.Instance;
        val_12 = MonoSingleton<TRVSpecialCategoriesManager>.Instance;
        if(val_12 != 0)
        {
                if((MonoSingleton<TRVSpecialCategoriesManager>.Instance.IsSpecialQuiz(subCategoryName:  this.currentGame.quizCategory)) == true)
        {
            goto label_27;
        }
        
        }
        
        val_13 = null;
        val_13 = null;
        val_12 = TRVMainController.<>c.<>9__76_0;
        if(val_12 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>, System.Int32> val_7 = null;
            val_12 = val_7;
            val_7 = new System.Func<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>, System.Int32>(object:  TRVMainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVMainController.<>c::<IsOutOfQuestions>b__76_0(System.Collections.Generic.KeyValuePair<int, System.Collections.Generic.List<QuestionData>> x));
            TRVMainController.<>c.<>9__76_0 = val_12;
        }
        
        if((System.Linq.Enumerable.Sum<System.Collections.Generic.KeyValuePair<System.Int32, System.Collections.Generic.List<QuestionData>>>(source:  this.currentGame.<myData>k__BackingField.questionData, selector:  val_7)) == (val_1.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  this.currentGame.quizCategory).totalQuestionsSeen))
        {
                val_2.isFinished = true;
            TRVDataParser val_10 = MonoSingleton<TRVDataParser>.Instance;
            val_10.<playerPersistance>k__BackingField.SaveProgress();
            TRVDataParser val_11 = MonoSingleton<TRVDataParser>.Instance;
            val_15 = true;
            val_11.<ForceUpdateSubCategories>k__BackingField = val_15;
            return (bool)val_15;
        }
        
        label_27:
        val_15 = 0;
        return (bool)val_15;
    }
    public void ShowOutOfQuestionsPopup(bool showFlyout = False)
    {
        if(showFlyout != false)
        {
                GameBehavior val_1 = App.getBehavior;
            null = val_1.<metaGameBehavior>k__BackingField;
        }
        else
        {
                GameBehavior val_2 = App.getBehavior;
        }
    
    }
    public void RewardMultiPicked(int multi)
    {
        var val_32;
        int val_33;
        var val_34;
        int val_35;
        var val_36;
        var val_37;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        val_32 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "total points gained ", value:  this.currentGame.totalPointsGained);
        val_3.Add(key:  "correct answers ", value:  this.currentGame.correctAnswers);
        TRVEcon val_6 = App.GetGameSpecificEcon<TRVEcon>();
        val_3.Add(key:  "Quiz Start Cost Multiplier", value:  System.String.Format(format:  "x{0}", arg0:  val_6.variableMultipliers[TRVMainController.currentMultiplier]));
        val_3.Add(key:  "Streak Bonus", value:  MonoSingleton<TRVStreakManager>.Instance.GetBonusStarReward());
        val_3.Add(key:  "Multiplier Redraw", value:  this.currentGame.hasRerolledChest);
        val_33 = this.currentGame.GetQuizBaseStarReward();
        if(this.currentGame.successfullyCompletedQuiz != false)
        {
                val_34 = 1152921504619999232;
            val_33 = ((MonoSingleton<TRVStreakManager>.Instance.GetBonusStarReward()) + val_33) * multi;
            val_35 = this.currentGame.GetQuizBaseReward() * multi;
        }
        else
        {
                val_35 = 0;
            val_34 = 1152921504619999232;
        }
        
        val_36 = null;
        val_36 = null;
        if(TRVMainController.noAnswerSelectedCharacter == null)
        {
            goto label_31;
        }
        
        val_37 = null;
        val_37 = null;
        if(TRVMainController.noAnswerSelectedCharacter != 3)
        {
            goto label_37;
        }
        
        label_31:
        int val_17 = val_33 * val_1.variableMultipliers[TRVMainController.currentMultiplier];
        val_3.Add(key:  "Quiz Start Cost Bonus", value:  val_17 - val_33);
        val_33 = val_17;
        label_37:
        if(this.currentGame.hasCollectedChest != true)
        {
                MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  val_33, source:  "TRV Quiz Complete", subSource:  0, additionalParam:  val_3);
            if(val_35 >= 1)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_20 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_20.Add(key:  "Multiplier Redraw", value:  this.currentGame.hasRerolledChest);
            val_20.Add(key:  "Level Entry Cost", value:  App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost);
            decimal val_24 = System.Decimal.op_Implicit(value:  0);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid}, source:  "TRVQuizComplete", subSource:  0, externalParams:  val_20, doTrack:  true);
        }
        
        }
        
        this.currentGame.hasCollectedChest = true;
        this.currentGame.finalStarReward = val_33;
        this.currentGame.finalCoinReward = val_35;
        this.currentGame.selectedMulitplier = multi;
        UnityEngine.Coroutine val_26 = this.StartCoroutine(routine:  this.EventLevelComplete());
        MonoSingleton<GameEventsManager>.Instance.CheckAndRequestServerEvents();
        if((MonoSingleton<TRVPromoCategoriesHandler>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<TRVPromoCategoriesHandler>.Instance.RequestPromosFromServer();
    }
    private System.Collections.IEnumerator EventLevelComplete()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVMainController.<EventLevelComplete>d__79();
    }
    private void TrackLevelStart()
    {
        string val_16;
        string val_17;
        string val_18;
        TRVQuizProgress val_19;
        var val_20;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_16 = 1152921504619999232;
        val_1.Add(key:  "Level", value:  this.currentGame.quizLevel);
        val_1.Add(key:  "Number of Questions", value:  this.currentGame.quizLength);
        if((System.String.op_Equality(a:  this.currentGame.quizCategory, b:  "QOTD_AllQuestions")) != false)
        {
                val_17 = "Question of the Day";
        }
        else
        {
                val_17 = this.currentGame.quizCategory;
        }
        
        val_1.Add(key:  "Category", value:  mem[this.currentGame.quizCategory]);
        Player val_3 = App.Player;
        val_1.Add(key:  "Coins", value:  val_3._credits);
        val_1.Add(key:  "Quiz Start Cost", value:  App.GetGameSpecificEcon<TRVEcon>().dynamicQuizEntryCost);
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != true)
        {
                val_1.Add(key:  "Trivia Masters", value:  this.currentGame.associatedEventID.Equals(value:  "TriviaMasters"));
            if((TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID != null) && ((System.String.IsNullOrEmpty(value:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32)) != true))
        {
                val_18 = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID;
            val_16 = "Crazy Category";
            if(val_18 != null)
        {
                val_18 = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32.Equals(value:  this.currentGame.quizCategory);
        }
        
            val_1.Add(key:  val_16, value:  val_18);
        }
        
            val_1.Add(key:  "Trivia Pursuit", value:  this.currentGame.associatedEventID.Equals(value:  "TriviaPursuit"));
            val_19 = this.currentGame;
            if(val_19 != null)
        {
                val_19 = 0;
        }
        
            val_1.Add(key:  "Special Categories", value:  null);
        }
        
        val_20 = null;
        val_20 = null;
        App.trackerManager.track(eventName:  "TRV Level Start", data:  val_1);
    }
    private System.Collections.Generic.Dictionary<string, object> TrackLevelEnd(TRVQuizProgress levelToTrack, bool abortedQuiz = False)
    {
        string val_48;
        UnityEngine.Object val_57;
        var val_58;
        var val_59;
        ChestType val_60;
        string val_61;
        string val_62;
        System.Collections.Generic.Dictionary<TKey, TValue> val_63;
        string val_64;
        TRVQuizProgress val_65;
        var val_66;
        bool val_67;
        TRVQuizProgress val_68;
        System.Collections.Generic.List<TRVQuestionHistory> val_69;
        object val_70;
        System.Collections.Generic.Dictionary<TKey, TValue> val_71;
        val_58 = levelToTrack;
        if(val_58 == null)
        {
            goto label_1;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Level", value:  levelToTrack.quizLevel);
        val_59 = 1152921504884269056;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Coins", value:  val_2._credits);
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Total Stars", value:  val_3._stars);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = this.currentGame.totalPointsGained;
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Stars Earned", value:  this.currentGame.correctAnswers * val_60);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        int val_7 = this.currentGame.extraLivesUsedThisQuiz;
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_7, value:  val_7);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = this.currentGame.hintsUsedThisQuiz;
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Total Hints Used", value:  this.currentGame.rerollsUsedThisQuiz + val_60);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  this.currentGame.quizCategory, b:  "QOTD_AllQuestions")) == false)
        {
            goto label_18;
        }
        
        val_61 = "Question of the Day";
        if(val_1 != 0)
        {
            goto label_19;
        }
        
        throw new NullReferenceException();
        label_18:
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        val_61 = this.currentGame.quizCategory;
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_19:
        val_1.Add(key:  "Category", value:  mem[this.currentGame.quizCategory]);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Level Success", value:  this.currentGame.successfullyCompletedQuiz);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "50/50 Hint Used", value:  this.currentGame.hintsUsedThisQuiz);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Free 50/50 Hint Used", value:  this.currentGame.freeHintWasUsedThisQuiz);
        if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = this.currentGame.myChest;
        val_62 = val_60;
        if(val_60 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = val_60;
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Chest Type", value:  val_60.ToString());
        TRVEcon val_18 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Quiz Start Cost", value:  val_18.dynamicQuizEntryCost);
        val_63 = 1152921515677551360;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance) != 0)
        {
                TRVQuestionOfTheDayManager val_22 = MonoSingleton<TRVQuestionOfTheDayManager>.Instance;
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            val_64 = 0;
            if(val_22.IsPlaying() != true)
        {
                val_65 = this.currentGame;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_64 = "Reroll Question Hint Used";
            val_1.Add(key:  val_64, value:  val_65.rerollsUsedThisQuiz);
            val_65 = this.currentGame;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_64 = "Free Reroll Question Hint Used";
            val_65 = val_1;
            val_1.Add(key:  val_64, value:  val_65.freeRerollWasUsedThisQuiz);
            if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
            val_65 = this.currentGame.associatedEventID;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_64 = "Trivia Masters";
            val_65 = val_1;
            val_1.Add(key:  val_64, value:  val_65.Equals(value:  "TriviaMasters"));
            val_63 = 1152921504964620288;
            if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID != null)
        {
                val_65 = mem[TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32];
            val_65 = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32;
            val_60 = "Crazy Category";
            val_64 = 0;
            if((System.String.IsNullOrEmpty(value:  val_65)) != false)
        {
                val_66 = 1152921504615792640;
            val_67 = 0;
        }
        else
        {
                if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                throw new NullReferenceException();
        }
        
            val_66 = 1152921504615792640;
            if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
            val_67 = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32.Equals(value:  this.currentGame.quizCategory);
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_65 = val_1;
            val_64 = val_60;
            val_1.Add(key:  val_64, value:  val_67);
        }
        
            if(this.currentGame == null)
        {
                throw new NullReferenceException();
        }
        
            val_65 = this.currentGame.associatedEventID;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_1.Add(key:  "Trivia Pursuit", value:  val_65.Equals(value:  "TriviaPursuit"));
            val_68 = this.currentGame;
            if(val_68 != null)
        {
                val_68 = 0;
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_64 = "Special Categories";
            val_1.Add(key:  val_64, value:  ( != 0) ? 1 : 0);
            val_65 = this.currentGame;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_64 = "Expert Hints Used";
            val_1.Add(key:  val_64, value:  val_65.expertHintWasUsed);
            val_65 = this.currentGame;
            if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_1.Add(key:  "Free Expert Hint Used", value:  val_65.freeexpertHintWasUsed);
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_38 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_60 = levelToTrack.previousQuestions;
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62 = "Out Of Time";
        val_59 = 0;
        var val_59 = 4;
        label_97:
        val_63 = val_59 - 4;
        if(val_63 >= 1152921510196879024)
        {
            goto label_73;
        }
        
        if(1152921510196879024 <= val_63)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if(levelToTrack.previousQuestions == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = GetTrackingData();
        if(1152921510196879024 <= val_63)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if(answeredCorrectly == false)
        {
            goto label_79;
        }
        
        bool val_57 = abortedQuiz;
        if(val_57 == false)
        {
            goto label_83;
        }
        
        val_69 = levelToTrack.previousQuestions;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57 = val_57 - 1;
        if(val_63 == val_57)
        {
            goto label_82;
        }
        
        goto label_83;
        label_79:
        val_69 = levelToTrack.previousQuestions;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        label_82:
        if(1152921510196879024 <= val_63)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        val_59 = 1;
        val_70 = val_62;
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60.Add(key:  "Failed", value:  null);
        label_83:
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        val_38.Add(key:  System.String.Format(format:  "Q{0}", arg0:  val_59 - 3), value:  val_60);
        val_60 = levelToTrack.previousQuestions;
        val_59 = val_59 + 1;
        if(val_60 != null)
        {
            goto label_97;
        }
        
        throw new NullReferenceException();
        label_73:
        val_63 = val_1;
        object val_43 = val_59 & 1;
        if(val_63 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_62, value:  val_43);
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  "Question Data", value:  val_38);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_44 = val_58.GetAdditionalTrackingInfo();
        val_58 = val_44;
        if((val_44 == null) || (val_58.Count < 1))
        {
            goto label_101;
        }
        
        Dictionary.KeyCollection<TKey, TValue> val_46 = val_58.Keys;
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_47 = val_46.GetEnumerator();
        val_60 = 1152921510222861648;
        val_62 = 1152921504758390784;
        val_59 = 1152921510214912464;
        label_110:
        if(val_43.MoveNext() == false)
        {
            goto label_103;
        }
        
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_63 = val_48;
        if((val_1.ContainsKey(key:  val_63)) == false)
        {
            goto label_105;
        }
        
        UnityEngine.Debug.LogError(message:  "attempting to add duplicate level end tracking key of " + val_63);
        goto label_110;
        label_105:
        if(val_1 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_63, value:  val_58.Item[val_63]);
        goto label_110;
        label_103:
        val_58 = 0;
        val_43.Dispose();
        if(val_58 != 0)
        {
            goto label_111;
        }
        
        label_101:
        if(this.currentGame == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.currentGame + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_64 = "QOTD_AllQuestions";
        if((this.currentGame + 16.Equals(value:  val_64)) != true)
        {
                if(this.currentGame == 0)
        {
                throw new NullReferenceException();
        }
        
            if((this.currentGame + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
            if(((this.currentGame + 40 + 32) == 0) && ((this.currentGame + 128) != 0))
        {
                val_65 = val_1;
            if(val_65 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_1.Add(key:  "Difficulty 0 Exhausted", value:  this.currentGame + 16);
        }
        
        }
        
        val_58 = 1152921504893161472;
        val_63 = 1152921515418697360;
        val_57 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_57 != 0)
        {
                WordGameEventsController val_56 = MonoSingleton<WordGameEventsController>.Instance;
            if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
            val_56.AppendLevelCompleteData(curData: ref  val_1);
        }
        
        val_71 = val_1;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_71;
        label_111:
        val_65 = val_58;
        val_64 = 0;
        throw val_65;
        label_1:
        val_71 = 0;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)val_71;
    }
    public TRVMainController()
    {
        this.numCategoriesSelection = 3;
    }
    private static TRVMainController()
    {
    
    }
    private void <StartNextQuestion>b__60_0()
    {
        MonoSingleton<TRVGameplayUI>.Instance.StartGameplay(incData:  this.currentGame);
    }
    private void <RerollCategory>b__69_0()
    {
        this.Init(currentlySelectedCategores:  0, fromReroll:  false);
    }

}
