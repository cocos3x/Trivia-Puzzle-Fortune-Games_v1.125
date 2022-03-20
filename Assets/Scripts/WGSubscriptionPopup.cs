using UnityEngine;
public class WGSubscriptionPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.Texture goldenTicket;
    private UnityEngine.Texture silverTicket;
    protected WGMessagePopup localMessagePopup;
    protected UnityEngine.GameObject goldenTicketPromoObject;
    protected UnityEngine.UI.Text goldenTicketPromoPurchaseCostText;
    protected UnityEngine.UI.Text goldenTicketPromoTrialText1;
    protected UnityEngine.UI.Text goldenTicketPromoTrialText2;
    private UnityEngine.UI.Text goldenTicketSecondaryDescText;
    protected UnityEngine.UI.Text goldenTicketPromoDailyCoins;
    protected UnityEngine.UI.Text goldenTicketPromoAppleMulti;
    private UnityEngine.UI.Text goldenTicketPromoValueText;
    protected UnityEngine.GameObject goldenTicketValueTagObject;
    protected UnityEngine.GameObject goldenTicketTrialDescsObject;
    protected UGUINetworkedButton goldenTicketPromoPurchaseButton;
    private UnityEngine.UI.Button goldenTicketPromoCloseButton;
    private UnityEngine.UI.Button goldenTicketPrivacyPolicy;
    private UnityEngine.UI.Button goldenTicketTermsOfUse;
    protected UnityEngine.GameObject silverTicketPromoObject;
    protected UnityEngine.UI.Text silverTicketPromoPurchaseCostText;
    protected UnityEngine.UI.Text silverTicketPromoTrialText1;
    protected UnityEngine.UI.Text silverTicketPromoTrialText2;
    private UnityEngine.UI.Text silverTicketSecondaryDescText;
    private UnityEngine.UI.Text promoDescText;
    private UnityEngine.UI.Text silverTicketPromoDailyCoins;
    private UnityEngine.UI.Text silverTicketPromoAppleMulti;
    private UnityEngine.UI.Text silverTicketPromoValueText;
    protected UnityEngine.GameObject silverTicketValueTagObject;
    protected UnityEngine.GameObject silverTicketTrialDescsObject;
    protected UGUINetworkedButton silverTicketPromoPurchaseButton;
    private UnityEngine.UI.Button silverTicketPromoCloseButton;
    private UnityEngine.GameObject appleRewardGroup;
    private UnityEngine.RectTransform bonusGrid;
    private UnityEngine.UI.Button silverTicketPrivacyPolicy;
    private UnityEngine.UI.Button silverTicketTermsOfUse;
    protected UnityEngine.GameObject collectObject;
    private UnityEngine.UI.Text coinCollectAmountText;
    private UGUINetworkedButton collectButton;
    private GridCoinCollectAnimationInstantiator collectCoinCollector;
    private UnityEngine.UI.RawImage collectImage;
    protected UnityEngine.GameObject statusObject;
    protected UnityEngine.UI.Text statusText;
    protected UnityEngine.UI.Button statusInfoButton;
    private UnityEngine.UI.Text statusCoinTimer;
    private UnityEngine.UI.RawImage statusImage;
    protected UnityEngine.GameObject infoObject;
    protected UnityEngine.UI.Button infoCloseButton;
    protected UnityEngine.UI.Text[] infoLines;
    private UnityEngine.UI.RawImage infoImage;
    public System.Action onCloseAction;
    public bool forcePromo;
    public SubscriptionHandler.SubScriptionType subPackage;
    protected UnityEngine.GameObject promoObject;
    
    // Methods
    private void Start()
    {
        goto typeof(WGSubscriptionPopup).__il2cppRuntimeField_170;
    }
    public virtual void Init()
    {
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        val_15 = this;
        val_16 = null;
        val_16 = null;
        if(App.game == 17)
        {
                this.subPackage = 0;
        }
        
        this.promoObject = (this.subPackage == 0) ? this.goldenTicketPromoObject : this.silverTicketPromoObject;
        this.localMessagePopup.gameObject.SetActive(value:  false);
        this.promoObject.SetActive(value:  false);
        this.collectObject.SetActive(value:  false);
        this.statusObject.SetActive(value:  false);
        var val_3 = (this.subPackage == 0) ? 24 : 32;
        this.infoImage.texture = 1152921504923832320;
        this.statusImage.texture = 1152921504923832320;
        this.collectImage.texture = 1152921504923832320;
        val_17 = 1152921504889913344;
        val_18 = 1152921515561714672;
        if((DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  this.subPackage)) != false)
        {
                if(this.forcePromo == false)
        {
            goto label_21;
        }
        
        }
        
        label_29:
        val_17 = ???;
        val_15 = ???;
        val_18 = ???;
        goto typeof(WGSubscriptionPopup).__il2cppRuntimeField_180;
        label_21:
        if((val_15 + 424.activeSelf) != false)
        {
                val_15 + 424.SetActive(value:  false);
        }
        
        if((DefaultHandler<WGBonusRewardsHandler>.Instance.CanCollect(subPackage:  val_15 + 420)) == false)
        {
            goto label_29;
        }
        
        val_15.InitCollectPopup();
    }
    public virtual void InitPromoPopup()
    {
        var val_69;
        UnityEngine.Object val_70;
        var val_71;
        UnityEngine.UI.Text val_72;
        this.goldenTicketPromoPurchaseButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::tryClickPurchase(bool connected));
        this.silverTicketPromoPurchaseButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::tryClickPurchase(bool connected));
        this.goldenTicketPrivacyPolicy.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::ClickPrivacyPolicy()));
        this.goldenTicketTermsOfUse.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::ClickTermsOfUse()));
        val_69 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.silverTicketPrivacyPolicy)) != false)
        {
                this.silverTicketPrivacyPolicy.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::ClickPrivacyPolicy()));
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.silverTicketTermsOfUse)) != false)
        {
                this.silverTicketTermsOfUse.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::ClickTermsOfUse()));
        }
        
        this.promoObject.gameObject.SetActive(value:  true);
        this.goldenTicketPromoCloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGSubscriptionPopup::ClosePopup()));
        val_70 = this.silverTicketPromoCloseButton;
        if((UnityEngine.Object.op_Implicit(exists:  val_70)) != false)
        {
                val_70 = this.silverTicketPromoCloseButton.m_OnClick;
            val_70.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WGSubscriptionPopup::ClosePopup()));
        }
        
        if(this.subPackage == 1)
        {
            goto label_26;
        }
        
        if(this.subPackage != 0)
        {
            goto label_27;
        }
        
        string val_16 = System.String.Format(format:  "{0} / {1}", arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  this.subPackage), arg1:  Localization.Localize(key:  "week_upper", defaultValue:  "WEEK", useSingularKey:  false));
        GameEcon val_20 = App.getGameEcon;
        string val_22 = System.String.Format(format:  Localization.Localize(key:  "x_coins_every_day", defaultValue:  "{0} Coins Every Day", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_20.numberFormatInt));
        string val_26 = System.String.Format(format:  Localization.Localize(key:  "x_percent_more_golden_apples", defaultValue:  "{0}% More Golden Apples", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.pointXMoreMultiplier);
        this.goldenTicketPromoCloseButton.interactable = true;
        val_70 = this.goldenTicketPromoPurchaseButton;
        if(val_70 != null)
        {
            goto label_41;
        }
        
        label_26:
        UnityEngine.Debug.LogError(message:  "setting silver ticket stuff?");
        this.appleRewardGroup.SetActive(value:  false);
        val_69 = 1152921515650474912;
        GameEcon val_30 = App.getGameEcon;
        string val_34 = System.String.Format(format:  Localization.Localize(key:  "silver_ticket_promo_popup_text", defaultValue:  "With the Silver Ticket, get {0} free coins every day and remove Ads from the game. Automatically renews each week for {1}", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_30.numberFormatInt), arg1:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  this.subPackage));
        string val_38 = System.String.Format(format:  "{0} / {1}", arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  this.subPackage), arg1:  Localization.Localize(key:  "week_upper", defaultValue:  "WEEK", useSingularKey:  false));
        GameEcon val_42 = App.getGameEcon;
        string val_44 = System.String.Format(format:  Localization.Localize(key:  "golden_ticket_benefits_1", defaultValue:  "{0} Daily Coins", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_42.numberFormatInt));
        string val_48 = System.String.Format(format:  Localization.Localize(key:  "x_all_upper", defaultValue:  "{0}X ALL", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.pointMultiplier);
        this.silverTicketPromoCloseButton.interactable = true;
        val_70 = this.silverTicketPromoPurchaseButton;
        label_41:
        val_70.interactable = true;
        label_27:
        bool val_49 = WGSubscriptionManager.WillGetFreeTrial;
        bool val_50 = val_49;
        this.goldenTicketTrialDescsObject.SetActive(value:  val_50);
        this.silverTicketTrialDescsObject.SetActive(value:  val_50);
        if(val_49 == false)
        {
            goto label_68;
        }
        
        if(this.subPackage == 1)
        {
            goto label_67;
        }
        
        if(this.subPackage != 0)
        {
            goto label_68;
        }
        
        this.goldenTicketValueTagObject.SetActive(value:  false);
        this.goldenTicketTrialDescsObject.SetActive(value:  true);
        string val_51 = Localization.Localize(key:  "free_trial_upper", defaultValue:  "SUBSCRIBE NOW", useSingularKey:  false);
        val_71 = 1152921515650474912;
        string val_56 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup1", defaultValue:  "START YOUR {0} DAY FREE TRIAL", useSingularKey:  false).ToUpper(), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.freeTrialDaysCount(subPackage:  this.subPackage));
        val_72 = this.goldenTicketPromoTrialText2;
        goto label_77;
        label_67:
        this.silverTicketValueTagObject.SetActive(value:  false);
        this.silverTicketTrialDescsObject.SetActive(value:  true);
        string val_57 = Localization.Localize(key:  "free_trial_upper", defaultValue:  "SUBSCRIBE NOW", useSingularKey:  false);
        val_71 = 1152921515650474912;
        string val_61 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup1", defaultValue:  "Start your {0} day free trial", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.freeTrialDaysCount(subPackage:  this.subPackage));
        val_72 = this.silverTicketPromoTrialText2;
        label_77:
        string val_65 = System.String.Format(format:  Localization.Localize(key:  "ticket_promo_popup2", defaultValue:  "Then {0} per week", useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.GetPromoCostForPackage(subPack:  this.subPackage));
        label_68:
        string val_68 = System.String.Format(format:  Localization.Localize(key:  "golden_ticket_subscribe_info", defaultValue:  "You may cancel anytime through your cell phone account settings, at least 24 hours before the end of your current period, and your benefits continue through the end of your subscription period. Payments will be charged to your {0} account", useSingularKey:  false), arg0:  Localization.Localize(key:  "googlePlayStore", defaultValue:  "Google Play", useSingularKey:  false));
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot:  this.bonusGrid);
        this.forcePromo = false;
    }
    protected void tryClickPurchase(bool connected, SubscriptionHandler.SubScriptionType subType)
    {
        if(connected != false)
        {
                this.goldenTicketPromoPurchaseButton.interactable = false;
            this.silverTicketPromoPurchaseButton.interactable = false;
            this.promoObject.SetActive(value:  false);
            WGSubscriptionManager val_1 = MonoSingleton<WGSubscriptionManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.purchaseResult, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::OnPurchaseAttemptResult(bool result)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            val_1.purchaseResult = val_3;
            MonoSingleton<WGSubscriptionManager>.Instance.TryPurchase(subPackage:  subType);
            return;
        }
        
        this.ShowInternetRequired(shouldReturn:  true);
        return;
        label_9:
    }
    private void tryClickPurchase(bool connected)
    {
        if(connected != false)
        {
                this.goldenTicketPromoPurchaseButton.interactable = false;
            this.silverTicketPromoPurchaseButton.interactable = false;
            this.promoObject.SetActive(value:  false);
            WGSubscriptionManager val_1 = MonoSingleton<WGSubscriptionManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.purchaseResult, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::OnPurchaseAttemptResult(bool result)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            val_1.purchaseResult = val_3;
            MonoSingleton<WGSubscriptionManager>.Instance.TryPurchase(subPackage:  this.subPackage);
            return;
        }
        
        this.ShowInternetRequired(shouldReturn:  true);
        return;
        label_9:
    }
    private void OnPurchaseAttemptResult(bool result)
    {
        object val_17;
        var val_18;
        System.Delegate val_19;
        val_17 = this;
        val_18 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Action<System.Boolean> val_2 = null;
        val_19 = val_2;
        val_2 = new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::OnPurchaseAttemptResult(bool result));
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.purchaseResult, value:  val_2);
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.purchaseResult = val_3;
        if(result == false)
        {
            goto label_6;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  DefaultHandler<ServerHandler>.Instance)) == false)
        {
                return;
        }
        
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        this.promoObject.SetActive(value:  false);
        val_17 = ???;
        val_18 = ???;
        val_19 = ???;
        goto typeof(WGSubscriptionPopup).__il2cppRuntimeField_170;
        label_6:
        val_17 + 136.interactable = true;
        val_17 + 256.interactable = true;
        val_17 + 128.interactable = true;
        val_17 + 248.interactable = true;
        val_17.ShowPurchaseFailed(title:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), message:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false));
        return;
        label_5:
    }
    protected void InitCollectPopup()
    {
        GameEcon val_3 = App.getGameEcon;
        string val_4 = MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_3.numberFormatInt);
        System.Delegate val_6 = System.Delegate.Combine(a:  this.collectButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::DoCollect(bool connected)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        this.collectButton.OnConnectionClick = val_6;
        this.collectObject.SetActive(value:  true);
        return;
        label_10:
    }
    private void DoCollect(bool connected)
    {
        if(connected == false)
        {
            goto typeof(WGSubscriptionPopup).__il2cppRuntimeField_190;
        }
        
        WGSubscriptionManager val_1 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.onCollectAttemptResult, b:  new System.Action<System.Boolean, collectResultStatus>(object:  this, method:  typeof(WGSubscriptionPopup).__il2cppRuntimeField_198));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
        val_1.onCollectAttemptResult = val_3;
        MonoSingleton<WGSubscriptionManager>.Instance.UITryCollect(subPackage:  this.subPackage);
        this.collectButton.interactable = false;
        return;
        label_7:
    }
    protected virtual void CollectAttemptResult(bool result, WGSubscriptionManager.collectResultStatus status)
    {
        WGSubscriptionManager val_1 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.onCollectAttemptResult, value:  new System.Action<System.Boolean, collectResultStatus>(object:  this, method:  typeof(WGSubscriptionPopup).__il2cppRuntimeField_198));
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
                System.Delegate val_5 = System.Delegate.Combine(a:  this.collectCoinCollector.OnCompleteCallback, b:  new System.Action(object:  this, method:  public System.Void WGSubscriptionPopup::ClosePopup()));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            this.collectCoinCollector.OnCompleteCallback = val_5;
            Player val_6 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage));
            decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = this.collectCoinCollector.OnCompleteCallback, mid = this.collectCoinCollector.OnCompleteCallback}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            this.collectCoinCollector.Set(instantValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid});
            Player val_11 = App.Player;
            this.collectCoinCollector.Play(fromValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, toValue:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
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
    protected virtual void InitStatusPopup()
    {
        var val_12;
        var val_13;
        string val_14;
        string val_15;
        if(this.subPackage == 1)
        {
            goto label_1;
        }
        
        if(this.subPackage != 0)
        {
            goto label_2;
        }
        
        val_12 = "Your next {0} free daily coins are coming soon! Don\'t forget you are earning double {1}";
        val_13 = "golden_ticket_status_popup_text";
        goto label_4;
        label_1:
        val_12 = "Your next {0} free daily coins are coming soon!";
        val_13 = "silver_ticket_status_popup_text";
        goto label_4;
        label_2:
        val_15 = "";
        val_14 = val_15;
        label_4:
        GameEcon val_4 = App.getGameEcon;
        GameBehavior val_6 = App.getBehavior;
        string val_7 = System.String.Format(format:  Localization.Localize(key:  val_15, defaultValue:  val_14, useSingularKey:  false), arg0:  MonoSingleton<WGSubscriptionManager>.Instance.promoDailyCoinsAmount(subPackage:  this.subPackage).ToString(format:  val_4.numberFormatInt), arg1:  val_6.<metaGameBehavior>k__BackingField);
        this.statusInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGSubscriptionPopup).__il2cppRuntimeField_1B8));
        UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.updateStatusTime());
        this.statusObject.SetActive(value:  true);
        if(this.promoObject.activeSelf == false)
        {
                return;
        }
        
        this.promoObject.SetActive(value:  false);
    }
    protected System.Collections.IEnumerator updateStatusTime()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGSubscriptionPopup.<updateStatusTime>d__62();
    }
    public virtual void InitInfoPopup()
    {
        var val_11;
        var val_12;
        var val_13;
        string val_14;
        string val_15;
        string val_16;
        if(this.subPackage == 1)
        {
            goto label_1;
        }
        
        if(this.subPackage != 0)
        {
            goto label_2;
        }
        
        val_11 = "golden";
        val_12 = "Golden";
        val_13 = "While you have a Golden Ticket, you earn double {0} and collect free coins every day";
        goto label_4;
        label_1:
        val_11 = "silver";
        val_12 = "Silver";
        val_13 = "While you have a Silver Ticket, you\'re awarded a number of free coins every day";
        goto label_4;
        label_2:
        val_16 = "";
        val_15 = val_16;
        val_14 = val_16;
        label_4:
        this.infoCloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGSubscriptionPopup::CloseInfo()));
        UnityEngine.UI.Text val_11 = this.infoLines[0];
        string val_4 = Localization.Localize(key:  val_14 + "_ticket_info_1", defaultValue:  val_15 + " Ticket is a weekly, automatically renewing subscription", useSingularKey:  false);
        UnityEngine.UI.Text val_12 = this.infoLines[1];
        GameBehavior val_7 = App.getBehavior;
        string val_8 = System.String.Format(format:  Localization.Localize(key:  val_14 + "_ticket_info_2", defaultValue:  val_16, useSingularKey:  false), arg0:  val_7.<metaGameBehavior>k__BackingField);
        UnityEngine.UI.Text val_13 = this.infoLines[2];
        string val_9 = Localization.Localize(key:  "golden_ticket_info_3", defaultValue:  "If you miss a day of free coins, unfortunately they go away", useSingularKey:  false);
        UnityEngine.UI.Text val_14 = this.infoLines[3];
        string val_10 = Localization.Localize(key:  "golden_ticket_info_4", defaultValue:  "You may cancel anytime through your cell phone account settings, and your benefits continue through the end of your subscription period", useSingularKey:  false);
        this.infoObject.SetActive(value:  true);
        this.statusObject.SetActive(value:  false);
    }
    protected void CloseInfo()
    {
        this.statusObject.SetActive(value:  true);
        this.infoObject.SetActive(value:  false);
        this.infoCloseButton.m_OnClick.RemoveAllListeners();
    }
    public void ClosePopup()
    {
        if(this.onCloseAction != null)
        {
                this.onCloseAction.Invoke();
        }
        
        this.onCloseAction = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected void ShowInternetRequired(bool shouldReturn = True)
    {
        int val_11;
        var val_12;
        .shouldReturn = shouldReturn;
        .<>4__this = this;
        this.promoObject.SetActive(value:  false);
        this.statusObject.SetActive(value:  false);
        this.collectObject.SetActive(value:  false);
        this.infoObject.SetActive(value:  false);
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_11 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_11 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_8[0] = new System.Func<System.Boolean>(object:  new WGSubscriptionPopup.<>c__DisplayClass66_0(), method:  System.Boolean WGSubscriptionPopup.<>c__DisplayClass66_0::<ShowInternetRequired>b__0());
        val_12 = null;
        val_12 = null;
        this.localMessagePopup.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        this.localMessagePopup.gameObject.SetActive(value:  true);
    }
    public void ShowPurchaseFailed(string title, string message)
    {
        int val_13;
        var val_14;
        if((UnityEngine.Object.op_Implicit(exists:  this.promoObject)) != false)
        {
                this.promoObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.statusObject)) != false)
        {
                this.statusObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.collectObject)) != false)
        {
                this.collectObject.SetActive(value:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.infoObject)) != false)
        {
                this.infoObject.SetActive(value:  false);
        }
        
        if(this.localMessagePopup != 0)
        {
                bool[] val_6 = new bool[2];
            val_6[0] = true;
            string[] val_7 = new string[2];
            val_13 = val_7.Length;
            val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_13 = val_7.Length;
            val_7[1] = "NO";
            System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
            val_9[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGSubscriptionPopup::<ShowPurchaseFailed>b__67_0());
            val_14 = null;
            val_14 = null;
            this.localMessagePopup.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.localMessagePopup)) == false)
        {
                return;
        }
        
        this.localMessagePopup.gameObject.SetActive(value:  true);
    }
    private void ClickPrivacyPolicy()
    {
        AppConfigs val_1 = App.Configuration;
        twelvegigs.plugins.SharePlugin.OpenURL(url:  val_1.gameConfig.privacyPolicyUrl);
    }
    private void ClickTermsOfUse()
    {
        AppConfigs val_1 = App.Configuration;
        twelvegigs.plugins.SharePlugin.OpenURL(url:  val_1.gameConfig.termsOfServiceURL);
    }
    private void OnDestroy()
    {
        System.Action<System.Boolean> val_9;
        var val_10;
        val_9 = 1152921504893161472;
        val_10 = 1152921515650474912;
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return;
        }
        
        WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
        System.Delegate val_5 = System.Delegate.Remove(source:  val_3.onCollectAttemptResult, value:  new System.Action<System.Boolean, collectResultStatus>(object:  this, method:  typeof(WGSubscriptionPopup).__il2cppRuntimeField_198));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_3.onCollectAttemptResult = val_5;
        WGSubscriptionManager val_6 = MonoSingleton<WGSubscriptionManager>.Instance;
        val_9 = val_6.purchaseResult;
        val_10 = 1152921504614248448;
        System.Delegate val_8 = System.Delegate.Remove(source:  val_9, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionPopup::OnPurchaseAttemptResult(bool result)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_6.purchaseResult = val_8;
        return;
        label_14:
    }
    public WGSubscriptionPopup()
    {
    
    }
    private bool <ShowPurchaseFailed>b__67_0()
    {
        return true;
    }

}
