using UnityEngine;
private sealed class WordBubblesController.<LevelCompleteDelay>d__37 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float delay;
    public bool wincondition;
    public SLC.Minigames.Bubbles.WordBubblesController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordBubblesController.<LevelCompleteDelay>d__37(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_9;
        int val_10;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_16;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_9 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  this.delay);
        val_10 = 1;
        this.<>2__current = val_9;
        this.<>1__state = val_10;
        return (bool)val_10;
        label_1:
        val_9 = this.<>4__this;
        this.<>1__state = 0;
        if(this.wincondition == false)
        {
            goto label_4;
        }
        
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) == true)
        {
            goto label_8;
        }
        
        if(val_9 != null)
        {
            goto label_9;
        }
        
        label_4:
        int val_9 = this.<>4__this.remainLives;
        val_9 = val_9 - 1;
        if((this.<>1__state) < 1)
        {
            goto label_12;
        }
        
        this.<>4__this.remainLives = val_9;
        this.<>4__this.<CurrentLevelIndex>k__BackingField = (this.<>4__this.<CurrentLevelIndex>k__BackingField) - 1;
        MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.UpdateLives(count:  this.<>4__this.remainLives);
        label_9:
        val_9.StartLevel();
        goto label_16;
        label_12:
        bool val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        label_8:
        SLC.Minigames.Bubbles.WordBubblesUIController val_8 = MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance;
        val_8.container.SetActive(value:  false);
        label_16:
        val_10 = 0;
        return (bool)val_10;
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
