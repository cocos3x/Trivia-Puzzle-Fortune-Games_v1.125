using UnityEngine;

namespace SRDebugger
{
    public sealed class VisibilityChangedDelegate : MulticastDelegate
    {
        // Methods
        public VisibilityChangedDelegate(object object, IntPtr method)
        {
            mem[1152921519496101920] = object;
            mem[1152921519496101928] = method;
            mem[1152921519496101904] = method;
        }
        public virtual void Invoke(bool isVisible)
        {
            var val_10;
            var val_11;
            var val_12;
            var val_13;
            var val_14;
            bool val_1 = isVisible;
            if(val_1 != false)
            {
                    val_10 = mem[(isVisible & 1) + 24];
                val_10 = (isVisible & 1) + 24;
                if(val_10 == 0)
            {
                    return;
            }
            
                val_11 = val_1 + 32;
            }
            else
            {
                    val_10 = 1;
            }
            
            var val_16 = 0;
            goto label_28;
            label_21:
            val_12 = mem[X22 + 72];
            val_12 = X22 + 72;
            if((this & 1) == 0)
            {
                goto label_4;
            }
            
            var val_13 = X21;
            if((X21 + 294) == 0)
            {
                goto label_8;
            }
            
            var val_8 = X21 + 176;
            var val_9 = 0;
            val_8 = val_8 + 8;
            label_7:
            if(((X21 + 176 + 8) + -8) == X22.disabledSprite)
            {
                goto label_6;
            }
            
            val_9 = val_9 + 1;
            val_8 = val_8 + 16;
            if(val_9 < (X21 + 294))
            {
                goto label_7;
            }
            
            goto label_8;
            label_22:
            var val_3 = X21 + (((isVisible & 1) + 72) << 4);
            val_14 = mem[(X21 + ((isVisible & 1) + 72) << 4) + 312];
            val_14 = (X21 + ((isVisible & 1) + 72) << 4) + 312;
            goto label_9;
            label_4:
            var val_10 = X21;
            val_10 = val_10 + val_12;
            goto label_16;
            label_24:
            var val_11 = X11;
            val_11 = val_11 + ((X21 + X22 + 72) + 304 + 8);
            val_10 = val_10 + val_11;
            var val_4 = val_10 + 304;
            label_26:
            val_14 = mem[(((X21 + X22 + 72) + (X11 + (X21 + X22 + 72) + 304 + 8)) + 304) + 8];
            val_14 = (((X21 + X22 + 72) + (X11 + (X21 + X22 + 72) + 304 + 8)) + 304) + 8;
            label_9:
            var val_5 = (val_12 != 0) ? 1 : 0;
            goto label_16;
            label_6:
            var val_12 = val_8;
            val_12 = val_12 + val_12;
            val_13 = val_13 + val_12;
            val_13 = val_13 + 304;
            label_8:
            var val_6 = (val_1 == true) ? 1 : 0;
            goto label_16;
            label_28:
            if((mem[1152921519496226216] & 1) == 0)
            {
                goto label_14;
            }
            
            if((mem[1152921519496226216] + 74) != 1)
            {
                goto label_27;
            }
            
            goto label_16;
            label_14:
            if(mem[1152921519496226208] == 0)
            {
                goto label_17;
            }
            
            if((((mem[1152921519496226216] + 72) == 1) || (((mem[1152921519496226208] + 273) & 1) != 0)) || ((mem[1152921519496226208] + 273) == 0))
            {
                goto label_27;
            }
            
            if((mem[1152921519496226216] & 1) == 0)
            {
                goto label_21;
            }
            
            if((mem[1152921519496226216] & 1) == 0)
            {
                goto label_22;
            }
            
            if((mem[1152921519496226208] + 294) == 0)
            {
                goto label_26;
            }
            
            var val_14 = mem[1152921519496226208] + 176;
            var val_15 = 0;
            val_14 = val_14 + 8;
            label_25:
            if(((mem[1152921519496226208] + 176 + 8) + -8) == (mem[1152921519496226216] + 24))
            {
                goto label_24;
            }
            
            val_15 = val_15 + 1;
            val_14 = val_14 + 16;
            if(val_15 < (mem[1152921519496226208] + 294))
            {
                goto label_25;
            }
            
            goto label_26;
            label_17:
            if((mem[1152921519496226216].disabledSprite & 1) != 0)
            {
                
            }
            
            label_27:
            label_16:
            val_16 = val_16 + 1;
            if(val_16 != val_10)
            {
                goto label_28;
            }
        
        }
        public virtual System.IAsyncResult BeginInvoke(bool isVisible, System.AsyncCallback callback, object object)
        {
            bool val_1 = isVisible;
            return (System.IAsyncResult)this;
        }
        public virtual void EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
