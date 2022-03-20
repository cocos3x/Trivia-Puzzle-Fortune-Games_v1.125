using UnityEngine;
private sealed class ClubLevelContribution_Window.<DeferredUpdate>d__47 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Social.Leagues.ClubLevelContribution_Window <>4__this;
    public bool success;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ClubLevelContribution_Window.<DeferredUpdate>d__47(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_10;
        int val_11;
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
        val_10 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  0.25f);
        val_11 = 1;
        this.<>2__current = val_10;
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        val_10 = this.<>4__this;
        this.<>1__state = 0;
        this.<>4__this._isAwaitingResponse = false;
        if(this.success != false)
        {
                if(val_10.gameObject.activeSelf != false)
        {
                Player val_4 = App.Player;
            decimal val_5 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = this.<>4__this.ContributionAmountCredits, hi = this.<>4__this.ContributionAmountCredits, lo = X21, mid = X21});
            Player val_7 = App.Player;
            this.<>4__this.coinsGainedAnim.Play(fromValue:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}), toValue:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits, lo = val_4._credits, mid = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  this.<>4__this.contributeAnimParent, originObject:  this.<>4__this.coinsGainedAnim.AppleIcon.gameObject);
            val_10.RefreshUI(onEnable:  false);
        }
        
        }
        
        label_7:
        val_11 = 0;
        return (bool)val_11;
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
