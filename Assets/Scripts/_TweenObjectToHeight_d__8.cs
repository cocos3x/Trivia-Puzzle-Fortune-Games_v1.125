using UnityEngine;
private sealed class SlotMachineReel.<TweenObjectToHeight>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.GameObject reelObject;
    public float targetHeight;
    public int extraRounds;
    public SlotMachineReel <>4__this;
    public System.Action callBack;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SlotMachineReel.<TweenObjectToHeight>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_38;
        if((this.<>1__state) <= 5)
        {
                var val_36 = 32561796 + (this.<>1__state) << 2;
            val_36 = val_36 + 32561796;
        }
        else
        {
                val_38 = 0;
            return (bool);
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
