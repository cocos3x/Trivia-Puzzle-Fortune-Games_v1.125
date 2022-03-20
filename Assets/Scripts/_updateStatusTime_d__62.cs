using UnityEngine;
private sealed class WGSubscriptionPopup.<updateStatusTime>d__62 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGSubscriptionPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGSubscriptionPopup.<updateStatusTime>d__62(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        if((this.<>1__state) >= 2)
        {
                return false;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this.gameObject.activeInHierarchy) == false)
        {
                return false;
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance.canCollectSubscription(subPackage:  this.<>4__this.subPackage)) != false)
        {
                this.<>4__this.statusObject.SetActive(value:  false);
            this.<>4__this.InitCollectPopup();
            return false;
        }
        
        System.DateTime val_6 = MonoSingleton<WGSubscriptionManager>.Instance.getNextCollectTime(subPackage:  this.<>4__this.subPackage);
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_6.dateData}, d2:  new System.DateTime() {dateData = val_7.dateData});
        string val_9 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_8._ticks}, formatted:  true);
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = 1;
        return false;
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
