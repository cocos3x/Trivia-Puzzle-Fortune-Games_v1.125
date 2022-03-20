using UnityEngine;
private sealed class SRDependencyServiceBase.<LoadDependencies>d__8<T> : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SRF.Service.SRDependencyServiceBase<T> <>4__this;
    private System.Type[] <>7__wrap1;
    private int <>7__wrap2;
    private SRF.Service.IAsyncService <a>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SRDependencyServiceBase.<LoadDependencies>d__8<T>(int <>1__state)
    {
        mem[1152921519481362656] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.WaitForEndOfFrame val_8;
        System.Type val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        if(true == 1)
        {
            goto label_1;
        }
        
        if(true != 0)
        {
            goto label_28;
        }
        
        mem[1152921519481603232] = 0;
        val_9 = 1152921505009721344;
        val_10 = null;
        val_10 = null;
        int val_8 = SRF.Service.SRServiceManager.LoadingCount;
        val_8 = val_8 + 1;
        SRF.Service.SRServiceManager.LoadingCount = val_8;
        val_11 = 41984000;
        val_12 = this;
        mem[1152921519481603256] = val_11;
        val_13 = 1152921519481603256;
        val_14 = 0;
        mem[1152921519481603264] = 0;
        if(!=0)
        {
            goto label_6;
        }
        
        label_1:
        val_15 = this;
        mem[1152921519481603232] = 0;
        if(X21 != 0)
        {
            goto label_8;
        }
        
        var val_1 = 31469 + ((W9) << 3);
        val_9 = mem[(31469 + (W9) << 3) + 32];
        val_9 = (31469 + (W9) << 3) + 32;
        if((SRF.Service.SRServiceManager.HasService(t:  val_9)) == true)
        {
            goto label_13;
        }
        
        if((SRF.Service.SRServiceManager.GetService(t:  val_9)) == null)
        {
            goto label_16;
        }
        
        val_15 = this;
        val_9 = X0;
        mem[1152921519481603272] = X0;
        if(X0 == false)
        {
            goto label_17;
        }
        
        label_8:
        var val_11 = val_9;
        if((X0 + 294) == 0)
        {
            goto label_21;
        }
        
        var val_9 = X0 + 176;
        var val_10 = 0;
        val_9 = val_9 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_10 = val_10 + 1;
        val_9 = val_9 + 16;
        if(val_10 < (X0 + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_19:
        val_11 = val_11 + (((X0 + 176 + 8)) << 4);
        val_16 = val_11 + 304;
        label_21:
        if(val_9.IsLoaded == false)
        {
            goto label_22;
        }
        
        val_13 = 1152921519481603264;
        val_12 = 1152921519481603256;
        label_17:
        mem[1152921519481603272] = 0;
        label_13:
        mem[1152921519481603264] = val_9;
        label_6:
        mem[1152921519481603256] = 0;
        val_17 = null;
        val_17 = null;
        int val_12 = SRF.Service.SRServiceManager.LoadingCount;
        val_12 = val_12 - 1;
        SRF.Service.SRServiceManager.LoadingCount = val_12;
        goto label_28;
        label_22:
        UnityEngine.WaitForEndOfFrame val_5 = null;
        val_8 = val_5;
        val_5 = new UnityEngine.WaitForEndOfFrame();
        val_18 = 1;
        mem[1152921519481603240] = val_8;
        mem[1152921519481603232] = val_18;
        return (bool)val_18;
        label_16:
        object[] val_6 = new object[1];
        val_9 = val_9;
        val_6[0] = val_9;
        UnityEngine.Debug.LogError(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[Service] Could not resolve dependency ({0})", args:  val_6));
        enabled = false;
        label_28:
        val_18 = 0;
        return (bool)val_18;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this;
    }

}
