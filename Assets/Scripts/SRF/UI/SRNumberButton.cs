using UnityEngine;

namespace SRF.UI
{
    public class SRNumberButton : Button, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
    {
        // Fields
        private const float ExtraThreshold = 3;
        public const float Delay = 0.4;
        private float _delayTime;
        private float _downTime;
        private bool _isDown;
        public double Amount;
        public SRF.UI.SRNumberSpinner TargetField;
        
        // Methods
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnPointerDown(eventData:  eventData);
            if(W8 == 0)
            {
                    return;
            }
            
            this.Apply();
            this._isDown = true;
            float val_1 = UnityEngine.Time.realtimeSinceStartup;
            this._downTime = val_1;
            val_1 = val_1 + 0.4f;
            this._delayTime = val_1;
        }
        public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnPointerUp(eventData:  eventData);
            this._isDown = false;
        }
        protected virtual void Update()
        {
            float val_5;
            float val_6;
            if(this._isDown == false)
            {
                    return;
            }
            
            val_5 = this._delayTime;
            if(val_5 > UnityEngine.Time.realtimeSinceStartup)
            {
                    return;
            }
            
            this.Apply();
            float val_2 = UnityEngine.Time.realtimeSinceStartup;
            val_2 = val_2 - this._downTime;
            val_6 = val_2 / 3f;
            int val_3 = UnityEngine.Mathf.RoundToInt(f:  val_6);
            val_5 = 0.2f;
            if(val_3 >= 1)
            {
                    val_6 = 0.5f;
                do
            {
                val_3 = val_3 - 1;
                val_5 = val_5 * val_6;
            }
            while(val_3 != 1);
            
            }
            
            float val_4 = UnityEngine.Time.realtimeSinceStartup;
            val_4 = val_5 + val_4;
            this._delayTime = val_4;
        }
        private void Apply()
        {
            double val_3 = (System.Double.Parse(s:  static_value_02807000)) + this.Amount;
            if(val_3 > this.TargetField.MaxValue)
            {
                    val_3 = this.TargetField.MaxValue;
            }
            
            string val_2 = this.TargetField.MinValue.ToString();
            this.TargetField.text = val_2;
            this.TargetField.Invoke(arg0:  val_2);
        }
        public SRNumberButton()
        {
            this.Amount = 1;
        }
    
    }

}
