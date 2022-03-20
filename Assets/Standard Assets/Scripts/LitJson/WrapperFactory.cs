using UnityEngine;

namespace LitJson
{
    public sealed class WrapperFactory : MulticastDelegate
    {
        // Methods
        public WrapperFactory(object object, IntPtr method)
        {
            mem[1152921513338824496] = object;
            mem[1152921513338824504] = method;
            mem[1152921513338824480] = method;
        }
        public virtual LitJson.IJsonWrapper Invoke()
        {
            var val_6;
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            if(X8 == 0)
            {
                goto label_0;
            }
            
            val_6 = mem[X8 + 24];
            val_6 = X8 + 24;
            if(val_6 == 0)
            {
                goto label_1;
            }
            
            val_7 = X8 + 32;
            goto label_2;
            label_0:
            val_6 = 1;
            label_2:
            var val_12 = 0;
            goto label_27;
            label_21:
            if((this & 1) == 0)
            {
                goto label_4;
            }
            
            var val_9 = X20;
            if((X20 + 294) == 0)
            {
                goto label_8;
            }
            
            var val_4 = X20 + 176;
            var val_5 = 0;
            val_4 = val_4 + 8;
            label_7:
            if(((X20 + 176 + 8) + -8) == X21.disabledSprite)
            {
                goto label_6;
            }
            
            val_5 = val_5 + 1;
            val_4 = val_4 + 16;
            if(val_5 < (X20 + 294))
            {
                goto label_7;
            }
            
            goto label_8;
            label_22:
            var val_2 = X20 + ((X21 + 72) << 4);
            val_9 = mem[(X20 + (X21 + 72) << 4) + 312];
            val_9 = (X20 + (X21 + 72) << 4) + 312;
            goto label_11;
            label_4:
            var val_6 = X20;
            val_10 = X20;
            val_6 = val_6 + (X21 + 72);
            goto label_16;
            label_24:
            var val_7 = X11;
            val_7 = val_7 + W2;
            val_6 = val_6 + val_7;
            var val_3 = val_6 + 304;
            label_26:
            val_9 = mem[(((X20 + X21 + 72) + (X11 + W2)) + 304) + 8];
            val_9 = (((X20 + X21 + 72) + (X11 + W2)) + 304) + 8;
            goto label_11;
            label_6:
            var val_8 = val_4;
            val_8 = val_8 + (X21 + 72);
            val_9 = val_9 + val_8;
            val_8 = val_9 + 304;
            label_8:
            label_11:
            val_10 = X20;
            goto label_16;
            label_27:
            if((mem[1152921513338944696] & 1) == 0)
            {
                goto label_14;
            }
            
            if((mem[1152921513338944696] + 74) != 0)
            {
                goto label_20;
            }
            
            val_10 = mem[1152921513338944696];
            goto label_16;
            label_14:
            if((((mem[1152921513338944688] == 0) || ((mem[1152921513338944696] + 72) == 1)) || (((mem[1152921513338944688] + 273) & 1) != 0)) || ((mem[1152921513338944688] + 273) == 0))
            {
                goto label_20;
            }
            
            if((mem[1152921513338944696] & 1) == 0)
            {
                goto label_21;
            }
            
            if((mem[1152921513338944696] & 1) == 0)
            {
                goto label_22;
            }
            
            if((mem[1152921513338944688] + 294) == 0)
            {
                goto label_26;
            }
            
            var val_10 = mem[1152921513338944688] + 176;
            var val_11 = 0;
            val_10 = val_10 + 8;
            label_25:
            if(((mem[1152921513338944688] + 176 + 8) + -8) == (mem[1152921513338944696] + 24))
            {
                goto label_24;
            }
            
            val_11 = val_11 + 1;
            val_10 = val_10 + 16;
            if(val_11 < (mem[1152921513338944688] + 294))
            {
                goto label_25;
            }
            
            goto label_26;
            label_20:
            val_10 = mem[1152921513338944688];
            label_16:
            val_12 = val_12 + 1;
            if(val_12 != val_6)
            {
                goto label_27;
            }
            
            return (LitJson.IJsonWrapper)val_10;
            label_1:
            val_10 = 0;
            return (LitJson.IJsonWrapper)val_10;
        }
        public virtual System.IAsyncResult BeginInvoke(System.AsyncCallback callback, object object)
        {
            return (System.IAsyncResult)this;
        }
        public virtual LitJson.IJsonWrapper EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
