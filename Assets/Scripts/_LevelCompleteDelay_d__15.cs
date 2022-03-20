using UnityEngine;
private sealed class WordLadderController.<LevelCompleteDelay>d__15 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float delay;
    public bool wincondition;
    public SLC.Minigames.Ladder.WordLadderController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordLadderController.<LevelCompleteDelay>d__15(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_10;
        }
        
        this.<>1__state = 0;
        val_7 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.delay);
        this.<>1__state = val_7;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        if(this.wincondition == false)
        {
            goto label_4;
        }
        
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) == true)
        {
            goto label_8;
        }
        
        this.<>4__this.StartLevel();
        goto label_10;
        label_4:
        bool val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        label_8:
        SLC.Minigames.Ladder.WordLadderUIController val_6 = MonoSingleton<SLC.Minigames.Ladder.WordLadderUIController>.Instance;
        val_6.container.SetActive(value:  false);
        label_10:
        val_7 = 0;
        return (bool)val_7;
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
