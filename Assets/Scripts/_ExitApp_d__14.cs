using UnityEngine;
private sealed class SRDebugger_Instantiator.<ExitApp>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int waitSeconds;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SRDebugger_Instantiator.<ExitApp>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<i>5__2 = this.waitSeconds;
        if((this.waitSeconds & 2147483648) != 0)
        {
            goto label_3;
        }
        
        label_7:
        UnityEngine.Debug.LogWarning(message:  "Exiting App in " + this.<i>5__2.ToString()(this.<i>5__2.ToString()));
        val_4 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        int val_4 = this.<i>5__2;
        val_4 = val_4 - 1;
        this.<>1__state = 0;
        this.<i>5__2 = val_4;
        if((val_4 & 2147483648) == 0)
        {
            goto label_7;
        }
        
        label_3:
        UnityEngine.Application.Quit();
        label_2:
        val_4 = 0;
        return (bool)val_4;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
