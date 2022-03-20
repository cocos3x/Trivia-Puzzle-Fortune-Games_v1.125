using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleLetterTile : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text letter;
        private char <character>k__BackingField;
        private SLC.Minigames.WordJumble.WordJumbleWordArea wordAreaParent;
        private UnityEngine.UI.Button button;
        
        // Properties
        public char character { get; set; }
        public bool used { get; }
        
        // Methods
        public char get_character()
        {
            return (char)this.<character>k__BackingField;
        }
        private void set_character(char value)
        {
            this.<character>k__BackingField = value;
        }
        public bool get_used()
        {
            if(this.button != null)
            {
                    return (bool)(this.button == 0) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
        private void Awake()
        {
            this.button = this.GetComponent<UnityEngine.UI.Button>();
            val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleLetterTile::OnLetterClick()));
        }
        public void Init(SLC.Minigames.WordJumble.WordJumbleWordArea _wordAreaParent, char _letter)
        {
            this.wordAreaParent = _wordAreaParent;
            string val_1 = _letter.ToString();
            this.<character>k__BackingField = _letter;
        }
        private void OnLetterClick()
        {
            this.HideLetter();
            this.wordAreaParent.LetterTileClicked(letterTile:  this);
        }
        public void HideLetter()
        {
            this.button.interactable = false;
            MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.button).alpha = 0f;
        }
        public void ReshowLetter()
        {
            this.button.interactable = true;
            MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.button).alpha = 1f;
        }
        public WordJumbleLetterTile()
        {
        
        }
    
    }

}
