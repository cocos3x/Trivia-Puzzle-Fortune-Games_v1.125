using UnityEngine;
private sealed class WGSnakesAndLaddersBoardUI.<MovePawnAndScrollCoroutine>d__24 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SnakesAndLaddersEvent.WGSnakesAndLaddersBoardUI <>4__this;
    public int start;
    public int end;
    public int final;
    public System.Action onPawnLanded;
    private UnityEngine.Coroutine <scrollCoroutine>5__2;
    private int <i>5__3;
    private SnakesAndLaddersBoardSpace <space>5__4;
    private bool <isDifferentRow>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersBoardUI.<MovePawnAndScrollCoroutine>d__24(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_41;
        if((this.<>1__state) <= 6)
        {
                var val_41 = 32555856 + (this.<>1__state) << 2;
            val_41 = val_41 + 32555856;
        }
        else
        {
                val_41 = 0;
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
