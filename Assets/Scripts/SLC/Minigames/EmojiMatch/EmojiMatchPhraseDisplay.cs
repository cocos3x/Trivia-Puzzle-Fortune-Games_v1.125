using UnityEngine;

namespace SLC.Minigames.EmojiMatch
{
    public class EmojiMatchPhraseDisplay : EmojiMatchDisplay, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        // Fields
        private string <phrase>k__BackingField;
        private int <index>k__BackingField;
        private UnityEngine.UI.Text phraseText;
        private bool completed;
        
        // Properties
        public string phrase { get; set; }
        public int index { get; set; }
        
        // Methods
        public string get_phrase()
        {
            return (string)this.<phrase>k__BackingField;
        }
        private void set_phrase(string value)
        {
            this.<phrase>k__BackingField = value;
        }
        public int get_index()
        {
            return (int)this.<index>k__BackingField;
        }
        private void set_index(int value)
        {
            this.<index>k__BackingField = value;
        }
        public void Init(string myPhrase, int myIndex)
        {
            this.completed = false;
            if((this.gameObject.GetComponent<UnityEngine.UI.Button>()) != 0)
            {
                    UnityEngine.UI.Button val_5 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
                val_5.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay::SelectMe()));
            }
            
            this.<phrase>k__BackingField = myPhrase;
            this.<index>k__BackingField = myIndex;
            this.SetState(state:  0);
        }
        public void SelectMe()
        {
            if(this.completed != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.SelectPhrase(phrase:  this);
        }
        public void MaybeDeselectMe(bool isDragging)
        {
            if(this.completed != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.MaybeDeselectPhrase(phrase:  this, isDragging:  isDragging);
        }
        public void DisplaySelectedState(bool selected)
        {
            if(selected != false)
            {
                    this.SetState(state:  1);
                return;
            }
            
            this.SetState(state:  0);
        }
        private void UnityEngine.EventSystems.IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(eventData != null)
            {
                    if((eventData.<dragging>k__BackingField) == false)
            {
                    return;
            }
            
                this.SelectMe();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.SelectMe();
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(eventData != null)
            {
                    if((eventData.<dragging>k__BackingField) != false)
            {
                    return;
            }
            
                this.MaybeDeselectMe(isDragging:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        private void UnityEngine.EventSystems.IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(eventData != null)
            {
                    this.MaybeDeselectMe(isDragging:  eventData.<dragging>k__BackingField);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void CompleteMe(bool matched)
        {
            if(matched == false)
            {
                goto label_0;
            }
            
            this.completed = true;
            this.SetState(state:  2);
            if(this != null)
            {
                goto label_1;
            }
            
            throw new NullReferenceException();
            label_0:
            this.SetState(state:  3);
            label_1:
            this.SetActive(value:  true);
        }
        public EmojiMatchPhraseDisplay()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
