using UnityEngine;
private sealed class PiggyBankPopup.<UpdateTimer>d__47 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PiggyBankPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PiggyBankPopup.<UpdateTimer>d__47(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_7;
        object val_8;
        int val_9;
        val_7 = 0;
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 1)
        {
                if((this.<>1__state) != 0)
        {
                return (bool)val_7;
        }
        
            this.<>1__state = 0;
            string val_3 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "deal_ends_in", defaultValue:  "Deal ends in", useSingularKey:  false), arg1:  this.<>4__this.GetDateString());
            UnityEngine.WaitForSeconds val_4 = null;
            val_8 = val_4;
            val_4 = new UnityEngine.WaitForSeconds(seconds:  1f);
            val_9 = 1;
        }
        else
        {
                this.<>1__state = 0;
            UnityEngine.Coroutine val_6 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.UpdateTimer());
            val_8 = 0;
            val_9 = 2;
        }
        
            val_7 = 1;
            this.<>2__current = val_8;
        }
        else
        {
                val_9 = 0;
        }
        
        this.<>1__state = val_9;
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
