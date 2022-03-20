using UnityEngine;
private sealed class WGSnakesAndLaddersBoardPopup.<ShowDiceRollResult>d__37 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGSnakesAndLaddersBoardPopup <>4__this;
    public SnakesAndLaddersEvent.DiceRollResult result;
    private WGSnakesAndLaddersBoardPopup.<>c__DisplayClass37_0 <>8__1;
    private UnityEngine.Vector3 <originalDiceRollPos>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersBoardPopup.<ShowDiceRollResult>d__37(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_34;
        if((this.<>1__state) <= 3)
        {
                var val_32 = 32560080 + (this.<>1__state) << 2;
            val_32 = val_32 + 32560080;
        }
        else
        {
                val_34 = 0;
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
