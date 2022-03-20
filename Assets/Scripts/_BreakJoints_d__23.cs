using UnityEngine;
private sealed class IceCreamController.<BreakJoints>d__23 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.WordDrop.IceCreamController <>4__this;
    private System.Collections.Generic.List<UnityEngine.HingeJoint2D> <hingeJoints>5__2;
    private float <delay>5__3;
    private int <i>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public IceCreamController.<BreakJoints>d__23(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_18;
        int val_21;
        val_18 = this;
        if((this.<>1__state) <= 3)
        {
                var val_17 = 32560592 + (this.<>1__state) << 2;
            val_17 = val_17 + 32560592;
        }
        else
        {
                val_21 = 0;
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
