using UnityEngine;

namespace EpicToonFX
{
    public class ETFXLightFade : MonoBehaviour
    {
        // Fields
        public float life;
        public bool killAfterLife;
        private UnityEngine.Light li;
        private float initIntensity;
        
        // Methods
        private void Start()
        {
            UnityEngine.GameObject val_4 = this.gameObject;
            if((UnityEngine.Object.op_Implicit(exists:  this.gameObject.GetComponent<UnityEngine.Light>())) != false)
            {
                    UnityEngine.Light val_5 = val_4.GetComponent<UnityEngine.Light>();
                this.li = val_5;
                this.initIntensity = val_5.intensity;
                return;
            }
            
            UnityEngine.MonoBehaviour.print(message:  "No light object found on " + val_4.name);
        }
        private void Update()
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.gameObject.GetComponent<UnityEngine.Light>())) == false)
            {
                    return;
            }
            
            float val_5 = UnityEngine.Time.deltaTime;
            val_5 = val_5 / this.life;
            val_5 = this.initIntensity * val_5;
            val_5 = this.li.intensity - val_5;
            this.li.intensity = val_5;
            if(this.killAfterLife == false)
            {
                    return;
            }
            
            if(this.li.intensity > 0f)
            {
                    return;
            }
            
            UnityEngine.Object.Destroy(obj:  this.gameObject.GetComponent<UnityEngine.Light>());
        }
        public ETFXLightFade()
        {
            this.life = 0.2f;
            this.killAfterLife = true;
        }
    
    }

}
