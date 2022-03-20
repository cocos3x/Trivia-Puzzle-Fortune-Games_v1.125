using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class Just2EmojisAnswer : MonoBehaviour
    {
        // Fields
        public string letter;
        public int index;
        public TMPro.TMP_Text myText;
        public UnityEngine.UI.Image myImage;
        public bool isHinted;
        private UnityEngine.UI.Button myButton;
        
        // Methods
        private void Awake()
        {
            this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisAnswer::OnClick()));
        }
        private void OnClick()
        {
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.AnswerClicked(answer:  this);
        }
        public void Fill(string letter)
        {
            this.letter = letter;
            this.myText.enableAutoSizing = false;
            this.myText.fontSize = MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisUIController>.Instance.FindBestAnswerFontSize();
        }
        public void Empty()
        {
            this.letter = System.String.alignConst;
        }
        public override string ToString()
        {
            return (string)System.String.Format(format:  "J2E Answer: {0}, index {1}", arg0:  this.letter, arg1:  this.index);
        }
        public Just2EmojisAnswer()
        {
        
        }
    
    }

}
