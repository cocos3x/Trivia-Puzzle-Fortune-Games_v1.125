using UnityEngine;

namespace SRF.UI
{
    public class SRNumberSpinner : InputField
    {
        // Fields
        private double _currentValue;
        private double _dragStartAmount;
        private double _dragStep;
        public float DragSensitivity;
        public double MaxValue;
        public double MinValue;
        
        // Methods
        protected override void Awake()
        {
            this.Awake();
            if(0 == 2)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "[SRNumberSpinner] contentType must be integer or decimal. Defaulting to integer");
            this.contentType = 3;
        }
        public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(true == 0)
            {
                    return;
            }
            
            if((eventData.<dragging>k__BackingField) != false)
            {
                    return;
            }
            
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(selected:  this.gameObject, pointer:  eventData);
            this.OnPointerClick(eventData:  eventData);
            if(this != null)
            {
                    if(this.active != false)
            {
                    this.UpdateLabel();
                eventData.Use();
                return;
            }
            
            }
            
            this.OnSelect(eventData:  eventData);
        }
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
        
        }
        public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
        
        }
        public override void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            var val_12;
            UnityEngine.EventSystems.BaseEventData val_13;
            float val_14;
            var val_15;
            val_13 = eventData;
            if(true == 0)
            {
                    return;
            }
            
            if(System.Math.Abs(S8) > (System.Math.Abs(eventData.<delta>k__BackingField)))
            {
                    UnityEngine.Transform val_2 = this.transform.parent;
                if(val_2 == 0)
            {
                    return;
            }
            
                val_12 = 1152921504818294784;
                UnityEngine.GameObject val_5 = UnityEngine.EventSystems.ExecuteEvents.GetEventHandler<UnityEngine.EventSystems.IBeginDragHandler>(root:  val_2.gameObject);
                eventData.<pointerDrag>k__BackingField = val_5;
                if(val_5 == 0)
            {
                    return;
            }
            
                val_15 = null;
                val_15 = null;
                bool val_7 = UnityEngine.EventSystems.ExecuteEvents.Execute<UnityEngine.EventSystems.IBeginDragHandler>(target:  eventData.<pointerDrag>k__BackingField, eventData:  val_13, functor:  UnityEngine.EventSystems.ExecuteEvents.s_BeginDragHandler);
                return;
            }
            
            val_13.Use();
            double val_8 = System.Double.Parse(s:  val_13);
            this._dragStartAmount = val_8;
            this._currentValue = val_8;
            val_14 = val_8;
            this._dragStep = System.Math.Max(val1:  (1152921504620371968 == 2) ? 10 : 1, val2:  val_14 * 0.0500000007450581);
            if(4 == 0)
            {
                    return;
            }
            
            this.DeactivateInputField();
        }
        public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            float val_2;
            float val_7;
            float val_8;
            double val_9;
            if(true == 0)
            {
                    return;
            }
            
            double val_7 = System.Math.Abs(this._dragStep);
            val_7 = val_7 * ((double)eventData.<delta>k__BackingField);
            double val_8 = (double)this.DragSensitivity;
            val_8 = val_7 * val_8;
            val_8 = this._currentValue + val_8;
            this._currentValue = val_8;
            double val_1 = System.Math.Round(value:  val_8, digits:  2);
            val_7 = val_1;
            this._currentValue = val_1;
            if(val_1 > this.MaxValue)
            {
                    val_7 = this.MaxValue;
                mem2[0] = this.MaxValue;
            }
            
            if(val_7 < 0)
            {
                    val_7 = this.MinValue;
                mem2[0] = this.MinValue;
            }
            
            if(val_7 >= 0f)
            {
                goto label_10;
            }
            
            if(val_7 != (-0.5))
            {
                goto label_11;
            }
            
            val_8 = val_2;
            val_9 = -1;
            goto label_12;
            label_10:
            if(val_7 != 0.5)
            {
                goto label_14;
            }
            
            val_8 = val_2;
            val_9 = 1;
            label_12:
            val_9 = val_8 + val_9;
            val_8 = (((long)val_8 & 1) != 0) ? (val_8) : (val_9);
            goto label_16;
            label_11:
            double val_4 = val_7 + (-0.5);
            goto label_16;
            label_14:
            double val_5 = val_7 + 0.5;
            label_16:
            val_5 = (val_5 == Infinity) ? (-val_5) : (val_5);
            this.text = (int)val_5.ToString();
        }
        public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(W8 == 0)
            {
                    return;
            }
            
            eventData.Use();
            if(this._dragStartAmount == this._currentValue)
            {
                    return;
            }
            
            this.DeactivateInputField();
            this.SendOnSubmit();
        }
        public SRNumberSpinner()
        {
            this.DragSensitivity = 0.01f;
            this.MaxValue = ;
            this.MinValue = -1.79769313486232E+308;
        }
    
    }

}
