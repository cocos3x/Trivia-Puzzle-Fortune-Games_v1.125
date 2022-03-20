using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class LoadingSpinnerBehaviour : SRMonoBehaviour
    {
        // Fields
        private float _dt;
        public int FrameCount;
        public float SpinDuration;
        
        // Methods
        private void Update()
        {
            float val_1 = UnityEngine.Time.unscaledDeltaTime;
            val_1 = this._dt + val_1;
            this._dt = val_1;
            UnityEngine.Quaternion val_3 = this.CachedTransform.localRotation;
            UnityEngine.Vector3 val_4 = val_3.x.eulerAngles;
            int val_7 = this.FrameCount;
            float val_9 = this._dt;
            val_7 = this.SpinDuration / (float)val_7;
            if(val_9 <= val_7)
            {
                    return;
            }
            
            float val_10 = val_4.z;
            float val_8 = 360f;
            val_8 = val_8 / (float)val_7;
            do
            {
                val_9 = val_9 - val_7;
                val_10 = val_10 - val_8;
            }
            while(val_9 > val_7);
            
            this._dt = val_9;
            this = this.CachedTransform;
            UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.Euler(x:  val_4.x, y:  val_4.y, z:  val_10);
            this.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
        }
        public LoadingSpinnerBehaviour()
        {
            this.FrameCount = 12;
            this.SpinDuration = 7.346868E-41f;
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
