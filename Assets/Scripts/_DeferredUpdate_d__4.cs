using UnityEngine;
private sealed class ClubLevelContribution_WindowGems.<DeferredUpdate>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.ClubLevelContribution_WindowGems <>4__this;
    public bool success;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ClubLevelContribution_WindowGems.<DeferredUpdate>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_12;
        int val_13;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_12 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  0.25f);
        val_13 = 1;
        this.<>2__current = val_12;
        this.<>1__state = val_13;
        return (bool)val_13;
        label_1:
        val_12 = this.<>4__this;
        this.<>1__state = 0;
        mem2[0] = 0;
        if(this.success != false)
        {
                if(val_12.gameObject.activeSelf != false)
        {
                Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Implicit(value:  val_4._gems);
            decimal val_6 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, d2:  new System.Decimal());
            Player val_8 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_8._gems);
            this.<>4__this.gemGainedAnim.Play(fromValue:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}), toValue:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  X24, originObject:  val_9.flags.AppleIcon.gameObject);
            val_12.RefreshUI(onEnable:  false);
        }
        
        }
        
        label_7:
        val_13 = 0;
        return (bool)val_13;
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
