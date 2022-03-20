using UnityEngine;
private sealed class WGAlphabetCollectionPopup.<PlayCelebrationAnimation>d__28 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGAlphabetCollectionPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGAlphabetCollectionPopup.<PlayCelebrationAnimation>d__28(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WGAlphabetCollectionPopup val_13;
        UnityEngine.Transform val_14;
        int val_15;
        val_13 = this.<>4__this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_25;
        }
        
        this.<>1__state = 0;
        val_14 = this.<>4__this.wordRegionComplete.transform;
        UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  31531.collectParticle, parent:  val_14, worldPositionStays:  false).GetComponent<UnityEngine.ParticleSystem>().Play();
        UnityEngine.WaitForSeconds val_5 = null;
        val_13 = val_5;
        val_5 = new UnityEngine.WaitForSeconds(seconds:  2.5f);
        val_15 = 1;
        this.<>2__current = val_13;
        this.<>1__state = val_15;
        return (bool)val_15;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.coinsAnim) != 0)
        {
                this.<>4__this.coinsAnim.OnCompleteCallback = new System.Action(object:  val_13, method:  System.Void WGAlphabetCollectionPopup::OnCoinsAnimFinished());
            decimal val_9 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRewardAmount;
            val_13 = this.<>4__this.coinsAnim;
            Player val_10 = App.Player;
            decimal val_11 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            val_14 = val_11.lo;
            Player val_12 = App.Player;
            val_13.Play(fromValue:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_14, mid = val_11.mid}, toValue:  new System.Decimal() {flags = val_12._credits, hi = val_12._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        }
        else
        {
                val_13.Setup();
        }
        
        label_25:
        val_15 = 0;
        return (bool)val_15;
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
