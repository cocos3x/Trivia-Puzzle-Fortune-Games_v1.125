using UnityEngine;

namespace SRF.UI
{
    public abstract class ResponsiveBase : SRMonoBehaviour
    {
        // Fields
        private bool _queueRefresh;
        
        // Properties
        protected UnityEngine.RectTransform RectTransform { get; }
        
        // Methods
        protected UnityEngine.RectTransform get_RectTransform()
        {
            UnityEngine.Transform val_1 = this.CachedTransform;
            if(val_1 == null)
            {
                    return (UnityEngine.RectTransform)val_1;
            }
            
            if(null == null)
            {
                    return (UnityEngine.RectTransform)val_1;
            }
        
        }
        protected void OnEnable()
        {
            this._queueRefresh = true;
        }
        protected void OnRectTransformDimensionsChange()
        {
            this._queueRefresh = true;
        }
        protected void Update()
        {
            if(this._queueRefresh == false)
            {
                    return;
            }
            
            this._queueRefresh = false;
        }
        protected abstract void Refresh(); // 0
        private void DoRefresh()
        {
            goto typeof(SRF.UI.ResponsiveBase).__il2cppRuntimeField_170;
        }
        protected ResponsiveBase()
        {
        
        }
    
    }

}
