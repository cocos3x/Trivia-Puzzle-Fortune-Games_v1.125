using UnityEngine;
private sealed class WGEventProgressFlyInAwayPopup.<ShowPopup>d__22 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventProgressFlyInAwayPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventProgressFlyInAwayPopup.<ShowPopup>d__22(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        System.Collections.Generic.List<EventProgressPopupData> val_6;
        int val_7;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_15;
        }
        
        this.<>1__state = 0;
        val_6 = this.<>4__this.eventsProgressPopupData;
        if(0 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_6 = this.<>4__this.eventsProgressPopupData;
        }
        
        this.<>4__this.currentEventProgressPopupData = 64;
        val_6.RemoveAt(index:  0);
        this.<>4__this.SetUpUI();
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.PlayFallAnimation());
        val_7 = 1;
        this.<>1__state = val_7;
        return (bool)val_7;
        label_2:
        this.<>1__state = 0;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
        this.<>1__state = 2;
        val_7 = 1;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.currentEventProgressPopupData.onCLose) != null)
        {
                this.<>4__this.currentEventProgressPopupData.onCLose.Invoke();
        }
        
        if((this.<>4__this.eventsProgressPopupData) >= 1)
        {
                UnityEngine.Coroutine val_5 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.ShowPopup());
        }
        else
        {
                this.<>4__this.Close();
        }
        
        label_15:
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
