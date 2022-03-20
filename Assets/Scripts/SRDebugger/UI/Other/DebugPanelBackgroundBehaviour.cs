using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class DebugPanelBackgroundBehaviour : SRMonoBehaviour
    {
        // Fields
        private string _defaultKey;
        private bool _isTransparent;
        private SRF.UI.StyleComponent _styleComponent;
        public string TransparentStyleKey;
        
        // Methods
        private void Awake()
        {
            this._styleComponent = this.GetComponent<SRF.UI.StyleComponent>();
            this._defaultKey = val_1._styleKey;
            this.Update();
        }
        private void Update()
        {
            if(this._isTransparent == false)
            {
                goto label_0;
            }
            
            label_8:
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._enableBackgroundTransparency == true)
            {
                    return;
            }
            
            this._styleComponent.StyleKey = this._defaultKey;
            this._isTransparent = false;
            return;
            label_0:
            SRDebugger.Settings val_2 = SRDebugger.Settings.Instance;
            if(val_2._enableBackgroundTransparency != false)
            {
                    this._styleComponent.StyleKey = this.TransparentStyleKey;
                this._isTransparent = true;
                return;
            }
            
            if(this._isTransparent == true)
            {
                goto label_8;
            }
        
        }
        public DebugPanelBackgroundBehaviour()
        {
            this.TransparentStyleKey = "";
            this = new UnityEngine.MonoBehaviour();
        }
    
    }

}
