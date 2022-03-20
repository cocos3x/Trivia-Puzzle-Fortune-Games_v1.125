using UnityEngine;
private sealed class WGSnakesAndLaddersDiceRollAnim.<AnimateRandomPointSp>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGSnakesAndLaddersDiceRollAnim <>4__this;
    public int result;
    private System.Collections.Generic.List<UnityEngine.Sprite> <sprites>5__2;
    private float <animationDuration>5__3;
    private System.DateTime <startTime>5__4;
    private int <i>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersDiceRollAnim.<AnimateRandomPointSp>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_13;
        int val_14;
        val_13 = this;
        if((this.<>1__state) <= 6)
        {
                var val_12 = 32560116;
            val_12 = (32560116 + (this.<>1__state) << 2) + val_12;
        }
        else
        {
                val_14 = 0;
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
