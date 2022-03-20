using UnityEngine;
public class UGUIGenericCoinsGainedParticleAnim : MonoBehaviour
{
    // Fields
    private ParticleAttraction particleAttractor;
    private UnityEngine.Transform ParticleStartPos;
    private UnityEngine.GameObject contents;
    private TweenCoinsText textTween;
    private UnityEngine.ParticleSystem coinFlyParticles;
    public float firstCoinPercent;
    public float lastCoinPercent;
    public float totalTime;
    private bool disableStatViewWhenComplete;
    private bool disableWhenComplete;
    private bool stopOnDisable;
    private decimal startCoins;
    private decimal finalCoins;
    public System.Action OnClosedCallback;
    private bool hasCreated;
    private UnityEngine.ParticleSystem.MainModule mainMan;
    
    // Properties
    public float countUpDuration { get; }
    
    // Methods
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
        UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  GameSpecificUI.currentGame.CoinsGainedAnimContents, parent:  this.transform);
        this.contents = val_4;
        this.textTween = val_4.GetComponentInChildren<TweenCoinsText>(includeInactive:  true);
        UnityEngine.ParticleSystem val_6 = this.contents.GetComponentInChildren<UnityEngine.ParticleSystem>(includeInactive:  true);
        this.coinFlyParticles = val_6;
        this.particleAttractor.PS = val_6;
        if(this.particleAttractor.endPoint == 0)
        {
                this.particleAttractor.endPoint = this.textTween.transform;
        }
        
        if(this.ParticleStartPos == 0)
        {
                this.ParticleStartPos = this.transform;
        }
        
        this.coinFlyParticles.transform.SetParent(parent:  this.ParticleStartPos, worldPositionStays:  false);
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.zero;
        this.coinFlyParticles.transform.localPosition = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
    }
    private void Awake()
    {
        if(this.hasCreated != false)
        {
                return;
        }
        
        this.Create();
    }
    public void Set(decimal instantValue)
    {
        if(this.hasCreated != true)
        {
                this.Create();
        }
        
        this.textTween.Set(instantValue:  new System.Decimal() {flags = instantValue.flags, hi = instantValue.hi, lo = instantValue.lo, mid = instantValue.mid});
    }
    public void Play(decimal startCoins, decimal finalCoins)
    {
        if(this.hasCreated != true)
        {
                this.Create();
        }
        
        MainModule val_1 = this.coinFlyParticles.main;
        this.mainMan = val_1.m_ParticleSystem;
        float val_4 = this.lastCoinPercent;
        float val_6 = this.totalTime;
        float val_5 = this.firstCoinPercent;
        val_4 = val_6 * val_4;
        val_4 = val_6 - val_4;
        val_5 = val_6 * val_5;
        val_4 = val_4 + val_5;
        val_6 = val_6 - val_4;
        this.mainMan.duration = val_6;
        mem[1152921515819654976] = startCoins.flags;
        mem[1152921515819654980] = startCoins.hi;
        mem[1152921515819654984] = startCoins.lo;
        mem[1152921515819654988] = startCoins.mid;
        mem[1152921515819654992] = finalCoins.flags;
        mem[1152921515819654996] = finalCoins.hi;
        mem[1152921515819655000] = finalCoins.lo;
        mem[1152921515819655004] = finalCoins.mid;
        this.textTween.disableAfterTween = this.disableStatViewWhenComplete;
        this.Set(instantValue:  new System.Decimal() {flags = startCoins.flags, hi = startCoins.hi, lo = startCoins.lo, mid = startCoins.mid});
        this.gameObject.SetActive(value:  true);
        this.textTween.gameObject.SetActive(value:  true);
        this.coinFlyParticles.Play();
        float val_7 = this.firstCoinPercent;
        val_7 = val_7 * this.totalTime;
        this.Invoke(methodName:  "StartCountingUp", time:  val_7);
        this.Invoke(methodName:  "ConcludeAnimation", time:  this.totalTime);
    }
    private void StartCountingUp()
    {
        if(this.textTween != null)
        {
                float val_1 = this.lastCoinPercent;
            float val_3 = this.totalTime;
            float val_2 = this.firstCoinPercent;
            val_1 = val_3 * val_1;
            val_1 = val_3 - val_1;
            val_2 = val_3 * val_2;
            val_2 = val_1 + val_2;
            val_3 = val_3 - val_2;
            this.textTween.Tween(startValue:  new System.Decimal() {flags = this.startCoins, hi = this.startCoins}, endValue:  new System.Decimal() {flags = this.finalCoins, hi = this.finalCoins}, seconds:  val_3);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void ConcludeAnimation()
    {
        if(this.OnClosedCallback != null)
        {
                this.OnClosedCallback.Invoke();
        }
        
        if(this.disableWhenComplete == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if(this.stopOnDisable == false)
        {
                return;
        }
        
        this.CancelInvoke();
        this.textTween.HaltImmediate();
    }
    public UGUIGenericCoinsGainedParticleAnim()
    {
        this.totalTime = 4f;
        this.disableStatViewWhenComplete = true;
        this.disableWhenComplete = true;
        this.firstCoinPercent = 0.5f;
        this.lastCoinPercent = 1.5f;
        this.stopOnDisable = true;
    }

}
