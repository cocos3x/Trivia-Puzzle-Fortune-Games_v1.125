using UnityEngine;

namespace SRDebugger.Services
{
    public sealed class BugReportCompleteCallback : MulticastDelegate
    {
        // Methods
        public BugReportCompleteCallback(object object, IntPtr method)
        {
            mem[1152921519550202720] = object;
            mem[1152921519550202728] = method;
            mem[1152921519550202704] = method;
        }
        public virtual void Invoke(bool didSucceed, string errorMessage)
        {
            var val_10;
            var val_11;
            bool val_12;
            var val_13;
            var val_14;
            bool val_1 = didSucceed;
            if(val_1 != false)
            {
                    val_10 = mem[(didSucceed & 1) + 24];
                val_10 = (didSucceed & 1) + 24;
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
            if((this & 1) == 0)
            {
                goto label_4;
            }
            
            var val_13 = X22;
            val_12 = val_1;
            if((X22 + 294) == 0)
            {
                goto label_8;
            }
            
            var val_8 = X22 + 176;
            var val_9 = 0;
            val_8 = val_8 + 8;
            label_7:
            if(((X22 + 176 + 8) + -8) == X23.disabledSprite)
            {
                goto label_6;
            }
            
            val_9 = val_9 + 1;
            val_8 = val_8 + 16;
            if(val_9 < (X22 + 294))
            {
                goto label_7;
            }
            
            goto label_8;
            label_22:
            var val_3 = X22 + (((didSucceed & 1) + 72) << 4);
            val_14 = mem[(X22 + ((didSucceed & 1) + 72) << 4) + 312];
            val_14 = (X22 + ((didSucceed & 1) + 72) << 4) + 312;
            goto label_9;
            label_4:
            var val_10 = X22;
            val_10 = val_10 + (X23 + 72);
            goto label_16;
            label_24:
            var val_11 = X11;
            val_11 = val_11 + errorMessage;
            val_10 = val_10 + val_11;
            string val_4 = val_10 + 304;
            label_26:
            label_9:
            var val_5 = ((X23 + 72) != 0) ? 1 : 0;
            goto label_16;
            label_6:
            var val_12 = val_8;
            val_12 = val_12 + (X23 + 72);
            val_13 = val_13 + val_12;
            val_13 = val_13 + 304;
            label_8:
            var val_6 = (val_12 == true) ? 1 : 0;
            goto label_16;
            label_28:
            val_12 = mem[1152921519550331112];
            if((val_12 & 1) == 0)
            {
                goto label_14;
            }
            
            if((mem[1152921519550331112] + 74) != 2)
            {
                goto label_27;
            }
            
            goto label_16;
            label_14:
            if(mem[1152921519550331104] == 0)
            {
                goto label_17;
            }
            
            if((((mem[1152921519550331112] + 72) == 1) || (((mem[1152921519550331104] + 273) & 1) != 0)) || ((mem[1152921519550331104] + 273) == 0))
            {
                goto label_27;
            }
            
            if((val_12 & 1) == 0)
            {
                goto label_21;
            }
            
            if((val_12 & 1) == 0)
            {
                goto label_22;
            }
            
            if((mem[1152921519550331104] + 294) == 0)
            {
                goto label_26;
            }
            
            var val_14 = mem[1152921519550331104] + 176;
            var val_15 = 0;
            val_14 = val_14 + 8;
            label_25:
            if(((mem[1152921519550331104] + 176 + 8) + -8) == (mem[1152921519550331112] + 24))
            {
                goto label_24;
            }
            
            val_15 = val_15 + 1;
            val_14 = val_14 + 16;
            if(val_15 < (mem[1152921519550331104] + 294))
            {
                goto label_25;
            }
            
            goto label_26;
            label_17:
            if((val_12.disabledSprite & 1) != 0)
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
        public virtual System.IAsyncResult BeginInvoke(bool didSucceed, string errorMessage, System.AsyncCallback callback, object object)
        {
            bool val_1 = didSucceed;
            return (System.IAsyncResult)this;
        }
        public virtual void EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
