using UnityEngine;

namespace LitJson
{
    public sealed class ImporterFunc<TJson, TValue> : MulticastDelegate
    {
        // Methods
        public ImporterFunc<TJson, TValue>(object object, IntPtr method)
        {
            mem[1152921513338302768] = object;
            mem[1152921513338302776] = method;
            mem[1152921513338302752] = method;
        }
        public virtual TValue Invoke(TJson input)
        {
            var val_13;
            var val_14;
            var val_15;
            var val_17;
            var val_18;
            var val_19;
            var val_20;
            if(X8 == 0)
            {
                goto label_0;
            }
            
            val_13 = mem[X8 + 24];
            val_13 = X8 + 24;
            if(val_13 == 0)
            {
                goto label_1;
            }
            
            val_14 = X8 + 32;
            goto label_2;
            label_0:
            val_13 = 1;
            label_2:
            var val_22 = 0;
            object val_1 = input - 16;
            goto label_46;
            label_39:
            val_15 = mem[X22 + 72];
            val_15 = X22 + 72;
            if((this & 1) == 0)
            {
                goto label_4;
            }
            
            UnityEngine.Sprite val_2 = X22.disabledSprite;
            var val_11 = 0;
            val_11 = val_11 + 1;
            goto label_8;
            label_40:
            object val_3 = 1152921504626761728 + ((X22 + 72) << 4);
            val_17 = mem[(1152921504626761728 + (X22 + 72) << 4) + 312];
            goto label_17;
            label_4:
            val_18 = input;
            object val_4 = 1152921504626761728 + val_15;
            goto label_25;
            label_31:
            if((val_18 & 1) == 0)
            {
                goto label_11;
            }
            
            var val_18 = val_15;
            if((X22 + 72 + 294) == 0)
            {
                goto label_15;
            }
            
            var val_12 = X22 + 72 + 176;
            var val_13 = 0;
            val_12 = val_12 + 8;
            label_14:
            if(((X22 + 72 + 176 + 8) + -8) == X22.disabledSprite)
            {
                goto label_13;
            }
            
            val_13 = val_13 + 1;
            val_12 = val_12 + 16;
            if(val_13 < (X22 + 72 + 294))
            {
                goto label_14;
            }
            
            goto label_15;
            label_32:
            var val_6 = val_15 + ((X22 + 72) << 4);
            val_20 = mem[(X22 + 72 + (X22 + 72) << 4) + 312];
            val_20 = (X22 + 72 + (X22 + 72) << 4) + 312;
            goto label_20;
            label_44:
            val_17 = mem[(((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8];
            val_17 = (((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8;
            goto label_17;
            label_8:
            label_17:
            val_18 = input;
            goto label_25;
            label_11:
            var val_15 = val_15;
            val_18 = val_15;
            val_15 = val_15 + (X22 + 72);
            goto label_25;
            label_34:
            var val_16 = X11;
            val_16 = val_16 + ((X22 + 72 + X22 + 72) + 304 + 8);
            val_15 = val_15 + val_16;
            var val_9 = val_15 + 304;
            label_36:
            val_20 = mem[(((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8];
            val_20 = (((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8;
            goto label_20;
            label_13:
            var val_17 = val_12;
            val_17 = val_17 + (X22 + 72);
            val_18 = val_18 + val_17;
            val_19 = val_18 + 304;
            label_15:
            label_20:
            val_18 = val_15;
            goto label_25;
            label_46:
            val_15 = mem[1152921513338435248];
            if((mem[1152921513338435256] & 1) == 0)
            {
                goto label_23;
            }
            
            if((mem[1152921513338435256] + 74) == 1)
            {
                goto label_45;
            }
            
            label_30:
            val_18 = val_15;
            goto label_25;
            label_23:
            if((mem[1152921513338435256] + 74) != 1)
            {
                goto label_26;
            }
            
            if(val_15 == 0)
            {
                goto label_27;
            }
            
            if((((mem[1152921513338435256] + 72) == 1) || (((mem[1152921513338435248] + 273) & 1) != 0)) || ((mem[1152921513338435248] + 273) == 0))
            {
                goto label_30;
            }
            
            if((mem[1152921513338435256] & 1) == 0)
            {
                goto label_31;
            }
            
            if((mem[1152921513338435256] & 1) == 0)
            {
                goto label_32;
            }
            
            if((mem[1152921513338435248] + 294) == 0)
            {
                goto label_36;
            }
            
            var val_19 = mem[1152921513338435248] + 176;
            var val_20 = 0;
            val_19 = val_19 + 8;
            label_35:
            if(((mem[1152921513338435248] + 176 + 8) + -8) == (mem[1152921513338435256] + 24))
            {
                goto label_34;
            }
            
            val_20 = val_20 + 1;
            val_19 = val_19 + 16;
            if(val_20 < (mem[1152921513338435248] + 294))
            {
                goto label_35;
            }
            
            goto label_36;
            label_26:
            if(((mem[1152921513338435256] + 72) == 1) || ((mem[1152921513338435256] + 72) == 0))
            {
                goto label_45;
            }
            
            if((mem[1152921513338435256] & 1) == 0)
            {
                goto label_39;
            }
            
            if((mem[1152921513338435256] & 1) == 0)
            {
                goto label_40;
            }
            
            var val_21 = 0;
            val_21 = val_21 + 1;
            goto label_44;
            label_27:
            UnityEngine.Sprite val_10 = mem[1152921513338435256].disabledSprite;
            label_45:
            val_18 = input;
            label_25:
            val_22 = val_22 + 1;
            if(val_22 != val_13)
            {
                goto label_46;
            }
            
            return (object)val_18;
            label_1:
            val_18 = 0;
            return (object)val_18;
        }
        public virtual System.IAsyncResult BeginInvoke(TJson input, System.AsyncCallback callback, object object)
        {
            return (System.IAsyncResult)this;
        }
        public virtual TValue EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
