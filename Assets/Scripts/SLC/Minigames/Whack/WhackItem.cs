using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text word;
        private UnityEngine.GameObject checkMark;
        private UnityEngine.GameObject xMark;
        private UnityEngine.GameObject emptySlot;
        private UnityEngine.GameObject melonSlot;
        private UnityEngine.GameObject winningSprite;
        private UnityEngine.GameObject losingSprite;
        private UnityEngine.GameObject hitSprite;
        private UnityEngine.GameObject victoryArmGroup;
        public SLC.Minigames.Whack.WhackWord wordDefinition;
        
        // Methods
        private void Awake()
        {
            this.melonSlot.SetActive(value:  false);
            this.winningSprite.SetActive(value:  false);
            this.losingSprite.SetActive(value:  false);
            this.hitSprite.SetActive(value:  false);
            this.victoryArmGroup.SetActive(value:  false);
            this.word.transform.parent.gameObject.SetActive(value:  false);
            this.checkMark.SetActive(value:  false);
            this.xMark.SetActive(value:  false);
        }
        public void Setup(SLC.Minigames.Whack.WhackWord wordDefinition)
        {
            this.wordDefinition = wordDefinition;
            if(wordDefinition != null)
            {
                    this.SetDisplayState(state:  1);
                this = ???;
            }
            else
            {
                    val_5 + 56.SetActive(value:  false);
            }
        
        }
        public void SetInteractable(bool state)
        {
            this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = state;
        }
        public void SetDisplayState(SLC.Minigames.Whack.MelonState state)
        {
            if((state - 1) > 6)
            {
                    return;
            }
            
            var val_12 = 32555584 + ((state - 1)) << 2;
            val_12 = val_12 + 32555584;
            goto (32555584 + ((state - 1)) << 2 + 32555584);
        }
        public void OnClick()
        {
            MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.ItemClicked(item:  this);
        }
        public void UpdateOnLevelComplete(bool correctAnswer)
        {
            if(this.wordDefinition == null)
            {
                    return;
            }
            
            this.melonSlot.SetActive(value:  false);
            if(correctAnswer == false)
            {
                goto label_2;
            }
            
            if(this.winningSprite != null)
            {
                goto label_3;
            }
            
            throw new NullReferenceException();
            label_2:
            label_3:
            this.losingSprite.SetActive(value:  true);
        }
        public WhackItem()
        {
        
        }
    
    }

}
