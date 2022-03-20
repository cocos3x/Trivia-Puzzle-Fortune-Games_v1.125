using UnityEngine;
private sealed class WGAlphabetCollectionBoxPopup.<AnimateCollecting>d__34 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGAlphabetCollectionBoxPopup <>4__this;
    private System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<string, int>> <>7__wrap1;
    private int <letterIndex>5__3;
    private LineWord <matchingWord>5__4;
    private UnityEngine.GameObject <newOne>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGAlphabetCollectionBoxPopup.<AnimateCollecting>d__34(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if(((this.<>1__state) - 2) >= 8)
        {
            goto label_0;
        }
        
        label_1:
        this.<>m__Finally1();
        return;
        label_0:
        if((this.<>1__state) == 3)
        {
            goto label_1;
        }
    
    }
    private bool MoveNext()
    {
        if((this.<>1__state) > 9)
        {
                return (bool);
        }
        
        var val_77 = 32555300 + (this.<>1__state) << 2;
        val_77 = val_77 + 32555300;
        goto (32555300 + (this.<>1__state) << 2 + 32555300);
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        this.<>7__wrap1.Dispose();
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
