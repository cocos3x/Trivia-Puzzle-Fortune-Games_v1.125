using UnityEngine;
private sealed class WGDailyChallengeLevelComplete.<PlayGoldenCurrencyGet>d__67 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeLevelComplete <>4__this;
    public int amount;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeLevelComplete.<PlayGoldenCurrencyGet>d__67(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_9;
        int val_10;
        val_9 = this;
        if((this.<>1__state) != 1)
        {
                val_10 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_10;
        }
        
            this.<>1__state = 0;
            val_10 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
            this.<>1__state = val_10;
            return (bool)val_10;
        }
        
        this.<>1__state = 0;
        GoldenMultiplierManager val_2 = MonoSingleton<GoldenMultiplierManager>.Instance;
        string val_4 = System.String.Format(format:  "+{0}", arg0:  val_2.currentLevelCompleteBonus.ToString());
        this.<>4__this.goldenMultiplierGroup.SetActive(value:  true);
        Player val_5 = App.Player;
        Player val_6 = App.Player;
        val_9 = val_6._stars;
        decimal val_7 = System.Decimal.op_Implicit(value:  val_9);
        this.<>4__this.goldenCurrencyAnimControl_mult.Play(fromValue:  val_5._stars - this.amount, toValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        val_10 = 0;
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
