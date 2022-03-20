using UnityEngine;
public class WordHuntEvent : WGEventHandler
{
    // Fields
    public static WordHuntEvent Instance;
    public const string WORD_HUNT_EVENT_ID = "WordHunt";
    public const string EVENT_TRACKING_ID = "Word Hunt";
    public const string SHOW_WORD_FOUND_TOOLTIP = "ShowWordHuntTooltip";
    private GameLevel generatedLevel;
    protected System.Collections.Generic.List<string> eventRequiredWords;
    private System.Collections.Generic.List<object> <collectedWords>k__BackingField;
    private GameEventRewardType <myReward>k__BackingField;
    private int _rewardCoins;
    private System.Collections.Generic.Dictionary<string, object> eventProgressData;
    private System.Collections.Generic.Dictionary<string, object> eventEconData;
    public System.Collections.Generic.Dictionary<string, UnityEngine.Color32> tileColorLookup;
    private bool wordCollectedInDC;
    protected int cacheCurrLevelWordFound;
    protected System.Collections.Generic.List<string> currLevelEventWordsTotal;
    protected int cacheOverallWordFound;
    protected int cacheOverallWordTotal;
    private const string CACHE_COLLECTED_WORDS_KEY = "cache_col_words";
    private System.Collections.Generic.List<string> tempCacheCollecteWords;
    private System.Collections.Generic.List<Cell> eventCellsInCurLevel;
    private bool <ShownExpiredUI>k__BackingField;
    
    // Properties
    public System.Collections.Generic.List<string> getCurrentWordList { get; }
    public System.Collections.Generic.List<object> collectedWords { get; set; }
    public GameEventRewardType myReward { get; set; }
    public int rewardCoins { get; }
    public bool eventComplete { get; }
    public GameEventV2 getEvent { get; }
    private static int LastProgressTimestampPref { get; set; }
    public int levelsBeforeGenerate { get; }
    public string eventTheme { get; }
    public string currentColor { get; }
    public bool EvtBtnFtuxShown { get; set; }
    public int LastLevelCollectedWordAt { get; set; }
    public string[] CacheCollectedWords { get; set; }
    public override int PointsCollected { get; }
    public override int PointsRequired { get; }
    public bool ShownExpiredUI { get; set; }
    public override bool IsEventValid { get; }
    
    // Methods
    public System.Collections.Generic.List<string> get_getCurrentWordList()
    {
        return (System.Collections.Generic.List<System.String>)this.eventRequiredWords;
    }
    public System.Collections.Generic.List<object> get_collectedWords()
    {
        return (System.Collections.Generic.List<System.Object>)this.<collectedWords>k__BackingField;
    }
    private void set_collectedWords(System.Collections.Generic.List<object> value)
    {
        this.<collectedWords>k__BackingField = value;
    }
    public GameEventRewardType get_myReward()
    {
        return (GameEventRewardType)this.<myReward>k__BackingField;
    }
    private void set_myReward(GameEventRewardType value)
    {
        this.<myReward>k__BackingField = value;
    }
    public int get_rewardCoins()
    {
        return (int)this._rewardCoins;
    }
    public bool get_eventComplete()
    {
        return (bool)((this.<collectedWords>k__BackingField) == this.eventRequiredWords) ? 1 : 0;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "wild_lst_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wild_lst_prog_ts", value:  value);
    }
    public int get_levelsBeforeGenerate()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.eventEconData, key:  "ml_no_col", defaultValue:  5);
        return (int)null;
    }
    public string get_eventTheme()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.eventEconData, key:  "theme", defaultValue:  "null");
        goto typeof(System.Object).__il2cppRuntimeField_160;
    }
    public string get_currentColor()
    {
        return EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.eventEconData, key:  "color", defaultValue:  "RED").ToUpper();
    }
    public bool get_EvtBtnFtuxShown()
    {
        var val_4;
        if((this.eventProgressData.ContainsKey(key:  "EvtBtnFtuxShown")) != false)
        {
                object val_2 = this.eventProgressData.Item["EvtBtnFtuxShown"];
            var val_3 = (null != 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public void set_EvtBtnFtuxShown(bool value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.eventProgressData, key:  "EvtBtnFtuxShown", newValue:  value);
    }
    public int get_LastLevelCollectedWordAt()
    {
        object val_3 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.eventProgressData, key:  "lastColAt", defaultValue:  App.Player - 1);
        return (int)null;
    }
    public void set_LastLevelCollectedWordAt(int value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.eventProgressData, key:  "lastColAt", newValue:  value);
    }
    public string[] get_CacheCollectedWords()
    {
        return PlayerPrefsX.GetStringArray(key:  "cache_col_words");
    }
    public void set_CacheCollectedWords(string[] value)
    {
        bool val_1 = PlayerPrefsX.SetStringArray(key:  "cache_col_words", stringArray:  value);
    }
    public override int get_PointsCollected()
    {
        return 38024;
    }
    public override int get_PointsRequired()
    {
        return 38025;
    }
    public bool get_ShownExpiredUI()
    {
        return (bool)this.<ShownExpiredUI>k__BackingField;
    }
    public void set_ShownExpiredUI(bool value)
    {
        this.<ShownExpiredUI>k__BackingField = value;
    }
    public override bool get_IsEventValid()
    {
        GameBehavior val_1 = App.getBehavior;
        return System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public override void Init(GameEventV2 eventV2)
    {
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY = this;
        mem[1152921516817052032] = eventV2;
        if(eventV2.eventData != null)
        {
                this.ParseEventData(eventData:  eventV2.eventData);
        }
        
        if(this.CheckNeedsNewData() != false)
        {
                this.GenerateNewData();
        }
        else
        {
                this.LoadPersistantData();
        }
        
        GameEcon val_3 = App.getGameEcon;
        if(App.Player == val_3.events_unlockLevel)
        {
                GameBehavior val_4 = App.getBehavior;
            if((val_4.<metaGameBehavior>k__BackingField) == 2)
        {
                this.CheckFtux();
        }
        
        }
        
        this.cacheOverallWordFound = typeof(MetaGameBehavior).__il2cppRuntimeField_2B0;
        this.cacheOverallWordTotal = this.eventRequiredWords;
    }
    public override GameLevel getGameLevel(GameLevel refLevel)
    {
        string val_38;
        var val_39;
        System.Func<System.String, System.Int32> val_41;
        GameLevel val_42;
        if(this.eventComplete == true)
        {
                return 0;
        }
        
        if((App.Player - this.LastLevelCollectedWordAt) <= this.levelsBeforeGenerate)
        {
                return 0;
        }
        
        if(this.IsEventExpired() != false)
        {
                return 0;
        }
        
        if(this.generatedLevel != null)
        {
                return 0;
        }
        
        if((public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.String>(System.Collections.Generic.IEnumerable<TSource> source)) == 0)
        {
                return 0;
        }
        
        if(App.Player <= 99)
        {
            goto label_13;
        }
        
        int val_11 = UnityEngine.Random.Range(min:  0, max:  typeof(Player).__il2cppRuntimeField_178>>0&0xFFFFFFFF);
        if(null <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        Player val_12 = 1152921504885919744 + (val_11 << 3);
        val_38 = mem[(1152921504885919744 + (val_11) << 3) + 32];
        if(refLevel != null)
        {
            goto label_15;
        }
        
        label_13:
        val_39 = null;
        val_39 = null;
        val_41 = WordHuntEvent.<>c.<>9__63_1;
        if(val_41 == null)
        {
                System.Func<System.String, System.Int32> val_13 = null;
            val_41 = val_13;
            val_13 = new System.Func<System.String, System.Int32>(object:  WordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordHuntEvent.<>c::<getGameLevel>b__63_1(string x));
            WordHuntEvent.<>c.<>9__63_1 = val_41;
        }
        
        val_38 = MoreLinq.MinBy<System.String, System.Int32>(source:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Where<System.String>(source:  this.eventRequiredWords, predicate:  new System.Func<System.String, System.Boolean>(object:  this, method:  System.Boolean WordHuntEvent::<getGameLevel>b__63_0(string x)))), selector:  val_13);
        label_15:
        string val_15 = refLevel.word.Replace(oldValue:  "|", newValue:  "");
        System.Collections.Generic.List<T> val_16 = CUtils.BuildListFromString<System.String>(values:  refLevel.answers, split:  '|');
        if(val_15.m_stringLength <= val_14.m_stringLength)
        {
            goto label_29;
        }
        
        int val_18 = System.Math.Max(val1:  1, val2:  val_15.m_stringLength + (~val_14.m_stringLength));
        int val_19 = System.Math.Min(val1:  refLevel.answers, val2:  18);
        GameBehavior val_20 = App.getBehavior;
        if(((val_20.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_36;
        }
        
        GameLevel val_22 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.BuildLevelContainingWordOfLength(word:  val_38, desiredLength:  val_15.m_stringLength, desiredAnswers:  val_19, lengthFlexibility:  val_18);
        goto label_40;
        label_29:
        val_42 = this.generatedLevel;
        if(val_42 != null)
        {
            goto label_46;
        }
        
        goto label_42;
        label_36:
        GameLevel val_26 = MonoSingletonSelfGenerating<WADataParser>.Instance.BuildLevelContainingWordOfLength(word:  val_38, desiredLength:  val_15.m_stringLength, desiredAnswers:  val_19, runWordRemoval:  (WADChapterManager.GetCurrentChapter() > 10) ? 1 : 0, lengthFlexibility:  val_18);
        label_40:
        this.generatedLevel = val_26;
        if(val_26 != null)
        {
            goto label_46;
        }
        
        label_42:
        .levelWord = val_38;
        mem[1152921516817449168] = refLevel.answers;
        mem[1152921516817449188] = 1;
        if((MonoSingleton<DifficultySettingManager>.Instance) != 0)
        {
                if((MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels) != false)
        {
                .includeUncommonAsRequiredWords = true;
            mem[1152921516817449189] = true;
        }
        
        }
        
        GameBehavior val_32 = App.getBehavior;
        if(((val_32.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                GameLevel val_34 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.BuildLevelBasedOnWord(daWord:  val_38, maxWordCount:  refLevel.answers, keepWord:  0);
        }
        else
        {
                GameLevel val_36 = MonoSingletonSelfGenerating<WADataParser>.Instance.BuildLevelBasedOnWord(param:  new BuildLevelBasedOnWordParams());
        }
        
        this.generatedLevel = val_36;
        if(val_36 == null)
        {
                return 0;
        }
        
        label_46:
        if((val_36.answers.Contains(value:  val_38)) != false)
        {
                return 0;
        }
        
        UnityEngine.Debug.LogWarning(message:  "Word Hunt failing to generate a level that contains its level word");
        return 0;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41967616 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<WordHuntPopup>(showNext:  false);
        }
    
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.SaveData();
        if(this.generatedLevel == null)
        {
                return;
        }
        
        this.generatedLevel = 0;
    }
    public override void OnDailyChallengeInit()
    {
        this.wordCollectedInDC = false;
    }
    public override void OnGameSceneInit()
    {
        var val_21;
        var val_22;
        var val_31;
        System.Action<System.String> val_32;
        var val_33;
        string val_35;
        this.SaveData();
        this.OnGameSceneInit();
        val_31 = 1152921504879157248;
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WordHuntEvent::OnValidWordSubmission(string word)));
        WordRegion val_3 = WordRegion.instance;
        System.Action<System.String> val_4 = null;
        val_32 = val_4;
        val_4 = new System.Action<System.String>(object:  this, method:  System.Void WordHuntEvent::OnValidExtraWordSubmission(string word));
        val_3.addOnExtraWordFoundAction(callback:  val_4);
        this.wordCollectedInDC = false;
        this.currLevelEventWordsTotal = this.GetEventWordsAvailableInLevel(dontIncludeDiscoveredWords:  ((System.Linq.Enumerable.Count<System.String>(source:  val_3.CacheCollectedWords)) == 0) ? 1 : 0);
        System.Collections.Generic.List<System.String> val_9 = this.GetEventWordsSolvedInLevel();
        this.cacheCurrLevelWordFound = 1152921516817954816;
        if((this.IsEventExpired() != false) && ((this.<ShownExpiredUI>k__BackingField) != true))
        {
                val_32 = 1152921504893161472;
            WGWindowManager val_11 = MonoSingleton<WGWindowManager>.Instance;
            if(val_3 != 0)
        {
                GameBehavior val_13 = App.getBehavior;
        }
        
        }
        
        if((System.Linq.Enumerable.Count<System.String>(source:  MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordHuntPopup>(showNext:  false).CacheCollectedWords)) < 1)
        {
                return;
        }
        
        List.Enumerator<T> val_20 = WordRegion.instance.GetEnumerator();
        val_31 = 1152921515429107504;
        label_36:
        bool val_23 = val_22.MoveNext();
        if(val_23 == false)
        {
            goto label_27;
        }
        
        val_33 = 0;
        goto label_28;
        label_33:
        val_33 = 1;
        label_28:
        int val_25 = System.Linq.Enumerable.Count<System.String>(source:  val_23.CacheCollectedWords);
        if(val_33 >= (val_25 << ))
        {
            goto label_36;
        }
        
        if(val_21 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.String[] val_26 = val_25.CacheCollectedWords;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_33 >= val_26.Length)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_35 = val_26[val_33];
        bool val_27 = System.String.op_Equality(a:  val_21 + 24, b:  val_35);
        if(val_27 == false)
        {
            goto label_33;
        }
        
        System.String[] val_28 = val_27.CacheCollectedWords;
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        string val_29 = this.EventWordContainedInWord(wordFound:  val_28[val_33]);
        goto label_36;
        label_27:
        val_22.Dispose();
    }
    public override void OnGameSceneBegan()
    {
        this.CheckFtux();
    }
    public override void OnMenuLoaded()
    {
        this.SaveData();
        this.OnMenuLoaded();
    }
    public override string GetEventDisplayName()
    {
        return "WORD HUNT";
    }
    public override string GetGameButtonText()
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.<collectedWords>k__BackingField, arg1:  this.eventRequiredWords);
    }
    public override string GetMainMenuButtonText()
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.<collectedWords>k__BackingField, arg1:  this.eventRequiredWords);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41967616 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<WordHuntPopup>(showNext:  false);
        }
    
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(WordHuntEvent).__il2cppRuntimeField_4F0;
    }
    public override bool IsRewardReadyToCollect()
    {
        return this.eventComplete;
    }
    public override bool EventCompleted()
    {
        return this.eventProgressData.ContainsKey(key:  "rewCollected");
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_3 = (float)S8;
        val_3 = val_3 / (float)S9;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentWordHunt>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  this.<collectedWords>k__BackingField, arg1:  this.eventRequiredWords), sliderValue:  val_3);
    }
    public override void OnSubmitWordWithHints(string word)
    {
        goto typeof(WordHuntEvent).__il2cppRuntimeField_7E0;
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        var val_10;
        List.Enumerator<T> val_2 = this.GetEventWordsAvailableInLevel(dontIncludeDiscoveredWords:  true).GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(hintedCell == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = 0;
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_10.Contains(value:  hintedCell.letter)) == false)
        {
            goto label_5;
        }
        
        0.Dispose();
        if((this.eventCellsInCurLevel.Contains(item:  hintedCell)) == false)
        {
                return;
        }
        
        UnityEngine.Color32 val_8 = this.tileColorLookup.Item[this.currentColor.ToUpper()];
        hintedCell.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_8.r & 4294967295, g = val_8.r & 4294967295, b = val_8.r & 4294967295, a = val_8.r & 4294967295}, bgAlpha:  1f);
        return;
        label_2:
        0.Dispose();
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventProgressUI = eventProgressUI;
        .eventButton = eventButton;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordHuntEvent.<DoLevelCompleteEventProgressAnimation>d__80();
    }
    public override int LastProgressTimestamp()
    {
        return WordHuntEvent.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        WordHuntEvent.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return true;
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        if(layoutType != 1)
        {
            goto label_2;
        }
        
        if(context == 5)
        {
            goto label_1;
        }
        
        if(context != 3)
        {
            goto label_2;
        }
        
        return this.IsLevelContainEventWord();
        label_1:
        if(this.cacheCurrLevelWordFound < 1)
        {
                return true;
        }
        
        label_2:
        return true;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  currentData, key:  "WH Word Collected", newValue:  (this.LastLevelCollectedWordAt == App.Player) ? 1 : 0);
    }
    public override void AppendDailyChallengeCompleteData(ref System.Collections.Generic.Dictionary<string, object> data)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  data, key:  "WH Word Collected", newValue:  this.wordCollectedInDC);
        this.wordCollectedInDC = false;
    }
    public override void ResetDCProgress()
    {
        this.wordCollectedInDC = false;
    }
    public override UnityEngine.Sprite GetEventIcon()
    {
        EventPrefabsConfig val_2 = MonoSingleton<WordGameEventsController>.Instance.EventPrefabsConfig;
        return (UnityEngine.Sprite)val_2.evtIconWordHunt;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        string val_14;
        var val_15;
        object val_20;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_21;
        var val_22;
        var val_23;
        string val_24;
        string val_25;
        val_20 = this;
        if(eventData == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = "economy";
        val_23 = 1152921510222861648;
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_24 = "economy";
        val_22 = 1152921510214912464;
        object val_2 = eventData.Item[val_24];
        if(val_2 == null)
        {
            goto label_5;
        }
        
        this.eventEconData = val_2;
        val_24 = "reward";
        if((val_2.ContainsKey(key:  val_24)) == false)
        {
            goto label_16;
        }
        
        val_21 = this.eventEconData;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = "reward";
        object val_4 = val_21.Item[val_24];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_7 = 0;
        val_24 = "coins";
        if((val_4.ContainsKey(key:  val_24)) == false)
        {
            goto label_14;
        }
        
        val_24 = "coins";
        object val_6 = val_4.Item[val_24];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7 < 1) || ((System.Int32.TryParse(s:  val_6, result: out  val_7)) == false))
        {
            goto label_14;
        }
        
        val_24 = "coins";
        object val_9 = val_4.Item[val_24];
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = this._rewardCoins;
        bool val_10 = System.Int32.TryParse(s:  val_9, result: out  val_24);
        this.<myReward>k__BackingField = 1;
        goto label_16;
        label_14:
        this.<myReward>k__BackingField = 5.30498947741812E-312;
        label_16:
        val_21 = this.eventEconData;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = "word_list";
        if((val_21.ContainsKey(key:  val_24)) == false)
        {
                return;
        }
        
        val_21 = this.eventEconData;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = "word_list";
        object val_12 = val_21.Item[val_24];
        if(this.eventRequiredWords == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = this.eventRequiredWords;
        val_24 = public System.Void System.Collections.Generic.List<System.String>::Clear();
        val_21.Clear();
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_13 = val_12.GetEnumerator();
        val_25 = val_14;
        val_23 = 1152921504622235648;
        label_28:
        if(val_15.MoveNext() == false)
        {
            goto label_24;
        }
        
        if(val_25 == 0)
        {
            goto label_25;
        }
        
        val_25 = null;
        if(val_25 != val_25)
        {
            goto label_26;
        }
        
        label_25:
        if(this.eventRequiredWords == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventRequiredWords.Add(item:  val_25);
        goto label_28;
        label_24:
        val_24 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_15.Dispose();
        if(this.eventRequiredWords != null)
        {
                return;
        }
        
        val_21 = this.eventEconData;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = val_21.Item["word_list"];
        UnityEngine.Debug.LogError(message:  val_20);
        return;
        label_26:
        val_21 = val_25;
        val_24 = val_25;
        throw new NullReferenceException();
        label_5:
        this.eventEconData = 0;
        throw new NullReferenceException();
    }
    private void LoadPersistantData()
    {
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "wordHuntData"));
        if(val_2 != null)
        {
                this.eventProgressData = val_2;
            object val_3 = val_2.Item["collected"];
            this.<collectedWords>k__BackingField = 0;
            mem[1152921516821557536] = new System.Collections.Generic.List<System.Object>();
            return;
        }
        
        this.eventProgressData = 0;
        throw new NullReferenceException();
    }
    private void GenerateNewData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "id", value:  System.Void System.Runtime.Serialization.Formatters.Binary.SizedArray::IncreaseCapacity(int index));
        val_1.Add(key:  "collected", value:  new System.Collections.Generic.List<System.Object>());
        val_1.Add(key:  "lastColAt", value:  App.Player - 1);
        CPlayerPrefs.SetString(key:  "wordHuntData", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
        this.<ShownExpiredUI>k__BackingField = false;
    }
    private bool CheckNeedsNewData()
    {
        if((CPlayerPrefs.HasKey(key:  "wordHuntData")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "wordHuntData"));
        if(val_3 == null)
        {
                return true;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        return true;
    }
    public void CollectReward()
    {
        if((this.<myReward>k__BackingField) == 1)
        {
                decimal val_2 = System.Decimal.op_Implicit(value:  this._rewardCoins);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Word Hunt Complete", subSource:  0, externalParams:  0, doTrack:  true);
        }
        else
        {
                UnityEngine.Debug.LogError(message:  "not sure how to process reward of " + this.<myReward>k__BackingField(this.<myReward>k__BackingField));
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.eventProgressData, key:  "rewCollected", newValue:  true);
        this.SaveData();
    }
    private void SaveData()
    {
        CPlayerPrefs.SetString(key:  "wordHuntData", val:  MiniJSON.Json.Serialize(obj:  this.eventProgressData));
    }
    private void OnValidExtraWordSubmission(string word)
    {
        goto typeof(WordHuntEvent).__il2cppRuntimeField_7E0;
    }
    private void OnValidWordSubmission(string word)
    {
        goto typeof(WordHuntEvent).__il2cppRuntimeField_7E0;
    }
    protected virtual void OnValidWordSubmission(string word, bool isExtraWord)
    {
        var val_7;
        var val_8;
        var val_30;
        var val_31;
        string val_32;
        var val_37;
        val_30 = isExtraWord;
        string val_1 = this.EventWordContainedInWord(wordFound:  word);
        if((this.<collectedWords>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<collectedWords>k__BackingField.Contains(item:  val_1)) == true)
        {
                return;
        }
        
        if(this.eventRequiredWords == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.eventRequiredWords.Contains(item:  word)) == false)
        {
            goto label_4;
        }
        
        if(this.tempCacheCollecteWords == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = 1152921509851232320;
        val_32 = word;
        goto label_6;
        label_4:
        if((System.String.IsNullOrEmpty(value:  val_1)) == false)
        {
            goto label_7;
        }
        
        WordRegion val_5 = WordRegion.instance;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_6 = val_5.GetEnumerator();
        val_30 = 1152921504687304704;
        label_43:
        label_15:
        if(val_8.MoveNext() == false)
        {
            goto label_12;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  val_7 + 24, b:  word)) == false)
        {
            goto label_15;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_11 = System.Linq.Enumerable.Intersect<Cell>(first:  val_7 + 40, second:  this.eventCellsInCurLevel);
        if((System.Linq.Enumerable.Count<Cell>(source:  val_11)) < 1)
        {
            goto label_15;
        }
        
        var val_34 = 0;
        val_34 = val_34 + 1;
        System.Collections.Generic.IEnumerator<T> val_14 = val_11.GetEnumerator();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        label_34:
        var val_35 = 0;
        val_35 = val_35 + 1;
        if(val_14.MoveNext() == false)
        {
            goto label_26;
        }
        
        var val_36 = 0;
        val_36 = val_36 + 1;
        T val_18 = val_14.Current;
        string val_19 = this.currentColor;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.tileColorLookup == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_21 = this.tileColorLookup.Item[val_19.ToUpper()];
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_18.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_21.r & 4294967295, g = val_21.r & 4294967295, b = val_21.r & 4294967295, a = val_21.r & 4294967295}, bgAlpha:  1f);
        goto label_34;
        label_26:
        val_30 = 0;
        var val_23 = 0 + 1;
        mem2[0] = 218;
        if(val_14 != null)
        {
                var val_37 = 0;
            val_37 = val_37 + 1;
            val_14.Dispose();
        }
        
        if(val_30 != 0)
        {
            goto label_40;
        }
        
        if((val_23 == 1) || ((1152921516822616336 + ((0 + 1)) << 2) != 218))
        {
            goto label_43;
        }
        
        var val_25 = 0 ^ (val_23 >> 31);
        val_25 = val_23 + val_25;
        goto label_43;
        label_7:
        if(this.tempCacheCollecteWords == null)
        {
                throw new NullReferenceException();
        }
        
        val_31 = 1152921509851232320;
        val_32 = val_1;
        label_6:
        this.tempCacheCollecteWords.Add(item:  val_32);
        if(this.tempCacheCollecteWords == null)
        {
                throw new NullReferenceException();
        }
        
        T[] val_26 = this.tempCacheCollecteWords.ToArray();
        val_26.CacheCollectedWords = val_26;
        WGDailyChallengeManager val_27 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_27.PlayingChallenge != false)
        {
                this.wordCollectedInDC = true;
            if(val_30 == true)
        {
                return;
        }
        
        }
        else
        {
                Player val_29 = App.Player;
            if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
            this.LastLevelCollectedWordAt = val_29;
            if(val_30 != false)
        {
                return;
        }
        
        }
        
        WordRegion val_30 = WordRegion.instance;
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_31 = val_30.GetEnumerator();
        label_78:
        if(val_8.MoveNext() == false)
        {
            goto label_76;
        }
        
        val_30 = val_7;
        if(val_30 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  val_7 + 24, b:  word)) == false)
        {
            goto label_78;
        }
        
        label_76:
        val_8.Dispose();
        return;
        label_12:
        val_8.Dispose();
        return;
        label_40:
        val_37 = val_30;
        throw val_37;
    }
    protected virtual void HighlightEventExtraWordFound(string word)
    {
    
    }
    protected virtual void PostValidWordSubmission()
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ShowWordHuntTooltip");
    }
    protected string EventWordContainedInWord(string wordFound)
    {
        .wordFound = wordFound;
        return System.Linq.Enumerable.FirstOrDefault<System.String>(source:  this.eventRequiredWords, predicate:  new System.Func<System.String, System.Boolean>(object:  new WordHuntEvent.<>c__DisplayClass100_0(), method:  System.Boolean WordHuntEvent.<>c__DisplayClass100_0::<EventWordContainedInWord>b__0(string x)));
    }
    protected virtual void ColorAllVisibleTiles(LineWord wordLine, string eventWord, bool doGameplayAnimation = True)
    {
        var val_2;
        var val_3;
        string val_10;
        List.Enumerator<T> val_1 = wordLine.cells.GetEnumerator();
        label_10:
        val_10 = public System.Boolean List.Enumerator<Cell>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_2 + 72) == 0)
        {
            goto label_10;
        }
        
        if(eventWord == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = mem[val_2 + 64];
        val_10 = val_2 + 64;
        if((eventWord.Contains(value:  val_10)) == false)
        {
            goto label_10;
        }
        
        string val_6 = this.currentColor;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = val_6.ToUpper();
        if(this.tileColorLookup == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_8 = this.tileColorLookup.Item[val_10];
        val_2.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_8.r & 4294967295, g = val_8.r & 4294967295, b = val_8.r & 4294967295, a = val_8.r & 4294967295}, bgAlpha:  1f);
        goto label_10;
        label_3:
        val_3.Dispose();
    }
    protected virtual void DecorateSelectedTiles(LineWord wordLine, string eventWord)
    {
        List.Enumerator<T> val_1 = wordLine.cells.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(eventWord == null)
        {
                throw new NullReferenceException();
        }
        
        if((eventWord.Contains(value:  1)) == false)
        {
            goto label_7;
        }
        
        0.ShowDynamicImage(sprite:  this);
        goto label_7;
        label_3:
        0.Dispose();
    }
    private void CheckFtux()
    {
        if((this.eventProgressData.ContainsKey(key:  "ftuxShown")) == true)
        {
                return;
        }
        
        this = this.eventProgressData;
        this.Add(key:  "ftuxShown", value:  true);
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordHuntPopup>(showNext:  false);
    }
    public System.Collections.Generic.List<string> GetEventWordsSolvedInLevel()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_2 = this.currLevelEventWordsTotal.GetEnumerator();
        label_5:
        bool val_3 = 0.MoveNext();
        if(val_3 == false)
        {
            goto label_2;
        }
        
        if((System.Linq.Enumerable.Contains<System.String>(source:  val_3.CacheCollectedWords, value:  0)) == false)
        {
            goto label_5;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  0);
        goto label_5;
        label_2:
        0.Dispose();
        return val_1;
    }
    public System.Collections.Generic.List<string> GetEventWordsAvailableInLevel(bool dontIncludeDiscoveredWords = False)
    {
        LineWord val_5;
        var val_6;
        System.Collections.Generic.IEnumerable<TSource> val_30;
        System.Collections.Generic.List<T> val_31;
        System.Collections.Generic.List<Cell> val_33;
        System.Collections.Generic.List<T> val_34;
        string val_35;
        WordHuntEvent val_36;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_30 = mem[1152921516823963928];
        System.Collections.Generic.List<Cell> val_2 = null;
        val_31 = val_2;
        val_2 = new System.Collections.Generic.List<Cell>();
        mem[1152921516823964008] = val_31;
        if(dontIncludeDiscoveredWords == false)
        {
            goto label_1;
        }
        
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>(capacity:  mem[1152921516823963936] + 24);
        List.Enumerator<T> val_4 = mem[1152921516823963936].GetEnumerator();
        val_31 = 1152921509851232320;
        label_8:
        val_33 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_5 != 0)
        {
                var val_8 = (val_5 == null) ? (val_5) : 0;
        }
        else
        {
                val_35 = 0;
        }
        
        val_3.Add(item:  val_35);
        goto label_8;
        label_1:
        val_36 = this;
        goto label_9;
        label_4:
        val_6.Dispose();
        val_36 = this;
        val_30 = System.Linq.Enumerable.Except<System.String>(first:  mem[1152921516823963928], second:  val_3);
        label_9:
        List.Enumerator<T> val_11 = WordRegion.instance.GetEnumerator();
        label_23:
        if(val_6.MoveNext() == false)
        {
            goto label_14;
        }
        
        WordHuntEvent.<>c__DisplayClass105_0 val_13 = null;
        val_33 = 0;
        val_13 = new WordHuntEvent.<>c__DisplayClass105_0();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        .wordLine = val_5;
        if(dontIncludeDiscoveredWords == false)
        {
            goto label_16;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_5 + 56) != 0)
        {
            goto label_23;
        }
        
        label_16:
        string val_16 = System.Linq.Enumerable.FirstOrDefault<System.String>(source:  System.Linq.Enumerable.Except<System.String>(first:  val_30, second:  val_1), predicate:  new System.Func<System.String, System.Boolean>(object:  val_13, method:  System.Boolean WordHuntEvent.<>c__DisplayClass105_0::<GetEventWordsAvailableInLevel>b__0(string x)));
        val_33 = 0;
        if((System.String.IsNullOrEmpty(value:  val_16)) == true)
        {
            goto label_23;
        }
        
        if(((WordHuntEvent.<>c__DisplayClass105_0)[1152921516824016368].wordLine) == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = mem[1152921516823964008];
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_33 = (WordHuntEvent.<>c__DisplayClass105_0)[1152921516824016368].wordLine.cells;
        val_2.AddRange(collection:  val_33);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_16);
        goto label_23;
        label_14:
        val_6.Dispose();
        WordRegion val_20 = WordRegion.instance;
        List.Enumerator<T> val_21 = val_20.validWords.GetEnumerator();
        label_35:
        if(val_6.MoveNext() == false)
        {
            goto label_28;
        }
        
        WordHuntEvent.<>c__DisplayClass105_1 val_23 = null;
        val_33 = 0;
        val_23 = new WordHuntEvent.<>c__DisplayClass105_1();
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_33 = val_5;
        .exWord = val_33;
        if(dontIncludeDiscoveredWords == false)
        {
            goto label_30;
        }
        
        val_34 = mem[1152921516823963936];
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_34.Contains(item:  val_33)) == true)
        {
            goto label_35;
        }
        
        label_30:
        string val_27 = System.Linq.Enumerable.FirstOrDefault<System.String>(source:  System.Linq.Enumerable.Except<System.String>(first:  val_30, second:  val_1), predicate:  new System.Func<System.String, System.Boolean>(object:  val_23, method:  System.Boolean WordHuntEvent.<>c__DisplayClass105_1::<GetEventWordsAvailableInLevel>b__1(string x)));
        val_33 = 0;
        if((System.String.IsNullOrEmpty(value:  val_27)) == true)
        {
            goto label_35;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_27);
        goto label_35;
        label_28:
        val_6.Dispose();
        return val_1;
    }
    public bool IsLevelContainEventWord()
    {
        System.Collections.Generic.List<System.String> val_3 = this.currLevelEventWordsTotal;
        if(val_3 == null)
        {
                return (bool)val_3 & 1;
        }
        
        if(val_3 >= 1)
        {
                val_3 = this.IsEventExpired() ^ 1;
            return (bool)val_3 & 1;
        }
        
        val_3 = 0;
        return (bool)val_3 & 1;
    }
    public bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public bool ShouldFoundWordShowInPopup(string word)
    {
        var val_5;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                val_5 = (this.GetEventWordsSolvedInLevel().Contains(item:  word)) ^ 1;
            return (bool)val_5 & 1;
        }
        
        val_5 = 1;
        return (bool)val_5 & 1;
    }
    protected UnityEngine.UI.Image CreateIconObject(UnityEngine.Vector3 worldPos, UnityEngine.Vector2 size, UnityEngine.Transform parentTransform)
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "WordHuntIcon");
        val_1.transform.SetParent(p:  parentTransform);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        val_1.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        val_1.transform.position = new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z};
        val_1.transform.SetAsLastSibling();
        UnityEngine.UI.Image val_7 = val_1.AddComponent<UnityEngine.UI.Image>();
        val_7.sprite = this;
        val_7.preserveAspect = true;
        val_7.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = size.x, y = size.y};
        return val_7;
    }
    public void SetRequiredWordsAsCurrentExtraWords()
    {
        GameLevel val_1 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  true);
        this.eventRequiredWords = CUtils.BuildListFromString<System.String>(values:  val_1.extraWords, split:  '|');
    }
    public void HackCollectSmallestWord()
    {
        var val_17;
        System.Func<System.String, System.Int32> val_19;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        if(this.eventComplete != false)
        {
                return;
        }
        
        System.Func<System.String, System.Boolean> val_4 = 31163516;
        val_4 = new System.Func<System.String, System.Boolean>(object:  this, method:  System.Boolean WordHuntEvent::<HackCollectSmallestWord>b__111_0(string x));
        val_17 = null;
        val_17 = null;
        val_19 = WordHuntEvent.<>c.<>9__111_1;
        if(val_19 == null)
        {
                System.Func<System.String, System.Int32> val_6 = null;
            val_19 = val_6;
            val_6 = new System.Func<System.String, System.Int32>(object:  WordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordHuntEvent.<>c::<HackCollectSmallestWord>b__111_1(string x));
            WordHuntEvent.<>c.<>9__111_1 = val_19;
        }
        
        this.<collectedWords>k__BackingField.Add(item:  MoreLinq.MinBy<System.String, System.Int32>(source:  System.Linq.Enumerable.Where<System.String>(source:  this.eventRequiredWords, predicate:  val_4), selector:  val_6));
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.eventProgressData, key:  "collected", newValue:  this.<collectedWords>k__BackingField);
        this.cacheOverallWordFound = 1152921515739705024;
        this.cacheOverallWordTotal = this.eventRequiredWords;
        this.LastLevelCollectedWordAt = App.Player;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                this.wordCollectedInDC = true;
        }
        
        if((MonoSingleton<WGWindowManager>.Instance.ShowingWindow<WordHuntPopup>()) != false)
        {
                UnityEngine.Object.FindObjectOfType<WordHuntPopup>().BuildUI();
            return;
        }
        
        if(this.eventComplete != false)
        {
                WGWindowManager val_16 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordHuntPopup>(showNext:  false);
        }
    
    }
    public WordHuntEvent()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "RAT");
        val_1.Add(item:  "OXEN");
        val_1.Add(item:  "TIGER");
        val_1.Add(item:  "RABBIT");
        val_1.Add(item:  "DRAGON");
        val_1.Add(item:  "SNAKE");
        val_1.Add(item:  "HORSE");
        val_1.Add(item:  "GOAT");
        val_1.Add(item:  "MONKEY");
        val_1.Add(item:  "ROOSTER");
        val_1.Add(item:  "DOG");
        val_1.Add(item:  "PIG");
        this.eventRequiredWords = val_1;
        this.eventProgressData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.eventEconData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32> val_4 = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Color32>();
        UnityEngine.Color32 val_5 = new UnityEngine.Color32(r:  255, g:  79, b:  67, a:  225);
        val_4.Add(key:  "RED", value:  new UnityEngine.Color32() {r = val_5.r, g = val_5.r, b = val_5.r, a = val_5.r});
        UnityEngine.Color32 val_6 = new UnityEngine.Color32(r:  255, g:  136, b:  192, a:  225);
        val_4.Add(key:  "PINK", value:  new UnityEngine.Color32() {r = val_6.r, g = val_6.r, b = val_6.r, a = val_6.r});
        UnityEngine.Color32 val_7 = new UnityEngine.Color32(r:  107, g:  249, b:  100, a:  225);
        val_4.Add(key:  "GREEN", value:  new UnityEngine.Color32() {r = val_7.r, g = val_7.r, b = val_7.r, a = val_7.r});
        UnityEngine.Color32 val_8 = new UnityEngine.Color32(r:  247, g:  220, b:  42, a:  225);
        val_4.Add(key:  "YELLOW", value:  new UnityEngine.Color32() {r = val_8.r, g = val_8.r, b = val_8.r, a = val_8.r});
        UnityEngine.Color32 val_9 = new UnityEngine.Color32(r:  125, g:  234, b:  8, a:  225);
        val_4.Add(key:  "SPRING GREEN", value:  new UnityEngine.Color32() {r = val_9.r, g = val_9.r, b = val_9.r, a = val_9.r});
        UnityEngine.Color32 val_10 = new UnityEngine.Color32(r:  106, g:  191, b:  255, a:  225);
        val_4.Add(key:  "BLUE", value:  new UnityEngine.Color32() {r = val_10.r, g = val_10.r, b = val_10.r, a = val_10.r});
        UnityEngine.Color32 val_11 = new UnityEngine.Color32(r:  255, g:  147, b:  21, a:  225);
        val_4.Add(key:  "ORANGE", value:  new UnityEngine.Color32() {r = val_11.r, g = val_11.r, b = val_11.r, a = val_11.r});
        this.tileColorLookup = val_4;
        this.tempCacheCollecteWords = new System.Collections.Generic.List<System.String>();
        this.eventCellsInCurLevel = new System.Collections.Generic.List<Cell>();
    }
    private bool <getGameLevel>b__63_0(string x)
    {
        bool val_1 = this.<collectedWords>k__BackingField.Contains(item:  x);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    private bool <HackCollectSmallestWord>b__111_0(string x)
    {
        bool val_1 = this.<collectedWords>k__BackingField.Contains(item:  x);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }

}
