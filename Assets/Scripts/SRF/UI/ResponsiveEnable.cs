using UnityEngine;

namespace SRF.UI
{
    public class ResponsiveEnable : ResponsiveBase
    {
        // Fields
        public SRF.UI.ResponsiveEnable.Entry[] Entries;
        
        // Methods
        protected override void Refresh()
        {
            Entry val_16;
            Entry val_17;
            var val_18;
            var val_19;
            UnityEngine.Rect val_2 = this.RectTransform.rect;
            var val_22 = 0;
            label_31:
            if(val_22 >= (this.Entries.Length << ))
            {
                    return;
            }
            
            Entry val_16 = this.Entries[0];
            val_16 = this.Entries[0];
            Entry val_18 = this.Entries[0];
            val_17 = this.Entries[0];
            if(val_16 == 1)
            {
                goto label_5;
            }
            
            if(val_16 != 0)
            {
                    throw new System.IndexOutOfRangeException();
            }
            
            if(val_18 <= 0f)
            {
                goto label_7;
            }
            
            var val_4 = (val_2.m_XMin.height >= val_18) ? 1 : 0;
            goto label_8;
            label_5:
            if(val_18 <= 0f)
            {
                goto label_9;
            }
            
            var val_6 = (val_2.m_XMin.height <= val_18) ? 1 : 0;
            goto label_10;
            label_7:
            val_18 = 1;
            label_8:
            if(val_17 <= 0f)
            {
                goto label_14;
            }
            
            val_18 = val_18 & ((val_2.m_XMin.width >= val_17) ? 1 : 0);
            if(val_16 != 0)
            {
                goto label_12;
            }
            
            goto label_16;
            label_9:
            val_19 = 1;
            label_10:
            var val_9 = (val_19 != 0) ? 1 : 0;
            if(val_17 > 0f)
            {
                    bool val_12 = (((val_2.m_XMin.width <= val_17) ? 1 : 0) != val_19) ? 1 : 0;
            }
            
            label_14:
            if(val_16 == 0)
            {
                goto label_16;
            }
            
            label_12:
            float val_19 = this.Entries[0x0][1].ThresholdWidth;
            if(val_19 >= (1.401298E-45f))
            {
                    var val_20 = 0;
                val_19 = val_19 & 4294967295;
                do
            {
                val_17 = mem[X27 + 0];
                val_17 = X27 + 0;
                if(val_17 != 0)
            {
                    val_17.SetActive(value:  val_12);
            }
            
                val_20 = val_20 + 1;
            }
            while(val_20 < (this.Entries[0x0][1].ThresholdWidth << ));
            
            }
            
            label_16:
            if(this.Entries[0] != 0)
            {
                    float val_21 = this.Entries[0x0][0].ThresholdWidth;
                if(val_21 >= (1.401298E-45f))
            {
                    val_21 = val_21 & 4294967295;
                do
            {
                val_17 = mem[(0 + 1) + 0];
                val_17 = (0 + 1) + 0;
                if(val_17 != 0)
            {
                    val_17.enabled = val_12;
            }
            
                val_16 = 0 + 1;
            }
            while(val_16 < (this.Entries[0x0][0].ThresholdWidth << ));
            
            }
            
            }
            
            val_22 = val_22 + 1;
            if(this.Entries != null)
            {
                goto label_31;
            }
            
            throw new NullReferenceException();
        }
        public ResponsiveEnable()
        {
            this.Entries = new Entry[0];
            this = new SRF.SRMonoBehaviour();
        }
    
    }

}
