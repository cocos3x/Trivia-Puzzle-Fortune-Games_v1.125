using UnityEngine;

namespace UnityEngine.UI
{
    public class LoopVerticalScrollRect : LoopScrollRect
    {
        // Methods
        protected override float GetSize(UnityEngine.RectTransform item)
        {
            if(static_value_02808000 != 0)
            {
                
            }
            else
            {
                    float val_3 = UnityEngine.UI.LayoutUtility.GetPreferredHeight(rect:  item);
            }
            
            val_3 = this.contentSpacing + val_3;
            return (float)val_3;
        }
        protected override float GetDimension(UnityEngine.Vector2 vector)
        {
            return (float)vector.y;
        }
        protected override UnityEngine.Vector2 GetVector(float value)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  value);
            return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        protected override void Awake()
        {
            this.Awake();
            mem[1152921520078566228] = 0;
            if((this.GetComponent<UnityEngine.UI.GridLayoutGroup>()) == 0)
            {
                    return;
            }
            
            if(val_1.m_Constraint == 1)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
        }
        protected override bool UpdateItems(UnityEngine.Bounds viewBounds, UnityEngine.Bounds contentBounds)
        {
            float val_30;
            float val_31;
            var val_32;
            float val_33;
            var val_34;
            UnityEngine.Vector3 val_1 = viewBounds.min;
            UnityEngine.Vector3 val_2 = contentBounds.min;
            if(val_1.y >= 0)
            {
                goto label_0;
            }
            
            float val_3 = this.NewItemAtEnd();
            val_30 = val_3;
            if(val_3 <= 0f)
            {
                goto label_7;
            }
            
            label_3:
            UnityEngine.Vector3 val_4 = viewBounds.min;
            UnityEngine.Vector3 val_5 = contentBounds.min;
            val_31 = val_5.y - val_30;
            if(val_4.y >= 0)
            {
                goto label_7;
            }
            
            float val_6 = this.NewItemAtEnd();
            val_30 = val_30 + val_6;
            if(val_6 > 0f)
            {
                goto label_3;
            }
            
            goto label_7;
            label_0:
            UnityEngine.Vector3 val_7 = viewBounds.min;
            UnityEngine.Vector3 val_8 = contentBounds.min;
            val_31 = val_8.y + val_8.x;
            if(val_7.y <= val_31)
            {
                goto label_9;
            }
            
            float val_9 = this.DeleteItemAtEnd();
            val_30 = val_9;
            if(val_9 <= 0f)
            {
                goto label_7;
            }
            
            label_8:
            UnityEngine.Vector3 val_10 = viewBounds.min;
            UnityEngine.Vector3 val_11 = contentBounds.min;
            val_11.x = val_11.y + val_11.x;
            val_31 = val_30 + val_11.x;
            if(val_10.y <= val_31)
            {
                goto label_7;
            }
            
            float val_12 = this.DeleteItemAtEnd();
            val_30 = val_30 + val_12;
            if(val_12 > 0f)
            {
                goto label_8;
            }
            
            label_7:
            if(val_30 <= 0f)
            {
                goto label_9;
            }
            
            val_32 = 1;
            goto label_10;
            label_9:
            val_32 = 0;
            label_10:
            UnityEngine.Vector3 val_13 = viewBounds.max;
            UnityEngine.Vector3 val_14 = contentBounds.max;
            if(val_13.y <= val_14.y)
            {
                goto label_11;
            }
            
            float val_15 = this.NewItemAtStart();
            val_33 = val_15;
            if(val_15 <= 0f)
            {
                goto label_13;
            }
            
            label_14:
            UnityEngine.Vector3 val_16 = viewBounds.max;
            UnityEngine.Vector3 val_17 = contentBounds.max;
            if(val_16.y <= (val_33 + val_17.y))
            {
                goto label_13;
            }
            
            float val_19 = this.NewItemAtStart();
            val_33 = val_33 + val_19;
            if(val_19 > 0f)
            {
                goto label_14;
            }
            
            label_13:
            val_34 = val_32 | ((val_33 > 0f) ? 1 : 0);
            return (bool)val_34;
            label_11:
            UnityEngine.Vector3 val_21 = viewBounds.max;
            val_33 = val_21.y;
            UnityEngine.Vector3 val_22 = contentBounds.max;
            val_22.x = val_22.y - val_22.x;
            if(val_33 >= 0)
            {
                goto label_16;
            }
            
            float val_23 = this.DeleteItemAtStart();
            val_33 = val_23;
            if(val_23 <= 0f)
            {
                goto label_18;
            }
            
            label_19:
            UnityEngine.Vector3 val_24 = viewBounds.max;
            UnityEngine.Vector3 val_25 = contentBounds.max;
            val_25.x = val_25.y - val_25.x;
            val_25.x = val_25.x - val_33;
            if(val_24.y >= 0)
            {
                goto label_18;
            }
            
            float val_26 = this.DeleteItemAtStart();
            val_33 = val_33 + val_26;
            if(val_26 > 0f)
            {
                goto label_19;
            }
            
            label_18:
            val_32 = val_32 | ((val_33 > 0f) ? 1 : 0);
            label_16:
            val_34 = val_32;
            return (bool)val_34;
        }
        public LoopVerticalScrollRect()
        {
        
        }
    
    }

}
