using UnityEngine;

namespace WordForest
{
    public class WFOWordChestRewardsPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button okayButton;
        private UnityEngine.Transform scrollViewParent;
        private WordForest.WFOChestRewardItem rewardItemPrefab;
        private UnityEngine.GameObject islandParadiseGroup;
        
        // Methods
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordChestRewardsPopup::CloseWindow()));
            this.okayButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOWordChestRewardsPopup::CloseWindow()));
        }
        private void OnEnable()
        {
            this.ToggleItemStates();
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void ToggleItemStates()
        {
            var val_2;
            if(IslandParadiseEventHandler.IsEventActive != false)
            {
                    val_2 = 1;
            }
            else
            {
                    val_2 = 0;
            }
            
            this.islandParadiseGroup.SetActive(value:  false);
        }
        public WFOWordChestRewardsPopup()
        {
        
        }
    
    }

}
