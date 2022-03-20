using UnityEngine;

namespace WordForest
{
    public class WFOAcornInfoPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button okButton;
        private UnityEngine.UI.Text unlockLevelText;
        
        // Methods
        private void Start()
        {
            int val_7;
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOAcornInfoPopup::CloseWindow()));
            this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOAcornInfoPopup::CloseWindow()));
            if(WordForest.WFOGameEcon.Instance != null)
            {
                    WordForest.WFOGameEcon val_4 = WordForest.WFOGameEcon.Instance;
                val_7 = val_4.wordStreakUnlockLevel;
            }
            else
            {
                    val_7 = 2;
            }
            
            string val_6 = System.String.Format(format:  Localization.Localize(key:  "unlock_forest_level", defaultValue:  "Unlocks at Forest Level {0}", useSingularKey:  false), arg0:  val_7);
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFOAcornInfoPopup()
        {
        
        }
    
    }

}
