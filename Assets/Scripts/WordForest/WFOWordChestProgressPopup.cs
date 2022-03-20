using UnityEngine;

namespace WordForest
{
    public class WFOWordChestProgressPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button chestRewardsButton;
        private UnityEngine.UI.Text titleText;
        private UnityEngine.UI.Text rewardsAmountText;
        private UnityEngine.UI.Text wordsRemainingText;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordChestProgressPopup::OnCloseButtonClicked()));
            this.chestRewardsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordChestProgressPopup::OnRewardsButtonClicked()));
            Player val_3 = App.Player;
            WordForest.WFOGameEcon val_7 = WordForest.WFOGameEcon.Instance;
            string val_9 = System.String.Format(format:  "Contains {0} Rewards!", arg0:  val_7.wordChestRewardAmount.Item[System.String.Format(format:  "{0} CHEST", arg0:  null.ToString().ToUpper())]);
            object val_10 = W24 - W25;
            string val_12 = System.String.Format(format:  "Make {0} More Word{1} to open!", arg0:  val_10, arg1:  (val_10 == 1) ? "" : "s");
        }
        private void OnCloseButtonClicked()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnRewardsButtonClicked()
        {
            GameBehavior val_1 = App.getBehavior;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public WFOWordChestProgressPopup()
        {
        
        }
    
    }

}
