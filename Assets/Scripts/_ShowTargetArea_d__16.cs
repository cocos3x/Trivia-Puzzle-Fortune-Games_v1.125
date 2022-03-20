using UnityEngine;
private sealed class WGSnakesAndLaddersBoardUI.<ShowTargetArea>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SnakesAndLaddersEvent.WGSnakesAndLaddersBoardUI <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSnakesAndLaddersBoardUI.<ShowTargetArea>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_5;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_12;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this.currentBoard.IsSeen) == false)
        {
            goto label_6;
        }
        
        this.<>4__this.SnapToPosition(spaceNum:  this.<>4__this.currentBoard.CurrentNumberSpace);
        goto label_7;
        label_2:
        this.<>1__state = 0;
        UnityEngine.Coroutine val_2 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.ScrollToPosition(startSpace:  this.<>4__this.currentBoard.Definition.MaxSpaceCount, endSpace:  1));
        label_7:
        if((this.<>4__this.currentBoard.CurrentNumberSpace) == 0)
        {
            goto label_12;
        }
        
        this.<>4__this.SpawnPawn(num:  this.<>4__this.currentBoard.CurrentNumberSpace);
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        val_5 = 1;
        return (bool)val_5;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.SetPawnOnTop();
        label_12:
        val_5 = 0;
        return (bool)val_5;
        label_6:
        this.<>4__this.currentBoard.IsSeen = true;
        this.<>4__this.SnapToPosition(spaceNum:  this.<>4__this.currentBoard.Definition.MaxSpaceCount);
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1.2f);
        this.<>1__state = 1;
        return (bool)val_5;
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
