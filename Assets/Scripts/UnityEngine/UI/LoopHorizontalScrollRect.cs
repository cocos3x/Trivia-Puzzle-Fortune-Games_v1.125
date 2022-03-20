using UnityEngine;

namespace UnityEngine.UI
{
    public class LoopHorizontalScrollRect : LoopScrollRect
    {
        // Methods
        protected override float GetSize(UnityEngine.RectTransform item)
        {
            if(static_value_02808000 != 0)
            {
                
            }
            else
            {
                    float val_3 = UnityEngine.UI.LayoutUtility.GetPreferredWidth(rect:  item);
            }
            
            val_3 = this.contentSpacing + val_3;
            return (float)val_3;
        }
        protected override float GetDimension(UnityEngine.Vector2 vector)
        {
            return (float)-vector.x;
        }
        protected override UnityEngine.Vector2 GetVector(float value)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  -value, y:  0f);
            return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        protected override void Awake()
        {
            this.Awake();
            mem[1152921520061232996] = 1;
            if((this.GetComponent<UnityEngine.UI.GridLayoutGroup>()) == 0)
            {
                    return;
            }
            
            if(val_1.m_Constraint == 2)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "[LoopHorizontalScrollRect] unsupported GridLayoutGroup constraint");
        }
        protected override bool UpdateItems(UnityEngine.Bounds viewBounds, UnityEngine.Bounds contentBounds)
        {
            float val_28;
            float val_29;
            var val_30;
            float val_31;
            var val_32;
            UnityEngine.Vector3 val_1 = viewBounds.max;
            UnityEngine.Vector3 val_2 = contentBounds.max;
            if(val_1.x <= val_2.x)
            {
                goto label_0;
            }
            
            float val_3 = this.NewItemAtEnd();
            val_28 = val_3;
            if(val_3 <= 0f)
            {
                goto label_7;
            }
            
            label_3:
            UnityEngine.Vector3 val_4 = viewBounds.max;
            UnityEngine.Vector3 val_5 = contentBounds.max;
            val_29 = val_28 + val_5.x;
            if(val_4.x <= val_29)
            {
                goto label_7;
            }
            
            float val_6 = this.NewItemAtEnd();
            val_28 = val_28 + val_6;
            if(val_6 > 0f)
            {
                goto label_3;
            }
            
            goto label_7;
            label_0:
            UnityEngine.Vector3 val_7 = viewBounds.max;
            UnityEngine.Vector3 val_8 = contentBounds.max;
            val_29 = val_8.x - val_8.y;
            if(val_7.x >= 0)
            {
                goto label_9;
            }
            
            float val_9 = this.DeleteItemAtEnd();
            val_28 = val_9;
            if(val_9 <= 0f)
            {
                goto label_7;
            }
            
            label_8:
            UnityEngine.Vector3 val_10 = viewBounds.max;
            UnityEngine.Vector3 val_11 = contentBounds.max;
            val_11.x = val_11.x - val_11.y;
            val_29 = val_11.x - val_28;
            if(val_10.x >= 0)
            {
                goto label_7;
            }
            
            float val_12 = this.DeleteItemAtEnd();
            val_28 = val_28 + val_12;
            if(val_12 > 0f)
            {
                goto label_8;
            }
            
            label_7:
            if(val_28 <= 0f)
            {
                goto label_9;
            }
            
            val_30 = 1;
            goto label_10;
            label_9:
            val_30 = 0;
            label_10:
            UnityEngine.Vector3 val_13 = viewBounds.min;
            UnityEngine.Vector3 val_14 = contentBounds.min;
            if(val_13.x >= 0)
            {
                goto label_11;
            }
            
            float val_15 = this.NewItemAtStart();
            val_31 = val_15;
            if(val_15 <= 0f)
            {
                goto label_13;
            }
            
            label_14:
            UnityEngine.Vector3 val_16 = viewBounds.min;
            UnityEngine.Vector3 val_17 = contentBounds.min;
            val_17.x = val_17.x - val_31;
            if(val_16.x >= 0)
            {
                goto label_13;
            }
            
            float val_18 = this.NewItemAtStart();
            val_31 = val_31 + val_18;
            if(val_18 > 0f)
            {
                goto label_14;
            }
            
            label_13:
            val_32 = val_30 | ((val_31 > 0f) ? 1 : 0);
            return (bool)val_32;
            label_11:
            UnityEngine.Vector3 val_20 = viewBounds.min;
            val_31 = val_20.x;
            UnityEngine.Vector3 val_21 = contentBounds.min;
            val_21.x = val_21.x + val_21.y;
            if(val_31 <= val_21.x)
            {
                goto label_16;
            }
            
            float val_22 = this.DeleteItemAtStart();
            val_31 = val_22;
            if(val_22 <= 0f)
            {
                goto label_18;
            }
            
            label_19:
            UnityEngine.Vector3 val_23 = viewBounds.min;
            UnityEngine.Vector3 val_24 = contentBounds.min;
            val_24.x = val_24.x + val_24.y;
            val_24.x = val_31 + val_24.x;
            if(val_23.x <= val_24.x)
            {
                goto label_18;
            }
            
            float val_25 = this.DeleteItemAtStart();
            val_31 = val_31 + val_25;
            if(val_25 > 0f)
            {
                goto label_19;
            }
            
            label_18:
            val_30 = val_30 | ((val_31 > 0f) ? 1 : 0);
            label_16:
            val_32 = val_30;
            return (bool)val_32;
        }
        public LoopHorizontalScrollRect()
        {
        
        }
    
    }

}
