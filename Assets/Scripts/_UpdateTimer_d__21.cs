using UnityEngine;
private sealed class SuperBundleEventPopup.<UpdateTimer>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SuperBundleEventPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SuperBundleEventPopup.<UpdateTimer>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_9;
        int val_10;
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
            goto label_3;
        }
        
        this.<>1__state = 0;
        string val_3 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "deal_ends_in", defaultValue:  "Deal ends in", useSingularKey:  false), arg1:  this.<>4__this.GetDateString());
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.<>4__this.dealEndTime}, d2:  new System.DateTime() {dateData = val_4.dateData});
        val_9 = null;
        val_9 = null;
        if((System.TimeSpan.op_LessThanOrEqual(t1:  new System.TimeSpan() {_ticks = val_5._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) == false)
        {
            goto label_12;
        }
        
        this.<>4__this.openButton.interactable = false;
        label_3:
        val_10 = 0;
        return (bool)val_10;
        label_2:
        this.<>1__state = 0;
        this.<>2__current = this.<>4__this.UpdateTimer();
        this.<>1__state = 2;
        val_10 = 1;
        return (bool)val_10;
        label_1:
        val_10 = 0;
        this.<>1__state = 0;
        return (bool)val_10;
        label_12:
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_10;
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
