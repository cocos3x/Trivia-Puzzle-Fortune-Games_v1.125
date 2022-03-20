using UnityEngine;
public sealed class AnimationState.TrackEntryEventDelegate : MulticastDelegate
{
    // Methods
    public AnimationState.TrackEntryEventDelegate(object object, IntPtr method)
    {
        mem[1152921510534981152] = object;
        mem[1152921510534981160] = method;
        mem[1152921510534981136] = method;
    }
    public virtual void Invoke(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        var val_16;
        var val_17;
        var val_18;
        var val_20;
        var val_21;
        var val_22;
        if(X8 != 0)
        {
                val_16 = mem[X8 + 24];
            val_16 = X8 + 24;
            if(val_16 == 0)
        {
                return;
        }
        
            val_17 = X8 + 32;
        }
        else
        {
                val_16 = 1;
        }
        
        var val_25 = 0;
        Spine.TrackEntry val_1 = trackEntry - 16;
        Spine.Event val_2 = e - 16;
        goto label_49;
        label_39:
        val_18 = mem[X24 + 72];
        val_18 = X24 + 72;
        if((this & 1) == 0)
        {
            goto label_4;
        }
        
        UnityEngine.Sprite val_3 = X24.disabledSprite;
        var val_14 = 0;
        val_14 = val_14 + 1;
        goto label_25;
        label_40:
        Spine.TrackEntry val_4 = 1152921504862277632 + ((X24 + 72) << 4);
        val_20 = mem[(1152921504862277632 + (X24 + 72) << 4) + 312];
        goto label_25;
        label_4:
        Spine.TrackEntry val_5 = 1152921504862277632 + val_18;
        goto label_25;
        label_31:
        if((trackEntry.Equals(obj:  e)) == false)
        {
            goto label_11;
        }
        
        var val_21 = val_18;
        if((X24 + 72 + 294) == 0)
        {
            goto label_25;
        }
        
        var val_15 = X24 + 72 + 176;
        var val_16 = 0;
        val_15 = val_15 + 8;
        label_14:
        if(((X24 + 72 + 176 + 8) + -8) == X24.disabledSprite)
        {
            goto label_13;
        }
        
        val_16 = val_16 + 1;
        val_15 = val_15 + 16;
        if(val_16 < (X24 + 72 + 294))
        {
            goto label_14;
        }
        
        goto label_25;
        label_32:
        var val_8 = val_18 + ((X24 + 72) << 4);
        val_22 = mem[(X24 + 72 + (X24 + 72) << 4) + 312];
        val_22 = (X24 + 72 + (X24 + 72) << 4) + 312;
        goto label_25;
        label_44:
        val_20 = mem[(((X24 + 72 + (X24 + 72) << 4) + (((X24 + 72 + 176 + 8) + 16) + X24 + 72)) + 304) + 8];
        val_20 = (((X24 + 72 + (X24 + 72) << 4) + (((X24 + 72 + 176 + 8) + 16) + X24 + 72)) + 304) + 8;
        goto label_25;
        label_11:
        var val_18 = val_18;
        val_18 = val_18 + (X24 + 72);
        goto label_25;
        label_34:
        var val_19 = X11;
        val_19 = val_19 + e;
        val_18 = val_18 + val_19;
        Spine.Event val_11 = val_18 + 304;
        goto label_25;
        label_13:
        var val_20 = val_15;
        val_20 = val_20 + (X24 + 72);
        val_21 = val_21 + val_20;
        val_21 = val_21 + 304;
        goto label_25;
        label_49:
        val_18 = mem[1152921510535121824];
        if((mem[1152921510535121832] & 1) == 0)
        {
            goto label_23;
        }
        
        if((mem[1152921510535121832] + 74) == 2)
        {
            goto label_48;
        }
        
        goto label_25;
        label_23:
        if((mem[1152921510535121832] + 74) != 2)
        {
            goto label_26;
        }
        
        if(val_18 == 0)
        {
            goto label_27;
        }
        
        if((((mem[1152921510535121832] + 72) == 1) || (((mem[1152921510535121824] + 273) & 1) != 0)) || ((mem[1152921510535121824] + 273) == 0))
        {
            goto label_25;
        }
        
        if((mem[1152921510535121832] & 1) == 0)
        {
            goto label_31;
        }
        
        if((mem[1152921510535121832] & 1) == 0)
        {
            goto label_32;
        }
        
        if((mem[1152921510535121824] + 294) == 0)
        {
            goto label_25;
        }
        
        var val_22 = mem[1152921510535121824] + 176;
        var val_23 = 0;
        val_22 = val_22 + 8;
        label_35:
        if(((mem[1152921510535121824] + 176 + 8) + -8) == (mem[1152921510535121832] + 24))
        {
            goto label_34;
        }
        
        val_23 = val_23 + 1;
        val_22 = val_22 + 16;
        if(val_23 < (mem[1152921510535121824] + 294))
        {
            goto label_35;
        }
        
        goto label_25;
        label_26:
        if(((mem[1152921510535121832] + 72) == 1) || ((mem[1152921510535121832] + 72) == 0))
        {
            goto label_38;
        }
        
        if((mem[1152921510535121832] & 1) == 0)
        {
            goto label_39;
        }
        
        if((mem[1152921510535121832] & 1) == 0)
        {
            goto label_40;
        }
        
        var val_24 = 0;
        val_24 = val_24 + 1;
        goto label_44;
        label_38:
        if((val_18 != 0) || ((mem[1152921510535121832].disabledSprite & 1) == 0))
        {
            goto label_48;
        }
        
        goto label_48;
        label_27:
        UnityEngine.Sprite val_13 = mem[1152921510535121832].disabledSprite;
        label_48:
        label_25:
        val_25 = val_25 + 1;
        if(val_25 != val_16)
        {
            goto label_49;
        }
    
    }
    public virtual System.IAsyncResult BeginInvoke(Spine.TrackEntry trackEntry, Spine.Event e, System.AsyncCallback callback, object object)
    {
        return (System.IAsyncResult)this;
    }
    public virtual void EndInvoke(System.IAsyncResult result)
    {
    
    }

}
