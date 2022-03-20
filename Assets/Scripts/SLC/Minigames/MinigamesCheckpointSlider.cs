using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesCheckpointSlider : MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>
    {
        // Fields
        private TMPro.TMP_Text levelText;
        private UnityEngine.UI.Text cpText;
        private UnityEngine.UI.Text rankText;
        private UnityEngine.UI.Slider checkpointSlider;
        private UnityEngine.UI.Image sliderSprite;
        private System.Collections.Generic.List<SLC.Minigames.MinigameRankSpriteDisplay> icons;
        private UnityEngine.UI.Button PauseButton;
        private UnityEngine.UI.Text coinAmountText;
        private UnityEngine.UI.Button storeButton;
        
        // Methods
        private void Start()
        {
            if(this.PauseButton != 0)
            {
                    this.PauseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesCheckpointSlider::OnPauseClick()));
            }
            
            if(this.storeButton == 0)
            {
                    return;
            }
            
            this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesCheckpointSlider::OnStoreButtonClick()));
        }
        private void OnPauseClick()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandlePauseClicked();
        }
        private void OnStoreButtonClick()
        {
            SLC.Minigames.MinigamesWindowManager val_2 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false);
        }
        public void UpdateUI()
        {
            string val_12;
            int val_13;
            int val_14;
            var val_15;
            var val_16;
            val_12 = "no rank";
            bool val_1 = UnityEngine.Object.op_Inequality(x:  this.coinAmountText, y:  0);
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_13 = val_4.currentPlayerLevel;
                SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_14 = val_5.currentPlayerData.checkpointLevel;
                val_15 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetLevelsToNextCheckpoint;
                val_16 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetPlayerLevelInCurrentRank;
                SLC.Minigames.MinigameLevelRank val_11 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank;
                val_12 = val_11.rankName;
            }
            else
            {
                    val_16 = 0;
                val_14 = 0;
                val_15 = 0;
                val_13 = 0;
            }
            
            this.UpdateUI(currLevel:  0, currCheckpoint:  0, levelsToNextCheckpoint:  0, currentLevelInRank:  0, rank:  val_12);
        }
        private void UpdateUI(int currLevel, int currCheckpoint, int levelsToNextCheckpoint, int currentLevelInRank, string rank)
        {
            string val_2 = System.String.Format(format:  "LVL {0}", arg0:  currLevel + 1);
            if(this.coinAmountText != 0)
            {
                    Player val_4 = App.Player;
                GameEcon val_5 = App.getGameEcon;
                string val_6 = val_4._credits.ToString(format:  val_5.numberFormatInt);
            }
            
            int val_7 = currentLevelInRank - currCheckpoint;
            float val_17 = (float)levelsToNextCheckpoint;
            val_17 = (float)val_7 / val_17;
            UnityEngine.Color val_8 = UnityEngine.Color.red;
            this.sliderSprite.color = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
            string val_11 = System.String.Format(format:  "{0} / {1}", arg0:  val_7.ToString(), arg1:  levelsToNextCheckpoint.ToString());
            if((rank.Equals(value:  0.ToString())) != false)
            {
                    if(this.rankText != null)
            {
                goto label_16;
            }
            
            }
            
            string val_14 = rank.ToUpper();
            label_16:
            UnityEngine.Color val_15 = UnityEngine.Color.red;
            this.rankText.color = new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a};
            this.rankText.GetComponent<UnityEngine.RectTransform>().ForceUpdateRectTransforms();
        }
        public MinigamesCheckpointSlider()
        {
        
        }
    
    }

}
