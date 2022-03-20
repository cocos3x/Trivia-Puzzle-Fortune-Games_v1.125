using UnityEngine;
public class PiggyBankPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject previewWindow;
    private UnityEngine.GameObject notReadyWindow;
    private UnityEngine.GameObject readyWindow;
    private UnityEngine.GameObject interstitialWindow;
    private UnityEngine.Playables.PlayableDirector interstitialToReadyDirector;
    protected UnityEngine.Playables.PlayableDirector previewDirector;
    private System.Collections.Generic.List<UnityEngine.UI.Text> coinTexts;
    private System.Collections.Generic.List<UnityEngine.UI.Text> appleTexts;
    protected UnityEngine.UI.Text previewText;
    private ExtraProgress progressBar;
    private UnityEngine.UI.Text progressBarText;
    private UnityEngine.UI.Text percentageFreeText;
    private UnityEngine.UI.Text valueText;
    private UnityEngine.UI.Text openButtonText;
    private UnityEngine.UI.Text timerText;
    private UGUINetworkedButton openButton;
    private UnityEngine.UI.Button closeButton;
    private ExtraProgress interstitialProgressBar;
    private UnityEngine.UI.Text interstitialProgressBarText;
    protected UnityEngine.GameObject piggyBankGraphic;
    private UnityEngine.UI.Image piggyBankOverlay;
    protected GoldenCurrencyCollectAnimationInstantiator interstitialGoldAnimation;
    private GridCoinCollectAnimationInstantiator coinAnimation;
    private GoldenCurrencyCollectAnimationInstantiator goldAnimation;
    protected GemsCollectAnimationInstantiator gemAnimation;
    protected decimal coinRewardAmount;
    private int appleRewardAmount;
    private System.DateTime dealEndTime;
    protected bool playPreviewOnAwake;
    private bool playInterstitialOnAwake;
    private bool endOfChapter;
    
    // Methods
    private void OnEnable()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.closeButton)) == false)
        {
                return;
        }
        
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void PiggyBankPopup::Close()));
    }
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PiggyBankPopup.<Start>d__32();
    }
    public virtual void SetupPreview()
    {
        var val_6;
        var val_7;
        string val_8;
        object val_9;
        string val_10;
        val_6 = null;
        val_6 = null;
        if(App.game == 17)
        {
                string val_1 = System.String.Format(format:  "Collect {0} Stars and buy the Piggy Bank to open it!", arg0:  PiggyBankHandler.iapHigh + 132);
            val_6 = null;
        }
        
        val_7 = null;
        val_7 = null;
        if(App.game == 18)
        {
                val_9 = PiggyBankHandler.iapHigh + 132;
            val_10 = "Collect {0} Acorns and buy the Piggy Bank to open it";
        }
        else
        {
                val_8 = Localization.Localize(key:  "piggy_bank_popup_info", defaultValue:  "Collect {0} Golden Apples and buy the Piggy Bank to open it", useSingularKey:  false);
            val_9 = PiggyBankHandler.iapHigh + 132;
            val_10 = val_8;
        }
        
        string val_3 = System.String.Format(format:  val_10, arg0:  PiggyBankHandler.iapHigh + 132);
        if(this.gameObject.activeInHierarchy != false)
        {
                this.previewDirector.Play();
            return;
        }
        
        this.playPreviewOnAwake = true;
    }
    public void SetupNotReady()
    {
        this.progressBar.target = (float)PiggyBankHandler.iapHigh + 128 + 4;
        this.progressBar.current = (float)PiggyBankHandler.iapHigh + 128;
        string val_1 = System.String.Format(format:  "{0}/{1}", arg0:  PiggyBankHandler.iapHigh + 128, arg1:  PiggyBankHandler.iapHigh + 128 + 4);
        this.notReadyWindow.SetActive(value:  true);
    }
    public void SetupReady(bool fromInterstitial = False, bool endOfChapter = False)
    {
        this.endOfChapter = endOfChapter;
        string val_2 = System.String.Format(format:  "{0}%", arg0:  PiggyBankHandler.iapHigh + 216);
        string val_5 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "open_upper", defaultValue:  "OPEN", useSingularKey:  false), arg1:  PiggyBankHandler.iapHigh.PricePurchaseString);
        this.dealEndTime = PiggyBankHandler.iapHigh + 152;
        System.Delegate val_7 = System.Delegate.Combine(a:  this.openButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  public System.Void PiggyBankPopup::OnOpenButtonClick(bool result)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        this.openButton.OnConnectionClick = val_7;
        if(this.gameObject.activeInHierarchy != false)
        {
                UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.UpdateTimer());
        }
        
        if(fromInterstitial == true)
        {
                return;
        }
        
        this.readyWindow.SetActive(value:  true);
        return;
        label_14:
    }
    public void SetupInterstitial(bool endOfChapter = False)
    {
        this.endOfChapter = endOfChapter;
        this.playInterstitialOnAwake = true;
    }
    private void PlayInterstitialAnimation()
    {
        int val_11;
        PiggyBankPopup.<>c__DisplayClass37_0 val_1 = new PiggyBankPopup.<>c__DisplayClass37_0();
        .<>4__this = this;
        .target = PiggyBankHandler.iapHigh + 132;
        .currentOld = PiggyBankHandler.iapHigh + 236;
        .current = PiggyBankHandler.iapHigh + 128;
        this.interstitialProgressBar.target = (float)(PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].target;
        this.interstitialProgressBar.current = (float)(PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].currentOld;
        string val_2 = System.String.Format(format:  "{0}/{1}", arg0:  (PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].currentOld, arg1:  (PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].target);
        this.interstitialWindow.SetActive(value:  true);
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single PiggyBankPopup.<>c__DisplayClass37_0::<PlayInterstitialAnimation>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void PiggyBankPopup.<>c__DisplayClass37_0::<PlayInterstitialAnimation>b__1(float x)), endValue:  (float)(PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].current, duration:  0.5f), delay:  0.8f);
        this.PopPiggyBankGraphic(initialDelay:  0.8f);
        mem2[0] = new System.Action(object:  this, method:  System.Void PiggyBankPopup::OnInterstitialAnimationComplete());
        if((System.Void PiggyBankPopup::OnInterstitialAnimationComplete()) != 0)
        {
                decimal val_8 = System.Decimal.op_Implicit(value:  (PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].current);
            val_11 = val_8.lo;
            this.interstitialGoldAnimation.Play(fromValue:  (PiggyBankPopup.<>c__DisplayClass37_0)[1152921516566634640].currentOld, toValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_11, mid = val_8.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  this.piggyBankGraphic.gameObject, originObject:  0);
            return;
        }
        
        System.Action val_10 = null;
        val_11 = val_10;
        val_10 = new System.Action(object:  val_1, method:  System.Void PiggyBankPopup.<>c__DisplayClass37_0::<PlayInterstitialAnimation>b__2());
        mem2[0] = val_11;
    }
    protected virtual void AnimateParticleAttraction()
    {
        var val_5;
        UnityEngine.Object val_6;
        var val_7;
        val_5 = this;
        val_7 = null;
        val_7 = null;
        if(App.game != 17)
        {
                return;
        }
        
        val_6 = GetComponent<ParticlePositionToPoint>();
        if(val_6 == 0)
        {
                return;
        }
        
        val_5 = GetComponent<ParticlePositionToPoint>();
        val_3.attractionPoint = this.piggyBankGraphic.transform;
    }
    private void OnInterstitialAnimationComplete()
    {
        PiggyBankHandler.iapHigh.ResetGoldGainedOld();
        if((PiggyBankHandler.iapHigh + 232) != 0)
        {
                this.interstitialToReadyDirector.Play();
            this.SetupReady(fromInterstitial:  true, endOfChapter:  this.endOfChapter);
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void PopPiggyBankGraphic(float initialDelay)
    {
        float val_11 = initialDelay;
        DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.piggyBankGraphic.transform, endValue:  1.1f, duration:  0.15f), delay:  val_11);
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.piggyBankOverlay, endValue:  0.3f, duration:  0.15f), delay:  val_11);
        val_11 = val_11 + 0.15f;
        DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.piggyBankGraphic.transform, endValue:  1f, duration:  0.35f), delay:  val_11);
        DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.piggyBankOverlay, endValue:  0f, duration:  0.35f), delay:  val_11);
    }
    public void OnOpenButtonClick(bool result)
    {
        int val_14;
        var val_15;
        System.Func<System.Boolean> val_17;
        var val_18;
        if(result != false)
        {
                this.openButton.interactable = false;
            this.closeButton.gameObject.SetActive(value:  false);
            System.Delegate val_3 = System.Delegate.Combine(a:  PiggyBankHandler.iapHigh + 280, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankPopup::OnPurchaseAttemptResult(bool result)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            PiggyBankHandler.iapHigh.__unknownFiledOffset_118 = val_3;
            PiggyBankHandler.iapHigh.TryPurchase();
            return;
        }
        
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_14 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_14 = val_9.Length;
        val_9[1] = "NULL";
        System.Func<System.Boolean>[] val_11 = new System.Func<System.Boolean>[2];
        val_15 = null;
        val_15 = null;
        val_17 = PiggyBankPopup.<>c.<>9__41_0;
        if(val_17 == null)
        {
                System.Func<System.Boolean> val_12 = null;
            val_17 = val_12;
            val_12 = new System.Func<System.Boolean>(object:  PiggyBankPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PiggyBankPopup.<>c::<OnOpenButtonClick>b__41_0());
            PiggyBankPopup.<>c.<>9__41_0 = val_17;
        }
        
        val_11[0] = val_17;
        val_18 = null;
        val_18 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_11, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_8:
    }
    private void OnPurchaseAttemptResult(bool result)
    {
        System.Delegate val_17;
        int val_18;
        var val_19;
        System.Func<System.Boolean> val_21;
        var val_22;
        System.Action<System.Boolean> val_1 = new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankPopup::OnPurchaseAttemptResult(bool result));
        val_17 = val_1;
        System.Delegate val_2 = System.Delegate.Remove(source:  PiggyBankHandler.iapHigh + 280, value:  val_1);
        if(val_2 == null)
        {
            goto label_3;
        }
        
        val_17 = null;
        if(null != val_17)
        {
            goto label_4;
        }
        
        label_3:
        PiggyBankHandler.iapHigh.__unknownFiledOffset_118 = val_2;
        if(result != false)
        {
                Player val_3 = App.Player;
            Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Implicit(value:  val_4._stars);
            this.goldAnimation.Play(fromValue:  val_3._stars - this.appleRewardAmount, toValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
            return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        bool[] val_11 = new bool[2];
        val_11[0] = true;
        string[] val_12 = new string[2];
        val_18 = val_12.Length;
        val_12[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_18 = val_12.Length;
        val_12[1] = "NO";
        System.Func<System.Boolean>[] val_14 = new System.Func<System.Boolean>[2];
        val_19 = null;
        val_19 = null;
        val_21 = PiggyBankPopup.<>c.<>9__42_0;
        if(val_21 == null)
        {
                System.Func<System.Boolean> val_15 = null;
            val_21 = val_15;
            val_15 = new System.Func<System.Boolean>(object:  PiggyBankPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PiggyBankPopup.<>c::<OnPurchaseAttemptResult>b__42_0());
            PiggyBankPopup.<>c.<>9__42_0 = val_21;
        }
        
        val_14[0] = val_21;
        val_22 = null;
        val_22 = null;
        val_7.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_11, buttonTexts:  val_12, showClose:  false, buttonCallbacks:  val_14, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_4:
    }
    protected virtual void DoOnPurchaseAnimation()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                mem2[0] = new System.Action(object:  this, method:  System.Void PiggyBankPopup::OnCollectAnimationComplete());
            Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
            decimal val_5 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount});
            Player val_7 = App.Player;
            decimal val_8 = System.Decimal.op_Implicit(value:  val_7._gems);
            this.gemAnimation.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}), toValue:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, textTickTime:  -1f, delayBeforeComplete:  1.5f, destinationObject:  0, originObject:  0);
            return;
        }
        
        this.coinAnimation.OnCompleteCallback = new System.Action(object:  this, method:  System.Void PiggyBankPopup::OnCollectAnimationComplete());
        Player val_10 = App.Player;
        decimal val_11 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = this.coinAnimation, mid = this.coinAnimation}, d2:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount, lo = -923930288, mid = 268435458});
        Player val_12 = App.Player;
        this.coinAnimation.Play(fromValue:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, toValue:  new System.Decimal() {flags = val_12._credits, hi = val_12._credits}, textTickTime:  -1f, delayBeforeComplete:  1.5f);
    }
    protected void OnCollectAnimationComplete()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void SetRewardAmounts()
    {
        System.Collections.Generic.List<UnityEngine.UI.Text> val_3;
        this.coinRewardAmount = PiggyBankHandler.iapHigh + 184;
        int val_3 = PiggyBankHandler.iapHigh + 200;
        this.appleRewardAmount = val_3;
        var val_4 = 0;
        label_8:
        if(val_4 >= val_3)
        {
            goto label_5;
        }
        
        if(val_3 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 0;
        string val_1 = this.coinRewardAmount.ToString();
        val_4 = val_4 + 1;
        if(this.coinTexts != null)
        {
            goto label_8;
        }
        
        label_5:
        val_3 = this.appleTexts;
        var val_5 = 0;
        do
        {
            if(val_5 >= val_3)
        {
                return;
        }
        
            if(val_3 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + 0;
            string val_2 = this.appleRewardAmount.ToString();
            val_3 = this.appleTexts;
            val_5 = val_5 + 1;
        }
        while(val_3 != null);
        
        throw new NullReferenceException();
    }
    private void StartTimer()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateTimer());
    }
    private System.Collections.IEnumerator UpdateTimer()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PiggyBankPopup.<UpdateTimer>d__47();
    }
    private string GetDateString()
    {
        var val_19;
        var val_20;
        System.Object[] val_21;
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.dealEndTime}, d2:  new System.DateTime() {dateData = val_1.dateData});
        val_19 = null;
        val_19 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_2._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_20 = null;
            val_20 = null;
        }
        
        if(System.TimeSpan.Zero.Days >= 1)
        {
                object[] val_5 = new object[4];
            val_21 = val_5;
            val_21[0] = System.TimeSpan.Zero.Days;
            val_21[1] = System.TimeSpan.Zero.Hours;
            val_21[2] = System.TimeSpan.Zero.Minutes;
            val_21[3] = System.TimeSpan.Zero.Seconds;
            string val_10 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}:{3:00}", args:  val_5);
            return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  int val_16 = System.TimeSpan.Zero.Minutes, arg1:  System.TimeSpan.Zero.Seconds);
        }
        
        if(System.TimeSpan.Zero.Hours >= 1)
        {
                int val_12 = System.TimeSpan.Zero.Hours;
            val_21 = val_12;
            string val_15 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_12, arg1:  System.TimeSpan.Zero.Minutes, arg2:  System.TimeSpan.Zero.Seconds);
            return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  val_16, arg1:  System.TimeSpan.Zero.Seconds);
        }
        
        val_21 = val_16;
        return (string)System.String.Format(format:  "{0:00}:{1:00}", arg0:  val_16, arg1:  System.TimeSpan.Zero.Seconds);
    }
    private void OnDisable()
    {
        if(PiggyBankHandler.iapHigh == null)
        {
                return;
        }
        
        goto typeof(System.String).__il2cppRuntimeField_540;
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PiggyBankPopup()
    {
        this.coinTexts = new System.Collections.Generic.List<UnityEngine.UI.Text>();
        this.appleTexts = new System.Collections.Generic.List<UnityEngine.UI.Text>();
    }

}
