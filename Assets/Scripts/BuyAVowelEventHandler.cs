using UnityEngine;
public class BuyAVowelEventHandler : WGEventHandler
{
    // Fields
    public const string BAV_EVENT_ID = "BuyAVowel";
    public const string BAV_EVENT_NAME = "BUY A VOWEL";
    private const string PREF_LEVEL_USED = "bav_used_level";
    private const string PREF_LEVEL_SHOWN = "bav_shown_level";
    private const string PREF_INFO_SHOWN_EVENT_ID = "bav_info_eid";
    private static BuyAVowelEventHandler <Instance>k__BackingField;
    private decimal vowelPrice;
    
    // Properties
    public static BuyAVowelEventHandler Instance { get; set; }
    public decimal GetVowelPrice { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static BuyAVowelEventHandler get_Instance()
    {
        return (BuyAVowelEventHandler)BuyAVowelEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(BuyAVowelEventHandler value)
    {
        BuyAVowelEventHandler.<Instance>k__BackingField = value;
    }
    public decimal get_GetVowelPrice()
    {
        var val_2;
        decimal val_3;
        var val_4;
        var val_5;
        val_2 = this;
        if((CPlayerPrefs.HasKey(key:  "bav_used_level")) != false)
        {
                val_3 = this.vowelPrice;
            val_4 = 1152921516104834728;
            return new System.Decimal() {flags = val_3, hi = val_3, lo = mem[1152921504617021488], mid = mem[1152921504617021488]};
        }
        
        val_2 = 1152921504617017344;
        val_5 = null;
        val_5 = null;
        val_3 = 1152921504617021480;
        val_4 = 1152921504617021488;
        return new System.Decimal() {flags = val_3, hi = val_3, lo = mem[1152921504617021488], mid = mem[1152921504617021488]};
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
        return (string)System.String.Format(format:  "{0:0}d {1:00}h {2:00}m {3:00}s", args:  val_3);
    }
    public void TrackBuyVowelOnLevel(string level)
    {
        CPlayerPrefs.SetString(key:  "bav_used_level", val:  level);
    }
    private void ShowBAVInfoPopup()
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41963520 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<WGBuyAVowelInfoPopup>(showNext:  false);
        }
    
    }
    private void ShowBAVEventPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGBuyAVowelEventPopup>(showNext:  false);
    }
    public override bool get_IsEventValid()
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) != false)
        {
                val_6 = CategoryPacksManager.IsPlaying ^ 1;
            return (bool)val_6 & 1;
        }
        
        val_6 = 0;
        return (bool)val_6 & 1;
    }
    public override void Init(GameEventV2 eventV2)
    {
        var val_6;
        mem[1152921516105665616] = eventV2;
        BuyAVowelEventHandler.<Instance>k__BackingField = this;
        if(eventV2.eventData == null)
        {
                return;
        }
        
        val_6 = 1152921510222861648;
        if((eventV2.eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = eventV2.eventData.Item["economy"];
        if((val_2.ContainsKey(key:  "coins")) == false)
        {
                return;
        }
        
        bool val_5 = System.Decimal.TryParse(s:  val_2.Item["coins"], result: out  new System.Decimal() {flags = this.vowelPrice, hi = this.vowelPrice, lo = this.vowelPrice, mid = this.vowelPrice});
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 98;
        ShowBAVInfoPopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 99;
        ShowBAVEventPopup();
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "buy_vowel_button", defaultValue:  "BUY A\nVOWEL", useSingularKey:  false);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "buy_vowel_upper", defaultValue:  "BUY A VOWEL", useSingularKey:  false);
    }
    public override void OnWordRegionLoaded()
    {
    
    }
    public override void OnValidWordSubmitted(string word)
    {
        int val_6;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        val_6 = 1152921504874684416;
        GameBehavior val_3 = App.getBehavior;
        bool val_4 = CPlayerPrefs.GetInt(key:  "bav_shown_level", defaultValue:  0).Equals(obj:  val_3.<metaGameBehavior>k__BackingField);
        if(val_4 == true)
        {
                return;
        }
        
        val_4.ShowBAVEventPopup();
        GameBehavior val_5 = App.getBehavior;
        val_6 = val_5.<metaGameBehavior>k__BackingField;
        CPlayerPrefs.SetInt(key:  "bav_shown_level", val:  val_6);
    }
    public override void OnGameSceneInit()
    {
        int val_1 = CPlayerPrefs.GetInt(key:  "bav_info_eid", defaultValue:  0);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentBAV val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentBAV>(allowMultiple:  false);
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return false;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4;
        object val_5;
        val_4 = 1152921516106905296;
        if((currentData.ContainsKey(key:  "Current Lvl")) == false)
        {
                return;
        }
        
        object val_3 = currentData.Item["Current Lvl"];
        val_4 = currentData;
        if(((CPlayerPrefs.GetString(key:  "bav_used_level", defaultValue:  "")) & 1) != 0)
        {
                val_5 = null;
        }
        else
        {
                val_5 = null;
        }
        
        val_4.Add(key:  "Buy a Vowel Used", value:  val_5);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return (bool)(layoutType == 0) ? 1 : 0;
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new BuyAVowelEventHandler.<DoLevelCompleteEventProgressAnimation>d__30();
    }
    public BuyAVowelEventHandler()
    {
        decimal val_1 = new System.Decimal(value:  94);
        this.vowelPrice = val_1.flags;
    }

}
