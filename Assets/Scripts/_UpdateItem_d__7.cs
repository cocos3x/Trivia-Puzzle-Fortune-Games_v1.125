using UnityEngine;
private sealed class EventListItem.<UpdateItem>d__7 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public EventListItem <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public EventListItem.<UpdateItem>d__7(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Object val_4;
        int val_5;
        val_4 = this;
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 1)
        {
                if((this.<>1__state) == 0)
        {
                this.<>1__state = 0;
            if((this.<>4__this.myHandler) != null)
        {
                if(((this.<>4__this.myHandler) & 1) == 0)
        {
            goto label_6;
        }
        
        }
        
            val_4 = this.<>4__this.gameObject;
            UnityEngine.Object.Destroy(obj:  val_4);
        }
        
            val_5 = 0;
            return (bool)val_5;
        }
        
            this.<>1__state = 0;
            this.<>4__this.SetTimerText(timeEnd:  new System.DateTime() {dateData = this.<>4__this.myHandler});
            this.<>2__current = this.<>4__this.UpdateItem();
            this.<>1__state = 2;
            val_5 = 1;
            return (bool)val_5;
        }
        
        val_5 = 0;
        this.<>1__state = 0;
        return (bool)val_5;
        label_6:
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_5;
        return (bool)val_5;
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
