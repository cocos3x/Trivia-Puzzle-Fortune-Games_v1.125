using UnityEngine;
public abstract class CurrencyParticles : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem trailParticles;
    private UnityEngine.ParticleSystem burstParticles;
    private UnityEngine.Transform trailDestination;
    private UnityEngine.Vector3 offSetVector;
    private float statViewDelay;
    private System.Action onAwake;
    
    // Methods
    private System.Collections.IEnumerator Start()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new CurrencyParticles.<Start>d__6();
    }
    public void SetOrigin(UnityEngine.GameObject originObject)
    {
        UnityEngine.Vector3 val_3 = originObject.transform.position;
        this.trailParticles.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public void PlayParticles(UnityEngine.Vector3 destinationPosition, int particleCount, bool animateStatView = True)
    {
        float val_11;
        float val_12;
        UnityEngine.ParticleSystem val_13;
        val_11 = destinationPosition.z;
        val_12 = destinationPosition.x;
        .<>4__this = this;
        .destinationPosition = destinationPosition;
        mem[1152921517461309020] = destinationPosition.y;
        mem[1152921517461309024] = val_11;
        .particleCount = particleCount;
        .animateStatView = animateStatView;
        if(this.gameObject.activeInHierarchy != false)
        {
                val_11 = (CurrencyParticles.<>c__DisplayClass8_0)[1152921517461308992].destinationPosition;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_11, y = destinationPosition.y, z = V13.16B}, b:  new UnityEngine.Vector3() {x = this.offSetVector, y = val_12, z = V11.16B});
            this.trailDestination.position = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            val_13 = this.trailParticles;
            val_13.Emit(count:  UnityEngine.Mathf.Abs(value:  (CurrencyParticles.<>c__DisplayClass8_0)[1152921517461308992].particleCount));
            this.burstParticles.Play();
            if((System.String.IsNullOrEmpty(value:  this)) == true)
        {
                return;
        }
        
            UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.UpdateStatView(statViewDelaySeconds:  this.statViewDelay, doStatViewAnimation:  (CurrencyParticles.<>c__DisplayClass8_0)[1152921517461308992].animateStatView));
            return;
        }
        
        System.Action val_10 = null;
        val_13 = val_10;
        val_10 = new System.Action(object:  new CurrencyParticles.<>c__DisplayClass8_0(), method:  System.Void CurrencyParticles.<>c__DisplayClass8_0::<PlayParticles>b__0());
        this.onAwake = val_13;
    }
    public void PlayParticles(int particleCount, bool animateStatView = True)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        this.trailDestination.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        UnityEngine.Vector3 val_2 = this.trailDestination.position;
        animateStatView = animateStatView;
        this.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, particleCount:  particleCount, animateStatView:  animateStatView);
    }
    private System.Collections.IEnumerator UpdateStatView(float statViewDelaySeconds, bool doStatViewAnimation)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .statViewDelaySeconds = statViewDelaySeconds;
        .doStatViewAnimation = doStatViewAnimation;
        return (System.Collections.IEnumerator)new CurrencyParticles.<UpdateStatView>d__10();
    }
    protected abstract string GetBalanceUpdateNotifiicationName(); // 0
    protected CurrencyParticles()
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0.25f, y:  0f, z:  0f);
        this.offSetVector = val_1.x;
        mem[1152921517461670392] = val_1.z;
        this.statViewDelay = 0.65f;
    }

}
