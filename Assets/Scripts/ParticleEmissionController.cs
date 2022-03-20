using UnityEngine;
public class ParticleEmissionController : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem particles;
    
    // Methods
    public void PlayEffects()
    {
        if(this.particles != null)
        {
                this.particles.Play();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void StopEffects()
    {
        if(this.particles != null)
        {
                this.particles.Stop();
            return;
        }
        
        throw new NullReferenceException();
    }
    public ParticleEmissionController()
    {
    
    }

}
