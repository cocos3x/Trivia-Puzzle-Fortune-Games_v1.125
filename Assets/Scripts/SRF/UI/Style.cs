using UnityEngine;

namespace SRF.UI
{
    [Serializable]
    public class Style
    {
        // Fields
        public UnityEngine.Color ActiveColor;
        public UnityEngine.Color DisabledColor;
        public UnityEngine.Color HoverColor;
        public UnityEngine.Sprite Image;
        public UnityEngine.Color NormalColor;
        
        // Methods
        public SRF.UI.Style Copy()
        {
            SRF.UI.Style val_1 = new SRF.UI.Style();
            val_1.CopyFrom(style:  this);
            return val_1;
        }
        public void CopyFrom(SRF.UI.Style style)
        {
            if(style != null)
            {
                    this.Image = style.Image;
                this.NormalColor = style.NormalColor;
                this.HoverColor = style.HoverColor;
                this.ActiveColor = style.ActiveColor;
                this.DisabledColor = style.DisabledColor;
                return;
            }
            
            throw new NullReferenceException();
        }
        public Style()
        {
            UnityEngine.Color val_1 = UnityEngine.Color.white;
            this.ActiveColor = val_1;
            mem[1152921519472511188] = val_1.g;
            mem[1152921519472511192] = val_1.b;
            mem[1152921519472511196] = val_1.a;
            UnityEngine.Color val_2 = UnityEngine.Color.white;
            this.DisabledColor = val_2;
            mem[1152921519472511204] = val_2.g;
            mem[1152921519472511208] = val_2.b;
            mem[1152921519472511212] = val_2.a;
            UnityEngine.Color val_3 = UnityEngine.Color.white;
            this.HoverColor = val_3;
            mem[1152921519472511220] = val_3.g;
            mem[1152921519472511224] = val_3.b;
            mem[1152921519472511228] = val_3.a;
            UnityEngine.Color val_4 = UnityEngine.Color.white;
            this.NormalColor = val_4;
            mem[1152921519472511244] = val_4.g;
            mem[1152921519472511248] = val_4.b;
            mem[1152921519472511252] = val_4.a;
        }
    
    }

}
