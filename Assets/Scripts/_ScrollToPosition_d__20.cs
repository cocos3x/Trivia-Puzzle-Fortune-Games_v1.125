using UnityEngine;
private sealed class WGSnakesAndLaddersBoardUI.<ScrollToPosition>d__20 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SnakesAndLaddersEvent.WGSnakesAndLaddersBoardUI <>4__this;
    public int startSpace;
    public int endSpace;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersBoardUI.<ScrollToPosition>d__20(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_6;
        SnakesAndLaddersEvent.WGSnakesAndLaddersBoardUI val_7;
        if((this.<>1__state) != 0)
        {
                return false;
        }
        
        this.<>1__state = 0;
        val_7 = this.<>4__this;
        WGSnakesAndLaddersBoardUI.<>c__DisplayClass20_0 val_1 = null;
        val_6 = val_1;
        val_1 = new WGSnakesAndLaddersBoardUI.<>c__DisplayClass20_0();
        .<>4__this = this.<>4__this;
        if(this.startSpace == this.endSpace)
        {
                return false;
        }
        
        .fromBottomToTop = (this.startSpace < this.endSpace) ? 1 : 0;
        .interpolation = 32555888 + this.startSpace < this.endSpace ? 1 : 0;
        int val_6 = this.endSpace;
        val_6 = val_6 - 1;
        val_6 = val_6 >> 32;
        int val_4 = val_6 + (val_6 >> 63);
        if(W10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (val_4 << 2);
        .targetScrollPosition = (((this.endSpace - 1) >> 32) + ((((this.endSpace - 1) >> 32) + ((this.endSpace - 1) >> 63))) << 2) + 32;
        this.<>4__this.frameSkipper._framesToSkip = 2;
        val_7 = this.<>4__this.frameSkipper;
        this.<>4__this.frameSkipper.updateLogic = new System.Action(object:  val_1, method:  System.Void WGSnakesAndLaddersBoardUI.<>c__DisplayClass20_0::<ScrollToPosition>b__0());
        return false;
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
