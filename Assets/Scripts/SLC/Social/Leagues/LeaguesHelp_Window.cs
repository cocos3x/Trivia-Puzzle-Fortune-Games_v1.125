using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesHelp_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesHelp_Window::<Start>b__1_0()));
        }
        public LeaguesHelp_Window()
        {
        
        }
        private void <Start>b__1_0()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
