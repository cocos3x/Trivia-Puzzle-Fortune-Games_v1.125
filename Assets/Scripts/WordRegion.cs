using UnityEngine;
public class WordRegion : WordRegionBase
{
    // Fields
    public TextPreview textPreview;
    public WGCompliment compliment;
    protected UnityEngine.Transform safeTransform;
    protected System.Collections.Generic.List<string> validWords;
    public bool canHint;
    protected GameLevel gameLevel;
    public UnityEngine.ParticleSystem hintEffect;
    protected UnityEngine.RectTransform rt;
    private static WordRegion wordRegion;
    protected decimal ooc_coins;
    private const string extra_req_words_daily_challenge_pref_key = "xtra_req_words_daily_challenge1";
    private const string level_progress_pref_key = "level_progress2";
    private const string level_progress_daily_challenge_pref_key = "lvl_prog_daily_challenge3";
    private const string level_progress_spd_pref_key = "level_progress_spd3";
    public System.Action<string, int, bool, bool> OnHintedUsed;
    private System.Action<bool, string, LineWord, Cell> OnPreprocessPlayerTurn;
    private System.Action<string, bool> OnValidWordSubmitted;
    private System.Action OnInvalidWordSubmitted;
    private System.Action<GameLevel> OnBeforeLevelComplete;
    private System.Action<GameLevel> OnLevelComplete;
    public System.Action<GameLevel> OnLevelLoaded;
    protected System.Action onLevelLoadCompleteAction;
    private System.Action<string> onWordFoundAction;
    private System.Action<string> onExtraWordFoundAction;
    private System.Action<UnityEngine.Vector3> onHintUsedAtLocation;
    public UnityEngine.Events.UnityEvent onWordFound;
    public UnityEngine.Events.UnityEvent onExtraWordFound;
    protected float baseScale;
    private bool validWordsIncluded;
    private System.Collections.Generic.List<string> Hack_ExtraWords;
    private System.Collections.Generic.List<string> Hack_EssentialWords;
    private string Hack_hackedWord;
    public static bool hackTapToReveal;
    protected System.Collections.Generic.HashSet<LevelCompleteBlockerType> levelCompleteBlockers;
    public UnityEngine.Events.UnityEvent onBeforeLevelComplete;
    private int correctChainCount;
    protected System.Collections.Generic.List<string> ExtraRequiredList;
    private bool _hintDemoFTUX;
    private UnityEngine.Coroutine levelCompleteCoroutine;
    
    // Properties
    public UnityEngine.Transform SafeTransform { get; }
    public System.Collections.Generic.List<string> ExtraWords { get; }
    private static string extra_req_words_pref_key { get; }
    public static WordRegion instance { get; }
    protected bool levelCompleteBlocked { get; }
    
    // Methods
    public UnityEngine.Transform get_SafeTransform()
    {
        if(this.safeTransform == 0)
        {
                return this.transform;
        }
        
        return (UnityEngine.Transform)this.safeTransform;
    }
    public System.Collections.Generic.List<string> get_ExtraWords()
    {
        return (System.Collections.Generic.List<System.String>)this.validWords;
    }
    private static string get_extra_req_words_pref_key()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_340;
    }
    public void addOnHintedUsedAction(System.Action<string, int, bool, bool> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnHintedUsed, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnHintedUsed, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnHintedUsed = val_2;
        return;
        label_3:
    }
    public void addOnValidWordSubmittedAction(System.Action<string, bool> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnValidWordSubmitted, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnValidWordSubmitted, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnValidWordSubmitted = val_2;
        return;
        label_3:
    }
    public void addOnPreprocessPlayerTurnAction(System.Action<bool, string, LineWord, Cell> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnPreprocessPlayerTurn, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnPreprocessPlayerTurn, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnPreprocessPlayerTurn = val_2;
        return;
        label_3:
    }
    public void addOnInvalidWordSubmittedAction(System.Action callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnInvalidWordSubmitted, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnInvalidWordSubmitted, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnInvalidWordSubmitted = val_2;
        return;
        label_3:
    }
    public void addOnBeforeLevelCompleteAction(System.Action<GameLevel> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnBeforeLevelComplete, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnBeforeLevelComplete, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnBeforeLevelComplete = val_2;
        return;
        label_3:
    }
    public void addOnLevelCompleteAction(System.Action<GameLevel> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnLevelComplete, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnLevelComplete, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnLevelComplete = val_2;
        return;
        label_3:
    }
    public void addOnLevelLoadedAction(System.Action<GameLevel> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.OnLevelLoaded, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.OnLevelLoaded, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.OnLevelLoaded = val_2;
        return;
        label_3:
    }
    public void addOnLevelLoadCompleteAction(System.Action callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.onLevelLoadCompleteAction, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.onLevelLoadCompleteAction, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.onLevelLoadCompleteAction = val_2;
        return;
        label_3:
    }
    public void addOnWordFoundAction(System.Action<string> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.onWordFoundAction, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.onWordFoundAction, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.onWordFoundAction = val_2;
        return;
        label_3:
    }
    public void removeOnWordFoundAction(System.Action<string> callback)
    {
        System.Delegate val_1 = System.Delegate.Remove(source:  this.onWordFoundAction, value:  callback);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.onWordFoundAction = val_1;
        return;
        label_2:
    }
    public void addOnExtraWordFoundAction(System.Action<string> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.onExtraWordFoundAction, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.onExtraWordFoundAction, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.onExtraWordFoundAction = val_2;
        return;
        label_3:
    }
    public void addOnHintUsedAtLocation(System.Action<UnityEngine.Vector3> callback)
    {
        if((this.CheckValidCallback(wordRegionEvent:  this.onHintUsedAtLocation, callback:  callback)) == false)
        {
                return;
        }
        
        System.Delegate val_2 = System.Delegate.Combine(a:  this.onHintUsedAtLocation, b:  callback);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.onHintUsedAtLocation = val_2;
        return;
        label_3:
    }
    private bool CheckValidCallback(System.Delegate wordRegionEvent, System.Delegate callback)
    {
        var val_3;
        if((wordRegionEvent != null) && (wordRegionEvent.invoke_impl != 0))
        {
                val_3 = (~(System.Linq.Enumerable.ToList<System.Delegate>(source:  wordRegionEvent).Contains(item:  callback))) & 1;
            return (bool)val_3;
        }
        
        val_3 = 1;
        return (bool)val_3;
    }
    public void AddLevelCompleteBlocker(LevelCompleteBlockerType blocker)
    {
        bool val_1 = this.levelCompleteBlockers.Add(item:  blocker);
    }
    public void RemoveLevelCompleteBlocker(LevelCompleteBlockerType blocker)
    {
        bool val_1 = this.levelCompleteBlockers.Remove(item:  blocker);
    }
    public static WordRegion get_instance()
    {
        var val_14;
        var val_15;
        string val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        if(((MonoSingleton<WGDailyChallengeManager>.Instance) == 0) || ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false))
        {
            goto label_9;
        }
        
        val_14 = 1152921504879157248;
        val_15 = null;
        val_15 = null;
        val_16 = WordRegion.level_progress_spd_pref_key;
        if(val_16 != 0)
        {
            goto label_82;
        }
        
        val_17 = 1152921515463582112;
        goto label_17;
        label_9:
        val_18 = null;
        val_18 = null;
        if(App.game != 4)
        {
            goto label_23;
        }
        
        val_14 = 1152921504879157248;
        val_19 = null;
        val_19 = null;
        val_16 = WordRegion.level_progress_spd_pref_key;
        if(val_16 != 0)
        {
            goto label_82;
        }
        
        val_17 = 1152921515463583136;
        label_17:
        val_16 = UnityEngine.Object.FindObjectOfType<WordRegionCrossword>();
        val_20 = null;
        WordRegion.level_progress_spd_pref_key = val_16;
        goto label_82;
        label_23:
        val_21 = null;
        val_21 = null;
        if(App.game != 1)
        {
                val_22 = null;
            val_22 = null;
            if(App.game != 7)
        {
                val_23 = null;
            val_23 = null;
            if(App.game != 8)
        {
                val_24 = null;
            val_24 = null;
            if(App.game != 9)
        {
                val_25 = null;
            val_25 = null;
            if(App.game != 10)
        {
                val_26 = null;
            val_26 = null;
            if(App.game != 11)
        {
                val_27 = null;
            val_27 = null;
            if(App.game != 18)
        {
                return (WordRegion)WordRegion.level_progress_spd_pref_key;
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        val_14 = 1152921504879157248;
        val_28 = null;
        val_28 = null;
        val_16 = WordRegion.level_progress_spd_pref_key;
        if(val_16 == 0)
        {
                int val_14 = val_9.Length;
            val_16 = UnityEngine.Resources.FindObjectsOfTypeAll<WordRegion>();
            if(val_14 >= 1)
        {
                var val_15 = 0;
            val_14 = val_14 & 4294967295;
            do
        {
            val_29 = 0;
            if( == 0)
        {
                val_30 = 0;
            if( == 0)
        {
                val_31 = null;
            val_31 = null;
            WordRegion.level_progress_spd_pref_key = null;
        }
        
        }
        
            val_15 = val_15 + 1;
        }
        while(val_15 < (val_9.Length << ));
        
        }
        
        }
        
        label_82:
        val_32 = null;
        return (WordRegion)WordRegion.level_progress_spd_pref_key;
    }
    protected bool get_levelCompleteBlocked()
    {
        return (bool)(this.levelCompleteBlockers != 0) ? 1 : 0;
    }
    protected virtual void Awake()
    {
        this.rt = this.GetComponent<UnityEngine.RectTransform>();
        WGDefinitionManager val_2 = MonoSingletonSelfGenerating<WGDefinitionManager>.Instance;
    }
    private void LateUpdate()
    {
        goto typeof(WordRegion).__il2cppRuntimeField_170;
    }
    public void SetActive(bool state)
    {
        this.gameObject.SetActive(value:  state);
    }
    public int GetTotalAcceptableWords()
    {
        var val_1;
        if(this.validWordsIncluded == true)
        {
                return (int)val_1;
        }
        
        val_1 = this.validWords + 38356;
        return (int)val_1;
    }
    protected string ScrubStar(string word)
    {
        if((word.Contains(value:  "*")) == false)
        {
                return (string)word;
        }
        
        return word.Remove(startIndex:  0, count:  1);
    }
    public static string Debug_GetExtraRequiredWordsInfo()
    {
        var val_14;
        int val_15;
        object[] val_1 = new object[13];
        GameEcon val_2 = App.getGameEcon;
        val_1[0] = val_2.extraReqBeginningChapter;
        GameEcon val_3 = App.getGameEcon;
        val_1[1] = val_3.extraReqDefaultLevelsPerChapter;
        GameEcon val_4 = App.getGameEcon;
        val_1[2] = val_4.extraReqIncrement;
        GameEcon val_5 = App.getGameEcon;
        val_1[3] = val_5.extraReqMaxLevelsPerChapter;
        val_1[4] = MainController.GetHintsPerChapterThreshold();
        GameEcon val_7 = App.getGameEcon;
        val_1[5] = val_7.extraReqQuantityPerLevel;
        Player val_8 = App.Player;
        val_1[6] = val_8.properties.ChaptersPlayedWithoutHints;
        Player val_9 = App.Player;
        val_1[7] = val_9.properties.HintsUsedOnCurrentChapter;
        Player val_10 = App.Player;
        val_1[8] = val_10.properties.LevelsPlayedPostPurchase;
        val_14 = null;
        val_14 = null;
        val_15 = val_1.Length;
        val_1[9] = WADataParser.CurrentLevelGenVersion;
        if(WADataParser.debug_lastReqDetermination != null)
        {
                val_15 = val_1.Length;
        }
        
        val_1[10] = WADataParser.debug_lastReqDetermination;
        val_1[11] = PrettyPrint.printJSON(obj:  WADataParser.debug_extraRequiredWords, types:  false, singleLineOutput:  false);
        val_1[12] = Prefs.currentChapter;
        return (string)System.String.Format(format:  "<color=#6FF154>Economy:\nCurrent Chapter = {12}\nBegin Chapter = {0}\nDefault Levels/CH = {1}\nInc. per no-hint CH = {2}\nMax Levels/CH = {3}\nAllowable Hints/CH = {4}\nExtra Quantity/LVL = {5}\n\n</color><color=#99DAF7>Player Properties:\nChaptersPlayedWithoutHints = {6}\nHintsUsedOnCurrentChapter = {7}\nLevelsPlayedPostPurchase = {8}</color>\n\n<color=#2EF58C>Logic:\n# Extra = {9}\nReason = {10}</color>\n\n<color=#6DE71A>Extra Required Word(s):\n{11}</color>", args:  val_1);
    }
    public virtual void Load(GameLevel gameLevel, System.Action loadCompleteCallback)
    {
        this.gameLevel = gameLevel;
        if(loadCompleteCallback != null)
        {
                this.addOnLevelLoadCompleteAction(callback:  loadCompleteCallback);
        }
        
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.LoadCoroutine());
    }
    private System.Collections.IEnumerator LoadCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegion.<LoadCoroutine>d__70();
    }
    public virtual void UpdateOverlayUI(LineWord word, bool hintUsed = False)
    {
    
    }
    public virtual void UpdateProgressBar()
    {
    
    }
    private System.Collections.IEnumerator LevelLoadCompleteActionCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegion.<LevelLoadCompleteActionCoroutine>d__73();
    }
    private void CheckLinesShowing()
    {
        List.Enumerator<T> val_1 = 38341.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(7 != 0)
        {
            goto label_5;
        }
        
        0.CheckShown();
        goto label_5;
        label_2:
        0.Dispose();
    }
    public virtual void CheckAnswer(string checkWord)
    {
        var val_17;
        var val_18;
        string val_41;
        TextPreview val_42;
        object val_43;
        var val_44;
        var val_45;
        UnityEngine.Object val_46;
        var val_47;
        val_41 = checkWord;
        WordRegion.<>c__DisplayClass75_0 val_1 = null;
        val_43 = 0;
        val_1 = new WordRegion.<>c__DisplayClass75_0();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        .checkWord = val_41;
        if((System.String.IsNullOrEmpty(value:  val_41)) == false)
        {
            goto label_2;
        }
        
        val_42 = this.textPreview;
        if(val_42 != null)
        {
            goto label_3;
        }
        
        throw new NullReferenceException();
        label_2:
        mem[1152921515465777684] = 0;
        this.NotifyPreprocessPlayerTurn(hintUsage:  false, wordEntered:  (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord, lineWord:  0, cell:  0);
        System.Predicate<LineWord> val_3 = null;
        val_43 = val_1;
        val_3 = new System.Predicate<LineWord>(object:  val_1, method:  System.Boolean WordRegion.<>c__DisplayClass75_0::<CheckAnswer>b__0(LineWord x));
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = val_41.Find(match:  val_3);
        val_42 = val_41;
        val_43 = 0;
        if(val_42 == val_43)
        {
            goto label_8;
        }
        
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4.isShown == false)
        {
            goto label_10;
        }
        
        val_42 = this.textPreview;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.SetExistColor();
        val_43 = 0;
        val_41.ShowExists();
        if((MonoSingleton<WGAudioController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_6.sound;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 6;
        val_42.PlayGeneralSound(type:  val_43, oneshot:  true, pitch:  1f, vol:  1f);
        val_44 = 1152921515465777728;
        goto label_33;
        label_8:
        val_42 = this.validWords;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
        bool val_7 = val_42.Contains(item:  val_43);
        if(ExtraWord.GAMETYPE_CATEGORY_LEVELS == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
        val_41 = val_7;
        if((ExtraWord.GAMETYPE_CATEGORY_LEVELS.ProcessWord(word:  val_43, lines:  public System.Boolean System.Collections.Generic.List<System.String>::Contains(System.String item), isWord:  val_7)) == false)
        {
            goto label_19;
        }
        
        if(this.onExtraWordFoundAction != null)
        {
                val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
            this.onExtraWordFoundAction.Invoke(obj:  val_43);
        }
        
        val_44 = this;
        val_42 = this.textPreview;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        val_42.SetValidColor();
        MainController val_10 = MainController.instance;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.ExtraWordsFound = val_10.extraWordsFound + 1;
        val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
        this.NotifyWordSubmitted(word:  val_43, valid:  true, isExtra:  true);
        goto label_33;
        label_19:
        val_44 = this;
        val_42 = this.textPreview;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        val_42.SetWrongColor();
        if(((WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_12 = (((WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord.m_stringLength) < 3) ? 1 : 0;
        val_12 = val_41 | val_12;
        if(val_12 != true)
        {
                val_42.PostGoldenApplesNotif(valid:  false, isHint:  false);
            val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
            this.NotifyWordSubmitted(word:  val_43, valid:  false, isExtra:  false);
        }
        
        this.correctChainCount = 0;
        if((MonoSingleton<WGAudioController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_13.sound;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 5;
        val_42.PlayGeneralSound(type:  5, oneshot:  true, pitch:  1f, vol:  1f);
        goto label_33;
        label_10:
        val_45 = null;
        if(WordRegion.EnabledNonAlphabeticalWords() == false)
        {
            goto label_104;
        }
        
        val_43 = 0;
        int val_15 = val_41.numLettersFound;
        if(val_15 != 0)
        {
            goto label_104;
        }
        
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_16 = val_15.GetEnumerator();
        label_45:
        val_43 = public System.Boolean List.Enumerator<LineWord>::MoveNext();
        if(val_18.MoveNext() == false)
        {
            goto label_39;
        }
        
        val_46 = val_17;
        if(val_46 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_17 + 56) != 0)
        {
            goto label_45;
        }
        
        val_42 = val_46;
        val_43 = 0;
        if(val_42.numLettersFound > 0)
        {
            goto label_45;
        }
        
        if(val_4.answer == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4.answer.m_stringLength != (val_17 + 24 + 16))
        {
            goto label_45;
        }
        
        mem2[0] = val_4.answer;
        val_4.answer = val_17 + 24;
        val_46.ReBuild();
        val_41.ReBuild();
        goto label_46;
        label_39:
        val_46 = val_41;
        label_46:
        val_43 = public System.Void List.Enumerator<LineWord>::Dispose();
        val_18.Dispose();
        val_41 = val_46;
        label_104:
        val_44 = this;
        val_42 = this.textPreview;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.SetAnswerColor();
        val_43 = 1;
        val_42.PostGoldenApplesNotif(valid:  true, isHint:  false);
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = val_4.answer;
        this.NotifyWordSubmitted(word:  val_43, valid:  true, isExtra:  false);
        if(val_4.isStarred != false)
        {
                GameEcon val_21 = App.getGameEcon;
            if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
            GameEcon val_22 = val_21 + 452;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_21.wordCoinBonus.flags, hi = val_21.wordCoinBonus.flags, lo = 366026752, mid = 268435456}, source:  "Word Coin Bonus", externalParams:  0, animated:  false);
        }
        
        val_43 = 0;
        val_47 = 0f;
        if((MonoSingleton<Alphabet2Manager>.Instance) != val_43)
        {
                if((MonoSingleton<Alphabet2Manager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        val_43 = 0;
        val_41.ShowAnswer(waitTime:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished == 0) ? 0f : 0.6f);
        MainController val_28 = MainController.instance;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = val_4.answer;
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28.WordsCompleted = val_29.wordsCompleted + val_43 + "|"("|");
        int val_40 = this.correctChainCount;
        val_40 = val_40 + 1;
        this.correctChainCount = val_40;
        val_43 = 0;
        bool val_31 = UnityEngine.Object.op_Implicit(exists:  this.compliment);
        if(val_31 != false)
        {
                val_43 = val_41;
            if((System.Linq.Enumerable.Last<LineWord>(source:  val_31)) != val_43)
        {
                if(this.correctChainCount < 3)
        {
            goto label_79;
        }
        
        }
        
            if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
            val_42 = val_34.<metaGameBehavior>k__BackingField;
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_42 >= 3)
        {
                val_42 = this.compliment;
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            val_43 = 0;
            val_42.ShowRandom();
        }
        
        }
        
        label_79:
        this.CheckLinesShowing();
        if(this.onWordFoundAction != null)
        {
                val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
            this.onWordFoundAction.Invoke(obj:  val_43);
        }
        
        this.CheckGameComplete();
        if((MonoSingleton<WGAudioController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_35.sound;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 4;
        val_42.PlayGeneralSound(type:  val_43, oneshot:  true, pitch:  1f, vol:  1f);
        WGDailyChallengeManager val_36 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        if(val_36.PlayingChallenge != true)
        {
                val_43 = 0;
            WGGenericNotificationsManager.SendLevelAnwserNotification(nextWord:  this.GetFirstIncompleteWord(), QAHACK_Force:  false);
        }
        
        val_42 = this.onWordFound;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        val_42.Invoke();
        val_42 = this.ExtraRequiredList;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord;
        if((val_42.Contains(item:  val_43)) != false)
        {
                val_42 = ExtraWord.GAMETYPE_CATEGORY_LEVELS;
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            val_42.CheckRequiredExtraWord(word:  (WordRegion.<>c__DisplayClass75_0)[1152921515465813744].checkWord);
        }
        
        label_33:
        val_42 = val_42;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        label_3:
        val_42.FadeOut();
    }
    public static bool EnabledNonAlphabeticalWords()
    {
        bool val_4;
        if(App.Player >= 3)
        {
                if(App.Player <= 24)
        {
            goto label_8;
        }
        
        }
        
        val_4 = 0;
        return val_4;
        label_8:
        GameEcon val_3 = App.getGameEcon;
        val_4 = val_3.jumbledWords;
        return val_4;
    }
    private void PostGoldenApplesNotif(bool valid, bool isHint = False)
    {
        UnityEngine.Debug.LogWarning(message:  "WordRegion: Would PostGoldenApplesNotif() -valid "("WordRegion: Would PostGoldenApplesNotif() -valid ") + valid.ToString() + " -isHint "(" -isHint ") + isHint.ToString());
    }
    private void NotifyPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
        if(this.OnPreprocessPlayerTurn == null)
        {
                return;
        }
        
        hintUsage = hintUsage;
        this.OnPreprocessPlayerTurn.Invoke(arg1:  hintUsage, arg2:  wordEntered, arg3:  lineWord, arg4:  cell);
    }
    private void NotifyWordSubmitted(string word, bool valid, bool isExtra)
    {
        if(valid != false)
        {
                if(this.OnValidWordSubmitted == null)
        {
                return;
        }
        
            this.OnValidWordSubmitted.Invoke(arg1:  word, arg2:  isExtra);
            return;
        }
        
        if(this.OnInvalidWordSubmitted == null)
        {
                return;
        }
        
        this.OnInvalidWordSubmitted.Invoke();
    }
    private void NotifyLevelLoaded(GameLevel level)
    {
        if(this.OnLevelLoaded == null)
        {
                return;
        }
        
        this.OnLevelLoaded.Invoke(obj:  level);
    }
    private void NotifyBeforeLevelComplete(GameLevel level)
    {
        if(this.OnBeforeLevelComplete == null)
        {
                return;
        }
        
        this.OnBeforeLevelComplete.Invoke(obj:  level);
    }
    private void NotifyLevelComplete(GameLevel level)
    {
        if(this.OnLevelComplete == null)
        {
                return;
        }
        
        this.OnLevelComplete.Invoke(obj:  level);
    }
    private void NotifyHintUsed(string word, int index, bool isFree, bool isPickerHint)
    {
        if(this.OnHintedUsed == null)
        {
                return;
        }
        
        isFree = isFree;
        isPickerHint = isPickerHint;
        this.OnHintedUsed.Invoke(arg1:  word, arg2:  index, arg3:  isFree, arg4:  isPickerHint);
    }
    public void CheckGameComplete()
    {
        var val_6;
        System.Predicate<LineWord> val_8;
        val_6 = null;
        val_6 = null;
        val_8 = WordRegion.<>c.<>9__84_0;
        if(val_8 == null)
        {
                System.Predicate<LineWord> val_1 = null;
            val_8 = val_1;
            val_1 = new System.Predicate<LineWord>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<CheckGameComplete>b__84_0(LineWord x));
            WordRegion.<>c.<>9__84_0 = val_8;
        }
        
        if((Find(match:  val_1)) != 0)
        {
                return;
        }
        
        if(this.levelCompleteCoroutine == null)
        {
                this.levelCompleteCoroutine = this.StartCoroutine(routine:  this.DoLevelCompleteActions());
        }
        
        this.onBeforeLevelComplete.Invoke();
    }
    private System.Collections.IEnumerator DoLevelCompleteActions()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegion.<DoLevelCompleteActions>d__86();
    }
    public virtual void HintReward()
    {
        var val_25;
        var val_26;
        System.Func<LineWord, System.Int32> val_28;
        var val_29;
        System.Func<LineWord, System.Int32> val_31;
        var val_32;
        System.Func<LineWord, System.Boolean> val_34;
        val_25 = this;
        val_26 = null;
        val_26 = null;
        val_28 = WordRegion.<>c.<>9__87_0;
        if(val_28 == null)
        {
                System.Func<LineWord, System.Int32> val_1 = null;
            val_28 = val_1;
            val_1 = new System.Func<LineWord, System.Int32>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordRegion.<>c::<HintReward>b__87_0(LineWord x));
            WordRegion.<>c.<>9__87_0 = val_28;
        }
        
        val_29 = null;
        val_29 = null;
        val_31 = WordRegion.<>c.<>9__87_1;
        if(val_31 == null)
        {
                System.Func<LineWord, System.Int32> val_3 = null;
            val_31 = val_3;
            val_3 = new System.Func<LineWord, System.Int32>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordRegion.<>c::<HintReward>b__87_1(LineWord x));
            WordRegion.<>c.<>9__87_1 = val_31;
        }
        
        val_32 = null;
        val_32 = null;
        val_34 = WordRegion.<>c.<>9__87_2;
        if(val_34 == null)
        {
                System.Func<LineWord, System.Boolean> val_5 = null;
            val_34 = val_5;
            val_5 = new System.Func<LineWord, System.Boolean>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<HintReward>b__87_2(LineWord x));
            WordRegion.<>c.<>9__87_2 = val_34;
        }
        
        LineWord val_6 = System.Linq.Enumerable.FirstOrDefault<LineWord>(source:  System.Linq.Enumerable.ThenBy<LineWord, System.Int32>(source:  System.Linq.Enumerable.OrderByDescending<LineWord, System.Int32>(source:  41967616, keySelector:  val_1), keySelector:  val_3), predicate:  val_5);
        if(val_6 == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_8 = val_6.ShowHint(cell:  0);
        if(val_6.isShown != false)
        {
                if(val_6.isStarred != false)
        {
                GameEcon val_10 = App.getGameEcon + 452;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_9.wordCoinBonus.flags, hi = val_9.wordCoinBonus.flags, lo = 366026752, mid = 268435456}, source:  "Word Coin Bonus", externalParams:  0, animated:  false);
        }
        
            val_9.wordCoinBonus.flags.PostGoldenApplesNotif(valid:  true, isHint:  true);
            this.NotifyWordSubmitted(word:  val_6.answer, valid:  true, isExtra:  false);
            WGAudioController val_11 = MonoSingleton<WGAudioController>.Instance;
            val_11.sound.PlayGeneralSound(type:  4, oneshot:  true, pitch:  1f, vol:  1f);
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                WGGenericNotificationsManager.SendLevelAnwserNotification(nextWord:  this.GetFirstIncompleteWord(), QAHACK_Force:  false);
        }
        
        }
        
        this.CheckGameComplete();
        val_34 = Prefs.currentChapter;
        Prefs.AddToNumHint(world:  Prefs.currentWorld, subWorld:  val_34, level:  Prefs.currentLevel);
        val_8.z = val_8.z + (-20f);
        UnityEngine.Vector3 val_19 = new UnityEngine.Vector3(x:  val_8.x, y:  val_8.y, z:  val_8.z);
        this.hintEffect.transform.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        this.hintEffect.Play();
        WGAudioController val_20 = MonoSingleton<WGAudioController>.Instance;
        val_20.sound.PlayGeneralSound(type:  9, oneshot:  true, pitch:  1f, vol:  1f);
        MainController val_21 = MainController.instance;
        val_25 = val_21;
        MainController val_22 = val_21 + 1;
        Player val_23 = App.Player;
        int val_25 = val_23.properties.HintsUsedOnCurrentChapter;
        val_25 = val_25 + 1;
        val_23.properties.HintsUsedOnCurrentChapter = val_25;
        Player val_24 = App.Player;
        val_24.properties.Save(writePrefs:  true);
    }
    public void OnHintDemoEnable()
    {
        this._hintDemoFTUX = true;
    }
    public void OnHintDemoDisable()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FrameAfterHintDemo());
    }
    private System.Collections.IEnumerator FrameAfterHintDemo()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegion.<FrameAfterHintDemo>d__90();
    }
    public virtual void HintClick(bool free = False, LineWord line, Cell cell, bool isPickerHint = False)
    {
        Cell val_96;
        System.Func<LineWord, System.Boolean> val_97;
        UnityEngine.Object val_98;
        bool val_99;
        var val_100;
        decimal val_101;
        int val_102;
        var val_103;
        float val_105;
        int val_106;
        var val_107;
        var val_108;
        var val_109;
        System.Func<LineWord, System.Int32> val_111;
        int val_112;
        var val_113;
        LineWord val_114;
        var val_115;
        int val_117;
        var val_119;
        var val_120;
        var val_121;
        var val_122;
        var val_123;
        var val_124;
        var val_125;
        var val_126;
        var val_127;
        var val_128;
        var val_129;
        var val_130;
        val_96 = cell;
        val_97 = free;
        val_98 = this;
        LineWord val_5 = line;
        if(WGFTUXManager.IsShowing == true)
        {
                return;
        }
        
        if(this._hintDemoFTUX != false)
        {
                if(val_97 == false)
        {
                return;
        }
        
        }
        
        HintFeatureManager val_2 = MonoSingleton<HintFeatureManager>.Instance;
        mem[1152921515468366212] = 0;
        val_99 = isPickerHint;
        MonoSingleton<WordGameEventsController>.Instance.OnHintForceEventLineWord(lines:  free, word: ref  val_5, isPickerHint:  val_99);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        decimal val_7 = CurrencyController.GetBalance();
        val_100 = 1152921504884269056;
        if(isPickerHint == false)
        {
            goto label_10;
        }
        
        GameEcon val_8 = App.getGameEcon;
        val_101 = val_8._HintPickerCost;
        goto label_34;
        label_10:
        GameBehavior val_9 = App.getBehavior;
        if((((val_9.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels) == false))
        {
            goto label_23;
        }
        
        val_103 = null;
        goto label_29;
        label_23:
        val_103 = null;
        if(this.gameLevel.isChallengingLevel == false)
        {
            goto label_27;
        }
        
        label_29:
        GameEcon val_12 = App.getGameEcon;
        GameEcon val_13 = App.getGameEcon;
        decimal val_14 = System.Decimal.op_Implicit(value:  val_13.difficultySettingHintDiscount);
        val_99 = val_14.lo;
        decimal val_15 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_12._HintCost, hi = val_12._HintCost, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_99, mid = val_14.mid});
        val_101 = val_15.flags;
        val_102 = val_15.lo;
        goto label_34;
        label_27:
        GameEcon val_16 = App.getGameEcon;
        val_101 = val_16._HintCost;
        label_34:
        GameBehavior val_17 = App.getBehavior;
        if((((val_17.<metaGameBehavior>k__BackingField) & 1) != 0) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true))
        {
                bool val_20 = isPickerHint;
            val_105 = WADPetsManager.GetLevelCurveModifier(ability:  val_20);
            decimal val_22 = System.Decimal.op_Explicit(value:  val_105);
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_22.lo, mid = val_22.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                decimal val_24 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_101, hi = val_101, lo = X28, mid = X28}, d2:  new System.Decimal() {flags = val_22.flags, hi = val_22.hi, lo = val_22.lo, mid = val_22.mid});
            WADPets.WADPet val_25 = WADPetsManager.GetPetByAbility(ability:  val_20);
            mem2[0] = val_25.Info.Name;
            val_6.Add(key:  System.String.Format(format:  "Pet Ability: {0} Discount", arg0:  val_25.Info.Name.ToString()), value:  val_22);
            val_100 = 1152921504884269056;
            val_102 = val_24.lo;
            val_101 = val_24.flags;
        }
        else
        {
                val_102 = X28;
            val_100 = 1152921504884269056;
        }
        
        }
        
        UnityEngine.Debug.LogError(message:  "WGChallengeWordsManager");
        if(((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGChallengeWordsManager>.Instance)) != false) && (WGChallengeWordsManager.IsFeatureUnlocked != false))
        {
                if((MonoSingleton<WGChallengeWordsManager>.Instance.IsPlaying) != false)
        {
                val_6.Add(key:  "Challenge Level Hint", value:  true);
        }
        
        }
        
        if(SeasonPassEventHandler.IsPlusPassActive == false)
        {
            goto label_70;
        }
        
        val_106 = val_101;
        val_107 = 1152921504765632512;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
            goto label_77;
        }
        
        if(isPickerHint == false)
        {
            goto label_75;
        }
        
        int val_36 = SeasonPassEventHandler.PassPickHintDiscount;
        goto label_76;
        label_70:
        val_107 = 1152921504765632512;
        val_106 = val_101;
        goto label_77;
        label_75:
        label_76:
        decimal val_38 = System.Decimal.op_Implicit(value:  SeasonPassEventHandler.PassHintDiscount);
        decimal val_39 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_106, hi = val_106, lo = val_102, mid = val_102}, d2:  new System.Decimal() {flags = val_38.flags, hi = val_38.hi, lo = val_38.lo, mid = val_38.mid});
        val_106 = val_39.flags;
        val_102 = val_39.lo;
        label_77:
        bool val_40 = isPickerHint ^ 1;
        val_40 = ((val_2.freeHintOnLastCheck == true) ? 1 : 0) & val_40;
        bool val_41 = val_40 | val_97;
        val_108 = null;
        val_96 = val_96;
        if((val_41 | (System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, d2:  new System.Decimal() {flags = val_106, hi = val_39.hi, lo = val_102, mid = val_39.mid}))) == false)
        {
            goto label_82;
        }
        
        if(isPickerHint != true)
        {
                MonoSingleton<HintFeatureManager>.Instance.OnHintUsed(wasFree:  val_41);
        }
        
        if(val_5 != 0)
        {
            goto label_89;
        }
        
        val_109 = null;
        val_109 = null;
        val_111 = WordRegion.<>c.<>9__91_0;
        if(val_111 != null)
        {
            goto label_92;
        }
        
        val_112 = val_106;
        goto label_119;
        label_82:
        decimal val_47 = CurrencyController.GetBalance();
        this.ooc_coins = val_47;
        mem[1152921515468366328] = val_47.lo;
        mem[1152921515468366332] = val_47.mid;
        val_113 = null;
        val_96 = 1152921504758390784;
        goto label_103;
        label_89:
        val_114 = val_5;
        goto label_102;
        label_103:
        PurchaseProxy.currentPurchasePoint = (CategoryPacksManager.IsPlaying != true) ? 117 : 6;
        UnityEngine.Debug.LogError(message:  "OOC good so far");
        if(WGStarterPackController.featureRelavent == false)
        {
            goto label_106;
        }
        
        WGWindowManager val_52 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
        WGStarterPackController val_53 = MonoSingleton<WGStarterPackController>.Instance;
        val_53._ap = 47;
        goto label_128;
        label_106:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  0);
        goto label_128;
        label_119:
        System.Func<LineWord, System.Int32> val_56 = null;
        val_111 = val_56;
        val_56 = new System.Func<LineWord, System.Int32>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordRegion.<>c::<HintClick>b__91_0(LineWord x));
        val_106 = ;
        val_102 = val_102;
        WordRegion.<>c.<>9__91_0 = val_111;
        val_107 = 1152921504765632512;
        label_92:
        val_115 = null;
        val_115 = null;
        val_97 = WordRegion.<>c.<>9__91_1;
        if(val_97 == null)
        {
                val_117 = val_106;
            System.Func<LineWord, System.Boolean> val_58 = null;
            val_97 = val_58;
            val_58 = new System.Func<LineWord, System.Boolean>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<HintClick>b__91_1(LineWord x));
            val_106 = ;
            val_102 = val_102;
            WordRegion.<>c.<>9__91_1 = val_97;
            val_107 = 1152921504765632512;
        }
        
        LineWord val_59 = System.Linq.Enumerable.FirstOrDefault<LineWord>(source:  System.Linq.Enumerable.OrderBy<LineWord, System.Int32>(source:  val_5, keySelector:  val_56), predicate:  val_58);
        val_100 = 1152921504884269056;
        val_114 = val_59;
        label_102:
        if(val_114 == 0)
        {
            goto label_128;
        }
        
        UnityEngine.Vector3 val_61 = UnityEngine.Vector3.zero;
        if(val_96 != 0)
        {
            goto label_134;
        }
        
        val_96 = val_59.ShowHintGetCell(cell:  val_96);
        if(val_96 != 0)
        {
            goto label_137;
        }
        
        UnityEngine.Debug.LogWarning(message:  "Could not get cell for hint, cancel!", context:  this);
        return;
        label_134:
        UnityEngine.Vector3 val_65 = val_59.ShowHint(cell:  val_96);
        label_137:
        UnityEngine.Vector3 val_67 = val_96.transform.position;
        val_105 = val_67.x;
        this.NotifyPreprocessPlayerTurn(hintUsage:  true, wordEntered:  0, lineWord:  val_59, cell:  val_96);
        this.NotifyHintUsed(word:  val_59 + 24, index:  val_59.GetHintCellIndex(cell:  val_96), isFree:  val_41, isPickerHint:  isPickerHint);
        if(isPickerHint != true)
        {
                if((MonoSingleton<HintFeatureManager>.Instance) != 0)
        {
                UnityEngine.Transform val_73 = cell + 32.transform;
            val_73.DoHintAnimation(letterGroup:  val_73, startTransform:  0);
        }
        
        }
        
        if(this.onHintUsedAtLocation != null)
        {
                this.onHintUsedAtLocation.Invoke(obj:  new UnityEngine.Vector3() {x = val_105, y = val_67.y, z = val_67.z});
        }
        
        if(val_41 != true)
        {
                bool val_75 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_106, hi = val_39.hi, lo = val_102, mid = val_39.mid}, source:  (isPickerHint != true) ? "Picker Hint" : "Hint", externalParams:  val_6, animated:  false);
        }
        
        val_96 = Prefs.currentWorld;
        Prefs.AddToNumHint(world:  val_96, subWorld:  Prefs.currentChapter, level:  Prefs.currentLevel);
        if(isPickerHint != false)
        {
                Prefs.HasUsedHintPicker = true;
            val_119 = MainController.instance;
        }
        else
        {
                Prefs.UsedHint(free:  val_41);
            MainController val_81 = MainController.instance;
            val_119 = val_81;
        }
        
        MainController val_82 = val_81 + 1;
        if(val_41 != false)
        {
                Player val_83 = App.Player;
            val_83.properties.Save(writePrefs:  true);
        }
        
        UnityEngine.Vector3 val_86 = new UnityEngine.Vector3(x:  val_105, y:  val_67.y, z:  val_67.z + (-20f));
        this.hintEffect.transform.position = new UnityEngine.Vector3() {x = val_86.x, y = val_86.y, z = val_86.z};
        this.hintEffect.Play();
        WGAudioController val_87 = MonoSingleton<WGAudioController>.Instance;
        val_120 = 0;
        val_87.sound.PlayGeneralSound(type:  9, oneshot:  true, pitch:  1f, vol:  1f);
        if(val_41 != false)
        {
                MainController.instance.FreeHintsUsed = true;
        }
        else
        {
                NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnHintUsed");
            val_121 = null;
            val_121 = null;
            App.trackerManager.track(eventName:  Events.HINT_USED);
            val_122 = null;
            val_122 = null;
            val_96 = Events.HINT_USED;
            Player val_90 = App.Player;
            val_120 = 0;
            App.trackerManager.track(eventName:  System.String.Format(format:  "{0}_{1}", arg0:  val_96, arg1:  val_90.properties.LifetimeHints));
            Player val_92 = App.Player;
            int val_95 = val_92.properties.HintsUsedOnCurrentChapter;
            val_95 = val_95 + 1;
            val_92.properties.HintsUsedOnCurrentChapter = val_95;
        }
        
        this.CheckLinesShowing();
        this.CheckGameComplete();
        label_128:
        val_123 = null;
        val_123 = null;
        if(App.game == 1)
        {
            goto label_239;
        }
        
        val_124 = null;
        val_124 = null;
        if(App.game == 4)
        {
            goto label_239;
        }
        
        val_125 = null;
        val_125 = null;
        if(App.game == 7)
        {
            goto label_239;
        }
        
        val_126 = null;
        val_126 = null;
        if(App.game == 8)
        {
            goto label_239;
        }
        
        val_127 = null;
        val_127 = null;
        if(App.game == 9)
        {
            goto label_239;
        }
        
        val_128 = null;
        val_128 = null;
        if(App.game == 10)
        {
            goto label_239;
        }
        
        val_129 = null;
        val_129 = null;
        if(App.game == 11)
        {
            goto label_239;
        }
        
        val_130 = null;
        val_130 = null;
        if(App.game != 18)
        {
            goto label_245;
        }
        
        label_239:
        WGAudioController val_93 = MonoSingleton<WGAudioController>.Instance;
        val_93.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
        return;
        label_245:
        Sound.instance.PlayButton(type:  0);
    }
    public virtual void DoFreeHint(LineWord line, Cell cell, UnityEngine.Transform hintAnimStartTransform)
    {
        if(line == 0)
        {
                return;
        }
        
        if(cell == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_3 = line.ShowHint(cell:  cell);
        if(this.onHintUsedAtLocation != null)
        {
                this.onHintUsedAtLocation.Invoke(obj:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        }
        
        if((MonoSingleton<HintFeatureManager>.Instance) != 0)
        {
                UnityEngine.Transform val_6 = cell.letterGroup.transform;
            val_6.DoHintAnimation(letterGroup:  val_6, startTransform:  hintAnimStartTransform);
        }
        
        UnityEngine.Vector3 val_9 = cell.transform.position;
        this.hintEffect.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        this.hintEffect.Play();
        WGAudioController val_10 = MonoSingleton<WGAudioController>.Instance;
        val_10.sound.PlayGeneralSound(type:  9, oneshot:  true, pitch:  1f, vol:  1f);
        this.CheckLinesShowing();
        this.CheckGameComplete();
    }
    protected virtual void ApplyHintToLine(LineWord line, Cell cell)
    {
        if(line.isShown != false)
        {
                if(line.isStarred != false)
        {
                GameEcon val_2 = App.getGameEcon + 452;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_1.wordCoinBonus.flags, hi = val_1.wordCoinBonus.flags, lo = 366026752, mid = 268435456}, source:  "Word Coin Bonus", externalParams:  0, animated:  false);
        }
        
            val_1.wordCoinBonus.flags.PostGoldenApplesNotif(valid:  true, isHint:  true);
            this.NotifyWordSubmitted(word:  line.answer, valid:  true, isExtra:  false);
            WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGeneralSound(type:  4, oneshot:  true, pitch:  1f, vol:  1f);
            if(this.onWordFoundAction != null)
        {
                this.onWordFoundAction.Invoke(obj:  line.answer);
        }
        
            if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnSubmitWordWithHints(word:  line.answer);
        }
        
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                line = this.GetFirstIncompleteWord();
            WGGenericNotificationsManager.SendLevelAnwserNotification(nextWord:  line, QAHACK_Force:  false);
        }
        
            this.textPreview.FadeOut();
            return;
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnHintIncompleteWord(word:  line.answer, hintedCell:  cell);
    }
    public virtual void MegalHint(LineWord line, Cell cell)
    {
        if(WGFTUXManager.IsShowing != false)
        {
                return;
        }
        
        if(line.isShown != false)
        {
                if(line.isStarred != false)
        {
                GameEcon val_3 = App.getGameEcon + 452;
            CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2.wordCoinBonus.flags, hi = val_2.wordCoinBonus.flags, lo = 366026752, mid = 268435456}, source:  "Word Coin Bonus", externalParams:  0, animated:  false);
        }
        
            val_2.wordCoinBonus.flags.PostGoldenApplesNotif(valid:  true, isHint:  true);
            this.NotifyWordSubmitted(word:  line.answer, valid:  true, isExtra:  false);
            WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
            val_4.sound.PlayGeneralSound(type:  4, oneshot:  true, pitch:  1f, vol:  1f);
            if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnSubmitWordWithHints(word:  line.answer);
        }
        
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true)
        {
                WGGenericNotificationsManager.SendLevelAnwserNotification(nextWord:  this.GetFirstIncompleteWord(), QAHACK_Force:  false);
        }
        
        }
        
        UnityEngine.Vector3 val_13 = cell.transform.position;
        this.hintEffect.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        this.hintEffect.Play();
        WGAudioController val_14 = MonoSingleton<WGAudioController>.Instance;
        val_14.sound.PlayGeneralSound(type:  9, oneshot:  true, pitch:  1f, vol:  1f);
        this.CheckLinesShowing();
        this.CheckGameComplete();
        WGAudioController val_15 = MonoSingleton<WGAudioController>.Instance;
        val_15.sound.PlayButtonSound(type:  0, pitch:  1f, vol:  1f);
    }
    public System.Collections.Generic.List<string> GetCompletedWords()
    {
        System.Collections.Generic.IEnumerable<TSource> val_6;
        var val_7;
        System.Predicate<LineWord> val_9;
        var val_12;
        System.Func<LineWord, System.String> val_14;
        val_7 = null;
        val_7 = null;
        val_9 = WordRegion.<>c.<>9__95_0;
        if(val_9 == null)
        {
                System.Predicate<LineWord> val_1 = null;
            val_9 = val_1;
            val_1 = new System.Predicate<LineWord>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<GetCompletedWords>b__95_0(LineWord x));
            WordRegion.<>c.<>9__95_0 = val_9;
        }
        
        System.Collections.Generic.List<T> val_2 = this.FindAll(match:  val_1);
        if(val_2 == null)
        {
                return (System.Collections.Generic.List<System.String>)System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<LineWord, System.String>(source:  val_6 = val_2, selector:  System.Func<LineWord, System.String> val_3 = null));
        }
        
        val_12 = null;
        val_12 = null;
        val_14 = WordRegion.<>c.<>9__95_1;
        if(val_14 != null)
        {
                return (System.Collections.Generic.List<System.String>)System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<LineWord, System.String>(source:  val_6, selector:  val_3));
        }
        
        val_14 = val_3;
        val_3 = new System.Func<LineWord, System.String>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.String WordRegion.<>c::<GetCompletedWords>b__95_1(LineWord x));
        WordRegion.<>c.<>9__95_1 = val_14;
        return (System.Collections.Generic.List<System.String>)System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Select<LineWord, System.String>(source:  val_6, selector:  val_3));
    }
    public string GetFirstIncompleteWord()
    {
        var val_4;
        System.Func<LineWord, System.Boolean> val_6;
        string val_7;
        val_4 = null;
        val_4 = null;
        val_6 = WordRegion.<>c.<>9__96_0;
        if(val_6 == null)
        {
                System.Func<LineWord, System.Boolean> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<LineWord, System.Boolean>(object:  WordRegion.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordRegion.<>c::<GetFirstIncompleteWord>b__96_0(LineWord x));
            WordRegion.<>c.<>9__96_0 = val_6;
        }
        
        val_7 = 0;
        if((System.Linq.Enumerable.FirstOrDefault<LineWord>(source:  this, predicate:  val_1)) == 0)
        {
                return val_7;
        }
        
        val_7 = val_2.answer;
        return val_7;
    }
    private string GetLevelProgressPrefKey()
    {
        var val_5;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_5 = "lvl_prog_daily_challenge3";
            return (string)val_5;
        }
        
        if(CategoryPacksManager.IsPlaying != false)
        {
                return MonoSingleton<CategoryPacksManager>.Instance.LevelProgressPrefKey;
        }
        
        val_5 = "level_progress2";
        return (string)val_5;
    }
    protected string GetExtraRequiredWordsProgressPrefKey()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return "xtra_req_words_daily_challenge1";
        }
        
        if(CategoryPacksManager.IsPlaying == false)
        {
                return WordRegion.extra_req_words_pref_key;
        }
        
        return MonoSingleton<CategoryPacksManager>.Instance.LevelExtraRequiredWordsProgressPrefKey;
    }
    private void DoHintAnimation(UnityEngine.Transform letterGroup, UnityEngine.Transform startTransform)
    {
        UnityEngine.Transform val_23 = startTransform;
        if(val_23 == 0)
        {
                HintFeatureManager val_3 = MonoSingleton<HintFeatureManager>.Instance;
            val_23 = val_3.<wgHbutton>k__BackingField.transform;
        }
        
        UnityEngine.Vector3 val_5 = val_23.position;
        letterGroup.position = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        .ps = 0;
        .removeGroup = UnityEngine.Object.op_Equality(x:  letterGroup.GetComponent<UnityEngine.Canvas>(), y:  0);
        if(MonoUtils.instance.tileTrailEffect != 0)
        {
                UnityEngine.ParticleSystem val_10 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  MonoUtils.instance.tileTrailEffect, parent:  letterGroup, worldPositionStays:  false);
            .ps = val_10;
            UnityEngine.Vector3 val_12 = UnityEngine.Vector3.zero;
            UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            val_10.GetComponent<UnityEngine.RectTransform>().anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
        }
        
        UnityEngine.Canvas val_14 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.Canvas>(child:  letterGroup);
        .cg = val_14;
        val_14.overrideSorting = true;
        (WordRegion.<>c__DisplayClass99_0)[1152921515470140480].cg.sortingLayerName = "Immediate";
        DG.Tweening.Sequence val_15 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_15);
        UnityEngine.Vector3 val_17 = UnityEngine.Vector3.zero;
        DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_15, t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  letterGroup, endValue:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, duration:  0.4f, snapping:  false));
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_15, interval:  0.05f);
        mem2[0] = new DG.Tweening.TweenCallback(object:  new WordRegion.<>c__DisplayClass99_0(), method:  System.Void WordRegion.<>c__DisplayClass99_0::<DoHintAnimation>b__0());
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenExtensions.Play<DG.Tweening.Sequence>(t:  val_15);
    }
    public virtual void SaveLevelProgress()
    {
        var val_3;
        var val_4;
        WordRegion val_21;
        var val_23;
        System.String[] val_27;
        System.String[] val_28;
        string val_29;
        val_21 = this;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  this.gameLevel.answers);
        List.Enumerator<T> val_2 = val_1.GetEnumerator();
        var val_22 = 0;
        label_14:
        if(val_4.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_23 = val_3;
        System.Text.StringBuilder val_6 = new System.Text.StringBuilder();
        if(val_23 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_7 = val_3 + 40.GetEnumerator();
        label_10:
        if(val_4.MoveNext() == false)
        {
            goto label_7;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_10 = val_6.Append(value:  ((val_3 + 72) == 0) ? "0" : "1");
        goto label_10;
        label_7:
        val_22 = val_22 + 1;
        val_23 = 0;
        mem2[0] = 126;
        val_4.Dispose();
        if(val_23 != 0)
        {
                throw val_23;
        }
        
        if(val_22 != 1)
        {
                var val_11 = ((1152921515470351728 + ((0 + 1)) << 2) == 126) ? 1 : 0;
            val_11 = ((val_22 >= 0) ? 1 : 0) & val_11;
            val_22 = val_22 - val_11;
        }
        
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_6);
        goto label_14;
        label_4:
        var val_13 = val_22 + 1;
        mem2[0] = 163;
        val_4.Dispose();
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_24;
        }
        
        if((PlayingLevel.GetCategoryLevel(categoryPackId:  0)) != null)
        {
            goto label_27;
        }
        
        goto label_31;
        label_24:
        if((PlayingLevel.GetLevel(currentMode:  PlayingLevel.CurrentGameplayMode, parameters:  0)) == null)
        {
            goto label_31;
        }
        
        label_27:
        val_17.levelProgress = val_1;
        label_31:
        PlayingLevel.Save();
        val_27 = mem[mem[1152921515470364256] + 24];
        val_27 = mem[1152921515470364256] + 24;
        string val_18 = this.GetExtraRequiredWordsProgressPrefKey();
        if(val_27 >= 1)
        {
                val_28 = mem[1152921515470364256].ToArray();
            val_29 = val_18;
        }
        else
        {
                string[] val_20 = new string[1];
            val_21 = "n/a";
            val_27 = val_20;
            val_29 = val_18;
            val_28 = val_27;
            val_27[0] = "n/a";
        }
        
        bool val_21 = CryptoPlayerPrefsX.SetStringArray(key:  val_29, stringArray:  val_20);
    }
    public string[] GetAncientLevelProgress()
    {
        System.String[] val_12 = CryptoPlayerPrefsX.GetStringArray(key:  this.GetLevelProgressPrefKey());
        if(val_2.Length == 0)
        {
                return (System.String[])val_12;
        }
        
        if((val_12[0].Replace(oldValue:  "*", newValue:  "").Equals(value:  this.gameLevel.answers.Replace(oldValue:  "*", newValue:  ""))) != false)
        {
                TSource[] val_7 = System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Skip<System.String>(source:  val_12 = CryptoPlayerPrefsX.GetStringArray(key:  this.GetLevelProgressPrefKey()), count:  1));
            val_12 = val_7;
            this.ExtraRequiredList = System.Linq.Enumerable.ToList<System.String>(source:  CryptoPlayerPrefsX.GetStringArray(key:  val_7.GetExtraRequiredWordsProgressPrefKey()));
            return (System.String[])val_12;
        }
        
        val_12 = new string[0];
        return (System.String[])val_12;
    }
    public void ClearAncientLevelProgress()
    {
        CPlayerPrefs.DeleteKey(key:  this.GetLevelProgressPrefKey());
    }
    private bool LevelsMatch(string setA, string setB)
    {
        if(setA != null)
        {
                return setA.Equals(value:  setB);
        }
        
        throw new NullReferenceException();
    }
    public void ClearLevelProgress()
    {
        CPlayerPrefs.DeleteKey(key:  this.GetExtraRequiredWordsProgressPrefKey());
    }
    public void TryShowWordDefinition(Cell selectedCell)
    {
        var val_4;
        var val_5;
        var val_10;
        var val_11;
        var val_12;
        Player val_1 = App.Player;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 < 3)
        {
                return;
        }
        
        MainController val_2 = MainController.instance;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_2.isGameComplete == true)
        {
                return;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_3 = val_2.GetEnumerator();
        val_10 = 1152921515429107504;
        label_14:
        val_12 = public System.Boolean List.Enumerator<LineWord>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_10;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_11 = mem[val_4 + 40];
        val_11 = val_4 + 40;
        if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(((val_11.Contains(item:  selectedCell)) == false) || ((val_4 + 56) == 0))
        {
            goto label_14;
        }
        
        MonoSingletonSelfGenerating<WGDefinitionManager>.Instance.displayDefinition(word:  val_4 + 24, flyout:  false);
        label_10:
        val_5.Dispose();
    }
    protected void SetupHackedWordsLists(System.Collections.Generic.List<string> wordList)
    {
        string val_9;
        var val_10;
        string val_11;
        System.Collections.Generic.List<System.String> val_12;
        string val_13;
        System.Collections.Generic.List<System.String> val_14;
        this.Hack_EssentialWords = CUtils.BuildListFromString<System.String>(values:  this.gameLevel.answers, split:  '|');
        this.Hack_ExtraWords = new System.Collections.Generic.List<System.String>();
        if(this.validWordsIncluded == false)
        {
            goto label_4;
        }
        
        val_9 = this.gameLevel.extraWords;
        List.Enumerator<T> val_4 = CUtils.BuildListFromString<System.String>(values:  val_9, split:  '|').GetEnumerator();
        val_10 = 1152921513250978752;
        label_13:
        val_11 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_9;
        }
        
        val_12 = this.Hack_EssentialWords;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = 0;
        val_11 = val_13;
        if((val_12.Contains(item:  val_11)) == true)
        {
            goto label_13;
        }
        
        val_12 = this.Hack_ExtraWords;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(item:  val_13);
        goto label_13;
        label_9:
        0.Dispose();
        return;
        label_4:
        System.Collections.Generic.List<System.String> val_7 = null;
        val_10 = 1152921515438511520;
        val_7 = new System.Collections.Generic.List<System.String>(collection:  wordList);
        this.Hack_EssentialWords = val_7;
        System.Collections.Generic.List<System.String> val_8 = null;
        val_14 = val_8;
        val_8 = new System.Collections.Generic.List<System.String>(collection:  this.validWords);
        this.Hack_ExtraWords = val_14;
    }
    protected bool IsSpellableWord(string letters, string word)
    {
        var val_11;
        var val_12;
        val_11 = letters;
        System.Collections.Generic.List<T> val_2 = CUtils.BuildListFromString<System.String>(values:  val_11.Trim(), split:  '|');
        if(1152921515450531344 <= 1)
        {
                val_2.Clear();
            string val_3 = val_11.Trim();
            if(val_3.m_stringLength >= 1)
        {
                var val_11 = 0;
            do
        {
            val_2.Add(item:  val_11.Chars[0].ToString());
            val_11 = val_11 + 1;
        }
        while(val_3.m_stringLength != val_11);
        
        }
        
        }
        
        string val_6 = word.Trim();
        if(val_6.m_stringLength < 1)
        {
            goto label_11;
        }
        
        val_11 = 0;
        label_13:
        string val_8 = word.Chars[0].ToString();
        if((val_2.Contains(item:  val_8)) == false)
        {
            goto label_12;
        }
        
        bool val_10 = val_2.Remove(item:  val_8);
        val_11 = val_11 + 1;
        if(val_11 < val_6.m_stringLength)
        {
            goto label_13;
        }
        
        label_11:
        val_12 = 1;
        return (bool)val_12;
        label_12:
        val_12 = 0;
        return (bool)val_12;
    }
    public virtual bool IsCellFoundInWord(string targetWord, int wordIndexOfCell, int cellIndex)
    {
        UnityEngine.Object val_2;
        if(((wordIndexOfCell & 2147483648) == 0) && (mem[41967640] > wordIndexOfCell))
        {
                if(mem[41967640] <= wordIndexOfCell)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_2 = mem[41967632];
            val_2 = val_2 + (wordIndexOfCell << 3);
            val_2 = mem[(mem[41967632] + (wordIndexOfCell) << 3) + 32];
            val_2 = (mem[41967632] + (wordIndexOfCell) << 3) + 32;
        }
        else
        {
                val_2 = 0;
        }
        
        if((((cellIndex & 2147483648) == 0) && (val_2 != 0)) && ((static System.Void DG.Tweening.Plugins.Core.PathCore.Path::RefreshNonLinearDrawWps(DG.Tweening.Plugins.Core.PathCore.Path p)) > cellIndex))
        {
                if((static System.Void DG.Tweening.Plugins.Core.PathCore.Path::RefreshNonLinearDrawWps(DG.Tweening.Plugins.Core.PathCore.Path p)) <= cellIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_3 = static UnityEngine.Vector3[] DG.Tweening.Plugins.Core.PathCore.Path::GetDrawPoints(DG.Tweening.Plugins.Core.PathCore.Path p, int drawSubdivisionsXSegment);
            val_3 = val_3 + (cellIndex << 3);
        }
    
    }
    public virtual bool IsCellFoundInWord(string targetWord, Cell targetCell)
    {
        .targetWord = targetWord;
        if(targetCell == 0)
        {
                return false;
        }
        
        if((targetWord.Find(match:  new System.Predicate<LineWord>(object:  new WordRegion.<>c__DisplayClass109_0(), method:  System.Boolean WordRegion.<>c__DisplayClass109_0::<IsCellFoundInWord>b__0(LineWord x)))) == 0)
        {
                return false;
        }
        
        return val_3.cells.Contains(item:  targetCell);
    }
    public virtual void Hack_GrantWord()
    {
        var val_9;
        System.Collections.Generic.List<System.String> val_11;
        val_9 = this;
        if(W9 >= 1)
        {
                string val_1 = 38358.ToUpper();
            val_11 = this.Hack_ExtraWords;
        }
        else
        {
                if(W9 < 1)
        {
                return;
        }
        
            val_11 = this.Hack_EssentialWords;
        }
        
        this.Hack_hackedWord = 38358.ToUpper().Replace(oldValue:  "*", newValue:  "");
        val_11.RemoveAt(index:  0);
        UnityEngine.Debug.LogWarning(message:  "Hack_GrantExtraWord():: "("Hack_GrantExtraWord():: ") + mem[this.Hack_hackedWord] + " is being checked...");
        val_9 = ???;
        goto typeof(WordRegion).__il2cppRuntimeField_1D0;
    }
    public virtual void Hack_CompleteLevel()
    {
        goto typeof(WordRegion).__il2cppRuntimeField_280;
    }
    public virtual void Hack_CompleteLevel(bool notifyLevelCompleteImmediately)
    {
        var val_2;
        var val_3;
        var val_10;
        var val_11;
        List.Enumerator<T> val_1 = this.Hack_EssentialWords.GetEnumerator();
        label_5:
        val_10 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_11 = val_2;
        if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = 0;
        string val_5 = val_11.ToUpper();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        this.NotifyWordSubmitted(word:  val_5.Replace(oldValue:  "*", newValue:  ""), valid:  true, isExtra:  false);
        goto label_5;
        label_2:
        val_3.Dispose();
        if(notifyLevelCompleteImmediately != false)
        {
                MainController val_7 = MainController.instance;
            this.NotifyBeforeLevelComplete(level:  this.gameLevel);
            this.NotifyLevelComplete(level:  this.gameLevel);
            return;
        }
        
        if(this.levelCompleteCoroutine != null)
        {
                return;
        }
        
        this.levelCompleteCoroutine = this.StartCoroutine(routine:  this.DoLevelCompleteActions());
    }
    public WordRegion()
    {
        var val_6;
        this.validWords = new System.Collections.Generic.List<System.String>();
        this.canHint = true;
        val_6 = null;
        val_6 = null;
        this.ooc_coins = System.Decimal.MinusOne;
        this.onWordFound = new UnityEngine.Events.UnityEvent();
        this.onExtraWordFound = new UnityEngine.Events.UnityEvent();
        this.baseScale = 1f;
        this.levelCompleteBlockers = new System.Collections.Generic.HashSet<LevelCompleteBlockerType>();
        this.onBeforeLevelComplete = new UnityEngine.Events.UnityEvent();
    }
    private static WordRegion()
    {
    
    }
    private int <LoadCoroutine>b__70_1(string x)
    {
        string val_1 = this.ScrubStar(word:  x);
        return (int)val_1.m_stringLength;
    }
    private string <LoadCoroutine>b__70_2(string x)
    {
        return this.ScrubStar(word:  x);
    }
    private bool <DoLevelCompleteActions>b__86_0()
    {
        bool val_1 = this.levelCompleteBlocked;
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }

}
