using UnityEngine;

namespace WordForest
{
    public class WFOChestRewardItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image rewardIcon;
        private UnityEngine.UI.Text rewardLabel;
        private UnityEngine.CanvasGroup rootCanvasGroup;
        private UnityEngine.RectTransform groupUnlocked;
        private UnityEngine.RectTransform groupLocked;
        private UnityEngine.Sprite spriteAcorn;
        private UnityEngine.Sprite spriteCoin;
        private UnityEngine.Sprite spriteAcornMultiplier;
        private UnityEngine.UI.Text progressText;
        private UnityEngine.UI.Slider progressBar;
        private WordForest.WFORewardData rewardData;
        
        // Methods
        public void Initialize(WordForest.WFORewardData rData)
        {
            UnityEngine.Sprite val_2;
            UnityEngine.UI.Text val_3;
            string val_5;
            mem[1152921518113327008] = rData.amount.lo;
            mem[1152921518113327000] = rData.amount.flags;
            this.rewardData = rData.id;
            if(mem[1152921518113358884] != 3)
            {
                    if(mem[1152921518113358884] != 2)
            {
                    if(mem[1152921518113358884] != 1)
            {
                    return;
            }
            
                val_2 = this.spriteAcorn;
            }
            else
            {
                    val_2 = this.spriteCoin;
            }
            
                this.rewardIcon.sprite = val_2;
                val_3 = this.rewardLabel;
                val_5 = "+{0}";
            }
            else
            {
                    this.rewardIcon.sprite = this.spriteAcornMultiplier;
                val_3 = this.rewardLabel;
                val_5 = "x{0}";
            }
            
            string val_1 = System.String.Format(format:  val_5, arg0:  rData.rewardType);
        }
        public void SetLockStatus()
        {
            this.groupLocked.gameObject.SetActive(value:  true);
            this.groupUnlocked.gameObject.SetActive(value:  false);
            this.rootCanvasGroup.alpha = 0.5f;
        }
        public void SetProgress(int currentAmount, int targetAmount)
        {
            string val_1 = System.String.Format(format:  "{0}/{1}", arg0:  currentAmount, arg1:  targetAmount);
            float val_3 = (float)currentAmount;
            val_3 = val_3 / (float)targetAmount;
            this.rootCanvasGroup.alpha = (currentAmount < 1) ? 0.5f : 1f;
        }
        public WFOChestRewardItem()
        {
        
        }
    
    }

}
