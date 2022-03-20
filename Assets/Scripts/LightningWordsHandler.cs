using UnityEngine;
public class LightningWordsHandler : WGEventHandler
{
    // Fields
    private static LightningWordsHandler <Instance>k__BackingField;
    public const string LIGHTNING_WORDS_EVENT_ID = "LightningWords";
    private LightningWordsEventProgress eventProgress;
    private LightningWordsLevelProgress levelProgress;
    private LightningWordsLevelProgress trackLevelProgress;
    private const string ECONOMY = "economy";
    private const string REW = "rew";
    private const string R_N_LW = "r_n_lw";
    private const string A_C = "a_c";
    private const string DUR = "dur";
    private const string MPL = "mpl";
    private const string COINS = "coins";
    private const string BONUS_WHEEL = "bonus_wheel";
    private const string BONUS_SPIN = "bonus_spin";
    private const string PROGRESS = "progress";
    private const string REWARDED = "rewarded";
    private const GameEventRewardType DEFAULT_REWARD_TYPE = 1;
    private const int DEFAULT_REWARD_VALUE = 200;
    
    // Properties
    public static LightningWordsHandler Instance { get; set; }
    
    // Methods
    public static LightningWordsHandler get_Instance()
    {
        return (LightningWordsHandler)LightningWordsHandler.DEFAULT_REWARD_VALUE;
    }
    private static void set_Instance(LightningWordsHandler value)
    {
        LightningWordsHandler.DEFAULT_REWARD_VALUE = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        LightningWordsHandler.DEFAULT_REWARD_VALUE = this;
        mem[1152921516334174960] = eventV2;
        this.ParseEventData(data:  eventV2.eventData);
        if(this.IsEventNewCycle() != false)
        {
                this.ResetLightningWordsEventProgress();
        }
        
        this.eventProgress.timestamp = LightningWordsEventProgress.__il2cppRuntimeField_name;
        goto typeof(LightningWordsEventProgress).__il2cppRuntimeField_190;
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(true == 0)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  0, b:  "LightningWords")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        this.ParseEventData(data:  eventV2.eventData);
        if(this.IsEventNewCycle() != false)
        {
                this.ResetLightningWordsEventProgress();
        }
        
        this.eventProgress.timestamp = LightningWordsEventProgress.__il2cppRuntimeField_name;
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        if(this.GetEventProgress() < 0)
        {
                return;
        }
        
        this.ShowLightningWordsPopup();
    }
    public override void OnGameSceneBegan()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void LightningWordsHandler::OnWordFound(string word)));
        if((this.levelProgress.lightningRemainingTime & 2147483648) == 0)
        {
                this.ResumeLightningCountDownTimer();
        }
        
        if(this.GetLightningCountDown() >= 1)
        {
                if((System.String.IsNullOrEmpty(value:  this.levelProgress.currentLightningWord)) == true)
        {
                return;
        }
        
            if(this.levelProgress.IsCurrentModeEqualsModeWithTile() == false)
        {
                return;
        }
        
            MonoSingleton<LightningWordsUIController>.Instance.ApplyLightningEffects(wordIndex:  this.levelProgress.currentLightningWordIndex);
            return;
        }
        
        this.levelProgress.ReleaseCurrentLightningWord();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        LightningWordsEventProgress val_3;
        if((this & 1) != 0)
        {
                return;
        }
        
        if((this.levelProgress.firstLightningWordTimeRemaining & 2147483648) != 0)
        {
                int val_2 = this.eventProgress.missedLevels;
            val_2 = val_2 + 1;
            this.eventProgress.missedLevels = val_2;
        }
        
        val_3 = this.eventProgress;
        if(this.eventProgress.resetLevelProgress != true)
        {
                this.trackLevelProgress = this.levelProgress;
            this.levelProgress = new LightningWordsLevelProgress();
            val_3 = this.eventProgress;
        }
        
        this.eventProgress.resetLevelProgress = false;
    }
    public override void OnEventEnded()
    {
        LightningWordsHandler.DEFAULT_REWARD_VALUE = 0;
        LightningWordsHandler.DEFAULT_REWARD_VALUE.__il2cppRuntimeField_3 = 0;
        goto typeof(LightningWordsEventProgress).__il2cppRuntimeField_1A0;
    }
    public override bool EventCompleted()
    {
        if(this.eventProgress != null)
        {
                return (bool)this.eventProgress.rewarded;
        }
        
        throw new NullReferenceException();
    }
    public override int LastProgressTimestamp()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.lastProgressTimestamp;
        }
        
        throw new NullReferenceException();
    }
    public override void UpdateProgress()
    {
        this.eventProgress.lastProgressTimestamp = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        var val_3;
        if(this.GetEventProgress() >= 1f)
        {
                return (bool)(this.eventProgress.rewarded == false) ? 1 : 0;
        }
        
        val_3 = 0;
        return (bool)(this.eventProgress.rewarded == false) ? 1 : 0;
    }
    public override void MarkEventRewarded()
    {
        var val_9;
        GameEventRewardType val_10;
        val_9 = null;
        val_9 = null;
        val_10 = LightningWordsEcon.rewardType;
        if(val_10 != 1)
        {
            goto label_3;
        }
        
        label_29:
        this.eventProgress.rewarded = true;
        this.UpdateProgressionToServer();
        return;
        label_3:
        val_9 = null;
        val_10 = LightningWordsEcon.rewardType;
        if(val_10 != 3)
        {
            goto label_8;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.GetWindow<BonusGameWheelPopup>();
        if((val_2 == 0) || (val_2.enabled == false))
        {
            goto label_29;
        }
        
        mem2[0] = 0;
        goto label_29;
        label_8:
        val_10 = LightningWordsEcon.rewardType;
        if(val_10 != 4)
        {
            goto label_29;
        }
        
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.GetWindow<BonusGameSlotMachinePopup>();
        if((val_6 == 0) || (val_6.enabled == false))
        {
            goto label_29;
        }
        
        val_6.waitingForGeneration = 0;
        goto label_29;
    }
    public override void OnSubmitWordWithHints(string word)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        this.OnWordFound(word:  word);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_1;
        var val_2;
        val_1 = this;
        if((val_1 & 1) != 0)
        {
                return;
        }
        
        this.ShowLightningWordsPopup();
        val_1 = 1152921504887996416;
        val_2 = null;
        val_2 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 45;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_1;
        var val_2;
        val_1 = this;
        if((val_1 & 1) != 0)
        {
                return;
        }
        
        this.ShowLightningWordsPopup();
        val_1 = 1152921504887996416;
        val_2 = null;
        val_2 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 46;
    }
    public override string GetMainMenuButtonText()
    {
        int val_4;
        int val_5;
        string[] val_1 = new string[5];
        val_1[0] = "<size=43>";
        val_4 = val_1.Length;
        val_1[1] = Localization.Localize(key:  "lightning_words_upper", defaultValue:  "LIGHTNING WORDS", useSingularKey:  false);
        val_4 = val_1.Length;
        val_1[2] = " ";
        val_5 = val_1.Length;
        val_1[3] = this.GetEventProgressText(spaced:  false);
        val_5 = val_1.Length;
        val_1[4] = "</size>";
        return +val_1;
    }
    public override string GetGameButtonText()
    {
        return this.GetEventProgressText(spaced:  false);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "lightning_words_upper", defaultValue:  "LIGHTNING WORDS", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentLightningWords val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentLightningWords>(allowMultiple:  false);
        string val_2 = this.GetEventProgressText(spaced:  false);
        float val_3 = this.GetEventProgress();
        goto typeof(EventListItemContentLightningWords).__il2cppRuntimeField_180;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1;
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.trackLevelProgress == null)
        {
                return;
        }
        
        if(null < 1)
        {
                return;
        }
        
        if((this.trackLevelProgress.firstLightningWordTimeRemaining & 2147483648) != 0)
        {
                return;
        }
        
        val_1 = currentData;
        val_1.Add(key:  "Lightning Words", value:  null);
        1152921516336542816 = currentData;
        1152921516336542816.Add(key:  "Lightning Words Time Remaining", value:  this.trackLevelProgress.firstLightningWordTimeRemaining);
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(LightningWordsHandler).__il2cppRuntimeField_4F0;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        if(data == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "economy")) != false)
        {
                object val_2 = data.Item["economy"];
            if(val_2 != null)
        {
                if((val_2.ContainsKey(key:  "rew")) != false)
        {
                val_24 = 0;
            val_2.Item["rew"].ParseRewards(rewardData:  null);
        }
        
            if((val_2.ContainsKey(key:  "r_n_lw")) != false)
        {
                val_25 = null;
            val_25 = null;
            bool val_8 = System.Int32.TryParse(s:  val_2.Item["r_n_lw"], result: out  1152921504977723400);
        }
        
            if((val_2.ContainsKey(key:  "a_c")) != false)
        {
                val_26 = null;
            val_26 = null;
            bool val_12 = System.Single.TryParse(s:  val_2.Item["a_c"], result: out  1152921504977723404);
        }
        
            if((val_2.ContainsKey(key:  "dur")) != false)
        {
                val_27 = null;
            val_27 = null;
            bool val_16 = System.Int32.TryParse(s:  val_2.Item["dur"], result: out  1152921504977723408);
        }
        
            if((val_2.ContainsKey(key:  "mpl")) != false)
        {
                val_28 = null;
            val_28 = null;
            bool val_20 = System.Int32.TryParse(s:  val_2.Item["mpl"], result: out  1152921504977723412);
        }
        
        }
        
        }
        
        val_23 = "progress";
        if((data.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        if(data.Item["progress"] == null)
        {
                return;
        }
    
    }
    private void ParseRewards(System.Collections.Generic.Dictionary<string, object> rewardData)
    {
        string val_3;
        var val_4;
        var val_14;
        string val_15;
        var val_16;
        GameEventRewardType val_17;
        var val_18;
        var val_19;
        Dictionary.Enumerator<TKey, TValue> val_1 = rewardData.GetEnumerator();
        label_10:
        val_14 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_16 = val_3;
        val_15 = val_3;
        int val_6 = 0;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_6 < 1) || (((System.Int32.TryParse(s:  val_15, result: out  val_6)) ^ 1) == true))
        {
            goto label_10;
        }
        
        if(val_16 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_14 = 0;
        string val_9 = val_16.Trim();
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        string val_10 = val_9.ToLower();
        if((System.String.Compare(strA:  val_10, strB:  "coins")) == 0)
        {
            goto label_8;
        }
        
        if((System.String.Compare(strA:  val_10, strB:  "bonus_wheel")) == 0)
        {
            goto label_9;
        }
        
        if((System.String.Compare(strA:  val_10, strB:  "bonus_spin")) != 0)
        {
            goto label_10;
        }
        
        val_17 = 4;
        goto label_13;
        label_2:
        val_18 = 0;
        val_17 = 0;
        goto label_12;
        label_8:
        val_17 = 1;
        goto label_13;
        label_9:
        val_17 = 3;
        label_13:
        val_18 = val_6;
        label_12:
        val_4.Dispose();
        val_19 = null;
        if(val_17 != 0)
        {
                val_19 = null;
        }
        else
        {
                val_19 = null;
            val_18 = 200;
            val_17 = 1;
        }
        
        LightningWordsEcon.rewardType = val_17;
        LightningWordsEcon.reward = 200;
    }
    private void ParseProgress(System.Collections.Generic.Dictionary<string, object> progress)
    {
        if((progress.ContainsKey(key:  "rewarded")) == false)
        {
                return;
        }
        
        bool val_4 = System.Boolean.TryParse(value:  progress.Item["rewarded"], result: out  false);
        this.eventProgress.rewarded = false;
    }
    private void OnWordFound(string word)
    {
        string val_10;
        var val_11;
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        val_10 = word;
        if(((System.String.op_Equality(a:  this.levelProgress.currentLightningWord, b:  val_10)) != false) && (this.levelProgress.IsCurrentModeEqualsModeWithTile() != false))
        {
                int val_4 = this.GetLightningCountDown();
            if((this.levelProgress.firstLightningWordTimeRemaining & 2147483648) != 0)
        {
                val_10 = 0;
            this.levelProgress.firstLightningWordTimeRemaining = UnityEngine.Mathf.Max(a:  val_4, b:  0);
        }
        
            if((val_4 & 2147483648) == 0)
        {
                this.HandleLightningWordFound(word:  val_10);
        }
        
            this.levelProgress.ReleaseCurrentLightningWord();
        }
        
        if(this.IsLightningWordReady() == false)
        {
                return;
        }
        
        this.ResetLightningWordJustFoundStatus();
        this.eventProgress.missedLevels = 0;
        System.DateTime val_7 = DateTimeCheat.Now;
        val_11 = null;
        val_11 = null;
        val_10 = 0;
        int val_10 = LightningWordsEcon.duration;
        val_10 = val_10 + 1;
        System.DateTime val_8 = val_7.dateData.AddSeconds(value:  (double)val_10);
        this.levelProgress.lightningEndTime = val_8;
        this.ShowLightningWord();
        MonoSingleton<LightningWordsUIController>.Instance.PlayLightningSFX();
    }
    private void ShowLightningWord()
    {
        var val_11;
        int val_12;
        var val_13;
        LightningWordsEventProgress val_14;
        val_11 = this;
        val_12 = this.levelProgress.currentLightningWordIndex;
        if(val_12 == 1)
        {
                val_12 = this.GenerateNewLightningWordIndex();
        }
        
        val_13 = 1152921516334511232;
        MonoSingleton<LightningWordsUIController>.Instance.ApplyLightningEffects(wordIndex:  val_12);
        val_14 = null;
        if(this.eventProgress.isFTUX != false)
        {
                MonoSingleton<LightningWordsUIController>.Instance.ShowFTUX();
            this.eventProgress.isFTUX = false;
            val_14 = this.eventProgress;
            val_11 = ???;
            val_13 = ???;
        }
        else
        {
                MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowLightningStrikeFlyout();
        }
    
    }
    private void HandleLightningWordFound(string word)
    {
        var val_1 = W9 + 1;
        mem2[0] = val_1;
        val_1 = val_1 + 1;
        mem2[0] = val_1;
        this.eventProgress.isLightningWordJustFound = true;
        if(this.IsLevelCompleted() != false)
        {
                this.trackLevelProgress = this.levelProgress;
            this.levelProgress = new LightningWordsLevelProgress();
            this.eventProgress.resetLevelProgress = true;
        }
        
        MonoSingleton<LightningWordsUIController>.Instance.UpdateEventButton();
    }
    private int GenerateNewLightningWordIndex()
    {
        int val_9;
        object val_10;
        var val_11;
        string val_12;
        int val_13;
        val_9 = 1152921504879157248;
        if(WordRegion.instance != 0)
        {
            goto label_5;
        }
        
        val_10 = "LightningWordsHandler:GenerateNewLightingWordIndex(): no WordRegion instance, will fail";
        goto label_8;
        label_5:
        WordRegion val_3 = WordRegion.instance;
        if((X22 + 24) == 0)
        {
            goto label_13;
        }
        
        RandomSet val_4 = new RandomSet();
        if((X22 + 24) >= 1)
        {
                var val_10 = 0;
            do
        {
            if((X22 + 24) <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_9 = X22 + 16;
            val_9 = val_9 + 0;
            if(((X22 + 16 + 0) + 32 + 56) == 0)
        {
                val_4.add(item:  0, weight:  1f);
        }
        
            val_10 = val_10 + 1;
        }
        while(val_10 < (X22 + 24));
        
        }
        
        val_11 = 0;
        this.levelProgress.currentLightningWordIndex = val_4.roll(unweighted:  false);
        val_9 = this.levelProgress.currentLightningWordIndex;
        if((X22 + 24) <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_11 = X22 + 16;
        val_11 = val_11 + ((this.levelProgress.currentLightningWordIndex) << 3);
        this.levelProgress.currentLightningWord = (X22 + 16 + (this.levelProgress.currentLightningWordIndex) << 3) + 32 + 24;
        this.levelProgress.currentMode = PlayingLevel.CurrentGameplayMode;
        if(this.levelProgress.currentMode != 4)
        {
            goto label_29;
        }
        
        CategoryPacksManager val_7 = MonoSingleton<CategoryPacksManager>.Instance;
        val_11 = 0;
        string val_8 = val_7.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
        goto label_34;
        label_13:
        val_10 = "LightningWordsHandler:GenerateNewLightingWordIndex(): no WordRegion instance lines, will fail";
        label_8:
        UnityEngine.Debug.LogError(message:  val_10);
        val_13 = 0;
        return val_13;
        label_29:
        val_12 = 0;
        label_34:
        this.levelProgress.currentModeSecondaryId = val_12;
        val_13 = this.levelProgress.currentLightningWordIndex;
        return val_13;
    }
    private bool IsLightningWordReady()
    {
        var val_5;
        if(this.IsLevelCompleted() == true)
        {
                return false;
        }
        
        if(this.eventProgress.missedLevels == 2)
        {
                val_5 = null;
            val_5 = null;
            if(LightningWordsEcon.appearingChance > 0f)
        {
                return false;
        }
        
        }
        
        if(this.GetEventProgress() >= 0)
        {
                return false;
        }
        
        if(this.GetLevelProgress() >= 0)
        {
                return false;
        }
        
        bool val_4 = System.String.IsNullOrEmpty(value:  this.levelProgress.currentLightningWord);
        if(val_4 != false)
        {
                return val_4.IsSuperLucky();
        }
        
        return false;
    }
    private bool IsSuperLucky()
    {
        var val_3 = null;
        float val_3 = 100f;
        val_3 = LightningWordsEcon.appearingChance * val_3;
        val_3 = (val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
        return (bool)((UnityEngine.Random.Range(min:  0, max:  100)) < (int)val_3) ? 1 : 0;
    }
    private bool IsLevelCompleted()
    {
        var val_4;
        var val_5;
        List.Enumerator<T> val_2 = WordRegion.instance.GetEnumerator();
        val_4 = 1152921515429107504;
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(7 != 0)
        {
            goto label_7;
        }
        
        val_5 = 0;
        goto label_8;
        label_5:
        val_5 = 1;
        label_8:
        0.Dispose();
        return (bool)val_5;
    }
    private float GetLevelProgress()
    {
        null = null;
        float val_1 = (float)LightningWordsEcon.maxNumPerLvl;
        val_1 = (1.152922E+18f) / val_1;
        return (float)val_1;
    }
    private void UpdateProgressionToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "timestamp", value:  this.eventProgress.timestamp);
        val_1.Add(key:  "level_progress", value:  this.levelProgress);
        val_1.Add(key:  "event_progress", value:  this.eventProgress);
        val_1.Add(key:  "rewarded", value:  this.eventProgress.rewarded);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    private void ResetLightningWordsEventProgress()
    {
        this.levelProgress = new LightningWordsLevelProgress();
        .missedLevels = 0;
        mem[1152921516338726288] = 0;
        mem[1152921516338726307] = 0;
        mem[1152921516338726305] = 0;
        .rewarded = false;
        .resetLevelProgress = false;
        .isLightningWordJustFound = false;
        .lastProgressTimestamp = 0;
        .isFTUX = true;
        this.eventProgress = new LightningWordsEventProgress();
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress.timestamp != (X9 + 16)) ? 1 : 0;
    }
    public void ShowLightningWordsPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLightningWordsPopup>(showNext:  false);
    }
    public void ShowInternetRequiredPopup()
    {
        int val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public bool InExpireInterval()
    {
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 504464731990392832})) != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28});
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28})) == false)
        {
                return false;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_5.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48});
    }
    public float GetEventProgress()
    {
        null = null;
        float val_1 = (float)LightningWordsEcon.requiredNumWords;
        val_1 = (1.152922E+18f) / val_1;
        return (float)val_1;
    }
    public string GetEventProgressText(bool spaced = False)
    {
        var val_5 = null;
        return (string)this.eventProgress + 16.ToString()(this.eventProgress + 16.ToString()) + (spaced != true) ? " / " : "/"((spaced != true) ? " / " : "/") + LightningWordsEcon.requiredNumWords;
    }
    public void PauseLightningCountDownTimer()
    {
        if(this.levelProgress.paused != false)
        {
                return;
        }
        
        this.levelProgress.paused = true;
        this.levelProgress.lightningRemainingTime = this.GetLightningCountDown() + 1;
        goto typeof(LightningWordsLevelProgress).__il2cppRuntimeField_190;
    }
    public void ResumeLightningCountDownTimer()
    {
        if(this.levelProgress.paused == false)
        {
                return;
        }
        
        this.levelProgress.paused = false;
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)this.levelProgress.lightningRemainingTime);
        this.levelProgress.lightningEndTime = val_2;
        this.levelProgress.lightningRemainingTime = 0;
    }
    public bool IsLightningWordJustFound()
    {
        if(this.eventProgress != null)
        {
                return (bool)this.eventProgress.isLightningWordJustFound;
        }
        
        throw new NullReferenceException();
    }
    public void ResetLightningWordJustFoundStatus()
    {
        this.eventProgress.isLightningWordJustFound = false;
        this.levelProgress.lightningEndTime = 0;
    }
    public bool IsLightningCountDownTimerPaused()
    {
        if(this.levelProgress != null)
        {
                return (bool)this.levelProgress.paused;
        }
        
        throw new NullReferenceException();
    }
    public int GetLightningCountDown()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.levelProgress.lightningEndTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        double val_3 = val_2._ticks.TotalSeconds;
        val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
        return (int)(int)val_3;
    }
    public string GetEventRemainingTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = UnityEngine.Mathf.Max(a:  val_2._ticks.Days, b:  0);
        val_3[1] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
        val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
        val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0);
        return (string)System.String.Format(format:  "{0:0}:{1:00}:{2:00}:{3:00}", args:  val_3);
    }
    public bool IsLightningWordPeriod()
    {
        var val_4;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.levelProgress.lightningEndTime}, d2:  new System.DateTime())) != false)
        {
                var val_3 = (this.GetLightningCountDown() > 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public bool IsCoinSpentDuringLightningWord()
    {
        if(this.levelProgress.isCoinSpent == true)
        {
                return (bool)this.levelProgress.isCoinSpent;
        }
        
        int val_2 = this.GetLightningCountDown() >> 31;
        val_2 = val_2 ^ 1;
        this.levelProgress.isCoinSpent = val_2;
        this.levelProgress = this.levelProgress;
        return (bool)this.levelProgress.isCoinSpent;
    }
    public string GetCurrentLightningWord()
    {
        if(this.levelProgress != null)
        {
                return (string)this.levelProgress.currentLightningWord;
        }
        
        throw new NullReferenceException();
    }
    public void Hack_ResetLightningWordsEventProgress()
    {
        this.ResetLightningWordsEventProgress();
        goto typeof(LightningWordsEventProgress).__il2cppRuntimeField_190;
    }
    public LightningWordsHandler()
    {
        .missedLevels = 0;
        mem[1152921516341100000] = 0;
        mem[1152921516341100019] = 0;
        mem[1152921516341100017] = 0;
        .rewarded = false;
        .resetLevelProgress = false;
        .isLightningWordJustFound = false;
        .lastProgressTimestamp = 0;
        .isFTUX = true;
        this.eventProgress = new LightningWordsEventProgress();
        this.levelProgress = new LightningWordsLevelProgress();
    }

}
