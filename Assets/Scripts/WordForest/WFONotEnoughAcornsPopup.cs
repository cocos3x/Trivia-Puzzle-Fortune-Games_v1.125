using UnityEngine;

namespace WordForest
{
    public class WFONotEnoughAcornsPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button playButton;
        private UnityEngine.UI.Text playButtonText;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONotEnoughAcornsPopup::OnCloseButtonClicked()));
            this.playButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONotEnoughAcornsPopup::OnPlayButtonClicked()));
            string val_4 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        }
        private void OnCloseButtonClicked()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnPlayButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFONotEnoughAcornsPopup()
        {
        
        }
    
    }

}
