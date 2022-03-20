using UnityEngine;
public class TRVCrazyCategoriesEventHandler : WGEventHandler
{
    // Fields
    private static TRVCrazyCategoriesEventHandler _Instance;
    public const string EVENT_ID = "CrazyCategories";
    public const string EVENT_TRACKING_ID = "Crazy Categories Event";
    private string bonusCategory;
    public int multiplier;
    
    // Properties
    public static TRVCrazyCategoriesEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public string getBonusCategory { get; }
    private static int LastProgressTimestampPref { get; set; }
    
    // Methods
    public static TRVCrazyCategoriesEventHandler get_Instance()
    {
        return (TRVCrazyCategoriesEventHandler)TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public string get_getBonusCategory()
    {
        return (string)this.bonusCategory;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "cc_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "cc_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517375356896] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID = this;
    }
    public override void OnGameSceneBegan()
    {
        int val_1 = CPlayerPrefs.GetInt(key:  "crazyCategoriesFtux", defaultValue:  0);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "crazy_categories_upper", defaultValue:  "CRAZY CATEGORIES", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "crazy_categories_upper", defaultValue:  "CRAZY CATEGORIES", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "crazy_categories_upper", defaultValue:  "CRAZY CATEGORIES", useSingularKey:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVCrazyCategoriesPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVCrazyCategoriesPopup>(showNext:  false);
    }
    public override void UpdateProgress()
    {
        TRVCrazyCategoriesEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentCrazyCategories val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentCrazyCategories>(allowMultiple:  false);
        goto typeof(EventListItemContentCrazyCategories).__il2cppRuntimeField_170;
    }
    public override void OnLevelCompleteRewarded()
    {
        int val_5;
        if(TRVCrazyCategoriesEventHandler.BonusStarsEligable() == false)
        {
                return;
        }
        
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        val_5 = val_2.currentGame.finalStarReward;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "Crazy Category Bonus Stars", value:  val_5);
        MonoSingleton<TRVStarsManager>.Instance.AwardStar(earnedAmount:  val_5, source:  "Crazy Category Bonus Stars", subSource:  0, additionalParam:  val_3);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = eventData.Item["economy"];
    }
    public static void RollBonusCategory(System.Collections.Generic.List<string> chosenCategories)
    {
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return;
        }
        
        int val_1 = UnityEngine.Random.Range(min:  0, max:  0);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID.__unknownFiledOffset_20 = (TRVCrazyCategoriesEventHandler.__il2cppRuntimeField_static_fields + (val_1) << 3) + 32;
    }
    public static bool BonusStarsEligable()
    {
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                return false;
        }
        
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID.m_stringLength.GetPhase() != 2)
        {
                return false;
        }
        
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        return System.String.op_Equality(a:  val_2.currentGame.quizCategory, b:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32);
    }
    public int bonusStars(int stars)
    {
        return (int)stars;
    }
    public TRVCrazyCategoriesEventHandler()
    {
        this.multiplier = 2;
    }

}
