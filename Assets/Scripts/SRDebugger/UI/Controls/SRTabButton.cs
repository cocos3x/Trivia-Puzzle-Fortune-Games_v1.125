using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class SRTabButton : SRMonoBehaviourEx
    {
        // Fields
        public UnityEngine.Behaviour ActiveToggle;
        public UnityEngine.UI.Button Button;
        public UnityEngine.RectTransform ExtraContentContainer;
        public SRF.UI.StyleComponent IconStyleComponent;
        public UnityEngine.UI.Text TitleText;
        
        // Properties
        public bool IsActive { get; set; }
        
        // Methods
        public bool get_IsActive()
        {
            if(this.ActiveToggle != null)
            {
                    return this.ActiveToggle.enabled;
            }
            
            throw new NullReferenceException();
        }
        public void set_IsActive(bool value)
        {
            if(this.ActiveToggle != null)
            {
                    this.ActiveToggle.enabled = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public SRTabButton()
        {
        
        }
    
    }

}
