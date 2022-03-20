using UnityEngine;
public class WGEventButtonProgressLightningLevels : WGEventButtonProgress
{
    // Fields
    protected UnityEngine.UI.Image completedIcon;
    protected LightningLevelsEventHandler lightningEventHandler;
    protected bool showingFinishedState;
    protected DG.Tweening.Tween countdownSeq;
    protected DG.Tweening.Tween refreshSeq;
    
    // Methods
    public override void Initialize(WGEventHandler handler)
    {
        mem[1152921517497572696] = handler;
        this.lightningEventHandler = handler;
        this.refreshSeq = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tween>(t:  DG.Tweening.DOVirtual.DelayedCall(delay:  0.25f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  typeof(WGEventButtonProgressLightningLevels).__il2cppRuntimeField_198), ignoreTimeScale:  true), loops:  0, loopType:  0);
    }
    protected void OnDestroy()
    {
        this.StopUpdate();
    }
    public override void Refresh()
    {
        int val_25 = 1152921516497973568;
        LightningLevelsUIController val_1 = MonoSingleton<LightningLevelsUIController>.Instance;
        if(val_1.isTimerPaused == false)
        {
            goto label_4;
        }
        
        if((this.countdownSeq == null) || ((DG.Tweening.TweenExtensions.IsPlaying(t:  this.countdownSeq)) == false))
        {
            goto label_9;
        }
        
        DG.Tweening.Tween val_3 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Tween>(t:  this.countdownSeq);
        goto label_9;
        label_4:
        label_9:
        if(this.showingFinishedState == true)
        {
                return;
        }
        
        if((DG.Tweening.TweenExtensions.Play<DG.Tweening.Tween>(t:  this.countdownSeq).alpha) <= 0f)
        {
                return;
        }
        
        LightningLevelsUIController val_7 = MonoSingleton<LightningLevelsUIController>.Instance;
        if(val_7.isTimerPaused == true)
        {
                return;
        }
        
        val_25 = this.lightningEventHandler.<CacheOverallEventProgress>k__BackingField;
        UnityEngine.GameObject val_8 = this.lightningEventHandler.gameObject;
        if(this.lightningEventHandler > val_25)
        {
                val_8.SetActive(value:  false);
            this.completedIcon.gameObject.SetActive(value:  true);
            this.StopUpdate();
            return;
        }
        
        val_8.SetActive(value:  true);
        this.completedIcon.gameObject.SetActive(value:  false);
        int val_11 = this.lightningEventHandler.GetMovingWordIndex();
        if(this.lightningEventHandler.TotalSeconds < 0)
        {
                if(this.countdownSeq == null)
        {
            goto label_32;
        }
        
        }
        
        this.gameObject.SetActive(value:  true);
        if(this.lightningEventHandler.TotalSeconds <= 0f)
        {
                return;
        }
        
        if(this.lightningEventHandler.TotalSeconds > 10)
        {
                return;
        }
        
        if(this.countdownSeq != null)
        {
                return;
        }
        
        UnityEngine.Vector3 val_17 = new UnityEngine.Vector3(x:  0.3f, y:  0.3f, z:  0f);
        DG.Tweening.TweenCallback val_22 = null;
        val_25 = val_22;
        val_22 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventButtonProgressLightningLevels::<Refresh>b__7_1());
        this.countdownSeq = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnStepComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.lightningEventHandler.transform, punch:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, duration:  1f, vibrato:  2, elasticity:  0.5f), loops:  10, loopType:  0), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventButtonProgressLightningLevels::<Refresh>b__7_0())), action:  val_22);
        return;
        label_32:
        this.gameObject.SetActive(value:  false);
    }
    public void DoCompleteEfx()
    {
        UnityEngine.GameObject val_1 = this.gameObject;
        val_1.SetActive(value:  true);
        val_1.Play();
    }
    public void DoCompleteAnimation()
    {
        35670.gameObject.SetActive(value:  false);
        this.completedIcon.gameObject.SetActive(value:  true);
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        this.completedIcon.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
        UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  3.5f, y:  3.5f, z:  1f);
        this.completedIcon.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_6, interval:  0.8f);
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.completedIcon, endValue:  1f, duration:  0.15f), ease:  1));
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.one;
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.completedIcon.transform, endValue:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, duration:  1f), ease:  30));
        this.StopUpdate();
    }
    protected void StopUpdate()
    {
        this.showingFinishedState = true;
        if(this.refreshSeq != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.refreshSeq, complete:  false);
        }
        
        this.refreshSeq = 0;
        if(this.countdownSeq != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.countdownSeq, complete:  false);
        }
        
        this.countdownSeq = 0;
    }
    public WGEventButtonProgressLightningLevels()
    {
        mem[1152921517498648160] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }
    private void <Refresh>b__7_0()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
        35673.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }
    private void <Refresh>b__7_1()
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this, endValue:  0f, duration:  1f);
        this.StopUpdate();
    }

}
