using UnityEngine;

namespace WordForest
{
    public class WFOSeedParticles : MonoBehaviour
    {
        // Fields
        private UnityEngine.ParticleSystem trailParticles;
        private UnityEngine.ParticleSystem burstParticles;
        private UnityEngine.Transform trailDestination;
        private float staggerDuration;
        
        // Methods
        public void PlayParticles(UnityEngine.Vector3 destinationPosition, int particleCount)
        {
            DG.Tweening.TweenCallback val_5;
            float val_6 = destinationPosition.z;
            this.trailDestination.position = new UnityEngine.Vector3() {x = destinationPosition.x, y = destinationPosition.y, z = val_6};
            if(particleCount >= 1)
            {
                    var val_6 = 0;
                do
            {
                val_6 = this.staggerDuration;
                DG.Tweening.TweenCallback val_1 = null;
                val_5 = val_1;
                val_1 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOSeedParticles::<PlayParticles>b__4_1());
                float val_5 = 0f;
                val_5 = val_6 * val_5;
                DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  val_5, callback:  val_1, ignoreTimeScale:  true);
                val_6 = val_6 + 1;
            }
            while(particleCount != val_6);
            
            }
            
            this.burstParticles.Play();
            DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  4f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOSeedParticles::<PlayParticles>b__4_0()), ignoreTimeScale:  true);
        }
        public WFOSeedParticles()
        {
        
        }
        private void <PlayParticles>b__4_1()
        {
            if(this.trailParticles != null)
            {
                    this.trailParticles.Emit(count:  1);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <PlayParticles>b__4_0()
        {
            UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
    
    }

}
