using UnityEngine;

namespace SRF.UI
{
    public class SRSpinner : Selectable, IDragHandler, IEventSystemHandler, IBeginDragHandler
    {
        // Fields
        private float _dragDelta;
        private SRF.UI.SRSpinner.SpinEvent _onSpinDecrement;
        private SRF.UI.SRSpinner.SpinEvent _onSpinIncrement;
        public float DragThreshold;
        
        // Properties
        public SRF.UI.SRSpinner.SpinEvent OnSpinIncrement { get; set; }
        public SRF.UI.SRSpinner.SpinEvent OnSpinDecrement { get; set; }
        
        // Methods
        public SRF.UI.SRSpinner.SpinEvent get_OnSpinIncrement()
        {
            return (SpinEvent)this._onSpinIncrement;
        }
        public void set_OnSpinIncrement(SRF.UI.SRSpinner.SpinEvent value)
        {
            this._onSpinIncrement = value;
        }
        public SRF.UI.SRSpinner.SpinEvent get_OnSpinDecrement()
        {
            return (SpinEvent)this._onSpinDecrement;
        }
        public void set_OnSpinDecrement(SRF.UI.SRSpinner.SpinEvent value)
        {
            this._onSpinDecrement = value;
        }
        public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this._dragDelta = 0f;
        }
        public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(true == 0)
            {
                    return;
            }
            
            float val_1 = this._dragDelta + (eventData.<delta>k__BackingField);
            this._dragDelta = val_1;
            if(System.Math.Abs(val_1) <= this.DragThreshold)
            {
                    return;
            }
            
            float val_2 = UnityEngine.Mathf.Sign(f:  this._dragDelta);
            float val_5 = System.Math.Abs(this._dragDelta);
            val_5 = val_5 / this.DragThreshold;
            int val_3 = UnityEngine.Mathf.FloorToInt(f:  val_5);
            if(val_2 > 0f)
            {
                    this.OnIncrement(amount:  val_3);
            }
            else
            {
                    this.OnDecrement(amount:  val_3);
            }
            
            float val_6 = this.DragThreshold;
            val_6 = val_6 * (float)val_3;
            val_6 = val_2 * val_6;
            val_6 = this._dragDelta - val_6;
            this._dragDelta = val_6;
        }
        private void OnIncrement(int amount)
        {
            if(amount < 1)
            {
                    return;
            }
            
            var val_1 = 0;
            do
            {
                this._onSpinIncrement.Invoke();
                val_1 = val_1 + 1;
            }
            while(val_1 < amount);
        
        }
        private void OnDecrement(int amount)
        {
            if(amount < 1)
            {
                    return;
            }
            
            var val_1 = 0;
            do
            {
                this._onSpinDecrement.Invoke();
                val_1 = val_1 + 1;
            }
            while(val_1 < amount);
        
        }
        public SRSpinner()
        {
            this._onSpinDecrement = new SRSpinner.SpinEvent();
            this._onSpinIncrement = new SRSpinner.SpinEvent();
            this.DragThreshold = 20f;
        }
    
    }

}
