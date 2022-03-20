using UnityEngine;
public class WGEventHandler : IDisposable
{
    // Fields
    protected GameEventV2 myEvent;
    public System.Action OnMyPopupWasClosed_action;
    
    // Properties
    public string EventType { get; }
    public virtual bool SupportsGoldenApples { get; }
    public virtual bool IsEventValid { get; }
    public virtual bool IsEventHidden { get; }
    public virtual bool OverrideEventButton { get; }
    public virtual int getPriorityWeight { get; }
    public virtual int UnlockLevel { get; }
    public virtual bool IsPointCollection { get; }
    public virtual bool IsGoalCompletion { get; }
    public virtual int PointsCollected { get; set; }
    public virtual int PointsRequired { get; }
    
    // Methods
    public static string UnFuckTrackingName(string eventName)
    {
        string val_20;
        string val_21;
        var val_22;
        var val_23;
        val_20 = eventName;
        uint val_1 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_20);
        if(val_1 > (-1733371588))
        {
            goto label_1;
        }
        
        if(val_1 > 1314484049)
        {
            goto label_2;
        }
        
        if(val_1 > 813111565)
        {
            goto label_3;
        }
        
        if(val_1 == 386644468)
        {
            goto label_4;
        }
        
        if(val_1 != 813111565)
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_2 = System.String.op_Equality(a:  val_21, b:  "TriviaMasters");
        val_22 = "Trivia Masters Event";
        goto label_37;
        label_1:
        if(val_1 > (-746431984))
        {
            goto label_7;
        }
        
        if(val_1 > (-1129030916))
        {
            goto label_8;
        }
        
        if(val_1 == (-1531801635))
        {
            goto label_9;
        }
        
        if(val_1 != (-1129030916))
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_3 = System.String.op_Equality(a:  val_21, b:  "WordHunt");
        val_22 = "Word Hunt";
        goto label_37;
        label_2:
        if(val_1 > 2102096662)
        {
            goto label_12;
        }
        
        if(val_1 == 1751534916)
        {
            goto label_13;
        }
        
        if(val_1 != 2102096662)
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_4 = System.String.op_Equality(a:  val_21, b:  "CrazyCategories");
        val_22 = "Crazy Categories Event";
        goto label_37;
        label_7:
        if(val_1 > (-306129312))
        {
            goto label_16;
        }
        
        if(val_1 == (-623396922))
        {
            goto label_17;
        }
        
        if(val_1 != (-306129312))
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_5 = System.String.op_Equality(a:  val_21, b:  "BigQuiz");
        val_22 = "Big Quiz Event";
        goto label_37;
        label_3:
        if(val_1 == 999457290)
        {
            goto label_20;
        }
        
        if(val_1 != 1314484049)
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_6 = System.String.op_Equality(a:  val_21, b:  "SeasonPass");
        val_22 = "Season Event";
        goto label_37;
        label_8:
        if(val_1 == (-1050565114))
        {
            goto label_23;
        }
        
        if(val_1 != (-746431984))
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_7 = System.String.op_Equality(a:  val_21, b:  "StarChampionship");
        val_22 = "Star Championship Event";
        goto label_37;
        label_12:
        if(val_1 == (-1957254795))
        {
            goto label_26;
        }
        
        if(val_1 != (-1733371588))
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_8 = System.String.op_Equality(a:  val_21, b:  "RestaurantMaster");
        val_22 = "Restaurant Master";
        goto label_37;
        label_16:
        if(val_1 == (-157622816))
        {
            goto label_29;
        }
        
        if(val_1 != (-53406543))
        {
            goto label_30;
        }
        
        val_21 = val_20;
        bool val_9 = System.String.op_Equality(a:  val_21, b:  "CrownClashCvC");
        val_22 = "Club Clash Event";
        goto label_37;
        label_4:
        val_21 = val_20;
        bool val_10 = System.String.op_Equality(a:  val_21, b:  "WordBingo");
        val_22 = "Bingo";
        goto label_37;
        label_9:
        val_21 = val_20;
        bool val_11 = System.String.op_Equality(a:  val_21, b:  "PiggyBankRaid");
        val_22 = "Piggy Bank Raid";
        goto label_37;
        label_13:
        val_21 = val_20;
        bool val_12 = System.String.op_Equality(a:  val_21, b:  "HotNSpicy");
        val_22 = "Hot N Spicy";
        goto label_37;
        label_17:
        val_21 = val_20;
        bool val_13 = System.String.op_Equality(a:  val_21, b:  "RaidMadness");
        val_22 = "Raid Madness";
        goto label_37;
        label_20:
        val_21 = val_20;
        bool val_14 = System.String.op_Equality(a:  val_21, b:  "AttackMadness");
        val_22 = "Attack Madness";
        goto label_37;
        label_23:
        val_21 = val_20;
        bool val_15 = System.String.op_Equality(a:  val_21, b:  "ForestMaster");
        val_22 = "Forest Master";
        goto label_37;
        label_26:
        var val_17 = ((System.String.op_Equality(a:  val_20, b:  "CrownClashPvP")) != true) ? "ApplePicking" : (val_20);
        return (string)val_23;
        label_29:
        val_21 = val_20;
        val_22 = "Trivia Pursuit";
        label_37:
        label_30:
        val_23 = ((System.String.op_Equality(a:  val_21, b:  "TriviaPursuit")) != true) ? (val_22) : (val_20);
        return (string)val_23;
    }
    public string get_EventType()
    {
        return (string)(this.myEvent == 0) ? "" : this.myEvent.type;
    }
    public virtual bool get_SupportsGoldenApples()
    {
        return false;
    }
    public virtual bool get_IsEventValid()
    {
        return true;
    }
    public virtual bool get_IsEventHidden()
    {
        return false;
    }
    public virtual bool get_OverrideEventButton()
    {
        return false;
    }
    public virtual int get_getPriorityWeight()
    {
        return 0;
    }
    public virtual int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return UnityEngine.Mathf.Max(a:  this.myEvent.minPlayerLevel, b:  val_1.events_unlockLevel);
    }
    public virtual void PreInit(GameEventV2 eventV2)
    {
    
    }
    public virtual void Init(GameEventV2 eventV2)
    {
        this.myEvent = eventV2;
    }
    public virtual void Dispose()
    {
    
    }
    public virtual void OnGameSceneInit()
    {
    
    }
    public virtual void OnGameSceneBegan()
    {
    
    }
    public virtual void OnMenuLoaded()
    {
    
    }
    public virtual void OnWordRegionLoaded()
    {
    
    }
    public virtual void OnMainMenuButtonPressed(bool connected)
    {
    
    }
    public virtual void OnGameButtonPressed(bool connected)
    {
    
    }
    public virtual bool IsChallengeCompleted()
    {
        return false;
    }
    public virtual bool IsRewardReadyToCollect()
    {
        return false;
    }
    public virtual int LastProgressTimestamp()
    {
        return 0;
    }
    public virtual bool IsExcludedFromGameSceneButtonOrdering()
    {
        return false;
    }
    public virtual void UpdateProgress()
    {
        MonoSingleton<WordGameEventsController>.Instance.OnEventHandlerProgress();
    }
    public virtual bool IsEventEndedOffline()
    {
        return false;
    }
    public virtual void OnBeforeLevelComplete(int levelsProgressed = 1)
    {
    
    }
    public virtual void OnEventEnded()
    {
    
    }
    public virtual void OnDataUpdated(GameEventV2 eventV2)
    {
    
    }
    public virtual void OnProfileUpdated()
    {
    
    }
    public virtual void OnCategorySelected(TRVCategorySelectionInfo category)
    {
    
    }
    public virtual System.Collections.Generic.List<TRVCategorySelectionInfo> GetEventsRegisteredCategories(System.Collections.Generic.List<TRVCategorySelectionInfo> categories)
    {
        return (System.Collections.Generic.List<TRVCategorySelectionInfo>)categories;
    }
    public virtual string GetMainMenuButtonText()
    {
        return this.myEvent.type + " not implemented";
    }
    public virtual string GetGameButtonText()
    {
        return this.myEvent.type + " not implemented";
    }
    public virtual string GetEventDisplayName()
    {
        return this.myEvent.type + " not implemented";
    }
    public virtual void OnLevelComplete(int levelsProgressed = 1)
    {
    
    }
    public virtual void OnForestComplete(int levelsProgressed = 1)
    {
    
    }
    public virtual void OnNewForestShown()
    {
    
    }
    public virtual void OnForestUpdated()
    {
    
    }
    public virtual void OnMysteryChestCollected()
    {
    
    }
    public virtual void OnCategoryComplete()
    {
    
    }
    public virtual void OnDailyChallengeLevelComplete()
    {
    
    }
    public virtual void OnDailyChallengeRewardGranted()
    {
    
    }
    public virtual void OnBonusGameGoldCurrencyRewardGranted()
    {
    
    }
    public virtual void OnAppleAwarded(int appleAwarded)
    {
    
    }
    public virtual void OnSubmitWordWithHints(string word)
    {
    
    }
    public virtual void OnHintIncompleteWord(string word, Cell hintedCell)
    {
    
    }
    public virtual void OnHintForceMyEventLineWord(System.Collections.Generic.List<LineWord> lines, ref LineWord word, bool isPickerHint)
    {
    
    }
    public virtual void OnDailyChallengeInit()
    {
    
    }
    public virtual void HandleCollectAction()
    {
    
    }
    public virtual void HandleAdvertisedSeen()
    {
    
    }
    public virtual void HackAddLevels(int levelsHacked)
    {
    
    }
    public virtual void OnWindowsStateChange(bool anyActiveWindows)
    {
    
    }
    public virtual void OnVideoResponse(bool success)
    {
    
    }
    public virtual string DebugGetLevel()
    {
        return "not implemented for current event";
    }
    public virtual bool ActivelyPlayingGameMode()
    {
        return false;
    }
    public virtual System.DateTime GetTimeEnd()
    {
        if(this.myEvent != null)
        {
                return (System.DateTime)this.myEvent.timeEnd;
        }
        
        throw new NullReferenceException();
    }
    public virtual System.DateTime GetTimeStart()
    {
        if(this.myEvent != null)
        {
                return (System.DateTime)this.myEvent.timeStart;
        }
        
        throw new NullReferenceException();
    }
    public virtual System.TimeSpan GetTimeLeft()
    {
        long val_4;
        var val_5;
        var val_6;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = this.Subtract(value:  new System.DateTime() {dateData = val_1.dateData});
        val_4 = val_2._ticks;
        val_5 = null;
        val_5 = null;
        if((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = val_4}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != 1)
        {
                return val_4;
        }
        
        val_6 = null;
        val_6 = null;
        val_4 = System.TimeSpan.Zero;
        return val_4;
    }
    public virtual string GetCustomizedEventListItemTimerText()
    {
        return "";
    }
    public virtual bool EventCompleted()
    {
        return false;
    }
    public virtual void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
    
    }
    public virtual void AppendDailyChallengeCompleteData(ref System.Collections.Generic.Dictionary<string, object> data)
    {
    
    }
    public virtual void AppendLeaguesRolloverData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
    
    }
    public virtual void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        if((loader.LoadStrictlyTypeNamedPrefab<EventListItemContent>(allowMultiple:  false)) == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(EventListItemContent).__il2cppRuntimeField_170;
    }
    public virtual void OnMyEventPopupClosed()
    {
        if(this.OnMyPopupWasClosed_action != null)
        {
                this.OnMyPopupWasClosed_action.Invoke();
        }
        
        this.OnMyPopupWasClosed_action = 0;
    }
    public virtual string GetHackPanelEventData()
    {
        return "No Event Data Set For Current Event";
    }
    public virtual bool TryShowFtux()
    {
        return false;
    }
    public virtual void MarkEventRewarded()
    {
    
    }
    public virtual GameLevel getGameLevel(GameLevel refLevel)
    {
        return 0;
    }
    public virtual bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return (bool)(~dailyChallengeState) & 1;
    }
    public virtual bool ShouldShowInCategories(bool categoriesState)
    {
        return (bool)categoriesState;
    }
    public virtual bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return false;
    }
    public virtual void ResetDCProgress()
    {
    
    }
    public virtual void OnPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
    {
    
    }
    public virtual int GetMovingWordIndex()
    {
        return 0;
    }
    public virtual void OnValidWordSubmitted(string word)
    {
    
    }
    public virtual void OnInvalidWordSubmitted()
    {
    
    }
    public virtual void BreakStreak()
    {
    
    }
    public virtual void OnFacebookPluginUpdate()
    {
    
    }
    public virtual void OnPurchaseCompleted(PurchaseModel purchase)
    {
    
    }
    public virtual void OnPurchaseFailure(PurchaseModel purchase)
    {
    
    }
    public virtual void OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    public virtual void OnAnyHintUsed(bool free)
    {
    
    }
    public virtual UnityEngine.Sprite GetEventIcon()
    {
        return 0;
    }
    public virtual void OnLevelCompleteRewarded()
    {
    
    }
    public virtual void OnLevelCompleteRewardAnimFinished()
    {
    
    }
    public virtual System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        return 0;
    }
    public virtual System.Collections.IEnumerator DoLevelCompleteEventWrapUpAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventButton = eventButton;
        return (System.Collections.IEnumerator)new WGEventHandler.<DoLevelCompleteEventWrapUpAnimation>d__94();
    }
    public virtual TRVQuizProgress GetCustomQuizLevel(TRVSubCategoryData data)
    {
        return 0;
    }
    public virtual WGWindow showPreQuestionWindow(TRVQuizProgress progress)
    {
        return 0;
    }
    public virtual bool HasMovingObject()
    {
        return false;
    }
    public virtual void AppendGemSpentTracking(ref System.Collections.Generic.Dictionary<string, object> refData)
    {
    
    }
    public virtual void AppendAmplitudeUserProperties(ref System.Collections.Generic.Dictionary<string, object> globals)
    {
    
    }
    public virtual string EventContentItemButtonText()
    {
        return Localization.Localize(key:  "view_event_upper", defaultValue:  "VIEW EVENT", useSingularKey:  false);
    }
    public virtual bool get_IsPointCollection()
    {
        return false;
    }
    public virtual bool get_IsGoalCompletion()
    {
        return false;
    }
    public virtual int get_PointsCollected()
    {
        return 0;
    }
    public virtual void set_PointsCollected(int value)
    {
    
    }
    public virtual int get_PointsRequired()
    {
        return 0;
    }
    public virtual RESEventRewardData GetCurrentReward()
    {
        return 0;
    }
    public virtual void OnSpinStarted()
    {
    
    }
    public virtual void OnSpinEnded()
    {
    
    }
    public virtual void OnReelStopped(Notification notif)
    {
    
    }
    public virtual void OnAllReelsStopped()
    {
    
    }
    public virtual void OnSpinAmountUpdate()
    {
    
    }
    public virtual void OnSpinBetUpdate()
    {
    
    }
    public WGEventHandler()
    {
    
    }

}
