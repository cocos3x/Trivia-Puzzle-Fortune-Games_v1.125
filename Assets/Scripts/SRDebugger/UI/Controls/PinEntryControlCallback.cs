using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public sealed class PinEntryControlCallback : MulticastDelegate
    {
        // Methods
        public PinEntryControlCallback(object object, IntPtr method)
        {
            mem[1152921519535119216] = object;
            mem[1152921519535119224] = method;
            mem[1152921519535119200] = method;
        }
        public virtual void Invoke(System.Collections.Generic.IList<int> result, bool didCancel)
        {
            var val_19;
            var val_20;
            bool val_21;
            var val_23;
            var val_24;
            var val_25;
            var val_26;
            bool val_1 = didCancel;
            if(val_1 != false)
            {
                    val_19 = mem[(didCancel & 1) + 24];
                val_19 = (didCancel & 1) + 24;
                if(val_19 == 0)
            {
                    return;
            }
            
                val_20 = val_1 + 32;
            }
            else
            {
                    val_19 = 1;
            }
            
            var val_28 = 0;
            System.Collections.Generic.IList<System.Int32> val_2 = result - 16;
            goto label_49;
            label_39:
            if((this & 1) == 0)
            {
                goto label_4;
            }
            
            UnityEngine.Sprite val_3 = X23.disabledSprite;
            val_21 = val_1;
            var val_17 = 0;
            val_17 = val_17 + 1;
            goto label_8;
            label_40:
            System.Collections.Generic.IList<System.Int32> val_4 = 1152921504687464448 + (((didCancel & 1) + 72) << 4);
            val_23 = mem[(1152921504687464448 + ((didCancel & 1) + 72) << 4) + 312];
            goto label_9;
            label_4:
            System.Collections.Generic.IList<System.Int32> val_5 = 1152921504687464448 + (X23 + 72);
            goto label_25;
            label_31:
            val_24 = mem[X23 + 72];
            val_24 = X23 + 72;
            if((result & 1) == 0)
            {
                goto label_11;
            }
            
            var val_24 = X23 + 72;
            val_21 = val_1;
            if((X23 + 72 + 294) == 0)
            {
                goto label_15;
            }
            
            var val_18 = X23 + 72 + 176;
            var val_19 = 0;
            val_18 = val_18 + 8;
            label_14:
            if(((X23 + 72 + 176 + 8) + -8) == X23.disabledSprite)
            {
                goto label_13;
            }
            
            val_19 = val_19 + 1;
            val_18 = val_18 + 16;
            if(val_19 < (X23 + 72 + 294))
            {
                goto label_14;
            }
            
            goto label_15;
            label_32:
            var val_7 = (X23 + 72) + (((didCancel & 1) + 72) << 4);
            val_26 = mem[(X23 + 72 + ((didCancel & 1) + 72) << 4) + 312];
            val_26 = (X23 + 72 + ((didCancel & 1) + 72) << 4) + 312;
            goto label_16;
            label_44:
            val_23 = mem[(((X23 + 72 + ((didCancel & 1) + 72) << 4) + (((X23 + 72 + 176 + 8) + 16) + X23 + 72)) + 304) + 8];
            val_23 = (((X23 + 72 + ((didCancel & 1) + 72) << 4) + (((X23 + 72 + 176 + 8) + 16) + X23 + 72)) + 304) + 8;
            label_9:
            var val_9 = ((X23 + 72) != 0) ? 1 : 0;
            goto label_25;
            label_8:
            var val_11 = (val_21 == true) ? 1 : 0;
            goto label_25;
            label_11:
            var val_21 = X23 + 72;
            val_21 = val_21 + val_24;
            goto label_25;
            label_34:
            var val_22 = X11;
            val_22 = val_22 + val_1;
            val_21 = val_21 + val_22;
            bool val_12 = val_21 + 304;
            label_36:
            val_26 = mem[(((X23 + 72 + X23 + 72) + (X11 + (didCancel & 1))) + 304) + 8];
            val_26 = (((X23 + 72 + X23 + 72) + (X11 + (didCancel & 1))) + 304) + 8;
            label_16:
            var val_13 = (val_24 != 0) ? 1 : 0;
            goto label_25;
            label_13:
            var val_23 = val_18;
            val_23 = val_23 + val_24;
            val_24 = val_24 + val_23;
            val_25 = val_24 + 304;
            label_15:
            var val_14 = (val_21 == true) ? 1 : 0;
            goto label_25;
            label_49:
            val_21 = mem[1152921519535255800];
            if((val_21 & 1) == 0)
            {
                goto label_23;
            }
            
            if((mem[1152921519535255800] + 74) == 2)
            {
                goto label_48;
            }
            
            goto label_25;
            label_23:
            if((mem[1152921519535255800] + 74) != 2)
            {
                goto label_26;
            }
            
            if(mem[1152921519535255792] == 0)
            {
                goto label_27;
            }
            
            if((((mem[1152921519535255800] + 72) == 1) || (((mem[1152921519535255792] + 273) & 1) != 0)) || ((mem[1152921519535255792] + 273) == 0))
            {
                goto label_25;
            }
            
            if((val_21 & 1) == 0)
            {
                goto label_31;
            }
            
            if((val_21 & 1) == 0)
            {
                goto label_32;
            }
            
            if((mem[1152921519535255792] + 294) == 0)
            {
                goto label_36;
            }
            
            var val_25 = mem[1152921519535255792] + 176;
            var val_26 = 0;
            val_25 = val_25 + 8;
            label_35:
            if(((mem[1152921519535255792] + 176 + 8) + -8) == (mem[1152921519535255800] + 24))
            {
                goto label_34;
            }
            
            val_26 = val_26 + 1;
            val_25 = val_25 + 16;
            if(val_26 < (mem[1152921519535255792] + 294))
            {
                goto label_35;
            }
            
            goto label_36;
            label_26:
            if(((mem[1152921519535255800] + 72) == 1) || ((mem[1152921519535255800] + 72) == 0))
            {
                goto label_38;
            }
            
            if((val_21 & 1) == 0)
            {
                goto label_39;
            }
            
            if((val_21 & 1) == 0)
            {
                goto label_40;
            }
            
            var val_27 = 0;
            val_27 = val_27 + 1;
            goto label_44;
            label_38:
            if((mem[1152921519535255792] != 0) || ((val_21.disabledSprite & 1) == 0))
            {
                goto label_48;
            }
            
            goto label_48;
            label_27:
            UnityEngine.Sprite val_16 = val_21.disabledSprite;
            label_48:
            label_25:
            val_28 = val_28 + 1;
            if(val_28 != val_19)
            {
                goto label_49;
            }
        
        }
        public virtual System.IAsyncResult BeginInvoke(System.Collections.Generic.IList<int> result, bool didCancel, System.AsyncCallback callback, object object)
        {
            bool val_1 = didCancel;
            return (System.IAsyncResult)this;
        }
        public virtual void EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
