using UnityEngine;
public class WGAdsControlPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject main_group;
    private UnityEngine.GameObject sorry_group;
    private UnityEngine.GameObject unavailable_group;
    private UnityEngine.GameObject noAdsGroup;
    protected UGUINetworkedButton purchaseButton;
    private UGUINetworkedButton watchButton;
    private UGUINetworkedButton watchAnotherButton;
    private UnityEngine.UI.Text noAdsButtonTextTop;
    private UnityEngine.UI.Text noAdsButtonPriceText;
    private UnityEngine.UI.Text xMonthNoAds;
    private UnityEngine.UI.Text xHoursNoAds;
    private UnityEngine.UI.Text watchButtonText;
    private UnityEngine.UI.Text watchButtonText2ndLine;
    private UnityEngine.UI.Text noAdsTimer;
    protected GridCoinCollectAnimationInstantiator coinsAnimControl;
    protected GemsCollectAnimationInstantiator gemAnimControl;
    protected CurrencyCollectAnimationInstantiator spinAnimControl;
    private FrameSkipper frameSkipper;
    private HeyZapAdTag initTag;
    protected PurchaseModel noAdsPackage;
    private TrackerPurchasePoints currentEntryPoint;
    public System.Action Action_OnClose;
    
    // Methods
    private void Awake()
    {
        var val_20;
        System.Delegate val_21;
        if((UnityEngine.Object.op_Implicit(exists:  this.coinsAnimControl)) != false)
        {
                this.coinsAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGAdsControlPopup::OnCoinAnimFinished());
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.gemAnimControl)) != false)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void WGAdsControlPopup::OnCoinAnimFinished());
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.spinAnimControl)) != false)
        {
                this.spinAnimControl.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGAdsControlPopup::OnCoinAnimFinished());
        }
        
        val_20 = null;
        val_20 = null;
        System.Delegate val_8 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGAdsControlPopup::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_8;
        System.Delegate val_10 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseCompleted(PurchaseModel obj)));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_10;
        System.Action<PurchaseModel> val_11 = null;
        val_21 = val_11;
        val_11 = new System.Action<PurchaseModel>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseFailure(PurchaseModel obj));
        System.Delegate val_12 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  val_11);
        if(val_12 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_12;
        if((UnityEngine.Object.op_Implicit(exists:  this.watchButton)) != false)
        {
                val_21 = this.watchButton;
            this.watchButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGAdsControlPopup::OnClick_WatchVideo(bool result));
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.watchAnotherButton)) != false)
        {
                val_21 = this.watchAnotherButton;
            this.watchAnotherButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGAdsControlPopup::OnClick_WatchAnotherVideo(bool result));
        }
        
        if(this.frameSkipper == 0)
        {
                this.frameSkipper = this.gameObject.AddComponent<FrameSkipper>();
        }
        
        this.FetchNoAdsPackage();
        return;
        label_20:
    }
    private void OnPurchaseFailure(PurchaseModel obj)
    {
        bool val_1 = obj.id.Contains(value:  "remove");
    }
    private void OnPurchaseCompleted(PurchaseModel obj)
    {
        var val_13;
        var val_14;
        UnityEngine.Object val_15;
        val_14 = this;
        if((obj.id.Contains(value:  "remove")) == false)
        {
                return;
        }
        
        App.Player.RemovedAds = true;
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        val_15 = 0;
        if((MonoSingleton<AdsUIController>.Instance) != val_15)
        {
                val_15 = 0;
            MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
        }
        
        val_14 = ???;
        val_13 = ???;
        goto typeof(WGAdsControlPopup).__il2cppRuntimeField_170;
    }
    private void OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    private void OnEnable()
    {
        if(this.purchaseButton != 0)
        {
                this.purchaseButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGAdsControlPopup::OnClick_NoAds(bool result));
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.ActivateMainGroup();
        this.watchButton.interactable = true;
        this.watchAnotherButton.interactable = true;
        this.UpdateUI();
        System.Delegate val_5 = System.Delegate.Combine(a:  this.frameSkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGAdsControlPopup::FrameSkip_UpdateLogic()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_5;
        this.SetSubscriptionEntryPoint();
        this.SetPopupSeen();
        return;
        label_12:
    }
    public WGAdsControlPopup InitEntryTag(HeyZapAdTag tag)
    {
        this.initTag = tag;
        this.SetPurchaseEntryByInitTag();
        return (WGAdsControlPopup)this;
    }
    public void OnVideoResponse(Notification notif)
    {
        string val_7;
        var val_8;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9;
        var val_10;
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
            goto label_6;
        }
        
        int val_3 = AdsManager.AdsWatched;
        val_3 = val_3 + 1;
        val_7 = 0;
        AdsManager.AdsWatched = val_3;
        if(AdsManager.AdsWatched != 0)
        {
            goto label_9;
        }
        
        val_8 = null;
        val_8 = null;
        if(App.game != 20)
        {
            goto label_15;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
        val_9 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7 = "Type";
        val_5.Add(key:  val_7, value:  "Ads Control Time");
        goto label_17;
        label_6:
        this.ActivateSorryGroup();
        this.watchAnotherButton.interactable = true;
        goto label_19;
        label_15:
        val_9 = 0;
        label_17:
        val_10 = null;
        val_10 = null;
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0}, source:  "Ads Control Time From Ads", externalParams:  val_9, animated:  false);
        label_9:
        this.ActivateMainGroup();
        this.UpdateUI();
        MonoSingleton<AdsUIController>.Instance.AdControlVideoWatched();
        label_19:
        this.watchButton.interactable = true;
    }
    public void DoOnCloseAction()
    {
        if(this.Action_OnClose == null)
        {
                return;
        }
        
        this.Action_OnClose.Invoke();
    }
    protected void FetchNoAdsPackage()
    {
        System.Collections.Generic.IEnumerable<TSource> val_13;
        var val_15;
        System.Func<PurchaseModel, System.Boolean> val_17;
        var val_18;
        val_13 = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePurchasePacks();
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_8;
        }
        
        System.Collections.Generic.List<PurchaseModel> val_5 = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrieveGemPurchasePacks();
        goto label_12;
        label_8:
        GameBehavior val_6 = App.getBehavior;
        if(((val_6.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_17;
        }
        
        label_12:
        val_13 = MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrieveSpinPurchasePacks();
        label_17:
        val_15 = null;
        val_15 = null;
        val_17 = WGAdsControlPopup.<>c.<>9__30_0;
        if(val_17 == null)
        {
                System.Func<PurchaseModel, System.Boolean> val_9 = null;
            val_17 = val_9;
            val_9 = new System.Func<PurchaseModel, System.Boolean>(object:  WGAdsControlPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGAdsControlPopup.<>c::<FetchNoAdsPackage>b__30_0(PurchaseModel x));
            WGAdsControlPopup.<>c.<>9__30_0 = val_17;
        }
        
        PurchaseModel val_10 = System.Linq.Enumerable.FirstOrDefault<PurchaseModel>(source:  val_13, predicate:  val_9);
        this.noAdsPackage = val_10;
        if(val_10 != null)
        {
                return;
        }
        
        UnityEngine.Debug.LogError(message:  "WGAdsControlPopup: No removeads package found matching price. using fallback");
        val_18 = null;
        val_18 = null;
        val_17 = WGAdsControlPopup.<>c.<>9__30_1;
        if(val_17 == null)
        {
                System.Func<PurchaseModel, System.Boolean> val_11 = null;
            val_17 = val_11;
            val_11 = new System.Func<PurchaseModel, System.Boolean>(object:  WGAdsControlPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGAdsControlPopup.<>c::<FetchNoAdsPackage>b__30_1(PurchaseModel x));
            WGAdsControlPopup.<>c.<>9__30_1 = val_17;
        }
        
        this.noAdsPackage = System.Linq.Enumerable.FirstOrDefault<PurchaseModel>(source:  val_13, predicate:  val_11);
    }
    protected void SetPopupSeen()
    {
        if((CPlayerPrefs.GetInt(key:  "noAdsNotifProg", defaultValue:  0)) != 0)
        {
                return;
        }
        
        CPlayerPrefs.SetInt(key:  "noAdsNotifProg", val:  1);
        CPlayerPrefs.Save();
    }
    private void SetPurchaseEntryByInitTag()
    {
        TrackerPurchasePoints val_1;
        if(this.initTag <= 2)
        {
            goto label_0;
        }
        
        if(this.initTag == 3)
        {
            goto label_1;
        }
        
        if(this.initTag == 30)
        {
            goto label_2;
        }
        
        if(this.initTag != 13)
        {
            goto label_6;
        }
        
        val_1 = 16;
        goto label_10;
        label_0:
        if(this.initTag == 1)
        {
            goto label_5;
        }
        
        if(this.initTag != 2)
        {
            goto label_6;
        }
        
        val_1 = 15;
        goto label_10;
        label_1:
        val_1 = 18;
        goto label_10;
        label_2:
        val_1 = 90;
        goto label_10;
        label_5:
        val_1 = 17;
        goto label_10;
        label_6:
        val_1 = 0;
        label_10:
        this.currentEntryPoint = val_1;
    }
    private void UpdateUI()
    {
        object val_42;
        object val_43;
        UnityEngine.UI.Text val_45;
        string val_46;
        string val_47;
        PurchaseModel val_48;
        var val_49;
        val_42 = 1152921504887623680;
        GameEcon val_3 = App.getGameEcon;
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "#_hours_no_ads_upper", defaultValue:  "{0} HOURS NO ADS", useSingularKey:  false), arg0:  AdsManager.CooldownHours.ToString(format:  val_3.numberFormatInt));
        if((UnityEngine.Object.op_Implicit(exists:  this.watchButtonText2ndLine)) == false)
        {
            goto label_9;
        }
        
        GameEcon val_9 = App.getGameEcon;
        val_43 = AdsManager.RequiredVideos.ToString(format:  val_9.numberFormatInt);
        GameEcon val_14 = App.getGameEcon;
        char[] val_17 = new char[1];
        val_17[0] = '
        ';
        System.String[] val_18 = System.String.Format(format:  Localization.Localize(key:  "watch_#_videos_n_#/#_upper", defaultValue:  "WATCH {0} VIDEOS\n{1}/{2}", useSingularKey:  false), arg0:  val_43, arg1:  AdsManager.AdsWatched.ToString(), arg2:  AdsManager.RequiredVideos.ToString(format:  val_14.numberFormatInt)).Split(separator:  val_17);
        if(val_18.Length != 2)
        {
            goto label_20;
        }
        
        string val_42 = val_18[0];
        string val_43 = val_18[1];
        goto label_24;
        label_9:
        val_45 = this.watchButtonText;
        val_46 = "watch_#_videos_n_#/#_upper";
        val_47 = "WATCH {0} VIDEOS\n{1}/{2}";
        goto label_25;
        label_20:
        this.watchButtonText2ndLine.gameObject.SetActive(value:  false);
        val_45 = this.watchButtonText;
        val_46 = "watch_#_videos_n_#/#_upper";
        val_47 = "WATCH {0} VIDEOS\n{1}/{2}";
        label_25:
        val_43 = Localization.Localize(key:  val_46, defaultValue:  val_47, useSingularKey:  false);
        GameEcon val_22 = App.getGameEcon;
        val_42 = AdsManager.AdsWatched.ToString();
        GameEcon val_27 = App.getGameEcon;
        string val_29 = System.String.Format(format:  val_43, arg0:  AdsManager.RequiredVideos.ToString(format:  val_22.numberFormatInt), arg1:  val_42, arg2:  AdsManager.RequiredVideos.ToString(format:  val_27.numberFormatInt));
        label_24:
        if(this.noAdsGroup != 0)
        {
                this.noAdsGroup.SetActive(value:  true);
        }
        
        if(this.noAdsButtonTextTop != 0)
        {
                GameBehavior val_32 = App.getBehavior;
            val_43 = "{0} + {1}";
            if(((val_32.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_48 = this.noAdsPackage;
            val_49 = 0;
            decimal val_33 = val_48.Gems;
        }
        else
        {
                GameBehavior val_34 = App.getBehavior;
            if(((val_34.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_48 = this.noAdsPackage;
            val_49 = 0;
            decimal val_35 = val_48.Spins;
        }
        else
        {
                val_48 = this.noAdsPackage;
            val_49 = 0;
            decimal val_36 = val_48.Credits;
        }
        
        }
        
            string val_38 = System.String.Format(format:  val_43, arg0:  val_36, arg1:  Localization.Localize(key:  "no_ads_upper", defaultValue:  "NO ADS", useSingularKey:  false));
        }
        
        if(this.noAdsButtonPriceText != 0)
        {
                string val_40 = this.noAdsPackage.LocalPrice;
        }
        
        string val_41 = Localization.Localize(key:  "no_ads_forever_upper", defaultValue:  "NO ADS FOREVER!", useSingularKey:  false);
    }
    private void ActivateMainGroup()
    {
        this.main_group.SetActive(value:  true);
        this.sorry_group.SetActive(value:  false);
        this.unavailable_group.SetActive(value:  false);
    }
    private void ActivateSorryGroup()
    {
        this.main_group.SetActive(value:  false);
        this.sorry_group.SetActive(value:  true);
        this.unavailable_group.SetActive(value:  false);
    }
    private void ActivateUnavailableGroup()
    {
        this.main_group.SetActive(value:  false);
        this.sorry_group.SetActive(value:  false);
        this.unavailable_group.SetActive(value:  true);
    }
    protected void SetSubscriptionEntryPoint()
    {
        var val_1;
        if(this.initTag > 2)
        {
            goto label_0;
        }
        
        if(this.initTag == 1)
        {
            goto label_1;
        }
        
        if(this.initTag != 2)
        {
                return;
        }
        
        val_1 = 36;
        goto label_10;
        label_0:
        if(this.initTag == 3)
        {
            goto label_5;
        }
        
        if(this.initTag != 13)
        {
                return;
        }
        
        val_1 = 37;
        goto label_10;
        label_1:
        val_1 = 33;
        goto label_10;
        label_5:
        val_1 = 38;
        label_10:
        WGSubscriptionManager._subEntryPoint = 38;
    }
    private void FrameSkip_UpdateLogic()
    {
        var val_28;
        System.TimeSpan val_29;
        var val_30;
        System.TimeSpan val_31;
        var val_32;
        UnityEngine.UI.Text val_33;
        var val_34;
        object val_35;
        string val_37;
        object val_38;
        string val_39;
        val_28 = null;
        val_28 = null;
        System.DateTime val_1 = AdsManager.LastPurchaseCooldownEnd;
        System.DateTime val_2 = ServerHandler.ServerTime;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        val_29 = val_3._ticks;
        val_30 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_30 = null;
            val_29 = System.TimeSpan.Zero;
        }
        
        System.TimeSpan val_5 = System.TimeSpan.op_Addition(t1:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero}, t2:  new System.TimeSpan() {_ticks = val_29});
        System.DateTime val_6 = AdsManager.AdsCooldownEnd;
        System.DateTime val_7 = ServerHandler.ServerTime;
        System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_6.dateData}, d2:  new System.DateTime() {dateData = val_7.dateData});
        val_31 = val_8._ticks;
        val_32 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_8._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_32 = null;
            val_31 = System.TimeSpan.Zero;
        }
        
        System.TimeSpan val_10 = System.TimeSpan.op_Addition(t1:  new System.TimeSpan() {_ticks = val_5._ticks}, t2:  new System.TimeSpan() {_ticks = val_31});
        System.TimeSpan val_11 = System.TimeSpan.FromDays(value:  1);
        if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_10._ticks}, t2:  new System.TimeSpan() {_ticks = val_11._ticks})) == false)
        {
            goto label_25;
        }
        
        val_33 = this.noAdsTimer;
        val_34 = 1152921504619999232;
        val_35 = val_10._ticks.Days;
        int val_14 = val_10._ticks.Hours;
        val_37 = "{0}d {1}h";
        goto label_30;
        label_25:
        System.TimeSpan val_15 = System.TimeSpan.FromHours(value:  1);
        if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_10._ticks}, t2:  new System.TimeSpan() {_ticks = val_15._ticks})) == false)
        {
            goto label_29;
        }
        
        val_33 = this.noAdsTimer;
        val_34 = 1152921504619999232;
        val_35 = val_10._ticks.Hours;
        int val_18 = val_10._ticks.Minutes;
        val_37 = "{0}h {1}m";
        goto label_30;
        label_29:
        System.TimeSpan val_19 = System.TimeSpan.FromMinutes(value:  1);
        if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_10._ticks}, t2:  new System.TimeSpan() {_ticks = val_19._ticks})) == false)
        {
            goto label_33;
        }
        
        val_33 = this.noAdsTimer;
        int val_21 = val_10._ticks.Minutes;
        val_34 = 1152921504619999232;
        val_35 = val_21;
        val_37 = "{0}m {1}s";
        label_30:
        string val_23 = System.String.Format(format:  val_37, arg0:  val_21, arg1:  val_10._ticks.Seconds);
        return;
        label_33:
        System.TimeSpan val_24 = System.TimeSpan.FromSeconds(value:  1);
        if((System.TimeSpan.op_GreaterThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_10._ticks}, t2:  new System.TimeSpan() {_ticks = val_24._ticks})) != false)
        {
                val_38 = val_10._ticks.Seconds;
            val_39 = "{0}s";
        }
        else
        {
                val_39 = "{0}s";
            val_38 = "0";
        }
        
        string val_27 = System.String.Format(format:  val_39, arg0:  val_38);
        if(this.noAdsTimer != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    protected void OnClick_NoAds(bool result)
    {
        var val_15;
        int val_16;
        var val_17;
        if(this.currentEntryPoint != 0)
        {
                val_15 = null;
            val_15 = null;
            PurchaseProxy.currentPurchasePoint = this.currentEntryPoint;
        }
        
        if(result != false)
        {
                WGStoreController val_1 = MonoSingletonSelfGenerating<WGStoreController>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnStorePurchaseFailed, b:  new System.Action<System.String, System.String>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseNoAdsPackFailed(string title, string message)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
            val_1.OnStorePurchaseFailed = val_3;
            MonoSingletonSelfGenerating<WGStoreController>.Instance.Purchase(purchase:  this.noAdsPackage);
            return;
        }
        
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_16 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_16 = val_10.Length;
        val_10[1] = "NULL";
        System.Func<System.Boolean>[] val_12 = new System.Func<System.Boolean>[2];
        val_12[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGAdsControlPopup::<OnClick_NoAds>b__39_0());
        val_17 = null;
        val_17 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  val_12, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_12:
    }
    protected virtual void OnPurchaseNoAdsPackSuccess()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Player val_2 = App.Player;
            decimal val_3 = System.Decimal.op_Implicit(value:  val_2._gems);
            decimal val_4 = this.noAdsPackage.Gems;
            decimal val_5 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
            Player val_7 = App.Player;
            decimal val_8 = System.Decimal.op_Implicit(value:  val_7._gems);
            this.gemAnimControl.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}), toValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        }
        else
        {
                GameBehavior val_9 = App.getBehavior;
            if(((val_9.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                Player val_10 = App.Player;
            decimal val_11 = this.noAdsPackage.Credits;
            decimal val_12 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
            Player val_13 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, toValue:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        
        }
        
        WGStoreController val_14 = MonoSingletonSelfGenerating<WGStoreController>.Instance;
        System.Delegate val_16 = System.Delegate.Remove(source:  val_14.OnStorePurchaseFailed, value:  new System.Action<System.String, System.String>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseNoAdsPackFailed(string title, string message)));
        if(val_16 != null)
        {
                if(null != null)
        {
            goto label_32;
        }
        
        }
        
        val_14.OnStorePurchaseFailed = val_16;
        return;
        label_32:
    }
    protected void OnPurchaseNoAdsPackFailed(string title, string message)
    {
        int val_12;
        var val_13;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_3 = new bool[2];
        val_3[0] = true;
        string[] val_4 = new string[2];
        val_12 = val_4.Length;
        val_4[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_4.Length;
        val_4[1] = "NO";
        System.Func<System.Boolean>[] val_6 = new System.Func<System.Boolean>[2];
        val_6[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGAdsControlPopup::<OnPurchaseNoAdsPackFailed>b__41_0());
        val_13 = null;
        val_13 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  title, messageTxt:  message, shownButtons:  val_3, buttonTexts:  val_4, showClose:  false, buttonCallbacks:  val_6, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        WGStoreController val_9 = MonoSingletonSelfGenerating<WGStoreController>.Instance;
        System.Delegate val_11 = System.Delegate.Remove(source:  val_9.OnStorePurchaseFailed, value:  new System.Action<System.String, System.String>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseNoAdsPackFailed(string title, string message)));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_25;
        }
        
        }
        
        val_9.OnStorePurchaseFailed = val_11;
        return;
        label_25:
    }
    private void OnCoinAnimFinished()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Store(bool result)
    {
        var val_4;
        TrackerPurchasePoints val_5;
        if(this.initTag > 2)
        {
            goto label_1;
        }
        
        if(this.initTag == 1)
        {
            goto label_2;
        }
        
        if(this.initTag != 2)
        {
            goto label_11;
        }
        
        val_4 = null;
        val_4 = null;
        val_5 = 3;
        goto label_23;
        label_1:
        if(this.initTag == 3)
        {
            goto label_10;
        }
        
        if(this.initTag != 13)
        {
            goto label_11;
        }
        
        val_4 = null;
        val_4 = null;
        val_5 = 16;
        goto label_23;
        label_2:
        val_4 = null;
        val_4 = null;
        val_5 = 10;
        goto label_23;
        label_10:
        val_4 = null;
        val_4 = null;
        val_5 = 7;
        label_23:
        PurchaseProxy.currentPurchasePoint = val_5;
        label_11:
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_WatchAnotherVideo(bool result)
    {
        this.ActivateMainGroup();
        this.OnClick_WatchVideo(result:  false);
    }
    private void OnClick_WatchVideo(bool result)
    {
        int val_20;
        var val_21;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance) != 0)
        {
                if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) == false)
        {
            goto label_9;
        }
        
        }
        
        bool val_6 = MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  this.initTag, adCapExempt:  true);
        return;
        label_9:
        System.Func<System.Boolean>[] val_7 = new System.Func<System.Boolean>[1];
        val_7[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGAdsControlPopup::<OnClick_WatchVideo>b__45_0());
        if((this.GetComponent<WGFlyoutWindow>()) == 0)
        {
                WGFlyoutWindow val_12 = this.gameObject.AddComponent<WGFlyoutWindow>();
        }
        
        GameBehavior val_13 = App.getBehavior;
        bool[] val_17 = new bool[2];
        val_17[0] = true;
        string[] val_18 = new string[2];
        val_20 = val_18.Length;
        val_18[0] = Localization.Localize(key:  "try_again_upper", defaultValue:  "TRY AGAIN", useSingularKey:  false);
        val_20 = val_18.Length;
        val_18[1] = "NULL";
        val_21 = null;
        val_21 = null;
        val_13.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "no_video_upper", defaultValue:  "NO VIDEO AVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "video_unavailable_explanation", defaultValue:  "No Rewarded Video Available.", useSingularKey:  false), shownButtons:  val_17, buttonTexts:  val_18, showClose:  true, buttonCallbacks:  val_7, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnDisable()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, value:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGAdsControlPopup::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseCompleted(PurchaseModel obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_4;
        System.Delegate val_6 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseFailure, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGAdsControlPopup::OnPurchaseFailure(PurchaseModel obj)));
        if(val_6 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_6;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        if((UnityEngine.Object.op_Implicit(exists:  this.GetComponent<WindowTransitionTween>())) == true)
        {
                return;
        }
        
        if(this.Action_OnClose == null)
        {
                return;
        }
        
        this.Action_OnClose.Invoke();
    }
    public WGAdsControlPopup()
    {
    
    }
    private bool <OnClick_NoAds>b__39_0()
    {
        var val_7;
        var val_8;
        var val_9;
        System.Action val_11;
        val_7 = this;
        val_8 = 1152921513412338272;
        mem2[0] = this.initTag;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  true).SetPurchaseEntryByInitTag();
        if(this.initTag != 13)
        {
                if(this.initTag != 2)
        {
                return true;
        }
        
        }
        
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false);
        mem2[0] = this.initTag;
        val_4.SetPurchaseEntryByInitTag();
        val_7 = val_4.GetComponent<WGWindow>();
        val_9 = null;
        val_9 = null;
        val_11 = WGAdsControlPopup.<>c.<>9__39_1;
        if(val_11 == null)
        {
                System.Action val_6 = null;
            val_11 = val_6;
            val_6 = new System.Action(object:  WGAdsControlPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGAdsControlPopup.<>c::<OnClick_NoAds>b__39_1());
            WGAdsControlPopup.<>c.<>9__39_1 = val_11;
        }
        
        mem2[0] = val_11;
        return true;
    }
    private bool <OnPurchaseNoAdsPackFailed>b__41_0()
    {
        GameBehavior val_1 = App.getBehavior;
        mem2[0] = this.initTag;
        val_1.<metaGameBehavior>k__BackingField.SetPurchaseEntryByInitTag();
        return true;
    }
    private bool <OnClick_WatchVideo>b__45_0()
    {
        this.OnClick_WatchVideo(result:  false);
        return true;
    }

}
