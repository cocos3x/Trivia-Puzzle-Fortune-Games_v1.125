using UnityEngine;
public sealed class WordGameEventsController.ProxyEventTrackingDelegate : MulticastDelegate
{
    // Methods
    public WordGameEventsController.ProxyEventTrackingDelegate(object object, IntPtr method)
    {
        mem[1152921516399524512] = object;
        mem[1152921516399524520] = method;
        mem[1152921516399524496] = method;
    }
    public virtual object Invoke(ref System.Collections.Generic.Dictionary<string, object> trackingData)
    {
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        if(X8 == 0)
        {
            goto label_0;
        }
        
        val_7 = mem[X8 + 24];
        val_7 = X8 + 24;
        if(val_7 == 0)
        {
            goto label_1;
        }
        
        val_8 = X8 + 32;
        goto label_2;
        label_0:
        val_7 = 1;
        label_2:
        var val_13 = 0;
        goto label_29;
        label_21:
        if((this & 1) == 0)
        {
            goto label_4;
        }
        
        var val_10 = X22;
        if((X22 + 294) == 0)
        {
            goto label_8;
        }
        
        var val_5 = X22 + 176;
        var val_6 = 0;
        val_5 = val_5 + 8;
        label_7:
        if(((X22 + 176 + 8) + -8) == X23.disabledSprite)
        {
            goto label_6;
        }
        
        val_6 = val_6 + 1;
        val_5 = val_5 + 16;
        if(val_6 < (X22 + 294))
        {
            goto label_7;
        }
        
        goto label_8;
        label_22:
        var val_2 = X22 + ((X23 + 72) << 4);
        val_10 = mem[(X22 + (X23 + 72) << 4) + 312];
        val_10 = (X22 + (X23 + 72) << 4) + 312;
        goto label_11;
        label_4:
        var val_7 = X22;
        val_11 = X22;
        val_7 = val_7 + (X23 + 72);
        goto label_27;
        label_24:
        var val_8 = X11;
        val_8 = val_8 + ((X22 + X23 + 72) + 304 + 8);
        val_7 = val_7 + val_8;
        var val_3 = val_7 + 304;
        label_26:
        val_10 = mem[(((X22 + X23 + 72) + (X11 + (X22 + X23 + 72) + 304 + 8)) + 304) + 8];
        val_10 = (((X22 + X23 + 72) + (X11 + (X22 + X23 + 72) + 304 + 8)) + 304) + 8;
        goto label_11;
        label_6:
        var val_9 = val_5;
        val_9 = val_9 + (X23 + 72);
        val_10 = val_10 + val_9;
        val_9 = val_10 + 304;
        label_8:
        label_11:
        val_11 = X22;
        goto label_27;
        label_29:
        if((mem[1152921516399652824] & 1) == 0)
        {
            goto label_14;
        }
        
        if((mem[1152921516399652824] + 74) != 1)
        {
            goto label_20;
        }
        
        goto label_28;
        label_14:
        if(mem[1152921516399652816] == 0)
        {
            goto label_17;
        }
        
        if((((mem[1152921516399652824] + 72) == 1) || (((mem[1152921516399652816] + 273) & 1) != 0)) || ((mem[1152921516399652816] + 273) == 0))
        {
            goto label_20;
        }
        
        if((mem[1152921516399652824] & 1) == 0)
        {
            goto label_21;
        }
        
        if((mem[1152921516399652824] & 1) == 0)
        {
            goto label_22;
        }
        
        if((mem[1152921516399652816] + 294) == 0)
        {
            goto label_26;
        }
        
        var val_11 = mem[1152921516399652816] + 176;
        var val_12 = 0;
        val_11 = val_11 + 8;
        label_25:
        if(((mem[1152921516399652816] + 176 + 8) + -8) == (mem[1152921516399652824] + 24))
        {
            goto label_24;
        }
        
        val_12 = val_12 + 1;
        val_11 = val_11 + 16;
        if(val_12 < (mem[1152921516399652816] + 294))
        {
            goto label_25;
        }
        
        goto label_26;
        label_20:
        val_11 = mem[1152921516399652816];
        goto label_27;
        label_17:
        UnityEngine.Sprite val_4 = mem[1152921516399652824].disabledSprite;
        label_28:
        val_11 = 1152921516399684784;
        label_27:
        val_13 = val_13 + 1;
        if(val_13 != val_7)
        {
            goto label_29;
        }
        
        return (object)val_11;
        label_1:
        val_11 = 0;
        return (object)val_11;
    }
    public virtual System.IAsyncResult BeginInvoke(ref System.Collections.Generic.Dictionary<string, object> trackingData, System.AsyncCallback callback, object object)
    {
        return (System.IAsyncResult)this;
    }
    public virtual object EndInvoke(ref System.Collections.Generic.Dictionary<string, object> trackingData, System.IAsyncResult result)
    {
        return (object)result;
    }

}
