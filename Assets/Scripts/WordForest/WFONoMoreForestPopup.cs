using UnityEngine;

namespace WordForest
{
    public class WFONoMoreForestPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button playButton;
        private UnityEngine.UI.Text playButtonText;
        
        // Methods
        private void Start()
        {
            this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONoMoreForestPopup::OnPlayButtonClicked()));
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONoMoreForestPopup::OnCloseButtonClicked()));
            string val_4 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        }
        private void OnPlayButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnCloseButtonClicked()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFONoMoreForestPopup()
        {
        
        }
    
    }

}
