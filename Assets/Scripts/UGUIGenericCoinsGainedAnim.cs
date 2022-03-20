using UnityEngine;
public class UGUIGenericCoinsGainedAnim : MonoBehaviour
{
    // Fields
    private ParticleAttraction particleAttractor;
    private UnityEngine.Transform ParticleStartPos;
    private TweenCoinsText textTween;
    private bool stopOnDisable;
    private bool disableWhenComplete;
    private bool useTweenCounter;
    private bool useParticleCounter;
    private float burstsTime;
    public float firstCoinPercent;
    public float lastCoinPercent;
    public float totalTime;
    public System.Action OnClosedCallback;
    private UnityEngine.ParticleSystem coinFlyParticles;
    private decimal startCoins;
    private decimal finalCoins;
    private bool hasCreated;
    private bool forceTextTweenOnAnimFinished;
    
    // Properties
    private UnityEngine.ParticleSystem particlesPrefab { get; }
    public float countUpDuration { get; }
    
    // Methods
    private UnityEngine.ParticleSystem get_particlesPrefab()
    {
        return PrefabLoader.LoadPrefab(featureName:  "CoinParticles", prefabName:  "coin_fly_explosion").GetComponent<UnityEngine.ParticleSystem>();
    }
    public float get_countUpDuration()
    {
        float val_1 = this.lastCoinPercent;
        float val_3 = this.totalTime;
        float val_2 = this.firstCoinPercent;
        val_1 = val_3 * val_1;
        val_1 = val_3 - val_1;
        val_2 = val_3 * val_2;
        val_1 = val_1 + val_2;
        val_3 = val_3 - val_1;
        return (float)val_3;
    }
    private void Create()
    {
        if(this.hasCreated != false)
        {
                return;
        }
        
        this.hasCreated = true;
        UnityEngine.Transform val_2 = this.gameObject.transform;
        this.ParticleStartPos = val_2;
        UnityEngine.ParticleSystem val_5 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  val_2.particlesPrefab, parent:  this.transform);
        this.coinFlyParticles = val_5;
        MainModule val_6 = val_5.main;
        val_6.m_ParticleSystem.stopAction = 0;
        this.particleAttractor.PS = this.coinFlyParticles;
        if(this.particleAttractor.endPoint == 0)
        {
                this.particleAttractor.endPoint = this.gameObject.transform;
        }
        
        if(this.useParticleCounter == false)
        {
                return;
        }
        
        if(this.useTweenCounter == true)
        {
                return;
        }
        
        System.Delegate val_11 = System.Delegate.Combine(a:  this.particleAttractor.OnParticleHitCallback, b:  new System.Action(object:  this, method:  System.Void UGUIGenericCoinsGainedAnim::ParticleAttractor_OnParticleHitCallback()));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_18;
        }
        
        }
        
        this.particleAttractor.OnParticleHitCallback = val_11;
        System.Delegate val_13 = System.Delegate.Combine(a:  this.particleAttractor.OnParticleHitsCompleteCallback, b:  new System.Action(object:  this, method:  System.Void UGUIGenericCoinsGainedAnim::ParticleAtractor_OnParticleHitsCompleteCallback()));
        if(val_13 != null)
        {
                if(null != null)
        {
            goto label_18;
        }
        
        }
        
        this.particleAttractor.OnParticleHitsCompleteCallback = val_13;
        return;
        label_18:
    }
    private void ParticleAtractor_OnParticleHitsCompleteCallback()
    {
        this.ConcludeAnimation();
    }
    private void ParticleAttractor_OnParticleHitCallback()
    {
        decimal val_6;
        decimal val_7;
        int val_8;
        var val_9;
        int val_10;
        val_6 = this.finalCoins;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_6, hi = val_6, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.startCoins, hi = this.startCoins, lo = 41967616})) == false)
        {
            goto label_3;
        }
        
        val_7 = this.startCoins;
        val_8 = val_7;
        val_9 = 41967616;
        val_10 = 0;
        decimal val_2 = System.Decimal.op_Increment(d:  new System.Decimal() {flags = val_8, hi = val_8, lo = 41967616});
        goto label_6;
        label_3:
        val_6 = this.finalCoins;
        val_7 = this.startCoins;
        val_10 = val_7;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_6, hi = val_6, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_10, hi = val_10, lo = 41967616})) == false)
        {
            goto label_9;
        }
        
        val_7 = this.startCoins;
        val_8 = val_7;
        val_9 = 41967616;
        val_10 = 0;
        decimal val_4 = System.Decimal.op_Decrement(d:  new System.Decimal() {flags = val_8, hi = val_8, lo = 41967616});
        label_6:
        this.startCoins = val_4;
        mem[1152921515817986608] = val_4.lo;
        mem[1152921515817986612] = val_4.mid;
        label_9:
        if((UnityEngine.Object.op_Implicit(exists:  this.textTween)) == false)
        {
                return;
        }
        
        this.textTween.Set(instantValue:  new System.Decimal() {flags = this.startCoins, hi = this.startCoins});
    }
    public void Set(decimal instantValue)
    {
        if(this.hasCreated != true)
        {
                this.Create();
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.textTween)) == false)
        {
                return;
        }
        
        this.textTween.Set(instantValue:  new System.Decimal() {flags = instantValue.flags, hi = instantValue.hi, lo = instantValue.lo, mid = instantValue.mid});
    }
    public void Play(decimal startCoins, decimal finalCoins, UnityEngine.Transform particleStart, bool forceTextTween = False)
    {
        UnityEngine.ParticleSystemCurveMode val_10;
        UnityEngine.AnimationCurve val_11;
        if(this.hasCreated != true)
        {
                this.Create();
        }
        
        if(particleStart != 0)
        {
                this.ParticleStartPos = particleStart;
        }
        
        UnityEngine.Vector3 val_3 = this.ParticleStartPos.position;
        this.coinFlyParticles.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        EmissionModule val_8 = this.coinFlyParticles.emission;
        MinMaxCurve val_9 = ParticleSystem.MinMaxCurve.op_Implicit(constant:  (float)UnityEngine.Mathf.Abs(value:  (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = finalCoins.flags, hi = finalCoins.hi, lo = finalCoins.lo, mid = finalCoins.mid})) - (System.Decimal.op_Explicit(value:  new System.Decimal() {flags = startCoins.flags, hi = startCoins.hi, lo = startCoins.lo, mid = startCoins.mid}))));
        val_8.m_ParticleSystem.rateOverTime = new MinMaxCurve() {m_Mode = val_10, m_CurveMultiplier = val_10, m_CurveMin = val_11, m_CurveMax = val_11};
        MainModule val_12 = this.coinFlyParticles.main;
        val_12.m_ParticleSystem.duration = this.burstsTime;
        this.startCoins = startCoins;
        mem[1152921515818284528] = startCoins.lo;
        mem[1152921515818284532] = startCoins.mid;
        this.finalCoins = finalCoins;
        mem[1152921515818284544] = finalCoins.lo;
        mem[1152921515818284548] = finalCoins.mid;
        this.Set(instantValue:  new System.Decimal() {flags = startCoins.flags, hi = startCoins.hi, lo = startCoins.lo, mid = startCoins.mid});
        particleStart.gameObject.SetActive(value:  true);
        this.coinFlyParticles.Play();
        this.forceTextTweenOnAnimFinished = forceTextTween;
        if(this.useTweenCounter == false)
        {
                return;
        }
        
        if(this.useParticleCounter == true)
        {
                return;
        }
        
        float val_15 = this.firstCoinPercent;
        val_15 = val_15 * this.totalTime;
        this.Invoke(methodName:  "StartCountingUp", time:  val_15);
        this.Invoke(methodName:  "ConcludeAnimation", time:  this.totalTime);
    }
    private void StartCountingUp()
    {
        if((UnityEngine.Object.op_Implicit(exists:  this.textTween)) == false)
        {
                return;
        }
        
        float val_2 = this.lastCoinPercent;
        float val_4 = this.totalTime;
        float val_3 = this.firstCoinPercent;
        val_2 = val_4 * val_2;
        val_2 = val_4 - val_2;
        val_3 = val_4 * val_3;
        val_3 = val_2 + val_3;
        val_4 = val_4 - val_3;
        this.textTween.Tween(startValue:  new System.Decimal() {flags = this.startCoins, hi = this.startCoins}, endValue:  new System.Decimal() {flags = this.finalCoins, hi = this.finalCoins}, seconds:  val_4);
    }
    private void ConcludeAnimation()
    {
        if(this.forceTextTweenOnAnimFinished != false)
        {
                if(this.useTweenCounter == false)
        {
            goto label_2;
        }
        
        }
        
        label_14:
        this.Set(instantValue:  new System.Decimal() {flags = this.finalCoins, hi = this.finalCoins});
        label_15:
        if(this.OnClosedCallback != null)
        {
                this.OnClosedCallback.Invoke();
        }
        
        if(this.disableWhenComplete != false)
        {
                this.gameObject.SetActive(value:  false);
        }
        
        this.hasCreated = false;
        if(this.useParticleCounter == false)
        {
                return;
        }
        
        if(this.useTweenCounter == true)
        {
                return;
        }
        
        System.Delegate val_3 = System.Delegate.Remove(source:  this.particleAttractor.OnParticleHitCallback, value:  new System.Action(object:  this, method:  System.Void UGUIGenericCoinsGainedAnim::ParticleAttractor_OnParticleHitCallback()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        this.particleAttractor.OnParticleHitCallback = val_3;
        System.Delegate val_5 = System.Delegate.Remove(source:  this.particleAttractor.OnParticleHitsCompleteCallback, value:  new System.Action(object:  this, method:  System.Void UGUIGenericCoinsGainedAnim::ParticleAtractor_OnParticleHitsCompleteCallback()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        this.particleAttractor.OnParticleHitsCompleteCallback = val_5;
        return;
        label_2:
        if(this.useParticleCounter == false)
        {
            goto label_14;
        }
        
        this.StartCountingUp();
        goto label_15;
        label_13:
    }
    private void OnDisable()
    {
        if(this.stopOnDisable == false)
        {
                return;
        }
        
        this.CancelInvoke();
        if((UnityEngine.Object.op_Implicit(exists:  this.textTween)) == false)
        {
                return;
        }
        
        this.textTween.HaltImmediate();
    }
    public UGUIGenericCoinsGainedAnim()
    {
        this.stopOnDisable = true;
        this.useParticleCounter = true;
        this.burstsTime = ;
        this.firstCoinPercent = ;
        this.lastCoinPercent = 1.5f;
        this.totalTime = 4f;
    }

}
