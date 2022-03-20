using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class MultiTapButton : Button
    {
        // Fields
        private float _lastTap;
        private int _tapCount;
        public int RequiredTapCount;
        public float ResetTime;
        
        // Methods
        public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            float val_1 = UnityEngine.Time.unscaledTime;
            val_1 = val_1 - this._lastTap;
            if(val_1 > this.ResetTime)
            {
                    this._tapCount = 0;
            }
            
            int val_3 = this._tapCount;
            this._lastTap = UnityEngine.Time.unscaledTime;
            val_3 = val_3 + 1;
            this._tapCount = val_3;
            if(val_3 != this.RequiredTapCount)
            {
                    return;
            }
            
            this.OnPointerClick(eventData:  eventData);
            this._tapCount = 0;
        }
        public MultiTapButton()
        {
            this.RequiredTapCount = 3;
            this.ResetTime = 0.5f;
        }
    
    }

}
