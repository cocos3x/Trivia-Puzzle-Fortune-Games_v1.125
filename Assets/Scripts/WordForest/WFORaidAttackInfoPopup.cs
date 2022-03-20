using UnityEngine;

namespace WordForest
{
    public class WFORaidAttackInfoPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFORaidAttackInfoPopup::CloseWindow()));
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFORaidAttackInfoPopup()
        {
        
        }
    
    }

}
