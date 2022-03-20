using UnityEngine;
private sealed class WhackUIController.<displayResult>d__30 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.Whack.WhackUIController <>4__this;
    public SLC.Minigames.Whack.WhackItem item;
    public bool won;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WhackUIController.<displayResult>d__30(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_16;
        }
        
        this.<>1__state = 0;
        this.<>4__this.paused = true;
        this.<>4__this.firstLevelThisSession = false;
        this.<>4__this.setAllWackItemsClickable(clickable:  false);
        if(this.item != 0)
        {
                this.item.SetDisplayState(state:  2);
        }
        
        this.<>4__this.HammerHit(hitDude:  this.item);
        val_4 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        this.<>1__state = 0;
        if(this.won != false)
        {
                MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.CheckCheckpoint();
        }
        
        this.<>4__this.hammer.SetActive(value:  false);
        if(this.won != false)
        {
                this.<>4__this.UIWon(item:  0);
        }
        else
        {
                this.<>4__this.UILose(item:  this.item);
        }
        
        label_16:
        val_4 = 0;
        return (bool)val_4;
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
