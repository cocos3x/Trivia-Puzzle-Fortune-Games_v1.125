using UnityEngine;
public class PiggyBankV2Popup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject previewWindow;
    private UnityEngine.GameObject mainWindow;
    private UnityEngine.GameObject interstitialWindow;
    private UnityEngine.Playables.PlayableDirector interstitialToReadyDirector;
    private UnityEngine.Playables.PlayableDirector previewDirector;
    private UnityEngine.GameObject maxedOutImage;
    private UnityEngine.UI.Text bankAmountText;
    private UnityEngine.UI.Text openButtonText;
    private UnityEngine.UI.Text timerText;
    private UGUINetworkedButton openButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text interstitialBankAmountText;
    private UnityEngine.GameObject piggyBankGraphic;
    private UnityEngine.UI.Image piggyBankOverlay;
    private GoldenCurrencyCollectAnimationInstantiator interstitialGoldAnimation;
    private GridCoinCollectAnimationInstantiator coinAnimation;
    private decimal coinRewardAmount;
    private System.DateTime dealEndTime;
    private bool playPreviewOnAwake;
    private bool playInterstitialOnAwake;
    private DG.Tweening.Sequence timerSequence;
    
    // Methods
    private void Awake()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.closeButton)) == false)
        {
                return;
        }
        
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PiggyBankV2Popup::Close()));
    }
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PiggyBankV2Popup.<Start>d__22();
    }
    private void OnDisable()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    private void OnDestroy()
    {
        if(this.timerSequence == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
    }
    public void SetupPreview()
    {
        this.playPreviewOnAwake = true;
        this.SetupMain();
    }
    public void SetupMain()
    {
        var val_8;
        this.mainWindow.SetActive(value:  true);
        decimal val_1 = PiggyBankV2Handler.minDowngradeTier.BankAmountCurrent;
        this.coinRewardAmount = val_1;
        mem[1152921516605705264] = val_1.lo;
        mem[1152921516605705268] = val_1.mid;
        this.maxedOutImage.SetActive(value:  PiggyBankV2Handler.minDowngradeTier + 144);
        GameEcon val_2 = App.getGameEcon;
        string val_3 = this.coinRewardAmount.ToString(format:  val_2.numberFormatInt);
        string val_4 = PiggyBankV2Handler.minDowngradeTier + 136.LocalPrice;
        this.dealEndTime = PiggyBankV2Handler.minDowngradeTier;
        System.Delegate val_6 = System.Delegate.Combine(a:  this.openButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankV2Popup::OnOpenButtonClick(bool result)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        this.openButton.OnConnectionClick = val_6;
        val_8 = null;
        val_8 = null;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.dealEndTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return;
        }
        
        this.StartTimer();
        return;
        label_19:
    }
    public void SetupInterstitial()
    {
        this.playInterstitialOnAwake = true;
    }
    private void PlayInterstitialAnimation()
    {
        PiggyBankV2Popup.<>c__DisplayClass28_0 val_1 = new PiggyBankV2Popup.<>c__DisplayClass28_0();
        .<>4__this = this;
        decimal val_2 = PiggyBankV2Handler.minDowngradeTier.BankAmountOld;
        decimal val_3 = PiggyBankV2Handler.minDowngradeTier.BankAmountCurrent;
        GameEcon val_4 = App.getGameEcon;
        string val_5 = val_2.flags.ToString(format:  val_4.numberFormatInt);
        this.interstitialWindow.SetActive(value:  true);
        .bankAmount = System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        DG.Tweening.Tweener val_11 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  val_1, method:  System.Int32 PiggyBankV2Popup.<>c__DisplayClass28_0::<PlayInterstitialAnimation>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  val_1, method:  System.Void PiggyBankV2Popup.<>c__DisplayClass28_0::<PlayInterstitialAnimation>b__1(int x)), endValue:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}), duration:  0.5f), delay:  0.8f);
        this.PopPiggyBankGraphic(initialDelay:  0.8f);
        mem2[0] = new System.Action(object:  this, method:  System.Void PiggyBankV2Popup::OnInterstitialAnimationComplete());
        this.interstitialGoldAnimation.Play(fromValue:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}), toValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void OnInterstitialAnimationComplete()
    {
        PiggyBankV2Handler.minDowngradeTier.__unknownFiledOffset_94 = PiggyBankV2Handler.minDowngradeTier + 52;
        if((PiggyBankV2Handler.minDowngradeTier + 144) != 0)
        {
                this.interstitialToReadyDirector.Play();
            this.SetupMain();
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
    private void OnOpenButtonClick(bool result)
    {
        int val_14;
        var val_15;
        System.Func<System.Boolean> val_17;
        var val_18;
        if(result != false)
        {
                this.openButton.interactable = false;
            this.closeButton.gameObject.SetActive(value:  false);
            System.Delegate val_3 = System.Delegate.Combine(a:  PiggyBankV2Handler.minDowngradeTier + 192, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankV2Popup::OnPurchaseAttemptResult(bool result)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            PiggyBankV2Handler.minDowngradeTier.__unknownFiledOffset_C0 = val_3;
            PiggyBankV2Handler.minDowngradeTier.TryPurchase();
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
        val_17 = PiggyBankV2Popup.<>c.<>9__31_0;
        if(val_17 == null)
        {
                System.Func<System.Boolean> val_12 = null;
            val_17 = val_12;
            val_12 = new System.Func<System.Boolean>(object:  PiggyBankV2Popup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PiggyBankV2Popup.<>c::<OnOpenButtonClick>b__31_0());
            PiggyBankV2Popup.<>c.<>9__31_0 = val_17;
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
        int val_17;
        var val_18;
        System.Func<System.Boolean> val_20;
        var val_21;
        System.Delegate val_2 = System.Delegate.Remove(source:  PiggyBankV2Handler.minDowngradeTier + 192, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void PiggyBankV2Popup::OnPurchaseAttemptResult(bool result)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        PiggyBankV2Handler.minDowngradeTier.__unknownFiledOffset_C0 = val_2;
        if(result != false)
        {
                this.coinAnimation.OnCompleteCallback = new System.Action(object:  this, method:  System.Void PiggyBankV2Popup::OnCollectAnimationComplete());
            Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = -884853216, mid = 268435458}, d2:  new System.Decimal() {flags = this.coinRewardAmount, hi = this.coinRewardAmount, lo = -884885216, mid = 268435458});
            Player val_6 = App.Player;
            this.coinAnimation.Play(fromValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, toValue:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits}, textTickTime:  -1f, delayBeforeComplete:  1.5f);
            return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        bool[] val_11 = new bool[2];
        val_11[0] = true;
        string[] val_12 = new string[2];
        val_17 = val_12.Length;
        val_12[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_17 = val_12.Length;
        val_12[1] = "NO";
        System.Func<System.Boolean>[] val_14 = new System.Func<System.Boolean>[2];
        val_18 = null;
        val_18 = null;
        val_20 = PiggyBankV2Popup.<>c.<>9__32_0;
        if(val_20 == null)
        {
                System.Func<System.Boolean> val_15 = null;
            val_20 = val_15;
            val_15 = new System.Func<System.Boolean>(object:  PiggyBankV2Popup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean PiggyBankV2Popup.<>c::<OnPurchaseAttemptResult>b__32_0());
            PiggyBankV2Popup.<>c.<>9__32_0 = val_20;
        }
        
        val_14[0] = val_20;
        val_21 = null;
        val_21 = null;
        val_7.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_11, buttonTexts:  val_12, showClose:  false, buttonCallbacks:  val_14, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_4:
    }
    private void OnCollectAnimationComplete()
    {
        this.Close();
    }
    private void StartTimer()
    {
        if(this.timerText == 0)
        {
                return;
        }
        
        if(this.timerSequence != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.timerSequence, complete:  false);
        }
        
        DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
        this.timerSequence = val_2;
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_2, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankV2Popup::<StartTimer>b__34_0()));
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.timerSequence, interval:  1f);
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.timerSequence, loops:  0);
    }
    private string GetDateString()
    {
        var val_15;
        object val_16;
        object val_17;
        string val_19;
        System.TimeSpan val_1 = PiggyBankV2Handler.minDowngradeTier.GetTimeRemaining();
        val_15 = null;
        val_15 = null;
        if((System.TimeSpan.op_LessThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_1._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                this.Close();
        }
        
        if(val_1._ticks.Days >= 1)
        {
                val_16 = val_1._ticks.Days;
            val_17 = val_1._ticks.Hours;
            int val_6 = val_1._ticks.Minutes;
            val_19 = "{0}d {1}h {2}m";
            return (string)System.String.Format(format:  val_19 = "{0}h {1}m {2}s", arg0:  int val_8 = val_1._ticks.Hours, arg1:  int val_9 = val_1._ticks.Minutes, arg2:  val_1._ticks.Seconds);
        }
        
        if(val_1._ticks.Hours >= 1)
        {
                val_16 = val_8;
            val_17 = val_9;
            return (string)System.String.Format(format:  val_19, arg0:  val_8, arg1:  val_9, arg2:  val_1._ticks.Seconds);
        }
        
        string val_14 = System.String.Format(format:  "{0}m {1}s", arg0:  val_1._ticks.Minutes, arg1:  val_1._ticks.Seconds);
        return (string)System.String.Format(format:  val_19, arg0:  val_8, arg1:  val_9, arg2:  val_1._ticks.Seconds);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public PiggyBankV2Popup()
    {
    
    }
    private void <StartTimer>b__34_0()
    {
        string val_3 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "deal_ends_in", defaultValue:  "Deal ends in", useSingularKey:  false), arg1:  this.GetDateString());
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
