using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesRankup_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text titleText;
        private UnityEngine.UI.Button continueButton;
        private SLC.Minigames.MinigameRankSpriteDisplay rankSpriteDisplay;
        
        // Methods
        private void Start()
        {
            this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesRankup_Window::OnClick_ContinueButton()));
        }
        private void OnClick_ContinueButton()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleCheckpointRankUpContinue();
            this.gameObject.SetActive(value:  false);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnEnable()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            SLC.Minigames.MinigameLevelRank val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetNextRank;
            string val_7 = System.String.Format(format:  "{0} REACHED", arg0:  val_3.rankName.ToUpper());
            this.rankSpriteDisplay.DisplaySprite(rank:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank);
        }
        public MinigamesRankup_Window()
        {
        
        }
    
    }

}
