using UnityEngine;
public class WFOEventPointsGainAnimator : MonoBehaviour
{
    // Fields
    protected UnityEngine.CanvasGroup bgCanvasGroup;
    protected UnityEngine.UI.Image bgImage;
    protected UnityEngine.CanvasGroup flyoutCanvasGroup;
    protected UnityEngine.UI.Image flyoutFrameImage;
    protected UnityEngine.UI.Text eventNameText;
    protected UnityEngine.UI.Slider progressSlider;
    protected UnityEngine.UI.Image pointIconImage;
    protected UnityEngine.UI.Image rewardIconImage;
    protected UnityEngine.UI.Text rewardAmountText;
    protected UnityEngine.UI.Text meterFillLabel;
    protected UnityEngine.Sprite spriteFlyoutBgBrown;
    protected UnityEngine.Sprite spriteFlyoutBgBlue;
    protected UnityEngine.Transform pointsIconParent;
    protected UnityEngine.Transform radialRay;
    protected UnityEngine.RectTransform pointsIconRootTransform;
    protected UnityEngine.Sprite iconAttack;
    protected UnityEngine.Sprite iconRaid;
    protected UnityEngine.Sprite iconCoins;
    protected UnityEngine.Sprite iconGold;
    protected UnityEngine.Sprite iconFood;
    protected UnityEngine.Sprite iconWordHunt;
    protected UnityEngine.Sprite flyIconAttack;
    protected UnityEngine.Sprite flyIconRaid;
    private DG.Tweening.Ease easeX;
    private UnityEngine.AnimationCurve curveY;
    private float duration;
    private float symbolInterval;
    private float symbolScale;
    protected WGEventHandler eventHandler;
    
    // Properties
    protected virtual float AdditionalFlyoutLingerTime { get; }
    
    // Methods
    protected virtual float get_AdditionalFlyoutLingerTime()
    {
        return 0f;
    }
    private void Awake()
    {
        if((UnityEngine.Object.op_Implicit(exists:  WordRegion.instance)) == false)
        {
                return;
        }
        
        WordRegion.instance.AddLevelCompleteBlocker(blocker:  2);
    }
    private void Start()
    {
        UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  0f, y:  380f);
        if(null == null)
        {
                this.flyoutCanvasGroup.transform.anchoredPosition = new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
            return;
        }
    
    }
    public void SetHandler(WGEventHandler handler)
    {
        UnityEngine.Sprite val_5;
        this.eventHandler = handler;
        string val_1 = handler.EventType;
        if((System.String.op_Equality(a:  val_1, b:  "AttackMadness")) == false)
        {
            goto label_2;
        }
        
        val_5 = this.iconAttack;
        goto label_7;
        label_2:
        if((System.String.op_Equality(a:  val_1, b:  "RaidMadness")) == false)
        {
            goto label_5;
        }
        
        val_5 = this.iconRaid;
        goto label_7;
        label_5:
        if((System.String.op_Equality(a:  val_1, b:  "WordHunt")) == false)
        {
            goto label_8;
        }
        
        val_5 = this.iconWordHunt;
        label_7:
        this.pointIconImage.sprite = val_5;
        label_8:
        this.UpdateValue(animated:  false);
    }
    public void ShowPointGainAnimation(int fromQty, int toQty, int maxQty, System.Action onAnimationComplete, bool onlyAnimateProgressBar = False, bool showBackground = False, bool showBrownFlyout = True)
    {
        if(showBackground != false)
        {
                DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bgCanvasGroup, endValue:  1f, duration:  0.15f);
        }
        
        this.SetFlyoutFrame(showBrownFrame:  showBrownFlyout);
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.pointsIconParent.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        if(onlyAnimateProgressBar != false)
        {
                UnityEngine.Transform val_4 = this.flyoutCanvasGroup.transform;
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
            DG.Tweening.Tweener val_5 = DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  val_4, endValue:  -30f, duration:  0.5f, snapping:  false);
            this.ShowProgressBarAnimation(fromQty:  0, toQty:  toQty, maxQty:  maxQty, parentSeq:  0, onAnimationComplete:  onAnimationComplete);
            return;
        }
        
        if(this.gameObject.activeSelf != true)
        {
                this.gameObject.SetActive(value:  true);
        }
        
        UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.ShowPointGainAnimationCoroutine(fromQty:  fromQty, toQty:  toQty, maxQty:  maxQty, onAnimationComplete:  onAnimationComplete));
        return;
        label_8:
    }
    public void Close()
    {
        if((UnityEngine.Object.op_Implicit(exists:  WordRegion.instance)) != false)
        {
                WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  2);
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void ShowProgressBarAnimation(int fromQty, int toQty, int maxQty, DG.Tweening.Sequence parentSeq, System.Action onAnimationComplete)
    {
        DG.Tweening.Sequence val_36;
        float val_37;
        DG.Tweening.Tween val_38;
        var val_39;
        DG.Tweening.TweenCallback val_41;
        val_36 = parentSeq;
        WFOEventPointsGainAnimator.<>c__DisplayClass36_0 val_1 = new WFOEventPointsGainAnimator.<>c__DisplayClass36_0();
        .<>4__this = this;
        .onAnimationComplete = onAnimationComplete;
        if(val_36 == null)
        {
                val_36 = DG.Tweening.DOTween.Sequence();
        }
        
        if(toQty < maxQty)
        {
                DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_36, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass36_0::<ShowProgressBarAnimation>b__0()));
            val_37 = 0.8f;
            val_38 = 0;
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_36, interval:  val_37);
        }
        else
        {
                UnityEngine.GameObject val_8 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.rewardIconImage.gameObject, parent:  this.pointsIconParent.parent);
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.one;
            val_8.transform.localScale = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
            val_8.gameObject.SetActive(value:  true);
            UnityEngine.Vector3 val_14 = this.rewardIconImage.transform.position;
            val_8.transform.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
            this.rewardIconImage.gameObject.SetActive(value:  false);
            DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_36, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass36_0::<ShowProgressBarAnimation>b__2()));
            DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_36, interval:  0.5f);
            val_39 = null;
            val_39 = null;
            val_41 = WFOEventPointsGainAnimator.<>c.<>9__36_3;
            if(val_41 == null)
        {
                DG.Tweening.TweenCallback val_19 = null;
            val_41 = val_19;
            val_19 = new DG.Tweening.TweenCallback(object:  WFOEventPointsGainAnimator.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOEventPointsGainAnimator.<>c::<ShowProgressBarAnimation>b__36_3());
            WFOEventPointsGainAnimator.<>c.<>9__36_3 = val_41;
        }
        
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_36, callback:  val_19);
            UnityEngine.Vector3 val_22 = this.pointsIconRootTransform.position;
            DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_36, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  val_8.transform, endValue:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z}, duration:  0.7f, snapping:  false));
            val_37 = 3f;
            val_38 = DG.Tweening.ShortcutExtensions.DOScale(target:  val_8.transform, endValue:  val_37, duration:  0.5f);
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_36, t:  val_38);
        }
        
        if(val_37 > 0f)
        {
                DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_36, interval:  val_37);
        }
        
        UnityEngine.Transform val_29 = this.flyoutCanvasGroup.transform;
        if(val_29 != null)
        {
                if(null != null)
        {
            goto label_30;
        }
        
        }
        
        DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_36, t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  val_29, endValue:  380f, duration:  0.5f, snapping:  false));
        DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_36, callback:  new DG.Tweening.TweenCallback(object:  this, method:  public System.Void WFOEventPointsGainAnimator::Close()));
        if(((WFOEventPointsGainAnimator.<>c__DisplayClass36_0)[1152921517429823632].onAnimationComplete) == null)
        {
                return;
        }
        
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_36, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass36_0::<ShowProgressBarAnimation>b__1()));
        return;
        label_30:
    }
    private System.Collections.IEnumerator ShowPointGainAnimationCoroutine(int fromQty, int toQty, int maxQty, System.Action onAnimationComplete)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .toQty = toQty;
        .fromQty = fromQty;
        .maxQty = maxQty;
        .onAnimationComplete = onAnimationComplete;
        return (System.Collections.IEnumerator)new WFOEventPointsGainAnimator.<ShowPointGainAnimationCoroutine>d__37();
    }
    private void MoveSymbol(DG.Tweening.Sequence sq, UnityEngine.Transform trans, UnityEngine.Transform dest, System.Action onComplete)
    {
        .onComplete = onComplete;
        UnityEngine.Vector3 val_2 = dest.position;
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  DG.Tweening.TweenSettingsExtensions.Append(s:  sq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  trans, endValue:  val_2.x, duration:  this.duration, snapping:  false), ease:  this.easeX)), action:  new DG.Tweening.TweenCallback(object:  new WFOEventPointsGainAnimator.<>c__DisplayClass38_0(), method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass38_0::<MoveSymbol>b__0()));
        UnityEngine.Vector3 val_8 = dest.position;
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Join(s:  sq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  trans, endValue:  val_8.y, duration:  this.duration, snapping:  false), animCurve:  this.curveY));
        UnityEngine.Vector3 val_12 = dest.localScale;
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Join(s:  sq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  trans, endValue:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, duration:  this.duration));
    }
    private void OnIndividualPointIconAnimComplete(UnityEngine.GameObject pointObj)
    {
        UnityEngine.Object.Destroy(obj:  pointObj);
    }
    private UnityEngine.Sprite GetFlySprite()
    {
        UnityEngine.Sprite val_4;
        var val_5;
        string val_1 = this.eventHandler.EventType;
        if((System.String.op_Equality(a:  val_1, b:  "AttackMadness")) != false)
        {
                val_4 = this.flyIconAttack;
        }
        else
        {
                val_5 = 0;
            if((System.String.op_Equality(a:  val_1, b:  "RaidMadness")) == false)
        {
                return (UnityEngine.Sprite)val_5;
        }
        
            val_4 = this.iconRaid;
        }
        
        val_5 = mem[this.iconRaid];
        return (UnityEngine.Sprite)val_5;
    }
    private void UpdateValue(bool animated = False)
    {
        if((this.eventHandler & 1) != 0)
        {
                this.rewardIconImage.gameObject.SetActive(value:  false);
            return;
        }
        
        if(this.eventHandler != null)
        {
                GameEcon val_3 = App.getGameEcon;
            this.SetRewardDisplay(gameEventRewardType:  RESEventRewardTypeExtensions.ToGameEventRewardType(rewardType:  this.eventHandler.myEvent), rewardText:  this.eventHandler.OnMyPopupWasClosed_action.ToString(format:  val_3.numberFormatInt));
        }
        
        this.SetProgressBarValue(pointsCollected:  UnityEngine.Mathf.Min(a:  this.eventHandler, b:  this.eventHandler), pointsRequired:  this.eventHandler, animated:  animated);
    }
    public void SetRewardDisplay(GameEventRewardType gameEventRewardType, string rewardText)
    {
        UnityEngine.Sprite val_4;
        if(gameEventRewardType == 5)
        {
            goto label_0;
        }
        
        if(gameEventRewardType == 2)
        {
            goto label_1;
        }
        
        if(gameEventRewardType != 1)
        {
            goto label_2;
        }
        
        val_4 = this.iconCoins;
        goto label_6;
        label_1:
        val_4 = this.iconGold;
        goto label_6;
        label_0:
        val_4 = this.iconFood;
        label_6:
        this.rewardIconImage.sprite = val_4;
        label_2:
        this.rewardAmountText.gameObject.SetActive(value:  (~(System.String.IsNullOrEmpty(value:  rewardText))) & 1);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void SetProgressBarValue(int pointsCollected, int pointsRequired, bool animated = False)
    {
        bool val_9 = animated;
        WFOEventPointsGainAnimator.<>c__DisplayClass43_0 val_1 = new WFOEventPointsGainAnimator.<>c__DisplayClass43_0();
        .<>4__this = this;
        .pointsRequired = pointsRequired;
        .pointsCollected = pointsCollected;
        float val_9 = (float)pointsCollected;
        val_9 = val_9 / (float)pointsRequired;
        if(val_9 != false)
        {
                DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOValue(target:  this.progressSlider, endValue:  val_9, duration:  0.3f, snapping:  false), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass43_0::<SetProgressBarValue>b__0())), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass43_0::<SetProgressBarValue>b__1()));
            return;
        }
        
        if((this.eventHandler & 1) != 0)
        {
                if(this.meterFillLabel != null)
        {
                return;
        }
        
        }
        
        val_9 = (WFOEventPointsGainAnimator.<>c__DisplayClass43_0)[1152921517431200624].pointsCollected;
        string val_8 = System.String.Format(format:  "{0}/{1}", arg0:  (WFOEventPointsGainAnimator.<>c__DisplayClass43_0)[1152921517431200624].pointsCollected, arg1:  (WFOEventPointsGainAnimator.<>c__DisplayClass43_0)[1152921517431200624].pointsRequired);
    }
    private void SetFlyoutFrame(bool showBrownFrame)
    {
        if(this.flyoutFrameImage != null)
        {
                var val_1 = (showBrownFrame != true) ? 104 : 112;
            this.flyoutFrameImage.sprite = null;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void SetBackground(bool darken)
    {
        if(darken == false)
        {
                return;
        }
        
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bgCanvasGroup, endValue:  1f, duration:  0.15f);
    }
    public WFOEventPointsGainAnimator()
    {
        this.symbolScale = 1f;
        this.duration = 1f;
        this.symbolInterval = 0.2f;
    }
    private void <ShowPointGainAnimationCoroutine>b__37_3()
    {
        this.radialRay.gameObject.SetActive(value:  false);
        this.pointsIconRootTransform.gameObject.SetActive(value:  false);
    }

}
