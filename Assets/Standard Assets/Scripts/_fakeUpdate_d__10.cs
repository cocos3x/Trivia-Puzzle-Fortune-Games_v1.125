using UnityEngine;
private sealed class UIGradientSpinner.<fakeUpdate>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UIGradientSpinner <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public UIGradientSpinner.<fakeUpdate>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_6;
        if(((this.<>1__state) - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this.enabled) == false)
        {
            goto label_5;
        }
        
        this.<>4__this.doTHing();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.15f);
        this.<>1__state = 2;
        val_6 = 1;
        return (bool)val_6;
        label_1:
        if((this.<>1__state) == 0)
        {
                this.<>1__state = 0;
            val_6 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  UnityEngine.Random.value);
            this.<>1__state = val_6;
            return (bool)val_6;
        }
        
        label_5:
        val_6 = 0;
        return (bool)val_6;
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
