using UnityEngine;
private sealed class WordFillManager.<OnStartNextLevel>d__39 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.WordFill.WordFillManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordFillManager.<OnStartNextLevel>d__39(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        SLC.Minigames.WordFill.WordFillManager val_3;
        int val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        val_4 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        val_3 = this.<>4__this;
        this.<>1__state = 0;
        val_3.CreateLevel();
        MonoSingleton<WordFillFTUXManager>.Instance.SetLevel(lev:  this.<>4__this.<playerLevel>k__BackingField);
        MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance.StartLevel(level:  this.<>4__this.currentLevel);
        label_2:
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
