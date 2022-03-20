using UnityEngine;
private sealed class DisplayWordDefinition.<AppendDots>d__17 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public DisplayWordDefinition <>4__this;
    private int <dots>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DisplayWordDefinition.<AppendDots>d__17(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_5;
        int val_6;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        this.<>1__state = 0;
        this.<dots>5__2 = 0;
        if((this.<>4__this) != null)
        {
            goto label_3;
        }
        
        label_1:
        this.<>1__state = 0;
        label_3:
        if((this.<>4__this.gameObject.activeInHierarchy) == false)
        {
            goto label_7;
        }
        
        if((this.<dots>5__2) <= 2)
        {
            goto label_8;
        }
        
        val_5 = 0;
        goto label_10;
        label_7:
        val_6 = 0;
        return (bool)val_6;
        label_8:
        string val_3 = this.<>4__this.definitionText(this.<>4__this.definitionText) + " . ";
        val_5 = (this.<dots>5__2) + 1;
        label_10:
        this.<dots>5__2 = val_5;
        val_6 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.3f);
        this.<>1__state = val_6;
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
