using UnityEngine;
public class ExtraChapterEventHandler : WGEventHandler
{
    // Fields
    public const string EXTRA_CHAPTER_EVENT_ID = "ExtraChapterRewards";
    private bool participatingInEvent;
    private bool showParticipationPopup;
    private const string ExtraChapterKey = "ExtraChapterEvent";
    private const string RewardPopupShownToday = "ExtraChapterRewardPopupShown";
    private static ExtraChapterEventHandler _Instance;
    
    // Properties
    public static ExtraChapterEventHandler Instance { get; }
    public System.TimeSpan TimeRemaining { get; }
    public string TimeRemainingFormatted { get; }
    
    // Methods
    public static ExtraChapterEventHandler get_Instance()
    {
        return (ExtraChapterEventHandler)ExtraChapterEventHandler._Instance;
    }
    public System.TimeSpan get_TimeRemaining()
    {
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        return true + 40.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
    }
    public string get_TimeRemainingFormatted()
    {
        System.TimeSpan val_1 = this.TimeRemaining;
        System.TimeSpan val_4 = this.TimeRemaining;
        System.TimeSpan val_7 = this.TimeRemaining;
        return (string)System.String.Format(format:  "{0}d {1}h {2}m", arg0:  val_1._ticks.Days.ToString(format:  "0"), arg1:  val_4._ticks.Hours.ToString(format:  "0"), arg2:  val_7._ticks.Minutes.ToString(format:  "0"));
    }
    public override void Init(GameEventV2 eventV2)
    {
        ExtraChapterEventHandler._Instance = this;
        mem[1152921516232191680] = eventV2;
        if((CPlayerPrefs.HasKey(key:  "ExtraChapterEvent")) == false)
        {
            goto label_3;
        }
        
        if((System.String.op_Equality(a:  CPlayerPrefs.GetString(key:  "ExtraChapterEvent"), b:  eventV2.timeStart.ToShortDateString())) == false)
        {
            goto label_7;
        }
        
        this.participatingInEvent = true;
        GameEcon val_5 = App.getGameEcon;
        GameEcon val_6 = App.getGameEcon;
        val_5.ChapterClearedRewardMulitplier = val_6.extraChapterEventMultiplier;
        goto label_13;
        label_3:
        this.participatingInEvent = false;
        goto label_13;
        label_7:
        this.participatingInEvent = false;
        CPlayerPrefs.DeleteKey(key:  "ExtraChapterEvent");
        label_13:
        if((CPlayerPrefs.HasKey(key:  "ExtraChapterRewardPopupShown")) != false)
        {
                System.DateTime val_9 = DateTimeCheat.Today;
            if((System.String.op_Inequality(a:  CPlayerPrefs.GetString(key:  "ExtraChapterRewardPopupShown"), b:  val_9.dateData.ToShortDateString())) == false)
        {
                return;
        }
        
            CPlayerPrefs.DeleteKey(key:  "ExtraChapterRewardPopupShown");
        }
        
        this.showParticipationPopup = true;
    }
    public override string GetGameButtonText()
    {
        return "";
    }
    public override string GetMainMenuButtonText()
    {
        string val_1 = Localization.Localize(key:  "extra_chapter_reward_upper", defaultValue:  "EXTRA CHAPTER REWARDS", useSingularKey:  false);
        if(val_1.m_stringLength < 16)
        {
                return val_1;
        }
        
        if((val_1.Contains(value:  "\n")) == true)
        {
                return val_1;
        }
        
        if((val_1.LastIndexOf(value:  ' ')) < 1)
        {
                return val_1;
        }
        
        System.Char[] val_4 = val_1.ToCharArray();
        val_4[(val_1.LastIndexOf(value:  ' ')) << 1] = '
        ';
        return 0.CreateString(val:  val_4);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "extra_chapter_reward_upper", defaultValue:  "EXTRA CHAPTER REWARDS", useSingularKey:  false);
    }
    public override void OnGameSceneBegan()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        this.OnGameSceneBegan();
        if(this.showParticipationPopup == false)
        {
                return;
        }
        
        if(this.participatingInEvent != false)
        {
                GameEcon val_3 = App.getGameEcon;
            GameEcon val_4 = App.getGameEcon;
            val_3.ChapterClearedRewardMulitplier = val_4.extraChapterEventMultiplier;
        }
        
        GameBehavior val_5 = App.getBehavior;
        val_5.<metaGameBehavior>k__BackingField.Init(particpating:  this.participatingInEvent);
        System.DateTime val_7 = DateTimeCheat.Today;
        CPlayerPrefs.SetString(key:  "ExtraChapterRewardPopupShown", val:  val_7.dateData.ToShortDateString());
        this.showParticipationPopup = false;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.participatingInEvent != false)
        {
                System.TimeSpan val_3 = this.TimeRemaining;
            if(val_3._ticks.TotalSeconds > 0f)
        {
                GameBehavior val_5 = App.getBehavior;
        }
        
        }
        
        if(MainController.instance.IsChapterComplete != false)
        {
                if(this.participatingInEvent == false)
        {
            goto label_15;
        }
        
        }
        
        bool val_10 = MainController.instance.IsChapterComplete;
        return;
        label_15:
        if(this.participatingInEvent != false)
        {
                CPlayerPrefs.SetString(key:  "ExtraChapterEvent", val:  this.participatingInEvent + 32.ToShortDateString());
            CPlayerPrefs.Save();
        }
        
        this.participatingInEvent = true;
        this.showParticipationPopup = true;
    }
    public override void OnMenuLoaded()
    {
    
    }
    public override void OnMainMenuButtonPressed(bool connected = True)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 22;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGExtraChapterRewardsPopup>(showNext:  false).Init(particpating:  this.participatingInEvent);
    }
    public override void OnGameButtonPressed(bool connected = True)
    {
        var val_6 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (23 + 1) : 23;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGExtraChapterRewardsPopup>(showNext:  false).Init(particpating:  this.participatingInEvent);
    }
    public override void OnEventEnded()
    {
        GameEcon val_1 = App.getGameEcon;
        val_1.ChapterClearedRewardMulitplier = 1f;
        ExtraChapterEventHandler._Instance = 0;
    }
    public override int LastProgressTimestamp()
    {
        return this.LastProgressTimestamp();
    }
    public override bool IsRewardReadyToCollect()
    {
        return this.IsRewardReadyToCollect();
    }
    public override bool EventCompleted()
    {
        return this.EventCompleted();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        GameBehavior val_3 = App.getBehavior;
        if(this.participatingInEvent != false)
        {
                GameEcon val_6 = App.getGameEcon;
            string val_7 = System.String.Format(format:  Localization.Localize(key:  "x_chapter_rewards_upper", defaultValue:  "{0}X CHAPTER REWARDS", useSingularKey:  false), arg0:  val_6.extraChapterEventMultiplier);
        }
        else
        {
                string val_8 = Localization.Localize(key:  "complete_a_chapter_upper", defaultValue:  "COMPLETE A CHAPTER", useSingularKey:  false);
        }
        
        EventListItemContentExtraChapterRewards val_9 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentExtraChapterRewards>(allowMultiple:  false);
        float val_11 = (float)WADChapterManager.GetCurrentChapterLastLevel();
        val_11 = val_11 + 1f;
        val_11 = val_11 - (float)WADChapterManager.GetCurrentChapterFirstLevel();
        val_11 = ((float)(val_3.<metaGameBehavior>k__BackingField) - WADChapterManager.GetCurrentChapterFirstLevel()) / val_11;
    }
    public ExtraChapterEventHandler()
    {
    
    }

}
