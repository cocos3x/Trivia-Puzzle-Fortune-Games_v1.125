using UnityEngine;

namespace SRF.UI
{
    public class DragHandle : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
    {
        // Fields
        private UnityEngine.UI.CanvasScaler _canvasScaler;
        private float _delta;
        private float _startValue;
        public UnityEngine.RectTransform.Axis Axis;
        public bool Invert;
        public float MaxSize;
        public UnityEngine.UI.LayoutElement TargetLayoutElement;
        public UnityEngine.RectTransform TargetRectTransform;
        
        // Properties
        private float Mult { get; }
        
        // Methods
        private float get_Mult()
        {
            return (float)(this.Invert == false) ? 1f : -1f;
        }
        public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.Verify() == false)
            {
                    return;
            }
            
            this._startValue = this.GetCurrentValue();
            this._delta = 0f;
        }
        public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            float val_11;
            if(this.Verify() == false)
            {
                    return;
            }
            
            val_11 = ((this.Axis == 0) ? eventData.<delta>k__BackingField : (eventData + 244)) + 0f;
            if(this._canvasScaler != 0)
            {
                    val_11 = val_11 / this._canvasScaler.m_ScaleFactor;
            }
            
            float val_5 = (this.Invert == false) ? 1f : -1f;
            val_5 = val_11 * val_5;
            float val_6 = this._delta + val_5;
            this._delta = val_6;
            this.SetCurrentValue(value:  UnityEngine.Mathf.Clamp(value:  this._startValue + val_6, min:  this.GetMinSize(), max:  (this.MaxSize > 0f) ? this.MaxSize : 3.402823E+38f));
        }
        public void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.Verify() == false)
            {
                    return;
            }
            
            this.SetCurrentValue(value:  UnityEngine.Mathf.Max(a:  this._startValue + this._delta, b:  this.GetMinSize()));
            this._delta = 0f;
            this.CommitCurrentValue();
        }
        private void Start()
        {
            bool val_1 = this.Verify();
            this._canvasScaler = this.GetComponentInParent<UnityEngine.UI.CanvasScaler>();
        }
        private bool Verify()
        {
            var val_3;
            if(this.TargetLayoutElement == 0)
            {
                    if(this.TargetRectTransform == 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "DragHandle: TargetLayoutElement and TargetRectTransform are both null. Disabling behaviour.");
                this.enabled = false;
                val_3 = 0;
                return (bool)val_3;
            }
            
            }
            
            val_3 = 1;
            return (bool)val_3;
        }
        private float GetCurrentValue()
        {
            RectTransform.Axis val_11;
            if(this.TargetLayoutElement == 0)
            {
                goto label_3;
            }
            
            if(this.Axis == 0)
            {
                goto label_5;
            }
            
            goto label_6;
            label_3:
            if(this.TargetRectTransform == 0)
            {
                    throw new System.InvalidOperationException();
            }
            
            val_11 = this.Axis;
            UnityEngine.Vector2 val_3 = this.TargetRectTransform.sizeDelta;
            if(val_11 == 0)
            {
                    return (float)S0;
            }
            
            return (float)S0;
            label_5:
            label_6:
            val_11 = ???;
            goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_360;
        }
        private void SetCurrentValue(float value)
        {
            if(this.TargetLayoutElement == 0)
            {
                goto label_3;
            }
            
            if(this.Axis == 0)
            {
                goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_370;
            }
            
            goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_370;
            label_3:
            if(this.TargetRectTransform == 0)
            {
                    throw new System.InvalidOperationException();
            }
            
            UnityEngine.Vector2 val_3 = this.TargetRectTransform.sizeDelta;
            this.TargetRectTransform.sizeDelta = new UnityEngine.Vector2() {x = (this.Axis == 0) ? value : val_3.x, y = (this.Axis == 0) ? val_3.y : value};
        }
        private void CommitCurrentValue()
        {
            if(this.TargetLayoutElement == 0)
            {
                    return;
            }
            
            UnityEngine.Transform val_2 = this.TargetLayoutElement.transform;
            if(null != null)
            {
                goto label_10;
            }
            
            if(this.Axis == 0)
            {
                goto label_7;
            }
            
            if(null != null)
            {
                goto label_10;
            }
            
            UnityEngine.Vector2 val_3 = val_2.sizeDelta;
            goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_370;
            label_7:
            if(null != null)
            {
                goto label_10;
            }
            
            UnityEngine.Vector2 val_4 = val_2.sizeDelta;
            goto typeof(UnityEngine.UI.LayoutElement).__il2cppRuntimeField_370;
            label_10:
        }
        private float GetMinSize()
        {
            if(this.TargetLayoutElement == 0)
            {
                    return 0f;
            }
            
            if(this.Axis != 0)
            {
                
            }
        
        }
        private float GetMaxSize()
        {
            return (float)(this.MaxSize > 0f) ? this.MaxSize : 3.402823E+38f;
        }
        public DragHandle()
        {
            this.MaxSize = -1f;
        }
    
    }

}
