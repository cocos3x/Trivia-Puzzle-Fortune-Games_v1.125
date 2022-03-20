using UnityEngine;
public class BBLOutOfLivesPopup : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Text headerLabel;
    private UnityEngine.UI.Button buttonClose;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private UnityEngine.GameObject lifeCountDisplay;
    private UnityEngine.UI.Text lifeCountLabel;
    private UnityEngine.UI.Text lifeTimerHeaderLabel;
    private UnityEngine.UI.Text lifeTimerValueLabel;
    private UGUINetworkedButton buttonWatchAd;
    private UnityEngine.UI.Text buttonWatchAdLifeQtyLabel;
    private UnityEngine.UI.Text buttonWatchAdLabel;
    private UnityEngine.UI.Button buttonPurchaseLives;
    private UnityEngine.UI.Text buttonPurchaseLivesQtyLabel;
    private UnityEngine.UI.Text buttonPurchaseLivesCostLabel;
    private System.Action onPopupClosed;
    private System.TimeSpan timerCooldownInterval;
    private int prevLifeCount;
    
    // Properties
    private int LivesCreditedPerAdView { get; }
    private int LivesCreditedPerPurchase { get; }
    
    // Methods
    private int get_LivesCreditedPerAdView()
    {
        return 1;
    }
    private int get_LivesCreditedPerPurchase()
    {
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        return (int)val_1.maxPlayerLives;
    }
    private void Start()
    {
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  (double)val_1.lifeRechargeTimeMins);
        this.timerCooldownInterval = val_2;
        mem[1152921513409759424] = 10;
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLOutOfLivesPopup::CloseWindow()));
        this.buttonPurchaseLives.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLOutOfLivesPopup::OnPurchaseClicked()));
        this.buttonPurchaseLives.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLOutOfLivesPopup::OnWatchAdClicked()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        this.UpdateView();
    }
    private void OnDisable()
    {
        if(this.onPopupClosed != null)
        {
                this.onPopupClosed.Invoke();
        }
        
        this.onPopupClosed = 0;
    }
    public void Init(System.Action onCloseAction)
    {
        System.Delegate val_1 = System.Delegate.Combine(a:  this.onPopupClosed, b:  onCloseAction);
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        this.onPopupClosed = val_1;
        return;
        label_2:
    }
    private void UpdateView()
    {
        BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
        string val_2 = val_1.livesBalance.ToString();
        string val_3 = System.String.Format(format:  "+{0}", arg0:  1);
        string val_5 = System.String.Format(format:  "+{0}", arg0:  this.buttonWatchAdLifeQtyLabel.LivesCreditedPerPurchase);
        BlockPuzzleMagic.BestBlocksGameEcon val_6 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        string val_7 = val_6.maxLivesCost.ToString();
    }
    protected override void UpdateLogic()
    {
        UnityEngine.UI.Text val_11;
        if(BestBlocksPlayer.Instance.IsLivesMaxed() == false)
        {
            goto label_2;
        }
        
        val_11 = this.lifeTimerValueLabel;
        string val_3 = Localization.Localize(key:  "max_upper", defaultValue:  "MAX", useSingularKey:  false);
        if(val_11 != null)
        {
            goto label_3;
        }
        
        label_2:
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        BestBlocksPlayer val_5 = BestBlocksPlayer.Instance;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = val_5.lastLifeTopupTime});
        System.TimeSpan val_7 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = this.timerCooldownInterval}, t2:  new System.TimeSpan() {_ticks = val_6._ticks});
        val_11 = this.lifeTimerValueLabel;
        string val_8 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_7._ticks}, formatted:  true);
        label_3:
        BestBlocksPlayer val_9 = BestBlocksPlayer.Instance;
        if(this.prevLifeCount == val_9.livesBalance)
        {
                return;
        }
        
        this.UpdateView();
        BestBlocksPlayer val_10 = BestBlocksPlayer.Instance;
        this.prevLifeCount = val_10.livesBalance;
    }
    private void CreditLife(int amt, string source)
    {
        .<>4__this = this;
        .amt = amt;
        this.ToggleAllButtonsInteractable(isInteractable:  false);
        int val_3 = BestBlocksPlayer.Instance.CreditLife(amount:  (BBLOutOfLivesPopup.<>c__DisplayClass25_0)[1152921513410680352].amt, source:  source);
        MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.SaveGame();
        DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
        if(((BBLOutOfLivesPopup.<>c__DisplayClass25_0)[1152921513410680352].amt) >= 1)
        {
                int val_24 = 0;
            do
        {
            .CS$<>8__locals1 = new BBLOutOfLivesPopup.<>c__DisplayClass25_0();
            .curr = val_24;
            float val_7 = 0f * 0.15f;
            UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  1.1f, y:  1.1f, z:  1f);
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_5, atPosition:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.lifeCountDisplay.transform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.01f), ease:  1));
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_5, atPosition:  val_7, callback:  new DG.Tweening.TweenCallback(object:  new BBLOutOfLivesPopup.<>c__DisplayClass25_1(), method:  System.Void BBLOutOfLivesPopup.<>c__DisplayClass25_1::<CreditLife>b__0()));
            UnityEngine.Vector3 val_16 = UnityEngine.Vector3.one;
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_5, atPosition:  val_7 + 0.01f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.lifeCountDisplay.transform, endValue:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, duration:  0.2f), ease:  1));
            val_24 = val_24 + 1;
        }
        while(val_24 < ((BBLOutOfLivesPopup.<>c__DisplayClass25_0)[1152921513410680352].amt));
        
        }
        
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_5, interval:  1f);
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_5, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLOutOfLivesPopup::CloseWindow()));
    }
    private void ToggleAllButtonsInteractable(bool isInteractable)
    {
        bool val_1 = isInteractable;
        this.buttonPurchaseLives.interactable = val_1;
        this.buttonWatchAd.interactable = val_1;
        this.buttonClose.interactable = isInteractable;
    }
    private void CloseWindow()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnPurchaseClicked()
    {
        var val_12;
        System.Action val_14;
        Player val_1 = App.Player;
        BlockPuzzleMagic.BestBlocksGameEcon val_2 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41979904}, d2:  new System.Decimal() {flags = val_2.maxLivesCost, hi = val_2.maxLivesCost, lo = X23, mid = X23})) != false)
        {
                GameBehavior val_4 = App.getBehavior;
            val_12 = null;
            val_12 = null;
            val_14 = BBLOutOfLivesPopup.<>c.<>9__28_0;
            if(val_14 == null)
        {
                System.Action val_6 = null;
            val_14 = val_6;
            val_6 = new System.Action(object:  BBLOutOfLivesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLOutOfLivesPopup.<>c::<OnPurchaseClicked>b__28_0());
            BBLOutOfLivesPopup.<>c.<>9__28_0 = val_14;
        }
        
            val_4.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  val_6);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        BlockPuzzleMagic.BestBlocksGameEcon val_8 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        this.CreditLife(amt:  CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_8.maxLivesCost, hi = val_8.maxLivesCost, lo = 41979904}, source:  "Max Lives", externalParams:  0, animated:  false).LivesCreditedPerPurchase, source:  0);
        Player val_11 = App.Player;
        this.coinsAnimControl.Set(instantValue:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits});
    }
    private void OnWatchAdClicked()
    {
        int val_13;
        var val_14;
        System.Func<System.Boolean> val_16;
        var val_17;
        if((MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  28, adCapExempt:  false)) != false)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        bool[] val_7 = new bool[2];
        val_7[0] = true;
        string[] val_8 = new string[2];
        val_13 = val_8.Length;
        val_8[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
        val_13 = val_8.Length;
        val_8[1] = "NULL";
        System.Func<System.Boolean>[] val_10 = new System.Func<System.Boolean>[2];
        val_14 = null;
        val_14 = null;
        val_16 = BBLOutOfLivesPopup.<>c.<>9__29_0;
        if(val_16 == null)
        {
                System.Func<System.Boolean> val_11 = null;
            val_16 = val_11;
            val_11 = new System.Func<System.Boolean>(object:  BBLOutOfLivesPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean BBLOutOfLivesPopup.<>c::<OnWatchAdClicked>b__29_0());
            BBLOutOfLivesPopup.<>c.<>9__29_0 = val_16;
        }
        
        val_10[0] = val_16;
        val_17 = null;
        val_17 = null;
        val_3.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_7, buttonTexts:  val_8, showClose:  false, buttonCallbacks:  val_10, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnVideoResponse(Notification notif)
    {
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        this.CreditLife(amt:  1, source:  "Free Life From Ads");
    }
    public BBLOutOfLivesPopup()
    {
    
    }

}
