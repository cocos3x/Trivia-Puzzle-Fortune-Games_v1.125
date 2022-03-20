using UnityEngine;

namespace WordForest
{
    public class WFOWordStreakInfoPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button okButton;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordStreakInfoPopup::CloseWindow()));
            this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordStreakInfoPopup::CloseWindow()));
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFOWordStreakInfoPopup()
        {
        
        }
    
    }

}
