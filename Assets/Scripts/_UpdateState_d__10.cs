using UnityEngine;
private sealed class WGDailyChallengeButton.<UpdateState>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeButton.<UpdateState>d__10(int <>1__state)
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
            val_1 = new UnityEngine.WaitForSeconds(seconds:  1f);
            val_6 = 1;
        }
        else
        {
                this.<>1__state = 0;
            WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
            this.<>4__this.Button_DailyChallenge.interactable = val_2.<IsDataReady>k__BackingField;
            this.<>4__this.UpdateButtonState();
            val_5 = this.<>4__this.UpdateState();
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
