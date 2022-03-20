using UnityEngine;
public class TRVSubscriptionPopup : WGSubscriptionPopup
{
    // Fields
    private UnityEngine.UI.Text silverTicketButtonHeader;
    private UnityEngine.UI.Text goldenTicketButtonHeader;
    private UnityEngine.UI.Text silverTicketCostText;
    private UnityEngine.UI.Text goldenTicketCostText;
    private GemsCollectAnimationInstantiator collectGemCollector;
    
    // Methods
    public override void Init()
    {
        var val_15 = null;
        if(App.game == 17)
        {
                mem[1152921517355337732] = 0;
        }
        
        mem[1152921517355337736] = (App.game == 0) ? 1152921517355337360 : 1152921517355337472;
        UnityEngine.GameObject val_2 = gameObject;
        val_2.SetActive(value:  false);
        val_2.SetActive(value:  false);
        val_2.SetActive(value:  false);
        val_2.SetActive(value:  false);
        if((DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  0)) != true)
        {
                bool val_6 = DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  1);
            if(val_6 == false)
        {
            goto typeof(TRVSubscriptionPopup).__il2cppRuntimeField_1A0;
        }
        
        }
        
        bool val_7 = val_6.activeSelf;
        if(val_7 != false)
        {
                val_7.SetActive(value:  false);
        }
        
        if((DefaultHandler<SubscriptionHandler>.Instance.CanCollect(subPackage:  0)) != true)
        {
                if((DefaultHandler<SubscriptionHandler>.Instance.CanCollect(subPackage:  1)) == false)
        {
            goto label_32;
        }
        
        }
        
        var val_15 = ~(DefaultHandler<SubscriptionHandler>.Instance.CanCollect(subPackage:  0));
        val_15 = val_15 & 1;
        mem[1152921517355337732] = val_15;
        this.InitCollectPopup();
        return;
        label_32:
        var val_16 = ~WGSubscriptionManager.HasSubscribedGoldenTicket;
        val_16 = val_16 & 1;
        mem[1152921517355337732] = val_16;
        goto typeof(TRVSubscriptionPopup).__il2cppRuntimeField_1A0;
    }
    public override void InitPromoPopup()
    {
        var val_49;
        UnityEngine.UI.Text val_50;
        string val_51;
        var val_52;
        this.InitPromoPopup();
        val_49 = 1152921504893161472;
        GameEcon val_4 = App.getGameEcon;
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "trv_vip_gems_every_day", defaultValue:  "{ 0} Gems Every Day", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  "{ 0} Gems Every Day").ToString(format:  val_4.numberFormatInt));
        SetActive(value:  false);
        SetActive(value:  false);
        bool val_8 = MonoSingleton<WGSubscriptionManager>.Instance.hasAnySubscription();
        if(val_8 != false)
        {
                UnityEngine.GameObject val_9 = val_8.gameObject;
            val_9.SetActive(value:  false);
            val_9.gameObject.SetActive(value:  false);
            UnityEngine.GameObject val_11 = this.silverTicketButtonHeader.gameObject;
            val_11.SetActive(value:  false);
            val_11.interactable = false;
            val_11.gameObject.SetActive(value:  false);
            string val_13 = Localization.Localize(key:  "trv_vip_active", defaultValue:  "Active", useSingularKey:  false);
            UnityEngine.Color val_14 = UnityEngine.Color.gray;
            this.silverTicketCostText.color = new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a};
        }
        else
        {
                bool val_16 = WGSubscriptionManager.WillGetFreeTrial;
            static_value_02808000.SetActive(value:  val_16);
            static_value_02808000.SetActive(value:  val_16);
            UnityEngine.GameObject val_18 = this.silverTicketCostText.gameObject;
            if(WGSubscriptionManager.WillGetFreeTrial_Silver != false)
        {
                val_18.SetActive(value:  false);
            UnityEngine.GameObject val_19 = this.silverTicketButtonHeader.gameObject;
            val_19.SetActive(value:  true);
            val_19.gameObject.SetActive(value:  false);
            val_49 = 1152921504619999232;
            string val_25 = System.String.Format(format:  "First {0} days FREE, then {1} per week", arg0:  MonoSingleton<WGSubscriptionManager>.Instance.freeTrialDaysCount(subPackage:  1), arg1:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  1));
            string val_30 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup1", defaultValue:  "START YOUR {0} DAY FREE TRIAL", useSingularKey:  false).ToUpper(), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.freeTrialDaysCount(subPackage:  1));
            string val_34 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup2", defaultValue:  "Then {0} per week", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  1));
            string val_38 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup1", defaultValue:  "Start your {0} day free trial", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.freeTrialDaysCount(subPackage:  1));
            val_51 = Localization.Localize(key:  "ticket_promo_popup2", defaultValue:  "Then {0} per week", useSingularKey:  false);
            val_52 = public static WGSubscriptionManager MonoSingleton<WGSubscriptionManager>::get_Instance();
        }
        else
        {
                val_18.SetActive(value:  true);
            UnityEngine.GameObject val_40 = this.silverTicketButtonHeader.gameObject;
            val_40.SetActive(value:  false);
            val_40.gameObject.SetActive(value:  false);
            val_50 = this.silverTicketCostText;
            val_51 = Localization.Localize(key:  "trv_vip_x_per_week", defaultValue:  "{0} / week", useSingularKey:  false);
            val_52 = public static WGSubscriptionManager MonoSingleton<WGSubscriptionManager>::get_Instance();
        }
        
            string val_45 = System.String.Format(format:  val_51, arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  1));
        }
        
        bool val_46 = UnityEngine.Object.op_Inequality(x:  val_50, y:  0);
        if(val_46 != false)
        {
                val_46.gameObject.SetActive(value:  false);
        }
        
        mem2[0] = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVSubscriptionPopup::<InitPromoPopup>b__6_0(bool result));
    }
    protected override void InitStatusPopup()
    {
        mem[1152921517355989412] = 0;
        goto typeof(TRVSubscriptionPopup).__il2cppRuntimeField_180;
    }
    public override void InitInfoPopup()
    {
        var val_10;
        var val_11;
        var val_12;
        string val_13;
        string val_14;
        string val_15;
        if(true == 1)
        {
            goto label_1;
        }
        
        if(true != 0)
        {
            goto label_2;
        }
        
        val_10 = "golden";
        val_11 = "Golden";
        val_12 = "While you have a Golden Ticket, you earn double {0} and collect free gems every day";
        goto label_4;
        label_1:
        val_10 = "silver";
        val_11 = "Silver";
        val_12 = "While you have a Silver Ticket, you\'re awarded a number of free gems every day";
        goto label_4;
        label_2:
        val_15 = "";
        val_14 = val_15;
        val_13 = val_15;
        label_4:
        AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::CloseInfo()));
        string val_4 = Localization.Localize(key:  val_13 + "_ticket_info_1", defaultValue:  val_14 + " Ticket is a weekly, automatically renewing subscription", useSingularKey:  false);
        string val_6 = Localization.Localize(key:  val_13 + "_ticket_info_2", defaultValue:  val_15, useSingularKey:  false);
        GameBehavior val_7 = App.getBehavior;
        string val_8 = System.String.Format(format:  val_6, arg0:  val_7.<metaGameBehavior>k__BackingField);
        string val_9 = Localization.Localize(key:  "golden_ticket_info_4", defaultValue:  "You may cancel anytime through your cell phone account settings, and your benefits continue through the end of your subscription period", useSingularKey:  false);
        val_6.SetActive(value:  true);
        val_6.SetActive(value:  false);
    }
    protected override void CollectAttemptResult(bool result, WGSubscriptionManager.collectResultStatus status)
    {
        WGSubscriptionManager val_1 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.onCollectAttemptResult, value:  new System.Action<System.Boolean, collectResultStatus>(object:  this, method:  typeof(TRVSubscriptionPopup).__il2cppRuntimeField_198));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_1.onCollectAttemptResult = val_3;
        if(result != false)
        {
                System.Delegate val_5 = System.Delegate.Combine(a:  status, b:  new System.Action(object:  this, method:  public System.Void WGSubscriptionPopup::ClosePopup()));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            mem2[0] = val_5;
            Player val_6 = App.Player;
            decimal val_10 = System.Decimal.op_Implicit(value:  val_6._gems - (MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  null)));
            this.collectGemCollector.SetStatViewValue(instantValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}));
            Player val_13 = App.Player;
            decimal val_14 = System.Decimal.op_Implicit(value:  val_13._gems);
            this.collectGemCollector.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}), toValue:  new System.Decimal() {flags = val_14.flags, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
            return;
        }
        
        if(status == 1)
        {
                this.ShowInternetRequired(shouldReturn:  false);
            return;
        }
        
        this.ClosePopup();
        return;
        label_10:
    }
    public TRVSubscriptionPopup()
    {
    
    }
    private void <InitPromoPopup>b__6_0(bool result)
    {
        this.tryClickPurchase(connected:  result, subType:  1);
    }

}
