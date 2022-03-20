using UnityEngine;
public class ParticleAttraction : MonoBehaviour
{
    // Fields
    public UnityEngine.Transform endPoint;
    public UnityEngine.ParticleSystem PS;
    private float attractionSpeed;
    public bool ignoreZ;
    private bool destroyWhenReached;
    private float destroyRadius;
    public System.Action OnParticleHitCallback;
    public System.Action OnParticleHitsCompleteCallback;
    
    // Methods
    private void Update()
    {
        this.Attract();
    }
    public void Attract()
    {
        var val_16;
        if(this.PS == 0)
        {
                return;
        }
        
        if(this.PS.isPlaying == false)
        {
                return;
        }
        
        if((this.PS.IsAlive(withChildren:  false)) == false)
        {
                return;
        }
        
        int val_4 = this.PS.particleCount;
        Particle[] val_5 = new Particle[0];
        UnityEngine.ParticleSystem val_22 = this.PS;
        int val_6 = val_22.GetParticles(particles:  val_5);
        if(val_6 >= 1)
        {
                var val_21 = 0;
            val_16 = 0;
            do
        {
            if(this.ignoreZ != false)
        {
                UnityEngine.Vector3 val_7 = val_5[32].position;
            UnityEngine.Vector3 val_8 = this.GetXYTargetPosition(pos:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        }
        else
        {
                UnityEngine.Vector3 val_9 = this.endPoint.position;
        }
        
            UnityEngine.Vector3 val_10 = val_5[32].position;
            UnityEngine.Vector3 val_13 = UnityEngine.Vector3.MoveTowards(current:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, target:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, maxDistanceDelta:  UnityEngine.Time.deltaTime * this.attractionSpeed);
            val_5[32].position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
            UnityEngine.Vector3 val_14 = val_5[32].position;
            if((UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z})) < 0)
        {
                if(this.destroyWhenReached != false)
        {
                val_5[32].remainingLifetime = 0.01f;
        }
        
            val_16 = val_16 + 1;
            if(this.OnParticleHitCallback != null)
        {
                this.OnParticleHitCallback.Invoke();
        }
        
        }
        
            val_21 = val_21 + 1;
        }
        while(val_21 < (long)val_6);
        
        }
        else
        {
                val_16 = 0;
        }
        
        this.PS.SetParticles(particles:  val_5, size:  val_6);
        val_22 = val_6 - val_16;
        if(val_22 > 0)
        {
                return;
        }
        
        if(this.OnParticleHitsCompleteCallback == null)
        {
                return;
        }
        
        this.OnParticleHitsCompleteCallback.Invoke();
    }
    public UnityEngine.Vector3 GetXYTargetPosition(UnityEngine.Vector3 pos)
    {
        UnityEngine.Vector3 val_1 = this.endPoint.position;
        UnityEngine.Vector3 val_2 = this.endPoint.position;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_1.x, y:  val_2.y, z:  pos.z);
        return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public ParticleAttraction()
    {
        this.attractionSpeed = 1f;
        this.destroyRadius = 0.05f;
    }

}
