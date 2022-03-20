using UnityEngine;
public class ParticlePositionToPoint : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform attractionPoint;
    private UnityEngine.ParticleSystem myParticleSystem;
    private UnityEngine.ParticleSystem.Particle[] myParticles;
    
    // Methods
    public void SetAttractionPoint(UnityEngine.Transform newPoint)
    {
        this.attractionPoint = newPoint;
    }
    private void LateUpdate()
    {
        if(this.myParticleSystem.isPlaying == false)
        {
                return;
        }
        
        int val_2 = this.myParticleSystem.GetParticles(particles:  this.myParticles);
        UnityEngine.Vector3 val_3 = this.attractionPoint.position;
        if(val_2 >= 1)
        {
                var val_18 = 0;
            var val_19 = 32;
            do
        {
            UnityEngine.Vector3 val_4 = this.myParticles[val_19].position;
            UnityEngine.Vector3 val_5 = this.myParticles[val_19].position;
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, d:  this.myParticles[val_19].remainingLifetime);
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, d:  UnityEngine.Time.deltaTime);
            UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            if((((((System.Single.IsNaN(f:  val_11.x)) != true) && ((System.Single.IsNaN(f:  val_11.y)) != true)) && ((System.Single.IsNaN(f:  val_11.z)) != true)) && ((System.Single.IsInfinity(f:  val_11.x)) != true)) && ((System.Single.IsInfinity(f:  val_11.y)) != true))
        {
                if((System.Single.IsInfinity(f:  val_11.z)) != true)
        {
                this.myParticles[val_19].position = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
        }
        
        }
        
            val_18 = val_18 + 1;
            val_19 = val_19 + 132;
        }
        while(val_18 < (long)val_2);
        
        }
        
        this.myParticleSystem.SetParticles(particles:  this.myParticles, size:  val_2);
    }
    public ParticlePositionToPoint()
    {
        this.myParticles = new Particle[1000];
    }

}
