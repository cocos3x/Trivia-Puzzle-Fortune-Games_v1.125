using UnityEngine;
public class WGFreeHintPopup : MonoBehaviour
{
    // Fields
    protected UnityEngine.GameObject group_start;
    protected UnityEngine.UI.Text desc_text;
    private UnityEngine.GameObject pet_icon;
    protected UnityEngine.UI.Text freeCoinButtonText;
    protected UGUINetworkedButton Button_FreeHint;
    private UnityEngine.UI.Button Button_Close_FreeHint;
    protected UnityEngine.GameObject group_sorry;
    protected UnityEngine.UI.Text sorry_message;
    protected UnityEngine.UI.Text sorry_button_text;
    protected UnityEngine.UI.Text sorry_banner_text;
    private UGUINetworkedButton Button_WatchAnother;
    private UnityEngine.UI.Button Button_Close_Sorry;
    protected UnityEngine.GameObject group_success;
    protected UnityEngine.UI.Button Button_CollectHint;
    private bool hideTextWhileCollecting;
    protected UnityEngine.UI.Text message_thankYou;
    protected GridCoinCollectAnimationInstantiator coinsAnim;
    private UnityEngine.Transform coinSource;
    private UnityEngine.Transform midCoinTransform;
    private UnityEngine.Transform leftCoinTransform;
    private UnityEngine.Transform rightCoinTransform;
    protected UnityEngine.UI.Text coin_amount;
    private UnityEngine.UI.Text gala_regular_coin_amount;
    private UnityEngine.UI.Text gala_bonus_coin_amount;
    private UnityEngine.GameObject regularRewardGroup;
    private UnityEngine.GameObject galaRewardGroup;
    private UnityEngine.GameObject galaRewardOverlay;
    private UnityEngine.UI.Button Button_GalaReward;
    protected UnityEngine.LineRenderer strikeoutLine;
    protected CurrencyRewardType curRewType;
    public System.Action OnClose;
    protected decimal reward;
    private decimal petsReward;
    protected HeyZapAdTag initTag;
    protected HeyZapAdTag currTag;
    protected string initFreeCointEvent;
    protected string currFreeCoinEvent;
    private int _isMinigameWindow;
    public static bool dailyCollected;
    private FrameSkipper frameSkipper;
    protected WGFreeHintPopup.WGFreeHintPopupStates state;
    
    // Properties
    private bool isMinigameWindow { get; }
    
    // Methods
    private bool get_isMinigameWindow()
    {
        int val_5 = this._isMinigameWindow;
        if(val_5 != 1)
        {
                return (bool)(val_5 == true) ? 1 : 0;
        }
        
        val_5 = UnityEngine.Object.op_Implicit(exists:  this.GetComponent<SLC.Minigames.MinigamesWindow>());
        this._isMinigameWindow = val_5;
        return (bool)(val_5 == true) ? 1 : 0;
    }
    private void Awake()
    {
        this.Button_Close_FreeHint.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFreeHintPopup::<Awake>b__42_0()));
        this.Button_WatchAnother.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result));
        this.Button_Close_Sorry.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGFreeHintPopup).__il2cppRuntimeField_1C8));
        this.Button_CollectHint.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGFreeHintPopup).__il2cppRuntimeField_1B8));
        if(this.Button_GalaReward != 0)
        {
                this.Button_GalaReward.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFreeHintPopup::OnGalaRewardButtonClicked()));
        }
        
        this.frameSkipper = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_8._framesToSkip = 60;
        this.frameSkipper.updateLogic = new System.Action(object:  this, method:  typeof(WGFreeHintPopup).__il2cppRuntimeField_178);
    }
    protected virtual void UpdateLogic()
    {
        object val_22;
        var val_23;
        if(this.state == 1)
        {
                val_22 = 1152921504893161472;
            if((MonoSingleton<ApplovinMaxPlugin>.Instance) != 0)
        {
                bool val_4 = MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable();
        }
        
        }
        
        if(this.freeCoinButtonText == null)
        {
                return;
        }
        
        val_22 = 1152921513404906384;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) != false)
        {
                System.DateTime val_8 = MonoSingletonSelfGenerating<AdsManager>.Instance.offsetServerTime;
            val_22 = System.String.Format(format:  "{0}:{1}:{2}", arg0:  23 - val_8.dateData.Hour.ToString(format:  "00"), arg1:  60 - val_8.dateData.Minute.ToString(format:  "00"), arg2:  60 - val_8.dateData.Second.ToString(format:  "00"));
            string val_20 = System.String.Format(format:  "{1} {0}", arg0:  val_22, arg1:  Localization.Localize(key:  "next_ad_available_in", defaultValue:  "Next Ad Available in", useSingularKey:  false));
            val_23 = 0;
        }
        else
        {
                string val_21 = Localization.Localize(key:  "get_free_coins_upper", defaultValue:  "GET FREE COINS", useSingularKey:  false);
            val_23 = 1;
        }
        
        this.Button_FreeHint.interactable = true;
    }
    private void OnEnable()
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) != 0)
        {
                WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
            1152921504893161472 = val_3.purchaseResult;
            System.Delegate val_5 = System.Delegate.Combine(a:  1152921504893161472, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGFreeHintPopup::OnSubscriptionPurchaseAttempt(bool success)));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            val_3.purchaseResult = val_5;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        return;
        label_10:
    }
    private void Start()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.transform.GetComponent<WGLevelClearPopup>())) == false)
        {
            goto typeof(WGFreeHintPopup).__il2cppRuntimeField_190;
        }
    
    }
    public virtual void InitWithTag(HeyZapAdTag tag, string eventName, CurrencyRewardType rt = 0)
    {
        this.initTag = tag;
        this.initFreeCointEvent = eventName;
        this.curRewType = rt;
    }
    public void UpdateGoldenGalaOverlay()
    {
        this.galaRewardOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
    }
    protected virtual void SetUp()
    {
        object val_58;
        HeyZapAdTag val_59;
        int val_60;
        decimal val_61;
        var val_62;
        decimal val_63;
        int val_64;
        int val_65;
        var val_66;
        var val_67;
        var val_68;
        string val_69;
        var val_70;
        var val_71;
        val_58 = this;
        object[] val_1 = new object[2];
        val_59 = this.initTag;
        mem2[0] = val_59;
        val_60 = val_1.Length;
        val_1[0] = val_59.ToString();
        if(this.initFreeCointEvent != null)
        {
                val_60 = val_1.Length;
        }
        
        val_1[1] = this.initFreeCointEvent;
        UnityEngine.Debug.LogWarningFormat(format:  "Setup Rewarded Video Window with: {0} & {1}", args:  val_1);
        this.Button_FreeHint.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result));
        this.Button_FreeHint.interactable = true;
        this.group_start.SetActive(value:  true);
        this.group_success.SetActive(value:  false);
        this.group_sorry.SetActive(value:  false);
        this.message_thankYou.canvasRenderer.SetAlpha(alpha:  1f);
        Player val_5 = App.Player;
        if(val_5.num_purchase < 1)
        {
            goto label_21;
        }
        
        if(val_5.num_purchase != 1)
        {
            goto label_22;
        }
        
        val_61 = val_6.oneTimePurchaserVidReward;
        val_62 = App.getGameEcon + 324;
        goto label_30;
        label_21:
        val_61 = val_7.nonPurchaserVidReward;
        val_62 = App.getGameEcon + 308;
        goto label_30;
        label_22:
        val_61 = val_8.repeatPurchaserVidReward;
        val_62 = App.getGameEcon + 340;
        label_30:
        this.reward = val_8.repeatPurchaserVidReward.flags;
        mem[1152921517850024232] = null;
        GameBehavior val_9 = App.getBehavior;
        if(((val_9.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                decimal val_11 = System.Decimal.op_Explicit(value:  WADPetsManager.GetLevelCurveModifier(ability:  4));
            this.petsReward = val_11;
            mem[1152921517850024248] = val_11.lo;
            mem[1152921517850024252] = val_11.mid;
            val_11.lo = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
            this.pet_icon.SetActive(value:  val_11.lo);
        }
        else
        {
                this.petsReward = 0m;
            mem[1152921517850024248] = 0;
        }
        
        val_63 = "wgfreehintpopup_explanation";
        val_65 = val_59;
        decimal val_14 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = X24, mid = X24}, d2:  new System.Decimal() {flags = this.petsReward, hi = this.petsReward, lo = 358311200, mid = 268435459});
        GameEcon val_15 = App.getGameEcon;
        val_66 = 1152921504617017344;
        string val_17 = System.String.Format(format:  Localization.Localize(key:  "wgfreehintpopup_explanation", defaultValue:  "Watch a quick video to receive {0} FREE COINS!", useSingularKey:  false), arg0:  val_14.flags.ToString(format:  val_15.numberFormatInt));
        if(this.midCoinTransform != 0)
        {
                UnityEngine.Vector3 val_19 = this.midCoinTransform.position;
            this.coinSource.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        }
        
        bool val_20 = UnityEngine.Object.op_Inequality(x:  this.coinSource, y:  0);
        if(val_20 != false)
        {
                val_20.SetActive(value:  false);
        }
        
        if(this.strikeoutLine != 0)
        {
                this.strikeoutLine.enabled = false;
        }
        
        if(this.strikeoutLine == 0)
        {
            goto label_76;
        }
        
        GameEcon val_24 = App.getGameEcon + 356;
        val_64 = mem[val_23.videoAdRewardBonusCollect];
        val_64 = val_23.videoAdRewardBonusCollect.flags;
        val_65 = this.strikeoutLine;
        if(((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_64, hi = val_64, lo = 366026752, mid = 268435456}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_65, mid = val_65})) == false) || (val_59 != 4))
        {
            goto label_76;
        }
        
        val_59 = 1152921504989913088;
        val_67 = null;
        val_67 = null;
        if(WGFreeHintPopup.dailyCollected == false)
        {
            goto label_76;
        }
        
        this.currTag = 18;
        val_68 = null;
        val_68 = null;
        this.currFreeCoinEvent = Events.AD_SEEN_REW_VID_DB;
        GameEcon val_26 = App.getGameEcon;
        this.reward = val_26.videoAdRewardBonusCollect.flags;
        val_69 = Localization.Localize(key:  "wgfreehintpopup_explanation", defaultValue:  "Watch a quick video to receive {0} FREE COINS!", useSingularKey:  false);
        GameEcon val_28 = App.getGameEcon;
        decimal val_30 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_64, mid = val_64}, d2:  new System.Decimal() {flags = this.petsReward, hi = this.petsReward, lo = this.reward, mid = this.reward});
        GameEcon val_31 = App.getGameEcon;
        string val_34 = System.String.Format(format:  val_69, arg0:  System.String.Format(format:  "{0} {1}", arg0:  this.reward.ToString(format:  val_28.numberFormatInt), arg1:  val_30.flags.ToString(format:  val_31.numberFormatInt)));
        val_66 = 1152921504617017344;
        GameEcon val_35 = App.getGameEcon;
        UnityEngine.Coroutine val_38 = this.StartCoroutine(routine:  this.SetStrkeOutLinePos_coroutine(textToStrike:  this.reward.ToString(format:  val_35.numberFormatInt)));
        this.strikeoutLine.enabled = true;
        val_70 = null;
        val_70 = null;
        WGFreeHintPopup.dailyCollected = false;
        goto label_94;
        label_76:
        val_69 = this.petsReward;
        this.currTag = this.initTag;
        this.currFreeCoinEvent = this.initFreeCointEvent;
        val_71 = null;
        val_71 = null;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_69, hi = val_69, lo = val_59, mid = val_59}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                GameEcon val_41 = App.getGameEcon;
            val_69 = this.reward;
            val_63 = this.reward;
            decimal val_43 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_63, hi = val_63, lo = 1152921504617017344}, d2:  new System.Decimal() {flags = this.petsReward, hi = this.petsReward, lo = X24, mid = X24});
            GameEcon val_44 = App.getGameEcon;
            string val_47 = System.String.Format(format:  Localization.Localize(key:  "wgfreehintpopup_explanation", defaultValue:  "Watch a quick video to receive {0} FREE COINS!", useSingularKey:  false), arg0:  System.String.Format(format:  "{0} {1}", arg0:  val_69.ToString(format:  val_41.numberFormatInt), arg1:  val_43.flags.ToString(format:  val_44.numberFormatInt)));
            val_66 = 1152921504617017344;
            GameEcon val_48 = App.getGameEcon;
            UnityEngine.Coroutine val_51 = this.StartCoroutine(routine:  this.SetStrkeOutLinePos_coroutine(textToStrike:  val_69.ToString(format:  val_48.numberFormatInt)));
            this.strikeoutLine.enabled = true;
        }
        
        label_94:
        decimal val_52 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_69, mid = val_69}, d2:  new System.Decimal() {flags = this.petsReward, hi = this.petsReward, lo = 358275088, mid = 268435459});
        GameEcon val_53 = App.getGameEcon;
        string val_54 = val_52.flags.ToString(format:  val_53.numberFormatInt);
    }
    protected void SetStrikeOutLinePos(string textToStrike)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.SetStrkeOutLinePos_coroutine(textToStrike:  textToStrike));
    }
    private System.Collections.IEnumerator SetStrkeOutLinePos_coroutine(string textToStrike)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .textToStrike = textToStrike;
        return (System.Collections.IEnumerator)new WGFreeHintPopup.<SetStrkeOutLinePos_coroutine>d__51();
    }
    public void OnFreeHintClick(bool result)
    {
        System.Collections.Hashtable val_11;
        var val_14;
        if(result == false)
        {
            goto label_1;
        }
        
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) == false)
        {
            goto label_5;
        }
        
        if(this.isMinigameWindow == false)
        {
            goto label_6;
        }
        
        if((MonoSingleton<MinigamesAdsController>.Instance.ShowIncentivizedVideo(heyZapAdTag:  this.currTag)) == false)
        {
            goto label_10;
        }
        
        goto label_18;
        label_1:
        System.Collections.Hashtable val_6 = null;
        val_11 = val_6;
        val_6 = new System.Collections.Hashtable();
        val_14 = "noconnection";
        goto label_13;
        label_5:
        System.Collections.Hashtable val_7 = null;
        val_11 = val_7;
        val_7 = new System.Collections.Hashtable();
        val_14 = "unavailable";
        label_13:
        Notification val_8 = new Notification(aSender:  this, aName:  "OnVideoResponse", aData:  val_7);
        return;
        label_6:
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  this.currTag, adCapExempt:  false)) == true)
        {
            goto label_18;
        }
        
        label_10:
        this.state = 1;
        label_18:
        this.Button_FreeHint.interactable = false;
        this.Button_FreeHint.interactable = true;
    }
    public virtual void OnVideoResponse(Notification notif)
    {
        var val_21;
        UnityEngine.UI.Text val_22;
        string val_23;
        string val_24;
        bool val_2 = System.Boolean.Parse(value:  notif.data.ToString());
        this.group_start.SetActive(value:  false);
        bool val_3 = val_2;
        this.group_success.SetActive(value:  val_3);
        this.Button_CollectHint.interactable = val_3;
        this.group_sorry.SetActive(value:  (~val_2) & 1);
        if(val_2 == false)
        {
            goto label_10;
        }
        
        if(GoldenGalaHandler.dailyChallengeApple == null)
        {
            goto label_12;
        }
        
        val_21 = GoldenGalaHandler.dailyChallengeApple ^ 1;
        goto label_13;
        label_10:
        val_21 = notif.data;
        if(this.sorry_message == 0)
        {
                return;
        }
        
        if(this.sorry_button_text == 0)
        {
                return;
        }
        
        if(this.sorry_banner_text == 0)
        {
                return;
        }
        
        if((notif.data & 1) == 0)
        {
            goto label_25;
        }
        
        string val_8 = Localization.Localize(key:  "no_video_upper", defaultValue:  "NO VIDEO AVAILABLE", useSingularKey:  false);
        string val_9 = Localization.Localize(key:  "video_unavailable_explanation", defaultValue:  "No Rewarded Video Available.", useSingularKey:  false);
        val_22 = this.sorry_button_text;
        val_23 = "try_again_upper";
        val_24 = "TRY AGAIN";
        goto label_28;
        label_12:
        val_21 = 0;
        label_13:
        this.regularRewardGroup.SetActive(value:  false);
        if(this.galaRewardGroup != 0)
        {
                this.galaRewardGroup.SetActive(value:  val_21 & 1);
        }
        
        if((val_21 & 1) == 0)
        {
                return;
        }
        
        this.SetupGalaRewards();
        return;
        label_25:
        if((val_21 & 1) != 0)
        {
                string val_12 = Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false);
            string val_13 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
            string val_14 = Localization.Localize(key:  "ok_upper", defaultValue:  "OKAY", useSingularKey:  false);
            System.Delegate val_16 = System.Delegate.Remove(source:  this.Button_WatchAnother.OnConnectionClick, value:  new System.Action<System.Boolean>(object:  this, method:  public System.Void WGFreeHintPopup::OnFreeHintClick(bool result)));
            if(val_16 != null)
        {
                if(null != null)
        {
            goto label_41;
        }
        
        }
        
            this.Button_WatchAnother.OnConnectionClick = val_16;
            this.Button_WatchAnother.OnConnectionClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGFreeHintPopup::<OnVideoResponse>b__54_0()));
            return;
        }
        
        string val_18 = Localization.Localize(key:  "incomplete_upper", defaultValue:  "INCOMPLETE", useSingularKey:  false);
        string val_19 = Localization.Localize(key:  "wgfreehintpopup_message", defaultValue:  "Sorry, you must complete video to receive coins.", useSingularKey:  false);
        val_22 = this.sorry_button_text;
        val_23 = "watch_another_upper";
        val_24 = "WATCH ANOTHER";
        label_28:
        string val_20 = Localization.Localize(key:  val_23, defaultValue:  val_24, useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        label_41:
    }
    private void SetupGalaRewards()
    {
        UnityEngine.Vector3 val_1 = this.leftCoinTransform.position;
        this.coinSource.position = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        this.coinsAnim.coinExpansionEnabled = false;
        this.galaRewardOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
        GameEcon val_4 = App.getGameEcon;
        string val_5 = this.reward.ToString(format:  val_4.numberFormatInt);
        GameEcon val_6 = App.getGameEcon;
        string val_7 = GoldenGalaHandler.dailyChallengeApple + 48.ToString(format:  val_6.numberFormatInt);
    }
    private void OnSubscriptionPurchaseAttempt(bool success)
    {
        this.galaRewardOverlay.SetActive(value:  (~GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive) & 1);
    }
    public virtual void OnCollectClicked()
    {
        int val_17;
        var val_18;
        var val_19;
        var val_20;
        object val_21;
        int val_22;
        int val_23;
        this.Button_CollectHint.interactable = false;
        val_17 = 1152921504614301696;
        System.Action val_1 = new System.Action(object:  this, method:  typeof(WGFreeHintPopup).__il2cppRuntimeField_198);
        this.coinsAnim.OnCompleteCallback = val_1;
        if(val_1 != 0)
        {
                mem2[0] = 0;
        }
        
        if((System.String.op_Equality(a:  this.currFreeCoinEvent, b:  "un-initialized")) != false)
        {
                object[] val_4 = new object[2];
            val_19 = null;
            val_19 = null;
            val_4[0] = PurchaseProxy.currentPurchasePoint;
            val_18 = 1152921504888475648;
            val_4[1] = this.currTag;
            UnityEngine.Debug.LogErrorFormat(format:  "About to collect WGFreeHint reward from unknown source. CurrentPurchasePoint is: {0}. CurrentTag is {1}", args:  val_4);
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_20 = 1152921515419383392;
        val_21 = this.reward;
        val_5.Add(key:  "Base Reward", value:  this.reward);
        if(GoldenGalaHandler.dailyChallengeApple == null)
        {
            goto label_26;
        }
        
        val_22 = 0;
        val_23 = 0;
        if(GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive == false)
        {
            goto label_34;
        }
        
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGFreeHintPopup::PlayGalaCoinAnim());
        val_23 = mem[GoldenGalaHandler.dailyChallengeApple + 48];
        val_23 = GoldenGalaHandler.dailyChallengeApple + 48;
        val_22 = mem[GoldenGalaHandler.dailyChallengeApple + 48 + 8];
        val_22 = GoldenGalaHandler.dailyChallengeApple + 48 + 8;
        decimal val_8 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = 1152921504614301696}, d2:  new System.Decimal() {flags = val_23, hi = val_23, lo = val_22, mid = val_22});
        this.reward = val_8;
        mem[1152921517851757912] = val_8.lo;
        mem[1152921517851757916] = val_8.mid;
        val_21 = val_23;
        val_5.Add(key:  "Golden Gala Bonus", value:  val_23);
        goto label_34;
        label_26:
        val_22 = 0;
        val_23 = 0;
        label_34:
        GameBehavior val_9 = App.getBehavior;
        if(((val_9.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_5.Add(key:  "Pet Ability: Simon Bonus", value:  this.petsReward);
            val_21 = this.petsReward;
            decimal val_10 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = 1152921515419383392}, d2:  new System.Decimal() {flags = val_21, hi = val_21, lo = 1152921504617017344});
            this.reward = val_10;
            mem[1152921517851757912] = val_10.lo;
            mem[1152921517851757916] = val_10.mid;
        }
        
        App.Player.AddCredits(amount:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = val_21, mid = val_21}, source:  this.currFreeCoinEvent, subSource:  0, externalParams:  val_5, doTrack:  true);
        if(this.coinsAnim == 0)
        {
                return;
        }
        
        Player val_13 = App.Player;
        decimal val_14 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits, lo = 1152921515419383392}, d2:  new System.Decimal() {flags = this.reward, hi = this.reward, lo = 1152921504617017344});
        val_17 = val_14.flags;
        Player val_15 = App.Player;
        decimal val_16 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_15._credits, hi = val_15._credits, lo = val_14.lo, mid = val_14.mid}, d2:  new System.Decimal());
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_17, hi = val_14.hi, lo = val_14.lo, mid = val_14.mid}, toValue:  new System.Decimal() {flags = val_16.flags, hi = val_16.hi, lo = val_16.lo, mid = val_16.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        if(this.hideTextWhileCollecting == false)
        {
                return;
        }
        
        this.message_thankYou.CrossFadeAlpha(alpha:  0f, duration:  1f, ignoreTimeScale:  true);
    }
    private void OnGalaRewardButtonClicked()
    {
        System.Delegate val_26;
        var val_27;
        var val_28;
        System.Action val_30;
        var val_31;
        var val_33;
        System.Action val_35;
        val_26 = GoldenGalaHandler.dailyChallengeApple.IsSubscriptionActive;
        WGFlyoutWindow val_3 = this.gameObject.GetComponent<WGFlyoutWindow>();
        if(val_26 == false)
        {
            goto label_4;
        }
        
        if(val_3 == 0)
        {
            goto label_7;
        }
        
        GameBehavior val_5 = App.getBehavior;
        val_27 = 1152921504990072832;
        val_28 = null;
        val_28 = null;
        val_30 = WGFreeHintPopup.<>c.<>9__58_0;
        if(val_30 == null)
        {
                System.Action val_7 = null;
            val_30 = val_7;
            val_7 = new System.Action(object:  WGFreeHintPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGFreeHintPopup.<>c::<OnGalaRewardButtonClicked>b__58_0());
            WGFreeHintPopup.<>c.<>9__58_0 = val_30;
        }
        
        mem2[0] = val_30;
        goto label_18;
        label_4:
        val_31 = null;
        if(val_3 == 0)
        {
            goto label_21;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_33 = null;
        val_33 = null;
        val_35 = WGFreeHintPopup.<>c.<>9__58_1;
        if(val_35 == null)
        {
                System.Action val_11 = null;
            val_35 = val_11;
            val_11 = new System.Action(object:  WGFreeHintPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGFreeHintPopup.<>c::<OnGalaRewardButtonClicked>b__58_1());
            WGFreeHintPopup.<>c.<>9__58_1 = val_35;
        }
        
        System.Delegate val_12 = System.Delegate.Combine(a:  val_26, b:  val_11);
        if(val_12 != null)
        {
                if(null != null)
        {
            goto label_33;
        }
        
        }
        
        mem2[0] = val_12;
        WGSubscriptionManager._subEntryPoint = 68;
        label_18:
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
        return;
        label_7:
        GameBehavior val_14 = App.getBehavior;
        val_26 = ???;
        goto mem[(1152921504946249728 + (public WGGoldenGalaInfoPopup MetaGameBehavior::ShowUGUIFlyOut<WGGoldenGalaInfoPopup>().__il2cppRuntimeField_48) << 4) + 312];
        label_21:
        GameBehavior val_15 = App.getBehavior;
        WGSubscriptionManager._subEntryPoint = 68;
        return;
        label_33:
    }
    private void PlayGalaCoinAnim()
    {
        UnityEngine.Vector3 val_1 = this.rightCoinTransform.position;
        this.coinSource.position = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  typeof(WGFreeHintPopup).__il2cppRuntimeField_198);
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = 360524880, mid = 268435459}, d2:  new System.Decimal() {flags = GoldenGalaHandler.dailyChallengeApple + 48, hi = GoldenGalaHandler.dailyChallengeApple + 48, lo = GoldenGalaHandler.dailyChallengeApple + 48 + 8, mid = GoldenGalaHandler.dailyChallengeApple + 48 + 8});
        Player val_5 = App.Player;
        this.coinsAnim.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause != false)
        {
                return;
        }
        
        if(this.Button_FreeHint != null)
        {
                this.Button_FreeHint.interactable = true;
            return;
        }
        
        throw new NullReferenceException();
    }
    protected virtual void CloseSorry()
    {
        this.group_start.SetActive(value:  true);
        this.Button_FreeHint.interactable = true;
        this.group_success.SetActive(value:  false);
        this.group_sorry.SetActive(value:  false);
    }
    protected virtual void Close(bool dontDestroyMonolith)
    {
        UnityEngine.Object val_7;
        if(this.isMinigameWindow != true)
        {
                val_7 = MonoSingleton<AdsUIController>.Instance;
            if((UnityEngine.Object.op_Implicit(exists:  val_7)) != false)
        {
                MonoSingleton<AdsUIController>.Instance.SawFreeHint();
        }
        
        }
        
        if(this.OnClose != null)
        {
                this.OnClose.Invoke();
            this.OnClose = 0;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  dontDestroyMonolith);
    }
    public virtual void OnDisable()
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) != 0)
        {
                WGSubscriptionManager val_3 = MonoSingleton<WGSubscriptionManager>.Instance;
            1152921504893161472 = val_3.purchaseResult;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGFreeHintPopup::OnSubscriptionPurchaseAttempt(bool success)));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            val_3.purchaseResult = val_5;
        }
        
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        return;
        label_10:
    }
    public WGFreeHintPopup()
    {
        this._isMinigameWindow = 0;
        this.initFreeCointEvent = "un-initialized";
        this.currFreeCoinEvent = "un-initialized";
    }
    private static WGFreeHintPopup()
    {
    
    }
    private void <Awake>b__42_0()
    {
        goto typeof(WGFreeHintPopup).__il2cppRuntimeField_1D0;
    }
    private void <OnVideoResponse>b__54_0()
    {
        goto typeof(WGFreeHintPopup).__il2cppRuntimeField_1D0;
    }

}
