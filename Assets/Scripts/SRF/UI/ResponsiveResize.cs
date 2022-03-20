using UnityEngine;

namespace SRF.UI
{
    public class ResponsiveResize : ResponsiveBase
    {
        // Fields
        public SRF.UI.ResponsiveResize.Element[] Elements;
        
        // Methods
        protected override void Refresh()
        {
            var val_13;
            var val_14;
            UnityEngine.Rect val_2 = this.RectTransform.rect;
            val_13 = 0;
            do
            {
                if(val_13 >= (this.Elements.Length << ))
            {
                    return;
            }
            
                Element val_12 = this.Elements[0];
                Element val_13 = this.Elements[0];
                if(val_13 != 0)
            {
                    var val_14 = mem[this.Elements[0x0][0] + 24];
                val_14 = -1f;
                if(val_14 >= 1)
            {
                    var val_15 = 0;
                val_14 = val_14 & 4294967295;
                do
            {
                var val_5 = ((X26 + -4 + 4) <= val_2.m_XMin.width) ? 1 : 0;
                var val_6 = ((X26 + -4 + 4) > (-3.402823E+38f)) ? 1 : 0;
                val_15 = val_15 + 1;
                float val_7 = (val_6 != val_5) ? (X26 + -4) : -1f;
                var val_8 = (val_6 != val_5) ? (X26 + -4 + 4) : -3.402823E+38f;
                var val_9 = X26 + 8;
            }
            while(val_15 < ((mem[this.Elements[0x0][0] + 24]) << ));
            
            }
            
                if(val_7 > 0f)
            {
                    val_13.SetSizeWithCurrentAnchors(axis:  0, size:  val_7);
                bool val_11 = UnityEngine.Object.op_Inequality(x:  val_13.GetComponent<UnityEngine.UI.LayoutElement>(), y:  0);
            }
            
            }
            
                val_13 = val_13 + 1;
            }
            while(this.Elements != null);
            
            throw new NullReferenceException();
        }
        public ResponsiveResize()
        {
            this.Elements = new Element[0];
            this = new SRF.SRMonoBehaviour();
        }
    
    }

}
