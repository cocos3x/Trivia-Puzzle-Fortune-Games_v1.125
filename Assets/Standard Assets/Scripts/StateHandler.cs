using UnityEngine;
private sealed class Lexer.StateHandler : MulticastDelegate
{
    // Methods
    public Lexer.StateHandler(object object, IntPtr method)
    {
        mem[1152921513368771312] = object;
        mem[1152921513368771320] = method;
        mem[1152921513368771296] = method;
    }
    public virtual bool Invoke(LitJson.FsmContext ctx)
    {
        var val_14;
        var val_15;
        var val_16;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        if(X8 == 0)
        {
            goto label_0;
        }
        
        val_14 = mem[X8 + 24];
        val_14 = X8 + 24;
        if(val_14 == 0)
        {
            goto label_1;
        }
        
        val_15 = X8 + 32;
        goto label_2;
        label_0:
        val_14 = 1;
        label_2:
        var val_23 = 0;
        LitJson.FsmContext val_1 = ctx - 16;
        goto label_46;
        label_39:
        val_16 = mem[X22 + 72];
        val_16 = X22 + 72;
        if((this & 1) == 0)
        {
            goto label_4;
        }
        
        UnityEngine.Sprite val_2 = X22.disabledSprite;
        var val_12 = 0;
        val_12 = val_12 + 1;
        goto label_8;
        label_40:
        LitJson.FsmContext val_3 = 1152921504871223296 + ((X22 + 72) << 4);
        val_18 = mem[(1152921504871223296 + (X22 + 72) << 4) + 312];
        goto label_17;
        label_4:
        val_19 = ctx;
        LitJson.FsmContext val_4 = 1152921504871223296 + val_16;
        goto label_25;
        label_31:
        if((val_19.Equals(obj:  mem[(1152921504871223296 + X22 + 72) + 304 + 8])) == false)
        {
            goto label_11;
        }
        
        var val_19 = val_16;
        if((X22 + 72 + 294) == 0)
        {
            goto label_15;
        }
        
        var val_13 = X22 + 72 + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_14:
        if(((X22 + 72 + 176 + 8) + -8) == X22.disabledSprite)
        {
            goto label_13;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (X22 + 72 + 294))
        {
            goto label_14;
        }
        
        goto label_15;
        label_32:
        var val_7 = val_16 + ((X22 + 72) << 4);
        val_21 = mem[(X22 + 72 + (X22 + 72) << 4) + 312];
        val_21 = (X22 + 72 + (X22 + 72) << 4) + 312;
        goto label_20;
        label_44:
        val_18 = mem[(((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8];
        val_18 = (((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8;
        goto label_17;
        label_8:
        label_17:
        val_19 = ctx;
        goto label_25;
        label_11:
        var val_16 = val_16;
        val_19 = val_16;
        val_16 = val_16 + (X22 + 72);
        goto label_25;
        label_34:
        var val_17 = X11;
        val_17 = val_17 + ((X22 + 72 + X22 + 72) + 304 + 8);
        val_16 = val_16 + val_17;
        var val_10 = val_16 + 304;
        label_36:
        val_21 = mem[(((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8];
        val_21 = (((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8;
        goto label_20;
        label_13:
        var val_18 = val_13;
        val_18 = val_18 + (X22 + 72);
        val_19 = val_19 + val_18;
        val_20 = val_19 + 304;
        label_15:
        label_20:
        val_19 = val_16;
        goto label_25;
        label_46:
        val_16 = mem[1152921513368903792];
        if((mem[1152921513368903800] & 1) == 0)
        {
            goto label_23;
        }
        
        if((mem[1152921513368903800] + 74) == 1)
        {
            goto label_45;
        }
        
        label_30:
        val_19 = val_16;
        goto label_25;
        label_23:
        if((mem[1152921513368903800] + 74) != 1)
        {
            goto label_26;
        }
        
        if(val_16 == 0)
        {
            goto label_27;
        }
        
        if((((mem[1152921513368903800] + 72) == 1) || (((mem[1152921513368903792] + 273) & 1) != 0)) || ((mem[1152921513368903792] + 273) == 0))
        {
            goto label_30;
        }
        
        if((mem[1152921513368903800] & 1) == 0)
        {
            goto label_31;
        }
        
        if((mem[1152921513368903800] & 1) == 0)
        {
            goto label_32;
        }
        
        if((mem[1152921513368903792] + 294) == 0)
        {
            goto label_36;
        }
        
        var val_20 = mem[1152921513368903792] + 176;
        var val_21 = 0;
        val_20 = val_20 + 8;
        label_35:
        if(((mem[1152921513368903792] + 176 + 8) + -8) == (mem[1152921513368903800] + 24))
        {
            goto label_34;
        }
        
        val_21 = val_21 + 1;
        val_20 = val_20 + 16;
        if(val_21 < (mem[1152921513368903792] + 294))
        {
            goto label_35;
        }
        
        goto label_36;
        label_26:
        if(((mem[1152921513368903800] + 72) == 1) || ((mem[1152921513368903800] + 72) == 0))
        {
            goto label_45;
        }
        
        if((mem[1152921513368903800] & 1) == 0)
        {
            goto label_39;
        }
        
        if((mem[1152921513368903800] & 1) == 0)
        {
            goto label_40;
        }
        
        var val_22 = 0;
        val_22 = val_22 + 1;
        goto label_44;
        label_27:
        UnityEngine.Sprite val_11 = mem[1152921513368903800].disabledSprite;
        label_45:
        val_19 = ctx;
        label_25:
        val_23 = val_23 + 1;
        if(val_23 != val_14)
        {
            goto label_46;
        }
        
        goto label_47;
        label_1:
        val_19 = 0;
        label_47:
        val_19 = val_19 & 1;
        return (bool)val_19;
    }
    public virtual System.IAsyncResult BeginInvoke(LitJson.FsmContext ctx, System.AsyncCallback callback, object object)
    {
        return (System.IAsyncResult)this;
    }
    public virtual bool EndInvoke(System.IAsyncResult result)
    {
        return (bool)null;
    }

}
