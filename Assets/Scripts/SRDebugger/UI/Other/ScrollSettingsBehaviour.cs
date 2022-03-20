using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class ScrollSettingsBehaviour : MonoBehaviour
    {
        // Fields
        public const float ScrollSensitivity = 40;
        
        // Methods
        private void Awake()
        {
            UnityEngine.UI.ScrollRect val_1 = this.GetComponent<UnityEngine.UI.ScrollRect>();
            val_1.m_ScrollSensitivity = 40f;
            if(SRDebugger.Internal.SRDebuggerUtil.IsMobilePlatform == true)
            {
                    return;
            }
            
            val_1.m_MovementType = 2;
            val_1.m_Inertia = false;
        }
        public ScrollSettingsBehaviour()
        {
        
        }
    
    }

}
