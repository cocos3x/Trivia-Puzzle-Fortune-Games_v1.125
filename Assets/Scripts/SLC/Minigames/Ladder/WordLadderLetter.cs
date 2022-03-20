using UnityEngine;

namespace SLC.Minigames.Ladder
{
    public class WordLadderLetter : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text myLetter;
        private UnityEngine.UI.Image image;
        private int index;
        private string letter;
        
        // Properties
        public string Letter { get; }
        
        // Methods
        public string get_Letter()
        {
            return (string)this.letter;
        }
        private void Awake()
        {
            UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
            val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(SLC.Minigames.Ladder.WordLadderLetter).__il2cppRuntimeField_178));
        }
        public void Setup(string letter, int myIndex)
        {
            this.index = myIndex;
            this.letter = letter;
        }
        public virtual void OnClick()
        {
            SLC.Minigames.Ladder.WordLadderController val_1 = MonoSingleton<SLC.Minigames.Ladder.WordLadderController>.Instance;
            if(val_1.IsGameOver != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance.LetterChosen(clickedIndex:  this.index);
        }
        public void SetSpriteAndText(UnityEngine.Sprite s, int textSize)
        {
            UnityEngine.Sprite val_3 = s;
            if(this.image == 0)
            {
                    return;
            }
            
            this.image.sprite = val_3;
            val_3 = this.myLetter;
            if(val_3 == 0)
            {
                    return;
            }
            
            this.myLetter.fontSize = textSize;
        }
        public WordLadderLetter()
        {
        
        }
    
    }

}
