using UnityEngine;
public class GoldenGalaHandler : WGEventHandler
{
    // Fields
    public const string GOLDEN_GALA_EVENT_ID = "GoldenGala";
    private static GoldenGalaHandler _Instance;
    private const string eventEconomy = "economy";
    private const string chapterCoin = "chapter";
    private const string adCoin = "ads";
    private const string dailyChallenge = "dc_s";
    private const string dailyChallengeCoin = "coins";
    private const string dailyChallengeApple = "golden_currency";
    private decimal chapterCoinReward;
    private decimal adCoinReward;
    private System.Collections.Generic.List<System.Decimal> dailyChallengeCoinReward;
    private System.Collections.Generic.List<int> dailyChallengeAppleReward;
    
    // Properties
    public static GoldenGalaHandler Instance { get; }
    public decimal ChapterCoinReward { get; }
    public decimal AdCoinReward { get; }
    public System.Collections.Generic.List<System.Decimal> DailyChallengeCoinReward { get; }
    public System.Collections.Generic.List<int> DailyChallengeAppleReward { get; }
    public bool IsSubscriptionActive { get; }
    public System.TimeSpan GetTimeRemaining { get; }
    public override bool OverrideEventButton { get; }
    
    // Methods
    public static GoldenGalaHandler get_Instance()
    {
        return (GoldenGalaHandler)GoldenGalaHandler.dailyChallengeApple;
    }
    public decimal get_ChapterCoinReward()
    {
        return new System.Decimal() {flags = this.chapterCoinReward, hi = this.chapterCoinReward};
    }
    public decimal get_AdCoinReward()
    {
        return new System.Decimal() {flags = this.adCoinReward, hi = this.adCoinReward};
    }
    public System.Collections.Generic.List<System.Decimal> get_DailyChallengeCoinReward()
    {
        return (System.Collections.Generic.List<System.Decimal>)this.dailyChallengeCoinReward;
    }
    public System.Collections.Generic.List<int> get_DailyChallengeAppleReward()
    {
        return (System.Collections.Generic.List<System.Int32>)this.dailyChallengeAppleReward;
    }
    public bool get_IsSubscriptionActive()
    {
        UnityEngine.Object val_4 = this;
        if((val_4 & 1) != 0)
        {
                return false;
        }
        
        val_4 = MonoSingleton<WGSubscriptionManager>.Instance;
        if(val_4 == 0)
        {
                return false;
        }
        
        return MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0);
    }
    public System.TimeSpan get_GetTimeRemaining()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
    }
    public override bool get_OverrideEventButton()
    {
        return true;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516435206592] = eventV2;
        GoldenGalaHandler.dailyChallengeApple = this;
        this.ParseEventData(eventData:  GoldenGalaHandler.dailyChallengeApple.__il2cppRuntimeField_68);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 68;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGGoldenGalaInfoPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 69;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGGoldenGalaInfoPopup>(showNext:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentGoldenGala>(allowMultiple:  false).Setup(handler:  this);
    }
    public override bool EventCompleted()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "golden_gala_upper", defaultValue:  "GOLDEN GALA", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "golden_gala_upper", defaultValue:  "GOLDEN GALA", useSingularKey:  false);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        val_16 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_17 = 1152921510214912464;
        object val_2 = eventData.Item["economy"];
        val_18 = 1152921504685600768;
        if((val_2.ContainsKey(key:  "chapter")) != false)
        {
                val_19 = val_2.Item["chapter"];
            decimal val_5 = System.Decimal.op_Implicit(value:  19914752);
            mem[1152921516436076064] = val_5.flags;
            mem[1152921516436076068] = val_5.hi;
            mem[1152921516436076072] = val_5.lo;
            mem[1152921516436076076] = val_5.mid;
        }
        
        if((val_2.ContainsKey(key:  "ads")) != false)
        {
                val_19 = val_2.Item["ads"];
            decimal val_8 = System.Decimal.op_Implicit(value:  19914752);
            mem[1152921516436076080] = val_8.flags;
            mem[1152921516436076084] = val_8.hi;
            mem[1152921516436076088] = val_8.lo;
            mem[1152921516436076092] = val_8.mid;
        }
        
        val_16 = "dc_s";
        if((val_2.ContainsKey(key:  "dc_s")) == false)
        {
                return;
        }
        
        object val_10 = val_2.Item["dc_s"];
        if(null < 1)
        {
                return;
        }
        
        do
        {
            if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.ContainsKey(key:  "coins")) != false)
        {
                val_20 = mem[1152921516436076096];
            object val_12 = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["coins"];
            decimal val_13 = System.Decimal.op_Implicit(value:  19914752);
            val_20.set_Item(index:  0, value:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid});
            val_17 = val_17;
            val_18 = val_18;
        }
        
            if((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.ContainsKey(key:  "golden_currency")) != false)
        {
                val_20 = mem[1152921516436076104];
            object val_15 = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.Item["golden_currency"];
            val_20.set_Item(index:  0, value:  19914752);
        }
        
            val_16 = 0 + 1;
        }
        while(val_16 < 1152921516173237664);
    
    }
    public GoldenGalaHandler()
    {
        decimal val_1 = new System.Decimal(value:  25);
        this.chapterCoinReward = val_1.flags;
        decimal val_2 = new System.Decimal(value:  10);
        this.adCoinReward = val_2.flags;
        System.Collections.Generic.List<System.Decimal> val_3 = new System.Collections.Generic.List<System.Decimal>();
        decimal val_4 = new System.Decimal(value:  10);
        val_3.Add(item:  new System.Decimal() {flags = val_4.flags, hi = val_4.flags, lo = val_4.lo, mid = val_4.lo});
        decimal val_5 = new System.Decimal(value:  20);
        val_3.Add(item:  new System.Decimal() {flags = val_5.flags, hi = val_5.flags, lo = val_5.lo, mid = val_5.lo});
        decimal val_6 = new System.Decimal(value:  30);
        val_3.Add(item:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo});
        decimal val_7 = new System.Decimal(value:  50);
        val_3.Add(item:  new System.Decimal() {flags = val_7.flags, hi = val_7.flags, lo = val_7.lo, mid = val_7.lo});
        this.dailyChallengeCoinReward = val_3;
        System.Collections.Generic.List<System.Int32> val_8 = new System.Collections.Generic.List<System.Int32>();
        val_8.Add(item:  5);
        val_8.Add(item:  10);
        val_8.Add(item:  15);
        val_8.Add(item:  20);
        this.dailyChallengeAppleReward = val_8;
    }

}
