using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleAnswerLetter : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text letter;
        private SLC.Minigames.WordJumble.WordJumbleWordArea wordAreaParent;
        private SLC.Minigames.WordJumble.WordJumbleLetterTile letterTile;
        private UnityEngine.UI.Button button;
        private bool <confirmed>k__BackingField;
        
        // Properties
        public char character { get; }
        public bool confirmed { get; set; }
        public bool IsLetterSet { get; }
        
        // Methods
        public char get_character()
        {
            if(this.letterTile != null)
            {
                    return (char)this.letterTile.<character>k__BackingField;
            }
            
            throw new NullReferenceException();
        }
        public bool get_confirmed()
        {
            return (bool)this.<confirmed>k__BackingField;
        }
        private void set_confirmed(bool value)
        {
            this.<confirmed>k__BackingField = value;
        }
        private void Awake()
        {
            this.button = this.GetComponent<UnityEngine.UI.Button>();
            val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SLC.Minigames.WordJumble.WordJumbleAnswerLetter::OnLetterClick()));
        }
        public void Init(SLC.Minigames.WordJumble.WordJumbleWordArea _wordAreaParent)
        {
            this.wordAreaParent = _wordAreaParent;
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public bool get_IsLetterSet()
        {
            return (bool)(null > 0) ? 1 : 0;
        }
        public void SetLetter(SLC.Minigames.WordJumble.WordJumbleLetterTile _letterTile, bool confirm = False)
        {
            string val_1 = _letterTile.<character>k__BackingField.ToString();
            this.letterTile = _letterTile;
            this.<confirmed>k__BackingField = confirm;
        }
        public void OnLetterClick()
        {
            if(this.wordAreaParent != null)
            {
                    this.wordAreaParent.AnswerLetterClicked(answerLetter:  this);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ResetLetter()
        {
            if((this.<confirmed>k__BackingField) != false)
            {
                    return;
            }
            
            if(this.letterTile != 0)
            {
                    this.letterTile.ReshowLetter();
                this.letterTile = 0;
            }
        
        }
        public WordJumbleAnswerLetter()
        {
        
        }
    
    }

}
