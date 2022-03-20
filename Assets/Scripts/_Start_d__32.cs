using UnityEngine;
private sealed class PiggyBankPopup.<Start>d__32 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PiggyBankPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PiggyBankPopup.<Start>d__32(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_5;
        int val_6;
        var val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_10;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_5 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_6 = 1;
        this.<>2__current = val_5;
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        val_5 = this.<>4__this;
        this.<>1__state = 0;
        val_5.SetRewardAmounts();
        if((this.<>4__this.playPreviewOnAwake) != false)
        {
                this.<>4__this.previewDirector.Play();
        }
        
        val_7 = null;
        val_7 = null;
        if((System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = this.<>4__this.dealEndTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                UnityEngine.Coroutine val_4 = val_5.StartCoroutine(routine:  val_5.UpdateTimer());
        }
        
        if((this.<>4__this.playInterstitialOnAwake) != false)
        {
                val_5.PlayInterstitialAnimation();
        }
        
        label_10:
        val_6 = 0;
        return (bool)val_6;
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
