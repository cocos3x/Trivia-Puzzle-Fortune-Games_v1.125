using UnityEngine;
private sealed class WGSnakesAndLaddersBoardPopup.<ShowRewardOnPawnLanded>d__40 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SnakesAndLaddersEvent.BoardSpaceReward reward;
    public WGSnakesAndLaddersBoardPopup <>4__this;
    public SnakesAndLaddersBoardSpace space;
    private string <source>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersBoardPopup.<ShowRewardOnPawnLanded>d__40(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        decimal val_26;
        int val_27;
        val_26 = this;
        if((this.<>1__state) <= 4)
        {
                var val_24 = 32560096 + (this.<>1__state) << 2;
            val_24 = val_24 + 32560096;
        }
        else
        {
                val_27 = 0;
            return (bool)val_27;
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
