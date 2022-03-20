using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ProfilerGraphAxisLabel : SRMonoBehaviourEx
    {
        // Fields
        private float _prevFrameTime;
        private System.Nullable<float> _queuedFrameTime;
        private float _yPosition;
        public UnityEngine.UI.Text Text;
        
        // Methods
        protected override void Update()
        {
            this.Update();
            if(true == 0)
            {
                    return;
            }
            
            this.SetValueInternal(frameTime:  this._queuedFrameTime.Value);
            this._queuedFrameTime = 0;
        }
        public void SetValue(float frameTime, float yPosition)
        {
            if(this._prevFrameTime == frameTime)
            {
                    if(this._yPosition == yPosition)
            {
                    return;
            }
            
            }
            
            System.Nullable<System.Single> val_1 = new System.Nullable<System.Single>(value:  frameTime);
            this._yPosition = yPosition;
            this._queuedFrameTime = val_1.HasValue;
        }
        private void SetValueInternal(float frameTime)
        {
            this._prevFrameTime = frameTime;
            float val_9 = 1000f;
            val_9 = frameTime * val_9;
            float val_10 = 1f;
            val_10 = val_10 / frameTime;
            object[] val_3 = new object[2];
            val_3[0] = UnityEngine.Mathf.FloorToInt(f:  val_9);
            val_3[1] = UnityEngine.Mathf.RoundToInt(f:  val_10);
            string val_4 = System.String.Format(format:  "{0}ms ({1}FPS)", args:  val_3);
            UnityEngine.Transform val_5 = this.CachedTransform;
            if(null == null)
            {
                    UnityEngine.Rect val_6 = val_5.rect;
                float val_7 = val_6.m_XMin.width;
                val_7 = val_7 * 0.5f;
                val_7 = val_7 + 10f;
                UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  val_7, y:  this._yPosition);
                val_5.anchoredPosition = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
                return;
            }
        
        }
        public ProfilerGraphAxisLabel()
        {
        
        }
    
    }

}
