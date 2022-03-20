using UnityEngine;

namespace SLC.Minigames.WordQuiz
{
    public class WordQuizLetterTile : MonoBehaviour
    {
        // Fields
        public UnityEngine.UI.Text letter;
        public UnityEngine.UI.Button btn;
        public UnityEngine.CanvasGroup canvasGroup;
        private UnityEngine.Sprite hiddenTileSprite;
        private UnityEngine.Sprite shownSprite;
        private UnityEngine.UI.Outline textOutline;
        private UnityEngine.Color hintColor;
        public int keyboardIndex;
        public int answerIndex;
        public bool locked;
        public bool submitted;
        
        // Methods
        public void SetHiddenState(bool hidden)
        {
            UnityEngine.Sprite val_2;
            if(hidden != false)
            {
                    val_2 = this.hiddenTileSprite;
            }
            else
            {
                    val_2 = this.shownSprite;
            }
            
            this.btn.image.sprite = val_2;
        }
        public void SetHinted()
        {
            this.btn.image.enabled = false;
            this.letter.color = new UnityEngine.Color() {r = this.hintColor};
            this.textOutline.enabled = true;
        }
        public WordQuizLetterTile()
        {
        
        }
    
    }

}
