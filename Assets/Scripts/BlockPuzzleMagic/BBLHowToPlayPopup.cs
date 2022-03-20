using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLHowToPlayPopup : WGHowToPlayPopup
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        
        // Methods
        private void Awake()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLHowToPlayPopup::OnClosePressed()));
        }
        private void OnClosePressed()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public BBLHowToPlayPopup()
        {
        
        }
    
    }

}
