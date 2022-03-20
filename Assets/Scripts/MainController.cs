using UnityEngine;
public class MainController : MonoBehaviour
{
    // Fields
    public const string ON_BEFORE_LEVEL_START = "OnBeforeLevelStart";
    protected GameMode gameMode;
    protected bool isGameComplete;
    protected GameLevel gameLevel;
    private UGUIGenericCoinsGainedAnim coin_stat_view_anim;
    private UnityEngine.GameObject coin_stat_view_plus;
    protected UnityEngine.GameObject extra_words_group;
    protected UnityEngine.UI.Text levelNameText;
    protected UnityEngine.GameObject levelNameGroup;
    protected UnityEngine.UI.Text topRightInfoText;
    protected UnityEngine.GameObject topRightInfoGroup;
    protected UnityEngine.GameObject goldenApplesGroup;
    protected UnityEngine.GameObject goldenMultiplierGroup;
    protected UnityEngine.UI.Image levelLabel_hard;
    protected UnityEngine.GameObject hintButton;
    protected ToggleEnabledByPlayerLevel howToPlayButton;
    protected EventButtonPanel eventButtonPanel;
    private float levelCompleteDelay;
    protected static WGDailyChallengeMainController _challengeInstance;
    private static MainController _mainInstance;
    public UnityEngine.Camera mainCamera;
    public UnityEngine.Events.UnityEvent onBeforeLevelComplete;
    public UnityEngine.Events.UnityEvent onLevelComplete;
    private const string prefs_tracking_key = "level_tracking";
    private int hintsUsed;
    private int extraWordsFound;
    private string wordsCompleted;
    private int shufflesUsed;
    private bool freeHintUsed;
    private int pickerHintsUsed;
    private int megarHintsUsed;
    private int trialHintsUsed;
    private int struggleHintsUsed;
    private bool struggleHintProvided;
    private const string extra_words_prefs_key = "xtra_word_levels";
    private string currentLanguage;
    private string currentLevelWord;
    private int <ExtraRequiredWordsUsed>k__BackingField;
    private bool <ExtraRequiredWordsPostPurchase>k__BackingField;
    
    // Properties
    public GameLevel GetCurrentGameLevel { get; }
    public UnityEngine.GameObject LevelNameGroup { get; }
    public EventButtonPanel EventButtonPanel { get; }
    public float GetLevelCompleteDelay { get; }
    public static MainController instance { get; }
    public bool IsChapterComplete { get; }
    public bool SpanishInfinityMode { get; }
    public bool IsLevelComplete { get; }
    public bool CompletedAllKnownLevels { get; }
    private MainController.GameModeForTracking CurrentGameModeForTracking { get; }
    private string CurrentLanguageForTracking { get; }
    public virtual int HintsUsed { get; set; }
    public virtual int HintsUsedPicker { get; set; }
    public int HintsUsedMega { get; set; }
    public int ExtraWordsFound { get; set; }
    public string WordsCompleted { get; set; }
    public int ShufflesUsed { get; set; }
    public bool FreeHintsUsed { get; set; }
    public virtual int TrialHintsUsed { get; set; }
    public int StruggleHintsUsed { get; set; }
    public bool StruggleHintProvided { set; }
    public int ExtraRequiredWordsUsed { get; set; }
    public bool ExtraRequiredWordsPostPurchase { get; set; }
    public UGUIGenericCoinsGainedAnim coinStatViewAnim { get; }
    public UnityEngine.GameObject coinStatViewPlus { get; }
    
    // Methods
    public GameLevel get_GetCurrentGameLevel()
    {
        return (GameLevel)this.gameLevel;
    }
    public UnityEngine.GameObject get_LevelNameGroup()
    {
        return (UnityEngine.GameObject)this.levelNameGroup;
    }
    public EventButtonPanel get_EventButtonPanel()
    {
        return (EventButtonPanel)this.eventButtonPanel;
    }
    public float get_GetLevelCompleteDelay()
    {
        return (float)this.levelCompleteDelay;
    }
    public static MainController get_instance()
    {
        var val_11;
        var val_12;
        string val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        if(((MonoSingleton<WGDailyChallengeManager>.Instance) != 0) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false))
        {
                val_11 = 1152921504877826048;
            val_12 = null;
            val_12 = null;
            val_13 = MainController.extra_words_prefs_key;
            if(val_13 == 0)
        {
                val_14 = null;
            val_13 = UnityEngine.Object.FindObjectOfType<WGDailyChallengeMainController>();
            val_14 = null;
            MainController.extra_words_prefs_key = val_13;
        }
        
            val_15 = null;
            val_15 = null;
            return (MainController)val_16;
        }
        
        val_11 = 1152921504877826048;
        val_17 = null;
        val_17 = null;
        val_13 = MainController._mainInstance;
        if(val_13 == 0)
        {
                int val_11 = val_8.Length;
            val_13 = UnityEngine.Resources.FindObjectsOfTypeAll<MainController>();
            if(val_11 >= 1)
        {
                var val_12 = 0;
            val_11 = val_11 & 4294967295;
            do
        {
            val_18 = 0;
            if( == 0)
        {
                val_19 = null;
            val_19 = null;
            MainController._mainInstance = null;
        }
        
            val_12 = val_12 + 1;
        }
        while(val_12 < (val_8.Length << ));
        
        }
        
        }
        
        val_20 = null;
        val_20 = null;
        val_16 = 1152921504877830152;
        return (MainController)val_16;
    }
    public void Hack_SetLevelToLastLevelOfChapter()
    {
        if(CategoryPacksManager.IsPlaying != false)
        {
                MonoSingleton<CategoryPacksManager>.Instance.HACKSetPackLastLevelOfChapterProgress();
            return;
        }
        
        Player val_3 = App.Player;
        int val_4 = WADChapterManager.GetCurrentChapterLastLevel();
        goto typeof(Player).__il2cppRuntimeField_180;
    }
    public bool get_IsChapterComplete()
    {
        var val_6;
        if(CategoryPacksManager.IsPlaying == false)
        {
                return WADChapterManager.ChapterComplete;
        }
        
        if((MonoSingleton<CategoryPacksManager>.Instance.IsCurrentLevelLastWithinChapter) != false)
        {
                val_6 = 1;
            return (bool)((val_4.<IsChapterCompleted>k__BackingField) == true) ? 1 : 0;
        }
        
        CategoryPacksManager val_4 = MonoSingleton<CategoryPacksManager>.Instance;
        return (bool)((val_4.<IsChapterCompleted>k__BackingField) == true) ? 1 : 0;
    }
    public bool get_SpanishInfinityMode()
    {
        var val_11;
        var val_12;
        var val_14;
        var val_16;
        val_11 = 1152921504884269056;
        val_12 = null;
        val_12 = null;
        if(App.game == 1)
        {
            goto label_6;
        }
        
        val_14 = null;
        val_14 = null;
        if(App.game != 4)
        {
            goto label_17;
        }
        
        label_6:
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "es")) != false)
        {
                GameBehavior val_4 = App.getBehavior;
            val_11 = val_4.<metaGameBehavior>k__BackingField;
            GameBehavior val_5 = App.getBehavior;
            if(((val_5.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return (bool)(val_11 > (MonoSingletonSelfGenerating<WADataParser>.Instance.MaxPredefinedLevels)) ? 1 : 0;
        }
        
            int val_7 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.DefinedLevelCount;
            return (bool)(val_11 > (MonoSingletonSelfGenerating<WADataParser>.Instance.MaxPredefinedLevels)) ? 1 : 0;
        }
        
        label_17:
        val_16 = 0;
        return (bool)(val_11 > (MonoSingletonSelfGenerating<WADataParser>.Instance.MaxPredefinedLevels)) ? 1 : 0;
    }
    public bool get_IsLevelComplete()
    {
        return (bool)this.isGameComplete;
    }
    public bool get_CompletedAllKnownLevels()
    {
        GameBehavior val_2 = App.getBehavior;
        return MonoSingletonSelfGenerating<WADChapterManager>.Instance.FinishedContent(toCompare:  val_2.<metaGameBehavior>k__BackingField);
    }
    private MainController.GameModeForTracking get_CurrentGameModeForTracking()
    {
        var val_6;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_6 = 2;
            return (GameModeForTracking)(LevelChallengeHandler.InGame != true) ? 5 : (0 + 1);
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED == 0)
        {
                return (GameModeForTracking)(LevelChallengeHandler.InGame != true) ? 5 : (0 + 1);
        }
        
        if(PuzzleCollectionHandler.DEFAULT_LIFETIME_PUZZLES_COMPLETED.PlayingChallenge == false)
        {
                return (GameModeForTracking)(LevelChallengeHandler.InGame != true) ? 5 : (0 + 1);
        }
        
        val_6 = 4;
        return (GameModeForTracking)(LevelChallengeHandler.InGame != true) ? 5 : (0 + 1);
    }
    private string get_CurrentLanguageForTracking()
    {
        null = null;
        if(App.game != 4)
        {
                if(App.game != 1)
        {
                return "es";
        }
        
        }
        
        GameBehavior val_1 = App.getBehavior;
        return val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
    }
    private void Awake()
    {
        var val_9;
        var val_10;
        val_9 = null;
        val_9 = null;
        CPlayerPrefs._useRijndael = true;
        GameBehavior val_1 = App.getBehavior;
        this.currentLanguage = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_10 = 1152921504893267968;
            WordLevelGen val_5 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            if(val_5.initialized == true)
        {
                return;
        }
        
            MonoSingletonSelfGenerating<WordLevelGen>.Instance.ReInitialize();
            return;
        }
        
        val_10 = 1152921504893267968;
        WADataParser val_7 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(val_7.initialized != false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<WADataParser>.Instance.ReInitialize();
    }
    private void Start()
    {
        CPlayerPrefs.Save();
        this.OnStartLogic();
    }
    public virtual void OnApplicationPause(bool pause)
    {
        CPlayerPrefs.Save();
    }
    private void OnStartLogic()
    {
        var val_49;
        var val_50;
        int val_51;
        var val_52;
        this.levelLabel_hard.gameObject.SetActive(value:  false);
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        if(val_2.music.currentMusicType == 0)
        {
                WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.music.PlayRandomMusicTrack(type:  1);
        }
        
        val_49 = 1152921504893161472;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(CategoryPacksManager.IsPlaying != false)
        {
                this.gameLevel = PlayingLevel.GetCategoryLevel(categoryPackId:  0);
        }
        else
        {
                GameBehavior val_8 = App.getBehavior;
            if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_50 = (MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels) ^ 1;
        }
        else
        {
                val_50 = 1;
        }
        
            this.gameLevel = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  val_50 & 1);
            GameBehavior val_14 = App.getBehavior;
            this.SetLevelName(str:  System.String.Format(format:  Localization.Localize(key:  "level_#", defaultValue:  "Level {0}", useSingularKey:  false), arg0:  val_14.<metaGameBehavior>k__BackingField), isVisible:  true);
        }
        
        if(this.howToPlayButton != 0)
        {
                if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                WGChallengeController val_19 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
            val_51 = val_19._unlockLevel;
        }
        else
        {
                val_51 = 25;
        }
        
            this.howToPlayButton.SetLevelRequirement(level:  25);
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                if(this.levelLabel_hard.gameObject != null)
        {
            goto label_56;
        }
        
        }
        
        GameBehavior val_23 = App.getBehavior;
        if((val_23.<metaGameBehavior>k__BackingField.CheckIfLevelIsHard(level:  val_23.<metaGameBehavior>k__BackingField)) != false)
        {
                val_52 = 1;
        }
        else
        {
                val_52 = 0;
        }
        
        this.levelLabel_hard.gameObject.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.topRightInfoGroup)) != false)
        {
                label_56:
            this.topRightInfoGroup.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.goldenApplesGroup)) != false)
        {
                this.goldenApplesGroup.SetActive(value:  (~GoldenMultiplierManager.IsAvaialable) & 1);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.goldenMultiplierGroup)) != false)
        {
                this.goldenMultiplierGroup.SetActive(value:  GoldenMultiplierManager.IsAvaialable);
        }
        
        this.GetLevelTrackingProgress();
        WordRegion.instance.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  Pan.tappingAllowed, method:  public System.Void Pan::EnablePan()));
        WordRegion.instance.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnWordRegionLoaded()));
        WordRegion.instance.addOnPreprocessPlayerTurnAction(callback:  new System.Action<System.Boolean, System.String, LineWord, Cell>(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)));
        WordRegion.instance.addOnValidWordSubmittedAction(callback:  new System.Action<System.String, System.Boolean>(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnValidWordSubmitted(string word, bool extra)));
        WordRegion.instance.addOnInvalidWordSubmittedAction(callback:  new System.Action(object:  MonoSingleton<WordGameEventsController>.Instance, method:  public System.Void WordGameEventsController::OnInvalidWordSubmitted()));
        val_49 = WordRegion.instance;
        System.Action val_48 = new System.Action(object:  this, method:  typeof(MainController).__il2cppRuntimeField_188);
    }
    protected virtual void OnWordRegionLoaded()
    {
        var val_20;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                WGGenericNotificationsManager.SendLevelAnwserNotification(nextWord:  WordRegion.instance.GetFirstIncompleteWord(), QAHACK_Force:  false);
        }
        
        Pan.tappingAllowed.Load(gameLevel:  this.gameLevel);
        WGFTUXManager val_5 = MonoSingleton<WGFTUXManager>.Instance;
        val_5.SkipToLevelCallback = new System.Action<System.Int32>(object:  this, method:  System.Void MainController::SkipToLevel(int level));
        WGFTUXManager val_7 = MonoSingleton<WGFTUXManager>.Instance;
        val_7.SkipTutorialCallback = new System.Action(object:  this, method:  System.Void MainController::SkipTutorial());
        MonoSingleton<WGFTUXManager>.Instance.OnMainControllerLoaded();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnBeforeLevelStart");
        string val_11 = this.GetLevelWord();
        this.currentLevelWord = val_11;
        this.TrackLevelStart(levelWord:  val_11);
        MonoSingletonSelfGenerating<WADChapterManager>.Instance.TrackLevelSkipLevelStart(levelWord:  this.currentLevelWord);
        WGGenericNotificationsManager.SendEngagementNotifications(QAHACK_Force:  false);
        MonoSingleton<WordGameEventsController>.Instance.OnGameSceneInit();
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<MysteryGiftManager>.Instance)) != false)
        {
                MonoSingleton<MysteryGiftManager>.Instance.OnGameSceneBegan();
        }
        
        if(this.hintButton.activeInHierarchy != true)
        {
                if(WGFTUXManager.IsShowing == false)
        {
            goto label_37;
        }
        
        }
        
        if(WGFTUXManager.IsShowing == false)
        {
                return;
        }
        
        val_20 = 0;
        goto label_40;
        label_37:
        val_20 = 1;
        label_40:
        this.hintButton.SetActive(value:  true);
    }
    private void TrackLevelStart(string levelWord)
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_29;
        int val_30;
        bool val_31;
        var val_32;
        bool val_33;
        object val_34;
        var val_35;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_29 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_3;
        }
        
        CategoryPacksManager val_4 = MonoSingleton<CategoryPacksManager>.Instance;
        val_30 = (MonoSingleton<CategoryPacksManager>.Instance.GetPackProgress(packId:  val_4.<CurrentCategoryPackInfo>k__BackingField.packId)) + 1;
        val_1.Add(key:  "Category Level", value:  val_30);
        CategoryPacksManager val_6 = MonoSingleton<CategoryPacksManager>.Instance;
        val_1.Add(key:  "Category Level Pack", value:  val_6.<CurrentCategoryPackInfo>k__BackingField.packId);
        val_29 = val_29;
        if(val_29 != 0)
        {
            goto label_13;
        }
        
        label_3:
        val_30 = 1152921515419383392;
        val_1.Add(key:  "Current Lvl", value:  Player.GetLevelForTracking());
        label_13:
        val_1.Add(key:  "Current Lvl Name", value:  levelWord);
        Player val_8 = App.Player;
        val_1.Add(key:  "Coin Balance", value:  val_8._credits);
        val_1.Add(key:  "Total Words", value:  WordRegion.instance.GetTotalAcceptableWords());
        val_1.Add(key:  "Daily Challenge", value:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge);
        val_1.Add(key:  "Extra Words", value:  ((this.<ExtraRequiredWordsUsed>k__BackingField) > 0) ? 1 : 0.ToString());
        val_1.Add(key:  "Extra Words #", value:  this.<ExtraRequiredWordsUsed>k__BackingField);
        val_31 = this.<ExtraRequiredWordsPostPurchase>k__BackingField;
        val_1.Add(key:  "Extra Words Post Purchase", value:  ((this.<ExtraRequiredWordsUsed>k__BackingField) > 0) ? 1 : 0.ToString());
        val_1.Add(key:  "Extra Words Levels", value:  this.gameMode);
        val_32 = 1152921504893161472;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGChallengeWordsManager>.Instance)) != false)
        {
                if(WGChallengeWordsManager.IsFeatureUnlocked != false)
        {
                WGChallengeWordsManager val_21 = MonoSingleton<WGChallengeWordsManager>.Instance;
            val_33 = val_21.<IsChallengeLevel>k__BackingField;
        }
        else
        {
                val_33 = false;
        }
        
            val_1.Add(key:  "Challenge Word", value:  val_33);
        }
        
        GameBehavior val_22 = App.getBehavior;
        if(((val_22.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_32 = 1152921515419469536;
            if((MonoSingleton<Alphabet2Manager>.Instance) != 0)
        {
                if((MonoSingleton<Alphabet2Manager>.Instance.IsCurrentLevelWithTile) != false)
        {
                val_34 = null;
        }
        else
        {
                val_34 = null;
        }
        
            val_1.Add(key:  "Alphabet Tile Available", value:  val_34);
        }
        
        }
        
        GameBehavior val_27 = App.getBehavior;
        val_35 = null;
        val_35 = null;
        App.trackerManager.track(eventName:  "Level Start", data:  val_1);
    }
    protected void TrackLevelGenerationLevelStart(string levelWord)
    {
    
    }
    protected string GetLevelWord()
    {
        if(CategoryPacksManager.IsPlaying == false)
        {
                return this.gameLevel.word.Replace(oldValue:  "|", newValue:  "");
        }
        
        CategoryPacksManager val_3 = MonoSingleton<CategoryPacksManager>.Instance;
        return MonoSingleton<CategoryPacksManager>.Instance.GetWordFromPack(packId:  val_3.<CurrentCategoryPackInfo>k__BackingField.packId);
    }
    public virtual void OnBeforeComplete()
    {
        if(this.onBeforeLevelComplete != null)
        {
                this.onBeforeLevelComplete.Invoke();
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnBeforeLevelComplete(levelsProgressed:  1);
    }
    public virtual void OnComplete()
    {
        UnityEngine.Object val_21;
        var val_22;
        DG.Tweening.TweenCallback val_24;
        val_21 = this;
        if(this.isGameComplete == true)
        {
                return;
        }
        
        this.isGameComplete = true;
        MonoSingletonSelfGenerating<WADChapterManager>.Instance.TrackLevelSkipLevelComplete(averageLevelWordCompletionTime:  this.gameLevel.avgCompletionTime);
        this.TrackLevelComplete(levelWord:  this.currentLevelWord);
        GameplayMode val_2 = PlayingLevel.CurrentGameplayMode;
        if(val_2 != 4)
        {
            goto label_8;
        }
        
        MonoSingleton<CategoryPacksManager>.Instance.OnLevelComplete();
        CategoryPacksManager val_4 = MonoSingleton<CategoryPacksManager>.Instance;
        if((val_4.<IsChapterCompleted>k__BackingField) == false)
        {
            goto label_31;
        }
        
        bool val_6 = MonoSingleton<CategoryPacksManager>.Instance.IsPackNewlyCompleted;
        goto label_31;
        label_8:
        val_2.AdvanceLevelLogic();
        MonoSingletonSelfGenerating<WADChapterManager>.Instance.LevelWasCompleted();
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                bool val_10 = ChapterBookLogic.ShowBookComplete(playerLevel:  App.Player);
        }
        else
        {
                bool val_11 = val_8.<metaGameBehavior>k__BackingField.IsChapterComplete;
        }
        
        label_31:
        if((MonoSingleton<WGChallengeWordsManager>.Instance) != 0)
        {
                MonoSingleton<WGChallengeWordsManager>.Instance.OnLevelComplete();
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnLevelComplete(levelsProgressed:  1);
        this.onLevelComplete.Invoke();
        val_22 = null;
        val_22 = null;
        val_24 = MainController.<>c.<>9__70_0;
        if(val_24 == null)
        {
                DG.Tweening.TweenCallback val_16 = null;
            val_24 = val_16;
            val_16 = new DG.Tweening.TweenCallback(object:  MainController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MainController.<>c::<OnComplete>b__70_0());
            MainController.<>c.<>9__70_0 = val_24;
        }
        
        DG.Tweening.DOVirtual.DelayedCall(delay:  this.levelCompleteDelay, callback:  val_16, ignoreTimeScale:  true).ClearLevelTrackingProgress();
        WGGenericNotificationsManager.CancelLevelAnswerNotification();
        val_21 = MonoSingleton<MysteryGiftManager>.Instance;
        if((UnityEngine.Object.op_Implicit(exists:  val_21)) == false)
        {
                return;
        }
        
        MonoSingleton<MysteryGiftManager>.Instance.OnPlayerLevelUp();
    }
    private void TrackLevelComplete(string levelWord)
    {
        var val_106;
        bool val_107;
        var val_108;
        var val_109;
        System.Collections.Generic.Dictionary<TKey, TValue> val_110;
        bool val_111;
        var val_112;
        var val_113;
        val_106 = this;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_3;
        }
        
        CategoryPacksManager val_4 = MonoSingleton<CategoryPacksManager>.Instance;
        CategoryPacksManager val_7 = MonoSingleton<CategoryPacksManager>.Instance;
        int val_9 = (MonoSingleton<CategoryPacksManager>.Instance.GetPackProgress(packId:  val_4.<CurrentCategoryPackInfo>k__BackingField.packId)) + 1;
        val_1.Add(key:  "Category Level", value:  val_9);
        CategoryPacksManager val_11 = MonoSingleton<CategoryPacksManager>.Instance;
        val_1.Add(key:  "Category Level Pack", value:  val_11.<CurrentCategoryPackInfo>k__BackingField.packId);
        val_1.Add(key:  "Category Level Pack Complete", value:  (val_9 >= (MonoSingleton<CategoryPacksManager>.Instance.GetWordBank(packId:  val_7.<CurrentCategoryPackInfo>k__BackingField.packId).Size)) ? 1 : 0);
        if(val_1 != 0)
        {
            goto label_18;
        }
        
        label_3:
        val_1.Add(key:  "Current Lvl", value:  Player.GetLevelForTracking());
        label_18:
        val_1.Add(key:  "Current Lvl Name", value:  levelWord);
        val_1.Add(key:  "Hints Used", value:  this.hintsUsed);
        val_1.Add(key:  "Hints Used Picker", value:  this.pickerHintsUsed);
        val_1.Add(key:  "Hints Used Mega", value:  this.megarHintsUsed);
        val_1.Add(key:  "Free Hints Used", value:  this.freeHintUsed);
        val_1.Add(key:  "Extra Words Found", value:  this.extraWordsFound);
        val_1.Add(key:  "Words Completed", value:  this.wordsCompleted);
        val_1.Add(key:  "Shuffles Used", value:  this.shufflesUsed);
        val_1.Add(key:  "Daily Challenge", value:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge);
        val_1.Add(key:  "Mode", value:  (CategoryPacksManager.IsPlaying != true) ? "Categories" : "Progression");
        val_1.Add(key:  "Extra Words", value:  ((this.<ExtraRequiredWordsUsed>k__BackingField) > 0) ? 1 : 0.ToString());
        val_1.Add(key:  "Extra Words #", value:  this.<ExtraRequiredWordsUsed>k__BackingField);
        val_107 = this.<ExtraRequiredWordsPostPurchase>k__BackingField;
        val_1.Add(key:  "Extra Words Post Purchase", value:  ((this.<ExtraRequiredWordsUsed>k__BackingField) > 0) ? 1 : 0.ToString());
        val_1.Add(key:  "Extra Words Levels", value:  this.gameMode);
        int val_26 = ExtraWord.ApplesFromExtra + WordStreak.ApplesFromStreak;
        val_26 = val_26 + DifficultySettingManagerGameplay.ApplesFromDifficulty;
        val_1.Add(key:  "League Points Earned", value:  val_26);
        val_1.Add(key:  "Largest Word Streak", value:  WordStreak.LargestStreak);
        val_1.Add(key:  "Trial Hints Used", value:  this.trialHintsUsed);
        val_1.Add(key:  "Hints Used Struggle", value:  this.struggleHintsUsed);
        val_1.Add(key:  "Struggle Hint Provided", value:  this.struggleHintProvided);
        GameBehavior val_28 = App.getBehavior;
        if(((val_28.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_1.Add(key:  "League Points Extra Words Earned", value:  ExtraWord.ApplesFromExtra);
            val_1.Add(key:  "Extra Words List Viewed", value:  ExtraWord.HasViewedWordList);
        }
        
        if((MonoSingleton<WordIQManagerGameplay>.Instance) != 0)
        {
                MonoSingleton<WordIQManagerGameplay>.Instance.AppendLevelCompleteData(curData: ref  val_1);
        }
        
        MonoSingleton<WordGameEventsController>.Instance.AppendLevelCompleteData(curData: ref  val_1);
        if((MonoSingleton<WADPetsManager>.Instance) != 0)
        {
                MonoSingleton<WADPetsManager>.Instance.AppendLevelCompleteData(curData: ref  val_1);
        }
        
        GameBehavior val_39 = App.getBehavior;
        if((((val_39.<metaGameBehavior>k__BackingField) & 1) != 0) && ((MonoSingleton<Alphabet2Manager>.Instance) != 0))
        {
                if((MonoSingleton<Alphabet2Manager>.Instance.IsCurrentLevelWithTile) != false)
        {
                val_1.Add(key:  "Alphabet Tile Earned", value:  MonoSingleton<Alphabet2Manager>.Instance.GetLevelTracking().Item["collected"]);
            val_1.Add(key:  "Alphabet Tile Rarity", value:  MonoSingleton<Alphabet2Manager>.Instance.GetLevelTracking().Item["rarity"]);
        }
        
        }
        
        if((MonoSingleton<WGPrizeBalloonManager>.Instance) != 0)
        {
                if((MonoSingleton<WGPrizeBalloonManager>.Instance.IsGameModeEligible()) != false)
        {
                val_1.Add(key:  "Prize Balloon Appearance", value:  MonoSingleton<WGPrizeBalloonManager>.Instance.GetTracking_BalloonsAppearedInLevel());
        }
        
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                GameBehavior val_58 = App.getBehavior;
            val_1.Add(key:  "Hard", value:  val_58.<metaGameBehavior>k__BackingField.CheckIfLevelIsHard(level:  val_58.<metaGameBehavior>k__BackingField));
        }
        
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY != null)
        {
                if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.isActive != false)
        {
                val_1.Add(key:  "Spins Earned", value:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 32);
            val_1.Add(key:  "Spin Balance", value:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY + 56);
        }
        
        }
        
        GameBehavior val_62 = App.getBehavior;
        if((((val_62.<metaGameBehavior>k__BackingField) & 1) != 0) && ((SnakesAndLaddersEventHandler.<Instance>k__BackingField) != null))
        {
                if((SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsDiceRollShownThisLevel) != false)
        {
                val_1.Add(key:  "Dice Roll Earned", value:  SnakesAndLaddersEventHandler.<Instance>k__BackingField.IsDiceRollCollectedThisLevel);
        }
        
        }
        
        if(IslandParadiseEventHandler.IsEventActive != false)
        {
                val_1.Add(key:  "Island Paradise Points", value:  IslandParadiseEventHandler._Instance.<PointsEarnedInLevel>k__BackingField);
        }
        
        val_108 = null;
        val_108 = null;
        if(App.game == 18)
        {
                if((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance) != 0)
        {
                WordForest.ChestLocData val_71 = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetCurrentChestPlacementData(mode:  PlayingLevel.CurrentGameplayMode);
            val_109 = val_71;
            val_1.Add(key:  "Mystery Chest Shown", value:  (val_71.GameLevel == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0);
            val_1.Add(key:  "Mystery Chest Complete", value:  ((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.LastMysteryChestCollectedPlayerLvel) == PlayingLevel.GetCurrentPlayerLevelNumber()) ? 1 : 0);
        }
        
        }
        
        val_110 = 1152921504893161472;
        if((MonoSingleton<WordStreak>.Instance) != 0)
        {
                if(((MonoSingleton<WordStreak>.Instance) != 0) && (val_80.streakSaverOffered != false))
        {
                val_110 = val_1;
            val_1.Add(key:  "Streak Saver Used", value:  val_80.streakSaved);
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGChallengeWordsManager>.Instance)) != false)
        {
                val_110 = "Challenge Word";
            if(WGChallengeWordsManager.IsFeatureUnlocked != false)
        {
                WGChallengeWordsManager val_85 = MonoSingleton<WGChallengeWordsManager>.Instance;
            val_111 = val_85.<IsChallengeLevel>k__BackingField;
        }
        else
        {
                val_111 = false;
        }
        
            val_1.Add(key:  val_110, value:  val_111);
        }
        
        val_112 = null;
        val_112 = null;
        App.trackerManager.track(eventName:  "Level Complete", data:  val_1);
        if(GoldenMultiplierManager.IsAvaialable == true)
        {
                return;
        }
        
        if(WordStreak.ApplesFromStreak < 1)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_88 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_88.Add(key:  "Base Reward", value:  WordStreak.ApplesFromStreak);
        if(this.gameLevel.isChallengingLevel != false)
        {
                val_88.Add(key:  "Challenge Bonus", value:  WordStreak.ApplesFromStreak);
            int val_106 = WordStreak.ApplesFromStreak;
            val_106 = val_106 << 1;
        }
        
        if(WordStreak.ApplesFromStreakSub >= 1)
        {
                val_88.Add(key:  "Golden Ticket Bonus", value:  WordStreak.ApplesFromStreakSub);
        }
        
        val_110 = MonoSingleton<WADPetsManager>.Instance;
        if(val_110 == 0)
        {
            goto label_241;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_99 = MonoSingleton<WADPetsManager>.Instance.GetBonusGoldenApplesRewardTrackingParameters(level:  this.gameLevel);
        if(val_99 == null)
        {
            goto label_241;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_100 = val_99.GetEnumerator();
        val_106 = 1152921510193071136;
        label_227:
        if(0.MoveNext() == false)
        {
            goto label_226;
        }
        
        val_88.Add(key:  0, value:  0);
        goto label_227;
        label_226:
        0.Dispose();
        label_241:
        val_113 = null;
        val_113 = null;
        if(App.game == 18)
        {
                return;
        }
        
        val_106 = App.Player;
        val_110 = "streak_" + WordStreak.LargestStreak;
        val_106.TrackNonCoinReward(source:  "Gameplay", subSource:  val_110, rewardType:  "Golden Currency", rewardAmount:  WordStreak.ApplesFromStreakSub + val_106.ToString(), additionalParams:  val_88);
    }
    public static int GetHintsPerChapterThreshold()
    {
        int val_6;
        Player val_1 = App.Player;
        if(val_1.num_purchase == 0)
        {
            goto label_4;
        }
        
        Player val_2 = App.Player;
        if(val_2.num_purchase != 1)
        {
            goto label_8;
        }
        
        GameEcon val_3 = App.getGameEcon;
        val_6 = val_3.extraReqHintsPerCh_BuyFirst;
        return val_6;
        label_4:
        GameEcon val_4 = App.getGameEcon;
        val_6 = val_4.extraReqHintsPerCh_BuyNone;
        return val_6;
        label_8:
        GameEcon val_5 = App.getGameEcon;
        val_6 = val_5.extraReqHintsPerCh_BuyRepeat;
        return val_6;
    }
    private void AdvanceLevelLogic()
    {
        MetaGameBehavior val_20;
        var val_21;
        var val_22;
        var val_23;
        Player val_1 = App.Player;
        if((val_1.properties.LevelsPlayedPostPurchase & 2147483648) == 0)
        {
                Player val_2 = App.Player;
            int val_20 = val_2.properties.LevelsPlayedPostPurchase;
            val_20 = val_20 + 1;
            val_2.properties.LevelsPlayedPostPurchase = val_20;
            Player val_3 = App.Player;
            val_3.properties.Save(writePrefs:  true);
        }
        
        PlayingLevel.CompleteLevel(mode:  1, parameters:  0);
        GameBehavior val_4 = App.getBehavior;
        val_20 = val_4.<metaGameBehavior>k__BackingField;
        MetaGameBehavior val_5 = val_20 + 1;
        if(val_20.IsChapterComplete != false)
        {
                GameEcon val_8 = App.getGameEcon;
            if(Prefs.currentChapter >= val_8.extraReqBeginningChapter)
        {
                Player val_9 = App.Player;
            val_21 = null;
            if(val_9.properties.HintsUsedOnCurrentChapter < MainController.GetHintsPerChapterThreshold())
        {
                Player val_11 = App.Player;
            int val_21 = val_11.properties.ChaptersPlayedWithoutHints;
            val_21 = val_21 + 1;
            val_11.properties.ChaptersPlayedWithoutHints = val_21;
        }
        
        }
        
            Player val_12 = App.Player;
            val_12.properties.HintsUsedOnCurrentChapter = 0;
            Player val_13 = App.Player;
            val_13.properties.Save(writePrefs:  true);
            val_20 = 1152921504874684416;
            if((CPlayerPrefs.HasKey(key:  "xtra_word_levels")) != false)
        {
                CPlayerPrefs.DeleteKey(key:  "xtra_word_levels");
        }
        
        }
        
        GameBehavior val_15 = App.getBehavior;
        if((val_15.<metaGameBehavior>k__BackingField) >= 10)
        {
                GameBehavior val_16 = App.getBehavior;
            if(0 != 0)
        {
                return;
        }
        
        }
        
        val_22 = null;
        val_22 = null;
        val_23 = null;
        val_20 = App.trackerManager;
        val_23 = null;
        GameBehavior val_17 = App.getBehavior;
        val_20.track(eventName:  Events.LEVEL_REACHED + "_" + val_17.<metaGameBehavior>k__BackingField.ToString()(val_17.<metaGameBehavior>k__BackingField.ToString()));
    }
    public virtual System.Collections.Generic.List<int> GetExtraWordLevels()
    {
        string val_18;
        object val_19;
        int val_20;
        val_18 = Prefs.currentChapter;
        GameEcon val_2 = App.getGameEcon;
        if(val_18 < val_2.extraReqBeginningChapter)
        {
                System.Collections.Generic.List<System.Int32> val_3 = null;
            val_19 = val_3;
            val_3 = new System.Collections.Generic.List<System.Int32>();
            return (System.Collections.Generic.List<System.Int32>)val_19;
        }
        
        string val_4 = CPlayerPrefs.GetString(key:  "xtra_word_levels", defaultValue:  "");
        val_18 = val_4;
        if((System.String.IsNullOrEmpty(value:  val_4)) == false)
        {
            goto label_8;
        }
        
        int val_6 = WADChapterManager.GetNumLevelsInCurrentChapter();
        GameEcon val_7 = App.getGameEcon;
        Player val_8 = App.Player;
        int val_18 = val_8.properties.ChaptersPlayedWithoutHints;
        GameEcon val_9 = App.getGameEcon;
        val_20 = val_9.extraReqIncrement;
        GameEcon val_10 = App.getGameEcon;
        int val_12 = UnityEngine.Mathf.Min(a:  val_7.extraReqDefaultLevelsPerChapter + (val_20 * val_18), b:  val_10.extraReqMaxLevelsPerChapter);
        val_18 = (val_12 > val_6) ? (val_6) : (val_12);
        System.Collections.Generic.List<System.Int32> val_13 = null;
        val_19 = val_13;
        val_13 = new System.Collections.Generic.List<System.Int32>();
        RandomSet val_14 = new RandomSet();
        val_14.addIntRange(lowest:  1, highest:  val_6);
        if((val_18 < 1) || (val_6 < 1))
        {
            goto label_20;
        }
        
        val_20 = 1;
        label_23:
        val_13.Add(item:  val_14.roll(unweighted:  false));
        if(val_20 >= val_18)
        {
            goto label_24;
        }
        
        val_20 = val_20 + 1;
        if(val_20 < val_6)
        {
            goto label_23;
        }
        
        goto label_24;
        label_8:
        val_19 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  val_18);
        return (System.Collections.Generic.List<System.Int32>)val_19;
        label_20:
        label_24:
        val_13.Sort();
        val_18 = Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_13);
        CPlayerPrefs.SetString(key:  "xtra_word_levels", val:  val_18);
        return (System.Collections.Generic.List<System.Int32>)val_19;
    }
    public virtual void OnLevelClearClosed()
    {
        GameBehavior val_1 = App.getBehavior;
        bool val_3 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        if(SLC.Social.Leagues.LeaguesManager.DAO == 0)
        {
                return;
        }
        
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateMyProfileInfo(force:  false);
    }
    public void OnChapterClearClosed()
    {
        GameBehavior val_1 = App.getBehavior;
        bool val_3 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.music.PlayRandomMusicTrack(type:  1);
    }
    public void OnCategoryPackCompletedClosed()
    {
        GameBehavior val_2 = App.getBehavior;
        .onSceneLoaded = 0;
        .onSceneLoaded = new System.Action<SceneType>(object:  new MainController.<>c__DisplayClass77_0(), method:  System.Void MainController.<>c__DisplayClass77_0::<OnCategoryPackCompletedClosed>b__0(SceneType s));
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_5 = System.Delegate.Combine(a:  val_4.OnSceneLoaded, b:  (MainController.<>c__DisplayClass77_0)[1152921515422358432].onSceneLoaded);
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.OnSceneLoaded = val_5;
        return;
        label_10:
    }
    public void UpdateExtraWordProgress()
    {
        int val_2 = Prefs.extraTarget;
        val_2 = Prefs.extraProgress - val_2;
        Prefs.extraProgress = val_2;
        GameEcon val_3 = App.getGameEcon;
        GameEcon val_5 = App.getGameEcon;
        Prefs.extraTarget = System.Math.Min(val1:  val_3.ExtraWordsMaxReq, val2:  val_5.ExtraWordsIncrement + Prefs.extraTarget);
        ExtraWord.GAMETYPE_CATEGORY_LEVELS.OnClaimed();
    }
    public void SetLevelName(string str, bool isVisible = True)
    {
        if((System.String.IsNullOrEmpty(value:  str)) != true)
        {
                bool val_2 = UnityEngine.Object.op_Inequality(x:  this.levelNameText, y:  0);
        }
        
        if(this.levelNameGroup == 0)
        {
                return;
        }
        
        this.levelNameGroup.SetActive(value:  isVisible);
    }
    private void OnLocalize()
    {
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Equality(a:  this.currentLanguage, b:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        this.currentLanguage = val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        MainController val_6 = MainController.instance;
        val_6.onLevelComplete.Invoke();
        Pan.tappingAllowed.Load(gameLevel:  PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false));
        GameBehavior val_8 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    private void SkipToLevel(int level)
    {
        MainController val_1 = MainController.instance;
        val_1.onLevelComplete.Invoke();
        GameBehavior val_2 = App.getBehavior;
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    private void SkipTutorial()
    {
    
    }
    private void SaveLevelTrackingProgress()
    {
        if(Prefs.IsCurrentLevel() == false)
        {
                return;
        }
        
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  this.hintsUsed.ToString());
        val_2.Add(item:  this.extraWordsFound.ToString());
        val_2.Add(item:  this.wordsCompleted);
        val_2.Add(item:  this.shufflesUsed.ToString());
        val_2.Add(item:  this.freeHintUsed.ToString());
        val_2.Add(item:  this.pickerHintsUsed.ToString());
        val_2.Add(item:  this.megarHintsUsed.ToString());
        val_2.Add(item:  this.trialHintsUsed.ToString());
        val_2.Add(item:  this.struggleHintsUsed.ToString());
        val_2.Add(item:  this.struggleHintProvided.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "level_tracking", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_2));
        bool val_13 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected void GetLevelTrackingProgress()
    {
        bool val_32;
        var val_33;
        if(Prefs.IsCurrentLevel() == false)
        {
                return;
        }
        
        val_32 = "level_tracking";
        if((UnityEngine.PlayerPrefs.HasKey(key:  "level_tracking")) == false)
        {
            goto label_2;
        }
        
        val_33 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.String[]>(value:  UnityEngine.PlayerPrefs.GetString(key:  "level_tracking", defaultValue:  "[]"));
        if(val_33 != null)
        {
            goto label_5;
        }
        
        return;
        label_2:
        if((CPlayerPrefs.HasKey(key:  "level_tracking")) == false)
        {
                return;
        }
        
        val_33 = CryptoPlayerPrefsX.GetStringArray(key:  "level_tracking");
        CPlayerPrefs.DeleteKey(key:  "level_tracking");
        if(val_33 == null)
        {
                return;
        }
        
        label_5:
        if(val_6.Length < 4)
        {
                return;
        }
        
        bool val_8 = System.Int32.TryParse(s:  val_33[0], result: out  this.hintsUsed);
        bool val_10 = System.Int32.TryParse(s:  val_33[1], result: out  this.extraWordsFound);
        this.wordsCompleted = val_33[2];
        bool val_12 = System.Int32.TryParse(s:  val_33[3], result: out  this.shufflesUsed);
        if(val_6.Length < 5)
        {
                return;
        }
        
        val_32 = this.freeHintUsed;
        bool val_14 = System.Boolean.TryParse(value:  val_33[4], result: out  val_32);
        if(val_6.Length < 6)
        {
                return;
        }
        
        bool val_16 = System.Int32.TryParse(s:  val_33[5], result: out  this.pickerHintsUsed);
        bool val_18 = System.Int32.TryParse(s:  val_33[6], result: out  this.megarHintsUsed);
        if(val_6.Length < 8)
        {
                return;
        }
        
        bool val_20 = System.Int32.TryParse(s:  val_33[7], result: out  this.trialHintsUsed);
        if(val_6.Length < 9)
        {
                return;
        }
        
        bool val_22 = System.Int32.TryParse(s:  val_33[8], result: out  this.struggleHintsUsed);
        if(val_6.Length < 10)
        {
                return;
        }
        
        bool val_24 = System.Boolean.TryParse(value:  val_33[9], result: out  this.struggleHintProvided);
    }
    private void ClearLevelTrackingProgress()
    {
        var val_3;
        if(Prefs.IsCurrentLevel() == false)
        {
                return;
        }
        
        val_3 = "level_tracking";
        UnityEngine.PlayerPrefs.DeleteKey(key:  "level_tracking");
        if((CPlayerPrefs.HasKey(key:  "level_tracking")) == false)
        {
                return;
        }
        
        CPlayerPrefs.DeleteKey(key:  "level_tracking");
    }
    private bool CheckIfLevelIsHard(int level)
    {
        GameEcon val_1 = App.getGameEcon;
        return val_1.WADHardLevels.Contains(item:  level);
    }
    public virtual int get_HintsUsed()
    {
        return (int)this.hintsUsed;
    }
    public virtual void set_HintsUsed(int value)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                DailyChallengeGameLevel val_4 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
            int val_5 = val_4.regularHintsUsed;
            val_5 = val_5 + value;
            val_5 = val_5 - this.hintsUsed;
            val_4.regularHintsUsed = val_5;
        }
        
        this.hintsUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public virtual int get_HintsUsedPicker()
    {
        return (int)this.pickerHintsUsed;
    }
    public virtual void set_HintsUsedPicker(int value)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                1152921504893161472 = MonoSingleton<WGDailyChallengeManager>.Instance.CurrentLevel;
            int val_5 = val_4.pickerHintsUsed + value;
            val_5 = val_5 - this;
            val_4.pickerHintsUsed = val_5;
        }
        
        this.pickerHintsUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public int get_HintsUsedMega()
    {
        return (int)this.megarHintsUsed;
    }
    public void set_HintsUsedMega(int value)
    {
        this.megarHintsUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public int get_ExtraWordsFound()
    {
        return (int)this.extraWordsFound;
    }
    public void set_ExtraWordsFound(int value)
    {
        this.extraWordsFound = value;
        this.SaveLevelTrackingProgress();
    }
    public string get_WordsCompleted()
    {
        return (string)this.wordsCompleted;
    }
    public void set_WordsCompleted(string value)
    {
        this.wordsCompleted = value;
        this.SaveLevelTrackingProgress();
    }
    public int get_ShufflesUsed()
    {
        return (int)this.shufflesUsed;
    }
    public void set_ShufflesUsed(int value)
    {
        this.shufflesUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public bool get_FreeHintsUsed()
    {
        return (bool)this.freeHintUsed;
    }
    public void set_FreeHintsUsed(bool value)
    {
        this.freeHintUsed = value;
        this.SaveLevelTrackingProgress();
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
    }
    public virtual int get_TrialHintsUsed()
    {
        return (int)this.trialHintsUsed;
    }
    public virtual void set_TrialHintsUsed(int value)
    {
        this.trialHintsUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public int get_StruggleHintsUsed()
    {
        return (int)this.struggleHintsUsed;
    }
    public void set_StruggleHintsUsed(int value)
    {
        this.struggleHintsUsed = value;
        this.SaveLevelTrackingProgress();
    }
    public void set_StruggleHintProvided(bool value)
    {
        this.struggleHintProvided = value;
        this.SaveLevelTrackingProgress();
    }
    public int get_ExtraRequiredWordsUsed()
    {
        return (int)this.<ExtraRequiredWordsUsed>k__BackingField;
    }
    public void set_ExtraRequiredWordsUsed(int value)
    {
        this.<ExtraRequiredWordsUsed>k__BackingField = value;
    }
    public bool get_ExtraRequiredWordsPostPurchase()
    {
        return (bool)this.<ExtraRequiredWordsPostPurchase>k__BackingField;
    }
    public void set_ExtraRequiredWordsPostPurchase(bool value)
    {
        this.<ExtraRequiredWordsPostPurchase>k__BackingField = value;
    }
    public UGUIGenericCoinsGainedAnim get_coinStatViewAnim()
    {
        return (UGUIGenericCoinsGainedAnim)this.coin_stat_view_anim;
    }
    public UnityEngine.GameObject get_coinStatViewPlus()
    {
        return (UnityEngine.GameObject)this.coin_stat_view_plus;
    }
    public MainController()
    {
        this.levelCompleteDelay = 1.75f;
        this.onBeforeLevelComplete = new UnityEngine.Events.UnityEvent();
        this.onLevelComplete = new UnityEngine.Events.UnityEvent();
        this.wordsCompleted = "|";
        this.currentLevelWord = "";
    }
    private static MainController()
    {
    
    }

}
