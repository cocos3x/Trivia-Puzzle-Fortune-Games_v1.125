using UnityEngine;
[Serializable]
public class WFOEventButton : WGEventButton
{
    // Fields
    private bool isInSneakPreviewMode;
    private System.Collections.Generic.List<WGEventHandler> sneakPreviewLockedEventList;
    private UnityEngine.UI.Image iconLocked;
    private UnityEngine.UI.Text lockedLabel;
    private UnityEngine.CanvasGroup buttonContentCanvasGroup;
    private UnityEngine.CanvasGroup sneakPreviewTooltip;
    private DG.Tweening.Tweener sneakTooltipTween;
    private DG.Tweening.Sequence eventDisplayLoop;
    private System.Collections.Generic.List<string> eventsToSkipProcessing;
    
    // Methods
    protected override void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventDataReceived");
        this.Awake();
        DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
        this.eventDisplayLoop = val_2;
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_2, loops:  0, loopType:  0);
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.eventDisplayLoop, interval:  4.8f);
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.OnStepComplete<DG.Tweening.Sequence>(t:  this.eventDisplayLoop, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOEventButton::<Awake>b__9_0()));
    }
    private void VisualLoop()
    {
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.buttonContentCanvasGroup, endValue:  0f, duration:  0.2f));
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  X21, method:  public System.Void UnityEngine.Events.UnityEvent::Invoke()));
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.1f);
        DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.buttonContentCanvasGroup, endValue:  1f, duration:  0.2f));
    }
    private void OnDestroy()
    {
        System.Collections.Generic.List<WGEventHandler> val_1;
        bool val_1 = true;
        val_1 = this.sneakPreviewLockedEventList;
        var val_2 = 0;
        label_5:
        if(val_2 >= val_1)
        {
            goto label_2;
        }
        
        if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + 0;
        val_1 = this.sneakPreviewLockedEventList;
        val_2 = val_2 + 1;
        if(val_1 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_2:
        val_1.Clear();
        this.sneakPreviewLockedEventList = 0;
    }
    private void OnGameEventDataReceived()
    {
        this.UpdateDisplay();
    }
    protected override void PrevEvent()
    {
        DG.Tweening.TweenExtensions.Restart(t:  this.eventDisplayLoop, includeDelay:  true, changeDelayTo:  -1f);
        if(this.isInSneakPreviewMode != false)
        {
                float val_2 = UnityEngine.Mathf.Repeat(t:  (float)W21 - 1, length:  4.197581E+07f);
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            mem[1152921517420380176] = (int)val_2;
            this.UpdateDisplay();
            return;
        }
        
        this.PrevEvent();
    }
    protected override void NextEvent()
    {
        DG.Tweening.TweenExtensions.Restart(t:  this.eventDisplayLoop, includeDelay:  true, changeDelayTo:  -1f);
        if(this.isInSneakPreviewMode != false)
        {
                float val_2 = UnityEngine.Mathf.Repeat(t:  (float)W21 + 1, length:  4.197581E+07f);
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            mem[1152921517420508560] = (int)val_2;
            this.UpdateDisplay();
            return;
        }
        
        this.NextEvent();
    }
    protected override void OnClick(bool result)
    {
        if(this.isInSneakPreviewMode != false)
        {
                if(this.sneakTooltipTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.sneakTooltipTween, complete:  false);
        }
        
            this.sneakPreviewTooltip.gameObject.SetActive(value:  true);
            this.sneakPreviewTooltip.alpha = 1f;
            this.sneakTooltipTween = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.sneakPreviewTooltip, endValue:  0f, duration:  0.2f), delay:  3.5f);
            return;
        }
        
        result = result;
        this.OnClick(result:  result);
    }
    protected override System.Collections.IEnumerator UpdateDisplayDelayed()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WFOEventButton.<UpdateDisplayDelayed>d__16();
    }
    protected void RefineEventIconLook(WGEventHandler evtHandler)
    {
        if(evtHandler == null)
        {
                return;
        }
        
        string val_1 = evtHandler.EventType;
    }
    public WFOEventButton()
    {
        this.sneakPreviewLockedEventList = new System.Collections.Generic.List<WGEventHandler>();
        this.eventsToSkipProcessing = new System.Collections.Generic.List<System.String>();
    }
    private void <Awake>b__9_0()
    {
        this.VisualLoop();
    }
    private System.Collections.IEnumerator <>n__0()
    {
        return this.UpdateDisplayDelayed();
    }

}
