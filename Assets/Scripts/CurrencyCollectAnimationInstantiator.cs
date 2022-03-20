using UnityEngine;
public abstract class CurrencyCollectAnimationInstantiator : StatViewInstantiatior
{
    // Fields
    private bool disableOnComplete;
    public UnityEngine.Transform particlesStartPos;
    private float delayBeforeAnimationConclusion;
    protected UnityEngine.Vector2 tweenPointBeforePlay;
    public System.Action OnCompleteCallback;
    private CurrencyParticles flyingParticles;
    
    // Properties
    public CurrencyParticles GetParticles { get; }
    
    // Methods
    public CurrencyParticles get_GetParticles()
    {
        return (CurrencyParticles)this.flyingParticles;
    }
    protected override void SetupAnimatedElements()
    {
        UnityEngine.Transform val_6;
        mem2[0] = new System.Action(object:  this, method:  System.Void CurrencyCollectAnimationInstantiator::ConcludeAnimation());
        if(this.particlesStartPos != 0)
        {
                val_6 = this.particlesStartPos;
        }
        else
        {
                val_6 = this.transform;
        }
        
        this.flyingParticles = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this, parent:  val_6).GetComponent<CurrencyParticles>();
    }
    public void Play(int fromValue, decimal toValue, float textTickTime = -1, float delayBeforeComplete = -1, UnityEngine.GameObject destinationObject, UnityEngine.GameObject originObject)
    {
        float val_13 = delayBeforeComplete;
        CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0 val_1 = new CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0();
        .<>4__this = this;
        .fromValue = fromValue;
        .toValue = toValue;
        mem[1152921517459936100] = toValue.lo;
        mem[1152921517459936104] = toValue.mid;
        .textTickTime = textTickTime;
        .delayBeforeComplete = val_13;
        .destinationObject = destinationObject;
        .originObject = originObject;
        if(null == 0)
        {
            goto label_2;
        }
        
        if(val_13 < 0)
        {
                val_13 = this.delayBeforeAnimationConclusion;
        }
        
        this.delayBeforeAnimationConclusion = val_13;
        val_1.gameObject.SetActive(value:  true);
        this.SetStatViewValue(instantValue:  (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].fromValue);
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
        bool val_4 = UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = val_13}, rhs:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
        if(val_4 == false)
        {
            goto label_9;
        }
        
        UnityEngine.Transform val_5 = val_4.transform;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = val_13});
        val_5.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.Vector2 val_8 = UnityEngine.Vector2.zero;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
        DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  val_5.transform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0::<Play>b__0()));
        return;
        label_2:
        UnityEngine.Debug.LogError(message:  "CurrencyCollectAnimationInstantiator attempting to play but stat view has not been created.");
        return;
        label_9:
        this.ContinueCoinCollectAnimation(fromValue:  (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].fromValue, toValue:  new System.Decimal() {flags = (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].toValue, hi = (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].toValue, lo = toValue.lo, mid = toValue.mid}, textTickTime:  this.tweenPointBeforePlay, delayBeforeComplete:  val_13, destinationObject:  (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].destinationObject, originObject:  (CurrencyCollectAnimationInstantiator.<>c__DisplayClass9_0)[1152921517459936064].originObject);
    }
    private void ContinueCoinCollectAnimation(int fromValue, decimal toValue, float textTickTime = -1, float delayBeforeComplete = -1, UnityEngine.GameObject destinationObject, UnityEngine.GameObject originObject)
    {
        if(originObject != 0)
        {
                this.flyingParticles.SetOrigin(originObject:  originObject);
        }
        
        bool val_2 = UnityEngine.Object.op_Equality(x:  destinationObject, y:  0);
        if(val_2 != false)
        {
                if(val_2.AppleIcon.transform != null)
        {
            goto label_10;
        }
        
        }
        
        label_10:
        UnityEngine.Vector3 val_6 = destinationObject.transform.position;
        decimal val_7 = System.Decimal.op_Implicit(value:  fromValue);
        decimal val_8 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = toValue.flags, hi = toValue.hi, lo = toValue.lo, mid = toValue.mid}, d2:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        this.flyingParticles.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, particleCount:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}), animateStatView:  true);
    }
    private void ConcludeAnimation()
    {
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  this.delayBeforeAnimationConclusion, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CurrencyCollectAnimationInstantiator::<ConcludeAnimation>b__11_0()), ignoreTimeScale:  true);
    }
    protected abstract UnityEngine.GameObject GetParticleSystemPrefabFromTheme(); // 0
    protected CurrencyCollectAnimationInstantiator()
    {
        this.delayBeforeAnimationConclusion = 0.25f;
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        this.tweenPointBeforePlay = val_1;
        mem[1152921517460351792] = val_1.y;
    }
    private void <ConcludeAnimation>b__11_0()
    {
        if(this.OnCompleteCallback != null)
        {
                this.OnCompleteCallback.Invoke();
        }
        
        if(this.disableOnComplete == false)
        {
                return;
        }
        
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = V8.16B}, rhs:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y})) != false)
        {
                UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = V8.16B});
            DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished.transform, endValue:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CurrencyCollectAnimationInstantiator::<ConcludeAnimation>b__11_1()));
            return;
        }
        
        UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished.SetActive(value:  false);
    }
    private void <ConcludeAnimation>b__11_1()
    {
        if(this != null)
        {
                this.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
