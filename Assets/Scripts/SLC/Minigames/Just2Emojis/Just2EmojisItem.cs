using UnityEngine;

namespace SLC.Minigames.Just2Emojis
{
    public class Just2EmojisItem : MonoBehaviour
    {
        // Fields
        public bool isHidden;
        public bool isHinted;
        public string letter;
        private UnityEngine.UI.Image myImage;
        private TMPro.TMP_Text label;
        private UnityEngine.UI.Button myButton;
        private UnityEngine.Sprite highlightedSprite;
        private UnityEngine.Sprite unhighlightedSprite;
        private UnityEngine.RectTransform imageRectTransform;
        private float myWidth;
        
        // Methods
        private void Awake()
        {
            this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.Just2Emojis.Just2EmojisItem::OnClick()));
        }
        public void SetUp(string letter)
        {
            UnityEngine.Rect val_1 = this.imageRectTransform.rect;
            this.myWidth = val_1.m_XMin.width;
            this.letter = letter;
            this.isHinted = false;
        }
        public void Hide()
        {
            this.myImage.enabled = false;
            this.myButton.interactable = false;
            this.isHidden = true;
        }
        public void Show()
        {
            this.myImage.sprite = this.unhighlightedSprite;
            this.myImage.enabled = true;
            this.myButton.interactable = true;
            this.isHidden = false;
        }
        public void Hinted()
        {
            this.Hide();
            this.isHinted = true;
        }
        private void OnClick()
        {
            if(this.isHinted != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance.LetterClick(item:  this);
        }
        public override string ToString()
        {
            return System.String.Format(format:  "J2E Item: {0}", arg0:  this.letter);
        }
        public void FTUXHighlight()
        {
            if(this.myImage != null)
            {
                    this.myImage.sprite = this.highlightedSprite;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void Unhighlight()
        {
            if(this.myImage.m_Sprite != this.highlightedSprite)
            {
                    return;
            }
            
            this.myImage.sprite = this.unhighlightedSprite;
        }
        public Just2EmojisItem()
        {
        
        }
    
    }

}
