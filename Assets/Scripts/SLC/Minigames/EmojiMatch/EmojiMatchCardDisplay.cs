using UnityEngine;

namespace SLC.Minigames.EmojiMatch
{
    public class EmojiMatchCardDisplay : EmojiMatchDisplay, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        // Fields
        private string[] <emojidata>k__BackingField;
        private int <index>k__BackingField;
        private UnityEngine.UI.GridLayoutGroup emoji_grid;
        public bool completed;
        
        // Properties
        public string[] emojidata { get; set; }
        public int index { get; set; }
        
        // Methods
        public string[] get_emojidata()
        {
            return (System.String[])this.<emojidata>k__BackingField;
        }
        private void set_emojidata(string[] value)
        {
            this.<emojidata>k__BackingField = value;
        }
        public int get_index()
        {
            return (int)this.<index>k__BackingField;
        }
        private void set_index(int value)
        {
            this.<index>k__BackingField = value;
        }
        public void Init(string emojiUnparsed, int myIndex)
        {
            int val_24;
            var val_25;
            val_24 = myIndex;
            this.completed = false;
            if((this.gameObject.GetComponent<UnityEngine.UI.Button>()) != 0)
            {
                    UnityEngine.UI.Button val_5 = this.gameObject.GetComponent<UnityEngine.UI.Button>();
                val_5.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay::SelectMe()));
            }
            
            this.<index>k__BackingField = val_24;
            char[] val_7 = new char[1];
            val_7[0] = ',';
            val_25 = 0;
            this.<emojidata>k__BackingField = emojiUnparsed.Split(separator:  val_7);
            do
            {
                if(0 >= val_8.Length)
            {
                    return;
            }
            
                System.Type[] val_11 = new System.Type[2];
                val_11[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
                val_11[1] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
                UnityEngine.GameObject val_14 = new UnityEngine.GameObject(name:  "Emoji_" + 0.ToString(), components:  val_11);
                val_14.transform.SetParent(p:  this.emoji_grid.transform);
                UnityEngine.Vector3 val_18 = UnityEngine.Vector3.one;
                val_14.transform.localScale = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
                val_24 = val_14.transform;
                UnityEngine.Vector3 val_20 = UnityEngine.Vector3.zero;
                val_24.localPosition = new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z};
                (null == null) ? val_14.transform : 0.sizeDelta = new UnityEngine.Vector2() {x = this.emoji_grid.m_CellSize, y = V9.16B};
                val_25 = 1;
                val_14.GetComponent<EmojiDisplay>().DisplayEmoji(emojiID:  this.<emojidata>k__BackingField[0], addOutline:  true);
            }
            while((this.<emojidata>k__BackingField) != null);
            
            throw new NullReferenceException();
        }
        public void SelectMe()
        {
            if(this.completed != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.SelectCard(card:  this);
        }
        public void MaybeDeselectMe(bool isDragging)
        {
            if(this.completed != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>.Instance.MaybeDeselectCard(card:  this, isDragging:  isDragging);
        }
        public void DisplaySelectedState(bool selected)
        {
            if(selected != false)
            {
                
            }
        
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
            if(this != null)
            {
                goto label_1;
            }
            
            throw new NullReferenceException();
            label_0:
            label_1:
            this.SetActive(value:  true);
        }
        public EmojiMatchCardDisplay()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
