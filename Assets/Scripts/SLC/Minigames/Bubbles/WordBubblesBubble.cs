using UnityEngine;

namespace SLC.Minigames.Bubbles
{
    public class WordBubblesBubble : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text myLetter;
        private UnityEngine.UI.Image image;
        private string <Text>k__BackingField;
        private UnityEngine.Color <color>k__BackingField;
        public int Index;
        
        // Properties
        public string Text { get; set; }
        public UnityEngine.Color color { get; set; }
        
        // Methods
        public string get_Text()
        {
            return (string)this.<Text>k__BackingField;
        }
        private void set_Text(string value)
        {
            this.<Text>k__BackingField = value;
        }
        public UnityEngine.Color get_color()
        {
            return new UnityEngine.Color() {r = this.<color>k__BackingField};
        }
        private void set_color(UnityEngine.Color value)
        {
            this.<color>k__BackingField = value;
            mem[1152921519835321828] = value.g;
            mem[1152921519835321832] = value.b;
            mem[1152921519835321836] = value.a;
        }
        private void Awake()
        {
            UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
            val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(SLC.Minigames.Bubbles.WordBubblesBubble).__il2cppRuntimeField_178));
        }
        public virtual void OnClick()
        {
            SLC.Minigames.Bubbles.WordBubblesController val_1 = MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>.Instance;
            if(val_1.IsGameOver != false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.ChooseWordElement(bubble:  this);
        }
        public void Setup(string text, UnityEngine.Color c, int index = -1)
        {
            if(this.image != 0)
            {
                    this.image.color = new UnityEngine.Color() {r = c.r, g = c.g, b = c.b, a = c.a};
                this.<color>k__BackingField = c;
                mem[1152921519835719268] = c.g;
                mem[1152921519835719272] = c.b;
                mem[1152921519835719276] = c.a;
                if(this.myLetter != 0)
            {
                    this.<Text>k__BackingField = text;
            }
            
            }
            
            if(index == 1)
            {
                    return;
            }
            
            this.Index = index;
        }
        public WordBubblesBubble()
        {
        
        }
    
    }

}
