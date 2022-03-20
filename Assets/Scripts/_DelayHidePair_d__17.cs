using UnityEngine;
private sealed class WordMemoryUIController.<DelayHidePair>d__17 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.WordMemory.WordMemoryUIController <>4__this;
    public int card1;
    public int card2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordMemoryUIController.<DelayHidePair>d__17(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        int val_4;
        val_3 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_4 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        int val_3 = 0;
        this.<>1__state = val_3;
        if(val_3 <= this.card1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + ((this.card1) << 3);
        (0 + (this.card1) << 3) + 32.Hide();
        val_3 = this.card2;
        if(val_3 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + ((this.card2) << 3);
        ((0 + (this.card1) << 3) + (this.card2) << 3) + 32.Hide();
        SLC.Minigames.WordMemory.WordMemoryManager val_2 = MonoSingleton<SLC.Minigames.WordMemory.WordMemoryManager>.Instance;
        val_4 = 0;
        val_2.<Locked>k__BackingField = false;
        return (bool)val_4;
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
