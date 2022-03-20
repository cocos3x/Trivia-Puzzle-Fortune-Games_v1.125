using UnityEngine;

namespace SRF.UI
{
    public class LongPressButton : Button
    {
        // Fields
        private bool _handled;
        private UnityEngine.UI.Button.ButtonClickedEvent _onLongPress;
        private bool _pressed;
        private float _pressedTime;
        public float LongPressDuration;
        
        // Properties
        public UnityEngine.UI.Button.ButtonClickedEvent onLongPress { get; set; }
        
        // Methods
        public UnityEngine.UI.Button.ButtonClickedEvent get_onLongPress()
        {
            return (ButtonClickedEvent)this._onLongPress;
        }
        public void set_onLongPress(UnityEngine.UI.Button.ButtonClickedEvent value)
        {
            this._onLongPress = value;
        }
        public override void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnPointerExit(eventData:  eventData);
            this._pressed = false;
        }
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnPointerDown(eventData:  eventData);
            if((eventData.<button>k__BackingField) != 0)
            {
                    return;
            }
            
            this._pressed = true;
            this._handled = false;
            this._pressedTime = UnityEngine.Time.realtimeSinceStartup;
        }
        public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this._handled != true)
            {
                    this.OnPointerUp(eventData:  eventData);
            }
            
            this._pressed = false;
        }
        public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this._handled != false)
            {
                    return;
            }
            
            this.OnPointerClick(eventData:  eventData);
        }
        private void Update()
        {
            if(this._pressed == false)
            {
                    return;
            }
            
            float val_1 = UnityEngine.Time.realtimeSinceStartup;
            val_1 = val_1 - this._pressedTime;
            if(val_1 < this.LongPressDuration)
            {
                    return;
            }
            
            this._pressed = false;
            this._handled = true;
            this._onLongPress.Invoke();
        }
        public LongPressButton()
        {
            this._onLongPress = new Button.ButtonClickedEvent();
            this.LongPressDuration = 0.9f;
        }
    
    }

}
