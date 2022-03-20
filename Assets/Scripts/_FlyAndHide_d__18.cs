using UnityEngine;
private sealed class KeyToRichesTile.<FlyAndHide>d__18 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public KeyToRichesTile <>4__this;
    private UnityEngine.Vector3 <endPos>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public KeyToRichesTile.<FlyAndHide>d__18(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_16;
        int val_18;
        val_16 = this;
        if((this.<>1__state) <= 3)
        {
                var val_16 = 32555092 + (this.<>1__state) << 2;
            val_16 = val_16 + 32555092;
        }
        else
        {
                val_18 = 0;
            return (bool)val_18;
        }
    
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
