using UnityEngine;

namespace SRF.UI
{
    public sealed class StyleRoot : SRMonoBehaviour
    {
        // Fields
        private SRF.UI.StyleSheet _activeStyleSheet;
        public SRF.UI.StyleSheet StyleSheet;
        
        // Methods
        public SRF.UI.Style GetStyle(string key)
        {
            if(this.StyleSheet != 0)
            {
                    return this.StyleSheet.GetStyle(key:  key, searchParent:  true);
            }
            
            UnityEngine.Debug.LogWarning(message:  "[StyleRoot] StyleSheet is not set.", context:  this);
            return 0;
        }
        private void OnEnable()
        {
            this._activeStyleSheet = 0;
            if(this.StyleSheet == 0)
            {
                    return;
            }
            
            this.OnStyleSheetChanged();
        }
        private void OnDisable()
        {
            this.OnStyleSheetChanged();
        }
        private void Update()
        {
            if(this._activeStyleSheet == this.StyleSheet)
            {
                    return;
            }
            
            this.OnStyleSheetChanged();
        }
        private void OnStyleSheetChanged()
        {
            this._activeStyleSheet = this.StyleSheet;
            this.BroadcastMessage(methodName:  "SRStyleDirty", options:  1);
        }
        public void SetDirty()
        {
            this._activeStyleSheet = 0;
        }
        public StyleRoot()
        {
        
        }
    
    }

}
