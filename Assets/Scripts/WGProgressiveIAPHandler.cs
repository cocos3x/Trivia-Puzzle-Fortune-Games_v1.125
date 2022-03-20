using UnityEngine;
public class WGProgressiveIAPHandler : TRVProgressiveIAPHandler
{
    // Fields
    private const string pref_highest_purchse = "php";
    private const string pref_sale_surfaced = "wgpiap_pss";
    private float playerHighestPurchase;
    private int daysToShowSale;
    private int daysUntilSaleResurface;
    private System.DateTime saleStartTime;
    
    // Properties
    private System.DateTime SaleStartTime { get; set; }
    
    // Methods
    private System.DateTime get_SaleStartTime()
    {
        var val_5;
        var val_6;
        val_5 = null;
        val_5 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.saleStartTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return (System.DateTime)this.saleStartTime;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wgpiap_pss")) == false)
        {
                return (System.DateTime)this.saleStartTime;
        }
        
        val_6 = null;
        val_6 = null;
        System.DateTime val_4 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "wgpiap_pss", defaultValue:  ""), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        this.saleStartTime = val_4;
        return (System.DateTime)this.saleStartTime;
    }
    private void set_SaleStartTime(System.DateTime value)
    {
        this.saleStartTime = value;
        UnityEngine.PlayerPrefs.SetString(key:  "wgpiap_pss", value:  SLCDateTime.SerializeInvariant(dateTime:  new System.DateTime() {dateData = value.dateData}));
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    protected override void GenerateExtraNewData(ref System.Collections.Generic.Dictionary<string, object> eventDataToSave)
    {
        this.GenerateExtraNewData(eventDataToSave: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = eventDataToSave);
        Player val_2 = App.Player;
        this.playerHighestPurchase = val_2.lastPurchasePrice;
        Player val_3 = App.Player;
        val_1.Add(key:  "php", value:  val_3.lastPurchasePrice);
    }
    protected override void LoadExtraPersistentData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        this.LoadExtraPersistentData(eventData:  eventData);
        if((eventData.ContainsKey(key:  "php")) == false)
        {
                return;
        }
        
        bool val_4 = System.Single.TryParse(s:  eventData.Item["php"], result: out  this.playerHighestPurchase);
    }
    protected override void SaveExtraData(ref System.Collections.Generic.Dictionary<string, object> myEventData)
    {
        this.SaveExtraData(myEventData: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = myEventData);
        if((this.GetCurrentTier(calculatedProgress:  -304748400)) > 0)
        {
                return;
        }
        
        Player val_3 = App.Player;
        this.playerHighestPurchase = val_3.lastPurchasePrice;
        1152921517187000464 = val_1;
        Player val_4 = App.Player;
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  1152921517187000464, key:  "php", newValue:  val_4.lastPurchasePrice);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        var val_5;
        DG.Tweening.TweenCallback val_7;
        bool val_5 = true;
        val_5 = val_5 + levelsProgressed;
        mem[1152921517187110136] = val_5;
        this.SaveData();
        PurchaseModel val_1 = this.GetCurrentPurchaseModel(tierOverride:  0);
        if((this & 1) != 0)
        {
                return;
        }
        
        if(levelsProgressed > (System.Linq.Enumerable.Sum(source:  this)))
        {
                return;
        }
        
        if(null == null)
        {
                return;
        }
        
        val_5 = null;
        val_5 = null;
        val_7 = WGProgressiveIAPHandler.<>c.<>9__12_0;
        if(val_7 == null)
        {
                DG.Tweening.TweenCallback val_3 = null;
            val_7 = val_3;
            val_3 = new DG.Tweening.TweenCallback(object:  WGProgressiveIAPHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGProgressiveIAPHandler.<>c::<OnLevelComplete>b__12_0());
            WGProgressiveIAPHandler.<>c.<>9__12_0 = val_7;
        }
        
        DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.6f, callback:  val_3, ignoreTimeScale:  true);
    }
    public override bool EventCompleted()
    {
        var val_5;
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = this.SaleStartTime;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        if(new System.DateTime() != 0)
        {
                if(val_3._ticks.TotalDays < 0)
        {
            goto label_6;
        }
        
        }
        
        val_5 = 0;
        return (bool)val_5;
        label_6:
        val_5 = 1;
        return (bool)val_5;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "play_more_get_more_upper", defaultValue:  "PLAY MORE GET MORE", useSingularKey:  false);
    }
    public override string EventContentItemButtonText()
    {
        return Localization.Localize(key:  "play_more_get_more_upper", defaultValue:  "PLAY MORE GET MORE", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "play_more_get_more_upper", defaultValue:  "PLAY MORE GET MORE", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "sale_upper", defaultValue:  "SALE", useSingularKey:  false);
    }
    public override void ShowSalePopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVProgressiveIAPPopup MetaGameBehavior::ShowUGUIMonolith<TRVProgressiveIAPPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void HackAddLevels(int levelsHacked)
    {
        mem[1152921517187923224] = W8 + levelsHacked;
    }
    protected override int GetCurrentTierIAPIndex(int tier)
    {
        var val_2 = (this.playerHighestPurchase > 5.99f) ? ((this.playerHighestPurchase < 0) ? 6 : 9) : 3;
        val_2 = tier + val_2;
        return (int)val_2 - 3;
    }
    protected override bool ParseExtraDataKnobs(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_7;
        if((eventData.ContainsKey(key:  "t")) == false)
        {
                return true;
        }
        
        val_7 = "d";
        if((eventData.ContainsKey(key:  "d")) == false)
        {
                return true;
        }
        
        this.daysToShowSale = System.Int32.Parse(s:  eventData.Item["t"]);
        this.daysUntilSaleResurface = System.Int32.Parse(s:  eventData.Item["d"]);
        return true;
    }
    private int GetOfferGroupIndex(float highestPurchasePrice)
    {
        if(highestPurchasePrice <= 5.99f)
        {
                return 1;
        }
        
        return (int)(highestPurchasePrice < 0) ? 2 : 3;
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_3;
        if(layoutType == 1)
        {
                val_3 = 0;
        }
        else
        {
                bool val_1 = this.IsEventHidden;
            val_3 = val_1 ^ 1;
        }
        
        val_1 = val_3;
        return (bool)val_1;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_10;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        val_10 = null;
        if(41963520 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
        }
        else
        {
                GameBehavior val_4 = App.getBehavior;
        }
    
    }
    public WGProgressiveIAPHandler()
    {
        var val_1;
        this.daysToShowSale = 3;
        this.daysUntilSaleResurface = 10;
        val_1 = null;
        val_1 = null;
        this.saleStartTime = System.DateTime.MinValue;
    }

}
