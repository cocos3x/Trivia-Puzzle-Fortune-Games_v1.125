using UnityEngine;
private sealed class SRDebugger_Instantiator.<BloatTheMemory>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SRDebugger_Instantiator <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SRDebugger_Instantiator.<BloatTheMemory>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        if((this.<>1__state) <= 1)
        {
                this.<>1__state = 0;
            this.<>4__this.wastedMemory.Add(item:  new UnityEngine.Texture2D(width:  512, height:  512, textureFormat:  5, mipChain:  false));
            val_3 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
            this.<>1__state = val_3;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
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
