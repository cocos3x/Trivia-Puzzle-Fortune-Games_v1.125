using UnityEngine;

namespace EpicToonFX
{
    public class ETFXRotation : MonoBehaviour
    {
        // Fields
        public UnityEngine.Vector3 rotateVector;
        public EpicToonFX.ETFXRotation.spaceEnum rotateSpace;
        
        // Methods
        private void Start()
        {
        
        }
        private void Update()
        {
            spaceEnum val_7 = this.rotateSpace;
            if(val_7 == 0)
            {
                    UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.rotateVector, y = V9.16B, z = V10.16B}, d:  UnityEngine.Time.deltaTime);
                this.transform.Rotate(eulers:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
                val_7 = this.rotateSpace;
            }
            
            if(val_7 != 1)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.rotateVector, y = V9.16B, z = V10.16B}, d:  UnityEngine.Time.deltaTime);
            this.transform.Rotate(eulers:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, relativeTo:  0);
        }
        public ETFXRotation()
        {
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            this.rotateVector = val_1;
            mem[1152921519629390716] = val_1.y;
            mem[1152921519629390720] = val_1.z;
        }
    
    }

}
