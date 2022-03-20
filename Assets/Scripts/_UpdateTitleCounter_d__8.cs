using UnityEngine;
private sealed class WGEventsListPopup.<UpdateTitleCounter>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventsListPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventsListPopup.<UpdateTitleCounter>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_9;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        val_9 = 0;
        if((this.<>1__state) != 0)
        {
                return (bool)val_9;
        }
        
        this.<>1__state = 0;
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
            goto label_8;
        }
        
        val_9 = 0;
        return (bool)val_9;
        label_2:
        this.<>1__state = 0;
        string val_6 = System.String.Format(format:  "EVENTS ({0})", arg0:  MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount.ToString());
        this.<>2__current = this.<>4__this.UpdateTitleCounter();
        this.<>1__state = 2;
        val_9 = 1;
        return (bool)val_9;
        label_1:
        val_9 = 0;
        this.<>1__state = 0;
        return (bool)val_9;
        label_8:
        val_9 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_9;
        return (bool)val_9;
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
