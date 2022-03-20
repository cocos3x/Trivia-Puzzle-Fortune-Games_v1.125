using UnityEngine;

namespace WordForest
{
    public class WFOForestInfoPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button okButton;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestInfoPopup::CloseWindow()));
            this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestInfoPopup::CloseWindow()));
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFOForestInfoPopup()
        {
        
        }
    
    }

}
