using UnityEngine;
public class WGLevelClearPopup : MonoBehaviour
{
    // Fields
    protected ExtraProgress progress;
    protected UnityEngine.UI.Text text_progress;
    protected TMPro.TextMeshProUGUI text_chapter;
    protected TMPro.TextMeshProUGUI text_chapter_shadow;
    protected UnityEngine.GameObject chapter_progress_group;
    protected UnityEngine.UI.Button buttonContinue;
    protected UnityEngine.CanvasGroup tapToContinueCanvasGroup;
    protected UnityEngine.CanvasGroup postLevelButtonsCanvasGroup;
    protected UGUINetworkedButton postLevelRewardedButton;
    protected UGUINetworkedButton postLevelAlphabetButton;
    protected UGUINetworkedButton postLevelAdControlButton;
    protected UnityEngine.UI.Text postLevelAdControlButtonText;
    protected UnityEngine.GameObject postLevelAlphabetRewardGroup;
    private UnityEngine.ParticleSystem completeAnimation;
    protected UnityEngine.GameObject group_tapToContinue;
    protected UnityEngine.GameObject group_freeHint;
    protected LevelCompletePopup levelCompletePopup;
    protected WGLevelClearPopup.OfferButton offerButton;
    private System.Action onEnableAction;
    
    // Methods
    public void Init()
    {
        this.completeAnimation.Play();
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.sound.PlayGeneralSound(type:  0, oneshot:  true, pitch:  1f, vol:  1f);
    }
    public void Setup(bool shouldBeShowing)
    {
        bool val_1 = shouldBeShowing;
        this.group_tapToContinue.SetActive(value:  val_1);
        this.group_freeHint.SetActive(value:  val_1);
        this.gameObject.SetActive(value:  shouldBeShowing);
        if(shouldBeShowing == false)
        {
                return;
        }
        
        if(this.gameObject.activeInHierarchy != false)
        {
                this.Init();
            return;
        }
        
        if(this.gameObject.activeInHierarchy == true)
        {
                return;
        }
        
        this.onEnableAction = new System.Action(object:  this, method:  public System.Void WGLevelClearPopup::Init());
    }
    public void SetupLevelCompletePopup(LevelCompletePopup popup)
    {
        this.levelCompletePopup = popup;
    }
    private void OnEnable()
    {
        if(this.onEnableAction != null)
        {
                this.onEnableAction.Invoke();
        }
        
        this.onEnableAction = 0;
    }
    protected virtual void Start()
    {
        UnityEngine.Events.UnityAction val_11;
        var val_12;
        System.Action<System.Boolean> val_14;
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(selected:  this.gameObject);
        UnityEngine.Events.UnityAction val_3 = null;
        val_11 = val_3;
        val_3 = new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGLevelClearPopup).__il2cppRuntimeField_198);
        this.buttonContinue.m_OnClick.AddListener(call:  val_3);
        if(this.postLevelRewardedButton != 0)
        {
                val_12 = null;
            val_12 = null;
            val_14 = WGLevelClearPopup.<>c.<>9__24_0;
            if(val_14 == null)
        {
                System.Action<System.Boolean> val_5 = null;
            val_14 = val_5;
            val_5 = new System.Action<System.Boolean>(object:  WGLevelClearPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGLevelClearPopup.<>c::<Start>b__24_0(bool result));
            WGLevelClearPopup.<>c.<>9__24_0 = val_14;
        }
        
            this.postLevelRewardedButton.OnConnectionClick = val_14;
        }
        
        if(this.postLevelAlphabetButton != 0)
        {
                if(this.postLevelAlphabetRewardGroup != 0)
        {
                val_11 = this.postLevelAlphabetButton;
            this.postLevelAlphabetButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGLevelClearPopup::<Start>b__24_1(bool result));
        }
        
        }
        
        if(this.postLevelAdControlButton == 0)
        {
                return;
        }
        
        val_11 = this.postLevelAdControlButton;
        this.postLevelAdControlButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void WGLevelClearPopup::OnClick_PostLevelAdControlButton(bool success));
    }
    protected virtual void UpdateUI()
    {
        OfferButton val_36;
        var val_37;
        this.chapter_progress_group.gameObject.SetActive(value:  false);
        string val_3 = Localization.Localize(key:  "chapter_upper", defaultValue:  "CHAPTER", useSingularKey:  false)(Localization.Localize(key:  "chapter_upper", defaultValue:  "CHAPTER", useSingularKey:  false)) + " " + 0;
        this.text_chapter.text = val_3;
        this.text_chapter_shadow.text = val_3;
        this.progress.target = 0f;
        this.progress.current = 0f;
        float val_4 = this.progress._current * 100f;
        val_4 = val_4 / this.progress.target;
        string val_7 = UnityEngine.Mathf.Clamp(value:  val_4, min:  0f, max:  100f).ToString(format:  "##,##0")(UnityEngine.Mathf.Clamp(value:  val_4, min:  0f, max:  100f).ToString(format:  "##,##0")) + "%"("%");
        this.HideOfferButtons();
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelOffer()) == false)
        {
                return;
        }
        
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) != false)
        {
                return;
        }
        
        val_36 = this.offerButton;
        if(val_36 == 0)
        {
                val_36 = this;
            this.offerButton = val_36;
        }
        
        if(val_36 == 3)
        {
            goto label_20;
        }
        
        if(val_36 == 2)
        {
            goto label_21;
        }
        
        if(val_36 != 1)
        {
                return;
        }
        
        if(this.postLevelRewardedButton == 0)
        {
                return;
        }
        
        GameBehavior val_14 = App.getBehavior;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelRewardedVideo(playerLevel:  (val_14.<metaGameBehavior>k__BackingField) - 1)) == false)
        {
                return;
        }
        
        if(this.postLevelRewardedButton != null)
        {
            goto label_60;
        }
        
        label_20:
        if(this.postLevelAdControlButton == 0)
        {
                return;
        }
        
        GameBehavior val_19 = App.getBehavior;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelAdsControlOffer(playerLevel:  (val_19.<metaGameBehavior>k__BackingField) - 1)) == false)
        {
                return;
        }
        
        val_37 = null;
        val_37 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
                return;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        GameEcon val_24 = App.getGameEcon;
        string val_25 = System.String.Format(format:  Localization.Localize(key:  "x_levels_no_ads_upper", defaultValue:  "{0} LEVELS NO ADS", useSingularKey:  false), arg0:  val_24.postLevelAdsControl_duration);
        if(this.postLevelAdControlButton != null)
        {
            goto label_60;
        }
        
        label_21:
        if(this.postLevelAlphabetButton == 0)
        {
                return;
        }
        
        GameBehavior val_28 = App.getBehavior;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelRewardedVideo(playerLevel:  (val_28.<metaGameBehavior>k__BackingField) - 1)) == false)
        {
                return;
        }
        
        if(Alphabet2Manager.IsAvailable == false)
        {
                return;
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance.ShouldShowPostLevelAd()) == false)
        {
                return;
        }
        
        label_60:
        this.postLevelAlphabetButton.gameObject.SetActive(value:  true);
        MonoSingleton<AdsUIController>.Instance.SawPostLevelOffer();
    }
    public virtual void OnClick_TapToContinue()
    {
        if((UnityEngine.Mathf.Approximately(a:  this.tapToContinueCanvasGroup.alpha, b:  1f)) == false)
        {
                return;
        }
        
        this.buttonContinue.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGLevelClearPopup).__il2cppRuntimeField_198));
        this = ???;
        goto typeof(LevelCompletePopup).__il2cppRuntimeField_190;
    }
    public virtual void PlayStartAnims()
    {
        if(this.gameObject.activeSelf == false)
        {
                return;
        }
        
        DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tapToContinueCanvasGroup, endValue:  1f, duration:  0.5f), delay:  2f);
        DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.postLevelButtonsCanvasGroup, endValue:  1f, duration:  0.5f), delay:  2f);
    }
    public virtual void ResetLevelClearAfterGiftReward()
    {
    
    }
    private void OnDestroy()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
    }
    protected void HideOfferButtons()
    {
        if(this.postLevelRewardedButton != 0)
        {
                this.postLevelRewardedButton.gameObject.SetActive(value:  false);
        }
        
        if(this.postLevelAlphabetButton != 0)
        {
                this.postLevelAlphabetButton.gameObject.SetActive(value:  false);
        }
        
        if(this.postLevelAdControlButton == 0)
        {
                return;
        }
        
        this.postLevelAdControlButton.gameObject.SetActive(value:  false);
    }
    private void ForceShowOfferButton(WGLevelClearPopup.OfferButton offer)
    {
        this.offerButton = offer;
    }
    private void OnClick_PostLevelAdControlButton(bool success)
    {
        var val_4;
        if(success == false)
        {
            goto label_1;
        }
        
        this.postLevelAdControlButton.gameObject.SetActive(value:  false);
        bool val_3 = MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  24, adCapExempt:  false);
        if(val_3 == false)
        {
            goto label_7;
        }
        
        val_4 = null;
        val_4 = null;
        PurchaseProxy.currentPurchasePoint = 18;
        return;
        label_1:
        this.ShowConnectionRequired();
        return;
        label_7:
        val_3.ShowVideoUnavailable();
    }
    private void ShowConnectionRequired()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = WGLevelClearPopup.<>c.<>9__33_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  WGLevelClearPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGLevelClearPopup.<>c::<ShowConnectionRequired>b__33_0());
            WGLevelClearPopup.<>c.<>9__33_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ShowVideoUnavailable()
    {
        int val_10;
        var val_11;
        System.Func<System.Boolean> val_13;
        var val_14;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_10 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_10 = val_6.Length;
        val_6[1] = "NULL";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_11 = null;
        val_11 = null;
        val_13 = WGLevelClearPopup.<>c.<>9__34_0;
        if(val_13 == null)
        {
                System.Func<System.Boolean> val_9 = null;
            val_13 = val_9;
            val_9 = new System.Func<System.Boolean>(object:  WGLevelClearPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGLevelClearPopup.<>c::<ShowVideoUnavailable>b__34_0());
            WGLevelClearPopup.<>c.<>9__34_0 = val_13;
        }
        
        val_8[0] = val_13;
        val_14 = null;
        val_14 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnVideoResponse(Notification notif)
    {
        var val_7;
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        AdsManager.noAdsStartLevel = App.Player;
        GameBehavior val_4 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0}, source:  "Ads Control Level Complete", subSource:  0, externalParams:  0, doTrack:  true);
    }
    protected virtual WGLevelClearPopup.OfferButton GetOfferButtonToShow()
    {
        var val_13;
        GameEcon val_1 = App.getGameEcon;
        float val_13 = val_1.postLevelAdsControl_freq;
        val_13 = val_13 * 10f;
        GameEcon val_3 = App.getGameEcon;
        GameEcon val_4 = App.getGameEcon;
        float val_5 = val_3.postLevelRewardedVideo_freq * 10f;
        float val_7 = val_4.postLevelCollectionTile_freq * 10f;
        var val_9 = ((int)(val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5)) + ((int)(val_13 == Infinityf) ? (-(double)val_13) : ((double)val_13));
        int val_11 = UnityEngine.Random.Range(min:  0, max:  val_9 + ((int)(val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7)));
        if(val_11 > ((int)(val_13 == Infinityf) ? (-(double)val_13) : ((double)val_13)))
        {
                var val_12 = (val_11 > val_9) ? (1 + 1) : 1;
            return (OfferButton)val_13;
        }
        
        val_13 = 3;
        return (OfferButton)val_13;
    }
    public WGLevelClearPopup()
    {
    
    }
    private void <Start>b__24_1(bool result)
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = 49;
        this.postLevelAlphabetRewardGroup.SetActive(value:  true);
    }

}
