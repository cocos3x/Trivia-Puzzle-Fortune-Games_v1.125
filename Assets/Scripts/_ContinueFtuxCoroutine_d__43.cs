using UnityEngine;
private sealed class RaidScreenMain.<ContinueFtuxCoroutine>d__43 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordForest.RaidScreenMain <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public RaidScreenMain.<ContinueFtuxCoroutine>d__43(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_5;
        var val_6;
        val_5 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_19;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.ftuxCursors) == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_1 = this.<>4__this.ftuxCursors.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_5;
        }
        
        0.SetActive(value:  false);
        goto label_7;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.forestContent) == null)
        {
                throw new NullReferenceException();
        }
        
        val_5 = 0;
        label_17:
        if((this.<>4__this.forestContent.raidXButtons) == null)
        {
                throw new NullReferenceException();
        }
        
        int val_5 = this.<>4__this.forestContent.raidXButtons.Length;
        if(val_5 >= val_5)
        {
            goto label_19;
        }
        
        if((this.<>4__this.chosenRewardIndexes) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.chosenRewardIndexes.Contains(item:  0)) != true)
        {
                if((this.<>4__this.ftuxCursors) == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_5 >= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + 0;
            if(((this.<>4__this.forestContent.raidXButtons.Length + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            (this.<>4__this.forestContent.raidXButtons.Length + 0) + 32.SetActive(value:  true);
        }
        
        val_5 = val_5 + 1;
        if((this.<>4__this.forestContent) != null)
        {
            goto label_17;
        }
        
        throw new NullReferenceException();
        label_5:
        0.Dispose();
        if((this.<>4__this.chosenRewardIndexes) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.chosenRewardIndexes) <= 2)
        {
                val_6 = 1;
            mem2[0] = new UnityEngine.WaitForSeconds(seconds:  5f);
            mem2[0] = val_6;
            return (bool)val_6;
        }
        
        label_19:
        val_6 = 0;
        return (bool)val_6;
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
