using UnityEngine;
private sealed class TwistyGameManager.<DelayShowLevelFailed>d__45 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.TwistyArrow.TwistyGameManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TwistyGameManager.<DelayShowLevelFailed>d__45(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_4;
        object val_5;
        int val_6;
        val_4 = 0;
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 1)
        {
                if((this.<>1__state) != 0)
        {
                return (bool)val_4;
        }
        
            this.<>1__state = 0;
            UnityEngine.WaitForSeconds val_1 = null;
            val_5 = val_1;
            val_1 = new UnityEngine.WaitForSeconds(seconds:  0.5f);
            val_6 = 1;
        }
        else
        {
                this.<>1__state = 0;
            if((this.<>4__this.inMinigameFramework) != false)
        {
                bool val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        }
        
            val_5 = 0;
            val_6 = 2;
        }
        
            val_4 = 1;
            this.<>2__current = val_5;
        }
        else
        {
                val_6 = 0;
        }
        
        this.<>1__state = val_6;
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
