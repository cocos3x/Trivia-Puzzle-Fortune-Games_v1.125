using UnityEngine;

namespace SRDebugger.Services
{
    public sealed class ConsoleUpdatedEventHandler : MulticastDelegate
    {
        // Methods
        public ConsoleUpdatedEventHandler(object object, IntPtr method)
        {
            mem[1152921519551229792] = object;
            mem[1152921519551229800] = method;
            mem[1152921519551229776] = method;
        }
        public virtual void Invoke(SRDebugger.Services.IConsoleService console)
        {
            var val_13;
            var val_14;
            var val_15;
            var val_17;
            var val_18;
            var val_19;
            if(X8 != 0)
            {
                    val_13 = mem[X8 + 24];
                val_13 = X8 + 24;
                if(val_13 == 0)
            {
                    return;
            }
            
                val_14 = X8 + 32;
            }
            else
            {
                    val_13 = 1;
            }
            
            var val_22 = 0;
            SRDebugger.Services.IConsoleService val_1 = console - 16;
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
            goto label_25;
            label_40:
            SRDebugger.Services.IConsoleService val_3 = 1152921505014726656 + ((X22 + 72) << 4);
            val_17 = mem[(1152921505014726656 + (X22 + 72) << 4) + 312];
            goto label_25;
            label_4:
            SRDebugger.Services.IConsoleService val_4 = 1152921505014726656 + val_15;
            goto label_25;
            label_31:
            if((console & 1) == 0)
            {
                goto label_11;
            }
            
            var val_18 = val_15;
            if((X22 + 72 + 294) == 0)
            {
                goto label_25;
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
            
            goto label_25;
            label_32:
            var val_6 = val_15 + ((X22 + 72) << 4);
            val_19 = mem[(X22 + 72 + (X22 + 72) << 4) + 312];
            val_19 = (X22 + 72 + (X22 + 72) << 4) + 312;
            goto label_25;
            label_44:
            val_17 = mem[(((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8];
            val_17 = (((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8;
            goto label_25;
            label_11:
            var val_15 = val_15;
            val_15 = val_15 + (X22 + 72);
            goto label_25;
            label_34:
            var val_16 = X11;
            val_16 = val_16 + ((X22 + 72 + X22 + 72) + 304 + 8);
            val_15 = val_15 + val_16;
            var val_9 = val_15 + 304;
            label_36:
            val_19 = mem[(((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8];
            val_19 = (((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8;
            goto label_25;
            label_13:
            var val_17 = val_12;
            val_17 = val_17 + (X22 + 72);
            val_18 = val_18 + val_17;
            val_18 = val_18 + 304;
            goto label_25;
            label_46:
            val_15 = mem[1152921519551362272];
            if((mem[1152921519551362280] & 1) == 0)
            {
                goto label_23;
            }
            
            if((mem[1152921519551362280] + 74) == 1)
            {
                goto label_45;
            }
            
            goto label_25;
            label_23:
            if((mem[1152921519551362280] + 74) != 1)
            {
                goto label_26;
            }
            
            if(val_15 == 0)
            {
                goto label_27;
            }
            
            if((((mem[1152921519551362280] + 72) == 1) || (((mem[1152921519551362272] + 273) & 1) != 0)) || ((mem[1152921519551362272] + 273) == 0))
            {
                goto label_25;
            }
            
            if((mem[1152921519551362280] & 1) == 0)
            {
                goto label_31;
            }
            
            if((mem[1152921519551362280] & 1) == 0)
            {
                goto label_32;
            }
            
            if((mem[1152921519551362272] + 294) == 0)
            {
                goto label_36;
            }
            
            var val_19 = mem[1152921519551362272] + 176;
            var val_20 = 0;
            val_19 = val_19 + 8;
            label_35:
            if(((mem[1152921519551362272] + 176 + 8) + -8) == (mem[1152921519551362280] + 24))
            {
                goto label_34;
            }
            
            val_20 = val_20 + 1;
            val_19 = val_19 + 16;
            if(val_20 < (mem[1152921519551362272] + 294))
            {
                goto label_35;
            }
            
            goto label_36;
            label_26:
            if(((mem[1152921519551362280] + 72) == 1) || ((mem[1152921519551362280] + 72) == 0))
            {
                goto label_45;
            }
            
            if((mem[1152921519551362280] & 1) == 0)
            {
                goto label_39;
            }
            
            if((mem[1152921519551362280] & 1) == 0)
            {
                goto label_40;
            }
            
            var val_21 = 0;
            val_21 = val_21 + 1;
            goto label_44;
            label_27:
            UnityEngine.Sprite val_10 = mem[1152921519551362280].disabledSprite;
            label_45:
            label_25:
            val_22 = val_22 + 1;
            if(val_22 != val_13)
            {
                goto label_46;
            }
        
        }
        public virtual System.IAsyncResult BeginInvoke(SRDebugger.Services.IConsoleService console, System.AsyncCallback callback, object object)
        {
            return (System.IAsyncResult)this;
        }
        public virtual void EndInvoke(System.IAsyncResult result)
        {
        
        }
    
    }

}
